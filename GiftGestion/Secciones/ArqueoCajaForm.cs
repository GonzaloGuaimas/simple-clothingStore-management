using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftGestion.Objetos;
using GiftGestion.Flotante;

namespace GiftGestion.Secciones
{
    public partial class ArqueoCajaForm : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario user = new Usuario();

        List<ArqueoCaja> arqueoCarga = new List<ArqueoCaja>();
        List<FormaPago> formaPagoCarga = new List<FormaPago>();
        List<Venta> ventasCarga = new List<Venta>();
        List<GastoDiario> cargaGastos = new List<GastoDiario>();

        List<Usuario> administradores = new List<Usuario>();
        Gmail gmail = new Gmail();


        private ArqueoCaja arqueoSeleccionado = new ArqueoCaja();

        public ArqueoCajaForm(Usuario usuario, List<Usuario> usuarios)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitializeComponent();
                user = usuario;
                administradores = usuarios;
            }
        }

        private void ArqueoCajaForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            try
            {
                precargaArqueo();
                precargarFormaPagos();
                cargarGastosDiarios();
                precargarVentas();
                textSucursal.Text = user.sucursal;
                textEmpleado.Text = user.apellido;

                cargarCajaDia();
                if (!user.sucursal.Equals("-"))
                {
                    cargarArqueo(textSucursal.Text);
                }


            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textEfectivoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void buttonActualizarArqueo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textEfeCierre.Text.Equals(""))
                {
                    buttonGeneraArqueoCaja.Enabled = false;
                    string id = arqueoSeleccionado.id;

                    await firebaseHelper.updateArqueo(id, dateFechaArqueo.Value.ToString("dd/MM/yyyy"), dateHora.Value.ToString("HH:mm"), textSucursal.Text, user.apellido + " " + user.nombre,
                        textEfectivoSistema.Text,
                        textEfeCierre.Text,
                        textEfeApertura.Text,
                        textEfeFinTM.Text,
                        textEfeExtr.Text,
                        textEfeRest.Text,
                        textEfeTotal.Text,
                        textDebito.Text,
                        textCredito.Text,
                        textTransferencia.Text,
                        textCanje.Text,
                        textCtaCte.Text,
                        textTotal.Text,
                        textDescuento.Text,
                        textComentario.Text,
                        textGastoDiario.Text);

                    MessageBox.Show("Caja Actualizada");
                    precargaArqueo();
                    cargarArqueo(textSucursal.Text);
                    clearTexts();
                    buttonGeneraArqueoCaja.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Complete Campos");
                }
            }
            catch (Exception es)
            {

            }
        }
        private void buttonGeneraArqueoCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textEfeCierre.Text.Equals(""))
                {
                    buttonGeneraArqueoCaja.Enabled = false;
                    string id = "";

                    if (buttonGeneraArqueoCaja.Text.Equals("Cerrar Caja"))
                    {
                       id = arqueoSeleccionado.id;
                    }
                    else if (buttonGeneraArqueoCaja.Text.Equals("Abrir Caja"))
                    {
                        id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    }

                    firebaseHelper.updateArqueo(id, dateFechaArqueo.Value.ToString("dd/MM/yyyy"), dateHora.Value.ToString("HH:mm"), textSucursal.Text, user.apellido + " " + user.nombre,
                        textEfectivoSistema.Text,
                        textEfeCierre.Text, 
                        textEfeApertura.Text, 
                        textEfeFinTM.Text, 
                        textEfeExtr.Text, 
                        textEfeRest.Text,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
                        textEfeTotal.Text, 
                        textDebito.Text,
                        textCredito.Text, 
                        textTransferencia.Text, 
                        textCanje.Text, 
                        textCtaCte.Text, 
                        textTotal.Text, 
                        textDescuento.Text, 
                        textComentario.Text,
                        textGastoDiario.Text);

                    if(buttonGeneraArqueoCaja.Text.Equals("Cerrar Caja"))
                    {
                        string mensaje = "<h1>Cierre Caja " + dateFechaArqueo.Value.ToString("dd/MM/yyyy") + " " + dateHora.Value.ToString("HH:mm") + " " + textSucursal.Text + " " + textEmpleado.Text + "</h1>" +
                        "<h3>Total:" + textTotal.Text + "$</h3>" +
                        "<h4>Efectivo Sistema:" + textEfectivoSistema.Text + "$</h4>" +
                        "<h4>Credito:" + textCredito.Text + "$</h4>" +
                        "<h4>Debito:" + textDebito.Text + "$</h4>" +
                        "<h4>Transferencia:" + textTransferencia.Text + "$</h4>" +
                        "<h4>Descuento:" + textDescuento.Text + "$</h4>"+
                        "<h4>Canje:" + textCanje.Text + "$</h4>"+
                        "<h4>Efectivo Cierre:" + textEfeCierre.Text + "$</h4>"+
                        "<h4>Extraccion:" + textEfeExtr.Text + "$</h4>"+
                        "<h5>Comentario:" + textComentario.Text + "</h5>";
                        gmail.EnviarMails(administradores, "Cierre Caja " + textSucursal.Text + " | " + user.apellido, mensaje);
                        MessageBox.Show("Caja Cerrada");
                    }else if (buttonGeneraArqueoCaja.Text.Equals("Abrir Caja"))
                    {
                        MessageBox.Show("Caja Abierta");
                    }

                    precargaArqueo();
                    cargarArqueo(textSucursal.Text);
                    clearTexts();
                    buttonGeneraArqueoCaja.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Complete Campos");
                }
            }catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void buttonTodas_Click(object sender, EventArgs e)
        {
            foreach (var arqueo in arqueoCarga)
            {
                dataGridArqueo.Rows.Add(arqueo.id, Convert.ToDateTime(arqueo.fecha), arqueo.hora_cierre, arqueo.sucursal, arqueo.empleado, 
                    arqueo.efectivo_sistema,
                    arqueo.efectivo_empleado,
                    arqueo.efectivo_apertura,
                    arqueo.efectivo_TM,
                    arqueo.efectivo_Extraccion,
                    arqueo.efectivo_Restante,
                     arqueo.efectivo_Total,
                                            arqueo.debito,
                                            arqueo.credito,
                                            arqueo.transferencia,
                                            arqueo.canje,
                                            arqueo.ctacte,
                                            arqueo.descuento,
                                            arqueo.gasto_diario,
                                            arqueo.total,
                                            arqueo.comentario);
            }
            dataGridArqueo.Sort(dataGridArqueo.Columns[1], System.ComponentModel.ListSortDirection.Descending);
        }
        private void buttonAgregarGasto_Click(object sender, EventArgs e)
        {
            this.Close();
            ExtraccionCaja extraccionCaja = new ExtraccionCaja(user);
            extraccionCaja.Show();
        }
        private void comboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (arqueoCarga != null)
                {
                    dataGridArqueo.Rows.Clear();
                    foreach (var arqueo in arqueoCarga)
                    {
                        if (comboSucursales.Text.Equals(arqueo.empleado))
                        {
                            dataGridArqueo.Rows.Add(arqueo.id, Convert.ToDateTime(arqueo.fecha), arqueo.hora_cierre, arqueo.sucursal, arqueo.empleado,
                                            arqueo.efectivo_sistema,
                                            arqueo.efectivo_empleado,
                                            arqueo.efectivo_apertura,
                                            arqueo.efectivo_TM,
                                            arqueo.efectivo_Extraccion,
                                            arqueo.efectivo_Restante,
                                            arqueo.efectivo_Total,
                                            arqueo.debito,
                                            arqueo.credito,
                                            arqueo.transferencia,
                                            arqueo.canje,
                                            arqueo.ctacte,
                                            arqueo.descuento,
                                            arqueo.gasto_diario,
                                            arqueo.total,
                                            arqueo.comentario);
                        }
                    }
                    dataGridArqueo.Sort(dataGridArqueo.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                }

            }
            catch (Exception es)
            {

            }
        }

        private void comboSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarArqueo(comboSucursales.Text);
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (arqueoCarga != null)
                {
                    dataGridArqueo.Rows.Clear();
                    foreach (var arqueo in arqueoCarga)
                    {
                        if (dateFecha.Value.ToString("dd/MM/yyyy").Equals(arqueo.fecha))
                        {
                            dataGridArqueo.Rows.Add(arqueo.id, Convert.ToDateTime(arqueo.fecha), arqueo.hora_cierre, arqueo.sucursal, arqueo.empleado,
                                            arqueo.efectivo_sistema,
                                            arqueo.efectivo_empleado,
                                            arqueo.efectivo_apertura,
                                            arqueo.efectivo_TM,
                                            arqueo.efectivo_Extraccion,
                                            arqueo.efectivo_Restante,
                                            arqueo.efectivo_Total,
                                            arqueo.debito,
                                            arqueo.credito,
                                            arqueo.transferencia,
                                            arqueo.canje,
                                            arqueo.ctacte,
                                            arqueo.descuento,
                                            arqueo.gasto_diario,
                                            arqueo.total,
                                            arqueo.comentario);
                        }
                    }
                }

            }
            catch (Exception es)
            {

            }
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            //cargarMontos();
        }

        private void dataGridArqueo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridArqueo.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    arqueoSeleccionado = new ArqueoCaja();

                    arqueoSeleccionado.id = dataGridArqueo.Rows[e.RowIndex].Cells[0].Value.ToString();
                    arqueoSeleccionado.fecha = dataGridArqueo.Rows[e.RowIndex].Cells[1].Value.ToString();
                    arqueoSeleccionado.hora_cierre = dataGridArqueo.Rows[e.RowIndex].Cells[2].Value.ToString();
                    arqueoSeleccionado.sucursal = dataGridArqueo.Rows[e.RowIndex].Cells[3].Value.ToString();
                    arqueoSeleccionado.empleado = dataGridArqueo.Rows[e.RowIndex].Cells[4].Value.ToString();
                    arqueoSeleccionado.efectivo_sistema = dataGridArqueo.Rows[e.RowIndex].Cells[5].Value.ToString();
                    arqueoSeleccionado.efectivo_empleado = dataGridArqueo.Rows[e.RowIndex].Cells[6].Value.ToString();

                    if (dataGridArqueo.Rows[e.RowIndex].Cells[7].Value != null)
                        arqueoSeleccionado.efectivo_apertura = dataGridArqueo.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (dataGridArqueo.Rows[e.RowIndex].Cells[8].Value != null)
                        arqueoSeleccionado.efectivo_TM = dataGridArqueo.Rows[e.RowIndex].Cells[8].Value.ToString();
                    if (dataGridArqueo.Rows[e.RowIndex].Cells[9].Value != null)
                        arqueoSeleccionado.efectivo_Extraccion = dataGridArqueo.Rows[e.RowIndex].Cells[9].Value.ToString();
                    if (dataGridArqueo.Rows[e.RowIndex].Cells[10].Value != null)
                        arqueoSeleccionado.efectivo_Restante = dataGridArqueo.Rows[e.RowIndex].Cells[10].Value.ToString();
                    if (dataGridArqueo.Rows[e.RowIndex].Cells[11].Value != null)
                        arqueoSeleccionado.efectivo_Total = dataGridArqueo.Rows[e.RowIndex].Cells[11].Value.ToString();

                    arqueoSeleccionado.debito = dataGridArqueo.Rows[e.RowIndex].Cells[12].Value.ToString();
                    arqueoSeleccionado.credito = dataGridArqueo.Rows[e.RowIndex].Cells[13].Value.ToString();
                    arqueoSeleccionado.transferencia = dataGridArqueo.Rows[e.RowIndex].Cells[14].Value.ToString();
                    arqueoSeleccionado.canje = dataGridArqueo.Rows[e.RowIndex].Cells[15].Value.ToString();
                    arqueoSeleccionado.ctacte = dataGridArqueo.Rows[e.RowIndex].Cells[16].Value.ToString();
                    arqueoSeleccionado.descuento = dataGridArqueo.Rows[e.RowIndex].Cells[17].Value.ToString();
                    if (dataGridArqueo.Rows[e.RowIndex].Cells[18].Value != null)
                        arqueoSeleccionado.gasto_diario = dataGridArqueo.Rows[e.RowIndex].Cells[18].Value.ToString();
                    arqueoSeleccionado.total = dataGridArqueo.Rows[e.RowIndex].Cells[19].Value.ToString();
                    arqueoSeleccionado.comentario = dataGridArqueo.Rows[e.RowIndex].Cells[20].Value.ToString();

                    buttonGeneraArqueoCaja.Text = "Cerrar Caja";


                    dateFechaArqueo.Value = Convert.ToDateTime(arqueoSeleccionado.fecha);
                    dateHora.Value = Convert.ToDateTime(arqueoSeleccionado.hora_cierre);
                    /*
                    textEfectivoSistema.Text = arqueoSeleccionado.efectivo_sistema;
                    textDebito.Text = arqueoSeleccionado.debito;
                    textCredito.Text = arqueoSeleccionado.credito;
                    textTransferencia.Text = arqueoSeleccionado.transferencia;
                    textDescuento.Text = arqueoSeleccionado.descuento;
                    textCanje.Text = arqueoSeleccionado.canje;
                    textCtaCte.Text = arqueoSeleccionado.ctacte;
                    textTotal.Text = arqueoSeleccionado.total;
                    */
                    textEfeApertura.Text = arqueoSeleccionado.efectivo_apertura;
                    textEfeFinTM.Text = arqueoSeleccionado.efectivo_TM;
                    textEfeCierre.Text = arqueoSeleccionado.efectivo_empleado;
                    textEfeExtr.Text = arqueoSeleccionado.efectivo_Extraccion;
                    textEfeRest.Text = arqueoSeleccionado.efectivo_Restante;
                    
                    textEfeTotal.Text = (Int32.Parse(textEfectivoSistema.Text) + Int32.Parse(textEfeApertura.Text) - Int32.Parse(textGastoDiario.Text)).ToString() ;
                    
                }
            }catch(Exception es)
            {

            }
        }


        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------

        private async void cargarGastosDiarios()
        {
            try
            {
                cargaGastos = await firebaseHelper.getAllGastoDiario();
            }catch(Exception es)
            {

            }
        }
        private void cargarArqueo(string sucursal)
        {
            try
            {
                if (arqueoCarga != null)
                {
                    dataGridArqueo.Rows.Clear();
                    foreach (var arqueo in arqueoCarga)
                    {
                        if (arqueo.sucursal.Equals(sucursal))
                        {
                            dataGridArqueo.Rows.Add(arqueo.id, Convert.ToDateTime(arqueo.fecha), arqueo.hora_cierre, arqueo.sucursal, arqueo.empleado,
                                                                   arqueo.efectivo_sistema,
                                                                   arqueo.efectivo_empleado,
                                                                   arqueo.efectivo_apertura,
                                                                   arqueo.efectivo_TM,
                                                                   arqueo.efectivo_Extraccion,
                                                                   arqueo.efectivo_Restante,
                                                                   arqueo.efectivo_Total,
                                                                   arqueo.debito,
                                                                   arqueo.credito,
                                                                   arqueo.transferencia,
                                                                   arqueo.canje,
                                                                   arqueo.ctacte,
                                                                   arqueo.descuento,
                                                                   arqueo.gasto_diario,
                                                                   arqueo.total,
                                                                   arqueo.comentario);
                        }
                    }
                    dataGridArqueo.Sort(dataGridArqueo.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                }
               
            }catch(Exception es)
            {

            }
        }

        private async void precargaArqueo()
        {
            try
            {
                arqueoCarga = new List<ArqueoCaja>();
                
                var arqueos = await firebaseHelper.getAllArqueos("Stgo del Estero");

                if (arqueos != null)
                {
                    foreach (var arqueo in arqueos)
                    {
                        arqueoCarga.Add(arqueo);
                    }
                }

                arqueos = await firebaseHelper.getAllArqueos("Galeria Palacio");

                if (arqueos != null)
                {
                    foreach (var arqueo in arqueos)
                    {
                        arqueoCarga.Add(arqueo);
                    }
                }
                arqueos = await firebaseHelper.getAllArqueos("Pueyrredon");

                if (arqueos != null)
                {
                    foreach (var arqueo in arqueos)
                    {
                        arqueoCarga.Add(arqueo);
                    }
                }
                foreach (var arqueo in arqueoCarga)
                {
                    dataGridArqueo.Rows.Add(arqueo.id, Convert.ToDateTime(arqueo.fecha), arqueo.hora_cierre, arqueo.sucursal, arqueo.empleado,
                                                           arqueo.efectivo_sistema,
                                                           arqueo.efectivo_empleado,
                                                           arqueo.efectivo_apertura,
                                                           arqueo.efectivo_TM,
                                                           arqueo.efectivo_Extraccion,
                                                           arqueo.efectivo_Restante,
                                                           arqueo.efectivo_Total,
                                                           arqueo.debito,
                                                           arqueo.credito,
                                                           arqueo.transferencia,
                                                           arqueo.canje,
                                                           arqueo.ctacte,
                                                           arqueo.descuento,
                                                           arqueo.gasto_diario,
                                                           arqueo.total,
                                                           arqueo.comentario);
                }
                dataGridArqueo.Sort(dataGridArqueo.Columns[1], System.ComponentModel.ListSortDirection.Descending);
            }
            catch (Exception es)
            {

            }
        }


        private void cargarCajaDia()
        {
            try
            {
                int efectivo = 0;
                int debito = 0;
                int credito = 0;
                int transferencia = 0;
                int canje = 0;
                int ctacte = 0;
                int descuento = 0;
                int total = 0;

                if (ventasCarga != null)
                {
                    foreach (var venta in ventasCarga)
                    {
                        if (venta.nombre_sucursal.Equals(textSucursal.Text))
                        {
                            foreach (var formaPago in formaPagoCarga)
                            {
                                if (formaPago.fecha.Equals(dateFechaArqueo.Value.ToString("dd/MM/yyyy")) && formaPago.foranea.Equals(venta.id))
                                {

                                    total = total + Int32.Parse(formaPago.monto);

                                    switch (formaPago.nombre)
                                    {
                                        case "cta cte":
                                            ctacte = ctacte + Int32.Parse(formaPago.monto);
                                            break;
                                        case "descuento":
                                            descuento = descuento + Int32.Parse(formaPago.monto);
                                            break;
                                        case "cbu":
                                            transferencia = transferencia + Int32.Parse(formaPago.monto);
                                            break;
                                        case "efectivo":
                                            efectivo = efectivo + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña efectivo":
                                            efectivo = efectivo + Int32.Parse(formaPago.monto);
                                            break;
                                        case "billetes":
                                            canje = canje + Int32.Parse(formaPago.monto);
                                            break;
                                        case "canje":
                                            canje = canje + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa debito":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña debito":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña credito":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "visa 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 1 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 3p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 6p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 12p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;


                                        case "master 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 3p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 6 c":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "maestro":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "naran 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "naran z":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "sucredito":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "mercado pago fondos":
                                            transferencia = transferencia + Int32.Parse(formaPago.monto);
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    foreach (var formaPago in formaPagoCarga)
                    {
                        if (formaPago.sucursal!=null)
                        {
                            if (formaPago.sucursal.Equals(textSucursal.Text))
                            {
                                if (formaPago.fecha.Equals(dateFechaArqueo.Value.ToString("dd/MM/yyyy")))
                                {
                                    total = total + Int32.Parse(formaPago.monto);

                                    switch (formaPago.nombre)
                                    {
                                        case "cta cte":
                                            ctacte = ctacte + Int32.Parse(formaPago.monto);
                                            break;
                                        case "descuento":
                                            descuento = descuento + Int32.Parse(formaPago.monto);
                                            break;
                                        case "cbu":
                                            transferencia = transferencia + Int32.Parse(formaPago.monto);
                                            break;
                                        case "efectivo":
                                            efectivo = efectivo + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña efectivo":
                                            efectivo = efectivo + Int32.Parse(formaPago.monto);
                                            break;
                                        case "billetes":
                                            canje = canje + Int32.Parse(formaPago.monto);
                                            break;
                                        case "canje":
                                            canje = canje + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa debito":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña debito":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña credito":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "visa 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 1 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 3p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 6p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 12p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;


                                        case "master 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 3p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 6 c":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "maestro":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "naran 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "naran z":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "sucredito":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "mercado pago fondos":
                                            transferencia = transferencia + Int32.Parse(formaPago.monto);
                                            break;
                                    }
                                }
                            }   
                        }
                      
                    }

                    textEfectivoSistema.Text = efectivo.ToString();
                    textDebito.Text = debito.ToString();
                    textCredito.Text = credito.ToString();
                    textTransferencia.Text = transferencia.ToString();
                    total = total - ctacte - canje - descuento;
                    textTotal.Text = total.ToString();
                    textCanje.Text = canje.ToString();
                    textCtaCte.Text = ctacte.ToString();
                    textDescuento.Text = descuento.ToString();

                    int gastos = 0;

                    foreach (var gasto in cargaGastos)
                    {
                        DateTime date2 = Convert.ToDateTime(gasto.fecha.Substring(0,10));
                        DateTime date1 = Convert.ToDateTime(dateFechaArqueo.Value.ToString("dd/MM/yyyy"));

                        int result = DateTime.Compare(date1, date2);
                        if (gasto.sucursal.Equals(textSucursal.Text) && result == 0)
                        {
                            gastos += Int32.Parse(gasto.monto);
                        }  
                    }
                    textGastoDiario.Text = gastos.ToString();

                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void dateFechaArqueo_ValueChanged(object sender, EventArgs e)
        {
            cargarCajaDia();
        }

        private async void precargarFormaPagos()
        {
            try
            {
                var pagos = await firebaseHelper.getAllDetalleFormaPago();

                foreach (var pago in pagos)
                {
                    formaPagoCarga.Add(pago);
                }
            }catch(Exception es)
            {

            }
        }

        private async void precargarVentas()
        {
            try
            {
                var ventas = await firebaseHelper.getAllVentas();

                foreach (var venta in ventas)
                {
                    ventasCarga.Add(venta);
                }
            }
            catch (Exception es)
            {

            }
        }



        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        private void cargarMontos()
        {
            dataGridArqueo.Rows.Clear();
            try
            {
                for (int i = 1; i<21; i++)
                {
                    int efectivo = 0;
                    int debito = 0;
                    int credito = 0;
                    int transferencia = 0;
                    int canje = 0;
                    int ctacte = 0;
                    int descuento = 0;
                    int total = 0;
                    if (ventasCarga != null)
                    {
                        foreach (var venta in ventasCarga)
                        {
                            if(venta.nombre_sucursal.Equals("Stgo del Estero"))
                            foreach (var formaPago in formaPagoCarga)
                            {
                                DateTime date1 = new DateTime(2021, 12, i, 0, 0, 0);
                                DateTime date2 = Convert.ToDateTime(formaPago.fecha);
                                int result = DateTime.Compare(date1, date2);

                                if (result == 0 && formaPago.foranea.Equals(venta.id))
                                {

                                    total = total + Int32.Parse(formaPago.monto);

                                    switch (formaPago.nombre)
                                    {
                                        case "cta cte":
                                            ctacte = ctacte + Int32.Parse(formaPago.monto);
                                            break;
                                        case "descuento":
                                            descuento = descuento + Int32.Parse(formaPago.monto);
                                            break;
                                        case "cbu":
                                            transferencia = transferencia + Int32.Parse(formaPago.monto);
                                            break;
                                        case "efectivo":
                                            efectivo = efectivo + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña efectivo":
                                            efectivo = efectivo + Int32.Parse(formaPago.monto);
                                            break;
                                        case "billetes":
                                            canje = canje + Int32.Parse(formaPago.monto);
                                            break;
                                        case "canje":
                                            canje = canje + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa debito":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña debito":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "seña credito":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "visa 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 1 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 3p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 6p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "visa 12p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "master 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 2p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 3p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "master 6 c":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "maestro":
                                            debito = debito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "naran 1p":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;
                                        case "naran z":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "sucredito":
                                            credito = credito + Int32.Parse(formaPago.monto);
                                            break;

                                        case "mercado pago fondos":
                                            transferencia = transferencia + Int32.Parse(formaPago.monto);
                                            break;
                                    }
                                }
                            }
                        }

                        textEfectivoSistema.Text = efectivo.ToString();
                        textDebito.Text = debito.ToString();
                        textCredito.Text = credito.ToString();
                        textTransferencia.Text = transferencia.ToString();
                        total = total - ctacte - canje - descuento;
                        textTotal.Text = total.ToString();
                        textCanje.Text = canje.ToString();
                        textCtaCte.Text = ctacte.ToString();
                        textDescuento.Text = descuento.ToString();


                        dataGridArqueo.Rows.Add("asd",efectivo.ToString(), debito.ToString(), credito.ToString(), transferencia.ToString(),
                            total.ToString(), canje.ToString(), ctacte.ToString(), descuento.ToString());
                    }
                }
                
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void textEfeExtr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textEfeRest.Text = (Int32.Parse(textEfeCierre.Text)- Int32.Parse(textEfeExtr.Text)).ToString();
            }
            catch(Exception es)
            {

            }
        }
        private void clearTexts()
        {
            textEfectivoSistema.Text = "0";
            textDebito.Text = "0";
            textCredito.Text = "0";
            textTransferencia.Text = "0";
            textDescuento.Text = "0";
            textCanje.Text = "0";
            textCtaCte.Text = "0";
            textTotal.Text = "0";

            textEfeApertura.Text = "0";
            textEfeFinTM.Text = "0";
            textEfeCierre.Text = "0";
            textEfeExtr.Text = "0";
            textEfeRest.Text = "0";
            textEfeTotal.Text = "0";
        }

        private void textSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

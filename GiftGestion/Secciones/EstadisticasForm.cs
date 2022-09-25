using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftGestion.Objetos;
using Microsoft.Office.Interop.Word;
using SpreadsheetLight;
using Word = Microsoft.Office.Interop.Word;

namespace GiftGestion.Secciones
{
    public partial class EstadisticasForm : Form
    {
        Usuario user = new Usuario();

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<FormaPago> formasPagos = new List<FormaPago>();
        List<FormaPago> formasPagosSucursales = new List<FormaPago>();
        List<ArqueoCaja> arqueos = new List<ArqueoCaja>();
        List<Venta> ventas = new List<Venta>();
        List<Cliente> clientes = new List<Cliente>();

        List<Producto> productos = new List<Producto>();
        List<Producto> productosVendidos = new List<Producto>();

        List<Remito> remitos = new List<Remito>();
        List<Producto> detalleRemitos = new List<Producto>();
        List<GastoDiario> cargaGastos = new List<GastoDiario>();

        List<Cambio> cambios = new List<Cambio>();
        List<Producto> detalleCambio = new List<Producto>();

        public List<Producto> prods = new List<Producto>();
        public List<Grupo> grupos = new List<Grupo>();

        private string rutaModeloExcel = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/stats.xlsx";
        private string rutaModeloPDF = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/stats.docx";
        private string rutaSalidaEstadisticas = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Estadisticas/";

        Color grey = Color.FromArgb(153, 149, 149);


        private int cantVentas = 0;
        private int cantProdsVend = 0;
        private int cantBrutoVent = 0;
        private int cantGanVent = 0;

        private int cantVentasPuey = 0;
        private int cantProdsVendPuey = 0;
        private int cantBrutoVentPuey = 0;
        private int cantGanVentPuey = 0;

        private int cantVentasStgo = 0;
        private int cantProdsVendStgo = 0;
        private int cantBrutoVentStgo = 0;
        private int cantGanVentStgo = 0;


        private int cantChanampa = 0;
        private int brutoChanampa = 0;

        private int cantZapata = 0;
        private int brutoZapata = 0;
        
        private int cantVon = 0;
        private int brutoVon = 0;

        private int cantVillareal = 0;
        private int brutoVillareal = 0;

        private int cantCollado = 0;
        private int brutoCollado = 0;

        private int cantRobles = 0;
        private int brutoRobles = 0;

        private int cantOtro= 0;
        private int brutoOtro = 0;
        public EstadisticasForm(Usuario usuario)
        {
           
            InitializeComponent();
            user = usuario;
        }

        private void EstadisticasForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cargarDatos();
        }

        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------

        private async void cargarDatos()
        {
            textTitulo.Text = "Cargando Datos";
            comboAño.Enabled = false;
            comboMesSeleccionado.Enabled = false;

            comboMesSeleccionado.Text = DateTime.Now.ToString("MM");
            cargaGastos = await firebaseHelper.getAllGastoDiario();
            ventas = await firebaseHelper.getAllVentas();
            productosVendidos = await firebaseHelper.getAllDetalleVenta();
            cambios = await firebaseHelper.getAllCambios();
            detalleCambio = await firebaseHelper.getAllDetalleCambio();
            remitos = await firebaseHelper.getAllRemitos();
            detalleRemitos = await firebaseHelper.getAllDetalleRemito();
            formasPagos = await firebaseHelper.getAllDetalleFormaPago();
            clientes = await firebaseHelper.getAllClientes();
            productos = await firebaseHelper.getAllProductos();
            prods = await firebaseHelper.getAllDetalleVenta();
            grupos = await firebaseHelper.getAllGrupos();

            textTitulo.Text = "ESTADISTICAS";
            comboAño.Enabled = true;
            comboMesSeleccionado.Enabled = true;

            cargarArqueosConSucursal();
        }
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        private void comboMesPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridFormasPagos.Rows.Clear();
            foreach (var forma in formasPagos)
            {
                if (forma.fecha.Substring(3, 2).Equals(comboMesPago.Text) && forma.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridFormasPagos.Rows.Add(forma.fecha, forma.nombre, forma.monto);
                }
            }

            calcularMontosFormaPago();
        }
        private void comboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridFormasPagos.Rows.Clear();
            foreach (var forma in formasPagos)
            {
                if (forma.fecha.Substring(3, 2).Equals(comboMesPago.Text) && forma.nombre.Equals(comboTipoPago.Text) && forma.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridFormasPagos.Rows.Add(forma.fecha, forma.nombre, forma.monto);
                }
            }

            calcularMontosFormaPago();
        }

        private void comboSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridFormasPagos.Rows.Clear();
                foreach (var forma in formasPagosSucursales)
                {
                    if (forma.fecha.Substring(3, 2).Equals(comboMesPago.Text) && forma.sucursal.Equals(comboSucursales.Text) && forma.fecha.Substring(6, 4).Equals(comboAño.Text))
                    {
                        dataGridFormasPagos.Rows.Add(forma.fecha, forma.nombre, forma.monto);
                    }
                }
                calcularMontosFormaPago();
            }
            catch(Exception es)
            {

            }
           

            
        }
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------

        private void comboMesVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (venta.fecha.Substring(3, 2).Equals(comboMesVentas.Text) && venta.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridVentas.Rows.Add(venta.fecha, venta.nombre_sucursal, venta.total,venta.ganancia,venta.tipo_pago);
                }
            }
            foreach (var venta in cambios)
            {
                if (venta.fecha.Substring(3, 2).Equals(comboMesVentas.Text) && venta.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridVentas.Rows.Add(venta.fecha, venta.nombre_sucursal, venta.total, venta.ganancia, venta.tipo_pago);
                }
            }

            calcularMontosVentas();
        }

        private void comboSucursalVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (venta.fecha.Substring(3, 2).Equals(comboMesVentas.Text) && venta.nombre_sucursal.Equals(comboSucursalVentas.Text) && venta.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridVentas.Rows.Add(venta.fecha, venta.nombre_sucursal, venta.total, venta.ganancia, venta.tipo_pago);
                }
            }
            foreach (var venta in cambios)
            {
                if (venta.fecha.Substring(3, 2).Equals(comboMesVentas.Text) && venta.nombre_sucursal.Equals(comboSucursalVentas.Text) && venta.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridVentas.Rows.Add(venta.fecha, venta.nombre_sucursal, venta.total, venta.ganancia, venta.tipo_pago);
                }
            }
            calcularMontosVentas();
        }

        private void comboTipoPagoVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (venta.fecha.Substring(3, 2).Equals(comboMesVentas.Text) && venta.tipo_pago.Equals(comboTipoPago.Text) && venta.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridVentas.Rows.Add(venta.fecha, venta.nombre_sucursal, venta.total, venta.ganancia, venta.tipo_pago);
                }
            }
            foreach (var venta in cambios)
            {
                if (venta.fecha.Substring(3, 2).Equals(comboMesVentas.Text) && venta.tipo_pago.Equals(comboTipoPago.Text) && venta.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridVentas.Rows.Add(venta.fecha, venta.nombre_sucursal, venta.total, venta.ganancia, venta.tipo_pago);
                }
            }
            calcularMontosVentas();
        }



        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        private void comboMesArqueo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridArqueo.Rows.Clear();
            foreach (var arqueo in arqueos)
            {
                if (arqueo.fecha.Substring(3, 2).Equals(comboMesArqueo.Text) && arqueo.fecha.Substring(6, 4).Equals(comboAño.Text))
                {
                    dataGridArqueo.Rows.Add(arqueo.fecha, arqueo.efectivo_sistema, arqueo.debito, arqueo.credito, arqueo.transferencia, arqueo.canje
                        , arqueo.ctacte, arqueo.descuento, arqueo.sucursal);
                }
            }

            calcularMontosArqueo();
        }
        private void comboTipoPagoArqueo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboSucursalArqueo_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            dataGridArqueo.Rows.Clear();
            foreach (var arqueo in arqueos)
            {
                if (arqueo.fecha.Substring(3, 2).Equals(comboMesArqueo.Text) && arqueo.sucursal.Equals(comboSucursalArqueo.Text))
                {
                    dataGridArqueo.Rows.Add(arqueo.fecha, arqueo.efectivo_sistema, arqueo.debito, arqueo.credito, arqueo.transferencia, arqueo.canje
                        ,arqueo.ctacte, arqueo.descuento, arqueo.sucursal);
                }
            }
            */
            //calcularMontosArqueo();
        }
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        private void comboSeleccionarMesProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridGrupos.Rows.Clear();
            int total = 0;
            foreach (var grupo in grupos)
            {
                dataGridGrupos.Rows.Add(grupo.nombre_grupo, 0);
            }
            foreach (DataGridViewRow row in dataGridGrupos.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    foreach (var venta in ventas)
                    {
                        if (Int32.Parse(venta.fecha.Substring(3, 2)) == Int32.Parse(comboSeleccionarMesProductos.Text))
                        {
                            foreach (var prod in prods)
                            {
                                if (venta.id.Equals(prod.foranea) && row.Cells[0].Value.ToString().Equals(prod.grupo))
                                {
                                    row.Cells[1].Value =  Int32.Parse(row.Cells[1].Value.ToString()) + 1 ;
                                }
                                else if (venta.id.Equals(prod.foranea))
                                {
                                    total++;
                                }
                            }
                        }
                       
                    }
                }
            }
            textTotalProds.Text = "Total Prods Vendidos: " + total;
        }
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        private void calcularMontosVentas()
        {
            int total = 0;
            int ganancias = 0;


            chart.Series["Efectivo"].Enabled = false;
            chart.Series["Efectivo"].Points.Clear();

            chart.Series["Debito"].Enabled = false;
            chart.Series["Debito"].Points.Clear();

            chart.Series["Credito"].Enabled = false;
            chart.Series["Credito"].Points.Clear();

            chart.Series["transferencia"].Enabled = false;
            chart.Series["transferencia"].Points.Clear();

            chart.Series["canje"].Enabled = false;
            chart.Series["canje"].Points.Clear();

            chart.Series["cta cte"].Enabled = false;
            chart.Series["cta cte"].Points.Clear();

            chart.Series["descuento"].Enabled = false;
            chart.Series["descuento"].Points.Clear();

            chart.Series["Pagos"].Enabled = false;
            chart.Series["Pagos"].Points.Clear();

            chart.Series["Ganancia"].Enabled = true;
            chart.Series["Ganancia"].Points.Clear();


       

            foreach (DataGridViewRow row in dataGridVentas.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    total += Int32.Parse(row.Cells[2].Value.ToString());
                    ganancias += Int32.Parse(row.Cells[3].Value.ToString());

                    chart.Series["Ganancia"].Points.AddXY(row.Cells[0].Value.ToString(), Int32.Parse(row.Cells[3].Value.ToString()));

                }
            }
            textGananciasVentas.Text ="Ganancias: $" +agregarPuntos(ganancias.ToString());
            textBrutoVentas.Text = "Bruto: $" + total.ToString();
            textCantidadVentas.Text = (dataGridVentas.Rows.Count-1).ToString();


        }
        private void calcularMontosFormaPago()
        {
            int total = 0;
            int efectivo = 0;
            int debito = 0;
            int credito = 0;
            int transferencia = 0;
            int canje = 0;
            int ctacte = 0;
            int descuento = 0;
            foreach (DataGridViewRow row in dataGridFormasPagos.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    switch (row.Cells[1].Value.ToString())
                    {
                        case "cta cte":
                            ctacte = ctacte + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "descuento":
                            descuento = descuento + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "cbu":
                            transferencia = transferencia + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "efectivo":
                            efectivo = efectivo + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "seña efectivo":
                            efectivo = efectivo + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "billetes":
                            canje = canje + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "canje":
                            canje = canje + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "visa debito":
                            debito = debito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "seña debito":
                            debito = debito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "seña credito":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;

                        case "visa 1p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "visa 1 2p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "visa 2p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "visa 3p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "visa 6p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "visa 12p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "master 1p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "master 2p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "master 3p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "master 6 c":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;

                        case "maestro":
                            debito = debito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "naran 1p":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                        case "naran z":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;

                        case "sucredito":
                            credito = credito + Int32.Parse(row.Cells[2].Value.ToString());
                            break;

                        case "mercado pago fondos":
                            transferencia = transferencia + Int32.Parse(row.Cells[2].Value.ToString());
                            break;
                    }

                    total += Int32.Parse(row.Cells[2].Value.ToString());
                }
            }
            chart.Series["Pagos"].Enabled = true;
            chart.Series["Pagos"].Points.Clear();
            var area = chart.ChartAreas[0];
            area.AxisX.Maximum = 10;


            chart.Series["Efectivo"].Enabled = false;
            chart.Series["Efectivo"].Points.Clear();

            chart.Series["Debito"].Enabled = false;
            chart.Series["Debito"].Points.Clear();

            chart.Series["Credito"].Enabled = false;
            chart.Series["Credito"].Points.Clear();

            chart.Series["transferencia"].Enabled = false;
            chart.Series["transferencia"].Points.Clear();

            chart.Series["canje"].Enabled = false;
            chart.Series["canje"].Points.Clear();

            chart.Series["cta cte"].Enabled = false;
            chart.Series["cta cte"].Points.Clear();

            chart.Series["descuento"].Enabled = false;
            chart.Series["descuento"].Points.Clear();

            chart.Series["Pagos"].Points.AddXY("-", 0); 

            chart.Series["Pagos"].Points.AddXY("efectivo", efectivo);
            chart.Series["Pagos"].Points[1].Label = "$" + agregarPuntos(efectivo.ToString());

            chart.Series["Pagos"].Points.AddXY("debito", debito);
            chart.Series["Pagos"].Points[2].Label = "$" + agregarPuntos(debito.ToString());

            chart.Series["Pagos"].Points.AddXY("credito", credito);
            chart.Series["Pagos"].Points[3].Label = "$" + agregarPuntos(credito.ToString());

            chart.Series["Pagos"].Points.AddXY("transferencia", transferencia);
            chart.Series["Pagos"].Points[4].Label = "$" + agregarPuntos(transferencia.ToString());

            chart.Series["Pagos"].Points.AddXY("canje", canje);
            chart.Series["Pagos"].Points[5].Label = "$" + agregarPuntos(canje.ToString());

            chart.Series["Pagos"].Points.AddXY("cta cte", ctacte);
            chart.Series["Pagos"].Points[6].Label = "$" + agregarPuntos(ctacte.ToString());

            chart.Series["Pagos"].Points.AddXY("descuento", descuento);
            chart.Series["Pagos"].Points[7].Label = "$" + agregarPuntos(descuento.ToString());

            /*
            chart.Series["Pagos"].Points[0].Color = grey;
            chart.Series["Pagos"].Points[1].Color = grey;
            chart.Series["Pagos"].Points[2].Color = grey;
            chart.Series["Pagos"].Points[3].Color = grey;
            chart.Series["Pagos"].Points[4].Color = grey;
            chart.Series["Pagos"].Points[5].Color = grey;
            chart.Series["Pagos"].Points[6].Color = grey;
            */

            int ganancias = total - descuento - canje - ctacte;
            textTotalPagos.Text = "Bruto: $" + agregarPuntos(total.ToString());
            textGananciaPagos.Text = "Total: $" + agregarPuntos(ganancias.ToString());

            textEfectivo.Text = "Efectivo: $" + agregarPuntos(efectivo.ToString());
            textDebito.Text = "Debito: $" + agregarPuntos(debito.ToString());
            textCredito.Text = "Credito: $" + agregarPuntos(credito.ToString());
            textTransferencia.Text = "Transferencia: $" + agregarPuntos(transferencia.ToString());
            textCanje.Text = "Canje: $" + agregarPuntos(canje.ToString());
            textCtaCte.Text = "Cta Cte: $" + agregarPuntos(ctacte.ToString());
            textDescuento.Text = "Descuento: $" + agregarPuntos(descuento.ToString());
        }
        private void calcularMontosArqueo()
        {
            var area = chart.ChartAreas[0];

            area.AxisX.Maximum = 31;

            chart.Series["Pagos"].Enabled = false;

            chart.Series["Efectivo"].Enabled = true;
            chart.Series["Efectivo"].Points.Clear();

            chart.Series["Debito"].Enabled = true;
            chart.Series["Debito"].Points.Clear();

            chart.Series["Credito"].Enabled = true;
            chart.Series["Credito"].Points.Clear();

            chart.Series["transferencia"].Enabled = true;
            chart.Series["transferencia"].Points.Clear();

            chart.Series["canje"].Enabled = true;
            chart.Series["canje"].Points.Clear();

            chart.Series["cta cte"].Enabled = true;
            chart.Series["cta cte"].Points.Clear();

            chart.Series["descuento"].Enabled = true;
            chart.Series["descuento"].Points.Clear();

            int total = 0;
            int efectivo = 0;
            int debito = 0;
            int credito = 0;
            int transferencia = 0;
            int canje = 0;
            int ctacte = 0;
            int descuento = 0;

            foreach (DataGridViewRow row in dataGridArqueo.Rows)
            {
                if (row.Cells[0].Value!=null)
                {
                    efectivo += Int32.Parse(row.Cells[1].Value.ToString());
                    debito += Int32.Parse(row.Cells[2].Value.ToString());
                    credito += Int32.Parse(row.Cells[3].Value.ToString());
                    transferencia += Int32.Parse(row.Cells[4].Value.ToString());
                    canje += Int32.Parse(row.Cells[5].Value.ToString());
                    ctacte += Int32.Parse(row.Cells[6].Value.ToString());
                    descuento += Int32.Parse(row.Cells[7].Value.ToString());

                    chart.Series["Efectivo"].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                    chart.Series["Efectivo"].Points[0].Label = "$" + row.Cells[1].Value.ToString();

                    chart.Series["Debito"].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString());
                    chart.Series["Debito"].Points[0].Label = "$" + row.Cells[2].Value.ToString();

                    chart.Series["Credito"].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                    chart.Series["Credito"].Points[0].Label = "$" + row.Cells[3].Value.ToString();

                    chart.Series["transferencia"].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[4].Value.ToString());
                    chart.Series["transferencia"].Points[0].Label = "$" + row.Cells[4].Value.ToString();

                    chart.Series["canje"].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[5].Value.ToString());
                    chart.Series["canje"].Points[0].Label = "$" + row.Cells[5].Value.ToString();

                    chart.Series["cta cte"].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[6].Value.ToString());
                    chart.Series["cta cte"].Points[0].Label = "$" + row.Cells[6].Value.ToString();

                    chart.Series["descuento"].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[7].Value.ToString());
                    chart.Series["descuento"].Points[0].Label = "$" + row.Cells[7].Value.ToString();
                }
            }
            total = efectivo+debito + credito + transferencia + canje + ctacte + descuento;
            int ganancias = total - canje - descuento - ctacte;

            textTotalArqueo.Text = "Bruto: $" + agregarPuntos(total.ToString());
            textGananciaArqueo.Text = "Total: $" + agregarPuntos(ganancias.ToString());
        }

        private void cargarArqueosConSucursal()
        {
            foreach (var venta in ventas)
            {
                foreach (var forma in formasPagos)
                {
                    if (forma.foranea.Equals(venta.id))
                    {
                        forma.sucursal = venta.nombre_sucursal;
                        formasPagosSucursales.Add(forma);
                    }
                }
            }
            foreach (var cambio in cambios)
            {
                foreach (var forma in formasPagos)
                {
                    if (forma.foranea.Equals(cambio.id))
                    {
                        forma.sucursal = cambio.nombre_sucursal;
                        formasPagosSucursales.Add(forma);
                    }
                }
            }
            foreach (var cliente in clientes)
            {
                foreach (var forma in formasPagos)
                {
                    if (cliente.dnicuit.Equals(forma.foranea))
                    {
                        formasPagosSucursales.Add(forma);
                    }
                }
            }

            cargarArqueos();
        }
        private void cargarArqueos()
        {

            try
            {
                DateTime inicio = new DateTime(2021, 10, 12, 0, 0, 0);
                DateTime fin = DateTime.Now;
                DateTime temp = inicio;
                Boolean band = false;
                while (temp < fin)
                {
                    int efectivo = 0;
                    int debito = 0;
                    int credito = 0;
                    int transferencia = 0;
                    int canje = 0;
                    int ctacte = 0;
                    int descuento = 0;
                    int total = 0;
                    ArqueoCaja arqueo = new ArqueoCaja();

                    foreach (var formaPago in formasPagosSucursales)
                    {
                        DateTime date2 = Convert.ToDateTime(formaPago.fecha);
                        
                        int result = DateTime.Compare(temp, date2);
                        if (result == 0)
                        {
                            arqueo.fecha = date2.ToString("dd/MM/yyyy");
                            //arqueo.sucursal = formaPago.sucursal;
                            total = total + Int32.Parse(formaPago.monto);
                            band = true;
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
                    if (band)
                    {
                        arqueo.efectivo_sistema = efectivo.ToString();
                        arqueo.debito = debito.ToString();
                        arqueo.credito = credito.ToString();
                        arqueo.transferencia = transferencia.ToString();
                        arqueo.canje = canje.ToString();
                        arqueo.ctacte = ctacte.ToString();
                        arqueo.descuento = descuento.ToString();

                        arqueos.Add(arqueo);
                    }
                    temp = temp.AddDays(1);
                    band = false;

                }
           }
           catch (Exception es) 
           {
                MessageBox.Show(es.Message);
           }
        }


        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------


        private string agregarPuntos(string numero)
        {
            string num = "";
            try
            {
                int nroNum = Convert.ToInt32(numero);
                num = nroNum.ToString("N0");
            }
            catch (Exception es)
            {

            }
            return num;
        }





        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------



        private void buttonExportar_Click(object sender, EventArgs e)
        {
            generarExcel();
        }
        private void buttonExportarPDF_Click(object sender, EventArgs e)
        {
            generarPDF();
        }

        private void generarPDF()
        {
            CreateWordDocument(rutaModeloPDF, rutaSalidaEstadisticas + "Gift" + comboMesSeleccionado.Text + ".pdf");
        }
        private void generarExcel()
        {
            try
            {
                buttonExportar.Enabled = false;
                buttonExportar.Text = "Espere porfavor...";
                SLDocument sl = new SLDocument(rutaModeloExcel);
                int j = 1;
                int k = 1;
                int l = 1;

                sl.SetCellValue("B" + j.ToString(), "ID");
                sl.SetCellValue("C" + j.ToString(), "FECHA");
                sl.SetCellValue("D" + j.ToString(), "EMPLEADO");
                sl.SetCellValue("E" + j.ToString(), "CLIENTE");
                sl.SetCellValue("F" + j.ToString(), "SUCURSAL");
                sl.SetCellValue("G" + j.ToString(), "OBSERVACION");
                sl.SetCellValue("I" + j.ToString(), "FECHA");
                sl.SetCellValue("J" + j.ToString(), "NOMBRE");
                sl.SetCellValue("K" + j.ToString(), "MONTO");
                sl.SetCellValue("M" + j.ToString(), "ID PROD");
                sl.SetCellValue("N" + j.ToString(), "NOMBRE");
                sl.SetCellValue("O" + j.ToString(), "DESCRIPCION");
                sl.SetCellValue("P" + j.ToString(), "TALLE");
                sl.SetCellValue("Q" + j.ToString(), "COLOR");
                sl.SetCellValue("R" + j.ToString(), "GRUPO");
                sl.SetCellValue("S" + j.ToString(), "PRECIO");
                sl.SetCellValue("T" + j.ToString(), "COSTO");
                j++;
                k++;
                l++;
                foreach (var venta in ventas)
                {
                    string mes = venta.fecha.Substring(3, 2);
                    string año = venta.fecha.Substring(6, 4);
                    if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                    {
                        int cont = 0;
                        sl.SetCellValue("B" + j.ToString(), venta.id);
                        sl.SetCellValue("C" + j.ToString(), venta.fecha);
                        sl.SetCellValue("D" + j.ToString(), venta.nombre_empleado);
                        sl.SetCellValue("E" + j.ToString(), venta.nombre_cliente);
                        sl.SetCellValue("F" + j.ToString(), venta.nombre_sucursal);
                        sl.SetCellValue("G" + j.ToString(), venta.observacion);
                        k = j + cont;
                        l = j + cont;
                        foreach (var forma in formasPagos)
                        {
                            if (forma.foranea.Equals(venta.id))
                            {
                                sl.SetCellValue("I" + k.ToString(), forma.fecha);
                                sl.SetCellValue("J" + k.ToString(), forma.nombre);
                                sl.SetCellValue("K" + k.ToString(), Int32.Parse(forma.monto));
                                k++;
                                cont++;
                            }
                        }
                        foreach (var prod in productosVendidos)
                        {
                            if (venta.id.Equals(prod.foranea))
                            {
                                sl.SetCellValue("M" + l.ToString(), prod.id);
                                sl.SetCellValue("N" + l.ToString(), prod.nombre_articulo);
                                sl.SetCellValue("O" + l.ToString(), prod.descripcion);
                                sl.SetCellValue("P" + l.ToString(), prod.talle);
                                sl.SetCellValue("Q" + l.ToString(), prod.color);
                                sl.SetCellValue("R" + l.ToString(), prod.grupo);
                                sl.SetCellValue("S" + l.ToString(), Int32.Parse(prod.precio));
                                sl.SetCellValue("T" + l.ToString(), Int32.Parse(prod.costo));
                                l++;
                                cont++;
                            }
                        }
                        j = j + cont;
                        j++;
                    }
                    
                }





                sl.AddWorksheet("Prod Vendidos");
                j = 1;
                sl.SetCellValue("B" + j.ToString(), "ID");
                sl.SetCellValue("C" + j.ToString(), "NOMBRE");
                sl.SetCellValue("D" + j.ToString(), "DESCRIPCION");
                sl.SetCellValue("E" + j.ToString(), "ID VENTA");
                sl.SetCellValue("F" + j.ToString(), "GRUPO");
                sl.SetCellValue("G" + j.ToString(), "COSTO");
                sl.SetCellValue("H" + j.ToString(), "PRECIO");
                j++;
                foreach (var producto in productosVendidos)
                {
                    string mes = producto.foranea.Substring(2,2);
                    string año = producto.foranea.Substring(4, 4);
                    if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                    {
                        sl.SetCellValue("B" + j.ToString(), producto.id);
                        sl.SetCellValue("C" + j.ToString(), producto.nombre_articulo);
                        sl.SetCellValue("D" + j.ToString(), producto.descripcion);
                        sl.SetCellValue("E" + j.ToString(), producto.foranea);
                        sl.SetCellValue("F" + j.ToString(), producto.grupo);
                        sl.SetCellValue("G" + j.ToString(), Int32.Parse(producto.costo));
                        sl.SetCellValue("H" + j.ToString(), Int32.Parse(producto.precio));
                        j++;
                    }
                }

                
                sl.AddWorksheet("Pagos");

                j = 1;
                sl.SetCellValue("B" + j.ToString(), "ID VENTA");
                sl.SetCellValue("C" + j.ToString(), "FECHA");
                sl.SetCellValue("D" + j.ToString(), "MONTO");
                sl.SetCellValue("E" + j.ToString(), "NOMBRE");
                j++;
                foreach (var forma in formasPagos)
                {
                    string mes = forma.fecha.Substring(3, 2);
                    string año = forma.fecha.Substring(6, 4);

                    if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                    {
                        sl.SetCellValue("B" + j.ToString(), forma.foranea);
                        sl.SetCellValue("C" + j.ToString(), forma.fecha);
                        sl.SetCellValue("D" + j.ToString(), Int32.Parse(forma.monto));
                        sl.SetCellValue("E" + j.ToString(), forma.nombre);
                        j++;
                    }
                }

                sl.AddWorksheet("Remitos Entrada");

                j = 1;
                sl.SetCellValue("B" + j.ToString(), "ID");
                sl.SetCellValue("C" + j.ToString(), "NOMBRE");
                sl.SetCellValue("D" + j.ToString(), "DESCRIPCION");
                sl.SetCellValue("E" + j.ToString(), "ID VENTA");
                sl.SetCellValue("F" + j.ToString(), "GRUPO");
                sl.SetCellValue("G" + j.ToString(), "COSTO");
                sl.SetCellValue("H" + j.ToString(), "LISTA");
                sl.SetCellValue("J" + j.ToString(), "EFECTIVO");
                sl.SetCellValue("K" + j.ToString(), "CANTIDAD");
                sl.SetCellValue("L" + j.ToString(), "OBSERVACION");
                sl.SetCellValue("M" + j.ToString(), "FECHA");
                j++;
                foreach (var remito in remitos)
                {
                    string mes = remito.fecha.Substring(3, 2);
                    string año = remito.fecha.Substring(6, 4);
                    if (remito.tipo.Equals("Entrada") && mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                    {
                        foreach (var producto in detalleRemitos)
                        {
                            if (producto.foranea.Equals(remito.id))
                            {
                                sl.SetCellValue("B" + j.ToString(), producto.id);
                                sl.SetCellValue("C" + j.ToString(), producto.nombre_articulo);
                                sl.SetCellValue("D" + j.ToString(), producto.descripcion);
                                sl.SetCellValue("E" + j.ToString(), producto.foranea);
                                sl.SetCellValue("F" + j.ToString(), producto.grupo);
                                sl.SetCellValue("G" + j.ToString(), Int32.Parse(producto.costo));
                                sl.SetCellValue("H" + j.ToString(), Int32.Parse(producto.precio_lista));
                                sl.SetCellValue("J" + j.ToString(), Int32.Parse(producto.precio_efectivo));
                                sl.SetCellValue("K" + j.ToString(), Int32.Parse(producto.cantidad));
                                sl.SetCellValue("L" + j.ToString(), remito.observacion);
                                sl.SetCellValue("M" + j.ToString(), remito.fecha);
                                j++;
                            }
                        }
                    }
                }

                //----------------------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------------------

                sl.AddWorksheet("Prod Vendidos fecha y Sucursal");
                j = 1;
                sl.SetCellValue("B" + j.ToString(), "ID");
                sl.SetCellValue("C" + j.ToString(), "NOMBRE");
                sl.SetCellValue("D" + j.ToString(), "DESCRIPCION");
                sl.SetCellValue("E" + j.ToString(), "ID VENTA");
                sl.SetCellValue("F" + j.ToString(), "GRUPO");
                sl.SetCellValue("G" + j.ToString(), "COSTO");
                sl.SetCellValue("H" + j.ToString(), "PRECIO");
                sl.SetCellValue("I" + j.ToString(), "FECHA");
                sl.SetCellValue("J" + j.ToString(), "SUCURSAL");
                j++;
                foreach (var venta in ventas)
                {
                    string mes = venta.fecha.Substring(3, 2);
                    string año = venta.fecha.Substring(6, 4);
                    if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                    {
                        foreach (var producto in productosVendidos)
                        {
                            if (venta.id.Equals(producto.foranea))
                            {
                                sl.SetCellValue("B" + j.ToString(), producto.id);
                                sl.SetCellValue("C" + j.ToString(), producto.nombre_articulo);
                                sl.SetCellValue("D" + j.ToString(), producto.descripcion);
                                sl.SetCellValue("E" + j.ToString(), producto.foranea);
                                sl.SetCellValue("F" + j.ToString(), producto.grupo);
                                sl.SetCellValue("G" + j.ToString(), Int32.Parse(producto.costo));
                                sl.SetCellValue("H" + j.ToString(), Int32.Parse(producto.precio));
                                sl.SetCellValue("I" + j.ToString(),venta.fecha);
                                sl.SetCellValue("J" + j.ToString(), venta.nombre_sucursal);
                                j++;
                            }
                        }
                    }
                }



                sl.AddWorksheet("Remitos Salida");

                j = 1;
                sl.SetCellValue("B" + j.ToString(), "ID");
                sl.SetCellValue("C" + j.ToString(), "NOMBRE");
                sl.SetCellValue("D" + j.ToString(), "DESCRIPCION");
                sl.SetCellValue("E" + j.ToString(), "ID VENTA");
                sl.SetCellValue("F" + j.ToString(), "GRUPO");
                sl.SetCellValue("G" + j.ToString(), "COSTO");
                sl.SetCellValue("H" + j.ToString(), "LISTA");
                sl.SetCellValue("J" + j.ToString(), "EFECTIVO");
                sl.SetCellValue("K" + j.ToString(), "CANTIDAD");
                sl.SetCellValue("L" + j.ToString(), "OBSERVACION");
                sl.SetCellValue("M" + j.ToString(), "FECHA");
                sl.SetCellValue("N" + j.ToString(), "DESTINO");
                j++;
                foreach (var remito in remitos)
                {
                    string mes = remito.fecha.Substring(3, 2);
                    string año = remito.fecha.Substring(6, 4);
                    if (remito.tipo.Equals("Salida") && mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                    {
                        foreach (var producto in detalleRemitos)
                        {
                            if (producto.foranea.Equals(remito.id))
                            {
                                sl.SetCellValue("B" + j.ToString(), producto.id);
                                sl.SetCellValue("C" + j.ToString(), producto.nombre_articulo);
                                sl.SetCellValue("D" + j.ToString(), producto.descripcion);
                                sl.SetCellValue("E" + j.ToString(), producto.foranea);
                                sl.SetCellValue("F" + j.ToString(), producto.grupo);
                                sl.SetCellValue("G" + j.ToString(), Int32.Parse(producto.costo));
                                sl.SetCellValue("H" + j.ToString(), Int32.Parse(producto.precio_lista));
                                sl.SetCellValue("J" + j.ToString(), Int32.Parse(producto.precio_efectivo));
                                sl.SetCellValue("K" + j.ToString(), Int32.Parse(producto.cantidad));
                                sl.SetCellValue("L" + j.ToString(), remito.observacion);
                                sl.SetCellValue("M" + j.ToString(), remito.fecha);
                                sl.SetCellValue("N" + j.ToString(), remito.destino);
                                j++;
                            }
                        }
                    }
                }
                //----------------------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------------------


                sl.SaveAs(rutaSalidaEstadisticas + "Gift " +comboMesSeleccionado.Text+ ".xlsx");

                MessageBox.Show("Se Exportaron Estadisticas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonExportar.Enabled = true;
                buttonExportar.Text = "Exportar Excel";
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
                buttonExportar.Enabled = true;
                buttonExportar.Text = "Exportar Excel";
            }
        }



















        



















        private void CreateWordDocument(object filename, object SaveAs)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;
            try
            {
                if (File.Exists((string)filename))
                {
                    buttonExportarPDF.Enabled = false;
                    buttonExportarPDF.Text = "Espere pofavor...";
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;
                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
                    myWordDoc.Activate();

                    int efectivo = 0;
                    int debito = 0;
                    int credito = 0;
                    int transferencia = 0;
                    int canje = 0;
                    int ctacte = 0;
                    int descuento = 0;
                    int gastos = 0;
                    int total = 0;

                    foreach (var gasto in cargaGastos)
                    {
                        string mes = gasto.fecha.Substring(3, 2);
                        string año = gasto.fecha.Substring(6, 4);
                        if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                        {
                            gastos += Int32.Parse(gasto.monto);
                        }
                    }

                    foreach (var venta in ventas)
                    {
                        string mes = venta.fecha.Substring(3, 2);
                        string año = venta.fecha.Substring(6, 4);
                        if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                        {
                            if (venta.nombre_empleado.Equals("Robles Carla"))
                            {
                                cantRobles++;
                                brutoRobles += Int32.Parse(venta.total);
                            }
                            else if (venta.nombre_empleado.Equals("Collado Juliana"))
                            {
                                cantCollado++;
                                brutoCollado += Int32.Parse(venta.total);
                            }
                            else if (venta.nombre_empleado.Equals("Villareal Marianela"))
                            {
                                cantVillareal++;
                                brutoVillareal += Int32.Parse(venta.total);
                            }
                            else if (venta.nombre_empleado.Equals("Zapata Martin"))
                            {
                                cantZapata++;
                                brutoZapata += Int32.Parse(venta.total);
                            }
                            else if (venta.nombre_empleado.Equals("Chanampa Fernando"))
                            {
                                cantChanampa++;
                                brutoChanampa += Int32.Parse(venta.total);
                            }
                            else if (venta.nombre_empleado.Equals("Von leipzig Tiago"))
                            {
                                cantVon++;
                                brutoVon += Int32.Parse(venta.total);
                            }
                            else
                            {
                                cantOtro++;
                                brutoOtro += Int32.Parse(venta.total);
                            }


                            if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                            {
                                cantBrutoVentStgo += Int32.Parse(venta.total);
                                cantGanVentStgo += Int32.Parse(venta.ganancia);
                                cantVentasStgo++;
                            }
                            else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                            {
                                cantBrutoVentPuey += Int32.Parse(venta.total);
                                cantGanVentPuey += Int32.Parse(venta.ganancia);
                                cantVentasPuey++;
                            }
                            cantBrutoVent += Int32.Parse(venta.total);
                            cantGanVent += Int32.Parse(venta.ganancia);
                            cantVentas++;

                            foreach (var producto in productosVendidos)
                            {
                                if (venta.id.Equals(producto.foranea))
                                {
                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                    {
                                        cantProdsVendStgo++;
                                    }
                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                    {
                                        cantProdsVendPuey++;
                                    }
                                    cantProdsVend++;
                                }
                            }
                        
                        }
                    }

                  

                    foreach (var formaPago in formasPagos)
                    {
                        string mes2 = formaPago.fecha.Substring(3, 2);
                        string año2 = formaPago.fecha.Substring(6, 4);
                        if (mes2.Equals(comboMesSeleccionado.Text) && año2.Equals(comboAño.Text))
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
                    total = total - (ctacte*2 + canje*2 + descuento*2 + gastos);

                    this.FindAndReplace(wordApp, "<mes>",comboMesSeleccionado.Text);
                    this.FindAndReplace(wordApp, "<año>",comboAño.Text);

                    this.FindAndReplace(wordApp, "<cantVentas>", cantVentas);
                    this.FindAndReplace(wordApp, "<cantProdsVend>", cantProdsVend);
                    this.FindAndReplace(wordApp, "<cantBrutoVent>", "$" + agregarPuntos(cantBrutoVent.ToString()));
                    this.FindAndReplace(wordApp, "<cantGanVent>", "$" + agregarPuntos(cantGanVent.ToString()));

                    this.FindAndReplace(wordApp, "<cantVentasPuey>", cantVentasPuey);
                    this.FindAndReplace(wordApp, "<cantProdsVendPuey>", cantProdsVendPuey);
                    this.FindAndReplace(wordApp, "<cantBrutoVentPuey>", "$" + agregarPuntos(cantBrutoVentPuey.ToString()));
                    this.FindAndReplace(wordApp, "<cantGanVentPuey>", "$" + agregarPuntos(cantGanVentPuey.ToString()));

                    this.FindAndReplace(wordApp, "<cantVentasStgo>", cantVentasStgo);
                    this.FindAndReplace(wordApp, "<cantProdsVendStgo>", cantProdsVendStgo);
                    this.FindAndReplace(wordApp, "<cantBrutoVentStgo>", "$" + agregarPuntos(cantBrutoVentStgo.ToString()));
                    this.FindAndReplace(wordApp, "<cantGanVentStgo>", "$" + agregarPuntos(cantGanVentStgo.ToString()));

                    this.FindAndReplace(wordApp, "<cantChanampa>", cantChanampa);
                    this.FindAndReplace(wordApp, "<cantZapata>", cantZapata);
                    this.FindAndReplace(wordApp, "<cantVon>", cantVon);
                    this.FindAndReplace(wordApp, "<cantVillareal>", cantVillareal);
                    this.FindAndReplace(wordApp, "<cantCollado>", cantCollado);
                    this.FindAndReplace(wordApp, "<cantRobles>", cantRobles);
                    this.FindAndReplace(wordApp, "<cantOtro>", cantOtro);
                    this.FindAndReplace(wordApp, "<brutoChanampa>", "$" + agregarPuntos(brutoChanampa.ToString()));
                    this.FindAndReplace(wordApp, "<brutoZapata>", "$" + agregarPuntos(brutoZapata.ToString()));
                    this.FindAndReplace(wordApp, "<brutoVon>", "$" + agregarPuntos(brutoVon.ToString()));
                    this.FindAndReplace(wordApp, "<brutoVillareal>", "$" + agregarPuntos(brutoVillareal.ToString()));
                    this.FindAndReplace(wordApp, "<brutoCollado>", "$" + agregarPuntos(brutoCollado.ToString()));
                    this.FindAndReplace(wordApp, "<brutoRobles>", "$" + agregarPuntos(brutoRobles.ToString()));
                    this.FindAndReplace(wordApp, "<brutoOtro>", "$" + agregarPuntos(brutoOtro.ToString()));

                    this.FindAndReplace(wordApp, "<efect>", "$" + agregarPuntos(efectivo.ToString()));
                    this.FindAndReplace(wordApp, "<deb>", "$" + agregarPuntos(debito.ToString()));
                    this.FindAndReplace(wordApp, "<cre>", "$" + agregarPuntos(credito.ToString()));
                    this.FindAndReplace(wordApp, "<tra>", "$" + agregarPuntos(transferencia.ToString()));
                    this.FindAndReplace(wordApp, "<canj>", "$" + agregarPuntos(canje.ToString()));
                    this.FindAndReplace(wordApp, "<ctacte>", "$" + agregarPuntos(ctacte.ToString()));
                    this.FindAndReplace(wordApp, "<desc>", "$" + agregarPuntos(descuento.ToString()));
                    this.FindAndReplace(wordApp, "<gasto>", "$" + agregarPuntos(gastos.ToString()));
                    this.FindAndReplace(wordApp, "<total>","$"+ agregarPuntos(total.ToString()));



                    //--------------------------------------------------------------------------------------------------------------
                    //--------------------------------------------------------------------------------------------------------------
                    //--------------------------------------------------------------------------------------------------------------
                    //--------------------------------------------------------------------------------------------------------------
                    //EFECTIVOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    int a1 = 0;
                    int a2 = 0;
                    int a3 = 0;
                    int a4 = 0;
                    int a5 = 0;
                    int a6 = 0;
                    int a7 = 0;
                    int a8 = 0;
                    int a9 = 0;
                    int a10 = 0;
                    int a11 = 0;
                    int a12 = 0;
                    int a13 = 0;
                    int a14 = 0;
                    int a15 = 0;
                    int a16 = 0;
                    int a17 = 0;
                    int a18 = 0;
                    int a19 = 0;
                    int a20 = 0;
                    int a21 = 0;
                    int a22 = 0;
                    int a23 = 0;
                    int a24 = 0;
                    int a25 = 0;
                    int a26 = 0;
                    int a27 = 0;
                    int a28 = 0;
                    int a29 = 0;
                    int a30 = 0;
                    int a31 = 0;

                    int b1 = 0;
                    int b2 = 0;
                    int b3 = 0;
                    int b4 = 0;
                    int b5 = 0;
                    int b6 = 0;
                    int b7 = 0;
                    int b8 = 0;
                    int b9 = 0;
                    int b10 = 0;
                    int b11 = 0;
                    int b12 = 0;
                    int b13 = 0;
                    int b14 = 0;
                    int b15 = 0;
                    int b16 = 0;
                    int b17 = 0;
                    int b18 = 0;
                    int b19 = 0;
                    int b20 = 0;
                    int b21 = 0;
                    int b22 = 0;
                    int b23 = 0;
                    int b24 = 0;
                    int b25 = 0;
                    int b26 = 0;
                    int b27 = 0;
                    int b28 = 0;
                    int b29 = 0;
                    int b30 = 0;
                    int b31 = 0;


                    foreach (var formaPago in formasPagos)
                    {
                        string mes = formaPago.fecha.Substring(3, 2);
                        string año = formaPago.fecha.Substring(6, 4);

                        
                        if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text) && (formaPago.nombre.Equals("efectivo") || formaPago.nombre.Equals("seña efectivo")))
                        {
                            if (formaPago.nombre.Equals("efectivo") || formaPago.nombre.Equals("seña efectivo"))
                            {
                                if (!formaPago.sucursal.Equals(""))
                                {
                                    switch (formaPago.fecha.Substring(0, 2))
                                    {
                                        case "01":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a1 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b1 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "02":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a2 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b2 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "03":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a3 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b3 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "04":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a4 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b4 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "05":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a5 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b5 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "06":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a6 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b6 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "07":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a7 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b7 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "08":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a8 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b8 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "09":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a9 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b9 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "10":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a10 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b10 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "11":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a11 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b11 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "12":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a12 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b12 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "13":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a13 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b13 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "14":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a14 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b14 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "15":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a15 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b15 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "16":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a16 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b16 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "17":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a17 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b17 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "18":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a18 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b18 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "19":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a19 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b19 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "20":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a20 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b20 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "21":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a21 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b21 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "22":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a22 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b22 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "23":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a23 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b23 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "24":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a24 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b24 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "25":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a25 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b25 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "26":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a26 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b26 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "27":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a27 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b27 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "28":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a28 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b28 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "29":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a29 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b29 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "30":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a30 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b30 += Int32.Parse(formaPago.monto);
                                            break;
                                        case "31":
                                            if (formaPago.sucursal.Equals("Stgo del Estero"))
                                                a31 += Int32.Parse(formaPago.monto);
                                            else if (formaPago.sucursal.Equals("Pueyrredon"))
                                                b31 += Int32.Parse(formaPago.monto);
                                            break;
                                    }
                                }
                                else
                                {
                                    foreach (var venta in ventas)
                                    {
                                        if (venta.id.Equals(formaPago.foranea))
                                        {
                                            switch (formaPago.fecha.Substring(0, 2))
                                            {
                                                case "01":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a1 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b1 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "02":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a2 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b2 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "03":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a3 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b3 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "04":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a4 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b4 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "05":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a5 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b5 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "06":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a6 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b6 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "07":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a7 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b7 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "08":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a8 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b8 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "09":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a9 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b9 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "10":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a10 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b10 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "11":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a11 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b11 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "12":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a12 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b12 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "13":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a13 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b13 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "14":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a14 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b14 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "15":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a15 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b15 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "16":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a16 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b16 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "17":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a17 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b17 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "18":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a18 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b18 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "19":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a19 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b19 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "20":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a20 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b20 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "21":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a21 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b21 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "22":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a22 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b22 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "23":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a23 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b23 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "24":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a24 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b24 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "25":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a25 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b25 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "26":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a26 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b26 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "27":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a27 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b27 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "28":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a28 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b28 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "29":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a29 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b29 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "30":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a30 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b30 += Int32.Parse(formaPago.monto);
                                                    break;
                                                case "31":
                                                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                                                        a31 += Int32.Parse(formaPago.monto);
                                                    else if (venta.nombre_sucursal.Equals("Pueyrredon"))
                                                        b31 += Int32.Parse(formaPago.monto);
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                           
                        }
                    }

                    this.FindAndReplace(wordApp, "<fecha1>","1/"+ comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal1>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto1>", "$" + agregarPuntos(a1.ToString()));

                    this.FindAndReplace(wordApp, "<fecha2>", "1/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal2>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto2>", "$" + agregarPuntos(b1.ToString()));

                    this.FindAndReplace(wordApp, "<fecha3>", "2/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal3>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto3>", "$" + agregarPuntos(a2.ToString()));

                    this.FindAndReplace(wordApp, "<fecha4>", "2/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal4>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto4>", "$" + agregarPuntos(b2.ToString()));

                    this.FindAndReplace(wordApp, "<fecha5>", "3/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal5>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto5>", "$" + agregarPuntos(a3.ToString()));

                    this.FindAndReplace(wordApp, "<fecha6>", "3/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal6>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto6>", "$" + agregarPuntos(b3.ToString()));

                    this.FindAndReplace(wordApp, "<fecha7>", "4/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal7>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto7>", "$" + agregarPuntos(a4.ToString()));

                    this.FindAndReplace(wordApp, "<fecha8>", "4/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal8>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto8>", "$" + agregarPuntos(b4.ToString()));

                    this.FindAndReplace(wordApp, "<fecha9>", "5/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal9>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto9>", "$" + agregarPuntos(a5.ToString()));

                    this.FindAndReplace(wordApp, "<fecha10>", "5/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal10>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto10>", "$" + agregarPuntos(b5.ToString()));

                    this.FindAndReplace(wordApp, "<fecha11>", "6/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal11>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto11>", "$" + agregarPuntos(a6.ToString()));

                    this.FindAndReplace(wordApp, "<fecha12>", "6/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal12>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto12>", "$" + agregarPuntos(b6.ToString()));

                    this.FindAndReplace(wordApp, "<fecha13>", "7/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal13>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto13>", "$" + agregarPuntos(a7.ToString()));

                    this.FindAndReplace(wordApp, "<fecha14>", "7/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal14>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto14>", "$" + agregarPuntos(b7.ToString()));

                    this.FindAndReplace(wordApp, "<fecha15>", "8/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal15>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto15>", "$" + agregarPuntos(a8.ToString()));

                    this.FindAndReplace(wordApp, "<fecha16>", "8/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal16>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto16>", "$" + agregarPuntos(b8.ToString()));

                    this.FindAndReplace(wordApp, "<fecha17>", "9/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal17>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto17>", "$" + agregarPuntos(a9.ToString()));

                    this.FindAndReplace(wordApp, "<fecha18>", "9/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal18>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto18>", "$" + agregarPuntos(b9.ToString()));

                    this.FindAndReplace(wordApp, "<fecha19>", "10/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal19>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto19>", "$" + agregarPuntos(a10.ToString()));

                    this.FindAndReplace(wordApp, "<fecha20>", "10/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal20>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto20>", "$" + agregarPuntos(b10.ToString()));

                    this.FindAndReplace(wordApp, "<fecha21>", "11/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal21>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto21>", "$" + agregarPuntos(a11.ToString()));

                    this.FindAndReplace(wordApp, "<fecha22>", "11/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal22>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto22>", "$" + agregarPuntos(b11.ToString()));

                    this.FindAndReplace(wordApp, "<fecha23>", "12/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal23>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto23>", "$" + agregarPuntos(a12.ToString()));

                    this.FindAndReplace(wordApp, "<fecha24>", "12/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal24>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto24>", "$" + agregarPuntos(b12.ToString()));

                    this.FindAndReplace(wordApp, "<fecha25>", "13/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal25>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto25>", "$" + agregarPuntos(a13.ToString()));

                    this.FindAndReplace(wordApp, "<fecha26>", "13/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal26>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto26>", "$" + agregarPuntos(b13.ToString()));

                    this.FindAndReplace(wordApp, "<fecha27>", "14/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal27>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto27>", "$" + agregarPuntos(a14.ToString()));

                    this.FindAndReplace(wordApp, "<fecha28>", "14/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal28>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto28>", "$" + agregarPuntos(b14.ToString()));

                    this.FindAndReplace(wordApp, "<fecha29>", "15/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal29>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto29>", "$" + agregarPuntos(a15.ToString()));

                    this.FindAndReplace(wordApp, "<fecha30>", "15/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal30>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto30>", "$" + agregarPuntos(b15.ToString()));

                    this.FindAndReplace(wordApp, "<fecha31>", "16/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal31>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto31>", "$" + agregarPuntos(a16.ToString()));

                    this.FindAndReplace(wordApp, "<fecha32>", "16/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal32>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto32>", "$" + agregarPuntos(b16.ToString()));

                    this.FindAndReplace(wordApp, "<fecha33>", "17/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal33>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto33>", "$" + agregarPuntos(a17.ToString()));

                    this.FindAndReplace(wordApp, "<fecha34>", "17/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal34>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto34>", "$" + agregarPuntos(b17.ToString()));

                    this.FindAndReplace(wordApp, "<fecha35>", "18/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal35>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto35>", "$" + agregarPuntos(a18.ToString()));

                    this.FindAndReplace(wordApp, "<fecha36>", "18/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal36>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto36>", "$" + agregarPuntos(b18.ToString()));

                    this.FindAndReplace(wordApp, "<fecha37>", "19/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal37>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto37>", "$" + agregarPuntos(a19.ToString()));

                    this.FindAndReplace(wordApp, "<fecha38>", "19/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal38>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto38>", "$" + agregarPuntos(b19.ToString()));

                    this.FindAndReplace(wordApp, "<fecha39>", "20/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal39>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto39>", "$" + agregarPuntos(a20.ToString()));

                    this.FindAndReplace(wordApp, "<fecha40>", "20/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal40>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto40>", "$" + agregarPuntos(b20.ToString()));

                    this.FindAndReplace(wordApp, "<fecha41>", "21/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal41>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto41>", "$" + agregarPuntos(a21.ToString()));

                    this.FindAndReplace(wordApp, "<fecha42>", "21/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal42>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto42>", "$" + agregarPuntos(b21.ToString()));

                    this.FindAndReplace(wordApp, "<fecha43>", "22/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal43>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto43>", "$" + agregarPuntos(a22.ToString()));

                    this.FindAndReplace(wordApp, "<fecha44>", "22/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal44>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto44>", "$" + agregarPuntos(b22.ToString()));

                    this.FindAndReplace(wordApp, "<fecha45>", "23/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal45>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto45>", "$" + agregarPuntos(a23.ToString()));

                    this.FindAndReplace(wordApp, "<fecha46>", "23/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal46>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto46>", "$" + agregarPuntos(b23.ToString()));

                    this.FindAndReplace(wordApp, "<fecha47>", "24/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal47>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto47>", "$" + agregarPuntos(a24.ToString()));

                    this.FindAndReplace(wordApp, "<fecha48>", "24/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal48>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto48>", "$" + agregarPuntos(b24.ToString()));

                    this.FindAndReplace(wordApp, "<fecha49>", "25/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal49>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto49>", "$" + agregarPuntos(a25.ToString()));

                    this.FindAndReplace(wordApp, "<fecha50>", "25/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal50>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto50>", "$" + agregarPuntos(b25.ToString()));

                    this.FindAndReplace(wordApp, "<fecha51>", "26/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal51>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto51>", "$" + agregarPuntos(a26.ToString()));

                    this.FindAndReplace(wordApp, "<fecha52>", "26/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal52>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto52>", "$" + agregarPuntos(b26.ToString()));

                    this.FindAndReplace(wordApp, "<fecha53>", "27/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal53>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto53>", "$" + agregarPuntos(a27.ToString()));

                    this.FindAndReplace(wordApp, "<fecha54>", "27/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal54>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto54>", "$" + agregarPuntos(b27.ToString()));

                    this.FindAndReplace(wordApp, "<fecha55>", "28/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal55>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto55>", "$" + agregarPuntos(a28.ToString()));

                    this.FindAndReplace(wordApp, "<fecha56>", "28/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal56>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto56>", "$" + agregarPuntos(b28.ToString()));

                    this.FindAndReplace(wordApp, "<fecha57>", "29/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal57>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto57>", "$" + agregarPuntos(a29.ToString()));

                    this.FindAndReplace(wordApp, "<fecha58>", "29/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal58>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto58>", "$" + agregarPuntos(b29.ToString()));

                    this.FindAndReplace(wordApp, "<fecha59>", "30/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal59>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto59>", "$" + agregarPuntos(a30.ToString()));

                    this.FindAndReplace(wordApp, "<fecha60>", "30/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal60>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto60>", "$" + agregarPuntos(b30.ToString()));

                    this.FindAndReplace(wordApp, "<fecha61>", "31/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal61>", "Stgo del Estero");
                    this.FindAndReplace(wordApp, "<monto61>", "$" + agregarPuntos(a31.ToString()));

                    this.FindAndReplace(wordApp, "<fecha62>", "31/" + comboMesSeleccionado.Text + "/" + comboAño.Text);
                    this.FindAndReplace(wordApp, "<sucursal62>", "Pueyrredon");
                    this.FindAndReplace(wordApp, "<monto62>", "$" + agregarPuntos(b31.ToString()));

                    //gastos

                    int i = 1;
                    foreach (var gasto in cargaGastos)
                    {
                        string mes = gasto.fecha.Substring(3, 2);
                        string año = gasto.fecha.Substring(6, 4);
                        if (mes.Equals(comboMesSeleccionado.Text) && año.Equals(comboAño.Text))
                        {
                            this.FindAndReplace(wordApp, "<f"+i.ToString()+">", gasto.fecha);
                            this.FindAndReplace(wordApp, "<s" + i.ToString() + ">", gasto.sucursal);
                            this.FindAndReplace(wordApp, "<m" + i.ToString() + ">", "$" + agregarPuntos(gasto.monto));
                            i++;
                        }
                       
                    }



                    //totales

                    int totStgo = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14 + a15 + a16 + a17 + a18 + a19 + a20 + a21 + a22 + a23 + a24 + a25 + a26 + a27 + a28 + a29 + a30 + a31;
                    int totPuey = b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8 + b9 + b10 + b11 + b12 + b13 + b14 + b15 + b16 + b17 + b18 + b19 + b20 + b21 + b22 + b23 + b24 + b25 + b26 + b27 + b28 + b29 + b30 + b31;
                    this.FindAndReplace(wordApp, "<totalStgo>", "$" + agregarPuntos(totStgo.ToString()));
                    this.FindAndReplace(wordApp, "<totalPuey>", "$" + agregarPuntos(totPuey.ToString()));





                    myWordDoc.SaveAs2(ref SaveAs, WdSaveFormat.wdFormatPDF, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing);
                    object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                    object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                    object routeDocument = false;
                    myWordDoc.Close(ref saveOption, ref originalFormat, ref routeDocument);
                    wordApp.Quit();
                    MessageBox.Show("Se Exportaron Estadisticas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonExportarPDF.Enabled = true;
                    buttonExportarPDF.Text = "Exportar PDF";
                }
            }

            catch (Exception es)
            {
                myWordDoc.SaveAs2(ref SaveAs, WdSaveFormat.wdFormatPDF, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing);

                object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                myWordDoc.Close(ref saveOption, ref originalFormat, ref routeDocument);
                wordApp.Quit();
                MessageBox.Show("Ocurrio un error");
                MessageBox.Show(es.Message);
                buttonExportarPDF.Enabled = true;
                buttonExportarPDF.Text = "Exportar PDF";
            }
        }

        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }
    }
}

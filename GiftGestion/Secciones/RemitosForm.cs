using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftGestion.Secciones.SubSecciones;
using GiftGestion.Objetos;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;
using SpreadsheetLight;

namespace GiftGestion.Secciones
{
    public partial class RemitosForm : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        OrdenCompra orden = new OrdenCompra();
        Usuario user = new Usuario();

        List<Remito> remitosCarga = new List<Remito>();
        List<Producto> productosOCCarga = new List<Producto>();
        List<Producto> precargaDetalleRemitos = new List<Producto>();
        Remito remitoSeleccionado = new Remito();

        private string rutaModeloRemito = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/remito.xlsx";
        private string rutaModeloRecorrido = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/recorrido.xlsx";
        private string rutaSalidaRemitos = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Remitos/";
        private string rutaSalidaRecorrido = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Recorridos/";

        Color redColor = Color.FromArgb(180, 63, 38);
        Color yellowColor = Color.FromArgb(216, 231, 20);
        Color greenColor = Color.FromArgb(27, 172, 0);
        public RemitosForm(Usuario usuario)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitializeComponent();
                user = usuario;
            }
        }

        private void RemitosForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cargarRemitos();
            precargaProductosOC();
            cargarDetalleRemito();
            if (user.rol.Equals("Admin"))
            {
                textTituloCodBarras.Visible = true;
                textCodigo.Visible = true;
                buttonRecorrido.Visible = true;
            }
        }
        private async void cargarDetalleRemito()
        {
            try
            {
                var detalleRemitos = await firebaseHelper.getAllDetalleRemito();
                foreach (var producto in detalleRemitos)
                {
                    precargaDetalleRemitos.Add(producto);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message + " asdsa");
            }
        }

        private async void precargaProductosOC()
        {
            try
            {
                var productosOC = await firebaseHelper.getAllDetalleOrdenCompra();
                foreach (var prod in productosOC)
                {
                    productosOCCarga.Add(prod);
                }
            }
            catch (Exception es)
            {

            }
        }
        private async void cargarRemitos()
        {
            try
            {
                var remitoss = await firebaseHelper.getAllRemitos();
                remitosCarga = new List<Remito>();
                if (remitoss != null)
                {
                    dataGridRemitos.Rows.Clear();

                    foreach (var remito in remitoss)
                    {
                        if (remito.foraneaOC != null)
                        {
                            dataGridRemitos.Rows.Add(remito.id, Convert.ToDateTime(remito.fecha), remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion,remito.foraneaOC);
                        }
                        else
                        {
                            dataGridRemitos.Rows.Add(remito.id, Convert.ToDateTime(remito.fecha), remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion);
                        }
                    }
                    dataGridRemitos.Sort(dataGridRemitos.Columns[1], System.ComponentModel.ListSortDirection.Descending);

                    foreach (var remito in remitoss)
                    {
                        remitosCarga.Add(remito);
                    }
                    recorrerListado();
                }
            }
            catch (Exception es)
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        private void dataGridRemitos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (var remito in remitosCarga)
            {
                if (remito.id.Equals(dataGridRemitos.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    remitoSeleccionado = remito;
                    textCodigoSeleccionado.Text = remito.id;
                    comboEstadoRemito.Text = remito.estado;
                }
            }
            try
            {
                if (dataGridRemitos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    dataGridProductos.Rows.Clear();

                    foreach (var producto in precargaDetalleRemitos)
                    {
                        if (producto.foranea.Equals(dataGridRemitos.Rows[e.RowIndex].Cells[0].Value.ToString()))
                        {
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                        }
                    }

                    dataGridProductosOC.Rows.Clear();
                    foreach (var producto in productosOCCarga)
                    {
                        if (dataGridRemitos.Rows[e.RowIndex].Cells[8].Value != null)
                        {
                            if (dataGridRemitos.Rows[e.RowIndex].Cells[8].Value.ToString().Equals(producto.foranea))
                                dataGridProductosOC.Rows.Add(producto.nombre_articulo, producto.descripcion, producto.cantidad, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                        }
                    }
                }

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            if (e.Button.Equals(MouseButtons.Right))
            {
                DialogResult resultado = MessageBox.Show("Desea abrir Remito?", "Advertencia", MessageBoxButtons.YesNoCancel);
                if (resultado == DialogResult.Yes)
                {
                    this.Close();
                    GenerarRemito generar = new GenerarRemito(user, remitoSeleccionado, orden);
                    generar.Show();
                }
            }
        }
        private void buttonGenerarRemito_Click(object sender, EventArgs e)
        {
            this.Close();
            Remito remito = new Remito();
            GenerarRemito generar = new GenerarRemito(user, remito, orden);
            generar.Show();
        }
      
        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comboEstadoRemito_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarEstadoRemito();
        }
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        //----------------------------------FILTROS-----------------------------
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (remitosCarga != null)
                {
                    dataGridRemitos.Rows.Clear();

                    foreach (var remito in remitosCarga)
                    {
                        if (remito.fecha.Equals(dateFecha.Value.ToString("dd/MM/yyyy")))
                        {
                            dataGridRemitos.Rows.Add(remito.id, remito.fecha, remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion);
                        }     
                    }
                    dataGridRemitos.Sort(dataGridRemitos.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                    recorrerListado();
                }
            }
            catch (Exception es)
            {

            }
        }

        private void comboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (remitosCarga != null)
                {
                    dataGridRemitos.Rows.Clear();

                    foreach (var remito in remitosCarga)
                    {
                        if (comboSucursal.Text.Equals("Todos"))
                        {
                            dataGridRemitos.Rows.Add(remito.id, Convert.ToDateTime(remito.fecha), remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion);
                        }
                        else
                        {
                            if (comboSucursal.Text.Equals(remito.destino))
                            {
                                dataGridRemitos.Rows.Add(remito.id, Convert.ToDateTime(remito.fecha), remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion);
                            }
                        }
                       
                    }
                    dataGridRemitos.Sort(dataGridRemitos.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                    recorrerListado();
                }
            }
            catch (Exception es)
            {

            }
        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (remitosCarga != null)
                {
                    dataGridRemitos.Rows.Clear();

                    foreach (var remito in remitosCarga)
                    {
                        if (comboEstado.Text.Equals("SIN SALIDA"))
                        {
                            if (remito.estado=="" && remito.tipo.Equals("Entrada"))
                            {
                                dataGridRemitos.Rows.Add(remito.id, Convert.ToDateTime(remito.fecha), remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion);
                            }
                        }
                        else if (!comboEstado.Text.Equals("SIN SALIDA"))
                        {
                            if (comboEstado.Text.Equals(remito.estado))
                            {
                                dataGridRemitos.Rows.Add(remito.id, Convert.ToDateTime(remito.fecha), remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion);
                            }
                        }
                    }
                    dataGridRemitos.Sort(dataGridRemitos.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                    recorrerListado();
                }
            }
            catch (Exception es)
            {

            }
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (remitosCarga != null)
                {
                    dataGridRemitos.Rows.Clear();

                    foreach (var remito in remitosCarga)
                    {
                        if (comboTipo.Text.Equals(remito.tipo))
                        {
                            dataGridRemitos.Rows.Add(remito.id, Convert.ToDateTime(remito.fecha), remito.hora, remito.tipo, remito.destino, remito.observacion, remito.estado, remito.observacion_eliminacion);
                        }
                    }
                    dataGridRemitos.Sort(dataGridRemitos.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                    recorrerListado();
                }
                    
            }
            catch (Exception es)
            {

            }
        }

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            /*
            try
            {

                SLDocument sl = new SLDocument(rutaModeloRemito);

                sl.SetCellValue("D6", remitoSeleccionado.id);
                sl.SetCellValue("D8", remitoSeleccionado.fecha);
                sl.SetCellValue("D9", remitoSeleccionado.hora);
                sl.SetCellValue("H8", remitoSeleccionado.tipo);
                sl.SetCellValue("I11", remitoSeleccionado.destino);
                sl.SetCellValue("B14", remitoSeleccionado.observacion);

                int rows = dataGridProductos.RowCount - 1;

                int j = 19;
                for (int i = 0; i < rows; i++)
                {

                    sl.SetCellValue("B" + j.ToString(), dataGridProductos.Rows[i].Cells[0].Value.ToString());
                    sl.SetCellValue("C" + j.ToString(), dataGridProductos.Rows[i].Cells[1].Value.ToString());
                    sl.SetCellValue("D" + j.ToString(), dataGridProductos.Rows[i].Cells[2].Value.ToString());
                    sl.SetCellValue("E" + j.ToString(), dataGridProductos.Rows[i].Cells[3].Value.ToString());
                    sl.SetCellValue("F" + j.ToString(), dataGridProductos.Rows[i].Cells[5].Value.ToString());
                    sl.SetCellValue("G" + j.ToString(), dataGridProductos.Rows[i].Cells[6].Value.ToString());
                    sl.SetCellValue("H" + j.ToString(), dataGridProductos.Rows[i].Cells[7].Value.ToString());
                    sl.SetCellValue("I" + j.ToString(), dataGridProductos.Rows[i].Cells[8].Value.ToString());
                    sl.SetCellValue("J" + j.ToString(), dataGridProductos.Rows[i].Cells[9].Value.ToString());
                    sl.SetCellValue("K" + j.ToString(), dataGridProductos.Rows[i].Cells[10].Value.ToString());
                    sl.SetCellValue("L" + j.ToString(), dataGridProductos.Rows[i].Cells[11].Value.ToString());
                    j++;
                }

                sl.SaveAs(rutaSalidaRemitos + remitoSeleccionado.tipo + " " + remitoSeleccionado.destino+" "+remitoSeleccionado.fecha.Replace('/','-')+".xlsx");
                MessageBox.Show("Se Generó el Remito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }*/

            try
            {
                 SLDocument sl = new SLDocument(rutaModeloRemito);

                int j = 2;
                foreach (var remito in remitosCarga)
                {
                    if (remito.tipo.Equals("Traspaso"))
                    {
                        foreach (var producto in precargaDetalleRemitos)
                        {
                            if (producto.foranea.Equals(remito.id))
                            {
                                sl.SetCellValue("A" + j.ToString(), producto.id);
                                sl.SetCellValue("B" + j.ToString(), producto.nombre_articulo);
                                sl.SetCellValue("C" + j.ToString(), producto.descripcion);
                                sl.SetCellValue("D" + j.ToString(), producto.costo);
                                sl.SetCellValue("E" + j.ToString(), producto.cantidad);
                                sl.SetCellValue("F" + j.ToString(), producto.proveedor);
                                sl.SetCellValue("G" + j.ToString(), remito.fecha);
                                sl.SetCellValue("H" + j.ToString(), remito.destino);
                                j++;
                            }
                            
                           
                        }
                    }
                }

                sl.SaveAs(rutaSalidaRemitos + "ExportacionRemitoEntrada.xlsx");
                MessageBox.Show("Se Exporto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception es)
            {

            }

        }

        private void recorridoProducto(string id)
        {
            try
            {
                SLDocument sl = new SLDocument(rutaModeloRecorrido);

                int j = 5;
                foreach (var remito in remitosCarga)
                {
                    foreach (var producto in precargaDetalleRemitos)
                    {
                        if (id.Equals(producto.id) && remito.id.Equals(producto.foranea))
                        {
                            sl.SetCellValue("B" + j.ToString(), producto.id);
                            sl.SetCellValue("C" + j.ToString(), producto.nombre_articulo);
                            sl.SetCellValue("D" + j.ToString(), producto.descripcion);
                            sl.SetCellValue("E" + j.ToString(), producto.cantidad);
                            sl.SetCellValue("F" + j.ToString(), producto.color);
                            sl.SetCellValue("G" + j.ToString(), producto.talle);
                            sl.SetCellValue("I" + j.ToString(), remito.fecha); //dia
                            sl.SetCellValue("J" + j.ToString(), remito.tipo); //tipo
                            sl.SetCellValue("K" + j.ToString(), remito.destino); //destino
                            sl.SetCellValue("L" + j.ToString(), remito.observacion); //observacion
                            j++;
                        }
                    }
                }
                sl.SaveAs(rutaSalidaRecorrido + id + ".xlsx");
                MessageBox.Show("Se Generó el Recorrido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }
      

        private void buttonRecorrido_Click(object sender, EventArgs e)
        {
            recorridoProducto(textCodigo.Text);
        }
        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                recorridoProducto(textCodigo.Text);
            }
        }

        private async void cambiarEstadoRemito()
        {
            if (remitoSeleccionado.id!=null && comboEstadoRemito.Text!="")
            {
                await firebaseHelper.updateRemito(remitoSeleccionado.id, remitoSeleccionado.fecha, remitoSeleccionado.hora,
              remitoSeleccionado.tipo, remitoSeleccionado.observacion, remitoSeleccionado.destino, comboEstadoRemito.Text);
                cargarRemitos();
                comboEstadoRemito.Text = "";
            }
        }

        private void recorrerListado()
        {
            foreach (DataGridViewRow row in dataGridRemitos.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    if ((row.Cells[3].Value).ToString().Equals("Traspaso"))
                    {
                        row.DefaultCellStyle.ForeColor = yellowColor;
                    }
                    else if ((row.Cells[3].Value).ToString().Equals("Entrada"))
                    {
                        row.DefaultCellStyle.ForeColor = greenColor;
                    }
                    else if ((row.Cells[3].Value).ToString().Equals("Salida"))
                    {
                        row.DefaultCellStyle.ForeColor = redColor;
                    }
                }
            }
        }
    }


}

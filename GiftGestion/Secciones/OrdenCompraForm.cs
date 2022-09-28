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
using GiftGestion.Secciones;
using GiftGestion.Secciones.SubSecciones;
using SpreadsheetLight;

namespace GiftGestion.Secciones
{
    public partial class OrdenCompraForm : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario user = new Usuario();

        List<OrdenCompra> ordenCompraCarga = new List<OrdenCompra>();
        List<Producto> detalleCarga = new List<Producto>();

        private OrdenCompra OCSeleccionada = new OrdenCompra();

        private string rutaModeloOC = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/ordenCompra.xlsx";
        private string rutaSalidaOC = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Ordenes de Compra/";

        Color redColor = Color.FromArgb(180, 63, 38);
        Color yellowColor = Color.FromArgb(216, 231, 20);
        Color greenColor = Color.FromArgb(27, 172, 0);
        public OrdenCompraForm(Usuario usuario)
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

        private void OrdenCompraForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            try
            {
                cargarOrdenesCompras();
                cargarDetalesOrdenes();
            }
            catch(Exception es)
            {

            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        private async void buttonGuardarCambios_Click(object sender, EventArgs e)
        {
            if (OCSeleccionada.id != null)
            {
                await firebaseHelper.updateOrdenCompra(OCSeleccionada.id, OCSeleccionada.fecha, OCSeleccionada.hora, OCSeleccionada.empleado,
                    OCSeleccionada.observacion, OCSeleccionada.validoHasta, OCSeleccionada.proveedor,
                    OCSeleccionada.total, OCSeleccionada.ganancia, OCSeleccionada.prioridad, comboEstadoOC.Text, comboRemitoOC.Text);

                cargarOrdenesCompras();
            }
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            exportarVentas();
        }
        private void buttonGenerarOC_Click(object sender, EventArgs e)
        {
            this.Close();
            GenerarOC generarOC = new GenerarOC(user);
            generarOC.Show();
        }
        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            calcularSubtotal();
        }
        private void dataGridOrdenesCompras_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    if (dataGridOrdenesCompras.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        dataGridProductos.Rows.Clear();
                        foreach (var producto in detalleCarga)
                        {
                            if (producto.foranea.Equals(dataGridOrdenesCompras.Rows[e.RowIndex].Cells[0].Value.ToString()))
                                dataGridProductos.Rows.Add(producto.nombre_articulo, producto.descripcion, producto.cantidad, producto.precio_lista, producto.precio_efectivo, producto.costo, producto.proveedor, producto.estacion, producto.color, producto.color, producto.talle, producto.grupo);
                        }
                     

                        OCSeleccionada = new OrdenCompra();
                        OCSeleccionada.id = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[0].Value.ToString();
                        OCSeleccionada.fecha = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[1].Value.ToString().Substring(0, 10);
                        OCSeleccionada.hora = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[2].Value.ToString();
                        OCSeleccionada.empleado = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[6].Value.ToString();
                        OCSeleccionada.observacion = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[5].Value.ToString();
                        OCSeleccionada.total = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[9].Value.ToString();
                        OCSeleccionada.proveedor = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[8].Value.ToString();
                        OCSeleccionada.ganancia = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[10].Value.ToString();
                        OCSeleccionada.prioridad = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[11].Value.ToString();
                        OCSeleccionada.validoHasta = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[7].Value.ToString();
                        OCSeleccionada.estado = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[3].Value.ToString();
                        OCSeleccionada.remito = dataGridOrdenesCompras.Rows[e.RowIndex].Cells[4].Value.ToString();

                        textInfo.Text = OCSeleccionada.fecha + " | " + OCSeleccionada.observacion + " | " + OCSeleccionada.id;

                        comboEstadoOC.Text = OCSeleccionada.estado;
                        comboRemitoOC.Text = OCSeleccionada.remito;
                    }
                }
                else if (e.Button.Equals(MouseButtons.Right))
                {
                    DialogResult resultado = MessageBox.Show("Desea Generar Remito de entrada?", "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        Remito remito = new Remito();

                        foreach (var orden in ordenCompraCarga)
                        {
                            if (orden.id.Equals(dataGridOrdenesCompras.Rows[e.RowIndex].Cells[0].Value.ToString()))
                            {
                                this.Close();
                                GenerarRemito generar = new GenerarRemito(user, remito, orden);
                                generar.Show();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void buttonTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ordenCompraCarga != null)
                {
                    dataGridOrdenesCompras.Rows.Clear();

                    foreach (var orden in ordenCompraCarga)
                    {
                        dataGridOrdenesCompras.Rows.Add(orden.id, Convert.ToDateTime(orden.fecha), orden.hora, orden.estado, orden.remito, orden.observacion, orden.empleado,
                                           orden.validoHasta, orden.proveedor, orden.total, orden.ganancia, orden.prioridad);
                    }
                    dataGridOrdenesCompras.Sort(dataGridOrdenesCompras.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                    recorrerListado();
                }
            }
            catch (Exception es)
            {

            }
        }
        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ordenCompraCarga != null)
                {
                    dataGridOrdenesCompras.Rows.Clear();

                    foreach (var orden in ordenCompraCarga)
                    {
                        if(orden.fecha.Equals(dateFecha.Value.ToString("dd/MM/yyyy")))
                            dataGridOrdenesCompras.Rows.Add(orden.id, Convert.ToDateTime(orden.fecha), orden.hora, orden.estado, orden.remito, orden.observacion, orden.empleado,
                               orden.validoHasta, orden.proveedor, orden.total, orden.ganancia, orden.prioridad);
                    }
                    dataGridOrdenesCompras.Sort(dataGridOrdenesCompras.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                    recorrerListado();
                }
            }
            catch(Exception es)
            {

            }
        }

        //------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------


        private async void cargarOrdenesCompras()
        {
            try
            {
                var ordeness = await firebaseHelper.getAllOrdenCompra();
                if (ordeness != null)
                {
                    dataGridOrdenesCompras.Rows.Clear();

                    foreach (var orden in ordeness)
                    {
                        dataGridOrdenesCompras.Rows.Add(orden.id, Convert.ToDateTime(orden.fecha), orden.hora, orden.estado, orden.remito, orden.observacion, orden.empleado,
                                    orden.validoHasta, orden.proveedor, orden.total, orden.ganancia, orden.prioridad);
                    }
                    dataGridOrdenesCompras.Sort(dataGridOrdenesCompras.Columns[1], System.ComponentModel.ListSortDirection.Descending);

                    foreach (var orden in ordeness)
                    {
                        ordenCompraCarga.Add(orden);
                    }
                    recorrerListado();
                }
            }
            catch (Exception es)
            {

            }
        }

        private async void cargarDetalesOrdenes()
        {
            try
            {
                var detalleOC = await firebaseHelper.getAllDetalleOrdenCompra();
                if (detalleOC != null)
                {
                    foreach (var detalle in detalleOC)
                    {
                        detalleCarga.Add(detalle);
                    }
                }
            }
            catch (Exception es)
            {

            }
        }

     


        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        
        private void recorrerListado()
        {
            foreach (DataGridViewRow row in dataGridOrdenesCompras.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    if ((row.Cells[4].Value).ToString().Equals("SI"))
                    {
                        row.DefaultCellStyle.ForeColor = greenColor;
                    }
                    else if ((row.Cells[4].Value).ToString().Equals("NO"))
                    {
                        row.DefaultCellStyle.ForeColor = redColor;
                    }
                }
            }
        }

        private void exportarVentas()
        {
            try
            {
                SLDocument sl = new SLDocument(rutaModeloOC);

                int j = 3;
                int i = 0;

                foreach (var orden in ordenCompraCarga)
                {
                    sl.SetCellValue("B" + j.ToString(), orden.id);
                    sl.SetCellValue("C" + j.ToString(), orden.fecha);
                    sl.SetCellValue("D" + j.ToString(), orden.observacion);
                    sl.SetCellValue("E" + j.ToString(), orden.proveedor);
                    sl.SetCellValue("F" + j.ToString(), orden.empleado);
                    sl.SetCellValue("G" + j.ToString(), orden.ganancia);
                    sl.SetCellValue("H" + j.ToString(), orden.total);
                    i = j;
                    int sum = 0;
                    foreach (var producto in detalleCarga)
                    {
                        if (producto.foranea.Equals(orden.id))
                        {
                            sl.SetCellValue("J" + i.ToString(), producto.id);
                            sl.SetCellValue("K" + i.ToString(), producto.nombre_articulo);
                            sl.SetCellValue("L" + i.ToString(), producto.descripcion);
                            sl.SetCellValue("M" + i.ToString(), producto.cantidad);
                            sl.SetCellValue("N" + i.ToString(), producto.color);
                            sl.SetCellValue("O" + i.ToString(), producto.talle);
                            sl.SetCellValue("P" + i.ToString(), producto.costo);
                            sl.SetCellValue("Q" + i.ToString(), producto.precio_efectivo);
                            sl.SetCellValue("R" + i.ToString(), producto.precio_lista);
                            i++;
                            sum++;
                        }
                    }
                   
                    j = j + sum;
                    j++;
                    j++;
                }
                sl.SaveAs(rutaSalidaOC + " Exportacion Ordenes de Compra" + ".xlsx");
                MessageBox.Show("Se Exportaron Ordenes de Compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }


        private void calcularSubtotal()
        {
            try
            {
                int cant = 0;
                int total = 0;
                foreach (DataGridViewRow item in dataGridProductos.Rows)
                {
                    if (item.Cells[2].Value != null)
                    {
                        total += Int32.Parse(item.Cells[2].Value.ToString());
                    }
                }

                foreach (DataGridViewRow item in this.dataGridProductos.SelectedRows)
                {
                    if (item.Cells[2].Value != null)
                    {
                        cant += Int32.Parse(item.Cells[2].Value.ToString());
                    }

                }
                textTOTAL.Text = "Total: " + total.ToString()+ " Seleccion: "+ cant.ToString();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

       
    }
}

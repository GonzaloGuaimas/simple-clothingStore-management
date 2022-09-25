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
using System.Globalization;
using SpreadsheetLight;
namespace GiftGestion.Secciones
{
    public partial class CambiosForm : Form
    {
        Usuario user = new Usuario();
        Venta venta = new Venta();
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        List<Venta> ventasCarga = new List<Venta>();
        List<FormaPago> formaPagoCarga = new List<FormaPago>();
        List<Producto> productosCarga = new List<Producto>();

        public CambiosForm(Usuario usuario)
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

        private void CambiosForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (user.rol.Equals("Vendedor"))
            {
                dataGridVentas.Columns[6].Visible = false;
            }
            cargarVentas();
            precargarDetallePagos();
            precargarProductos();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridVentas.Rows[e.RowIndex].Cells[0].Value != null)
            {
                string id = dataGridVentas.Rows[e.RowIndex].Cells[0].Value.ToString();
                cargarDetalleProductos(id);
                cargarDetallePagos(id);
            }
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {

            exportarVentas2();
        }
        private async void cargarVentas()
        {
            try
            {
                var ventas = await firebaseHelper.getAllCambios();
                if (ventas != null)
                {
                    dataGridVentas.Rows.Clear();
                    foreach (var vent in ventas)
                    {
                        int año = Int32.Parse(vent.fecha.Substring(6, 4));
                        int mes = Int32.Parse(vent.fecha.Substring(3, 2));
                        int dia = Int32.Parse(vent.fecha.Substring(0, 2));
                        int hora = Int32.Parse(vent.hora.Substring(0, 2));
                        int min = Int32.Parse(vent.hora.Substring(3, 2));

                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);

                        dataGridVentas.Rows.Add(vent.id, fecha, vent.hora, vent.nombre_sucursal, vent.tipo_pago, vent.total, vent.ganancia, vent.estado, vent.nombre_empleado, vent.nombre_cliente, vent.observacion);
                    }
                    dataGridVentas.Sort(dataGridVentas.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                    foreach (var vent in ventas)
                    {
                        ventasCarga.Add(vent);
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private async void precargarDetallePagos()
        {
            try
            {
                var pagos = await firebaseHelper.getAllDetalleFormaPago();
                if (pagos != null)
                {
                    foreach (var pago in pagos)
                    {
                        formaPagoCarga.Add(pago);
                    }
                }
            }
            catch (Exception es)
            {

            }
        }
        private async void precargarProductos()
        {
            try
            {
                var productos = await firebaseHelper.getAllDetalleCambio();
                if (productos != null)
                {
                    foreach (var producto in productos)
                    {
                        productosCarga.Add(producto);
                    }
                }
            }
            catch (Exception es)
            {

            }
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------


        private void cargarDetalleProductos(string id)
        {
            try
            {
                if (productosCarga != null)
                {
                    dataGridProductos.Rows.Clear();
                    foreach (var producto in productosCarga)
                    {
                        if (producto.foranea.Equals(id))
                        {
                            dataGridProductos.Rows.Add(producto.nombre_articulo, producto.descripcion, producto.precio);
                        }
                    }
                }
            }
            catch (Exception es)
            {

            }
        }
        private void cargarDetallePagos(string id)
        {
            try
            {

                if (formaPagoCarga != null)
                {
                    dataGridPagos.Rows.Clear();
                    foreach (var pago in formaPagoCarga)
                    {
                        if (pago.foranea.Equals(id))
                        {
                            dataGridPagos.Rows.Add(pago.nombre, pago.fecha, pago.monto);
                        }
                    }
                }
            }
            catch (Exception es)
            {

            }
        }

        //--------------------------------------------------------------------
        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ventasCarga != null)
                {
                    dataGridVentas.Rows.Clear();
                    foreach (var vent in ventasCarga)
                    {
                        if (vent.fecha.Equals(dateFecha.Value.ToString("dd/MM/yyyy")))
                        {
                            dataGridVentas.Rows.Add(vent.id, vent.fecha, vent.hora, vent.nombre_sucursal, vent.tipo_pago, vent.total, vent.ganancia, vent.estado, vent.nombre_empleado, vent.nombre_cliente);
                        }
                    }
                }
            }
            catch (Exception es)
            {

            }
        }

        private void buttonTodas_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventasCarga != null)
                {
                    dataGridVentas.Rows.Clear();
                    foreach (var vent in ventasCarga)
                    {
                        int año = Int32.Parse(vent.fecha.Substring(6, 4));
                        int mes = Int32.Parse(vent.fecha.Substring(3, 2));
                        int dia = Int32.Parse(vent.fecha.Substring(0, 2));
                        int hora = Int32.Parse(vent.hora.Substring(0, 2));
                        int min = Int32.Parse(vent.hora.Substring(3, 2));

                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);

                        dataGridVentas.Rows.Add(vent.id, fecha, vent.hora, vent.nombre_sucursal, vent.tipo_pago, vent.total, vent.ganancia, vent.estado, vent.nombre_empleado, vent.nombre_cliente);
                    }
                    dataGridVentas.Sort(dataGridVentas.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            catch (Exception es)
            {

            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void exportarVentas2()
        {
            try
            {
                SLDocument sl = new SLDocument(rutaModeloVentas);

                int j = 3;
                int i = 0;
                int k = 0;

                foreach (DataGridViewRow row in dataGridVentas.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        sl.SetCellValue("A" + j.ToString(), row.Cells[0].Value.ToString());
                        sl.SetCellValue("B" + j.ToString(), row.Cells[1].Value.ToString());
                        sl.SetCellValue("C" + j.ToString(), row.Cells[3].Value.ToString());
                        sl.SetCellValue("D" + j.ToString(), row.Cells[8].Value.ToString());
                        sl.SetCellValue("E" + j.ToString(), row.Cells[4].Value.ToString());
                        sl.SetCellValue("F" + j.ToString(), row.Cells[10].Value.ToString());
                        sl.SetCellValue("G" + j.ToString(), row.Cells[6].Value.ToString());
                        sl.SetCellValue("H" + j.ToString(), row.Cells[5].Value.ToString());
                        sl.SetCellValue("I" + j.ToString(), row.Cells[9].Value.ToString());

                        i = j;
                        k = j;
                        int sum = 0;
                        foreach (var producto in productosCarga)
                        {
                            if (producto.foranea.Equals(row.Cells[0].Value.ToString()))
                            {
                                sl.SetCellValue("K" + i.ToString(), producto.id);
                                sl.SetCellValue("L" + i.ToString(), producto.nombre_articulo);
                                sl.SetCellValue("M" + i.ToString(), producto.descripcion);
                                sl.SetCellValue("N" + i.ToString(), producto.cantidad);
                                sl.SetCellValue("O" + i.ToString(), producto.color);
                                sl.SetCellValue("P" + i.ToString(), producto.talle);
                                sl.SetCellValue("Q" + i.ToString(), producto.precio);
                                i++;
                                sum++;
                            }
                        }
                        foreach (var forma in formaPagoCarga)
                        {
                            if (forma.foranea.Equals(row.Cells[0].Value.ToString()))
                            {
                                sl.SetCellValue("S" + k.ToString(), forma.fecha);
                                sl.SetCellValue("T" + k.ToString(), forma.nombre);
                                sl.SetCellValue("U" + k.ToString(), forma.monto);
                                sum++;
                                k++;
                            }
                        }
                        j = j + sum;

                    }
                }
                sl.SaveAs(rutaSalidaVentas + " Exportacion Ventas" + ".xlsx");
                MessageBox.Show("Se Exportaron Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }

        private void buttonGenerarCambio_Click(object sender, EventArgs e)
        {
            GenerarCambio generarVenta = new GenerarCambio(user);
            generarVenta.Show();
            this.Close();
        }
    }
}

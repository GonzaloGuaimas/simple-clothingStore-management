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
using SpreadsheetLight;
using GiftGestion.Secciones.SubSecciones;

namespace GiftGestion.Secciones
{
    public partial class ClientesForm : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        List<Cliente> clientes = new List<Cliente>();
        List<Venta> ventas = new List<Venta>();
        List<Venta> ventasCargaCtaCte = new List<Venta>();
        List<Producto> productosVentas = new List<Producto>();
        List<FormaPago> formaPagos = new List<FormaPago>();
        String idCliente = "";

        private string rutaModeloClientes = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/clientes.xlsx";
        private string rutaSalidaClientes = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Clientes/";

        private Usuario user;

        public ClientesForm(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cargarDatos();

        }

        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        private void dataGridClientes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridClientes.Rows[e.RowIndex].Cells[0].Value != null)
            {
                idCliente = dataGridClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
                cargarCompras(dataGridClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                cargarPagos(dataGridClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                groupPagarCtaCte.Text = "Pagar Cta Cte " + idCliente;
                textSaldo.Text = "Saldo: $" + dataGridClientes.Rows[e.RowIndex].Cells[7].Value.ToString();
                textPagado.Text = "Pagado: $" + dataGridClientes.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private async void dataGridCompras_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridCompras.Rows[e.RowIndex].Cells[0].Value != null)
            {
                cargarDetalleCompra(dataGridCompras.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            if (e.Button.Equals(MouseButtons.Right))
            {
                DialogResult resultado = MessageBox.Show("Desea abrir Venta?", "Advertencia", MessageBoxButtons.YesNoCancel);
                if (resultado == DialogResult.Yes)
                {
                    var venta = await firebaseHelper.getVenta((dataGridCompras.Rows[e.RowIndex].Cells[0].Value.ToString()));

                    GenerarVenta generar = new GenerarVenta(user, venta);
                    generar.Show();
                }
            }
        }
        private void dataGridCompras_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridCompras.Rows[e.RowIndex].Cells[0].Value != null)
            {
                calcularTotal();
            }
        }
        private void buttonTodas_Click(object sender, EventArgs e)
        {
            cargarTodasVentas();
        }
        private async void buttonPagarCtaCte_Click(object sender, EventArgs e)
        {
            try
            {
                if (!comboFormaPago.Text.Equals("") && !textMonto.Text.Equals(""))
                {
                    FormaPago forma = new FormaPago();
                    forma.foranea = idCliente;
                    forma.fecha = dateFechaPago.Value.ToString("dd/MM/yyyy");
                    forma.nombre = comboFormaPago.Text;
                    forma.monto = textMonto.Text;
                    forma.sucursal = comboSucursal.Text;
                    forma.comentario = textComentario.Text;
                    await firebaseHelper.addDetalleFormaPago2(forma);

                    MessageBox.Show("Se agregó Pago");
                    cargarDatos();
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

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            exportarVentas();
        }
        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        private async void cargarDatos()
        {
            ventas = await firebaseHelper.getAllVentas();
            formaPagos = await firebaseHelper.getAllDetalleFormaPago();
            productosVentas = await firebaseHelper.getAllDetalleVenta();
            clientes = await firebaseHelper.getAllClientes();
            dataGridClientes.Rows.Clear();
            dataGridProductos.Rows.Clear();
            dataGridCtaCte.Rows.Clear();
            dataGridCompras.Rows.Clear();
            foreach (var cliente in clientes)
            {
                dataGridClientes.Rows.Add(cliente.dnicuit, cliente.nombre, cliente.telefono, cliente.email, cliente.situacion_fiscal, cargarTotalCtaCte(cliente.dnicuit));
            }
            foreach (DataGridViewRow row in dataGridClientes.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    foreach (var venta in ventas)
                    {
                        if (row.Cells[0].Value.ToString().Equals(venta.nombre_cliente))
                        {
                            ventasCargaCtaCte.Add(venta);
                        }
                    }
                }
            }
            dataGridClientes.Rows.Clear();
            foreach (var cliente in clientes)
            {
                string total = cargarTotalCtaCte(cliente.dnicuit);
                string pagos = cargaPagos(cliente.dnicuit);
                dataGridClientes.Rows.Add(cliente.dnicuit, 
                    cliente.nombre,
                    cliente.telefono,
                    cliente.email,
                    cliente.situacion_fiscal,
                    total,
                    pagos,
                    (Int32.Parse(total)-Int32.Parse(pagos)).ToString(),
                    cargarComprasTotales(cliente.dnicuit));
            }

        }

        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        private string cargarTotalCtaCte(string id)
        {
            int total = 0;
            foreach (var venta in ventasCargaCtaCte)
            {
                if (venta.nombre_cliente.Equals(id))
                {
                    foreach (var forma in formaPagos)
                    {
                        if (forma.foranea.Equals(venta.id) && forma.nombre.Equals("cta cte"))
                        {
                            total += Int32.Parse(forma.monto);
                        }
                    }
                }
            }

            return total.ToString();
        }
        private string cargarComprasTotales(string id)
        {
            int total = 0;
            foreach (var venta in ventasCargaCtaCte)
            {
                if (venta.nombre_cliente.Equals(id))
                {
                    total++;
                }
            }

            return total.ToString();
        }
        private string cargaPagos(string id)
        {
            int total = 0;
            foreach (var forma in formaPagos)
            {
                if (forma.foranea.Equals(id))
                {
                    total += Int32.Parse(forma.monto);
                }
            }
            return total.ToString();
        }
        private void cargarCompras(string id)
        {
            dataGridCompras.Rows.Clear();
            foreach (var vent in ventasCargaCtaCte)
            {
                if (vent.nombre_cliente.Equals(id))
                {
                    int año = Int32.Parse(vent.fecha.Substring(6, 4));
                    int mes = Int32.Parse(vent.fecha.Substring(3, 2));
                    int dia = Int32.Parse(vent.fecha.Substring(0, 2));
                    int hora = Int32.Parse(vent.hora.Substring(0, 2));
                    int min = Int32.Parse(vent.hora.Substring(3, 2));
                    DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);
                    dataGridCompras.Rows.Add(vent.id, fecha, vent.nombre_sucursal, vent.tipo_pago, vent.total, vent.ganancia, vent.estado, vent.nombre_empleado, vent.nombre_cliente);
                }
                dataGridCompras.Sort(dataGridCompras.Columns[1], System.ComponentModel.ListSortDirection.Descending);
            }
        }
        private void cargarPagos(string id)
        {
            dataGridCtaCte.Rows.Clear();
            foreach (var forma in formaPagos)
            {
                if (forma.foranea.Equals(id))
                {
                    dataGridCtaCte.Rows.Add(forma.fecha,forma.nombre,forma.monto,forma.sucursal,forma.comentario);
                }

            }
        }

        private void cargarDetalleCompra(string id)
        {
            dataGridProductos.Rows.Clear();
            foreach (var producto in productosVentas)
            {
                if (producto.foranea.Equals(id))
                {
                    dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        private void calcularTotal()
        {
            try
            {
                int total = 0;
                foreach (DataGridViewRow item in this.dataGridCompras.SelectedRows)
                {
                    total = total + Int32.Parse(item.Cells[4].Value.ToString());
                }
                textTotal.Text = "Total: $" + total.ToString();
            }
            catch (Exception es)
            {

            }
        }
        private void cargarTodasVentas()
        {
            dataGridCompras.Rows.Clear();
            foreach (var vent in ventasCargaCtaCte)
            {
                try
                {
                    Int32.Parse(vent.nombre_cliente);
                    int año = Int32.Parse(vent.fecha.Substring(6, 4));
                    int mes = Int32.Parse(vent.fecha.Substring(3, 2));
                    int dia = Int32.Parse(vent.fecha.Substring(0, 2));
                    int hora = Int32.Parse(vent.hora.Substring(0, 2));
                    int min = Int32.Parse(vent.hora.Substring(3, 2));
                    DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);
                    dataGridCompras.Rows.Add(vent.id, fecha, vent.nombre_sucursal, vent.tipo_pago, vent.total, vent.ganancia, vent.estado, vent.nombre_empleado, vent.nombre_cliente);
                }
                catch(Exception es)
                {

                }
            }
            dataGridCompras.Sort(dataGridCompras.Columns[1], System.ComponentModel.ListSortDirection.Descending);
        }

        
        private void exportarVentas()
        {
            try
            {
                SLDocument sl = new SLDocument(rutaModeloClientes);

                int j = 3;
                int i = 0;
                int k = 0;
                foreach (DataGridViewRow row in dataGridClientes.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        sl.SetCellValue("B" + j.ToString(), row.Cells[0].Value.ToString());
                        sl.SetCellValue("C" + j.ToString(), row.Cells[1].Value.ToString());
                        sl.SetCellValue("D" + j.ToString(), row.Cells[2].Value.ToString());
                        sl.SetCellValue("E" + j.ToString(), row.Cells[3].Value.ToString());
                        sl.SetCellValue("F" + j.ToString(), row.Cells[4].Value.ToString());
                        sl.SetCellValue("G" + j.ToString(), row.Cells[5].Value.ToString());
                        sl.SetCellValue("H" + j.ToString(), row.Cells[6].Value.ToString());
                        sl.SetCellValue("I" + j.ToString(), row.Cells[7].Value.ToString());
                        sl.SetCellValue("K" + j.ToString(), row.Cells[8].Value.ToString());

                        i = j;
                        k = j;
                        int sum = 0;
                        foreach (var vent in ventasCargaCtaCte)
                        {
                            if (vent.nombre_cliente.Equals(row.Cells[0].Value.ToString()))
                            {

                                int año = Int32.Parse(vent.fecha.Substring(6, 4));
                                int mes = Int32.Parse(vent.fecha.Substring(3, 2));
                                int dia = Int32.Parse(vent.fecha.Substring(0, 2));
                                int hora = Int32.Parse(vent.hora.Substring(0, 2));
                                int min = Int32.Parse(vent.hora.Substring(3, 2));
                                DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);
                                sl.SetCellValue("L" + i.ToString(), vent.id);
                                sl.SetCellValue("M" + i.ToString(), fecha.ToString("dd/MM/yyyy"));
                                sl.SetCellValue("N" + i.ToString(), vent.nombre_sucursal);
                                sl.SetCellValue("O" + i.ToString(), vent.tipo_pago);
                                sl.SetCellValue("P" + i.ToString(), vent.total);
                                sl.SetCellValue("R" + i.ToString(), vent.ganancia);
                                sl.SetCellValue("S" + i.ToString(), vent.estado);
                                sl.SetCellValue("T" + i.ToString(), vent.nombre_empleado);
                                sl.SetCellValue("U" + i.ToString(), vent.nombre_cliente);
                                i++;
                                sum++;
                                foreach (var producto in productosVentas)
                                {
                                    if (producto.foranea.Equals(vent.id))
                                    {
                                        sl.SetCellValue("W" + k.ToString(), producto.nombre_articulo);
                                        sl.SetCellValue("X" + k.ToString(), producto.descripcion);
                                        sl.SetCellValue("Y" + k.ToString(), producto.costo);

                                        sum++;
                                        k++;
                                    }
                                }
                            }
                        }
                        


                        j = j + sum;
                        j++;
                        j++;
                    }
                }
                sl.SaveAs(rutaSalidaClientes + " Exportacion Clientes" + ".xlsx");
                MessageBox.Show("Se Exportaron Clientes", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }

    }
}

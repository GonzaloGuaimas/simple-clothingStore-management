using System;
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

namespace GiftGestion.Secciones.SubSecciones
{
    public partial class GenerarCambio : Form
    {
        Usuario user = new Usuario();
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Producto> productos = new List<Producto>();
        List<Producto> productosVenta = new List<Producto>();
        List<Producto> productosDevolucion = new List<Producto>();
        List<Producto> productosActualizar = new List<Producto>();
        List<FormaPago> formaPagoVenta = new List<FormaPago>();
        List<Clave> claves = new List<Clave>();

        Venta venta = new Venta();
        private int subtotal = 0;
        private int total = 0;
        private int ganancia = 0;
        public GenerarCambio(Usuario usuario)
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

        private async void GenerarCambio_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cargarProductos();

            textEmpleado.Text = user.apellido + " " + user.nombre;
            textSucursal.Text = user.sucursal;
        }


        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregarProducto();
        }

        private void buttonGenerarVenta_Click(object sender, EventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                generarVenta();
            }

        }

        private void dataGridProductos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (dataGridProductos.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Producto  " + dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridProductos.Rows.RemoveAt(e.RowIndex);
                        calcular();
                    }
                }
            }
        }
        private void dataGridDevolucion_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (dataGridDevolucion.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Producto  " + dataGridDevolucion.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridDevolucion.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridDevolucion.Rows.RemoveAt(e.RowIndex);
                        calcular();
                    }
                }
            }
        }

        private void buttonAgregarFormaPago_Click(object sender, EventArgs e)
        {
            agregarPago();

        }

        private void dataGridPagos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (dataGridPagos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Pago  " + dataGridPagos.Rows[e.RowIndex].Cells[0].Value.ToString() + " " + dataGridPagos.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridPagos.Rows.RemoveAt(e.RowIndex);
                        calcular();
                    }
                }
            }
        }
        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                agregarProducto();
            }
        }
        private void textCodigoDevolucion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void buttonBuscarProdDevolucion_Click(object sender, EventArgs e)
        {
            agregarProductoDevolucion();
        }
        private void textMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                agregarPago();
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

        private void comboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoPago.Text.Equals("Efectivo") || comboTipoPago.Text.Equals("Lista") || comboTipoPago.Text.Equals("Costo"))
            {
                textCodigo.Enabled = true;

                try
                {
                    List<Producto> productosAux = new List<Producto>();
                    Producto producto = null;
                    foreach (DataGridViewRow row in dataGridProductos.Rows)
                    {

                        if (row.Cells[0].Value != null)
                        {
                            producto = new Producto();
                            producto.id = row.Cells[0].Value.ToString();
                            producto.nombre_articulo = row.Cells[1].Value.ToString();
                            producto.descripcion = row.Cells[2].Value.ToString();
                            producto.precio = row.Cells[3].Value.ToString();
                            producto.proveedor = row.Cells[4].Value.ToString();
                            producto.estacion = row.Cells[5].Value.ToString();
                            producto.color = row.Cells[6].Value.ToString();
                            producto.talle = row.Cells[7].Value.ToString();
                            producto.grupo = row.Cells[8].Value.ToString();
                            producto.cantidad = "1";

                            producto.costo = row.Cells[9].Value.ToString();
                            producto.precio_lista = row.Cells[10].Value.ToString();
                            producto.precio_efectivo = row.Cells[11].Value.ToString();

                            productosAux.Add(producto);
                        }
                    }
                    dataGridProductos.Rows.Clear();
                    string precio = "";
                    foreach (var product in productosAux)
                    {
                        if (comboTipoPago.Text.Equals("Efectivo"))
                        {
                            precio = product.precio_efectivo;
                        }
                        else if (comboTipoPago.Text.Equals("Lista"))
                        {
                            precio = product.precio_lista;
                        }
                        else if (comboTipoPago.Text.Equals("Costo"))
                        {
                            precio = product.costo;
                        }
                        dataGridProductos.Rows.Add(product.id, product.nombre_articulo, product.descripcion, precio,
                              product.proveedor, product.estacion, product.color, product.talle, product.grupo,
                              product.costo, product.precio_lista, product.precio_efectivo);
                    }
                    calcular();


                }
                catch (Exception es)
                {

                }
            }
        }
        private void comboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFormaPago.Text.Equals("descuento"))
            {
                textContraseña.Visible = true;
                textContraseñalabel.Visible = true;
            }
            else if (comboFormaPago.Text.Equals("canje"))
            {
                MessageBox.Show("PEDIR AUTORIZACIÓN a GERENTES y agregar OBSERVACIÓN");
                textContraseña.Visible = true;
                textContraseñalabel.Visible = true;
            }
            else
            {
                textContraseña.Visible = false;
                textContraseñalabel.Visible = false;
            }
        }
        //---------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------
        private async void generarVenta()
        {
            try
            {
                if (!textSucursal.Text.Equals("-"))
                {
                    if (dataGridProductos.Rows.Count > 1)
                    {
                        if (dataGridPagos.Rows.Count > 1)
                        {
                            Boolean band = false;
                            foreach (DataGridViewRow row in dataGridPagos.Rows)
                            {
                                if (row.Cells[0].Value != null)
                                {
                                    if (row.Cells[0].Value.ToString().Equals("cta cte"))
                                    {
                                        band = true;
                                    }
                                }
                            }

                            if (band == false)
                            {
                                if (!comboTipoPago.Text.Equals(""))
                                {
                                    buttonGenerarVenta.Enabled = false;
                                    buttonGenerarVenta.Text = "Espere Porfavor...";

                                    productosVenta = new List<Producto>();
                                    productosDevolucion = new List<Producto>();
                                    productosActualizar = new List<Producto>();
                                    formaPagoVenta = new List<FormaPago>();
                                    Producto producto = null;
                                    FormaPago formaPago = null;
                                    foreach (DataGridViewRow row in dataGridProductos.Rows)
                                    {
                                        if (row.Cells[0].Value != null)
                                        {
                                            producto = new Producto();
                                            producto.id = row.Cells[0].Value.ToString();
                                            producto.nombre_articulo = row.Cells[1].Value.ToString();
                                            producto.descripcion = row.Cells[2].Value.ToString();
                                            producto.precio = row.Cells[3].Value.ToString();
                                            producto.proveedor = row.Cells[4].Value.ToString();
                                            producto.estacion = row.Cells[5].Value.ToString();
                                            producto.color = row.Cells[6].Value.ToString();
                                            producto.talle = row.Cells[7].Value.ToString();
                                            producto.grupo = row.Cells[8].Value.ToString();
                                            producto.cantidad = "1";
                                            producto.puey = "1";
                                            producto.stgo = "1";
                                            producto.general = "1";
                                            producto.deposito = "1";


                                            producto.costo = row.Cells[9].Value.ToString();
                                            producto.precio_lista = row.Cells[10].Value.ToString();
                                            producto.precio_efectivo = row.Cells[11].Value.ToString();

                                            productosVenta.Add(producto);
                                            productosActualizar.Add(producto);
                                        }
                                    }
                                    foreach (DataGridViewRow row in dataGridDevolucion.Rows)
                                    {
                                        if (row.Cells[0].Value != null)
                                        {
                                            producto = new Producto();
                                            producto.id = row.Cells[0].Value.ToString();
                                            producto.nombre_articulo = row.Cells[1].Value.ToString();
                                            producto.descripcion = row.Cells[2].Value.ToString();
                                            producto.precio = row.Cells[3].Value.ToString();
                                            producto.proveedor = row.Cells[4].Value.ToString();
                                            producto.estacion = row.Cells[5].Value.ToString();
                                            producto.color = row.Cells[6].Value.ToString();
                                            producto.talle = row.Cells[7].Value.ToString();
                                            producto.grupo = row.Cells[8].Value.ToString();
                                            producto.cantidad = "1";
                                            producto.puey = "1";
                                            producto.stgo = "1";
                                            producto.general = "1";

                                            producto.costo = row.Cells[9].Value.ToString();
                                            producto.precio_lista = row.Cells[10].Value.ToString();
                                            producto.precio_efectivo = row.Cells[11].Value.ToString();

                                            productosDevolucion.Add(producto);
                                            productosActualizar.Add(producto);
                                        }

                                    }
                                    foreach (DataGridViewRow row in dataGridPagos.Rows)
                                    {
                                        if (row.Cells[0].Value != null)
                                        {
                                            formaPago = new FormaPago();
                                            formaPago.nombre = row.Cells[0].Value.ToString();
                                            formaPago.fecha = row.Cells[1].Value.ToString();
                                            formaPago.monto = row.Cells[2].Value.ToString();
                                            formaPagoVenta.Add(formaPago);
                                        }

                                    }
                                    string estado = "";
                                    if (total <= 0)
                                    {
                                        estado = "Concretada";
                                    }
                                    else if (total > 0)
                                    {
                                        estado = "Pendiente";
                                    }

                                    if (venta.id == null)
                                    {
                                        string id = DateTime.Now.ToString("ddMMyyyyHHmmss");

                                        firebaseHelper.addCambio(id, dateFecha.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"),
                                            textEmpleado.Text, textSucursal.Text, "-", textObservacion.Text, estado, comboTipoPago.Text,
                                            subtotal.ToString(), ganancia.ToString());

                                        firebaseHelper.addDetalleCambio(id, productosVenta);

                                        firebaseHelper.addDetalleFormaPago(id, formaPagoVenta);

                                        await firebaseHelper.addProductos(productosDevolucion, "+", " ", textSucursal.Text, "+");
                                        await firebaseHelper.addProductos(productosActualizar, "-", " ", textSucursal.Text, "-");

                                        MessageBox.Show("Venta Realizada. Estado: " + estado);
                                    }
                                    
                                    this.Close();
                                    CambiosForm generarVenta = new CambiosForm(user);
                                    generarVenta.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione tipo de Pago");
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Inserte Pagos en Tabla");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Inserte productos en Tabla");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione Sucursal");
                }


            }
            catch (Exception es)
            {
                buttonGenerarVenta.Enabled = true;
                buttonGenerarVenta.Text = "Generar Venta";
            }
        }
        private Boolean verificarStock(string id, int cant)
        {
            Boolean band = true;
            return band;
        }

        private void agregarProducto()
        {
            if (comboTipoPago.Text.Equals("Efectivo") || comboTipoPago.Text.Equals("Lista") || comboTipoPago.Text.Equals("Costo"))
            {
                try
                {
                    Boolean band = false;
                    string precio = "";


                    foreach (var producto in productos)
                    {
                        if (producto.id.Equals(textCodigo.Text))
                        {
                            band = true;
                            if (comboTipoPago.Text.Equals("Efectivo"))
                            {
                                precio = producto.precio_efectivo;
                            }
                            else if (comboTipoPago.Text.Equals("Lista"))
                            {
                                precio = producto.precio_lista;
                            }
                            else if (comboTipoPago.Text.Equals("Costo"))
                            {
                                precio = producto.costo;
                            }
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, precio,
                                                         producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.costo, producto.precio_lista, producto.precio_efectivo, "NO");


                            calcular();
                            textCodigo.Text = "";
                            this.ActiveControl = textCodigo;
                            break;
                        }
                    }
                    if (!band)
                    {
                        MessageBox.Show("No se encontró producto");
                    }
                }
                catch (Exception es)
                {

                }
            }
            else
            {
                MessageBox.Show("Seleccione Tipo de Pago");
            }
        }
        private void agregarProductoDevolucion()
        {
            try
            {
                Boolean band = false;
                string precio = "";
                foreach (var producto in productos)
                {
                    if (producto.id.Equals(textCodigoDevolucion.Text))
                    {
                        dataGridDevolucion.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, precio,
                                producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.costo, producto.precio_lista, producto.precio_efectivo);
                        band = true;
                        textCodigoDevolucion.Text = "";
                        this.ActiveControl = textCodigoDevolucion;
                        break;
                    }
                }
                if (!band)
                {
                    MessageBox.Show("No se encontró producto");
                }
            }
            catch (Exception es)
            {

            }
        }

        private async void cargarProductos()
        {
            try
            {
                var products = await firebaseHelper.getAllProductosV2();
                if (products != null)
                {
                    foreach (var producto in products)
                    {
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception es)
            {

            }
        }


        private async void agregarPago()
        {
            try
            {
                if (comboFormaPago.Text.Equals("descuento") || comboFormaPago.Text.Equals("canje"))
                {
                    if (!textMonto.Text.Equals("") && !textContraseña.Text.Equals(""))
                    {
                        Boolean band = false;
                        foreach (var clave in claves)
                        {
                            if (clave.clave.Equals(textContraseña.Text))
                            {
                                band = true;
                            }
                        }
                        if (band)
                        {
                            dataGridPagos.Rows.Add(comboFormaPago.Text, dateFechaPago.Value.ToString("dd/MM/yyyy"), textMonto.Text);
                            calcular();
                            comboFormaPago.Text = "";
                            textMonto.Text = "";
                            textContraseña.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Complete Campos");
                    }
                }

                else
                {
                    if (!comboFormaPago.Text.Equals("") && !textMonto.Text.Equals(""))
                    {

                        dataGridPagos.Rows.Add(comboFormaPago.Text, dateFechaPago.Value.ToString("dd/MM/yyyy"), textMonto.Text);
                        calcular();
                        comboFormaPago.Text = "";
                        textMonto.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Complete Campos");
                    }
                }

            }
            catch (Exception es)
            {

            }
        }
        private void calcular()
        {
            subtotal = 0;
            int pago = 0;
            total = 0;
            int costoTotal = 0;
            int descuento = 0;

            foreach (DataGridViewRow row in dataGridProductos.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    subtotal = subtotal - Int32.Parse(row.Cells[3].Value.ToString());
                    costoTotal = costoTotal - Int32.Parse(row.Cells[9].Value.ToString());
                }

            }
            foreach (DataGridViewRow row in dataGridDevolucion.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    subtotal = subtotal + Int32.Parse(row.Cells[3].Value.ToString());
                    costoTotal = costoTotal + Int32.Parse(row.Cells[9].Value.ToString());
                }

            }
            foreach (DataGridViewRow row in dataGridPagos.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString().Equals("descuento") ||
                        row.Cells[0].Value.ToString().Equals("canje") ||
                        row.Cells[0].Value.ToString().Equals("billetes") ||
                        row.Cells[0].Value.ToString().Equals("gift card")
                        )
                    {
                        descuento = descuento + Int32.Parse(row.Cells[2].Value.ToString());
                    }

                    pago = pago + Int32.Parse(row.Cells[2].Value.ToString());
                }
            }
            if (descuento > 0)
            {
                ganancia = (pago - costoTotal) - descuento;
                if (ganancia <= 0)
                {
                    ganancia = 0;
                }
            }
            else
            {
                ganancia = (pago - costoTotal);
            }

            total = subtotal - pago;
            textTotal.Text = "TOTAL: $" + total.ToString();
            textSubtotal.Text = "SUBTOTAL: $" + subtotal.ToString();
        }


    }
}

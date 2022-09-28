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
    public partial class GenerarVenta : Form
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
        public GenerarVenta(Usuario usuario,Venta ven)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitializeComponent();
                user = usuario;
                venta = ven;
            }

            
        }
        private async void GenerarVenta_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //precargaProductos(user.sucursal);
            
            cargarProductos();

            textEmpleado.Text = user.apellido + " " + user.nombre;
            textSucursal.Text = user.sucursal;

            claves = await firebaseHelper.getAllClaves();

            var gruposCarga = await firebaseHelper.getAllGrupos();
            foreach (var grupo in gruposCarga)
            {
                comboFiltroGrupo.Items.Add(grupo.nombre_grupo);
            }

            if (venta.id == null)
            {
                textEstado.Text = "-";
                textCliente.Text = "-";
            }
            else
            {
                //cargar toda la venta
                textEstado.Text = venta.estado;
                textCliente.Text = venta.nombre_cliente;
                textSucursal.Text = venta.nombre_sucursal;
                textEmpleado.Text = venta.nombre_empleado;
                textObservacion.Text = venta.observacion;

                dateFecha.Value = Convert.ToDateTime(venta.fecha);
                comboTipoPago.Text = venta.tipo_pago;
                buttonGenerarVenta.Text = "Actualizar Venta";

                var prods = await firebaseHelper.getAllDetalleVenta();

                foreach (var producto in prods)
                {
                    if (producto.foranea.Equals(venta.id))
                    {
                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.precio,
                                producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.costo, producto.precio_lista, producto.precio_efectivo);
                    }
                }

                var formasPagos = await firebaseHelper.getAllDetalleFormaPago();

                foreach (var forma in formasPagos)
                {
                    if (forma.foranea.Equals(venta.id))
                    {
                        dataGridPagos.Rows.Add(forma.nombre, forma.fecha, forma.monto);
                    }
                }
                calcular();
            }

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------



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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                agregarProductoDevolucion();
            }
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

        private void dataGridProductosSucursal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridProductosSucursal.Rows[e.RowIndex].Cells[0].Value != null)
            {
                if (comboTipoPago.Text.Equals("Efectivo") || comboTipoPago.Text.Equals("Lista") || comboTipoPago.Text.Equals("Costo"))
                {
                    try
                    {
                        Boolean band = false;
                        string precio = "";


                        foreach (var producto in productos)
                        {
                            if (dataGridProductosSucursal.Rows[e.RowIndex].Cells[0].Value.ToString().Equals(producto.id))
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

                                if (buttonAbrirDevolucion.Text.Equals("Cerrar Devolución"))
                                {
                                    dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, precio,
                                  producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.costo, producto.precio_lista, producto.precio_efectivo, "SI");
                                }
                                else
                                {
                                    dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, precio,
                                  producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.costo, producto.precio_lista, producto.precio_efectivo, "NO");
                                }
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
        }
        private async void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = await firebaseHelper.getCliente(textBuscarCliente.Text);

                if (cliente != null)
                {
                    textDNICUIL.Text = cliente.dnicuit;
                    textNombre.Text = cliente.nombre;
                    textTelefono.Text = cliente.telefono;
                    textEmail.Text = cliente.email;
                    textSituacionFiscal.Text = cliente.situacion_fiscal;
                    textCliente.Text = cliente.dnicuit;
                }


            }
            catch (Exception es)
            {

            }
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
        private void buttonAbrirDevolucion_Click(object sender, EventArgs e)
        {
            if (buttonAbrirDevolucion.Text.Equals("Cerrar Devolución"))
            {
                panelCodDevolucion.Visible = false;
                dataGridDevolucion.Visible = false;
                buttonAbrirDevolucion.Text = "Abrir Devolución";
            }
            else if (buttonAbrirDevolucion.Text.Equals("Abrir Devolución"))
            {
                panelCodDevolucion.Visible = true;
                dataGridDevolucion.Visible = true;
                buttonAbrirDevolucion.Text = "Cerrar Devolución";
                MessageBox.Show("Elimine sólo el producto a devolución del listado 'Productos Agregados' y luego agregueló por codigo de barras en 'Productos Devolución'");
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

                            if (band == true && !textDNICUIL.Text.Equals(""))
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
                                            producto.general = "1";
                                            producto.deposito = "1";
                                            producto.puey = "1";
                                            producto.stgo = "1";

                                            producto.costo = row.Cells[9].Value.ToString();
                                            producto.precio_lista = row.Cells[10].Value.ToString();
                                            producto.precio_efectivo = row.Cells[11].Value.ToString();

                                            productosVenta.Add(producto);
                                        }
                                    }
                                    foreach (DataGridViewRow row in dataGridProductos.Rows)
                                    {
                                        if (row.Cells[0].Value != null)
                                        {
                                            if (row.Cells[12].Value != null)
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
                                                producto.general = "1";
                                                producto.deposito = "1";
                                                producto.puey = "1";
                                                producto.stgo = "1";

                                                producto.costo = row.Cells[9].Value.ToString();
                                                producto.precio_lista = row.Cells[10].Value.ToString();
                                                producto.precio_efectivo = row.Cells[11].Value.ToString();

                                                productosActualizar.Add(producto);
                                            }

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
                                            producto.general = "1";
                                            producto.deposito = "1";
                                            producto.puey = "1";
                                            producto.stgo = "1";

                                            producto.costo = row.Cells[9].Value.ToString();
                                            producto.precio_lista = row.Cells[10].Value.ToString();
                                            producto.precio_efectivo = row.Cells[11].Value.ToString();

                                            productosDevolucion.Add(producto);
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
                                    if (total <= 0 )
                                    {
                                        estado = "Concretada";
                                    }
                                    else if(total > 0)
                                    {
                                        estado = "Pendiente";
                                    }

                                    if (venta.id == null)
                                    {
                                        string id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                                        firebaseHelper.addVenta(id, dateFecha.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"),
                                            textEmpleado.Text, textSucursal.Text, textDNICUIL.Text, textObservacion.Text, estado, comboTipoPago.Text,
                                            subtotal.ToString(), ganancia.ToString());

                                        firebaseHelper.addDetalleVenta(id, productosVenta);

                                        firebaseHelper.addDetalleFormaPago(id, formaPagoVenta);

                                        firebaseHelper.addProductos(productosActualizar, "-", " ", textSucursal.Text, "-");

                                        //firebaseHelper.updateProductosSucursal(textSucursal.Text, productosVenta, "Salida");
                                        //firebaseHelper.updateProductos(productosVenta, "Salida");

                                        if (!textDNICUIL.Text.Equals(""))
                                        {
                                            firebaseHelper.updateCliente(textDNICUIL.Text, textNombre.Text, textTelefono.Text, textEmail.Text, textSituacionFiscal.Text);
                                        }


                                        MessageBox.Show("Venta Realizada. Estado: " + estado);
                                    }
                                    else
                                    {
                                        if (buttonAbrirDevolucion.Text.Equals("Cerrar Devolución"))
                                        {
                                            firebaseHelper.updateVenta(venta.id, venta.fecha, venta.hora,
                                        textEmpleado.Text, textSucursal.Text, textDNICUIL.Text, textObservacion.Text, estado, comboTipoPago.Text,
                                        subtotal.ToString(), ganancia.ToString());

                                            foreach (DataGridViewRow row in dataGridDevolucion.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    firebaseHelper.deleteDetalleVenta(venta.id);

                                                }
                                            }

                                            await firebaseHelper.addProductos(productosDevolucion, "+", " ", textSucursal.Text, "+");

                                            await firebaseHelper.addProductos(productosActualizar, "-", " ", textSucursal.Text, "-");

                                            //firebaseHelper.updateProductosSucursal(textSucursal.Text, productosDevolucion, "Entrada");
                                            //firebaseHelper.updateProductos(productosDevolucion, "Entrada");

                                            //firebaseHelper.updateProductosSucursal(textSucursal.Text, productosActualizar, "Salida");
                                            //firebaseHelper.updateProductos(productosActualizar, "Salida");

                                            foreach (DataGridViewRow row in dataGridProductos.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    await firebaseHelper.deleteDetalleVenta(venta.id);
                                                }
                                            }

                                            firebaseHelper.addDetalleVenta(venta.id, productosVenta);

                                            foreach (DataGridViewRow row in dataGridPagos.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    await firebaseHelper.deleteDetalleFormaPago(venta.id);
                                                }

                                            }


                                            firebaseHelper.addDetalleFormaPago(venta.id, formaPagoVenta);

                                            if (!textDNICUIL.Text.Equals(""))
                                            {
                                                firebaseHelper.updateCliente(textDNICUIL.Text, textNombre.Text, textTelefono.Text, textEmail.Text, textSituacionFiscal.Text);
                                            }


                                            MessageBox.Show("Venta Actualizada. Estado: " + estado);
                                        }
                                        else if (buttonAbrirDevolucion.Text.Equals("Abrir Devolución"))
                                        {
                                            firebaseHelper.updateVenta(venta.id, venta.fecha, venta.hora,
                                      textEmpleado.Text, textSucursal.Text, textDNICUIL.Text, textObservacion.Text, estado, comboTipoPago.Text,
                                      subtotal.ToString(), ganancia.ToString());

                                            foreach (DataGridViewRow row in dataGridPagos.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    await firebaseHelper.deleteDetalleFormaPago(venta.id);
                                                }

                                            }


                                            firebaseHelper.addDetalleFormaPago(venta.id, formaPagoVenta);

                                            if (!textDNICUIL.Text.Equals(""))
                                            {
                                                firebaseHelper.updateCliente(textDNICUIL.Text, textNombre.Text, textTelefono.Text, textEmail.Text, textSituacionFiscal.Text);
                                            }


                                            MessageBox.Show("Venta Actualizada. Estado: " + estado);
                                        }


                                    }

                                    this.Close();
                                    Venta ven = new Venta();
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione tipo de Pago");
                                }
                            }
                            else if (band == true && textDNICUIL.Text.Equals(""))
                            {
                                MessageBox.Show("Completar DNI Cliente CTA CTE");
                            }
                            else if (band == false)
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
                                        }
                                    }
                                    foreach (DataGridViewRow row in dataGridProductos.Rows)
                                    {
                                        if (row.Cells[0].Value != null)
                                        {
                                            if (row.Cells[12].Value != null)
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

                                                productosActualizar.Add(producto);
                                            }

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

                                        firebaseHelper.addVenta(id, dateFecha.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"),
                                            textEmpleado.Text, textSucursal.Text, textDNICUIL.Text, textObservacion.Text, estado, comboTipoPago.Text,
                                            subtotal.ToString(), ganancia.ToString());

                                        firebaseHelper.addDetalleVenta(id, productosVenta);

                                        firebaseHelper.addDetalleFormaPago(id, formaPagoVenta);

                                        firebaseHelper.addProductos(productosVenta, "-", " ", textSucursal.Text, "-");

                                        //firebaseHelper.updateProductosSucursal(textSucursal.Text, productosVenta, "Salida");
                                        //firebaseHelper.updateProductos(productosVenta, "Salida");

                                        if (!textDNICUIL.Text.Equals(""))
                                        {
                                            firebaseHelper.updateCliente(textDNICUIL.Text, textNombre.Text, textTelefono.Text, textEmail.Text, textSituacionFiscal.Text);
                                        }


                                        MessageBox.Show("Venta Realizada. Estado: " + estado);
                                    }
                                    else
                                    {
                                        if (buttonAbrirDevolucion.Text.Equals("Cerrar Devolución"))
                                        {
                                            firebaseHelper.updateVenta(venta.id, venta.fecha, venta.hora,
                                        textEmpleado.Text, textSucursal.Text, textDNICUIL.Text, textObservacion.Text, estado, comboTipoPago.Text,
                                        subtotal.ToString(), ganancia.ToString());

                                            foreach (DataGridViewRow row in dataGridDevolucion.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    firebaseHelper.deleteDetalleVenta(venta.id);

                                                }
                                            }
                                            await firebaseHelper.addProductos(productosDevolucion, "+", " ", textSucursal.Text, "+");
                                            await firebaseHelper.addProductos(productosActualizar, "-", " ", textSucursal.Text, "-");

                                            //firebaseHelper.updateProductosSucursal(textSucursal.Text, productosDevolucion, "Entrada");
                                            //firebaseHelper.updateProductos(productosDevolucion, "Entrada");

                                            //firebaseHelper.updateProductosSucursal(textSucursal.Text, productosActualizar, "Salida");
                                            //firebaseHelper.updateProductos(productosActualizar, "Salida");

                                            foreach (DataGridViewRow row in dataGridProductos.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    await firebaseHelper.deleteDetalleVenta(venta.id);
                                                }
                                            }

                                            firebaseHelper.addDetalleVenta(venta.id, productosVenta);

                                            foreach (DataGridViewRow row in dataGridPagos.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    await firebaseHelper.deleteDetalleFormaPago(venta.id);
                                                }

                                            }


                                            firebaseHelper.addDetalleFormaPago(venta.id, formaPagoVenta);

                                            if (!textDNICUIL.Text.Equals(""))
                                            {
                                                firebaseHelper.updateCliente(textDNICUIL.Text, textNombre.Text, textTelefono.Text, textEmail.Text, textSituacionFiscal.Text);
                                            }


                                            MessageBox.Show("Venta Actualizada. Estado: " + estado);
                                        }
                                        else if (buttonAbrirDevolucion.Text.Equals("Abrir Devolución"))
                                        {
                                            firebaseHelper.updateVenta(venta.id, venta.fecha, venta.hora,
                                      textEmpleado.Text, textSucursal.Text, textDNICUIL.Text, textObservacion.Text, estado, comboTipoPago.Text,
                                      subtotal.ToString(), ganancia.ToString());

                                            foreach (DataGridViewRow row in dataGridPagos.Rows)
                                            {
                                                if (row.Cells[0].Value != null)
                                                {
                                                    await firebaseHelper.deleteDetalleFormaPago(venta.id);
                                                }

                                            }


                                            firebaseHelper.addDetalleFormaPago(venta.id, formaPagoVenta);

                                            if (!textDNICUIL.Text.Equals(""))
                                            {
                                                firebaseHelper.updateCliente(textDNICUIL.Text, textNombre.Text, textTelefono.Text, textEmail.Text, textSituacionFiscal.Text);
                                            }


                                            MessageBox.Show("Venta Actualizada. Estado: " + estado);
                                        }


                                    }

                                    this.Close();
                                    Venta ven = new Venta();
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
               
                
            }catch(Exception es)
            {
                buttonGenerarVenta.Enabled = true;
                buttonGenerarVenta.Text = "Generar Venta";
            }
        }
        private Boolean verificarStock(string id,int cant)
        {
            Boolean band = true;
            /*
            try
            {
                int cantAgregada = 0;
                foreach (DataGridViewRow row in dataGridProductos.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(id))
                        {
                            cantAgregada++;
                        }
                    }
                }
                if ((cant - cantAgregada)==0)
                {
                    band = false;
                }
            }
            catch(Exception es)
            {

            }*/
            return band;
        }

        private void agregarProducto()
        {
            if(comboTipoPago.Text.Equals("Efectivo") || comboTipoPago.Text.Equals("Lista") || comboTipoPago.Text.Equals("Costo"))
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
                            if (buttonAbrirDevolucion.Text.Equals("Cerrar Devolución"))
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, precio,
                              producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.costo, producto.precio_lista, producto.precio_efectivo, "SI");
                            }
                            else
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, precio,
                              producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.costo, producto.precio_lista, producto.precio_efectivo, "NO");
                            }


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
        private async void precargaProductos(string sucursal)
        {
            try
            {
                var products = await firebaseHelper.getAllProductosSucursal(sucursal);
                if (products != null)
                {
                    foreach (var producto in products)
                    {
                        productos.Add(producto);

                        if (Int32.Parse(producto.cantidad)>0)
                        {
                            //productos.Add(producto);
                        }
                    }
                    foreach (var producto in products)
                    {
                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);

                        /*
                        if (Int32.Parse(producto.cantidad) > 0)
                        {
                            dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);

                        }*/
                    }
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
                    foreach (var producto in products)
                    {
                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                    }
                }
            }
            catch(Exception es)
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
                        //var clave = await firebaseHelper.getClave(textContraseña.Text);
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
                if (row.Cells[0].Value !=null)
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
            if (descuento>0)
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



        //---------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------


        private void buttonFiltrarNombre_Click(object sender, EventArgs e)
        {
            try
            {
                if (productos != null)
                {
                    dataGridProductosSucursal.Rows.Clear();
                    string nom = "";
                    string[] var = null;
                    foreach (var producto in productos)
                    {
                        nom = producto.nombre_articulo;
                        var = nom.Split(' ');

                        switch (var.Length)
                        {
                            case 1:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0,3).ToLower().Equals(textNombreFiltrar.Text.Substring(0,3).ToLower()))
                                    {
                                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);

                                    }
                                }
                                break;
                            case 2:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);

                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                                    }
                                }
                                break;
                            case 3:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                                    }
                                }
                                if (var[2].Length > 2)
                                {
                                    if (var[2].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                                    }
                                }
                                break;
                        }
                    }
                }
                textNombreFiltrar.Text = "";
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (productos != null)
                {
                    dataGridProductosSucursal.Rows.Clear();
                    foreach (var producto in productos)
                    {
                        dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                    }
                }
            }
            catch (Exception es)
            {

            }
        }

        private void comboFiltroGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (productos != null)
                {
                    dataGridProductosSucursal.Rows.Clear();
                    foreach (var producto in productos)
                    {
                        if (producto.grupo.Equals(comboFiltroGrupo.Text))
                        {
                            dataGridProductosSucursal.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo);
                        }
                    }
                }
            }
            catch (Exception es)
            {

            }
        }

       
    }
}

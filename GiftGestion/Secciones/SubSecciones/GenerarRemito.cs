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
    public partial class GenerarRemito : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Producto> productos = new List<Producto>();
        List<Producto> productosCarga = new List<Producto>();
        Producto productoSeleccionado = new Producto();
        Usuario user = new Usuario();
        Remito remito = new Remito();
        OrdenCompra orden = new OrdenCompra();
        private int cantidadMax = 0;

        public GenerarRemito(Usuario usuario,Remito rem ,OrdenCompra ord)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitializeComponent();
                user = usuario;
                remito = rem;
                orden = ord;
            }
        }

        private async void cargarRemito()
        {
            if (remito.id!=null)
            {
                comboTipo.Text = "Salida";
                var prods = await firebaseHelper.getAllDetalleRemito();
                int cant = 0;
                foreach (var producto in prods)
                {
                    if (producto.foranea.Equals(remito.id))
                    {
                        cant = cant + Int32.Parse(producto.cantidad);
                        dataGridProductosRemito.Rows.Add(producto.id, producto.nombre_articulo,
                        producto.descripcion, producto.cantidad, producto.proveedor, producto.estacion,
                        producto.color, producto.talle, producto.grupo,
                        producto.precio_lista, producto.precio_efectivo, producto.costo);
                    }
                }
                textTOTAL.Text = cant.ToString();
            }
        }
        private async void cargarOrden()
        {
            try
            {
                var prodsOrden = await firebaseHelper.getAllDetalleOrdenCompra();

                comboTipo.Text = "Entrada";
                textIDOrdenCompra.Text = orden.id;
                foreach (var producto in prodsOrden)
                {
                    if (producto.foranea.Equals(orden.id))
                    {
                        dataGridProductosRemito.Rows.Add(producto.id, producto.nombre_articulo,
                    producto.descripcion, producto.cantidad, producto.proveedor, producto.estacion,
                    producto.color, producto.talle, producto.grupo,
                    producto.precio_lista, producto.precio_efectivo, producto.costo);
                    }     
                }
            }
            catch(Exception es)
            {

            }
        }
        private async void GenerarRemito_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textObservacion;
            WindowState = FormWindowState.Maximized;

            var gruposCarga = await firebaseHelper.getAllGrupos();
            foreach (var grupo in gruposCarga)
            {
                comboFiltroGrupo.Items.Add(grupo.nombre_grupo);
            }
            cargarProductos();
            if (remito.id != null)
            {
                cargarRemito();
            }
            else
            {
                comboTipo.Text = "Salida";
            }
            if (orden.id != null)
            {
                cargarOrden();
            }
        }
      
        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGenerarRemito_Click(object sender, EventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                generarRemito();
            }
           
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            agregarProductoRemito();
            this.ActiveControl = textCodigo;
            textCodigo.Text = "";
        }

        private void dataGridProductos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                try
                {
                    if(dataGridProductos.Rows[e.RowIndex].Cells[0].Value!=null)
                    {
                        productoSeleccionado = new Producto();
                        if (dataGridProductos.Rows[e.RowIndex].Cells[0].Value != null)
                        {
                            if (comboTipo.Text.Equals("Entrada"))
                            {
                                productoSeleccionado.id = dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
                                productoSeleccionado.nombre_articulo = dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
                                productoSeleccionado.descripcion = dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString();

                                if (dataGridProductos.Rows[e.RowIndex].Cells[3].Value!=null)
                                {
                                    productoSeleccionado.cantidad = dataGridProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
                                }
                                
                                productoSeleccionado.proveedor = dataGridProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
                                productoSeleccionado.estacion = dataGridProductos.Rows[e.RowIndex].Cells[5].Value.ToString();
                                productoSeleccionado.color = dataGridProductos.Rows[e.RowIndex].Cells[6].Value.ToString();
                                productoSeleccionado.talle = dataGridProductos.Rows[e.RowIndex].Cells[7].Value.ToString();
                                productoSeleccionado.grupo = dataGridProductos.Rows[e.RowIndex].Cells[8].Value.ToString();
                                productoSeleccionado.precio_lista = dataGridProductos.Rows[e.RowIndex].Cells[9].Value.ToString();
                                productoSeleccionado.precio_efectivo = dataGridProductos.Rows[e.RowIndex].Cells[10].Value.ToString();
                                productoSeleccionado.costo = dataGridProductos.Rows[e.RowIndex].Cells[11].Value.ToString();

                                textInformacion.Text = productoSeleccionado.nombre_articulo + " " + productoSeleccionado.descripcion + " " + productoSeleccionado.color + " " + productoSeleccionado.talle + " " + "Stock Diponible: " + productoSeleccionado.cantidad;
                                this.ActiveControl = textCantidad;
                                textCantidad.Enabled = true;
                                buttonAgregar.Enabled = true;
                            }
                            else if (comboTipo.Text.Equals("Salida") || comboTipo.Text.Equals("Traspaso"))
                            {
                                if (!dataGridProductos.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("0"))
                                {
                                    cantidadMax = Int32.Parse(dataGridProductos.Rows[e.RowIndex].Cells[3].Value.ToString());

                                    textCantidad.Enabled = true;
                                    buttonAgregar.Enabled = true;
                                    productoSeleccionado.id = dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
                                    productoSeleccionado.nombre_articulo = dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
                                    productoSeleccionado.descripcion = dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
                                    productoSeleccionado.cantidad = dataGridProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
                                    productoSeleccionado.proveedor = dataGridProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
                                    productoSeleccionado.estacion = dataGridProductos.Rows[e.RowIndex].Cells[5].Value.ToString();
                                    productoSeleccionado.color = dataGridProductos.Rows[e.RowIndex].Cells[6].Value.ToString();
                                    productoSeleccionado.talle = dataGridProductos.Rows[e.RowIndex].Cells[7].Value.ToString();
                                    productoSeleccionado.grupo = dataGridProductos.Rows[e.RowIndex].Cells[8].Value.ToString();
                                    productoSeleccionado.precio_lista = dataGridProductos.Rows[e.RowIndex].Cells[9].Value.ToString();
                                    productoSeleccionado.precio_efectivo = dataGridProductos.Rows[e.RowIndex].Cells[10].Value.ToString();
                                    productoSeleccionado.costo = dataGridProductos.Rows[e.RowIndex].Cells[11].Value.ToString();


                                    textInformacion.Text = productoSeleccionado.nombre_articulo + " " + productoSeleccionado.descripcion + " " + productoSeleccionado.color + " " + productoSeleccionado.talle + " " + "Stock Diponible: " + productoSeleccionado.cantidad;
                                    this.ActiveControl = textCantidad;

                                }
                                else
                                {
                                    MessageBox.Show("Sin Stock");
                                    textCantidad.Enabled = false;
                                    buttonAgregar.Enabled = false;
                                }
                            }


                        }
                    }
                }
                catch(Exception ES)
                {

                }
            }
            else
            {
                //eliminar producto
            }
        }

        private void dataGridProductosRemito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridProductosRemito.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Producto  " + dataGridProductosRemito.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridProductosRemito.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridProductosRemito.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void textCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                agregarProductoRemito();
                this.ActiveControl = textCodigo;
                textCodigo.Text = "";
            }
        }

     

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipo.Text.Equals("Entrada"))
            {
                comboDestino.Enabled = false;
                comboDesde.Enabled = false;
            }
            else if(comboTipo.Text.Equals("Salida"))
            {
                comboDestino.Enabled = true;
                comboDesde.Enabled = false;
            }
            else if (comboTipo.Text.Equals("Traspaso"))
            {
                comboDesde.Enabled = true;
                MessageBox.Show("Seleccionar Sucursal 'Desde' primero");
            }
        }
        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------FUNCIONES----------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        private async void cargarProductos()
        {
            try
            {
                var productoss = await firebaseHelper.getAllProductosV2();
                if (productoss != null)
                {
                    dataGridProductos.Rows.Clear();

                    foreach (var producto in productoss)
                    {
                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo,producto.costo);
                    }
                    foreach (var producto in productoss)
                    {
                        productosCarga.Add(producto);
                    }
                   
                }
            }
            catch (Exception es)
            {

            }
        }
        private void agregarProductoRemito()
        {
            try
            {
                if (!textInformacion.Text.Equals("producto seleccionado"))
                {
                    if (!textCantidad.Text.Equals(""))
                    {
                        if (comboTipo.Text.Equals("Entrada"))
                        {
                            if (Int32.Parse(textCantidad.Text) > 0)
                            {
                                productoSeleccionado.cantidad = textCantidad.Text;

                                dataGridProductosRemito.Rows.Add(productoSeleccionado.id, productoSeleccionado.nombre_articulo,
                                    productoSeleccionado.descripcion, productoSeleccionado.cantidad, productoSeleccionado.proveedor, productoSeleccionado.estacion,
                                    productoSeleccionado.color, productoSeleccionado.talle, productoSeleccionado.grupo,
                                    productoSeleccionado.precio_lista, productoSeleccionado.precio_efectivo, productoSeleccionado.costo);

                                textCantidad.Text = "";
                            }
                        }
                        else if (comboTipo.Text.Equals("Salida"))
                        {
                            if (Int32.Parse(textCantidad.Text) <= cantidadMax && Int32.Parse(textCantidad.Text) > 0)
                            {
                                productoSeleccionado.cantidad = textCantidad.Text;

                                dataGridProductosRemito.Rows.Add(productoSeleccionado.id, productoSeleccionado.nombre_articulo,
                                    productoSeleccionado.descripcion, productoSeleccionado.cantidad, productoSeleccionado.proveedor, productoSeleccionado.estacion,
                                    productoSeleccionado.color, productoSeleccionado.talle, productoSeleccionado.grupo,
                                    productoSeleccionado.precio_lista, productoSeleccionado.precio_efectivo, productoSeleccionado.costo);

                                textCantidad.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Ingrese Otra Cantidad");
                            }
                        }
                        else if (comboTipo.Text.Equals("Traspaso"))
                        {
                            if (comboDesde.Text.Equals("Pueyrredon"))
                            {
                                if (Int32.Parse(textCantidad.Text) <= cantidadMax && Int32.Parse(textCantidad.Text) > 0)
                                {
                                    productoSeleccionado.puey = textCantidad.Text;

                                    dataGridProductosRemito.Rows.Add(productoSeleccionado.id, productoSeleccionado.nombre_articulo,
                                        productoSeleccionado.descripcion, productoSeleccionado.puey, productoSeleccionado.proveedor, productoSeleccionado.estacion,
                                        productoSeleccionado.color, productoSeleccionado.talle, productoSeleccionado.grupo,
                                        productoSeleccionado.precio_lista, productoSeleccionado.precio_efectivo, productoSeleccionado.costo);

                                    textCantidad.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese Otra Cantidad");
                                }
                            }
                            else if (comboDesde.Text.Equals("Stgo del Estero"))
                            {
                                if (Int32.Parse(textCantidad.Text) <= cantidadMax && Int32.Parse(textCantidad.Text) > 0)
                                {
                                    productoSeleccionado.stgo = textCantidad.Text;

                                    dataGridProductosRemito.Rows.Add(productoSeleccionado.id, productoSeleccionado.nombre_articulo,
                                        productoSeleccionado.descripcion, productoSeleccionado.stgo, productoSeleccionado.proveedor, productoSeleccionado.estacion,
                                        productoSeleccionado.color, productoSeleccionado.talle, productoSeleccionado.grupo,
                                        productoSeleccionado.precio_lista, productoSeleccionado.precio_efectivo, productoSeleccionado.costo);

                                    textCantidad.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese Otra Cantidad");
                                }
                            }

                           
                        }
                        calcularTOTAL();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese Cantidad");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione producto");
                }
            }
            catch (Exception es)
            {

            }
        }


        private async void generarRemito()
        {
            if (dataGridProductosRemito.Rows.Count > 1)
            {
                if (comboTipo.Text.Equals("Entrada"))
                {
                    try
                    {
                        buttonGenerarOC.Enabled = false;
                        buttonGenerarOC.Text = "Espere Porfavor...";

                        productos = new List<Producto>();
                        Producto producto = null;
                        foreach (DataGridViewRow row in dataGridProductosRemito.Rows)
                        {
                            producto = new Producto();
                            if (row.Cells[0].Value != null)
                            {
                                producto.id = row.Cells[0].Value.ToString();
                                producto.nombre_articulo = row.Cells[1].Value.ToString();
                                producto.descripcion = row.Cells[2].Value.ToString();
                                producto.cantidad = row.Cells[3].Value.ToString();
                                producto.proveedor = row.Cells[4].Value.ToString();
                                producto.estacion = row.Cells[5].Value.ToString();
                                producto.color = row.Cells[6].Value.ToString();
                                producto.talle = row.Cells[7].Value.ToString();
                                producto.grupo = row.Cells[8].Value.ToString();
                                producto.precio_lista = row.Cells[9].Value.ToString();
                                producto.precio_efectivo = row.Cells[10].Value.ToString();
                                producto.costo = row.Cells[11].Value.ToString();

                                producto.general = producto.cantidad;
                                producto.deposito = producto.cantidad;
                                producto.puey = producto.cantidad;
                                producto.stgo = producto.cantidad;

                                productos.Add(producto);
                            }
                        }
                        string id = DateTime.Now.ToString("ddMMyyyyHHmmss");

                        firebaseHelper.addRemito(id, dateFecha.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"),
                       comboTipo.Text, textObservacion.Text, comboDestino.Text, "", "", productos, textIDOrdenCompra.Text);

                        if (orden.id != null)
                        {
                            firebaseHelper.updateOrdenCompra(orden.id,orden.fecha,orden.hora,orden.empleado,orden.observacion,orden.validoHasta,
                                orden.proveedor,orden.total,orden.ganancia,orden.prioridad,orden.estado, "SI");
                        }



                       



                        if (comboTipo.Text.Equals("Entrada"))   //si es de entrada
                        {
                            firebaseHelper.addProductos(productos, "+", "+", " ", " "); //aumenta general y deposito
                            //await firebaseHelper.updateProductos(productos, comboTipo.Text);    //ingreso de stock PRODUCTOS
                        }
                        if (comboTipo.Text.Equals("Salida"))    //si es de salida
                        {
                            firebaseHelper.addProductos(productos," ", "-", comboDestino.Text, "+"); //aumenta general y deposito

                            //await firebaseHelper.updateProductosSucursal(comboDestino.Text, productos,"Entrada"); //ingreso stock sucursal
                        }

                        //await firebaseHelper.updateDeposito(productos, comboTipo.Text);    //AUMENTO o DISMINUCION de stock DEPOSITO







                        firebaseHelper.addDetalleRemito(id, productos);

                        MessageBox.Show("Remito Agregado");
                        this.Close();
                        RemitosForm remitosForm = new RemitosForm(user);
                        remitosForm.Show();
                    }
                    catch (Exception es)
                    {
                        buttonGenerarOC.Enabled = true;
                        buttonGenerarOC.Text = "Generar Remito";

                        MessageBox.Show(es.Message.ToString());
                    }
                }
                else if (comboTipo.Text.Equals("Salida"))
                {
                    if (!comboDestino.Text.Equals(""))
                    {
                        try
                        {
                            buttonGenerarOC.Enabled = false;
                            buttonGenerarOC.Text = "Espere Porfavor...";

                            productos = new List<Producto>();
                            Producto producto = null;
                            foreach (DataGridViewRow row in dataGridProductosRemito.Rows)
                            {
                                producto = new Producto();
                                if (row.Cells[0].Value != null)
                                {
                                    producto.id = row.Cells[0].Value.ToString();
                                    producto.nombre_articulo = row.Cells[1].Value.ToString();
                                    producto.descripcion = row.Cells[2].Value.ToString();
                                    producto.cantidad = row.Cells[3].Value.ToString();
                                    producto.proveedor = row.Cells[4].Value.ToString();
                                    producto.estacion = row.Cells[5].Value.ToString();
                                    producto.color = row.Cells[6].Value.ToString();
                                    producto.talle = row.Cells[7].Value.ToString();
                                    producto.grupo = row.Cells[8].Value.ToString();
                                    producto.precio_lista = row.Cells[9].Value.ToString();
                                    producto.precio_efectivo = row.Cells[10].Value.ToString();
                                    producto.costo = row.Cells[11].Value.ToString();

                                    producto.general = producto.cantidad;
                                    producto.deposito = producto.cantidad;
                                    producto.puey = producto.cantidad;
                                    producto.stgo = producto.cantidad;

                                    productos.Add(producto);
                                }

                            }
                            string id = DateTime.Now.ToString("ddMMyyyyHHmmss");

                            firebaseHelper.addRemito(id, dateFecha.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"),
                                comboTipo.Text, textObservacion.Text, comboDestino.Text, "", "", productos,textIDOrdenCompra.Text);


                            if (comboTipo.Text.Equals("Entrada"))
                            {
                                firebaseHelper.addProductos(productos, "+", "+", " ", " "); //aumenta general y deposito
                            }
                            if (comboTipo.Text.Equals("Salida"))
                            {
                                firebaseHelper.addProductos(productos, " ", "-", comboDestino.Text, "+"); //aumenta general y deposito

                            }




                            firebaseHelper.addDetalleRemito(id, productos);

                            MessageBox.Show("Remito Agregado");
                            this.Close();
                            RemitosForm remitosForm = new RemitosForm(user);
                            remitosForm.Show();
                        }
                        catch (Exception es)
                        {
                            buttonGenerarOC.Enabled = true;
                            buttonGenerarOC.Text = "Generar Remito";
                            MessageBox.Show(es.Message.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione Destino");
                    }
                }
                else if (comboTipo.Text.Equals("Traspaso"))
                {
                    if (!comboDestino.Text.Equals(""))
                    {
                        try
                        {
                            buttonGenerarOC.Enabled = false;
                            buttonGenerarOC.Text = "Espere Porfavor...";

                            productos = new List<Producto>();
                            Producto producto = null;
                            foreach (DataGridViewRow row in dataGridProductosRemito.Rows)
                            {
                                producto = new Producto();
                                if (row.Cells[0].Value != null)
                                {
                                    producto.id = row.Cells[0].Value.ToString();
                                    producto.nombre_articulo = row.Cells[1].Value.ToString();
                                    producto.descripcion = row.Cells[2].Value.ToString();
                                    producto.cantidad = row.Cells[3].Value.ToString();
                                    producto.proveedor = row.Cells[4].Value.ToString();
                                    producto.estacion = row.Cells[5].Value.ToString();
                                    producto.color = row.Cells[6].Value.ToString();
                                    producto.talle = row.Cells[7].Value.ToString();
                                    producto.grupo = row.Cells[8].Value.ToString();
                                    producto.precio_lista = row.Cells[9].Value.ToString();
                                    producto.precio_efectivo = row.Cells[10].Value.ToString();
                                    producto.costo = row.Cells[11].Value.ToString();

                                    producto.general = producto.cantidad;
                                    producto.deposito = producto.cantidad;
                                    producto.puey = producto.cantidad;
                                    producto.stgo = producto.cantidad;

                                    productos.Add(producto);
                                }
                            }
                            string id = DateTime.Now.ToString("ddMMyyyyHHmmss");


                            firebaseHelper.addRemito(id, dateFecha.Value.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"),
                                comboTipo.Text, textObservacion.Text, comboDestino.Text, "", "", productos, textIDOrdenCompra.Text);


                            await firebaseHelper.addProductos(productos, " ", " ",comboDesde.Text, "-");

                            await firebaseHelper.addProductos(productos, " ", " ", comboDestino.Text,"+");


                            //await firebaseHelper.updateProductosSucursal(comboDesde.Text, productos, "Salida");
                            //await firebaseHelper.updateProductosSucursal(comboDestino.Text, productos, "Entrada");





                            firebaseHelper.addDetalleRemito(id, productos);

                            MessageBox.Show("Remito Agregado");
                            this.Close();
                            RemitosForm remitosForm = new RemitosForm(user);
                            remitosForm.Show();
                        }
                        catch (Exception es)
                        {
                            buttonGenerarOC.Enabled = true;
                            buttonGenerarOC.Text = "Generar Remito";
                            MessageBox.Show(es.Message.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione Destino");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione Tipo");
                }
            }
            else
            {
                MessageBox.Show("Agregue productos al remito");
            }
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonFiltrarNombre_Click(object sender, EventArgs e)
        {
            try
            {

                if (productosCarga != null)
                {
                    dataGridProductos.Rows.Clear();

                    string nom = "";
                    string[] var = null;
                    foreach (var producto in productosCarga)
                    {
                        nom = producto.nombre_articulo;
                        var = nom.Split(' ');

                        switch (var.Length)
                        {
                            case 1:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        if (comboDesde.Text.Equals("Pueyrredon"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else if (comboDesde.Text.Equals("Stgo del Estero"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }

                                    }
                                }
                                break;
                            case 2:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        if (comboDesde.Text.Equals("Pueyrredon"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else if (comboDesde.Text.Equals("Stgo del Estero"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        if (comboDesde.Text.Equals("Pueyrredon"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else if (comboDesde.Text.Equals("Stgo del Estero"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        if (comboDesde.Text.Equals("Pueyrredon"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else if (comboDesde.Text.Equals("Stgo del Estero"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        if (comboDesde.Text.Equals("Pueyrredon"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else if (comboDesde.Text.Equals("Stgo del Estero"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                    }
                                }
                                if (var[2].Length > 2)
                                {
                                    if (var[2].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        if (comboDesde.Text.Equals("Pueyrredon"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else if (comboDesde.Text.Equals("Stgo del Estero"))
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
                                        else
                                        {
                                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                        }
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
                MessageBox.Show("Insertar palabra con más de 3 letras");
            }
        }

        private void comboFiltroGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (productosCarga != null)
                {
                    dataGridProductos.Rows.Clear();

                    if (comboDesde.Text.Equals(""))
                    {
                        foreach (var producto in productosCarga)
                        {
                            if (producto.grupo.Equals(comboFiltroGrupo.Text))
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

                            }
                        }
                    }
                    else if (comboDesde.Text.Equals("Pueyrredon"))
                    {
                        foreach (var producto in productosCarga)
                        {
                            if (producto.grupo.Equals(comboFiltroGrupo.Text))
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

                            }
                        }
                    }
                    else if (comboDesde.Text.Equals("Stgo del Estero"))
                    {
                        foreach (var producto in productosCarga)
                        {
                            if (producto.grupo.Equals(comboFiltroGrupo.Text))
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

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

        private void comboFiltroProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (productosCarga != null)
                {
                    dataGridProductos.Rows.Clear();
                    if (comboDesde.Text.Equals(""))
                    {
                        foreach (var producto in productosCarga)
                        {
                            if (producto.proveedor.Equals(comboFiltroProveedor.Text))
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

                            }
                        }
                    }
                    else if (comboDesde.Text.Equals("Pueyrredon"))
                    {
                        foreach (var producto in productosCarga)
                        {
                            if (producto.proveedor.Equals(comboFiltroProveedor.Text))
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

                            }
                        }
                    }
                    else if (comboDesde.Text.Equals("Stgo del Estero"))
                    {
                        foreach (var producto in productosCarga)
                        {
                            if (producto.proveedor.Equals(comboFiltroProveedor.Text))
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

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

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (productosCarga != null)
                {
                    dataGridProductos.Rows.Clear();

                    if (comboDesde.Text.Equals(""))
                    {
                        foreach (var producto in productosCarga)
                        {
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.deposito, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                        }
                    }
                    else if (comboDesde.Text.Equals("Pueyrredon"))
                    {
                        foreach (var producto in productosCarga)
                        {
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                        }
                    }
                    else if (comboDesde.Text.Equals("Stgo del Estero"))
                    {
                        foreach (var producto in productosCarga)
                        {
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                        }
                    }
                   
                }
            }
            catch (Exception es)
            {

            }
        }

        private void comboDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                dataGridProductos.Rows.Clear();

                foreach (var producto in productosCarga)
                {
                    switch (comboDesde.Text)
                    {
                        case "Pueyrredon":
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                            break;
                        case "Stgo del Estero":
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.stgo, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                            break;
                    }
                   
                }
            }
            catch (Exception es)
            {

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

        private void agregarProducto()
        {
            try
            {
                foreach (var prod in productosCarga)
                {
                    if (prod.id.Equals(textCodigo.Text))
                    {
                        productoSeleccionado.id = prod.id;
                        productoSeleccionado.nombre_articulo = prod.nombre_articulo;
                        productoSeleccionado.descripcion = prod.descripcion;
                        productoSeleccionado.cantidad = prod.cantidad;
                        productoSeleccionado.stgo = prod.stgo;
                        productoSeleccionado.puey = prod.puey;
                        productoSeleccionado.proveedor = prod.proveedor;
                        productoSeleccionado.estacion = prod.estacion;
                        productoSeleccionado.color = prod.color;
                        productoSeleccionado.talle = prod.talle;
                        productoSeleccionado.grupo = prod.grupo;
                        productoSeleccionado.precio_lista = prod.precio_lista;
                        productoSeleccionado.precio_efectivo = prod.precio_efectivo;
                        productoSeleccionado.costo = prod.costo;

                        if (comboTipo.Text.Equals("Entrada"))
                        {
                            textInformacion.Text = productoSeleccionado.nombre_articulo + " " + productoSeleccionado.descripcion + " " + productoSeleccionado.color + " " + productoSeleccionado.talle + " " + "Stock Diponible: " + productoSeleccionado.cantidad;
                            this.ActiveControl = textCantidad;
                        }
                        else if (comboTipo.Text.Equals("Salida"))
                        {
                            if (Int32.Parse(productoSeleccionado.cantidad)>0)
                            {
                                cantidadMax = Int32.Parse(productoSeleccionado.cantidad);

                                textCantidad.Enabled = true;
                                buttonAgregar.Enabled = true;

                                textInformacion.Text = productoSeleccionado.nombre_articulo + " " + productoSeleccionado.descripcion + " " + productoSeleccionado.color + " " + productoSeleccionado.talle + " " + "Stock Diponible: " + productoSeleccionado.cantidad;
                                this.ActiveControl = textCantidad;

                            }
                            else
                            {
                                MessageBox.Show("Sin Stock");
                                textCantidad.Enabled = false;
                                buttonAgregar.Enabled = false;
                                textCantidad.Enabled = false;
                                buttonAgregar.Enabled = false;
                            }
                        }
                        else if (comboTipo.Text.Equals("Traspaso"))
                        {
                            if(comboDesde.Text.Equals("Stgo del Estero"))
                            {
                                if (Int32.Parse(productoSeleccionado.stgo) > 0)
                                {
                                    cantidadMax = Int32.Parse(productoSeleccionado.stgo);
                                    textCantidad.Enabled = true;
                                    buttonAgregar.Enabled = true;
                                    textInformacion.Text = productoSeleccionado.nombre_articulo + " " + productoSeleccionado.descripcion + " " + productoSeleccionado.color + " " + productoSeleccionado.talle + " " + "Stock Diponible: " + productoSeleccionado.stgo;
                                    this.ActiveControl = textCantidad;
                                }
                                else
                                {
                                    MessageBox.Show("Sin Stock");
                                    textCantidad.Enabled = false;
                                    buttonAgregar.Enabled = false;
                                    textCantidad.Enabled = false;
                                    buttonAgregar.Enabled = false;
                                }
                            }
                            else if(comboDesde.Text.Equals("Pueyrredon"))
                            {
                                if (Int32.Parse(productoSeleccionado.puey) > 0)
                                {
                                    cantidadMax = Int32.Parse(productoSeleccionado.puey);
                                    textCantidad.Enabled = true;
                                    buttonAgregar.Enabled = true;
                                    textInformacion.Text = productoSeleccionado.nombre_articulo + " " + productoSeleccionado.descripcion + " " + productoSeleccionado.color + " " + productoSeleccionado.talle + " " + "Stock Diponible: " + productoSeleccionado.puey;
                                    this.ActiveControl = textCantidad;
                                }
                                else
                                {
                                    MessageBox.Show("Sin Stock");
                                    textCantidad.Enabled = false;
                                    buttonAgregar.Enabled = false;
                                    textCantidad.Enabled = false;
                                    buttonAgregar.Enabled = false;
                                }
                            }
                            
                        }
                        break;
                    }
                }
              
            }
            catch (Exception ES)
            {
                MessageBox.Show(ES.Message);
            }

        }

        private void buttonAgregarCB_Click(object sender, EventArgs e)
        {
            agregarProducto();
        }

        private void dataGridProductosRemito_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            calcularCantidad();
            calcularSubtotal();
        }
        private void calcularSubtotal()
        {
            try
            {
                int cant = 0;
                int costo = 0;
                foreach (DataGridViewRow item in this.dataGridProductosRemito.SelectedRows)
                {
                    if (item.Cells[3].Value != null)
                    {
                        cant += Int32.Parse(item.Cells[3].Value.ToString());
                        costo += Int32.Parse(item.Cells[3].Value.ToString()) * Int32.Parse(item.Cells[11].Value.ToString());

                    }

                }
                textCantidadProductos.Text = "Cantidad: " + cant.ToString();
                //textTotalCosto.Text = "Costo: $" + costo.ToString();
            }
            catch (Exception es)
            {

            }

        }

        private void calcularTOTAL()
        {
            try
            {
                int cant = 0;
                foreach (DataGridViewRow row in dataGridProductosRemito.Rows)
                {
                    if (row.Cells[3].Value!=null)
                    {
                        cant += Int32.Parse(row.Cells[3].Value.ToString());
                    }
                   
                }
                 textTOTAL.Text = "Cantidad: "+cant.ToString();
            }
            catch(Exception es)
            {

            }
        }
        private void calcularCantidad()
        {
            int cant = 0;
            foreach (DataGridViewRow item in this.dataGridProductosRemito.SelectedRows)
            {
                if (item.Cells[3].Value != null)
                {
                    cant += Int32.Parse(item.Cells[3].Value.ToString());
                }

            }
            textCantidadProductos.Text = "Cantidad: " + cant.ToString();
        }
    }
}

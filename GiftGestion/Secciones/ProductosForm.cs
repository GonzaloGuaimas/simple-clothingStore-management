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
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;
using SpreadsheetLight;
using GiftGestion.Flotante;

namespace GiftGestion.Secciones
{
    public partial class ProductosForm : Form
    {

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public List<Producto> productos = new List<Producto>();
        
        public List<Producto> productosCarga = new List<Producto>();


        private List<Remito> remitos = new List<Remito>();
        private List<Venta> ventas = new List<Venta>();
        public List<Producto> productosREMITO = new List<Producto>();
        public List<Producto> productosVENTA = new List<Producto>();

        private List<Cambio> cambios = new List<Cambio>();
        public List<Producto> productosCambios = new List<Producto>();

        public List<Grupo> gruposCarga = new List<Grupo>();

        private string rutaModeloStock = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/stock.xlsx";
        private string rutaSalidaStock = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Stock/";


        Color redColor = Color.FromArgb(180, 63, 38);
        Color yellowColor = Color.FromArgb(216, 231, 20);
        Color greenColor = Color.FromArgb(27, 172, 0);


        private string rutaCodigos = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/codigos/";
        private string rutaModeloEtiqueta= Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/etiquetas.docx";
        private string rutaEtiquetas = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Etiquetas Generadas/";

        private string rutaGenerada = "";
        private Producto productoSeleccionado = new Producto();
        Usuario user = new Usuario();

        private string idSeleccionado = "";
        private string cantDeposito = "";
        private string cantProducto = "";
        private string cantGaleria = "";
        private string cantSantiag = "";
        private string cantPueyrr = "";

        Boolean band = false;

        public ProductosForm(Usuario usuario)
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

        private async void ProductosForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cargarProductosRemito();
            cargarProductosVenta();
            cargarProductosCambios();

            gruposCarga = await firebaseHelper.getAllGrupos();
            foreach (var grupo in gruposCarga)
            {
                comboGrupo.Items.Add(grupo.nombre_grupo);
                comboFiltroGrupo.Items.Add(grupo.nombre_grupo);
            }

           
            if (user.rol.Equals("Vendedor"))
            {
                panelUtiles.Visible = false;
                panelAgregarProducto.Visible = false;
                dataGridProductos.Columns[15].Visible = false;
            }
            if (user.rol.Equals("Admin") || user.rol.Equals("Super"))
            { 
                textID.Visible = true;
                textRemito.Visible = true;
            }
            cargarProductos();
            //cargarProductosSucursales();   
        }

     
        private async void buttonInsertar_Click(object sender, EventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                buttonInsertar.Enabled = false;
                buttonInsertar.Text = "Espere Porfavor...";

                List<Producto> listadoActualizar = new List<Producto>();

                foreach (DataGridViewRow row in this.dataGridProductos.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        productoSeleccionado.id = row.Cells[0].Value.ToString();
                        productoSeleccionado.nombre_articulo = row.Cells[1].Value.ToString();
                        productoSeleccionado.descripcion = row.Cells[2].Value.ToString();
                        productoSeleccionado.cantidad = row.Cells[3].Value.ToString();
                        productoSeleccionado.deposito = row.Cells[4].Value.ToString();
                        productoSeleccionado.stgo = row.Cells[5].Value.ToString();
                        productoSeleccionado.puey = row.Cells[7].Value.ToString();
                        productoSeleccionado.proveedor = row.Cells[8].Value.ToString();
                        productoSeleccionado.estacion = row.Cells[9].Value.ToString();
                        productoSeleccionado.color = row.Cells[10].Value.ToString();
                        productoSeleccionado.talle = row.Cells[11].Value.ToString();
                        productoSeleccionado.grupo = row.Cells[12].Value.ToString();
                        productoSeleccionado.precio_lista = row.Cells[13].Value.ToString();
                        productoSeleccionado.precio_efectivo = row.Cells[14].Value.ToString();
                        productoSeleccionado.costo = row.Cells[15].Value.ToString();
                        listadoActualizar.Add(productoSeleccionado);
                    }
                }
                

                await firebaseHelper.updateProductosV2(listadoActualizar);
                MessageBox.Show("Productos Actualizados");
                buttonInsertar.Enabled = true;
                buttonInsertar.Text = "Actualizar Productos";

                /*
                if (!textNombre.Text.Equals("") && !textColor.Text.Equals("") && !comboEstacion.Text.Equals("")
                && !comboGrupo.Text.Equals("") && !comboTalle.Text.Equals("")
                && !textPrecioLista.Text.Equals("") && !textPrecioEfectivo.Text.Equals("")) {
                    buttonInsertar.Enabled = false;
                    buttonInsertar.Text = "Espere Porfavor...";

                    MessageBox.Show("Producto Actualizado");
                    await firebaseHelper.updateProductoV2();
                    buttonInsertar.Enabled = true;
                    buttonInsertar.Text = "Actualizar";
                }
                else
                {
                    MessageBox.Show("Complete Campos");
                }
                */
            }
        }

     
        private void buttonGenerarEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                buttonGenerarEtiqueta.Text = "Espere porfavor...";
                buttonGenerarEtiqueta.Enabled = false;
                CreateWordDocument(rutaModeloEtiqueta, rutaEtiquetas + DateTime.Now.ToString("ddMMyyyyHHmmss")+ ".pdf");
            }
            catch (Exception es)
            {

            }
        }

        private void dataGridProductos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (MouseButtons.Right.Equals(e.Button))
                {
                    DialogResult resultado = MessageBox.Show("Desea Actualizar Producto " + dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString()+" ?" , "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        productoSeleccionado = new Producto();
                        productoSeleccionado = dataGridProductos.SelectedRows[0].DataBoundItem as Producto;

                        MessageBox.Show(productoSeleccionado.nombre_articulo);

                        idSeleccionado = dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
                        textNombre.Text = dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
                        textDescripcion.Text = dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString();

                        comboProveedor.Text = dataGridProductos.Rows[e.RowIndex].Cells[8].Value.ToString();
                        comboEstacion.Text = dataGridProductos.Rows[e.RowIndex].Cells[9].Value.ToString();
                        textColor.Text = dataGridProductos.Rows[e.RowIndex].Cells[10].Value.ToString();
                        comboTalle.Text = dataGridProductos.Rows[e.RowIndex].Cells[11].Value.ToString();
                        comboGrupo.Text = dataGridProductos.Rows[e.RowIndex].Cells[12].Value.ToString();
                        textPrecioLista.Text = dataGridProductos.Rows[e.RowIndex].Cells[13].Value.ToString();
                        textPrecioEfectivo.Text = dataGridProductos.Rows[e.RowIndex].Cells[14].Value.ToString();
                        textCosto.Text = dataGridProductos.Rows[e.RowIndex].Cells[15].Value.ToString();
                    }
                }
                else
                {
                    if (dataGridProductos.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        productoSeleccionado.id = dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
                        productoSeleccionado.nombre_articulo = dataGridProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
                        productoSeleccionado.descripcion = dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
                        productoSeleccionado.precio_lista = dataGridProductos.Rows[e.RowIndex].Cells[13].Value.ToString();
                        productoSeleccionado.precio_efectivo = dataGridProductos.Rows[e.RowIndex].Cells[14].Value.ToString();
                        textIDProducto.Text = productoSeleccionado.id;
                    }
                }
              
            }

            catch(Exception es)
            {

            }

        }
        private void calcularEtiquetas()
        {
            try
            {
                int cant = 0;
                foreach (DataGridViewRow item in this.dataGridProductos.SelectedRows)
                {
                    if (item.Cells[3].Value!=null)
                    {
                        cant = cant + Int32.Parse(item.Cells[3].Value.ToString());
                    }
                    
                }
                textCantidadEtiqueta.Text = cant.ToString();
            }
            catch(Exception es)
            {

            }
        }

        private void textPrecioLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textPrecioEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textNombre.Text = "";
            textDescripcion.Text = "";
            comboEstacion.Text = "";
            comboGrupo.Text = "";
            comboTalle.Text = "";
            textColor.Text = "";
            comboProveedor.Text = "";
            textPrecioEfectivo.Text = "";
            textPrecioLista.Text = "";
            textCosto.Text = "";
        }

        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------FUNCIONES----------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------

        /*
        private async void cargarProductosSucursales()
        {

            var prodsGal = await firebaseHelper.getAllProductosSucursal("Galeria Palacio");
            var prodStgo = await firebaseHelper.getAllProductosSucursal("Stgo del Estero");
            var prodsPuey = await firebaseHelper.getAllProductosSucursal("Pueyrredon");
            var prodDep = await firebaseHelper.getAllDeposito();

            if (prodsGal != null)
            {
                foreach (var prod in prodsGal)
                {
                    productosGaleria.Add(prod);
                }
            }
            if (prodStgo != null)
            {
                foreach (var prod in prodStgo)
                {
                    productosStgo.Add(prod);
                }
            }
            if (prodDep != null)
            {
                foreach (var prod in prodDep)
                {
                    productosDep.Add(prod);
                }
            }
            if (prodsPuey != null)
            {
                foreach (var prod in prodsPuey)
                {
                    productosPueyrredon.Add(prod);
                }
            }
            cargarProductos();

        }
        */
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

                        int año = Convert.ToInt32(producto.id.ToString().Substring(4, 4));
                        int mes = Convert.ToInt32(producto.id.ToString().Substring(2, 2));
                        int dia = Convert.ToInt32(producto.id.ToString().Substring(0, 2));
                        int hora = Convert.ToInt32(producto.id.ToString().Substring(8, 2));
                        int min = Convert.ToInt32(producto.id.ToString().Substring(10, 2));


                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);

                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo,producto.costo, fecha);
                       
                        // dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                        //     buscarProductoSucursal("Deposito", producto.id),buscarProductoSucursal("Stgo del Estero", producto.id),
                        //   buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                        //producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo,producto.costo, fecha);
                    }

                    dataGridProductos.Sort(dataGridProductos.Columns[16], System.ComponentModel.ListSortDirection.Descending);
                }
                foreach (var producto in productoss)
                {
                    productosCarga.Add(producto);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        /*
        private string buscarProductoSucursal(string sucursal,string id)
        {
            string cant = "0";
            switch (sucursal)
            {
                case "Galeria Palacio":
                    foreach (var prod in productosGaleria)
                    {
                        if (id.Equals(prod.id))
                        {
                            cant = prod.cantidad;
                        }
                     
                    };
                    break;
                case "Stgo del Estero":
                    foreach (var prod in productosStgo)
                    {
                        if (id.Equals(prod.id))
                        {
                            cant = prod.cantidad;
                        }

                    };
                    break;
                case "Pueyrredon":
                    foreach (var prod in productosPueyrredon)
                    {
                        if (id.Equals(prod.id))
                        {
                            cant = prod.cantidad;
                        }

                    };
                    break;
                case "Deposito":
                    foreach (var prod in productosDep)
                    {
                        if (id.Equals(prod.id))
                        {
                            cant = prod.cantidad;
                        }

                    };
                    break;
            }
            return cant;
        }
        
        */

        private void generarEtiqueta(string idProducto)
        {
            try
            {
                BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
                Codigo.IncludeLabel = true;
                panelResultado.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, idProducto, Color.Black, Color.White, 188, 56);
                Image imgFinal = (Image)panelResultado.BackgroundImage.Clone();
                rutaGenerada = rutaCodigos + idProducto + ".png";
                imgFinal.Save(rutaGenerada, ImageFormat.Png);
            }
            catch (Exception es)
            {

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
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;

                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);

                    myWordDoc.Activate();

                    int fin = 1;
                    int ini = 1;
                    foreach (DataGridViewRow item in this.dataGridProductos.SelectedRows)
                    {
                        generarEtiqueta(item.Cells[0].Value.ToString());
                        item.Cells[17].Value = "SI";
                        fin = fin + Int32.Parse(item.Cells[3].Value.ToString());

                        for (int i = ini; i < fin; i++)
                        {
                            this.FindAndReplace(wordApp, "<desc" + i.ToString() + ">", item.Cells[2].Value.ToString() +" "+ item.Cells[10].Value.ToString() + " " + item.Cells[11].Value.ToString());
                            this.FindAndReplace(wordApp, "<NombreProducto" + i.ToString() + ">", item.Cells[1].Value.ToString());
                            this.FindAndReplace(wordApp, "<PrecioEfectivo" + i.ToString() + ">", item.Cells[14].Value.ToString());
                            this.FindAndReplace(wordApp, "<PrecioLista" + i.ToString() + ">", item.Cells[13].Value.ToString());
                            var shape = myWordDoc.Bookmarks["codigo" + i.ToString()].Range.InlineShapes.AddPicture(rutaGenerada, false, true);
                            
                        }

                        ini = ini + Int32.Parse(item.Cells[3].Value.ToString());
                    }
                    recorrerListado();

                    //--------------------------------------------------------------------------------------------------------------

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


                    MessageBox.Show("Etiqueta Generada | Carpeta: GIFT Gestion/Etiquetas Generadas");
                    buttonGenerarEtiqueta.Text = "Generar Etiqueta";
                    buttonGenerarEtiqueta.Enabled = true;
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
                buttonGenerarEtiqueta.Text = "Generar Etiqueta";
                buttonGenerarEtiqueta.Enabled = true;
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

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void comboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                switch (comboFiltroSucursal.Text)
                {
                    case "Stgo del Estero":
                        
                        if (productosStgo != null)
                        {
                            dataGridProductos.Rows.Clear();

                            foreach (var producto in productosStgo)
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                    "", "", "","", producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo,
                                    producto.precio_lista, producto.precio_efectivo, producto.costo);
                            }
                        }
                        break;
                    case "Deposito":

                        if (productosDep != null)
                        {
                            dataGridProductos.Rows.Clear();

                            foreach (var producto in productosDep)
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                    "", "", "","", producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo,
                                    producto.precio_lista, producto.precio_efectivo, producto.costo);
                            }
                        }
                        break;
                    case "Galeria Palacio":

                        if (productosGaleria != null)
                        {
                            dataGridProductos.Rows.Clear();

                            foreach (var producto in productosGaleria)
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                    "", "", "","", producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo,
                                    producto.precio_lista, producto.precio_efectivo, producto.costo);
                            }
                        }
                        break;
                    case "Pueyrredon":

                        if (productosPueyrredon != null)
                        {
                            dataGridProductos.Rows.Clear();

                            foreach (var producto in productosPueyrredon)
                            {
                                dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                    "", "", "","", producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo,
                                    producto.precio_lista, producto.precio_efectivo, producto.costo);
                            }
                        }
                        break;
                }
               
            }
            catch (Exception es)
            {

            }
            */
        }

        private void textCosto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textPrecioLista.Text = (Math.Round(Int32.Parse(textCosto.Text)*1.35) + Int32.Parse(textCosto.Text)).ToString();
                textPrecioEfectivo.Text = (Math.Round(Int32.Parse(textCosto.Text)*1.1) + Int32.Parse(textCosto.Text)).ToString();
            }
            catch (Exception es)
            {

            }
        }
        
        private void textCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

     

        private void comboFiltroGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (productosCarga != null)
                {
                    dataGridProductos.Rows.Clear();

                    foreach (var producto in productosCarga)
                    {
                        if (producto.grupo.Equals(comboFiltroGrupo.Text))
                        {
                            int año = Int32.Parse(producto.id.Substring(4, 4));
                            int mes = Int32.Parse(producto.id.Substring(2, 2));
                            int dia = Int32.Parse(producto.id.Substring(0, 2));
                            int hora = Int32.Parse(producto.id.Substring(8, 2));
                            int min = Int32.Parse(producto.id.Substring(10, 2));

                            DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);


                            //                      dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo,producto.costo, fecha);
                            // buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                            // buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                            //producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);


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

                    foreach (var producto in productosCarga)
                    {
                        if (producto.proveedor.Equals(comboFiltroProveedor.Text))
                        {
                            //dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                            //buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                            //buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                            //producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);

                        }
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void buttonFiltrarNombre_Click(object sender, EventArgs e)
        {
            buscarNombre();
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            try
            {

                if (productosCarga != null)
                {
                    dataGridProductos.Rows.Clear();

                    foreach (var producto in productosCarga)
                    {
                        int año = Int32.Parse(producto.id.Substring(4, 4));
                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                        int min = Int32.Parse(producto.id.Substring(10, 2));

                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);

                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);

                        // dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                        //    buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                        //  buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                        // producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);
                    }
                    dataGridProductos.Sort(dataGridProductos.Columns[16], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            catch (Exception es)
            {

            }
        }

        private async void dataGridProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridProductos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    Clipboard.SetText(dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                }

                calcularEtiquetas();
                if (user.rol.Equals("Admin") || user.rol.Equals("Super") && band && dataGridProductos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    textID.Text = await firebaseHelper.getProductoID(dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //textIDDeposito.Text = await firebaseHelper.getProductoIDDeposito(dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //textGaleria.Text = await firebaseHelper.getProductoSucursal(dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString(),"Galeria Palacio");
                    //textPueyrredon.Text = await firebaseHelper.getProductoSucursal(dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString(),"Pueyrredon");
                    //textStgo.Text = await firebaseHelper.getProductoSucursal(dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString(),"Stgo del Estero");
                    textRemito.Text = await firebaseHelper.getProductoIDRemito(dataGridProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch(Exception es)
            {

            }
           

        }

        private void buttonObtenerID_Click(object sender, EventArgs e)
        {
            band = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------

        
        private void buttonExportar_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                SLDocument sl = new SLDocument(rutaModeloStock);
                int j = 5;
                foreach (var producto in productosCarga)
                {
                    int remito = 0;
                    int venta = 0;

                    foreach (var item in productosREMITO)
                    {
                        if (item.id.Equals(producto.id))
                        {
                            remito = remito + Int32.Parse(item.cantidad);
                        }
                    }
                    foreach (var item in productosVENTA)
                    {
                        if (item.id.Equals(producto.id))
                        {
                            venta = venta + Int32.Parse(item.cantidad);
                        }
                    }


                    sl.SetCellValue("B" + j.ToString(), producto.id);   //id prod
                    sl.SetCellValue("C" + j.ToString(), producto.nombre_articulo);
                    sl.SetCellValue("D" + j.ToString(), producto.descripcion);
                   
                    sl.SetCellValue("E" + j.ToString(), producto.color);
                    sl.SetCellValue("F" + j.ToString(), producto.talle);
                    sl.SetCellValue("G" + j.ToString(), producto.grupo);


                    sl.SetCellValue("I" + j.ToString(), remito);    //STOCK REMITO
                    sl.SetCellValue("K" + j.ToString(), venta);    //STOCK VENTA
                    sl.SetCellValue("M" + j.ToString(), producto.cantidad); //stock gral
                    sl.SetCellValue("O" + j.ToString(), buscarProductoSucursal("Stgo del Estero", producto.id));    //STOCK STGO
                    sl.SetCellValue("Q" + j.ToString(), buscarProductoSucursal("Galeria Palacio", producto.id));    //STOCK GAL
                    sl.SetCellValue("S" + j.ToString(), buscarProductoSucursal("Pueyrredon", producto.id));    //STOCK PUEY 
                    sl.SetCellValue("U" + j.ToString(), buscarProductoSucursal("Deposito", producto.id));    //STOCK PUEY 

                    j++;
                }

                sl.SaveAs(rutaSalidaStock + " control stock" + ".xlsx");
                MessageBox.Show("Se Generó el STOCK", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
            */
        }

        private async void cargarProductosRemito()
        {
            try
            {
                var remitoss = await firebaseHelper.getAllRemitos();
                remitos = remitoss;
                var detalleRemitos = await firebaseHelper.getAllDetalleRemito();
                if (remitoss != null)
                {
                    foreach (var remito in remitoss)
                    {
                        foreach (var producto in detalleRemitos)
                        {
                            if (producto.foranea.Equals(remito.id))
                            {
                                productosREMITO.Add(producto);
                            }
                        }

                    }
                }
                buttonExportar.Enabled = true;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }  
        }

        private async void cargarProductosVenta()
        {
            try
            {
                var productoss = await firebaseHelper.getAllDetalleVenta();
                ventas = await firebaseHelper.getAllVentas();
                if (productoss != null)
                {
                    foreach (var producto in productoss)
                    {
                        productosVENTA.Add(producto);
                    }
                }
                buttonExportar.Enabled = true;
            }
            catch (Exception es)
            {

            }
        }
        private async void cargarProductosCambios()
        {
            try
            {
                var cambioss = await firebaseHelper.getAllDetalleCambio();
                cambios = await firebaseHelper.getAllCambios();
                if (cambioss != null)
                {
                    foreach (var producto in cambioss)
                    {
                        productosCambios.Add(producto);
                    }
                }
                buttonExportar.Enabled = true;
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
                dataGridProductos.Rows.Clear();
                foreach (var producto in productosCarga)
                {
                    if (producto.id.Equals(textCodigo.Text))
                    {
                        int año = Int32.Parse(producto.id.Substring(4, 4));
                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                        int min = Int32.Parse(producto.id.Substring(10, 2));

                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);

                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);

                        //dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                        //   buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                        //  buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                        // producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);
                    }
                }
            }
        }

        private void buttonSeguimiento_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado.id != null)
            {
                SeguimientoProducto seguimiento = new SeguimientoProducto(productoSeleccionado, remitos, productosREMITO, ventas, productosVENTA, cambios, productosCambios);
                seguimiento.Show();
            }

        }

        private void textNombreFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                buscarNombre();
            }
        }

        private void buscarNombre()
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
                                        int año = Int32.Parse(producto.id.Substring(4, 4));
                                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                                        int min = Int32.Parse(producto.id.Substring(10, 2));

                                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);
                                        
                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);


                                        //  dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                        //     buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                        //   buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                        // producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);
                                    }
                                }
                                break;
                            case 2:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        int año = Int32.Parse(producto.id.Substring(4, 4));
                                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                                        int min = Int32.Parse(producto.id.Substring(10, 2));

                                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);
                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);


                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        int año = Int32.Parse(producto.id.Substring(4, 4));
                                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                                        int min = Int32.Parse(producto.id.Substring(10, 2));

                                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);

                                    }
                                }
                                break;
                            case 3:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        int año = Int32.Parse(producto.id.Substring(4, 4));
                                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                                        int min = Int32.Parse(producto.id.Substring(10, 2));

                                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);

                                    
                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        int año = Int32.Parse(producto.id.Substring(4, 4));
                                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                                        int min = Int32.Parse(producto.id.Substring(10, 2));

                                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);


                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);

                                    }
                                }
                                if (var[2].Length > 2)
                                {
                                    if (var[2].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {
                                        int año = Int32.Parse(producto.id.Substring(4, 4));
                                        int mes = Int32.Parse(producto.id.Substring(2, 2));
                                        int dia = Int32.Parse(producto.id.Substring(0, 2));
                                        int hora = Int32.Parse(producto.id.Substring(8, 2));
                                        int min = Int32.Parse(producto.id.Substring(10, 2));

                                        DateTime fecha = new DateTime(año, mes, dia, hora, min, 0);


                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo, fecha);

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
                MessageBox.Show("Insertar palabra con más de 3 letras");
            }
        }

        private void recorrerListado()
        {
            foreach (DataGridViewRow row in dataGridProductos.Rows)
            {
                if (row.Cells[17].Value != null)
                {
                    if ((row.Cells[17].Value).ToString().Equals("SI"))
                    {
                        row.DefaultCellStyle.ForeColor = greenColor;
                    }
                    else if ((row.Cells[17].Value).ToString().Equals(""))
                    {
                        row.DefaultCellStyle.ForeColor = redColor;
                    }
                }
            }
        }

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
using GiftGestion.Secciones.Herramientas;
using SpreadsheetLight;

namespace GiftGestion
{
    public partial class Login : Form
    {
        ConexionSQL obj = new ConexionSQL();
        string estado;

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario user = new Usuario();

        private string rutaModeloVentas = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/GIFT Gestion/Files/vacio.xlsx";
        private string rutaSalidaVentas = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/" ;


        public Login()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitializeComponent();
            }
          
        }

        private async void buttonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                buttonIngresar.Enabled = false;
                buttonIngresar.Text = "Ingresando...";
                var usuario = await firebaseHelper.getUsuario(textDNI.Text);
                if (usuario != null)
                {
                    if (usuario.contraseña.Equals(textContraseña.Text))
                    {
                        Main main = new Main(usuario);
                        main.Show();
                    }
                    else
                    {
                        buttonIngresar.Enabled = true;
                        buttonIngresar.Text = "Ingresar";
                        MessageBox.Show("Contraseña incorrecta");
                    }
                   
                }
                else
                {
                    buttonIngresar.Enabled = true;
                    buttonIngresar.Text = "Ingresar";
                    MessageBox.Show("No existe Usuario");
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
           
        }

        private void textDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.ActiveControl = textContraseña;
            }
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //ControlStock reposStock = new ControlStock();
            //reposStock.Show();
        }

        private async void Login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textDNI;
            //exportarVentas2();
            //exportarVentas2();
            //exportarProdVendidos();
            //exportarVentasSucursal();
            //exportarVentasSucursal();
            //arreglo();
            //arreglo2();
            //exportarVentas();
            //asignarRoles();
            //exportarVentas();
            //exportarFP();
        }

        private async void exportarProdVendidos()
        { 
            try
            {
                var prods = await firebaseHelper.getAllDetalleVenta();
                SLDocument sl = new SLDocument(rutaModeloVentas);

                int j = 3;

                foreach (var prod in prods)
                {
                    sl.SetCellValue("B" + j.ToString(), prod.id);
                    sl.SetCellValue("C" + j.ToString(), prod.nombre_articulo);
                    sl.SetCellValue("D" + j.ToString(), prod.descripcion);
                    sl.SetCellValue("E" + j.ToString(), prod.talle);
                    sl.SetCellValue("F" + j.ToString(), prod.color);
                    sl.SetCellValue("G" + j.ToString(), prod.precio);
                    sl.SetCellValue("H" + j.ToString(), prod.foranea);
                    sl.SetCellValue("I" + j.ToString(), prod.grupo);
                    sl.SetCellValue("J" + j.ToString(), prod.cantidad);
                    sl.SetCellValue("K" + j.ToString(), prod.costo);
                    j++;
                }
                sl.SaveAs(rutaSalidaVentas + "PRODS VENDIDOS" + ".xlsx");
                MessageBox.Show("Se Exportaron Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private async void exportarProdInsertados()
        {
            try
            {
                var remitos = await firebaseHelper.getAllRemitos();
                var detalle = await firebaseHelper.getAllDetalleRemito();
                SLDocument sl = new SLDocument(rutaModeloVentas);

                int j = 3;

                foreach (var remito in remitos)
                {
                    if (remito.tipo.Equals("Salida"))
                    {
                        foreach (var prod in detalle)
                        {
                            if (prod.foranea.Equals(remito.id))
                            {
                                sl.SetCellValue("B" + j.ToString(), prod.id);
                                sl.SetCellValue("C" + j.ToString(), prod.nombre_articulo);
                                sl.SetCellValue("D" + j.ToString(), prod.descripcion);
                                sl.SetCellValue("E" + j.ToString(), prod.talle);
                                sl.SetCellValue("F" + j.ToString(), prod.color);
                                sl.SetCellValue("G" + j.ToString(), prod.precio);
                                sl.SetCellValue("H" + j.ToString(), prod.foranea);
                                sl.SetCellValue("I" + j.ToString(), prod.grupo);
                                sl.SetCellValue("J" + j.ToString(), prod.cantidad);
                                sl.SetCellValue("K" + j.ToString(), prod.costo);
                                j++;
                            }

                        }
                    }
                    
                }
                sl.SaveAs(rutaSalidaVentas + "GRAL SALIDA" + ".xlsx");
                MessageBox.Show("Se Exportaron Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }
        }
        private async void exportarVentasSucursal()
        {
            try
            {
                var prods = await firebaseHelper.getAllDetalleVenta();
                var ventas = await firebaseHelper.getAllVentas();

                SLDocument sl = new SLDocument(rutaModeloVentas);

                int l = 3;

                foreach (var venta in ventas)
                {
                    if (venta.nombre_sucursal.Equals("Stgo del Estero"))
                    {
                        foreach (var prod in prods)
                        {

                            if (venta.id.Equals(prod.foranea))
                            {
                                sl.SetCellValue("L" + l.ToString(), prod.id);
                                sl.SetCellValue("M" + l.ToString(), prod.nombre_articulo);
                                sl.SetCellValue("N" + l.ToString(), prod.descripcion);
                                sl.SetCellValue("O" + l.ToString(), prod.talle);
                                sl.SetCellValue("P" + l.ToString(), prod.color);
                                sl.SetCellValue("Q" + l.ToString(), prod.precio);
                                sl.SetCellValue("R" + l.ToString(), prod.foranea);
                                sl.SetCellValue("S" + l.ToString(), prod.grupo);
                                sl.SetCellValue("T" + l.ToString(), venta.fecha);
                                sl.SetCellValue("U" + l.ToString(), prod.costo);
                                sl.SetCellValue("V" + l.ToString(), prod.cantidad);
                                l++;

                            }
                        }
                    }
                       
                    
                }

                sl.SaveAs(rutaSalidaVentas + "VENTAS" + ".xlsx");
                MessageBox.Show("Se Exportaron Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }
        private async void arreglo2()
        {
            var prods = await firebaseHelper.getAllDetalleVenta();
            foreach (var prod in prods)
            {
                if (prod.foranea.Equals("31122021154824"))
                {
                    string id = await firebaseHelper.getProductoDetalleVenta("31122021154824");
                    MessageBox.Show(prod.id+" "+id );
                }
            }
        }

        private async void exportarVentas2()
        {
            try
            {
                var prods = await firebaseHelper.getAllDetalleVenta();
                var ventas = await firebaseHelper.getAllVentas();
                var formaPagos = await firebaseHelper.getAllDetalleFormaPago();

                SLDocument sl = new SLDocument(rutaModeloVentas);

                int j = 3;
                int k = 3;
                int l = 3;
                
                foreach (var venta in ventas)
                {
                    int cont = 0;
                    sl.SetCellValue("B" + j.ToString(), venta.id);
                    sl.SetCellValue("C" + j.ToString(), venta.fecha);
                    sl.SetCellValue("D" + j.ToString(), venta.nombre_empleado);
                    sl.SetCellValue("E" + j.ToString(), venta.nombre_cliente);
                    sl.SetCellValue("F" + j.ToString(), venta.nombre_sucursal);
                    sl.SetCellValue("G" + j.ToString(), venta.observacion);

                    k = j+cont;
                    l = j + cont;

                    foreach (var forma in formaPagos)
                    {
                        if (forma.foranea.Equals(venta.id))
                        {
                            sl.SetCellValue("H" + k.ToString(), forma.foranea);
                            sl.SetCellValue("I" + k.ToString(), forma.fecha);
                            sl.SetCellValue("J" + k.ToString(), forma.nombre);
                            sl.SetCellValue("K" + k.ToString(), forma.monto);
                            k++;
                            cont++;
                        }
                    }
                    foreach (var prod in prods)
                    {
                        if (venta.id.Equals(prod.foranea))
                        {
                            sl.SetCellValue("L" + l.ToString(), prod.id);
                            sl.SetCellValue("M" + l.ToString(), prod.nombre_articulo);
                            sl.SetCellValue("N" + l.ToString(), prod.descripcion);
                            sl.SetCellValue("O" + l.ToString(), prod.talle);
                            sl.SetCellValue("P" + l.ToString(), prod.color);
                            sl.SetCellValue("Q" + l.ToString(), prod.precio);
                            sl.SetCellValue("R" + l.ToString(), prod.foranea);
                            sl.SetCellValue("S" + l.ToString(), prod.grupo);
                            sl.SetCellValue("T" + l.ToString(), venta.fecha);
                            sl.SetCellValue("U" + l.ToString(), prod.costo);
                            sl.SetCellValue("V" + l.ToString(), prod.cantidad);
                            l++;
                            cont++;

                        }
                    }
                    j = j + cont;
                    j++;
                }

                sl.SaveAs(rutaSalidaVentas + "VENTAS" + ".xlsx");
                MessageBox.Show("Se Exportaron Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }
        private async void exportarFP()
        {
            try
            {
                var prods = await firebaseHelper.getAllDetalleFormaPago();
                SLDocument sl = new SLDocument(rutaModeloVentas);

                int j = 3;

                j++;
                foreach (var forma in prods)
                {
                    sl.SetCellValue("B" + j.ToString(), forma.fecha);
                    sl.SetCellValue("C" + j.ToString(), forma.nombre);
                    sl.SetCellValue("D" + j.ToString(), forma.monto);
                    j++;
                }

                sl.SaveAs(rutaSalidaVentas + " PRODS con FECHA" + ".xlsx");
                MessageBox.Show("Se Exportaron Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }

        private async void exportarVentas()
        {
            try
            {
                var prods = await firebaseHelper.getAllDetalleVenta();
                var ventas = await firebaseHelper.getAllVentas();
                SLDocument sl = new SLDocument(rutaModeloVentas);

                int j = 3;
                sl.SetCellValue("B" + j.ToString(), "ID");
                sl.SetCellValue("C" + j.ToString(), "NOMBRE");
                sl.SetCellValue("D" + j.ToString(), "DESCRIPCION");
                sl.SetCellValue("E" + j.ToString(), "TALLE");
                sl.SetCellValue("F" + j.ToString(), "COLOR");
                sl.SetCellValue("G" + j.ToString(), "PRECIO");
                sl.SetCellValue("H" + j.ToString(), "FORANEA");
                sl.SetCellValue("I" + j.ToString(), "FECHA");
                j++;
                foreach (var venta in ventas)
                {
                    foreach (var prod in prods)
                    {
                        if (venta.id.Equals(prod.foranea))
                        {
                            sl.SetCellValue("B" + j.ToString(), prod.id);
                            sl.SetCellValue("C" + j.ToString(), prod.nombre_articulo);
                            sl.SetCellValue("D" + j.ToString(), prod.descripcion);
                            sl.SetCellValue("E" + j.ToString(), prod.talle);
                            sl.SetCellValue("F" + j.ToString(), prod.color);
                            sl.SetCellValue("G" + j.ToString(), prod.precio);
                            sl.SetCellValue("H" + j.ToString(), prod.foranea);
                            sl.SetCellValue("I" + j.ToString(), prod.grupo);
                            sl.SetCellValue("J" + j.ToString(), venta.fecha);
                            j++;
                        }
                    }
                }

                sl.SaveAs(rutaSalidaVentas + " FORMAS PAGOS" + ".xlsx");
                MessageBox.Show("Se Exportaron Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {

            }
        }
        private async void arreglo()
        {
            List<Producto> productos = new List<Producto>();
            productos = await firebaseHelper.getAllDetalleVenta();

            List<Producto> productosGaleria = new List<Producto>();
            List<Producto> productosStgo = new List<Producto>();
            List<Producto> productosPueyrredon = new List<Producto>();

            productosPueyrredon = await firebaseHelper.getAllProductosSucursal("Pueyrredon");

            foreach (var producto in productos)
            {
                switch (producto.grupo)
                {
                    case "BODY":
                        await firebaseHelper.updateProductoDetalleGRUPO(producto, "BODYS");
                        break;
                    case "bermudas":
                        await firebaseHelper.updateProductoDetalleGRUPO(producto, "BERMUDAS");
                        break;
                    case "camisas":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "CAMISAS");
                        break;
                    case "camisa":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "CAMISAS");
                        break;
                    case "CAMISA":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "CAMISAS");
                        break;
                    case "CAMPERA":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "CAMPERAS");
                        break;
                    case "CHALECO":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "CHALECOS");
                        break;
                    case "chomba":
                      await  firebaseHelper.updateProductoDetalleGRUPO(producto, "CHOMBAS");
                        break;
                    case "CONJUNTIO":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "CONJUNTOS");
                        break;
                    case "GORRA":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "GORRAS"); 
                        break;
                    case "gorras":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "GORRAS");
                        break;
                    case "jeans":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "JEANS");
                        break;
                    case "joggers":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "JOGGERS");
                        break;
                    case "short de baño":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "MALLAS");
                        break;
                    case "medias":
                      await  firebaseHelper.updateProductoDetalleGRUPO(producto, "MEDIAS");
                        break;
                    case "MUSCULOSA":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "MUSCULOSAS");
                        break;
                    case "remera":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "REMERAS");
                        break;
                    case "REMERA":
                        await firebaseHelper.updateProductoDetalleGRUPO(producto, "REMERAS");
                        break;
                    case "remeras":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "REMERAS");
                        break;
                    case "short":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "SHORTS");
                        break;
                    case "SHORT":
                        await firebaseHelper.updateProductoDetalleGRUPO(producto, "SHORTS");
                        break;
                    case "VESTIDO":
                       await firebaseHelper.updateProductoDetalleGRUPO(producto, "VESTIDOS");
                        break;
                    case "chinos":
                        await firebaseHelper.updateProductoDetalleGRUPO(producto, "CHINOS");
                        break;
                }
            }
            MessageBox.Show("Terrmino");

            
        }

        private void textContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.ActiveControl = buttonIngresar;
            }
        }

        private void asignarRoles()
        {
            Rol rol = new Rol();
            rol.rol = "33927555";
            rol.descripcion_rol = "Leer Ventas";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Crear Ventas";
            rol.SI = "NO";
            rol.NO = "SI";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Modificar Ventas";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Eliminar Ventas";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);


            rol.rol = "33927555";
            rol.descripcion_rol = "Ver Ganancias";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Leer Productos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Crear Productos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Modificar Productos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Eliminar Productos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Ver Precio Costo";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Leer Remitos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Crear Remitos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Modificar Remitos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Eliminar Remitos";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Leer OC";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Crear OC";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Modificar OC";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Eliminar OC";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Leer Usuario";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Crear Usuario";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Modificar Usuario";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Eliminar Usuario";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);


            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Leer Arqueo";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Crear Arqueo";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Modificar Arqueo";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Eliminar Arqueo";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Leer Cta Cte";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Crear Cta Cte";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Modificar Cta Cte";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            rol.rol = "33927555";
            rol.descripcion_rol = "Eliminar Cta Cte";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Leer Estadisticas";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "Configuracion";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);

            //------------------------------------------------

            rol.rol = "33927555";
            rol.descripcion_rol = "RRHH";
            rol.SI = "SI";
            rol.NO = "NO";
            firebaseHelper.addRol(rol);
        }
    }
}

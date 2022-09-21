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

namespace GiftGestion.Secciones.Herramientas
{
    public partial class ReposStock : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public List<Producto> productosGaleria = new List<Producto>();
        public List<Producto> productosStgo = new List<Producto>();
        public List<Producto> productosPueyrredon = new List<Producto>();
        public List<Producto> productosDep = new List<Producto>();
        public List<Producto> productosCarga = new List<Producto>();

        public List<Producto> productosAgregados = new List<Producto>();
        public List<Producto> productoss = new List<Producto>();


        private string rutaModeloStock = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Files/stock.xlsx";
        private string rutaSalidaStock = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GIFT Gestion/Stock/";


        public ReposStock()
        {
            InitializeComponent();
        }

        private async void ReposStock_Load(object sender, EventArgs e)
        {
            cargarProductosSucursales();
            productoss = await firebaseHelper.getAllProductos();
            productosAgregados = await firebaseHelper.getAllProductosV2();

            if (productosAgregados != null)
            {

                foreach (var producto in productosAgregados)
                {
                    dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, "", producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo,producto.costo);
                }
            }


            var gruposCarga = await firebaseHelper.getAllGrupos();
            foreach (var grupo in gruposCarga)
            {
                comboFiltroGrupo.Items.Add(grupo.nombre_grupo);
            }
        }
        //__________________________________________________________________________________________________________________________________
        //__________________________________________________________________________________________________________________________________
        //__________________________________________________________________________________________________________________________________
        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridProductos.Rows[e.RowIndex];

            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }

            dataGridProductosV2.Rows.Add(clonedRow);
            calcular();
        }

        private void dataGridProductosAgregados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridProductosAgregados.Rows[e.RowIndex];

            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }

            dataGridProductosV2.Rows.Add(clonedRow);
            calcular();
        }

        private void buttonReponer_Click(object sender, EventArgs e)
        {
           
            List<Producto> productos = new List<Producto>();
            foreach (DataGridViewRow row in dataGridProductosV2.Rows)
            {
                Producto producto = new Producto();
                if (row.Cells[0].Value!=null)
                {
                    producto.id = row.Cells[0].Value.ToString();
                    producto.nombre_articulo = row.Cells[1].Value.ToString();
                    producto.descripcion = row.Cells[2].Value.ToString();
                    producto.general = row.Cells[3].Value.ToString();
                    producto.deposito = row.Cells[4].Value.ToString();
                    producto.stgo = row.Cells[5].Value.ToString();

                    producto.puey = row.Cells[7].Value.ToString();
                    producto.proveedor = row.Cells[8].Value.ToString();
                    producto.estacion = row.Cells[9].Value.ToString();
                    producto.color = row.Cells[10].Value.ToString();
                    producto.talle = row.Cells[11].Value.ToString();
                    producto.grupo = row.Cells[12].Value.ToString();
                    producto.precio_lista = row.Cells[13].Value.ToString();
                    producto.precio_efectivo = row.Cells[14].Value.ToString();
                    producto.costo = row.Cells[15].Value.ToString();
                    productos.Add(producto);
                }
            }

            firebaseHelper.addProductos(productos, "+", "+", comboSucursal.Text,"+");


            MessageBox.Show("StockRepuesto");
        }
        //__________________________________________________________________________________________________________________________________
        //__________________________________________________________________________________________________________________________________
        //__________________________________________________________________________________________________________________________________
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

        private void cargarProductos()
        {
            try
            {


                if (productoss != null)
                {
                    dataGridProductos.Rows.Clear();

                    foreach (var producto in productoss)
                    {


                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                             buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                             buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                            producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                    }
                    foreach (var producto in productoss)
                    {
                        productosCarga.Add(producto);
                    }
                    dataGridProductos.Sort(dataGridProductos.Columns[16], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private string buscarProductoSucursal(string sucursal, string id)
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

        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                foreach (DataGridViewRow row in dataGridProductos.Rows)
                {
                    if (row.Cells[0].Value!=null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(textCodigo.Text))
                        {
                            dataGridProductosV2.Rows.Add(
                                row.Cells[0].Value.ToString(),
                                row.Cells[1].Value.ToString(),
                                row.Cells[2].Value.ToString(),
                                "1",
                                "0",
                                "0",
                                "0",
                                "1",
                                row.Cells[8].Value.ToString(),
                                row.Cells[9].Value.ToString(),
                                row.Cells[10].Value.ToString(),
                                row.Cells[11].Value.ToString(),
                                row.Cells[12].Value.ToString(),
                                row.Cells[13].Value.ToString(),
                                row.Cells[14].Value.ToString(),
                                row.Cells[15].Value.ToString()
                                );
                            /*
                            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
                            for (Int32 index = 0; index < row.Cells.Count; index++)
                            {
                                clonedRow.Cells[index].Value = row.Cells[index].Value;
                            }
                            dataGridProductosV2.Rows.Add(clonedRow);*/
                        }
                    }
                }
                textCodigo.Text = "";
                calcular();
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

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                             buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                             buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                            producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                    }
                                }
                                break;
                            case 2:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                             buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                             buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                            producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                             buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                             buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                            producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                    }
                                }
                                break;
                            case 3:
                                if (var[0].Length > 2)
                                {
                                    if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                             buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                             buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                            producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                    }
                                }
                                if (var[1].Length > 2)
                                {
                                    if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                             buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                             buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                            producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                    }
                                }
                                if (var[2].Length > 2)
                                {
                                    if (var[2].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                    {

                                        dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                             buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                             buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                            producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                                    }
                                }
                                break;
                        }

                    }
                    calcular();
                }
                textNombreFiltrar.Text = "";
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
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

                    foreach (var producto in productosCarga)
                    {
                        if (producto.grupo.Equals(comboFiltroGrupo.Text))
                        {

                            dataGridProductos.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.cantidad,
                                 buscarProductoSucursal("Deposito", producto.id), buscarProductoSucursal("Stgo del Estero", producto.id),
                                 buscarProductoSucursal("Galeria Palacio", producto.id), buscarProductoSucursal("Pueyrredon", producto.id), producto.proveedor, producto.estacion,
                                producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);


                        }
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void dataGridProductosV2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (dataGridProductosV2.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Producto  " + dataGridProductosV2.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridProductos.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridProductosV2.Rows.RemoveAt(e.RowIndex);
                        calcular();
                    }
                }
            }
        }

        private void calcular()
        {
            try
            {
                int selec = 0;
                int tot = 0;
                foreach (DataGridViewRow row in dataGridProductosV2.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (comboSucursal.Text.Equals("Pueyrredon"))
                        {
                            tot = tot + Int32.Parse(row.Cells[7].Value.ToString());
                        }
                        if (comboSucursal.Text.Equals("Stgo del Estero"))
                        {
                            tot = tot + Int32.Parse(row.Cells[5].Value.ToString());
                        }
                        
                    }
                }
                foreach (DataGridViewRow row in this.dataGridProductosV2.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (comboSucursal.Text.Equals("Pueyrredon"))
                        {
                            selec = selec + Int32.Parse(row.Cells[7].Value.ToString());
                        }
                        if (comboSucursal.Text.Equals("Stgo del Estero"))
                        {
                            selec = selec + Int32.Parse(row.Cells[5].Value.ToString());
                        }
                    }

                }
                textTotal.Text = "Total: " + tot.ToString() + " Seleccionado: " + selec.ToString();
            }
            catch(Exception es)
            {

            }
        }

        private void dataGridProductosV2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calcular();
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void textCodigo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                foreach (DataGridViewRow row in dataGridProductosAgregados.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(textCodigo2.Text))
                        {
                            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
                            for (Int32 index = 0; index < row.Cells.Count; index++)
                            {
                                clonedRow.Cells[index].Value = row.Cells[index].Value;
                            }
                            dataGridProductosV2.Rows.Add(clonedRow);
                        }
                    }
                }
                calcular();
                textCodigo2.Text = "";
            }
        }

        private async void buttonExportar_Click(object sender, EventArgs e)
        {
            List<Producto> productosREMITO = new List<Producto>();
            var productosVENTA = await firebaseHelper.getAllDetalleVenta();

            var remitoss = await firebaseHelper.getAllRemitos();
            var detalleRemitos = await firebaseHelper.getAllDetalleRemito();
            if (remitoss != null)
            {
                foreach (var remito in remitoss)
                {
                    if (remito.tipo.Equals("Entrada"))
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
            }

            try
            {
                SLDocument sl = new SLDocument(rutaModeloStock);
                int j = 5;
                foreach (var producto in productosCarga)
                {
                    int remito = 0;
                    int venta = 0;

                    int puey = 0;
                    int stgo = 0;
                    int gal = 0;
                    int gral = 0;

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
                    foreach (DataGridViewRow row in dataGridProductosAgregados.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.ToString().Equals(producto.id))
                            {
                                puey = puey + Int32.Parse(row.Cells[7].Value.ToString());
                                stgo = stgo + Int32.Parse(row.Cells[5].Value.ToString());
                                gral = gral + Int32.Parse(row.Cells[3].Value.ToString());
                                
                            }
                        }
                    }


                    sl.SetCellValue("B" + j.ToString(), producto.id);   //id prod
                    sl.SetCellValue("C" + j.ToString(), producto.nombre_articulo);
                    sl.SetCellValue("D" + j.ToString(), producto.descripcion);

                    sl.SetCellValue("E" + j.ToString(), producto.color);
                    sl.SetCellValue("F" + j.ToString(), producto.talle);
                    sl.SetCellValue("G" + j.ToString(), producto.grupo);
                    sl.SetCellValue("H" + j.ToString(), Int32.Parse(producto.costo));


                    sl.SetCellValue("I" + j.ToString(),remito);    //STOCK REMITO
                    sl.SetCellValue("K" + j.ToString(), venta);    //STOCK VENTA
                    sl.SetCellValue("M" + j.ToString(), Int32.Parse(producto.cantidad) ); //stock gral
                    sl.SetCellValue("N" + j.ToString(), gral); //stock gral

                    sl.SetCellValue("P" + j.ToString(), Int32.Parse(buscarProductoSucursal("Stgo del Estero", producto.id)));    //STOCK STGO
                    sl.SetCellValue("Q" + j.ToString(), stgo );    //STOCK STGO
                    
                    sl.SetCellValue("S" + j.ToString(), Int32.Parse(buscarProductoSucursal("Galeria Palacio", producto.id)) );    //STOCK GAL
                    sl.SetCellValue("T" + j.ToString(), gal);    //STOCK GAL
                   
                    sl.SetCellValue("V" + j.ToString(), Int32.Parse(buscarProductoSucursal("Pueyrredon", producto.id)) );    //STOCK PUEY 
                    sl.SetCellValue("W" + j.ToString(), puey );    //STOCK PUEY 
                    
                    sl.SetCellValue("Y" + j.ToString(), Int32.Parse(buscarProductoSucursal("Deposito", producto.id)) );    //STOCK PUEY 

                    j++;
                }

                sl.SaveAs(rutaSalidaStock + "CONTROL STOCK" + ".xlsx");
                MessageBox.Show("Se Generó el control STOCK", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}

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
    public partial class GenerarOC : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Producto> productos = new List<Producto>();
        Usuario user = new Usuario();
        List<Grupo> gruposCarga = new List<Grupo>();


        public GenerarOC(Usuario usuario)
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

        private async void GenerarOC_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            gruposCarga = await firebaseHelper.getAllGrupos();
            foreach (var grupo in gruposCarga)
            {
                comboGrupo.Items.Add(grupo.nombre_grupo);
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------
        private void buttonGenerarOC_Click(object sender, EventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                generarOrdenCompra();
            }
        }
     

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridProductosOC.Rows.Add(DateTime.Now.ToString("ddMMyyyyHHmmss"), textNombre.Text,
                              textDescripcion.Text, textCantidad.Text, comboProveedor.Text, comboEstacion.Text,
                              textColor.Text, comboTalle.Text, comboGrupo.Text,
                              textPrecioLista.Text, textPrecioEfectivo.Text, textCosto.Text);
                calcularTotal();
            }
            catch (Exception ES)
            {

            }
        }

        private void textCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void textCosto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textPrecioLista.Text = (Math.Round(Int32.Parse(textCosto.Text) * 1.40) + Int32.Parse(textCosto.Text)).ToString();
                textPrecioEfectivo.Text = (Math.Round(Int32.Parse(textCosto.Text) * 1.1) + Int32.Parse(textCosto.Text)).ToString();
            }
            catch (Exception es)
            {

            }
        }
        private void dataGridProductosOC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            calcularSubtotal();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void generarOrdenCompra()
        {
            try
            {
                buttonGenerarOC.Enabled = false;
                buttonGenerarOC.Text = "Espere porfavor...";
                Producto producto = null;
                string idOrdenCompra = DateTime.Now.ToString("ddMMyyyyHHmmss");

                foreach (DataGridViewRow row in dataGridProductosOC.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        producto = new Producto();
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

                        producto.general = "0";
                        producto.deposito = "0";
                        producto.stgo = "0";
                        producto.puey = "0";
                        productos.Add(producto);

                        /*
                        await firebaseHelper.updateProductoOC(row.Cells[0].Value.ToString(),
                       row.Cells[1].Value.ToString(),
                       row.Cells[2].Value.ToString(),
                       row.Cells[5].Value.ToString(),
                       row.Cells[8].Value.ToString(),
                       row.Cells[7].Value.ToString(),
                       row.Cells[6].Value.ToString(),
                       row.Cells[4].Value.ToString(),
                       row.Cells[3].Value.ToString(),
                       row.Cells[9].Value.ToString(),
                       row.Cells[10].Value.ToString(),
                       row.Cells[11].Value.ToString());
                        */
                    }
                    producto = new Producto();
                }

                firebaseHelper.addProductos(productos, " ", " ", " ", " ");
                
                firebaseHelper.addDetalleOrdenCompra(idOrdenCompra, productos);
                firebaseHelper.addOrdenCompra(idOrdenCompra, dateFecha.Value.ToString("dd/MM/yyyy"),
                    DateTime.Now.ToString("HH:mm"), user.dni,
                    textObservacion.Text,
                    dateValidoHasta.Value.ToString("dd/MM/yyyy"),
                    comboProveedorOC.Text,
                    textTotal.Text,
                    textGanancia.Text,
                    comboPrioridad.Text,
                    "PENDIENTE",
                    "NO"
                    );
                MessageBox.Show("Orden de Compra generada");
                this.Close();
            }
            catch (Exception es)
            {

            }
        }

        private void calcularTotal()
        {
            try
            {
                int total = 0;
                int ganancia = 0;
                foreach (DataGridViewRow row in dataGridProductosOC.Rows)
                {
                    if (row.Cells[3].Value!=null)
                    {
                        total += Int32.Parse(row.Cells[3].Value.ToString()) * Int32.Parse(row.Cells[11].Value.ToString());
                        ganancia += Int32.Parse(row.Cells[3].Value.ToString()) * Int32.Parse(row.Cells[10].Value.ToString());
                    }
                   
                }
                textTotal.Text = total.ToString();
                textGanancia.Text = ganancia.ToString();
            }
            catch(Exception es)
            {

            }
        }

        private void limpiar()
        {
            textNombre.Text = "";
            textDescripcion.Text = "";
            comboEstacion.Text = "";
            comboGrupo.Text = "";
            comboTalle.Text = "";
            textColor.Text = "";
            comboProveedor.Text = "";
            textCantidad.Text = "";
            textCosto.Text = "";
            textPrecioEfectivo.Text = "";
            textPrecioLista.Text = "";
        }

        private void calcularSubtotal()
        {
            try
            {
                int cant = 0;
                int costo = 0;
                foreach (DataGridViewRow item in this.dataGridProductosOC.SelectedRows)
                {
                    if (item.Cells[3].Value != null)
                    {
                        cant += Int32.Parse(item.Cells[3].Value.ToString());
                        costo += Int32.Parse(item.Cells[3].Value.ToString()) * Int32.Parse(item.Cells[11].Value.ToString());

                    }
                        
                }
                textCantidadProductos.Text ="Cantidad: "+ cant.ToString();
                textTotalCosto.Text = "Costo: $"+costo.ToString();
            }
            catch (Exception es)
            {

            }

        }

        private void dataGridProductosOC_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridProductosOC.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Producto  " + dataGridProductosOC.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridProductosOC.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridProductosOC.Rows.RemoveAt(e.RowIndex);
                        calcularSubtotal();
                        calcularTotal();
                    }
                }
            }
        }
    }
}

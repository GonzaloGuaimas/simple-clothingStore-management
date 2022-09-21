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

namespace GiftGestion.Secciones.Herramientas
{
    public partial class ControlStock : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public List<Producto> productosAgregados = new List<Producto>();

        public ControlStock()
        {
            InitializeComponent();
        }

        private async void ControlStock_Load(object sender, EventArgs e)
        {
            productosAgregados = await firebaseHelper.getAllProductosV2();

            if (productosAgregados != null)
            {
                foreach (var producto in productosAgregados)
                {
                    dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                }
            }
        }





        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------



        private void textNombreFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridProductosAgregados.Rows.Clear();
            string nom = "";
            string[] var = null;
            foreach (var producto in productosAgregados)
            {
                nom = producto.nombre_articulo;
                var = nom.Split(' ');
                switch (var.Length)
                {
                    case 1:
                        if (var[0].Length > 2)
                        {

                            if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                        }
                        break;
                    case 2:
                        if (var[0].Length > 2)
                        {
                            if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

                        }
                        if (var[1].Length > 2)
                        {
                            if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

                        }
                        break;
                    case 3:
                        if (var[0].Length > 2)
                        {
                            if (var[0].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);

                        }
                        if (var[1].Length > 2)
                        {
                            if (var[1].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                        }
                        if (var[2].Length > 2)
                        {
                            if (var[2].Substring(0, 3).ToLower().Equals(textNombreFiltrar.Text.Substring(0, 3).ToLower()))
                                dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
                        }
                        break;
                }
            }
            textNombreFiltrar.Text = "";
        }
        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (row.Cells[0].Value.ToString().Equals(textCodigo.Text))
                        {
                            dataGridRealidad.Rows.Add(
                                row.Cells[0].Value.ToString(),
                                row.Cells[1].Value.ToString(),
                                row.Cells[2].Value.ToString(),
                                "0",
                                "0",
                                "0",
                                "1",
                                row.Cells[7].Value.ToString(),
                                row.Cells[8].Value.ToString(),
                                row.Cells[9].Value.ToString(),
                                row.Cells[10].Value.ToString(),
                                row.Cells[11].Value.ToString(),
                                row.Cells[12].Value.ToString(),
                                row.Cells[13].Value.ToString(),
                                row.Cells[14].Value.ToString()
                                );
                        }
                    }
                }
                textCodigo.Text = "";
                calcular();
            }
        }
        private void calcular()
        {
            try
            {
                textCantidad.Text = dataGridRealidad.Rows.Count.ToString();
            }
            catch(Exception es)
            {
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------


        private void dataGridProductosAgregados_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            dataGridRealidad.Rows.Add(
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            "0",
                            "0",
                            "0",
                            "1",
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[7].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[8].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[9].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[10].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[11].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[12].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[13].Value.ToString(),
                            dataGridProductosAgregados.Rows[e.RowIndex].Cells[14].Value.ToString()
                            );
            calcular();
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            dataGridProductosAgregados.Rows.Clear();
            foreach (var producto in productosAgregados)
            {
                dataGridProductosAgregados.Rows.Add(producto.id, producto.nombre_articulo, producto.descripcion, producto.general, producto.deposito, producto.stgo, producto.puey, producto.proveedor, producto.estacion, producto.color, producto.talle, producto.grupo, producto.precio_lista, producto.precio_efectivo, producto.costo);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------


        private void buttonCruzar_Click(object sender, EventArgs e)
        {
            dataGridProductosResultado.Rows.Clear();
            string codigo = "";
            foreach (DataGridViewRow row in dataGridProductosAgregados.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    int count = 0;
                    codigo = row.Cells[0].Value.ToString();

                    foreach (DataGridViewRow row2 in dataGridRealidad.Rows)
                    {
                        if (row2.Cells[0].Value != null)
                        {
                            if (row2.Cells[0].Value.ToString().Equals(codigo))
                            {
                                count++;
                            }
                        }
                    }
                    dataGridProductosResultado.Rows.Add(
                                   row.Cells[0].Value.ToString(),
                                   row.Cells[1].Value.ToString(),
                                   row.Cells[2].Value.ToString(),
                                   row.Cells[3].Value.ToString(),
                                   row.Cells[4].Value.ToString(),
                                   row.Cells[5].Value.ToString(),
                                   "",//real stgo
                                   row.Cells[6].Value.ToString(),
                                   count,//real puey
                                   row.Cells[7].Value.ToString(),
                                   row.Cells[8].Value.ToString(),
                                   row.Cells[9].Value.ToString(),
                                   row.Cells[10].Value.ToString(),
                                   row.Cells[11].Value.ToString(),
                                   row.Cells[12].Value.ToString(),
                                   row.Cells[13].Value.ToString(),
                                   row.Cells[14].Value.ToString()
                                   );
                }
            }
        }

        
    }
}

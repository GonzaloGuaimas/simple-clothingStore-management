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

namespace GiftGestion.Flotante
{
    public partial class ExtraccionCaja : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        List<GastoDiario> cargaGastosDiarios = new List<GastoDiario>();
        Usuario usuario = new Usuario();

        public ExtraccionCaja(Usuario user)
        {
            usuario = user;
            InitializeComponent();
        }

        private void ExtraccionCaja_Load(object sender, EventArgs e)
        {
            comboSucursal.Text = usuario.sucursal;
            comboEmpleado.Text = usuario.apellido + " " + usuario.nombre;
            cargarDatos();
        }


        //---------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------
        private void textMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private async void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textMotivo.Text != "" && textMonto.Text != "")
                {
                    if (!comboSucursal.Text.Equals("-"))
                    {
                        buttonAgregar.Enabled = false;
                        GastoDiario gasto = new GastoDiario();
                        gasto.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                        gasto.fecha = dateFecha.Value.ToString("dd/MM/yyyy HH:mm:ss");
                        gasto.empleado = comboEmpleado.Text;
                        gasto.sucursal = comboSucursal.Text;
                        gasto.motivo = textMotivo.Text;
                        gasto.monto = textMonto.Text;

                        await firebaseHelper.addGastoDiario(gasto);

                        MessageBox.Show("Se agregó el Gasto");
                        buttonAgregar.Enabled = true;
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una sucursal");
                    }

                }
                else
                {
                    MessageBox.Show("Complete Campos");
                }


            } catch (Exception es)
            {

            }
        }

        private void dateFiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            dataGridGastos.Rows.Clear();
            foreach (var gasto in cargaGastosDiarios)
            {
                DateTime date1 = new DateTime(Int32.Parse(dateFiltroFecha.Value.ToString("yyyy")),
                    Int32.Parse(dateFiltroFecha.Value.ToString("MM")), 
                    Int32.Parse(dateFiltroFecha.Value.ToString("dd")), 0, 0, 0);
                
                DateTime date2 = new DateTime(Int32.Parse(gasto.fecha.Substring(6, 4)),
                    Int32.Parse(gasto.fecha.Substring(3, 2)),
                    Int32.Parse(gasto.fecha.Substring(0, 2)), 0, 0, 0);
                int result = DateTime.Compare(date1, date2);
                if (result == 0)
                {
                    dataGridGastos.Rows.Add(gasto.id, gasto.fecha, gasto.monto, gasto.motivo, gasto.empleado, gasto.sucursal);
                    total += Int32.Parse(gasto.monto);
                }
            }
            textTotalExtraccion.Text = "Total: $" + total.ToString();
        }

        private void comboFiltroSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int total = 0;
            dataGridGastos.Rows.Clear();
            foreach (var gasto in cargaGastosDiarios)
            {
                if (gasto.sucursal.Equals(comboFiltroSucursal.Text))
                {
                    dataGridGastos.Rows.Add(gasto.id, gasto.fecha, gasto.monto, gasto.motivo, gasto.empleado, gasto.sucursal);
                    total += Int32.Parse(gasto.monto);
                }
            }
            textTotalExtraccion.Text = "Total: $" + total.ToString();
        }
        private void buttonTodos_Click(object sender, EventArgs e)
        {
            dataGridGastos.Rows.Clear();
            foreach (var gasto in cargaGastosDiarios)
            {
                dataGridGastos.Rows.Add(gasto.id, gasto.fecha, gasto.monto, gasto.motivo, gasto.empleado, gasto.sucursal);
            }
            calcular();
        }
        //---------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------

        private async void cargarDatos()
        {
            try
            {
                dataGridGastos.Rows.Clear();
                cargaGastosDiarios = await firebaseHelper.getAllGastoDiario();

                foreach (var gasto in cargaGastosDiarios)
                {
                    dataGridGastos.Rows.Add(gasto.id, gasto.fecha, gasto.monto, gasto.motivo, gasto.empleado, gasto.sucursal);
                }
                calcular();
            } catch (Exception es)
            {

            }
        }

        private void calcular()
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridGastos.Rows)
            {
                if (row.Cells[0].Value!=null)
                {
                    total += Int32.Parse(row.Cells[2].Value.ToString());
                }
                
            }
            textTotalExtraccion.Text = "Total: $" + total.ToString();
        }

      
    }
}

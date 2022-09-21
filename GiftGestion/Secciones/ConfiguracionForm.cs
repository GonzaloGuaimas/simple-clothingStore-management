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

namespace GiftGestion.Secciones
{
    public partial class ConfiguracionForm : Form
    {
        Usuario user = new Usuario();
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        List<Tarjeta> tarjetasCarga = new List<Tarjeta>();
        List<Clave> claveCarga = new List<Clave>();
        List<Grupo> gruposCarga = new List<Grupo>();
        public ConfiguracionForm(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        private void ConfiguracionForm_Load(object sender, EventArgs e)
        {
            precargarFormasPagos();
            precargarClaves();
            precargarGrupos();
        }

    

        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        private void buttonAgregarTarjeta_Click(object sender, EventArgs e)
        {
            if (textNombreTarjeta.Text!="" && textComision.Text!="")
            {
                dataGridFormaPago.Rows.Add(DateTime.Now.ToString("ddMMyyyyHHmmss"),textNombreTarjeta.Text,textComision.Text);
            }
            else
            {
                MessageBox.Show("Complete Campos");
            }
        }

        private void buttonAgregarClave_Click(object sender, EventArgs e)
        {
            if (textClave.Text != "")
            {
                dataGridClaves.Rows.Add(textClave.Text, textClave.Text,user.apellido);
            }
            else
            {
                MessageBox.Show("Complete Campos");
            }
        }
        private async void buttonAgregarGrupo_Click(object sender, EventArgs e)
        {
            if (!textNombreGrupo.Text.Equals(""))
            {
                Grupo grupo = new Grupo();
                grupo.id = DateTime.Now.ToString("dd/MM/yyyy");
                grupo.nombre_grupo = textNombreGrupo.Text;
                await firebaseHelper.addGrupo(grupo);
            }
        }
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        private async void buttonActualizarTarjetas_Click(object sender, EventArgs e)
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
           
            foreach (DataGridViewRow row in dataGridFormaPago.Rows)
            {
               
                if (row.Cells[0].Value != null)
                {
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.id = row.Cells[0].Value.ToString(); ;
                    tarjeta.nombre = row.Cells[1].Value.ToString();
                    tarjeta.comision = row.Cells[2].Value.ToString();
                    tarjetas.Add(tarjeta);
                }
            }

            foreach (var tarjeta in tarjetas)
            {
                await firebaseHelper.updateFormaPago(tarjeta.id,tarjeta.nombre,tarjeta.comision);
            }

        }

        private async void buttonActualizarClaves_Click(object sender, EventArgs e)
        {
            List<Clave> claves = new List<Clave>();

            foreach (DataGridViewRow row in dataGridClaves.Rows)
            {

                if (row.Cells[0].Value != null)
                {
                    Clave clave = new Clave();
                    clave.id = row.Cells[0].Value.ToString(); ;
                    clave.clave = row.Cells[1].Value.ToString();
                    clave.nombre_empleado_alta = row.Cells[2].Value.ToString();
                    claves.Add(clave);
                }
            }

            foreach (var clave in claves)
            {
                await firebaseHelper.updateClave(clave.id, clave.clave, clave.nombre_empleado_alta,clave.fecha);
            }
        }
        private void buttonActualizarPorcentajeG_Click(object sender, EventArgs e)
        {

        }
        private async void dataGridClaves_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (dataGridClaves.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Clave  " + dataGridClaves.Rows[e.RowIndex].Cells[1].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridClaves.Rows.RemoveAt(e.RowIndex);

                        await firebaseHelper.deleteClave(dataGridClaves.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------

        private async void precargarFormasPagos()
        {
            try
            {
                var formas = await firebaseHelper.getAllFormasPagos();
                foreach (var forma in formas)
                {
                    tarjetasCarga.Add(forma);
                }
                foreach (var tarjeta in tarjetasCarga)
                {
                    dataGridFormaPago.Rows.Add(tarjeta.id, tarjeta.nombre, tarjeta.comision);
                }
            }catch(Exception ES)
            {

            }
        }
        private async void precargarClaves()
        {
            try
            {
                var claves = await firebaseHelper.getAllClaves();
                foreach (var clave in claves)
                {
                    claveCarga.Add(clave);
                }
                foreach (var clave in claveCarga)
                {
                    dataGridClaves.Rows.Add(clave.id, clave.clave, clave.nombre_empleado_alta);
                }
            }
            catch (Exception ES)
            {

            }
        }
        private async void precargarGrupos()
        {
            try
            {
                gruposCarga = await firebaseHelper.getAllGrupos();

                foreach (var grupo in gruposCarga)
                {
                    dataGridGrupo.Rows.Add(grupo.id, grupo.nombre_grupo);
                }
            }
            catch (Exception ES)
            {

            }
        }


    }
   
}

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
    public partial class RRHHForm : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Usuario> usuarios = new List<Usuario>(); 
        List<Rol> roles = new List<Rol>(); 
        
        
        public RRHHForm(Usuario usuario)
        {
            InitializeComponent();
        }

        private void RRHHForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cargarDatos();
        }

        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------

        private async void cargarDatos()
        {
            /*
            usuarios = await firebaseHelper.getAllUsuario();
            roles = await firebaseHelper.getAllRol();
            cargarUsuarios();
            */
        }

        private void cargarUsuarios()
        {
            try
            {
                dataGridUsuarios.Rows.Clear();
                foreach (var usuario in usuarios)
                {
                    dataGridUsuarios.Rows.Add(usuario.dni, usuario.apellido, usuario.nombre, usuario.rol,
                        usuario.contraseña, usuario.sucursal, usuario.mail);
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
          
        }
        private void cargarRoles(string id)
        {
            dataGridRoles.Rows.Clear();
            foreach (var rol in roles)
            {
                Boolean bandSI = false;
                Boolean bandNO = false;
                if (rol.rol.Equals(id))
                {
                    if (rol.SI.Equals("SI"))
                    {
                        bandSI = true;
                    }
                    if (rol.NO.Equals("SI"))
                    {
                        bandNO = true;
                    }
                    dataGridRoles.Rows.Add(rol.descripcion_rol, bandSI, bandNO);
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        private void dataGridUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridUsuarios.Rows[e.RowIndex].Cells[0].Value != null)
            {
                cargarRoles(dataGridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
                textDNIUsuario.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                textDNI.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                textApellido.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                textNombre.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboRol.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                textContraseña.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboSucursal.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (dataGridUsuarios.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    textEmail.Text = dataGridUsuarios.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
            }

            if (MouseButtons.Right.Equals(e.Button))
            {
                if (dataGridUsuarios.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Usuario  " + dataGridUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {

                        firebaseHelper.deleteUsuario(dataGridUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
                        dataGridUsuarios.Rows.RemoveAt(e.RowIndex);
                    }

                }
            }
        }

        private async void buttonActualizarRoles_Click(object sender, EventArgs e)
        {
            try
            {
                buttonActualizarRoles.Enabled = false;
                buttonActualizarRoles.Text = "Espere...";
                foreach (DataGridViewRow row in dataGridRoles.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        Rol rol = new Rol();
                        rol.SI = "NO";
                        rol.NO = "NO";
                        rol.rol = textDNIUsuario.Text;
                        rol.descripcion_rol = row.Cells[0].Value.ToString();

                        if (Convert.ToBoolean(row.Cells[1].Value).Equals(true))
                        {
                            rol.SI = "SI";
                        }
                        if (Convert.ToBoolean(row.Cells[2].Value).Equals(true))
                        {
                            rol.NO = "SI";
                        }
                        await firebaseHelper.updateRol(rol);
                    }
                }
                buttonActualizarRoles.Enabled = true;
                buttonActualizarRoles.Text = "Actualizar";
                MessageBox.Show("Roles Actualizados");
                cargarDatos();
                
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
           
        }

        private async void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonAgregarUsuario.Text.Equals("Agregar"))
                {
                    if (!textDNI.Text.Equals("") && !textApellido.Text.Equals("") && !textNombre.Text.Equals("") && !comboRol.Text.Equals("")
                     && !textContraseña.Text.Equals("") && !comboSucursal.Text.Equals(""))
                    {
                        if (comboRol.Equals("Admin") && comboRol.Equals("Gerente") && !textEmail.Text.Equals(""))
                        {
                            await firebaseHelper.addUsuario(textDNI.Text, textNombre.Text, textApellido.Text, comboRol.Text, comboSucursal.Text, textContraseña.Text, textEmail.Text);
                        }
                        else if (comboRol.Equals("Admin") && comboRol.Equals("Gerente") && textEmail.Text.Equals(""))
                        {
                            MessageBox.Show("Complete Campo con Gmail (unicamente @gmail)");
                        }
                        else
                        {
                            await firebaseHelper.addUsuario(textDNI.Text, textNombre.Text, textApellido.Text, comboRol.Text, comboSucursal.Text, textContraseña.Text, "");
                        }
                    }
                    cargarDatos();
                }
                else if (buttonAgregarUsuario.Text.Equals("Actualizar"))
                {
                    if (!textDNI.Text.Equals("") && !textApellido.Text.Equals("") && !textNombre.Text.Equals("") && !comboRol.Text.Equals("")
                     && !textContraseña.Text.Equals("") && !comboSucursal.Text.Equals(""))
                    {
                        if (comboRol.Equals("Admin") && comboRol.Equals("Gerente") && !textEmail.Text.Equals(""))
                        {
                            await firebaseHelper.updateUsuario(textDNI.Text, textNombre.Text, textApellido.Text, comboRol.Text, comboSucursal.Text, textContraseña.Text, textEmail.Text);
                        }
                        else if (comboRol.Equals("Admin") && comboRol.Equals("Gerente") && textEmail.Text.Equals(""))
                        {
                            MessageBox.Show("Complete Campo con Gmail (unicamente @gmail)");
                        }
                        else
                        {
                            await firebaseHelper.updateUsuario(textDNI.Text, textNombre.Text, textApellido.Text, comboRol.Text, comboSucursal.Text, textContraseña.Text, "");
                        }
                    }
                    cargarDatos();
                }
            }
            catch(Exception es)
            {

            }
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRol.Text.Equals("Admin") || comboRol.Text.Equals("Gerente"))
            {
                textEmail.Enabled = true;
                comboSucursal.Enabled = false;
                comboSucursal.Text = "-";
            }
            else
            {
                textEmail.Enabled = true;
                comboSucursal.Enabled = true;
                comboSucursal.Text = "";
            }
        }
    }
}

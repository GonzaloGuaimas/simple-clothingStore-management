using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftGestion.Secciones;
using GiftGestion.Objetos;
using GiftGestion.Secciones.Herramientas;

namespace GiftGestion
{
    public partial class Main : Form
    {
        Usuario user = new Usuario();
        FirebaseHelper firebase = new FirebaseHelper();

        List<Usuario> usuarios = new List<Usuario>();
        public Main(Usuario usuario)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Verifique su Conexión a Internet", "Sin Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cargarUsuarios();
                InitializeComponent();
                user = usuario;
            }
            
        }
        private void Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        private void buttonRemitos_Click(object sender, EventArgs e)
        {
            if (user.rol.Equals("Admin") || user.rol.Equals("Gerente") || user.rol.Equals("Gerente"))
            {
                RemitosForm remitos = new RemitosForm(user);
                remitos.Show();
            }
            else
            {
                MessageBox.Show("No tiene permisos");
            }
          
        }
        private void buttonProductos_Click(object sender, EventArgs e)
        {
            ProductosForm productos = new ProductosForm(user);
            productos.Show();
        }
        private void buttonVentas_Click(object sender, EventArgs e)
        {
            VentasForm ventasForm = new VentasForm(user);
            ventasForm.Show();
        }
        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonArqueoCaja_Click(object sender, EventArgs e)
        {
            ArqueoCajaForm arqueoCajaForm = new ArqueoCajaForm(user, usuarios);
            arqueoCajaForm.Show();
        }

        private void buttonOrdenesCompras_Click(object sender, EventArgs e)
        {
            if (user.rol.Equals("Admin") || user.rol.Equals("Gerente"))
            {
                OrdenCompraForm ordenCompraForm = new OrdenCompraForm(user);
                ordenCompraForm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permisos");
            }
        }

        private void buttonEstadisticas_Click(object sender, EventArgs e)
        {
            if (user.rol.Equals("Admin") || user.rol.Equals("Gerente"))
            {
                EstadisticasForm estadisticasForm = new EstadisticasForm(user);
                estadisticasForm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permisos");
            }
        }

        private void buttonConfiguracion_Click(object sender, EventArgs e)
        {
            if (user.rol.Equals("Admin") || user.rol.Equals("Gerente"))
            {
                ConfiguracionForm configuracionForm = new ConfiguracionForm(user);
                configuracionForm.Show();
            }
            else
            {
                MessageBox.Show("No tiene permisos");
            }
        }
        private void buttonRRHH_Click(object sender, EventArgs e)
        {
            if (user.rol.Equals("Admin") || user.rol.Equals("Gerente"))
            {
                RRHHForm rrhh = new RRHHForm(user);
                rrhh.Show();
            }
            else
            {
                MessageBox.Show("No tiene permisos");
            }
        }
        private void buttonClientes_Click(object sender, EventArgs e)
        {
            ClientesForm clientes = new ClientesForm(user);
            clientes.Show();
        }

        private void buttonControlStock_Click(object sender, EventArgs e)
        {
            ControlStock reposStock = new ControlStock();
            reposStock.Show();
        }

        private void buttonCambios_Click(object sender, EventArgs e)
        {
            CambiosForm cambios = new CambiosForm(user);
            cambios.Show();
        }


        private async void cargarUsuarios()
        {
            try 
            {
                var empleados = await firebase.getAllUsuario();

                foreach (var empleado in empleados)
                {
                    if(empleado.rol.Equals("Admin"))
                    usuarios.Add(empleado);
                }
            }
            catch(Exception es)
            {

            }
        }

     
    }
}

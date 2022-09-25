using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftGestion.Secciones.SubSecciones;
using GiftGestion.Objetos;
using System.Globalization;
using SpreadsheetLight;
namespace GiftGestion.Secciones
{
    public partial class CambiosForm : Form
    {
        Usuario user = new Usuario();
        Venta venta = new Venta();
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        List<Venta> ventasCarga = new List<Venta>();
        List<FormaPago> formaPagoCarga = new List<FormaPago>();
        List<Producto> productosCarga = new List<Producto>();

        public CambiosForm()
        {
            InitializeComponent();
        }

        private void CambiosForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonGenerarCambio_Click(object sender, EventArgs e)
        {

        }
    }
}

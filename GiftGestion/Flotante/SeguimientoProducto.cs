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
    public partial class SeguimientoProducto : Form
    {
        private List<Remito> remitos = new List<Remito>();
        private List<Producto> productosRemitos = new List<Producto>();
        private List<Venta> ventas = new List<Venta>();
        private List<Producto> productosVentas = new List<Producto>();
        private Producto product;

        public SeguimientoProducto(Producto prod, List<Remito> rem, List<Producto> productosRem, List<Venta> vent, List<Producto> productosVent)
        {
            InitializeComponent();
            product = prod;
            remitos = rem;
            productosRemitos = productosRem;
            ventas = vent;
            productosVentas = productosVent;
        }

        private void SeguimientoProducto_Load(object sender, EventArgs e)
        {
            textInformacionProducto.Text = product.id + " | " + product.nombre_articulo + " | " + product.descripcion + " | " +
                product.cantidad + " | " + product.color + " | " + product.talle + " | ";
            foreach (var remito in remitos)
            {
                foreach (var producto in productosRemitos)
                {
                    if (producto.foranea.Equals(remito.id) && producto.id.Equals(product.id))
                    {
                        dataGridRemitos.Rows.Add(remito.fecha,remito.tipo,producto.cantidad,remito.destino,remito.observacion);
                    }
                }
            }
            foreach (var venta in ventas)
            {
                foreach (var producto in productosVentas)
                {
                    if (producto.foranea.Equals(venta.id) && producto.id.Equals(product.id))
                    {
                        dataGridVentas.Rows.Add(venta.fecha, producto.cantidad, venta.nombre_sucursal, venta.nombre_empleado);
                    }
                }
            }
        }
    }
}

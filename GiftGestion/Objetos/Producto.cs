using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftGestion.Objetos
{
    public class Producto
    {
        public string id { get; set; }
        public string nombre_articulo { get; set; }
        public string descripcion { get; set; }
        public string estacion { get; set; }
        public string grupo { get; set; }
        public string talle { get; set; }
        public string color { get; set; }
        public string proveedor { get; set; }
        public string cantidad { get; set; }
        public string costo { get; set; }
        public string precio_lista { get; set; }
        public string precio_efectivo { get; set; }

        //----------producto venta---------------

        public string precio { get; set; }

        //----------------------------------------
        public string foranea { get; set; }

        //---------sucursales,deposito,gral--------------------

        public string deposito { get; set; }
        public string general { get; set; }
        public string stgo { get; set; }
        public string puey { get; set; }


    }
}

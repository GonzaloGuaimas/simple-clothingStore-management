using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftGestion.Objetos
{
    public class OrdenCompra
    {
        public string id { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string empleado { get; set; }
        public string observacion { get; set; }

        //faltaria poner
        public string total { get; set; }
        public string proveedor { get; set; }
        public string ganancia { get; set; }
        public string prioridad { get; set; }
        public string validoHasta { get; set; }

        //falta poner

        public string estado { get; set; }
        public string remito { get; set; }
    }
}

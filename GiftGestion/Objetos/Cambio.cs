using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftGestion.Objetos
{
    public class Cambio
    {
        public string id { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string nombre_empleado { get; set; }
        public string nombre_sucursal { get; set; }
        public string nombre_cliente { get; set; }
        public string observacion { get; set; }
        public string estado { get; set; }
        public string tipo_pago { get; set; }
        public string total { get; set; }
        public string ganancia { get; set; }

    }
}

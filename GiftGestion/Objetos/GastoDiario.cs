using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftGestion.Objetos
{
    public class GastoDiario
    {
        public string id { get; set; }
        public string fecha { get; set; }
        public string sucursal { get; set; }
        public string empleado { get; set; }
        public string motivo { get; set; }
        public string monto { get; set; }
    }
}

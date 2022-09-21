using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftGestion.Objetos
{
    public class ArqueoCaja
    {
        public string id { get; set; }
        public string fecha { get; set; }
        public string hora_cierre { get; set; }
        public string sucursal { get; set; }
        public string empleado { get; set; }
        public string efectivo_sistema { get; set; }
        public string efectivo_empleado { get; set; }   //efectivo cierre
        public string efectivo_apertura { get; set; }   //efectivo apertura
        public string efectivo_TM { get; set; }   //efectivo hasta TM
        public string efectivo_Extraccion { get; set; }   //efectivo extraccion
        public string efectivo_Restante { get; set; }   //efectivo restante
        public string efectivo_Total { get; set; }   //efectivo apertura + sistema
        public string gasto_diario { get; set; }   //gasto diario

        public string debito { get; set; }
        public string credito { get; set; }
        public string transferencia { get; set; }
        public string canje { get; set; }
        public string ctacte { get; set; }
        public string total { get; set; }
        public string descuento { get; set; }
        public string comentario { get; set; }

        //
        public string estado { get; set; }

    }
}

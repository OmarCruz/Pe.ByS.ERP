using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja
{
    public class TipoPago
    {
        public int id { get; set; }
        public int tipoPagoId { get; set; }
        public String tipoPagoText { get; set; }
        public int monedaId { get; set; }
        public String monedaText { get; set; }
        public String referencia { get; set; }
        public double monto { get; set; }        
    }
}

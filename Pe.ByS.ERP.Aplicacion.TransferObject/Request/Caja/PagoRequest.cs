using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja
{
    public class PagoRequest
    {
        public int numeroSolicitud { get; set; }
        public decimal montoRecibido { get; set; }
        public decimal vuelto { get; set; }
        public String referenciaPagoTarjeta { get; set; }
        public int codigoTipoDocumento { get; set; }
        public String ruc { get; set; }
        public String razonSocial { get; set; }
        public int codigoTipoPago { get; set; }
        public int codigoTipoMoneda { get; set; }
    }
}

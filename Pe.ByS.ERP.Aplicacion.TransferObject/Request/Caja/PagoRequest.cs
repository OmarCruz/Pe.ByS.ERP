using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja
{
    public class PagoRequest
    {
        //public int numeroSolicitud { get; set; }
        //public decimal montoRecibido { get; set; }
        //public decimal vuelto { get; set; }
        //public String referenciaPagoTarjeta { get; set; }
        //public int codigoTipoDocumento { get; set; }
        //public String ruc { get; set; }
        //public String razonSocial { get; set; }
        //public int codigoTipoPago { get; set; }
        //public int codigoTipoMoneda { get; set; }

        public decimal montoRecibido { get; set; }
        public int documentoId { get; set; }
        public int documentoPagoId { get; set; }
        public String numeroDocumento { get; set; }
        public int numeroSolicitudVenta { get; set; }
        public decimal montoTotal { get; set; }
        public decimal Vuelto { get; set; }
        public String ruc { get; set; }
        public String razonSocial { get; set; }
        public String observaciones { get; set; }
        public int tipoDocumentoId { get; set; }
        public String tipoAtencion { get; set; }
        public int tipoCambioId { get; set; }

        public String referenciaPagoTarjeta { get; set; }
        public decimal monto { get; set; }
        public int productoId { get; set; }
        public int cantidadProducto { get; set; }
        public int tipoPagoId { get; set; }
        public int monedaId { get; set; }

        public List<TipoPago> tipoPago { get; set; }



    }
}

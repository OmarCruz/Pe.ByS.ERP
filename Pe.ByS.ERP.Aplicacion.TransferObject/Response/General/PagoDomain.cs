using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Response.General
{
    public class PagoDomain
    {

        public int documentoPagoId { get; set; }
        public int documentoId { get; set; }
        public String numeroDocumento { get; set; }
        public int numeroSolicitudVenta { get; set; }
        public decimal montoTotal { get; set; }
        public decimal montoRecibido { get; set; }
        public decimal Vuelto { get; set; }
        public String ruc { get; set; }
        public String razonSocial { get; set; }
        public String observaciones { get; set; }
        public int tipoDocumentoId { get; set; }
        public String tipoAtencion { get; set; }
        public int tipoCambioId { get; set; }

        public String referenciaPagoTarjeta { get; set; }
        public decimal monto { get; set; }
        public int tipoPagoId { get; set; }
        public int monedaId { get; set; }

        public int productoId { get; set; }
        public int cantidadProducto { get; set; }

        //public String NumeroComprobante { get; set; }
        //public int NumeroSolicitud { get; set; }
        //public decimal MontoRecibido { get; set; }
        //public decimal Vuelto { get; set; }
        //public String referenciaPagoTarjeta { get; set; }
        //public int codigoTipoDocumento { get; set; }
        //public String ruc { get; set; }
        //public String razonSocial { get; set; }
        //public int codigoTipoPago { get; set; }
        //public int codigoTipoMoneda { get; set; }
        public String nombreSucursal { get; set; }
        public String telefono { get; set; }
        public String tipoPago { get; set; }
        public String moneda { get; set; }
        public String fechaRegistroPago { get; set; }
        public decimal totalVenta { get; set; }
        public String Cajero { get; set; }
        public String nombreProducto { get; set; }
        public decimal precioProducto { get; set; }
        public String unidadMedidaProducto { get; set; }
        public decimal subtotalProducto { get; set; }

        public List<TipoPago> listaTipoPago { get; set; }
    }
}

using Pe.ByS.ERP.Infraestructura.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pe.ByS.ERP.Infraestructura.QueryModel
{
    public class PagoLogic : Logic
    {
        public String NumeroComprobante { get; set; }
        public int NumeroSolicitud { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal Vuelto { get; set; }
        public String referenciaPagoTarjeta { get; set; }
        public int codigoTipoDocumento { get; set; }
        public String ruc { get; set; }
        public String razonSocial { get; set; }
        public int codigoTipoPago { get; set; }
        public int codigoTipoMoneda { get; set; }
        public String nombre { get; set; }
        public String telefono { get; set; }
        public String tipoPago { get; set; }
        public String moneda { get; set; }
        public String fechaRegistroPago { get; set; }
        public decimal totalVenta { get; set; }
        public String Cajero { get; set; }
        public String nombreSucursal { get; set; }
        public String nombreProducto { get; set; }
        public decimal precioProducto { get; set; }
        public int cantidadProducto { get; set; }
        public decimal subtotalProducto { get; set; }

    }
}

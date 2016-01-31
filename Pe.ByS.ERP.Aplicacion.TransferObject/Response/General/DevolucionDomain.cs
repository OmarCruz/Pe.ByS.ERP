using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Response.General
{
    public class DevolucionDomain
    {
        public int productoId { get; set; }
        public String descripcionProducto { get; set; }
        public String presentacionProducto { get; set; }
        public int cantidadProducto { get; set; }
        public decimal descuento { get; set; }
        public decimal precioProducto { get; set; }
        public decimal subtotal { get; set; }
        public int EstadoSolicitud { get; set; }
        public int documentoPagoId { get; set; }
        public String fechaCreacion { get; set; }
        public int tiempoTranscurrido { get; set; }
    }
}

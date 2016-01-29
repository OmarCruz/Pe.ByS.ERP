using Pe.ByS.ERP.Infraestructura.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Infraestructura.QueryModel
{
    public class SolicitudVentaLogic : Logic
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
    }
}

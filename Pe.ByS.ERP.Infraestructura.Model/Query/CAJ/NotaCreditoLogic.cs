using Pe.ByS.ERP.Infraestructura.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Infraestructura.QueryModel
{
    public class NotaCreditoLogic : Logic
    {
        public int productoId { get; set; }
        public String nombreProducto { get; set; }
        public int cantidadProducto { get; set; }
        public decimal precioProducto { get; set; }
        public decimal subtotal { get; set; }
        public int notaCreditoId { get; set; }
        public String numeroNotaCredito { get; set; }
        public String numeroComprobantePago { get; set; }
        public String fechaCreacion { get; set; }
        public String nombreEmpleado { get; set; }
        public String apellidoPaternoEmpleado { get; set; }
        public decimal montoTotal { get; set; }
        public String sucursalNombre { get; set; }
        public String sucursalTelefono { get; set; }
    }
}

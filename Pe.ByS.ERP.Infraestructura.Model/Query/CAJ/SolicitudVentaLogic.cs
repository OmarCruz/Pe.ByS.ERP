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

        public int NumeroSolicitud { get; set; }
        public String FechaSolicitud { get; set; }
        public int EstadoSolicitud { get; set; }
        //public double TotalVenta { get; set; }
        //public int CodigoSucursal { get; set; }
        //public int CodigoEmpleado { get; set; }
        public int codigoProducto { get; set; }
        public int cantidadProducto { get; set; }
        public String descripcionProducto { get; set; }
        public decimal precioProducto { get; set; }
        public decimal subtotal { get; set; }

    }
}

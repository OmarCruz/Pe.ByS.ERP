using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Response.General
{
    public class GrabarDevolucionDomain
    {
        public String numeroComprobantePago { get; set; }
        public int tipoDocumentoId { get; set; }
        public int empleadoId { get; set; }
        public int cajaId { get; set; }
        public int tipoAtencionId { get; set; }
        public int pendientePago { get; set; }
        public String observaciones { get; set; }
        public decimal montoTotal { get; set; }

        public List<ProductoDevolucion> ListaProductos { get; set; }
    }
}

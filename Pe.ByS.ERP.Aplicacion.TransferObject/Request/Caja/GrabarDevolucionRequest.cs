using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja
{
    public class GrabarDevolucionRequest
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

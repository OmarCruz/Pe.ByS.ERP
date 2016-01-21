using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja
{
    public class CierreRequest
    {
        public decimal efectivoSoles { get; set; }
        public decimal efectivoDolares { get; set; }
        public decimal tarjetaSoles { get; set; }
        public decimal tarjetaDolares { get; set; }
        public decimal devolucionSoles { get; set; }
        public decimal devolucionDolares { get; set; }
        public decimal montoDiferencia { get; set; }
        public int codigoEmpleado { get; set; }
        public int numeroCaja { get; set; }
    }
}

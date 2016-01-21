using Pe.ByS.ERP.Infraestructura.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pe.ByS.ERP.Infraestructura.QueryModel
{
    public class CierreCajaLogic : Logic
    {
        /*public int numeroFacturasEmitidas { get; set; }
        public int numeroFacturasAnuladas { get; set; }
        public int numeroBoletasEmitidas { get; set; }
        public int numeroBoletasAnuladas { get; set; }
        public int numeroVouchers { get; set; }
        public decimal montoNotasCredito { get; set; }*/

        public String codigoCierreCaja { get; set; }
        public String fechaCierre  { get; set; }
        public String nombreEmpleado { get; set; }
        public decimal efectivoDolares { get; set; }
        public decimal efectivoSoles { get; set; }
        public decimal tarjetaSoles { get; set; }
        public decimal tarjetaDolares { get; set; }
        public decimal devolucionSoles { get; set; }
        public decimal devolucionDolares { get; set; }
        public decimal efectivoSolesReal { get; set; }
        public decimal efectivoDolaresReal { get; set; }
        public decimal tarjetaSolesReal { get; set; }
        public decimal tarjetaDolaresReal { get; set; }
        public decimal devolucionSolesReal { get; set; }
        public decimal devolucionDolaresReal { get; set; }
        public decimal MontoReal { get; set; }
        public decimal MontoTotal { get; set; }

        public decimal montoDiferencia { get; set; }
        public int codigoEmpleado { get; set; }
        public int numeroCaja { get; set; }
    }
}

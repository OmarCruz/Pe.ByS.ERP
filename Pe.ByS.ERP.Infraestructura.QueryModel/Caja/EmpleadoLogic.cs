using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Infraestructura.QueryModel
{
    public class EmpleadoLogic : Logic
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int TipoEmpleado { get; set; }
    }
}

using Pe.ByS.ERP.Infraestructura.Core.Base;
using Pe.ByS.ERP.Infraestructura.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Infraestructura.Core.QueryContract
{
    public interface ISolicitudVentaLogicRepository :IQueryRepository<SolicitudVentaLogic>
    {
        SolicitudVentaLogic BuscarSolicitudVenta(int numeroSolicitud);
    }
}

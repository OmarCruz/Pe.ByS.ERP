using Pe.ByS.ERP.Infraestructura.Core.Base;
using Pe.ByS.ERP.Infraestructura.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Infraestructura.Core.QueryContract
{
    public interface IEmpleadoLogicRepository : IQueryRepository<EmpleadoLogic>
    {
        EmpleadoLogic FindById(int Id);

        List<SolicitudVentaLogic> BuscarSolicitudVenta(int numeroSolicitud);

        String GrabarPago(PagoLogic obj);

        String GrabarPagoDetalle(PagoLogic obj);

        List<PagoLogic> BuscarComprobante(int numeroSolicitud);


        List<SolicitudVentaLogic> BuscarDocumentoPago(String numeroDocumento);

        String GrabarNotaCredito(PagoLogic obj);

        String GrabarNotaCreditoDetalle(PagoLogic obj);



        CierreCajaLogic CierreCaja();

        String GrabarCierre(CierreCajaLogic obj);

        List<CierreCajaLogic> BuscarCierreCaja(String codigoCierreCaja);

    }

}


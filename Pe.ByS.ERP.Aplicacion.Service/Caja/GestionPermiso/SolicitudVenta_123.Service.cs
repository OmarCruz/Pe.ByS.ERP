using Pe.ByS.ERP.Aplicacion.Core.Base;
using Pe.ByS.ERP.Aplicacion.Core.ServiceContract.Caja.GestionPermiso;
using Pe.ByS.ERP.Aplicacion.Service.Base;
using Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja;
using Pe.ByS.ERP.Aplicacion.TransferObject.Response.General;
using Pe.ByS.ERP.Aplicacion.TransferObject.Response.Caja;
using Pe.ByS.ERP.Cross.Core.Exception;
using Pe.ByS.ERP.Infraestructura.Core.QueryContract;
using Pe.ByS.ERP.Infraestructura.QueryModel;
using System;
using System.Collections.Generic;

namespace Pe.ByS.ERP.Aplicacion.Service.Caja.GestionPermiso
{
    public class SolicitudVentaService : GenericService, ISolicitudVentaService
    {

        //public IEmpleadoLogicRepository EmpleadoLogicRepository { get; set; }


        //public ProcessResult<List<SolicitudPermisoResponse>> BuscarSolicitudesPermiso(SolicitudPermisoRequest filtro)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public ProcessResult<EmpleadoDomain> BuscarEmpleadoPorId(int Id)
        //{
        //    ProcessResult<EmpleadoDomain> result = new ProcessResult<EmpleadoDomain>();
        //    try
        //    {
        //        Id = 1;
        //        EmpleadoLogic empleado = EmpleadoLogicRepository.FindById(Id);
        //    }
        //    catch (Exception e)
        //    {
        //        result.IsSuccess = true;
        //        result.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
        //    }

        //    return result;
        //}


        //public ProcessResult<object> RegistraSolicitudPermiso(SolicitudPermisoRequest objRqst)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public ProcessResult<SolicitudPermisoResponse> ObtenerSolicitudPermisoPorId(System.Guid codigoBien)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public ProcessResult<object> EliminarSolicitudPermiso(List<int> listaCodigosBien)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}

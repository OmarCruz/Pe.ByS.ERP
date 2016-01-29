using System;
using System.Collections.Generic;
using Pe.ByS.ERP.Aplicacion.Core.Base;
using Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja;
using Pe.ByS.ERP.Aplicacion.TransferObject.Response.Caja;
using Pe.ByS.ERP.Aplicacion.TransferObject.Response.General;


namespace Pe.ByS.ERP.Aplicacion.Core.ServiceContract.Caja.GestionPermiso
{
    /// <summary>
    /// Servicio que representa los Contratos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150710 <br />
    /// Modificación: <br />
    /// </remarks>
    public interface ISolicitudPermisoService : IGenericService
    {
        /// <summary>
        /// Método que retorna la Lista de solicitudes
        /// </summary>
        /// <param name="filtro">objeto request del tipo Bien</param>
        /// <returns>Lista de Bienes</returns>
        ProcessResult<List<SolicitudPermisoResponse>> BuscarSolicitudesPermiso(SolicitudPermisoRequest filtro);

        /// <summary>
        /// Método que registra y/o Edita una solicitudes
        /// </summary>
        /// <param name="objRqst">objeto request del tipo Bien</param>
        /// <returns>Retorna entero, 1 transacción Ok.</returns>
        ProcessResult<Object> RegistraSolicitudPermiso(SolicitudPermisoRequest objRqst);

        /// <summary>
        /// Retorna información de la solicitud.
        /// </summary>
        /// <param name="codigoBien">código del bien</param>
        /// <returns>Información del bien</returns>
        ProcessResult<SolicitudPermisoResponse> ObtenerSolicitudPermisoPorId(Guid codigoBien);       

        /// <summary>
        /// Elimina uno o muchos Bien
        /// </summary>
        /// <param name="listaCodigosBien">Lista de Códigos de Bien a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> EliminarSolicitudPermiso(List<int> listaCodigosBien);

        ProcessResult<EmpleadoDomain> BuscarEmpleadoPorId(int Id);

        ProcessResult<List<SolicitudVentaDomain>> BuscarSolicitudVenta(int numeroSolicitud);

        ProcessResult<String> GrabarPago(PagoDomain obj);

        ProcessResult<String> GrabarPagoDetalle(PagoDomain obj);



        ProcessResult<List<SolicitudVentaDomain>> BuscarDocumentoPago(String numeroDocumento);

        ProcessResult<String> GrabarNotaCredito(PagoDomain obj);

        ProcessResult<String> GrabarNotaCreditoDetalle(PagoDomain obj);



        ProcessResult<CierreCajaDomain> CierreCaja();

        ProcessResult<String> GrabarCierre(CierreCajaDomain obj);

        ProcessResult<List<PagoDomain>> BuscarComprobante(int numeroSolicitud);

        ProcessResult<List<CierreCajaDomain>> BuscarCierreCaja(String codigoCierreCaja);

    }
}

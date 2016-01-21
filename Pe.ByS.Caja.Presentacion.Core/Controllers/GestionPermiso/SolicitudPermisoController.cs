
using Pe.ByS.ERP.Aplicacion.Core.ServiceContract.Caja.GestionPermiso;
using Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja;
using Pe.ByS.ERP.Aplicacion.TransferObject.Response.General;
using Pe.ByS.ERP.Presentation.Web.Src.Controllers.Base;
using Pe.ByS.Caja.Presentacion.Core.ViewModel.GestionPermiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.ByS.Caja.Presentacion.Core.Controllers.GestionPermiso
{
    public class SolicitudPermisoController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de Solicitudes de permisos
        /// </summary>
        public ISolicitudPermisoService solicitudVentaService { get; set; }

        #endregion
        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult RegistrarCierreCaja()
        {
            var modelo = new BuscarSolicitudPermisoViewModel(new List<CodigoValorResponse> { 
                new CodigoValorResponse {Codigo="1",Valor="En Proceso"},
                new CodigoValorResponse {Codigo="1",Valor="Terminado"}
            });
            return View(modelo);
        }

        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        [HttpGet]
        public ActionResult Buscar()
        {
            var modelo = new BuscarSolicitudPermisoViewModel(new List<CodigoValorResponse> { 
                new CodigoValorResponse {Codigo="1",Valor="En Proceso"},
                new CodigoValorResponse {Codigo="1",Valor="Terminado"}
            });
            return View(modelo);
        }
        #endregion

        #region Vistas Parciales
        #endregion

        #region Json
        
        [HttpPost]
        public virtual JsonResult Buscar(SolicitudVentaRequest request)
        {
            var solicitudes = solicitudVentaService.BuscarSolicitudVenta(request.NumeroSolicitud);
            return Json(solicitudes);
        }

        [HttpPost]
        public virtual JsonResult Grabar(PagoRequest request)
        {
            if (request.referenciaPagoTarjeta == null) request.referenciaPagoTarjeta = "";
            if (request.ruc == null) request.ruc = "";
            if (request.razonSocial == null) request.razonSocial = "";

            int numeroSolicitud = request.numeroSolicitud;
            decimal montoRecibido = request.montoRecibido;
            decimal vuelto = request.vuelto;
            String referenciaPagoTarjeta = request.referenciaPagoTarjeta;
            int codigoTipoDocumento = request.codigoTipoDocumento;
            String ruc = request.ruc;
            String razonSocial = request.razonSocial;
            int codigoTipoPago = request.codigoTipoPago;
            int codigoTipoMoneda = request.codigoTipoMoneda;

            PagoDomain svd = new PagoDomain();
            svd.NumeroSolicitud = numeroSolicitud;
            svd.MontoRecibido = montoRecibido;
            svd.Vuelto = vuelto;
            svd.referenciaPagoTarjeta = referenciaPagoTarjeta;
            svd.codigoTipoDocumento = codigoTipoDocumento;
            svd.ruc = ruc;
            svd.razonSocial = razonSocial;
            svd.codigoTipoPago = codigoTipoPago;
            svd.codigoTipoMoneda = codigoTipoMoneda;

            var solicitudes = solicitudVentaService.GrabarPago(svd);

            var comprobante = solicitudVentaService.BuscarComprobante(request.numeroSolicitud);

            return Json(comprobante);
        }

        [HttpPost]
        public virtual JsonResult Cierre()
        {
            var solicitudes = solicitudVentaService.CierreCaja();
            /*CierreCajaDomain cierre = new CierreCajaDomain();
            cierre.efectivoSoles = 100;
            cierre.efectivoDolares = 200;
            cierre.montoTarjetas = 300;
            cierre.montoDevoluciones = 10;
            solicitudes.Result = cierre;
            solicitudes.Exception = null;*/
            return Json(solicitudes);
        }

        [HttpPost]
        public virtual JsonResult GrabarCierre(CierreRequest request)
        {
            
            decimal efectivoSoles = request.efectivoSoles;
            decimal efectivoDolares = request.efectivoDolares;
            decimal tarjetaSoles = request.tarjetaSoles;
            decimal tarjetaDolares = request.tarjetaDolares;
            decimal devolucionSoles = request.devolucionSoles;
            decimal devolucionDolares = request.devolucionDolares;
            decimal montoDiferencia = request.montoDiferencia;
            int codigoEmpleado = request.codigoEmpleado;
            int numeroCaja = request.numeroCaja;

            /* decimal efectivoSoles = 100;
             decimal efectivoDolares = 50;
             decimal montoTarjetas = 30;
             decimal montoDevoluciones = 0;
             decimal montoDiferencia = 20;
             int codigoEmpleado = 1;
             int numeroCaja = 1;*/

            CierreCajaDomain cierre = new CierreCajaDomain();
            cierre.efectivoSoles = efectivoSoles;
            cierre.efectivoDolares = efectivoDolares;
            cierre.tarjetaSoles = tarjetaSoles;
            cierre.tarjetaDolares = tarjetaDolares;
            cierre.devolucionSoles = devolucionSoles;
            cierre.devolucionDolares = devolucionDolares;
            cierre.montoDiferencia = montoDiferencia;
            cierre.codigoEmpleado = codigoEmpleado;
            cierre.numeroCaja = numeroCaja;

            var numeroCierre = solicitudVentaService.GrabarCierre(cierre);

            var cierreCaja = solicitudVentaService.BuscarCierreCaja(numeroCierre.Result.ToString());

            // solicitudes.Exception = null; // --> Test only
            return Json(cierreCaja);

        }

        #endregion
    }
}

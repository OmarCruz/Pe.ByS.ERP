
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

        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        [HttpGet]
        public ActionResult RegistrarDevolucion()
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

            PagoDomain svd = new PagoDomain();
            svd.numeroSolicitudVenta = request.numeroSolicitudVenta;
            svd.tipoDocumentoId = request.tipoDocumentoId;
            svd.tipoCambioId = request.tipoCambioId;
            svd.tipoAtencion = request.tipoAtencion;
            svd.observaciones = request.observaciones;
            svd.montoTotal = request.montoTotal;
            svd.montoRecibido = request.montoRecibido;
            svd.Vuelto = request.Vuelto;
            svd.ruc = request.ruc;
            svd.razonSocial = request.razonSocial;

            var solicitudes = solicitudVentaService.GrabarPago(svd);

            var comprobante = solicitudVentaService.BuscarComprobante(request.numeroSolicitudVenta);

            return Json(comprobante);
        }

        [HttpPost]
        public virtual JsonResult GrabarPagoDetalle(PagoRequest request)
        {
            if (request.referenciaPagoTarjeta == null) request.referenciaPagoTarjeta = "";
            PagoDomain svd = new PagoDomain();
            svd.documentoId = request.documentoId;
            svd.tipoPagoId = request.tipoPagoId;
            svd.monedaId = request.monedaId;
            svd.monto = request.monto;
            svd.referenciaPagoTarjeta = request.referenciaPagoTarjeta;
           
            var solicitudes = solicitudVentaService.GrabarPagoDetalle(svd);

            return Json(solicitudes);
        }



        [HttpPost]
        public virtual JsonResult BuscarDocumento(SolicitudVentaRequest request)
        {
            var solicitudes = solicitudVentaService.BuscarDocumentoPago(request.NumeroDocumento);
            return Json(solicitudes);
        }

        [HttpPost]
        public virtual JsonResult GrabarNotaCredito(PagoRequest request)
        {
            if (request.referenciaPagoTarjeta == null) request.referenciaPagoTarjeta = "";
            if (request.ruc == null) request.ruc = "";
            if (request.razonSocial == null) request.razonSocial = "";

            PagoDomain svd = new PagoDomain();
            // svd.numeroSolicitudVenta = request.numeroSolicitudVenta;
            svd.tipoDocumentoId = request.tipoDocumentoId; // Se autogenera en el SP
            svd.tipoCambioId = request.tipoCambioId;
            svd.tipoAtencion = request.tipoAtencion;
            svd.observaciones = request.observaciones;
            svd.montoTotal = request.montoTotal;
            // svd.Vuelto = request.Vuelto; // No se usa
            svd.ruc = request.ruc;
            svd.razonSocial = request.razonSocial;
            svd.documentoPagoId = request.documentoPagoId;

            var solicitudes = solicitudVentaService.GrabarNotaCredito(svd);

            return Json(solicitudes);
        }

        [HttpPost]
        public virtual JsonResult GrabarNotaCreditoDetalle(PagoRequest request)
        {

            PagoDomain svd = new PagoDomain();
            svd.documentoId = request.documentoId;
            svd.productoId = request.productoId;
            svd.cantidadProducto = request.cantidadProducto;
            
            var solicitudes = solicitudVentaService.GrabarNotaCreditoDetalle(svd);

            return Json(solicitudes);
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

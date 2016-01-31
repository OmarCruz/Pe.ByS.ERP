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
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Pe.ByS.ERP.Aplicacion.Service.Caja.GestionPermiso
{
    public class SolicitudPermisoService : GenericService, ISolicitudPermisoService
    {

        public IEmpleadoLogicRepository EmpleadoLogicRepository { get; set; }

        public ProcessResult<List<SolicitudPermisoResponse>> BuscarSolicitudesPermiso(SolicitudPermisoRequest filtro)
        {
            throw new System.NotImplementedException();
        }

        public ProcessResult<EmpleadoDomain> BuscarEmpleadoPorId(int Id)
        {
            ProcessResult<EmpleadoDomain> result = new ProcessResult<EmpleadoDomain>();
            try
            {
                Id = 1;
                EmpleadoLogic empleado = EmpleadoLogicRepository.FindById(Id);

                /*EmpleadoDomain empleado = new EmpleadoDomain();
                empleado.Id = 1;
                empleado.Nombre = "Cesar Kina";
                empleado.TipoEmpleado = 2;

                result.Result = empleado;*/
            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }

            return result;
        }

        public ProcessResult<object> RegistraSolicitudPermiso(SolicitudPermisoRequest objRqst)
        {
            throw new System.NotImplementedException();
        }

        public ProcessResult<SolicitudPermisoResponse> ObtenerSolicitudPermisoPorId(System.Guid codigoBien)
        {
            throw new System.NotImplementedException();
        }

        public ProcessResult<object> EliminarSolicitudPermiso(List<int> listaCodigosBien)
        {
            throw new System.NotImplementedException();
        }


        public ProcessResult<List<SolicitudVentaDomain>> BuscarSolicitudVenta(int numerosolicitud)
        {
            ProcessResult<List<SolicitudVentaDomain>> list = new ProcessResult<List<SolicitudVentaDomain>>();
            List<SolicitudVentaDomain> listResult = new List<SolicitudVentaDomain>();
            try
            {
                List<SolicitudVentaLogic> solicitudVenta = EmpleadoLogicRepository.BuscarSolicitudVenta(numerosolicitud);

                foreach (var item in solicitudVenta)
                {
                    SolicitudVentaDomain svd = new SolicitudVentaDomain();

                    svd.productoId = item.productoId;
                    svd.descripcionProducto = item.descripcionProducto;
                    svd.presentacionProducto = item.presentacionProducto;
                    svd.cantidadProducto = item.cantidadProducto;
                    svd.descuento = item.descuento;
                    svd.precioProducto = item.precioProducto;
                    svd.subtotal = item.subtotal;

                    listResult.Add(svd);
                }

                list.Result = listResult;

            }
            catch (Exception e)
            {
                list.IsSuccess = true;
                list.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }
            return list;
        }

        public ProcessResult<String> GrabarPago(PagoDomain obj)
        {
            ProcessResult<String> result = new ProcessResult<String>();

            var documentoId = "";

            try
            {
                PagoLogic svd = new PagoLogic();

                svd.numeroSolicitudVenta = obj.numeroSolicitudVenta;
                svd.tipoDocumentoId = obj.tipoDocumentoId;
                svd.tipoCambioId = obj.tipoCambioId;
                svd.tipoAtencion = obj.tipoAtencion;
                svd.observaciones = obj.observaciones;
                svd.montoTotal = obj.montoTotal;
                svd.montoRecibido = obj.montoRecibido;
                svd.Vuelto = obj.Vuelto;   
                svd.ruc = obj.ruc;
                svd.razonSocial = obj.razonSocial;

                documentoId = EmpleadoLogicRepository.GrabarPago(svd);

            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }

            return result;
        }

        public ProcessResult<String> GrabarPagoDetalle(PagoDomain obj)
        {
            ProcessResult<String> result = new ProcessResult<String>();

            var documentoId = "";

            try
            {
                PagoLogic svd = new PagoLogic();

                svd.documentoId = obj.documentoId;
                svd.tipoPagoId = obj.tipoPagoId;
                svd.monedaId = obj.monedaId;
                svd.monto = obj.monto;
                svd.referenciaPagoTarjeta = obj.referenciaPagoTarjeta;
        
                documentoId = EmpleadoLogicRepository.GrabarPagoDetalle(svd);

            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }

            return result;
        }

        public ProcessResult<List<PagoDomain>> BuscarComprobante(int numerosolicitud)
        {
            ProcessResult<List<PagoDomain>> list = new ProcessResult<List<PagoDomain>>();
            List<PagoDomain> listResult = new List<PagoDomain>();
            try
            {
                List<PagoLogic> documento = EmpleadoLogicRepository.BuscarComprobante(numerosolicitud);

                foreach (var item in documento)
                {
                    PagoDomain svd = new PagoDomain();

                    svd.numeroDocumento = item.numeroDocumento;
                    svd.razonSocial = item.razonSocial;
                    svd.ruc = item.ruc;
                    svd.telefono = item.telefono;
                    svd.fechaRegistroPago = item.fechaRegistroPago;
                    svd.tipoPago = item.tipoPago;
                    svd.totalVenta = item.totalVenta;
                    svd.moneda = item.moneda;
                    svd.Vuelto = item.Vuelto;
                    svd.monto = item.monto;
                    svd.Cajero = item.Cajero;
                    svd.nombreSucursal = item.nombreSucursal;
                    svd.nombreProducto = item.nombreProducto;
                    svd.unidadMedidaProducto = item.unidadMedidaProducto;
                    svd.precioProducto = item.precioProducto;
                    svd.cantidadProducto = item.cantidadProducto;
                    svd.subtotalProducto = item.subtotalProducto;
                    svd.montoRecibido = item.montoRecibido;
                    svd.documentoId = item.documentoId;

                    listResult.Add(svd);
                }

                list.Result = listResult;

            }
            catch (Exception e)
            {
                list.IsSuccess = true;
                list.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }
            return list;
        }




        public ProcessResult<List<DevolucionDomain>> BuscarDocumentoPago(String numeroDocumento)
        {
            ProcessResult<List<DevolucionDomain>> list = new ProcessResult<List<DevolucionDomain>>();
            List<DevolucionDomain> listResult = new List<DevolucionDomain>();
            try
            {
                List<DevolucionLogic> solicitudVenta = EmpleadoLogicRepository.BuscarDocumentoPago(numeroDocumento);

                foreach (var item in solicitudVenta)
                {
                    DevolucionDomain svd = new DevolucionDomain();

                    svd.productoId = item.productoId;
                    svd.descripcionProducto = item.descripcionProducto;
                    svd.presentacionProducto = item.presentacionProducto;
                    svd.cantidadProducto = item.cantidadProducto;
                    svd.precioProducto = item.precioProducto;
                    svd.subtotal = item.subtotal;
                    svd.descuento = item.descuento;
                    svd.EstadoSolicitud = item.EstadoSolicitud;
                    svd.documentoPagoId = item.documentoPagoId;
                    svd.fechaCreacion = item.fechaCreacion;
                    svd.tiempoTranscurrido = item.tiempoTranscurrido;

                    listResult.Add(svd);
                }

                list.Result = listResult;

            }
            catch (Exception e)
            {
                list.IsSuccess = true;
                list.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }
            return list;
        }

        public ProcessResult<String> GrabarNotaCredito(GrabarDevolucionDomain obj)
        {
            ProcessResult<String> result = new ProcessResult<String>();

            var documentoId = "";

            try
            {
                GrabarDevolucionLogic objLogic = new GrabarDevolucionLogic();

                objLogic.numeroComprobantePago = obj.numeroComprobantePago;
                objLogic.tipoDocumentoId = obj.tipoDocumentoId;
                objLogic.empleadoId = obj.empleadoId;
                objLogic.cajaId = obj.cajaId;
                objLogic.tipoAtencionId = obj.tipoAtencionId;
                objLogic.pendientePago = obj.pendientePago;
                objLogic.observaciones = obj.observaciones;
                objLogic.montoTotal = obj.montoTotal;
                objLogic.ListaProductos = obj.ListaProductos;

                documentoId = EmpleadoLogicRepository.GrabarNotaCredito(objLogic);

            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }

            return result;
        }

        public ProcessResult<List<NotaCreditoDomain>> BuscarNotaCredito(String numeroComprobantePago)
        {
            ProcessResult<List<NotaCreditoDomain>> list = new ProcessResult<List<NotaCreditoDomain>>();
            List<NotaCreditoDomain> listResult = new List<NotaCreditoDomain>();
            try
            {
                List<NotaCreditoLogic> solicitudVenta = EmpleadoLogicRepository.BuscarNotaCredito(numeroComprobantePago);

                foreach (var item in solicitudVenta)
                {
                    NotaCreditoDomain svd = new NotaCreditoDomain();

                    svd.productoId = item.productoId;
                    svd.nombreProducto = item.nombreProducto;
                    svd.cantidadProducto = item.cantidadProducto;
                    svd.precioProducto = item.precioProducto;
                    svd.subtotal = item.subtotal;
                    svd.notaCreditoId = item.notaCreditoId;
                    svd.numeroNotaCredito = item.numeroNotaCredito;
                    svd.numeroComprobantePago = item.numeroComprobantePago;
                    svd.fechaCreacion = item.fechaCreacion;
                    svd.nombreEmpleado = item.nombreEmpleado;
                    svd.apellidoPaternoEmpleado = item.apellidoPaternoEmpleado;
                    svd.montoTotal = item.montoTotal;
                    svd.sucursalNombre = item.sucursalNombre;
                    svd.sucursalTelefono = item.sucursalTelefono;

                    listResult.Add(svd);
                }

                list.Result = listResult;

            }
            catch (Exception e)
            {
                list.IsSuccess = true;
                list.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }
            return list;
        }

        public ProcessResult<String> GrabarNotaCreditoDetalle(PagoDomain obj)
        {
            ProcessResult<String> result = new ProcessResult<String>();

            var documentoId = "";

            try
            {
                PagoLogic svd = new PagoLogic();

                svd.documentoId = obj.documentoId;
                svd.productoId = obj.productoId;
                svd.cantidadProducto = obj.cantidadProducto;
                svd.monto = obj.monto;
                svd.referenciaPagoTarjeta = obj.referenciaPagoTarjeta;

                documentoId = EmpleadoLogicRepository.GrabarNotaCreditoDetalle(svd);
                result.Result = documentoId;
            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }

            return result;
        }


        public ProcessResult<CierreCajaDomain> CierreCaja()
        {
            ProcessResult<CierreCajaDomain> list = new ProcessResult<CierreCajaDomain>();
            //CierreCajaDomain listResult = new CierreCajaDomain();
            try
            {
                CierreCajaLogic cierreCaja = EmpleadoLogicRepository.CierreCaja();
                CierreCajaDomain svd = new CierreCajaDomain();

                /*svd.numeroFacturasEmitidas = cierreCaja.numeroFacturasEmitidas;
                svd.numeroFacturasAnuladas = cierreCaja.numeroFacturasAnuladas;
                svd.numeroBoletasEmitidas = cierreCaja.numeroBoletasEmitidas;
                svd.numeroBoletasAnuladas = cierreCaja.numeroBoletasAnuladas;
                svd.numeroVouchers = cierreCaja.numeroVouchers;
                svd.montoNotasCredito = cierreCaja.montoNotasCredito;*/
                svd.efectivoDolares = cierreCaja.efectivoDolares;
                svd.efectivoSoles = cierreCaja.efectivoSoles;
                svd.tarjetaSoles = cierreCaja.tarjetaSoles;
                svd.tarjetaDolares = cierreCaja.tarjetaDolares;
                svd.devolucionSoles = cierreCaja.devolucionSoles;
                svd.devolucionDolares = cierreCaja.devolucionDolares;

                list.Result = svd;

            }
            catch (Exception e)
            {
                list.IsSuccess = true;
                list.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }
            return list;
        }

        public ProcessResult<String> GrabarCierre(CierreCajaDomain obj)
        {
            ProcessResult<String> result = new ProcessResult<String>();

            var numeroCierre = "";

            try
            {

                CierreCajaLogic cierre = new CierreCajaLogic();

                cierre.efectivoSoles = obj.efectivoSoles;
                cierre.efectivoDolares = obj.efectivoDolares;
                cierre.tarjetaSoles = obj.tarjetaSoles;
                cierre.tarjetaDolares = obj.tarjetaDolares;
                cierre.devolucionSoles = obj.devolucionSoles;
                cierre.devolucionDolares = obj.devolucionDolares;
                cierre.montoDiferencia = obj.montoDiferencia;
                cierre.codigoEmpleado = obj.codigoEmpleado;
                cierre.numeroCaja = obj.numeroCaja;

                numeroCierre = EmpleadoLogicRepository.GrabarCierre(cierre);
                result.Result = numeroCierre;
            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }

            return result;
        }

        public ProcessResult<List<CierreCajaDomain>> BuscarCierreCaja(String codigoCierreCaja)
        {
            ProcessResult<List<CierreCajaDomain>> list = new ProcessResult<List<CierreCajaDomain>>();
            List<CierreCajaDomain> listResult = new List<CierreCajaDomain>();
            try
            {
                List<CierreCajaLogic> solicitudVenta = EmpleadoLogicRepository.BuscarCierreCaja(codigoCierreCaja);

                foreach (var item in solicitudVenta)
                {
                    CierreCajaDomain svd = new CierreCajaDomain();

                    svd.codigoCierreCaja = item.codigoCierreCaja;
                    svd.fechaCierre = item.fechaCierre;
                    svd.nombreEmpleado = item.nombreEmpleado;
                    svd.efectivoSoles = item.efectivoSoles;
                    svd.efectivoDolares = item.efectivoDolares;
                    svd.tarjetaSoles = item.tarjetaSoles;
                    svd.tarjetaDolares = item.tarjetaDolares;
                    svd.devolucionSoles = item.devolucionSoles;
                    svd.devolucionDolares = item.devolucionDolares;
                    svd.efectivoSolesReal = item.efectivoSolesReal;
                    svd.efectivoDolaresReal = item.efectivoDolaresReal;
                    svd.tarjetaSolesReal = item.tarjetaSolesReal;
                    svd.tarjetaDolaresReal = item.tarjetaDolaresReal;
                    svd.devolucionSolesReal = item.devolucionSolesReal;
                    svd.devolucionDolaresReal = item.devolucionDolaresReal;
                    svd.MontoReal = item.MontoReal;
                    svd.MontoTotal = item.MontoTotal;
                    svd.montoDiferencia = item.montoDiferencia;

                    listResult.Add(svd);
                }

                list.Result = listResult;

            }
            catch (Exception e)
            {
                list.IsSuccess = true;
                list.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
            }
            return list;
        }

    }
}

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

                    svd.cantidadProducto = item.cantidadProducto;
                    svd.codigoProducto = item.codigoProducto;
                    svd.descripcionProducto = item.descripcionProducto;
                    svd.EstadoSolicitud = item.EstadoSolicitud;
                    svd.FechaSolicitud = item.FechaSolicitud;
                    svd.NumeroSolicitud = item.NumeroSolicitud;
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


        //public ProcessResult<String> GrabarPago(int numeroSolicitud, decimal montoRecibido, String referenciaPagoTarjeta, int codigoTipoDocumento,
        //    String ruc, String razonSocial, int codigoTipoPago, int codigoTipoMoneda)
        //{
        //    ProcessResult<String> result = new ProcessResult<String>();

        //    var numeroComprobante = "";

        //    try
        //    {
        //        PagoLogic svd = new PagoLogic();

        //        svd.NumeroSolicitud = numeroSolicitud;
        //        svd.MontoRecibido = montoRecibido;
        //        svd.referenciaPagoTarjeta = referenciaPagoTarjeta;
        //        svd.codigoTipoDocumento = codigoTipoDocumento;
        //        svd.ruc = ruc;
        //        svd.razonSocial = razonSocial;
        //        svd.codigoTipoPago = codigoTipoPago;
        //        svd.codigoTipoMoneda = codigoTipoMoneda;

        //        numeroComprobante = EmpleadoLogicRepository.GrabarPago(svd);

        //    }
        //    catch (Exception e)
        //    {
        //        //list.IsSuccess = true;
        //        //list.Exception = new ApplicationLayerException<SolicitudPermisoService>("Ocurrio un problema en el sistema", e);
        //    }

        //    return result;
        //}


        public ProcessResult<String> GrabarPago(PagoDomain obj)
        {
            ProcessResult<String> result = new ProcessResult<String>();

            var numeroComprobante = "";

            try
            {
                PagoLogic svd = new PagoLogic();

                svd.NumeroSolicitud = obj.NumeroSolicitud;
                svd.MontoRecibido = obj.MontoRecibido;
                svd.Vuelto = obj.Vuelto;
                svd.referenciaPagoTarjeta = obj.referenciaPagoTarjeta;
                svd.codigoTipoDocumento = obj.codigoTipoDocumento;
                svd.ruc = obj.ruc;
                svd.razonSocial = obj.razonSocial;
                svd.codigoTipoPago = obj.codigoTipoPago;
                svd.codigoTipoMoneda = obj.codigoTipoMoneda;

                numeroComprobante = EmpleadoLogicRepository.GrabarPago(svd);

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
                List<PagoLogic> solicitudVenta = EmpleadoLogicRepository.BuscarComprobante(numerosolicitud);

                foreach (var item in solicitudVenta)
                {
                    PagoDomain svd = new PagoDomain();

                    svd.NumeroComprobante = item.NumeroComprobante;
                    svd.razonSocial = item.razonSocial;
                    svd.ruc = item.ruc;
                    svd.telefono = item.telefono;
                    svd.fechaRegistroPago = item.fechaRegistroPago;
                    svd.tipoPago = item.tipoPago;
                    svd.totalVenta = item.totalVenta;
                    svd.moneda = item.moneda;
                    svd.Vuelto = item.Vuelto;
                    svd.MontoRecibido = item.MontoRecibido;
                    svd.Cajero = item.Cajero;
                    svd.nombreSucursal = item.nombreSucursal;
                    svd.nombreProducto = item.nombreProducto;
                    svd.precioProducto = item.precioProducto;
                    svd.cantidadProducto = item.cantidadProducto;
                    svd.subtotalProducto = item.subtotalProducto;

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

using Pe.ByS.ERP.Infraestructura.Core.QueryContract;
using Pe.ByS.ERP.Infraestructura.QueryModel;
using Pe.ByS.ERP.Infraestructura.Repository.Base;
using Pe.ByS.ERP.Aplicacion.TransferObject.Response.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja;

namespace Pe.ByS.ERP.Infraestructura.Repository.Query.Caja
{
    public class EmpleadoLogicRepository : QueryRepository<EmpleadoLogic>, IEmpleadoLogicRepository
    {
        public EmpleadoLogic FindById(int Id)
        {
            SqlParameter userNameParameter = new SqlParameter("Id", Id);
            var result = this.dataBaseProvider.ExecuteStoreProcedure<EmpleadoLogic>("dbo.GetEmpleadoById", userNameParameter).SingleOrDefault();

            return result;
        }

        public List<SolicitudVentaLogic> BuscarSolicitudVenta(int nroSolicitud)
        {
            List<SolicitudVentaLogic> list = new List<SolicitudVentaLogic>();

            SqlParameter userNameParameter = new SqlParameter("numeroSolicitud", nroSolicitud);

            var solicitudVenta = this.dataBaseProvider.ExecuteStoreProcedure<SolicitudVentaLogic>("dbo.DatosSolicitudVenta", userNameParameter).ToList();

            foreach (var item in solicitudVenta)
            {
                SolicitudVentaLogic obj = new SolicitudVentaLogic();
                obj.productoId = item.productoId;
                obj.descripcionProducto = item.descripcionProducto;
                obj.presentacionProducto = item.presentacionProducto;
                obj.cantidadProducto = item.cantidadProducto;
                obj.descuento = item.descuento;
                obj.precioProducto = item.precioProducto;
                obj.subtotal = item.subtotal;
                obj.EstadoSolicitud = item.EstadoSolicitud;

                list.Add(obj);
            }
            return list;
        }

        public String GrabarPago(PagoLogic obj)
        {
            SqlParameter[] parametro = new SqlParameter[8];

            parametro[0] = new SqlParameter(); parametro[0].ParameterName = "numeroSolicitudVenta"; parametro[0].Value = obj.numeroSolicitudVenta;
            parametro[1] = new SqlParameter(); parametro[1].ParameterName = "tipoDocumentoId"; parametro[1].Value = obj.tipoDocumentoId;
            parametro[2] = new SqlParameter(); parametro[2].ParameterName = "tipoCambioId"; parametro[2].Value = obj.tipoCambioId;
            parametro[3] = new SqlParameter(); parametro[3].ParameterName = "observaciones"; parametro[3].Value = obj.observaciones;
            parametro[4] = new SqlParameter(); parametro[4].ParameterName = "montoTotal"; parametro[4].Value = obj.montoTotal;
            parametro[5] = new SqlParameter(); parametro[5].ParameterName = "vuelto"; parametro[5].Value = obj.Vuelto;
            parametro[6] = new SqlParameter(); parametro[6].ParameterName = "ruc"; parametro[6].Value = obj.ruc;
            parametro[7] = new SqlParameter(); parametro[7].ParameterName = "razonSocial"; parametro[7].Value = obj.razonSocial;

            var documentoId = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("dbo.GrabarDocumento", parametro).ToString();

            return documentoId;
        }

        public String GrabarPagoDetalle(PagoLogic obj)
        {
            SqlParameter[] parametro = new SqlParameter[5];
            
            parametro[0] = new SqlParameter(); parametro[0].ParameterName = "documentoId"; parametro[0].Value = obj.documentoId;
            parametro[1] = new SqlParameter(); parametro[1].ParameterName = "tipoPagoId"; parametro[1].Value = obj.tipoPagoId;
            parametro[2] = new SqlParameter(); parametro[2].ParameterName = "monedaId"; parametro[2].Value = obj.monedaId;
            parametro[3] = new SqlParameter(); parametro[3].ParameterName = "monto"; parametro[3].Value = obj.monto;
            parametro[4] = new SqlParameter(); parametro[4].ParameterName = "referencia"; parametro[4].Value = obj.referenciaPagoTarjeta;

            var documentoId = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("dbo.GrabarDocumentoTipoPago", parametro).ToString();

            return documentoId;
        }

        public List<PagoLogic> BuscarComprobante(int nroSolicitud)
        {
            List<PagoLogic> list = new List<PagoLogic>();

            SqlParameter userNameParameter = new SqlParameter("numeroSolicitud", nroSolicitud);

            var solicitudVenta = this.dataBaseProvider.ExecuteStoreProcedure<PagoLogic>("dbo.ImprimeComprobantePago", userNameParameter).ToList();

            foreach (var item in solicitudVenta)
            {
                PagoLogic obj = new PagoLogic();

                obj.numeroDocumento = item.numeroDocumento;
                obj.razonSocial = item.razonSocial;
                obj.ruc = item.ruc;
                obj.telefono = item.telefono;
                obj.fechaRegistroPago = item.fechaRegistroPago;
                obj.tipoPago = item.tipoPago;
                obj.totalVenta = item.totalVenta;
                obj.moneda = item.moneda;
                obj.Vuelto = item.Vuelto;
                obj.monto = item.monto;
                obj.Cajero = item.Cajero;
                obj.nombreSucursal = item.nombreSucursal;
                obj.nombreProducto = item.nombreProducto;
                obj.UMProducto = item.UMProducto;
                obj.precioProducto = item.precioProducto;
                obj.cantidadProducto = item.cantidadProducto;
                obj.subtotalProducto = item.subtotalProducto;
                obj.montoRecibido = item.montoRecibido;
                obj.documentoId = item.documentoId;
                list.Add(obj);
            }
            return list;
        }

        public List<NotaCreditoLogic> BuscarNotaCredito(String numeroComprobantePago)
        {
            List<NotaCreditoLogic> list = new List<NotaCreditoLogic>();

            SqlParameter input = new SqlParameter("numeroComprobantePago", numeroComprobantePago);

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<NotaCreditoLogic>("dbo.ImprimeNotaCredito", input).ToList();

            foreach (var item in resultado)
            {
                NotaCreditoLogic obj = new NotaCreditoLogic();

                obj.productoId = item.productoId;
                obj.nombreProducto = item.nombreProducto;
                obj.cantidadProducto = item.cantidadProducto;
                obj.precioProducto = item.precioProducto;
                obj.subtotal = item.subtotal;
                obj.notaCreditoId = item.notaCreditoId;
                obj.numeroNotaCredito = item.numeroNotaCredito;
                obj.numeroComprobantePago = item.numeroComprobantePago;
                obj.fechaCreacion = item.fechaCreacion;
                obj.nombreEmpleado = item.nombreEmpleado;
                obj.apellidoPaternoEmpleado = item.apellidoPaternoEmpleado;
                obj.montoTotal = item.montoTotal;
                obj.sucursalNombre = item.sucursalNombre;
                obj.sucursalTelefono = item.sucursalTelefono;

                list.Add(obj);
            }
            return list;
        }

        public List<DevolucionLogic> BuscarDocumentoPago(string numeroDocumento)
        {
            List<DevolucionLogic> list = new List<DevolucionLogic>();

            SqlParameter userNameParameter = new SqlParameter("numeroDocumento", numeroDocumento);

            var solicitudVenta = this.dataBaseProvider.ExecuteStoreProcedure<DevolucionLogic>("dbo.DatosDocumento", userNameParameter).ToList();

            foreach (var item in solicitudVenta)
            {
                DevolucionLogic obj = new DevolucionLogic();
                obj.productoId = item.productoId;
                obj.descripcionProducto = item.descripcionProducto;
                obj.presentacionProducto = item.presentacionProducto;
                obj.cantidadProducto = item.cantidadProducto;
                obj.precioProducto = item.precioProducto;
                obj.subtotal = item.subtotal;
                obj.descuento = item.descuento;
                obj.EstadoSolicitud = item.EstadoSolicitud;
                obj.documentoPagoId = item.documentoPagoId;
                obj.fechaCreacion = item.fechaCreacion;
                obj.tiempoTranscurrido = item.tiempoTranscurrido;

                list.Add(obj);
            }
            return list;
        }

        public String GrabarNotaCredito(GrabarDevolucionLogic obj)
        {
            SqlParameter[] parametro = new SqlParameter[8];

            parametro[0] = new SqlParameter(); parametro[0].ParameterName = "numeroComprobantePago"; parametro[0].Value = obj.numeroComprobantePago;
            parametro[1] = new SqlParameter(); parametro[1].ParameterName = "tipoDocumentoId"; parametro[1].Value = obj.tipoDocumentoId;
            parametro[2] = new SqlParameter(); parametro[2].ParameterName = "empleadoId"; parametro[2].Value = obj.empleadoId;
            parametro[3] = new SqlParameter(); parametro[3].ParameterName = "cajaId"; parametro[3].Value = obj.cajaId;
            parametro[4] = new SqlParameter(); parametro[4].ParameterName = "tipoAtencionId"; parametro[4].Value = obj.tipoAtencionId;
            parametro[5] = new SqlParameter(); parametro[5].ParameterName = "pendientePago"; parametro[5].Value = obj.pendientePago;
            parametro[6] = new SqlParameter(); parametro[6].ParameterName = "observaciones"; parametro[6].Value = obj.observaciones;
            parametro[7] = new SqlParameter(); parametro[7].ParameterName = "montoTotal"; parametro[7].Value = obj.montoTotal;

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("dbo.GrabarNotaCredito", parametro).ToString();

            foreach (ProductoDevolucion producto in obj.ListaProductos)
            {
                if (producto.cantidadDevolucionValue > 0) {
                    SqlParameter[] parametroProducto = new SqlParameter[3];
                    parametroProducto[0] = new SqlParameter(); parametroProducto[0].ParameterName = "numeroComprobantePago"; parametroProducto[0].Value = obj.numeroComprobantePago;
                    parametroProducto[1] = new SqlParameter(); parametroProducto[1].ParameterName = "productoId"; parametroProducto[1].Value = producto.productoId;
                    parametroProducto[2] = new SqlParameter(); parametroProducto[2].ParameterName = "cantidad"; parametroProducto[2].Value = producto.cantidadDevolucionValue;

                    this.dataBaseProvider.ExecuteStoreProcedureNonQuery("dbo.GrabarNotaCreditoDetalle", parametroProducto).ToString();
                }
            }

            return result;
        }

        public String GrabarNotaCreditoDetalle(PagoLogic obj)
        {
            SqlParameter[] parametro = new SqlParameter[3];

            parametro[0] = new SqlParameter(); parametro[0].ParameterName = "documentoId"; parametro[0].Value = obj.documentoId;
            parametro[1] = new SqlParameter(); parametro[1].ParameterName = "productoId"; parametro[1].Value = obj.productoId;
            parametro[2] = new SqlParameter(); parametro[2].ParameterName = "cantidad"; parametro[2].Value = obj.cantidadProducto;

            var documentoId = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("dbo.GrabarNotaCreditoDetalle", parametro).ToString();

            return documentoId;
        }


        public CierreCajaLogic CierreCaja()
        {
            CierreCajaLogic list = new CierreCajaLogic();

            //SqlParameter userNameParameter = new SqlParameter("numeroSolicitud", nroSolicitud);

            var cierre = this.dataBaseProvider.ExecuteStoreProcedure<CierreCajaLogic>("dbo.DatosCierreCaja").ToList();

            foreach (var item in cierre)
            {
                /*list.numeroFacturasEmitidas = item.numeroFacturasEmitidas;
                list.numeroFacturasAnuladas = item.numeroFacturasAnuladas;
                list.numeroBoletasEmitidas = item.numeroBoletasEmitidas;
                list.numeroBoletasAnuladas = item.numeroBoletasAnuladas;
                list.numeroVouchers = item.numeroVouchers;
                list.montoNotasCredito = item.montoNotasCredito;*/
                list.efectivoDolares = item.efectivoDolares;
                list.efectivoSoles = item.efectivoSoles;
                list.tarjetaSoles = item.tarjetaSoles;
                list.tarjetaDolares = item.tarjetaDolares;
                list.devolucionSoles = item.devolucionSoles;
                list.devolucionDolares = item.devolucionDolares;

            }
            return list;
        }

        public String GrabarCierre(CierreCajaLogic obj)
        {
            SqlParameter[] parametro = new SqlParameter[9];
            
            parametro[0] = new SqlParameter(); parametro[0].ParameterName = "efectivoSoles"; parametro[0].Value = obj.efectivoSoles;
            parametro[1] = new SqlParameter(); parametro[1].ParameterName = "efectivoDolares"; parametro[1].Value = obj.efectivoDolares;
            parametro[2] = new SqlParameter(); parametro[2].ParameterName = "tarjetaSoles"; parametro[2].Value = obj.tarjetaSoles;
            parametro[3] = new SqlParameter(); parametro[3].ParameterName = "tarjetaDolares"; parametro[3].Value = obj.tarjetaDolares;
            parametro[4] = new SqlParameter(); parametro[4].ParameterName = "devolucionSoles"; parametro[4].Value = obj.devolucionSoles;
            parametro[5] = new SqlParameter(); parametro[5].ParameterName = "devolucionDolares"; parametro[5].Value = obj.devolucionDolares;
            parametro[6] = new SqlParameter(); parametro[6].ParameterName = "montoDiferencia"; parametro[6].Value = obj.montoDiferencia;
            parametro[7] = new SqlParameter(); parametro[7].ParameterName = "codigoEmpleado"; parametro[7].Value = obj.codigoEmpleado;
            parametro[8] = new SqlParameter(); parametro[8].ParameterName = "numeroCaja"; parametro[8].Value = obj.numeroCaja;


            //var cierre = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("dbo.RegistrarCierreCaja", parametro).ToString();
            var cierre = this.dataBaseProvider.ExecuteStoreProcedure<CierreCajaLogic>("dbo.RegistrarCierreCaja", parametro).SingleOrDefault();

            return cierre.codigoCierreCaja;
        }

        public List<CierreCajaLogic> BuscarCierreCaja(String codigoCierreCaja)
        {
            List<CierreCajaLogic> list = new List<CierreCajaLogic>();

            SqlParameter userNameParameter = new SqlParameter("codigoCierreCaja", codigoCierreCaja);

            var solicitudVenta = this.dataBaseProvider.ExecuteStoreProcedure<CierreCajaLogic>("dbo.ImprimeCierreCaja", userNameParameter).ToList();

            foreach (var item in solicitudVenta)
            {
                CierreCajaLogic obj = new CierreCajaLogic();

                obj.codigoCierreCaja = item.codigoCierreCaja;
                obj.fechaCierre = item.fechaCierre;
                obj.nombreEmpleado = item.nombreEmpleado;
                obj.efectivoSoles = item.efectivoSoles;
                obj.efectivoDolares = item.efectivoDolares;
                obj.tarjetaSoles = item.tarjetaSoles;
                obj.tarjetaDolares = item.tarjetaDolares;
                obj.devolucionSoles = item.devolucionSoles;
                obj.devolucionDolares = item.devolucionDolares;
                obj.efectivoSolesReal = item.efectivoSolesReal;
                obj.efectivoDolaresReal = item.efectivoDolaresReal;
                obj.tarjetaSolesReal = item.tarjetaSolesReal;
                obj.tarjetaDolaresReal = item.tarjetaDolaresReal;
                obj.devolucionSolesReal = item.devolucionSolesReal;
                obj.devolucionDolaresReal = item.devolucionDolaresReal;
                obj.MontoReal = item.MontoReal;
                obj.MontoTotal = item.MontoTotal;
                obj.montoDiferencia = item.montoDiferencia;

                list.Add(obj);
            }
            return list;
        }


    }
}

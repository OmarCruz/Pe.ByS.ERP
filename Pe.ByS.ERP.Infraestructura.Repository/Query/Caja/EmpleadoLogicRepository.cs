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
                obj.cantidadProducto = item.cantidadProducto;
                obj.codigoProducto = item.codigoProducto;
                obj.descripcionProducto = item.descripcionProducto;
                obj.EstadoSolicitud = item.EstadoSolicitud;
                obj.FechaSolicitud = item.FechaSolicitud;
                obj.NumeroSolicitud = item.NumeroSolicitud;
                obj.precioProducto = item.precioProducto;
                obj.subtotal = item.subtotal;

                list.Add(obj);
            }
            return list;
        }

        public String GrabarPago(PagoLogic obj)
        {
            SqlParameter[] parametro = new SqlParameter[9];

            parametro[0] = new SqlParameter(); parametro[0].ParameterName = "numeroSolicitud"; parametro[0].Value = obj.NumeroSolicitud;
            parametro[1] = new SqlParameter(); parametro[1].ParameterName = "montoRecibido"; parametro[1].Value = obj.MontoRecibido;
            parametro[2] = new SqlParameter(); parametro[2].ParameterName = "referenciaPagoTarjeta"; parametro[2].Value = obj.referenciaPagoTarjeta;
            parametro[3] = new SqlParameter(); parametro[3].ParameterName = "codigoTipoDocumento"; parametro[3].Value = obj.codigoTipoDocumento;
            parametro[4] = new SqlParameter(); parametro[4].ParameterName = "ruc"; parametro[4].Value = obj.ruc;
            parametro[5] = new SqlParameter(); parametro[5].ParameterName = "razonSocial"; parametro[5].Value = obj.razonSocial;
            parametro[6] = new SqlParameter(); parametro[6].ParameterName = "codigoTipoPago"; parametro[6].Value = obj.codigoTipoPago;
            parametro[7] = new SqlParameter(); parametro[7].ParameterName = "codigoTipoMoneda"; parametro[7].Value = obj.codigoTipoMoneda;
            parametro[8] = new SqlParameter(); parametro[8].ParameterName = "vuelto"; parametro[8].Value = obj.Vuelto;

            var pago = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("dbo.GRABARPAGO", parametro).ToString();

            return pago;
        }

        public List<PagoLogic> BuscarComprobante(int nroSolicitud)
        {
            List<PagoLogic> list = new List<PagoLogic>();

            SqlParameter userNameParameter = new SqlParameter("numeroSolicitud", nroSolicitud);

            var solicitudVenta = this.dataBaseProvider.ExecuteStoreProcedure<PagoLogic>("dbo.ImprimeComprobantePago", userNameParameter).ToList();

            foreach (var item in solicitudVenta)
            {
                PagoLogic obj = new PagoLogic();

                obj.NumeroComprobante = item.NumeroComprobante;
                obj.razonSocial = item.razonSocial;
                obj.ruc = item.ruc;
                obj.telefono = item.telefono;
                obj.fechaRegistroPago = item.fechaRegistroPago;
                obj.tipoPago = item.tipoPago;
                obj.totalVenta = item.totalVenta;
                obj.moneda = item.moneda;
                obj.Vuelto = item.Vuelto;
                obj.MontoRecibido = item.MontoRecibido;
                obj.Cajero = item.Cajero;
                obj.nombreSucursal = item.nombreSucursal;
                obj.nombreProducto = item.nombreProducto;
                obj.precioProducto = item.precioProducto;
                obj.cantidadProducto = item.cantidadProducto;
                obj.subtotalProducto = item.subtotalProducto;

                list.Add(obj);
            }
            return list;
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

using System.Collections.Generic;
using System.Configuration;
namespace Pe.ByS.ERP.Infraestructura.Core.Context
{
    /// <summary>
    /// Clase de datos constantes de la Base datos
    /// </summary>
    /// <remarks>
    /// Creación:   20150424 <br />
    /// Modificación:            <br />
    /// </remarks> 
    public class DatosConstantes
    {
        /// <summary>
        /// Constantes de Estado de Registro
        /// </summary>
        public sealed class EstadoRegistro
        {
            /// <summary>
            /// Estado de Registro
            /// </summary>
            public static readonly string Activo = "1";

            /// <summary>
            /// Estado Inactivo
            /// </summary>
            public static readonly string Inactivo = "0";
        }

        /// <summary>
        /// Constantes de Estado de Vigencia
        /// </summary>
        public sealed class EstadoVigencia
        {
            /// <summary>
            /// Estado Vigente
            /// </summary>
            public static readonly string Vigente = "V";

            /// <summary>
            /// Estado Próximo
            /// </summary>
            public static readonly string Proximo = "P";

            /// <summary>
            /// Estado Histórico
            /// </summary>
            public static readonly string Historico = "H";
        }

        /// <summary>
        /// Constantes Formato
        /// </summary>
        public sealed class Formato
        {
            /// <summary>
            /// Formato de Fecha
            /// </summary>
            public static readonly string FormatoFecha = "dd/MM/yyyy";

            /// <summary>
            /// Formato de Fecha de Selector
            /// </summary>
            public static readonly string FormatoFechaSelector = "dd/mm/yy";

            /// <summary>
            /// Formato de Fecha de Mascara
            /// </summary>
            public static readonly string FormatoFechaMascara = "00/00/0000";

            /// <summary>
            /// Formato de Hora
            /// </summary>
            public static readonly string FormatoHora = "hh:mm tt";

            /// <summary>
            /// Formato de Número Entero
            /// </summary>
            public static readonly string FormatoNumeroEntero = "#,##0";

            /// <summary>
            /// Formato de Número Decimal
            /// </summary>
            public static readonly string FormatoNumeroDecimal = "#,##0.00";

            /// <summary>
            /// Formato de número de adenda
            /// </summary>
            public static readonly string FormatoNumeroAdenda = "{0}-ADENDA{1}";
        }

       
        /// <summary>
        /// Constantes de Sesiones
        /// </summary>
        public sealed class Sesiones
        {
            /// <summary>
            /// Sesión para Parrafos por Contrato
            /// </summary>
            public static readonly string SessionParrafoContrato = "SessionParrafosPorContrato";
            /// <summary>
            /// Sesión para los tipos de servicio de contrato
            /// </summary>
            public static readonly string SessionTipoServicio = "SessionTipoServicio";
            /// <summary>
            /// Sesión para los tipos de requerimiento del contrato
            /// </summary>
            public static readonly string SessionTipoRequerimiento = "SessionTipoRequerimiento";
            /// <summary>
            /// Sesión para Tipos de Bien
            /// </summary>
            public static readonly string SessionTipoBien = "SessionTipoBien";
            /// <summary>
            /// Sesión para tipos de tarifa
            /// </summary>
            public static readonly string SessionTipoTarifaBien = "SessionTipoTarifaBien";
            /// <summary>
            /// Sesión para Periodo de Alquiler
            /// </summary>
            public static readonly string SessionPeriodoAlquilerBien = "SessionPeriodoAlquilerBien";
            /// <summary>
            /// Sesión para Periodo de Alquiler
            /// </summary>
            public static readonly string SessionMonedaBien = "SessionMonedaBien";
            /// <summary>
            /// Sesión para el tipo de contenido de datos del bien
            /// </summary>
            public static readonly string SessionContenidoBien = "SessionContenidoBien";

        }
      
    }
}
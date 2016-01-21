using System;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Entidad que retorna el código y valor de un parámetro.
    /// </summary>
    /// <remarks>
    /// Creación:   14042015 <br />
    /// Modificación:            <br />
    /// </remarks>
    /// 
    [Serializable]
    public class CodigoValorResponse
    {
        /// <summary>
        /// Código de parámetro
        /// </summary>
        public object Codigo { get; set; }
        /// <summary>
        /// Valor de parámetro
        /// </summary>
        public object Valor { get; set; }
    }
}

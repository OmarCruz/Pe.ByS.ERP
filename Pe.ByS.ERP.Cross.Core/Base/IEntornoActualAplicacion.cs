using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Cross.Core.Base
{
    /// <summary>
    /// Objecto que representa un entorno de usuario en la aplicación
    /// </summary>
    /// <remarks>
    /// Creación:        20150319
    /// Modificación:   
    /// </remarks>
    public interface IEntornoActualAplicacion
    {    
        /// <summary>
        /// Id del usaurio en sesión
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Alias del usaurio en sesión
        /// </summary>
        string UsuarioSession { get; set; }
        /// <summary>
        /// Terminal de donde se accedio
        /// </summary>
        string Terminal { get; set; }

    }
}

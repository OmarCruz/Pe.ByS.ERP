using Pe.ByS.ERP.Cross.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Cross.Core.Exception
{
    /// <summary>
    /// Infrastructure Exception
    /// </summary>
    /// <remarks>
    /// Creación:    22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class InfrastructureLayerException<T> : GenericException<T>
        where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public InfrastructureLayerException(string message, System.Exception e) : base(message, e) { }
    }
}

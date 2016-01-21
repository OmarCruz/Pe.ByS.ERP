
using Pe.ByS.ERP.Aplicacion.Core.Base;
using System;

namespace Pe.ByS.ERP.Aplicacion.Service.Base
{
    /// <summary>
    /// Implementación base generica de servicios de aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   22122015 <br />
    /// Modificación:            <br />
    /// </remarks>
    public abstract class GenericService : IGenericService
    {

        private bool Disposed = false;
        /// <summary>
        /// Finaliza el objeto
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {

                }
            }
            this.Disposed = true;
        }
        /// <summary>
        /// Finaliza el objeto
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

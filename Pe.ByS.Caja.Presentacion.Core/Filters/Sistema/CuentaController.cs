using Pe.ByS.ERP.Presentation.Web.Src.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.ByS.Caja.Presentacion.Core.Controllers.Sistema
{
    public class CuentaController : GenericController
    {

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Logut()
        {
            return View();
        }
        #endregion
    }
}

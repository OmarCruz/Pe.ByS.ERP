using Pe.ByS.ERP.Aplicacion.TransferObject.Response.General;
using Pe.ByS.ERP.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Pe.ByS.Caja.Presentacion.Core.ViewModel.GestionPermiso
{
    public class BuscarSolicitudPermisoViewModel : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Lista combo estados
        /// </summary>
        public List<SelectListItem> EstadosSolicitud { get; set; }
        #endregion

        /// <summary>
        /// Constructor del modelo de vista buscar
        /// </summary>
        /// <param name="estadosSolicitud">Estados de la solicitud</param>
        public BuscarSolicitudPermisoViewModel(List<CodigoValorResponse> estadosSolicitud) {

            this.EstadosSolicitud = this.GenerarListadoOpcioneGenericoFiltro(estadosSolicitud);
        }
    }
}

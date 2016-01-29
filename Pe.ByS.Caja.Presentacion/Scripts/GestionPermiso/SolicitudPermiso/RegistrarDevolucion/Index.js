/// <summary>
/// Script de Vista 
/// </summary>
/// <remarks>
/// Creacion: 20140225 <br />
/// </remarks>
try {
    ns('Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion');
    $(document).ready(function () {
        'use strict';
        Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion.Page = new Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion.Controller();
        Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion.Page.Ini();
        //setActive('mdlCredito', 'mnuAdministracionMasivo');
    });
} catch (ex) {
    alert(ex.message);
}
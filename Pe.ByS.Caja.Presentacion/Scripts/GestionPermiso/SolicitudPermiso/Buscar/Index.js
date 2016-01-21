/// <summary>
/// Script de Vista 
/// </summary>
/// <remarks>
/// Creacion: 20140225 <br />
/// </remarks>
try {
    ns('Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Buscar');
    $(document).ready(function () {
        'use strict';
        Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Buscar.Page = new Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Buscar.Controller();
        Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Buscar.Page.Ini();
        //setActive('mdlCredito', 'mnuAdministracionMasivo');
    });
} catch (ex) {
    alert(ex.message);
}
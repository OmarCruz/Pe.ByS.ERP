/// <summary>
/// Script de Vista 
/// </summary>
/// <remarks>
/// Creacion: 20140225 <br />
/// </remarks>
try {
    ns('Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.RegistrarCierreCaja');
    $(document).ready(function () {
        'use strict';
        Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.RegistrarCierreCaja.Page = new Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.RegistrarCierreCaja.Controller();
        Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.RegistrarCierreCaja.Page.Ini();
        //setActive('mdlCredito', 'mnuAdministracionMasivo');
    });
} catch (ex) {
    alert(ex.message);
}
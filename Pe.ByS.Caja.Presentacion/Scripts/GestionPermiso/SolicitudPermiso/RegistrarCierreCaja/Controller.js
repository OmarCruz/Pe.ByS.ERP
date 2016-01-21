/// <summary>
/// Script de Controladora de la Vista 
/// </summary>
/// <remarks>
/// Creacion: 20151126 <br />
/// </remarks>
try {
    ns('Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.RegistrarCierreCaja.Controller');
    Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.RegistrarCierreCaja.Controller = function () {
        var base = this;
        var tipoCambio = 3.27;
        var CierreRequest = {};
        
        // base.Ini es ejecutado por el Framework al cargar la pagina
        base.Ini = function () {
            // Cargar propiedades de los controles en pantalla
            base.Control.txtEfectivoSolesReal().keypress(base.Event.CalcularMontoTotalRealKeypress);
            base.Control.txtEfectivoDolaresReal().keypress(base.Event.CalcularMontoTotalRealKeypress);
            base.Control.txtTarjetaSolesReal().keypress(base.Event.CalcularMontoTotalRealKeypress);
            base.Control.txtTarjetaDolaresReal().keypress(base.Event.CalcularMontoTotalRealKeypress);
            base.Control.txtDevolucionSolesReal().keypress(base.Event.CalcularMontoTotalRealKeypress);
            base.Control.txtDevolucionDolaresReal().keypress(base.Event.CalcularMontoTotalRealKeypress);
            base.Control.btnGrabar().click(base.Event.btnGrabarClick);
            base.Control.btnLimpiar().click(base.Event.btnLimpiarClick);
            // Cargar transacciones cargadas en el sistema
            base.Ajax.AjaxCierre.submit();
        };


        base.Control = {
            // Montos del Sistema
            txtEfectivoSoles: function () { return $('#txtEfectivoSoles'); },
            txtEfectivoDolares: function () { return $('#txtEfectivoDolares'); },
            txtTarjetaSoles: function () { return $('#txtTarjetaSoles'); },
            txtTarjetaDolares: function () { return $('#txtTarjetaDolares'); },
            txtDevolucionSoles: function () { return $('#txtDevolucionSoles'); },
            txtDevolucionDolares: function () { return $('#txtDevolucionDolares'); },
            txtMontoTotal: function () { return $('#txtMontoTotal'); },
            // Montos reales ingresados por el cajero
            txtEfectivoSolesReal: function () { return $('#txtEfectivoSolesReal'); },
            txtEfectivoDolaresReal: function () { return $('#txtEfectivoDolaresReal'); },
            txtTarjetaSolesReal: function () { return $('#txtTarjetaSolesReal'); },
            txtTarjetaDolaresReal: function () { return $('#txtTarjetaDolaresReal'); },
            txtDevolucionSolesReal: function () { return $('#txtDevolucionSolesReal'); },
            txtDevolucionDolaresReal: function () { return $('#txtDevolucionDolaresReal'); },
            txtMontoTotalReal: function () { return $('#txtMontoTotalReal'); },
            // Otros
            txtMontoDiferencia: function () { return $('#txtMontoDiferencia'); },
            btnGrabar: function () { return $('#btnGrabar'); },
            btnLimpiar: function () { return $('#btnLimpiar'); }
        };

        base.Event = {
            AjaxCierreSuccess: function (data) {
                'use strict';
                if (data) {
                    if (data.IsSuccess) {
                        console.log(JSON.stringify(data));
                        base.Control.txtEfectivoSoles().val((data.Result.efectivoSoles).toFixed(2));
                        base.Control.txtEfectivoDolares().val((data.Result.efectivoDolares).toFixed(2));
                        base.Control.txtTarjetaSoles().val((data.Result.tarjetaSoles).toFixed(2));
                        base.Control.txtTarjetaDolares().val((data.Result.tarjetaDolares).toFixed(2));
                        base.Control.txtDevolucionSoles().val((data.Result.devolucionSoles).toFixed(2));
                        base.Control.txtDevolucionDolares().val((data.Result.devolucionDolares).toFixed(2));

                        // Cargar monto total del sistema
                        var montoTotal = data.Result.efectivoSoles +
                                            (data.Result.efectivoDolares * tipoCambio) +
                                            data.Result.tarjetaSoles +
                                            (data.Result.tarjetaDolares * tipoCambio) -
                                            data.Result.devolucionSoles -
                                            (data.Result.devolucionDolares * tipoCambio);

                        base.Control.txtMontoTotal().val((montoTotal).toFixed(2));
                    }
                    else {
                        $.each(data.Result.Messages, function (key, value) {
                            alert(value);
                        });
                    }
                }
            },
            CalcularMontoTotalRealKeypress: function (e) {
                if (e.keyCode == 13) {
                    base.Function.CalcularTotales();
                }
            },
            btnLimpiarClick: function () {
                base.Function.Limpiar();
            },
            btnGrabarClick: function () {
                base.Function.CalcularTotales();
                var montoDiferencia = base.Control.txtMontoDiferencia().val();
                var mensajeConfirmacion = "";
                if (montoDiferencia != 0) {
                    mensajeConfirmacion = "Existe una diferencia de " + montoDiferencia + " Soles. ¿Desea continuar?";
                } else {
                    mensajeConfirmacion = "Los montos cuadran. ¿Desea continuar?"
                }

                if (confirm(mensajeConfirmacion)) {
                    CierreRequest.efectivoSoles = base.Control.txtEfectivoSolesReal().val();
                    CierreRequest.efectivoDolares = base.Control.txtEfectivoDolaresReal().val();
                    CierreRequest.tarjetaSoles = base.Control.txtTarjetaSolesReal().val();
                    CierreRequest.tarjetaDolares = base.Control.txtTarjetaDolaresReal().val();
                    CierreRequest.devolucionSoles = base.Control.txtDevolucionSolesReal().val();
                    CierreRequest.devolucionDolares = base.Control.txtDevolucionDolaresReal().val();
                    CierreRequest.montoDiferencia = base.Control.txtMontoDiferencia().val();
                    CierreRequest.codigoEmpleado = 1;
                    CierreRequest.numeroCaja = 1;

                    base.Ajax.AjaxGrabar.data = CierreRequest;
                    base.Ajax.AjaxGrabar.submit();
                }
            },
            AjaxGrabarSuccess: function (data) {
                'use strict';
                if (data) {
                    if (data.IsSuccess) {
                        alert("Cierre grabado satisfactoriamente");
                        //base.Function.BloquearControles();

                        //alert(data.Result[0].codigoCierreCaja.toString());
                        //alert(data.Result[0].fechaCierre.toString());
                        //alert(data.Result[0].nombreEmpleado.toString());
                        //alert(data.Result[0].efectivoSoles.toString());
                        //alert(data.Result[0].efectivoSolesReal.toString());
                        //alert(data.Result[0].efectivoDolares.toString());
                        //alert(data.Result[0].efectivoDolaresReal.toString() );
                        //alert(data.Result[0].tarjetaSoles.toString() );
                        //alert(data.Result[0].tarjetaSolesReal.toString() );
                        //alert(data.Result[0].tarjetaDolares.toString() );
                        //alert(data.Result[0].tarjetaDolaresReal.toString());
                        //alert(data.Result[0].devolucionSoles.toString());
                        //alert(data.Result[0].devolucionSolesReal.toString()); 
                        //alert(data.Result[0].devolucionDolares.toString());
                        //alert(data.Result[0].devolucionDolaresReal.toString() );
                        //alert(data.Result[0].MontoTotal.toString());
                        //alert(data.Result[0].MontoReal.toString());
                        //alert(data.Result[0].montoDiferencia.toString());

                        var docDefinition = {

                            pageSize: 'A5',
                            pageOrientation: 'landscape',
                            pageMargins: [40, 60, 40, 60],

                            
                            header: {
                                text: "SUSTENTO DE CIERRE DE CAJA  N° " + data.Result[0].codigoCierreCaja.toString(),
                                margin: [20, 20, 10, 20],
                                alignment: 'center',
                                fontSize: 17,
                                fontFamily: 'tahoma'
                            },

                            content: [
                                        { text: '', margin: 5 },
                                        { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Fecha:' },
                                                { text: data.Result[0].fechaCierre.toString() },
                                                //{ text: '' },
                                                { text: 'Cajero:' },
                                                { text: data.Result[0].nombreEmpleado.toString() }
                                            ]
                                        },
                                        { text: '', margin: 5 },
                                        { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Efectivo S/. :' },
                                                { text: data.Result[0].efectivoSoles.toString() },
                                                //{ text: '' },
                                                { text: 'Efectivo S/. Real:' },
                                                { text: data.Result[0].efectivoSolesReal.toString() }
                                            ]
                                        }, { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Efectivo $ :' },
                                                { text: data.Result[0].efectivoDolares.toString() },
                                                //{ text: '' },
                                                { text: 'Efectivo $ Real:' },
                                                { text: data.Result[0].efectivoDolaresReal.toString() }
                                            ]
                                        }, { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Tarjeta S/. :' },
                                                { text: data.Result[0].tarjetaSoles.toString() },
                                                //{ text: '' },
                                                { text: 'Tarjeta S/. Real:' },
                                                { text: data.Result[0].tarjetaSolesReal.toString() }
                                            ]
                                        }, { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Tarjeta $ :' },
                                                { text: data.Result[0].tarjetaDolares.toString() },
                                                //{ text: '' },
                                                { text: 'Tarjeta $ Real:' },
                                                { text: data.Result[0].tarjetaDolaresReal.toString() }
                                            ]
                                        }, { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Devolución S/. :' },
                                                { text: data.Result[0].devolucionSoles.toString() },
                                                //{ text: '' },
                                                { text: 'Devolución S/. Real:' },
                                                { text: data.Result[0].devolucionSolesReal.toString() }
                                            ]
                                        }, { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Devolución $ :' },
                                                { text: data.Result[0].devolucionDolares.toString() },
                                                //{ text: '' },
                                                { text: 'Devolución $ Real:' },
                                                { text: data.Result[0].devolucionDolaresReal.toString() }
                                            ]
                                        },
                                        { text: '', margin: 5 },
                                        { text: '', margin: 5 },
                                        { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Monto Total:' },
                                                { text: data.Result[0].MontoTotal.toString() },
                                                //{ text: '' },
                                                { text: 'Monto Real:' },
                                                { text: data.Result[0].MontoReal.toString() }
                                            ]
                                        },
                                        { text: '', margin: 5 },
                                        {
                                            alignment: 'left',
                                            fontSize: 14,
                                            columns: [
                                                { text: 'Monto Diferencia:' },
                                                { text: data.Result[0].montoDiferencia.toString() },
                                                { text: '' },
                                                //{ text: '' },
                                                { text: '' }
                                            ]
                                        },
                                        { text: '', margin: 5 }

                            ],
                            styles: {
                                tableExample: {
                                    margin: [0, 5, 0, 15],
                                    fontSize: 10
                                }
                            }

                        };
 
                        // open the PDF in a new window
                        pdfMake.createPdf(docDefinition).open();

                    }
                    else {
                        $.each(data.Result.Messages, function (key, value) {
                            alert(value);
                        });
                    }
                }
            }
        };

        base.Ajax = {
            AjaxCierre: new Pe.GMD.UI.Web.Components.Ajax({
                action: Pe.ByS.ERP.GestionPermiso.SolicitudPermiso.Actions.Cierre,
                autoSubmit: false,
                onSuccess: base.Event.AjaxCierreSuccess
            }),
            AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
                action: Pe.ByS.ERP.GestionPermiso.SolicitudPermiso.Actions.Grabar,
                autoSubmit: false,
                onSuccess: base.Event.AjaxGrabarSuccess
            })
        };

        base.Function = {
            CalcularTotales: function () {
                var efectivoSolesReal = base.Control.txtEfectivoSolesReal().val() != "" ? parseFloat(base.Control.txtEfectivoSolesReal().val()) : 0;
                var efectivoDolaresReal = base.Control.txtEfectivoDolaresReal().val() != "" ? parseFloat(base.Control.txtEfectivoDolaresReal().val()) : 0;
                var tarjetaSolesReal = base.Control.txtTarjetaSolesReal().val() != "" ? parseFloat(base.Control.txtTarjetaSolesReal().val()) : 0;
                var tarjetaDolaresReal = base.Control.txtTarjetaDolaresReal().val() != "" ? parseFloat(base.Control.txtTarjetaDolaresReal().val()) : 0;
                var devolucionSolesReal = base.Control.txtDevolucionSolesReal().val() != "" ? parseFloat(base.Control.txtDevolucionSolesReal().val()) : 0;
                var devolucionDolaresReal = base.Control.txtDevolucionDolaresReal().val() != "" ? parseFloat(base.Control.txtDevolucionDolaresReal().val()) : 0;
                // Cargar monto total del sistema
                var montoTotal = base.Control.txtMontoTotal().val();
                var montoTotalReal = efectivoSolesReal +
                                        (efectivoDolaresReal * tipoCambio) +
                                        tarjetaSolesReal +
                                        (tarjetaDolaresReal * tipoCambio) -
                                        devolucionSolesReal -
                                        (devolucionDolaresReal * tipoCambio);

                base.Control.txtMontoTotalReal().val((montoTotalReal).toFixed(2));
                base.Control.txtMontoDiferencia().val((montoTotalReal - montoTotal).toFixed(2));
            },
            BloquearControles: function () {
                base.Control.txtEfectivoSolesReal().prop('disabled', true);
                base.Control.txtEfectivoDolaresReal().prop('disabled', true);
                base.Control.txtTarjetaSolesReal().prop('disabled', true);
                base.Control.txtTarjetaDolaresReal().prop('disabled', true);
                base.Control.txtDevolucionSolesReal().prop('disabled', true);
                base.Control.txtDevolucionDolaresReal().prop('disabled', true);
                base.Control.txtMontoTotalReal().prop('disabled', true);
                base.Control.btnGrabar().prop('disabled', true);
            },
            Limpiar: function () {
                // Habilitar Campos
                base.Control.txtEfectivoSolesReal().prop('disabled', false);
                base.Control.txtEfectivoDolaresReal().prop('disabled', false);
                base.Control.txtTarjetaSolesReal().prop('disabled', false);
                base.Control.txtTarjetaDolaresReal().prop('disabled', false);
                base.Control.txtDevolucionSolesReal().prop('disabled', false);
                base.Control.txtDevolucionDolaresReal().prop('disabled', false);
                base.Control.txtMontoTotalReal().prop('disabled', false);
                base.Control.btnGrabar().prop('disabled', false);
                // Limpiar Campos
                base.Control.txtEfectivoSolesReal().val('');
                base.Control.txtEfectivoDolaresReal().val('');
                base.Control.txtTarjetaSolesReal().val('');
                base.Control.txtTarjetaDolaresReal().val('');
                base.Control.txtDevolucionSolesReal().val('');
                base.Control.txtDevolucionDolaresReal().val('');
                base.Control.txtMontoTotalReal().val('');
            }
        };

        $('.doubleInput').keypress(function (event) {
            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });

    };
} catch (ex) {
    alert(ex.message);
}



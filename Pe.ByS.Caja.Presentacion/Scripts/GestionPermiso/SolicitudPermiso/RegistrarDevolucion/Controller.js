/// <summary>
/// Script de Controladora de la Vista 
/// </summary>
/// <remarks>
/// Creacion: 20151126 <br />
/// </remarks>

// var eliminarDocumentoTipoPago = function (id) {
//     alert("id=" + tipoPago)
// };

// prueba commit

try {
    ns('Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion.Controller');
    Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion.Controller = function () {
        var base = this;
        var SolicitudVentaRequest = {};
        var PagoRequest = {};
        var tipoCambio = 3.27;
        var tipoPago = new Array();
        var tipoPagoIndex = 0;

        // base.Ini es ejecutado por el Framework al cargar la pagina
        base.Ini = function () {
            base.Control.btnBuscar().click(base.Event.btnBuscarClick);
            base.Function.CrearGridResultado();
            // base.Function.CrearGridDocumentoTipoPago();
            base.Control.DivResultadoBusqueda().fadeIn();
            // base.Control.DivDocumentoTipoPago().fadeIn();
            base.Control.btnGrabar().click(base.Event.btnGrabarClick);
            base.Control.btnLimpiar().click(base.Event.btnLimpiarClick);
            base.Control.btnAgregarDocumentoTipoPago().click(base.Event.btnAgregarDocumentoTipoPagoClick);

            $("#lblReferenciaPagoTarjeta").hide();
            $("#txtReferenciaPagoTarjeta").hide();

            $("#lblRuc").hide();
            $("#txtRuc").hide();
            $("#lblRazonSocial").hide();
            $("#txtRazonSocial").hide();
        }

        /*$('#divDocumentoTipoPago').click(function (event) {
            // alert(event.target.id);
            jQuery.each(tipoPago, function (i, val) {
                if (event.target.id.indexOf("btnEliminar_")!=-1 && 
                    val.id == event.target.id.replace("btnEliminar_", "")) {
                    var r = confirm("¿Seguro que desea eliminar el registro?");
                    if (r == true) {
                        tipoPago.splice(i, 1);
                        $('#grdDocumentoTipoPago').empty();
                        base.Function.CrearGridDocumentoTipoPago(tipoPago);
                        base.Function.CalcularTotales();
                        // alert("Se eliminó el medio de pago");
                    }
                    
                    return false;
                }
            });
        });*/

        /*$('#divDocumentoTipoPago').keypress(function (event) {
            if ((event.which != 46 || event.target.value.indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            } else {
                jQuery.each(tipoPago, function (i, val) {

                    if (event.target.id.indexOf("txtTipoPago_") != -1 &&
                        val.id == event.target.id.replace("txtTipoPago_", "")) {
                        val.tipoPagoValue = event.target.value + String.fromCharCode(event.keyCode);
                        return true;
                    }
                });

            }
        });*/

        $('.integerInput').keypress(function (event) {
            if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
                event.preventDefault(); //stop character from entering input
            }
        });

        $('.doubleInput').keypress(function (event) {
            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });

        $('#cboTipoPago').on('change', function () {
            // alert(this.value); // or $(this).val()
            if (this.value == 2) {
                $("#lblReferenciaPagoTarjeta").show();
                $("#txtReferenciaPagoTarjeta").show();
            } else {
                $("#lblReferenciaPagoTarjeta").hide();
                $("#txtReferenciaPagoTarjeta").hide();
                $("#lblReferenciaPagoTarjeta").val('');
                $("#txtReferenciaPagoTarjeta").val('');
            }
        });

        /*$('#cboMoneda').on('change', function () {

            $("#txtImporte").val(0);
            $("#txtVuelto").val(0);

            if ($('#cboMoneda').val() != 0) {
                $("#txtImporte").prop('disabled', false);
            }
            else {
                $("#txtImporte").prop('disabled', true);
            }
        });*/

        $('#cboTipoDocumento').on('change', function () {
            // alert(this.value); // or $(this).val()
            if (this.value == 2) {
                $("#lblRuc").show();
                $("#txtRuc").show();
                $("#lblRazonSocial").show();
                $("#txtRazonSocial").show();
            } else {
                $("#lblRuc").hide();
                $("#txtRuc").hide();
                $("#lblRazonSocial").hide();
                $("#txtRazonSocial").hide();

                $("#txtRuc").val('');
                $("#txtRazonSocial").val('');

                //$("#lblReferenciaPagoTarjeta").hide();
                //$("#txtReferenciaPagoTarjeta").hide();
                //$("#lblReferenciaPagoTarjeta").val('');
                //$("#txtReferenciaPagoTarjeta").val('');
            }
        });

        /*$("#txtImporte").keypress(function (e) {
            
            if (e.keyCode == 13) {
               
                var vuelto = 0;
                
                if ($('#cboMoneda').val() == 1) {
                    vuelto = (-1) * ($('#txtTotalSoles').val() - $('#txtImporte').val()).toFixed(2);
                } else {
                    vuelto = (-1) * ($('#txtTotalSoles').val() - ($('#txtImporte').val() * tipoCambio)).toFixed(2);
                    //vuelto = vuelto * tipoCambio;
                }
                
                if (vuelto < 0) {
                    $('#txtVuelto').val(0);
                    alert('El importe recibido no puede ser menor al importe total del pedido');
                    $('#txtImporte').val(0);
                }
                else {
                    $('#txtVuelto').val(vuelto.toFixed(2));
                }

            }
        });*/

        base.Control = {
            txtNumeroSolicitud: function () { return $('#txtNumeroSolicitud'); },
            btnBuscar: function () { return $('#btnBuscar'); },
            GridResultado: null,
            DivResultadoBusqueda: function () { return $('#divResultadoBusqueda') },
            btnGrabar: function () { return $('#btnGrabar'); },
            btnLimpiar: function () { return $('#btnLimpiar'); },
            btnAgregarDocumentoTipoPago: function () { return $('#btnAgregarDocumentoTipoPago'); },
            // DivDocumentoTipoPago: function () { return $('#divDocumentoTipoPago') }
        };

        base.Event = {
            btnBuscarClick: function () {
                // alert("btnBuscar clicked");

                if ($('#txtNumeroSolicitud').val() == null || $('#txtNumeroSolicitud').val() == '') {
                    alert('Debe ingresar un N° de Comprobante de Pedido');
                }
                else {
                    SolicitudVentaRequest.NumeroDocumento = base.Control.txtNumeroSolicitud().val();
                    base.Ajax.AjaxBuscar.data = SolicitudVentaRequest;
                    base.Ajax.AjaxBuscar.submit();
                }
            },
            AjaxBuscarSuccess: function (data) {
                'use strict';
                if (data) {
                    if (data.IsSuccess) {
                        console.log("is valid = true");
                        $('#grdResultado').empty();
                        $('#grdDocumentoTipoPago').empty();

                        if (data.Result.length > 0)
                        {
                            if (data.Result[0].EstadoSolicitud == 1) {
                                alert('El pago ya ha sido realizado')
                            }
                            else {
                                base.Function.CrearGridResultado(data.Result);
                                var montoTotalSoles = 0;
                                $.each(data.Result, function (i, l) {
                                    montoTotalSoles = montoTotalSoles + l.subtotal;
                                });
                                $('#txtTotalSoles').val((montoTotalSoles).toFixed(2));
                                $('#txtTotalDolares').val((montoTotalSoles / tipoCambio).toFixed(2));
                                // base.Control.GridResultado.data = data.Result;
                                $('#txtMonto').val((montoTotalSoles).toFixed(2));
                                $('#txtImporte').val((montoTotalSoles).toFixed(2));
                                tipoPago = new Array();
                                // base.Function.CrearGridDocumentoTipoPago(null);
                            }                                
                        }
                        else
                            alert('Comprobante de pedido no existe')
                    }
                    else {
                        $.each(data.Result.Messages, function (key, value) {
                            alert(value);
                        });
                    }
                }
            },
            btnGrabarClick: function () {

                /*var mensaje = "";

                if ($('#txtNumeroSolicitud').val() == null || $('#txtNumeroSolicitud').val() == '') {
                    mensaje = mensaje + '- Debe ingresar un Comprobante de Pedido' + "\n";
                }
               
                if ($('#txtImporte').val() == null || $('#txtImporte').val() == '' || $('#txtImporte').val() == 0) {
                    mensaje = mensaje + '- Debe ingresar medios de pago' + "\n";
                }
                
                // if ($('#cboTipoPago').val() == 0) {
                //     mensaje = mensaje + '- Debe seleccionar el tipo de pago' + "\n";
                // }

                // if ($('#cboMoneda').val() == 0) {
                //     mensaje = mensaje + '- Debe seleccionar la moneda de pago' + "\n";
                // }

                if ($('#cboTipoDocumento').val() == 0) {
                    mensaje = mensaje + '- Debe seleccionar el tipo de documento';
                }
                
                if ($('#cboTipoDocumento').val() == 2) {
                    if ($('#txtRuc').val() == '') {
                        mensaje = mensaje + '- Debe ingresar el RUC' + "\n";
                    }

                    if ($('#txtRazonSocial').val() == '') {
                        mensaje = mensaje + '- Debe ingresar la razón social';
                    }
                }

                if ( mensaje == "" ) {


                    PagoRequest.numeroSolicitudVenta = base.Control.txtNumeroSolicitud().val();

                    PagoRequest.montoRecibido = $('#txtImporte').val();
                    // PagoRequest.referenciaPagoTarjeta = $('#txtReferenciaPagoTarjeta').val();
                    PagoRequest.tipoDocumentoId = $('#cboTipoDocumento').val();
                    PagoRequest.ruc = $('#txtRuc').val();
                    PagoRequest.razonSocial = $('#txtRazonSocial').val();
                    // PagoRequest.codigoTipoPago = $('#cboTipoPago').val();
                    // PagoRequest.codigoTipoMoneda = $('#cboMoneda').val();
                    PagoRequest.Vuelto = $('#txtVuelto').val();
                    PagoRequest.montoTotal = $('#txtTotalSoles').val();
                    PagoRequest.tipoCambioId = 1;
                    PagoRequest.observaciones = "Pago en Caja";
                    
                    $('#btnGrabar').prop('disabled', true);
                    $('#btnBuscar').prop('disabled', true);
                    $('#txtNumeroSolicitud').prop('disabled', true);
                    $('#txtImporte').prop('disabled', true);

                    $('#cboTipoDocumento').prop('disabled', true);
                    $('#cboTipoPago').prop('disabled', true);
                    $('#cboMoneda').prop('disabled', true);
                    $('#txtReferenciaPagoTarjeta').prop('disabled', true);
                    $('#txtRuc').prop('disabled', true);
                    $('#txtRazonSocial').prop('disabled', true);

                    base.Ajax.AjaxGrabar.data = PagoRequest;
                    base.Ajax.AjaxGrabar.submit();
                }
                else {
                    alert(mensaje);
                }*/

                alert("Nota de credito generada satisfactoriamente");

            },
            AjaxGrabarSuccess: function (data) {
                'use strict';
                if (data) {
                    if (data.IsSuccess) {
                        console.log("is valid = true");
                        // alert("Pago satisfactorio!");
                        //window.open('Comprobante.cshtml','','width=500,height=500');

                        var produc = ['', '', '', '', '', '', '', '', '', ''];
                        var prec = ['', '', '', '', '', '', '', '', '', ''];
                        var canti = ['', '', '', '', '', '', '', '', '', ''];
                        var subto = ['', '', '', '', '', '', '', '', '', ''];

                        for (var i = 0; i < data.Result.length; i++) {
                            produc[i] = data.Result[i].nombreProducto;
                            prec[i] = data.Result[i].precioProducto.toString();
                            canti[i] = data.Result[i].cantidadProducto.toString();
                            subto[i] = data.Result[i].subtotalProducto.toString();
                        };

                        var docDefinition = {

                            pageSize: 'A5',
                            pageOrientation: 'landscape',
                            pageMargins: [40, 60, 40, 60],


                            header: { 
                                text: "COMPROBANTE DE PAGO N°  " + data.Result[0].NumeroComprobante,
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
                                            fontSize: 10,
                                            columns: [
                                                { text: 'FECHA:' },
                                                { text: data.Result[0].fechaRegistroPago },
                                                { text: '' },
                                                { text: 'SUCURSAL:' },
                                                { text: data.Result[0].nombreSucursal }
                                            ]
                                        },
                                        {
                                            alignment: 'left',
                                            fontSize: 10,
                                            columns: [
                                                { text: 'CAJERO:' },
                                                { text: data.Result[0].Cajero },
                                                { text: '' },
                                                { text: 'TELEFONO:' },
                                                { text: data.Result[0].telefono }
                                            ]
                                        },
                                        {
                                            alignment: 'left',
                                            fontSize: 10,
                                            columns: [
                                                { text: 'RAZON SOCIAL:' },
                                                { text: data.Result[0].razonSocial },
                                                { text: '' },
                                                { text: 'TIPO PAGO:' },
                                                { text: data.Result[0].tipoPago }
                                            ]
                                        },
                                        {
                                            alignment: 'left',
                                            fontSize: 10,
                                            columns: [
                                                { text: 'RUC:' },
                                                { text: data.Result[0].ruc },
                                                { text: '' },
                                                { text: 'MONEDA:' },
                                                { text: data.Result[0].moneda }
                                            ]
                                        },
                                        {
                                            alignment: 'left',
                                            fontSize: 10,
                                            columns: [
                                                { text: 'MONTO REC:' },
                                                { text: data.Result[0].montoRecibido.toString() },
                                                { text: '' },
                                                { text: 'VUELTO:' },
                                                { text: data.Result[0].Vuelto.toString() }
                                            ]
                                        },

                                        

                                        { text: '', margin: 5 },
                                        { text: '', margin: 5 },

                                        {
                                            style: 'tableExample',
                                            //fontSize: 8,
                                            table: {
                                                headerRows: 1,
                                                widths: [290, 60, 60, 60],
                                                body: [
                                                        ['PRODUCTO', 'PRECIO', 'CANT.', 'SUBTOTAL'],
                                                        [produc[0], prec[0], canti[0], subto[0]],
                                                        [produc[1], prec[1], canti[1], subto[1]],
                                                        [produc[2], prec[2], canti[2], subto[2]],
                                                        [produc[3], prec[3], canti[3], subto[3]],
                                                        [produc[4], prec[4], canti[4], subto[4]],
                                                        [produc[5], prec[5], canti[5], subto[5]],
                                                        [produc[6], prec[6], canti[6], subto[6]],
                                                        [produc[7], prec[7], canti[7], subto[7]],
                                                        [produc[8], prec[8], canti[8], subto[8]],
                                                        [produc[9], prec[9], canti[9], subto[9]]

                                                ]
                                            },
                                            layout: {

                                                hLineColor: function (i, node) {
                                                    return (i === 0 || i === 1 || i === node.table.body.length) ? 'black' : 'white';
                                                },
                                            }
                                        },

                                        { text: '', margin: 5 },
                                        { text: '', margin: 5 },

                                        {
                                            alignment: 'left',
                                            fontSize: 10,
                                            columns: [
                                                { text: '' },
                                                { text: '' },
                                                { text: '' },
                                                { text: '' },
                                                { text: '' },
                                                { text: '' },
                                                { text: 'TOTAL:'},
                                                { text: data.Result[0].totalVenta.toString() }
                                            ]
                                        },
                            ],

                            styles: {
                                tableExample: {
                                    margin: [0, 5, 0, 15],
                                    fontSize: 10
                                }
                            }

                        };

                        // Grabar medios de pago
                        jQuery.each(tipoPago, function (i, val) {
                            PagoRequest = {};
                            PagoRequest.documentoId = data.Result[0].documentoId.toString();
                            PagoRequest.tipoPagoId = val.tipoPagoId;
                            PagoRequest.monedaId = val.monedaId;
                            PagoRequest.monto = val.monto;
                            PagoRequest.referenciaPagoTarjeta = val.referencia;

                            base.Ajax.AjaxGrabarMediosPago.data = PagoRequest;
                            base.Ajax.AjaxGrabarMediosPago.submit();

                        });

                        // open the PDF in a new window
                        pdfMake.createPdf(docDefinition).open();
                    }
                    else {
                        $.each(data.Result.Messages, function (key, value) {
                            alert(value);
                        });
                    }
                }
            },
            AjaxGrabarMediosPagoSuccess: function (data) {
                'use strict';
                if (data) {
                    if (data.IsSuccess) {
                        alert("Pago satisfactorio!");
                    }
                    else {
                        $.each(data.Result.Messages, function (key, value) {
                            alert(value);
                        });
                    }
                }
            },
            btnLimpiarClick: function () {
                $('#btnGrabar').prop('disabled', false);
                $('#btnBuscar').prop('disabled', false);
                $('#txtNumeroSolicitud').prop('disabled', false);
                // $('#txtImporte').prop('disabled', false);
                $('#cboTipoDocumento').prop('disabled', false);
                $('#cboTipoPago').prop('disabled', false);
                $('#cboMoneda').prop('disabled', false);
                $('#txtReferenciaPagoTarjeta').prop('disabled', false);
                $('#txtRuc').prop('disabled', false);
                $('#txtRazonSocial').prop('disabled', false);
                $('#grdResultado').empty();
                $('#grdDocumentoTipoPago').empty();
                

                $('#txtTotalSoles').val('');
                $('#txtTotalDolares').val('');
                $('#txtVuelto').val('');
                $('#txtImporte').val('');
                $('#txtNumeroSolicitud').val('');
                $('#txtImporte').val('');
                $("#cboTipoDocumento").prop('selectedIndex', 0);
                $('#cboTipoPago').prop('selectedIndex', 0);
                $('#cboMoneda').prop('selectedIndex', 0);
                $("#lblRuc").hide();
                $("#txtRuc").hide();
                $("#lblRazonSocial").hide();
                $("#txtRazonSocial").hide();

                $("#txtRuc").val('');
                $("#txtRazonSocial").val('');

                $("#lblReferenciaPagoTarjeta").hide();
                $("#txtReferenciaPagoTarjeta").hide();
                $("#lblReferenciaPagoTarjeta").val('');
                $("#txtReferenciaPagoTarjeta").val('');


                $("#txtMonto").val('');
                $('#grdResultado').empty();
                $('#grdDocumentoTipoPago').empty();
                tipoPago = new Array();
                base.Function.CrearGridResultado(null);
                // base.Function.CrearGridDocumentoTipoPago(null);
                base.Function.CalcularTotales();
            },
            btnAgregarDocumentoTipoPagoClick: function () {
                
                
                var tipoPagoSelectedId = $('#cboTipoPago').val();
                var tipoPagoSelectedText = $('#cboTipoPago option:selected').text();
                var monedaSelectedId = $('#cboMoneda').val();
                var monedaSelectedText = $('#cboMoneda option:selected').text();
                var referenciaText = $('#txtReferenciaPagoTarjeta').val();
                var montoText = $('#txtMonto').val();

                if (tipoPagoSelectedId != 0 && monedaSelectedId != 0 &&
                    montoText.trim() != "" && (parseFloat(montoText)) > 0 &&
                    (tipoPagoSelectedId == 1 || (tipoPagoSelectedId == 2 && referenciaText.trim()))
                    ) {
                    $('#grdDocumentoTipoPago').empty();
                    tipoPagoIndex = tipoPagoIndex + 1;
                    // tipoPago.push({ "id": tipoPagoIndex, "tipoPagoValue": "" ,"tipoPagoControl": '<input id="txtTipoPago_' + tipoPagoIndex + '" type="text" class="form-control doubleInput" placeholder="0.00">', "referencia": 0, "monto": 0, "moneda": '<button id="btnEliminar_' + tipoPagoIndex + '" type="button" class="btn btn-default tipoPagoEliminar">Eliminar</button>' });
                    tipoPago.push({
                        "id": tipoPagoIndex,
                        "tipoPagoId": tipoPagoSelectedId,
                        "tipoPagoText": tipoPagoSelectedText,
                        "monedaId": monedaSelectedId,
                        "monedaText": monedaSelectedText,
                        "referencia": referenciaText,
                        "monto": montoText,
                        "eliminar": '<button id="btnEliminar_' + tipoPagoIndex + '" type="button" class="btn btn-default tipoPagoEliminar">Eliminar</button>'
                    });
                    // base.Function.CrearGridDocumentoTipoPago(tipoPago);
                    // base.Function.CalcularTotales();
                } else {
                    alert("Debe ingresar correctamente el medio de pago");
                }

                
            }
        };

        base.Ajax = {
            AjaxBuscar: new Pe.GMD.UI.Web.Components.Ajax({
                action: Pe.ByS.ERP.GestionPermiso.SolicitudPermiso.Actions.Buscar,
                autoSubmit: false,
                onSuccess: base.Event.AjaxBuscarSuccess
            }),
            AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
                action: Pe.ByS.ERP.GestionPermiso.SolicitudPermiso.Actions.Grabar,
                autoSubmit: false,
                onSuccess: base.Event.AjaxGrabarSuccess
            }),
            AjaxGrabarMediosPago: new Pe.GMD.UI.Web.Components.Ajax({
                action: Pe.ByS.ERP.GestionPermiso.SolicitudPermiso.Actions.GrabarPagoDetalle,
                autoSubmit: false,
                onSuccess: base.Event.AjaxGrabarMediosPagoSuccess
            }),
            //Agregado por RRG
            AjaxComprobante: new Pe.GMD.UI.Web.Components.Ajax({
                action: Pe.ByS.ERP.GestionPermiso.SolicitudPermiso.Actions.Comprobante,
                autoSubmit: false,
                onSuccess: base.Event.AjaxComprobanteSuccess
            })
        };

        base.Function = {
            CrearGridResultado: function (data) {
                var columns = new Array();
                columns.push({
                    data: 'descripcionProducto',
                    title: 'Producto',
                    width: "20%"
                });
                columns.push({
                    data: 'presentacionProducto',
                    title: 'Presentación',
                    width: "15%"
                });
                columns.push({
                    data: 'cantidadProducto',
                    title: 'Cantidad',
                    width: "15%"
                });
                columns.push({
                    data: 'descuento',
                    title: 'Descuento',
                    width: "15%"
                });
                columns.push({
                    data: 'precioProducto',
                    title: 'Precio Venta',
                    width: "15%"
                });
                columns.push({
                    data: 'subtotal',
                    title: 'Subtotal',
                    width: "15%"
                });
                base.Control.GridResultado = new Pe.GMD.UI.Web.Components.Grid({
                    renderTo: 'grdResultado',
                    columns: columns,
                    columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                    hasSelectionRows: false,
                    data: data
                });
            }
            /* CrearGridDocumentoTipoPago: function (data) {
                var columns = new Array();
                columns.push({
                    data: 'tipoPagoText',
                    title: 'Tipo',
                    width: "20%"
                });
                columns.push({
                    data: 'monto',
                    title: 'Monto',
                    width: "15%"
                });
                columns.push({
                    data: 'monedaText',
                    title: 'Moneda',
                    width: "15%"
                });
                columns.push({
                    data: 'referencia',
                    title: 'Referencia',
                    width: "15%"
                });
                columns.push({
                    data: 'eliminar',
                    title: 'Eliminar',
                    width: "15%"
                });
                base.Control.GridResultado = new Pe.GMD.UI.Web.Components.Grid({
                    renderTo: 'grdDocumentoTipoPago',
                    columns: columns,
                    columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                    hasSelectionRows: false,
                    data: data
                });
            },
            CalcularTotales: function (data) {
                var vuelto = 0;
                var importe = 0;

                jQuery.each(tipoPago, function (i, val) {

                    if (val.monedaId == 1) {
                        importe += parseFloat(val.monto);
                    } else {
                        importe += parseFloat(val.monto) * tipoCambio;
                    }
                });

                vuelto = (-1) * ($('#txtTotalSoles').val() - importe);
                $('#txtVuelto').val(vuelto.toFixed(2));
                $('#txtImporte').val(importe.toFixed(2));
            }*/
        };

    };
} catch (ex) {
    alert(ex.message);
}



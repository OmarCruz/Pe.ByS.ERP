/// <summary>
/// Script de Controladora de la Vista 
/// </summary>
/// <remarks>
/// Creacion: 20151126 <br />
/// </remarks>
try {
    ns('Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Buscar.Controller');
    Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Buscar.Controller = function () {
        var base = this;
        var SolicitudVentaRequest = {};
        var PagoRequest = {};
        var tipoCambio = 3.27;

        // base.Ini es ejecutado por el Framework al cargar la pagina
        base.Ini = function () {
            base.Control.btnBuscar().click(base.Event.btnBuscarClick);
            base.Function.CrearGridResultado();
            base.Control.DivResultadoBusqueda().fadeIn();
            base.Control.btnGrabar().click(base.Event.btnGrabarClick);
            base.Control.btnLimpiar().click(base.Event.btnLimpiarClick);

            $("#lblReferenciaPagoTarjeta").hide();
            $("#txtReferenciaPagoTarjeta").hide();

            $("#lblRuc").hide();
            $("#txtRuc").hide();
            $("#lblRazonSocial").hide();
            $("#txtRazonSocial").hide();
        }

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

        $('#cboMoneda').on('change', function () {

            $("#txtImporte").val(0);
            $("#txtVuelto").val(0);

            if ($('#cboMoneda').val() != 0) {
                $("#txtImporte").prop('disabled', false);
            }
            else {
                $("#txtImporte").prop('disabled', true);
            }
        });

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

        $("#txtImporte").keypress(function (e) {
            
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
        });

        base.Control = {
            txtNumeroSolicitud: function () { return $('#txtNumeroSolicitud'); },
            btnBuscar: function () { return $('#btnBuscar'); },
            GridResultado: null,
            DivResultadoBusqueda: function () { return $('#divResultadoBusqueda') },
            btnGrabar: function () { return $('#btnGrabar'); },
            btnLimpiar: function () { return $('#btnLimpiar'); }
        };

        base.Event = {
            btnBuscarClick: function () {
                // alert("btnBuscar clicked");

                if ($('#txtNumeroSolicitud').val() == null || $('#txtNumeroSolicitud').val() == '') {
                    alert('Debe ingresar un N° de Comprobante de Pedido');
                }
                else {
                    SolicitudVentaRequest.NumeroSolicitud = base.Control.txtNumeroSolicitud().val();
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

                var mensaje = "";

                if ($('#txtNumeroSolicitud').val() == null || $('#txtNumeroSolicitud').val() == '') {
                    mensaje = mensaje + '- Debe ingresar un Comprobante de Pedido' + "\n";
                }
               
                if ($('#txtImporte').val() == null || $('#txtImporte').val() == '' || $('#txtImporte').val() == 0) {
                    mensaje = mensaje + '- Debe ingresar el Importe a Pagar' + "\n";
                }
                
                if ($('#cboTipoPago').val() == 0) {
                    mensaje = mensaje + '- Debe seleccionar el tipo de pago' + "\n";
                }

                if ($('#cboMoneda').val() == 0) {
                    mensaje = mensaje + '- Debe seleccionar la moneda de pago' + "\n";
                }

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


                    PagoRequest.numeroSolicitud = base.Control.txtNumeroSolicitud().val();

                    PagoRequest.montoRecibido = $('#txtImporte').val();
                    PagoRequest.referenciaPagoTarjeta = $('#txtReferenciaPagoTarjeta').val();
                    PagoRequest.codigoTipoDocumento = $('#cboTipoDocumento').val();
                    PagoRequest.ruc = $('#txtRuc').val();
                    PagoRequest.razonSocial = $('#txtRazonSocial').val();
                    PagoRequest.codigoTipoPago = $('#cboTipoPago').val();
                    PagoRequest.codigoTipoMoneda = $('#cboMoneda').val();
                    PagoRequest.vuelto = $('#txtVuelto').val();
                    
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
                }

            },
            AjaxGrabarSuccess: function (data) {
                'use strict';
                if (data) {
                    if (data.IsSuccess) {
                        console.log("is valid = true");
                        alert("Pago satisfactorio!");
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
                                                { text: data.Result[0].MontoRecibido.toString() },
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
            btnLimpiarClick: function () {
                $('#btnGrabar').prop('disabled', false);
                $('#btnBuscar').prop('disabled', false);
                $('#txtNumeroSolicitud').prop('disabled', false);
                $('#txtImporte').prop('disabled', false);
                $('#cboTipoDocumento').prop('disabled', false);
                $('#cboTipoPago').prop('disabled', false);
                $('#cboMoneda').prop('disabled', false);
                $('#txtReferenciaPagoTarjeta').prop('disabled', false);
                $('#txtRuc').prop('disabled', false);
                $('#txtRazonSocial').prop('disabled', false);
                $('#grdResultado').empty();
                

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



                $('#grdResultado').empty();
                base.Function.CrearGridResultado(null);
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
                    data: 'precioProducto',
                    title: 'Precio Venta',
                    width: "15%"
                });
                columns.push({
                    data: 'cantidadProducto',
                    title: 'Cantidad',
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
        };

    };
} catch (ex) {
    alert(ex.message);
}



/// <summary>
/// Script de Controladora de la Vista 
/// </summary>
/// <remarks>
/// Creacion: 20160130 <br />
/// </remarks>

try {
    ns('Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion.Controller');
    Pe.ByS.Caja.GestionPermiso.SolicitudPermiso.Devolucion.Controller = function () {
        var base = this;
        var BuscarComprobantePagoRequest = {};
        var GrabarDevolucionRequest = {};
        var ListaProductos = {};
        var tiempoLimiteDevolucion = 7;

        base.Ini = function () {
            base.Control.btnBuscar().click(base.Event.btnBuscarClick);
            base.Function.CrearGridResultado();
            base.Control.DivResultadoBusqueda().fadeIn();
            base.Control.btnGrabar().click(base.Event.btnGrabarClick);
            base.Control.btnLimpiar().click(base.Event.btnLimpiarClick);
        }

        $('.integerInput').keypress(function (event) {
            if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
                event.preventDefault();
            }
        });

        base.Control = {
            txtComprobantePago: function () { return $('#txtComprobantePago'); },
            btnBuscar: function () { return $('#btnBuscar'); },
            GridResultado: null,
            DivResultadoBusqueda: function () { return $('#divResultadoBusqueda') },
            btnGrabar: function () { return $('#btnGrabar'); },
            btnLimpiar: function () { return $('#btnLimpiar'); },
        };

        $('#divResultadoBusqueda').change(function () {
            var montoTotal = 0;
            jQuery.each(ListaProductos, function (i, val) {
                var cantidadDevolucionTag = "#txtCantidadDevolucion_" + val.productoId;
                var subtotalDevolucionTag = "#txtSubTotal_" + val.productoId;
                var cantidadDevolucionValue = $(cantidadDevolucionTag).val();
                val.cantidadDevolucionValue = cantidadDevolucionValue;
                var subtotalDevolucionValue = (cantidadDevolucionValue * val.precioProducto).toFixed(2);
                val.subtotalDevolucionValue = subtotalDevolucionValue;
                $(subtotalDevolucionTag).val(val.subtotalDevolucionValue);
                montoTotal += parseFloat(subtotalDevolucionValue);
            });
            $("#txtTotalSoles").val(montoTotal);
        });

        base.Event = {
            btnBuscarClick: function () {
                if ($('#txtComprobantePago').val() == null || $('#txtComprobantePago').val() == '') {
                    alert('Debe ingresar un Comprobante de Pago');
                }
                else {
                    BuscarComprobantePagoRequest.NumeroDocumento = base.Control.txtComprobantePago().val();
                    base.Ajax.AjaxBuscar.data = BuscarComprobantePagoRequest;
                    base.Ajax.AjaxBuscar.submit();
                }
            },
            AjaxBuscarSuccess: function (data) {
                'use strict';
                if (data) {
                    if (data.IsSuccess) {
                        $('#grdResultado').empty();

                        if (data.Result.length > 0) {
                            $('#txtFechaPago').val(data.Result[0].fechaCreacion);
                            $('#txtTiempoTranscurrido').val(data.Result[0].tiempoTranscurrido);

                            var montoTotalSoles = 0;
                            $.each(data.Result, function (i, l) {
                                l.cantidadDevolucionControl = '<input id="txtCantidadDevolucion_' + l.productoId + '" type="number" class="form-control"  min="0" max="' + l.cantidadProducto + '" value="0">';
                                l.subtotalDevolucionControl = '<input id="txtSubTotal_' + l.productoId + '" class="form-control" value="0.00" disabled="disabled"/>';
                                l.cantidadDevolucionValue = 0;
                                l.subtotalDevolucionValue = 0;
                            });
                            ListaProductos = data.Result;
                            base.Function.CrearGridResultado(data.Result);
                            $('#txtTotalSoles').val((montoTotalSoles).toFixed(2));
                            $('#txtComprobantePago').prop('disabled', true);
                            $('#btnBuscar').prop('disabled', true);

                            if (data.Result[0].tiempoTranscurrido > tiempoLimiteDevolucion) {
                                alert("El comprobante [" + $('#txtComprobantePago').val() + "] supera el tiempo límite de solicitud de devolución. El tiempo máximo es de: [" + tiempoLimiteDevolucion + " días]");
                                $('#btnGrabar').prop('disabled', true);
                            }
                        }
                        else {
                            base.Function.CrearGridResultado(); // Mostrar grid vacio
                            alert('Comprobante de pago no existe')
                        }
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

                if ($('#txtComprobantePago').val() == null || $('#txtComprobantePago').val() == '') {
                    mensaje = mensaje + '- Debe ingresar un Comprobante de Pago' + "\n";
                }
               
                if ($('#txtTotalSoles').val() == null || $('#txtTotalSoles').val() == '' || $('#txtTotalSoles').val() == 0) {
                    mensaje = mensaje + '- Debe devolver al menos un producto' + "\n";
                }
                
                if ( mensaje == "" ) {

                    // Tabla NotaCredito
                    GrabarDevolucionRequest.numeroComprobantePago = $('#txtComprobantePago').val();
                    // Tabla NotaCreditoDetalle
                    GrabarDevolucionRequest.ListaProductos = ListaProductos;
                    // Tabla Documento
                    GrabarDevolucionRequest.tipoDocumentoId = 3;
                    GrabarDevolucionRequest.empleadoId = 1;
                    GrabarDevolucionRequest.cajaId = 1;
                    GrabarDevolucionRequest.tipoAtencionId = 1;
                    GrabarDevolucionRequest.pendientePago = 0;
                    GrabarDevolucionRequest.observaciones = "Nota de Credito generada";
                    GrabarDevolucionRequest.montoTotal = $('#txtTotalSoles').val();

                    $('#btnGrabar').prop('disabled', true);
                    $('#btnBuscar').prop('disabled', true);
                    $('#txtComprobantePago').prop('disabled', true);
                    $('#txtTotalSoles').prop('disabled', true);

                    base.Ajax.AjaxGrabar.data = GrabarDevolucionRequest;
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
                        var produc = ['', '', '', '', '', '', '', '', '', ''];
                        var prec = ['', '', '', '', '', '', '', '', '', ''];
                        var canti = ['', '', '', '', '', '', '', '', '', ''];
                        var subto = ['', '', '', '', '', '', '', '', '', ''];

                        for (var i = 0; i < data.Result.length; i++) {
                            produc[i] = data.Result[i].nombreProducto;
                            prec[i] = data.Result[i].precioProducto.toString();
                            canti[i] = data.Result[i].cantidadProducto.toString();
                            subto[i] = data.Result[i].subtotal.toString();
                        };

                        var docDefinition = {

                            pageSize: 'A5',
                            pageOrientation: 'landscape',
                            pageMargins: [40, 60, 40, 60],


                            header: {
                                text: "NOTA DE CRÉDITO N°  " + data.Result[0].numeroNotaCredito,
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
                                                { text: data.Result[0].fechaCreacion },
                                                { text: '' },
                                                { text: 'SUCURSAL:' },
                                                { text: data.Result[0].sucursalNombre }
                                            ]
                                        },
                                        {
                                            alignment: 'left',
                                            fontSize: 10,
                                            columns: [
                                                { text: 'CAJERO:' },
                                                { text: data.Result[0].nombreEmpleado },
                                                { text: '' },
                                                { text: 'TELEFONO:' },
                                                { text: data.Result[0].sucursalTelefono }
                                            ]
                                        },

                                        { text: '', margin: 5 },

                                        {
                                            alignment: 'left',
                                            fontSize: 10,
                                            columns: [
                                                { text: 'NOTA DE CRÉDITO GENERADA BAJO LA DEVOLUCIÓN DE LOS SIGUIENTES PRODUCTOS:' }
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
                                                { text: 'TOTAL SOLES:' },
                                                { text: data.Result[0].montoTotal.toString() }
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
                $('#txtComprobantePago').prop('disabled', false);
                $('#grdResultado').empty();
                
                $('#txtFechaPago').val('');
                $('#txtTiempoTranscurrido').val('');
                $('#txtTotalSoles').val('');
                $('#txtComprobantePago').val('');
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
                    data: 'precioProducto',
                    title: 'Precio Venta',
                    width: "15%"
                });
                columns.push({
                    data: 'cantidadProducto',
                    title: 'Cantidad en el Pago',
                    width: "15%"
                });
                columns.push({
                    data: 'cantidadDevolucionControl',
                    title: 'Cantidad Devolución',
                    width: "15%"
                });
                columns.push({
                    data: 'subtotalDevolucionControl',
                    title: 'Subtotal Devolución',
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



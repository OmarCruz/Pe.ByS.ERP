/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	07/01/2015
/// </remarks>

try {
    var subMenuActual = null;
    $(document).ready(function () {
        'use strict';

        var valorOpcionMenu = null;
        var cultura = 'ES-es';
        $.datepicker.setDefaults($.datepicker.regional[cultura]);
        function moveMenu() {
            var $panelMenu = $('.u-module-nav'),
                $modulePanel = $('.u-module-panel');

            $('#toggle-menu').on('click', function (e) {
                e.preventDefault();
                var $el = $(this),
                    $ulClosest = $(this).closest('ul').find('ul');

                var valorMenu = null;
                if (valorOpcionMenu == Pe.ByS.ERP.Web.Enumerados.FormaPresentacionMenu.FormaExtendido) {
                    var valorTemporal = $el.addClass('active');
                    valorMenu = valorTemporal.hasClass('active');
                }
                else if (valorOpcionMenu == Pe.ByS.ERP.Web.Enumerados.FormaPresentacionMenu.FormaContraido) {
                    var valorTemporal = $el.removeClass('active');
                    valorMenu = valorTemporal.hasClass('active');
                }
                else {
                    valorMenu = $el.hasClass('active')
                }

                if (!valorMenu) {
                    $el.addClass('active');
                    $panelMenu
                    .addClass('expanded')
                    $modulePanel.addClass('expanded');
                    valorOpcionMenu = null;
                } else {
                    $el.removeClass('active');
                    $panelMenu.removeClass('acenter expanded');
                    $modulePanel.removeClass('expanded');

                    var $btn = $('.btn-submenu');
                    $btn.removeClass('active');
                    $btn.closest('.w-submenu').removeClass('active');
                    $btn.next('ul').hide();

                    if (subMenuActual != null) {
                        subMenuActual.addClass('active');
                        subMenuActual.closest('.w-submenu').addClass('active');
                        subMenuActual.next('ul').show();
                        $('#' + Pe.ByS.ERP.Web.Global.MenuSeleccionado.SubModulo).focus();
                    }

                    //seleccionarMenuActual();
                    valorOpcionMenu = null;
                }
            });

        };

        moveMenu();

        function subMenu() {
            var $btn = $('.btn-submenu');

            $btn.on('click', function () {
                var $el = $(this),
                      $currentMenu = $el.next('ul');
                var $wrap = $el.closest('.w-submenu');

                if ($currentMenu.is(':hidden')) {
                    if ($el.parent().parent().parent().parent().hasClass('expanded')) {
                        $("#toggle-menu").trigger("click");
                        if (!$el.hasClass('active')) {
                            if (subMenuActual != null) {
                                subMenuActual.removeClass('active');
                                subMenuActual.closest('.w-submenu').removeClass('active');
                                subMenuActual.next('ul').slideUp();
                            }

                            $el.addClass('active');
                            $wrap.addClass('active');
                            $currentMenu.slideDown(function () {
                                $('#' + Pe.ByS.ERP.Web.Global.MenuSeleccionado.SubModulo).focus();
                            });
                        } else {
                            $('#' + Pe.ByS.ERP.Web.Global.MenuSeleccionado.SubModulo).focus();
                        }
                    } else {
                        if (subMenuActual != null) {
                            subMenuActual.removeClass('active');
                            subMenuActual.closest('.w-submenu').removeClass('active');
                            subMenuActual.next('ul').slideUp();
                        }
                        $el.addClass('active');
                        $wrap.addClass('active');
                        $currentMenu.slideDown(function () {
                            $('#' + Pe.ByS.ERP.Web.Global.MenuSeleccionado.SubModulo).focus();
                        });
                    }

                    subMenuActual = $el;

                }
                else {
                    $el.removeClass('active');
                    $wrap.removeClass('active');
                    $currentMenu.slideUp();
                    subMenuActual = null;
                }




            });

        }

        subMenu();

        function seleccionarMenuActual() {

            var modulo = Pe.ByS.ERP.Web.Global.MenuSeleccionado.Modulo;
            var submenu = Pe.ByS.ERP.Web.Global.MenuSeleccionado.SubModulo;

            $('#' + modulo).addClass('active');
            $('#' + submenu).addClass('active');
            $('#' + modulo).find('.btn-submenu, .w-submenu').addClass('active');
            $('#' + modulo).find('.btn-submenu').next('ul').slideDown('fast', function () {
                $('#' + submenu).focus();
            });
            subMenuActual = $('#' + modulo).find('.btn-submenu');

        }


        $('.u-toggle').on('click', function (event) {
            event.preventDefault();
            $(this).parent().parent().next().toggle('fast');
        });

        seleccionarMenuActual();
        if (Pe.ByS.ERP.Web.Global.MenuSeleccionado.Modulo != "") {
            valorOpcionMenu = Pe.ByS.ERP.Web.Global.Politicas.Menu.FormaMenuDesplegable;
            $("#toggle-menu").trigger("click");
        }

    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}
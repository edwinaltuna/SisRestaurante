/**
* Theme: Velonic Admin Template
* Author: Coderthemes
* Form wizard page
*/

!function($) {
    "use strict";

    var FormWizard = function () {
        this.secondStepValidaFecha = false;
        this.secondStepValidaCodigoPromo = false;
    };

    FormWizard.prototype.createBasic = function($form_container) {
        $form_container.children("div").steps({
            headerTag: "h3",
            bodyTag: "section",
            transitionEffect: "slideLeft"
        });
        return $form_container;
    },
    //creates form with validation
    FormWizard.prototype.createValidatorForm = function($form_container) {
        $form_container.validate({
            errorPlacement: function errorPlacement(error, element) {
                element.after(error);
            }
        });
        $form_container.children("div").steps({
            headerTag: "h3",
            bodyTag: "section",
            transitionEffect: "slideLeft",
            onStepChanging: function (event, currentIndex, newIndex) {

                var stepOne = false;
                var stepTwo = false;

                var pedidos = $("div").filter(function () {
                    return this.id.match(/div_pedido_/);
                })
                var conteo = -1;
                $.each(pedidos, function (i, v) {
                    if ($(this).css('-webkit-filter') == 'blur(0px)') {
                        conteo++;
                    }
                });
                if (conteo != -1) {
                    stepOne = true;
                } else {                    
                    $.Notification.fromElementNotify('panelBodyNuevaVenta', 'info', 'top center', 'Aviso', 'Debe seleccionar un pedido antes de proceder con el siguiente paso');
                    stepOne = false;
                }

                //vamos del segundo step al tercero
                if (currentIndex == 1 && newIndex == 2) {
                    return $.FormWizard.secondStepValidaFecha && $.FormWizard.secondStepValidaCodigoPromo;

                }
                
                return stepOne;
            },
            onFinishing: function (event, currentIndex) {
                $form_container.validate().settings.ignore = ":disabled";
                return $form_container.valid();
            },
            onFinished: function (event, currentIndex) {
                alert("Submitted!");
            },
            labels: {
                cancel: "Cancelar",
                current: "Paso actual",
                pagination: "Paginación",
                finish: "Guardar Venta",
                next: "Siguiente",
                previous: "Anterior",
                loading: "Cargando..."
            }
        });

        return $form_container;
    },
    //creates vertical form
    FormWizard.prototype.createVertical = function($form_container) {
        $form_container.steps({
            headerTag: "h3",
            bodyTag: "section",
            transitionEffect: "fade",
            stepsOrientation: "vertical"
        });
        return $form_container;
    },
    FormWizard.prototype.init = function() {
        //initialzing various forms

        //basic form
        this.createBasic($("#basic-form"));

        //form with validation
        this.createValidatorForm($("#wizard-validation-form"));

        //vertical form
        this.createVertical($("#wizard-vertical"));
    },
    //init
    $.FormWizard = new FormWizard, $.FormWizard.Constructor = FormWizard
}(window.jQuery),

//initializing 
function($) {
    "use strict";
    $.FormWizard.init()
}(window.jQuery);
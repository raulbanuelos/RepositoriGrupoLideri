//------------- forms-wizard.js -------------//
var formsWizard = function () {

    return {

        //first wizard form
        wizard : function () {
            //add validation to wizard
            var $validator = $("#wizard form").validate({
                errorPlacement: function( error, element ) {
                    var place = element.closest('.input-group');
                    if (!place.get(0)) {
                        place = element;
                    }
                    if (place.get(0).type === 'checkbox') {
                        place = element.parent();
                    }
                    if (error.text() !== '') {
                        place.after(error);
                    }
                },
                errorClass: 'help-block',
                rules: {
                    Nombre: {
                        required: true
                    },
                    ApellidoPaterno: {
                        required: true
                    },
                    ApellidoMaterno: {
                        required: true
                    },
                    RFC:{
                        required: true
                    },
                    Usuario: {
                        required: true
                    },
                    Contrasena: {
                        required: true,
                        minlength: 8
                    },
                    Matricula: {
                        required: true,
                        minlength: 8
                    },
                    email: {
                        required: true,
                        email: true
                    },
                },
                messages: {
                    Nombre: {
                        required: "El nombre es requerido"
                    },
                    ApellidoPaterno: {
                        required: "El apellido paterno es requerido"
                    },
                    ApellidoMaterno: {
                        required: "El apellido materno es requerido"
                    },
                    RFC: {
                        required: "El RFC es requerido"
                    },
                    Usuario: {
                        required: "El usuario es requerido"
                    },
                    Contrasena: {
                        required: "La contrase�a debe ser m�nimo 8 caracteres"
                    },
                    Matricula: {
                        required: "La clave promotor debe ser al menos de 8 digitos"
                    },
                    email: {
                        required: "El email es requerido"
                    },
                },
                highlight: function( label ) {
                    $(label).closest('.form-group').removeClass('has-success').addClass('has-error');
                },
                success: function( label ) {
                    $(label).closest('.form-group').removeClass('has-error').addClass('has-success');
                    label.remove();
                }
            });
            
            //init first wizard
            $('#wizard').bootstrapWizard({
                tabClass: 'bwizard-steps',
                nextSelector: 'ul.pager li.next',
                previousSelector: 'ul.pager li.previous',
                firstSelector: null,
                lastSelector: null,
                onNext: function( tab, navigation, index, newindex ) {
                    currentTab = tab;
                    var validated = $('#wizard form').valid();
                    if( !validated ) {
                        currentTab.addClass('step-error');
                        $validator.focusInvalid();
                        return false;
                    } else { currentTab.removeClass('step-error'); }
                },
                onTabClick: function( tab, navigation, index, newindex ) {
                    if ( newindex == index + 1 ) {
                        return this.onNext( tab, navigation, index, newindex);
                    } else if ( newindex > index + 1 ) {
                        return false;
                    } else {
                        return true;
                    }
                },
                onTabShow: function( tab, navigation, index ) {
                    tab.prevAll().addClass('completed');
                    tab.nextAll().removeClass('completed');
                    var $total = navigation.find('li').length;
                    var $current = index+1;
                    // If it's the last tab then hide the last button and show the finish instead
                    if($current >= $total) {
                        $('#wizard').find('.pager .next').hide();
                        $('#wizard').find('.pager .finish').show();
                        $('#wizard').find('.pager .finish').removeClass('disabled');
                    } else {
                        $('#wizard').find('.pager .next').show();
                        $('#wizard').find('.pager .finish').hide();
                    }
                }
            });

            //wizard is finish
            $('#wizard .finish').click(function() {
                //var n = noty({
                //    text: '<i class="fa fa-check"></i> Your finish the wizard!',
                //    type: 'success',
                //    layout: 'topRight',
                //    theme: 'bootstrapTheme',//Current theme
                //    closeWith: ['button'],
                //    timeout: 5000, // MiliSeconds before notification close
                //    animation: {
                //        open: 'animated bounceInRight', // Animate.css class names
                //        close: 'animated bounceOutRight', // Animate.css class names
                //        easing: 'swing', // unavailable - no need
                //        speed: 500 // unavailable - no need
                //    }
                //});  

                Guardar();

            });
        },

        // Wizard with progress bar
        wizardProgress : function () {
            //------------- Wizard with progressbar -------------//
            $('#wizard1').bootstrapWizard({
                tabClass: 'bwizard-steps',
                nextSelector: 'ul.pager li.next',
                previousSelector: 'ul.pager li.previous',
                firstSelector: null,
                lastSelector: null,
                onTabShow: function( tab, navigation, index ) {
                    tab.prevAll().addClass('completed');
                    tab.nextAll().removeClass('completed');
                    var $total = navigation.find('li').length;
                    var $current = index+1;
                    var $percent = ($current/$total) * 100;
                    $('#wizard1').find('.progress-bar').css({width:$percent+'%'});
                    // If it's the last tab then hide the last button and show the finish instead
                    if($current >= $total) {
                        $('#wizard1').find('.pager .next').hide();
                        $('#wizard1').find('.pager .finish').show();
                        $('#wizard1').find('.pager .finish').removeClass('disabled');
                    } else {
                        $('#wizard1').find('.pager .next').show();
                        $('#wizard1').find('.pager .finish').hide();
                    }
                }
            });

            //wizard is finish
            $('#wizard1 .finish').click(function() {
                var n = noty({
                    text: '<i class="fa fa-check"></i> Your finish the wizard!',
                    type: 'success',
                    layout: 'topRight',
                    theme: 'bootstrapTheme',//Current theme
                    closeWith: ['button'],
                    timeout: 5000, // MiliSeconds before notification close
                    animation: {
                        open: 'animated bounceInRight', // Animate.css class names
                        close: 'animated bounceOutRight', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });  
            });
        },

        // Vertical wizard
        verticalWizard : function () {
            $('#wizard2').bootstrapWizard({
                tabClass: 'bwizard-steps',
                nextSelector: 'ul.pager li.next',
                previousSelector: 'ul.pager li.previous',
                firstSelector: null,
                lastSelector: null,
                onTabShow: function( tab, navigation, index ) {
                    tab.prevAll().addClass('completed');
                    tab.nextAll().removeClass('completed');
                    var $total = navigation.find('li').length;
                    var $current = index+1;
                   
                    // If it's the last tab then hide the last button and show the finish instead
                    if($current >= $total) {
                        $('#wizard1').find('.pager .next').hide();
                        $('#wizard1').find('.pager .finish').show();
                        $('#wizard1').find('.pager .finish').removeClass('disabled');
                    } else {
                        $('#wizard1').find('.pager .next').show();
                        $('#wizard1').find('.pager .finish').hide();
                    }
                }
            });

            //wizard is finish
            $('#wizard2 .finish').click(function() {
                var n = noty({
                    text: '<i class="fa fa-check"></i> Your finish the wizard!',
                    type: 'success',
                    layout: 'topRight',
                    theme: 'bootstrapTheme',//Current theme
                    closeWith: ['button'],
                    timeout: 5000, // MiliSeconds before notification close
                    animation: {
                        open: 'animated bounceInRight', // Animate.css class names
                        close: 'animated bounceOutRight', // Animate.css class names
                        easing: 'swing', // unavailable - no need
                        speed: 500 // unavailable - no need
                    }
                });  
            });
        },
        
    }

}();

$(document).ready(function() {    
    formsWizard.wizard(); //Activate wizard
    formsWizard.wizardProgress(); //Activate wizard with progress
    formsWizard.verticalWizard(); //activate vertical wizard
}); 
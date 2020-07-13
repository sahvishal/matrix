(function () {
    'use strict'; 
    
    angular.module(ApplicationConfiguration.applicationModuleName).directive(OnlineConfiguration.directives.userNameValidator, function () {
        return {
            link: function(scope, elm, attrs) {
                elm.bind('keypress', function(evt) { 
                    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
                    if (evt.shiftKey == false) {
                        if ((key >= 48 && key <= 57) || key == 46 || key == 9 || key == 13 || key == 8 || key == 190 || key == 189 || key == 109 || (key >= 65 && key <= 90) || (key >= 97 && key <= 122)) {
                            return true;
                        }
                    } else if (evt.shiftKey == true) {
                        if (key == 45 || key == 189 || key == 95 || (key >= 65 && key <= 90)) {

                            return true;
                        }
                    }
                    evt.preventDefault();
                    return false;

                });
            }
        };
    });
    
}());
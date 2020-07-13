(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive('focusOnInvalid', function () {
        return { 
            restrict: 'A', 
            link: function (scope, elem) {

                // set up event handler on the form element
                elem.on('submit', function () {

                    // find the first invalid element
                     elem.find('.ng-invalid:first').focus(); 
                });
            }
        };
    });
})();

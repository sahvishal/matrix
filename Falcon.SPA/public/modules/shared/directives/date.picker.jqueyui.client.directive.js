(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive("datePickerSimple", ['$timeout', function ($timeout) {

        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                if (typeof (attrs.startdate) === "undefined") {
                    element.datepicker();
                } else {
                    element.datepicker({
                        inline: true,
                        changeYear: true,
                        changeMonth: true,
                        defaultDate: new Date("01/01/1950")
                    });
                }
            }
        };

    }]);
})();
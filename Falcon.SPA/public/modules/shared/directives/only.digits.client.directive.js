(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive('onlyDigits', function () {
        return {
            require: 'ngModel',
            restrict: 'A',
            scope: {
                dmin: '=',
                dmax: '='
            },
            link: function (scope, element, attr, ctrl) {
                //var dmin = attr.dmin;
                //var dmax = attr.dmax;

                function inputValue(val) {
                    if (val) {
                        var digits = val.replace(/[^0-9]/g, '');

                        if (digits !== val) {
                            ctrl.$setViewValue(digits);
                            ctrl.$render();
                        }

                        var num = parseInt(digits, 10);

                        validateRange(num);

                        return num;
                    }
                    else if (val == '') {
                        return '';
                    }
                    return undefined;
                }

                function validateRange(num) {

                    if (scope.dmin != undefined && scope.dmin != null && num < Number(scope.dmin)) {
                        ctrl.$setViewValue('');
                        ctrl.$render();
                    }

                    if (scope.dmax != undefined && scope.dmax != null && num > Number(scope.dmax)) {
                        ctrl.$setViewValue('');
                        ctrl.$render();
                    }
                }

                ctrl.$parsers.push(inputValue);
            }
        };
    });
})();

 
(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive("maskFormat", ['logger', '$timeout', function (logger, $timeout) {

        return {
            restrict: 'A',
            scope: {
                ngModel:"="
            },
            link: function ($scope, element, $attrs) {
                var text = $attrs["maskFormat"];
                switch (text) {
                    case 'date': 
                        element.inputmask({ 'alias': 'mm/dd/yyyy' });
                        break;
                    case 'time12': 
                        element.mask("99:99 aa");
                        element.blur(function () {
                            
                            var val = element.val();
                            if (val != '' && val.length == 8) {
                                var meridian = val.substring(6, 8);
                                if (!(meridian.toUpperCase() == "AM" || meridian.toUpperCase() == "PM")) {
                                    element.val('');
                                    $scope.ngModel = element.val();
                                } 

                                var timePart = val.substring(0, 5);
                                var hhmm = timePart.split(":");
                                if (hhmm.length == 2) {
                                    if (Number(hhmm[0]) > 12 || Number(hhmm[1]) > 60) {
                                        element.val('');
                                        $timeout(function () {
                                            $scope.ngModel = element.val();
                                            logger.showToasterError('Please provide a valid date time.');
                                        }, 0);
                                    }
                                }
                            }
                        });
                        break;
                    case 'time24':
                        element.mask("99:99");
                        break;
                    case 'phone':
                        element.mask("(999) 999-9999");
                        break;
                    case 'phone-ext':
                        element.mask("(999) 999-9999? x99999");
                        break;
                    case 'phone-int':
                        element.mask("+33 999 999 999");
                        break;
                    case 'decimal':
                        element.inputmask({ 'alias': 'numeric', 'groupSeparator': '', 'autoGroup': true, 'digits': 2, rightAlign: false, 'placeholder': '0' });
                        break;
                    case 'decimal-single':
                        element.inputmask({'mask':'9{1,6}.9{1}', 'alias': 'decimal', 'autoGroup': true, 'digits':1, 'digitsOptional': false, rightAlign: false, 'placeholder': '0' });
                        break;
                    case 'currency-special':
                        element.inputmask({ 'mask': '9{1,4}.9{2}', 'alias': 'decimal', 'autoGroup': true, 'digits': 2, 'digitsOptional': false, rightAlign: false, 'placeholder': '0' });
                        break;
                    case 'currency':
                        element.inputmask({ 'alias': 'numeric', 'groupSeparator': '', 'autoGroup': true, 'digits': 2, 'digitsOptional': false, 'placeholder': '0' });
                        break;
                    default:
                        break;
                }
            }
        };
    }]);
})();
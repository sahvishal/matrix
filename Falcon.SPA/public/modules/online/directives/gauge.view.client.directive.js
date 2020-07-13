(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.gaugeView, function () {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/event/gauge.client.view.html',
            scope: {
                availableSlots: '=',
                totalSlots: '='
            },
            link: function (scope, elem, attr) {
                scope.CalculatePendingSlotsPercentage = function () {
                    if ("undefined" === typeof scope.availableSlots || scope.availableSlots <= 0 || "undefined" === typeof scope.totalSlots || scope.totalSlots <= 0) {
                        return "gauge-0";
                    } else {
                        var remainingPercentage = scope.roundDownToMultiple(((scope.availableSlots / scope.totalSlots) * 100), 10);

                        return "gauge-" + (100 - remainingPercentage);
                    }
                };

                scope.roundDownToMultiple = function (number, multiple) {
                    return number - (number % multiple);
                }
            }
        };
    });
}());
(function () {
    'use strict';
    //todo: this is very specific to Trip Edit/Create screen
    angular.module(ApplicationConfiguration.applicationModuleName).directive("datePickerMultipleTextbox", ['$timeout', function ($timeout) {

        return {
            restrict: 'E',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/shared/views/date.picker.multiple.textbox.html',
            scope: {
                model: '='
            },
            link: function (scope, element, attrs) {

                scope.opened = false;

                scope.format = 'MM/dd/yyyy';
                scope.currentDate = moment(new Date());
                scope.currentYear = scope.currentDate.format("YY");

                while (scope.$$phase) {
                }


                scope.open = function ($event) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    scope.opened = true;
                };

                scope.changeDate = function () {
                    var year = Number(scope.date.Year);

                    if (year > Number(scope.currentYear))
                        year = year + 1900;
                    else
                        year = year + 2000;

                    scope.model = scope.date.Month + "/" + scope.date.Day + "/" + year;
                };

                scope.$watch("model", function (newVal) {
                    var momentDate = moment(newVal);

                    scope.date = {
                        Month: momentDate.format("MM"),
                        Day: momentDate.format("DD"),
                        Year: momentDate.format("YY")
                    };
                });

            }
        };

    }]);
})();
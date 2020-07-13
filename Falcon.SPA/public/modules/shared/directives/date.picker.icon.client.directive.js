﻿(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive("datePickerIcon", ['$timeout', function ($timeout) {

        return {
            restrict: 'E',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl +  'public/modules/shared/views/date.picker.icon.html',
            scope: {
                model: '='
            },
            link: function(scope, element, attrs) {

                while (scope.$$phase) {
                }

                scope.opened = false;

                scope.format = 'MM/dd/yyyy';

                scope.open = function($event) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    scope.opened = true;
                };
            }
        };

    }]);
})();
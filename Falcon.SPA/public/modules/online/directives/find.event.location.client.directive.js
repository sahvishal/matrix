(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive(OnlineConfiguration.directives.eventLocation, function () {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/shared/find-event-location.client.view.html',
            scope: {
                address: '=',
                text: '='
            },
            link: function (scope, elem, attr) {
                scope.GetMapUrl = function () {
                    if (typeof (scope.address) != 'undefined') {
                        var mapLocation = scope.address.StreetAddressLine1 + " " + scope.address.City + " " + scope.address.State + " " + scope.address.Country + " " + scope.address.ZipCode;
                        return "http://maps.google.com/maps?f=q&hl=en&geocode=&ie=UTF8&z=16&q=" + mapLocation;
                    }
                    return '';
                };
            }
        };
    });
}());
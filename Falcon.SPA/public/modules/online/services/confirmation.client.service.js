(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.confirmationService, ['onlineHttpWrapper', '$http', '$q', function (onlineHttpWrapper, $http, $q) {
        var confirmationService = {};

        confirmationService.get = function (guid) {
            var endpoint = 'Scheduling/OnlineConfirmation/GetAppointmentConfirmation?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };
       
        return confirmationService;
    }]);
}());


(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.upsellTestService, ['onlineHttpWrapper', function (onlineHttpWrapper) {
        var upsellService = {};

        upsellService.get = function (guid) {
            var endpoint = 'Scheduling/OnlinePackage/GetUpsellTest?Guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        upsellService.post = function (data) {
            var endpoint = 'Scheduling/OnlinePackage/PostUpsellTest';
            return onlineHttpWrapper.post(endpoint, data);
        };

        return upsellService;

    }]);
}());
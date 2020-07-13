(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.shippingService, ['onlineHttpWrapper', function (onlineHttpWrapper) {
        var shippingService = {};

        var getPropertyValue = function (propterty) {
            if (typeof propterty === "undefined" || propterty === "null" || propterty === "")
                return "";
            return propterty;
        };

        shippingService.GetShippingOption = function (guid) {
            var endpoint = 'Marketing/OnlinePackage/GetShippingOption?Guid=' + getPropertyValue(guid);
            return onlineHttpWrapper.get(endpoint);
        };

        shippingService.saveSelectedShippingOption = function (data) {
            var endpoint = 'Marketing/OnlinePackage/SaveSelectedShippingOption';

            return onlineHttpWrapper.post(endpoint, data);
        };

        return shippingService;
    }]);

}());


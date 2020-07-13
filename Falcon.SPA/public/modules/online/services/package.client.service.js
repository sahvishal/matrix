(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.packageService, ['onlineHttpWrapper',   function (onlineHttpWrapper) {
        var packageService = {};

        var getPropertyValue = function (propterty) {
            if (typeof propterty === "undefined" || propterty === "null" || propterty === "")
                return "";
            return propterty;
        };
         
        packageService.get = function (guid) {
            var endpoint = 'Scheduling/OnlinePackage/GetEventPackageList?Guid=' + getPropertyValue(guid);
            return onlineHttpWrapper.get(endpoint);
        }; 

        packageService.post = function (guid, selectedEventPackageId) {
            var endpoint = 'Scheduling/OnlinePackage/SaveSelectedPackage?guid=' + getPropertyValue(guid) + '&selectedEventPackageId=' + getPropertyValue(selectedEventPackageId);
            return onlineHttpWrapper.post(endpoint);
        };

        return packageService;
    }]);

}());


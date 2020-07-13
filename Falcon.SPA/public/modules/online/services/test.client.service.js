(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.testService, ['onlineHttpWrapper',  function (onlineHttpWrapper) {
        var testService = {};

        var getPropertyValue = function (propterty) {
            if (typeof propterty === "undefined" || propterty === "null" || propterty === "")
                return "";
            return propterty;
        };
         
        testService.GetAdditionalTest = function (guid) { 
            var endpoint = 'Marketing/OnlinePackage/GetAdditionalTest?Guid=' + getPropertyValue(guid);
            return onlineHttpWrapper.get(endpoint);
        }; 
         
        testService.saveSelectedtest = function (data) {
           
            var endpoint = 'Marketing/OnlinePackage/SaveSelectedTest';

            return onlineHttpWrapper.post(endpoint, data);
        };

        return testService;
    }]);

}());


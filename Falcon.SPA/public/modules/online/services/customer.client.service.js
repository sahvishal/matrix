(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.customerService, ['onlineHttpWrapper', 'httpWrapper', '$http', '$q', function (onlineHttpWrapper, httpWrapper, $http, $q) {
        var customerService = {}; 

        var getPropertyValue = function (propterty) {
            if (typeof propterty === "undefined" || propterty === "null" || propterty === "")
                return "";
            return propterty;
        };
         
        customerService.GetCustomerInfo = function (guid) {
            var endpoint = 'Scheduling/OnlineCustomer/GetCustomerInfo?guid=' + guid;
            return  onlineHttpWrapper.get(endpoint);
        };
        customerService.UpdateCartwithReturningCustomer = function (guid, customerId) {
            var endpoint = 'Scheduling/OnlineCustomer/UpdateCartwithReturningCustomer?guid=' + guid + '&customerId=' + customerId;
            return onlineHttpWrapper.get(endpoint);
        };
        customerService.registerCustomer = function (guid, customerEditModel) {
            var endpoint = 'Scheduling/OnlineCustomer/RegisterCustomer?guid=' + guid;
            return onlineHttpWrapper.post(endpoint, customerEditModel);
        };
        //customerService.SaveProspectCustomerAndUpdateCart = function (guid, prospectCustomerEditModel) {
        //    var endpoint = 'Scheduling/OnlineCustomer/SaveProspectCustomerAndUpdateCart?guid=' + guid;
        //    return onlineHttpWrapper.post(endpoint, prospectCustomerEditModel);
        //};
        
        customerService.SaveProspectCustomerAndUpdateCart = function (guid, prospectCustomerEditModel) {
            var api = ApplicationConfiguration.remoteServiceUrl;
            var endpoint = api + 'Scheduling/OnlineCustomer/SaveProspectCustomerAndUpdateCart?guid=' + guid;
            var deffered = $q.defer();
            $http.post(endpoint, prospectCustomerEditModel).then(function (res) {
                deffered.resolve(res.data);
            });

            return deffered.promise;
        };
        customerService.ValidateUser = function ( loginModel,guid) {
            var endpoint = 'Users/OnlineLogin/ValidateUser?guid='+ guid;
            return httpWrapper.post({ url: endpoint, data: loginModel });
        };
        customerService.checkUserNameAvailability = function (userName) {
            var endpoint = 'Scheduling/OnlineCustomer/CheckUserNameAvailability?userName=' + userName;
            return onlineHttpWrapper.get(endpoint);
        };

        return customerService;
    }]);

}());


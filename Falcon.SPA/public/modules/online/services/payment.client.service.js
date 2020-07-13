(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.paymentService, ['onlineHttpWrapper', 'httpWrapper', function (onlineHttpWrapper, httpWrapper) {
        var paymentService = {}; 

        var getPropertyValue = function (propterty) {
            if (typeof propterty === "undefined" || propterty === "null" || propterty === "")
                return "";
            return propterty;
        };
         
        paymentService.GetPaymentInfo = function (guid) {
            var endpoint = 'Finance/OnlinePayment/GetPaymentInfo?guid=' + guid;
            return  onlineHttpWrapper.get(endpoint);
        };
        
        paymentService.SavePaymentInfo = function (sourceCodeApplyEditModel) {
            var endpoint = 'Finance/OnlinePayment/SavePaymentInfo';
            return onlineHttpWrapper.post(endpoint, sourceCodeApplyEditModel);
        };

        
        paymentService.applyGiftCertificate = function (code) {
            var endpoint = 'Finance/OnlinePayment/ApplyGiftCertificate?claimCode=' + code;
            return httpWrapper.post({ url: endpoint });
        };
        paymentService.ApplySourceCode = function (guid, sourceCodeApplyEditModel) {
            var endpoint = 'Finance/OnlinePayment/ApplySourceCode?guid='  + guid;
            return onlineHttpWrapper.post( endpoint, sourceCodeApplyEditModel);
        };
        
        return paymentService;
    }]);

}());


(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.customerPaymentDetail, [function () {

        return {
            restrict: 'E',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/shared/customer.order.payment.client.view.html',
        };
    }]);
}());
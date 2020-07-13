(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.customerOrderDetail, [function () {

        return {
            restrict: 'E',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/shared/customer.order.detail.client.view.html',
        };
    }]);
}());
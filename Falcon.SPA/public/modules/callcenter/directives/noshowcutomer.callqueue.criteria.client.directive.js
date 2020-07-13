(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.noShowCriteriaView, [function () {

        return {
            restrict: 'E',
            scope: {
                model: '=',
                notifyParent: '&method'
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/noshowcustomer/noshowcustomer.criteria.view.client.html'
        };
    }]);
}());
(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.healthplanFillEventCriteriaView, [function () {

        return {
            restrict: 'E',
            scope: {
                model: '='
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplanevents/healthplan.event.criteria.view.client.html'
        };
    }]);
}());
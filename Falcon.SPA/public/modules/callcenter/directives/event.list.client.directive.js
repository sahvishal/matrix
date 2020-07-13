(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.eventlist, [function () {

        return {
            restrict: 'E',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/contact/event.list.client.view.html',
        };
    }]);
}());
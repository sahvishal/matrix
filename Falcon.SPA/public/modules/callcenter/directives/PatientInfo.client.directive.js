(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.patientInfo, [function () {

        return {
            restrict: 'E',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/contact/patientInfo.client.view.html',
        }
    }]);
}());
(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.hafChildCheckbox, function () {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/healthassessment/haf.child.checkbox.client.view.html',
        };
    });
}());
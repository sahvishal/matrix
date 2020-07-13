(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.hafParentTextbox, function () {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/healthassessment/haf.parent.textbox.client.view.html',
        };
    });
}());
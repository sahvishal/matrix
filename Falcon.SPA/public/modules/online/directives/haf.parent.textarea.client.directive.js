(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.hafParentTextarea, function () {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/healthassessment/haf.parent.textarea.client.view.html',
        };
    });
}());
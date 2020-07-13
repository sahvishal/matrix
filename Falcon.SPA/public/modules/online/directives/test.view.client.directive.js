(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.testBox, function () {
        return {
            restrict: 'AE',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/test/testBox.client.view.html'
        };
    });
}());
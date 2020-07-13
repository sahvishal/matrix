(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.quantcast, function () {
        return {
            restrict: 'AE',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/quantcast/quantcast.client.view.html',
            scope: {
                name1: "=",
                name2: "="
            }
        };
    });
}());
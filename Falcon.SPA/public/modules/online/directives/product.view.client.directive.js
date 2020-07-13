(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.productBox, function () {
        return {
            restrict: 'AE',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/shipping/productBox.client.view.html'
        };
    });
}());
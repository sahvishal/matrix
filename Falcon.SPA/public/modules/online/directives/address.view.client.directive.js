(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive(OnlineConfiguration.directives.addressView, function () {
        return {
            restrict: 'AE',
            replace:true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/shared/address.client.view.html',
            scope: {
                address: '='
            }
        };
    });
}());
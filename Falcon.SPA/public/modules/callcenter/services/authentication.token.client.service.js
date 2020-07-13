(function () {
    'use strict';
    angular.module(CallCenterConfiguration.moduleName).service(CallCenterConfiguration.services.authenticationTokenService,
        ['$stateParams', '$localStorage', function (stateParams, localStorage) {
            return {
                get: function () {
                    return {
                        token: window.localStorage.token
                    };
                },

                set: function (urlObject) {
                    localStorage.$reset();
                    localStorage.$default({
                        token: urlObject.token
                    });
                }
            };
        }
        ]);
}());
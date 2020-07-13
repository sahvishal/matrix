'use strict';

//Start by defining the main module and adding the module dependencies
var app = angular.module(ApplicationConfiguration.applicationModuleName, ApplicationConfiguration.applicationModuleVendorDependencies);

//todo: move into module.core.factory
app.config([
    "$httpProvider", function ($httpProvider) {
        $httpProvider.interceptors.push('customInterceptor');
    }
]);

app.config(['$compileProvider', '$stateProvider', '$urlRouterProvider', function ($compileProvider, $stateProvider, $urlRouterProvider) {
    $compileProvider.debugInfoEnabled(false);
    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|Glocom|glocom):/);
}]);

app.run(['$rootScope', '$state', '$stateParams', function ($rootScope, $state, $stateParams) {
    $rootScope.domainUrl = ApplicationConfiguration.domainUrl;
}]);

//todo: move into module.core.factory
app.factory("customInterceptor", function () {
    return {
        request: function (cfg) {
            cfg.headers['ApplicationIdentity'] = ApplicationConfiguration.applicationIdentity;
            cfg.headers['Cache-Control'] = "no-cache, no-store, must-revalidate";
            return cfg;
        }
    };
});

//Then define the init function for starting up the application
angular.element(document).ready(function () {
    //Then init the app
    angular.bootstrap(document, [ApplicationConfiguration.applicationModuleName]);

});



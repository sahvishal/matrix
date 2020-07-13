'use strict';

var ApplicationConfiguration = (function () {
    var applicationModuleName = "falcon";
   
    var applicationModuleVendorDependencies = ['ngResource', 'ngCookies', 'ngSanitize', 'ui.router', 'ui.bootstrap', 'ngStorage', 'angularSpinner', 'ngPercentDisplay', 'ui.select'];//'ui.multiselect',

    var applicationIdentity = ''; //set value inside the ui project web.config
    var remoteServiceUrl = '';//set value inside the ui project web.config
    var domainUrl = "";
    var phoneTollFree = "855-755-8378";
    var companyName = "ABC Screenings";
    var minimumAgeForScreening = 18;
    var siteUrl = "";
    var appUrl = "";
    
    var registerModule = function (moduleName, dependencies) {

        //Create angular module
        angular.module(moduleName, dependencies || []);
        //debugger;
        // Add the module to the AngularJS configuration file
        angular.module(applicationModuleName).requires.push(moduleName);
       
    };
    return {
        applicationModuleName: applicationModuleName,
        applicationModuleVendorDependencies: applicationModuleVendorDependencies,
        registerModule: registerModule,
        applicationIdentity: applicationIdentity,
        remoteServiceUrl: remoteServiceUrl,
        domainUrl: domainUrl,
        phoneTollFree: phoneTollFree,
        minimumAgeForScreening: minimumAgeForScreening,
        companyName: companyName,
        siteUrl: siteUrl,
        appUrl: appUrl
};
}());

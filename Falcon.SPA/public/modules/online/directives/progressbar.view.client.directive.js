(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive(OnlineConfiguration.directives.progressbarView, [OnlineConfiguration.services.progressbarService, CoreConfiguration.constants, function (progressbarService, constants) {
        return {
            restrict: 'AE',
            replace: false,
            scope: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/shared/progressbar.client.view.html',
            controller: ['$scope', '$rootScope', function (scope, $rootScope) {
                scope.constants = constants.ProgressBarStatus;
                scope.ProgressBarSteps = constants.ProgressBarSteps;
                scope.checkLocation = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.checkLocationSelected(scope.data.RequestValidationModel.TempCart);
                    }
                    return scope.constants.NotStarted;

                };
                
                scope.checkPreQualificationStatus = function () {
                    
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.checkPreQualificationStatus(scope.data.RequestValidationModel.TempCart);
                    }
                    return scope.constants.NotStarted;
                };
                
                scope.checkPackagesStatus = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.checkPackagesStatus(scope.data.RequestValidationModel.TempCart);
                    }
                    return scope.constants.NotStarted;
                };

                scope.checkTestStatus = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.checkTestStatus(scope.data.RequestValidationModel.TempCart);
                    }
                    return scope.constants.NotStarted;
                };
                
                scope.checkAppointmentStatus = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.checkAppointmentStatus(scope.data.RequestValidationModel.TempCart);
                    }
                    return scope.constants.NotStarted;
                };
                
                scope.checkPersonalInformationStatus = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.checkPersonalInformationStatus(scope.data.RequestValidationModel.TempCart);
                    }
                    return scope.constants.NotStarted;
                };
                
                scope.checkPaymentStatus = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.checkPaymentStatus(scope.data.RequestValidationModel.TempCart);
                    }
                    return scope.constants.NotStarted;
                };
               

                scope.ProgressbarInPercentage = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.ProgressInValue(scope.data.RequestValidationModel.TempCart, scope.data.RequestValidationModel.CaptureOnlineHaf) + "%";
                    }
                    return 0;
                };

                scope.ProgressbarInValue = function () {
                    if ("undefined" != typeof scope.data.RequestValidationModel) {
                        return progressbarService.ProgressInValue(scope.data.RequestValidationModel.TempCart, scope.data.RequestValidationModel.CaptureOnlineHaf);
                    }
                    return 0;
                };

                scope.showHideProgressBar = function() {
                    $rootScope.showProgressBar = !$rootScope.showProgressBar;
                    if ($rootScope.showProgressBar) {
                        $rootScope.showsummarybox = false;
                    }
                };
            }]

        };
    }]);
}());

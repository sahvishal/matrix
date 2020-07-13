(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).service(OnlineConfiguration.services.progressbarService, [OnlineConfiguration.services.localStorageProgressBarService, CoreConfiguration.constants, function (localStorageService, constants) {
        var progressService = {};

        var progressStatus = function(guid) {
          return  localStorageService.getProgessStatus(guid);
        };

        progressService.checkLocationSelected = function (tempCart) {
            var status = constants.ProgressBarStatus.Started;
            if (typeof tempCart != 'undefined' && tempCart != null && progressStatus(tempCart.Guid)) {
                status = constants.ProgressBarStatus.Complete;
            }

            return status;
        };

        progressService.checkPreQualificationStatus = function (tempCart) {
            var status = constants.ProgressBarStatus.NotStarted;

            if (tempCart === null || typeof tempCart === 'undefined') {
                status = constants.ProgressBarStatus.NotStarted;
            } else if (progressStatus(tempCart.Guid).RiskAssessment === constants.ProgressBarStatus.Started) {
                status = constants.ProgressBarStatus.Started;
            } else if (progressStatus(tempCart.Guid).RiskAssessment === constants.ProgressBarStatus.Complete) {
                status = constants.ProgressBarStatus.Complete;
            }

            return status;
        };
        
        progressService.checkPackagesStatus = function (tempCart) {
            var status = constants.ProgressBarStatus.NotStarted;

            if (tempCart === null || typeof tempCart === 'undefined') {
                status = constants.ProgressBarStatus.NotStarted;
            } else if (progressStatus(tempCart.Guid).PackagesTest === constants.ProgressBarStatus.Started) {
                status = constants.ProgressBarStatus.Started;
            } else if (progressStatus(tempCart.Guid).PackagesTest === constants.ProgressBarStatus.Complete) {
                status = constants.ProgressBarStatus.Complete;
            }

            return status;
        };
                
        progressService.checkAppointmentStatus = function (tempCart) {
            var status = constants.ProgressBarStatus.NotStarted;

            if ((tempCart === null || typeof tempCart === 'undefined')) {
                status = constants.ProgressBarStatus.NotStarted;
            } else if (progressStatus(tempCart.Guid).Appointment === constants.ProgressBarStatus.Started) {
                status = constants.ProgressBarStatus.Started;
            } else if (progressStatus(tempCart.Guid).Appointment === constants.ProgressBarStatus.Complete) {
                status = constants.ProgressBarStatus.Complete;
            }

            return status;
        };
        
        progressService.checkPersonalInformationStatus = function (tempCart) {
            var status = constants.ProgressBarStatus.NotStarted;

            if (tempCart === null || typeof tempCart === 'undefined' || tempCart.Id < 0) {
                status = constants.ProgressBarStatus.NotStarted;
            }
            else if (progressStatus(tempCart.Guid).InfoPayment === constants.ProgressBarStatus.Started) {
                status = constants.ProgressBarStatus.Started;               
            }
            else if (progressStatus(tempCart.Guid).InfoPayment === constants.ProgressBarStatus.Complete) {
                status = constants.ProgressBarStatus.Complete;
            }

            return status;
        };       

        progressService.ProgressInValue = function (tempCart) {
            var percentage = 0;

            if (typeof tempCart === 'undefined' || tempCart === null) return percentage;

            if (progressStatus(tempCart.Guid).Location === constants.ProgressBarStatus.Complete) {
                percentage = percentage + 20;
            }
            if (progressStatus(tempCart.Guid).RiskAssessment === constants.ProgressBarStatus.Complete) {
                percentage = percentage + 20;
            }
            if (progressStatus(tempCart.Guid).PackagesTest === constants.ProgressBarStatus.Complete) {
                percentage = percentage + 20;
            }
            if (progressStatus(tempCart.Guid).Appointment === constants.ProgressBarStatus.Complete) {
                percentage = percentage + 20;
            }
            if (progressStatus(tempCart.Guid).InfoPayment === constants.ProgressBarStatus.Complete) {
                percentage = percentage + 20;
            }

            return percentage;
        };

        return progressService;
    }]);
}());
(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.localStorageProgressBarService, [function () {
        var localStorageService = {};


        var progressBarStatus = function (guid) {
            var progressBarObject = window.localStorage.getItem(guid);

            if (typeof (progressBarObject) === 'undefined' || progressBarObject === null) {
                if (typeof (guid) != "undefined" && guid != null && guid != "null") {
                    var oldGuid = window.localStorage.getItem("online-guid");
                    if (typeof (oldGuid) != "undefined" && oldGuid != null) {
                        window.localStorage.removeItem(oldGuid);
                        window.localStorage.removeItem("online-guid");
                    }
                    window.localStorage.setItem("online-guid", guid);
                }

                var defaultObject = {
                    Location: 2,
                    RiskAssessment: 1,
                    PackagesTest: 1,
                    Appointment: 1,
                    InfoPayment: 1,
                    Payment: 1
                };

                if (typeof (guid) === 'undefined' || guid === null || guid === "null") return defaultObject;

                localStorageService.setProgressState(guid, defaultObject);

                return defaultObject;
            }
            return JSON.parse(progressBarObject);
        };

        localStorageService.getProgessStatus = function (guid) {
            return progressBarStatus(guid);
        };

        localStorageService.setProgressState = function (guid, progressStateObject) {
            if (typeof (guid) === 'undefined' || guid === null || guid === "null") return;
            window.localStorage.setItem(guid, JSON.stringify(progressStateObject));
        };

        localStorageService.UpdateLocation = function (guid, status) {
            var currentStatus = progressBarStatus(guid);

            if (currentStatus.Location < status) {
                currentStatus.Location = status;
            }

            localStorageService.setProgressState(guid, currentStatus);
        };

        localStorageService.RiskAssessment = function (guid, status) {
            var currentStatus = progressBarStatus(guid);

            if (currentStatus.RiskAssessment < status) {
                currentStatus.RiskAssessment = status;
            }

            localStorageService.setProgressState(guid, currentStatus);
        };

        localStorageService.PackagesTest = function (guid, status) {
            var currentStatus = progressBarStatus(guid);

            if (currentStatus.PackagesTest < status) {
                currentStatus.PackagesTest = status;
            }

            localStorageService.setProgressState(guid, currentStatus);
        };

        localStorageService.Appointment = function (guid, status) {
            var currentStatus = progressBarStatus(guid);

            if (currentStatus.Appointment < status) {
                currentStatus.Appointment = status;
            }

            localStorageService.setProgressState(guid, currentStatus);
        };

        localStorageService.InfoPayment = function (guid, status) {
            var currentStatus = progressBarStatus(guid);

            if (currentStatus.InfoPayment < status) {
                currentStatus.InfoPayment = status;
            }

            localStorageService.setProgressState(guid, currentStatus);
        };

        localStorageService.Payment = function (guid, status) {
            var currentStatus = progressBarStatus(guid);

            if (currentStatus.Payment < status) {
                currentStatus.Payment = status;
            }

            localStorageService.setProgressState(guid, currentStatus);
        };

        localStorageService.ResetProgressBar = function(guid) {
            var defaultObject = {
                Location: 2,
                RiskAssessment: 1,
                PackagesTest: 1,
                Appointment: 1,
                InfoPayment: 1,
                Payment: 1
            };
            localStorageService.setProgressState(guid, defaultObject);
        };

        return localStorageService;
    }]);

}());


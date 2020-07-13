(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.preQualificationService, ['onlineHttpWrapper', function (onlineHttpWrapper) {
        var prequalificationService = {};

        prequalificationService.SavePreQualificationAnswer = function (answer) {
            var endpoint = 'Scheduling/OnlineEvent/SavePreQualificationAnswer';
            return onlineHttpWrapper.post(endpoint, answer);
        };

        prequalificationService.GetPreQualificationAnswer = function (guid) {
            var endpoint = 'Scheduling/OnlineEvent/GetPreQualificationAnswer?Guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        prequalificationService.GetOrderSummary = function (guid) {
            var endpoint = 'Scheduling/OnlineEvent/GetOnlineSummaryModel?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        prequalificationService.UpdateUserPrefrenceWithPrequalificationQuestion = function (guid) {
            var endpoint = 'Scheduling/OnlineEvent/UpdateUserPrefrenceWithPrequalificationQuestion?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        prequalificationService.UpdateUserPrefrenceSkip = function (guid) {
            var endpoint = 'Scheduling/OnlineEvent/UpdateUserPrefrenceSkip?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        return prequalificationService;
    }]);

}());


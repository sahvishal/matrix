(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).factory(CallCenterConfiguration.services.callQueueCriteriaSerivce, ['httpWrapper', function (httpWrapper) {
        var criteriaSerivce = {};

        criteriaSerivce.GetSystemGeneratedCallQueueCriteria = function (callQueueId) {
            var endpoint = 'CallCenter/CallQueue/GetSystemGeneratedCallQueueCriteria?callQueueId=' + callQueueId;
            return httpWrapper.get({ url: endpoint });
        };

        criteriaSerivce.UpdateFillEventQueueCriteria = function (model) {
            var endpoint = 'CallCenter/CallQueue/UpdateFillEventQueueCriteria';
            return httpWrapper.post({ url: endpoint, data: model });
        };
        criteriaSerivce.UpdateUpsellQueueCriteria = function (model) {
            var endpoint = 'CallCenter/CallQueue/UpdateUpsellQueueCriteria';
            return httpWrapper.post({ url: endpoint, data: model });
        };
        criteriaSerivce.UpdateConfirmationQueueCriteria = function (model) {
            var endpoint = 'CallCenter/CallQueue/UpdateConfirmationQueueCriteria';
            return httpWrapper.post({ url: endpoint, data: model });
        };
        
        return criteriaSerivce;
    }]);
}());


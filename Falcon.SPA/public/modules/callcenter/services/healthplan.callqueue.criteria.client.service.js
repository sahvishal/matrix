(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).factory(CallCenterConfiguration.services.healthPlanCallQueueCriteriaSerivce, ['httpWrapper', function (httpWrapper) {
        var criteriaSerivce = {};

        criteriaSerivce.GetSystemGeneratedCallQueueCriteria = function (callQueueId, healthPlanId, criteriaId, campaignId) {
            
            var endpoint = 'CallCenter/HealthPlanCriteria/GetHealthGeneratedCallQueueCriteria?callQueueId=' + callQueueId + "&healthPlanId=" + healthPlanId + "&criteriaId=" + criteriaId + "&campaignId=" + campaignId;
            return httpWrapper.get({ url: endpoint });
        };

        criteriaSerivce.UpdateCallRoundQueueCriteria = function (model) {
            var endpoint = 'CallCenter/HealthPlanCriteria/UpdateCallRoundQueueCriteria';
            return httpWrapper.post({ url: endpoint, data: model });
        };
        criteriaSerivce.UpdateFillEventCriteria = function (model) {
            var endpoint = 'CallCenter/HealthPlanCriteria/UpdateFillEventCriteria';
            return httpWrapper.post({ url: endpoint, data: model });
        };

        criteriaSerivce.UpdateNoShowCustomerCriteria = function (model) {
            var endpoint = 'CallCenter/HealthPlanCriteria/UpdateNoShowCustomerCriteria';
            return httpWrapper.post({ url: endpoint, data: model });
        };
        
        criteriaSerivce.UpdateZipRadiusCustomerCriteria = function (model) {
            var endpoint = 'CallCenter/HealthPlanCriteria/UpdateZipRadiusCustomerCriteria';
            return httpWrapper.post({ url: endpoint, data: model });
        };
        
        criteriaSerivce.UpdateUncontactedCustomerQueueCriteria = function (model) {
            var endpoint = 'CallCenter/HealthPlanCriteria/UncontactedCustomerQueue';
            return httpWrapper.post({ url: endpoint, data: model });
        };
       
        return criteriaSerivce;
    }]);
}());


(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).factory(CallCenterConfiguration.services.searchHealthPlanService, ["httpWrapper", function (httpWrapper) {
        var healthPlanService = {};

        var getPropertyValue = function (property) {

            if (typeof property === "undefined" || property === null || property === "null" || property === "")
                return "";
            return property;
        };

        var getUnFormatedPhoneNumber = function (phoneNumber) {
            if (phoneNumber != '' && phoneNumber != undefined) {
                phoneNumber = phoneNumber.replace("(", "");
                phoneNumber = phoneNumber.replace(")", "");
                phoneNumber = phoneNumber.replace(" ", "");
                phoneNumber = phoneNumber.replace(/_/gi, "");
                phoneNumber = phoneNumber.replace(/-/gi, "");
            }

            return phoneNumber;
        };

        var getPropertyNumberic = function (property) {
            if (typeof property === "undefined" || property === "null" || property === "" || property === 0)
                return "";
            return property;
        };

        healthPlanService.GetSelectedCategory = function (callQueueId) {
            var endpoint = 'CallCenter/CallQueue/GetCallQueueById?callQueueId=' + callQueueId;
            return httpWrapper.get({ url: endpoint });
        };

        //healthPlanService.GetHealthPlanDropDown = function () {
        //    var endpoint = 'CallCenter/HealthPlanCallQueue/GetHealthPlanDropDown';
        //    return httpWrapper.get({ url: endpoint });
        //};

        //healthPlanService.GetCallQueueCategories = function () {
        //    var endpoint = 'CallCenter/HealthPlanCallQueue/GetHealthPlanCallQueueCategories';
        //    return httpWrapper.get({ url: endpoint });
        //};

        healthPlanService.GetOutboundCallQueue = function (req) {
            var endpoint = 'CallCenter/HealthPlanCallQueue/GetOutboundCallQueue?CallQueueId=' + getPropertyValue(req.CallQueueId) + "&ZipCode=" + getPropertyValue(req.ZipCode) + '&Radius=' + getPropertyValue(req.Radius);
            endpoint = endpoint + '&PageNumber=' + getPropertyValue(req.PageNumber) + '&EventId=' + getPropertyNumberic(req.EventId);
            endpoint = endpoint + '&CustomCorporateTag=' + getPropertyValue(req.CustomCorporateTag) + '&HealthPlanId=' + getPropertyNumberic(req.HealthPlanId) + "&UseCustomTagExclusively=" + req.UseCustomTagExclusively;
            endpoint = endpoint + '&CriteriaId=' + getPropertyNumberic(req.CriteriaId) + '&CampaignId=' + getPropertyNumberic(req.CampaignId) + '&DirectMailDate=' + getPropertyValue(req.DirectMailDate);
            endpoint = endpoint + '&DirectMailStartDate=' + getPropertyValue(req.DirectMailStartDate) + '&DirectMailEndDate=' + getPropertyValue(req.DirectMailEndDate) + '&DirectMailDate=' + getPropertyValue(req.DirectMailDate);

            return httpWrapper.get({ url: endpoint });
        };

        healthPlanService.GetOutboundEventList = function (req) {
            var endpoint = 'CallCenter/HealthPlanCallQueue/GetEventsForFillEventHealthPlan?CallQueueId=' + getPropertyValue(req.CallQueueId);
            endpoint = endpoint + '&PageNumber=' + getPropertyValue(req.PageNumber) + '&EventId=' + getPropertyValue(req.EventId) + '&Pod=' + getPropertyValue(req.Pod);
            endpoint = endpoint + "&HealthPlanId=" + getPropertyNumberic(req.HealthPlanId) + '&CustomCorporateTag=' + req.CustomCorporateTag + '&CriteriaId=' + getPropertyNumberic(req.CriteriaId);

            return httpWrapper.get({ url: endpoint });
        };

        healthPlanService.GetOutboundCampaignList = function (req) {
            var endpoint = 'CallCenter/HealthPlanCallQueue/GetCampaignHealthPlan?CallQueueId=' + getPropertyValue(req.CallQueueId);
            endpoint = endpoint + '&PageNumber=' + getPropertyValue(req.PageNumber) + '&EventId=' + getPropertyValue(req.CampaignId);
            endpoint = endpoint + "&HealthPlanId=" + getPropertyNumberic(req.HealthPlanId) + '&CustomCorporateTag=' + req.CustomCorporateTag;
            endpoint = endpoint + "&StartDate=" + getPropertyValue(req.StartDate) + '&EndDate=' + getPropertyValue(req.EndDate);
            return httpWrapper.get({ url: endpoint });
        };

        healthPlanService.GetDirectMailDates = function (campaignId) {
            var endpoint = 'CallCenter/HealthPlanCallQueue/DirectMailDates?campaignId=' + campaignId;
            return httpWrapper.get({ url: endpoint });
        };

        healthPlanService.CallCenterAgentDashBoardData = function(filter, pageNumber) {
            var endpoint = 'CallCenter/HealthPlanCallQueue/GetCallAgentSpecificQueuesData?HealthPlanId=' + getPropertyValue(filter.HealthPlanId) + '&CallQueueId=' + getPropertyValue(filter.CallQueueId) + '&pageNumber=' + getPropertyValue(pageNumber);
            return httpWrapper.get({ url: endpoint });
        };

        healthPlanService.ViewAvailableCustomerForFillEvent = function(filter) {
            var endpoint = 'CallCenter/HealthPlanCallQueue/GetAvailableCustomer';
            return httpWrapper.post({ url: endpoint, data: filter });
        };
        return healthPlanService;
    }]);
}());


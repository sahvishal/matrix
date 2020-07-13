(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).factory(CallCenterConfiguration.services.healthplanlocalstorage, [function () {
        var localSession = {};

        var getPropertyValue = function (propterty) {
            if (typeof propterty === "undefined" || propterty === "null" || propterty === "" || propterty === "undefined" || propterty == null)
                return "";
            return propterty;
        };

        var getPropertyNumberic = function (property) {
            if (typeof property === "undefined" || property === "null" || property === "" || property === 0)
                return 0;
            return property;
        };

        var getPropertyDate = function (property) {
            if (typeof property === "undefined" || property === "null" || property === "" || property === 0 || property == null)
                return "";

            return moment(property).format('MM/DD/YYYY');
        };

        localSession.ClearAll = function () {
            window.localStorage.removeItem("hpName");
            window.localStorage.removeItem("hpPhoneNumber");
            window.localStorage.removeItem("hpZipCode");
            window.localStorage.removeItem("hpEventId");
            window.localStorage.removeItem("hpHealthPlanId");
            window.localStorage.removeItem("hpHealthPlan");
            window.localStorage.removeItem("hpCustomCorporateTag");
            window.localStorage.removeItem("hpCallQueueId");
            window.localStorage.removeItem("hpEventId");
            window.localStorage.removeItem("hpPod");
            window.localStorage.removeItem('hpCampaignId');
            window.localStorage.removeItem('hpEndDate');
            window.localStorage.removeItem('hpFillEventZipCode');
            window.localStorage.removeItem('hpHealthPlanTag');
            window.localStorage.removeItem('hpStartDate');
            window.localStorage.removeItem('hpDirectMailStartDate');
            window.localStorage.removeItem('hpDirectMailEndDate');
            window.localStorage.removeItem('hpDirectMailDate');
            window.localStorage.removeItem('hpCriteriaId');

        };

        localSession.SetHealthPlan = function (filter) {
            window.localStorage.setItem("hpHealthPlan", getPropertyValue(filter.HealthPlan));
            window.localStorage.setItem("hpHealthPlanTag", getPropertyValue(filter.HealthPlanTag));
            window.localStorage.setItem("hpHealthPlanId", getPropertyNumberic(filter.HealthPlanId));
            window.localStorage.setItem("hpCustomCorporateTag", getPropertyValue(filter.CustomCorporateTag));
            window.localStorage.setItem("hpUseCustomTagExclusively", getPropertyValue(filter.UseCustomTagExclusively));
        };

        localSession.GetHealthPlan = function () {
            var filter = {
                HealthPlan: getPropertyValue(window.localStorage.hpHealthPlan),
                HealthPlanId: getPropertyNumberic(window.localStorage.hpHealthPlanId),
                CustomCorporateTag: getPropertyValue(window.localStorage.hpCustomCorporateTag),
                UseCustomTagExclusively: window.localStorage.hpUseCustomTagExclusively,
                HealthPlanTag: getPropertyValue(window.localStorage.hpHealthPlanTag)
            };

            return filter;
        };

        localSession.ClearCallQueueCategoryFilters = function () {
            window.localStorage.removeItem("hpCallQueueId");
            window.localStorage.removeItem("hpName");
            window.localStorage.removeItem("hpPhoneNumber");
            window.localStorage.removeItem("hpZipCode");
            window.localStorage.removeItem("hpEventId");
            window.localStorage.removeItem("hpRadius");
            window.localStorage.removeItem("hpEventId");
            window.localStorage.removeItem("hpPod");
            window.localStorage.removeItem('hpCriteriaId');
            window.localStorage.removeItem('hpCampaignId');
            window.localStorage.removeItem('hpEndDate');
            window.localStorage.removeItem('hpFillEventZipCode');
            window.localStorage.removeItem('hpStartDate');
            window.localStorage.removeItem('hpDirectMailStartDate');
            window.localStorage.removeItem('hpDirectMailEndDate');
            window.localStorage.removeItem('hpDirectMailDate');
        };

        localSession.SetCallQueueCategoryFilters = function (filter) {
            window.localStorage.setItem("hpCallQueueId", getPropertyNumberic(filter.CallQueueId));
        };

        localSession.GetCallQueueCategoryFilters = function () {
            filter.CallQueueId = getPropertyNumberic(window.localStorage.hpCallQueueId);
        };

        localSession.ClearCallRoundFilter = function () {
            window.localStorage.removeItem("hpName");
            window.localStorage.removeItem("hpPhoneNumber");
            window.localStorage.removeItem("hpZipCode");
            window.localStorage.removeItem("hpEventId");
            window.localStorage.removeItem("hpRadius");
            window.localStorage.removeItem("hpEventId");
            window.localStorage.removeItem("hpPod");
            window.localStorage.removeItem("hpCriteriaId");
            window.localStorage.removeItem("hpCampaignId");
            window.localStorage.removeItem('hpDirectMailStartDate');
            window.localStorage.removeItem('hpDirectMailEndDate');
            window.localStorage.removeItem('hpDirectMailDate');
        };

        localSession.GetCallRoundFilter = function () {
            var customerFilters = {};

            customerFilters.ZipCode = getPropertyValue(window.localStorage.hpZipCode);
            customerFilters.EventId = getPropertyNumberic(window.localStorage.hpEventId);
            customerFilters.CallQueueId = getPropertyNumberic(window.localStorage.hpCallQueueId);
            customerFilters.HealthPlan = getPropertyValue(window.localStorage.hpHealthPlan);
            customerFilters.HealthPlanId = getPropertyNumberic(window.localStorage.hpHealthPlanId);
            customerFilters.CustomCorporateTag = getPropertyValue(window.localStorage.hpCustomCorporateTag);
            customerFilters.PageNumber = getPropertyNumberic(window.localStorage.hpPageNumber);
            customerFilters.Radius = getPropertyNumberic(window.localStorage.hpRadius);
            customerFilters.UseCustomTagExclusively = getPropertyNumberic(window.localStorage.hpUseCustomTagExclusively);
            customerFilters.HealthPlanTag = getPropertyValue(window.localStorage.hpHealthPlanTag);
            customerFilters.CriteriaId = getPropertyNumberic(window.localStorage.hpCriteriaId);
            customerFilters.CampaignId = getPropertyNumberic(window.localStorage.hpCampaignId);
            customerFilters.DirectMailStartDate = getPropertyDate(window.localStorage.hpDirectMailStartDate);
            customerFilters.DirectMailEndDate = getPropertyDate(window.localStorage.hpDirectMailEndDate);
            customerFilters.DirectMailDate = getPropertyDate(window.localStorage.hpDirectMailDate);

            return customerFilters;
        };

        localSession.SetCriteriaId = function (criteriaId) {
            window.localStorage.setItem('hpCriteriaId', getPropertyNumberic(criteriaId));
        };

        localSession.GetCriteriaId = function () {
            return getPropertyNumberic(window.localStorage.hpCriteriaId);
        };

        localSession.SetCallRoundFilter = function (filter) {

            window.localStorage.setItem('hpName', getPropertyValue(filter.Name));
            window.localStorage.setItem('hpZipCode', getPropertyValue(filter.ZipCode));
            window.localStorage.setItem('hpPageNumber', getPropertyValue(filter.PageNumber));
            window.localStorage.setItem('hpRadius', getPropertyNumberic(filter.Radius));
            window.localStorage.setItem('hpCriteriaId', getPropertyNumberic(filter.CriteriaId));
            window.localStorage.setItem('hpDirectMailStartDate', getPropertyDate(filter.DirectMailStartDate));
            window.localStorage.setItem('hpDirectMailEndDate', getPropertyDate(filter.DirectMailEndDate));
            window.localStorage.setItem('hpDirectMailDate', getPropertyDate(filter.DirectMailDate));
        };

        localSession.ClearFilledEventCallQueueFilter = function () {
            window.localStorage.removeItem('hpEventId');
            window.localStorage.removeItem('hpPod');
            window.localStorage.removeItem('hpCriteriaId');
        };

        localSession.SetFilledEventCallQueueFilter = function (filter) {
            window.localStorage.setItem('hpEventId', getPropertyValue(filter.EventId));
            window.localStorage.setItem('hpPod', getPropertyValue(filter.Pod));
            window.localStorage.setItem('hpFillEventZipCode', getPropertyValue(filter.FillEventZipCode));
        };

        localSession.GetFilledEventCallQueueFilter = function () {
            var filter = {};

            filter.EventId = getPropertyValue(window.localStorage.hpEventId);
            filter.Pod = getPropertyValue(window.localStorage.hpPod);
            filter.CallQueueId = getPropertyNumberic(window.localStorage.hpCallQueueId);
            filter.HealthPlan = getPropertyValue(window.localStorage.hpHealthPlan);
            filter.HealthPlanId = getPropertyNumberic(window.localStorage.hpHealthPlanId);
            filter.CustomCorporateTag = getPropertyValue(window.localStorage.hpCustomCorporateTag);
            filter.CriteriaId = getPropertyNumberic(window.localStorage.hpCriteriaId);

            return filter;
        };

        localSession.GetFilledEventZipCode = function () {
            return getPropertyValue(window.localStorage.hpFillEventZipCode);
        };


        localSession.GetCampaignCallQueueFilter = function () {
            var filter = {};

            filter.CampaignId = getPropertyValue(window.localStorage.hpCampaignId);
            filter.CallQueueId = getPropertyNumberic(window.localStorage.hpCallQueueId);
            filter.HealthPlan = getPropertyValue(window.localStorage.hpHealthPlan);
            filter.HealthPlanId = getPropertyNumberic(window.localStorage.hpHealthPlanId);
            filter.CustomCorporateTag = getPropertyValue(window.localStorage.hpCustomCorporateTag);
            filter.EndDate = getPropertyValue(window.localStorage.hpEndDate);
            filter.StartDate = getPropertyValue(window.localStorage.hpStartDate);
            filter.CriteriaId = getPropertyValue(window.localStorage.hpCriteriaId);

            return filter;
        };

        localSession.SetCampaignCallQueueFilter = function (filter) {
            window.localStorage.setItem('hpCampaignId', getPropertyValue(filter.CampaignId));
            window.localStorage.setItem('hpEndDate', getPropertyValue(filter.EndDate));
            window.localStorage.setItem('hpStartDate', getPropertyValue(filter.StartDate));
            window.localStorage.setItem('hpCriteriaId', getPropertyValue(filter.CriteriaId));
        };

        localSession.ClearLocalStorageForFillEvent = function() {
            window.localStorage.removeItem('hpCampaignId');
        };

        localSession.ClearLocalStorageForMailRound = function() {
            window.localStorage.removeItem('hpFillEventZipCode');
            window.localStorage.removeItem('hpEventId');
        };

        localSession.ClearLocalStorageForLanguageBarrier = function() {
            window.localStorage.removeItem('hpEventId');
            window.localStorage.removeItem('hpFillEventZipCode');
            window.localStorage.removeItem('hpCampaignId');
        };

        localSession.ClearStorageForDashboard = function() {
            window.localStorage.removeItem('hpCallQueueId');
            window.localStorage.removeItem('hpHealthPlanId');
            window.localStorage.removeItem('hpCriteriaId');
        };
        localSession.ClearDashboardFilter = function() {
            window.localStorage.removeItem('sHealthPlanId');
            window.localStorage.removeItem('sCallQueueId');
        };

        localSession.GetDashboardFilter = function() {
            var data = {};
            data.searchHealthPlanId = window.localStorage.sHealthPlanId;
            data.searchCallQueueId = window.localStorage.sCallQueueId;
            return data;
        };
        localSession.SetDashboardFilter = function(data) {
            window.localStorage.setItem('sHealthPlanId', data.searchHealthPlanId);
            window.localStorage.setItem('sCallQueueId', data.searchCallQueueId);
        };

        return localSession;
    }]);
}());
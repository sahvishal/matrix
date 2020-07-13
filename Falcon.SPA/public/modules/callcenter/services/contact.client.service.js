(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).factory(CallCenterConfiguration.services.contactService, ["httpWrapper", function (httpWrapper) {
        var contactService = {};

        contactService.GetCustomerInfo = function (callQueueCustomerId, attemptId) {
            var endpoint = 'CallCenter/HealthPlanCallQueue/GetCustomerInfo?callQueueCustomerId=' + callQueueCustomerId + '&attemptId=' + attemptId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.GetEventsByZipCode = function (filter, showFutureEvents, pageNumber) {
            if (filter.state == null)
                filter.state = '';
            var endpoint = 'CallCenter/ContactCustomer/GetEventList?ZipCode=' + filter.zipcode + "&Radius=" + filter.radius + "&City=" + filter.city + "&State=" + filter.state;
            endpoint = endpoint + "&PageNumber=" + pageNumber + "&HealthPlanId=" + filter.forHealthPlanId + "&ToBeFilledEventId=" + filter.tobeFilledEventId + "&ExcludeCorporateEvents=" + filter.ExcludeCorporateEvents;
            endpoint = endpoint + "&SortByOrder=" + filter.SortByOrder + "&SortOrderType=" + filter.SortOrderType + "&PageSize=" + filter.PageSize + "&ShowFutureEvents=" + showFutureEvents + "&SearchMammoEvents=" + filter.SearchMammoEvents;
            endpoint = endpoint + "&CustomerZipCode=" + filter.customerZipCode + "&SearchAllEvents=" + filter.SearchAllEvents + "&CustomerId=" + filter.CustomerId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.DoesEventCustomerAlreadyExists = function (customerId, eventId) {
            var endpoint = 'CallCenter/ContactCustomer/DoesEventCustomerAlreadyExists?customerId=' + customerId + "&eventId=" + eventId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.GetCustomerMedicalHistory = function (customerId) {
            var endpoint = 'CallCenter/ContactCustomer/GetCustomerMedicalHistory?customerId=' + customerId;
            return httpWrapper.get({ url: endpoint });
        };


        contactService.UpdateCallQuequeCustomer = function (customerEditModel) {
            var endpoint = 'CallCenter/ContactCustomer/UpdateCallQueueCustomer';
            return httpWrapper.post({ url: endpoint, data: customerEditModel });
        };

        contactService.GetStates = function () {
            var endpoint = 'CallCenter/ContactCustomer/GetStatesDropDown';
            return httpWrapper.get({ url: endpoint });
        };

        contactService.GetUsaStatesDropDown = function () {
            var endpoint = 'CallCenter/ContactCustomer/GetUsaStatesDropDown';
            return httpWrapper.get({ url: endpoint });
        };

        contactService.EndActiveCall = function (callquequeCustomerId, callId, isCallQueueRequsted, removeFromCallQueue) {
            var endpoint = 'CallCenter/ContactCustomer/EndActiveCall?callQueueCustomerId=' + callquequeCustomerId + "&callId=" + callId + "&isCallQueueRequsted=" + isCallQueueRequsted + "&removeFromCallQueue=" + removeFromCallQueue;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.saveCallOutCome = function (dataModel) {
            var endpoint = 'CallCenter/ContactCustomer/SaveCallOutCome';
            return httpWrapper.post({ url: endpoint, data: dataModel });
        };

        contactService.GetCallOutCome = function (callquequeCustomerId, callId, customerId) {
            var endpoint = 'CallCenter/ContactCustomer/GetCallOutCome?callQueueCustomerId=' + callquequeCustomerId + "&callId=" + callId + "&customerId=" + customerId;
            return httpWrapper.get({ url: endpoint });
        };
        contactService.GetCategoryByCallQueueCustomerId = function (callQueueCustomerId) {
            var endpoint = 'CallCenter/ContactCustomer/GetCategoryByCallQueueCustomerId?callQueueCustomerId=' + callQueueCustomerId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.GetCallDispositionTags = function () {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/GetCallDispositionTags';
            return httpWrapper.get({ url: endpoint });
        };


        //healthplan
        contactService.EndHealthPlanActiveCall = function (dataModel) {
            var endpoint = 'CallCenter/ContactCustomer/EndHealthPlanActiveCall';
            return httpWrapper.post({ url: endpoint, data: dataModel });
        };

        contactService.GetNotes = function (callId, callquequeCustomerId) {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/GetNotes?callId=' + callId + '&callQueueCustomerId=' + callquequeCustomerId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.SetReadAndUnderstoodNotes = function (callAttemptId) {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/SetReadAndUnderstoodNotes?callAttemptId=' + callAttemptId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.getHealthPlanSubDispositions = function () {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/GetHealthPlanSubDispositions';
            return httpWrapper.get({ url: endpoint });
        };

        contactService.GetActivityTypes = function () {
            var endpoint = 'CallCenter/ContactCustomer/GetActivityTypes';
            return httpWrapper.get({ url: endpoint });
        };

        contactService.InitializeCallAttemptTable = function () {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/Initialize';
            return httpWrapper.get({ url: endpoint });
        }

        contactService.StartCallAndUpdateCallAttemptTable = function (callQueueCustomerId, callAttemptId, calledGlocomNumber, patientPhoneNumber, callQueueCategory) {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/StartCallAndUpdateCallAttemptTable?callQueueCustomerId=' + callQueueCustomerId + '&callAttemptId=' + callAttemptId + '&calledGlocomNumber=' + calledGlocomNumber
            + "&patientPhoneNumber=" + patientPhoneNumber + "&callQueueCategory=" + callQueueCategory;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.ReleaseLockedCustomer = function (callQueueCustomerId) {
            var endpoint = 'CallCenter/ContactCustomer/ReleaseLockedCustomer?callQueueCustomerId=' + callQueueCustomerId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.UpdateCallersPhoneNumber = function (callId, patientPhoneNumber) {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/UpdateCallersPhoneNumber?callId=' + callId + '&patientPhoneNumber=' + patientPhoneNumber;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.GetPreQualificationTemplateIds = function (customerId, eventId) {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/GetPreQualificationTemplateIds?customerId=' + customerId + '&eventId=' + eventId;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.GetPreQualificationQuestion = function (customerId, templateIds) {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/GetPreQualificationQuestion?customerId=' + customerId + '&templateIds=' + templateIds;
            return httpWrapper.get({ url: endpoint });
        };

        contactService.SavePreQualificationAnswers = function (model) {
            var endpoint = 'CallCenter/HealthPlanContactCustomer/SavePreQualificationAnswers';
            return httpWrapper.post({ url: endpoint, data: model });
        };

        return contactService;

    }]);
}());


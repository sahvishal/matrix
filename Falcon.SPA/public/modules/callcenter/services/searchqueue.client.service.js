(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).factory(CallCenterConfiguration.services.searchQueueService, ['httpWrapper', function (httpWrapper) {
        var searchQueueService = {};

        searchQueueService.GetCallQueueCategories = function () {
            var endpoint = 'CallCenter/CallQueue/GetCallQueueCategories';
            return httpWrapper.get({ url: endpoint });
        };

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

        searchQueueService.GetOutboundCallQueue = function (req) {
            var endpoint = 'CallCenter/CallQueue/GetOutboundCallQueue?CallQueueId=' + getPropertyValue(req.CallQueueId) + "&ZipCode=" + getPropertyValue(req.ZipCode) + '&Radius=' + getPropertyValue(req.Radius) + '&Name=' + getPropertyValue(req.Name);
            endpoint = endpoint + '&Email=' + getPropertyValue(req.Email) + '&PhoneNumber=' + getUnFormatedPhoneNumber(getPropertyValue(req.PhoneNumber)) + '&PageNumber=' + getPropertyValue(req.PageNumber) + '&EventId=' + getPropertyNumberic(req.EventId) + '&Tag=' + getPropertyValue(req.Tag);

            return httpWrapper.get({ url: endpoint });
        };

        searchQueueService.GetOutboundEventList = function (req) {
            var endpoint = 'CallCenter/CallQueue/GetEventsForFillEventCallQueue?CallQueueId=' + getPropertyValue(req.CallQueueId) + '&PageNumber=' + getPropertyValue(req.PageNumber) + '&EventId=' + getPropertyValue(req.EventId) + '&Pod=' + getPropertyValue(req.Pod);
            return httpWrapper.get({ url: endpoint });
        };

        searchQueueService.GetSelectedCategory = function (callQueueId) {
            var endpoint = 'CallCenter/CallQueue/GetCallQueueById?callQueueId=' + callQueueId;
            return httpWrapper.get({ url: endpoint });
        };
        searchQueueService.GetOrderSummary = function (customerId, eventId) {
            var endpoint = 'Finance/CustomerOrder/GetOrderSummary?customerId=' + customerId + '&eventId=' + eventId;
            return httpWrapper.get({ url: endpoint });
        };
        searchQueueService.UpdateDoNotCallStatus = function (callQueueCustomerId, dontCall) {
            var endpoint = 'CallCenter/ContactCustomer/UpdateDoNotCallStatus?callQueueCustomerId=' + callQueueCustomerId + '&dontCall=' + dontCall;
            return httpWrapper.get({ url: endpoint });
        };
        return searchQueueService;
    }]);
}());


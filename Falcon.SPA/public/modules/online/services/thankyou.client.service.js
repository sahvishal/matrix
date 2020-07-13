(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.thankYouService, ['onlineHttpWrapper', function (onlineHttpWrapper) {
        var eventService = {};
        

        eventService.GetOrderSummary = function (guid) {
            var endpoint = 'Scheduling/OnlineEvent/GetOnlineSummaryModel?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };
        
        eventService.GetOnlineThankyouModel = function (guid) {
            var endpoint = 'Scheduling/OnlineEvent/GetOnlineThankyouModel?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };
        
        return eventService;
    }]);

}());

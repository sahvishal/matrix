(function () {
    'use strict';
    angular.module(ApplicationConfiguration.applicationModuleName).factory(OnlineConfiguration.services.orderService, ['onlineHttpWrapper', function (onlineHttpWrapper) {
        var orderSummary = {};

        orderSummary.GetOrderSummary = function (guid) {
            var endpoint = 'Scheduling/OnlineEvent/GetOnlineSummaryModel?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        orderSummary.GetDateSuffix = function (date) {

            var d = new Date(date);
            var dayofMonth = d.getDate();
            var dateSuffix = '';
            if (dayofMonth >= 11 && dayofMonth <= 13) {
                dateSuffix = 'th';
            } else {
                switch (dayofMonth % 10) {
                    case 1:
                        dateSuffix = 'st';
                        break;
                    case 2:
                        dateSuffix = "nd";
                        break;
                    case 3:
                        dateSuffix = "rd";
                        break;
                    default:
                        dateSuffix = "th";
                        break;
                }
            }
            return dateSuffix;
        };

        return orderSummary;
    }]);
}());
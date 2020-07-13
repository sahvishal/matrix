(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive(OnlineConfiguration.directives.orderSummary, [OnlineConfiguration.services.orderService, '$stateParams', function (orderService, stateParams) {
        return {
            restrict: 'AE',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/shared/order.summary.client.view.html',
            controller: ['$scope', '$rootScope', function ($scope, $rootScope) {
                $scope.orderSummary = new Object();
               
                $scope.dateSuffix = '';
                orderService.GetOrderSummary(stateParams.guid).then(function (orderSummary) {
                    $scope.orderSummary = orderSummary;
                    if (orderSummary != null && orderSummary.EventCustomerOrderSummaryModel != null && orderSummary.EventCustomerOrderSummaryModel.EventDate != null) {
                        $scope.dateSuffix = orderService.GetDateSuffix(orderSummary.EventCustomerOrderSummaryModel.EventDate);
                    }
                });

                $scope.ShowHideSummery = function () {
                    $rootScope.showsummarybox = !$rootScope.showsummarybox;
                    if ($rootScope.showsummarybox) {
                        $rootScope.showProgressBar = false;
                    }
                };

            }]
        };
    }]);
}());

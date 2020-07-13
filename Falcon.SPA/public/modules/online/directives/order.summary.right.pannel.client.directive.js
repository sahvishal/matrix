(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive(OnlineConfiguration.directives.orderSummaryRightPannel,
        [OnlineConfiguration.services.orderService, '$stateParams', OnlineConfiguration.services.localStorageProgressBarService, CoreConfiguration.constants,
            function (orderService, stateParams, progressBarService, constants) {
        return {
            restrict: 'AE',
            replace: true,
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/shared/order.summary.right.pannel.client.view.html',
            controller: ['$scope', '$rootScope', function ($scope, $rootScope) {
                $scope.orderSummary = new Object();
                
                $scope.dateSuffix = '';
                $scope.hidePaymentDetail = progressBarService.getProgessStatus(stateParams.guid).Payment === constants.ProgressBarStatus.NotStarted;
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

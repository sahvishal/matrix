(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.customerOrderSummary, [CallCenterConfiguration.services.searchQueueService,function (searchQueueService) {

        return {
            restrict: 'E',
            scope: {
                customerid: '=',
                eventid: '=',
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/shared/customer.order.summary.client.view.html',
            controller: ['$scope', '$modal', function ($scope, $modal) {
                 
                $scope.ViewOrder = function () {
                    searchQueueService.GetOrderSummary($scope.customerid, $scope.eventid).then(function (result) {
                            $scope.CutomerOrderDetailPopup(result);
                         
                    }, function () {
                         
                    });
                };

                var modelPopupInstance = null;
                $scope.CutomerOrderDetailPopup = function (order) {
                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/shared/customer.order.popup.client.view.html', 
                        controller: ['$scope', 'data', 'logger', function (scope, data, log) {

                            scope.OrderDetails = data.order.OrderDetails;
                            scope.Paymentdetails = data.order.Paymentdetails;
                            scope.CustomerName = data.order.CustomerName;
                            scope.CustomerId = data.order.CustomerId;
                            scope.AmountOwed = data.order.AmountOwed;
                            scope.OrderTotal = data.order.OrderTotal;
                            scope.PaymentTotal = data.order.PaymentTotal;
                           

                            scope.ClosePopup = function () {
                                scope.$close();
                            };
                            
                            scope.$on('$destroy', function () {
                                scope.$close();
                            });
                        }],
                        size: 'lg',
                        resolve: {
                            data: function () {
                                return {
                                    order: order
                                };
                            }
                        }
                    });
                };
            }]
        };
    }]);
}());
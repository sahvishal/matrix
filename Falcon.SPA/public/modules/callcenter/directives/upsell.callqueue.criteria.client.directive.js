(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.upsellCallQueueCriteriaView, [CallCenterConfiguration.services.callQueueCriteriaSerivce, function (callQueueCriteriaSerivce) {

        return {
            restrict: 'E',
            scope: {
                callqueueid: '=',
                notifyParent: '&method'
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/searchqueue/upsell.callqueue.criteria.view.client.html',
            controller: ['$scope', '$modal', function ($scope, $modal) {
                $scope.model = null;
                var init = function () {
                    if ($scope.model == null) {
                        callQueueCriteriaSerivce.GetSystemGeneratedCallQueueCriteria($scope.callqueueid).then(function (criteria) {
                            $scope.model = criteria; // { Amount: 5, NoOfDays: 10 };
                        });
                    }
                };
                init();
                var updateView = function (criteria) {
                    $scope.model = criteria;
                    $scope.notifyParent();
                };

                $scope.UpdateUpsellCriteria = function (model) {
                    model.callbackFunction = updateView;
                    $scope.CriteriaPopup(model);
                };

                var modelPopupInstance = null;
                $scope.CriteriaPopup = function (criteria) {
                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/searchqueue/edit.upsell.criteria.view.client.html',
                        backdrop: 'static',
                        keyboard: false,
                        controller: ['$scope', 'data', 'logger', CallCenterConfiguration.services.searchQueueService, function (scope, data, log, searchQueueService) {

                            scope.modal = {};
                            scope.modal = angular.copy(data.criteria);
                            scope.upsellCriteriaFormIsSubmitted = false;
                            scope.InvalidNoOfDays = false;
                            scope.InvalidAmount = false;

                            scope.SaveUpsellCriteria = function () {
                                scope.upsellCriteriaFormIsSubmitted = true;
                                if (scope.upsellCriteriaFormIsSubmitted) {
                                    if (isNaN(scope.modal.NoOfDays) || scope.modal.NoOfDays == null || scope.modal.NoOfDays == '' || scope.modal.NoOfDays == 0) {
                                        scope.InvalidNoOfDays = true;
                                    } else {
                                        scope.InvalidNoOfDays = false;
                                    } 
                                    var rE = /^-{0,1}\d*\.{0,1}\d+$/;
                                    var isvalidAmount = (rE.test(scope.modal.Amount));
                                    scope.InvalidAmount = !isvalidAmount;

                                    if (scope.InvalidNoOfDays || scope.InvalidAmount) {
                                        scope.modal.Amount = 0;
                                        return;
                                    }
                                }

                                if (confirm("This will regenerate the list , do you wish to continue?")) {
                                    scope.modal.CriteriaId = 0;
                                    if (scope.modal.IsDefault == false)
                                        scope.modal.CriteriaId = scope.modal.Id;
                                    callQueueCriteriaSerivce.UpdateUpsellQueueCriteria(scope.modal).then(function (result) {
                                        if (result != null) {
                                            log.showToasterSuccess('Criteria modified Successfuly.');
                                            log.showToasterSuccess('The list will be generated within few minutes.');
                                            scope.modal.Id = result.Id;
                                            scope.modal.IsDefault = result.IsDefault;
                                            data.criteria = scope.modal;
                                            data.criteria.callbackFunction(scope.modal);
                                            scope.$close();
                                        }
                                    });
                                }
                            };
                            scope.Cancel = function () {
                                scope.$close();
                            };

                            scope.$on('$destroy', function () {
                                scope.$close();
                            });
                        }],
                        size: 'sm',
                        resolve: {
                            data: function () {
                                return {
                                    criteria: criteria
                                };
                            }
                        }
                    });
                };
            }]
        };
    }]);
}());
(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.fillEventCriteriaView, [function () {

        return {
            restrict: 'E',
            scope: {
                model: '=',
                notifyParent: '&method'
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/fillevent/fill.event.criteria.view.client.html',
            controller: ['$scope', '$modal', function($scope, $modal) {
                var updateView = function(criteria) {
                    $scope.model = criteria;
                    $scope.notifyParent();
                };

                $scope.UpdateFillEventCriteria = function(model) {
                    model.callbackFunction = updateView;
                    $scope.CriteriaPopup(model);
                };


                var modelPopupInstance = null;
                $scope.CriteriaPopup = function(criteria) {
                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/fillevent/edit.fill.event.criteria.view.client.html',
                        backdrop: 'static',
                        keyboard: false,
                        controller: ['$scope', 'data', 'logger', CallCenterConfiguration.services.callQueueCriteriaSerivce, function (scope, data, log, callQueueCriteriaSerivce) {

                            scope.modal = {};
                            scope.modal = angular.copy(data.criteria);
                            scope.fillEventCriteriaFormIsSubmitted = false;
                            scope.InvalidNoOfDays = false;
                            scope.InvalidPercentage = false;

                            scope.SaveCriteria = function() {
                                scope.fillEventCriteriaFormIsSubmitted = true;
                                if (scope.fillEventCriteriaFormIsSubmitted) {
                                    if (isNaN(scope.modal.NoOfDays) || scope.modal.NoOfDays == null || scope.modal.NoOfDays == '' || scope.modal.NoOfDays == 0) {
                                        scope.InvalidNoOfDays = true;
                                    } else {
                                        scope.InvalidNoOfDays = false;
                                    } 
                                    if (isNaN(scope.modal.Percentage) || scope.modal.Percentage == null || scope.modal.Percentage == '' || scope.modal.Percentage == 0) {
                                        scope.InvalidPercentage = true;
                                    } else {
                                        scope.InvalidPercentage = false;
                                    }
                                    if (scope.InvalidNoOfDays || scope.InvalidPercentage)
                                        return;
                                }

                                if (confirm("This will regenerate the list, do you wish to continue?")) {
                                    scope.modal.CriteriaId = 0;
                                    if (scope.modal.IsDefault == false)
                                        scope.modal.CriteriaId = scope.modal.Id;
                                    callQueueCriteriaSerivce.UpdateFillEventQueueCriteria(scope.modal).then(function (result) {
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
                            scope.Cancel = function() {
                                scope.$close();
                            };

                            scope.$on('$destroy', function() {
                                scope.$close();
                            });
                        }],
                        size: 'sm',
                        resolve: {
                            data: function() {
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
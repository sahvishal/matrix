(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.uncontactedCustomerCriteriaView, ['logger', CallCenterConfiguration.services.healthPlanCallQueueCriteriaSerivce, CallCenterConfiguration.services.healthplanlocalstorage, function (log,healthPlanCallQueueCriteriaSerivce, healthplanlocalstorage) {

        return {
            restrict: 'E',
            scope: {
                model: '=',
                notifyParent: '&method'
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/uncontacted/customers.callqueue.criteria.view.client.html',
            controller: ['$scope', '$modal', function ($scope, $modal) {

                var updateView = function (criteria) {
                    $scope.model = criteria;
                    $scope.notifyParent();
                };

                $scope.UpdateUncontactedCustomerCriteira = function (model) {
                    
                    model.callbackFunction = updateView;

                    if (confirm("This will regenerate the list, do you wish to continue?")) {
                        
                        var healthPlanInfo = healthplanlocalstorage.GetHealthPlan();
                        
                        $scope.model.CriteriaId = 0;
                        
                        if ($scope.model.IsDefault == false)
                            $scope.model.CriteriaId = $scope.model.Id;
                        
                        $scope.model.HealthPlanId = healthPlanInfo.HealthPlanId;
                        $scope.model.CustomCorporateTag = healthPlanInfo.CustomCorporateTag;
                        
                        healthPlanCallQueueCriteriaSerivce.UpdateUncontactedCustomerQueueCriteria($scope.model).then(function (result) {
                            
                            if (result != null) {
                                log.showToasterSuccess('Criteria modified Successfuly.');
                                log.showToasterSuccess('The list will be generated within few minutes.');
                                $scope.model.Id = result.Id;
                                $scope.model.IsDefault = result.IsDefault;
                                
                                model.callbackFunction($scope.model);
                            }
                        });
                    }
                };
            }]
        };
    }]);
}());
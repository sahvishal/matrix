(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.zipRadiusCriteriaView, [CallCenterConfiguration.services.healthplanlocalstorage, CallCenterConfiguration.services.healthPlanCallQueueCriteriaSerivce, function (healthplanlocalstorage, healthPlanCallQueueCriteriaSerivce) {

        return {
            restrict: 'E',
            scope: {
                model: '='
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/zipradius/zipradius.callqueue.criteria.client.view.html',
            controller: ['$scope', '$modal', function ($scope) {

                $scope.init = function () {
                    var filters = healthplanlocalstorage.GetCallRoundFilter();
                    $scope.model = { HealhPlanId: filters.HealthPlanId, CreateNewCriteria: true, CallQueueId: filters.CallQueueId };

                    healthPlanCallQueueCriteriaSerivce.GetSystemGeneratedCallQueueCriteria(filters.CallQueueId, filters.HealthPlanId).then(function (item) {

                        if (item != null) {
                            $scope.model = item;
                            $scope.model.CreateNewCriteria = false;
                        } else {
                            $scope.model = { CreateNewCriteria: true, CallQueueId: filters.CallQueueId, HealthPlanId: filters.HealthPlanId };
                            
                            $scope.UpdateZipRaddiusCriteira($scope.model);
                        }
                        
                    });
                };

                $scope.UpdateZipRaddiusCriteira = function (model) {
                    $scope.CriteriaPopup(model);
                };

                $scope.RadiusText = function (model) {
                    var radius = [
                                { text: 'Exact search', value: 0 },
                                { text: '5 miles', value: 5 },
                                { text: '10 miles', value: 10 },
                                { text: '15 miles', value: 15 },
                                { text: '20 miles', value: 20 },
                                { text: '25 miles', value: 25 },
                                { text: '50 miles', value: 50 }

                    ];
                    var radiusText = "";
                    $.each(radius, function (index, item) {
                        if (model != null && item.value == model.Radius) {
                            radiusText = radius[index].text;
                        }
                    });

                    return radiusText;
                };
            }]
        };
    }]);
}());
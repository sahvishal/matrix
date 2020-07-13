(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller("healthplanDashboardController",
        ['$scope', '$state', 'usSpinnerService', CallCenterConfiguration.services.searchHealthPlanService,
        CoreConfiguration.constants, CallCenterConfiguration.services.healthplanlocalstorage, 'logger', 'analytics',
        function ($scope, $state, usSpinnerService, healthPlanService, constants, healthplanlocalstorage, logger, analytics) {
            $scope.category = null;
            $scope.CallQueueCategory = constants.HealthPlanCallQueueCategory;
            $scope.HealthPlan = "";
            function init() {
               
                var healthPlanInfo = healthplanlocalstorage.GetHealthPlan();
                
                if (healthPlanInfo.HealthPlanId <= 0) {
                    logger.showToasterError('Please select healthplan.');
                    $state.go("healthplan");
                }
               $scope.HealthPlan = healthPlanInfo.HealthPlan;
                healthplanlocalstorage.ClearCallQueueCategoryFilters();
                
                healthPlanService.GetCallQueueCategories().then(function (result) {
                    $scope.category = result;
                    setTimeout(function () {
                        usSpinnerService.stop('online-spinner');
                    }, 1000);

                }, function () {
                    usSpinnerService.stop('online-spinner');
                });
            }

            $scope.SelectCategory = function (category) {
                var filter = { CallQueueId: category.CallQueueId };
                healthplanlocalstorage.SetCallQueueCategoryFilters(filter);
                
                if (category.Category == $scope.CallQueueCategory.FillEventsHealthPlan) {
                    $state.go('healthplanfillevents');
                } else if (category.Category == $scope.CallQueueCategory.MailRound) {
                    $state.go('healthplancampaigns');
                }
                else {
                    $state.go("callround");
                }
            };

            $scope.numtoWord = function (num) {
                switch (num) {
                    case 1: return 'one';
                    case 2: return 'two';
                    case 3: return 'three';
                    case 4: return 'four';
                    case 5: return 'five';
                    case 6: return 'Six';
                    case 7: return 'seven';
                }
                
                return "";
            };

            $scope.gotoSeachHealthPlan = function () {
                $state.go('healthplan');
            };
            
            init();
        }]);

}());
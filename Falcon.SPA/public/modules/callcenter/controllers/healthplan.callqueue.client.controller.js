(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.healthPlanCallQueue,
    ['$scope', '$state', 'usSpinnerService', CallCenterConfiguration.services.searchHealthPlanService, CoreConfiguration.constants, CallCenterConfiguration.services.healthplanlocalstorage, 'analytics',
        function ($scope, $state, usSpinnerService, searchHealthPlanService, constants, healthplanlocalstorage, analytics) {

            $scope.HealthPlans = null;
            $scope.selectedplans = null;
            $scope.IsHealthPlanNotSelected = false;
            $scope.customTags = [];
            $scope.multipleDemo = {};
            $scope.multipleDemo.selectedCustomTag = [];
            //$scope.UseCustomTagExclusively = false;
            //$scope.IsCustomTagNotSelected = false;

            function init() {

                healthplanlocalstorage.ClearAll();

                searchHealthPlanService.GetHealthPlanDropDown().then(function (result) {

                    $scope.HealthPlans = result;

                    setTimeout(function () {
                        usSpinnerService.stop('online-spinner');
                    }, 1000);

                }, function () {
                    usSpinnerService.stop('online-spinner');
                });
            }


            $scope.GetCustomTagDropdown = function () {

                var dropdown = [];
                $scope.customTags = [];
                $scope.multipleDemo.selectedCustomTag = [];
                $scope.IsCustomTagNotSelected = false;
                
                if ($scope.selectedplans != null || typeof ($scope.selectedplans) != 'undefined') {
                    $scope.IsHealthPlanNotSelected = false;
                    if ($scope.selectedplans.CorporateCustomTag != null && typeof ($scope.selectedplans.CorporateCustomTag) != 'undefined') {
                        $.each($scope.selectedplans.CorporateCustomTag, function (index, item) {
                            var object = { Value: item.Id, Text: item.CorporateTag };
                            dropdown.push(object);
                        });
                    }
                }

                $scope.customTags = dropdown;
            };

            $scope.gotoCallQueueCategory = function () {

                var selectedTag = [];

                if ($scope.multipleDemo.selectedCustomTag != null && typeof ($scope.multipleDemo.selectedCustomTag) != 'undefined' && $scope.multipleDemo.selectedCustomTag.length > 0) {
                    $.each($scope.multipleDemo.selectedCustomTag, function (index, item) {
                        var object = getById($scope.selectedplans.CorporateCustomTag, item.Value);

                        if (object != null) {
                            selectedTag.push(object.CorporateTag);
                        }
                    });
                }

                if ($scope.selectedplans == null || typeof ($scope.selectedplans) == 'undefined' || $scope.selectedplans.Id <= 0) {
                    $scope.IsHealthPlanNotSelected = true;
                    return;
                }

                if ((selectedTag.length <= 0) && $scope.customTags.length > 0) {
                    $scope.IsCustomTagNotSelected = true;
                    return;
                }

                var filter = { HealthPlanId: $scope.selectedplans.Id, HealthPlan: $scope.selectedplans.HealthPlanName, CustomCorporateTag: selectedTag.toString(), UseCustomTagExclusively: $scope.UseCustomTagExclusively, HealthPlanTag: $scope.selectedplans.CorporateTag };

                healthplanlocalstorage.SetHealthPlan(filter);

                $state.go("healthplanCategory");

            };

            function getById(array, id) {
                for (var i = 0, len = array.length; i < len; i++) {
                    if (array[i].Id === id) {
                        return array[i];
                    }
                }
                return null; // Nothing found
            }

            init();
        }]);

}());
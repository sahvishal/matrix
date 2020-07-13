(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.healthplanCampaignClientController,
    [
        '$rootScope', '$scope', '$stateParams', '$state', 'usSpinnerService', CallCenterConfiguration.services.searchHealthPlanService, CoreConfiguration.constants,
        CallCenterConfiguration.services.healthPlanCallQueueCriteriaSerivce, CallCenterConfiguration.services.healthplanlocalstorage, 'logger', 'analytics',
        function ($rootScope, $scope, $stateParams, $state, usSpinnerService, searchHealthPlanService, constants, healthPlanCallQueueCriteriaSerivce, healthplanlocalstorage, logger, analytics) {
            $scope.category = null;
            $scope.CallQueueCategory = constants.CallQueueCategory;

            $scope.disableStartCallingButton = false;
            $scope.showNoCampaignInList = false;
            $scope.CampaignList = null;
            $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
            $scope.isPosted = false;
            $scope.campaignFilters = { CampaignId: null, Pod: '', PageNumber: 1, CallQueueId: 0, HealthPlanId: 0, HealthPlan: "", StartDate: null, EndDate: null };
            $scope.HealthPlan = "";

            $scope.backToDashboard = function () {
                healthplanlocalstorage.ClearStorageForDashboard();
                $state.transitionTo('CallCentreDashboard');
            }

            function init() {
                usSpinnerService.spin('online-spinner');
                $scope.campaignFilters = healthplanlocalstorage.GetCampaignCallQueueFilter();
                $scope.HealthPlan = $scope.campaignFilters.HealthPlan;
                $scope.isPosted = true;
                if ($scope.campaignFilters.CallQueueId <= 0) {
                    logger.showToasterError('Please select Call Queue Again');
                    $state.go("CallCentreDashboard");
                    return;
                }

                searchHealthPlanService.GetSelectedCategory($scope.campaignFilters.CallQueueId).then(function (item) {
                    $scope.selectedCategory = {
                        value: item.Id, text: item.Name, Category: item.Category
                    };
                });

                searchHealthPlanService.GetOutboundCampaignList($scope.campaignFilters).then(function (result) {
                    if (result != null) {
                        if (result.Campaign == null || result.Campaign.length <= 0) {
                            $scope.showNoCampaignInList = true;
                        }
                        $scope.CampaignList = result.Campaign;
                        $scope.PagingModel = result.PagingModel;
                    }
                    setTimeout(function() {
                        usSpinnerService.stop('online-spinner');
                    }, 1000);
                }, function () {
                    $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                    $scope.showNoCampaignInList = true;
                    usSpinnerService.stop('online-spinner');
                });
                $scope.isPosted = false;
                $scope.CriteriaName = window.localStorage.getItem('CriteriaName');
            };

            $scope.GetCampaignByPageNumber = function (pageNumber) {
                $scope.isPosted = true;
                $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                $scope.CampaignList = null;
                $scope.campaignFilters.PageNumber = pageNumber;
                $scope.campaignFilters.CampaignId = window.localStorage.hpCampaignId;
                $scope.campaignFilters.HealthPlanId = window.localStorage.hpHealthPlanId;
                $scope.campaignFilters.CallQueueId = window.localStorage.hpCallQueueId;
                $scope.loader_filter = true;
                $scope.showNoCampaignInList = false;

                searchHealthPlanService.GetOutboundCampaignList($scope.campaignFilters).then(function (result) {
                    $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                    if (result != null) {
                        if (result.Campaign == null || result.Campaign.length <= 0) {
                            $scope.showNoCampaignInList = true;
                        }
                        $scope.CampaignList = result.Campaign;
                        $scope.PagingModel = result.PagingModel;
                    }

                    $scope.isPosted = false;
                    $scope.loader_filter = false;
                }, function (result) {

                    if (result != null && result.Campaign == null) {
                        $scope.showNoCampaignInList = true;
                    }
                    if (result == undefined) {
                        $scope.showNoCampaignInList = true;
                        $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                    }
                    $scope.isPosted = false;
                    $scope.loader_filter = false;
                });
            };

            $scope.filterCampaign = function (form) {
                form.submitted = true;
                if (form.$valid) {
                    form.submitted = true;
                    $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                    $scope.GetCampaignByPageNumber(1);
                    form.submitted = false;
                }
            };

            $scope.clearFilter = function () {
                $scope.campaignFilters = { CampaignId: null, Pod: '', PageNumber: 1, CallQueueId: 0, HealthPlanId: 0, HealthPlan: "", StartDate: null, EndDate: null };
            };

            $scope.getCustomerForCall = function (campaign) {
                $scope.disableStartCallingButton = true;
                var filter = { CampaignId: campaign.Id };
                window.localStorage.setItem('hpCriteriaId', campaign.CriteriaId);
                healthplanlocalstorage.SetCampaignCallQueueFilter(filter);
                var searchModel = {
                    CallQueueId: window.localStorage.hpCallQueueId,
                    CampaignId: filter.CampaignId,
                    HealthPlanId: window.localStorage.hpHealthPlanId,
                    Radius: window.localStorage.hpRadius,
                    UseCustomTagExclusively: false,
                    PageNumber: 1,
                    CriteriaId: campaign.CriteriaId
                };

                //Clear Irrelevant data stored for other Queues
                healthplanlocalstorage.ClearLocalStorageForMailRound();

                usSpinnerService.spin('online-spinner');
                searchHealthPlanService.ViewAvailableCustomerForFillEvent(searchModel).then(function (result) {
                    if (result.TryAgain) {
                        $scope.getCustomerForCall(campaign);
                    } else if (result.NoMoreCustomerInList) {
                        logger.showToasterError("No Customer in this Call Queue");
                        $state.transitionTo('CallCentreDashboard');
                    }
                    else {
                        usSpinnerService.stop('online-spinner');
                        $state.go('healthplanContact', { callQueueCustomerId: result.CallQueueCustomerId, attemptId: result.AttemptId });
                    }
                }, function () {
                    $scope.disableStartCallingButton = false;
                    logger.showToasterError('Some Error Occurred, cannot get Customer for Call');
                    usSpinnerService.stop('online-spinner');
                });
            }

            $scope.ClearData = function () {
                $scope.CampaignList = null;
                $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
            };
            init();
        }]);

}());
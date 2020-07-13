(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName)
        .controller(CallCenterConfiguration.controllers.healthplanDashboardController,
            ['$scope', '$state', 'usSpinnerService', CallCenterConfiguration.services.searchHealthPlanService, CallCenterConfiguration.services.healthplanlocalstorage,
                'logger', CallCenterConfiguration.services.searchHealthPlanService,
                function ($scope, $state, usSpinnerService, healthPlanService, healthplanlocalstorage, logger, searchHealthPlanService) {
                    $scope.CallCenterAgentDashBoardData = {};
                    $scope.CallQueueData = {};
                    $scope.noRecordsFound = false;
                    $scope.callQueueTypes = {
                        FillEvents: "Fill Events",
                        MailRound: "Mail Round",
                        LanguageBarrier: "Language Barrier",
                        AppointmentConfirmation: "Appointment Confirmation"
                    };
                    var filter = {
                        CallQueueId: "",
                        HealthPlanId: ""
                    };
                    $scope.assignedCallQueueFilters = { CallQueueId: -1, HealthPlanId: -1 };

                    $scope.getSelectedCallQueuesType = function(callQueueId, selectedHealthPlanId, criteriaName, criteriaId, campaignId) {
                        filter.CallQueueId = callQueueId;
                        filter.CampaignId = campaignId;
                        filter.CriteriaId = criteriaId;
                        filter.HealthPlanId = selectedHealthPlanId;
                        healthplanlocalstorage.SetHealthPlan(filter);
                        healthplanlocalstorage.SetCallQueueCategoryFilters(filter);
                        healthplanlocalstorage.SetCampaignCallQueueFilter(filter);

                        window.localStorage.setItem('CriteriaName', criteriaName);

                        //Transition to child states
                        if (callQueueId === 147) {
                            $scope.isCallQueueSelected = true;
                            $state.transitionTo("fillEvents");
                        } else {
                            $scope.isCallQueueSelected = true;
                            usSpinnerService.spin('online-spinner');
                            var searchModel = {
                                CallQueueId: window.localStorage.hpCallQueueId,
                                HealthPlanId: window.localStorage.hpHealthPlanId,
                                Radius: window.localStorage.hpRadius,
                                UseCustomTagExclusively: false,
                                PageNumber: 1,
                                CampaignId: campaignId,
                                CriteriaId: criteriaId
                            };
                            $scope.GetNextCustomerForCall(searchModel);
                            //Clear Irrelevant data stored for other Queues
                            if (callQueueId === 152) {
                                healthplanlocalstorage.ClearLocalStorageForLanguageBarrier();
                            } else {
                                healthplanlocalstorage.ClearLocalStorageForMailRound();
                            }

                        }
                    };
                    
                    $scope.GetNextCustomerForCall = function (searchModel) {
                        searchHealthPlanService.ViewAvailableCustomerForFillEvent(searchModel).then(function (result) {
                            if (result.TryAgain) {
                                $scope.GetNextCustomerForCall(searchModel);
                            } else if (result.AssignmentChanged) {
                                logger.showToasterError("Your assignment is changed.");
                                $scope.isCallQueueSelected = false;
                                usSpinnerService.stop('online-spinner');
                                $scope.clearFilter();
                            } else if (result.NoMoreCustomerInList) {
                                logger.showToasterError("No patient left in queue. Please check back in few mins.");
                                $scope.isCallQueueSelected = false;
                                usSpinnerService.stop('online-spinner');
                                $scope.clearFilter();
                            } else {
                                usSpinnerService.stop('online-spinner');
                                window.sessionStorage.setItem("showCallPanel", false);
                                //window.localStorage.setItem("isScriptOpen", true);
                                $state.go('healthplanContact', { callQueueCustomerId: result.CallQueueCustomerId, attemptId: result.AttemptId });
                            }

                        }, function () {
                            $state.transitionTo('CallCentreDashboard');
                            $scope.isCallQueueSelected = false;
                            logger.showToasterError('Some error occurred, try again');
                            usSpinnerService.stop('online-spinner');
                        });

                    };

                    usSpinnerService.stop('');
                    function init() {
                        window.localStorage.setItem("isScriptOpen", false);
                        if (window.localStorage.AssignmentChanged == 'true') {
                            logger.showToasterError("Your assignment is changed.");
                            window.localStorage.removeItem("AssignmentChanged");
                        }
                        window.sessionStorage.setItem("showCallPanel", true);
                        usSpinnerService.spin('online-spinner');
                        $('#dvStartCall').show();
                        $('#assignedCallQueue').show();
                        window.localStorage.setItem('hpRadius', 25);  //always passing radius 25miles as discussed
                        $scope.sHealthPlanId = "-1";
                        $scope.sCallQueueId = "-1";

                        //searchHealthPlanService.GetHealthPlanDropDown().then(function (result) {
                        //    $scope.HealthPlans = result;
                        //});
                        //searchHealthPlanService.GetCallQueueCategories().then(function (result) {
                        //    $scope.CallQueues = result;
                        //});

                        //to retain filter on refresh
                        var data = healthplanlocalstorage.GetDashboardFilter();
                        $scope.assignedCallQueueFilters.CallQueueId = data.searchCallQueueId;
                        $scope.assignedCallQueueFilters.HealthPlanId = data.searchHealthPlanId;
                        
                        if ($scope.assignedCallQueueFilters.CallQueueId != -1 || $scope.assignedCallQueueFilters.HealthPlanId != -1) {
                            $scope.sHealthPlanId = data.searchHealthPlanId == null ? "-1" : data.searchHealthPlanId.toString();
                            $scope.sCallQueueId = data.searchCallQueueId == null ? "-1" : data.searchCallQueueId.toString();
                        }

                        healthPlanService.CallCenterAgentDashBoardData($scope.assignedCallQueueFilters, 1).then(function (result) {
                            if (result.HealthPlanList != null && result.CallQueuesList != null) {
                                $scope.HealthPlans = result.HealthPlanList;
                                $scope.CallQueues = result.CallQueuesList;
                            } else {
                                logger.showToasterError('Some Error Occurred in gathering search Filter Data');
                            }
                            if (result.Collection == null || result.Collection.length === 0) {
                                logger.showToasterError('No Queues Assigned, Contact your Manager or Try Clearing Search filter');
                                $scope.noRecordsFound = true;
                                $scope.isPosted = false;
                            } else {
                                $scope.noRecordsFound = false;
                                $scope.CallCenterAgentDashBoardData = result.Collection;
                                $scope.PagingModel = result.PagingModel;
                            }
                            $scope.isPosted = false;
                            usSpinnerService.stop('online-spinner');
                        }, function () {
                            if (result.HealthPlanList != null && result.CallQueuesList != null) {
                                $scope.HealthPlans = result.HealthPlanList;
                                $scope.CallQueues = result.CallQueuesList;
                            } else {
                                logger.showToasterError('Some Error Occurred in gathering search Filter Data');
                            }
                            $scope.isPosted = false;
                            $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                            //$scope.showNoCampaignInList = true;
                            usSpinnerService.stop('online-spinner');
                        });
                    }

                    $scope.filterAssignedCallQueues = function (form) {
                        form.submitted = true;
                        if (form.$valid) {
                            form.submitted = true;
                            $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };

                            var data = {
                                searchHealthPlanId: $scope.sHealthPlanId,
                                searchCallQueueId: $scope.sCallQueueId
                            };
                            healthplanlocalstorage.SetDashboardFilter(data);

                            $scope.assignedCallQueueFilters.HealthPlanId = $scope.sHealthPlanId;
                            $scope.assignedCallQueueFilters.CallQueueId = $scope.sCallQueueId;
                            $scope.GetAssignedCallQueuesByPageNumber(1);
                            form.submitted = false;
                        }
                    };

                    $scope.GetAssignedCallQueuesByPageNumber = function (pageNumber) {
                        $scope.isPosted = true;
                        $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };

                        var dashboardFilters = healthplanlocalstorage.GetDashboardFilter();
                        $scope.assignedCallQueueFilters.HealthPlanId = dashboardFilters.searchHealthPlanId;
                        $scope.assignedCallQueueFilters.CallQueueId = dashboardFilters.searchCallQueueId;

                        $scope.loader_filter = true;

                        healthPlanService.CallCenterAgentDashBoardData($scope.assignedCallQueueFilters, pageNumber).then(function (result) {
                            if (result.Collection == null || result.Collection.length === 0) {
                                logger.showToasterError('No Queues Assigned for this Search Filter');
                                $scope.noRecordsFound = true;
                                $scope.CallCenterAgentDashBoardData = null;
                                $scope.loader_filter = false;
                                $scope.isPosted = false;
                            } else {
                                $scope.noRecordsFound = false;
                                $scope.CallCenterAgentDashBoardData = result.Collection;
                                $scope.PagingModel = result.PagingModel;
                                $scope.loader_filter = false;
                                $scope.isPosted = false;
                            }
                            usSpinnerService.stop('online-spinner');
                        }, function () {
                            $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                            $scope.isPosted = false;
                            usSpinnerService.stop('online-spinner');
                        });
                        
                        var data = healthplanlocalstorage.GetDashboardFilter();
                        $scope.sHealthPlanId = data.searchHealthPlanId == null ? "-1" : data.searchHealthPlanId;
                        $scope.sCallQueueId = data.searchCallQueueId == null ? "-1" : data.searchCallQueueId;
                    };

                    $scope.clearFilter = function () {
                        $scope.sHealthPlanId = "-1";
                        $scope.sCallQueueId = "-1";
                        $scope.isPosted = false;
                        $scope.assignedCallQueueFilters.HealthPlanId = -1;
                        $scope.assignedCallQueueFilters.CallQueueId = -1;

                        var data = {
                            searchHealthPlanId: $scope.sHealthPlanId,
                            searchCallQueueId: $scope.sCallQueueId
                        };
                        healthplanlocalstorage.SetDashboardFilter(data);
                        init();
                    }

                    init();
                }]);
}());
(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.healthplanFilledEventController,
    [
        '$rootScope', '$scope', '$stateParams', '$state', 'usSpinnerService', CallCenterConfiguration.services.searchHealthPlanService, CoreConfiguration.constants,
        CallCenterConfiguration.services.healthPlanCallQueueCriteriaSerivce, CallCenterConfiguration.services.healthplanlocalstorage, 'logger', 'analytics',
    function ($rootScope, $scope, $stateParams, $state, usSpinnerService, searchHealthPlanService, constants, healthPlanCallQueueCriteriaSerivce, healthplanlocalstorage, logger, analytics) {
        $scope.category = null;
        $scope.CallQueueCategory = constants.CallQueueCategory;

        $scope.disableStartCallingButton = false;
        $scope.showNoEventInList = false;
        $scope.EventList = null;
        $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
        $scope.isPosted = false;
        $scope.eventFilters = { EventId: null, Pod: '', PageNumber: 1, CallQueueId: 0, HealthPlanId: 0, HealthPlan: "" };
        $scope.HealthPlan = "";
        $scope.RegistrationMode = constants.RegistrationMode;
        $scope.EventType = constants.EventType;

        $scope.backToDashboard = function () {
            healthplanlocalstorage.ClearStorageForDashboard();
            $state.transitionTo('CallCentreDashboard');
        }

        function init() {
            $('#dvStartCall').hide();
            $scope.eventFilters = healthplanlocalstorage.GetFilledEventCallQueueFilter();
            $scope.eventFilters.EventId = null;                     //We are not using event id from this anywhere, (this solves the automatic filtering on reload)
            $scope.HealthPlan = $scope.eventFilters.HealthPlan;
            $scope.isPosted = true;

            if ($scope.eventFilters.CallQueueId <= 0) {
                logger.showToasterError('Please select call queue type.');
                $state.go("CallCentreDashboard");
                return;
            }
            usSpinnerService.spin('online-spinner');

            searchHealthPlanService.GetSelectedCategory($scope.eventFilters.CallQueueId).then(function (item) {
                $scope.selectedCategory = {
                    value: item.Id, text: item.Name, Category: item.Category
                };
            });
            
            searchHealthPlanService.GetOutboundEventList($scope.eventFilters).then(function (result) {
                if (result != null) {
                    if (result.Events == null || result.Events.length <= 0) {
                        $scope.showNoEventInList = true;
                    }
                    $scope.EventList = result.Events;
                    $scope.PagingModel = result.PagingModel;
                }
                setTimeout(function () { usSpinnerService.stop('online-spinner'); }, 600);
            }, function () {
                $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                $scope.showNoEventInList = true;
                usSpinnerService.stop('online-spinner');
            });

            $scope.SystemGeneratedCallQueueCriteria();
            $scope.isPosted = false;
            $scope.CriteriaName = window.localStorage.getItem('CriteriaName');
        }


        $scope.SystemGeneratedCallQueueCriteria = function () {
            healthPlanCallQueueCriteriaSerivce.GetSystemGeneratedCallQueueCriteria($scope.eventFilters.CallQueueId, $scope.eventFilters.HealthPlanId, $scope.eventFilters.CriteriaId).then(function (eventFilterCriteria) {
                var lastCriteria = Number(healthplanlocalstorage.GetCriteriaId());
                if (lastCriteria > 0 && lastCriteria !== Number(eventFilterCriteria.Id)) {
                    logger.showToasterSuccess('Event list has been Updated.');
                }
                healthplanlocalstorage.SetCriteriaId(eventFilterCriteria.Id);
                $scope.EventFilterCriteria = eventFilterCriteria;
            });
        };

        $scope.GetEventByPageNumber = function (pageNumber) {
            $scope.isPosted = true;
            $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
            $scope.EventList = null;
            $scope.eventFilters.PageNumber = pageNumber;
            $scope.loader_filter = true;
            $scope.showNoEventInList = false;

            searchHealthPlanService.GetOutboundEventList($scope.eventFilters).then(function (result) {
                $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                if (result != null) {
                    if (result.Events == null || result.Events.length <= 0) {
                        $scope.showNoEventInList = true;
                    }
                    $scope.EventList = result.Events;
                    $scope.PagingModel = result.PagingModel;
                }

                $scope.isPosted = false;
                $scope.loader_filter = false;
            }, function (result) {
                $scope.SystemGeneratedCallQueueCriteria();
                if (result != null && result.Events == null) {
                    $scope.showNoEventInList = true;
                }
                if (result == undefined) {
                    $scope.showNoEventInList = true;
                    $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                }
                $scope.isPosted = false;
                $scope.loader_filter = false;
            });
        };

        $scope.filterEvent = function (form) {
            form.submitted = true;
            if (form.$valid) {
                $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
                $scope.GetEventByPageNumber(1);
                form.submitted = false;
            }
        };

        $scope.clearFilter = function () {
            $scope.eventFilters.EventId = null;
            $scope.eventFilters.Pod = '';
        };

        $scope.getCustomerForCall = function(event) {
            $scope.disableStartCallingButton = true;
            usSpinnerService.spin('online-spinner');
            var filter = { EventId: event.Id, Pod: $scope.eventFilters.Pod, FillEventZipCode: event.HostAddress.ZipCode };
            healthplanlocalstorage.SetFilledEventCallQueueFilter(filter);
            var searchModel = {
                CallQueueId: window.localStorage.hpCallQueueId,
                EventId: filter.EventId,
                HealthPlanId: window.localStorage.hpHealthPlanId,
                ZipCode: filter.FillEventZipCode,
                Radius: window.localStorage.hpRadius,
                UseCustomTagExclusively: false,
                PageNumber: 1,
                CriteriaId: window.localStorage.hpCriteriaId
            };

            //Clear Irrelevant data stored for other Queues
            healthplanlocalstorage.ClearLocalStorageForFillEvent();

            //searchHealthPlanService.ViewAvailableCustomerForFillEvent(searchModel).then(function (result) {
            //    if (result.NoMoreCustomerInList) {
            //        logger.showToasterError("No Customer in this Call Queue");
            //        $state.transitionTo('CallCentreDashboard');
            //    } else {
            //        usSpinnerService.stop('online-spinner');
            //        window.sessionStorage.setItem("showCallPanel", false);
            //        window.localStorage.setItem("isScriptOpen", true);
            //        $state.go('healthplanContact', { callQueueCustomerId: result.CallQueueCustomerId, attemptId: result.AttemptId });
            //    }
            //}, function () {
            //    $scope.disableStartCallingButton = false;
            //    logger.showToasterError('Some Error Occurred, cannot get Customer for Call');
            //    usSpinnerService.stop('online-spinner');
            //});

            $scope.GetNextCustomerForCall(searchModel);
        };
        
        $scope.GetNextCustomerForCall = function (searchModel) {

            searchHealthPlanService.ViewAvailableCustomerForFillEvent(searchModel).then(function (result) {
                if (result.TryAgain) {
                    $scope.GetNextCustomerForCall(searchModel);
                } else if (result.AssignmentChanged) {
                    logger.showToasterError("Your assignment is changed.");
                    $scope.isCallQueueSelected = false;
                    usSpinnerService.stop('online-spinner');
                    $state.transitionTo('CallCentreDashboard');
                } else if (result.NoMoreCustomerInList) {
                    logger.showToasterError("No Customer in this Call Queue");
                    $state.transitionTo('CallCentreDashboard');
                } else {
                    usSpinnerService.stop('online-spinner');
                    window.sessionStorage.setItem("showCallPanel", false);
                    //window.localStorage.setItem("isScriptOpen", true);
                    $state.go('healthplanContact', { callQueueCustomerId: result.CallQueueCustomerId, attemptId: result.AttemptId });
                }
            }, function () {
                $scope.disableStartCallingButton = false;
                logger.showToasterError('Some Error Occurred, cannot get Customer for Call');
                usSpinnerService.stop('online-spinner');
            });

        };

        $scope.ClearData = function () {
            $scope.EventList = null;
            $scope.PagingModel = { "NumberOfItems": 0, "PageUrl": null, "CurrentPage": 1, "PageCount": 0 };
        };
        init();
    }]);

}());
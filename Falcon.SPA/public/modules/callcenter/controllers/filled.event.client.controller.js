(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.filledEventController,
    [
        '$rootScope', '$scope', '$stateParams', '$state', 'usSpinnerService', CallCenterConfiguration.services.searchQueueService, CoreConfiguration.constants,CallCenterConfiguration.services.callQueueCriteriaSerivce,
        function ($rootScope, $scope, $stateParams, $state, usSpinnerService, searchQueueService, constants, callQueueCriteriaSerivce) {
            $scope.category = null;
            $scope.CallQueueCategory = constants.CallQueueCategory;
            
            $scope.showNoEventInList = false;
            $scope.EventList = null;
            $scope.PagingModel = null;
            $scope.isPosted = false;
            $scope.eventFilters = { EventId: null, Pod: '', PageNumber: 1, CallQueueId: $stateParams.categoryId };
            
            $scope.RegistrationMode = constants.RegistrationMode;
            
            function init() {
                
                localStorage.removeItem('CallQueueId');
                localStorage.removeItem('Name');
                localStorage.removeItem('PhoneNumber');
                localStorage.removeItem('ZipCode');
                localStorage.removeItem('Radius');
                localStorage.removeItem('EventId');
                localStorage.removeItem('Tag');

                $scope.isPosted = true;

                usSpinnerService.spin('online-spinner');
                
                searchQueueService.GetSelectedCategory($stateParams.categoryId).then(function (item) {
                    $scope.selectedCategory = {
                        value: item.Id, text: item.Name, Category: item.Category
                    }; 
                });
                
                searchQueueService.GetOutboundEventList($scope.eventFilters).then(function (result) {
                    if (result != null) {
                        if (result.Events == null || result.Events.length <= 0) {
                            $scope.showNoEventInList = true;
                        }
                        $scope.EventList = result.Events;
                        $scope.PagingModel = result.PagingModel;
                    }

                    

                    setTimeout(function () { usSpinnerService.stop('online-spinner'); }, 1000);
                }, function () {
                    $scope.showNoEventInList = true;
                    usSpinnerService.stop('online-spinner');
                });
                callQueueCriteriaSerivce.GetSystemGeneratedCallQueueCriteria($scope.eventFilters.CallQueueId).then(function (eventFilterCriteria) {
                    $scope.EventFilterCriteria = eventFilterCriteria;
                });
                $scope.isPosted = false;
            };


            $scope.GetEventByPageNumber = function (pageNumber) {
                $scope.isPosted = true;
                $scope.PagingModel = null;
                $scope.EventList = null;
                $scope.eventFilters.PageNumber = pageNumber;
                $scope.loader_filter = true;
                $scope.showNoEventInList = false;
                searchQueueService.GetOutboundEventList($scope.eventFilters).then(function (result) {
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
                    if (result != null && result.Events == null) {
                        $scope.showNoEventInList = true;
                    }
                    $scope.isPosted = false;
                    $scope.loader_filter = false;
                });
            };

            $scope.filterEvent = function(form) {
                form.submitted = true;
                if (form.$valid) {
                    $scope.PagingModel = null;
                    $scope.GetEventByPageNumber(1);
                    form.submitted = false;
                }
            };

            $scope.clearFilter = function() {
                $scope.eventFilters.EventId = null;
                $scope.eventFilters.Pod = '';
            };

            $scope.ManageCategory = function () {
                $state.go("callqueues");
            };

            $scope.getCustomersByEvent = function (event) {
                window.localStorage.setItem('EventId', event.Id);
                window.localStorage.setItem('CallQueueId', $stateParams.categoryId);
                $state.go("SearchQueue");
            };

            $scope.ClearData = function() {
                $scope.EventList = null;
                $scope.PagingModel = null;
            };
            init();
        }]);

}());
(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.callroundqueuecController,
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', 'usSpinnerService',
            CallCenterConfiguration.services.searchHealthPlanService, '$modal',
            CoreConfiguration.constants, CallCenterConfiguration.services.healthplanlocalstorage,
            CallCenterConfiguration.services.healthPlanCallQueueCriteriaSerivce, CallCenterConfiguration.services.searchQueueService, 'analytics',
            function ($rootScope, $scope, $stateParams, $state, logger, usSpinnerService, searchHealthPlanService, $modal, constants, healthplanlocalstorage, healthPlanCallQueueCriteriaSerivce,
                searchQueueService, analytics) {

                $scope.CallQueueCategory = constants.HealthPlanCallQueueCategory;
                $scope.EventType = constants.EventType;
                $scope.RegistrationMode = constants.RegistrationMode;
                $scope.GenderEnum = constants.Gender;
                $scope.healthPlanCriteria = null;
                $scope.HealthPlan = "";
                $scope.HealthPlanTag = "";
                $scope.data = {};
                $scope.FillEventZipCode = '';
                $scope.FilterZipCode = '';
                $scope.isDefaultSearch = false;

                $scope.selectedCategory = null;
                $scope.PagingModel = { NumberOfItems: 0, PageSize: 25 };
                $scope.CustomerFilters =
                        {
                            CallQueueId: null,
                            PageNumber: 1,
                            ZipCode: '',
                            Radius: 0,
                            EventId: null,
                            HealthPlanId: 0,
                            UseCustomTagExclusively: true,
                            CriteriaId: 0,
                            CampaignId: null,
                            DirectMailStartDate: null,
                            DirectMailEndDate: null,
                            DirectMailDate: "",
                        };
                $scope.pagenumber = 1;
                $scope.isPosted = false;
                $scope.callingCustomer = 0;
                $scope.showOrderDetailLink = false;
                $scope.IsPopUpShown = false;
                $scope.CustomerFilterHistory = null;

                $scope.DirectMailDateDropDown = null;

                function init() {

                    $scope.CustomerFilters = healthplanlocalstorage.GetCallRoundFilter();
                    $scope.healthPlanId = $scope.CustomerFilters.HealthPlanId;
                    $scope.HealthPlan = $scope.CustomerFilters.HealthPlan;
                    $scope.HealthPlanTag = $scope.CustomerFilters.HealthPlanTag;

                    if ($scope.CustomerFilters.CallQueueId <= 0) {
                        logger.showToasterError('Please select call queue type.');
                        $state.go("healthplanCategory");
                        return;
                    }

                    searchHealthPlanService.GetSelectedCategory($scope.CustomerFilters.CallQueueId).then(function (item) {

                        $scope.selectedCategory = {
                            value: item.Id, text: item.Name, Category: item.Category
                        };

                        if ($scope.selectedCategory.Category === $scope.CallQueueCategory.FillEventsHealthPlan) {
                            $scope.FillEventZipCode = healthplanlocalstorage.GetFilledEventZipCode();
                            $scope.isDefaultSearch = true;
                        }

                        if (typeof $scope.CustomerFilters.ZipCode !== 'undefined' && $scope.CustomerFilters.ZipCode != '') {
                            $scope.isDefaultSearch = false;
                        }

                        if ($scope.selectedCategory.Category === $scope.CallQueueCategory.MailRound) {

                            searchHealthPlanService.GetDirectMailDates($scope.CustomerFilters.CampaignId).then(function (directMailDates) {
                                var directMails = [];
                                $.each(directMailDates, function (key, value) {
                                    directMails.push(moment(value).format("MM/DD/YYYY"));
                                });
                                
                                $scope.DirectMailDateDropDown = directMails;
                            });
                        }

                        var filter = $scope.CustomerFilters;
                        filter.PageNumber = 1;
                        $scope.getCustomerbyFilters(filter);

                        healthPlanCallQueueCriteriaSerivce.GetSystemGeneratedCallQueueCriteria($scope.CustomerFilters.CallQueueId, $scope.CustomerFilters.HealthPlanId, $scope.CustomerFilters.CampaignId).then(function (item) {

                            if (item != null) {
                                $scope.healthPlanCriteria = item;
                                if ($scope.selectedCategory.Category == $scope.CallQueueCategory.NoShows) {
                                    if ($scope.healthPlanCriteria.StartDate != null && typeof ($scope.healthPlanCriteria.StartDate) != 'undefined' && $scope.healthPlanCriteria.StartDate != '') {
                                        $scope.healthPlanCriteria.StartDate = moment($scope.healthPlanCriteria.StartDate).format('MM/DD/YYYY');
                                    }

                                    if ($scope.healthPlanCriteria.EndDate != null && typeof ($scope.healthPlanCriteria.EndDate) != 'undefined' && $scope.healthPlanCriteria.EndDate != '') {
                                        $scope.healthPlanCriteria.EndDate = moment($scope.healthPlanCriteria.EndDate).format('MM/DD/YYYY');
                                    }

                                    $scope.healthPlanCriteria.CreateNewCriteria = false;
                                }
                            }

                        });
                    });
                }

                $scope.UpdateCallQueueCriteria = function () {

                    healthPlanCallQueueCriteriaSerivce.GetSystemGeneratedCallQueueCriteria($scope.CustomerFilters.CallQueueId, $scope.CustomerFilters.HealthPlanId, $scope.CustomerFilters.CampaignId).then(function (item) {

                        if (item != null) {
                            $scope.healthPlanCriteria = item;
                            if ($scope.selectedCategory.Category == $scope.CallQueueCategory.NoShows) {
                                if ($scope.healthPlanCriteria.StartDate != null && typeof ($scope.healthPlanCriteria.StartDate) != 'undefined' && $scope.healthPlanCriteria.StartDate != '') {
                                    $scope.healthPlanCriteria.StartDate = moment($scope.healthPlanCriteria.StartDate).format('MM/DD/YYYY');
                                }

                                if ($scope.healthPlanCriteria.EndDate != null && typeof ($scope.healthPlanCriteria.EndDate) != 'undefined' && $scope.healthPlanCriteria.EndDate != '') {
                                    $scope.healthPlanCriteria.EndDate = moment($scope.healthPlanCriteria.EndDate).format('MM/DD/YYYY');
                                }

                                $scope.healthPlanCriteria.CreateNewCriteria = false;
                            }
                        } else {
                            $scope.healthPlanCriteria = item;
                        }

                    });
                };

                $scope.getCustomerbyFilters = function (req) {
                    $scope.isPosted = true;
                    $scope.loader_filter = true;
                    usSpinnerService.spin('online-spinner');
                    $scope.FilterZipCode = req.ZipCode;
                    searchHealthPlanService.GetOutboundCallQueue(req).then(function (result) {

                        if (result != null) {

                            if (result.IsQueueGenerated == false)
                                logger.showToasterError('Please wait for 10 minutes(max) as your Call center manager has changed the criteria so that the queue is regenerated.');

                            $scope.data.Customers = result.OutboundCallQueues;
                            $scope.PagingModel = result.PagingModel;

                            if (result.IsQueueChanged) {
                                logger.showToasterSuccess('Customer list has been Updated.');
                                $scope.UpdateCallQueueCriteria();
                                $scope.CustomerFilters.PageNumber = 1;
                            }

                            healthplanlocalstorage.SetCriteriaId(result.CriteriaId);
                            req.CriteriaId = result.CriteriaId;
                            $scope.CustomerFilters.CriteriaId = result.CriteriaId;
                        }

                        if ($scope.CallQueueCategory != null && $scope.selectedCategory.Category === $scope.CallQueueCategory.FillEventsHealthPlan) {
                            $scope.showEventCatory = true;
                        }
                        setTimeout(function () { usSpinnerService.stop('online-spinner'); }, 1000);

                        $scope.isPosted = false;
                        $scope.loader_filter = false;
                        $scope.CustomerFilterHistory = angular.copy(req);

                    }, function () {
                        setTimeout(function () { usSpinnerService.stop('online-spinner'); }, 1000);

                        $scope.isPosted = false;
                        $scope.loader_filter = false;
                    });
                };

                $scope.filterCustomer = function (form) {
                    form.submitted = true;

                    if (form.$valid) {
                        $scope.PagingModel = { NumberOfItems: 0, PageSize: 25 };
                        $scope.CustomerFilters.PageNumber = 1;

                        if (typeof $scope.CustomerFilters.ZipCode !== 'undefined' && $scope.CustomerFilters.ZipCode != '') {
                            $scope.isDefaultSearch = false;
                        } else { $scope.isDefaultSearch = true; }

                        healthplanlocalstorage.SetCallRoundFilter($scope.CustomerFilters);

                        $scope.getCustomerbyFilters($scope.CustomerFilters);

                        form.submitted = false;
                    }
                };

                function isHistorySame() {
                    var h = $scope.CustomerFilterHistory;
                    var c = $scope.CustomerFilters;
                    
                    return h.ZipCode == c.ZipCode && h.Radius == c.Radius && h.EventId == c.EventId
                            && h.DirectMailStartDate == c.DirectMailStartDate && h.DirectMailEndDate == c.DirectMailEndDate
                            && h.DirectMailDate == c.DirectMailDate;

                }
                //Customer
                $scope.GetPage = function (number) {

                    $scope.PagingModel = { NumberOfItems: 0, PageSize: 25 };
                    if ($scope.CustomerFilterHistory != null && isHistorySame()) {
                        $scope.CustomerFilters.PageNumber = number;
                        $scope.getCustomerbyFilters($scope.CustomerFilters);
                    } else {
                        $scope.CustomerFilterHistory.PageNumber = number;
                        $scope.getCustomerbyFilters($scope.CustomerFilterHistory);
                    }
                };

                //StartCall
                $scope.StartOutboundCall = function (customer) {
                    $scope.isPosted = true;
                    $scope.callingCustomer = customer.CallQueueCustomerId;

                    searchQueueService.StartCall(customer.CallQueueCustomerId, $scope.CustomerFilters.CustomCorporateTag).then(function (result) {
                        if (result != null) {
                            if (result.IsDoNotCall)
                                logger.showToasterError('This customer is marked as Do not call, by another agent.');
                            
                            if (result.IsRemovedFromQueue)
                                logger.showToasterError('This customer is removed from queue, by another agent.');

                            if (result.IsAlreadyCalledToday) {
                                logger.showToasterError('This customer is already called today by another agent.');
                                $scope.getCustomerbyFilters($scope.CustomerFilters);
                            }

                            if (result.IsAlreadyLocked)
                                logger.showToasterError('Another agent is already in call with the customer.');
                            
                            if (result.CallId > 0) {
                                if (($scope.selectedCategory.Category === $scope.CallQueueCategory.Upsell || $scope.selectedCategory.Category === $scope.CallQueueCategory.Confirmation)) {
                                    window.location.href = ApplicationConfiguration.appUrl + '/CallCenter/CallQueue/CustomerDetails?callQueueCustomerId=' + customer.CallQueueCustomerId + '&customerId=' + customer.CustomerId + "&callId=" + result.CallId;
                                } else {
                                    $state.go('healthplanContact', { callQueueCustomerId: customer.CallQueueCustomerId, callId: result.CallId });
                                }
                            }
                        }
                        $scope.isPosted = false;
                        $scope.callingCustomer = 0;

                    }, function () {
                        $scope.isPosted = false;
                        $scope.callingCustomer = 0;
                    });
                };
                
                var modelPopupInstance = null;
                $scope.ShowEventPreview = function (customer) {
                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/healthplan/event.preview.model.popup.view.html',
                        controller: 'EventPreviewModelController',
                        backdrop: 'static',
                        size: 'lg',
                        resolve: {
                            ModalParams: function () {
                                return {
                                    ZipCode: customer.ZipCode,
                                    HealthPlanId:$scope.healthPlanId,
                                    onclose: function () {
                                    modelPopupInstance.close();
                                } };
                            }
                        }
                    });
                };

                $scope.clearFilter = function () {
                    $scope.CustomerFilters.ZipCode = '';
                    $scope.CustomerFilters.DirectMailStartDate = null;
                    $scope.CustomerFilters.DirectMailEndDate = null;
                    $scope.CustomerFilters.DirectMailDate = "";
                };

                $scope.ManageCategory = function () {
                    if ($scope.CallQueueCategory.FillEventsHealthPlan == $scope.selectedCategory.Category) {
                        $state.go("healthplanfillevents");
                    } else if ($scope.CallQueueCategory.MailRound == $scope.selectedCategory.Category) {
                        $state.go("healthplancampaigns");
                    } else {
                        $state.go("healthplanCategory");
                    }
                };

                $scope.DoNotCall = function (customer, donotcall) {
                    $scope.isPosted = true;
                    searchQueueService.UpdateDoNotCallStatus(customer.CallQueueCustomerId, donotcall).then(function (result) {
                        if (result != null) {
                            if (result.IsDoNotCall)
                                logger.showToasterError('This customer is marked as Do not call, by another agent.');
                            else if (result.IsRemovedFromQueue)
                                logger.showToasterError('This customer is removed from queue, by another agent.');
                            else if (result.CallId > 0) {
                                logger.showToasterError('This customer is in call with another agent.');
                            }
                            else
                                customer.IsDoNotCallCustomer = donotcall;
                        }

                        $scope.isPosted = false;
                    });
                };

                $scope.ClearData = function () {
                    $scope.data.Customers = null;
                    $scope.PagingModel = { NumberOfItems: 0, PageSize: 25 };
                };



                init();
            }]);

}());
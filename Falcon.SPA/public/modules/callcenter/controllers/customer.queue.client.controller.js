(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.searchQueueController,
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', 'usSpinnerService',
            CallCenterConfiguration.services.searchQueueService, '$modal', CoreConfiguration.constants, CallCenterConfiguration.services.tagsDropdownHelper,
            function ($rootScope, $scope, $stateParams, $state, logger, usSpinnerService, searchQueueService, $modal, constants, tagsDropdownHelper) {

                $scope.CallQueueCategory = constants.CallQueueCategory;
                $scope.EventType = constants.EventType;
                $scope.RegistrationMode = constants.RegistrationMode;
                $scope.GenderEnum = constants.Gender;

               
                $scope.data = {};
                $scope.tags = tagsDropdownHelper.get();
               
                $scope.selectedCategory = null;
                $scope.PagingModel = null;
                $scope.CustomerFilters = { CallQueueId: null, Name: '', Email: '', PhoneNumber: '', PageNumber: 1, ZipCode: null, Radius: 0, EventId: null, Tag: '' };
                $scope.pagenumber = 1;
                $scope.isPosted = false;
                $scope.callingCustomer = 0;
                $scope.showOrderDetailLink = false;
                $scope.IsPopUpShown = false;
                $scope.CustomerFilterHistory = null;
                
                var getPropertyValue = function (propterty) {
                    if (typeof propterty === "undefined" || propterty === "null" || propterty === "" || propterty === "undefined")
                        return "";
                    return propterty;
                };
               
                var setFilterValueLocalStorage = function (filter) {
                    window.localStorage.setItem('Name', filter.Name);
                    window.localStorage.setItem('PhoneNumber', filter.PhoneNumber);
                    window.localStorage.setItem('ZipCode', filter.ZipCode);
                    //window.localStorage.setItem('Radius', filter.Radius);
                    window.localStorage.setItem('EventId', filter.EventId);
                    window.localStorage.setItem('Tag', filter.Tag);
                };

                var getFilterValueFromLocalStorage = function () {
                    $scope.CustomerFilters.Name = getPropertyValue(window.localStorage.Name);
                    $scope.CustomerFilters.PhoneNumber = getPropertyValue(window.localStorage.PhoneNumber);
                    $scope.CustomerFilters.ZipCode = getPropertyValue(window.localStorage.ZipCode);
                    //$scope.CustomerFilters.Radius = getPropertyValue(window.localStorage.Radius);
                    $scope.CustomerFilters.EventId = getPropertyValue(window.localStorage.EventId);
                    $scope.CustomerFilters.Tag = getPropertyValue(window.localStorage.Tag);
                    

                    var quequeId = window.localStorage.CallQueueId;
                    if (typeof quequeId === 'undefined' || quequeId === null || quequeId === '') {
                        $scope.CustomerFilters.CallQueueId = 0;
                    } else {
                        $scope.CustomerFilters.CallQueueId = Number(quequeId);
                    }
                };

                $scope.getAllCustomers = function () {
                    $scope.showCustomers = true;

                    var req = $scope.CustomerFilters;
                    req.PageNumber = 1;
                    $scope.getCustomerbyFilters(req);
                };

                function init() {
                    getFilterValueFromLocalStorage();

                    searchQueueService.GetSelectedCategory($scope.CustomerFilters.CallQueueId).then(function (item) {
                        $scope.selectedCategory = {
                            value: item.Id, text: item.Name, Category: item.Category
                        };
                        if ($scope.selectedCategory.Category === $scope.CallQueueCategory.Confirmation || $scope.selectedCategory.Category === $scope.CallQueueCategory.Upsell) {
                            $scope.showOrderDetailLink = true;
                        }
                        
                        var isShown = getPropertyValue(window.localStorage.IsPopUpShown);
                        if ($scope.IsPopUpShown == false && isShown == "true")
                            $scope.IsPopUpShown = true;
                        if ($scope.IsPopUpShown == false && (typeof $scope.CustomerFilters.ZipCode == "undefined" || $scope.CustomerFilters.ZipCode == '') && (typeof $scope.CustomerFilters.EventId == "undefined" || $scope.CustomerFilters.EventId == '' || $scope.CustomerFilters.EventId == 'null' || $scope.CustomerFilters.EventId == null)) {
                            usSpinnerService.stop('online-spinner');
                            $scope.askToFilterByZip();
                            window.localStorage.setItem('IsPopUpShown', true);
                        } else {
                            $scope.getAllCustomers();
                        }
                    });
                }

                $scope.getCustomersByZip = function (zipCode) {
                    $scope.showCustomers = true;

                    $scope.CustomerFilters.ZipCode = zipCode;
                    setFilterValueLocalStorage($scope.CustomerFilters.ZipCode);
                    $scope.getCustomerbyFilters($scope.CustomerFilters);

                };

                $scope.getCustomerbyFilters = function (req) {
                    $scope.isPosted = true;
                    $scope.loader_filter = true;

                    usSpinnerService.spin('online-spinner');
                    searchQueueService.GetOutboundCallQueue(req).then(function (result) {
                        if (result != null) {
                            if (result.IsQueueGenerated == false && $scope.CallQueueCategory != null && ($scope.selectedCategory.Category === $scope.CallQueueCategory.FillEvents || $scope.selectedCategory.Category === $scope.CallQueueCategory.Upsell || $scope.selectedCategory.Category === $scope.CallQueueCategory.Confirmation))
                                logger.showToasterError('Please wait for 10 minutes(max) after you have changed the criteria so that the queue is regenerated.');
                            $scope.data.Customers = result.OutboundCallQueues;
                            $scope.PagingModel = result.PagingModel;
                        }

                        if ($scope.CallQueueCategory != null && $scope.selectedCategory.Category === $scope.CallQueueCategory.FillEvents) {
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

                        $scope.PagingModel = null;

                        $scope.CustomerFilters.Name = $scope.CustomerFilters.Name;
                        $scope.CustomerFilters.Email = $scope.CustomerFilters.Email;
                        $scope.CustomerFilters.PhoneNumber = $scope.CustomerFilters.PhoneNumber;
                        $scope.CustomerFilters.Tag = $scope.CustomerFilters.Tag;
                        $scope.CustomerFilters.PageNumber = 1;

                        setFilterValueLocalStorage($scope.CustomerFilters);

                        $scope.getCustomerbyFilters($scope.CustomerFilters);

                        form.submitted = false;
                    }
                };
                function isHistorySame() {
                    var h = $scope.CustomerFilterHistory;
                    var c = $scope.CustomerFilters;
                    return h.Name == c.Name && h.Email == c.Email && h.PhoneNumber == c.PhoneNumber && h.ZipCode == c.ZipCode && h.Radius == c.Radius && h.EventId == c.EventId && h.Tag == c.Tag;

                }
                //Customer
                $scope.GetPage = function (number) {
                    $scope.PagingModel = null;
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

                    searchQueueService.StartCall(customer.CallQueueCustomerId).then(function (result) {
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
                                    $state.go('Contact', { callQueueCustomerId: customer.CallQueueCustomerId, callId: result.CallId });
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
                $scope.askToFilterByZip = function () {

                    var modalPopupObject = {
                        showTitle: false,
                        Title: '',
                        showCancelButton: false,
                        cancelButtonText: '',
                        showOkButton: true,
                        OKButtonText: 'OK',
                        Message: '',
                        CallBackOnOkButton: $scope.getAllCustomers,
                        CallBackOnEscape: $scope.getAllCustomers,
                        CallBackOnSearchButton: $scope.getCustomersByZip
                    };

                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/searchqueue/filterByzip.client.view.html',
                        backdrop: 'static',
                        keyboard: false,
                        controller: ['$scope', 'data', 'logger', function (scope, data, log) {

                            scope.modal = {};
                            scope.modal.showOKButtonButton = true;
                            scope.closeOnEscape = true;
                            scope.modal = data;

                            scope.zipCode = '';
                            scope.isZipCodeValid = true;
                            $scope.SearchCustomerByZipCode = false;

                            scope.IsOkButtonclicked = false;
                            scope.IsSearchButtonclicked = false;
                            scope.FilterOptionChanged = function (result) {
                                scope.SearchCustomerByZipCode = result;
                            };
                            scope.onOkbutton = function () {
                                if (scope.SearchCustomerByZipCode) {
                                    if (scope.zipCode != '' && scope.zipCode.length == 5) {
                                        scope.isZipCodeValid = true;
                                        scope.$close();
                                    } else if (scope.zipCode != '' && scope.zipCode.length != 5) {
                                        scope.isZipCodeValid = false;
                                        log.showToasterError('Please provide valid ZipCode');
                                    }
                                }
                                else {
                                    scope.IsOkButtonclicked = true;
                                    scope.$close();
                                }
                            };

                            scope.$on('$destroy', function () {
                               
                                if (scope.SearchCustomerByZipCode == false) {
                                    scope.modal.CallBackOnOkButton();
                                } else if (scope.SearchCustomerByZipCode) {
                                    scope.modal.CallBackOnSearchButton(scope.zipCode);
                                }
                                else if (scope.closeOnEscape) {
                                    scope.modal.CallBackOnEscape();
                                }
                            });
                        }],
                        size: 'sm',
                        resolve: {
                            data: function () {
                                return modalPopupObject;
                            }
                        }
                    });
                };

                $scope.$on('$destroy', function () {
                    if (modelPopupInstance != null) {
                        modelPopupInstance.close();
                    }
                });

                $scope.clearFilter = function () {
                    $scope.CustomerFilters.Name = '';
                    $scope.CustomerFilters.Email = '';
                    $scope.CustomerFilters.PhoneNumber = '';
                    $scope.CustomerFilters.ZipCode = '';
                    $scope.CustomerFilters.Tag = '';
                    $scope.CustomerFilters.EventId = '';
                };

                $scope.GoToFillEventList = function () {
                    $state.go('EventFilled', { categoryId: $scope.CustomerFilters.CallQueueId });
                };
                $scope.ManageCategory = function () {
                    $state.go("callqueues");
                };

                $scope.showSmallColumns = function () {
                    if ($scope.selectedCategory !== null && ($scope.selectedCategory.Category === $scope.CallQueueCategory.Upsell || $scope.selectedCategory.Category === $scope.CallQueueCategory.Confirmation || $scope.selectedCategory.Category === $scope.CallQueueCategory.EasiestToConvertProspect)) {
                        return true;
                    }
                    return false;
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
                    $scope.PagingModel = null;
                };
                init();
            }]);

}());
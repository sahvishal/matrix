(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.eventController,
        ['$scope', '$rootScope', '$stateParams', '$state', 'logger', CoreConfiguration.constants, OnlineConfiguration.services.eventService,
            OnlineConfiguration.services.eventParameterService, "usSpinnerService",OnlineConfiguration.services.localStorageProgressBarService,
            function ($scope, $rootScope, $stateParams, $state, logger, constants, eventService, eventParameterService, usSpinnerService, localStorageProgressBarService) {

                $rootScope.title = $state.current.title;
                $scope.changeZipCode = false;
                $scope.data = {};
                $scope.eventFilter = {};

                $scope.constants = constants;
                $scope.ShowTryDiffrentLocation = false;
                $scope.isPosted = false;
                $scope.changezipwrap = true;
                $scope.TempCartEventId = 0;
                $scope.zipCode = '';
                $scope.glowContinueButtonOnSelection = false;
                $scope.isSearchInProgress = true;
                $rootScope.currentState = constants.ProgressBarSteps.Location;
                $scope.ProgressBarStatus = constants.ProgressBarStatus;
                localStorageProgressBarService.UpdateLocation($stateParams.guid, $scope.ProgressBarStatus.Started);
                $scope.phoneTollFree = ApplicationConfiguration.phoneTollFree;

                $scope.sortByOrderHelper = [{
                    value: 0,
                    text: 'Earliest Event'
                }, {
                    value: 1,
                    text: 'Nearest Location'
                }];

                $scope.sortByOrderHelperMobile = [{
                    value: 0,
                    text: 'Earliest'
                }, {
                    value: 1,
                    text: 'Nearest'
                }];

                $scope.orderby = {
                    value: 1,
                    text: 'Nearest Location'
                };

                $scope.bindFilerWithStateParams = function () {
                    var param = eventParameterService.get();

                    $scope.eventFilter = param;
                    $scope.eventFilter.pageNumber = 1;
                    $scope.eventFilter.sortOrderBy = $scope.orderby.value;
                    $scope.changeZipCode = typeof $scope.eventFilter.zipCode === 'undefined' || $scope.eventFilter.zipCode === '' || $scope.eventFilter.zipCode === 'null' || $scope.eventFilter.zipCode === null;

                    $scope.eventId = param.eventId;

                    if (typeof $scope.eventFilter.zipCode !== 'undefined' && $scope.eventFilter.zipCode !== '' && $scope.eventFilter.zipCode !== 'null' && $scope.eventFilter.zipCode !== null) {
                        $scope.zipCode = param.zipCode;
                    }

                    $scope.guid = param.guid;
                };

                $scope.bindFilerWithStateTempCart = function (tempCart) {
                    if (typeof (tempCart) !== 'undefined' && tempCart != null) {
                        if (tempCart.EventId !== null && Number(tempCart.EventId) > 0) {
                            $scope.TempCartEventId = tempCart.EventId;
                        }

                        eventParameterService.updateWithTempcart(tempCart);

                        $scope.eventFilter = eventParameterService.get();
                        $scope.eventFilter.pageNumber = 1;
                        $scope.eventFilter.sortOrderBy = $scope.orderby.value;

                        if ((typeof $scope.zipCode == 'undefined' || $scope.zipCode === "" || $scope.zipCode == 'null')) {
                            $scope.zipCode = tempCart.ZipCode;
                        }

                        $scope.eventId = tempCart.EventId;
                        $scope.guid = tempCart.Guid;

                    }
                };

                var isParameterNotEmptyorNull = function () {

                    if (typeof ($scope.eventFilter.zipCode) != 'undefined' && $scope.eventFilter.zipCode != "" && $scope.eventFilter.zipCode != "null") return true;
                    if (typeof ($scope.eventFilter.guid) != 'undefined' && $scope.eventFilter.guid != "" && $scope.eventFilter.guid != "null") return true;
                    if (typeof ($scope.eventFilter.invitationCode) != 'undefined' && $scope.eventFilter.invitationCode != "" && $scope.eventFilter.invitationCode != "null") return true;
                    if (typeof ($stateParams.guid) != 'undefined' && $stateParams.guid != "" && $stateParams.guid != "null") {
                        $scope.eventFilter.guid = $stateParams.guid;
                        return true;
                    }
                    return false;
                };

                $scope.getEventList = function () {

                    if (isParameterNotEmptyorNull()) {
                        $scope.isSearchInProgress = true;
                        $scope.loader = true;
                        eventService.fetchEvents($scope.eventFilter).then(function (data) {
                            $scope.isSearchInProgress = false;
                            if (typeof data.Events === 'undefined' || data.Events === null || data.Events.length <= 0) {
                                $scope.ShowTryDiffrentLocation = true;
                            } else {
                                $scope.ShowTryDiffrentLocation = false;
                            }
                            $scope.data = data;
                            if (typeof data.RequestValidationModel != 'undefined' && data.RequestValidationModel != null && typeof data.RequestValidationModel.TempCart != 'undefined' && data.RequestValidationModel.TempCart != null) {
                                var zipcode = $scope.eventFilter.zipCode;

                                if (typeof (zipcode) != 'undefined' && zipcode != "" && zipcode != "null" && zipcode != null) {
                                    data.RequestValidationModel.TempCart.ZipCode = zipcode;
                                }

                                $scope.bindFilerWithStateTempCart(data.RequestValidationModel.TempCart);
                            }
                            if (data != null && data.PagingModel != null) {
                                $scope.eventFilter.pageNumber = data.PagingModel.CurrentPage;
                            }

                            $scope.changeZipCode = typeof $scope.eventFilter.zipCode === 'undefined' || $scope.eventFilter.zipCode === '' || $scope.eventFilter.zipCode === 'null' || $scope.eventFilter.zipCode === null;

                            if ($scope.changezipwrap == false) {
                                $scope.changezipwrap = true;
                            }

                            if (typeof (data.CheckoutPhoneNumber) !== 'undefined' && data.CheckoutPhoneNumber !== null && data.CheckoutPhoneNumber !== '') {
                                $rootScope.CheckoutPhoneNumber = data.CheckoutPhoneNumber;
                            }

                            $scope.loader_EventsByZip = false;
                            setTimeout(function () {
                                usSpinnerService.stop('online-spinner');
                            }, 1000);

                        }, function () {
                            $scope.loader_EventsByZip = false;
                            usSpinnerService.stop('online-spinner');
                        });
                    } else {

                        $scope.loader_EventsByZip = false;
                        $scope.ShowTryDiffrentLocation = true;
                        usSpinnerService.stop('online-spinner');
                    }
                };

                $scope.oncontrollerLoad = function () {
                    $scope.bindFilerWithStateParams();
                    $scope.getEventList();
                };

                $scope.oncontrollerLoad();

                $scope.showSearchZipcode = function () {
                    $scope.changeZipCode = true;
                };

                $scope.toggleZipWrap = function () {
                    $scope.changezipwrap = !$scope.changezipwrap;
                };

                $scope.searchEventsByZipCode = function () {
                    if ($scope.zipCode !== '') {
                        $scope.changeZipCode = true;
                        $scope.loader_EventsByZip = true;


                        $scope.eventFilter.zipCode = $scope.zipCode;
                        $scope.eventFilter.pageNumber = 1;

                        $scope.getEventList();
                    } else {
                        logger.showToasterError('Please provide zipcode to search.');
                    }
                };


                $scope.selectEvent = function (e) {
                   
                    $scope.eventFilter.eventId = e.EventId;

                    if (typeof ($scope.eventFilter.zipCode) == 'undefined' || $scope.eventFilter.zipCode == 'null') {
                        $scope.eventFilter.zipCode = e.EventLocation.ZipCode;
                    }

                    $scope.eventId = e.EventId;
                    $scope.glowContinueButtonOnSelection = true;
                };

                $scope.selectEventOnRowClick = function (event) {
                    if (event.AvailableSlots >= 1 && event.IsMarkedOffforSelection === false) {
                        $scope.selectEvent(event);
                    }
                };

                var getPropertyValue = function (propterty) {
                    if (typeof propterty === "undefined" || propterty === "null" || propterty === "")
                        return "";
                    return propterty;
                };

                var getSelectedParams = function() {
                    var param = $scope.eventFilter;
                    return {
                        EventId: getPropertyValue(param.eventId),
                        Guid: getPropertyValue(param.guid),
                        ZipCode: getPropertyValue(param.zipCode),
                        Radius: getPropertyValue(param.radius),
                        InvitationCode: getPropertyValue(param.invitationCode),
                        CorpCode: getPropertyValue(param.corpcode),
                        CouponCode: getPropertyValue(param.cpncd),
                        RequestUrl: '',
                    };

                };
                
                $scope.loadergoForPreQualification = false;
                $scope.goForPreQualification = function () {                  
                    loadergoForPreQualification();
                };

                $scope.goForPreQualificationCheck = function (e) {
                   
                    if ($scope.data != null && $scope.data.RequestValidationModel != null && $scope.data.RequestValidationModel.TempCart != null) {
                        var tempCart = $scope.data.RequestValidationModel.TempCart;
                        if (typeof (tempCart) !== 'undefined' && tempCart != null && e.EventId != tempCart.EventId) {
                            localStorageProgressBarService.ResetProgressBar(tempCart.Guid);
                        }
                    }
                    
                    
                    $scope.selectEvent(e);
                    loadergoForPreQualification();
                };

                var loadergoForPreQualification = function() {
                    var param = getSelectedParams();
                    $scope.loadergoForPreQualification = true;
                    if (param != null && param.EventId !== 'null' && Number(param.EventId) > 0) {

                        $scope.isPosted = true;
                        if ($scope.TempCartEventId != param.EventId) {
                            eventService.saveSelectedEvent(param).then(function(result) {
                                $scope.isPosted = false;
                                param.Guid = result.RequestValidationModel.TempCart.Guid;
                                eventParameterService.updateWithTempcart(result.RequestValidationModel.TempCart);
                                $scope.loadergoForPreQualification = false;
                                $state.go('PreQualification', { guid: param.Guid });
                            },
                                function() {
                                    $scope.loadergoForPreQualification = false;
                                    $scope.isPosted = false;
                                });
                        } else {
                            $state.go('PreQualification', { guid: param.Guid });
                        }

                    } else {
                        $scope.loadergoForPreQualification = false;
                        logger.showToasterError('Please select a event to continue.');
                    }
                };              

                $scope.loaderRequestForScreening = false;

                $scope.RequestForScreening = function () {
                    $scope.loaderRequestForScreening = true;
                    $state.go('RequestEvent', { zip: $scope.zipCode });
                };


                //todo: split up paging in directive
                $scope.showPaging = function () {
                    if ($scope.data != null && $scope.data.PagingModel != null && $scope.data.PagingModel.PageCount > 1) {
                        return true;
                    }
                    return false;
                };
                $scope.showNextButton = function () {
                    if ($scope.data != null && $scope.data.PagingModel != null && $scope.data.PagingModel.CurrentPage < $scope.data.PagingModel.PageCount) {
                        return true;
                    }
                    return false;
                };
                $scope.showPreviousButton = function () {
                    if ($scope.data != null && $scope.data.PagingModel != null && $scope.data.PagingModel.CurrentPage > 1) {
                        return true;
                    }
                    return false;
                };

                $scope.previousButtonClick = function () {
                    $scope.eventFilter.pageNumber--;
                    $scope.getEventList();

                };
                $scope.nextButtonClick = function () {
                    $scope.eventFilter.pageNumber++;
                    $scope.getEventList();
                };

                $scope.eventShortBy = function () {

                    $scope.eventFilter.sortOrderBy = $scope.orderby.value;
                    $scope.getEventList();
                };

                $scope.eventAvilability = function (event) {

                    var avilabilityString = "";
                    if (event.MorningAvailableSlots > 0) {
                        avilabilityString = "Morning";
                    }
                    if (event.MorningAvailableSlots > 0 && event.AfternoonAvailableSlots > 0 && event.EveningAvailableSlots > 0) {
                        avilabilityString = avilabilityString + ", Afternoon";
                    } else if (event.MorningAvailableSlots > 0 && event.AfternoonAvailableSlots > 0 && event.EveningAvailableSlots <= 0) {
                        avilabilityString = avilabilityString + " and Afternoon";
                    } if (event.MorningAvailableSlots <= 0 && event.AfternoonAvailableSlots > 0) {
                        avilabilityString = "Afternoon";
                    }

                    if ((event.MorningAvailableSlots > 0 || event.AfternoonAvailableSlots > 0) && event.EveningAvailableSlots > 0) {
                        avilabilityString = avilabilityString + " and Evening";
                    } else if ((event.MorningAvailableSlots <= 0 && event.AfternoonAvailableSlots <= 0) && event.EveningAvailableSlots > 0) {
                        avilabilityString = "Evening";
                    }

                    if (avilabilityString != "") {
                        avilabilityString = avilabilityString + " appointments available";
                    }

                    return avilabilityString;
                };

            }]);
}());


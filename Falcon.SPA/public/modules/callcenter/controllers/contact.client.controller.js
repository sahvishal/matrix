(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.contactController,
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', 'usSpinnerService', CallCenterConfiguration.services.contactService, CoreConfiguration.constants,
            function ($rootScope, $scope, $stateParams, $state, logger, usSpinnerService, contactService, constants) {
                
                $scope.popupmodel = false;
                $rootScope.title = $state.current.title;
                $scope.data = {};
                $scope.Gender = constants.Gender;
                $scope.patientInfo = null;
                $scope.PagingModel = null;
                $scope.medicalHistory = null;
                $scope.callQueueCustomerId = $stateParams.callQueueCustomerId;
                $scope.callId = $stateParams.callId;


                $scope.CallQueueCategory = constants.CallQueueCategory;
                $scope.CallQueueSortOrderBy = constants.CallQueueSortOrderBy;
                $scope.SortOrderType = constants.SortOrderType;
                $scope.model = null;
                $scope.Events = null;
                $scope.callHistory = null;
                $scope.updateCustomer = false;

                $scope.CallBackPhoneNumber = '';
                $scope.OfficePhoneNumber = '';
                $scope.MobilePhoneNumber = '';
                $scope.patientState = null;
                $scope.selectedCallStatusId = 0;
                $scope.CallNotes = '';
                $scope.isCallbackRequested = false;
                $scope.CallbackRequestedChk = false;
                $scope.isCallOutComeSaved = false;
                $scope.showRequestedCallBackDiv = false;

                $scope.loader_customerEventSearch = false;
                $scope.isPostBack = false;
                $scope.loader_updateCustomer = false;
                $scope.loader_saveCustomer = false;
                $scope.loader_saveOutCome = false;
                $scope.ProspectCustomerId = 0;
                $scope.RemoveFromQueue = false;
                $scope.DoNotCall = false;
                $scope.toBeFilledEventId = "";
                $scope.ToDisplayCallBackDateTime = "";
                $scope.IsHealthPlanQueue = false;
                $scope.ReadAndUnderstood = true;


                $scope.EventFilters = { zipcode: '', city: '', state: '', radius: 0, forHealthPlanId: 0, tobeFilledEventId: 0, SortByOrder: $scope.CallQueueSortOrderBy.Distance, SortOrderType: $scope.SortOrderType.Ascending };
                $scope.pagingFilters = { zipcode: '', city: '', state: '', radius: 0, forHealthPlanId: 0, tobeFilledEventId: 0, SortByOrder: $scope.CallQueueSortOrderBy.Distance, SortOrderType: $scope.SortOrderType.Ascending };

                $scope.selectedCategory = null;

                $scope.CallBackDateTime = {
                    date: '', time: '',
                    get dateTime() { if (this.date != '' && this.time != '') return this.date + ' ' + this.time; else return null; }
                };

                $scope.genderDropDown = [{
                    value: -1,
                    text: 'Select'
                }, {
                    value: 185,
                    text: 'Male'
                }, {
                    value: 186,
                    text: 'Female'
                }];

                $scope.CallStatusRadioList = [{
                    value: constants.CallStatus.NoAnswer,
                    text: 'No Answer'
                }, {
                    value: constants.CallStatus.VoiceMessage,
                    text: 'Left Voice Mail'
                }, {
                    value: constants.CallStatus.Attended,
                    text: 'Talked To Patient'
                }];

                function updateFilters(obj) {
                    $scope.pagingFilters.zipcode = obj.zipcode;
                    $scope.pagingFilters.city = obj.city;
                    $scope.pagingFilters.state = obj.state;
                    $scope.pagingFilters.radius = obj.radius;
                }

                $scope.States = null;
                $scope.UsaStates = null;

                function init() {

                    contactService.GetStates().then(function (result) {
                        $scope.States = new Array();
                        $.each(result, function (index, item) {
                            $scope.States.push(item);
                        });

                    });

                    contactService.GetCustomerInfo($scope.callQueueCustomerId, $scope.callId).then(function (result) {
                        $scope.model = result;
                        $scope.patientInfo = result.PatientInfomation;
                        //$scope.callHistory = result.CallHistory;
                        var zipcode = $scope.patientInfo.AddressViewModel.ZipCode;
                        if (typeof result.PatientInfomation.CustomerId !== 'undefined' && result.PatientInfomation.CustomerId != null && result.PatientInfomation.CustomerId != "null") {
                            var mcustomerId = result.PatientInfomation.CustomerId;
                            contactService.GetCustomerMedicalHistory(mcustomerId).then(function (medicalHistory) {
                                $scope.medicalHistory = medicalHistory;
                            });
                        }
                        $scope.ProspectCustomerId = $scope.patientInfo.ProspectCustomerId == null ? 0 : $scope.patientInfo.ProspectCustomerId;

                        contactService.GetCategoryByCallQueueCustomerId($scope.callQueueCustomerId).then(function (item) {
                            $scope.selectedCategory = {
                                value: item.CallQueueId, text: item.Name, Category: item.Category
                            };

                            if ($scope.selectedCategory.Category == constants.CallQueueCategory.FillEvents) {
                                zipcode = item.EventZipCode;
                            }

                            $scope.EventFilters.zipcode = zipcode;

                            updateFilters($scope.EventFilters);
                            $scope.EventFilters.ExcludeCorporateEvents = true;
                            contactService.GetEventsByZipCode($scope.EventFilters, false, 1).then(function (eventList) {
                                $scope.Events = eventList.Events;
                                $scope.PagingModel = eventList.PagingModel;
                            });

                        });


                        var customerId = 0;
                        if ($scope.patientInfo.CustomerId != null && $scope.patientInfo.CustomerId > 0) {
                            customerId = $scope.patientInfo.CustomerId;
                        }

                        contactService.GetCallOutCome($scope.callQueueCustomerId, $scope.callId, $scope.ProspectCustomerId, customerId).then(function (outcome) {
                            if (outcome.Note != '') {
                                $scope.CallNotes = outcome.Note;
                            }

                            if (outcome.CallStatusId != constants.CallStatus.Initiated) {
                                $scope.isCallOutComeSaved = true;
                                $scope.selectedCallStatusId = outcome.CallStatusId;

                                if ($scope.selectedCallStatusId == constants.CallStatus.Attended) {
                                    $scope.showRequestedCallBackDiv = true;
                                    if (outcome.CallBackDateTime != null) {
                                        $scope.CallBackDateTime.date = moment(outcome.CallBackDateTime).format('MM/DD/YYYY');
                                        $scope.CallBackDateTime.time = moment(outcome.CallBackDateTime).format('h:mm a');
                                        $scope.CallbackRequestedChk = true;
                                    }
                                }
                            }
                            if (outcome.CallBackDateTime != null) {
                                $scope.ToDisplayCallBackDateTime = outcome.CallBackDateTime;//).format('MM/DD/YYYY h:mm a'); 
                            }

                            $scope.DoNotCall = outcome.DoNotCall;
                            $scope.RemoveFromQueue = outcome.RemoveFromQueue;

                        });

                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    }, function () {
                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });

                    contactService.GetUsaStatesDropDown().then(function (result) {
                        ////$scope.UsaStates = [{
                        ////    FirstValue: "",
                        ////    SecondValue: "State"
                        ////}];
                        $scope.UsaStates = new Array();
                        $.each(result, function (index, item) {
                            $scope.UsaStates.push(item);
                        });

                    });

                    contactService.GetNotes($scope.callId, $scope.callQueueCustomerId).then(function (result) {
                        $scope.callHistory = result.CallHistory;
                    });

                    $scope.toBeFilledEventId = getPropertyValue(window.localStorage.EventId);
                    if ($scope.toBeFilledEventId != '') {
                        $scope.EventFilters.tobeFilledEventId = $scope.toBeFilledEventId;
                        $scope.pagingFilters.tobeFilledEventId = $scope.toBeFilledEventId;
                    }
                }
                var getPropertyValue = function (propterty) {
                    if (typeof propterty === "undefined" || propterty === "null" || propterty === "" || propterty === "undefined")
                        return "";
                    return propterty;
                };
                init();

                var validateEventSearchFilter = function (filter) {

                    if (filter.zipcode === '' && filter.city === '' && filter.state === '') {
                        logger.showToasterError('Please provide zipcode or city or state');
                        return false;
                    }
                    if (filter.city != '' && filter.state === '') {
                        logger.showToasterError('Please select state');
                        return false;
                    }
                    return true;
                };
                $scope.SeachByFilters = function () {
                    if (validateEventSearchFilter($scope.EventFilters)) {
                        $scope.loader_customerEventSearch = true;
                        $scope.isPostBack = true;

                        $scope.EventFilters.ExcludeCorporateEvents = true;
                        contactService.GetEventsByZipCode($scope.EventFilters, false, 1).then(function (eventList) {
                            updateFilters($scope.EventFilters);
                            $scope.Events = eventList.Events;
                            $scope.PagingModel = eventList.PagingModel;
                            $scope.loader_customerEventSearch = false;
                            $scope.isPostBack = false;
                        }, function () {
                            $scope.loader_customerEventSearch = false;
                            $scope.isPostBack = false;
                        });
                    }
                };

                $scope.GetEventPage = function (pageNumber) {
                    $scope.EventFilters.ExcludeCorporateEvents = true;
                    contactService.GetEventsByZipCode($scope.pagingFilters, false, pageNumber).then(function (eventList) {
                        $scope.Events = eventList.Events;
                        $scope.PagingModel = eventList.PagingModel;

                    });
                };

                $scope.CustomerRegistration = function (evt) {
                    $scope.loader_booknow = true;
                    $scope.isPostBack = true;
                    var previousEventId = $('#hfPreviousEventId').val();
                    
                    if ($scope.patientInfo.CustomerId == null || $scope.patientInfo.CustomerId <= 0) {
                        window.location.href = ApplicationConfiguration.appUrl + '/CallCenter/CallQueue/RegisterForEvent?callQueueCustomerId=' + $scope.callQueueCustomerId + '&eventId=' + evt.EventId + "&callId=" + $scope.callId + "&previousEventId=" + previousEventId;

                    } else {
                        contactService.DoesEventCustomerAlreadyExists($scope.patientInfo.CustomerId, evt.EventId).then(function (result) {
                            if (result == false) {
                                window.location.href = ApplicationConfiguration.appUrl + '/CallCenter/CallQueue/RegisterForEvent?callQueueCustomerId=' + $scope.callQueueCustomerId + '&eventId=' + evt.EventId + "&callId=" + $scope.callId + "&previousEventId=" + previousEventId;
                            }
                            $scope.loader_booknow = false;
                            $scope.isPostBack = false;
                        }, function () {
                            $scope.loader_booknow = false;
                            $scope.isPostBack = false;

                        });
                    }

                };

                $scope.CancelPatientInfo = function () {
                    $scope.updateCustomer = false;
                    $scope.patientInfo = $scope.copy;
                    hideErrors();
                };

                var getUnFormatedPhoneNumber = function (phoneNumber) {
                    if (phoneNumber != '' && phoneNumber != undefined) {
                        phoneNumber = phoneNumber.replace("(", "");
                        phoneNumber = phoneNumber.replace(")", "");
                        phoneNumber = phoneNumber.replace(/_/gi, "");
                        phoneNumber = phoneNumber.replace(/-/gi, "");
                    }
                    return phoneNumber;
                };

                $scope.SavePatientInfo = function () {

                    var customerId = 0;
                    var prospectId = 0;
                    if ($scope.patientInfo.CustomerId !== null)
                        customerId = $scope.patientInfo.CustomerId;
                    if ($scope.patientInfo.ProspectCustomerId !== null)
                        prospectId = $scope.patientInfo.ProspectCustomerId;

                    $scope.MobilePhoneNumber = '';
                    $scope.CallBackPhoneNumber = '';
                    $scope.OfficePhoneNumber = '';

                    if ($scope.patientInfo.CallBackPhoneNumber != null) {
                        $scope.CallBackPhoneNumber = getUnFormatedPhoneNumber($scope.patientInfo.CallBackPhoneNumber.FormatPhoneNumber)
                    }
                    if ($scope.patientInfo.OfficePhoneNumber != null) {
                        $scope.OfficePhoneNumber = $scope.patientInfo.OfficePhoneNumber.FormatPhoneNumber;
                    }
                    if ($scope.patientInfo.MobilePhoneNumber != null) {
                        $scope.MobilePhoneNumber = $scope.patientInfo.MobilePhoneNumber.FormatPhoneNumber;
                    }
                    if ($scope.patientInfo.DateOfBirth == '')
                        $scope.patientInfo.DateOfBirth = null;
                    var customerEditModel = {
                        CustomerId: customerId,
                        ProspectCustomerId: prospectId,
                        FirstName: $scope.patientInfo.FirstName,
                        LastName: $scope.patientInfo.LastName,
                        Gender: $scope.patientInfo.Gender,
                        Email: $scope.patientInfo.Email,
                        UserId: $scope.patientInfo.UserId,
                        DateOfBirth: $scope.patientInfo.DateOfBirth,
                        CallID: $scope.callId,
                        CallQueueCustomerId: $scope.callQueueCustomerId,
                        CallBackPhoneNumber: $scope.CallBackPhoneNumber,
                        OfficePhoneNumber: $scope.OfficePhoneNumber,
                        MobilePhoneNumber: $scope.MobilePhoneNumber,
                        IsHealthPlanQueue: false,

                        Address: {
                            StreetAddressLine1: $scope.patientInfo.AddressViewModel.StreetAddressLine1,
                            StreetAddressLine2: $scope.patientInfo.AddressViewModel.StreetAddressLine2,
                            City: $scope.patientInfo.AddressViewModel.City,
                            StateId: $scope.patientState,
                            CountryId: 1,
                            ZipCode: $scope.patientInfo.AddressViewModel.ZipCode
                        }
                    };
                    $scope.loader_saveCustomer = true;
                    $scope.isPostBack = true;

                    contactService.UpdateCallQuequeCustomer(customerEditModel).then(function (result) {
                        if (result != null) {
                            $.each($scope.States, function (index, item) {
                                if (item.FirstValue == $scope.patientState.FirstValue) {
                                    $scope.patientInfo.AddressViewModel.State = item.SecondValue;
                                }
                            });

                            $scope.EventFilters.zipcode = $scope.patientInfo.AddressViewModel.ZipCode;
                            $scope.loader_saveCustomer = false;
                            $scope.isPostBack = false;
                            $scope.updateCustomer = false;
                        }
                    }, function () {
                        $scope.isPostBack = false;
                        $scope.loader_saveCustomer = false;
                    });
                };

                $scope.ShowUpdatePanel = function () {

                    $scope.isPostBack = true;
                    $scope.loader_updateCustomer = true;

                    try {
                        $scope.patientState = $scope.States[0].FirstValue;

                        $.each($scope.States, function (index, item) {
                            if (item.SecondValue == $scope.patientInfo.AddressViewModel.State) {
                                $scope.patientState = item.FirstValue;
                            }
                        });

                        $scope.updateCustomer = true;

                        $scope.copy = angular.copy($scope.patientInfo);

                        if ($scope.patientInfo.Gender == null || $scope.patientInfo.Gender === $scope.Gender.Unspecified) {
                            $scope.patientInfo.Gender = $scope.genderDropDown[0].value;
                        }
                        if ($scope.patientInfo.DateOfBirth != null) {
                            $scope.patientInfo.DateOfBirth = moment($scope.patientInfo.DateOfBirth).format("MM/DD/YYYY");
                        }
                    } catch (e) {

                    }

                    $scope.isPostBack = false;
                    $scope.loader_updateCustomer = false;
                };

                $scope.setStatus = function (status) {
                    $scope.selectedCallStatusId = status.value;
                    if ($scope.selectedCallStatusId == constants.CallStatus.Attended) {
                        $scope.showRequestedCallBackDiv = true;

                    } else {
                        $scope.showRequestedCallBackDiv = false;
                        $scope.CallBackDateTime.date = '';
                        $scope.CallBackDateTime.time = '';
                        $scope.CallbackRequestedChk = false;
                    }

                };
                $scope.onCallbackRequestedChkClicked = function () {
                    if (!$scope.CallbackRequestedChk) {
                        $scope.CallBackDateTime.date = '';
                        $scope.CallBackDateTime.time = '';
                    }
                };

                $scope.saveCallOutCome = function () {

                    var customerId = 0;
                    if ($scope.selectedCallStatusId == 0) {
                        logger.showToasterError('Please Select one of the call outcome options');
                        return;
                    }

                    if ($scope.patientInfo.CustomerId != null && $scope.patientInfo.CustomerId > 0) {
                        customerId = $scope.patientInfo.CustomerId;
                    }
                    if ($scope.CallbackRequestedChk) {
                        if ($scope.CallBackDateTime.date == '' || $scope.CallBackDateTime.time == '') {
                            logger.showToasterError('Please select date and time.');
                            return;
                        }
                    }

                    if ($scope.CallbackRequestedChk && $scope.CallBackDateTime.date != '') {
                        if ($scope.CallBackDateTime.time != '') {
                            var currentdate = new Date();
                            var selectedDate = moment($scope.CallBackDateTime.date + ' ' + $scope.CallBackDateTime.time, "MM/DD/YYYY hh:mm a");
                            if (!selectedDate.isAfter(currentdate)) {
                                logger.showToasterError('Please select a future date and time.');
                                return;
                            }
                        }
                    }
                    var dataModel = {
                        CallQueueCustomerId: $scope.callQueueCustomerId,
                        CallId: $scope.callId,
                        CallStatusId: $scope.selectedCallStatusId,
                        CallBackDateTime: ($scope.CallbackRequestedChk) ? $scope.CallBackDateTime.dateTime : null,
                        Note: $scope.CallNotes,
                        CustomerId: customerId,
                        ProspectCustomerId: $scope.ProspectCustomerId,
                        RemoveFromQueue: $scope.RemoveFromQueue,
                        DoNotCall: $scope.DoNotCall
                    };

                    $scope.loader_saveOutCome = true;
                    $scope.isPostBack = true;

                    contactService.saveCallOutCome(dataModel).then(function (result) {
                        logger.showToasterSuccess('Call Notes Saved Successfuly.');
                        $scope.isCallbackRequested = $scope.CallBackDateTime.dateTime != null ? true : false;
                        $scope.isCallOutComeSaved = true;
                        $scope.loader_saveOutCome = false;
                        $scope.isPostBack = false;
                    }, function () {
                        $scope.loader_saveOutCome = false;
                        $scope.isPostBack = false;
                    });

                };

                $scope.EndActiveCall = function () {

                    if ($scope.isCallOutComeSaved) {
                        var callid = $stateParams.callId;

                        var callQueueCustomerId = $stateParams.callQueueCustomerId;
                        var isCallbackRequested = $scope.isCallbackRequested;

                        $scope.loader_EndActvieCall = true;
                        $scope.isPostBack = true;

                        contactService.EndActiveCall(callQueueCustomerId, callid, isCallbackRequested, $scope.RemoveFromQueue).then(function () {
                            $scope.loader_EndActvieCall = false;
                            $scope.isPostBack = false;
                            $state.go("SearchQueue");
                        }, function () {
                            $scope.loader_saveOutCome = false;
                            $scope.isPostBack = false;
                        });
                    } else {
                        logger.showToasterError('Please fill Call Outcome before ending call.');
                    }
                };
                function hideErrors() {
                    $("span.validation-message").val('').hide();
                    $('form :input').removeClass('validation-message');
                }

                $scope.eventShortBy = function (orderBy) {

                    if ($scope.pagingFilters.SortByOrder === orderBy) {
                        if ($scope.pagingFilters.SortOrderType === $scope.SortOrderType.Ascending) {
                            $scope.pagingFilters.SortOrderType = $scope.SortOrderType.Descending;
                        } else {
                            $scope.pagingFilters.SortOrderType = $scope.SortOrderType.Ascending;
                        }

                    } else {
                        $scope.pagingFilters.SortByOrder = orderBy;
                        $scope.pagingFilters.SortOrderType = $scope.SortOrderType.Ascending;
                    }

                    if (validateEventSearchFilter($scope.pagingFilters)) {
                        $scope.loader_customerEventSearch = true;
                        $scope.isPostBack = true;

                        contactService.GetEventsByZipCode($scope.pagingFilters, false, 1).then(function (eventList) {
                            updateFilters($scope.pagingFilters);
                            $scope.Events = eventList.Events;
                            $scope.PagingModel = eventList.PagingModel;
                            $scope.loader_customerEventSearch = false;
                            $scope.isPostBack = false;
                        }, function () {
                            $scope.loader_customerEventSearch = false;
                            $scope.isPostBack = false;
                        });
                    }
                };

                $scope.getPodName = function (pods) {

                    if (pods === null || typeof pods === 'undefined' || pods.length <= 0) return "";
                    var podName = [];
                    $.each(pods, function (index, item) {
                        podName.push($(item)[0].SecondValue);
                    });

                    return podName.toString();
                };

                $scope.ViewAll = function (eventId) {
                    window.open(ApplicationConfiguration.appUrl + '/Scheduling/AppointmentSlot/ViewAll?eventId=' + eventId, '_blank');;
                };

                $scope.IsEligible = function (patientInfo) {
                    if (patientInfo != null && patientInfo.IsEligible === false) {
                        return { 'background-color': 'Red' };
                    }

                    if (patientInfo != null && patientInfo.IsEligible) {
                        return { 'background-color': 'Green' };
                    }

                    if (patientInfo != null && patientInfo.IsEligible === null) {
                        return { 'background-color': 'Yellow' };
                    }

                    return { 'background-color': 'none' };
                };

            }]);

}());
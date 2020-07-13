(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.healthPlanContactController,
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', 'usSpinnerService', CallCenterConfiguration.services.contactService, CoreConfiguration.constants,
            CallCenterConfiguration.services.healthplanlocalstorage, '$modal', 'analytics', CallCenterConfiguration.services.searchHealthPlanService,
    function ($rootScope, $scope, $stateParams, $state, logger, usSpinnerService, contactService, constants, healthplanlocalstorage,
        $modal, analytics, searchHealthPlanService) {

        //$scope.isCallSuccess = false;
        $scope.showCallOutcomeAndEndCallButton = false;
        $scope.CustomerFilters = healthplanlocalstorage.GetCallRoundFilter();
        $scope.popupmodel = false;
        $rootScope.title = $state.current.title;
        $scope.data = {};
        $scope.Gender = constants.Gender;
        $scope.patientInfo = null;
        $scope.PagingModel = null;
        $scope.medicalHistory = null;
        $scope.callQueueCustomerId = $stateParams.callQueueCustomerId;
        $scope.attemptId = $stateParams.attemptId;

        $scope.PhoneHomeUrl = '';
        $scope.PhoneOfficeUrl = '';
        $scope.PhoneMobileUrl = '';

        $scope.CallQueueCategory = constants.HealthPlanCallQueueCategory;
        $scope.CallQueueSortOrderBy = constants.CallQueueSortOrderBy;
        $scope.SortOrderType = constants.SortOrderType;
        $scope.ProspectCustomerHealthPlanTag = constants.ProspectCustomer.HealthPlanTag;

        $scope.model = null;
        $scope.Events = null;
        $scope.callHistory = null;
        $scope.directMail = null;
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
        $scope.showDispositionDiv = false;

        $scope.loader_customerEventSearch = false;
        $scope.isPostBack = false;
        $scope.loader_updateCustomer = false;
        $scope.loader_saveCustomer = false;
        $scope.loader_saveOutCome = false;
        //$scope.ProspectCustomerId = 0;
        $scope.callId = 0;
        $scope.DoNotCall = false;
        $scope.toBeFilledEventId = "";
        $scope.ToDisplayCallBackDateTime = "";

        $scope.SelectedDisposition = '0';
        $scope.SelectedSubDispositionId = '0';
        $scope.showNotesMandatory = false;
        $scope.IsHealthPlanQueue = true;
        //$scope.ReadAndUnderstood = false;
        $scope.MemberIdLabel = "Member Id";

        $scope.ShowNotInterestedReason = false;

        $scope.AllDispositionOptions = [];

        $scope.NotesTabContactHistory = constants.NotesTabContactHistory;
        $scope.callHistoryTab = false;
        $scope.notesTab = true;
        $scope.directMailTab = false;
        $scope.CustomerRegistrationNotesType = constants.CustomerRegistrationNotesType;

        $scope.EventFilters = { zipcode: '', city: '', state: '', radius: 25, forHealthPlanId: 0, tobeFilledEventId: 0, SortByOrder: $scope.CallQueueSortOrderBy.EventDate, SortOrderType: $scope.SortOrderType.Ascending, ExcludeCorporateEvents: false, SearchAllEvents: false, customerZipCode: '', CustomerId: 0 };
        $scope.pagingFilters = { zipcode: '', city: '', state: '', radius: 25, forHealthPlanId: 0, tobeFilledEventId: 0, SortByOrder: $scope.CallQueueSortOrderBy.EventDate, SortOrderType: $scope.SortOrderType.Ascending, ExcludeCorporateEvents: false, customerZipCode: '', CustomerId: 0 };

        $scope.isScriptOpen = false;
        $scope.scriptPopup = null;

        $scope.CallBackDateTime = {
            date: '', time: '',
            get dateTime() { if (this.date != '' && this.time != '') return this.date + ' ' + this.time; else return null; }
        };

        $scope.AllHealthPlanDispositions = [];

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

        $scope.CallStatusRadioList = [
        {
            value: constants.CallStatus.Attended,
            text: 'Talked To Patient'
        },
        {
            value: constants.CallStatus.VoiceMessage,
            text: 'Left Voice Mail'
        },
        {
            value: constants.CallStatus.LeftMessageWithOther,
            text: 'Left Message With Other'
        },
        {
            value: constants.CallStatus.NoAnswer,
            text: 'No Answer / Busy /Mail Full'
        },
        //{
        //    value: constants.CallStatus.IncorrectPhoneNumber,
        //    text: 'Incorrect Phone Number'
        //},
         {
             value: constants.CallStatus.TalkedtoOtherPerson,
             text: 'Talked to Other Person'
         },
        {
            value: constants.CallStatus.NoEventsInArea,
            text: 'No Events In Area'
        },
         {
             value: constants.CallStatus.InvalidNumber,
             text: 'Invalid Number'
         },

        ];

        $scope.EligibleStatus = [{
            value: 'Select',
            text: ' Select '
        }, {
            value: 'Yes',
            text: 'Yes'
        }, {
            value: "No",
            text: "No"
        }];

        $scope.NotInterestedResons = [
                { Id: "278", Name: "Customer Refused" },
                { Id: "279", Name: "Don't have insurance" }
        ];

        $scope.consentModel = { phoneHome: "", homeConsent: "", phoneCell: "", cellConsent: "", phoneOffice: "", officeConsent: "" };
        $scope.consentDropdown = [
            { text: 'Unknown', value: constants.PatientConsent.Unknown },
            { text: 'Granted', value: constants.PatientConsent.Granted },
            { text: 'Rejected', value: constants.PatientConsent.Rejected }
        ];
        $scope.showConsentDiv = false;

        $scope.isConfirmationCall = false;
        $scope.registeredEventInformation = null;
        $scope.showHelpText = false;
        $scope.ConfirmationTalkedToPatientDisposition = constants.AttendedConfirmationDispositions;
        $scope.WarmTransfer = false;
        function updateFilters(obj) {
            $scope.pagingFilters.zipcode = obj.zipcode;
            $scope.pagingFilters.city = obj.city;
            $scope.pagingFilters.state = obj.state;
            $scope.pagingFilters.radius = obj.radius;
            $scope.pagingFilters.SortByOrder = obj.SortByOrder;
            $scope.pagingFilters.customerZipCode = obj.customerZipCode;
            $scope.pagingFilters.CustomerId = $scope.patientInfo.CustomerId;
        }

        $scope.States = null;
        $scope.customerNotes = null;
        $scope.ActivityTypes = [];
        $scope.isCallDisabled = false;

        $scope.criteriaDetails = null;

        function init() {
            if ($scope.callQueueCustomerId == '0' && $scope.attemptId == '0') {
                logger.showToasterError("No patient left in queue. Please check back in few mins.");
                $state.transitionTo('CallCentreDashboard', { isCallQueueSelected: "noQueuesSelected" }, { reload: true });
                return;
            }

            $('#dvStartCall').hide();
            $('#assignedCallQueue').hide();
            //$scope.callAttemptId = contactService.InitializeCallAttemptTable($scope.customerId, $scope.agentId);
            $scope.CustomerFilters = healthplanlocalstorage.GetCallRoundFilter();
            $scope.EventFilters.forHealthPlanId = $scope.CustomerFilters.HealthPlanId;
            $scope.pagingFilters.forHealthPlanId = $scope.CustomerFilters.HealthPlanId;

            contactService.GetStates().then(function (result) {
                $scope.States = new Array();
                $.each(result, function (index, item) {
                    $scope.States.push(item);
                });
            });

            $scope.ActivityTypes = constants.ActivityTypes;
            /*contactService.GetActivityTypes().then(function (result) {
                $scope.ActivityTypes = result;
            });*/

            $scope.loader_customerEventSearch = true;
            $scope.isPostBack = true;

            contactService.GetCustomerInfo($scope.callQueueCustomerId, $scope.attemptId).then(function (result) {

                var hfCustomerId = localStorage.getItem("customerId");
                if (hfCustomerId != result.PatientInfomation.CustomerId) {
                    window.localStorage.setItem("hfActivityId", result.PatientInfomation.ActivityId);
                    window.localStorage.setItem("hfCustomerId", result.PatientInfomation.CustomerId);
                }

                $scope.WarmTransfer = result.WarmTransfer;
                $scope.model = result;
                $scope.patientInfo = result.PatientInfomation;
                $scope.registeredEventInformation = result.EventInformation;
                $scope.criteriaDetails = result.CriteriaInfo;
                setCallUrl();

                $scope.preApprovedTest = result.PreApprovedTests;
                $scope.preApprovedPackage = result.PreApprovedPackages;
                $scope.additionalfields = result.AdditionalFields;

                //$scope.requiredTest = result.RequiredTests;

                $scope.patientInfo.ActivityId = result.PatientInfomation.ActivityId.toString();

                if (window.localStorage.isScriptOpen === "true" && window.localStorage.scriptUrl != '') {
                    $scope.openScriptWindow();
                }

                if (result.CallQueueCustomerAttempt.CallId !== null && typeof result.CallQueueCustomerAttempt.CallId !== 'undefined') {
                    $scope.callId = result.CallQueueCustomerAttempt.CallId;
                    $scope.showCallOutcomeAndEndCallButton = true;


                }

                if (result.MemberIdLabel != null && result.MemberIdLabel != '') {
                    $scope.MemberIdLabel = result.MemberIdLabel;
                }

                var customerZipCode = $scope.patientInfo.AddressViewModel.ZipCode;
                $scope.EventFilters.customerZipCode = customerZipCode;
                $scope.EventFilters.zipcode = customerZipCode;

                if ($scope.model.CallQueueCategory === constants.HealthPlanCallQueueCategory.AppointmentConfirmation) {

                    $scope.isConfirmationCall = true;

                    $scope.CallStatusRadioList = [
                        {
                            value: constants.CallStatus.Attended,
                            text: 'Talked To Patient'
                        },
                        {
                            value: constants.CallStatus.VoiceMessage,
                            text: 'Left Voice Mail'
                        },
                        {
                            value: constants.CallStatus.LeftMessageWithOther,
                            text: 'Left Message With Other'
                        },
                        {
                            value: constants.CallStatus.NoAnswer,
                            text: 'No Answer / Busy /Mail Full'
                        }];

                    setHraValues();
                }

                contactService.GetCallDispositionTags().then(function (outcome) {
                    var dropdown = [];
                    if (outcome == null)
                        $scope.CallDispositionOptions = dropdown;
                    $scope.AllDispositionOptions = outcome;

                    if (!result.PatientInfomation.MammoTestAsPreApproved) {
                        var dispositionWithoutMammoDisposition = [];

                        dispositionWithoutMammoDisposition = $scope.AllDispositionOptions.filter(function (x) {
                            return x.Alias != 'MemberStatesIneligibleMastectomy' && x.Alias != 'DeclinedMemberNotMammoAvailableNoEventsInArea' && x.Alias != 'DeclinedMammoNotinterestedInMammogram';
                        });

                        $scope.AllDispositionOptions = dispositionWithoutMammoDisposition;
                    }

                    var object = { Value: '0', Text: '-- Select --' };
                    dropdown.push(object);
                    if ($scope.isConfirmationCall) {
                        $.each(constants.AttendedConfirmationDispositions, function (index, item) {
                            object = { Value: item.Alias, Text: item.Name };
                            dropdown.push(object);
                        });
                    } else {
                        if ($scope.WarmTransfer) {
                            $.each($scope.AllDispositionOptions, function (index, item) {
                                if (item.CallStatus == constants.CallStatus.Attended && (!item.ForAppointmentConfirmation || item.Alias == constants.ProspectCustomer.HealthPlanTag.CallBackLater)) {
                                    object = { Value: item.Alias, Text: item.Name };
                                    dropdown.push(object);
                                }
                            });
                        }
                        else {
                            $.each($scope.AllDispositionOptions, function (index, item) {
                                if (item.CallStatus == constants.CallStatus.Attended && (!item.ForAppointmentConfirmation || item.Alias == constants.ProspectCustomer.HealthPlanTag.CallBackLater) && item.ForWarmTransfer == false) {
                                    object = { Value: item.Alias, Text: item.Name };
                                    dropdown.push(object);
                                }
                            });
                        }
                    }

                    $scope.CallDispositionOptions = dropdown;
                });
                
                //if ($scope.model.CallQueueCategory === constants.HealthPlanCallQueueCategory.FillEventsHealthPlan) {
                //    //customerZipCode = item.EventZipCode;
                //    $scope.EventFilters.SearchAllEvents = true;
                //}

                updateFilters($scope.EventFilters);
                $scope.EventFilters.ExcludeCorporateEvents = false;
                $scope.EventFilters.SearchMammoEvents = $scope.patientInfo.MammoTestAsPreApproved;
                $scope.EventFilters.CustomerId = $scope.patientInfo.CustomerId;
                //$scope.EventFilters.SearchAllEvents = !$scope.patientInfo.HasMammo;

                if (!$scope.isConfirmationCall) {
                    contactService.GetEventsByZipCode($scope.EventFilters, false, 1).then(function (eventList) {
                        localStorage.setItem("EventFilterForMammo", JSON.stringify($scope.EventFilters));
                        $scope.Events = eventList.Events;
                        $scope.PagingModel = eventList.PagingModel;
                        $scope.loader_customerEventSearch = false;
                        $scope.isPostBack = false;
                    }, function () {
                        $scope.loader_customerEventSearch = false;
                        $scope.isPostBack = false;
                    });
                }

                $scope.isPostBack = false;

                $scope.customerNotesModel = [];
                if ($scope.showCallOutcomeAndEndCallButton) {
                    contactService.GetNotes($scope.callId, $scope.callQueueCustomerId).then(function (result) {
                        $scope.customerNotes = result.CustomerCallNotes;
                        $scope.callHistory = result.CallHistory;
                        $scope.directMail = result.DirectMail;

                        $.each($scope.customerNotes, function (index, item) {

                            if (item.NotesType == $scope.CustomerRegistrationNotesType.AppointmentNote && item.EventId > 0) {
                                item.NotesTypeName = "Event Instructions";
                                $scope.customerNotesModel.push(item);
                            } else if (item.NotesType == $scope.CustomerRegistrationNotesType.PostScreeningFollowUpNotes) {
                                item.NotesTypeName = "Post Screening Followup Notes";
                                $scope.customerNotesModel.push(item);
                            } else if ((item.NotesType == $scope.CustomerRegistrationNotesType.CustomerNote || item.NotesType == $scope.CustomerRegistrationNotesType.AppointmentNote) && (item.EventId == null || item.EventId == 0)) {
                                item.NotesTypeName = "General Instructions";
                                $scope.customerNotesModel.push(item);
                            } else if (item.NotesType == $scope.CustomerRegistrationNotesType.CancellationNote) {
                                item.NotesTypeName = "Cancellation Note";
                                $scope.customerNotesModel.push(item);
                            }
                            else if (item.NotesType == $scope.CustomerRegistrationNotesType.LeftWithoutScreeningNotes) {
                                item.NotesTypeName = "Left Without Screening Note";
                                $scope.customerNotesModel.push(item);
                            }
                        });
                    });
                }
                var customerId = 0;
                if ($scope.patientInfo.CustomerId != null && $scope.patientInfo.CustomerId > 0) {
                    customerId = $scope.patientInfo.CustomerId;
                }

                if ($scope.callId > 0) {
                    contactService.GetCallOutCome($scope.callQueueCustomerId, $scope.callId, customerId).then(function (outcome) {
                        if (outcome.Note !== '') {
                            $scope.CallNotes = outcome.Note;
                        }

                        if (outcome.CallStatusId !== constants.CallStatus.Initiated) {
                            $scope.isCallOutComeSaved = true;
                            $scope.selectedCallStatusId = outcome.CallStatusId;

                            if ($scope.selectedCallStatusId === constants.CallStatus.Attended) {

                                if ($scope.isConfirmationCall)
                                    $scope.showHelpText = true;

                                if (outcome.CallBackDateTime != null) {
                                    $scope.CallBackDateTime.date = moment(outcome.CallBackDateTime).format('MM/DD/YYYY');
                                    $scope.CallBackDateTime.time = moment(outcome.CallBackDateTime).format('hh:mm a');
                                    $scope.CallbackRequestedChk = true;
                                }
                                if (outcome.DispositionAlias !== 'Unspecified') {
                                    $scope.showDispositionDiv = true;
                                    $scope.SelectedDisposition = outcome.DispositionAlias;
                                    $scope.showNotesMandatory = isNotesMandatory();
                                }

                                $scope.showConsentDiv = true;
                            } else {
                                $scope.showConsentDiv = false;
                            }

                            if ($scope.selectedCallStatusId == constants.CallStatus.LeftMessageWithOther) {
                                //getCallDispositions(true, false);
                                if (outcome.DispositionAlias != 'Unspecified') {
                                    $scope.showDispositionDiv = true;
                                    $scope.SelectedDisposition = outcome.DispositionAlias;
                                    $scope.showNotesMandatory = isNotesMandatory();
                                }
                            }

                            if ($scope.selectedCallStatusId == constants.CallStatus.TalkedtoOtherPerson) {
                                //getCallDispositions(false, true);
                                if (outcome.DispositionAlias != 'Unspecified') {
                                    $scope.showDispositionDiv = true;
                                    $scope.SelectedDisposition = outcome.DispositionAlias;
                                    $scope.showNotesMandatory = isNotesMandatory();
                                }
                            } else if ($scope.selectedCallStatusId == constants.CallStatus.NoEventsInArea) {
                                //getCallDispositions(false, true);
                                $scope.SelectedDisposition = outcome.DispositionAlias;
                                $scope.showDispositionDiv = true;
                                $scope.showHelpText = false;

                            }

                            getCallDispositions($scope.selectedCallStatusId);
                        }

                        if (outcome.CallBackDateTime != null) {
                            $scope.ToDisplayCallBackDateTime = outcome.CallBackDateTime;
                        }

                        if (outcome.NotIntrestedReasonId != null) {
                            $scope.SelectedReason = outcome.NotIntrestedReasonId.toString();
                        }
                    });
                }

                //setting default dropdown values for CONSENT
                setDefaultConsent();

                setTimeout(function () {
                    usSpinnerService.stop('online-spinner');
                }, 1000);
            }, function () {
                setTimeout(function () {
                    usSpinnerService.stop('online-spinner');
                }, 1000);
            });

            $scope.toBeFilledEventId = getPropertyValue(window.localStorage.hpEventId);
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
            if (filter.zipcode === '' && filter.city === '' && (filter.state === '' || filter.state == null)) {
                logger.showToasterError('Please provide zipcode or city or state');
                return false;
            }
            if (filter.city !== '' && filter.state === '') {
                logger.showToasterError('Please select state');
                return false;
            }
            return true;
        };

        $scope.SeachByFilters = function () {
            $("#hfPreviousEventId").val(0);
            if (validateEventSearchFilter($scope.EventFilters)) {
                $scope.loader_customerEventSearch = true;
                $scope.isPostBack = true;
                $scope.EventFilters.ExcludeCorporateEvents = false;
                $scope.EventFilters.SearchMammoEvents = $scope.patientInfo.MammoTestAsPreApproved;
                $scope.EventFilters.CustomerId = $scope.patientInfo.CustomerId;
                //$scope.EventFilters.SearchMammoEvents = !$scope.EventFilters.SearchAllEvents;
                //!$scope.EventFilters.SearchAllEvents

                contactService.GetEventsByZipCode($scope.EventFilters, false, 1).then(function (eventList) {
                    updateFilters($scope.EventFilters);
                    localStorage.setItem("EventFilterForMammo", JSON.stringify($scope.EventFilters));

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
            $scope.EventFilters.ExcludeCorporateEvents = false;
            //$scope.EventFilters.SearchMammoEvents = !$scope.EventFilters.SearchAllEvents;
            contactService.GetEventsByZipCode($scope.pagingFilters, false, pageNumber).then(function (eventList) {
                $scope.Events = eventList.Events;
                $scope.PagingModel = eventList.PagingModel;

            });
        };

        function customerRegistration(evt, patientInfo) {

            $scope.loader_booknow = true;
            $scope.isPostBack = true;
            if (patientInfo.MammoTestAsPreApproved && evt.HasBreastCancerTest !== null && typeof (evt.HasBreastCancerTest) !== "undefined" && evt.HasBreastCancerTest === false) {
                if (!confirm("Warning: You are scheduling a Mammo Customer on Non-Mammo Event. Do you want to proceed?")) {
                    $scope.loader_booknow = false;
                    $scope.isPostBack = false;
                    return;
                }
            }

            if (patientInfo.CustomerId !== null && patientInfo.CustomerId > 0) {

                localStorage.setItem("EventFilterForMammo", JSON.stringify($scope.EventFilters));
                contactService.DoesEventCustomerAlreadyExists(patientInfo.CustomerId, evt.EventId).then(function (result) {
                    
                    var previousEventId = $('#hfPreviousEventId').val();
                    if (result == false) {
                        window.location.href = ApplicationConfiguration.appUrl + '/CallCenter/CallQueue/RegisterForEvent?callQueueCustomerId=' + $scope.callQueueCustomerId + '&eventId=' + evt.EventId + "&callId=" + $scope.callId + '&attemptId=' + $scope.attemptId + "&previousEventId=" + previousEventId;
                    } else {
                        $scope.isPostBack = false;
                    }
                    $scope.loader_booknow = false;

                }, function () {
                    $scope.loader_booknow = false;
                    $scope.isPostBack = false;
                });
            }
        }

        var modelPopupInstance = null;
        function verifyInvitationForPrivateEvent(evt) {
            if (evt.EventType != 'Private') {
                setCallBackFunction(evt);
                return false;
            }


            modelPopupInstance = $modal.open({
                templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/healthplanevents/verify.invitation.event.view.client.html',
                controller: 'verifyInvitationController',
                size: 'md',
                backdrop: 'static',
                keyboard: false,
                resolve: {
                    data: function () {
                        return { Event: evt, CallBack: setCallBackFunction, PatientInfo: $scope.patientInfo };
                    }
                }
            });

            return false;
        }

        function setCallBackFunction(evt) {
            if ($scope.patientInfo.MammoTestAsPreApproved && evt.HasBreastCancerTest) {
                contactService.GetPreQualificationTemplateIds($scope.patientInfo.CustomerId, evt.EventId).then(function (data) {
                    if (typeof data != "undefined" && data != '' && data != null) {
                        openPreQualificationPopup(evt, data);
                    } else {
                        customerRegistration(evt, $scope.patientInfo);
                    }
                });
            } else {
                customerRegistration(evt, $scope.patientInfo);
            }
        }

        var preQualificationModalPopupInstance = null;
        function openPreQualificationPopup(evt, templateIds) {
           
            if ($('#hfIsSearchNonMammoEvent').val() == 'Yes') {
                customerRegistration(evt, $scope.patientInfo);
                return;
            }

            preQualificationModalPopupInstance = $modal.open({
                templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/healthplanevents/prequalification.question.client.view.html',
                controller: 'healthplanPreQualificationController',
                size: 'md',
                backdrop: 'static',
                keyboard: false,
                resolve: {
                    data: function () {
                        return { Event: evt, CallBack: customerRegistration, PatientInfo: $scope.patientInfo, TemplateIds: templateIds };
                    }
                }
            });
            preQualificationModalPopupInstance.result.then(function (retData) {
                if (retData == null)
                    return false;
                if (retData.isRedirectNonMammo == 'Yes') {
                     alert("You are not eligible for " + $(".testName").html() + ".");
                    $('#hfIsSearchNonMammoEvent').val(retData.isRedirectNonMammo);
                    $('#hfPreviousEventId').val(retData.eventId);
                    var eventFileter = JSON.parse(localStorage.getItem("EventFilterForMammo"));
                    eventFileter.SearchMammoEvents = false;
                    contactService.GetEventsByZipCode(eventFileter, false, 1).then(function (eventList) {
                        $scope.Events = eventList.Events;
                        $scope.PagingModel = eventList.PagingModel;
                    });

                }
                else if (retData.isRedirectNonMammo == 'Continue') {
                    alert("You are not eligible for " + $(".testName").html() + ".");
                    customerRegistration(evt, $scope.patientInfo);
                }
                else {
                    if (retData.disqualifedTest != '') {

                        alert("You are not eligible for " + $(".testName").html() + ".");

                        $('#hfIsSearchNonMammoEvent').val(retData.isRedirectNonMammo);
                        $('#hfPreviousEventId').val(retData.eventId);
                        var eventFileter = JSON.parse(localStorage.getItem("EventFilterForMammo"));
                        eventFileter.SearchMammoEvents = false;
                        contactService.GetEventsByZipCode(eventFileter, false, 1).then(function (eventList) {
                            $scope.Events = eventList.Events;
                            $scope.PagingModel = eventList.PagingModel;
                        });

                    }
                    else {
                        customerRegistration(evt, $scope.patientInfo);
                    }
                }

            });

            return false;
        }

        $scope.CustomerRegistration = function (evt) {
            if ($scope.medicalHistory != null && $scope.medicalHistory.LastScreeningDate != null) {
                var eventYear = moment(evt.EventDate).format('YYYY');
                var lastScreeningYear = moment($scope.medicalHistory.LastScreeningDate).format('YYYY');
                if (lastScreeningYear == eventYear) {
                    var result = confirm("Customer is already screened for an event this Year. Do you wish to register him for another event in same Year?");
                    if (result) {
                        if (verifyInvitationForPrivateEvent(evt)) {
                            customerRegistration(evt, $scope.patientInfo);
                        }
                    }
                } else {
                    if (verifyInvitationForPrivateEvent(evt)) {
                        customerRegistration(evt, $scope.patientInfo);
                    }
                }
            } else {
                if (verifyInvitationForPrivateEvent(evt)) {
                    customerRegistration(evt, $scope.patientInfo);
                }
            }
        };

        $scope.CancelPatientInfo = function () {
            $scope.updateCustomer = false;
            $scope.patientInfo = $scope.copy;
            setCallUrl();
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
                
            var email = $.trim($scope.patientInfo.Email);
            var alternateEmail = $.trim($scope.patientInfo.AlternateEmail);
            var enableEmail = $scope.patientInfo.EnableEmail;
            var pcpEmail = $scope.PrimaryCarePhysician.Email;

            if (email != "") {
                if (validateEmail(email, "Email") != true) {
                    return false;
                }
            }

            if (alternateEmail != "") {
                if (validateEmail(alternateEmail, "Alternate Email") != true) {
                    return false;
                }
            }

            if (pcpEmail != "") {
                if (validateEmail(pcpEmail, "PCP Email") != true) {
                    return false;
                }
            }

            if ((email != '' || alternateEmail != '') && !enableEmail) {
                var isContinue = confirm('Consent for Email is set to No. Do you wish to continue?');
                if (!isContinue)
                    return;
            }

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
                $scope.CallBackPhoneNumber = getUnFormatedPhoneNumber($scope.patientInfo.CallBackPhoneNumber.FormatPhoneNumber);
            }
            if ($scope.patientInfo.OfficePhoneNumber != null) {
                $scope.OfficePhoneNumber = $scope.patientInfo.OfficePhoneNumber.FormatPhoneNumber;
            }
            if ($scope.patientInfo.MobilePhoneNumber != null) {
                $scope.MobilePhoneNumber = $scope.patientInfo.MobilePhoneNumber.FormatPhoneNumber;
            }
            if ($scope.patientInfo.DateOfBirth == '')
                $scope.patientInfo.DateOfBirth = null;

            var isEligible = null;
            if ($scope.patientInfo.EligibleStatus == $scope.EligibleStatus[1].value) {
                isEligible = true;
            }
            else if ($scope.patientInfo.EligibleStatus == $scope.EligibleStatus[2].value) {
                isEligible = false;
            }

            //  $scope.patientInfo.EligibleStatus = isEligible;

            var customerEditModel = {
                CustomerId: customerId,
                ProspectCustomerId: prospectId,
                FirstName: $scope.patientInfo.FirstName,
                LastName: $scope.patientInfo.LastName,
                Gender: $scope.patientInfo.Gender,
                Email: $scope.patientInfo.Email,
                AlternateEmail: $scope.patientInfo.AlternateEmail,
                UserId: $scope.patientInfo.UserId,
                DateOfBirth: $scope.patientInfo.DateOfBirth,
                CallID: $scope.callId,
                CallQueueCustomerId: $scope.callQueueCustomerId,
                CallBackPhoneNumber: $scope.CallBackPhoneNumber,
                OfficePhoneNumber: $scope.OfficePhoneNumber,
                MobilePhoneNumber: $scope.MobilePhoneNumber,
                IsHealthPlanQueue: true,
                Hicn: $scope.patientInfo.HicnNumber,
                Mbi: $scope.patientInfo.MbiNumber,
                MemberId: $scope.patientInfo.MemberId,
                EligibleStatus: isEligible,
                ActivityId: $scope.patientInfo.ActivityId,
                Address: {
                    StreetAddressLine1: $scope.patientInfo.AddressViewModel.StreetAddressLine1,
                    StreetAddressLine2: $scope.patientInfo.AddressViewModel.StreetAddressLine2,
                    City: $scope.patientInfo.AddressViewModel.City,
                    StateId: $scope.patientState,
                    CountryId: 1,
                    ZipCode: $scope.patientInfo.AddressViewModel.ZipCode
                },

                PrimaryCarePhysician: setPrimaryCarePhysicianEditModel(),
                EnableEmail: $scope.patientInfo.EnableEmail
            };

            $scope.loader_saveCustomer = true;
            $scope.isPostBack = true;

            contactService.UpdateCallQuequeCustomer(customerEditModel).then(function (result) {
                if (result != null) {
                    $scope.patientInfo = result.PatientInfomation;
                    setCallUrl();

                    $scope.patientInfo.ActivityId = result.PatientInfomation.ActivityId.toString();
                    $.each($scope.States, function (index, item) {
                        if (item.FirstValue == $scope.patientState.FirstValue) {
                            $scope.patientInfo.AddressViewModel.State = item.SecondValue;
                        }
                    });

                    //$scope.EventFilters.zipcode = $scope.patientInfo.AddressViewModel.ZipCode;
                    $scope.EventFilters.customerZipCode = $scope.patientInfo.AddressViewModel.ZipCode;

                    $scope.loader_saveCustomer = false;
                    $scope.isPostBack = false;
                    $scope.updateCustomer = false;
                    setDefaultConsent();
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

                if (typeof $scope.patientInfo.PrimaryCarePhysician != 'undefined' && $scope.patientInfo.PrimaryCarePhysician != null) {
                    if ($scope.patientInfo.PrimaryCarePhysician.Address != null) {
                        $scope.StatePcp = $scope.States[0].FirstValue;
                        $.each($scope.States, function (index, item) {
                            if (item.SecondValue == $scope.patientInfo.PrimaryCarePhysician.Address.State) {
                                $scope.StatePcp = item.FirstValue;
                            }
                        });
                    }

                    if ($scope.patientInfo.PrimaryCarePhysician.MailingAddress == null) {
                        angular.copy($scope.patientInfo.PrimaryCarePhysician.Address, $scope.patientInfo.PrimaryCarePhysician.MailingAddres);
                    }

                    if ($scope.patientInfo.PrimaryCarePhysician.MailingAddress != null) {
                        $scope.StateMailingPcp = $scope.States[0].FirstValue;
                        $.each($scope.States, function (index, item) {
                            if (item.SecondValue == $scope.patientInfo.PrimaryCarePhysician.MailingAddress.State) {
                                $scope.StateMailingPcp = item.FirstValue;
                            }
                        });
                    }

                    setPcpScopeModel();

                    $scope.PrimaryCarePhysician.HasSameAddress = isAddressSameAsMailing($scope.patientInfo.PrimaryCarePhysician);
                }

                $scope.updateCustomer = true;

                $scope.copy = angular.copy($scope.patientInfo);

                if ($scope.patientInfo.Gender == null || $scope.patientInfo.Gender === $scope.Gender.Unspecified) {
                    $scope.patientInfo.Gender = $scope.genderDropDown[0].value;
                }
                if ($scope.patientInfo.IsEligible == null) {
                    $scope.patientInfo.EligibleStatus = $scope.EligibleStatus[0].value;
                } else {

                    if ($scope.patientInfo.IsEligible) {
                        $scope.patientInfo.EligibleStatus = 'Yes';
                    } else {
                        $scope.patientInfo.EligibleStatus = 'No';
                    }
                }

                if ($scope.patientInfo.DateOfBirth != null) {
                    $scope.patientInfo.DateOfBirth = moment($scope.patientInfo.DateOfBirth).format("MM/DD/YYYY");
                }
            } catch (e) {

            }

            $scope.isPostBack = false;
            $scope.loader_updateCustomer = false;
        };

        var checkIsPropertyNotNullOrUndefined = function (property) {
            if (typeof property == 'undefined' || property == null) return false;
            return true;
        };

        var checkIsPropertyNotNullOrUndefinedOrEmpty = function (property) {
            if (typeof property == 'undefined' || property == null || property == '') return false;
            return true;
        };
        var checkIsPcpAddressIsNotEmpty = function (address) {
            if (checkIsPropertyNotNullOrUndefined(address) && (checkIsPropertyNotNullOrUndefinedOrEmpty(address.StreetAddressLine1)
                || checkIsPropertyNotNullOrUndefinedOrEmpty(address.StreetAddressLine2) || checkIsPropertyNotNullOrUndefinedOrEmpty(address.City)
                || checkIsPropertyNotNullOrUndefinedOrEmpty(address.ZipCode))) {
                return true;
            }
            return false;
        };

        var setPrimaryCarePhysicianEditModel = function () {

            var pcpInfo = $scope.PrimaryCarePhysician;

            if (checkIsPropertyNotNullOrUndefined(pcpInfo) && ((checkIsPropertyNotNullOrUndefined(pcpInfo.FullName)
                        && (checkIsPropertyNotNullOrUndefinedOrEmpty(pcpInfo.FullName.LastName) || checkIsPropertyNotNullOrUndefinedOrEmpty(pcpInfo.FullName.FirstName)))
                || checkIsPcpAddressIsNotEmpty(pcpInfo.Address) || checkIsPropertyNotNullOrUndefinedOrEmpty(pcpInfo.Email))) {


                var phoneNumber = $scope.pcpPhoneNumber;

                if (checkIsPropertyNotNullOrUndefinedOrEmpty(phoneNumber)) {
                    phoneNumber = phoneNumber.replace("(", "");
                    phoneNumber = phoneNumber.replace(")", "");
                    phoneNumber = phoneNumber.replace(/_/gi, "");
                    phoneNumber = phoneNumber.replace(/-/gi, "");
                    $scope.PrimaryCarePhysician.PhoneNumber = { AreaCode: "", Number: "" };
                    $scope.PrimaryCarePhysician.PhoneNumber.AreaCode = phoneNumber.substring(0, 3);
                    $scope.PrimaryCarePhysician.PhoneNumber.Number = phoneNumber.substring(3, phoneNumber.length).trim();
                } else {
                    $scope.PrimaryCarePhysician.PhoneNumber = null;
                }

                if (checkIsPcpAddressIsNotEmpty(pcpInfo.Address)) {

                    $scope.PrimaryCarePhysician.Address.StateId = $scope.StatePcp;
                    $scope.PrimaryCarePhysician.Address.CountryId = 1;
                }

                if (checkIsPcpAddressIsNotEmpty(pcpInfo.MailingAddress)) {
                    $scope.PrimaryCarePhysician.MailingAddress.StateId = $scope.StateMailingPcp;
                    $scope.PrimaryCarePhysician.MailingAddress.CountryId = 1;
                }

                if ($scope.PrimaryCarePhysician.HasSameAddress == true && checkIsPcpAddressIsNotEmpty(pcpInfo.Address)) {

                    if ($scope.PrimaryCarePhysician.MailingAddress === null)
                        $scope.PrimaryCarePhysician.MailingAddress = new Object();

                    $scope.PrimaryCarePhysician.MailingAddress.StateId = $scope.StateMailingPcp;
                    $scope.PrimaryCarePhysician.MailingAddress.CountryId = 1;

                    $scope.PrimaryCarePhysician.MailingAddress.StreetAddressLine1 = $scope.PrimaryCarePhysician.Address.StreetAddressLine1;
                    $scope.PrimaryCarePhysician.MailingAddress.StreetAddressLine2 = $scope.PrimaryCarePhysician.Address.StreetAddressLine2;
                    $scope.PrimaryCarePhysician.MailingAddress.ZipCode = $scope.PrimaryCarePhysician.Address.ZipCode;
                    $scope.PrimaryCarePhysician.MailingAddress.City = $scope.PrimaryCarePhysician.Address.City;
                    $scope.PrimaryCarePhysician.MailingAddress.StateId = $scope.PrimaryCarePhysician.Address.StateId;
                    $scope.PrimaryCarePhysician.MailingAddress.CountryId = $scope.PrimaryCarePhysician.Address.CountryId;
                }
            }
            else {
                $scope.PrimaryCarePhysician = null;
            }

            return $scope.PrimaryCarePhysician;
        };

        var setPcpScopeModel = function () {
            var pcpInfo = $scope.patientInfo.PrimaryCarePhysician;
            $scope.PrimaryCarePhysician = null;

            if (pcpInfo != null) {
                $scope.PrimaryCarePhysician = $scope.patientInfo.PrimaryCarePhysician;
                if (checkIsPropertyNotNullOrUndefined($scope.PrimaryCarePhysician.PhoneNumber)) {
                    $scope.pcpPhoneNumber = $scope.PrimaryCarePhysician.PhoneNumber.FormatPhoneNumber;
                }
            }
        };

        $scope.setStatus = function (status) {
            $scope.selectedCallStatusId = status.value;
            $scope.ShowNotInterestedReason = false;
            $scope.showNotesMandatory = false;
            $scope.SelectedReason = null;
            $scope.showConsentDiv = false;
            setDefaultConsent();
            $scope.CallbackRequestedChk = false;
            if ($scope.selectedCallStatusId == constants.CallStatus.Attended) {
                $scope.SelectedDisposition = '0';
                //getCallDispositions(false, false);
                $scope.showDispositionDiv = true;
                $scope.showRequestedCallBackDiv = true;
                $scope.showHelpText = true;
                $scope.showConsentDiv = true;
            } else if ($scope.selectedCallStatusId == constants.CallStatus.LeftMessageWithOther) {
                $scope.SelectedDisposition = '0';
                //getCallDispositions(true, false);
                $scope.showDispositionDiv = true;
                $scope.showHelpText = false;
            } else if ($scope.selectedCallStatusId == constants.CallStatus.TalkedtoOtherPerson) {
                //getCallDispositions(false, true);
                $scope.SelectedDisposition = 'IncorrectPhoneNumber_TalkedToOthers';
                $scope.showDispositionDiv = true;
                $scope.showHelpText = false;

            } else if ($scope.selectedCallStatusId == constants.CallStatus.NoEventsInArea) {
                //getCallDispositions(false, true);
                $scope.SelectedDisposition = '0';
                $scope.showDispositionDiv = true;
                $scope.showHelpText = false;

            } else {
                $scope.showDispositionDiv = false;
                $scope.CallBackDateTime.date = '';
                $scope.CallBackDateTime.time = '';
                $scope.showRequestedCallBackDiv = false;
                $scope.SelectedDisposition = '0';
                $scope.showHelpText = false;
            }
            getCallDispositions($scope.selectedCallStatusId);
        };

        function isNotesMandatory() {
            var id = $scope.SelectedDisposition;

            if (id == constants.ProspectCustomer.HealthPlanTag.RecentlySawDoc || id == constants.ProspectCustomer.HealthPlanTag.NotInterested ||
                id == constants.ProspectCustomer.HealthPlanTag.DateTimeConflict || id == constants.ProspectCustomer.HealthPlanTag.HomeVisitRequested ||
                id == constants.ProspectCustomer.HealthPlanTag.LanguageBarrier || id == constants.ProspectCustomer.HealthPlanTag.InLongTermCareNursingHome ||
                id == constants.ProspectCustomer.HealthPlanTag.LeftMessage) {

                return true;
            }
            return false;
        }

        $scope.onCallDispositionSelected = function () {
            $scope.CallBackDateTime.date = '';
            $scope.CallBackDateTime.time = '';
            $scope.showRequestedCallBackDiv = false;
            $scope.CallbackRequestedChk = false;
            $scope.ShowNotInterestedReason = false;
            $scope.SelectedReason = null;

            if ($scope.SelectedDisposition == constants.ProspectCustomer.HealthPlanTag.NotInterested) {
                $scope.ShowNotInterestedReason = true;
            }
            else if ($scope.SelectedDisposition == constants.ProspectCustomer.HealthPlanTag.CallBackLater) {
                $scope.CallbackRequestedChk = true;
                $scope.showRequestedCallBackDiv = true;
            }
            else {
                $scope.CallbackRequestedChk = false;
            }

            $scope.showNotesMandatory = isNotesMandatory();

        };

        $scope.saveCallOutCome = function () {
            var customerId = 0;
            if ($scope.selectedCallStatusId == 0) {
                logger.showToasterError('Please select one of the call outcome options');
                return;
            }
            if (($scope.selectedCallStatusId == constants.CallStatus.Attended || $scope.selectedCallStatusId == constants.CallStatus.LeftMessageWithOther || $scope.selectedCallStatusId == constants.CallStatus.TalkedtoOtherPerson
                || $scope.selectedCallStatusId == constants.CallStatus.NoEventsInArea) && $scope.SelectedDisposition == '0') {
                logger.showToasterError('Please select one of the call disposition');
                return;
            } else if (($scope.selectedCallStatusId == constants.CallStatus.Attended || $scope.selectedCallStatusId == constants.CallStatus.LeftMessageWithOther) && $scope.SelectedDisposition != '0') {

                if (isNotesMandatory() && ($scope.CallNotes == null || $scope.CallNotes.trim() == '')) {
                    logger.showToasterError('Please enter the notes.');
                    return;
                }
            }

            if ($scope.selectedCallStatusId == constants.CallStatus.Attended && $scope.ShowNotInterestedReason == true && $scope.SelectedReason == null) {
                logger.showToasterError('Please select reason.');
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

                    if (selectedDate.isValid() === false) {
                        logger.showToasterError('Please provide a valid date time.');
                        return;
                    }
                    if (!selectedDate.isAfter(currentdate)) {
                        logger.showToasterError('Please select a future date and time.');
                        return;
                    }
                }
            }

            if ($scope.isConfirmationCall == true && $scope.selectedCallStatusId == constants.CallStatus.Attended && $scope.SelectedDisposition == constants.AttendedConfirmationDispositions[4].Alias) {
                var date = new Date($scope.registeredEventInformation.EventDate.toString());
                var callBackDate = new Date($scope.CallBackDateTime.date);

                if (callBackDate >= date) {
                    logger.showToasterError('The callback date should be less than event date.');
                    return;
                }
            }

            if ($scope.selectedCallStatusId == constants.CallStatus.Attended) {
                if ($scope.consentModel.phoneHome === "" && $scope.consentModel.homeConsent != constants.PatientConsent.Unknown) {
                    logger.showToasterError('Enter Phone Home before saving consent');
                    return;
                }
                if ($scope.consentModel.phoneOffice === "" && $scope.consentModel.officeConsent != constants.PatientConsent.Unknown) {
                    logger.showToasterError('Enter Phone Office before saving consent');
                    return;
                }
                if ($scope.consentModel.phoneCell === "" && $scope.consentModel.cellConsent != constants.PatientConsent.Unknown) {
                    logger.showToasterError('Enter Phone Cell before saving consent');
                    return;
                }

                if ($scope.consentModel.cellConsent == constants.PatientConsent.Unknown
                    && $scope.consentModel.officeConsent == constants.PatientConsent.Unknown
                    && $scope.consentModel.homeConsent == constants.PatientConsent.Unknown) {
                    var isConfirm = confirm("Consent for all phone numbers is set to Unknown. Do you want to continue?");
                    if (!isConfirm)
                        return;
                }
            }

            var dataModel = {
                CallQueueCustomerId: $scope.callQueueCustomerId,
                CallId: $scope.callId,
                CallStatusId: $scope.selectedCallStatusId,
                CallBackDateTime: ($scope.CallbackRequestedChk) ? $scope.CallBackDateTime.dateTime : null,
                Note: $scope.CallNotes,
                CustomerId: customerId,
                //ProspectCustomerId: $scope.ProspectCustomerId,
                RemoveFromQueue: false,
                DoNotCall: $scope.DoNotCall,
                DispositionAlias: $scope.SelectedDisposition,
                NotIntrestedReasonId: $scope.SelectedReason,
                CallQueueId: $scope.CustomerFilters.CallQueueId,
                PhoneHome: $scope.consentModel.phoneHome,
                PhoneOffice: $scope.consentModel.phoneOffice,
                PhoneCell: $scope.consentModel.phoneCell,
                PhoneHomeConsent: $scope.consentModel.homeConsent,
                PhoneOfficeConsent: $scope.consentModel.officeConsent,
                PhoneCellConsent: $scope.consentModel.cellConsent,
                ActivityId: window.localStorage.getItem("hfActivityId"),
            };
            $scope.loader_saveOutCome = true;
            $scope.isPostBack = true;

            contactService.saveCallOutCome(dataModel).then(function (result) {
                if ($scope.showConsentDiv) {
                    logger.showToasterSuccess('Call Notes and Consent saved successfuly.');
                } else {
                    logger.showToasterSuccess('Call Notes saved successfuly.');
                }
                $scope.isCallbackRequested = $scope.CallBackDateTime.dateTime != null ? true : false;
                $scope.isCallOutComeSaved = true;
                $scope.loader_saveOutCome = false;
                $scope.isPostBack = false;
                //set updated Number and URLs
                updateConsentAndPhoneInfo(result);

                setCallUrl();
            }, function () {
                $scope.loader_saveOutCome = false;
                $scope.isPostBack = false;
            });
        };

        modelPopupInstance = null;

        $scope.customerNotesPopup = function () {

            modelPopupInstance = $modal.open({
                templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/healthplan/customer.notes.client.view.html',
                controller: 'customerNotesController',
                size: 'lg',
                backdrop: 'static',
                keyboard: false,
                resolve: {
                    data: function () {
                        return { CustomerNotes: $scope.customerNotes };
                    }
                }
            });
        };

        function hideErrors() {
            $("span.validation-message").val('').hide();
            $('form :input').removeClass('validation-message');
        }

        $scope.getCallDispositionText = function (selectedDisposition) {

            if ($scope.CallDispositionOptions != null) {
                var dispositions = $scope.CallDispositionOptions;
                var dispositionText = 'N/A';
                var i = 0;
                for (i = 0; i < dispositions.length; i++) {
                    var item = dispositions[i];
                    if (item.Value == selectedDisposition) {
                        dispositionText = item.Text;
                        break;
                    }
                }
                return dispositionText;
            }
            return 'N/A';
        };

        function isAddressSameAsMailing(pcp) {
            if (pcp == null) return true;
            if (pcp.Address != null && pcp.MailingAddress === null) return true;
            if (pcp.Address == null && pcp.MailingAddress === null) return true;
            if (pcp.Address != null && pcp.MailingAddress != null) {
                return pcp.Address.StreetAddressLine1 === pcp.MailingAddress.StreetAddressLine1 && pcp.Address.StreetAddressLine2 === pcp.MailingAddress.StreetAddressLine2 &&
                       pcp.Address.City === pcp.MailingAddress.City && pcp.Address.State === pcp.MailingAddress.State;
            }
            return false;
        }

        $scope.copyAddressToMailingAddrress = function (pcp) {

            if (pcp != null) {
                if (pcp.MailingAddress == null)
                    pcp.MailingAddress = new Object();

                angular.copy(pcp.Address, pcp.MailingAddress);
            }
        };

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
                //$scope.pagingFilters.SearchMammoEvents = !$scope.EventFilters.SearchAllEvents;
                
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

        //$scope.SetReadAndUnderstood = function () {
        //    contactService.SetReadAndUnderstoodNotes($scope.attemptId).then(function (result) {
        //        $scope.ReadAndUnderstood = result;
        //        if (!$scope.isConfirmationCall) {
        //            contactService.GetEventsByZipCode($scope.EventFilters, false, 1).then(function (eventList) {
        //                $scope.Events = eventList.Events;
        //                $scope.PagingModel = eventList.PagingModel;
        //                $scope.loader_customerEventSearch = false;
        //                $scope.isPostBack = false;
        //            }, function () {
        //                $scope.loader_customerEventSearch = false;
        //                $scope.isPostBack = false;
        //            });
        //        }
        //    });
        //};

        $scope.ShowTab = function (showTab) {
            if ($scope.NotesTabContactHistory.CallHistoryTab == showTab) {
                $scope.callHistoryTab = true;
                $scope.notesTab = false;
                $scope.directMailTab = false;
            } else if ($scope.NotesTabContactHistory.NotesCustomerNotesTab == showTab) {
                $scope.notesTab = true;
                $scope.callHistoryTab = false;
                $scope.directMailTab = false;
            } else if ($scope.NotesTabContactHistory.DirectMailTab == showTab) {
                $scope.directMailTab = true;
                $scope.callHistoryTab = false;
                $scope.notesTab = false;
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

        $scope.IsFutureDate = function (mailDate) {

            mailDate = moment(new Date(mailDate)).format('MM/DD/YYYY');
            var currenDate = moment(new Date()).format('MM/DD/YYYY');

            return moment(mailDate).isAfter(currenDate);
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

        function getCallDispositions(outcomeId) {
            
            var dropdown = [];
            var object = { Value: '0', Text: '-- Select --' };
            dropdown.push(object);
            if ($scope.isConfirmationCall && outcomeId == constants.CallStatus.Attended) {
                $.each(constants.AttendedConfirmationDispositions, function (index, item) {
                    object = { Value: item.Alias, Text: item.Name };
                    dropdown.push(object);
                });
            }
            else {
                
                var isForConfirmation = false;
                $.each($scope.AllDispositionOptions, function (index, item) {
                    //if (( item.Alias == 'CancelAppointment' || item.Alias == 'RescheduleAppointment' || item.Alias == 'CHATCompleted' || item.Alias == 'RequestedCHATMailed' || item.Alias == 'MemberDoesntHaveTimeForQuestions' || item.Alias == 'MemberDoesNotFeelComfortableAnsweringQuestions' || item.Alias == 'FollowUpCallEscalated' || item.Alias == 'MemberConfirmedChange' || item.Alias == 'NotInterested'))
                    if ((item.Alias == 'PatientConfirmed' || item.Alias == 'CancelAppointment' || item.Alias == 'RescheduleAppointment' || item.Alias == 'ConfirmedHRANotComplete' || item.Alias == 'ConfirmLanguageBarrier'))
                        isForConfirmation = true;
                    else
                        isForConfirmation = false;
                    if ($scope.WarmTransfer) {
                        if (item.CallStatus == outcomeId && !isForConfirmation) {
                            object = { Value: item.Alias, Text: item.Name };
                            dropdown.push(object);
                        }
                    }
                    else {
                        if (item.CallStatus == outcomeId && !isForConfirmation && !item.ForWarmTransfer) {
                            object = { Value: item.Alias, Text: item.Name };
                            dropdown.push(object);
                        }
                    }
                });
            }
            $scope.CallDispositionOptions = dropdown;

        }

        function setCallUrl() {
            if ($scope.patientInfo.HealthPlanPhoneNumber != null && $scope.patientInfo.HealthPlanPhoneNumber.Number != '') {
                if ($scope.patientInfo.CallBackPhoneNumber != null && $scope.patientInfo.CallBackPhoneNumber.Number != '')
                    //$scope.PhoneHomeUrl = "Glocom://*65*" + $scope.patientInfo.HealthPlanPhoneNumber.AreaCode + $scope.patientInfo.HealthPlanPhoneNumber.Number + "*1" + $scope.patientInfo.CallBackPhoneNumber.AreaCode + $scope.patientInfo.CallBackPhoneNumber.Number;
                    $scope.PhoneHomeUrl = $scope.patientInfo.CallBackPhoneNumberUrl;

                if ($scope.patientInfo.OfficePhoneNumber != null && $scope.patientInfo.OfficePhoneNumber.Number != '')
                    //$scope.PhoneOfficeUrl = "Glocom://*65*" + $scope.patientInfo.HealthPlanPhoneNumber.AreaCode + $scope.patientInfo.HealthPlanPhoneNumber.Number + "*1" + $scope.patientInfo.OfficePhoneNumber.AreaCode + $scope.patientInfo.OfficePhoneNumber.Number;
                    $scope.PhoneOfficeUrl = $scope.patientInfo.OfficePhoneNumberUrl;

                if ($scope.patientInfo.MobilePhoneNumber != null && $scope.patientInfo.MobilePhoneNumber.Number != '')
                    //$scope.PhoneMobileUrl = "Glocom://*65*" + $scope.patientInfo.HealthPlanPhoneNumber.AreaCode + $scope.patientInfo.HealthPlanPhoneNumber.Number + "*1" + $scope.patientInfo.MobilePhoneNumber.AreaCode + $scope.patientInfo.MobilePhoneNumber.Number;
                    $scope.PhoneMobileUrl = $scope.patientInfo.MobilePhoneNumberUrl;
            }
        }

        $scope.EndCallandGetNextAvailableCustomer = function () {
            closeScriptWindow();
            if ($scope.isCallOutComeSaved) {
                var endCall = {
                    CallQueueCustomerId: $scope.callQueueCustomerId,
                    CallId: $scope.callId,
                    SelectedDisposition: $scope.SelectedDisposition,
                    CallOutcomeId: $scope.selectedCallStatusId,
                    IsSkipped: false,
                    AttemptId: $scope.attemptId
                };
                $scope.isPostBack = true;
                $scope.loader_EndActvieCall = true;
                contactService.EndHealthPlanActiveCall(endCall).then(function (success) {
                    if (success === true) {
                        $scope.getNextAvailableCustomerForCall();
                    } else {
                        $scope.isPostBack = false;
                        $scope.loader_EndActvieCall = false;
                    }
                });
            } else {
                logger.showToasterError('Please save Call Outcome before ending call.');
            }
        };

        $scope.SaveSkipCallNotes = function () {
            closeScriptWindow();
            var modalInstance = $modal.open({
                templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/callcenter/views/healthplan/healthplan.skipcallnotes.client.view.html',
                controller: 'SaveSkipCallNotesController',
                backdrop: 'static',
                size: 'md'
            });
            modalInstance.result.then(function (skipCallNote) {
                if (skipCallNote != null && skipCallNote != '') {
                    var callid = $scope.callId;
                    var callQueueCustomerId = $stateParams.callQueueCustomerId;
                    $scope.selectedCallStatusId = constants.CallStatus.CallSkipped;
                    $scope.SelectedDisposition = '';
                    $scope.loader_EndActvieCall = true;
                    $scope.isPostBack = true;

                    var model = {
                        CallQueueCustomerId: callQueueCustomerId,
                        CallId: callid,
                        SelectedDisposition: $scope.SelectedDisposition,
                        CallOutcomeId: $scope.selectedCallStatusId,
                        SkipCallNote: skipCallNote,
                        IsSkipped: true,
                        AttemptId: $scope.attemptId
                    };
                    contactService.EndHealthPlanActiveCall(model).then(function () {
                        $scope.loader_EndActvieCall = false;
                        $scope.isPostBack = false;
                        $scope.getNextAvailableCustomerForCall();
                    }, function () {
                        $scope.loader_saveOutCome = false;
                        $scope.isPostBack = false;
                    });
                }
            });

        };

        $scope.getNextAvailableCustomerForCall = function () {
            //var filter = { EventId: window.localStorage.hpEventId, Pod: window.localStorage.hpPod, FillEventZipCode: window.localStorage.hpFillEventZipCode };
            //healthplanlocalstorage.SetFilledEventCallQueueFilter(filter);
            var searchModel = {
                CallQueueId: window.localStorage.hpCallQueueId,
                EventId: window.localStorage.hpEventId,
                HealthPlanId: window.localStorage.hpHealthPlanId,
                ZipCode: window.localStorage.hpFillEventZipCode,
                Radius: window.localStorage.hpRadius,
                UseCustomTagExclusively: false,
                PageNumber: 1,
                CriteriaId: window.localStorage.hpCriteriaId,
                CampaignId: window.localStorage.hpCampaignId
            };
            usSpinnerService.spin('online-spinner');
            searchHealthPlanService.ViewAvailableCustomerForFillEvent(searchModel).then(function (result) {
                usSpinnerService.stop('online-spinner');
                if (result.TryAgain) {
                    $scope.getNextAvailableCustomerForCall();
                } else if (result.AssignmentChanged) {
                    logger.showToasterError("Your assignment is changed.");
                    $state.transitionTo('CallCentreDashboard', { isCallQueueSelected: "noQueuesSelected" }, { reload: true });
                } else if (result.NoMoreCustomerInList) {
                    logger.showToasterError("No patient left in queue. Please check back in few mins.");
                    $state.transitionTo('CallCentreDashboard', { isCallQueueSelected: "noQueuesSelected" }, { reload: true });
                } else {
                    //window.localStorage.setItem("isScriptOpen", true);
                    $state.go('healthplanContact', { callQueueCustomerId: result.CallQueueCustomerId, attemptId: result.AttemptId });
                }
            }, function () {
                usSpinnerService.stop('online-spinner');
            });
        };

        $scope.StartOutboundCall = function (numberToCall, patientPhoneNumber) {
            if ($scope.isPostBack == true) {
                return;
            }
            if ($scope.callId !== 0) {
                $scope.isPostBack = false;
                contactService.UpdateCallersPhoneNumber($scope.callId, patientPhoneNumber).then(function () {
                    window.open(numberToCall, '_blank');
                });
                return;
            }
            $scope.isPostBack = true;
            usSpinnerService.spin('online-spinner');
            contactService.StartCallAndUpdateCallAttemptTable($scope.callQueueCustomerId, $scope.attemptId, $scope.patientInfo.HealthPlanPhoneNumber.FormatPhoneNumber, patientPhoneNumber, $scope.model.CallQueueCategory).then(function (result) {
                if (result > 0) {;
                    $scope.callId = result;
                    $scope.showCallOutcomeAndEndCallButton = true;
                    window.open(numberToCall, '_blank');
                    window.localStorage.setItem("hfAtivityId", $scope.patientInfo.ActivityId);
                    window.localStorage.setItem("hfCustomerId", $scope.patientInfo.CustomerId);
                    contactService.GetNotes($scope.callId, $scope.callQueueCustomerId).then(function (result) {
                        $scope.customerNotes = result.CustomerCallNotes;
                        $scope.callHistory = result.CallHistory;
                        $scope.directMail = result.DirectMail;

                        $.each($scope.customerNotes, function (index, item) {

                            if (item.NotesType == $scope.CustomerRegistrationNotesType.AppointmentNote && item.EventId > 0) {
                                item.NotesTypeName = "Event Instructions";
                                $scope.customerNotesModel.push(item);
                            } else if (item.NotesType == $scope.CustomerRegistrationNotesType.PostScreeningFollowUpNotes) {
                                item.NotesTypeName = "Post Screening Followup Notes";
                                $scope.customerNotesModel.push(item);
                            } else if ((item.NotesType == $scope.CustomerRegistrationNotesType.CustomerNote || item.NotesType == $scope.CustomerRegistrationNotesType.AppointmentNote) && (item.EventId == null || item.EventId == 0)) {
                                item.NotesTypeName = "General Instructions";
                                $scope.customerNotesModel.push(item);
                            } else if (item.NotesType == $scope.CustomerRegistrationNotesType.CancellationNote) {
                                item.NotesTypeName = "Cancellation Note";
                                $scope.customerNotesModel.push(item);
                            }
                            else if (item.NotesType == $scope.CustomerRegistrationNotesType.LeftWithoutScreeningNotes) {
                                item.NotesTypeName = "Left Without Screening Note";
                                $scope.customerNotesModel.push(item);
                            }
                        });
                    });

                } else {
                    logger.showToasterError("Can't Start Call, Something went wrong. Contact Manager");
                }
                setTimeout(function () {
                    usSpinnerService.stop('online-spinner');
                }, 500);
                $scope.isPostBack = false;
            }, setTimeout(function () {
                usSpinnerService.stop('online-spinner');
            }, 500));


        };

        $scope.openScriptWindow = function () {
            var properties = "width=" + Number($(window).width() / 2) + ", height=" + Number($(window).height()) + ", resizable=1, scrollbars=1";

            $scope.isScriptOpen = true;
            if ($scope.patientInfo.CallCenterScriptUrl != null && $scope.patientInfo.CallCenterScriptUrl != '') {
                $scope.scriptPopup = window.open($scope.patientInfo.CallCenterScriptUrl, "Call Center Script", properties);

                window.localStorage.setItem("isScriptOpen", true);
                window.localStorage.setItem('scriptUrl', $scope.patientInfo.CallCenterScriptUrl);
                checkScriptPopupOpen();
            }
        };

        function checkScriptPopupOpen() {
            if ($scope.scriptPopup && $scope.scriptPopup.closed) {
                window.localStorage.setItem("isScriptOpen", false);
                window.localStorage.removeItem("scriptUrl");
            } else {
                window.setTimeout(checkScriptPopupOpen, 500);
            }
        }

        function closeScriptWindow() {
            if ($scope.isScriptOpen && $scope.scriptPopup != null) {
                $scope.scriptPopup.close();
            }
        }

        /*window.onbeforeunload = function () {
            if ($scope.isScriptOpen) {
                $scope.scriptPopup.close();
            }
        };*/

        $scope.gotoDashboard = function () {
            closeScriptWindow();
            contactService.ReleaseLockedCustomer($scope.callQueueCustomerId);
            $state.transitionTo('CallCentreDashboard');
        };

        $scope.viewOnMap = function () {
            var patientAddress = $scope.patientInfo.AddressViewModel.StreetAddressLine1;
            if ($scope.patientInfo.AddressViewModel.StreetAddressLine2 != null && $scope.patientInfo.AddressViewModel.StreetAddressLine2 != '')
                patientAddress += ", " + $scope.patientInfo.AddressViewModel.StreetAddressLine2;
            if ($scope.patientInfo.AddressViewModel.City != null && $scope.patientInfo.AddressViewModel.City != '')
                patientAddress += ", " + $scope.patientInfo.AddressViewModel.City;
            if ($scope.patientInfo.AddressViewModel.State != null && $scope.patientInfo.AddressViewModel.State != '')
                patientAddress += ", " + $scope.patientInfo.AddressViewModel.State;
            if ($scope.patientInfo.AddressViewModel.ZipCode != null && $scope.patientInfo.AddressViewModel.ZipCode != '')
                patientAddress += ", " + $scope.patientInfo.AddressViewModel.ZipCode;

            var url = "https://maps.google.com?saddr=" + patientAddress.replace('#', '') + "&daddr=" + $scope.registeredEventInformation.HostAddress.replace('#', '');
            window.open(url, "_blank");
        };

        $scope.cancelAppointment = function () {
            var result = confirm("Are you sure you want to cancel this appointment?");
            if (result) {
                window.location.href = ApplicationConfiguration.appUrl + '/App/CallCenter/CallCenterRep/CallCenterRepCancelAppointment.aspx?Call=No&EventCustomerID=' + $scope.registeredEventInformation.EventCustomerId
                    + '&callQueueCustomerId=' + $scope.callQueueCustomerId + '&attemptId=' + $scope.attemptId;
            }
        };

        $scope.rescheduleAppointment = function () {
            var result = confirm("Are you sure you want to reschedule appointment for this patient?");
            if (result) {
                /*window.location.href = ApplicationConfiguration.appUrl + '/CallCenter/CallQueue/ChangeAppointment?callQueueCustomerId=' + $scope.callQueueCustomerId + '&callId=' + $scope.callId + '&attemptId=' + $scope.attemptId
                    + '&eventId=' + $scope.registeredEventInformation.EventId;*/
                window.location.href = ApplicationConfiguration.appUrl + '/App/CallCenter/CallCenterRep/CallCenterRepRescheduleCustomerAppointment.aspx?Call=No&EventCustomerID=' + $scope.registeredEventInformation.EventCustomerId
                    + "&EventID=" + $scope.registeredEventInformation.EventId + "&CustomerID=" + $scope.patientInfo.CustomerId
                    + '&callQueueCustomerId=' + $scope.callQueueCustomerId + '&attemptId=' + $scope.attemptId;
            }
        };

        $scope.openHaf = function (eventId, customerId) {
            var properties = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=1100,height=500";


            if (eventId > 0 && customerId > 0) {
                var url = "/App/Franchisor/MedicalHistory.aspx?CustomerID=" + customerId + "&EventId=" + eventId + "&Edit=true";
                $scope.hafPopup = window.open(url, "Health Assessment Form", properties);

            }
        };

        function setHraValues() {
            var url = $scope.registeredEventInformation.HraQuestionerAppUrl;
            var name = $scope.registeredEventInformation.OrganizationNameForHraQuestioner;
            var corporateTag = $scope.registeredEventInformation.CorporateAccountTag;
            var token = window.localStorage.hraEncryptedToken;
            var evtId = $scope.registeredEventInformation.EventId;

            initiateHraQuestionare(url, name, corporateTag, token, evtId, true, true);

            $(document).bind('cbox_open', function () {
                $('body').css({ overflow: 'hidden' });
            }).bind('cbox_closed', function () {
                $('body').css({ overflow: '' });
            });
        }

        $scope.openHra = function () {
            checkSession().then(function () {
                var eventCustId = $scope.registeredEventInformation.EventCustomerId;
                var custId = $scope.patientInfo.CustomerId;
                var visitId = $scope.registeredEventInformation.MedicareVisitId;
                addColorBox(eventCustId, custId, visitId);
                $('#hraLink_' + eventCustId).click();
            }, function (data) {
                alert(data);
            });
        };

        function setDefaultConsent() {
            $scope.consentModel.homeConsent = $scope.patientInfo.PhoneHomeConsent;
            $scope.consentModel.officeConsent = $scope.patientInfo.PhoneOfficeConsent;
            $scope.consentModel.cellConsent = $scope.patientInfo.PhoneCellConsent;

            $scope.consentModel.phoneHome = $scope.patientInfo.CallBackPhoneNumber.FormatPhoneNumber;
            $scope.consentModel.phoneOffice = $scope.patientInfo.OfficePhoneNumber.FormatPhoneNumber;
            $scope.consentModel.phoneCell = $scope.patientInfo.MobilePhoneNumber.FormatPhoneNumber;
        }

        function updateConsentAndPhoneInfo(result) {
            $scope.patientInfo.CallBackPhoneNumber = result.CallBackPhoneNumber;
            $scope.patientInfo.OfficePhoneNumber = result.OfficePhoneNumber;
            $scope.patientInfo.MobilePhoneNumber = result.MobilePhoneNumber;

            $scope.patientInfo.CallBackPhoneNumberUrl = result.CallBackPhoneNumberUrl;
            $scope.patientInfo.OfficePhoneNumberUrl = result.OfficePhoneNumberUrl;
            $scope.patientInfo.MobilePhoneNumberUrl = result.MobilePhoneNumberUrl;

            $scope.patientInfo.PhoneHomeConsent = result.PhoneHomeConsent;
            $scope.patientInfo.PhoneOfficeConsent = result.PhoneOfficeConsent;
            $scope.patientInfo.PhoneCellConsent = result.PhoneCellConsent;
        }

        function validateEmail(Control, returnmessage) {

            //var emailStr = Control.value;
            var reg1 = /(@.*@)|(\.\.)|(@\.)|(\.@)|(^\.)/; // not valid
            var reg2 = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/; // valid
            if (!reg1.test(Control) && reg2.test(Control)) {
                return true;
            } else {
                alert(returnmessage + ' is not a valid email address.');
                Control.focus();
                return false;
            }
        }
    }]);
}());
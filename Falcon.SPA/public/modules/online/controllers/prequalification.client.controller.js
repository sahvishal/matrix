(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.prequalificationController,
        ['$rootScope', '$scope', '$stateParams', '$state', '$modal', 'logger', '$window', CoreConfiguration.constants, OnlineConfiguration.services.eventService,
            OnlineConfiguration.services.preQualificationService, OnlineConfiguration.services.eventParameterService, "usSpinnerService", OnlineConfiguration.services.localStorageProgressBarService,
            function ($rootScope, $scope, $stateParams, $state, $modal, logger, $window, constants, eventService, preQualificationService, eventParameterService, usSpinnerService, localStorageProgressBarService) {

                $rootScope.title = $state.current.title;
                $scope.data = {};
                $scope.tempCart = {};
                $scope.isCollapsed = true;
                $scope.displayMessage = '';
                $rootScope.currentState = constants.ProgressBarSteps.PreQualifiedTest;
                $scope.ProgressBarStatus = constants.ProgressBarStatus;
                localStorageProgressBarService.UpdateLocation($stateParams.guid, $scope.ProgressBarStatus.Complete);
                localStorageProgressBarService.RiskAssessment($stateParams.guid, $scope.ProgressBarStatus.Started);
                $scope.genderDropDown = [{
                    value: 'Male',
                    text: 'Male'
                }, {
                    value: 'Female',
                    text: 'Female'
                }];

                $scope.isPosted = false;
                $scope.notQualified = false;
                $scope.BirthDate = new Date(moment().format("MM/DD/YYYY"));
                $scope.hideQuestions = true;

                $scope.MonthDropwdown = new Array();
                $scope.DaysDropwdown = new Array();
                $scope.YearDropwdown = new Array();

                $scope.isSubmitted = false;

                $scope.Month = {
                    value: 1,
                    text: 1
                };

                $scope.Year = {
                    value: 1950,
                    text: 1950
                };
                $scope.Day = {
                    value: 1,
                    text: 1
                };

                $scope.NumberOfMonth = function () {
                    for (var monthIndex = 1; monthIndex < 13; monthIndex++) {
                        var month = { value: monthIndex, text: monthIndex };
                        $scope.MonthDropwdown.push(month);
                    }
                };

                $scope.GetNumberOfDaysInMonth = function () {
                    var getNumberofDaysinMonth = new Date($scope.Year.value, $scope.Month.value, 0).getDate();
                    $scope.DaysDropwdown = new Array();
                    for (var dayIndex = 1; dayIndex <= getNumberofDaysinMonth; dayIndex++) {
                        var day = { value: dayIndex, text: dayIndex };
                        $scope.DaysDropwdown.push(day);
                    }
                };

                $scope.GetNumberYear = function () {
                    var currentYear = new Date().getFullYear();
                    for (var yearIndex = currentYear - 100; yearIndex <= currentYear; yearIndex++) {
                        var year = { value: yearIndex, text: yearIndex };
                        $scope.YearDropwdown.push(year);
                    }
                };
                $scope.ResetDayForInvalidDate = function () {

                    if ($scope.IsInvalidDate() == true) {
                        logger.showToasterError("Date of Birth entered is invalid. Please select again.");
                        $scope.Day = {
                            value: 1,
                            text: 1
                        };
                    }
                };

                $scope.IsInvalidDate = function () {
                    var isDateValid = false;
                    $.each($scope.DaysDropwdown, function (index, obj) {
                        if (obj.value == $scope.Day.value) {
                            isDateValid = true;
                        }
                    });
                    return isDateValid == false;
                };


                $scope.MonthChange = function () {

                    $scope.GetNumberOfDaysInMonth();
                    $scope.ResetDayForInvalidDate();
                };

                $scope.YearChange = function () {
                    $scope.GetNumberOfDaysInMonth();
                    $scope.ResetDayForInvalidDate();
                };


                $scope.questionsResult = {
                    Guid: '', Gender: '',
                    HighBloodPressure: '',
                    Smoker: '',
                    HeartDisease: '',
                    Diabetic: '',
                    ChestPain: '',
                    DiagnosedHeartProblem: '',
                    HighCholestrol: '',
                    OverWeight: '',
                    SkipPreQualificationQuestion: false,
                    AgreedWithPrequalificationQuestion: false
                };
                $scope.movedtoOtherPage = false;
                var disclaimerObject = {
                    Message: '', showSkipOption: false, hafPopupButtons: false, guid: $stateParams.guid, showAgain: true, GaMessage: '', onCloseCallBack: function (isAgreed) {
                        if ($scope.movedtoOtherPage == false) {
                            if (typeof (isAgreed) == 'undefined' || isAgreed == false) {
                                $scope.goForpackageSelection();
                            }
                        }
                    }
                };

                function init() {

                    $scope.GetNumberYear();
                    $scope.NumberOfMonth();
                    $scope.GetNumberOfDaysInMonth();

                    preQualificationService.GetPreQualificationAnswer($stateParams.guid).then(function (result) {
                        if (result != null) {
                            $scope.questionsResult = result;
                            $scope.data = result;
                            $scope.tempCart = result.RequestValidationModel.TempCart;
                            $scope.AskPreQualificationQuestion = result.AskPreQualificationQuestion;

                            if (typeof $scope.tempCart.Gender != 'undefined' && $scope.tempCart.Gender !== "" && $scope.tempCart.Gender !== null) {
                                $scope.gender = $scope.tempCart.Gender;
                            }

                            if (typeof $scope.tempCart.Dob != 'undefined' && $scope.tempCart.Dob != null) {
                                var birtDate = $scope.tempCart.Dob;
                                $scope.BirthDate = moment(birtDate, "YYYY-MM-DD").format("MM/DD/YYYY");
                                $scope.Month = {
                                    value: parseInt(moment(birtDate, "YYYY-MM-DD").format("M")),
                                    text: parseInt(moment(birtDate, "YYYY-MM-DD").format("M"))
                                };
                                $scope.GetNumberOfDaysInMonth();
                                $scope.Day = {
                                    value: parseInt(moment(birtDate, "YYYY-MM-DD").format("D")),
                                    text: parseInt(moment(birtDate, "YYYY-MM-DD").format("D"))
                                };
                                $scope.Year = {
                                    value: parseInt(moment(birtDate, "YYYY-MM-DD").format("YYYY")),
                                    text: parseInt(moment(birtDate, "YYYY-MM-DD").format("YYYY"))
                                };

                            }
                            if ($scope.AskPreQualificationQuestion) {
                                if ($scope.questionsResult.SkipPreQualificationQuestion || $scope.questionsResult.AgreedWithPrequalificationQuestion) {
                                    $scope.hideQuestions = true;
                                } else {
                                    $scope.hideQuestions = false;
                                }
                                if ((isSet($scope.questionsResult.HighBloodPressure)
                                        && isSet($scope.questionsResult.Smoker)
                                        && isSet($scope.questionsResult.HeartDisease)
                                        && isSet($scope.questionsResult.Diabetic)
                                        && isSet($scope.questionsResult.ChestPain)
                                        && isSet($scope.questionsResult.DiagnosedHeartProblem)
                                        && isSet($scope.questionsResult.HighCholestrol)
                                        && isSet($scope.questionsResult.OverWeight)
                                ) && $scope.questionsResult.AgreedWithPrequalificationQuestion == false) {
                                    $scope.goForpackageSelection();
                                }
                            } else {
                                $scope.hideQuestions = true;
                            }
                            if ($scope.AskPreQualificationQuestion)
                                gacNotifyPreQualification('Opened');
                        }
                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });
                }

                init();

                $scope.goForpackageSelection = function () {

                    $scope.isSubmitted = true;
                    $scope.isPosted = true;
                    if ($scope.gender == undefined || $scope.gender == null) {
                        logger.showToasterError('Please select gender.');
                        $scope.isPosted = false;
                        return;
                    }

                    $scope.BirthDate = moment($scope.Year.value + "-" + $scope.Month.value + "-" + $scope.Day.value, "YYYY-MM-DD").format("YYYY-MM-DD");
                    $scope.questionsResult.Gender = $scope.gender;
                    $scope.questionsResult.Dob = moment($scope.BirthDate).format("MM/DD/YYYY");
                    $scope.questionsResult.Guid = $stateParams.guid;
                    
                    if ($scope.AskPreQualificationQuestion==false) {
                        showDisclaimerModelAfterSavingAnswer();
                    } else if ($scope.questionsResult.AgreedWithPrequalificationQuestion) {
                        showDisclaimerModelAfterSavingAnswer();
                    } else if ((isSet($scope.questionsResult.HighBloodPressure)
                        && isSet($scope.questionsResult.Smoker)
                        && isSet($scope.questionsResult.HeartDisease)
                        && isSet($scope.questionsResult.Diabetic)
                        && isSet($scope.questionsResult.ChestPain)
                        && isSet($scope.questionsResult.DiagnosedHeartProblem)
                        && isSet($scope.questionsResult.HighCholestrol)
                        && isSet($scope.questionsResult.OverWeight)) && $scope.questionsResult.AgreedWithPrequalificationQuestion == false) {
                        showDisclaimerModelAfterSavingAnswer();
                    } else {
                        logger.showToasterError('Please answer all Questions.');
                        $scope.isPosted = false;
                    }

                    //if ($scope.questionsResult.AgreedWithPrequalificationQuestion === true || $scope.questionsResult.SkipPreQualificationQuestion === true || $scope.AskPreQualificationQuestion === false) {
                    //    if ($scope.BirthDate != "" && getAge($scope.BirthDate) < parseInt(ApplicationConfiguration.minimumAgeForScreening)) {
                    //        disclaimerObject.Message = 'Customers below 18 years of age are not allowed for screening. In case of any queries, please call us at ' + ApplicationConfiguration.phoneTollFree;
                    //        disclaimerObject.Title = "Minimum Age Alert";
                    //        disclaimerObject.RedirectToSiteUrl = true;
                    //        disclaimerObject.GaMessage = "Under Age";
                    //    }
                    //    showDisclaimerModelAfterSavingAnswer();
                    //} else {
                    //if ((isSet($scope.questionsResult.HighBloodPressure)
                    //&& isSet($scope.questionsResult.Smoker)
                    //&& isSet($scope.questionsResult.HeartDisease)
                    //&& isSet($scope.questionsResult.Diabetic)
                    //&& isSet($scope.questionsResult.ChestPain)
                    //&& isSet($scope.questionsResult.DiagnosedHeartProblem)
                    //&& isSet($scope.questionsResult.HighCholestrol)
                    //&& isSet($scope.questionsResult.OverWeight)
                    //) && $scope.questionsResult.AgreedWithPrequalificationQuestion == false) {

                    //        $scope.noOfYesAnsweredByCustomer = 0;
                    //        $scope.noOfNoAnsweredByCustomer = 0;
                    //        showDisclaimerMessage();
                    //        var a = ApplicationConfiguration.siteUrl;
                    //        if ($scope.questionsResult.ChestPain == answeryes) {
                    //            disclaimerObject.Message = 'Due to the symptoms you are experiencing, cardiac screenings may not be appropriate for you. We encourage you to contact your physician or 911 immediately. For more information please call us at 855-435-8378.';
                    //            disclaimerObject.Title = "Disclaimer";
                    //            disclaimerObject.RedirectToSiteUrl = true;
                    //            disclaimerObject.GaMessage = "Chest Pain";
                    //        } else if ($scope.questionsResult.DiagnosedHeartProblem == answeryes) {
                    //            disclaimerObject.Message = 'Since you are currently under the care of a Cardiologist, the cardiac screenings may not be appropriate for you. We encourage you to follow up with your Cardiologist or Primary Care Physician for further evaluation. For more information please call us at 855-435-8378.';
                    //            disclaimerObject.Title = "Contact us at 855-435-8378";
                    //            disclaimerObject.GaMessage = "Heart Problem";
                    //            disclaimerObject.RedirectToSiteUrl = true;
                    //        } else if ($scope.BirthDate != "" && getAge($scope.BirthDate) < parseInt(ApplicationConfiguration.minimumAgeForScreening)) {
                    //            disclaimerObject.Message = 'Customers below 18 years of age are not allowed for screening. In case of any queries, please call us at ' + ApplicationConfiguration.phoneTollFree;
                    //            disclaimerObject.Title = "Minimum Age Alert";
                    //            disclaimerObject.RedirectToSiteUrl = true;
                    //            disclaimerObject.GaMessage = "Under Age";
                    //        } else if ($scope.noOfYesAnsweredByCustomer >= 2) {
                    //            //disclaimerObject.Message = 'Based on your responses you exhibit risk which qualifies you to participate in our screenings.';
                    //            //disclaimerObject.Title = "Disclaimer";
                    //            //disclaimerObject.showSkipOption = true;
                    //            //disclaimerObject.showSkipLink = false;
                    //            //disclaimerObject.RedirectToSiteUrl = false;
                    //            //disclaimerObject.showAgain = false;
                    //            //disclaimerObject.GaMessage = "";
                    //            $scope.questionsResult.AgreedWithPrequalificationQuestion = true;

                    //        } else if ($scope.noOfNoAnsweredByCustomer >= 6) {
                    //            disclaimerObject.Message = 'Based on your responses, you are at low risk. However, if you would like to continue scheduling an appointment, please continue or you can';
                    //            disclaimerObject.Title = "Disclaimer";
                    //            disclaimerObject.showSkipLink = true;
                    //            disclaimerObject.showSkipOption = false;
                    //            disclaimerObject.RedirectToSiteUrl = false;
                    //            disclaimerObject.showAgain = false;
                    //            disclaimerObject.GaMessage = "Low Risk";
                    //        }

                    //        //$scope.isPosted = true;
                    //        showDisclaimerModelAfterSavingAnswer();

                    //    } else {
                    //        logger.showToasterError('Please answer all Questions.');
                    //        $scope.isPosted = false;
                    //    }
                    //}
                };

                var showDisclaimerModelAfterSavingAnswer = function () {
                    $scope.loader_next = true;
                    $scope.isPosted = true;

                    $scope.questionsResult.AgreedWithPrequalificationQuestion = true;

                    preQualificationService.SavePreQualificationAnswer($scope.questionsResult).then(function (result) {
                        $scope.loader_next = false;
                        $scope.isPosted = false;
                        if (!$scope.questionsResult.SkipPreQualificationQuestion) {
                            gacNotifyPreQualification('Submitted');
                        }

                        //if ((!$scope.questionsResult.AgreedWithPrequalificationQuestion && !$scope.questionsResult.SkipPreQualificationQuestion) && $scope.AskPreQualificationQuestion && disclaimerObject.Message != '')
                        //    showDisclaimerModal();
                        //else if ($scope.questionsResult.SkipPreQualificationQuestion) {
                        //    if (disclaimerObject.Message != '' && disclaimerObject.showAgain) {
                        //        showDisclaimerModal();
                        //    } else {
                        //        $state.go('Package', { guid: $stateParams.guid });
                        //    }
                        //} else if (($scope.questionsResult.AgreedWithPrequalificationQuestion || $scope.questionsResult.SkipPreQualificationQuestion) && disclaimerObject.Message == '')
                        //    $state.go('Package', { guid: $stateParams.guid });
                        //else if ($scope.questionsResult.AgreedWithPrequalificationQuestion && disclaimerObject.Message != '' && disclaimerObject.showAgain)
                        //    showDisclaimerModal();
                        //else
                        $state.go('Package', { guid: $stateParams.guid });

                    },
                        function () {
                            $scope.loader_next = false;
                            $scope.isPosted = false;
                        });
                };

                var modelPopupInstance = null;
                //var showDisclaimerModal = function () {
                //    if (typeof disclaimerObject.GaMessage != 'undefined' && disclaimerObject.GaMessage != null && disclaimerObject.GaMessage != '') {
                //        $window._gaq.push(['_trackEvent', 'Pre-Qualification Question Disclaimer', "Exit", $stateParams.guid + disclaimerObject.GaMessage]);
                //    }
                //    modelPopupInstance = $modal.open({
                //        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/online/views/prequalification/prequalification.disclaimer.client.view.html',
                //        controller: 'PrequalificationDisclaimerController',
                //        size: 'md',
                //        backdrop: 'static',
                //        keyboard: false,
                //        resolve: {
                //            data: function () {
                //                return { DisclaimerModal: disclaimerObject };
                //            }
                //        }
                //    });

                //};

                //$scope.skipQuestions = function () {
                //    $scope.isPosted = true;
                //    $scope.loader_skipQuestion = true;
                //    $scope.hideQuestions = true;
                //    $scope.BirthDate = moment($scope.Year.value + "-" + $scope.Month.value + "-" + $scope.Day.value, "YYYY-MM-DD").format("YYYY-MM-DD");
                //    $scope.questionsResult.Gender = $scope.gender;
                //    $scope.questionsResult.Dob = moment($scope.BirthDate).format("MM/DD/YYYY");
                //    $scope.questionsResult.Guid = $stateParams.guid;
                //    $scope.questionsResult.SkipPreQualificationQuestion = true;
                //    $scope.questionsResult.HighBloodPressure = null;
                //    $scope.questionsResult.Smoker = null;
                //    $scope.questionsResult.HeartDisease = null;
                //    $scope.questionsResult.Diabetic = null;
                //    $scope.questionsResult.ChestPain = null;
                //    $scope.questionsResult.DiagnosedHeartProblem = null;
                //    $scope.questionsResult.HighCholestrol = null;
                //    $scope.questionsResult.OverWeight = null;

                //    preQualificationService.UpdateUserPrefrenceSkip($stateParams.guid).then(function (e) {
                //        $scope.loader_skipQuestion = false;
                //        $scope.isPosted = false;
                //    }, function (e) {
                //        $scope.loader_skipQuestion = false;
                //        $scope.hideQuestions = false;
                //        $scope.isPosted = false;
                //    });

                //    gacNotifyPreQualification('Skipped');
                //};

                $scope.loader_back = false;
                $scope.loader_next = false;
                $scope.loader_skipQuestion = false;

                $scope.searchEvent = function () {
                    $scope.loader_back = true;
                    eventParameterService.updateWithTempcart($scope.tempCart);

                    $state.go('Event', { guid: $stateParams.guid });
                };

                //function getAge(dob) {
                //    var today = new Date();
                //    var birthDate = new Date(dob);
                //    var age = today.getFullYear() - birthDate.getFullYear();
                //    var m = today.getMonth() - birthDate.getMonth();
                //    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                //        age--;
                //    }
                //    return age;
                //}

                function isSet(o) {
                    return (o == '178' || o == '179');
                }


                //  var maximumAge = 45;


                //$scope.noOfYesAnsweredByCustomer = 0;
                //$scope.noOfNoAnsweredByCustomer = 0;

                //var answeryes = '178';
                //var answerno = '179';

                //function showDisclaimerMessage() {

                //    var qResult = $scope.questionsResult;
                //    //Are you age 45 or older
                //    if ($scope.BirthDate != "" && getAge($scope.BirthDate) < parseInt(maximumAge)) {
                //        $scope.noOfNoAnsweredByCustomer = $scope.noOfNoAnsweredByCustomer + 1;
                //    } else if ($scope.BirthDate != "" && getAge($scope.BirthDate) >= parseInt(maximumAge)) {
                //        $scope.noOfYesAnsweredByCustomer = $scope.noOfYesAnsweredByCustomer + 1;
                //    }

                //    //have you ever been told you have high blood pressure
                //    if (qResult.HighBloodPressure == answerno) {
                //        $scope.noOfNoAnsweredByCustomer = $scope.noOfNoAnsweredByCustomer + 1;
                //    } else if (qResult.HighBloodPressure == answeryes) {
                //        $scope.noOfYesAnsweredByCustomer = $scope.noOfYesAnsweredByCustomer + 1;
                //    }

                //    //have you ever been told you have elevated cholesterol
                //    if (qResult.HighCholestrol == answerno) {
                //        $scope.noOfNoAnsweredByCustomer = $scope.noOfNoAnsweredByCustomer + 1;
                //    } else if (qResult.HighCholestrol == answeryes) {
                //        $scope.noOfYesAnsweredByCustomer = $scope.noOfYesAnsweredByCustomer + 1;
                //    }

                //    //Do you currenty smoke or have you smoked in the past
                //    if (qResult.Smoker == answerno) {
                //        $scope.noOfNoAnsweredByCustomer = $scope.noOfNoAnsweredByCustomer + 1;
                //    } else if (qResult.Smoker == answeryes) {
                //        $scope.noOfYesAnsweredByCustomer = $scope.noOfYesAnsweredByCustomer + 1;
                //    }

                //    //Do you have a family history of any heart realted disease or iliness
                //    if (qResult.HeartDisease == answerno) {
                //        $scope.noOfNoAnsweredByCustomer = $scope.noOfNoAnsweredByCustomer + 1;
                //    } else if (qResult.HeartDisease == answeryes) {
                //        $scope.noOfYesAnsweredByCustomer = $scope.noOfYesAnsweredByCustomer + 1;
                //    }

                //    //Diabetic
                //    if (qResult.Diabetic == answerno) {
                //        $scope.noOfNoAnsweredByCustomer = $scope.noOfNoAnsweredByCustomer + 1;
                //    } else if (qResult.Diabetic == answeryes) {
                //        $scope.noOfYesAnsweredByCustomer = $scope.noOfYesAnsweredByCustomer + 1;
                //    }

                //    //OverWeight
                //    if (qResult.OverWeight == answerno) {
                //        $scope.noOfNoAnsweredByCustomer = $scope.noOfNoAnsweredByCustomer + 1;
                //    } else if (qResult.OverWeight == answeryes) {
                //        $scope.noOfYesAnsweredByCustomer = $scope.noOfYesAnsweredByCustomer + 1;
                //    }
                //}

                $scope.$on('$destroy', function () {
                    $scope.movedtoOtherPage = true;
                    if (modelPopupInstance != null) {
                        modelPopupInstance.close();
                    }
                });


                function gacNotifyPreQualification(action) {
                    $window._gaq.push(['_trackEvent', 'Pre-Qualification Question', action, $stateParams.guid]);
                }

            }]);
}());


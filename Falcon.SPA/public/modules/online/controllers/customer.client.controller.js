(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.customerController,
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', '$timeout', CoreConfiguration.constants,
            OnlineConfiguration.services.customerService, "usSpinnerService", OnlineConfiguration.services.localStorageProgressBarService, '$modal',
            function ($rootScope, $scope, $stateParams, $state, logger, $timeout, constants, customerService, usSpinnerService, localStorageProgressBarService, $modal) {

                $rootScope.title = $state.current.title;
                $scope.guid = $stateParams.guid;
                $scope.data = {};
                $scope.data.tempCart = {};
                $scope.MarketingSourcesList = null;
                $scope.isCollapsed = true;
                $scope.ReceiveSms = false;
                $scope.selectedTab = 1;
                $scope.showTab2 = true;
                $scope.isPosted = false;

                $scope.loader_back = false;
                $scope.loader_next = false;
                $scope.loader_login = false;
                $scope.IsCorporateEvent = false;
                $rootScope.currentState = constants.ProgressBarSteps.PersonalInformation;
                $scope.EventTypeEnum = constants.EventType;
                $scope.ProgressBarStatus = constants.ProgressBarStatus;
                localStorageProgressBarService.InfoPayment($stateParams.guid, $scope.ProgressBarStatus.Started);
                localStorageProgressBarService.Appointment($stateParams.guid, $scope.ProgressBarStatus.Complete);
                //**to be moved in directive**/
                $scope.BirthDate = new Date(moment().format("MM/DD/YYYY"));

                //*****To be moved in directive*****//
                $scope.MonthDropwdown = new Array();
                $scope.DaysDropwdown = new Array();
                $scope.YearDropwdown = new Array();
                $scope.FeetDropwdown = new Array();
                $scope.InchDropwdown = new Array();
                $scope.IsAdditionalTestAvailable = true;
                $scope.shippingProductEditModel = null;


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

                /**************/

                $scope.genderDropDown = [{
                    value: 185,
                    text: 'Male'
                }, {
                    value: 186,
                    text: 'Female'
                }];

                $scope.loginDetail = { Guid: $scope.guid, UserName: null, Password: '' };
                $scope.prospectCustomer = {
                    Id: 0,
                    FirstName: "",
                    LastName: "",
                    Gender: "186",
                    Address: { StreetAddressLine1: "Online Address", StreetAddressLine2: "", City: "Winter Springs", StateId: 20, CountryId: 1, ZipCode: "32708" },
                    CallBackPhoneNumber: { AreaCode: "", Number: "" },
                    BirthDate: "1/1/1950",
                    Email: { Address: "", DomainName: "" },
                    MarketingSource: "",
                    Source: constants.ProspectCustomer.Source.Online,
                    Tag: constants.ProspectCustomer.Tag.OnlineSignup
                };


                function init() {
                    $scope.GetNumberYear();
                    $scope.NumberOfMonth();
                    $scope.GetNumberOfDaysInMonth();

                    $scope.setShippingDetail = function (tempCart) {
                        var productId = [];
                        var selectedOptionId = -1;

                        if (tempCart != null && tempCart.ProductId != null && tempCart.ProductId > 0) {
                            productId.push(tempCart.ProductId);
                        }
                        if (tempCart != null && tempCart.ShippingId != null && tempCart.ShippingId >= 0) {
                            selectedOptionId = tempCart.ShippingId;
                        }

                        $scope.shippingProductEditModel = {
                            SelectedProductIds: productId,
                            SelectedShippingOptionId: selectedOptionId
                        };
                    };



                    customerService.GetCustomerInfo($stateParams.guid).then(function (result) {
                        $scope.data = result;
                        $scope.data.tempCart = result.RequestValidationModel.TempCart;
                        $scope.SchedulingCustomer = result.CustomerEditModel;
                        $scope.IsCorporateEvent = result.RequestValidationModel.IsCorporateEvent;
                        $scope.IsAdditionalTestAvailable = result.IsAdditionalTestAvailable;

                        if ($scope.SchedulingCustomer.ConfirmationToEnablTexting == undefined || $scope.SchedulingCustomer.ConfirmationToEnablTexting == null || $scope.SchedulingCustomer.ConfirmationToEnablTexting === "")
                            $scope.SchedulingCustomer.ConfirmationToEnablTexting = false;

                        if ($scope.SchedulingCustomer.ConfirmationToEnableVoiceMail == undefined || $scope.SchedulingCustomer.ConfirmationToEnableVoiceMail == null || $scope.SchedulingCustomer.ConfirmationToEnableVoiceMail === "")
                            $scope.SchedulingCustomer.ConfirmationToEnableVoiceMail = false;

                        if ($scope.data.tempCart.CustomerId > 0) {
                            $scope.showTab2 = false;
                            $scope.ReturningCustomer = true;
                        }


                        if (typeof $scope.SchedulingCustomer.DateofBirth != 'undefined' && $scope.SchedulingCustomer.DateofBirth != null) {
                            var birtDate = $scope.SchedulingCustomer.DateofBirth;
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
                        $scope.setShippingDetail($scope.data.tempCart);

                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });
                }

                init();

                $scope.goToPreviousStep = function () {

                    $scope.isPosted = true;
                    $scope.loader_back = true;

                    $state.go('Appointment', { guid: $scope.guid });
                };

                $scope.goToNextStep = function () {

                    if ($scope.selectedTab == 1) {
                        $timeout(function () {
                            angular.element('#submitform1').trigger('click');
                        });
                    }
                    else if ($scope.selectedTab == 2) {
                        logger.showToasterError('Please login.');
                    }

                };
                var modelPopupInstance = null;
                $scope.callbackFunction = function (shippingModel) {
                    
                    $scope.shippingProductEditModel = shippingModel;
                    modelPopupInstance.close();
                    $scope.SubmitCustomerData();
                };

                $scope.setTab = function (id) {
                    $scope.selectedTab = id;
                };

                $scope.SubmitCustomerData = function() {
                    $scope.isPosted = true;
                    $scope.loader_next = true;

                    $scope.SchedulingCustomer.Weight = null;
                    $scope.SchedulingCustomer.Height = null;

                    if (typeof($scope.SchedulingCustomerWeight) != 'undefined' && $scope.SchedulingCustomerWeight != '' && $scope.SchedulingCustomerWeight != null) {
                        $scope.SchedulingCustomer.Weight = { Pounds: $scope.SchedulingCustomerWeight };
                    }
                    if (typeof($scope.SchedulingCustomerFeet) != 'undefined' && $scope.SchedulingCustomerFeet != '' && $scope.SchedulingCustomerFeet != null) {
                        $scope.SchedulingCustomerHeight = $scope.SchedulingCustomerFeet * 12;
                        if (typeof($scope.SchedulingCustomerInches) != 'undefined' && $scope.SchedulingCustomerInches != '' && $scope.SchedulingCustomerInches != null) {
                            $scope.SchedulingCustomerHeight = $scope.SchedulingCustomerHeight + $scope.SchedulingCustomerInches;
                        }
                        $scope.SchedulingCustomer.Height = { TotalInches: $scope.SchedulingCustomerHeight };
                    }

                    $scope.SchedulingCustomer.FullName.FirstName = $.trim($scope.SchedulingCustomer.FullName.FirstName);
                    $scope.SchedulingCustomer.FullName.MiddleName = $.trim($scope.SchedulingCustomer.FullName.MiddleName);
                    $scope.SchedulingCustomer.FullName.LastName = $.trim($scope.SchedulingCustomer.FullName.LastName);
                    $scope.SchedulingCustomer.Email = $scope.SchedulingCustomer.Email == '' ? null : $scope.SchedulingCustomer.Email;
                    $scope.SchedulingCustomer.IsRegisteringForCorporateEvent = $scope.IsCorporateEvent;

                    if ($scope.IsCorporateEvent == false) {
                        $scope.SchedulingCustomer.UserName = $scope.SchedulingCustomer.Email;
                    }

                    customerService.registerCustomer($scope.guid, $scope.SchedulingCustomer).then(function(data) {
                        $scope.isPosted = false;
                        $scope.loader_next = false;
                        $state.go('Payment', { guid: $scope.guid });
                    }, function() {
                        $scope.isPosted = false;
                        $scope.loader_next = false;
                    });
                };

                $scope.registerCustomer = function (form) {
                    form.submitted = true;
                    if (form.$valid) {
                        if ($scope.IsCorporateEvent && $scope.SchedulingCustomer.Id == 0 && $scope.isUserNameAvailable == false) {
                            logger.showToasterError('The username entered is not available.');
                            return;
                        }

                        modelPopupInstance = $modal.open({
                            templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/shared/views/shipping.client.view.html',
                            controller: 'ShippingController',
                            size: 'lg',
                            resolve: {
                                client: function () {
                                    return $scope.callbackFunction;
                                }
                            }
                        });

                    } else {
                        $("span.validation-message").val('').hide();
                    }
                };


                $scope.loginCustomer = function (form) {
                    form.submitted = true;
                    if (form.$valid) {
                        $scope.isPosted = true;
                        $scope.loader_login = true;
                        customerService.ValidateUser($scope.loginDetail, $scope.guid).then(function (result) {
                            if (result.Message == '') {
                                var customerId = result.CustomerId;
                                customerService.UpdateCartwithReturningCustomer($scope.guid, customerId).then(function (result1) {
                                    $scope.SchedulingCustomer = result1;
                                    if (customerId > 0) {
                                        $scope.showTab2 = false;
                                        $scope.selectedTab = 1;
                                        $scope.ReturningCustomer = true;
                                        $scope.isPosted = false;
                                        $scope.loader_login = false;
                                    }
                                });
                            } else {
                                $scope.isPosted = false;
                                $scope.loader_login = false;
                                logger.showToasterError(result.Message);
                            }
                        }, function () {
                            $scope.isPosted = false;
                            $scope.loader_login = false;
                        });
                    }
                };

                var isNotNullOrUndefined = function (property) {
                    if (typeof (property) != 'undefined' && property != null) {
                        return true;
                    }
                    return false;
                };

                $scope.saveProspectCustomer = function () {

                    if (isNotNullOrUndefined($scope.SchedulingCustomer.FullName) && isNotNullOrUndefined($scope.SchedulingCustomer.FullName.FirstName) && $scope.SchedulingCustomer.FullName.FirstName.length > 0 && isNotNullOrUndefined($scope.SchedulingCustomer.FullName.LastName) && $scope.SchedulingCustomer.FullName.LastName.length > 0 && ($scope.SchedulingCustomer.Email != null || $scope.SchedulingCustomer.HomeNumber != null)) {

                        $scope.prospectCustomer.FirstName = $scope.SchedulingCustomer.FullName.FirstName;
                        $scope.prospectCustomer.LastName = $scope.SchedulingCustomer.FullName.LastName;
                        $scope.prospectCustomer.Gender = $scope.SchedulingCustomer.Gender;

                        $scope.prospectCustomer.BirthDate = moment($scope.Year.value + "-" + $scope.Month.value + "-" + $scope.Day.value, "YYYY-MM-DD").format("YYYY-MM-DD");

                        $scope.prospectCustomer.MarketingSource = $scope.SchedulingCustomer.MarketingSource;

                        var phoneNumber = $scope.SchedulingCustomer.HomeNumber;
                        if (phoneNumber != '' && phoneNumber != undefined) {
                            phoneNumber = phoneNumber.replace("(", "");
                            phoneNumber = phoneNumber.replace(")", "");
                            phoneNumber = phoneNumber.replace(/_/gi, "");
                            phoneNumber = phoneNumber.replace(/-/gi, "");
                            $scope.prospectCustomer.CallBackPhoneNumber = { AreaCode: "", Number: "" };
                            $scope.prospectCustomer.CallBackPhoneNumber.AreaCode = phoneNumber.substring(0, 3);
                            $scope.prospectCustomer.CallBackPhoneNumber.Number = phoneNumber.substring(3, phoneNumber.length).trim();
                        } else {
                            $scope.prospectCustomer.CallBackPhoneNumber = null;
                        }

                        var email = $scope.SchedulingCustomer.Email;
                        if (email != '' && email != undefined) {
                            var emailSplit = email.split('@');
                            $scope.prospectCustomer.Email.Address = emailSplit[0];
                            $scope.prospectCustomer.Email.DomainName = emailSplit[1];
                        }
                        customerService.SaveProspectCustomerAndUpdateCart($scope.guid, $scope.prospectCustomer).then(function (data) {
                        });
                    }
                };
                $scope.loader_availablity = false;
                $scope.isUserNameAvailable = false;
                $scope.checkUserNameAvailability = function () {
                    if ($scope.SchedulingCustomer.UserName.trim() != '' && $scope.SchedulingCustomer.UserName.trim().length > 5) {

                        $scope.loader_availablity = true;
                        customerService.checkUserNameAvailability($scope.SchedulingCustomer.UserName).then(function (result) {
                            $scope.isUserNameAvailable = result;
                            $scope.loader_availablity = false;
                        }, function () {
                            $scope.loader_availablity = false;
                        });
                    }
                };

                function getSelectedShipingId() {
                    var selectedShippingOptionId = -1;

                    return selectedShippingOptionId;
                }

                $scope.$on('$destroy', function () {
                    if (modelPopupInstance != null) {
                        modelPopupInstance.close();
                    }
                });
            }]);
}());
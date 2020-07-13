(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.paymentController,
        ['$rootScope', '$scope', '$stateParams', '$state', '$timeout', 'logger', '$modal',
            CoreConfiguration.constants, OnlineConfiguration.services.paymentService, "usSpinnerService", '$localStorage', OnlineConfiguration.services.localStorageProgressBarService, OnlineConfiguration.services.orderService, 
            function ($rootScope, $scope, $stateParams, $state, $timeout, logger, $modal, constants, paymentService, usSpinnerService, $localStorage, localStorageProgressBarService, orderService) {

                $rootScope.title = $state.current.title;
                $scope.isCollapsed = true;
                $scope.guid = $stateParams.guid;
                $scope.data = {};
                $scope.data.tempCart = {};
                $scope.displayMessage = '';
                $scope.selectedTabId = 1;
                $scope.ExpiryDateYear = [];
                $scope.giftCertificateCode = '';
                $scope.giftCertificateApplyAmount = 0.0;
                $scope.isPosted = false;
                $scope.showApplyGiftCeritficate = true;
                $rootScope.currentState = constants.ProgressBarSteps.Payment;
                $scope.loader_back = false;
                $scope.loader_Payment = false;
                $scope.loader_ApplySource = false;
                $scope.loader_ApplyGC = false;              
                $scope.ProgressBarStatus = constants.ProgressBarStatus;
                $scope.IsCardTypeNumberProvided = false;
                localStorageProgressBarService.Payment($stateParams.guid, $scope.ProgressBarStatus.Started);
                $scope.ChargeCard = {
                    "TypeId": 0, "NameOnCard": null, "Number": '', "CVV": null, "CardIssuer": null, "IsDebit": false,
                    get ExpirationDate() {
                        return this.Month.toString() + '/01/' + this.Year.toString();
                    }, "DataRecorderMetaData": null, "Id": 0, "Month": null, "Year": ''
                };
                $scope.eCheck = {
                    "PayableTo": ApplicationConfiguration.companyName, "CheckNumber": null,
                    get CheckDate() {
                        return this.Month.toString() + '/' + this.Day.toString() + '/' + this.Year.toString();
                    }, "RoutingNumber": null, "BankName": null, "AccountNumber": null, "Memo": null, "AcountHolderName": null, "IsElectronicCheck": true,
                    "PaymentType": { "PersistenceLayerId": constants.PaymentType.Check.Id, "Name": constants.PaymentType.Check.Name }, "DataRecorderMetaData": null, "Amount": 0, "PaymentId": 0, "Id": 0, "Month": null, "Year": '', "Day": null
                };
                $scope.ExistingBillingAddress = { "Id": 0, "StreetAddressLine1": null, "StreetAddressLine2": null, "City": null, "StateId": 0, "CountryId": 1, "ZipCode": null };
                $scope.ExistingShippingAddress = { "Id": 0, "StreetAddressLine1": null, "StreetAddressLine2": null, "City": null, "StateId": 0, "CountryId": 1, "ZipCode": null };

                $scope.giftPayment = null;
                $scope.AppliedSourceCode = '';
                $scope.showPaymentPanel = true;
                var chargeCardType =
                {
                    Visa: 2,
                    MasterCard: 1,
                    AmericanExpress: 4,
                    Discover: 3
                };
                $scope.cardTypeId = 0;

                function init() {
                    setExpiryDateYear();
                    paymentService.GetPaymentInfo($stateParams.guid).then(function (result) {
                        $scope.data = result;
                        $scope.data.tempCart = result.RequestValidationModel.TempCart;

                        $scope.OnlineSchedulingCustomerInfoEditModel = result;
                        $scope.states = result.StateList;
                        $scope.SchedulingCustomer = result.CustomerEditModel;
                        $scope.MarketingSourceList = result.MarketingSourcesList;
                        $scope.CustomerOrder = result.EventCustomerOrderSummaryModel;
                        $scope.PaymentEditModel = result.PaymentEditModel;

                        $scope.SourceCodeApplyEditModel = result.SourceCodeApplyEditModel;
                        if (typeof ($scope.SourceCodeApplyEditModel) !== 'undefined' && $scope.SourceCodeApplyEditModel !== null) {
                            $scope.AppliedSourceCode = $scope.SourceCodeApplyEditModel.SourceCode;
                        }
                        if (typeof ($scope.CustomerOrder) !== 'undefined' && $scope.CustomerOrder !== null) {
                            if ($scope.CustomerOrder.AmountDue != null && $scope.CustomerOrder.AmountDue <= 0) {
                                $scope.showApplyGiftCeritficate = false;
                            }
                        }
                        isPaymentRequired();

                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });
                }

                init();

                function setExpiryDateYear() {
                    var index = 0;
                    var currentYearExpDate = Number((new Date()).getFullYear());
                    while (index <= 15) {
                        var yearToSet = currentYearExpDate + index;
                        $scope.ExpiryDateYear.push({ value: yearToSet, text: yearToSet.toString() });
                        index = index + 1;
                    }
                }

                $scope.setSelectedTab = function (id) {
                    $scope.selectedTabId = id;
                };

                $scope.setCardType = function () {
                    $scope.IsCardTypeNumberProvided = true;
                    var cardNumber = $scope.ChargeCard.Number;
                    $scope.cardTypeId = 0;
                    if (cardNumber != null && cardNumber.length > 0) {
                        if (cardNumber.substring(0, 1) == 4)
                            $scope.cardTypeId = chargeCardType.Visa;
                        else if (cardNumber.substring(0, 2) >= 51 && cardNumber.substring(0, 2) <= 55)
                            $scope.cardTypeId = chargeCardType.MasterCard;
                        else if (cardNumber.substring(0, 2) == 34 || cardNumber.substring(0, 2) == 37) {
                            $scope.cardTypeId = chargeCardType.AmericanExpress;
                            $scope.IsPayedByAmericanExpress = true;
                        } else if (cardNumber.substring(0, 2) == 60 || cardNumber.substring(0, 2) == 65)
                            $scope.cardTypeId = chargeCardType.Discover;
                    }
                    
                    if ($scope.showPaymentPanel && $scope.IsCardTypeNumberProvided && $scope.cardTypeId == 0) {
                        logger.showToasterError('Please provide a valid card number');
                    }
                };

                $scope.goToPreviousStep = function () {
                    $scope.isPosted = true;
                    $scope.loader_back = true;

                    $state.go('Customer', { guid: $scope.guid });
                };

                $scope.payByCard = function (form) {
                    form.submitted = true;
                    if (form.$valid == false) {
                        return;
                    }
                    
                    if ($scope.showPaymentPanel && $scope.IsCardTypeNumberProvided && $scope.cardTypeId == 0) {
                        logger.showToasterError('Please provide a valid card number');
                        return;
                    }
                    
                    if (checkForTermAcceptance())
                        return;

                    $scope.AdjustGiftCertificate();
                    var payIndex = 0;
                    var amountToPay = $scope.CustomerOrder.TotalPrice - $scope.CustomerOrder.DiscountAmount;
                    var paymentByGift = 0, paymentbycard = 0;

                    if ($scope.giftPayment != null && amountToPay > 0) {
                        $scope.PaymentEditModel.Payments[payIndex] = $scope.giftPayment;

                        amountToPay = amountToPay - $scope.giftPayment.Amount;
                        paymentByGift = $scope.giftPayment.Amount;

                        payIndex = payIndex + 1;
                    }

                    if ($scope.selectedTabId == 1 && amountToPay > 0) {

                        var cardPayment = {
                            "PaymentType": constants.PaymentType.CreditCard.Id,
                            "Amount": 0.00,
                            "ChargeCard":
                            {
                                "ChargeCard": null,
                                "ChargeCardPayment": {
                                    "ChargeCardId": 0,
                                    "ProcessorResponse": null,
                                    "ChargeCardPaymentStatus": 0,
                                    "PaymentType": { "PersistenceLayerId": constants.PaymentType.CreditCard.Id, "Name": constants.PaymentType.CreditCard.Name },
                                    "DataRecorderMetaData": null,
                                    "Amount": 0.0,
                                    "PaymentId": 0,
                                    "Id": 0
                                }
                            },
                            "Check": null,
                            "ECheck": null,
                            "GiftCertificate": null,
                            "Insurance": null,
                            "BillingAddress": null,
                            "IsProcessed": false,
                            "FeedbackMessage": null
                        };

                        $scope.ChargeCard.TypeId = $scope.cardTypeId;
                        $scope.PaymentEditModel.Payments[payIndex] = cardPayment;
                        $scope.PaymentEditModel.Payments[payIndex].ChargeCard.ChargeCard = $scope.ChargeCard;
                        $scope.PaymentEditModel.Payments[payIndex].ChargeCard.ChargeCardPayment.Amount = amountToPay;
                        //$scope.PaymentEditModel.Payments[payIndex].PaymentType = constants.PaymentType.CreditCard.Id;
                        $scope.PaymentEditModel.Payments[payIndex].BillingAddress = $scope.PaymentEditModel.ExistingBillingAddress;
                        $scope.PaymentEditModel.ExistingBillingAddress.CountryId = 1;
                        $scope.PaymentEditModel.Payments[payIndex].Amount = amountToPay;
                        paymentbycard = $scope.PaymentEditModel.Payments[payIndex].Amount;
                    }

                    $scope.PaymentEditModel.Amount = paymentByGift + paymentbycard;
                    if ($scope.PaymentEditModel.Amount == 0) {
                        $scope.PaymentEditModel.Payments = null;
                    }
                    makePayment();

                };

                $scope.payByecheck = function (form) {
                    form.submitted = true;
                    if (form.$valid == false) {
                        return;
                    }
                    if (checkForTermAcceptance())
                        return;
                    $scope.AdjustGiftCertificate();
                    var payIndex = 0;
                    var amountToPay = $scope.CustomerOrder.TotalPrice - $scope.CustomerOrder.DiscountAmount;
                    var paymentByGift = 0, paymentbyecheck = 0;

                    if ($scope.giftPayment != null && amountToPay > 0) {

                        $scope.PaymentEditModel.Payments[payIndex] = $scope.giftPayment;

                        amountToPay = amountToPay - $scope.giftPayment.Amount;

                        paymentByGift = $scope.giftPayment.Amount;

                        payIndex = payIndex + 1;
                    }

                    if ($scope.selectedTabId == 2 && amountToPay > 0) {

                        var echeckPayment = {
                            "PaymentType": constants.PaymentType.eCheck.Id,
                            "Amount": 0.00,
                            "ChargeCard": null,
                            "Check": null,
                            "ECheck": null,
                            "GiftCertificate": null,
                            "Insurance": null,
                            "BillingAddress": null,
                            "IsProcessed": false,
                            "FeedbackMessage": null
                        };
                        var echeck = {
                            "ECheck": null,
                            "ECheckPayment": {
                                "ECheck": null,
                                "ECheckId": 0,
                                "ProcessorResponse": null,
                                "ECheckPaymentStatus": 0,
                                "PaymentType": {
                                    "PersistenceLayerId": constants.PaymentType.eCheck.Id,
                                    "Name": constants.PaymentType.eCheck.Name
                                },
                                "DataRecorderMetaData": null,
                                "Amount": 0,
                                "PaymentId": 0,
                                "Id": 0
                            }
                        };

                        $scope.eCheck.Amount = amountToPay;
                        echeck.ECheck = $scope.eCheck;
                        echeck.ECheckPayment.PaymentType = constants.PaymentType.eCheck.Id;
                        echeck.ECheckPayment.Amount = amountToPay;
                        echeckPayment.ECheck = echeck;
                        $scope.PaymentEditModel.Payments[payIndex] = echeckPayment;
                        //$scope.PaymentEditModel.Payments[payIndex].PaymentType = constants.PaymentType.eCheck.Id;
                        $scope.PaymentEditModel.Payments[payIndex].BillingAddress = $scope.PaymentEditModel.ExistingBillingAddress;
                        $scope.PaymentEditModel.ExistingBillingAddress.CountryId = 1;
                        $scope.PaymentEditModel.Payments[payIndex].Amount = amountToPay;
                        paymentbyecheck = $scope.PaymentEditModel.Payments[payIndex].Amount;
                    }

                    $scope.PaymentEditModel.Amount = paymentByGift + paymentbyecheck;
                    if ($scope.PaymentEditModel.Amount == 0) {
                        $scope.PaymentEditModel.Payments = null;
                    }
                    makePayment();
                };

                function makePayment() {

                    if ($scope.PaymentEditModel.ShippingAddressSameAsBillingAddress) {
                        $scope.PaymentEditModel.ExistingShippingAddress = $scope.PaymentEditModel.ExistingBillingAddress;
                    } else {
                        $scope.PaymentEditModel.ExistingShippingAddress.CountryId = 1; //to do : find why this property is lost
                    }

                    $scope.OnlineSchedulingCustomerInfoEditModel = $scope.OnlineSchedulingCustomerInfoEditModel;

                    $scope.OnlineSchedulingCustomerInfoEditModel.CustomerEditModel = $scope.SchedulingCustomer;
                    $scope.OnlineSchedulingCustomerInfoEditModel.MarketingSourceList = $scope.MarketingSourcesList;
                    $scope.OnlineSchedulingCustomerInfoEditModel.EventCustomerOrderSummaryModel = $scope.CustomerOrder;
                    $scope.OnlineSchedulingCustomerInfoEditModel.PaymentEditModel = $scope.PaymentEditModel;
                    $scope.OnlineSchedulingCustomerInfoEditModel.SourceCodeApplyEditModel = $scope.SourceCodeApplyEditModel;
                    //$scope.OnlineSchedulingCustomerInfoEditModel.StateList = $scope.states;
                    $scope.isPosted = true;
                    $scope.loader_Payment = true;
                    paymentService.SavePaymentInfo($scope.OnlineSchedulingCustomerInfoEditModel).then(function (result) {
                        $scope.isPosted = false;
                        $scope.loader_Payment = false;
                        if (result.PaymentEditModel.IsTemporaryBookedSlotExpired) {
                            redirectToAppointment();
                        } else {
                            $localStorage.$reset();
                            localStorageProgressBarService.InfoPayment($stateParams.guid, $scope.ProgressBarStatus.Complete);
                            $state.go("ThankYou", { guid: $scope.guid });
                        }
                    }, function () {
                        $scope.isPosted = false;
                        $scope.loader_Payment = false;
                    });
                }
                var modelPopupInstance = null;
                function redirectToAppointment() {
                    var modalPopupObject = {
                        showTitle: false,
                        Title: '',
                        showCancelButton: false,
                        cancelButtonText: '',
                        showOkButton: true,
                        OKButtonText: 'OK',
                        Message: 'The appointment time selected by you is no longer temporarily booked for you. Please go back to appointment page to choose the time slot.',
                        CallBackOnOkButton: function () { $state.go("Appointment", { guid: $scope.guid }); },
                        CallBackOnCancelButton: null,
                        CallBackOnEscape: function () { $state.go("Appointment", { guid: $scope.guid }); }
                    };

                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/shared/views/model.popup.client.view.html',
                        controller: 'modalPopupController',
                        size: 'md',
                        backdrop: 'static',
                        resolve: {
                            data: function () {
                                return modalPopupObject;
                            }
                        }
                    });
                }
                 
                
                var checkForTermAcceptance = function () {
                    if ($scope.OnlineSchedulingCustomerInfoEditModel.AcceptTerms == false) {
                        logger.showToasterError('Please read and accept our terms and conditions before moving ahead.');
                        return !$scope.OnlineSchedulingCustomerInfoEditModel.AcceptTerms;
                    }
                    return false;
                };

                $scope.goToNextStep = function () {

                    if ($scope.selectedTabId == 1) {
                        $timeout(function () {
                            angular.element('#submitform1').trigger('click');
                        });
                    } else {
                        $timeout(function () {
                            angular.element('#submitform2').trigger('click');
                        });
                    }
                };

                $scope.AdjustGiftCertificate = function () {
                    var amountTopay = $scope.CustomerOrder.TotalPrice - $scope.CustomerOrder.DiscountAmount;

                    if ($scope.giftPayment != null) {
                        var gc = $scope.giftPayment.GiftCertificate.GiftCertificate;

                        //$scope.giftCertificateApplyAmount = gc.BalanceAmount;

                        if (amountTopay > 0) {
                            var payBygift = 0;
                            if (amountTopay >= gc.BalanceAmount) {
                                payBygift = gc.BalanceAmount;
                            } else {
                                payBygift = amountTopay;
                            }

                            $scope.giftPayment.GiftCertificate.Amount = payBygift;
                            $scope.giftPayment.GiftCertificate.GiftCertificatePayment.Amount = payBygift;
                            $scope.giftPayment.Amount = payBygift;

                        } else {
                            $scope.giftPayment.GiftCertificate.GiftCertificatePayment.Amount = 0;
                            $scope.giftPayment.Amount = 0;
                        }
                    }
                }

                $scope.applyGiftCertificate = function () {
                    if ($scope.giftCertificateCode != '' && $scope.giftCertificateCode != $scope.AppliedgiftCertificateCode) {
                        $scope.giftPayment = null;
                        $scope.giftCertificateApplyAmount = 0;
                        $scope.isPosted = true;
                        $scope.loader_ApplyGc = true;
                        paymentService.applyGiftCertificate($scope.giftCertificateCode).then(function (result) {
                            if (result.Result == true) {
                                $scope.giftCertificateApplyAmount = result.GiftCertificate.BalanceAmount;

                                var payBygift = 0;
                                var amountTopay = $scope.CustomerOrder.TotalPrice - $scope.CustomerOrder.DiscountAmount;

                                if (amountTopay > result.GiftCertificate.BalanceAmount) {
                                    payBygift = result.GiftCertificate.BalanceAmount;
                                } else {
                                    payBygift = amountTopay;
                                }

                                $scope.giftPayment = {
                                    "PaymentType": constants.PaymentType.GiftCertificate.Id, "Amount": 0.00, "ChargeCard": null, "ChargeCardPayment": null, "Check": null, "ECheck": null, "GiftCertificate": null,
                                    "Insurance": null, "BillingAddress": null, "IsProcessed": false, "FeedbackMessage": null
                                };
                                $scope.giftPayment.GiftCertificate = { GiftCertificate: result.GiftCertificate, GiftCertificatePayment: { Amount: payBygift, GiftCertificateId: result.GiftCertificate.Id } };
                                $scope.giftPayment.PaymentType = constants.PaymentType.GiftCertificate.Id;
                                $scope.giftPayment.Amount = payBygift;
                                isPaymentRequired();
                                $scope.AppliedgiftCertificateCode = $scope.giftCertificateCode;
                            }
                            else {
                                logger.showToasterError(result.Message);
                            }
                            $scope.isPosted = false;
                            $scope.loader_ApplyGc = false;
                        }, function () {
                            $scope.isPosted = false;
                            $scope.loader_ApplyGc = false;
                        });
                    }

                };

                $scope.applySourceCode = function () {

                    if ($scope.SourceCodeApplyEditModel.SourceCode !=null && $scope.SourceCodeApplyEditModel.SourceCode != '' && $scope.SourceCodeApplyEditModel.SourceCode != $scope.AppliedSourceCode) {
                        $scope.isPosted = true;
                        $scope.loader_ApplySource = true;
                        paymentService.ApplySourceCode($scope.guid, $scope.SourceCodeApplyEditModel).then(function (result) {
                            $scope.SourceCodeApplyEditModel = result;
                            logger.showToasterSuccess('Source Code Applied Successfully');
                            $scope.CustomerOrder.DiscountAmount = result.DiscountApplied;
                            $scope.data.tempCart = result.RequestValidationModel.TempCart;
                            $scope.AppliedSourceCode = $scope.SourceCodeApplyEditModel.SourceCode;
                            isPaymentRequired();
                            if (($scope.CustomerOrder.TotalPrice - $scope.CustomerOrder.DiscountAmount) > 0) {
                                $scope.showApplyGiftCeritficate = true;
                            } else {
                                $scope.showApplyGiftCeritficate = false;
                            }

                            $scope.isPosted = false;
                            $scope.loader_ApplySource = false;                       
                            orderSummaryRecall();
                        }, function () {
                            $scope.isPosted = false;
                            $scope.loader_ApplySource = false;
                        });
                       
                    }
                    else if ($scope.SourceCodeApplyEditModel.SourceCode != null && $scope.SourceCodeApplyEditModel.SourceCode != '' && $scope.SourceCodeApplyEditModel.SourceCode == $scope.AppliedSourceCode) {
                        logger.showToasterError('Source Code already applied');
                    }
                };

                function isPaymentRequired() {
                   
                    if (typeof ($scope.CustomerOrder) === 'undefined' || $scope.CustomerOrder === null) {
                        return false;
                    }
                    var amountToPay = $scope.CustomerOrder.TotalPrice - $scope.CustomerOrder.DiscountAmount;
                    if ($scope.giftPayment != null && amountToPay > 0) {
                        amountToPay = amountToPay - $scope.giftPayment.Amount;
                    }
                    if (amountToPay <= 0) {
                        $scope.showPaymentPanel = false;
                        $scope.PaymentEditModel.ShippingAddressSameAsBillingAddress = false;
                        if ($scope.giftPayment != null)
                            $scope.giftCertificateApplyAmount = $scope.giftPayment.Amount + amountToPay;
                        return false;
                    } else {
                        $scope.showPaymentPanel = true;
                        if ($scope.giftPayment != null)
                            $scope.giftCertificateApplyAmount = $scope.giftPayment.Amount;
                    }

                    return true;
                };

                $scope.getTotalPaymentAmount = function () {
                    if ($scope.CustomerOrder != undefined)
                        return $scope.CustomerOrder.TotalPrice - $scope.CustomerOrder.DiscountAmount;
                    return 0;
                };

                $scope.getSourceCodeHelpDescription = function () {
                    var avilabilityString = "<div class='help-block text-left'>";
                    if ($scope.SourceCodeApplyEditModel != undefined)
                        avilabilityString = avilabilityString + $scope.SourceCodeApplyEditModel.SourceCodeHelpDescription;

                    avilabilityString = avilabilityString + "</div>";

                    return avilabilityString;
                };

                $scope.getSourceCVVHelpDescription = function () {
                    var avilabilityString = "<div class='help-block text-left' >";

                    avilabilityString = avilabilityString +
                        '<div><p>CVV is an anti-fraud security feature to help verify that you are in possession of your credit card. For Visa/Mastercard, the three-digit CVV number is printed on the signature panel on the back of the card immediately after the cards account number.</p></div>' +
                        '<div> <img src="Images/whatisCVV.jpg" height="82" width="172" alt="CVV" align="middle" border="0"></img></div> ';

                    avilabilityString = avilabilityString + "</div>";

                    return avilabilityString;
                };

                
                $scope.openTermsAndConditions = function (event) {
                    event.preventDefault();// required for IE9 , placeholder clear out issue on modal open
                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/online/views/payment/termsAndCondition.client.view.html',
                        controller: ['$scope',function (scope) {
                            scope.close = function () {
                                scope.$close();
                            };
                        }],
                        size: 'md'
                    });
                };

                $scope.$on('$destroy', function () {
                    if (modelPopupInstance != null) {
                        modelPopupInstance.close(); 
                    }
                });

                function orderSummaryRecall() {
                    $scope.orderSummary = new Object();
                    $scope.dateSuffix = '';                 
                    orderService.GetOrderSummary($stateParams.guid).then(function (orderSummary) {
                        $scope.orderSummary = orderSummary;
                        if (orderSummary != null && orderSummary.EventCustomerOrderSummaryModel != null && orderSummary.EventCustomerOrderSummaryModel.EventDate != null) {
                            $scope.dateSuffix = orderService.GetDateSuffix(orderSummary.EventCustomerOrderSummaryModel.EventDate);
                        }
                    });
                }               

            }]);
}());
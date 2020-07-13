(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.thankYouController,
        ['$rootScope', '$scope', '$stateParams', '$state', '$window', OnlineConfiguration.services.preQualificationService,
            OnlineConfiguration.services.thankYouService, "usSpinnerService", OnlineConfiguration.services.localStorageProgressBarService, CoreConfiguration.constants,
            function ($rootScope, $scope, $stateParams, $state, $window, preQualificationService, thankYouService, usSpinnerService, localStorageProgressBarService, constants) {

                $rootScope.title = $state.current.title;
                $scope.guid = $stateParams.guid;
                $scope.data = {};
                $scope.tempCart = {};
                $scope.isCollapsed = true;
                $scope.isPosted = false;
                $scope.loader_next = false;
                $scope.captureHafOnline = false;
                $scope.ProgressBarStatus = constants.ProgressBarStatus;
                localStorageProgressBarService.InfoPayment($stateParams.guid, $scope.ProgressBarStatus.Complete);

                function init() {
                    $scope.quantcastDate = moment(new Date()).format("MMDDYYYYhhmmss");
                    thankYouService.GetOnlineThankyouModel($stateParams.guid).then(function (thankyouModel) {
                        $scope.data = thankyouModel;
                        $scope.tempCart = thankyouModel.RequestValidationModel.TempCart;
                        $scope.OrderSummary = thankyouModel;
                        $scope.EventDate = thankyouModel.EventCustomerOrderSummaryModel.EventDate;
                        $scope.captureHafOnline = thankyouModel.RequestValidationModel.CaptureOnlineHaf;
                        $scope.AppointmentTime = thankyouModel.EventCustomerOrderSummaryModel.AppointmentTime;
                        $scope.AmountPaid = thankyouModel.EventCustomerOrderSummaryModel.AmountPaid == null ? 0 : thankyouModel.EventCustomerOrderSummaryModel.AmountPaid;
                        $scope.GoogleAnalyticsReportingDataModel = thankyouModel.GoogleAnalyticsReportingDataModel;                       
                        $scope.showProgressBar = false;

                        var d = new Date($scope.AppointmentTime);
                        var dayofMonth = d.getDate();
                        if (dayofMonth >= 11 && dayofMonth <= 13) {
                            $scope.suffix = 'th';
                        } else {
                            switch (dayofMonth % 10) {
                                case 1:
                                    $scope.suffix = 'st';
                                    break;
                                case 2:
                                    $scope.suffix = "nd";
                                    break;
                                case 3:
                                    $scope.suffix = "rd";
                                    break;
                                default:
                                    $scope.suffix = "th";
                                    break;
                            }
                        }
                        googleAnalyticsNotifyThankYou();

                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });
                }

                init();

                $scope.printConfirmation = function() {
                    var eventId = $scope.tempCart.EventId;
                    var customerId = $scope.tempCart.CustomerId;
                    var url = "/Communication/AppointmentConfirmation/Online?eventId=" + eventId + "&customerId=" + customerId;
                    window.open(url, "AppointmentConfirmation_" + customerId, "width=680, height=700, resizable=0, scrollbars=1");
                };

                $scope.goToNextStep = function () {
                    $scope.isPosted = true;
                    $scope.loader_next = true;
                    if ($scope.captureHafOnline) {
                        $state.go('HealthAssessment', { guid: $scope.guid });
                    } else {
                        $state.go('Confirmation', { guid: $stateParams.guid });
                    }
                };
                
                function funcReplace(str) { 
                    var res = str.replace("\"", "\\\"");
                    res = res.replace("'", "\\'");
                    return res;
                }
                function formatPricetoString(price,decimalPoint) {
                    var num = parseFloat(price);
                    var str = num.toFixed(10);
                    str = str.substring(0, str.length - (10 - decimalPoint));
                    return str;
                }
                
                function googleAnalyticsNotifyThankYou() {
                    
                    var gamodel =  $scope.GoogleAnalyticsReportingDataModel;
                    $window._gaq.push(['_addTrans',
                                gamodel.CustomerId.toString(), // order ID
                                'healthfair.com', // affiliation or store name (use healthfair.com)
                                formatPricetoString(gamodel.TotalPrice,2), // total sale amount including tax and shipping
                                '0.00', // tax
                                formatPricetoString(gamodel.Shipping,2), // shipping
                                 funcReplace(gamodel.Address.City),  
                                 funcReplace(gamodel.Address.State),  
                                 funcReplace(gamodel.Address.Country) 
                    ]);
                    if (gamodel.EventPackage != null) {
                        var eP = gamodel.EventPackage;
                        $window._gaq.push(['_addItem',
                            gamodel.CustomerId.toString(), // order ID (same as above in addTrans) - Passing in Customer Id after discussion
                            eP.Id.toString(), // SKU/code
                            funcReplace(eP.Package.Name), // product name
                            '', // category or variation
                            formatPricetoString(eP.Price,2), // unit price or item purchased
                            '1' // quantity of item purchased
                        ]);
                    }
                    if (gamodel.EventTests != null && gamodel.EventTests.length > 0) {

                        $.each(gamodel.EventTests, function(index, item) {
                            $window._gaq.push(['_addItem',
                                gamodel.CustomerId.toString(), // order ID (same as above in addTrans) - Passing in Customer Id after discussion
                                item.Id.toString(), // SKU/code
                                funcReplace(item.Test.Name), // product name
                                '', // category or variation
                                formatPricetoString(item.Price,2), // unit price or item purchased
                                '1' // quantity of item purchased
                            ]);
                        });
                    }
                    if (gamodel.Products != null && gamodel.Products.length > 0) {

                        $.each(gamodel.Products, function(index, item) {
                            $window._gaq.push(['_addItem',
                                gamodel.CustomerId.toString(), // order ID (same as above in addTrans) - Passing in Customer Id after discussion
                                item.Id.toString(), // SKU/code
                                funcReplace(item.Name), // product name
                                '', // category or variation
                                formatPricetoString(item.Price,2), // unit price or item purchased
                                '1' // quantity of item purchased
                            ]);
                        });
                    }
                    $window._gaq.push(['_trackTrans']); //submits transaction to the Analytics servers
                      
                }
                
            }]);
}());
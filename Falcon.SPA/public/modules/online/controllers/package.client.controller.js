(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.packageController,
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', '$modal', OnlineConfiguration.services.eventService, OnlineConfiguration.services.packageService, "usSpinnerService", CoreConfiguration.constants, OnlineConfiguration.services.localStorageProgressBarService,
            function ($rootScope, $scope, $stateParams, $state, logger, $modal, eventService, packageService, usSpinnerService, constants, localStorageProgressBarService) {

                $rootScope.title = $state.current.title;
                $scope.guid = $stateParams.guid;
                $scope.data = {};
                $scope.isCollapsed = true;
                $scope.UpsellTestAvailable = false;
                $scope.IsAdditionalTestAvailable = false;
                $scope.allPackageCount = 0;
                $scope.selectedPackageId = 0;
                $scope.isPosted = false;
                $scope.loader_next = false;
                $scope.loader_back = false;
                $scope.isSelectedPackagePresentInPackageList = false;
                $rootScope.currentState = constants.ProgressBarSteps.Packages;

                $scope.ProgressBarStatus = constants.ProgressBarStatus;
                localStorageProgressBarService.RiskAssessment($stateParams.guid, $scope.ProgressBarStatus.Complete);
                localStorageProgressBarService.PackagesTest($stateParams.guid, $scope.ProgressBarStatus.Started);

                $scope.DisplayPackage = {
                    First: -1,
                    Second: -1
                };

                function init() {

                    packageService.get($stateParams.guid).then(function (result) {
                        $scope.data = result;
                        $scope.AllPackage = result.AllEventPackages;
                        $scope.tempCart = result.RequestValidationModel.TempCart;
                        $scope.RecommendPackageForEvent = result.RecommendPackageForEvent;
                        $scope.selectedPackageId = $scope.tempCart.EventPackageId;
                        $scope.UpsellTestAvailable = result.UpsellTestAvailable;
                        $scope.IsAdditionalTestAvailable = result.IsAdditionalTestAvailable;

                        var packageList = new Array();

                        $.each($scope.AllPackage, function (index, eventPackage) {
                            if (($scope.selectedPackageId == null && $scope.selectedPackageId <= 0) && eventPackage.IsRecommended == true) {
                                eventPackage.isChecked = true;
                                $scope.isSelectedPackagePresentInPackageList = true;
                                $scope.selectedPackageId = eventPackage.EventPackageId;
                            } else if (eventPackage.EventPackageId == $scope.selectedPackageId) {
                                eventPackage.isChecked = true;
                                $scope.isSelectedPackagePresentInPackageList = true;
                            } else {
                                eventPackage.isChecked = false;
                            }

                            var totalPrice = 0;
                            $.each(eventPackage.Tests, function (testIndex, packageTest) {
                                totalPrice = packageTest.Price + totalPrice;
                            });

                            eventPackage.TestPriceTotal = totalPrice;
                            packageList.push(eventPackage);
                        });

                        if (!$scope.isSelectedPackagePresentInPackageList) {
                            $scope.selectedPackageId = 0;
                        }
                        $scope.allPackageCount = $scope.AllPackage.length;

                        if (typeof $scope.AllPackage != 'undefined' && $scope.AllPackage != null && $scope.AllPackage.length > 0) {

                            if ($scope.allPackageCount > 4) {
                                $scope.DisplayPackage.First = $scope.allPackageCount - 1;
                            }

                            if ($scope.allPackageCount > 3) {
                                $scope.DisplayPackage.Second = 3;
                            }
                        }
                        $scope.AllPackage = packageList;
                        $scope.NextPackageInfo();
                        $scope.PrevPackageInfo();

                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });
                }

                $scope.selectPackage = function (packageId) {

                    if ($scope.selectedPackageId !== packageId) {
                        $scope.selectedPackageId = packageId;

                        $.each($scope.AllPackage, function (index, eventPackage) {
                            if (eventPackage.EventPackageId == $scope.selectedPackageId) {
                                eventPackage.isChecked = true;

                            } else {
                                eventPackage.isChecked = false;
                            }
                        });
                    }

                    $(".event-package-detail input[type='radio']").closest(".event-package-detail").removeClass("active-package");
                    $(".event-package-detail input[type='radio']:checked").closest(".event-package-detail").addClass("active-package");

                    var span = $(".event-package-detail .radio-wrap label span");
                    $(span).removeClass("ng-hide");
                    $(span).hide();
                    $(".event-package-detail .radio-wrap input[type='radio']:checked").closest(".radio-wrap").find("label span").show();
                };

                init();


                $scope.showNextButtons = function () {
                    return $scope.AllPackage != null && typeof ($scope.AllPackage) != 'undefined' && $scope.AllPackage.length > 3;
                };

                $scope.showPreviousButton = function () {
                    return $scope.AllPackage != null && typeof ($scope.AllPackage) != 'undefined' && $scope.AllPackage.length > 4;
                };

                $scope.goToNextStep = function () {
                    $scope.isPosted = true;
                    $scope.loader_next = true;
                    if ($scope.selectedPackageId == null || $scope.selectedPackageId == 0) {
                        logger.showToasterError('Please select a package.');
                        $scope.isPosted = false;
                        $scope.loader_next = false;
                        return;
                    } else {
                        if ($scope.tempCart.EventPackageId == null || $scope.selectedPackageId != $scope.tempCart.EventPackageId) {
                            packageService.post($scope.guid, $scope.selectedPackageId).then(function (result) {

                                $scope.UpsellTestAvailable = result.UpsellTestAvailable;
                                $scope.IsAdditionalTestAvailable = result.IsAdditionalTestAvailable;

                                if ($scope.UpsellTestAvailable) {
                                    $state.go('UpsellTests', { guid: $stateParams.guid });
                                } else if ($scope.IsAdditionalTestAvailable) {
                                    $state.go('Test', { guid: $stateParams.guid });
                                }
                                else {
                                    $rootScope.IsTestScreenCrossed = true;
                                    $state.go("Appointment", { guid: $scope.guid });
                                }
                                $scope.isPosted = false;
                                $scope.loader_next = false;
                            }, function () {
                                $scope.loader_next = false;
                                $scope.isPosted = false;
                            });
                        } else {
                            if ($scope.UpsellTestAvailable) {
                                $state.go('UpsellTests', { guid: $stateParams.guid });
                            } else if ($scope.IsAdditionalTestAvailable) {
                                $state.go('Test', { guid: $stateParams.guid });
                            }
                            else {
                                $rootScope.IsTestScreenCrossed = true;
                                $state.go("Appointment", { guid: $scope.guid });
                            }
                        }
                    }
                };

                $scope.goToPreviousStep = function () {
                    $scope.isPosted = true;
                    $scope.loader_back = true;
                    if ($scope.selectedPackageId == null || $scope.selectedPackageId == 0) {
                        $state.go('PreQualification', { guid: $stateParams.guid });
                        return;
                    } else {
                        if ($scope.tempCart.EventPackageId == null || $scope.selectedPackageId != $scope.tempCart.EventPackageId) {

                            packageService.post($scope.guid, $scope.selectedPackageId).then(function () {
                                $scope.isPosted = false;
                                $scope.loader_back = false;

                                $state.go('PreQualification', { guid: $stateParams.guid });
                            }, function () {
                                $scope.isPosted = false;
                                $scope.loader_back = false;
                            });
                        } else {
                            $state.go('PreQualification', { guid: $stateParams.guid });
                        }
                    }
                };

                $scope.getClass = function (packageDetail, index) {
                    var classname = "";

                    if (packageDetail.MostPopular && packageDetail.ImageUrlForOnlineDisplay == null) {
                        classname = "mostpopular panel-primary ";
                    }
                    else if (packageDetail.BestValue && packageDetail.ImageUrlForOnlineDisplay == null) {
                        classname = "bestvalued panel-primary ";
                    }
                    //else if ($scope.RecommendPackageForEvent && packageDetail.IsRecommended && packageDetail.ImageUrlForOnlineDisplay == null) {
                    //    classname = "recommended panel-primary ";
                    //}
                    else {
                        classname = "panel-primary ";
                    }

                    return classname + 'ca-item-' + (Number(index) + 1);
                };

                $scope.NextPackageInfo = function () {
                    if ($scope.DisplayPackage.Second == -1) {
                        $scope.DisplayPackage.NextPackageName = "";
                        $scope.DisplayPackage.NextPackagePrice = 0;
                    } else {
                        //var packageDetails = $scope.AllPackage[$scope.DisplayPackage.Second];
                        //$scope.DisplayPackage.NextPackageName = "More Packages";
                        // $scope.DisplayPackage.NextPackagePrice = packageDetails.Price;
                    }
                };
                $scope.PrevPackageInfo = function () {

                    if ($scope.DisplayPackage.First == -1) {
                        $scope.DisplayPackage.PrePackageName = "";
                        $scope.DisplayPackage.PrePackagePrice = 0;
                    } else {
                        // var packageDetails = $scope.AllPackage[$scope.DisplayPackage.First];
                        //$scope.DisplayPackage.PrePackageName = "More Packages";
                        // $scope.DisplayPackage.PrePackagePrice = packageDetails.Price;
                    }
                };

                var modelPopupInstance = null;
                $scope.learnMoreAboutTest = function (test) {

                    var discription = test.Description;
                    if (test.MediaUrl !== null && test.MediaUrl != '') {
                        discription = discription + '<a href="' + test.MediaUrl + '" class="pull-left text-danger text-underline top-buffer-10 col-md-12 no-padding-x" target="_blank">Click here to watch video</a> </div>';
                    }

                    var modalPopupObject = {
                        showTitle: true,
                        Title: test.Name,
                        showCancelButton: false,
                        cancelButtonText: '',
                        showOkButton: true,
                        OKButtonText: 'OK',
                        Message: discription,
                        CallBackOnOkButton: null,
                        CallBackOnCancelButton: null
                    };

                    modelPopupInstance = $modal.open({
                        templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/shared/views/model.popup.client.view.html',
                        controller: 'modalPopupController',
                        size: 'md',
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
                });;


            }]);

}());


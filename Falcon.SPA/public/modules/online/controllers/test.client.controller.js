(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.testController,
        ['$rootScope', '$scope', '$stateParams', '$state', '$modal', "$filter", OnlineConfiguration.services.eventService, OnlineConfiguration.services.testService, "usSpinnerService", CoreConfiguration.constants, '$localStorage',
    function ($rootScope, $scope, $stateParams, $state, $modal, $filter, eventService, testService, usSpinnerService, constants, $localStorage) {

        $rootScope.title = $state.current.title;
        $scope.guid = $stateParams.guid;
        $scope.data = {};
        $scope.tempCart = {};
        $scope.isCollapsed = true;
        $scope.displayMessage = '';
        $scope.UpsellTestAvilable = false;
        $scope.isPosted = false;
        $rootScope.currentState = constants.ProgressBarSteps.Tests;
        $scope.TestTypes = constants.TestTypes;
        $scope.MensBloodPanelTestId = constants.BloodWorkTestIds.MenBloodPanel;
        $scope.WomensBloodPanelTestId = constants.BloodWorkTestIds.WomenBloodPanel;
        $scope.WomenBloodPanelGroup = [5, 17, 66];
        $scope.MenBloodPanelGroup = [20, 17, 28];
        
        $scope.loader_back = false;
        $scope.loader_next = false;
        $scope.SaveBloodPanelTest = false;
        $scope.hasUserConfirmedForBloodPanelAddition = false;
        $scope.FilteredTests = [];
        $scope.EnableImageUpsell = false;
        $scope.IsProductItemUpdated = false;
        var selectedProductId = -1;

        var selectedTestsIds = 0;

        function init() {

            if ($localStorage.hasUserConfirmedForBloodPanelAddition != undefined)
                $scope.hasUserConfirmedForBloodPanelAddition = true;

            testService.GetAdditionalTest($stateParams.guid).then(function (result) {
                $scope.AllTests = result.AllEventTests;

                $scope.data = result;
                $scope.tempCart = result.RequestValidationModel.TempCart;
                selectedProductId = $scope.tempCart.ProductId;
                $scope.EnableImageUpsell = result.EnableImageUpsell;
                
                $scope.BloodPanelTestId = result.BloodPanelTestId;
                $scope.BloodPanelTestName = result.BloodPanelTestName;
                
                $scope.UpsellTestAvailable = result.UpsellTestAvailable;
                $scope.IsBloodPanelTestTaken = result.IsBloodPanelTestTaken;
                selectedTestsIds = $scope.tempCart.TestId;

                var testArray = [];
                if (selectedTestsIds.length > 1) {
                    testArray = selectedTestsIds.split(',');

                }
                getContainsFunction(testArray);
                $.each($scope.AllTests, function (index, test) {
                    test.isChecked = false;
                    
                    if (testArray.contains(test.EventTestId)) {
                        test.isChecked = true;
                    } else if (test.AddDefaultToOrder) {
                        test.isChecked = true;
                        $scope.AlacarteSelectionChanged = true;
                    }
                });

                //if (typeof ($scope.UpsellTests) != "undefined" && $scope.UpsellTests != null) {
                //    $.each($scope.UpsellTests, function (index, test) {
                //        test.isChecked = false;

                //        if (testArray.contains(test.EventTestId)) {
                //            test.isChecked = true;
                //        } else if (test.AddDefaultToOrder) {
                //            test.isChecked = true;
                //            $scope.AlacarteSelectionChanged = true;
                //        }
                //        if (test.TestId == constants.TestTypes.Echocardiogram) {
                //            test.Description = 'An Echocardiogram is a test that uses ultrasound waves to create a moving picture of your heart.  According to the American Heart Association this test is considered the most accurate, non-invasive study to provide information about the heart and identify your risk for heart disease.';
                //            test.DescriptionPara2 = 'An Echo may be right for you if you have the following risk factors - over age of 50, family history of heart attacks, smoker, overweight, abnormal cholesterol, diabetes, family history of obesity and experience shortness of breath.  <a href="https://www.youtube.com/watch?v=UAQ0-bNUcGQ&feature=youtu.be" class="pull-right text-danger text-underline" target="_blank">Click here to watch video</a>';
                //        }
                //        if (testArray.contains(test.EventTestId) && (test.TestId === $scope.MensBloodPanelTestId || test.TestId === $scope.WomensBloodPanelTestId)) {
                //            if ($scope.AllTests != null && typeof ($scope.AllTests) != 'undefined') {
                //                $scope.hideBloodPanelTest(test);
                //            }
                //        }
                //    });
                //}

                //$.each($scope.AllProducts, function (index, product) {
                //    product.isChecked = false;
                //    if (product.ProductId == selectedProductId)
                //        product.isChecked = true;
                //    if (product.ProductId == constants.Products.Ultrasound)
                //        product.ShortDescription = product.ShortDescription + ' For purchasing the ultrasound images, we will provide unlimited online access and a complementary mailed copy of your report and ultrasound images on a CD.';

                //});

                //$scope.FilteredTests = angular.copy($filter("filter")($scope.AllTests, { ShowTest: true }));

                setTimeout(function () {
                    usSpinnerService.stop('online-spinner');
                }, 1000);
            });
        }

        init();
        $scope.AlacarteSelectionChanged = false;

        $scope.alacarteStatusChanged = function (testdetail) {
            //$.each($scope.AllTests, function (inedx, test) {
            //    if (test.TestId == testdetail.TestId) {
            //        test.isChecked = testdetail.isChecked;
            //    }
            //});

            $scope.AlacarteSelectionChanged = true;
        };

        //$scope.UpsellItemChecked = function (test) {
        //    $scope.AlacarteSelectionChanged = true;
        //    $scope.hideBloodPanelTest(test);
        //    $scope.FilteredTests = angular.copy($filter("filter")($scope.AllTests, { ShowTest: true }));
        //};


        //$scope.hideBloodPanelTest = function (test) {
        //    var bloodGroupTest = [];
        //    if (test.TestId === $scope.MensBloodPanelTestId || test.TestId === $scope.WomensBloodPanelTestId) {

        //        $.each(test.Tests, function (index, bloodTest) {
        //            bloodGroupTest.push(bloodTest.Id);
        //        });

        //        if (bloodGroupTest.length > 0) {
        //            getContainsFunction(bloodGroupTest);
        //            $.each($scope.AllTests, function (index, bloodTest) {
        //                if (bloodGroupTest.contains(bloodTest.TestId)) {
        //                    bloodTest.ShowTest = !test.isChecked;
        //                    bloodTest.isChecked = false;
        //                }
        //            });
        //        }
        //    }
        //};

        var getSeletedTest = function () {
            var selectedTests = new Array();

            if (typeof ($scope.AllTests) != 'undefined' && $scope.AllTests != null && $scope.AllTests.length > 0) {
                $.each($scope.AllTests, function (index, value) {
                    if (value.isChecked == true)
                        selectedTests.push(value.EventTestId);
                });
            }

            //if (typeof ($scope.UpsellTests) != 'undefined' && $scope.UpsellTests != null && $scope.UpsellTests.length > 0) {
            //    $.each($scope.UpsellTests, function (index, testItem) {
            //        if (testItem.isChecked) {
            //            selectedTests.push(testItem.EventTestId);
            //        }
            //    });
            //}
            return selectedTests;
        };

        //var getSelectedProductId = function () {
        //    var selectedProductIds = new Array();
        //    $.each($scope.AllProducts, function (index, product) {

        //        if (product.isChecked) {
        //            selectedProductIds.push(product.ProductId);
        //        }
        //    });

        //    return selectedProductIds;
        //};

        //$scope.productOptionChanged = function () {

        //    $scope.AlacarteSelectionChanged = true;
        //    $scope.IsProductItemUpdated = true;
        //};

        $scope.goToPreviousStep = function () {
            $scope.isPosted = true;
            $scope.loader_back = true;
            if ($scope.UpsellTestAvailable) {
                $state.go('UpsellTests', { guid: $scope.guid });
            } else {
                $state.go('Package', { guid: $scope.guid });
            }
            
        };

        var modelPopupInstance = null;
        $scope.learnMore = function (test) {

            var modalPopupObject = {
                showTitle: true,
                Title: test.Name,
                showCancelButton: false,
                cancelButtonText: '',
                showOkButton: true,
                OKButtonText: 'OK',
                Message: test.Description,
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
        $scope.openKynSampleReport = function () {
            modelPopupInstance = $modal.open({
                templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/online/views/upselltest/kyn.sample.report.client.view.html',
                controller: ['$scope', function (scope) {
                    scope.close = function () {
                        scope.$close();
                    };
                }],
                size: 'lg'
            });
        };

    

        $scope.learnMoreAboutTest = function (test) {
            var modalPopupObject = {
                showTitle: true,
                Title: test.Name,
                showCancelButton: false,
                cancelButtonText: '',
                showOkButton: true,
                OKButtonText: 'OK',
                Message: test.Description,
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
        $scope.goToNextStep = function () {
            $scope.isPosted = true;
            $scope.loader_next = true;

            if ($scope.AlacarteSelectionChanged == false) {
                $rootScope.IsTestScreenCrossed = true;
                $state.go("Appointment", { guid: $scope.guid });
            } else {
                var selectedTests = getSeletedTest();
                getContainsFunction(selectedTests);
                var bloodPanelTest = getBloodPanelTest($scope.BloodPanelTestId);
                if (bloodPanelTest && $scope.hasUserConfirmedForBloodPanelAddition == false) {
                    recommendIfBloodPanelNotTaken();
                } else {
                    saveAllSelectedTest();
                }
            }
        };

        function getBloodPanelTest(bloodPannelTestId) {
           
            if ($scope.IsBloodPanelTestTaken == false && ($scope.MensBloodPanelTestId == bloodPannelTestId || $scope.WomensBloodPanelTestId == bloodPannelTestId)) return true;

            return false;
        }

        function saveAllSelectedTest() {
            var selectedTests = getSeletedTest();
           
            var data = {
                SelectedEventTestIds: selectedTests,
                Guid: $scope.guid,
                SaveBloodPanelTest: $scope.SaveBloodPanelTest
            };
            
            testService.saveSelectedtest(data).then(function () {
                $scope.isPosted = false;
                $scope.loader_next = false;
                $rootScope.IsTestScreenCrossed = true;
                $state.go("Appointment", { guid: $scope.guid });
            }, function () {
                $scope.isPosted = false;
                $scope.loader_next = false;
            });
        }

        function recommendIfBloodPanelNotTaken() {

            if ($scope.BloodPanelTestName != null && $scope.BloodPanelTestName != '') {

                var selectedTestIds = new Array();

                $.each($scope.AllTests, function (index, value) {
                    if (value.isChecked == true)
                        selectedTestIds.push(value.TestId);
                });
                var panelTestIds = constants.BloodWorkTestIds;
                
                if (($scope.BloodPanelTestId === $scope.MensBloodPanelTestId && (selectedTestIds.indexOf(panelTestIds.Psa) >= 0 || selectedTestIds.indexOf(panelTestIds.Crp) >= 0 || selectedTestIds.indexOf(panelTestIds.Testosterone) >= 0)) || ($scope.BloodPanelTestId === $scope.WomensBloodPanelTestId && (selectedTestIds.indexOf(panelTestIds.Thyroid) >= 0 || selectedTestIds.indexOf(panelTestIds.Crp) >= 0 || selectedTestIds.indexOf(panelTestIds.VitaminD) >= 0))) {
                    var modalPopupObject = {
                        showTitle: true,
                        Title: 'Recommendation for ' + $scope.BloodPanelTestName,
                        showCancelButton: true,
                        cancelButtonText: 'I am ok with Individual test',
                        showOkButton: true,
                        OKButtonText: 'OK',
                        Message: 'It is recommended to purchase ' + $scope.BloodPanelTestName + ' instead of selecting individual test as it is of greater value.',
                        CallBackOnOkButton: onRecomendOkClick,
                        CallBackOnCancelButton: onRecomendCancelClick,
                        CallBackOnEscape: onRecomendCancelClick
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
                } else {
                    saveAllSelectedTest();
                }
            }
        }

        function onRecomendOkClick() {
            setLocalStorageForUSerConfirmation();
            $scope.SaveBloodPanelTest = true;
            saveAllSelectedTest();
        }
        function onRecomendCancelClick() {
            setLocalStorageForUSerConfirmation();
            $scope.SaveBloodPanelTest = false;
            saveAllSelectedTest();
        }

        function setLocalStorageForUSerConfirmation() {
            if ($localStorage.hasUserConfirmedForBloodPanelAddition != undefined)
                $scope.hasUserConfirmedForBloodPanelAddition = true;
            else {
                $localStorage.$default({
                    hasUserConfirmedForBloodPanelAddition: true
                });
            }
        }

        $scope.$on('$destroy', function () {
            if (modelPopupInstance != null) {
                modelPopupInstance.close();
            }
        });

        var getContainsFunction = function (collection) {
            if (collection == null) collection = new Array();

            collection.contains = function (currentElement) {
                for (var counter = 0; counter < this.length; counter++) {
                    if (parseInt(this[counter]) == parseInt(currentElement))
                        return true;
                }
                return false;
            };
        };
    }]);
}());
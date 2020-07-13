(function () {
    'use strict';
    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.upsellTestController,
       ['$rootScope', '$scope', '$stateParams', '$state', '$modal', OnlineConfiguration.services.upsellTestService, CoreConfiguration.constants, "usSpinnerService",
           function ($rootScope, $scope, $stateParams, $state, $modal, upsellTestService, constants, usSpinnerService) {

               $rootScope.title = $state.current.title;
               $scope.data = {};
               $scope.EventTestOrderItemList = {};
               $scope.isCollapsed = true;
               $scope.isPosted = false;
               $scope.TestTypes = constants.TestTypes;
               $scope.MensBloodPanelTestId = constants.BloodWorkTestIds.MenBloodPanel;
               $scope.WomensBloodPanelTestId = constants.BloodWorkTestIds.WomenBloodPanel;
               $rootScope.currentState = constants.ProgressBarSteps.Tests;
               $scope.loader_back = false;
               $scope.loader_next = false;

               function init() {
                   upsellTestService.get($stateParams.guid).then(function (result) {
                       $scope.data = result;
                       $scope.tempCart = result.RequestValidationModel.TempCart;

                       var testList = new Array();
                       var selectedTestEventIDs = new Array();
                       if (typeof $scope.tempCart.TestId != 'undefined' && $scope.tempCart.TestId != null && $scope.tempCart.TestId != '') {
                           selectedTestEventIDs = $scope.tempCart.TestId.split(",");
                       }

                       $.each(result.EventTestOrderItemList, function (index, test) {
                           test.isSeletected = false;
                           $.each(selectedTestEventIDs, function (it, tl) {
                               if (tl == test.EventTestId) {
                                   test.isSeletected = true;
                               }
                           });
                           if (test.TestId == constants.TestTypes.Echocardiogram) {
                               test.Description = 'An Echocardiogram is a test that uses ultrasound waves to create a moving picture of your heart.  According to the American Heart Association this test is considered the most accurate, non-invasive study to provide information about the heart and identify your risk for heart disease.';
                               test.DescriptionPara2 = 'An Echo may be right for you if you have the following risk factors - over age of 50, family history of heart attacks, smoker, overweight, abnormal cholesterol, diabetes, family history of obesity and experience shortness of breath. <a href="https://www.youtube.com/watch?v=UAQ0-bNUcGQ&feature=youtu.be" class="pull-right text-danger text-underline" target="_blank">Click here to watch video</a>';
                           }
                           testList.push(test);
                       });

                       $scope.EventTestOrderItemList = testList;

                       setTimeout(function () {
                           usSpinnerService.stop('online-spinner');
                       }, 1000);
                   });
               }

               init();

               $scope.goToPackagePage = function () {
                   var selectedTestIds = new Array();

                   $.each($scope.EventTestOrderItemList, function (index, test) {
                       if (test.isSeletected) {
                           selectedTestIds.push(test.EventTestId);
                       }
                   });

                   var data = { SelectedEventTestIds: selectedTestIds, Guid: $stateParams.guid };
                   $scope.isPosted = true;
                   $scope.loader_back = true;
                   upsellTestService.post(data).then(function () {
                       $scope.isPosted = false;
                       $scope.loader_back = false;
                       $state.go('Package', { guid: $stateParams.guid });
                   }, function () { $scope.isPosted = false; $scope.loader_back = false; });
               };

               $scope.goToTestPage = function () {
                   
                   var selectedTestIds = new Array();

                   $.each($scope.EventTestOrderItemList, function (index, test) {
                       if (test.isSeletected) {
                           selectedTestIds.push(test.EventTestId);
                       }
                   });

                   var data = { SelectedEventTestIds: selectedTestIds, Guid: $stateParams.guid };
                   $scope.isPosted = true;
                   $scope.loader_next = true;
                   upsellTestService.post(data).then(function () {
                       $scope.isPosted = false;
                       $scope.loader_next = false;
                       if ($scope.data.IsAdditionalTestAvailable)
                           $state.go('Test', { guid: $stateParams.guid });
                       else {
                           $state.go('Appointment', { guid: $stateParams.guid });
                       }
                   }, function () {
                       $scope.isPosted = false;
                       $scope.loader_next = false;
                   });

               };

               $scope.GetTestTotalPrice = function (tests) {
                   if (tests != null) {
                       var totalPrice = 0.0;
                       $.each(tests, function (i, item) {
                           totalPrice = item.Price + totalPrice;
                       });
                       return totalPrice;
                   }
                   return 0.0;
               };

               var modelPopupInstance = null;
               $scope.openKynSampleReport = function () {
                   modelPopupInstance = $modal.open({
                       templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/online/views/upselltest/kyn.sample.report.client.view.html',
                       controller: ['$scope',function (scope) {
                           scope.close = function () {
                               scope.$close();
                           };
                       }],
                       size: 'lg'
                   });
               };
                
                
               $scope.learnMore = function (test) {
                   
                   var discription = '';
                   if (test.TestId == constants.TestTypes.Echocardiogram) {
                       discription = test.Description + "<br/>" + test.DescriptionPara2;
                   } else {
                       discription = test.Description;
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
               });
               

           }]);
}());
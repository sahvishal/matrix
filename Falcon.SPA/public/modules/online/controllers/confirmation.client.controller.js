(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.confirmationController,
        ['$rootScope', '$scope', '$stateParams', '$state', OnlineConfiguration.services.confirmationService,
            OnlineConfiguration.services.eventService, CoreConfiguration.constants, "usSpinnerService",
            function ($rootScope, $scope, $stateParams, $state, confirmationService, eventService, constants, usSpinnerService) {

                $rootScope.title = $state.current.title;
                $scope.guid = $stateParams.guid;
                $scope.data = {};
                $scope.isCollapsed = true;
                $scope.isPosted = false;
                $scope.Model = {};
                $scope.showPrintHafForm = true;
                $scope.showsignupbtn = true;
                $scope.hafPDFurl = '';
                $scope.eventType = constants.EventType;

                function init() {
                    $scope.isPosted = true;

                    confirmationService.get($stateParams.guid).then(function (result) {
                        if (result != null) {
                            $scope.data = result;
                            $scope.tempCart = result.RequestValidationModel.TempCart;
                            $scope.Model = result.ConfirmationViewModel;
                            $scope.isPosted = false;

                            if ($scope.tempCart.IsHafFilled) {
                                $scope.showPrintHafForm = true;
                            } else {
                                $scope.showPrintHafForm = false;
                            }

                            if ($scope.data.EventType == $scope.eventType.Corporate) {
                                $scope.showsignupbtn = false;
                            }
                        }
                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });
                }

                init();

                $scope.printConfirmation = function () {
                    var eventId = $scope.data.RequestValidationModel.TempCart.EventId;
                    var customerId = $scope.data.RequestValidationModel.TempCart.CustomerId;
                    var url = "/Communication/AppointmentConfirmation/Online?eventId=" + eventId + "&customerId=" + customerId;
                    window.open(url, "AppointmentConfirmation_" + customerId, "width=680, height=700, resizable=0, scrollbars=1");
                }

                //$scope.printHealthAssessmentForm = function () {
                //    var url = "/Scheduling/Online/OnlineCheckoutPrintHaf?guid=" + $stateParams.guid;
                //    return url;
                //}

                $scope.signupAnotherCustomer = function () {
                    var data = {
                        EventId: $scope.tempCart.EventId,
                        ZipCode: $scope.tempCart.ZipCode,
                        Radius: $scope.tempCart.Radius
                    };
                    $scope.isPosted = true;
                    eventService.saveSelectedEvent(data).then(function (result) {
                        $scope.isPosted = false;
                        $state.go('PreQualification', { guid: result.RequestValidationModel.TempCart.Guid });
                    });
                }

                $scope.finish = function () {
                    window.location.href = ApplicationConfiguration.siteUrl;
                }

            }]);
}());
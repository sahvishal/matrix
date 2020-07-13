(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.appointmentController,
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', 
            OnlineConfiguration.services.appointmentService, "usSpinnerService", CoreConfiguration.constants, OnlineConfiguration.services.localStorageProgressBarService,
            function ($rootScope, $scope, $stateParams, $state, logger, appointmentService, usSpinnerService, constants, localStorageProgressBarService) {

                $rootScope.title = $state.current.title;
                $scope.guid = $stateParams.guid;
                $scope.data = {};
                $scope.data.tempCart = {};
                $scope.isCollapsed = true;
                $scope.isPosted = false;
                $scope.loader_back = false;
                $scope.loader_next = false;
                $scope.loader_differentEvent = false;
                $scope.showMorningTabOpen = false;
                $scope.showAfternoonTabOpen = false;
                $scope.showEveningTabOpen = false;
                $scope.phoneTollFree = ApplicationConfiguration.phoneTollFree;
                $scope.noSlotsAvailable = false;
                $rootScope.currentState = constants.ProgressBarSteps.Appointment;
                $scope.selectedAppointmentsId = 0;
                $scope.IsAdditionalTestAvailable = false;
                $scope.ProgressBarStatus = constants.ProgressBarStatus;
                $scope.EventTypeEnum = constants.EventType;
                $scope.IsHospitalPartnerEvent = false;
                localStorageProgressBarService.PackagesTest($stateParams.guid, $scope.ProgressBarStatus.Complete);
                localStorageProgressBarService.Appointment($stateParams.guid, $scope.ProgressBarStatus.Started);
               
                function init() {
                    $scope.data.tempCart.Guid = $stateParams.guid;

                    appointmentService.GetEventAppointmentSlotOnline($scope.guid).then(function (result) {
                        $scope.data = result;
                        $scope.data.Allappointments = result;
                        $scope.data.tempCart = result.RequestValidationModel.TempCart;
                       
                        $scope.selectedAppointmentsId = $scope.data.tempCart.AppointmentId;
                       
                        
                        $scope.IsAdditionalTestAvailable = result.IsAdditionalTestAvailable;
                        
                        if ($scope.selectedAppointmentsId != null && $scope.selectedAppointmentsId > 0)
                            initialiseData($scope.selectedAppointmentsId);
                        else {
                            if ($scope.data.Allappointments.MorningSlots.length > 0)
                                $scope.showMorningTabOpen = true;
                            else if($scope.data.Allappointments.AfterNoonSlots.length > 0)
                                $scope.showAfternoonTabOpen = true;
                            else if ($scope.data.Allappointments.EveningSlots.length > 0)
                                $scope.showEveningTabOpen = true;
                        }
                        if ($scope.data.Allappointments.MorningSlots.length + $scope.data.Allappointments.AfterNoonSlots.length + $scope.data.Allappointments.EveningSlots.length > 0)
                            $scope.noSlotsAvailable = false;
                        else
                            $scope.noSlotsAvailable = true;
                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);

                    }, function () {
                        $scope.noSlotsAvailable = true;
                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });

                }
                function initialiseData(appointmentId) {
                    var found = false;
                    for (var i = 0; i < $scope.data.Allappointments.MorningSlots.length; i++) {
                        $scope.data.Allappointments.MorningSlots[i].isChecked = false;
                        if (found == false && $scope.data.Allappointments.MorningSlots[i].AppointmentId == appointmentId) {
                            $scope.data.Allappointments.MorningSlots[i].isChecked = true;
                            $scope.appointmentDate = $scope.data.Allappointments.MorningSlots[i].StartTime;
                            found = true;
                            $scope.showMorningTabOpen = true;
                        }
                    }
                    if (found == false) {
                        for (i = 0; i < $scope.data.Allappointments.AfterNoonSlots.length; i++) {
                            $scope.data.Allappointments.AfterNoonSlots[i].isChecked = false;
                            if ($scope.data.Allappointments.AfterNoonSlots[i].AppointmentId == appointmentId) {
                                $scope.data.Allappointments.AfterNoonSlots[i].isChecked = true;
                                $scope.appointmentDate = $scope.data.Allappointments.AfterNoonSlots[i].StartTime;
                                found = true;
                                $scope.showAfternoonTabOpen = true;
                            }
                        }
                    }
                    if (found == false) {
                        for (i = 0; i < $scope.data.Allappointments.EveningSlots.length; i++) {
                            $scope.data.Allappointments.EveningSlots[i].isChecked = false;
                            if ($scope.data.Allappointments.EveningSlots[i].AppointmentId == appointmentId) {
                                $scope.data.Allappointments.EveningSlots[i].isChecked = true;
                                $scope.appointmentDate = $scope.data.Allappointments.EveningSlots[i].StartTime;
                                $scope.showEveningTabOpen = true;
                            }
                        }
                    }
                     
                    var d = new Date($scope.appointmentDate);
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
                }

                init();

                $scope.selectAppointment = function (appointmentId) {

                    $scope.selectedAppointmentsId = appointmentId;

                    $scope.isPosted = true;
                    appointmentService.SaveEventAppointmentSlotOnline($scope.guid, $scope.selectedAppointmentsId).then(function (result) {
                        $scope.data = result;
                        $scope.data.Allappointments = result;
                        $scope.data.tempCart = result.RequestValidationModel.TempCart;
                        $scope.selectedAppointmentsId = $scope.data.tempCart.AppointmentId;
                        initialiseData($scope.selectedAppointmentsId);
                        $scope.isPosted = false;
                    }, function () {
                        reloadSlots();
                    });

                };


                function reloadSlots() {

                    appointmentService.GetEventAppointmentSlotOnline($scope.guid, $scope.data.tempCart.EventId).then(function (result) {
                        $scope.data = result;
                        $scope.data.Allappointments = result;
                        $scope.data.tempCart = result.RequestValidationModel.TempCart;
                        $scope.selectedAppointmentsId = $scope.data.tempCart.AppointmentId;
                        initialiseData($scope.selectedAppointmentsId);
                        $scope.isPosted = false;
                    });
                }

                $scope.goToPreviousStep = function () {
                    $scope.isPosted = true;
                    $scope.loader_back = true;

                    if ($scope.IsAdditionalTestAvailable) {
                        $state.go("Test", { guid: $scope.guid });
                    }
                    else if ($scope.UpsellTestAvailable) {
                        $state.go("UpsellTests", { guid: $scope.guid });
                    }
                    else {
                        $state.go("Package", { guid: $scope.guid });
                    }
                    
                };
              
                
                $scope.goToNextStep = function () {
                    $scope.isPosted = true;
                    $scope.loader_back = true;
                      
                    if ($scope.selectedAppointmentsId == null || $scope.selectedAppointmentsId <= 0) {
                        logger.showToasterError('Please select one appointment Slot.');
                        $scope.isPosted = false;
                        $scope.loader_back = false;
                    }
                   else {
                        appointmentService.SaveEventAppointmentSlotOnline($scope.guid, $scope.selectedAppointmentsId).then(function () {
                            $scope.isPosted = false;
                            $scope.loader_back = false;
                            $state.go('Customer', { guid: $scope.guid });
                        }, function () {
                            $scope.isPosted = false;
                            $scope.loader_back = false;
                        });

                    }
                };

                $scope.goToRequestForEvent = function () {
                    $scope.isPosted = true;
                    $scope.loader_differentEvent = true;
                    $state.go('Event', { guid: $scope.guid });
                };
                
            }]);

}());
(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.requestEventController,
        ['$rootScope', '$scope', '$stateParams', '$state', CoreConfiguration.constants, OnlineConfiguration.services.eventService,"usSpinnerService",
            function ($rootScope, $scope, $stateParams, $state, constants, eventService, usSpinnerService) {

                $rootScope.title = $state.current.title;
                $scope.data = {};
                $scope.isCollapsed = true;
                $scope.displayMessage = '';
                var customer = {
                    Id: 0,
                    FirstName: '',
                    LastName: '',
                    Gender: 0,
                    Address: { StreetAddressLine1: "", StreetAddressLine2: "", City: "", State: "", Country: "", ZipCode: $stateParams.zip },
                    CallBackPhoneNumber: { CountryCode: 1, AreaCode: "", Number: "" },
                    Email: { Address: "", DomainName: "" },
                    Source: '',
                    Tag: '',
                    IsCallBackPhoneNumberRequired:true
                };
                setTimeout(function () {
                    usSpinnerService.stop('online-spinner');
                }, 1000);


                $scope.requestForEvents = function (form) {
                    form.submitted = true;

                    if (form.$valid) {
                        customer.FirstName = $scope.firstName;
                        customer.LastName = $scope.lastName;
                        customer.Address.Country = "USA";
                        customer.Source = constants.ProspectCustomer.Source.Online;
                        customer.Tag = constants.ProspectCustomer.Tag.NotServicedZip;
                        var phoneNumber = $scope.phone;
                        if (phoneNumber != '' && phoneNumber != undefined) {
                            phoneNumber = phoneNumber.replace("(", "");
                            phoneNumber = phoneNumber.replace(")", "");
                            phoneNumber = phoneNumber.replace(/_/gi, "");
                            phoneNumber = phoneNumber.replace(/-/gi, "");
                            customer.CallBackPhoneNumber.AreaCode = phoneNumber.substring(0, 3).trim();
                            customer.CallBackPhoneNumber.Number = phoneNumber.substring(3, phoneNumber.length).trim();
                        }
                        var email = $scope.email;
                        if (email != '' && email != undefined) {
                            var emailSplit = email.split('@');
                            customer.Email.Address = emailSplit[0];
                            customer.Email.DomainName = emailSplit[1];
                        }

                        eventService.requestForEvents(customer)
                            .then(function (data) {
                                if (data.Data == true) {
                                    $scope.firstName = '';
                                    $scope.lastName = '';
                                    $scope.phone = '';
                                    $scope.email = '';
                                    $scope.displayMessage = 'Thanks again for the participation. We will get back to you soon!';
                                    form.submitted = false;
                                }
                                window.location.href = ApplicationConfiguration.siteUrl;
                            });
                    }
                };


                $scope.searchEvent = function () {
                    $state.go('SearchEvent');
                };

            }]);
}());


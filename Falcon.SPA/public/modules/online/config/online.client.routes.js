(function () {
    'use strict';

    // Setting up route
    angular.module(OnlineConfiguration.moduleName)
        .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

            $locationProvider.html5Mode(true).hashPrefix('');

            // Redirect to home view when route not found
            $urlRouterProvider.otherwise('/Default');
            // Home stadete routing
            $stateProvider.state('Default', {
                url: '/Default',
                template: '',
                controller: ['$state', function ($state) {
                    $state.go("SearchEvent", { zipcode: '', radius: '' });
                }]
            })
            .state('SearchEvent', {
                url: '/SearchEvent/{zipcode}/{radius}/{distance}/{guid}/{eventid}/{cpncd}/{invitationcode}/{corpcode}',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/event/event.client.view.html',
                title: 'Search Event'
                    , controller: [OnlineConfiguration.services.eventParameterService, '$state', '$stateParams', function (eventParameterFactory, $state, $stateParams) {
                        var parameter = {
                            zipCode: $stateParams.zipcode,
                            radius: $stateParams.radius,
                            distance: $stateParams.distance,
                            guid: $stateParams.guid,
                            eventId: $stateParams.eventid,
                            cpncd: $stateParams.cpncd,
                            invitationCode: $stateParams.invitationcode,
                            corpcode: $stateParams.corpcode
                        };

                        eventParameterFactory.set(parameter);

                        if (parameter.invitationCode !== null && parameter.invitationCode !== 'null' && parameter.invitationCode !== '')
                            $state.go("EventWithInvitationCode", { invitationcode: parameter.invitationCode });
                        else if (parameter.guid !== 'null' && parameter.guid !== null && parameter.guid !== '') {
                            $state.go("Event", { guid: parameter.guid });
                        }
                        else if (parameter.zipCode !== null && parameter.zipCode !== 'null' && parameter.zipCode !== '')
                            $state.go("EventWithZipCode", { zipcode: parameter.zipCode });
                        else
                            $state.go("EventWithZipCode", { zipcode: '' });
                    }]
            })
            .state('EventWithZipCode', {
                url: '/Event/:zipcode',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/event/event.client.view.html',
                title: 'Search Event'
            })
            .state('EventWithInvitationCode', {
                url: '/Event/:invitationcode',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/event/event.client.view.html',
                title: 'Search Event'
            })
            .state('Event', {
                url: '/Event/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/event/event.client.view.html',
                title: 'Search Event'
            })
            .state('PreQualification', {
                url: '/question/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/prequalification/questions.client.view.html'
                , title: 'Risk Assessment'
            })
            .state('Package', {
                url: '/package/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/package/package.client.view.html',
                title: "Select Package"
            })
            //.state('Shipping', {
            //    url: '/delivery/:guid',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/shipping/shipping.client.view.html',
            //    title: 'Delivery Options'
            //})
            .state('Test', {
                url: '/test/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/test/test.client.view.html',
                title: 'Additional Screenings/Tests'
            })
            .state('Appointment', {
                url: '/appointment/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/appointment/appointment.client.view.html'
                , title: 'Make your Appointment (Time Selction)'
            })
            .state('RequestEvent', {
                url: '/requestevent/:zip',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/event/event.request.view.html'
                , title: 'Request Event'
            })
             .state('Customer', {
                 url: '/customer/:guid',
                 templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/customer/customer.client.view.html'
                 , title: 'Patient Information'
             })
            .state('Payment', {
                url: '/payment/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/payment/payment.client.view.html'
                , title: 'Payment Information'
            })
            .state('HealthAssessment', {
                url: '/HealthAssessment/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/healthassessment/healthassessment.client.view.html'
                , title: 'Health Assessment Questions'
            })
            .state('UpsellTests', {
                url: '/UpsellTests/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/upselltest/upselltest.client.view.html'
                , title: 'Upsell Tests'
            })
            .state('ThankYou', {
                url: '/thankyou/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/thankyou/thankyou.client.view.html'
                , title: 'Thank you'
            })
            .state('Confirmation', {
                url: '/confirmation/:guid',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/confirmation/confirmation.client.view.html'
                , title: 'Confirmation'
            });
        }])
        .run(['$rootScope', '$state', '$window', "usSpinnerService", function ($rootScope, $state, $window, usSpinnerService) {
            $rootScope.CheckoutPhoneNumber = ApplicationConfiguration.phoneTollFree;

            $rootScope.showProgressBar = false;
            $rootScope.showsummarybox = false;
            $rootScope.currentState = 0;

            $rootScope.$on("$stateChangeStart", function (event, to, toP, from, fromP) {
                usSpinnerService.spin('online-spinner');
            });

            $rootScope.$on('$stateChangeSuccess', function (event) {
                //if ($state.current.name != 'ThankYou') {
                    $window._gaq.push(['_setAccount', 'UA-8222763-2']);
                    $window._gaq.push(['_setDomainName', 'healthfair.com']);
                    $window._gaq.push(['_trackPageview']);
                //}
                $rootScope.showProgressBar = false;
                $rootScope.showsummarybox = false;

                if (typeof mouseflow != "undefined") {
                    mouseflow.newPageView();
                }
            });
        }]);
}());

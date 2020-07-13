(function () {
    'use strict';

    // Setting up route
    angular.module(CallCenterConfiguration.moduleName)
        .config(['$stateProvider', '$urlRouterProvider', '$httpProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $httpProvider, $locationProvider) {
            $httpProvider.interceptors.push('callcenterInterceptor');
            $urlRouterProvider.otherwise('/CallCenterDefault');

            $stateProvider.state('CallCenterDefault', {
                url: '/CallCenterDefault',
                template: '',
                controller: [
                    '$state', function ($state) {
                        $state.go("CallCentreDashboard");//,{isCallQueueSelected:"noQueuesSelected"});
                    }
                ]
            })
            .state('CallCentreDashboard', {
                url: '/dashboard',///:isCallQueueSelected',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplan/healthplan.dashboard.client.view.html',
                title: 'Search Prospect'
            })
            .state('fillEvents', {
                url: '/fillEvents',
                title: 'Search Prospect',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplanevents/healthplan.fill.event.view.client.html'
            })
            .state('healthplancampaigns', {
                url: '/healthPlanCampaigns',
                title: 'Search Prospect',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplancampaign/healthplan.campaign.view.client.html'
            })
            .state('healthplanContact', {
                url: '/healthplan/contact/:callQueueCustomerId/:attemptId',
                templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplan/healthplan.contact.client.view.html',
                title: 'Contact Screen'
            });
            //.state('callqueues', {
            //    url: '/callqueues',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/category/category.view.client.html',
            //    title: 'Search Prospect'
            //})
            //.state('EventFilled', {
            //    url: '/EventFilled/:categoryId',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/fillevent/fill.event.view.client.html',
            //    title: 'Search Prospect'
            //})
            //.state('SearchQueue', {
            //    url: '/callqueuecustomers',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/searchqueue/customer.queue.client.view.html',
            //    title: 'Search Prospect'
            //})
            //.state('Contact', {
            //    url: '/contact/:callQueueCustomerId/:callId',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/contact/contact.client.view.html',
            //    title: 'Contact Screen'
            //})
            //.state('healthplan', {
            //    url: '/healthplanDashboard',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplan/search.healthplan.client.view.html',
            //    title: 'Search Prospect'
            //})
            //.state('healthplanCategory', {
            //    url: '/healthplanCategory',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplan/healthplan.category.client.view.html',
            //    title: 'Search Prospect'
            //})

            //This state is opened after selecting EVENT or Campaign
            //.state('callround', {
            //    url: '/healthplan/callround',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/callround/callround.callqueue.client.view.html',
            //    title: 'Search Prospect'
            //})
            //.state('healthplanfillevents', {
            //    url: '/healthplan/fillevents',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplanevents/healthplan.fill.event.view.client.html',
            //    title: 'Search Prospect'
            //})
            //.state('healthplancampaigns', {
            //    url: '/healthplan/campaigns',
            //    templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/healthplancampaign/healthplan.campaign.view.client.html',
            //    title: 'Campaign List'
            //})
        }])
        .run(['$rootScope', "usSpinnerService", function ($rootScope, usSpinnerService) {
            $rootScope.$on("$stateChangeStart", function (event, to, toP, from, fromP) {
                usSpinnerService.spin('online-spinner');
            });
        }]);
}());

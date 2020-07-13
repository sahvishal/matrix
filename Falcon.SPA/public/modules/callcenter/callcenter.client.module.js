'use strict';

var CallCenterConfiguration = (function () {
    return {
        moduleName: "CallCenter",
        services: {
            searchQueueService: "SearchQueueService",
            contactService: "ContactService",
            authenticationTokenService: "authenticationTokenService",
            tagsDropdownHelper: "tagsDropdownHelper",
            callQueueCriteriaSerivce: "callQueueCriteriaSerivce",
            searchHealthPlanService: "searchHealthPlanService",
            healthPlanCallQueueCriteriaSerivce: "healthPlanCallQueueCriteriaSerivce",
            healthplanlocalstorage: 'healthplanlocalstorage'
        },
        controllers: {
            searchQueueController: 'SearchQueueController',
            contactController: 'ContactController',
            catergoryController: 'catergoryController',
            filledEventController: 'filledEventController',
            healthPlanCallQueue: 'healthPlanCallQueue',
            healthplanCatergoryController: 'healthplanCatergoryController',
            callroundqueuecController: 'callroundqueuecController',
            healthPlanContactController: 'healthPlanContactController',
            healthplanFilledEventController: 'healthplanFilledEventController',
            verifyInvitationController: 'verifyInvitationController',
            customerNotes: 'customerNotesController',
            healthplanCampaignClientController: 'healthplanCampaignClientController',
            eventPreviewModelController: 'EventPreviewModelController',
            saveSkipCallNotesController: 'SaveSkipCallNotesController',
            healthplanDashboardController: 'healthplanDashboardController',
            medicareController: 'medicareController',
            healthplanPreQualificationController: 'healthplanPreQualificationController',
        },
        directives: {
            customtoolTip: "customToolTip",
            pagingModel: "pagingModel",
            patientInfo: "patientInfo",
            eventlist: "eventList",
            fillEventCriteriaView: "fillEventCriteriaView",
            customerOrderDetail: "customerOrderDetail",
            customerPaymentDetail: "customerPaymentDetail",
            customerOrderSummary: "customerOrderSummary",
            upsellCallQueueCriteriaView: "upsellCallQueueCriteriaView",
            confirmationCallQueueCriteriaView: "confirmationCallQueueCriteriaView",
            callRoundCriteriaView: "callRoundCriteriaView",
            healthplanFillEventCriteriaView: 'healthplanFillEventCriteriaView',
            noShowCriteriaView: 'noShowCriteriaView',
            zipRadiusCriteriaView: 'zipRadiusCriteriaView',
            uncontactedCustomerCriteriaView: "uncontactedCustomerCriteriaView"
        }
    };
}());

// Use application configuration module to register a new module
ApplicationConfiguration.registerModule(CallCenterConfiguration.moduleName);


angular.module(CallCenterConfiguration.moduleName).factory("callcenterInterceptor", [CallCenterConfiguration.services.authenticationTokenService, function (authenticationTokenService) {

    var authenticationToken = authenticationTokenService.get();

    return {
        request: function (cfg) {
            cfg.headers["Auth-token"] = authenticationToken.token;
            cfg.headers['Cache-Control'] = "no-cache, no-store, must-revalidate";
            return cfg;
        }
    };


}]);
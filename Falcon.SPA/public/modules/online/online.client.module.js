'use strict';

var OnlineConfiguration = (function () {
    return {
        moduleName: "Online",
        services: {
            validateRequestService: "ValidateRequestService",
            eventService: "EventService",
            preQualificationService: "PreQualificationService",
            packageService: "PackageService",
            shippingService: 'ShippingService',
            testService: 'TestService',
            appointmentService: 'AppointmentService',
            customerService: 'CustomerService',
            healthAssessmentService: 'HealthAssessmentService',
            paymentService: 'PaymentService',
            upsellTestService: 'UpsellTestService',
            thankYouService: 'ThankYouService',
            confirmationService: 'ConfirmationService',
            progressbarService: "OnlineCheckoutProgressbarService",
            orderService: "OnlineCheckoutOrderService",
            eventParameterService: 'eventParameterService',
            localStorageProgressBarService: 'localStorageProgressBarService'

        },
        controllers: {
            eventController: 'EventController',
            packageController: 'PackageController',
            shippingController: 'ShippingController',
            testController: 'TestController',
            requestEventController: 'RequestEventController',
            prequalificationController: 'PrequalificationController',
            prequalificationDisclaimerController: 'PrequalificationDisclaimerController',
            appointmentController: 'AppointmentController',
            customerController: 'CustomerController',
            healthAssessmentController: 'HealthAssessmentController',
            paymentController: 'PaymentController',
            upsellTestController: 'UpsellTestController',
            thankYouController: 'ThankYouController',
            confirmationController: 'ConfirmationController'
            
        },
        directives: {
            gaugeView: "gaugeView", 
            testBox: "testBox",
            shippingBox: "shippingBox",
            productBox: "productBox",
            appointmentBox: "appointmentBox",
            hafParentRadio: "hafParentRadio",
            hafParentTextarea: "hafParentTextarea",
            hafParentTextbox: "hafParentTextbox",
            hafChildRadio: "hafChildRadio",
            hafChildCheckbox: "hafChildCheckbox",
            hafChildTextbox: "hafChildTextbox",
            hafModelPopup: "hafModelPopup",
            printableconfirmationview: 'printableConfirmationView',
            quantcast: 'quantcast',
            addressView: "addressView",
            progressbarView: "progressbarView",
            eventLocation: "eventLocation",
            orderSummary: "orderSummary",
            userNameValidator: "userNameValidator",
            orderSummaryRightPannel: "orderSummaryRightPannel",
            shippingOptions: "shippingOptions"
        }
    };
}());

// Use application configuration module to register a new module
ApplicationConfiguration.registerModule(OnlineConfiguration.moduleName);


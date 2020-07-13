(function() {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.eventService, ['onlineHttpWrapper' , function (onlineHttpWrapper) {
        var eventService = {};

        var getPropertyValue = function(propterty) {
            if (typeof propterty === "undefined" || propterty === "null" || propterty === "")
                return "";
            return propterty;
        };

        eventService.fetchEvents = function (filter) { 
            var endpoint = 'Scheduling/OnlineEvent/GetEvents?ZipCode=' + getPropertyValue(filter.zipCode) + '&Radius=' + getPropertyValue(filter.radius) + '&PageNumber=' + filter.pageNumber + "&OrderBy=" + getPropertyValue(filter.sortOrderBy) + "&InvitationCode=" + getPropertyValue(filter.invitationCode) + "&EventId=" + getPropertyValue(filter.eventId) + "&Guid=" + getPropertyValue(filter.guid);
            return onlineHttpWrapper.get(endpoint);
        };
        
        eventService.fetchTempCart = function (Guid) {
            var endpoint = 'Scheduling/OnlineEvent/GetTempcart?Guid=' + getPropertyValue(Guid);
            return onlineHttpWrapper.get(endpoint);
        };
        
        eventService.saveSelectedEvent = function (selectedEvent) {
            selectedEvent.RequestUrl = window.location.href;
            var endpoint = 'Scheduling/OnlineEvent/SaveSelectedEvent';
            return onlineHttpWrapper.post(endpoint, selectedEvent);
        };

        eventService.requestForEvents = function (customer) {
            var endpoint = 'Scheduling/OnlineCustomer/SaveProspectCustomer';
            return onlineHttpWrapper.post(endpoint, customer);
        }; 
         

        return eventService;
    }]);

}());


























var staticData = (function () {
    'use strict';
    
    var eventCart = {
        "Message": {
            "Message": "Request succeeded successfully.",
            "MessageType": 0
        },
        "Data": {
            "Events": [
              {
                  "EventId": 36199,
                  "EventDate": "2015-01-16T00:00:00",
                  "EventLocation": {
                      "StreetAddressLine1": "fdsfds",
                      "StreetAddressLine2": "",
                      "City": "Austin",
                      "State": "Texas",
                      "StateCode": "TX",
                      "Country": "USA",
                      "ZipCode": "78705"
                  },
                  "HostName": "Tst_Accpimt",
                  "DistanceFromZip": 0,
                  "TotalSlots": 28,
                  "MorningAvailableSlots": 0,
                  "AfternoonAvailableSlots": 0,
                  "EveningAvailableSlots": 0,
                  "AvailableSlots": 0,
                  "CorporateAccountName": null,
                  "CorporateAccountLogoPath": null,
                  "HasBreastCancer": false,
                  "SponsorImage": null,
                  "IsMarkedOffforSelection": false,
                  "EventType": 69,
                  "RegistrationMode": 2,
                  "IsFemaleOnly": false
              },
              {
                  "EventId": 36200,
                  "EventDate": "2015-01-16T00:00:00",
                  "EventLocation": {
                      "StreetAddressLine1": "fdsfds",
                      "StreetAddressLine2": "",
                      "City": "Austin",
                      "State": "Texas",
                      "StateCode": "TX",
                      "Country": "USA",
                      "ZipCode": "78705"
                  },
                  "HostName": "Tst_Accpimt",
                  "DistanceFromZip": 0,
                  "TotalSlots": 28,
                  "MorningAvailableSlots": 12,
                  "AfternoonAvailableSlots": 12,
                  "EveningAvailableSlots": 4,
                  "AvailableSlots": 28,
                  "CorporateAccountName": null,
                  "CorporateAccountLogoPath": null,
                  "HasBreastCancer": false,
                  "SponsorImage": null,
                  "IsMarkedOffforSelection": false,
                  "EventType": 68,
                  "RegistrationMode": 1,
                  "IsFemaleOnly": false
              },
              {
                  "EventId": 36201,
                  "EventDate": "2015-01-17T00:00:00",
                  "EventLocation": {
                      "StreetAddressLine1": "fdsfds",
                      "StreetAddressLine2": "",
                      "City": "Austin",
                      "State": "Texas",
                      "StateCode": "TX",
                      "Country": "USA",
                      "ZipCode": "78705"
                  },
                  "HostName": "Tst_Accpimt",
                  "DistanceFromZip": 0,
                  "TotalSlots": 28,
                  "MorningAvailableSlots": 12,
                  "AfternoonAvailableSlots": 12,
                  "EveningAvailableSlots": 4,
                  "AvailableSlots": 28,
                  "CorporateAccountName": null,
                  "CorporateAccountLogoPath": null,
                  "HasBreastCancer": false,
                  "SponsorImage": null,
                  "IsMarkedOffforSelection": false,
                  "EventType": 68,
                  "RegistrationMode": 1,
                  "IsFemaleOnly": false
              },
              {
                  "EventId": 36202,
                  "EventDate": "2015-01-18T00:00:00",
                  "EventLocation": {
                      "StreetAddressLine1": "fdsfds",
                      "StreetAddressLine2": "",
                      "City": "Austin",
                      "State": "Texas",
                      "StateCode": "TX",
                      "Country": "USA",
                      "ZipCode": "78705"
                  },
                  "HostName": "Tst_Accpimt",
                  "DistanceFromZip": 0,
                  "TotalSlots": 28,
                  "MorningAvailableSlots": 12,
                  "AfternoonAvailableSlots": 12,
                  "EveningAvailableSlots": 4,
                  "AvailableSlots": 28,
                  "CorporateAccountName": null,
                  "CorporateAccountLogoPath": null,
                  "HasBreastCancer": false,
                  "SponsorImage": null,
                  "IsMarkedOffforSelection": false,
                  "EventType": 68,
                  "RegistrationMode": 1,
                  "IsFemaleOnly": false
              },
              {
                  "EventId": 36203,
                  "EventDate": "2015-01-19T00:00:00",
                  "EventLocation": {
                      "StreetAddressLine1": "fdsfds",
                      "StreetAddressLine2": "",
                      "City": "Austin",
                      "State": "Texas",
                      "StateCode": "TX",
                      "Country": "USA",
                      "ZipCode": "78705"
                  },
                  "HostName": "Tst_Accpimt",
                  "DistanceFromZip": 0,
                  "TotalSlots": 28,
                  "MorningAvailableSlots": 12,
                  "AfternoonAvailableSlots": 12,
                  "EveningAvailableSlots": 4,
                  "AvailableSlots": 28,
                  "CorporateAccountName": null,
                  "CorporateAccountLogoPath": null,
                  "HasBreastCancer": false,
                  "SponsorImage": null,
                  "IsMarkedOffforSelection": false,
                  "EventType": 68,
                  "RegistrationMode": 1,
                  "IsFemaleOnly": false
              }
            ],
            "TempCart": {
                "Id": 1,
                "Guid": "f45ab5f0-dfb5-4e83-818a-97ffb0eaf26f",
                "ZipCode": "60612",
                "EventId": 25968,
                "AppointmentId": 1391801,
                "EventPackageId": 79080,
                "TestId": "",
                "ProductId": "",
                "Shippingid": "",
                "PaymentMode": "",
                "PaymentAmount": "",
                "IsPaymentSuccessful": "",
                "IsHafFilled": "",
                "EntryPage": "",
                "ExitPage": "",
                "IPAddress": "",
                "ScreenResolution": "",
                "Browser": "",
                "IsCompleted": "",
                "IsExistingCustomer": "",
                "LoginAttempt": "",
                "DateCreated": "",
                "DateModified": "",
                "ShippingAddressId": "",
                "InvitationCode": "",
                "CorpCode": "",
                "IsUsedAppointmentSlotExpiryExtension": "",
                "Radius": "25.00",
                "MarketingSource": "",
                "InChainAppointmentSlots": "",
                "PreliminarySelectedTime": "",
                "Gender": "Male",
                "Dob": "1950-01-10 00:00:00.000",
                "Version": "",
                "EligibilityId": "",
                "ChargeCardId": "",
                "HighBloodPressure": "",
                "Smoker": "",
                "HeartDisease": "",
                "Diabetic": "",
                "ChestPain": "",
                "DiagnosedHeartProblem": "",
                "HighCholestrol": "",
                "OverWeight": "",
                "AgreedWithPrequalificationQuestion": "",
                "SkipPreQualificationQuestion": "",
                "AgeOverPreQualificationQuestion": ""
            },
            "TotalEvents": 7,
            "PagingModel": {
                "PageSize": 5,
                "NumberOfItems": 7,
                "PageUrl": null,
                "CurrentPage": 1,
                "PageCount": 2,
                "PageSpan": 3
            },
            "RequestStatus": 4
        },
        "IsFeedbackSet": true
    };
    
    return {
        onlinePackgeModel: eventCart
    }

}());
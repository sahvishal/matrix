(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).factory(CallCenterConfiguration.services.tagsDropdownHelper, [
         function () {
             var tagsDropdownHelper = {};
             tagsDropdownHelper.get = function () {

                 var tags = [
                      { value: "", text: "-- Select --" },
                     { value: "OnlineSignup", text: "Online Registration" },
                     { value: "CallCenterSignup", text: "CallCenter Registration" },
                     { value: "NotServicedZip", text: "Non-Serviced Zip code" },
                     { value: "InsuranceConcerns", text: "Insurance concerns" },
                     { value: "PricingConcerns", text: "Pricing concerns" },
                     { value: "NoEventsInTheArea", text: "No events in the area" },
                     { value: "MorningAppointmentPreferred", text: "Morning appointment preferred" },
                     { value: "AfternoonAppointmentPreferred", text: "Afternoon appointment preferred" },
                     { value: "Cancellation", text: "Cancellation" },
                     { value: "NoShow", text: "No Show" },
                     { value: "AllEventsFull", text: "All Events Full" },
                     { value: "DoctorConcerns", text: "Doctor Concerns" },
                     { value: "PoorLocation", text: "Poor Location" },
                     { value: "SurveyResponse", text: "Survey Response" },
                     { value: "IndecisiveUndecided", text: "Indecisive/Undecided" }

                 ];

                 return tags;

             };
             
             tagsDropdownHelper.getHealthPlanTag = function () {

                 var tags = [
                      { value: "", text: "-- Select --" },
                     { value: "OnlineSignup", text: "Online Registration" },
                     { value: "CallCenterSignup", text: "CallCenter Registration" },
                     { value: "NotServicedZip", text: "Non-Serviced Zip code" },
                     { value: "InsuranceConcerns", text: "Insurance concerns" },
                     { value: "PricingConcerns", text: "Pricing concerns" },
                     { value: "NoEventsInTheArea", text: "No events in the area" },
                     { value: "MorningAppointmentPreferred", text: "Morning appointment preferred" },
                     { value: "AfternoonAppointmentPreferred", text: "Afternoon appointment preferred" },
                     { value: "Cancellation", text: "Cancellation" },
                     { value: "NoShow", text: "No Show" },
                     { value: "AllEventsFull", text: "All Events Full" },
                     { value: "DoctorConcerns", text: "Doctor Concerns" },
                     { value: "PoorLocation", text: "Poor Location" },
                     { value: "SurveyResponse", text: "Survey Response" },
                     { value: "IndecisiveUndecided", text: "Indecisive/Undecided" }

                 ];

                 return tags;

             };

             return tagsDropdownHelper;

         }]);
}());
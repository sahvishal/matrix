(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.appointmentService, ['onlineHttpWrapper', function (onlineHttpWrapper) {
        var appointmentService = {};


        appointmentService.GetEventAppointmentSlotOnline = function (guid) {
            var endpoint = 'Scheduling/OnlineAppointment/GetEventAppointmentSlotOnline?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        appointmentService.SaveEventAppointmentSlotOnline = function (guid, selectedSlotId) {
            var data = {
                SelectedSlotId: selectedSlotId,
                Guid: guid
            };

            var endpoint = 'Scheduling/OnlineAppointment/SaveEventAppointmentSlotOnline';
            
            return onlineHttpWrapper.post(endpoint, data);
        };

        return appointmentService;
    }]);
}());


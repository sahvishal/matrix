(function () {
    'use strict';
    angular.module(ApplicationConfiguration.applicationModuleName).factory(OnlineConfiguration.services.eventParameterService, ['$stateParams', '$localStorage', function (stateParams, localStorage) {

        return {
            get: function () {

                return {
                    zipCode: localStorage.zipCode,
                    radius: localStorage.radius,
                    distance: localStorage.distance,
                    guid: localStorage.guid,
                    eventId: localStorage.eventId,
                    cpncd: localStorage.cpncd,
                    invitationCode: localStorage.invitationCode,
                    corpcode: localStorage.corpcode
                };
            },

            set: function (urlObject) {
                localStorage.$reset();
                localStorage.$default({
                    zipCode: urlObject.zipCode,
                    radius: urlObject.radius,
                    distance: urlObject.distance,
                    guid: urlObject.guid,
                    eventId: urlObject.eventId,
                    cpncd: urlObject.cpncd,
                    invitationCode: urlObject.invitationCode,
                    corpcode: urlObject.corpcode
                });
            },
            updateWithTempcart: function (tempCart) {
                localStorage.$reset();
                localStorage.$default({
                    zipCode: tempCart.ZipCode,
                    radius: tempCart.Radius,
                    distance: tempCart.Distance,
                    guid: tempCart.Guid,
                    eventId: tempCart.EventId,
                    invitationCode: tempCart.InvitationCode,
                    corpcode: tempCart.CorpCode,
                    cpncd: tempCart.SourceCodeId
                });
            }
        };
    }]);
}());
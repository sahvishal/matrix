(function () {
    angular.module(OnlineConfiguration.moduleName).service("onlineHttpWrapper", ["httpWrapper", CoreConfiguration.constants, '$location', '$state', '$http', function (hw, constants, $location, $state, $http) {

        var parseRequestStatus = function (requestValidationModel) {
            var requestStatus = requestValidationModel.RequestStatus;
            var tempCart = requestValidationModel.TempCart;
            var endpoint = ApplicationConfiguration.remoteServiceUrl + 'Scheduling/OnlineEvent/UpdateExitUrl';
            var data = {}

            if (typeof requestStatus === "undefined" || requestStatus === null || requestStatus == constants.RequestStatus.InvalidOperation) {
                if (typeof tempCart != 'undefined' && tempCart != null && tempCart.ExitPage != '') {
                    $location.url(tempCart.EntryPage.split("#")[1]);
                }
            } else if (requestStatus == constants.RequestStatus.InValid) {
                if (typeof tempCart != 'undefined' && tempCart != null && tempCart.ExitPage != '') {
                    window.location.href = ApplicationConfiguration.siteUrl;
                }
            }
            else if (requestStatus == constants.RequestStatus.Completed) {
                var stateName = $state.current.name;

                if (stateName != "HealthAssessment" && stateName != "ThankYou" && stateName != "Confirmation") {
                    if (typeof tempCart != 'undefined' && tempCart != null && tempCart.ExitPage != '') {
                        $location.url(tempCart.ExitPage.split("#")[1]);
                    }
                } else {
                    data = { PageUrl: window.location.href, Guid: tempCart.Guid };
                    return $http.post(endpoint, data);
                }
            } else if (requestStatus == constants.RequestStatus.Valid) {
                if (typeof tempCart != 'undefined' && tempCart != null && tempCart.Guid != '') {
                    data = { PageUrl: window.location.href, Guid: tempCart.Guid };
                    return $http.post(endpoint, data);
                }
            }
        };

        var cbOnBeforeSuccess = function (result) {
            if (result.Data.RequestValidationModel != null)
                parseRequestStatus(result.Data.RequestValidationModel);
        };

        var cbOnBeforeError = function (result) {
            if (result != null && result.Data != null && result.Data.RequestValidationModel != null)
                parseRequestStatus(result.Data.RequestValidationModel.RequestStatus);
        };

        return {
            get: function (url) {
                return hw.get({ url: url, onBeforeSuccess: cbOnBeforeSuccess, onBeforeError: cbOnBeforeError });
            },
            post: function (url, data) {
                return hw.post({ url: url, data: data, onBeforeSuccess: cbOnBeforeSuccess, onBeforeError: cbOnBeforeError });
            },
        };

    }]);
}());
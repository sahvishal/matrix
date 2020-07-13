(function () {
    'use script';

    angular.module(ApplicationConfiguration.applicationModuleName).controller(OnlineConfiguration.controllers.prequalificationDisclaimerController, ['$scope', 'data', '$state', OnlineConfiguration.services.preQualificationService, function ($scope, data, $state, preQualificationService) {

        $scope.Message = data.DisclaimerModal.Message;
        $scope.Title = data.DisclaimerModal.Title;
        $scope.showSkipLink = data.DisclaimerModal.showSkipLink;
        $scope.showSkipOption = data.DisclaimerModal.showSkipOption;
        $scope.isAgreed = false;

        $scope.hafPopupButtons = data.DisclaimerModal.hafPopupButtons;

        $scope.close = function () {
            if (data.DisclaimerModal.RedirectToSiteUrl) {
                window.location = ApplicationConfiguration.siteUrl;
                $scope.isAgreed = true;
            }
            else {
                $scope.isAgreed = true;
                preQualificationService.UpdateUserPrefrenceWithPrequalificationQuestion(data.DisclaimerModal.guid);
                $state.go('Package', { guid: data.DisclaimerModal.guid });
            }
            $scope.$close();
        };

        $scope.Cancel = function () {
            $scope.$close();
        }

        $scope.OKbutton = function () {
            $scope.isAgreed = true;
            $scope.$close();
        }

        $scope.skipOption = function () {
            window.location = ApplicationConfiguration.siteUrl;
           // $scope.$close();
        };
        $scope.$on('$destroy', function () {
            if (typeof (data.DisclaimerModal.onCloseCallBack) == 'function') {
                data.DisclaimerModal.onCloseCallBack($scope.isAgreed);
            }

        });

    }]);
})();
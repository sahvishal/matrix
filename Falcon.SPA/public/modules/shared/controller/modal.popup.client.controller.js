(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).controller(SharedConfiguration.controller.modalPopupController, ['$scope', 'data', function ($scope, data) {
        $scope.modal = {};
        $scope.modal.showTitle = false;
        $scope.modal.showCancelButton = false;
        $scope.modal.showOKButtonButton = true;
        $scope.closeOnEscape = true;
        $scope.modal = data; 

        $scope.IsOkButtonclicked = false;
        $scope.IsCancelButtonclicked = false;

        $scope.onOkbutton = function () { 
            $scope.IsOkButtonclicked = true;
            $scope.$close();
        };

        $scope.onCancelButton = function () { 
            $scope.IsCancelButtonclicked = true;
            $scope.$close();
        };

        $scope.$on('$destroy', function () {
            if ($scope.IsOkButtonclicked && typeof ($scope.modal.CallBackOnOkButton) !== 'undefined' && $scope.modal.CallBackOnOkButton != null && typeof ($scope.modal.CallBackOnOkButton) === 'function') {
                $scope.modal.CallBackOnOkButton();
            } else if ($scope.IsCancelButtonclicked && typeof ($scope.modal.CallBackOnCancelButton) !== 'undefined' && $scope.modal.CallBackOnCancelButton != null && typeof ($scope.modal.CallBackOnCancelButton) === 'function') {
                $scope.modal.CallBackOnCancelButton();
            } else if ($scope.closeOnEscape && typeof ($scope.modal.CallBackOnEscape) !== 'undefined' && $scope.modal.CallBackOnEscape != null && typeof ($scope.modal.CallBackOnEscape) === 'function') {
                $scope.modal.CallBackOnEscape();
            } 
        }); 
    }]);
})();
(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.saveSkipCallNotesController,
    ['$scope', '$modalInstance', 'logger', function ($scope, $modalInstance, logger) {

        $scope.SkipCallNotes = '';

        $scope.Cancel = function () {
            $modalInstance.dismiss();
        }

        $scope.Save = function () {
            if ($scope.SkipCallNotes != null && $scope.SkipCallNotes != '') {
                $modalInstance.close($scope.SkipCallNotes);
            } else {
                logger.showToasterError('Please provide notes for skip call.');
            }
        }
    }]);

}());
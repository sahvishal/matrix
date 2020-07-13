(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.verifyInvitationController,
    ['$scope', 'data', 'logger',
	function ($scope, data, logger) {
	    $scope.InvitationCode = '';

	    $scope.Verify = function () {

	        if ($scope.InvitationCode.toLowerCase() == data.Event.InvitationCode.toLowerCase()) {
	            data.CallBack(data.Event);
	            $scope.$close();
	        } else {
	            logger.showToasterError('You had enter the wrong invitation code.<br> Please enter correct invitation code and try again.');
	        }
	    };
	    $scope.Cancel = function() {
	        $scope.$close();
	    };
	}]);
}());
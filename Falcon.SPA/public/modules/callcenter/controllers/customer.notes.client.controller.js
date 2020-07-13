(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.customerNotes,
    ['$scope', 'data',  function ($scope, data) {
        $scope.customerNotes = data.CustomerNotes;
        console.log($scope.customerNotes);
	    $scope.Cancel = function () {
	        $scope.$close();
	    }
        
	}]);

}());
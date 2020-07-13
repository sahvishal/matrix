(function () {
    'use script';

    angular.module(ApplicationConfiguration.applicationModuleName).controller(SharedConfiguration.controller.validationResultsController, ['$scope', 'data', function ($scope, data) {

        $scope.validations = data.validationList;

        $scope.close = function () {
            $scope.$close();
        };

    }]);
})();
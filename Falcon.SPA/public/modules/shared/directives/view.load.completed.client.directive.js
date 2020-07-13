(function () {
    'use strict';
    
    angular.module(ApplicationConfiguration.applicationModuleName).directive('viewLoadCompleted', function () {
        return {
            restrict: 'A',
            link: function($scope, $elem, attrs) {

                $scope.$on('$viewContentLoaded', function () {
                    //required to show placeholder in IE9
                    $('input, textarea').placeholder();
                });
            }
        };
    });
}());
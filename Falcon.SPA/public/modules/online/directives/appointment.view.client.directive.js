(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).directive(OnlineConfiguration.directives.appointmentBox, function () {
        return {
            restrict: 'AE',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/online/views/appointment/appointmentBox.client.view.html',
            scope: {
                slotdetail: '=',
                radiogroupname: '@',
                select: '&selectmethod'
            },
            controller: ['$scope', function ($scope) { 
                $scope.selectThisOption = function () {
                    // if ($scope.slotdetail.isChecked) {
                    $scope.select();
                    //}
                };
            }]
        };
    });
}());
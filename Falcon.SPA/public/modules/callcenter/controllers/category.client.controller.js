(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.catergoryController,
    ['$scope', '$state', 'usSpinnerService', CallCenterConfiguration.services.searchQueueService, CoreConfiguration.constants,
        function ($scope, $state, usSpinnerService, searchQueueService, constants) {
            $scope.category = null;
            $scope.CallQueueCategory = constants.CallQueueCategory;

            function init() {

                localStorage.removeItem('CallQueueId');
                localStorage.removeItem('Name');
                localStorage.removeItem('PhoneNumber');
                localStorage.removeItem('ZipCode');
                localStorage.removeItem('EventId');
                localStorage.removeItem('Tag');
                localStorage.removeItem('IsPopUpShown');

                searchQueueService.GetCallQueueCategories().then(function (result) {
                    $scope.category = result;

                    setTimeout(function () {
                        usSpinnerService.stop('online-spinner');
                    }, 1000);

                }, function () {
                    usSpinnerService.stop('online-spinner');
                });
            }

            $scope.SelectCategory = function(category) {
                if (category.Category == $scope.CallQueueCategory.FillEvents) {
                    $state.go('EventFilled', { categoryId: category.CallQueueId });

                } else {
                    window.localStorage.setItem('CallQueueId', category.CallQueueId);
                    $state.go("SearchQueue");
                }
            };

            $scope.numtoWord = function (num) {
                switch (num) {
                    case 1: return 'one';
                    case 2: return 'two';
                    case 3: return 'three';
                    case 4: return 'four';
                    case 5: return 'five';
                    case 6: return 'Six';
                }
                return "";
            };
            init();
        }]);

}());
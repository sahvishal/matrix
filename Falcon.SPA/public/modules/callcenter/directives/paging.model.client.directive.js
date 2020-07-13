(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.pagingModel, function () {
        return {
            restrict: 'E',
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/shared/paging.model.view.client.directive.html',
            scope: {
                model: '=',
                url: '&'
            },
            controller: ['$scope', function ($scope) {
                $scope.GetPages = function () {
                    var list = new Array();
                    for (var pageNumber = 1; pageNumber <= $scope.model.PageCount; pageNumber++) {
                        if ($scope.IsPageIncluded(pageNumber)) {
                            list.push(pageNumber);
                        }
                    }
                    return list;
                }

                $scope.IsPageIncluded = function (pageNumber) {
                    return (pageNumber <= $scope.model.PageSpan)
                        || (pageNumber > $scope.model.PageCount - $scope.model.PageSpan || (Math.abs(pageNumber - $scope.model.CurrentPage) < $scope.model.PageSpan));
                }
                $scope.PageUrl = function (pageNumber) {
                    $scope.number = pageNumber;
                    if (typeof ($scope.url) === 'function') {
                        $scope.url({ number: pageNumber });
                    }
                }
            }]
        }
    });
}());
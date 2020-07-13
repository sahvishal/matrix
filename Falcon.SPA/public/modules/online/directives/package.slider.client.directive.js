(function () {
    angular.module(OnlineConfiguration.moduleName).directive("contentCarousel", function () {
        return {
            restrict: 'A',
            scope: true,
            link: function (scope, element, attrs) {

                if (scope.$last === true) {
                    element.ready(function () {

                        $('.ca-container').contentcarousel('init', {
                            infinite: false,
                            onNextClick: function () {
                                var sIndex = scope.DisplayPackage.Second;
                                var fIndex = scope.DisplayPackage.First;

                                if (sIndex != -1 && scope.allPackageCount > 2) {
                                    scope.DisplayPackage.First = sIndex;

                                    if (sIndex == (scope.allPackageCount - 1)) {
                                        sIndex = 0;
                                    } else {
                                        sIndex = sIndex + 1;
                                    }
                                    if (fIndex == (scope.allPackageCount - 1)) {
                                        fIndex = 0;
                                    } else {
                                        fIndex = fIndex + 1;
                                    }

                                    scope.DisplayPackage.First = fIndex;
                                    scope.DisplayPackage.Second = sIndex;

                                    scope.NextPackageInfo();
                                    scope.PrevPackageInfo();

                                    scope.$apply();
                                }
                            }, onPrevClick: function () {

                                var fIndex = scope.DisplayPackage.First;
                                var sIndex = scope.DisplayPackage.Second;

                                if (scope.allPackageCount > 2) {
                                    scope.DisplayPackage.Second = fIndex;

                                    if (sIndex == 0) {
                                        sIndex = scope.allPackageCount - 1;
                                    } else {
                                        sIndex = sIndex - 1;
                                    }

                                    if (fIndex == 0) {
                                        fIndex = 0;
                                    } else {
                                        fIndex = fIndex - 1;
                                    }

                                    scope.DisplayPackage.First = fIndex;
                                    scope.DisplayPackage.Second = sIndex;

                                    scope.NextPackageInfo();
                                    scope.PrevPackageInfo();

                                    scope.$apply();
                                }
                            }
                        });
                    });
                }
            }
        };
    });
}());
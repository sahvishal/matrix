(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.customtoolTip, function () {
        return {
            restrict: 'A',
            scope: {
                toolTipHeader: '@',
                toolTipContainer: '@'
            },

            compile: function(telement, tAttrs, transclude) {
                return {
                    post: function(scope, element, attributes, controller, transcludeFn) {
                        $(element).qtip({
                            position: {
                                my: 'left bottom'
                            },
                            content: {
                                title: scope.toolTipHeader,
                                text: function() {
                                    return $(element).parent().find("." + scope.toolTipContainer).html();
                                }
                            }
                        });
                    }
                };
            }
        };
    });
}());
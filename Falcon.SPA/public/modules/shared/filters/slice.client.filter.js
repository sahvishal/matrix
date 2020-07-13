(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).filter(SharedConfiguration.filters.slice, function () {
        return function (array, start, end) {
            return (array || []).slice(start, end);
        };
    });
}());
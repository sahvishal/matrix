(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).service('analytics', ['$rootScope', '$window', '$location', function ($rootScope, $window, $location) {
      //debugger;
        var track = function () {
            
            if ($window.ga) {
                $window.ga('set', 'page', $location.path());
                $window.ga('send', 'pageview');
            }
         // debugger;
           // $window.ga.push(['_trackPageview', $location.path()]);
            //ga('send', 'pageview', { page: $location.url() });
        };
        $rootScope.$on('$viewContentLoaded', track);
    }]);
}());
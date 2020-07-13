(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).directive(CallCenterConfiguration.directives.callRoundCriteriaView, [function () {

        return {
            restrict: 'E',
            scope: {
                model: '='
            },
            templateUrl: ApplicationConfiguration.domainUrl + 'public/modules/callcenter/views/callround/callround.callqueue.criteria.view.client.html',
            controller: ['$scope', function ($scope) {

               

                $scope.LastCallMadeText = function (model) {
                    var lastCallMade = [
                        { text: '0-3 Days', value: 3 },
                        { text: '4-6 Days', value: 6 },
                        { text: '1 Week or More', value: 7 },
                        { text: '2 Week or More', value: 15 },
                        { text: 'More Than a Month', value: 31 }
                    ];
                    var selectedDays = "";
                    $.each(lastCallMade, function (index, item) {
                        if (model != null && item.value == model.NoOfDays) {
                            selectedDays = lastCallMade[index].text;
                        }
                    });
                    return selectedDays;
                };
                
                $scope.CallRoundText = function (model) {
                    var lastCallRounds = [
                                { text: 'Never been called', value: 0 },
                                { text: '1', value: 1 },
                                { text: '2', value: 2 },
                                { text: '3', value: 3 },
                                { text: '4', value: 4 },
                                { text: '5', value: 5 },
                                { text: '6', value: 6 },
                                { text: '7', value: 7 },
                                { text: '8', value: 8 },
                                { text: '9', value: 9 },
                                { text: '10', value: 10 }

                    ];
                    var selectedDays = "";
                    $.each(lastCallRounds, function (index, item) {
                        if (model != null  && item.value == model.RoundOfCalls) {
                            selectedDays = lastCallRounds[index].text;
                        }
                    });
                    
                    return selectedDays;
                };

               
            }]
        };
    }]);
}());
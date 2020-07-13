(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).factory(SharedConfiguration.services.datePickerService, [function () {
        var datePickerService = {};

        scope.MonthDropwdown = new Array();
        scope.DaysDropwdown = new Array();
        scope.YearDropwdown = new Array();

        scope.Month = {
            value: 1,
            text: 1
        };

        scope.Year = {
            value: 1950,
            text: 1950
        };
        scope.Day = {
            value: 1,
            text: 1
        };

        scope.NumberOfMonth = function () {
            for (var monthIndex = 1; monthIndex < 13; monthIndex++) {
                var month = { value: monthIndex, text: monthIndex };
                scope.MonthDropwdown.push(month);
            }
        };

        scope.GetNumberOfDaysInMonth = function () {
            var getNumberofDaysinMonth = new Date(scope.Year.value, scope.Month.value, 0).getDate();
            scope.DaysDropwdown = new Array();
            for (var dayIndex = 1; dayIndex <= getNumberofDaysinMonth; dayIndex++) {
                var day = { value: dayIndex, text: dayIndex };
                scope.DaysDropwdown.push(day);
            }
        };

        scope.GetNumberYear = function () {
            var currentYear = new Date().getFullYear();
            for (var yearIndex = currentYear - 100; yearIndex <= currentYear; yearIndex++) {
                var year = { value: yearIndex, text: yearIndex };
                scope.YearDropwdown.push(year);
            }
        };
        scope.ResetDayForInvalidDate = function () {
            if (scope.IsInvalidDate() == true) {
                alert("Date of Birth entered is invalid. Please select again.");
                scope.Day = {
                    value: '1',
                    text: '1'
                };
            }
        };

        scope.IsInvalidDate = function () {
            var isDateValid = false;
            $.each(scope.DaysDropwdown, function (index, obj) {
                if (obj.value == scope.Day.value) {
                    isDateValid = true;
                }
            });
            return isDateValid == false;
        };


        scope.MonthChange = function () {
            scope.GetNumberOfDaysInMonth();
            scope.ResetDayForInvalidDate();
        };

        scope.YearChange = function () {
            scope.GetNumberOfDaysInMonth();
            scope.ResetDayForInvalidDate();
        };

        datePickerService.GetDate = function (date) {
            scope.GetNumberYear();
            scope.NumberOfMonth();
            scope.GetNumberOfDaysInMonth();

            if (typeof date != 'undefined' && date != null) {
                var birthDate = date;
                scope.BirthDate = moment(birthDate, "YYYY-MM-DD").format("MM/DD/YYYY");

                scope.Day = {
                    value: parseInt(moment(birthDate, "YYYY-MM-DD").format("D")),
                    text: parseInt(moment(birthDate, "YYYY-MM-DD").format("D"))
                };
                scope.Year = {
                    value: parseInt(moment(birthDate, "YYYY-MM-DD").format("YYYY")),
                    text: parseInt(moment(birthDate, "YYYY-MM-DD").format("YYYY"))
                };
                scope.Month = {
                    value: parseInt(moment(birthDate, "YYYY-MM-DD").format("M")),
                    text: parseInt(moment(birthDate, "YYYY-MM-DD").format("M"))
                };
            }

            return moment($scope.Year.value + "-" + $scope.Month.value + "-" + $scope.Day.value, "YYYY-MM-DD").format("YYYY-MM-DD");
        };

        return datePickerService;
    }]);
}());
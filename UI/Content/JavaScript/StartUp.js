$(document).ready(function () {
    setDatePicker();

    $.ajaxSetup({
        cache: false
    });
});


function setDatePicker() {
    $(".datePicker").val(function (index, value) { return value.indexOf(" ") > 0 ? value.substr(0, value.indexOf(" ")) : value; }).datepicker({ changeMonth: true,
        changeYear: true
    });

    var currentDate = new Date();
    $(".datePicker-dob").val(function (index, value) { return value.indexOf(" ") > 0 ? value.substr(0, value.indexOf(" ")) : value; }).datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: ("1900:" + currentDate.getFullYear()),
        defaultDate: new Date("01/01/1950"),
        maxDate: currentDate,
        minDate: new Date("01/01/1900")
    });
}
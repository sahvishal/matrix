function IsValidDate(sDate)
{
    var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/
    if (re.test(sDate))
    {
        var dArr = sDate.split("/");
        var d = new Date(sDate);
        return d.getMonth() + 1 == dArr[0] && d.getDate() == dArr[1] && d.getFullYear() == dArr[2];
    }
    return false;
}

function ValidateDateRangeControls(startDateField, endDateField)
{
    var startDate = startDateField.val();
    var endDate = endDateField.val();
    
    if (startDate == '')
    {
        alert('Please enter a start date.');
        startDateField.focus();
        return false;
    }
    else if (!IsValidDate(startDate)) 
    {
        alert('Please enter a valid start date.');
        startDateField.focus();
        return false;
    }
    else if (endDate == '')
    {
        alert('Please enter an end date.');
        endDateField.focus();
        return false;
    }
    else if (!IsValidDate(endDate)) 
    {
        alert('Please enter a valid end date.');
        endDateField.focus();
        return false;
    }
    else 
    {
        return true;
    }
}

function FormatTimestamp(timestamp)
{
    var date = new Date(timestamp);
    return (1+date.getMonth())    + "/" // Javascript months are 0-based
             + date.getDate()     + "/" // GetDate is of course 1-based
             + date.getFullYear() + " "
             + date.getHours()    + ":"
             + date.getMinutes().toString(10).rset(2, '0');
}
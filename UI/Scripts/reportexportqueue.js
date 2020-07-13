
function requestReport(url, ctrlRef,totalRecords) {
    var maxLimit = 100000;

    if (totalRecords > maxLimit) {
        alert("Please contact support@healthfair.com");
        return;
    }
    
    $.ajax({
        url: url,
        type: 'Post',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            //  debugger;
            if (result != null) {
                if (result.IsQueued) {
                    //alert(result.Message);
                    $("#" + ctrlRef).addClass("success-message");
                    $("#" + ctrlRef).html("Your export to CSV request has been queued. You will be notified by an email once it is completed.");
                } else {
                    //alert(result.Message);
                    $("#" + ctrlRef).addClass("error-message");
                    $("#" + ctrlRef).html("Some error occured while processing your request for export to CSV.");
                }
                $("#" + ctrlRef).show();
            }
            return false;
        },
        error: function (arg1, arg2) {
            return false;
        }
    });
}
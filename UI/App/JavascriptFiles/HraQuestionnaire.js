var hraQuestionerAppUrl = '';
var organizationNameForHraQuestioner = '';
var corporateAccountTag = '';
var hraToken = '';
var eventId = 0;
var updatetheStatus = false;
var isCustomerHistory = false;
function initiateHraQuestionare(url, name, tag, token, evtId, updatetheStatusOnClose, isCustHistory) {
    hraQuestionerAppUrl = url;
    organizationNameForHraQuestioner = name;
    corporateAccountTag = tag;
    hraToken = token;
    eventId = evtId;
    window.removeEventListener("message", updateVisit);
    window.addEventListener("message", updateVisit, false);
    updatetheStatus = updatetheStatusOnClose;
    if (isCustHistory)
        isCustomerHistory = true;
    else
        isCustomerHistory = false;
}

function updateVisit(event) {
    if (event.data.Action == 'UpdateVisit') {
        setVisitId(event.data.CustomerId, eventId, event.data.VisitId);
    } else if (event.data.Action == 'ClosePopupWindow') {
        $.colorbox.close();
    }
}


function addColorBox(eventCustomerId, customerId, visitId) {

    var url = hraQuestionerAppUrl + "?userToken=" + hraToken + "&customerId=" + customerId + "&orgName=" + organizationNameForHraQuestioner + "&tag=" + corporateAccountTag + "&visitId=" + visitId;
    // console.log(url);
    //$("#hraLink_" + eventCustomerId).attr('href', url);
    $("#hraLink_" + eventCustomerId).colorbox({
        iframe: true, width: "100%", height: "100%", href: url, onClosed: function () {
            $.colorbox.close();
            if (visitId != undefined) {
                $.ajax({
                    url: '/CallCenter/CallQueue/UnlockMedicarePatient?visitId=' + visitId,
                    type: 'GET',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (result) {

                    },
                    error: function (a, b, c) {
                        console.log('Patient Unlock failed in EHR');
                    }
                });
            }
            if (updatetheStatus == true) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "html", url: "/CallCenter/CallQueue/UpdateVisitStatus?visitId=" + visitId + "&status=4&unlock=false",

                    success: function (result) { },
                    error: function (a, b, c) {
                        if (a.status == 401) {
                            console.log("Error update while Medicare Updating Visit Status");
                        }
                    }
                });
            }
        }
    });

}

function addColorBoxCustomerHistory(eventCustomerId, customerId, visitId) { // updateOnyIfNotCancelledOrNoshow is additional in this function

    var url = hraQuestionerAppUrl + "?userToken=" + hraToken + "&customerId=" + customerId + "&orgName=" + organizationNameForHraQuestioner + "&tag=" + corporateAccountTag + "&visitId=" + visitId;
    // console.log(url);
    $("#hraLink_" + eventCustomerId).colorbox({
        iframe: true, width: "100%", height: "100%", href: url, onClosed: function () {
            $.colorbox.close();
            if (visitId != undefined) {
                $.ajax({
                    url: '/CallCenter/CallQueue/UnlockMedicarePatient?visitId=' + visitId,
                    type: 'GET',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (result) {

                    },
                    error: function (a, b, c) {
                        console.log('Patient Unlock failed in EHR');
                    }
                });
            }
            if (updatetheStatus == true) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "html", url: "/CallCenter/CallQueue/UpdateVisitStatus?visitId=" + visitId + "&status=4&unlock=false&updateAccordinglyIfCancelledOrNoshow=true",

                    success: function (result) { },
                    error: function (a, b, c) {
                        if (a.status == 401) {
                            console.log("Error update while Medicare Updating Visit Status");
                        }
                    }
                });
            }
        }
    });

}

function setVisitId(customerId, eventId, visitId) {
    $("#medicareVisitId").val(visitId);
    $.ajax({
        url: '/Scheduling/EventCustomerList/UpdateCustomerVisitInfo?customerId=' + customerId + "&visitId=" + visitId + "&eventId=" + eventId,
        type: 'POST',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (result) {
            $("#hravisitId_" + result).val(visitId);
            if (isCustomerHistory) {
                addColorBoxCustomerHistory(result, customerId, visitId);
            } else {
                addColorBox(result, customerId, visitId);
            }
        },
        error: function (a, b, c) {
            console.log('Some error Occurred while updating AWV Visit Id');
        }
    });
};

function checkSession() {
    var dfd = jQuery.Deferred();
    $.ajax({
        url: '/CallCenter/CallQueue/MedicarePopupSessionCheck',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (result, textStatus, errorThrown) {
            if (result == 'false' || result == 'False') {
                dfd.reject("Session expired");
            } else {
                dfd.resolve("true");
            }
        },
        error: function (result, textStatus, errorThrown) {
            return dfd.reject("Either you are logged out or you do not have access to Medicare, Redirecting");
        }
    });
    return dfd;
}

function OpenChatUrl(chatUrl, eventCustomerId) { // updateOnyIfNotCancelledOrNoshow is additional in this function

    $("#chatLink_" + eventCustomerId).colorbox({
        iframe: true, width: "100%", height: "100%", href: chatUrl, onClosed: function () {
            $.colorbox.close();
        }
    });

}
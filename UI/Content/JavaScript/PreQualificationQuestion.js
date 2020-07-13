
function replaceAll(str, find, replace) {
    return str.replace(new RegExp(find, 'g'), replace);
}

function AnswerFilled(prefilledQuestions) {

    if (prefilledQuestions != "") {
        var prefilleddata = '';
        prefilleddata = prefilledQuestions.split('|');
        $(prefilleddata).each(function (index, item) {

            var queanstest = item.split(',');
            var queid = queanstest[0];
            var ans = queanstest[1];
            RadioChangeEvent(queid, ans);
            var test = queanstest[2];
            if (test != "")
                disqualifiedTestId = parseInt(test);
            var controlType = 'hdnControlType_' + queid;

            var controltypevalue = $("input[name='" + controlType + "']").val();

            if (controltypevalue == 'Radio') {
                var postfix = replaceAll(ans, " ", "_");
                var radionselect = test + '_' + queid + '_' + postfix;

                $('input:radio[id=' + radionselect + ']').attr('checked', true);
            }
            else if (controltypevalue == 'TextBox') {
                $("[questionid='" + queid + "']").closest("div").show();
                $("[questionid='" + queid + "']").show();
                $("[questionid='" + queid + "']").val(ans);
            }
        });
    }
}

function CommonFunctionOfDisqualified() {
    var objectData = new Object();


    var isComplete = true;
    var answerStr = "";
    var answer = "";
    var qId = "";
    var tId = "";

    $("#tblQuestion input:radio:checked").each(function (index, item) {
        answer = $(item).val();
        qId = $(item).attr("questionId");
        tId = $(item).attr("testid");

        if (answerStr == "") {
            answerStr = qId + "," + answer + "," + tId;
        } else {
            answerStr = answerStr + "|" + qId + "," + answer + "," + tId;
        }
    });

    $("#tblQuestion input:radio:visible").each(function (index, item) {
        var name = $(item).attr("name");
        if ($("[name='" + name + "']").is(":checked") === false) {
            isComplete = false;
        }
    });

    $("#tblQuestion input:text:visible").each(function (index, item) {
        answer = $(item).val();
        qId = $(item).attr("questionId");
        tId = $(item).attr("testid");

        if (answer !== "" && qId !== "" && tId !== "") {
            if (answerStr == "") {
                answerStr = qId + "," + answer + "," + tId;
            } else {
                answerStr = answerStr + "|" + qId + "," + answer + "," + tId;
            }
        } else {
            isComplete = false;
        }
    });


    objectData.isComplete = isComplete;
    objectData.answerStr = answerStr;
    return objectData;
}

function IsCustomerMammoQualified(customerID) {
    var questionAnswer='';
    $.ajax({
        url: '/CallCenter/CallQueue/GetEventCustomerQuestionAnswer',
        type: 'GET',
        async: false,
        data: { customerId: customerID },
        success: function (data) {
            if (data != 'error') {
                questionAnswer = data;
            }
        }
    });
    if (questionAnswer != '' && CheckIsEligibleForTest(questionAnswer) == '')
        return true;
    else
        return false;
}
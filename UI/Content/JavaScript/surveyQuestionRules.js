function updateSurveyAnswers() {
    $(".sequence-block input[type='radio']:checked").each(function () {
        var self = $(this);
        var parent = self.closest(".sequence-block");

        if (self.is(":visible") == true && self.is(":disabled") == false && parent.is(":visible") == true) {
            var questionId = parent.find("input[type=text].survey-questionid").val();
            var defanswer = parent.find("input[type=text].survey-default-answer").val();
            var controltype = parent.find("input[type=text].survey-control-type").val();
            var answer = self.attr("ctrl_answer");
            // debugger;
            var key = searchCollectionInSurveyTemplate(questionId);

            if (key >= 0) {
                surveyQuestionrecord = selectedSurveyRecords[key];
            }
            else {
                surveyQuestionrecord = new Object();
            }

            if (answer == null || $.trim(answer).length < 1) {
                if (key >= 0) {
                    removeSurveyQuestionObject(key);
                }
                return;
            }

            surveyQuestionrecord.QuestionId = questionId;
            surveyQuestionrecord.Answer = answer;
            surveyQuestionrecord.DefaultAnswer = defanswer;
            surveyQuestionrecord.ControlType = controltype;

            if (key >= 0) {
                selectedSurveyRecords[key] = surveyQuestionrecord;
            }
            else {
                surveyQuestionrecord.Key = key_haf;
                selectedSurveyRecords[key_haf] = surveyQuestionrecord;
                key_haf = key_haf + 1;
            }
        }
    });

    renderTemplate();
}

function removeSurveyQuestionObject(key) {
    delete selectedSurveyRecords[key];
}

function searchCollectionInSurveyTemplate(questionId) {
    var key = -1;
    $.each(selectedSurveyRecords, function () {
        if (this.QuestionId == questionId) {
            key = this.Key;
            return false;
        }
    });

    return key;
}

function ValidateSurveyQuestionQuestions() {

    var allQuestionAnswered = true;

    $(".front-radio-block").each(function () {

        if ($(this).parents(".sequence-block:first").is(":visible") == false)
            return;

        if ($(this).find('input[type="radio"]').length < 1)
            return;

        if ($(this).find('input[type="radio"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="radio"]:checked').length == 0) {
            allQuestionAnswered = false;
        }
    });

    if (!allQuestionAnswered) {
        alert("Please answer all questions.");
        return false;
    }

    return true;
}

function CreateSurveyQuestionDisplayTemplate(displayTemplate, questionId) {
    var question = $(".sequence-block .survey-questionid[value='" + questionId + "']").parent().find(".survey-question-label-block").text();

    if (displayTemplate == "") {
        displayTemplate = "<li>" + question + "</li>";
    } else {
        displayTemplate = displayTemplate + "<li>" + question + "</li>";
    }

    return displayTemplate;
}

function CreateSurveyQuestionDisplayText(displayTemplate, question) {
    if (displayTemplate == "") {
        displayTemplate = "<li>" + question + "</li>";
    } else {
        displayTemplate = displayTemplate + "<li>" + question + "</li>";
    }
    return displayTemplate;
}

$(".decimalonly").keydown(function (e) {
    return KeyPress_DecimalAllowedOnly(e);
});

$(".isNumericOnly").keydown(function (e) {
    return KeyPress_NumericAllowedOnly(e);
});

$(document).ready(function () {
    
});

function SetEnableDisableRadiobtn(QuestionId, enable) {

    var sequenceblock = $(".survey-questionid[value='" + QuestionId + "']").closest(".sequence-block");
    if ($(sequenceblock).is(":visible") && enable == true) {
        $(sequenceblock).find("input[type=radio][name='question-" + QuestionId + "']").removeAttr("disabled");
    } else
        if ($(sequenceblock).is(":visible") && enable == false) {
            $(sequenceblock).find("input[type=radio][name='question-" + QuestionId + "']").attr("checked", false);
            $(sequenceblock).find("input[type=radio][name='question-" + QuestionId + "']").attr("disabled", "disabled");
        }
}

function SetEnableDisableText(QuestionId, enable) {

    var sequenceblock = $(".survey-questionid[value='" + QuestionId + "']").closest(".sequence-block");
    if ($(sequenceblock).is(":visible") && enable == true) {
        $(sequenceblock).find(".text-question").removeAttr("disabled");
    } else if ($(sequenceblock).is(":visible") && enable == false) {
        $(sequenceblock).find(".text-question").val('');
        $(sequenceblock).find(".text-question").attr("disabled", "disabled");

        var theKey = searchCollectionInSurveyTemplate(QuestionId);
        if (theKey != null) {
            removeSurveyQuestionObject(theKey);
        }
    }
}

function EnableServiceProvided(enable) {
    SetEnableDisableText(8, enable);
}

function setSurveyQuestionDependency() {
    if ($("input[type=radio][name='question-7'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-7'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableServiceProvided(false);
    }
}


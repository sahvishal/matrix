function emptyRatings() {
    $("input[type=radio][name='question-47']").attr("checked", false);
    var theKey = searchCollection(47);
    if (theKey != null) {
        removeObject(theKey);
    }
}

function setRatings() {
    $("input[type=radio][name='question-46'][ctrl_answer='Yes']").attr("checked", true);
    $("input[type=radio][name='question-46'][ctrl_answer='Yes']").click();
    $("input[type=radio][name='question-46'][ctrl_answer='Yes']").attr("checked", true);
}

function EnableVisitedPcp(enable) {//debugger;
    if (enable == true) {
        $("input[type=radio][name='question-1007']").removeAttr("disabled");
    }
    else {
        $("input[type=radio][name='question-1007']").attr("disabled", "disabled");
        if (setDefaultAnswer) {
            $("input[type=radio][name='question-1007'][ctrl_answer='No']").attr("checked", true);
        }
        else {
            $("input[type=radio][name='question-1007'][ctrl_answer='Yes']").attr("checked", false);
        }

        //$("input[type=radio][name='question-1007']").attr("checked", false);

        var theKey = searchCollection(1007);
        if (theKey != null) {
            removeObject(theKey);
        }
        EnablePhysicianName(false);
    }
}

function EnablePhysicianName(enable) {//debugger;
    var firstNameTextbox = $(".sequence-block .questionid[value='1014']").parent().find("input[type='text'].text-question");
    var lastNameTextbox = $(".sequence-block .questionid[value='1015']").parent().find("input[type='text'].text-question");

    if (enable == true) {
        firstNameTextbox.removeAttr("disabled");
        lastNameTextbox.removeAttr("disabled");
    }
    else {
        firstNameTextbox.attr("disabled", "disabled");
        lastNameTextbox.attr("disabled", "disabled");

        firstNameTextbox.val('');
        lastNameTextbox.val('');

        var theKey = searchCollection(1014);
        if (theKey != null) {
            removeObject(theKey);
        }

        theKey = searchCollection(1015);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnablePhysicianFullName(enable) {//debugger;
    var nameTextbox = $(".sequence-block .questionid[value='139']").parent().find("input[type='text'].text-question");

    if (enable == true) {
        nameTextbox.removeAttr("disabled");
    }
    else {
        nameTextbox.attr("disabled", "disabled");

        nameTextbox.val('');

        var theKey = searchCollection(139);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableRefferalPcp(enable) {//debugger;
    var refferalPcpTextbox = $(".sequence-block .questionid[value='81']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        refferalPcpTextbox.removeAttr("disabled");
    }
    else {
        refferalPcpTextbox.attr("disabled", "disabled");
        refferalPcpTextbox.val('');
        var theKey = searchCollection(81);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function ValidateDiabeticQuestion(enable) {//debugger;
    if (enable == true) {
        $("input[type=radio][name='question-85']").removeAttr("disabled");
    }
    else {
        $("input[type=radio][name='question-85']").attr("disabled", "disabled");

        if (setDefaultAnswer) {
            $("input[type=radio][name='question-85'][ctrl_answer='No']").attr("checked", true);
        }
        else {
            $("input[type=radio][name='question-85'][ctrl_answer='Yes']").attr("checked", false);
        }
        //$("input[type=radio][name='question-85']").attr("checked", false);
        var theKey = searchCollection(85);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function ValidateSmokingQuestion(enable) {//debugger;
    if (enable == true) {
        $("input[type=radio][name='question-87']").removeAttr("disabled");
    }
    else {
        $("input[type=radio][name='question-87']").attr("disabled", "disabled");

        if (setDefaultAnswer) {
            $("input[type=radio][name='question-87'][ctrl_answer='No']").attr("checked", true);
        }
        else {
            $("input[type=radio][name='question-87']").attr("checked", false);
        }
        //$("input[type=radio][name='question-87']").attr("checked", false);
        var theKey = searchCollection(87);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function ValidateWeightLossQuestion(enable) {//debugger;
    if (enable == true) {
        $("input[type=radio][name='question-91']").removeAttr("disabled");
        $("input[type=radio][name='question-92']").removeAttr("disabled");
    }
    else {
        $("input[type=radio][name='question-91']").attr("disabled", "disabled");
        $("input[type=radio][name='question-92']").attr("disabled", "disabled");

        if (setDefaultAnswer) {
            $("input[type=radio][name='question-91'][ctrl_answer='No']").attr("checked", true);
            $("input[type=radio][name='question-92'][ctrl_answer='No']").attr("checked", true);
        }
        else {
            $("input[type=radio][name='question-91'][ctrl_answer='Yes']").attr("checked", false);
            $("input[type=radio][name='question-92'][ctrl_answer='Yes']").attr("checked", false);
        }
        //$("input[type=radio][name='question-91']").attr("checked", false);
        //$("input[type=radio][name='question-92']").attr("checked", false);

        var theKey = searchCollection(91);
        if (theKey != null) {
            removeObject(theKey);
        }

        theKey = searchCollection(92);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableCardiovascularSpecialist(enable) {//debugger;
    var firstNameTextbox = $(".sequence-block .questionid[value='106']").parent().find("input[type='text'].text-question");
    var lastNameTextbox = $(".sequence-block .questionid[value='107']").parent().find("input[type='text'].text-question");

    if (enable == true) {
        firstNameTextbox.removeAttr("disabled");
        lastNameTextbox.removeAttr("disabled");
    }
    else {
        firstNameTextbox.attr("disabled", "disabled");
        lastNameTextbox.attr("disabled", "disabled");

        firstNameTextbox.val('');
        lastNameTextbox.val('');

        var theKey = searchCollection(106);
        if (theKey != null) {
            removeObject(theKey);
        }

        theKey = searchCollection(107);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableCardiovascularSpecialistName(enable) {//debugger;
    var nameTextbox = $(".sequence-block .questionid[value='141']").parent().find("input[type='text'].text-question");

    if (enable == true) {
        nameTextbox.removeAttr("disabled");
    }
    else {
        nameTextbox.attr("disabled", "disabled");

        nameTextbox.val('');

        var theKey = searchCollection(141);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function ValidateSmokingQuestion_VCU(enable) {//debugger;
    if (enable == true) {
        $("input[type=radio][name='question-174']").removeAttr("disabled");
        $("input[type=radio][name='question-175']").removeAttr("disabled");
    }
    else {
        $("input[type=radio][name='question-174']").attr("disabled", "disabled");
        $("input[type=radio][name='question-175']").attr("disabled", "disabled");

        if (setDefaultAnswer) {
            $("input[type=radio][name='question-174'][ctrl_answer='No']").attr("checked", true);
            $("input[type=radio][name='question-175'][ctrl_answer='No']").attr("checked", true);
        }
        else {
            $("input[type=radio][name='question-174']").attr("checked", false);
            $("input[type=radio][name='question-175']").attr("checked", false);
        }
        var theKey = searchCollection(174);
        if (theKey != null) {
            removeObject(theKey);
        }

        theKey = searchCollection(175);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableVisitedPcp_VCU(enable) {//debugger;
    if (enable == true) {
        $("input[type=radio][name='question-181']").removeAttr("disabled");
    }
    else {
        $("input[type=radio][name='question-181']").attr("disabled", "disabled");
        if (setDefaultAnswer) {
            $("input[type=radio][name='question-181'][ctrl_answer='No']").attr("checked", true);
        }
        else {
            $("input[type=radio][name='question-181']").attr("checked", false);
        }
        var theKey = searchCollection(181);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableBreastProblem(enable) {
    if (enable == true) {
        $("input[type=radio][name='question-135']").removeAttr("disabled");
    }
    else {
        $("input[type=radio][name='question-135']").attr("checked", false);
        $("input[type=radio][name='question-135']").attr("disabled", "disabled");
    }

    var theKey = searchCollection(135);
    if (theKey != null) {
        removeObject(theKey);
    }
}

function EnablePrevoiusMammogram(enable) { //debugger;
    var dateTextbox = $(".sequence-block .questionid[value='117']").parent().find("input[type='text'].text-question");
    var locationTextbox = $(".sequence-block .questionid[value='118']").parent().find("input[type='text'].text-question");

    if (enable == true) {
        dateTextbox.removeAttr("disabled");
        locationTextbox.removeAttr("disabled");
    } else {
        dateTextbox.attr("disabled", "disabled");
        locationTextbox.attr("disabled", "disabled");

        dateTextbox.val('');
        locationTextbox.val('');

        var theKey = searchCollection(117);
        if (theKey != null) {
            removeObject(theKey);
        }

        theKey = searchCollection(118);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableBreastCancer(enable) { //debugger;
    var dateTextbox = $(".sequence-block .questionid[value='120']").parent().find("input[type='text'].text-question");

    if (enable == true) {
        dateTextbox.removeAttr("disabled");
        $("input[type=radio][name='question-121']").removeAttr("disabled");
    } else {
        dateTextbox.attr("disabled", "disabled");
        $("input[type=radio][name='question-121']").attr("checked", false);
        $("input[type=radio][name='question-121']").attr("disabled", "disabled");

        dateTextbox.val('');

        var theKey = searchCollection(120);
        if (theKey != null) {
            removeObject(theKey);
        }

        theKey = searchCollection(121);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableBreastMass(enable) {
    var dateTextbox = $(".sequence-block .questionid[value='136']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        dateTextbox.removeAttr("disabled");
        $("input[type=radio][name='question-123']").removeAttr("disabled");
    }
    else {
        dateTextbox.attr("disabled", "disabled");
        $("input[type=radio][name='question-123']").attr("checked", false);
        $("input[type=radio][name='question-123']").attr("disabled", "disabled");
    }
    var theKey = searchCollection(136);
    if (theKey != null) {
        removeObject(theKey);
    }

    theKey = searchCollection(123);
    if (theKey != null) {
        removeObject(theKey);
    }
}

function EnableBiopsy(enable) {
    var dateTextbox = $(".sequence-block .questionid[value='137']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        dateTextbox.removeAttr("disabled");
        $("input[type=radio][name='question-125']").removeAttr("disabled");
    }
    else {
        dateTextbox.attr("disabled", "disabled");
        $("input[type=radio][name='question-125']").attr("checked", false);
        $("input[type=radio][name='question-125']").attr("disabled", "disabled");
    }

    var theKey = searchCollection(137);
    if (theKey != null) {
        removeObject(theKey);
    }

    theKey = searchCollection(125);
    if (theKey != null) {
        removeObject(theKey);
    }
}

function EnableImplants(enable) {
    if (enable == true)
        $("input[type=radio][name='question-127']").removeAttr("disabled");
    else {
        $("input[type=radio][name='question-127']").attr("checked", false);
        $("input[type=radio][name='question-127']").attr("disabled", "disabled");
    }
    var theKey = searchCollection(127);
    if (theKey != null) {
        removeObject(theKey);
    }
}

function EnableHysterectomy(enable) {
    var dateTextbox = $(".sequence-block .questionid[value='129']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        dateTextbox.removeAttr("disabled");
        $("input[type=radio][name='question-130']").removeAttr("disabled");
    }
    else {
        dateTextbox.attr("disabled", "disabled");
        dateTextbox.val('');
        //$("input[type=radio][name='question-130']").attr("checked", false);
        $("input[type=radio][name='question-130']").attr("disabled", "disabled");
    }
    var theKey = searchCollection(129);
    if (theKey != null) {
        removeObject(theKey);
    }

    theKey = searchCollection(130);
    if (theKey != null) {
        removeObject(theKey);
    }
}

function EnableMenopause(enable) {
    if (enable == true)
        $("input[type=radio][name='question-133']").removeAttr("disabled");
    else {
        $("input[type=radio][name='question-133']").attr("checked", false);
        $("input[type=radio][name='question-133']").attr("disabled", "disabled");
    }
    var theKey = searchCollection(133);
    if (theKey != null) {
        removeObject(theKey);
    }
}
function EnableDisableFallWithoutPushed(enable) {
    var questionId391 = $(".questionid[value='391']").closest(".sequence-block");
    var questionId393 = $(".questionid[value='393']").closest(".sequence-block");

    if (enable) {
        if ($(questionId391).is(":visible")) {
            $(questionId391).find("input[name='question-391']").removeAttr("disabled");
        }
        if ($(questionId393).is(":visible")) {
            $(questionId393).find("input[name='question-393']").removeAttr("disabled");
        }
    } else if (enable == false) {
        if ($(questionId391).is(":visible")) {
            $(questionId391).find("input[name='question-391']").attr("disabled", "disabled");
            $(questionId391).find("input[name='question-391']").val('');
            $(questionId391).find("input[name='question-391']").removeAttr('checked');
        }
        if ($(questionId393).is(":visible")) {
            $(questionId393).find("input[name='question-393']").attr("disabled", "disabled");
            $(questionId393).find("input[name='question-393']").val('');
            $(questionId393).find("input[name='question-393']").removeAttr('checked');
        }
    }
}


function EnableDisableSpiroSectionOne(enable) {
    var questionId473 = $(".questionid[value='473']").closest(".sequence-block");
    var questionId474 = $(".questionid[value='474']").closest(".sequence-block");
    var questionId475 = $(".questionid[value='475']").closest(".sequence-block");
    var questionId476 = $(".questionid[value='476']").closest(".sequence-block");

    if (enable) {
        if ($(questionId473).is(":visible")) {
            $(questionId473).find("input[name='question-473']").removeAttr("disabled");
        }
        if ($(questionId474).is(":visible")) {
            $(questionId474).find("input[name='question-474']").removeAttr("disabled");
        }
        if ($(questionId475).is(":visible")) {
            $(questionId475).find("input[name='question-475']").removeAttr("disabled");
        }
        if ($(questionId476).is(":visible")) {
            $(questionId476).find("input[name='question-476']").removeAttr("disabled");
        }

    } else if (enable == false) {
        if ($(questionId473).is(":visible")) {
            $(questionId473).find("input[name='question-473']").attr("disabled", "disabled");
            $(questionId473).find("input[name='question-473']").val('');
            $(questionId473).find("input[name='question-473']").removeAttr('checked');
        }
        if ($(questionId474).is(":visible")) {
            $(questionId474).find("input[name='question-474']").attr("disabled", "disabled");
            $(questionId474).find("input[name='question-474']").val('');
            $(questionId474).find("input[name='question-474']").removeAttr('checked');
        }
        if ($(questionId475).is(":visible")) {
            $(questionId475).find("input[name='question-475']").attr("disabled", "disabled");
            $(questionId475).find("input[name='question-475']").val('');
            $(questionId475).find("input[name='question-475']").removeAttr('checked');
        }
        if ($(questionId476).is(":visible")) {
            $(questionId476).find("input[name='question-476']").attr("disabled", "disabled");
            $(questionId476).find("input[name='question-476']").val('');
            $(questionId476).find("input[name='question-476']").removeAttr('checked');
        }
    }
}

function EnableDisableSpiroSectionTwo(enable) {
    var questionId478 = $(".questionid[value='478']").closest(".sequence-block");
    var questionId479 = $(".questionid[value='479']").closest(".sequence-block");
    var questionId480 = $(".questionid[value='480']").closest(".sequence-block");


    if (enable) {
        if ($(questionId478).is(":visible")) {
            $(questionId478).find("input[name='question-478']").removeAttr("disabled");
        }
        if ($(questionId479).is(":visible")) {
            $(questionId479).find("input[name='question-479']").removeAttr("disabled");
        }
        if ($(questionId480).is(":visible")) {
            $(questionId480).find("input[name='question-480']").removeAttr("disabled");
        }

    } else if (enable == false) {
        if ($(questionId478).is(":visible")) {
            $(questionId478).find("input[name='question-478']").attr("disabled", "disabled");
            $(questionId478).find("input[name='question-478']").val('');
            $(questionId478).find("input[name='question-478']").removeAttr('checked');
        }
        if ($(questionId479).is(":visible")) {
            $(questionId479).find("input[name='question-479']").attr("disabled", "disabled");
            $(questionId479).find("input[name='question-479']").val('');
            $(questionId479).find("input[name='question-479']").removeAttr('checked');
        }
        if ($(questionId480).is(":visible")) {
            $(questionId480).find("input[name='question-480']").attr("disabled", "disabled");
            $(questionId480).find("input[name='question-480']").val('');
            $(questionId480).find("input[name='question-480']").removeAttr('checked');
        }
    }
}

function EnableDisableNeedHelpToPeromDailyActivity(enable) {
    var questionId397 = $(".questionid[value='397']").closest(".sequence-block");
    var questionId399 = $(".questionid[value='399']").closest(".sequence-block");
    var questionId401 = $(".questionid[value='401']").closest(".sequence-block");
    var questionId403 = $(".questionid[value='403']").closest(".sequence-block");
    var questionId405 = $(".questionid[value='405']").closest(".sequence-block");
    var questionId407 = $(".questionid[value='407']").closest(".sequence-block");

    if (enable) {
        if ($(questionId397).is(":visible")) {
            $(questionId397).find("input[type='checkbox']").removeAttr("disabled");
        }
        if ($(questionId399).is(":visible")) {
            $(questionId399).find("input[type='checkbox']").removeAttr("disabled");
        }
        if ($(questionId401).is(":visible")) {
            $(questionId401).find("input[type='checkbox']").removeAttr("disabled");
        }
        if ($(questionId403).is(":visible")) {
            $(questionId403).find("input[type='checkbox']").removeAttr("disabled");
        }
        if ($(questionId405).is(":visible")) {
            $(questionId405).find("input[type='checkbox']").removeAttr("disabled");
        }
        if ($(questionId407).is(":visible")) {
            $(questionId407).find("input[type='checkbox']").removeAttr("disabled");
        }
    } else if (enable == false) {

        if ($(questionId397).is(":visible")) {
            $(questionId397).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId397).find("input[type='checkbox']").val('');
            $(questionId397).find("input[type='checkbox']").removeAttr('checked');
        }
        if ($(questionId399).is(":visible")) {
            $(questionId399).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId399).find("input[type='checkbox']").val('');
            $(questionId399).find("input[type='checkbox']").removeAttr('checked');
        }
        if ($(questionId401).is(":visible")) {
            $(questionId401).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId401).find("input[type='checkbox']").val('');
            $(questionId401).find("input[type='checkbox']").removeAttr('checked');
        }
        if ($(questionId403).is(":visible")) {
            $(questionId403).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId403).find("input[type='checkbox']").val('');
            $(questionId403).find("input[type='checkbox']").removeAttr('checked');
        }
        if ($(questionId405).is(":visible")) {
            $(questionId405).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId405).find("input[type='checkbox']").val('');
            $(questionId405).find("input[type='checkbox']").removeAttr('checked');
        }
        if ($(questionId407).is(":visible")) {
            $(questionId407).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId407).find("input[type='checkbox']").val('');
            $(questionId407).find("input[type='checkbox']").removeAttr('checked');
        }
    }
}

function EnableKynGestationalDiabetes(enable) {
    var dateTextbox = $(".sequence-block .questionid[value='156']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        dateTextbox.removeAttr("disabled");
    }
    else {
        dateTextbox.attr("disabled", "disabled");
        dateTextbox.val('');
    }
    var theKey = searchCollection(156);
    if (theKey != null) {
        removeObject(theKey);
    }
}

function updateHAFAnswers() {
    $(".sequence-block input[type='radio']:checked").each(function () {
        var self = $(this);
        var parent = self.closest(".sequence-block");

        if (self.is(":visible") == true && self.is(":disabled") == false && parent.is(":visible") == true) {
            var questionId = parent.find("input[type=text].questionid").val();
            var defanswer = parent.find("input[type=text].default-answer").val();
            var controltype = parent.find("input[type=text].control-type").val();
            var answer = self.attr("ctrl_answer");
            // debugger;
            var key = searchCollection(questionId);

            if (key >= 0) {
                record = selectedRecords[key];
            }
            else {
                record = new Object();
            }

            if (answer == null || $.trim(answer).length < 1) {
                if (key >= 0) {
                    removeObject(key);
                }
                return;
            }

            record.QuestionId = questionId;
            record.Answer = answer;
            record.DefaultAnswer = defanswer;
            record.ControlType = controltype;

            if (key >= 0) {
                selectedRecords[key] = record;
            }
            else {
                record.Key = key_haf;
                selectedRecords[key_haf] = record;
                key_haf = key_haf + 1;
            }
        }
    });

    renderTemplate();
}

function EnableKynWomenOnly(isFemale) {
    //debugger;
    if (isFemale) {
        $(".kyn-women-only input[type=radio]").removeAttr("disabled");
        $(".kyn-women-only input[type=text]").removeAttr("disabled");

        if ($("input[type=radio][name='question-155'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-155'][ctrl_answer='Yes']").attr("checked") == false) {
            EnableKynGestationalDiabetes(false);
        }

    } else {
        $(".kyn-women-only input[type=radio]").attr("disabled", "disabled");
        $(".kyn-women-only input[type=text]:visible").attr("disabled", "disabled");

        $(".kyn-women-only input[type=text]:visible").val("");

        $(".kyn-women-only .sequence-block input[type='radio']").each(function () {

            var parent = $(this).closest(".sequence-block");
            var questionId = parent.find("input[type=text].questionid").val();
            var key = searchCollection(questionId);
            if (key >= 0) {
                removeObject(key);
            }
        });

        $(".kyn-women-only .sequence-block input[type='text']:visible").each(function () {

            var parent = $(this).closest(".sequence-block");
            var questionId = parent.find("input[type=text].questionid").val();
            var key = searchCollection(questionId);
            if (key >= 0) {
                removeObject(key);
            }
        });
    }
}

function EnableEcho(enable) {//debugger;
    var echoTextbox = $(".sequence-block .questionid[value='186']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        echoTextbox.removeAttr("disabled");
    }
    else {
        echoTextbox.attr("disabled", "disabled");
        echoTextbox.val('');
        var theKey = searchCollection(186);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableEkg(enable) {//debugger;
    var ekgTextbox = $(".sequence-block .questionid[value='188']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        ekgTextbox.removeAttr("disabled");
    }
    else {
        ekgTextbox.attr("disabled", "disabled");
        ekgTextbox.val('');
        var theKey = searchCollection(188);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableStroke(enable) {//debugger;
    var strokeTextbox = $(".sequence-block .questionid[value='190']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        strokeTextbox.removeAttr("disabled");
    }
    else {
        strokeTextbox.attr("disabled", "disabled");
        strokeTextbox.val('');
        var theKey = searchCollection(190);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnablePad(enable) {//debugger;
    var padTextbox = $(".sequence-block .questionid[value='192']").parent().find("input[type='text'].text-question");
    if (enable == true) {
        padTextbox.removeAttr("disabled");
    }
    else {
        padTextbox.attr("disabled", "disabled");
        padTextbox.val('');
        var theKey = searchCollection(192);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function EnableLocationPainExperiencing(enable) {
    var locatePainText = $(".sequence-block .questionid[value='217']").parent().find("input[type='text'].text-question");
    var locateTextDiv = $(".sequence-block .questionid[value='217']").parent();
    if (locateTextDiv.is(":visible")) {
        if (enable == true) {
            locatePainText.removeAttr("disabled");
        }
        else {
            locatePainText.attr("disabled", "disabled");
            locatePainText.val('');

            var theKey = searchCollection(217);
            if (theKey != null) {
                removeObject(theKey);
            }
        }
    }

}

function EnableLocateHarnia(enable) {
    var locateText = $(".sequence-block .questionid[value='219']").parent().find("input[type='text'].text-question");
    var locateTextDiv = $(".sequence-block .questionid[value='219']").parent();
    if (locateTextDiv.is(":visible")) {
        if (enable == true) {
            locateText.removeAttr("disabled");
        }
        else {
            locateText.attr("disabled", "disabled");
            locateText.val('');

            var theKey = searchCollection(218);
            if (theKey != null) {
                removeObject(theKey);
            }
        }
    }
}
function EnableColonoscopyLastTime(enable) {
    var locateText = $(".sequence-block .questionid[value='235']").parent().find("input[type='text'].text-question");
    var locateTextDiv = $(".sequence-block .questionid[value='235']").parent();
    if (locateTextDiv.is(":visible")) {
        if (enable == true) {
            locateText.removeAttr("disabled");
        }
        else {
            locateText.attr("disabled", "disabled");
            locateText.val('');

            var theKey = searchCollection(235);
            if (theKey != null) {
                removeObject(theKey);
            }
        }
    }
}
function EnableFamilyCancerHistory(enable) {
    var locateText = $(".sequence-block .questionid[value='1020']").parent().find("input[type='text'].text-question");
    var locateTextDiv = $(".sequence-block .questionid[value='1020']").parent();
    if (locateTextDiv.is(":visible")) {
        if (enable == true) {
            locateText.removeAttr("disabled");
        }
        else {
            locateText.attr("disabled", "disabled");
            locateText.val('');

            var theKey = searchCollection(1020);
            if (theKey != null) {
                removeObject(theKey);
            }
        }
    }
}
function EnableWoundNotHealed(enable) {
    var locateText = $(".sequence-block .questionid[value='224']").parent().find("input[type='text'].text-question");
    var locateTextDiv = $(".sequence-block .questionid[value='224']").parent();
    if (locateTextDiv.is(":visible")) {
        if (enable == true) {
            locateText.removeAttr("disabled");
        }
        else {
            locateText.attr("disabled", "disabled");
            locateText.val('');

            var theKey = searchCollection(224);
            if (theKey != null) {
                removeObject(theKey);
            }
        }
    }
}

function setMammoQuestions() {
    //debugger;
    $(".mammo-haf-container").html($(".mammo-haf").clone(true));
    $(".mammo-haf:first").empty();
    $(".mammo-haf:first").hide();
}

function setKynQuestions() {

    $(".kyn-haf-container").html($(".kyn-haf").clone(true));
    $(".kyn-haf:first").empty();
    $(".kyn-haf:first").hide();
}

function setControlswithDefaultAnswer() {

    if (setDefaultAnswer) {
        return;
    }
    setDefaultAnswer = true;

    $('.questionid').each(function () {
        var questionId = $(this).val();

        var parentDiv = $(this).parents(".sequence-block:first");
        if (parentDiv.length < 1) return;

        var defanswer = parentDiv.find("input[type=text].default-answer").val();
        var controltype = parentDiv.find("input[type=text].control-type").val();

        setAnswertoControl(parentDiv, controltype, defanswer);
    });
    setQuestionDependency();
}


function removeObject(key) {
    delete selectedRecords[key];
}

function renderTemplate() {
    $("#healthAssessmentTemplateDiv").empty();
    $.each(selectedRecords, function (key, selRecord) {
        $("#healthAssessmentTemplateDiv").append($("#selectedQuestionTemplate").tmpl(selRecord));
    });
}

function getkynHealthAssessmentEditModel() {
    var kynModel = null;

    if ($(".kyn-info").length > 0) {
        kynModel = new Object();

        kynModel.HeightInFeet = $(".kyn-info #HeightInFeet").val();
        kynModel.HeightInInches = $(".kyn-info #HeightInInches").val();
        kynModel.FastingStatus = $(".kyn-info #FastingStatus").val();
        kynModel.KynWeight = $(".kyn-info #KynWeight").val();
        kynModel.Glucose = $(".kyn-info #Glucose").val();
        kynModel.Notes = $(".kyn-info #Notes").val();
        kynModel.WaistSize = $(".kyn-info #WaistSize").val();
        kynModel.TotalCholesterol = $(".kyn-info #TotalCholesterol").val();
        kynModel.PulseRate = $(".kyn-info #PulseRate").val();
        kynModel.Triglycerides = $(".kyn-info #Triglycerides").val();
        kynModel.SystolicPressure = $(".kyn-info #SystolicPressure").val();
        kynModel.DiastolicPressure = $(".kyn-info #DiastolicPressure").val();
        kynModel.HDLCholesterol = $(".kyn-info #HDLCholesterol").val();
        kynModel.ManualSystolic = $(".kyn-info #ManualSystolic").val();
        kynModel.ManualDiastolic = $(".kyn-info #ManualDiastolic").val();
        kynModel.CustomerId = $("#CustomerId").val();
        kynModel.EventId = $("#EventId").val();
        kynModel.A1c = $(".kyn-info #A1c").val();


        kynModel.LdlCholestrol = $(".kyn-info #LdlCholestrol").val();
        kynModel.BodyFat = $(".kyn-info #BodyFat").val();
        kynModel.BoneDensity = $(".kyn-info #BoneDensity").val();
        kynModel.Psa = $(".kyn-info #Psa").val();
        kynModel.NonHdlCholestrol = $(".kyn-info #NonHdlCholestrol").val();
        kynModel.Nicotine = $(".kyn-info #Nicotine").val();
        kynModel.Cotinine = $(".kyn-info #Cotinine").val();
        kynModel.Smoker = $(".kyn-info #Smoker").val();
    }

    return kynModel;
}

function searchCollection(questionId) {
    var key = -1;
    $.each(selectedRecords, function () {
        if (this.QuestionId == questionId) {
            key = this.Key;
            return false;
        }
    });

    return key;
}

function ValidateHealthQuestionsWithHighLightedText() {

    var allQuestionAnswered = true;
    $(".front-radio-block").each(function () {
        $(this).closest(".sequence-block").css("font-weight", "").css("margin", "").css("border", "");
        $(this).closest(".sequence-block").removeClass("validate-set-focus");
        if ($(this).parents(".sequence-block:first").is(":visible") == false)
            return;

        if ($(this).find('input[type="radio"]').length < 1)
            return;

        if ($(this).find('input[type="radio"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="radio"]:checked').length == 0) {
            allQuestionAnswered = false;
            $(this).closest(".sequence-block").css("font-weight", "bolder").css("width", "98%").css("margin", "1px 0 5px 5px").css("border", "1px solid #ff0000");
            $(this).closest(".kyn-lifestyle").css("height", "200px");
            $(this).closest(".sequence-block").addClass("validate-set-focus");
        }
    });

    $(".agent-highlight-parent").each(function () {
        $(this).removeClass("agent-validate").removeClass("validate-set-focus");

        if ($(this).find(".sequence-block").is(":visible") == false)
            return;

        if ($(this).find('input[type="radio"]').length < 1)
            return;

        if ($(this).find('input[type="radio"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="radio"]:checked').length == 0) {
            allQuestionAnswered = false;
            $(this).addClass("agent-validate").addClass("validate-set-focus");
        }
    });

    $(".validate-child-radio").each(function () {
        $(this).removeClass("agent-validate").removeClass("validate-set-focus");

        if ($(this).is(":visible") == false)
            return;

        if ($(this).find('input[type="radio"]').length < 1)
            return;

        if ($(this).find('input[type="radio"]:visible').length < 1)
            return;

        if ($(this).find('input[type="radio"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="radio"]:checked').length == 0) {
            allQuestionAnswered = false;
            $(this).closest(".kyn-lifestyle").css("height", "200px");
            $(this).addClass("agent-validate").addClass("validate-set-focus");
        }
    });
    $(".validate-child-text").each(function () {
        $(this).removeClass("agent-validate").removeClass("validate-set-focus");

        if ($(this).is(":visible") == false)
            return;

        if ($(this).find('input[type="text"]').length < 1)
            return;

        if ($(this).find('input[type="text"]:visible').length < 1)
            return;

        if ($(this).find('input[type="text"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="text"]:first').val().length == 0) {
            allQuestionAnswered = false;
            $(this).addClass("agent-validate").addClass("validate-set-focus");
        }
    });
    $(".validate-child-chkbox").each(function () {
        $(this).removeClass("agent-validate").removeClass("validate-set-focus");

        if ($(this).is(":visible") == false)
            return;

        if ($(this).find('input[type="checkbox"]').length < 1)
            return;

        if ($(this).find('input[type="checkbox"]:visible').length < 1)
            return;

        if ($(this).find('input[type="checkbox"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="checkbox"]:checked').length == 0) {
            allQuestionAnswered = false;
            $(this).addClass("agent-validate").addClass("validate-set-focus");
        }
    });

    if ($("input[type=radio][name='question-46'][ctrl_answer='Yes']").attr("checked")) {
        var group = $(".agent-validate47");
        if (group.find('input[type="radio"]:checked').length == 0) {
            allQuestionAnswered = false;
            group.addClass("agent-validate").addClass("validate-set-focus");
        } else {
            group.removeClass("agent-validate").removeClass("validate-set-focus");
        }
    }
    else {
        var group = $(".agent-validate47");
        group.removeClass("agent-validate").removeClass("validate-set-focus");
    }

    $(".validate-child-radio-nowidth").each(function () {
        $(this).removeClass("agent-validate-nowidth").removeClass("validate-set-focus");

        if ($(this).is(":visible") == false)
            return;

        if ($(this).find('input[type="radio"]').length < 1)
            return;

        if ($(this).find('input[type="radio"]:visible').length < 1)
            return;

        if ($(this).find('input[type="radio"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="radio"]:checked').length == 0) {
            allQuestionAnswered = false;
            $(this).addClass("agent-validate-nowidth").addClass("validate-set-focus");
        }
    });
    $(".validate-child-text-nowidth").each(function () {
        $(this).removeClass("agent-validate-nowidth").removeClass("validate-set-focus");

        if ($(this).is(":visible") == false)
            return;

        if ($(this).find('input[type="text"]').length < 1)
            return;

        if ($(this).find('input[type="text"]:visible').length < 1)
            return;

        if ($(this).find('input[type="text"]:disabled').length > 0)
            return;

        if ($(this).find('input[type="text"]:first').val().length == 0) {
            allQuestionAnswered = false;
            $(this).addClass("agent-validate-nowidth").addClass("validate-set-focus");
        }
    });


    $(".validate-set-focus:first").find(':input:visible:enabled:first').focus();

    if (!allQuestionAnswered) {
        var r = confirm("Few Questions are still left unanswered. Do you wish to answer all the questions?");
        return !r;
    }

    return true;
}

function ValidateHealthQuestions() {

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

function ValidateHealthQuestionsOnline() {

    var allQuestionAnswered = true;

    $(".front-radio-block").each(function () {

        if ($(this).parents(".sequence-block:first").is(":visible") == false)
            return;

        if ($(this).find('input[type="radio"]').length < 1)
            return;

        if ($(this).find('input[type="radio"]:disabled').length > 0)
            return;

        if ($(this).hasClass("currently-smoking")) {
            var question168 = $("input:radio[name='question-168']");
            if (question168.is(":visible") && $("input:radio[name='question-168']:checked").attr("ctrl_answer") == "Yes") {
                if ($(this).find('input[type="radio"]:checked').length == 0) {
                    allQuestionAnswered = false;
                }
            }
        } else {
            if ($(this).find('input[type="radio"]:checked').length == 0) {
                allQuestionAnswered = false;
            }
        }

    });

    if ($(".questionid[value='154']").parents(".sequence-block:first").is(":visible") == true && $(".sequence-block .questionid[value='154']").parent().find("input[type='text'].text-question").is(":disabled") == false) {

        var liveBirthQuestion = $(".sequence-block .questionid[value='154']").parent().find("input[type='text'].text-question").val();

        if (liveBirthQuestion == "") {
            allQuestionAnswered = false;
        }
    }

    if ($("input:radio[name='question-155']").parents(".sequence-block:first").is(":visible") == true) {

        var question155 = $("input:radio[name='question-155']:checked").attr("ctrl_answer");
        if (question155 == "Yes") {
            var question156 = $(".sequence-block .questionid[value='156']").parent().find("input[type='text'].text-question").val();
            if (question156 == "") {
                allQuestionAnswered = false;
            }
        }
    }

    var question168 = $("input:radio[name='question-168']");
    var question163;
    if (question168.is(":visible") && $("input:radio[name='question-168']:checked").attr("ctrl_answer") == "Yes") {

        question163 = $(".sequence-block .questionid[value='163']").parent().find("input[type='text'].text-question");
        if (question163.is(":visible") == true) {
            if (question163.val() == "") {
                allQuestionAnswered = false;
            }
        }
        var question164 = $(".sequence-block .questionid[value='164']").parent().find("input[type='text'].text-question");

        if (question164.is(":visible") == true) {
            if (question164.val() == "") {
                allQuestionAnswered = false;
            }
        }
    }

    var question315 = $("input:radio[name='question-315']");
    var question317;
    if (question315.is(":visible") && $("input:radio[name='question-315']:checked").attr("ctrl_answer") == "Yes") {

        question317 = $(".sequence-block .questionid[value='317']").parent().find("input[type='text'].text-question");
        if (question317.is(":visible") == true) {
            if (question317.val() == "") {
                allQuestionAnswered = false;
            }
        }
    }
    var question321 = $("input:radio[name='question-321']");
    var question323;
    if (question321.is(":visible") && $("input:radio[name='question-321']:checked").attr("ctrl_answer") == "Yes") {

        question323 = $(".sequence-block .questionid[value='323']").parent().find("input[type='text'].text-question");
        if (question323.is(":visible") == true) {
            if (question323.val() == "") {
                allQuestionAnswered = false;
            }
        }
    }

    if (!allQuestionAnswered) {
        return false;
    }

    return true;
}

function CreateDisplayTemplate(displayTemplate, questionId) {
    var question = $(".sequence-block .questionid[value='" + questionId + "']").parent().find(".question-label-block").text();

    if (displayTemplate == "") {
        displayTemplate = "<li>" + question + "</li>";
    } else {
        displayTemplate = displayTemplate + "<li>" + question + "</li>";
    }

    return displayTemplate;
}
function CreateDisplayText(displayTemplate, question) {
    if (displayTemplate == "") {
        displayTemplate = "<li>" + question + "</li>";
    } else {
        displayTemplate = displayTemplate + "<li>" + question + "</li>";
    }
    return displayTemplate;
}

function ValidateHAF(callbacklSuccess) {

    var validationTemplate = "";

    if ($("#Race").length = 1 && $("#Race").val() == "-1") {
        validationTemplate = CreateDisplayText(validationTemplate, "Race");
    }

    if ($(".questionid[value='154']").parents(".sequence-block:first").is(":visible") == true && $(".sequence-block .questionid[value='154']").parent().find("input[type='text'].text-question").is(":disabled") == false) {

        var liveBirthQuestion = $(".sequence-block .questionid[value='154']").parent().find("input[type='text'].text-question").val();

        if (liveBirthQuestion == "") {
            validationTemplate = CreateDisplayTemplate(validationTemplate, 154);
        }
    }

    if ($("input:radio[name='question-155']").parents(".sequence-block:first").is(":visible") == true) {

        var question155 = $("input:radio[name='question-155']:checked").attr("ctrl_answer");
        if (question155 == "Yes") {
            var question156 = $(".sequence-block .questionid[value='156']").parent().find("input[type='text'].text-question").val();
            if (question156 == "") {
                validationTemplate = CreateDisplayTemplate(validationTemplate, 156);
            }
        }
    }

    var question168 = $("input:radio[name='question-168']");
    var question163;
    if (question168.is(":visible") && $("input:radio[name='question-168']:checked").attr("ctrl_answer") == "Yes") {

        question163 = $(".sequence-block .questionid[value='163']").parent().find("input[type='text'].text-question");
        if (question163.is(":visible") == true) {
            if (question163.val() == "") {
                validationTemplate = CreateDisplayTemplate(validationTemplate, 163);
            }
        }
        var question164 = $(".sequence-block .questionid[value='164']").parent().find("input[type='text'].text-question");

        if (question164.is(":visible") == true) {
            if (question164.val() == "") {
                validationTemplate = CreateDisplayTemplate(validationTemplate, 164);
            }
        }
    }


    var question170 = $("input:radio[name='question-170']");
    if (question170.is(":visible") && question170.is(":checked") == false) {
        validationTemplate = CreateDisplayText(validationTemplate, "Average times per week you exercise for at least 20 minutes");
    }

    var question171 = $("input:radio[name='question-171']");
    if (question171.is(":visible") && question171.is(":checked") == false) {
        validationTemplate = CreateDisplayText(validationTemplate, "While exercising, how hard are you breathing? ");
    }

    if ($(".kyn-info #HeightInFeet").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Height");
    }

    if ($(".kyn-info #FastingStatus").val() == "" || $(".kyn-info #FastingStatus").val() == "0") {
        validationTemplate = CreateDisplayText(validationTemplate, "Fasting Status");
    }
    if ($(".kyn-info #KynWeight").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Weight");
    }

    if ($(".kyn-info #Glucose").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Glucose");
    }


    if ($(".kyn-info #WaistSize").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Waist Size");
    }
    if ($(".kyn-info #TotalCholesterol").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Total Cholesterol");
    }
    if ($(".kyn-info #PulseRate").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Pulse Rate");
    }
    if ($(".kyn-info #Triglycerides").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Triglycerides");
    }
    if ($(".kyn-info #SystolicPressure").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Systolic Pressure");
    }
    if ($(".kyn-info #DiastolicPressure").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Diastolic Pressure");
    }
    if ($(".kyn-info #HDLCholesterol").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "HDL Cholesterol");
    }

    //if ($(".kyn-info #A1c").val() == "") {
    //    validationTemplate = CreateDisplayText(validationTemplate, "A1C");
    //}

    if ($(".kyn-info #LdlCholestrol").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "LdlCholestrol");
    }

    //if ($(".kyn-info #BodyFat").val() == "") {
    //    validationTemplate = CreateDisplayText(validationTemplate, "BodyFat");
    //}

    //if ($(".kyn-info #BoneDensity").val() == "") {
    //    validationTemplate = CreateDisplayText(validationTemplate, "BoneDensity");
    //}

    //if ($(".kyn-info #Psa").val() == "") {
    //    validationTemplate = CreateDisplayText(validationTemplate, "Psa");
    //}

    //if ($(".kyn-info #NonHdlCholestrol").val() == "") {
    //    validationTemplate = CreateDisplayText(validationTemplate, "NonHdlCholestrol");
    //}

    //if ($(".kyn-info #Nicotine").val() == "") {
    //    validationTemplate = CreateDisplayText(validationTemplate, "Nicotine");
    //}

    //if ($(".kyn-info #Cotinine").val() == "") {
    //    validationTemplate = CreateDisplayText(validationTemplate, "Cotinine");
    //}

    if ($(".kyn-info #Smoker").val() == "") {
        validationTemplate = CreateDisplayText(validationTemplate, "Smoker");
    }


    if (validationTemplate != "") {
        validationTemplate = "Following information is still not updated on " + (isHkynPurchased ? "HKYN" : (isMyBioCheckPurchased ? "My Bio-Check Assessment" : "KYN")) + " Health Questionnnaire of the customer:<br/> <ul>" + validationTemplate + "</ul>";
        fnOpenNormalDialog(validationTemplate, callbacklSuccess);
    } else {
        if (typeof (callbacklSuccess) == "function") {
            callbacklSuccess();
        }
    }
}

function fnOpenNormalDialog(validationTemplate, callbackSuccess) {
    $("#dialog-confirm").empty();
    $("#dialog-confirm").append(validationTemplate);

    // Define the Dialog and its properties.
    $("#dialog-confirm").dialog({
        resizable: false,
        modal: true,
        title: (isHkynPurchased ? "HKYN" : (isMyBioCheckPurchased ? "My Bio-Check Assessment" : "KYN")) + " Process Validation",
        height: 'auto',
        width: 600,
        buttons: {
            "Skip & Continue": function () {
                $("#dialog-confirm").empty();
                $(this).dialog('close');
                if (typeof (callbackSuccess) == "function") {
                    callbackSuccess();
                }
            },
            "Stay Back & Complete": function () {
                $("#dialog-confirm").empty();
                $(this).dialog('close');
            }
        }
    });
}

$(".decimalonly").keydown(function (e) {
    return KeyPress_DecimalAllowedOnly(e);
});

$(".isNumericOnly").keydown(function (e) {
    return KeyPress_NumericAllowedOnly(e);
});

$("#kynethinic-group input[type='checkbox']").click(function () {
    var ethincGroup = $(this).val();
    $("#Race option").each(function () {
        if ($(this).val() != ethincGroup) {
            $(this).removeAttr("selected");
        } else {
            $(this).attr("selected", "selected");
        }
    });
    ethnicgroupCheckbox(ethincGroup);
});

function ethnicgroupCheckbox(ethincGroup) {
    $("#kynethinic-group input[type='checkbox']").each(function () {
        if ($(this).val() != ethincGroup) {
            $(this).attr("checked", false);
        }
        else
            $(this).attr("checked", true);
    });
}
$(document).ready(function () {
    ethnicgroupCheckbox($("#Race").val());
});

$("select#Race").change(function () {
    ethnicgroupCheckbox($(this).val());
});

function setphqQuestions() {
    $(".phq-question-container").html($(".phq9-section").clone(true));
    $(".phq9-section:first").hide();
}

function SetEnableDisableSingleQuetionsRadiobtn(QuestionId, enable) {

    var sequenceblock = $(".questionid[value='" + QuestionId + "']").closest(".sequence-block");
    if ($(sequenceblock).is(":visible") && enable == true) {
        $(sequenceblock).find("input[type=radio][name='question-" + QuestionId + "']").removeAttr("disabled");
    } else
        if ($(sequenceblock).is(":visible") && enable == false) {
            $(sequenceblock).find("input[type=radio][name='question-" + QuestionId + "']").attr("checked", false);
            $(sequenceblock).find("input[type=radio][name='question-" + QuestionId + "']").attr("disabled", "disabled");
        }
}

function SetEnableDisableSingleQuetionsText(QuestionId, enable) {

    var sequenceblock = $(".questionid[value='" + QuestionId + "']").closest(".sequence-block");
    if ($(sequenceblock).is(":visible") && enable == true) {
        $(sequenceblock).find("input.text-question").removeAttr("disabled");
    } else if ($(sequenceblock).is(":visible") && enable == false) {
        $(sequenceblock).find("input.text-question").val('');
        $(sequenceblock).find("input.text-question").attr("disabled", "disabled");

        var theKey = searchCollection(QuestionId);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function SetEnableDisableHeartSurgeryCheckBox(questionId, enable) {

    var sequenceblock = $(".questionid[value='" + questionId + "']").closest(".sequence-block");
    if ($(sequenceblock).is(":visible") && enable == true) {
        $(sequenceblock).find("input[type=checkbox]").removeAttr("disabled");
    } else if ($(sequenceblock).is(":visible") && enable == false) {

        $(sequenceblock).find("input[type='checkbox']").attr("disabled", "disabled");
        $(sequenceblock).find("input[type='checkbox']").val('');
        $(sequenceblock).find("input[type='checkbox']").removeAttr('checked');

        var theKey = searchCollection(questionId);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function SetEnableDisableSingleCheckBox(questionId, enable) {

    var sequenceblock = $(".questionid[value='" + questionId + "']").closest(".sequence-block");
    if ($(sequenceblock).is(":visible") && enable == true) {
        $(sequenceblock).find("input[type=checkbox]").removeAttr("disabled");
    } else if ($(sequenceblock).is(":visible") && enable == false) {

        $(sequenceblock).find("input[type='checkbox']").attr("disabled", "disabled");
        $(sequenceblock).find("input[type='checkbox']").val('');
        $(sequenceblock).find("input[type='checkbox']").removeAttr('checked');

        var theKey = searchCollection(questionId);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function SetEnableDisableHospitalizedOvernight(enable) {
    SetEnableDisableSingleQuetionsText(551, enable);
    SetEnableDisableSingleQuetionsText(494, enable);
}

function SetEnableDisableDifficultyHoldingUrineQuestions(enable) {
    SetEnableDisableSingleQuetionsRadiobtn(502, enable);
    SetEnableDisableSingleQuetionsText(503, enable);
}

function SetEnableDisableQualityOfLifeWeightLoss(enable) {
    SetEnableDisableSingleQuetionsText(529, enable);
    SetEnableDisableSingleQuetionsText(530, enable);
}

function SetEnableDisableQualityOfLifeConsistentPain(enable) {
    SetEnableDisableSingleQuetionsText(532, enable);
    SetEnableDisableSingleQuetionsText(533, enable);
}

function SetEnableDisableQualityOfLifeMedicationMotrin(enable) {
    SetEnableDisableSingleQuetionsText(535, enable);
    SetEnableDisableSingleQuetionsText(536, enable);
}

function SetEnableDisableQualityOfLifeMedicationAnxiety(enable) {
    SetEnableDisableSingleQuetionsText(538, enable);
    SetEnableDisableSingleQuetionsText(539, enable);
}

function SetEnableDisableQualityOfLifeAnySwelling(enable) {
    var questionId541 = $(".questionid[value='541']").closest(".sequence-block");
    var questionId552 = $(".questionid[value='552']").closest(".sequence-block");

    if (enable) {
        if ($(questionId541).is(":visible")) {
            $(questionId541).find("input[type='checkbox']").removeAttr("disabled");
        }
        if ($(questionId552).is(":visible")) {
            $(questionId552).find("input[type='checkbox']").removeAttr("disabled");
        }
    } else if (enable == false) {
        if ($(questionId541).is(":visible")) {
            $(questionId541).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId541).find("input[type='checkbox']").val('');
            $(questionId541).find("input[type='checkbox']").removeAttr('checked');
        }
        if ($(questionId552).is(":visible")) {
            $(questionId552).find("input[type='checkbox']").attr("disabled", "disabled");
            $(questionId552).find("input[type='checkbox']").val('');
            $(questionId552).find("input[type='checkbox']").removeAttr('checked');
        }
    }
}

function ShowHideSingleQuetionsRadioButton(questionId, showChild) {
    var sequenceblock = $(".questionid[value='" + questionId + "']").closest(".sequence-block");
    if (showChild) {
        $(sequenceblock).show();
    } else if (showChild == false) {
        $(sequenceblock).find("input[type=radio][name='question-" + questionId + "']").attr("checked", false);
        $(sequenceblock).hide();

        var theKey = searchCollection(questionId);
        if (theKey != null) {
            removeObject(theKey);
        }
    }
}

function SetEnableDisableHeartValveSurgery(enable) {

    SetEnableDisableHeartSurgeryCheckBox(588, enable);
    SetEnableDisableHeartSurgeryCheckBox(589, enable);
    SetEnableDisableHeartSurgeryCheckBox(590, enable);
    SetEnableDisableHeartSurgeryCheckBox(591, enable);
}

function SetEnableDisablDoYouHaveCaregiver(enable) {
    SetEnableDisableSingleQuetionsText(1076, enable);
    SetEnableDisableSingleQuetionsText(1077, enable);
    SetEnableDisableSingleQuetionsText(1078, enable);
}

function SetEnableDisablHaveYouSeenSpecialist(enable) {
    SetEnableDisableSingleQuetionsText(1080, enable);
    SetEnableDisableSingleQuetionsText(1081, enable);
    SetEnableDisableSingleQuetionsText(1082, enable);
    SetEnableDisableSingleQuetionsText(1083, enable);
    SetEnableDisableSingleQuetionsText(1084, enable);
    SetEnableDisableSingleQuetionsText(1085, enable);
    SetEnableDisableSingleQuetionsText(1086, enable);
    SetEnableDisableSingleQuetionsText(1087, enable);
    SetEnableDisableSingleQuetionsText(1088, enable);
}

function SetEnableDisablOtcHerbalMedication(enable) {
    SetEnableDisableSingleQuetionsText(1090, enable);
    SetEnableDisableSingleQuetionsText(1091, enable);
    SetEnableDisableSingleQuetionsText(1092, enable);
    SetEnableDisableSingleQuetionsText(1093, enable);
    SetEnableDisableSingleQuetionsText(1094, enable);
    SetEnableDisableSingleQuetionsText(1095, enable);
    SetEnableDisableSingleQuetionsText(1096, enable);
    SetEnableDisableSingleQuetionsText(1097, enable);
    SetEnableDisableSingleQuetionsText(1098, enable);
    SetEnableDisableSingleQuetionsText(1099, enable);
    SetEnableDisableSingleQuetionsText(1100, enable);
    SetEnableDisableSingleQuetionsText(1101, enable);
    SetEnableDisableSingleQuetionsText(1102, enable);
    SetEnableDisableSingleQuetionsText(1103, enable);
    SetEnableDisableSingleQuetionsText(1104, enable);
    SetEnableDisableSingleQuetionsText(1105, enable);
}

function SetEnableDisableInfluenza(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1107, true);
        SetEnableDisableSingleQuetionsRadiobtn(1108, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1107, false);
        SetEnableDisableSingleQuetionsRadiobtn(1108, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1107, false);
        SetEnableDisableSingleQuetionsRadiobtn(1108, false);
    }
}

function SetEnableDisablePneumovax(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsRadiobtn(1110, true);
        SetEnableDisableSingleQuetionsRadiobtn(1111, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsRadiobtn(1110, false);
        SetEnableDisableSingleQuetionsRadiobtn(1111, true);
    }
    else {
        SetEnableDisableSingleQuetionsRadiobtn(1110, false);
        SetEnableDisableSingleQuetionsRadiobtn(1111, false);
    }
}

function SetEnableDisableHerpesZosterVaccine(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1113, true);
        SetEnableDisableSingleQuetionsRadiobtn(1114, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1113, false);
        SetEnableDisableSingleQuetionsRadiobtn(1114, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1113, false);
        SetEnableDisableSingleQuetionsRadiobtn(1114, false);
    }
}

function SetEnableDisableTdapTDVaccine(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsRadiobtn(1116, true);
        SetEnableDisableSingleQuetionsRadiobtn(1117, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsRadiobtn(1116, false);
        SetEnableDisableSingleQuetionsRadiobtn(1117, true);
    }
    else {
        SetEnableDisableSingleQuetionsRadiobtn(1116, false);
        SetEnableDisableSingleQuetionsRadiobtn(1117, false);
    }
}

function SetEnableDisablePrevnar13Vaccine(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsRadiobtn(1119, true);
        SetEnableDisableSingleQuetionsRadiobtn(1120, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsRadiobtn(1119, false);
        SetEnableDisableSingleQuetionsRadiobtn(1120, true);
    }
    else {
        SetEnableDisableSingleQuetionsRadiobtn(1119, false);
        SetEnableDisableSingleQuetionsRadiobtn(1120, false);
    }
}

function SetEnableDisableColonoscopy(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1122, true);
        SetEnableDisableSingleQuetionsRadiobtn(1123, true);
        SetEnableDisableSingleQuetionsRadiobtn(1124, true);
        SetEnableDisableSingleQuetionsRadiobtn(1125, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1122, false);
        SetEnableDisableSingleQuetionsRadiobtn(1123, false);
        SetEnableDisableSingleQuetionsRadiobtn(1124, false);
        SetEnableDisableSingleQuetionsRadiobtn(1125, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1122, false);
        SetEnableDisableSingleQuetionsRadiobtn(1123, false);
        SetEnableDisableSingleQuetionsRadiobtn(1124, false);
        SetEnableDisableSingleQuetionsRadiobtn(1125, false);
    }
}

function SetEnableDisableSigmoidoscopy(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1127, true);
        SetEnableDisableSingleQuetionsRadiobtn(1128, true);
        SetEnableDisableSingleQuetionsRadiobtn(1129, true);
        SetEnableDisableSingleQuetionsRadiobtn(1130, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1127, false);
        SetEnableDisableSingleQuetionsRadiobtn(1128, false);
        SetEnableDisableSingleQuetionsRadiobtn(1129, false);
        SetEnableDisableSingleQuetionsRadiobtn(1130, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1127, false);
        SetEnableDisableSingleQuetionsRadiobtn(1128, false);
        SetEnableDisableSingleQuetionsRadiobtn(1129, false);
        SetEnableDisableSingleQuetionsRadiobtn(1130, false);
    }
}

function SetEnableDisableImmunochemical(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1132, true);
        SetEnableDisableSingleQuetionsRadiobtn(1133, true);
        SetEnableDisableSingleQuetionsRadiobtn(1134, true);
        SetEnableDisableSingleQuetionsRadiobtn(1135, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1132, false);
        SetEnableDisableSingleQuetionsRadiobtn(1133, false);
        SetEnableDisableSingleQuetionsRadiobtn(1134, false);
        SetEnableDisableSingleQuetionsRadiobtn(1135, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1132, false);
        SetEnableDisableSingleQuetionsRadiobtn(1133, false);
        SetEnableDisableSingleQuetionsRadiobtn(1134, false);
        SetEnableDisableSingleQuetionsRadiobtn(1135, false);
    }
}

function SetEnableDisableMammogram(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1137, true);
        SetEnableDisableSingleQuetionsRadiobtn(1138, true);
        SetEnableDisableSingleQuetionsRadiobtn(1139, true);
        SetEnableDisableSingleQuetionsRadiobtn(1140, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1137, false);
        SetEnableDisableSingleQuetionsRadiobtn(1138, false);
        SetEnableDisableSingleQuetionsRadiobtn(1139, false);
        SetEnableDisableSingleQuetionsRadiobtn(1140, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1137, false);
        SetEnableDisableSingleQuetionsRadiobtn(1138, false);
        SetEnableDisableSingleQuetionsRadiobtn(1139, false);
        SetEnableDisableSingleQuetionsRadiobtn(1140, false);
    }
}

function SetEnableDisableOsteoporosis(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1142, true);
        SetEnableDisableSingleQuetionsRadiobtn(1143, true);
        SetEnableDisableSingleQuetionsRadiobtn(1144, true);
        SetEnableDisableSingleQuetionsRadiobtn(1145, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1142, false);
        SetEnableDisableSingleQuetionsRadiobtn(1143, false);
        SetEnableDisableSingleQuetionsRadiobtn(1144, false);
        SetEnableDisableSingleQuetionsRadiobtn(1145, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1142, false);
        SetEnableDisableSingleQuetionsRadiobtn(1143, false);
        SetEnableDisableSingleQuetionsRadiobtn(1144, false);
        SetEnableDisableSingleQuetionsRadiobtn(1145, false);
    }
}

function SetEnableDisableDilatedRetinalExam(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1147, true);
        SetEnableDisableSingleQuetionsRadiobtn(1148, true);
        SetEnableDisableSingleQuetionsRadiobtn(1149, true);
        SetEnableDisableSingleQuetionsRadiobtn(1150, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1147, false);
        SetEnableDisableSingleQuetionsRadiobtn(1148, false);
        SetEnableDisableSingleQuetionsRadiobtn(1149, false);
        SetEnableDisableSingleQuetionsRadiobtn(1150, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1147, false);
        SetEnableDisableSingleQuetionsRadiobtn(1148, false);
        SetEnableDisableSingleQuetionsRadiobtn(1149, false);
        SetEnableDisableSingleQuetionsRadiobtn(1150, false);
    }
}

function SetEnableDisableGlaucomaExam(ctrlAnswer) {
    if (ctrlAnswer == 'Yes') {
        SetEnableDisableSingleQuetionsText(1152, true);
        SetEnableDisableSingleQuetionsRadiobtn(1153, true);
        SetEnableDisableSingleQuetionsRadiobtn(1154, true);
        SetEnableDisableSingleQuetionsRadiobtn(1155, false);
    }
    else if (ctrlAnswer == 'No') {
        SetEnableDisableSingleQuetionsText(1152, false);
        SetEnableDisableSingleQuetionsRadiobtn(1153, false);
        SetEnableDisableSingleQuetionsRadiobtn(1154, false);
        SetEnableDisableSingleQuetionsRadiobtn(1155, true);
    }
    else {
        SetEnableDisableSingleQuetionsText(1152, false);
        SetEnableDisableSingleQuetionsRadiobtn(1153, false);
        SetEnableDisableSingleQuetionsRadiobtn(1154, false);
        SetEnableDisableSingleQuetionsRadiobtn(1155, false);
    }
}

function SetEnableDisableUsedCigarettes(enable) {
    SetEnableDisableSingleCheckBox(1157, enable);
    SetEnableDisableSingleQuetionsText(1158, enable);
    SetEnableDisableSingleQuetionsText(1159, enable);
    SetEnableDisableSingleCheckBox(1160, enable);
    SetEnableDisableSingleCheckBox(1161, enable);
    SetEnableDisableSingleQuetionsText(1162, enable);
    SetEnableDisableSingleQuetionsText(1163, enable);
    SetEnableDisableSingleQuetionsText(1164, enable);
}

function SetEnableDisableTobaccoProducts(enable) {
    SetEnableDisableSingleCheckBox(1166, enable);
    SetEnableDisableSingleQuetionsText(1167, enable);
    SetEnableDisableSingleCheckBox(1168, enable);
    SetEnableDisableSingleQuetionsText(1169, enable);
    SetEnableDisableSingleCheckBox(1170, enable);
}

function SetEnableDisableAssistiveDevices(enable)
{
    SetEnableDisableSingleCheckBox(1178, enable);
    SetEnableDisableSingleCheckBox(1179, enable);
    SetEnableDisableSingleCheckBox(1180, enable);
    SetEnableDisableSingleCheckBox(1181, enable);
}

function SetEnableDisableAssistanceServices(enable) {
    SetEnableDisableSingleCheckBox(1183, enable);
    SetEnableDisableSingleCheckBox(1184, enable);
    SetEnableDisableSingleCheckBox(1185, enable);
    SetEnableDisableSingleCheckBox(1186, enable);
    SetEnableDisableSingleCheckBox(1187, enable);
    SetEnableDisableSingleCheckBox(1188, enable);
    SetEnableDisableSingleCheckBox(1189, enable);
    SetEnableDisableSingleCheckBox(1190, enable);
}

function SetEnableDisableCurrentlyHhaveAnyPain(enable) {
    SetEnableDisableSingleQuetionsRadiobtn(1211, enable);
    SetEnableDisableSingleQuetionsText(1212, enable);
    SetEnableDisableSingleQuetionsText(1213, enable);
    SetEnableDisableSingleQuetionsText(1214, enable);
    SetEnableDisableSingleQuetionsText(1215, enable);
    SetEnableDisableSingleQuetionsText(1216, enable);
    SetEnableDisableSingleQuetionsRadiobtn(1217, enable);
    SetEnableDisableSingleQuetionsRadiobtn(1218, enable);
}

function SetEnableDisableReceiveCareFromVAClinic(enable) {
    SetEnableDisableSingleQuetionsText(1221, enable);
    SetEnableDisableSingleQuetionsText(1222, enable);
    SetEnableDisableSingleQuetionsText(1223, enable);
    SetEnableDisableSingleQuetionsText(1224, enable);
    SetEnableDisableSingleQuetionsText(1225, enable);
    SetEnableDisableSingleQuetionsText(1226, enable);
}

function SetEnableDisableFamilyMembersUnableToGetThings(enable)
{
    SetEnableDisableSingleCheckBox(1233, enable);
    SetEnableDisableSingleCheckBox(1234, enable);
    SetEnableDisableSingleCheckBox(1235, enable);
    SetEnableDisableSingleCheckBox(1236, enable);
    SetEnableDisableSingleCheckBox(1237, enable);
    SetEnableDisableSingleCheckBox(1238, enable);
    SetEnableDisableSingleCheckBox(1239, enable);
    SetEnableDisableSingleCheckBox(1240, enable);
    SetEnableDisableSingleCheckBox(1241, enable);
    SetEnableDisableSingleCheckBox(1242, enable);
}

function SetEnableDisableLackOfTransportation(enable) {
    SetEnableDisableSingleCheckBox(1244, enable);
    SetEnableDisableSingleCheckBox(1245, enable);
    SetEnableDisableSingleCheckBox(1246, enable);
}


function setQuestionDependency() {

    if ($("input[type=radio][name='question-1000'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1000'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableVisitedPcp(false);
    }

    if ($("input[type=radio][name='question-80'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-80'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableRefferalPcp(false);
    }

    if ($("input[type=radio][name='question-1007'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1007'][ctrl_answer='Yes']").attr("checked") == false) {
        EnablePhysicianName(false);
    }

    if ($("input[type=radio][name='question-138'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-138'][ctrl_answer='Yes']").attr("checked") == false) {
        EnablePhysicianFullName(false);
    }

    if ($("input[type=radio][name='question-28'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-28'][ctrl_answer='Yes']").attr("checked") == false) {
        ValidateDiabeticQuestion(false);
    }

    if ($("input[type=radio][name='question-29'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-29'][ctrl_answer='Yes']").attr("checked") == false) {
        ValidateSmokingQuestion(false);
    }

    if ($("input[type=radio][name='question-90'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-90'][ctrl_answer='Yes']").attr("checked") == false) {
        ValidateWeightLossQuestion(false);
    }

    if ($("input[type=radio][name='question-105'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-105'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableCardiovascularSpecialist(false);
    }

    if ($("input[type=radio][name='question-140'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-140'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableCardiovascularSpecialistName(false);
    }

    if ($("input[type=radio][name='question-173'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-173'][ctrl_answer='Yes']").attr("checked") == false) {
        ValidateSmokingQuestion_VCU(false);
    }

    if ($("input[type=radio][name='question-180'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-180'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableVisitedPcp_VCU(false);
    }

    if ($("input[type=radio][name='question-185'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-185'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableEcho(false);
    }

    if ($("input[type=radio][name='question-187'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-187'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableEkg(false);
    }

    if ($("input[type=radio][name='question-189'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-189'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableStroke(false);
    }

    if ($("input[type=radio][name='question-191'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-191'][ctrl_answer='Yes']").attr("checked") == false) {
        EnablePad(false);
    }

    //Mammogram
    if ($("input[type=radio][name='question-115'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-115'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableBreastProblem(false);
    }

    if ($("input[type=radio][name='question-116'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-116'][ctrl_answer='Yes']").attr("checked") == false) {
        EnablePrevoiusMammogram(false);
    }

    if ($("input[type=radio][name='question-119'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-119'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableBreastCancer(false);
    }

    if ($("input[type=radio][name='question-122'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-122'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableBreastMass(false);
    }

    if ($("input[type=radio][name='question-124'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-124'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableBiopsy(false);
    }

    if ($("input[type=radio][name='question-126'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-126'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableImplants(false);
    }

    if ($("input[type=radio][name='question-128'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-128'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableHysterectomy(false);
    }

    if ($("input[type=radio][name='question-132'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-132'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableMenopause(false);
    }

    if ($("input[type=radio][name='question-46'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-46'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableLocationPainExperiencing(false);
    }

    if ($("input[type=radio][name='question-1003'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1003'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableFamilyCancerHistory(false);
    }

    if ($("input[type=radio][name='question-234'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-234'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableColonoscopyLastTime(false);
    }

    if ($("input[type=radio][name='question-218'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-218'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableLocateHarnia(false);
    }

    if ($("input[type=radio][name='question-223'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-223'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableWoundNotHealed(false);
    }

    //Kyn

    if ($("input[type=radio][name='question-155'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-155'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableKynGestationalDiabetes(false);
    }

    if ($("input[type=radio][name='question-301'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-301'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(303, false);
    }
    if ($("input[type=radio][name='question-307'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-307'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(309, false);
    }
    if ($("input[type=radio][name='question-315'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-315'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsText(317, false);
    }
    if ($("input[type=radio][name='question-321'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-321'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsText(323, false);
    }
    if ($("input[type=radio][name='question-325'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-325'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(327, false);
    }
    if ($("input[type=radio][name='question-452'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-452'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsText(454, false);
    }

    if ($("input[type=radio][name='question-472'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-472'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableDisableSpiroSectionOne(false);
    }
    if ($("input[type=radio][name='question-477'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-477'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableDisableSpiroSectionTwo(false);
    }

    //Level One Assessment Questions
    if ($("input[type=radio][name='question-489'][ctrl_answer='Yes']").attr("checked") || $("input[type=radio][name='question-477'][ctrl_answer='No']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(490, false);
    }
    if ($("input[type=radio][name='question-491'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-491'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(492, false);
    }
    if ($("input[type=radio][name='question-493'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-493'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableHospitalizedOvernight(false);
    }
    if ($("input[type=radio][name='question-495'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-495'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsText(496, false);
    }
    if ($("input[type=radio][name='question-497'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-497'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(498, false);
    }
    if ($("input[type=radio][name='question-501'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-501'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableDifficultyHoldingUrineQuestions(false);
    }
    if ($("input[type=radio][name='question-505'][ctrl_answer='Yes']").attr("checked") || $("input[type=radio][name='question-505'][ctrl_answer='No']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(506, false);
    }
    if ($("input[type=radio][name='question-508'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-508'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(509, false);
    }
    if ($("input[type=radio][name='question-510'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-510'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(511, false);
    }
    if ($("input[type=radio][name='question-512'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-512'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(513, false);
    }
    if ($("input[type=radio][name='question-514'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-514'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(515, false);
    }
    if ($("input[type=radio][name='question-516'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-516'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(517, false);
    }
    if ($("input[type=radio][name='question-518'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-518'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(519, false);
    }
    if ($("input[type=radio][name='question-525'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-525'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(526, false);
    }
    if ($("input[type=radio][name='question-528'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-528'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableQualityOfLifeWeightLoss(false);
    }
    if ($("input[type=radio][name='question-531'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-531'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableQualityOfLifeConsistentPain(false);
    }
    if ($("input[type=radio][name='question-534'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-534'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableQualityOfLifeMedicationMotrin(false);
    }
    if ($("input[type=radio][name='question-537'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-537'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableQualityOfLifeMedicationAnxiety(false);
    }
    if ($("input[type=radio][name='question-540'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-540'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableQualityOfLifeAnySwelling(false);
    }
    if ($("input[type=radio][name='question-544'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-544'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsText(545, false);
    }
    if ($("input[type=radio][name='question-560'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-560'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsText(561, false);
    }

    //Risk Assessment
    if ($("input[type=radio][name='question-389'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-389'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableDisableFallWithoutPushed(false);
    }
    if ($("input[type=radio][name='question-395'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-395'][ctrl_answer='Yes']").attr("checked") == false) {
        EnableDisableNeedHelpToPeromDailyActivity(false);
    }
    if ($("input[type=radio][name='question-576'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-576'][ctrl_answer='Yes']").attr("checked") == false) {
        ShowHideSingleQuetionsRadioButton(577, false);
    }

    if ($("input[type=radio][name='question-11'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-11'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableHeartValveSurgery(false);
    }

    if ($("input[type=radio][name='question-1072'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1072'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsRadiobtn(1073, false);
    }

    if ($("input[type=radio][name='question-1073'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1073'][ctrl_answer='Yes']").attr("checked") == false) {
        SetEnableDisableSingleQuetionsText(1074, false);
    }

    //HouseCalls Questions for call center

    if ($("input[type=radio][name='question-1075'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1075'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1075'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisablDoYouHaveCaregiver(false);
    }

    if ($("input[type=radio][name='question-1079'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1079'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1079'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisablHaveYouSeenSpecialist(false);
    }

    if ($("input[type=radio][name='question-1089'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1089'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1089'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisablOtcHerbalMedication(false);
    }

    if ($("input[type=radio][name='question-1106'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableInfluenza('No');
    } else if ($("input[type=radio][name='question-1106'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableInfluenza('Yes');
    } else {
        SetEnableDisableInfluenza('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1109'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisablePneumovax('No');
    } else if ($("input[type=radio][name='question-1109'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisablePneumovax('Yes');
    } else {
        SetEnableDisablePneumovax('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1112'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableHerpesZosterVaccine('No');
    } else if ($("input[type=radio][name='question-1112'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableHerpesZosterVaccine('Yes');
    } else {
        SetEnableDisableHerpesZosterVaccine('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1115'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableTdapTDVaccine('No');
    } else if ($("input[type=radio][name='question-1115'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableTdapTDVaccine('Yes');
    } else {
        SetEnableDisableTdapTDVaccine('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1118'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisablePrevnar13Vaccine('No');
    } else if ($("input[type=radio][name='question-1118'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisablePrevnar13Vaccine('Yes');
    } else {
        SetEnableDisablePrevnar13Vaccine('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1121'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableColonoscopy('No');
    } else if ($("input[type=radio][name='question-1121'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableColonoscopy('Yes');
    } else {
        SetEnableDisableColonoscopy('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1126'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableSigmoidoscopy('No');
    } else if ($("input[type=radio][name='question-1126'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableSigmoidoscopy('Yes');
    } else {
        SetEnableDisableSigmoidoscopy('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1131'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableImmunochemical('No');
    } else if ($("input[type=radio][name='question-1131'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableImmunochemical('Yes');
    } else {
        SetEnableDisableImmunochemical('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1136'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableMammogram('No');
    } else if ($("input[type=radio][name='question-1136'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableMammogram('Yes');
    } else {
        SetEnableDisableMammogram('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1141'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableOsteoporosis('No');
    } else if ($("input[type=radio][name='question-1141'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableOsteoporosis('Yes');
    } else {
        SetEnableDisableOsteoporosis('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1146'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableDilatedRetinalExam('No');
    } else if ($("input[type=radio][name='question-1146'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableDilatedRetinalExam('Yes');
    } else {
        SetEnableDisableDilatedRetinalExam('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1151'][ctrl_answer='No']").is(":checked")) {
        SetEnableDisableGlaucomaExam('No');
    } else if ($("input[type=radio][name='question-1151'][ctrl_answer='Yes']").is(":checked")) {
        SetEnableDisableGlaucomaExam('Yes');
    } else {
        SetEnableDisableGlaucomaExam('Refuse to answer');
    }

    if ($("input[type=radio][name='question-1156'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1156'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1156'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableUsedCigarettes(false);
    }

    if ($("input[type=radio][name='question-1165'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1165'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1165'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableTobaccoProducts(false);
    }

    if ($("input[type=radio][name='question-1171'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1171'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1171'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1172, false);
    }

    if ($("input[type=radio][name='question-1176'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1176'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1176'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableAssistiveDevices(false);
    }

    if ($("input[type=radio][name='question-1182'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1182'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1182'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableAssistanceServices(false);
    }

    if ($("input[type=radio][name='question-1192'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1192'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1192'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1193,false);
    }

    if ($("input[type=radio][name='question-1194'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1194'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1194'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1195,false);
    }

    if ($("input[type=radio][name='question-1196'][ctrl_answer='Yes']").attr("checked") || $("input[type=radio][name='question-1196'][ctrl_answer='No']").attr("checked") == false
        || $("input[type=radio][name='question-1196'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1197, false);
    }

    if ($("input[type=radio][name='question-1198'][ctrl_answer='Yes']").attr("checked") || $("input[type=radio][name='question-1198'][ctrl_answer='No']").attr("checked") == false
        || $("input[type=radio][name='question-1198'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1199, false);
    }

    if ($("input[type=radio][name='question-1201'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1201'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1201'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1202, false);
    }

    if ($("input[type=radio][name='question-1203'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1203'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1203'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1204, false);
    }

    if ($("input[type=radio][name='question-1205'][ctrl_answer='Yes']").attr("checked") || $("input[type=radio][name='question-1205'][ctrl_answer='No']").attr("checked") == false
        || $("input[type=radio][name='question-1205'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1206, false);
    }

    if ($("input[type=radio][name='question-1207'][ctrl_answer='Yes']").attr("checked") || $("input[type=radio][name='question-1207'][ctrl_answer='No']").attr("checked") == false
        || $("input[type=radio][name='question-1207'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1208, false);
    }

    if ($("input[type=radio][name='question-1210'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1210'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1210'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableCurrentlyHhaveAnyPain(false);
    }

    if ($("input[type=radio][name='question-1220'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1220'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1220'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableReceiveCareFromVAClinic(false);
    }

    if ($("input[type=radio][name='question-1229'][ctrl_answer='Yes']").attr("checked") || $("input[type=radio][name='question-1229'][ctrl_answer='No']").attr("checked") == false
        || $("input[type=radio][name='question-1229'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableSingleQuetionsRadiobtn(1230,false);
    }

    if ($("input[type=radio][name='question-1232'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1232'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1232'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableFamilyMembersUnableToGetThings(false);
    }

    if ($("input[type=radio][name='question-1243'][ctrl_answer='No']").attr("checked") || $("input[type=radio][name='question-1243'][ctrl_answer='Yes']").attr("checked") == false
        || $("input[type=radio][name='question-1243'][ctrl_answer='Refuse to answer']").attr("checked")) {
        SetEnableDisableLackOfTransportation(false);
    }
}


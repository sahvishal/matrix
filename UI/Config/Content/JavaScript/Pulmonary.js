function Pulmonary(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypePulmonary,
            "Finding": null,
            "UnableScreenReason": new Array(),
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentPulmonaryInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val()
            }
        };

    }
    this.Result = testResult;
}

Pulmonary.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-pulmonary"), testResult.Finding.Id);
        }

        $("#DescribeSelfPresentPulmonaryInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.ResultImage != null) {
            var newImageArray = new Array();
            newImageArray.push(testResult.ResultImage);
            LoadNewImagesPulmonary(newImageArray, true);
        }

        setUnableScreenReason($('.dtl-unabletoscreen-pulmonary'), testResult.UnableScreenReason);
        
        $("#technotespulmonary").val(testResult.TechnicianNotes);
        $("#conductedbypulmonary option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        
        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksPulmonary").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpPulmonary").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalPulmonary").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        var testFindings = getSelectedFinding($(".gv-findings-pulmonary"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-pulmonary')));


        if (currentScreenMode != ScreenMode.Physician) {

            if (pulmonaryResultMedia != null && pulmonaryResultMedia.length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = pulmonaryResultMedia[0];
                else {
                    var resultMedia = pulmonaryResultMedia[0];
                    resultMedia.Id = testResult.ResultImage.Id;
                    resultMedia.File.Id = testResult.ResultImage.File.Id;
                    resultMedia.Thumbnail.Id = testResult.ResultImage.Thumbnail.Id;
                    testResult.ResultImage = resultMedia;
                }
            }
            else
                testResult.ResultImage = null;
                
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }

        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbypulmonary option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotespulmonary").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentPulmonaryInputCheck").attr("checked");
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksPulmonary").val(), 'IsCritical': $("#criticalPulmonary").attr("checked"), 'FollowUp': $("#followUpPulmonary").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksPulmonary").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpPulmonary").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalPulmonary").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Finding == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                    && testResult.ConductedByOrgRoleUserId == "0" && $("#DescribeSelfPresentPulmonaryInputCheck").attr("checked") == false)
                return null;
        }
        return testResult;
    }
}


var PulmonaryImageCount = 0;
var pulmonaryResultMedia = null;
function LoadNewImagesPulmonary(jsonMedia, correctJson) {
    pulmonaryResultMedia = jsonMedia;
    PulmonaryImageCount = 0;
    $("#PulmonaryImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    PulmonaryImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#PulmonaryImagesContainerDiv"));
}

function getPulmonaryMedia() {
    return pulmonaryResultMedia;
}

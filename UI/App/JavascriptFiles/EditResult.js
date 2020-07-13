var ScreenMode = { 'Entry': 1, 'Physician': 2, 'CorrectionPreEvaluation': 3, 'CorrectionPostEvaluation': 4, 'ViewResults' : 5, 'PostAudit' : 6 };
var currentScreenMode = ScreenMode.Entry;

var ResultEntryType = { 'Hip': 420, 'Chat': 421 };

/* ****************************************************************************************************************** */
/* ******************************************** Standard Findings *************************************************** */
/* ****************************************************************************************************************** */

function autoSelectFinding(tableRef, readingRef, floatPos, findingBoxClass) {
    findingBoxClass = (findingBoxClass == null ? "rbt-finding" : findingBoxClass);

    if ($.trim(readingRef.val()).length < 1) {
        tableRef.find("tr").each(function () {
            $(this).find("." + findingBoxClass).attr("checked", false);
        });
        return;
    }

    if (floatPos == null) {
        floatPos = 2;
    }

    var readingVal = Number(parseFloat($.trim(readingRef.val())).toFixed(floatPos));

    tableRef.find("tr").each(function () {
        
        var minValue = Number(parseFloat($(this).find(".finding-minvalue").val()).toFixed(floatPos));
        var maxValue = Number(parseFloat($(this).find(".finding-maxvalue").val()).toFixed(floatPos));

        if (!isNaN(minValue) && !isNaN(maxValue)) {
            if (readingVal >= minValue && readingVal <= maxValue) {
                $(this).find("." + findingBoxClass).attr("checked", true);
                return;
            }
        }
        else if (!isNaN(minValue)) {
            if (readingVal >= minValue) {
                $(this).find("." + findingBoxClass).attr("checked", true);
                return;
            }
        }
        else if (!isNaN(maxValue)) {
            if (readingVal <= maxValue) {
                $(this).find("." + findingBoxClass).attr("checked", true);
                return;
            }
        }

        $(this).find("." + findingBoxClass).attr("checked", false);

    });
}

function setSelectedFinding(tableRef, id, radiobtncls) {
    if (id == null || id < 1) return;
    
    if (radiobtncls == null) radiobtncls = "rbt-finding";

    tableRef.find("tr").each(function () {
        if ($(this).find(".finding-id").val() == id) {
            $(this).find("." + radiobtncls).attr("checked", true);
            return false;
        }
    });
}

function setSelectedFinding_Horizontal(tableRef, id, radiobtncls) {
    if (id == null || id < 1) return;
    
    if (radiobtncls == null) radiobtncls = "rbt-finding";

    tableRef.find("td").each(function () {
        if ($(this).find(".finding-id").val() == id) {
            $(this).find("." + radiobtncls).attr("checked", true);
            return false;
        }
    });
}

function getSelectedFinding(tableRef, radiobtncls) {
    var id = 0;
    if (radiobtncls == null) radiobtncls = "rbt-finding";

    tableRef.find("tr").each(function () {
        if ($(this).find("." + radiobtncls).attr("checked") == true) {
            id = $(this).find(".finding-id").val();
            return false;
        }
    });

    if (id > 0)
        return { "Id": id };
    else
        return null;
}

function getSelectedFinding_Horizontal(tableRef, radiobtncls) {
    var id = 0;
    if (radiobtncls == null) radiobtncls = "rbt-finding";

    tableRef.find("td").each(function () {
        if ($(this).find("." + radiobtncls).attr("checked") == true) {
            id = $(this).find(".finding-id").val();
            return false;
        }
    });

    if (id > 0)
        return { "Id": id };
    else
        return null;
}


function getSelectedFindingDatalist(tableRef, radiobtncls) {
    var id = 0;
    if (radiobtncls == null) radiobtncls = "rbt-finding";

    tableRef.find("td").each(function () {
        if ($(this).find("." + radiobtncls).attr("checked") == true) {
            id = $(this).find(".finding-id").val();
            return false;
        }
    });

    if (id > 0)
        return { "Id": id };
    else
        return null;
}


function setSelectedFindingDatalist(tableRef, id, radiobtncls) {
    if (id == null || id < 1) return;

    if (radiobtncls == null) radiobtncls = "rbt-finding";

    tableRef.find("td").each(function () {
        if ($(this).find(".finding-id").val() == id) {
            $(this).find("." + radiobtncls).attr("checked", true);
            return false;
        }
    });
}


function getMultipleFindingDatalist(tableRef) {
    var id = 0;
    var coll = new Array();

    tableRef.find("td").each(function () {
        if ($(this).find("input[type=checkbox]").attr("checked") == true) {
            id = $(this).find(".finding-id").val();
            coll.push({ "Id": id });
        }
    });

    if (coll.length > 0)
        return coll;
    else
        return null;
}


function setMultipleFindingDatalist(tableRef, coll) {
    if (coll == null || coll.length < 1)
        return;

    $.each(coll, function () {
        var element = tableRef.find(".finding-id[value='" + this.Id + "']");
        if (element.length > 0) {
            element.parent().find("input[type=checkbox]").attr("checked", true);
        }
    });
}
/* ****************************************************************************************************************** */


/* ****************************************************************************************************************** */
/* ****************************************** Incidental Findings *************************************************** */
/* ****************************************************************************************************************** */

function getSelectedIncidentalFindings(tableRef) {
    var testIncidentalFindings = new Array();
    tableRef.find("span").each(function () {
        if ($(this).find("input:checked").length < 1) return;

        var incidentalFindingId = $(this).find(".hidden-ifid").val();
        var incidentalFinding = { "Id": incidentalFindingId, "CustomerEventTestIncidentalFindingId": 0, "IncidentalFindingGroups": new Array() };


        var testIncidentalFindingID = Number($(this).find(".hidden-iftransactionid").val());
        incidentalFinding.CustomerEventTestIncidentalFindingId = testIncidentalFindingID;

        if ($(this).find(".value-box").length > 0 && $.trim($(this).find(".value-box").val()).length > 0) {

            var group = { "GroupItems": new Array() };

            var groupItem = { "Id": $(this).find(".hidden-groupitemid").val(), "CustomerEventTestGroupItemId": 0, "Value": $.trim($(this).find(".value-box").val()), "Location": 1 };
            group.GroupItems.push(groupItem);
            incidentalFinding.IncidentalFindingGroups.push(group);
        }

        testIncidentalFindings.push(incidentalFinding);

    });
    return testIncidentalFindings;
}

function setSelectedIncidentalFinding(tableRef, incidentalFindings) {
    $.each(incidentalFindings, function () {
        var currentObject = this;

        tableRef.find("span").each(function () {
            var incidentalFindingId = $(this).find(".hidden-ifid").val();
            if (incidentalFindingId != currentObject.Id) return;

            $(this).find("input[type=checkbox]").attr("checked", true);
            $(this).find("input[type=checkbox]").click();
            $(this).find("input[type=checkbox]").attr("checked", true);

            $(this).find(".hidden-iftransactionid").val(currentObject.CustomerEventTestIncidentalFindingId);

            if (currentObject.IncidentalFindingGroups == null || currentObject.IncidentalFindingGroups.length < 1)
                return;

            if ($(this).find(".value-box").length < 1) return;

            var groupItemId = $(this).find(".hidden-groupitemid").val();
            var valueBox = $(this).find(".value-box");

            $.each(currentObject.IncidentalFindingGroups, function () {
                var group = this;
                if (group.GroupItems == null || group.GroupItems.length < 1)
                    return;

                if (group.GroupItems[0].Id == groupItemId)
                    valueBox.val(group.GroupItems[0].Value);

                return;
            });

        });

    });
}

function initialSettingsIncidentalFinding() {
    if (js_arrIFID == null || js_arrIFID == undefined || js_arrIFID.length < 1) return;

    $(".incidental-finding-dtl").each(function () {
        settingForGivenIncidentalFindingTable($(this));
    });
}

function settingForGivenIncidentalFindingTable(tableRef) {
    tableRef.find("span").each(function () {
        var id = $(this).find(".hidden-ifid").val();
        var found = false;
        var groupItemId = 0;
        var index = 0;

        $.each(js_arrIFID, function () {
            if (this == id) {
                found = true;
                groupItemId = js_arrIFGroupItemId[index];
            }
            index++;
        });

        if (found) {
            $(this).append("<input type='text' class='input_bdrbot value-box' style='display:none; width: 100px;' /> <input type='hidden' class='hidden-groupitemid' value='" + groupItemId + "' />");

            $(this).find("input[type=checkbox]").click(function () {
                if ($(this).attr("checked") == true) {
                    $(this).parent().find(".value-box").val("");
                    $(this).parent().find(".value-box").show();
                }
                else
                    $(this).parent().find(".value-box").hide();
            });
        }

    });
}

/* ****************************************************************************************************************** */

function fillConductedBy() {
    $(".conductedby-ddl").html($(".conducted-by option")); 
    
    $(".conductedby-ddl").each(function () {
        $(this).find("option:first").attr("selected", true);
    });
    
}

function imposeMaxLength(evt, Object, MaxLen) {
    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));

    if (key == 8 || key == 46) { return true; }
    return (Object.value.length <= MaxLen);
}


function setboolTypeReading(checkBox, obj) {
    checkBox.attr("checked", false);
    if (obj != null) {
        checkBox.attr("checked", obj.Reading);
    }
}

function SetDropdownListReading(dropdownlistObj, readingObj) {
    if (readingObj != null) {
        $(dropdownlistObj).val(readingObj.Id);
    }
}

function GetDropdownListReading(dropdownlistObj) {
    var value = Number($(dropdownlistObj).val());
    
    if (value > 0)
        return { "Id": value };
    else
        return null;
    
}

function getboolTypeReading(checkBox, obj) {
    if (checkBox.attr("checked") == false)
        return null;

    if (obj == null) {
        obj = { "Reading": true, "Id": 0, "ReadingSource": readingSourceManual, 'RecorderMetaData': {
            'DataRecorderCreator': { 'Id': currentUser },
            'DateCreated': currentDate
        }
        };
    }
    else {
		obj.ReadingSource = obj.Reading != true ? readingSourceManual : obj.ReadingSource;
        obj.Reading = true;
        obj.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
        obj.RecorderMetaData.DateModified = currentDate;
    }
    return obj;
}

function setboolTypeReadingRadioButton(ctrl, obj) {
        
    $(ctrl).find("input[type='radio']").attr("checked", false);
    if (obj != null) {
        $(ctrl).find("input[type='radio'][value='" + obj.Reading + "']").attr("checked", true);
    }
}

function getboolTypeReadingRadioButton(ctrl, obj) {
    if ($(ctrl).find("input[type='radio']:checked").length < 1)
        return null;

    var readingValue = $(ctrl).find("input[type='radio']:checked").attr("value");

    if (obj == null) {
        obj = {
            "Reading": readingValue, "Id": 0, "ReadingSource": readingSourceManual, 'RecorderMetaData': {
                'DataRecorderCreator': { 'Id': currentUser },
                'DateCreated': currentDate
            }
        };
    }
    else {
        obj.ReadingSource = readingSourceManual;
        obj.Reading = readingValue;
        obj.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
        obj.RecorderMetaData.DateModified = currentDate;
    }
    return obj;
}

function setReading(inputBox, obj) {
    inputBox.val("");
    if (obj != null) {
        inputBox.val(obj.Reading);
    }
}

function getReading(inputBox, obj) {
    if ($.trim(inputBox.val()).length < 1)
        return null;

    if (obj == null) {
        obj = { "Reading": $.trim(inputBox.val()), "Id": 0, "ReadingSource": readingSourceManual, 'RecorderMetaData': {
            'DataRecorderCreator': { 'Id': currentUser },
            'DateCreated': currentDate
        }
        };
    }
    else {
		obj.ReadingSource = obj.Reading != $.trim(inputBox.val()) ? readingSourceManual : obj.ReadingSource;
        obj.Reading = $.trim(inputBox.val());
        obj.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
        obj.RecorderMetaData.DateModified = currentDate;
    }
    return obj;
}


function getReadingwithNullValue(inputBox, obj) {

    if (obj == null) {
        obj = { "Reading": null, "Id": 0, "ReadingSource": readingSourceManual, 'RecorderMetaData': {
            'DataRecorderCreator': { 'Id': currentUser },
            'DateCreated': currentDate
        }
        };
    }
    else {
        obj.ReadingSource = obj.Reading != null ? readingSourceManual : obj.ReadingSource;
        obj.Reading = null;
        obj.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
        obj.RecorderMetaData.DateModified = currentDate;
    }
    return obj;
}

function hideAll() {
    $("#testdatasectiondiv").find("input").attr("disabled", "disabled");
    $("#testdatasectiondiv").find("textarea").attr("disabled", "disabled");
    $("#testdatasectiondiv").find("select").attr("disabled", "disabled");
    $(".upload-media-section").hide();
}

function excludeFromHiding(divSpecified) {
    divSpecified.find(".exclude-hide-evaluation input, .finding-section input,.finding-section-checkbox input, .physician-section input").attr("disabled", "");
    divSpecified.find(".exclude-hide-evaluation textarea, .physician-section textarea").attr("disabled", "");
}

// ----------------------------------------------------------------------------------------------------------- //
// ----------------------------------------------------------------------------------------------------------- //

function CorrectDateissue(testResult) {
    if (testResult == null) return null;

    testResult.DataRecorderMetaData = CorrectDataRecorderMetaDataforDates(testResult.DataRecorderMetaData);
    testResult.ResultStatus.DataRecorderMetaData = CorrectDataRecorderMetaDataforDates(testResult.ResultStatus.DataRecorderMetaData);
    //testResult.IncidentalFindings = correctIncidentalFindingDateIssue(testResult.IncidentalFindings);
    //    if (testResult.PhysicianInterpretation != null) {
    //        testResult.PhysicianInterpretation.RecorderMetaData = CorrectDataRecorderMetaDataforDates(testResult.PhysicianInterpretation.RecorderMetaData);
    //    }

    testResult = searchForRecorderMetaData(testResult);

    return testResult;
}

function CorrectDataRecorderMetaDataforDates(recorderMetaData) {
    if (recorderMetaData == null) return null;

    if (recorderMetaData.DateCreated != null) {
        var expr = null;
        eval("expr = " + recorderMetaData.DateCreated + ";");
        eval("recorderMetaData.DateCreated = new " + expr.source + ";");
    }

    if (recorderMetaData.DateModified != null) {
        var expr = null;
        eval("expr = " + recorderMetaData.DateModified + ";");
        eval("recorderMetaData.DateModified = new " + expr.source + ";");
    }

    return recorderMetaData;
}

function searchForRecorderMetaData(object) {
    if (object == null) return null;

    for (var member in object) {
        if (!(member == null || member == undefined)) {
            if (member == "RecorderMetaData") {
                object[member] = CorrectDataRecorderMetaDataforDates(object[member]);
            }
            else if (typeof (object[member]) == "object") {
                object[member] = searchForRecorderMetaData(object[member]);
            }
        }
    }
    return object;
}

function correctIncidentalFindingDateIssue(incidentalFindings) {
    if (incidentalFindings == null) return null;

    $.each(incidentalFindings, function () {
        var currentObject = this;
        if (currentObject.IncidentalFindingGroups == null || currentObject.IncidentalFindingGroups.length < 1)
            return;

        $.each(currentObject.IncidentalFindingGroups, function () {
            var group = this;
            if (group.GroupItems == null || group.GroupItems.length < 1)
                return;

            group.GroupItems[0].RecorderMetaData = CorrectDataRecorderMetaDataforDates(group.GroupItems[0].RecorderMetaData);
            return;
        });

    });

    return incidentalFindings;
}

///--------------------------------------------------------------------------------------------------///
///--------------------------------------------------------------------------------------------------///

function setPhysicianResultStatus(testResult, isTestPermitted) {
    if (isTestPermitted)
        testResult.EvaluatedbyOrgRoleUserId = currentUser;

    testResult.ResultStatus.StateNumber = stateNumberEvaluation;

    if (!isOverReadAvailable) {
        testResult.ResultStatus.Status = statusComplete;
    }
    else {
        if (isCurrentViewforOverread) {
            testResult.ResultStatus.Status = statusComplete;
        }
        else {
            testResult.ResultStatus.Status = statusIncomplete;
        }
    }

    if (isTestPermitted) {
        testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
        testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
    }

    return testResult;
}


function setPostAuditResultStatus(testResult) {

    testResult.ResultStatus.StateNumber = stateNumberPostAudit;
    testResult.ResultStatus.Status = statusIncomplete;
    testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
    testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;

    return testResult;
}

///--------------------------------------------------------------------------------------------------///
///--------------------------------------------------------------------------------------------------///

function getFindingDataandSynchronized(findingObjinDb, currentFindingObj) {
    if (currentFindingObj != null) {
        if (findingObjinDb != null) {
            currentFindingObj.CustomerEventStandardFindingId = findingObjinDb.CustomerEventStandardFindingId;
        }

        return currentFindingObj;

    }
    else
        return null;

}

function getMultipleFindingDataandSynchronized(findingObjinDb, currentFindingObj) {
    if (currentFindingObj == null)
        return null;

    if (findingObjinDb != null) {
        for (var current in currentFindingObj) {
            for (var db in findingObjinDb) {
                if (current.Id == db.Id) {
                    current.CustomerEventStandardFindingId = db.CustomerEventStandardFindingId;
                    break;
                }
            }
        }
    }

    return currentFindingObj;
}

function CompareListfindings(current, alreadyinDb) {
    if (current != null && current.length > 0 && alreadyinDb != null && alreadyinDb.length > 0) {
        var index = 0;
        $.each(current, function () {
            this.CustomerEventStandardFindingId = alreadyinDb[index].CustomerEventStandardFindingId;
            index++;
            if (index == alreadyinDb.length) return false;
        });
    }
    return current;
}
// ----------------------------------------------------------------------------------------------------- //
// ----------------------------------------------------------------------------------------------------- //
// ----------------------------------------------------------------------------------------------------- //


function LoadNewMedia(jsonMedia, correctJson, divReference) {
    divReference.empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    var index = 0;
    var stringHtml = '';

    while (index < jsonMedia.length) {
        if (correctJson) {
            var expr = null;
            eval("expr = " + jsonMedia[index].File.UploadedOn + ";");
            eval("jsonMedia[index].File.UploadedOn = new " + expr.source + ";");

            if (jsonMedia[index].File.Type == fileTypeImage) {
                eval("expr = " + jsonMedia[index].Thumbnail.UploadedOn + ";");
                eval("jsonMedia[index].Thumbnail.UploadedOn = new " + expr.source + ";");
            }
        }

        if (jsonMedia[index].File.Type == fileTypeImage) {
            stringHtml = stringHtml + " <div class='left media-inner-div' style='padding: 5px 10px;'> <a href=\"javascript:void(0)\" class='thumbnail-img'> <img src='" + getUrlPrefix() + jsonMedia[index].Thumbnail.Path + "' alt='' /> </a> <span class='fullsize-imgcontainer' style='display:none'> <input type='hidden' id='hidden-img-src' value='" + getUrlPrefix() + jsonMedia[index].File.Path + "' /> </span></div>";
        }
        else {
            stringHtml = stringHtml + " <div class='left media-inner-div' style='padding: 5px 10px;'> <a href=\"javascript:void(0)\" class='video-img'> <img src='/Content/Images/MovieThumb.gif' alt='' /> </a> <span class='fullsize-imgcontainer' style='display:none'> <input type='hidden' id='hidden-img-src' value='" + getUrlPrefix() + jsonMedia[index].File.Path + "' /> </span></div>";
        }
        index++;
    }

    divReference.append(stringHtml);
    registerQtipForDiv(divReference);
}

$(document).ready(function () {
    //if (currentScreenMode != ScreenMode.Physician) {
        $('#videoplayerfortestmediadiv').dialog({ width: 850, autoOpen: false, title: 'Media Viewer', resizable: false, draggable: true });
        $('#videoplayerfortestmediadiv').dialog("option", "position", ['center', 100]);
    //} else {
    //    $('#videoplayerfortestmediadiv').dialog({ width: 810, height: 580, autoOpen: false, title: 'Media Viewer', resizable: false, draggable: true });
    //}
    
    $('#videoplayerfortestmediadiv').bind('dialogclose', onCloseVideoPLayer);
});

function onImageClick(imgSrc, height) {
    if (height == null)
        height = 560;
    
    $("#imgcontainer").empty();
    $("#imgcontainer").html("<img src='" + imgSrc + "' alt='' style='width: 760px; height: " + height + "px; margin: auto;' />");
    //$("#imgcontainer").html("<img src='" + imgSrc + "' alt='' style='width: 760px; height: 500px; margin: auto;' />");
    $("#ViewImageAnchor").attr("href", imgSrc);
    $("#videoplayerfortestmediadiv").dialog('open');
}

var currentReference;

function registerQtipForDiv(divReference) {
    divReference.find(".thumbnail-img").click(function () {
        //if (currentScreenMode != ScreenMode.Physician) {
            var imgSrc = $(this).parent().find("span input[type=hidden]").val();
            currentReference = $(this);
            checkNextPrevAvailable();
            if (divReference.attr("id") == "SpiroImagesContainerDiv") {
                onImageClick(imgSrc, 750);
            } else {
                onImageClick(imgSrc);
            }
            
        //} else {
        //    viewAllImages(divReference);
        //}
        
    });

    divReference.find(".video-img").click(function () {
        //if (currentScreenMode != ScreenMode.Physician) {
            $("#imgcontainer").empty();
            var imgSrc = $(this).parent().find("span input[type=hidden]").val();
            currentReference = $(this);
            checkNextPrevAvailable();

            //$("#imgcontainer").html("<a href='" + imgSrc + "' style='display: block; width: 760px; height: 560px; margin: auto;' id='player'></a>");

            //flowplayer("player", "/Content/Flash/flowplayer-3.2.7.swf", {
            //    clip: {
            //        onBeforeFinish: function() {
            //            return false;
            //        }
            //    }
        //});
        
            var fileExtensionRegularExpression = /(?:\.([^.]+))?$/;
            if (fileExtensionRegularExpression.exec(imgSrc)[1] == "flv") {
                $('#imgcontainer').html("<a href='" + imgSrc + "' style='display: block; width: 760px; height: 560px; margin: auto;' id='player'></a>");

                flowplayer("player", "/Content/Flash/flowplayer-3.2.7.swf", {
                    clip: {
                        onBeforeFinish: function () {
                            return false;
                        }
                    }
                });
            } else {
                var videoHtml = "<video id='video_player_2' class='video-js vjs-default-skin' controls width='760' height='560' data-setup='{}'>";
                videoHtml = videoHtml + "<source src=" + imgSrc + " type='video/mp4' />";
                videoHtml = videoHtml + "</video>";
                $("#imgcontainer").html(videoHtml);

                VideoJS(document.getElementById('video_player_2'), { "controls": true, "loop": true, "preload": "auto" }, function () {
                    // Player (this) is initialized and ready.
                    this.play();
                });
            }

            $("#videoplayerfortestmediadiv").dialog('open');
        //} else {
        //    viewAllImages(divReference);
        //}
        
    });
}

function viewAllImages(divReference) {
    $("#videoplayerfortestmediadiv").find('table').html("");
    
    $(divReference).find(".media-inner-div").each(function (i) {
        var imgSrc = $(this).find("span input[type=hidden]").val();
        var htmlText = "";
        
        if ($(this).find("a").hasClass('thumbnail-img')) {
            htmlText = "<tr><td style='text-align: right; padding-bottom: 5px; padding-right: 15px;'><a href='" + imgSrc + "' target='_blank'>View Image</a></td></tr>";
            
            htmlText = htmlText + "<tr><td style='width:770px;'>" + "<img src='" + imgSrc + "' alt='' style='width: 760px; height: 500px; margin: auto;' />" + "</td></tr>";
            
            $("#videoplayerfortestmediadiv").find('table').append(htmlText);
        }
        else {
            var mediaId = "player" + i;
            htmlText = "<tr><td style='width:770px;'>" + "<a href='" + imgSrc + "' style='display: block; width: 760px; height: 560px; margin: auto;' id='" + mediaId + "'></a>" + "</td></tr>";
            
            $("#videoplayerfortestmediadiv").find('table').append(htmlText);
            
            flowplayer(mediaId, "/Content/Flash/flowplayer-3.2.7.swf", {
                clip: {
                    autoPlay: true,
                    autoBuffering: true,
                    onBeforeFinish: function() {
                        return false;
                    }
                }
            });
        }
    });
    
    $("#videoplayerfortestmediadiv").dialog('open');
}

function viewEkgImage(imgSrc) {
    $("#videoplayerfortestmediadiv").find('table').html("");
    var htmlText = "<tr><td style='text-align: right; padding-bottom: 5px; padding-right: 15px;'><a href='" + imgSrc + "' target='_blank'>View Image</a></td></tr>";

    htmlText = htmlText + "<tr><td style='width:770px;'>" + "<img src='" + imgSrc + "' alt='' style='width: 760px; height: 500px; margin: auto;' />" + "</td></tr>";

    $("#videoplayerfortestmediadiv").find('table').append(htmlText);
    
    $("#videoplayerfortestmediadiv").dialog('open');
}

function checkNextPrevAvailable() {
    if (currentReference.parent().next().find(".video-img, .thumbnail-img").length < 1) {
        $(".media-navigation-next").hide();
    }
    else if (currentReference.parents(".media-container-div:first")[0] == currentReference.parent().next().find(".video-img, .thumbnail-img").parents(".media-container-div:first")[0]) {
        $(".media-navigation-next").show();
    }

    if (currentReference.parent().prev().find(".video-img, .thumbnail-img").length < 1) {
        $(".media-navigation-prev").hide();
    }
    else if (currentReference.parents(".media-container-div:first")[0] == currentReference.parent().prev().find(".video-img, .thumbnail-img").parents(".media-container-div:first")[0]) {
        $(".media-navigation-prev").show();
    }        
}

function onNextClick_MediaTraversing() {
    if (currentReference.parent().next().find(".video-img, .thumbnail-img").length > 0)
        currentReference.parent().next().find(".video-img, .thumbnail-img").click();
}

function onPreviousClick_MediaTraversing() {
    if (currentReference.parent().prev().find(".video-img, .thumbnail-img").length > 0)
        currentReference.parent().prev().find(".video-img, .thumbnail-img").click();
}

function onCloseVideoPLayer() {
    //if (currentScreenMode != ScreenMode.Physician) {
        $("#imgcontainer").empty();
    //}
    //else {
    //    $("#videoplayerfortestmediadiv").find('table').html("");
    //}
    return false;
}


// ----------------------------------------------------------------------------------------- //
// ----------------------------------------------------------------------------------------- //
// ----------------------------------------------------------------------------------------- //


function Age(DateofBirth) {//debugger
    var DOB = DateofBirth;
    var Byear;
    Byear = DOB.split('/')[2];
    var Bmonth;
    Bmonth = DOB.split('/')[0];
    var Bday;
    Bday = DOB.split('/')[1];
    var age;
    var now = new Date();
    Tday = now.getDate();
    Tmo = (now.getMonth());
    Tmo = Tmo + 1; //now.getMonth() gives value from 0 to 11(0 for January)
    Tyr = (now.getFullYear());

    {
        if ((Tmo > Bmonth) || (Tmo == Bmonth & Tday >= Bday))
        { age = Byear }

        else
        { age = parseInt(Byear) + 1 }
        return (parseInt(Tyr) - parseInt(age));
    }
}

// ----------------------------------------------------------------------------------------- //
// ------------------------------- Unable Screen Reason ------------------------------------ //

function setUnableScreenReason(datalist, unableScreenReason) {

    if (unableScreenReason == null || unableScreenReason.length < 1) return;

    $.each(unableScreenReason, function () {
        var currentUnableScreenReason = this.Reason;

        datalist.find("input[type=hidden]").each(function () {
            if ($(this).val() == currentUnableScreenReason) {
                $(this).parent().find('input:checkbox').attr("checked", true);
            }
        });
    });

}

function getUnableScreenReason(datalist) {
    var unableScreenReason = new Array();
    datalist.find('span').each(function () {
        if ($(this).find('input:checkbox').attr("checked")) {
            var currentUnableScreenReason = $(this).find('input:hidden').val();
            var entity = { "Reason": currentUnableScreenReason };
            unableScreenReason.push(entity);
        }
    });

    if (unableScreenReason.length < 1) {
        unableScreenReason = null;
    }

    return unableScreenReason;
}

function SynchronizeUnableScreenReason(inDbCollection, currentCollection) {
    if(currentCollection == null || currentCollection.length < 1) return null;

    if (inDbCollection != null && inDbCollection.length > 0) {
        var index = 0;
        while (currentCollection.length > index && inDbCollection.length > index) {
            currentCollection[index].Id = inDbCollection[index].Id;
            index++;
        }
    }
    return currentCollection;
}

function removeTypeAttribute(testResult) {
    s = JSON.stringify(testResult);
    var match = /\"__type\":\"([^\\\"]|\\.)*\",/;
    s = s.replace(/\"__type\":\"([^\\\"]|\\.)*\",/, "");
    eval("testResult = " + s);
    return testResult;
}

function IsTestPermitted(testId) {
    if (arr_permittedtest == null) return false;
    for (var i = 0; i < arr_permittedtest.length; i++) {
        var test = arr_permittedtest[i];
        if (test == testId) return true;
    }
    return false;
}


function CompareIfObject(testResultIncidentalFindings, actualTestResultIncidentalFindings) {
    if(IsArrayNullOrEmpty(testResultIncidentalFindings)) return null;

    if (IsArrayNullOrEmpty(actualTestResultIncidentalFindings)) return testResultIncidentalFindings;

    $.each(testResultIncidentalFindings, function () {
        var newIncidentalFinding = this;
        var existingIncidentalFinding = null;

        $.each(actualTestResultIncidentalFindings, function () {
            if (this.Id == newIncidentalFinding.Id)
                existingIncidentalFinding = this;
        });

        if (existingIncidentalFinding == null) return;

        newIncidentalFinding.CustomerEventTestIncidentalFindingId = existingIncidentalFinding.CustomerEventTestIncidentalFindingId;

        if (IsArrayNullOrEmpty(newIncidentalFinding) || IsArrayNullOrEmpty(existingIncidentalFinding))
            return;

        $.each(newIncidentalFinding.IncidentalFindingGroups, function () {

            if (IsArrayNullOrEmpty(this.GroupItems)) return;

            $.each(this.GroupItems, function () {
                var existingGroupItem = FindIfGroupItemExists(existingIncidentalFinding.IncidentalFindingGroups, this.Id, this.Location);
                if (existingGroupItem != null) {
                    this.CustomerEventTestGroupItemId = existingGroupItem.CustomerEventTestGroupItemId;
                    this.RecorderMetaData = existingGroupItem.RecorderMetaData;
                    this.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                    this.RecorderMetaData.DateModified = currentDate;
                }
                else {
                    this.RecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    };
                }
            });

        });

    });

    return testResultIncidentalFindings;
}

function FindIfGroupItemExists(incidentalFindingGroups, groupItemId, location) {
    var existingGroupItem = null;
    $.each(incidentalFindingGroups, function () {
        if (IsArrayNullOrEmpty(this.GroupItems)) return;

        $.each(this.GroupItems, function () {
            if (this.Id == groupItemId && location == this.Location)
                existingGroupItem = this;
        });
    });

    return existingGroupItem;
}

function IsArrayNullOrEmpty(arrayToCheck) {
    if (arrayToCheck == null || arrayToCheck.length < 1)
        return true;

    return false;
}


function SetConductedBy(testType, conductedByDdl) {

    try {
        if (!defaultStaffCollection == undefined || defaultStaffCollection == null) return;
    }
    catch (e) {
        return;
    }

    for (var i = 0; i < defaultStaffCollection.length; i++) {
        var staff = defaultStaffCollection[i];
        if (staff.FirstValue == testType) {
            conductedByDdl.find("option[value=" + staff.SecondValue + "]").attr("selected", true);
        }
    }
}

$(document).ready(function () {
    $("#systolicbp, #diastolicbp").change(function () {
        var result = CheckElevatedBP();

        if (result) {
            $("#isElevatedBp").attr("checked", "checked");
        }
        else {
            $("#isElevatedBp").attr("checked", false);
        }
    });

});


function setTestNotPerformed(controlId, testNotPerfromedObject) {
    if (typeof testNotPerfromedObject === 'undefined' || testNotPerfromedObject == null) return;
    var section = $("#" + controlId);
    $(section).find("input[type='checkbox']").attr("checked", "checked ");

    $(section).find(".test-not-performed-container").show();

    if (testNotPerfromedObject.TestNotPerformedReasonId > 0) {
        $(section).find("select").val(testNotPerfromedObject.TestNotPerformedReasonId);
    }

    $(section).find("textarea").val(testNotPerfromedObject.Notes);
}

function getTestNotPerformed(controlId, testNotPerfromedObject) {
    if (typeof testNotPerfromedObject === 'undefined' || testNotPerfromedObject == null) {
        testNotPerfromedObject = new Object();
    }

    var section = $("#" + controlId);
    var isChecked = $(section).find("input[type='checkbox']").is(":checked");

    if (isChecked) {
        testNotPerfromedObject.TestNotPerformedReasonId = $(section).find("select").val();
        testNotPerfromedObject.Notes = $(section).find("textarea").val();
        testNotPerfromedObject.IsManual = true;
    } else {
        testNotPerfromedObject = null;
    }

    return testNotPerfromedObject;
}

function ShowTestNotPerformedSection(obj) {
    var section = $(obj).closest(".test-not-performed-section");
    SetTestNotPerformedEnableDisabled($(section).attr("id"));
    if ($(obj).is(":checked")) {
        $(section).find(".test-not-performed-container").show();
    } else {
        $(section).find(".test-not-performed-container").hide();
        $(section).find("select").val('');
        $(section).find("textarea").val('');
    }
}

function txtkeypress_AlphanumericOnly(evt)//Allows only alphanumeric
{
    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    if (key == 9 || key == 13 || key == 8 || key == 32 || key == 20 || key == 46 || (key >= 37 && key <= 40) || (key >= 65 && key <= 90) || (((key >= 48 && key <= 57) || (key >= 96 && key <= 105)) && (evt.shiftKey == false))) {
        return true;
    }
    return false;
}

function setTestPerformedExternally(controlId, testPerformedExternallyObject) {
    if (typeof testPerformedExternallyObject === 'undefined' || testPerformedExternallyObject == null) return;
    var section = $("#" + controlId);
    if (testPerformedExternallyObject.EntryCompleted)
    {
        section.attr("checked", true);
    }
    else {
        section.attr("checked", false);
    }

}
function getTestPerformedExternally(controlId, testPerformedExternallyObject) {
    if (typeof testPerformedExternallyObject === 'undefined' || testPerformedExternallyObject == null) {
        testPerformedExternallyObject = new Object();
    }
    var section = $("#" + controlId);
    var isChecked = $(section).is(":checked");
    testPerformedExternallyObject.EntryCompleted = isChecked;
    testPerformedExternallyObject.ResultEntryTypeId = ResultEntryType.Chat;
    if (testPerformedExternallyObject.Id > 0) {
        testPerformedExternallyObject.CreatedBy = currentUser;
        testPerformedExternallyObject.CreatedDate = currentDate;
        testPerformedExternallyObject.ModifiedBy = currentUser;
        testPerformedExternallyObject.ModifiedDate = currentDate;
    } else {
        testPerformedExternallyObject.CreatedBy = currentUser;
        testPerformedExternallyObject.CreatedDate = currentDate;
    }
    return testPerformedExternallyObject;
}


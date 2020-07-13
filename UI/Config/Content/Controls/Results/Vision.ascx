<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Vision.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Vision" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Vision.js?q=<%= VersionNumber %>"></script>
<div id="vision_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Vision Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyVision" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="vision-critical-span">
        <input type="checkbox" id="DescribeSelfPresentVisionInputCheck" onclick="onClick_CriticalDataVision();" />Critical </span>
    <span class="chk_orngband" id="vision-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestVisionCheck" onclick="onClick_PriorityInQueueDataVision();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="vision-retest-span">
        <input type="checkbox" id="Retest_44" />Retest
    </span>
</div>
<div class="left_info1" id="ConfrontationBothEyeDiv" runat="server" style="padding-left: 0px; display: block;">
    <div style="width: 300px; border: solid 1px black; padding: 10px;">
        <div><b>CONFRONTATION Section (Both EYES OPEN)</b></div>
        <table style="height: 150px;">
            <tr>
                <td style="width: 200px;"></td>
                <td style="width: 50px;"><b>Pass</b></td>
                <td><b>Fail</b></td>
            </tr>
            <tr class="bothEyesLeftUpperQuadrant">
                <td>Left upper quadrant</td>
                <td>
                    <input type="radio" value="true" name="BothEyesLeftUpperQuadrant" />
                </td>
                <td>
                    <input type="radio" value="false" name="BothEyesLeftUpperQuadrant" />
                </td>
            </tr>
            <tr class="bothEyesLeftLowerQuadrant">
                <td>Left  lower quadrant</td>
                <td>
                    <input type="radio" value="true" name="BothEyesLeftLowerQuadrant" />
                </td>
                <td>
                    <input type="radio" value="false" name="BothEyesLeftLowerQuadrant" />
                </td>
            </tr>
            <tr class="bothEyesRightUpperQuadrant">
                <td>Right upper quadrant</td>
                <td>
                    <input type="radio" value="true" name="BothEyesRightUpperQuadrant" />
                </td>
                <td>
                    <input type="radio" value="false" name="BothEyesRightUpperQuadrant" />
                </td>
            </tr>
            <tr class="bothEyesRightLowerQuadrant">
                <td>Right lower quadrant</td>
                <td>
                    <input type="radio" value="true" name="BothEyesRightLowerQuadrant" />
                </td>
                <td>
                    <input type="radio" value="false" name="BothEyesRightLowerQuadrant" />
                </td>
            </tr>
        </table>
    </div>

</div>
<div class="rgt_info1" style="float: right;">
    <div class="rgt_gbox">
        <div class="grow">
            <span class="left" style="width: 150px;"><b>Vision Level:&nbsp;&nbsp;</b><br />
                Right eye
                <input type="text" id="RightEyeCylindrical" style="width: 25px;" class="input_bdrbot" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                <span style="margin-top: 10px;">/</span>
                <input type="text" id="RightEyeSpherical" style="width: 25px;" class="input_bdrbot" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
            </span>
            <span class="right">
                <br />
                Left eye
                <input type="text" id="LeftEyeCylindrical" style="width: 25px;" class="input_bdrbot" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                <span style="margin-top: 10px;">/</span>
                <input type="text" id="LeftEyeSpherical" style="width: 25px;" class="input_bdrbot" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
            </span>

        </div>
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesVision" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedVision">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonVision" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
            </asp:DropDownList>
            <br />
            <div>
                <b>Notes :</b>
                <br />
                <textarea rows="2" cols="54"></textarea>
            </div>
        </div>
    </div>
</div>
<div class="contentrow" id="ConfrontationOneEyeDiv" runat="server" style="border: 1px solid black; width: 720px; padding-top: 10px; padding-bottom: 10px; margin-top: 10px; margin-bottom: 10px; display: block;">
    <div style="padding-left: 10px">
        <div><b>CONFRONTATION Section (One eye at a time)</b></div>
        <div class="left_info1" style="width: 400px; padding-left: 0px">
            <div style="float: left; width: 100%"><b>RIGHT EYE</b></div>
            <table style="height: 150px;">
                <tr>
                    <td style="width: 200px;"></td>
                    <td style="width: 50px;"><b>Pass</b></td>
                    <td><b>Fail</b></td>
                </tr>
                <tr class="rightEyeLeftUpperQuadrant">
                    <td>Left upper quadrant</td>
                    <td>
                        <input type="radio" value="true" name="RightEyeLeftUpperQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="RightEyeLeftUpperQuadrant" />
                    </td>
                </tr>
                <tr class="rightEyeLeftLowerQuadrant">
                    <td>Left  lower quadrant</td>
                    <td>
                        <input type="radio" value="true" name="RightEyeLeftLowerQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="RightEyeLeftLowerQuadrant" />
                    </td>
                </tr>
                <tr class="rightEyeRightUpperQuadrant">
                    <td>Right upper quadrant</td>
                    <td>
                        <input type="radio" value="true" name="RightEyeRightUpperQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="RightEyeRightUpperQuadrant" />
                    </td>
                </tr>
                <tr class="rightEyeRightLowerQuadrant">
                    <td>Right lower quadrant</td>
                    <td>
                        <input type="radio" value="true" name="RightEyeRightLowerQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="RightEyeRightLowerQuadrant" />
                    </td>
                </tr>
            </table>

        </div>
        <div class="rgt_info1" style="width: 285px;">
            <div style="float: left; width: 100%"><b>LEFT EYE</b></div>
            <table style="height: 150px;">
                <tr>
                    <td style="width: 200px;"></td>
                    <td style="width: 50px;"><b>Pass</b></td>
                    <td><b>Fail</b></td>
                </tr>
                <tr class="leftEyeLeftUpperQuadrant">
                    <td>Left upper quadrant</td>
                    <td>
                        <input type="radio" value="true" name="LeftEyeLeftUpperQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="LeftEyeLeftUpperQuadrant" />
                    </td>
                </tr>
                <tr class="leftEyeLeftLowerQuadrant">
                    <td>Left  lower quadrant</td>
                    <td>
                        <input type="radio" value="true" name="LeftEyeLeftLowerQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="LeftEyeLeftLowerQuadrant" />
                    </td>
                </tr>
                <tr class="leftEyeRightUpperQuadrant">
                    <td>Right upper quadrant</td>
                    <td>
                        <input type="radio" value="true" name="LeftEyeRightUpperQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="LeftEyeRightUpperQuadrant" />
                    </td>
                </tr>
                <tr class="leftEyeRightLowerQuadrant">
                    <td>Right lower quadrant</td>
                    <td>
                        <input type="radio" value="true" name="LeftEyeRightLowerQuadrant" />
                    </td>
                    <td>
                        <input type="radio" value="false" name="LeftEyeRightLowerQuadrant" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="labelwdt2 finding" style="margin-left: 10px; margin-top: 10px;">
    <asp:DataList runat="server" ID="UnableToScreenVisionDataList" EnableViewState="false"
        RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Vision" GridLines="None"
        RepeatDirection="Horizontal">
        <ItemTemplate>
            <input type="checkbox" id="chkUnableScreenReason" />
            <b>Unable To Screen</b>
            <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
        </ItemTemplate>
    </asp:DataList>
</div>
    </div>
<div id="vision_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Vision Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyVision" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="vision-retest-span">
            <input type="checkbox" id="Retest_44" />Retest
        </span>
    </div>
    <div class="hrows vision-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_visioncapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeVision = '<%= (long)TestType.Vision %>';
    var IsvisionResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var vision = null;
    function SetVisionData(testResult) {
        vision = new Vision(testResult);
        vision.setData();
    }

    function GetVisionData() {
        if (vision == null) vision = new Vision();
        return vision.getData();
    }

</script>

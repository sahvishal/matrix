<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Qv.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Qv" %>

<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Users.Domain" %>

<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Qv.js?q=<%= VersionNumber %>"></script>
<style type="text/css">
    .dob_pop {
        width: 302px;
        padding: 10px;
        background-color: #f5f5f5;
    }

    .dob_popin {
        width: 278px;
        padding: 10px;
    }

    .dob_popinmain {
        float: left;
        width: 100%;
        margin-top: 5px;
    }

        .dob_popinmain label {
            font-weight: bold;
            padding-top: 20px;
        }

        .dob_popinmain .inpt {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            z-index: -5;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
            margin-right: 20px;
        }

    .btnrgt {
        float: right;
        padding-right: 5px;
    }

    .input-small {
        border-bottom: 1px solid #535353;
        border-left: 0px;
        background-color: transparent;
        border-right: 0px;
        border-top: 0px;
        width: 40px;
        font-size: 10px;
        color: #666666;
        padding-left: 5px;
    }

    .lnkred {
        color: red;
        text-decoration: none;
    }

        .lnkred a:link {
            color: red;
            text-decoration: underline;
        }

        .lnkred a:visited {
            color: red;
            text-decoration: underline;
        }

        .lnkred a:hover {
            color: red;
            text-decoration: underline;
        }
</style>
<div id="qv_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 120px">
            <span class="org-heading" style="width: 120px"><strong>QV Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyqv" class="conductedby-ddl">
            </select>
        </span>
       <%-- <span class="chk_orngband" id="qv-critical-span">
            <input type="checkbox" id="SelfPresentQvInputCheck" onclick="onClick_CriticalDataQv();" />Critical</span>
        <span class="chk_orngband" id="qv-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestQvCheck" onclick="onClick_PriorityInQueueDataQv();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="qv-retest-span">
            <input type="checkbox" id="Retest_102" />Retest
        </span>--%>
    </div>
    <div class="contentrow " style="width: 99%; padding-left: 0px;">
        <div class="hlfbox" style="display:none;">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_qvcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
        <div style="float: left; clear: none; padding-top: 0; display:none;" class="test-not-performed-section" id="testnotPerformedQv">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonQv" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
</div>



<div id="qv_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>QV Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyqv" class="conductedby-ddl">
            </select>
        </span>
      <%--  <span class="chk_orngband" id="qv-critical-span">
            <input type="checkbox" id="SelfPresentQvInputCheck" onclick="onClick_CriticalDataQv();" />Critical
        </span>
        <span class="chk_orngband" id="qv-retest-span">
            <input type="checkbox" id="Retest_102" />Retest
        </span>--%>
    </div>
    <div class="contentrow " style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_qvcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
        <div style="float: left; clear: none; padding-top: 0; display:none;" class="test-not-performed-section" id="testnotPerformedQv">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonQv_Chat" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
</div>


<script language="javascript" type="text/javascript">
    var testTypeQv = '<%= (long)TestType.Qv %>';
    var IsqvResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var qv = null;
    function SetQvData(testResult) {
        qv = new Qv(testResult);
        qv.setData();
    }

    function GetQvData() {
        if (qv == null) qv = new Qv();
        return qv.getData();
    }

</script>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Imt.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Imt" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Imt.js?q=<%= VersionNumber %>"></script>

<div id="imt_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Intima-Media Thickness (IMT) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyimt" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="imt-critical-span">
        <input type="checkbox" id="DescribeSelfPresentImtInputCheck" onclick="onClick_CriticalDataImt();" />Critical </span>
    <span class="chk_orngband" id="imt-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestImtCheck" onclick="onClick_PriorityInQueueDataImt();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="imt-retest-span">
        <input type="checkbox" id="Retest_8" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="lrow finding">
        <asp:GridView runat="server" Style="float: left;" CssClass="gv-findings-imt finding-section"
            ID="StandardFindingsImtGridView" EnableViewState="false" AutoGenerateColumns="False"
            ShowHeader="False" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="lrow small">
                            <div class="listchkbox">
                                <input type="radio" name="rbtFindingsImt" class="rbt-finding" />
                            </div>
                            <div class="lfttoppad">
                                <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            </div>
                        </div>
                        <input type="hidden" id="FindingImtInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                        <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="lrow margin-top-small">
        <asp:DataList runat="server" ID="UnableToScreenImtDataList" CssClass="dtl-unabletoscreen-imt unable-to-screen-section"
            RepeatLayout="Flow" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# (int)DataBinder.Eval(Container.DataItem, "Reason") %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesimt" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<div class="rgt_gbox">
    <div class="grow">
        <div class="left" style="display: block; width: 60%;">
            <strong>QIMT Left: </strong>
            <input type="text" id="qimtlefttextbox" class="input_bdrbot" style="width: 40px;"
                onkeydown="return KeyPress_NumericAllowedOnly(event);" />
            &nbsp; &nbsp; <strong>Right: </strong>
            <input type="text" id="qimtrighttextbox" class="input_bdrbot" style="width: 40px;"
                onkeydown="return KeyPress_NumericAllowedOnly(event);" />
        </div>
        <div class="left" style="display: block; width: 40%; text-align: right;">
            <strong>Expected QIMT: </strong>
            <input type="text" id="expectedqimttextbox" class="input_bdrbot" style="width: 70px;"
                onkeydown="return KeyPress_NumericAllowedOnly(event);" />
        </div>
    </div>
</div>
<div class="contentrowltpad upload-media-section">
    <a href="javascript:OpenPopUp('Upload Images', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.IMT %>&CustomerId=' + customerId);">Upload Media</a>
</div>
<div id="imtImagesContainerDiv" class="contentrowltpad media-container-div">
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalImt" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksImt" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
</div>

<div id="imt_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Intima-Media Thickness (IMT) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyimt" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="imt-retest-span">
            <input type="checkbox" id="Retest_8" />Retest
        </span>
    </div>
    <div class="hrows imt-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_imtcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeImt = '<%= (long)TestType.IMT %>';
    var IsimtResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    $(document).ready(function () {
        SetConductedBy(testTypeImt, $("#conductedbyimt"));
    });

    var imt = null;
    function SetImtData(testResult) {
        imt = new Imt(testResult);
        imt.setData();
    }

    function GetImtData() {
        if (imt == null) imt = new Imt();
        return imt.getData();
    }
</script>

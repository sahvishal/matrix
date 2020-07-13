<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Kyn.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Kyn" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="System.IO" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Kyn.js?q=<%= VersionNumber %>"></script>
<style type="text/css">
    .kynreporttable {
        width: 100%;
        text-align: center;
    }

        .kynreporttable td {
            width: 25%;
        }
</style>
<div id="kyn_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>KYN Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyKYN" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="kyn-critical-span">
        <input type="checkbox" id="DescribeSelfPresentKYNInputCheck" onclick="onClick_CriticalDataKyn();" />Critical</span>
    <span class="chk_orngband" id="kyn-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestKynCheck" onclick="onClick_PriorityInQueueDataKyn();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="kyn-retest-span">
        <input type="checkbox" id="Retest_23" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenKYNDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-KYN" GridLines="None" RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesKYN" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<div style="float: left; margin-top: 10px; width: 98%;">
    <%
        string letterWriterFilePath, participantSummReportFilePath, physicianSummReportFilePath;
        string letterWriterFileUrl, participantSummReportFileUrl, physicianSummReportFileUrl;

        letterWriterFilePath =
            participantSummReportFilePath = physicianSummReportFilePath = string.Empty;

        var repository = IoC.Resolve<IMediaRepository>();
        var location = EventId > 0 ? repository.GetKynIntegrationOutputDataLocation(EventId, CustomerId) : null;

        if (location != null && Directory.Exists(location.PhysicalPath))
        {

            var files = Directory.GetFiles(location.PhysicalPath, TestType.Kyn + "_*.pdf");

            if (files.Count() > 0)
            {
                letterWriterFilePath = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.LetterWriter));
                participantSummReportFilePath = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.ParticipantSummaryReport));
                physicianSummReportFilePath = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.PhysicianSummaryReport));
            }
        }
        
    %>
    <table class="kynreporttable">
        <tr>
            <td class="<%= KynFileTypes.LetterWriter %>">
                <div class="file">
                    <% if (!string.IsNullOrEmpty(letterWriterFilePath))
                       {
                           letterWriterFileUrl = location.Url + Path.GetFileName(letterWriterFilePath);
                    %>
                    <img src="/App/Images/pdf-icon-mm.gif" alt="" onclick="ViewKynFile('<%= letterWriterFileUrl %>', 'Letter Writer');"
                        style="cursor: pointer;" />
                    <%}
                       else
                       {%>
                    <img src="/Content/Images/PageNotFound-Icons.jpg" alt="" />
                    <%}
                    %>
                </div>
                <div class="action-link">
                    <a href="javascript:uploadKynFile('<%= KynFileTypes.LetterWriter%>'); void(0);">Upload</a>&nbsp;&nbsp;
                    <% if (!string.IsNullOrEmpty(letterWriterFilePath))
                       {%><a href="javascript:removeKynImage('<%= KynFileTypes.LetterWriter%>'); void(0);"
                           class='remove-link'>Remove</a>
                    <%}
                       else
                       { %>
                    <a href="javascript:removeKynImage('<%= KynFileTypes.LetterWriter%>'); void(0);"
                        class='remove-link' style="display: none;">Remove</a>
                    <%}%>
                </div>
                <div style="display: none;" class="action-link">
                    <img src="/App/Images/loading.gif" alt="" />
                </div>
                <br />
                <b>Letter Writer </b>
            </td>
            <td class="<%= KynFileTypes.ParticipantSummaryReport %>">
                <div class="file">
                    <% if (!string.IsNullOrEmpty(participantSummReportFilePath))
                       {
                           participantSummReportFileUrl = location.Url + Path.GetFileName(participantSummReportFilePath);
                    %>
                    <img src="/App/Images/pdf-icon-mm.gif" alt="" onclick="ViewKynFile('<%= participantSummReportFileUrl %>', 'Participant Summary Report');"
                        style="cursor: pointer;" />
                    <%}
                       else
                       {%>
                    <img src="/Content/Images/PageNotFound-Icons.jpg" alt="" />
                    <%}%>
                </div>
                <div class="action-link">
                    <a href="javascript:uploadKynFile('<%= KynFileTypes.ParticipantSummaryReport%>'); void(0);">Upload</a>&nbsp;&nbsp;
                    <% if (!string.IsNullOrEmpty(participantSummReportFilePath))
                       {%>
                    <a href="javascript:removeKynImage('<%= KynFileTypes.ParticipantSummaryReport%>'); void(0);"
                        class='remove-link'>Remove</a>
                    <%}
                       else
                       { %>
                    <a href="javascript:removeKynImage('<%= KynFileTypes.ParticipantSummaryReport%>'); void(0);"
                        class='remove-link' style="display: none;">Remove</a>
                    <%}%>
                </div>
                <div style="display: none;" class="action-link">
                    <img src="/App/Images/loading.gif" alt="" />
                </div>
                <br />
                <b>Participant Summary Report</b>
            </td>
            <td class="<%= KynFileTypes.PhysicianSummaryReport %>">
                <div class="file">
                    <% if (!string.IsNullOrEmpty(physicianSummReportFilePath))
                       {
                           physicianSummReportFileUrl = location.Url + Path.GetFileName(physicianSummReportFilePath);
                    %>
                    <img src="/App/Images/pdf-icon-mm.gif" alt="" onclick="ViewKynFile('<%= physicianSummReportFileUrl %>', 'Physician Summary Report');"
                        style="cursor: pointer;" />
                    <%}
                       else
                       {%>
                    <img src="/Content/Images/PageNotFound-Icons.jpg" alt="" />
                    <%}
                    %>
                </div>
                <div class="action-link">
                    <a href="javascript:uploadKynFile('<%= KynFileTypes.PhysicianSummaryReport%>'); void(0);">Upload</a>&nbsp;&nbsp;
                    <% if (!string.IsNullOrEmpty(physicianSummReportFilePath))
                       {%>
                    <a href="javascript:removeKynImage('<%= KynFileTypes.PhysicianSummaryReport%>'); void(0);"
                        class='remove-link'>Remove</a>
                    <%}
                       else
                       { %>
                    <a href="javascript:removeKynImage('<%= KynFileTypes.PhysicianSummaryReport%>'); void(0);"
                        class='remove-link' style="display: none;">Remove</a>
                    <%}
                    %>
                </div>
                <div style="display: none;" class="action-link">
                    <img src="/App/Images/loading.gif" alt="" />
                </div>
                <br />
                <b>Physician Summary Report</b>
            </td>
            <%--<td class="<%= KynFileTypes.LongitudinalPrompt %>">
                <div>
                    <% if (!string.IsNullOrEmpty(longitudinalPromptFilePath))
                       {
                           longitudinalPromptFileUrl = location.Url + Path.GetFileName(longitudinalPromptFilePath);
                    %>
                    <img src="/App/Images/pdf-icon-mm.gif" alt="" onclick="ViewKynFile('<%= longitudinalPromptFileUrl %>', 'Longitudinal Prompt');"
                        style="cursor: pointer;" />
                    <%}
                       else
                       {%>
                    <img src="/Content/Images/PageNotFound-Icons.jpg" alt="" />
                    <%}
                    %>
                </div>
                <div class="action-link">
                    <a href="javascript:uploadKynFile('<%= KynFileTypes.LongitudinalPrompt%>'); void(0);">
                        Upload</a>&nbsp;&nbsp;
                    <% if (!string.IsNullOrEmpty(physicianSummReportFilePath))
                       {%>
                    <a href="javascript:removeKynImage('<%= KynFileTypes.LongitudinalPrompt%>'); void(0);"
                        class='remove-link'>Remove</a>
                    <%}
                    %>
                </div>
                <div style="display: none;" class="action-link">
                    <img src="/App/Images/loading.gif" alt="" />
                </div>
                <br />
                <b>Longitudinal Prompt </b>
            </td>--%>
        </tr>
    </table>
</div>
    </div>

<div id="kyn_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>KYN Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyKYN" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="kyn-retest-span">
            <input type="checkbox" id="Retest_23" />Retest
        </span>
    </div>
    <div class="hrows kyn-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_kyncapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeKyn = '<%= (long)TestType.Kyn %>';
    var IskynResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var kyn = null;
    function SetKynData(testResult) {
        kyn = new Kyn(testResult);
        kyn.setData();
    }

    function GetKynData() {
        if (kyn == null) kyn = new Kyn();
        return kyn.getData();
    }

    function ViewKynFile(link, title) {
        window.open(link, title, 'width=900, height=600');
    }

    var uploadKynWindow = null;
    function uploadKynFile(filetype) {
        uploadKynWindow = window.open("/app/franchisee/technician/UploadKynFile.aspx?EventId=<%= EventId %>&CustomerId=<%= CustomerId %>&FileType=" + filetype + "&TestType=<%= (long)TestType.Kyn %>", filetype, 'width=400, height=100');
    }

    function setFileUrlforFileType(url, filetype) {
        uploadKynWindow.close();
        var imgTag = $("td." + filetype + " .file").find("img");
        $("<img src='/App/Images/pdf-icon-mm.gif' alt='' onclick=\"ViewKynFile('" + url + "', 'Longitudinal Prompt');\" style='cursor: pointer;' />").insertAfter(imgTag);
        $("td." + filetype + " .remove-link").show();
        imgTag.remove();
    }

    function removeKynImage(fileType) {
        $("td." + fileType + " .action-link").toggle();
        $.ajax({
            url: '/App/Controllers/ManualEntryAndAuditController.asmx/RemoveKynDataFile', type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: "{'eventId' : '<%= EventId %>', 'customerId' : '<%= CustomerId %>', fileType : '" + fileType + "','testId' : '<%= (long)TestType.Kyn %>' }",
            cache: false,
            dataType: 'json',
            success: function (result) {
                $("td." + fileType + " .action-link").toggle();
                if (result.d == null) return;

                if (result.d.IsSuccess) {
                    var imgTag = $("td." + fileType + " .file").find("img");
                    $("<img src='/Content/Images/PageNotFound-Icons.jpg' alt='' />").insertAfter(imgTag);
                    imgTag.remove();
                    $("td." + fileType + " .remove-link").hide();
                    return;
                }
                else {
                    alert(result.d.Message);
                }
            },
            error: function (a) {
                $("td." + fileType + " .action-link").toggle();
            }
        });
    }

    $(document).ready(function () {
        if (currentScreenMode == ScreenMode.ViewResults || currentScreenMode == ScreenMode.Physician) {
            $(".kynreporttable .action-link").hide();
        }

    });

</script>

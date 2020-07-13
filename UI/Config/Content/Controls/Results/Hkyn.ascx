<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hkyn.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Hkyn" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="System.IO" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Hkyn.js??q=<%= VersionNumber %>"></script>
<style type="text/css">
    .hkynreporttable {
        /*width: 100%;*/
        text-align: center;
    }

        .hkynreporttable td {
            /*width: 25%;*/
        }
</style>
<div id="hkyn_hip" runat="server" >
    <div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>HKYN Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyHKYN" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="hkyn-critical-span">
        <input type="checkbox" id="DescribeSelfPresentHKYNInputCheck" onclick="onClick_CriticalDataHkyn();" />Critical</span>
    <span class="chk_orngband" id="hkyn-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHkynCheck" onclick="onClick_PriorityInQueueDataHkyn();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="hkyn-retest-span">
        <input type="checkbox" id="Retest_98" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenHKYNDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-HKYN" GridLines="None" RepeatDirection="Horizontal">
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
        <textarea id="technotesHKYN" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<div style="float: left; margin-top: 10px; width: 98%;">
    <%
        // string letterWriterFilePath, participantSummReportFilePath, physicianSummReportFilePath;
        //string letterWriterFileUrl, participantSummReportFileUrl, physicianSummReportFileUrl;
        string participantSummReportFilePath = string.Empty;
        string participantSummReportFileUrl = string.Empty;

        // participantSummReportFilePath = participantSummReportFilePath = physicianSummReportFilePath = string.Empty;

        var repository = IoC.Resolve<IMediaRepository>();
        var location = EventId > 0 ? repository.GetKynIntegrationOutputDataLocation(EventId, CustomerId) : null;

        if (location != null && Directory.Exists(location.PhysicalPath))
        {
            var files = Directory.GetFiles(location.PhysicalPath, TestType.HKYN + "_*.pdf");

            if (files.Any())
            {
                // letterWriterFilePath = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.LetterWriter));
                participantSummReportFilePath = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.ParticipantSummaryReport));
                // physicianSummReportFilePath = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(KynFileTypes.PhysicianSummaryReport));
            }
        }
        
    %>
    <table class="hkynreporttable">
        <tr>
            <%--<td class="hkyn_<%= KynFileTypes.LetterWriter %>" style="display: none;">
                <div class="file">
                    <% if (!string.IsNullOrEmpty(letterWriterFilePath))
                       {
                           letterWriterFileUrl = location.Url + Path.GetFileName(letterWriterFilePath);
                    %>
                    <img src="/App/Images/pdf-icon-mm.gif" alt="" onclick="ViewHkynFile('<%= letterWriterFileUrl %>', 'Letter Writer');"
                        style="cursor: pointer;" />
                    <%}
                       else
                       {%>
                    <img src="/Content/Images/PageNotFound-Icons.jpg" alt="" />
                    <%}
                    %>
                </div>
                <div class="action-link">
                    <a href="javascript:uploadHkynFile('<%= KynFileTypes.LetterWriter%>'); void(0);">Upload</a>&nbsp;&nbsp;
                    <% if (!string.IsNullOrEmpty(letterWriterFilePath))
                       {%><a href="javascript:removeHkynImage('<%= KynFileTypes.LetterWriter%>'); void(0);"
                           class='remove-link'>Remove</a>
                    <%}
                       else
                       { %>
                    <a href="javascript:removeHkynImage('<%= KynFileTypes.LetterWriter%>'); void(0);"
                        class='remove-link' style="display: none;">Remove</a>
                    <%}%>
                </div>
                <div style="display: none;" class="action-link">
                    <img src="/App/Images/loading.gif" alt="" />
                </div>
                <br />
                <b>Letter Writer </b>
            </td>--%>
            <td class="hkyn_<%= KynFileTypes.ParticipantSummaryReport %>">
                <div class="file">
                    <% if (!string.IsNullOrEmpty(participantSummReportFilePath))
                       {
                           participantSummReportFileUrl = location.Url + Path.GetFileName(participantSummReportFilePath);
                    %>
                    <img src="/App/Images/pdf-icon-mm.gif" alt="" onclick="ViewHkynFile('<%= participantSummReportFileUrl %>', 'Participant Summary Report');"
                        style="cursor: pointer;" />
                    <%}
                       else
                       {%>
                    <img src="/Content/Images/PageNotFound-Icons.jpg" alt="" />
                    <%}%>
                </div>
                <div class="action-link">
                    <a href="javascript:uploadHkynFile('<%= KynFileTypes.ParticipantSummaryReport%>'); void(0);">Upload</a>&nbsp;&nbsp;
                    <% if (!string.IsNullOrEmpty(participantSummReportFilePath))
                       {%>
                    <a href="javascript:removeHkynImage('<%= KynFileTypes.ParticipantSummaryReport%>'); void(0);"
                        class='remove-link'>Remove</a>
                    <%}
                       else
                       { %>
                    <a href="javascript:removeHkynImage('<%= KynFileTypes.ParticipantSummaryReport%>'); void(0);"
                        class='remove-link' style="display: none;">Remove</a>
                    <%}%>
                </div>
                <div style="display: none;" class="action-link">
                    <img src="/App/Images/loading.gif" alt="" />
                </div>
                <br />
                <b>Participant Summary Report</b>
            </td>
            <%-- <td class="hkyn_<%= KynFileTypes.PhysicianSummaryReport %>">
                <div class="file">
                    <% if (!string.IsNullOrEmpty(physicianSummReportFilePath))
                       {
                           physicianSummReportFileUrl = location.Url + Path.GetFileName(physicianSummReportFilePath);
                    %>
                    <img src="/App/Images/pdf-icon-mm.gif" alt="" onclick="ViewHkynFile('<%= physicianSummReportFileUrl %>', 'Physician Summary Report');"
                        style="cursor: pointer;" />
                    <%}
                       else
                       {%>
                    <img src="/Content/Images/PageNotFound-Icons.jpg" alt="" />
                    <%}
                    %>
                </div>
                <div class="action-link">
                    <a href="javascript:uploadHkynFile('<%= KynFileTypes.PhysicianSummaryReport%>'); void(0);">Upload</a>&nbsp;&nbsp;
                    <% if (!string.IsNullOrEmpty(physicianSummReportFilePath))
                       {%>
                    <a href="javascript:removeHkynImage('<%= KynFileTypes.PhysicianSummaryReport%>'); void(0);"
                        class='remove-link'>Remove</a>
                    <%}
                       else
                       { %>
                    <a href="javascript:removeHkynImage('<%= KynFileTypes.PhysicianSummaryReport%>'); void(0);"
                        class='remove-link' style="display: none;">Remove</a>
                    <%}
                    %>
                </div>
                <div style="display: none;" class="action-link">
                    <img src="/App/Images/loading.gif" alt="" />
                </div>
                <br />
                <b>Physician Summary Report</b>
            </td>--%>
        </tr>
    </table>
</div>

    </div>
<div id="hkyn_chat" runat="server" >
      <div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>HKYN Results</strong></span>
    </h5>
     <span class="chk_orngband">
        <select id="conductedbyHKYN" class="conductedby-ddl">
        </select>
    </span>
    <span class="chk_orngband" id="hkyn-retest-span">
        <input type="checkbox" id="Retest_98" />Retest
    </span>
</div>
   <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_hkyncapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>


    </div>

    </div>

<script language="javascript" type="text/javascript">
    var testTypeHkyn = '<%= (long)TestType.HKYN %>';
    var isHKYNResultEntryType = '<%= IsResultEntrybyChat %>';
    var hkyn = null;
    function SetHkynData(testResult) {
        hkyn = new Hkyn(testResult);
        hkyn.setData();
    }

    function GetHkynData() {
        if (hkyn == null) hkyn = new Hkyn();
        return hkyn.getData();
    }

    function ViewHkynFile(link, title) {
        window.open(link, title, 'width=900, height=600');
    }

    var uploadHkynWindow = null;
    function uploadHkynFile(filetype) {
        uploadHkynWindow = window.open("/app/franchisee/technician/UploadKynFile.aspx?EventId=<%= EventId %>&CustomerId=<%= CustomerId %>&FileType=" + filetype + "&TestType=<%= (long)TestType.HKYN %>", filetype, 'width=400, height=100');
    }

    function setFileUrlforHkynFileType(url, filetype) {
        uploadHkynWindow.close();
        var imgTag = $("td.hkyn_" + filetype + " .file").find("img");
        $("<img src='/App/Images/pdf-icon-mm.gif' alt='' onclick=\"ViewHkynFile('" + url + "', 'Longitudinal Prompt');\" style='cursor: pointer;' />").insertAfter(imgTag);
        $("td.hkyn_" + filetype + " .remove-link").show();
        imgTag.remove();
    }

    function removeHkynImage(fileType) {
        $("td.hkyn_" + fileType + " .action-link").toggle();
        $.ajax({
            url: '/App/Controllers/ManualEntryAndAuditController.asmx/RemoveKynDataFile', type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: "{'eventId' : '<%= EventId %>', 'customerId' : '<%= CustomerId %>', fileType : '" + fileType + "','testId' : '<%= (long)TestType.HKYN %>' }",
            cache: false,
            dataType: 'json',
            success: function (result) {
                $("td.hkyn_" + fileType + " .action-link").toggle();
                if (result.d == null) return;

                if (result.d.IsSuccess) {
                    var imgTag = $("td.hkyn_" + fileType + " .file").find("img");
                    $("<img src='/Content/Images/PageNotFound-Icons.jpg' alt='' />").insertAfter(imgTag);
                    imgTag.remove();
                    $("td.hkyn_" + fileType + " .remove-link").hide();
                    return;
                }
                else {
                    alert(result.d.Message);
                }
            },
            error: function (a) {
                $("td.hkyn_" + fileType + " .action-link").toggle();
            }
        });
    }

    $(document).ready(function () {
        if (currentScreenMode == ScreenMode.ViewResults || currentScreenMode == ScreenMode.Physician) {
            $(".hkynreporttable .action-link").hide();
        }

    });

</script>

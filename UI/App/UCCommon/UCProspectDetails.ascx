<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCProspectDetails"
    CodeBehind="UCProspectDetails.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_JQueryToolkit" runat="server" IncludeJQueryUI="true"
    IncudeJQueryJTip="true" IncludeAjax="true" />
<style type="text/css">
    /*---------- bubble tooltip -----------*/a.tt
    {
        position: relative;
        z-index: 24;
        color: #287AA8;
        font-weight: normal;
        text-decoration: none;
    }
    a.tt span
    {
        display: none;
    }
    /*background:; ie hack, something must be changed in a for ie to execute it*/a.tt:hover
    {
        z-index: 25;
        color: #ff6600;
        text-decoration: none;
    }
    a.tt:hover span.tooltip
    {
        display: block;
        position: absolute;
        top: 0px;
        left: 0;
        padding: 15px 0 0 0;
        width: 200px;
        color: #287AA8;
        text-align: left;
        filter: alpha(opacity:90);
        khtmlopacity: 0.90;
        mozopacity: 0.90;
        opacity: 0.90;
        text-decoration: none;
    }
    a.tt:hover span.top
    {
        display: block;
        padding: 30px 8px 0;
        background: url(/App/Images/bubble.gif) no-repeat top;
        text-decoration: none;
    }
    a.tt:hover span.middle
    {
        /* different middle bg for stretch */
        display: block;
        padding: 0 8px;
        background: url(/App/Images/bubble_filler.gif) repeat bottom;
        color: #000;
        text-decoration: none;
    }
    a.tt:hover span.bottom
    {
        display: block;
        padding: 3px 8px 10px;
        color: #ff6600;
        background: url(/App/Images/bubble.gif) no-repeat bottom;
        text-decoration: none;
    }
    .TextBoxAsLabel
    {
       border: none !important;
       background-color: #fff !important;
       background: transparent !important;
    }
</style>
<script type="text/javascript" language="javascript">

    String.prototype.trim = function () { return this.replace(/^\s+|\s+$/, ''); };

    function sel_caption(divactive) {
        //debugger
        document.getElementById("<%= this.hfheader.ClientID %>").value = divactive;

        document.getElementById('divHeaderCall').className = 'gridtaboff_vesv';
        document.getElementById('divCall').className = 'tabtxtoff_vesv';
        document.getElementById('divHeaderTask').className = 'gridtaboff_vesv';
        document.getElementById('divTask').className = 'tabtxtoff_vesv';
        document.getElementById('divHeaderMeeting').className = 'gridtaboff_vesv';
        document.getElementById('divMeeting').className = 'tabtxtoff_vesv';
        document.getElementById('divHeaderNotes').className = 'gridtaboff_vesv';
        document.getElementById('divNotes').className = 'tabtxtoff_vesv';
        document.getElementById('divHeaderAll').className = 'gridtaboff_vesv';
        document.getElementById('divAll').className = 'tabtxtoff_vesv';


        document.getElementById(divactive).className = 'gridtabon_vesv';
        if (divactive == 'divHeaderCall') {
            document.getElementById('divCall').className = 'tabtxton_vesv';

        }
        if (divactive == 'divHeaderTask') {
            document.getElementById('divTask').className = 'tabtxton_vesv';

        }
        if (divactive == 'divHeaderMeeting') {
            document.getElementById('divMeeting').className = 'tabtxton_vesv';

        }
        if (divactive == 'divHeaderNotes') {
            document.getElementById('divNotes').className = 'tabtxton_vesv';
        }
        if (divactive == 'divHeaderAll') {
            document.getElementById('divAll').className = 'tabtxton_vesv';
        }

    }


    function NextBuild() {
        alert('Please check this in next release');
        return false;
    }
    function DeleteNotes() {
        var answer = confirm("Are you sure you want to delete notes? ")
        return answer;
    }

    function updateNotes() {
        var txtNotes = document.getElementById("<%=this.txtNotes.ClientID %>");
        var hfProsectID = document.getElementById("<%=this.hfProsectID.ClientID %>");
        if (txtNotes.value.trim().length > 0) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: '<%= ResolveUrl("~/App/AutoCompleteService.asmx/SaveProspectNotes") %>',
                data: "{'notes' : '" + txtNotes.value.replace(/'/gi, "\\\'").replace(/\\\"/gi, "\\\\\"") + "', 'prospectid' : '" + hfProsectID.value + "'}",
                success: function (result) {
                    OnComplete(result);
                },
                error: function (a, b, c) {
                    OnError(a);
                }

            });

        }
        else {
            alert("Please input some text for new Note.");
        }
        return false;
    }

    function OnComplete(arg) {

        if (arg.d == true) {
            document.getElementById("divSaveNotes").style.display = "none";
            alert("Note saved successfully.");
        }
        else {
            alert("Note updated successfully.");
        }
    }

    function OnTimeOut(arg) {
        alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");
    }

    function OnError(arg) {
        alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");
    }

    function ShowNotes() {
        document.getElementById("divSaveNotes").style.display = "block";
    }
    //-- Expand/Collapse Contacts/Activity/Events
    function ExpandCollapse(dvName, aName, imgName) {
        var dv = document.getElementById(dvName);
        var a = document.getElementById(aName);
        var img = document.getElementById(imgName);

        if (dv.style.display == '') {
            dv.style.display = 'none';
            a.innerHTML = 'Expand';
            img.src = "/App/Images/plus-sign.gif";
        }
        else if (dv.style.display == 'block') {
            dv.style.display = 'none';
            a.innerHTML = 'Expand';
            img.src = "/App/Images/plus-sign.gif";
        }
        else {
            dv.style.display = 'block';
            a.innerHTML = 'Collapse';
            img.src = "/App/Images/minus-signs.gif";
        }
    }
</script>
<script type="text/javascript" language="javascript">
    function ChangePageEventHost(pagenumber) {
        document.getElementById("<%= this.hidpageindex.ClientID %>").value = pagenumber;
        __doPostBack('__Page', 'PageChangeEventHost');
    }
    function ChangePageEventHostZip(pagenumber) {
        document.getElementById("<%= this.hidpageindex.ClientID %>").value = pagenumber;
        __doPostBack('__Page', 'PageChangeEventHostZip');
    }
    function ChangePageEventHostDistance(pagenumber) {
        document.getElementById("<%= this.hidpageindex.ClientID %>").value = pagenumber;
        __doPostBack('__Page', 'PageChangeEventHostDistance');
    }
</script>
<asp:HiddenField ID="hfheader" Value="divHeaderAll" runat="server" />
<div class="wrapper_inpg">
    <div class="main_area_bdrnone">
        <span class="orngheadtxt_default" runat="server" id="spnTitle">Prospect Details:<span
            id="spProspectName1" runat="server"></span></span> <span class="headingright_default">
                <asp:LinkButton ID="lnkContact" Text="Add Contact" runat="server" OnClick="lnkContact_Click"></asp:LinkButton>
            </span><span class="headingright_default">&nbsp;|&nbsp; </span><span class="headingright_default">
                <asp:LinkButton ID="lnkTask" runat="server" Text="Add Task" OnClick="lnkTask_Click"></asp:LinkButton>
            </span><span class="headingright_default">&nbsp;|&nbsp; </span><span class="headingright_default">
                <asp:LinkButton ID="lnkCall" runat="server" Text="Add Call" OnClick="lnkCall_Click1"></asp:LinkButton>
            </span><span class="headingright_default">&nbsp;|&nbsp; </span><span class="headingright_default">
                <asp:LinkButton ID="lnkMeeting" runat="server" Text="Add Meeting" OnClick="lnkMeeting_Click1"></asp:LinkButton>
            </span><span class="headingright_default">&nbsp;|&nbsp; </span><span class="headingright_default">
                <asp:LinkButton ID="lnkProspect" runat="server" Text="Edit Prospect" OnClick="lnkProspect_Click"></asp:LinkButton>
            </span><span style="float: right" id="spnConvertToHost" runat="server"><span class="headingright_default">
                &nbsp;|&nbsp; </span><span class="headingright_default">
                    <asp:LinkButton ID="lnkConvertToHost" runat="server" Text="Convert To Host" OnClick="lnkConvertToHost_Click"></asp:LinkButton>
                </span></span><span style="float: right; display: none;" id="spAddEvent" runat="server">
                    <span class="headingright_default">&nbsp;|&nbsp; </span><span class="headingright_default">
                        <asp:LinkButton ID="lnkEvent" runat="server" Text="Add Event" OnClick="lnkEvent_Click"></asp:LinkButton>
                    </span></span>
    </div>
    <div class="hr left">
    </div>
    <div class="main_area_bdrnone">
        <div class="divtoptxtbox_hd">
            <div class="ltbox">
                <div class="hrw">
                    <span class="blacknormal16_default" id="spProspectName2" runat="server"></span>
                </div>
                <div class="hrw">
                    <span class="ttxtnowidthnormal_default" id="spAddress" runat="server"></span><span
                        id="_addressVerifiedStatus" runat="server" class="left"></span>
                </div>
                <div class="hrw" style="margin-top: 3px; font-size: 14px">
                    <span class="titletextnowidth_default">Owning Sales Rep:</span> <span class="ttxtnowidthnormal_default"
                        id="_salesRep" runat="server"></span>
                </div>
                <div class="hrw">
                    <span class="titletextnowidth_default" runat="server" id="spnType">Prospect Type:</span>
                    <span class="ttxtnowidthnormal_default" id="spnProspectType" runat="server"></span>
                </div>
                <div class="hrw">
                    <span class="titletextnowidth_default">Mailing Address:</span> <span class="ttxtnowidthnormal_default"
                        runat="server" id="_mailingAddress"></span>
                </div>
                <div class="hrw" style="margin-top: 3px">
                    <span class="left bold"><u>Contact Info:</u></span>
                </div>
                <div class="hrw">
                    <span class="titletextsmallbld_default" style="width: 60px">Phone No:</span> <span
                        class="ttxtwidthnormalsmall_default" id="spPhone" runat="server" style="width: 200px">
                    </span><span class="titletextnowidth_default">Fax:</span><span class="ttxtnowidthnormal_default"
                        id="_fax" runat="server"></span>
                </div>
                <div class="hrw">
                    <span class="titletextsmallbld_default" style="width: 60px">Email:</span> <span class="ttxtnowidthnormal_default"
                        id="spOther" runat="server"></span>
                </div>
                <div class="hrw">
                    <span class="titletextnowidth_default" style="width: 60px">URL:</span> 
                   <%-- <span class="ttxtnowidthnormal_default"
                        id="spURL" runat="server"></span>--%> <asp:TextBox id="spURL" runat="server" CssClass="TextBoxAsLabel" disabled></asp:TextBox>
                </div>
            </div>
            <div class="rtbox">
                <div class="hrwt">
                    <span class="titletext1b_default">Members:</span> <span class="ttxtnowidthnormal_default"
                        id="spnMembersEmployees" runat="server"></span>
                </div>
                <div class="hrwt">
                    <span class="titletext1b_default">Attendance:</span> <span class="ttxtnowidthnormal_default"
                        id="spnAttendence" runat="server"></span>
                </div>
                <div class="hrwt">
                    <span class="titletext1b_default">Will Promote:</span> <span class="ttxtnowidthnormal_default"
                        id="spnWillPromote" runat="server"></span>
                </div>
                <div class="hrwt">
                    <span class="titletext1b_default">Facilities Fee($):</span> <span class="ttxtnowidthnormal_default"
                        id="spnFacilitiesFee" runat="server"></span><span id="_facilitiesFeeDetails" runat="server">
                            (<a href="#">View Details</a>)</span>
                </div>
                <div class="hrwt">
                    <span class="titletext1b_default">Viable Host Site:</span> <span class="ttxtnowidthnormal_default"
                        id="spnViableHostSite" runat="server"></span>
                </div>
                <div class="hrwt">
                    <%--<span class="ttxtnowidthnormal_default" id="spnWillHost" runat="server"></span>--%>
                    <span class="titletext1b_default">Hosted in Past:</span> <span class="ttxtnowidthnormal_default"
                        id="hostInPastWith" runat="server"></span><span id="_hostedInPastDetails" runat="server">
                            (<a href="#">View Details</a>)</span>
                </div>
            </div>
            <p class="divtopboxrow_hd" id="addressVerification" runat="server" style="display: none">
            </p>
            <p class="divtopboxrow_hd">
                <span class="divtopboxttext_hd"><a href="#" onclick="ShowNotes()">+ Add new Note</a></span>
            </p>
            <div style="display: none" id="divSaveNotes">
                <p class="divtopboxrow_hd">
                    <span class="divtopboxttextnowidth_hd">
                        <asp:TextBox ID="txtNotes" runat="server" Width="725px" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </span>
                </p>
                <p class="divtopboxrow_hd">
                    <span style="float: right;">
                        <asp:LinkButton ID="lnkBtnSaveNotes" runat="server" Text="Save" OnClientClick="return updateNotes();"></asp:LinkButton>
                    </span>
                </p>
            </div>
        </div>
        <div class="fltrdv" id="HostFacilityDataDiv" runat="server" style="margin: 5px 0;">
            <h4 class="mpo graybold14_default">
                <u>Host Facility Viability Details:</u></h4>
            <div class="inrrow">
                <label class="titletextlarge_default">
                    Ranking:</label>
                <span class="ttxtwidthnormalsmall_default" runat="server" id="HostRankingByHsc">
                </span>
                <label class="titletext1b_default">
                    No of Plug Points:</label>
                <span class="ttxtwidthnormalsmall_default" runat="server" id="NumberofPlugPointsSpan">
                </span>
                <label class="titletext1b_default">
                    Room Size:</label>
                <span class="ttxtnowidthnormal_default" runat="server" id="RoomSizeSpan"></span>
            </div>
            <div class="inrrow">
                <label class="titletextlarge_default">
                    Room Needs Cleared:</label>
                <span class="ttxtwidthnormalsmall_default" runat="server" id="RoomNeedClearedSpan">
                </span>
                <label class="titletextlarge_default">
                    Internet Access:</label>
                <span class="ttxtwidthnormal_default" runat="server" id="InternetAccessSpan"></span>
            </div>
            <div style="clear: both">
            </div>
            <h4 class="graybold14_default">
                <u>Franchisee View:</u> <span id="FranchiseeRatingNotAvailSpan" runat="server" style="display: none;">
                    (Not Available) </span>
            </h4>
            <div class="inrrow left mt_medium" style="background: #f8f8f8; border: solid 1px #ccc">
                <div class="inrrow left">
                    <label class="titletextlarge_default">
                        Ranking:</label>
                    <span class="ttxtwidthnormalsmall_default" runat="server" id="HostRankingbyFranchiseeSpan">
                    </span>
                </div>
                <div class="inrrow left">
                    <label class="titletextlarge_default">
                        Comments:</label>
                    <span class="titletextnowidth_default" style="width: 600px" runat="server" id="CommentsbyFranchiseeSpan">
                    </span>
                </div>
            </div>
        </div>
        <div id="HostImageDiv" runat="server" class="fltrdv" style="background: none; display: none">
            <h4 class="mpo graybold14_default">
                <u>Host Images:</u></h4>
            <div id="HostImageInnerDiv" runat="server" class="inrrow">
                Images grid comes here</div>
        </div>
        <%--Begin Contact --%>
        <p>
            <img src="/App/Images/specer.gif" width="700px" height="20px" /></p>
        <p class="maindivinnerrow_feedback">
            <span class="orngbold14_default" style="float: left">Contacts</span> &nbsp;<img src="/App/Images/minus-signs.gif"
                id="imgContactInfo" style="cursor: pointer" onclick="ExpandCollapse('_divContacts','aContactInfo','imgContactInfo')" />
            <a href="javascript:void(0);" onclick="ExpandCollapse('dvLoginInfo','aLoginInfo','imgLoginInfo')"
                id="aContactInfo">Collapse</a>
        </p>
        <p class="graylinefull_feedback">
            <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
        <p>
            <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
        <div id="_divContacts">
            <div class="maindivgrids_hd">
                <asp:GridView ID="grdContacts" DataKeyNames="ContactID" runat="server" CssClass="divgrid_cl"
                    AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10"
                    EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="grdContacts_PageIndexChanging"
                    OnSorting="grdContacts_Sorting" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ProspectID" Visible="false"></asp:BoundField>
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                            <ItemTemplate>
                                <a href='<%# this.ResolveUrl("~/App/Franchisor/AddNewContact.aspx?ContactID=" + DataBinder.Eval(Container.DataItem, "ContactID")+"&ProspectID="+DataBinder.Eval(Container.DataItem, "ProspectID") + "&Parent=Prospect") %>'>
                                    <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                </a>
                                <br />
                                <%# DataBinder.Eval(Container.DataItem, "Address")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Email")%>
                                <br />
                                <%# DataBinder.Eval(Container.DataItem, "EmailOffice")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone">
                            <ItemTemplate>
                                Direct:<%# DataBinder.Eval(Container.DataItem, "PhoneOffice")%><br />
                                Home:<%# DataBinder.Eval(Container.DataItem, "PhoneHome")%><br />
                                Cell:<%# DataBinder.Eval(Container.DataItem, "PhoneCell")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact Type">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "ContactType")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkCall" runat="server" Text="Add Call" OnClick="lnkCall_Click"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ContactID") %>'></asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkMeeting" runat="server" Text="Add Meeting" OnClick="lnkMeeting_Click"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ContactID") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1" />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
            <div id="divNoContacts" runat="server" visible="false">
                <span style="color: #D60202;">No Contacts has been added by you.</span>
            </div>
        </div>
        <%--End Contact--%>
        <%--Begin Activities--%>
        <p>
            <img src="/App/Images/specer.gif" width="650px" height="20px" /></p>
        <p class="maindivinnerrow_feedback">
            <span class="orngbold14_default" style="float: left">Activities</span> &nbsp;<img
                src="/App/Images/minus-signs.gif" id="imgActivityInfo" style="cursor: pointer"
                onclick="ExpandCollapse('_divActivity','aActivityInfo','imgActivityInfo')" />
            <a href="javascript:void(0);" onclick="ExpandCollapse('_divActivity','aActivityInfo','imgActivityInfo')"
                id="aActivityInfo">Collapse</a>
        </p>
        <p class="graylinefull_feedback">
            <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
        <p>
            <img src="/App/Images/specer.gif" width="600px" height="5px" /></p>
        <div class="maindivinnerrow_feedback" id="_divActivity">
            <div class="maindivgrids_hd">
                <div class="dgviewcalls_hd">
                    <cc1:tabcontainer activetabindex="0" cssclass="grayboxtop_cl" id="tbpnlContainer"
                        runat="server">
                        <%--Begin All Container--%>
                        <cc1:TabPanel runat="server" ID="pnlAll">
                            <HeaderTemplate>
                                <div id="divHeaderAll" class="gridtabon_vesv">
                                    <div id="divAll" class="tabtxton_vesv">
                                        <a href="javascript:sel_caption('divHeaderAll');">All[<span id="spnAllCount" runat="server"></span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </a>
                                    </div>
                                </div>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="grayboxtop_cl" id="divAllResults" runat="server">
                                    <asp:GridView ID="grdAll" DataKeyNames="ID" runat="server" CssClass="divgrid_cl"
                                        PageSize="10" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grdAll_PageIndexChanging"
                                        GridLines="None" AllowSorting="true" OnSorting="grdAll_Sorting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "Type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" SortExpression="StartDate">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "Subject")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName">
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle CssClass="row1" />
                                        <RowStyle CssClass="row2" />
                                        <AlternatingRowStyle CssClass="row3" />
                                    </asp:GridView>
                                </div>
                                <div style="float: left; width: 746px; border: solid 1px #E7F0F5; padding: 10px 0px 10px 0px;
                                    display: none;" id="divNoResultsAll" runat="server">
                                    <div class="divnoitemfound_custdbrd" style="margin-top: 15px;">
                                        <p class="divnoitemtxt_custdbrd">
                                            <span class="orngbold18_default">No Records Found</span>
                                        </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <%--End All Coninter--%>
                        <%--Begin Call--%>
                        <cc1:TabPanel runat="server" ID="pnlCall">
                            <HeaderTemplate>
                                <div id="divHeaderCall" class="gridtabon_vesv">
                                    <div id="divCall" class="tabtxton_vesv">
                                        <a href="javascript:sel_caption('divHeaderCall');">Calls[<span id="spCallcount" runat="server"></span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>
                                    </div>
                                </div>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="grayboxtop_cl" id="divCalls" runat="server">
                                    <asp:GridView DataKeyNames="CallID" ID="grdCall" runat="server" CssClass="divgrid_cl"
                                        AutoGenerateColumns="False" OnSorting="grdCall_Sorting" AllowSorting="True" AllowPaging="True"
                                        OnPageIndexChanging="grdCall_PageIndexChanging" GridLines="None" OnRowDataBound="grdCall_RowDataBound">
                                        <AlternatingRowStyle CssClass="row3" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                                <ItemTemplate>
                                                    <a href='<%# this.ResolveUrl("~/App/Franchisor/AddCallProspect.aspx?IsHost=" + DataBinder.Eval(Container.DataItem, "IsHost")+ "&ContactCallID=" + DataBinder.Eval(Container.DataItem, "CallID") + "&ProspectID=" + DataBinder.Eval(Container.DataItem, "ProspectID") + "&Parent=Prospect") %>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "Subject")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Call Date">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Notes">
                                                <ItemTemplate>
                                                    <a href="javascript:void(0);" class="tt">Notes <span class="tooltip"><span class="top">
                                                    </span><span class="middle">
                                                        <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                                    </span><span class="bottom"></span></span></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ContactName" HeaderText="Contact Name"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="" ImageUrl="~/App/Images/delete.gif"
                                                        OnClick="ibtnDelete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CallID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="row1" />
                                        <RowStyle CssClass="row2" />
                                    </asp:GridView>
                                </div>
                                <div style="float: left; width: 746px; border: solid 1px #E7F0F5; padding: 10px 0px 10px 0px;
                                    display: none;" id="divNoResultsCalls" runat="server">
                                    <div class="divnoitemfound_custdbrd" style="margin-top: 15px;">
                                        <p class="divnoitemtxt_custdbrd">
                                            <span class="orngbold18_default">No Records Found</span>
                                        </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <%--End Call--%>
                        <%--Begin Task--%>
                        <cc1:TabPanel runat="server" ID="pnlTask">
                            <HeaderTemplate>
                                <div id="divHeaderTask" class="gridtabon_vesv">
                                    <div id="divTask" class="tabtxton_vesv">
                                        <a href="javascript:sel_caption('divHeaderTask');">Tasks[<span id="spTaskCount" runat="server"></span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </a>
                                    </div>
                                </div>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="grayboxtop_cl" id="divTaskResults" runat="server">
                                    <asp:GridView DataKeyNames="TaskID" ID="grdTask" runat="server" CssClass="divgrid_cl"
                                        AutoGenerateColumns="False" OnSorting="grdTask_Sorting" AllowSorting="True" AllowPaging="True"
                                        PageSize="10" OnPageIndexChanging="grdTask_PageIndexChanging" GridLines="None"
                                        OnRowDataBound="grdTask_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                                <ItemTemplate>
                                                    <a href='<%# this.ResolveUrl("~/App/Franchisor/AddTask.aspx?TaskID=" + DataBinder.Eval(Container.DataItem, "TaskID") + "&Parent=Prospect") %>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "Subject")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Due Date">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "DueDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DueTime" HeaderText="Due Time" HtmlEncode="false"></asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                            <asp:BoundField DataField="Priority" HeaderText="Priority" />
                                            <asp:BoundField DataField="Notes" HeaderText="Notes" />
                                        </Columns>
                                        <HeaderStyle CssClass="row1" />
                                        <RowStyle CssClass="row2" />
                                        <AlternatingRowStyle CssClass="row3" />
                                    </asp:GridView>
                                </div>
                                <div style="float: left; width: 746px; border: solid 1px #E7F0F5; padding: 10px 0px 10px 0px;
                                    display: none;" id="divNoResultsTask" runat="server">
                                    <div class="divnoitemfound_custdbrd" style="margin-top: 15px;">
                                        <p class="divnoitemtxt_custdbrd">
                                            <span class="orngbold18_default">No Records Found</span>
                                        </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <%--End Task--%>
                        <%--Begin Meeting--%>
                        <cc1:TabPanel runat="server" ID="pnlMy">
                            <HeaderTemplate>
                                <div id="divHeaderMeeting" class="gridtabon_vesv">
                                    <div id="divMeeting" class="tabtxton_vesv">
                                        <a href="javascript:sel_caption('divHeaderMeeting');">Meetings[<span id="spMeetingCount"
                                            runat="server"></span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </a>
                                    </div>
                                </div>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="grayboxtop_cl" id="divMeetingResults" runat="server">
                                    <asp:GridView ID="grdMeeting" DataKeyNames="MeetingID" runat="server" CssClass="divgrid_cl"
                                        AutoGenerateColumns="False" OnSorting="grdMeeting_Sorting" AllowSorting="True"
                                        PageSize="10" AllowPaging="True" OnPageIndexChanging="grdMeeting_PageIndexChanging"
                                        GridLines="None" OnRowDataBound="grdMeeting_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                                <ItemTemplate>
                                                    <a href='<%# this.ResolveUrl("~/App/Franchisor/AddMeeting.aspx?ContactMeetingID=" + DataBinder.Eval(Container.DataItem, "MeetingID") + "&ProspectID=" + DataBinder.Eval(Container.DataItem, "ProspectID") + "&Parent=Prospect&IsHost=" + DataBinder.Eval(Container.DataItem, "IsHost")) %>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "Subject")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                                            <asp:BoundField DataField="StartTime" HeaderText="Start Time" />
                                            <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                            <asp:BoundField DataField="Venue" HeaderText="Venue" />
                                        </Columns>
                                        <HeaderStyle CssClass="row1" />
                                        <RowStyle CssClass="row2" />
                                        <AlternatingRowStyle CssClass="row3" />
                                    </asp:GridView>
                                </div>
                                <div style="float: left; width: 746px; border: solid 1px #E7F0F5; padding: 10px 0px 10px 0px;
                                    display: none;" id="divNoResultsMeeting" runat="server">
                                    <div class="divnoitemfound_custdbrd" style="margin-top: 15px;">
                                        <p class="divnoitemtxt_custdbrd">
                                            <span class="orngbold18_default">No Records Found</span>
                                        </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <%--End Meeting--%>
                        <%--Begin Notes Container--%>
                        <cc1:TabPanel runat="server" ID="pnlNotes">
                            <HeaderTemplate>
                                <div id="divHeaderNotes" class="gridtabon_vesv">
                                    <div id="divNotes" class="tabtxton_vesv">
                                        <a href="javascript:sel_caption('divHeaderNotes');">Notes[<span id="spNotesCount"
                                            runat="server"></span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </a>
                                    </div>
                                </div>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="grayboxtop_cl" id="divNotesResults" runat="server">
                                    <asp:GridView ID="grdNotes" DataKeyNames="NotesID" runat="server" CssClass="divgrid_cl"
                                        PageSize="10" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grdNotes_PageIndexChanging"
                                        GridLines="None" OnSorting="grdNotes_Sorting" AllowSorting="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Created">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "DateCreated")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton OnClientClick="return DeleteNotes();" ToolTip="Delete Notes" runat="server"
                                                        Text="Delete" ID="lnkDeleteNotes" OnCommand="Command_Button_Click" CommandName="DeleteNotes"
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NotesID")%>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="row1" />
                                        <RowStyle CssClass="row2" />
                                        <AlternatingRowStyle CssClass="row3" />
                                    </asp:GridView>
                                </div>
                                <div style="float: left; width: 746px; border: solid 1px #E7F0F5; padding: 10px 0px 10px 0px;
                                    display: none;" id="divNoResultsNotes" runat="server">
                                    <div class="divnoitemfound_custdbrd" style="margin-top: 15px;">
                                        <p class="divnoitemtxt_custdbrd">
                                            <span class="orngbold18_default">No Records Found</span>
                                        </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <%--End Notes Coninter--%>
                    </cc1:tabcontainer>
                </div>
            </div>
        </div>
        <%--End Activities--%>
        <div style="float: left; display: none;" runat="server" id="divEvents">
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="20px" /></p>
            <p class="maindivinnerrow_feedback">
                <span class="orngbold14_default" style="float: left">Events</span> &nbsp;<img src="/App/Images/minus-signs.gif"
                    id="imgEventInfo" style="cursor: pointer" onclick="ExpandCollapse('_divEventInfo','aEventInfo','imgEventInfo')" />
                <a href="javascript:void(0);" onclick="ExpandCollapse('_divEventInfo','aEventInfo','imgEventInfo')"
                    id="aEventInfo">Collapse</a>
            </p>
            <p class="graylinefull_feedback">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <div id="_divEventInfo">
                <div class="fltrdv" style="margin-bottom: 5px">
                    <strong>Events Held at
                        <%=HostName%></strong> &nbsp;<img src="/App/Images/minus-signs.gif" id="_imgEventsOnHost"
                            style="cursor: pointer" onclick="ExpandCollapse('_divEventsOnHost','_hrfEventOnHost','_imgEventsOnHost')" />
                    <a href="javascript:void(0);" onclick="ExpandCollapse('_divEventsOnHost','_hrfEventOnHost','_imgEventsOnHost')"
                        id="_hrfEventOnHost">Collapse</a></div>
                <div class="maindivgrids_hd" id="_divEventsOnHost">
                    <asp:GridView ID="grdevents" runat="server" CssClass="divgrid_cl" GridLines="none"
                        DataKeyNames="EventID" AllowSorting="True" OnSorting="grdevents_Sorting" EnableSortingAndPagingCallbacks="false"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="SalesRepID" Visible="False" />
                            <asp:TemplateField HeaderText="Name" SortExpression="EventName">
                                <ItemTemplate>
                                    <a href='<%#ResolveUrl("~/App/Common/EventDetails.aspx?EventID=" + DataBinder.Eval(Container.DataItem, "EventID")+ "&Parent=Host") %>'>
                                        <%# DataBinder.Eval(Container.DataItem, "HostName")%>
                                    </a>
                                    <br />
                                    Event Status:(<%# (EventStatus) DataBinder.Eval(Container.DataItem, "EventStatus")%>)
                                </ItemTemplate>
                                <ItemStyle CssClass="" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="EventDate" DataFormatString="{0:MM/dd/yyyy}"
                                HtmlEncode="false"></asp:BoundField>
                            <asp:BoundField DataField="CustomerCount" HeaderText="Customers Registered"></asp:BoundField>
                        </Columns>
                        <RowStyle CssClass="row2"></RowStyle>
                        <HeaderStyle CssClass="row1"></HeaderStyle>
                        <AlternatingRowStyle CssClass="row3"></AlternatingRowStyle>
                    </asp:GridView>
                    <div runat="server" id="eventsOnHostPaging" style="float: left; width: 750px;">
                    </div>
                    <div id="divNoEvents" runat="server" style="display: none">
                        <span style="color: #D60202;">No event has been scheduled at this Host by you.</span>
                    </div>
                </div>
                <div class="fltrdv" style="margin: 10px 0 5px 0">
                    <strong>Events in ZipCode
                        <%=HostZipCode%></strong> &nbsp;<img src="/App/Images/minus-signs.gif" id="_imgEventsOnHostZip"
                            style="cursor: pointer" onclick="ExpandCollapse('_divEventsOnHostZip','_hrfEventsOnHostZip','_imgEventsOnHostZip')" />
                    <a href="javascript:void(0);" onclick="ExpandCollapse('_divEventsOnHostZip','_hrfEventsOnHostZip','_imgEventsOnHostZip')"
                        id="_hrfEventsOnHostZip">Collapse</a></div>
                <div class="maindivgrids_hd" id="_divEventsOnHostZip">
                    <asp:GridView ID="_eventsOnHostZip" runat="server" CssClass="divgrid_cl" GridLines="none"
                        DataKeyNames="EventID" AllowSorting="True" OnSorting="EventsOnHostZip_Sorting"
                        EnableSortingAndPagingCallbacks="false" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="SalesRepID" Visible="False" />
                            <asp:TemplateField HeaderText="Name" SortExpression="EventName">
                                <ItemTemplate>
                                    <a href='<%#ResolveUrl("~/App/Common/EventDetails.aspx?EventID=" + DataBinder.Eval(Container.DataItem, "EventID")+ "&Parent=Host") %>'>
                                        <%# DataBinder.Eval(Container.DataItem, "HostName")%>
                                    </a>
                                    <br />
                                    Event Status:(<%# (EventStatus) DataBinder.Eval(Container.DataItem, "EventStatus")%>)
                                </ItemTemplate>
                                <ItemStyle CssClass="" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="EventDate" DataFormatString="{0:MM/dd/yyyy}"
                                HtmlEncode="false"></asp:BoundField>
                            <asp:BoundField DataField="CustomerCount" HeaderText="Customers Registered"></asp:BoundField>
                        </Columns>
                        <RowStyle CssClass="row2"></RowStyle>
                        <HeaderStyle CssClass="row1"></HeaderStyle>
                        <AlternatingRowStyle CssClass="row3"></AlternatingRowStyle>
                    </asp:GridView>
                    <div runat="server" id="eventsOnHostZipPaging" style="float: left; width: 750px;">
                    </div>
                    <div id="_eventHostZipNoRecord" runat="server" style="display: none">
                        <span style="color: #D60202;">No event has been scheduled at this Host zip code.</span>
                    </div>
                </div>
                <div class="fltrdv" style="margin: 10px 0 5px 0">
                    <strong>Events Held Within
                        <%=HostDistanceMiles%>
                        Miles of ZipCode
                        <%=HostZipCode%></strong> &nbsp;<img src="/App/Images/minus-signs.gif" id="_imgEventsOnHostZipDistance"
                            style="cursor: pointer" onclick="ExpandCollapse('_divEventsOnHostZipDistance','_hrfEventsOnHostZipDistance','_imgEventsOnHostZipDistance')" />
                    <a href="javascript:void(0);" onclick="ExpandCollapse('_divEventsOnHostZipDistance','_hrfEventsOnHostZipDistance','_imgEventsOnHostZipDistance')"
                        id="_hrfEventsOnHostZipDistance">Collapse</a></div>
                <div class="maindivgrids_hd" id="_divEventsOnHostZipDistance">
                    <asp:GridView ID="_eventsOnHostZipDistance" runat="server" CssClass="divgrid_cl"
                        GridLines="none" DataKeyNames="EventID" AllowSorting="True" OnSorting="EventsOnHostZipDistance_Sorting"
                        EnableSortingAndPagingCallbacks="false" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="SalesRepID" Visible="False" />
                            <asp:TemplateField HeaderText="Name" SortExpression="EventName">
                                <ItemTemplate>
                                    <a href='<%#ResolveUrl("~/App/Common/EventDetails.aspx?EventID=" + DataBinder.Eval(Container.DataItem, "EventID")+ "&Parent=Host") %>'>
                                        <%# DataBinder.Eval(Container.DataItem, "HostName")%>
                                    </a>
                                    <br />
                                    Event Status:(<%# (EventStatus) DataBinder.Eval(Container.DataItem, "EventStatus")%>)
                                </ItemTemplate>
                                <ItemStyle CssClass="" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="EventDate" DataFormatString="{0:MM/dd/yyyy}"
                                HtmlEncode="false"></asp:BoundField>
                            <asp:BoundField DataField="CustomerCount" HeaderText="Customers Registered"></asp:BoundField>
                        </Columns>
                        <RowStyle CssClass="row2"></RowStyle>
                        <HeaderStyle CssClass="row1"></HeaderStyle>
                        <AlternatingRowStyle CssClass="row3"></AlternatingRowStyle>
                    </asp:GridView>
                    <div runat="server" id="eventsOnHostDistancePaging" style="float: left; width: 750px;">
                    </div>
                    <div id="_eventHostZipDistanceNoRecord" runat="server" style="display: none">
                        <span style="color: #D60202;">No event has been scheduled within
                            <%=HostDistanceMiles%>
                            Miles.</span>
                    </div>
                </div>
            </div>
        </div>
        <div class="hr left">
        </div>
        <p style="float: left; width: 740px;">
            <asp:ImageButton ID="ibtnback" runat="server" ImageUrl="~/App/Images/back-button.gif"
                OnClick="ibtnback_Click" />
        </p>
        <div class="maindivgrids_hd">
        </div>
    </div>
    <asp:HiddenField ID="hfProsectID" runat="server" />
    <asp:HiddenField ID="hidpageindex" runat="server" />
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
    });
</script>

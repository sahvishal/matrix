<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_AddCallProspect" CodeBehind="AddCallProspect.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../UCCommon/ucMiniAddNewContact.ascx" TagName="ucMiniAddNewContact"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        /*---------- bubble tooltip -----------*/a.tt
        {
            position: relative;
            z-index: 24;
            color: #287AA8;
            font-weight: normal;
            text-decoration: underline;
        }
        a.tt span
        {
            display: none;
        }
        /*background:; ie hack, something must be changed in a for ie to execute it*/a.tt:hover
        {
            z-index: 25;
            color: #ff6600;
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
        }
        a.tt:hover span.top
        {
            display: block;
            padding: 30px 8px 0;
            background: url(/App/Images/bubble.gif) no-repeat top;
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
        }
        .titletext_anp
        {
            float: left;
            width: 100px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputf_anp
        {
            float: left;
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 1px;
        }
        .inputfieldrightcon_anp
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
        }
        .list_anp
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .inputfieldrightcon_anp
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
        }
        .inputfield180px_anp
        {
            float: left;
            width: 185px;
            margin-right: 45px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfield300px_anp
        {
            float: left;
            width: 300px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfield480px_anp
        {
            float: left;
            width: 458px;
            font: bold 12px arial;
            color: #000;
            padding-left: 22px;
        }
        .inputfield140px_anp
        {
            float: left;
            width: 140px;
            margin-right: 30px;
            font: bold 12px arial;
            color: #000;
        }
        .greybox_anp
        {
            float: left;
            width: 500px;
            padding: 10px;
            background-color: #eee;
            border: solid 1px #e6e6e6;
        }
        .greybox_anp .row
        {
            float: left;
            width: 480px;
            font-weight: bold;
        }
        .TextBoxAsLabel
        {
           border: none !important;
           background-color: #fff !important;
           background: transparent !important;
        }
    </style>
    <script src="/App/JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>
    <script type="text/javascript" src="../JavascriptFiles/HttpRequest.js"></script>
    <script language="javascript" type="text/javascript">

        function OpenEditProspect() {
            var hfProspectID = document.getElementById("<%=this.hfProspectID.ClientID %>");
            var hfProspectType = document.getElementById("<%=this.hfProspectType.ClientID %>");
            var HidDuplicateContact = document.getElementById("<%=this.HidDuplicateContact.ClientID %>");
            HidDuplicateContact.value = "True";

            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=780,height=430";
            if (hfProspectType.value == 'Host')
                window.open("EditProspectPopUp.aspx?IsHost=True&ProspectId=" + hfProspectID.value, 'EditHost', winOpts);
            else
                window.open("EditProspectPopUp.aspx?ProspectId=" + hfProspectID.value, 'EditProspect', winOpts);
            return false;
        }

        function validation() {

            GetAllContacts();
            var txtStartDate = document.getElementById('<%= this.txtStartDate.ClientID %>');

            if (txtStartDate.value != '' && txtStartDate.value.length > 0) {
                if (ValidateDate(txtStartDate.value, 'Start date') == false) {
                    return false;
                }
                if (checkDate(txtStartDate.value, 'Start Date') == false)
                { return false; }
            }

            var radioFollowAction = document.getElementById("<%=this.radioFollowAction.ClientID %>");
            if (radioFollowAction.checked == true) {
                var chkboxCall = document.getElementById("<%=this.chkboxCall.ClientID %>");
                var chkboxMeeting = document.getElementById("<%=this.chkboxMeeting.ClientID %>");
                var chkboxTask = document.getElementById("<%=this.chkboxTask.ClientID %>");

                var txtCallSubject = document.getElementById("<%=this.txtCallSubject.ClientID %>");
                var txtCallStartDate = document.getElementById("<%=this.txtCallStartDate.ClientID %>");
                var txtCallStartTime = document.getElementById("<%=this.txtCallStartTime.ClientID %>");
                var txtMeetingStartDate = document.getElementById("<%=this.txtMeetingStartDate.ClientID %>");
                var txtMeetingStartTime = document.getElementById("<%=this.txtMeetingStartTime.ClientID %>");
                var txtTask = document.getElementById("<%=this.txtTask.ClientID %>");

                if (chkboxCall.checked == true) {
                    if (isBlank(txtCallSubject, 'Follow Up Call Subject'))
                        return false;
                    if (isBlank(txtCallStartDate, 'Follow Up Call Start Date'))
                        return false;
                    //                if(isBlank(txtCallStartTime, 'Follow Up Call Start Time'))
                    //                    return false;
                }
                if (chkboxMeeting.checked == true) {
                    if (isBlank(txtMeetingStartDate, 'Follow Up Meeting Start Date'))
                        return false;
                    if (isBlank(txtMeetingStartTime, 'Follow Up Meeting Start Time'))
                        return false;
                }
                //            if(chkboxTask.checked==true)
                //            {
                //                if(isBlank(txtTask, 'Follow Up Task'))
                //                    return false;
                //            }
                if (txtCallStartDate.value != "") {
                    if (ValidateDate(txtCallStartDate.value, 'Follow Up Call Start Date') == false) {
                        return false;
                    }
                    if (checkDate(txtCallStartDate.value, 'Follow Up Call Start Date') == false)
                    { return false; }
                }
                if (txtMeetingStartDate.value != "") {
                    if (ValidateDate(txtMeetingStartDate.value, 'Follow Up Meeting Start Date') == false) {
                        return false;
                    }
                    if (checkDate(txtMeetingStartDate.value, 'Follow Up Meeting Start Date') == false)
                    { return false; }
                }
                var txtTaskDueDate = document.getElementById("<%=this.txtTaskDueDate.ClientID %>");
                if (txtTaskDueDate.value != "") {
                    if (ValidateDate(txtTaskDueDate.value, 'Follow Up Task Due Date') == false) {
                        return false;
                    }
                    if (checkDate(txtTaskDueDate.value, 'Follow Up Task Due Date') == false)
                    { return false; }
                }
            }

        }
        function check() {
            alert("Please check this in next release.");
        }


        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }
        function hideDivFollwoUpAction() {
            var divFollwoUpAction = document.getElementById("divFollwoUpAction");
            divFollwoUpAction.style.display = "none";
        }
        function ShowDivFollwoUpAction() {
            var divFollwoUpAction = document.getElementById("divFollwoUpAction");
            divFollwoUpAction.style.display = "block";

        }
        function HideShowCall() {
            var chkboxCall = document.getElementById("<%=this.chkboxCall.ClientID %>");
            var divCall = document.getElementById("divCall");
            if (chkboxCall.checked == true) {
                divCall.style.display = "block";
            }
            else {
                divCall.style.display = "none";
            }
        }

        function HideShowMeeting() {
            var chkboxMeeting = document.getElementById("<%=this.chkboxMeeting.ClientID %>");
            var divMetting = document.getElementById("divMetting");
            if (chkboxMeeting.checked == true) {
                divMetting.style.display = "block";
            }
            else {
                divMetting.style.display = "none";
            }
        }
        function HideShowTask() {
            var chkboxTask = document.getElementById("<%=this.chkboxTask.ClientID %>");
            var pTask = document.getElementById("pTask");
            if (chkboxTask.checked == true) {
                pTask.style.display = "block";
            }
            else {
                pTask.style.display = "none";
            }
        }
        function FilterTime(key, textbox, dFilterMask) {
            return dFilter(key, textbox, dFilterMask);
        }

        function AddSlotAutoFill(textbox) {
            dFilter_AutoFill(textbox);
        }
        function ShowAddContactPopup() {
            ClearContactFields();
            SetContactTitle('Add New Contact');
            document.getElementById('<%= this.hidContactIDEdit.ClientID %>').value = '';
            $find('mdlPopup1').show();
            return false;
        }
        function HideAddContactPopup() {
            $find('mdlPopup1').hide();
            return false;
        }

        function GetAllContacts() {
            var HidAllContactID = document.getElementById('<%= this.HidAllContactID.ClientID %>');
            HidAllContactID.value = '';
            var grdContacts = document.getElementById('<%= this.grdContacts.ClientID %>');
            var rowcount = 0;
            var cellnode = 0;
            if (grdContacts) {
                while (rowcount < grdContacts.rows.length) {
                    if (grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id == undefined)
                        cellnode = 1;
                    if (grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id == 'chkContact') {
                        if (grdContacts.rows[rowcount].cells[0].childNodes[cellnode].checked) {
                            HidAllContactID.value = HidAllContactID.value + grdContacts.rows[rowcount].cells[0].childNodes[cellnode].value + ',';
                        }
                    }
                    rowcount = rowcount + 1;
                }
                //alert(HidAllContactID.value);  
            }
        }

        function CallDetails() {
            // Set Tab Status in Hidden Field
            var HidTabStatus = document.getElementById("<%=this.HidTabStatus.ClientID %>");
            HidTabStatus.value = 1;

            var imgBtnCallDetails = document.getElementById("<%=this.imgBtnCallDetails.ClientID %>");
            imgBtnCallDetails.src = "/App/Images/MarketingPartner/calldetails-tab-on.gif";

            var imgBtnCallHistory = document.getElementById("<%=this.imgBtnCallHistory.ClientID %>");
            imgBtnCallHistory.src = "/App/Images/MarketingPartner/history-taboff.gif";

            var DivCallDetails = document.getElementById("<%=this.DivCallDetails.ClientID %>");
            DivCallDetails.style.display = "block"

            var DivCallHistory = document.getElementById("<%=this.DivCallHistory.ClientID %>");
            DivCallHistory.style.display = "none"
            return false;
        }

        function CallHistory() {
            // Set Tab Status in Hidden Field
            var HidTabStatus = document.getElementById("<%=this.HidTabStatus.ClientID %>");
            HidTabStatus.value = 2;

            var imgBtnCallDetails = document.getElementById("<%=this.imgBtnCallDetails.ClientID %>");
            imgBtnCallDetails.src = "/App/Images/MarketingPartner/calldetails-tab-off.gif";

            var imgBtnCallHistory = document.getElementById("<%=this.imgBtnCallHistory.ClientID %>");
            imgBtnCallHistory.src = "/App/Images/MarketingPartner/history-tabon.gif";

            var DivCallDetails = document.getElementById("<%=this.DivCallDetails.ClientID %>");
            DivCallDetails.style.display = "none"

            var DivCallHistory = document.getElementById("<%=this.DivCallHistory.ClientID %>");
            DivCallHistory.style.display = "block"
            return false;
        }
        function SelectContact() {
            var hidContactID = document.getElementById('<%= this.hidContactID.ClientID %>');
            var grdContacts = document.getElementById('<%= this.grdContacts.ClientID %>');
            var rowcount = 0;
            var cellnode = 0;
            if (grdContacts) {
                while (rowcount < grdContacts.rows.length) {
                    if (grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id == undefined)
                        cellnode = 1;
                    if (grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id == 'chkContact') {
                        if (grdContacts.rows[rowcount].cells[0].childNodes[cellnode].value == hidContactID.value) {
                            grdContacts.rows[rowcount].cells[0].childNodes[cellnode].checked = true;
                        }
                    }
                    rowcount = rowcount + 1;
                }
                //alert(HidAllContactID.value);  
            }
        }
        function EditContact(SelectedContactID) {
            ClearContactFields();
            hidContactID = document.getElementById('<%= this.hidContactID.ClientID %>');
            document.getElementById('<%= this.hidContactIDEdit.ClientID %>').value = SelectedContactID;
            hidContactID.value = SelectedContactID;
            FillGrid(hidContactID.value);
            return false;
        }

        function FillGrid(ContactID) {
            //alert(ContactID);
            var postRequest1 = new HttpRequest();
            postRequest1.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            postRequest1.failureCallback = requestFailed();
            //alert("AsyncEditContactProspect.aspx?ContactID="+ ContactID);
            postRequest1.url = "AsyncEditContactProspect.aspx?ContactID=" + ContactID;
            postRequest1.successCallback = setGrid;
            postRequest1.post("");
            return false;
        }

        function setGrid(httpRequest1) {
            var xmlDoc = httpRequest1.responseXML;
            var result = httpRequest1.responseText;
            //alert(result);
            var firstindex = result.indexOf('divMain');
            var lastindex = result.lastIndexOf('</div>');
            var mainresult = result.substring(firstindex + 9, lastindex);
            //alert(mainresult);
            SetContactTitle('Edit Contact');
            SetContact(mainresult);
            $find('mdlPopup1').show();
            return false;
        }
        function requestFailed()
        { }
    
    </script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="8px" /></p>
                <div class="headingbox_default">
                    <div class="orngheadtxt_heading" id="heading" runat="server" runat="server">
                        Add Call To Prospect
                    </div>
                </div>
                <div class="maindivinnerrow_feedback" id="divProspectDetails" runat="server">
                    <%--Begin Prospect Details--%>
                    <div class="divtoptxtbox_hd">
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd" id="spnName" runat="server">Prospect Name:</span>
                            <span class="inputfieldconleft_default" id="spProspectName2" runat="server"></span>
                            <span class="divtopboxttext_hd">URL:</span> <%--<span class="inputfieldconright_default" id="spURL" runat="server"></span>--%>
                             <asp:TextBox id="spURL" runat="server" CssClass="TextBoxAsLabel inputfieldconright_default" disabled></asp:TextBox>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd" id="spnAddress" runat="server">Prospect Address:</span>
                            <span class="inputfieldconleft_default" id="spAddress" runat="server"></span><span
                                class="divtopboxttext_hd">Phone No:</span> <span class="inputfieldconright_default"
                                    id="spPhone" runat="server"></span>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd">Email:</span> <span class="inputfieldconleft_default"
                                id="spOther" runat="server"></span><span class="divtopboxttext_hd" id="spnType" runat="server">
                                    Prospect Type:</span> <span class="inputfieldconright_default" id="spnProspectType"
                                        runat="server"></span>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd">Attendance:</span> <span class="inputfieldconleft_default"
                                id="spnAttendence" runat="server"></span><span class="divtopboxttext_hd">Members:</span>
                            <span class="inputfieldconright_default" id="spnMembersEmployees" runat="server">
                            </span>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd">Will Promote:</span> <span class="inputfieldconleft_default"
                                id="spnWillPromote" runat="server"></span><span class="divtopboxttext_hd">Facilities
                                    Fee($):</span> <span class="inputfieldconright_default" id="spnFacilitiesFee" runat="server">
                                    </span>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd">Viable Host Site:</span> <span class="inputfieldconleft_default"
                                id="spnViableHostSite" runat="server"></span><span class="divtopboxttext_hd">Will Host:</span>
                            <span class="inputfieldconright_default" id="spnWillHost" runat="server"></span>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd">
                                <asp:LinkButton ID="lnkEditProspect" OnClientClick="return OpenEditProspect();" runat="server">Edit Prospect</asp:LinkButton></span>
                            <span class="inputfieldconleft_default" id="Span1" runat="server"></span><span class="divtopboxttext_hd">
                            </span><span class="inputfieldconright_default" id="Span2" runat="server"></span>
                        </p>
                    </div>
                    <%--End Prospect Details--%>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
                <div style="float: left; height: 27px; width: 746px;" id="divTab" runat="server">
                    <asp:ImageButton ID="imgBtnCallDetails" runat="server" ImageUrl="~/App/Images/MarketingPartner/calldetails-tab-on.gif"
                        OnClientClick="return CallDetails();"></asp:ImageButton>
                    <asp:ImageButton ID="imgBtnCallHistory" runat="server" ImageUrl="~/App/Images/MarketingPartner/history-taboff.gif"
                        OnClientClick="return CallHistory();"></asp:ImageButton>
                </div>
                <%--Begin Call Details--%>
                
                    <div style="float: left; display: block" id="DivCallDetails" runat="server">
                        <div class="main_area_bdr" style="margin-top: 0px; border-color: #D4ECF6;">
                            <div class="main_container_row_default" runat="server" id="divGridContacts" style="display: block;
                                visibility: visible">
                                <div class="titletextsmallbld1_default" style="">
                                    Talked To:</div>
                                <div class="inputfldnowidth_default">
                                    <asp:GridView ID="grdContacts" DataKeyNames="ContactID" runat="server" CssClass=""
                                        GridLines="None" AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="grdContacts_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--<input type="radio" id="rbtnPCP"  name="PCP" value="<%# DataBinder.Eval(Container.DataItem, "ContactID")%>"  onclick="return SetContact(this);" />--%>
                                                    <input type="checkbox" id="chkContact" name="PCP" value="<%# DataBinder.Eval(Container.DataItem, "ContactID")%>" />
                                                    <span id="spnContactID" style="visibility: hidden">
                                                        <%# DataBinder.Eval(Container.DataItem, "ContactID")%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <span id="spnFullName" runat="server">
                                                        <%# DataBinder.Eval(Container.DataItem, "FullName")%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <span id="spnTitle" runat="server">&nbsp;<%# DataBinder.Eval(Container.DataItem, "Title")%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <span id="spnUpdate" runat="server">&nbsp;[&nbsp; <a href="#" title="Update Contact"
                                                        onclick='return EditContact(<%# DataBinder.Eval(Container.DataItem, "ContactID")%>);'>
                                                        Update</a> &nbsp;|&nbsp;<a href="javascript:void(0);" class="tt" runat="server" id="a1"
                                                            title='<%# DataBinder.Eval(Container.DataItem, "Title")%>'> View notes <span class="tooltip">
                                                                <span class="top"></span><span class="middle" id="spndefcursor<%# DataBinder.Eval(Container.DataItem, "ContactID")%>"
                                                                    onmouseover="changetodefault('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ContactID")%>');"
                                                                    onmouseout="changetopointer('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ContactID")%>');">
                                                                    <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                </span><span class="bottom"></span></span></a>&nbsp;] </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <p class="main_container_row_default">
                                <span class="titletextsmallbld1_default"></span><span class="inputfldnowidth_default">
                                    <asp:LinkButton Text="+ Add New Contact" ID="lnkNewContact" runat="server" OnClientClick="return ShowAddContactPopup();"></asp:LinkButton>
                                </span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletextsmallbld1_default">Subject: </span><span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="inputf_def" Width="600px"></asp:TextBox></span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletextsmallbld1_default">Start Date: </span><span class="inputfldnowidth_default"
                                    style="width: 110px">
                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputf_def" Width="105px"></asp:TextBox>
                                    <span style="font-size: 7pt;">(mm/dd/yyyy)</span> </span><span class="calendarcntrl_default"
                                        style="margin-right: 40px;">
                                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="Imgbtncalender"
                                            AlternateText="Click to show calendar" />
                                        <ajaxToolkit:CalendarExtender ID="extTaskStartDate" runat="server" Format="MM/dd/yyyy"
                                            Animated="true" PopupButtonID="Imgbtncalender" TargetControlID="txtStartDate">
                                        </ajaxToolkit:CalendarExtender>
                                    </span><span class="titletextnowidth_default">Time:</span> <span class="inputfldnowidth_default"
                                        style="width: 140px; margin-right: 40px;">
                                        <asp:TextBox ID="txtStartTime" runat="server" CssClass="inputf_anp" onblur="javascript:AddSlotAutoFill(this);"
                                            onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                        <span style="font-size: 7pt;">(hh:mm)</span> </span><span class="titletextnowidth_default"
                                            style="width: 50px">Type:</span> <span class="inputfldnowidth_default">
                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="inputf_def" Width="110px">
                                                </asp:DropDownList>
                                            </span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletextsmallbld1_default">Duration:</span> <span class="inputfldnowidth_default"
                                    style="margin-right: 51px;">
                                    <asp:DropDownList ID="ddlDuration" runat="server" AutoPostBack="false" Width="110px">
                                    </asp:DropDownList>
                                </span><span class="titletextnowidth_default">Status:</span> <span class="inputfldnowidth_default"
                                    style="margin-right: 40px;">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputf_def" Width="115px">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletextsmallbld1_default">Notes:</span> <span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtNotes" runat="server" CssClass="inputf_def" TextMode="MultiLine"
                                        Rows="4" Width="600px"></asp:TextBox></span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletextsmallbld1_default" style="width: 78px">Call Result:</span>
                                <span class="inputfldnowidth_default">
                                    <asp:RadioButton ID="rbnCallResultNoAnswer" runat="server" GroupName="CallResult"
                                        Text="No Answer" />
                                    <asp:RadioButton ID="rbnCallResultLeftVoiceMail" runat="server" GroupName="CallResult"
                                        Text="Left Voice Mail" />
                                    <asp:RadioButton ID="rbnCallResultTaledToPerson" runat="server" GroupName="CallResult"
                                        Text="Talked to a person" />
                                </span>
                            </p>
                            <div id="divFutureAction" runat="server" style="float: left; display: block; visibility: visible">
                                <p class="main_container_row_default">
                                    <span class="titletextsmallbld1_default" style="width: 78px">Future Action:</span>
                                    <span class="inputfieldconleft_default">
                                        <asp:RadioButton ID="radioNone" runat="server" Text="None" Checked="true" GroupName="FollowUpAction" />
                                    </span>
                                </p>
                                <p class="main_container_row_default">
                                    <span class="titletextsmallbld1_default" style="width: 78px">
                                        <img src="../Images/specer.gif" width="78px" height="1px" /></span> <span class="inputfieldconleft_default">
                                            <asp:RadioButton ID="radioFollowAction" runat="server" Text="Follow up Action" GroupName="FollowUpAction" /></span>
                                </p>
                                <div class="main_container_row_default">
                                    <div class="titletextsmallbld1_default" style="width: 78px">
                                        <img src="../Images/specer.gif" width="78px" height="1px" /></div>
                                    <div class="greybox_anp" id="divFollwoUpAction" style="display: none;">
                                        <p class="row">
                                            <asp:CheckBox ID="chkboxCall" runat="server" Text="Follow up Call" />
                                        </p>
                                        <div id="divCall" style="display: none;">
                                            <p class="row">
                                                <span class="inputfield480px_anp">Subject:<span class="reqiredmark"><sup>*</sup></span><asp:TextBox
                                                    ID="txtCallSubject" runat="server" Width="458px" CssClass="inputf_anp"></asp:TextBox></span>
                                            </p>
                                            <p class="row">
                                                <span class="inputfield480px_anp"><span class="inputfield140px_anp">Start Date:<span
                                                    class="reqiredmark"><sup>*</sup></span><asp:TextBox ID="txtCallStartDate" runat="server"
                                                        Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                    <span class="calendarcntrl_default">
                                                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="ImageButton1" /></span></span>
                                                    <span class="inputfield140px_anp">Time:<asp:TextBox ID="txtCallStartTime" runat="server"
                                                        Width="140px" CssClass="inputf_anp" onblur="javascript:AddSlotAutoFill(this);"
                                                        onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                                        (hh:mm)</span> </span>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                                    Animated="true" PopupButtonID="ImageButton1" TargetControlID="txtCallStartDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </p>
                                            <p class="row">
                                                <img src="../Images/specer.gif" width="5px" height="5px" /></p>
                                        </div>
                                        <p class="row">
                                            <asp:CheckBox ID="chkboxMeeting" runat="server" Text="Follow up Meeting" />
                                        </p>
                                        <div id="divMetting" style="display: none;">
                                            <p class="row">
                                                <span class="inputfield480px_anp"><span class="inputfield140px_anp">Start Date:<span
                                                    class="reqiredmark"><sup>*</sup></span><asp:TextBox ID="txtMeetingStartDate" runat="server"
                                                        Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                    <span class="calendarcntrl_default">
                                                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="ImageButton2" /></span></span>
                                                    <span class="inputfield140px_anp">Time:<span class="reqiredmark"><sup>*</sup></span><asp:TextBox
                                                        ID="txtMeetingStartTime" runat="server" Width="110px" CssClass="inputf_anp" onblur="javascript:AddSlotAutoFill(this);"
                                                        onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                                        (hh:mm)</span> <span class="inputfield110px_anp">Venue:
                                                            <asp:TextBox ID="txtVenue" runat="server" Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                        </span></span>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                                    Animated="true" PopupButtonID="ImageButton2" TargetControlID="txtMeetingStartDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </p>
                                            <p class="row">
                                                <img src="../Images/specer.gif" width="5px" height="5px" /></p>
                                        </div>
                                        <p class="row">
                                            <asp:CheckBox ID="chkboxTask" runat="server" Text="Follow up Task" />
                                        </p>
                                        <div id="pTask" style="display: none;">
                                            <p class="row">
                                                <span class="inputfield480px_anp">
                                                    <asp:TextBox ID="txtTask" runat="server" Width="458px" CssClass="inputf_anp"></asp:TextBox>
                                                </span>
                                            </p>
                                            <p class="row">
                                                <span class="inputfield480px_anp"><span class="inputfield140px_anp">Due Date:(mm/dd/yyyy)
                                                    <asp:TextBox ID="txtTaskDueDate" runat="server" Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                    <span class="calendarcntrl_default">
                                                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="ImageButton3" />
                                                    </span><span class="">
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="true"
                                                            Format="MM/dd/yyyy" PopupButtonID="ImageButton3" TargetControlID="txtTaskDueDate">
                                                        </ajaxToolkit:CalendarExtender>
                                                    </span></span><span class="inputfield140px_anp">Time:
                                                        <asp:TextBox ID="txtTaskDueTime" runat="server" Width="140px" CssClass="inputf_anp"
                                                            onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                                        (hh:mm) </span></span>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="headbg2_box_default">
                            <div class="buttoncon_default">
                                <asp:ImageButton ID="btnSave" runat="server" CssClass="" ImageUrl="~/App/Images/save-button.gif"
                                    OnClientClick="return validation();" OnClick="btnSave_Click" />
                            </div>
                            <div class="button_con_savencancel" id="divBtnCloseNCreate" runat="server">
                                <asp:ImageButton ID="btnCloseAndCreate" runat="server" CssClass="" ImageUrl="~/App/Images/savencreatenew-btn.gif"
                                    OnClientClick="return validation();" OnClick="btnCloseAndCreate_Click" />
                            </div>
                            <div class="buttoncon_default">
                                <asp:ImageButton ID="btnCancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                                    OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                <%--End Call Details--%>
                <div class="main_area_bdr" runat="server" id="DivCallHistory" style="margin-top: 0px;
                    border-color: #D4ECF6; display: none;">
                    <%--Begin Call Details Grid--%>
                    <div class="dgdefault" id="divCalls" runat="server" style="padding: 0px 10px 0px 10px;">
                        <div style="float: left; width: 733px">
                            <asp:GridView DataKeyNames="ID" ID="grdAll" runat="server" CssClass="divgrid_cl"
                                AutoGenerateColumns="False" OnPageIndexChanging="grdAll_PageIndexChanging" GridLines="None">
                                <AlternatingRowStyle CssClass="row3" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div style="float: left; width: 100%;">
                                                <span class="titletextsmallbld_default">
                                                    <%# DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                </span><span style="float: left; width: 500px;"><span class="ttxtwidthnormal_default">
                                                    <span class="btextblu">
                                                        <%# DataBinder.Eval(Container.DataItem, "Type")%></span>
                                                    <%# DataBinder.Eval(Container.DataItem, "Subject")%></span> <span class="ttxtwidthnormal_default">
                                                        <span class="btextblu">
                                                            <%# DataBinder.Eval(Container.DataItem, "TypeText")%></span>
                                                        <%# DataBinder.Eval(Container.DataItem, "ContactName")%></span> <span class="ttxtwidthnormal_default">
                                                            <%# DataBinder.Eval(Container.DataItem, "Notes")%></span> </span>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="row1" />
                                <RowStyle CssClass="row2" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="norcrdmsg_acp" style="display: none;" id="divNoResultsAll" runat="server">
                        <span class="norcrdmsgtxt_acp">No Result Found.</span>
                    </div>
                    <%--End Call Details Grid--%>
                </div>
            </div>
        </div>
    </div>
    <asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
    <asp:Panel ID="pnlAddContact" runat="server" Style="display: none;">
        <uc1:ucMiniAddNewContact ID="ucMiniAddNewContact1" runat="server" Onclicking="HandleSave" />
    </asp:Panel>
    <asp:HiddenField ID="hfProspectID" Value="" runat="server" />
    <asp:HiddenField ID="hfProspectType" Value="" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkNewContact"
        PopupControlID="pnlAddContact" BackgroundCssClass="modalBackground" CancelControlID="lnktemp"
        BehaviorID="mdlPopup1" />
    <input type="hidden" id="hidContactID" runat="server" />
    <input type="hidden" id="hidContactIDEdit" runat="server" />
    <asp:HiddenField ID="hfProsectID" runat="server" />
    <asp:HiddenField ID="HidAllContactID" runat="server" />
    <asp:HiddenField ID="HidTabStatus" runat="server" />
    <asp:HiddenField ID="HidDuplicateContact" runat="server" />
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCChangeAppointment"
    CodeBehind="UCChangeAppointment.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UcEventAppointment.ascx" TagName="UcEventAppointment" TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/OrderItemCart.ascx" TagName="ItemCart" TagPrefix="Order" %>
<%@ Register Src="~/App/UCCommon/UcChangeAppointmentPayment.ascx" TagName="appointmentPayment" TagPrefix="payment" %>
<link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>
<script src="/Content/JavaScript/PreQualificationQuestion.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>
<style type="text/css">
    .wrapper_pop {
        float: left;
        width: 502px;
        padding: 10px;
        background-color: #f5f5f5;
    }

    .wrapperin_pop {
        float: left;
        width: 478px;
        border: solid 2px #4888AB;
        padding: 10px;
        background-color: #fff;
    }

    .innermain_pop {
        float: left;
        width: 458px;
        padding: 0px 5px 0px 5px;
    }

    .innermain_1_pop {
        float: left;
        width: 463px;
        padding-top: 5px;
    }
</style>
<script type="text/javascript" language="javascript">

    String.prototype.trim = function () {
        a = this.replace(/^\s+/, '');
        return a.replace(/\s+$/, '');
    };

    function Reset() {
        document.getElementById("<%= txtState.ClientID %>").value = "";
        document.getElementById("<%= txtCity.ClientID %>").value = "";
        document.getElementById("<%= txtZip.ClientID %>").value = "";
        document.getElementById("<%= txtFrom.ClientID %>").value = "";
        document.getElementById("<%= txtTo.ClientID %>").value = "";

        return false;
    }

    function Validate() {
        var state = document.getElementById("<%= txtState.ClientID %>").value.trim();
        var city = document.getElementById("<%= txtCity.ClientID %>").value.trim();
        var zip = document.getElementById("<%= txtZip.ClientID %>").value.trim();
        var txtStartDate = document.getElementById("<%= txtFrom.ClientID %>");
        var txtEndDate = document.getElementById("<%= txtTo.ClientID %>");

        if (state == "" && city == "" && zip == "" && txtStartDate.value.trim() == "" && txtEndDate.value.trim() == "") {
            alert("Please input at least one field (State/City/Zip/DateRange) to search.");
            return false;
        }

        //debugger
        if (txtStartDate.value.trim() == "" && txtEndDate.value.trim() == "") {
            ///No date range provided
            return true;
        }
        else {
            if (CompareDateWithCurrentDate2(txtStartDate, 'Please provide a future Start Date') == false)
            { return false; }
            if (CompareDateWithCurrentDate2(txtEndDate, 'Please provide a future End Date') == false)
            { return false; }
            if (ValidateDate(txtStartDate.value, 'Date Range') == false) {
                return false;
            }
            if (ValidateDate(txtEndDate.value, 'Date Range') == false) {
                return false;
            }
        }

        return true;
    }

    function txtkeypress(evt) {
        return KeyPress_NumericAllowedOnly(evt);
    }

    function CheckAppointment() {
        //debugger;


        if (!isAppointmentSelected()) {
            alert("Please select an appointment.");
            return false;
        }

        if (parseInt($("#<%= RescheduleReasonDropdownList.ClientID%>").val()) <= 0) {
            alert("Please select Reason");
            return false;
        }
        
        if ($('#' + '<%=RescheduleSubReasonDropdownList.ClientID %> option').length > 1 && $('#' + '<%=RescheduleSubReasonDropdownList.ClientID %>').val() <= "0")
        {
            alert("Please Select Sub Reason.");
            return false;
        }
    
        var notes = $('#' + '<%=ReasonNotesTextbox.ClientID %>').val();

        if($("#<%= RescheduleReasonDropdownList.ClientID%>").val() === '<%= (long)RescheduleAppointmentReason.PersonalReasons%>' && $.trim(notes) == "")
        {
            alert("Please enter notes.");
            return false;
        }

        var divCnfrmMsg = document.getElementById("divCnfrmMsg");
        var spPrevAppTime = document.getElementById("spPrevAppTime");
        var spNextAppTime = document.getElementById("spNextAppTime");
        var rBtnCnfrm = document.getElementById("<%=rBtnCnfrm.ClientID %>");
        var divEventInfo = document.getElementById("divEventInfo");
        var spOldEventID = document.getElementById("spOldEventID");
        var spNewEventID = document.getElementById("spNewEventID");
        var spOldHostName = document.getElementById("spOldHostName");
        var spNewHostName = document.getElementById("spNewHostName");

        var spAppointmentTime = document.getElementById("<%=spAppointmentTime.ClientID %>");
        var hfAppointmentTime = document.getElementById("<%= hfAppointmentTime.ClientID %>");
        var rdbNo = document.getElementById("<%=rdbNo.ClientID %>");
        var hfEventID = document.getElementById("<%=hfEventID.ClientID %>");
        var hfHostName = document.getElementById("<%=hfHostName.ClientID %>");
        var spEventID = document.getElementById("<%=spEventID.ClientID %>");
        var spHost = document.getElementById("<%=spHost.ClientID %>");
        var hfNewEventID = document.getElementById("<%=hfNewEventID.ClientID %>");
        if (divCnfrmMsg.style.display == "none") {
            rBtnCnfrm.rows[0].cells[1].childNodes[0].checked = true;
        }
        if (rdbNo.checked == true) {
            divEventInfo.style.display = "block";
            divEventInfo.style.visibility = "visible";
        }
        else {
            divEventInfo.style.display = "none";
            divEventInfo.style.visibility = "hidden";
        }
        divCnfrmMsg.style.display = "block";
        divCnfrmMsg.style.visibility = "visible";

        if (spAppointmentTime.innerHTML.indexOf(':') == 1) {
            spPrevAppTime.innerHTML = "0" + spAppointmentTime.innerHTML;
        }
        else {
            spPrevAppTime.innerHTML = spAppointmentTime.innerHTML;
        }
        spNextAppTime.innerHTML = getAppointmentTime();

        spNewEventID.innerHTML = hfNewEventID.value;
        spNewHostName.innerHTML = hfHostName.value + ' ';
        spOldEventID.innerHTML = spEventID.innerHTML;

        spOldHostName.innerHTML = document.getElementById("<%=hidNewEvent.ClientID %>").value + ' ';

        if (divCnfrmMsg.style.display == "block" && rBtnCnfrm.rows[0].cells[0].childNodes[0].checked == true) {

            $('#spnIndicator').show();
            $('#spnSave').hide();

            return true;
        }
        return false;
    }

    function hideConfirmationMessage() {//debugger;
        $("#divCnfrmMsg").hide();
    }

    $(document).ready(function () {
        _hideConfirmationMessageMethod = hideConfirmationMessage;

        if (window.localStorage.isScriptOpen === "true" && window.localStorage.scriptUrl != null && window.localStorage.scriptUrl.length > 0 && window.localStorage.scriptUrl != "null") {
            openScriptWindow();
        }
    });

    function showTagChangeWarning(customerTag, eventTag, isTagChangeAllowed) {

        var warningMessag = "WARNING: You are scheduling a " + customerTag + " member for a ";
        if (eventTag == '') {
            warningMessag = warningMessag + "retail event.  This is NOT ALLOWED.  Do you want to proceed?";
        } else {
            if (isTagChangeAllowed == 'True') {
                warningMessag = warningMessag + eventTag + " event.  This is NOT ALLOWED.  Do you want to proceed?";
            } else {
                alert("You are scheduling a " + customerTag + " member for a " + eventTag + " event.  This is NOT ALLOWED.");
                return;
            }
        }

        if (confirm(warningMessag)) {
            __doPostBack('continueWithWarning', '');
        }
    }
</script>

<script type="text/javascript" language="javascript">
    function SetAppointment(appointmentid, appointmenttime) {
        document.getElementById("<%= hfAppointmentID.ClientID %>").value = appointmentid;
        document.getElementById("<%= hfAppointmentTime.ClientID %>").value = appointmenttime;
    }
</script>
<script type="text/javascript" language="javascript">
    function ValidateInvitation() {
        var txtInvitationCode = document.getElementById("<%= this.txtInvitationCode.ClientID %>");

        if (txtInvitationCode.value == '') {
            alert('Please enter invitation code');
            txtInvitationCode.focus();
            return false;
        }
        return true;
    }
    function HideInvitationPopup() {
        $find('mdlPopup1').hide();
        return false;
    }
    function SelectEvent(eventid) {

        var hidEventID = document.getElementById("<%= this.hfNewEventID.ClientID %>");
        var txtInvitationCode = document.getElementById("<%= this.txtInvitationCode.ClientID %>");
        txtInvitationCode.value = '';
        hidEventID.value = eventid;
        $find('mdlPopup1').show();

        return false;
    }
</script>

<asp:HiddenField ID="hfEventCustomerID" runat="server" />
<asp:HiddenField ID="hfEventID" runat="server" />
<asp:HiddenField ID="hfHostName" runat="server" />
<div class="wrapper_inpg">
    <div class="main_area_bdrnone">
        <div class="headingbox_top_body">
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" />
            </p>
            <span class="orngheadtxt_heading" runat="server" id="sptitle">Change Appointment:<span
                id="spCustomerName" runat="server"></span>(ID:<span id="spCustomerID" runat="server"></span>)</span>
        </div>
        <p>
            <img src="/App/Images/specer.gif" width="700px" height="2px" />
        </p>
        <p class="graylinefull_common">
            <img src="/App/Images/specer.gif" width="1px" height="1px" />
        </p>
        <p>
            <img src="/App/Images/specer.gif" width="700px" height="5px" />
        </p>
        <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
            runat="server">
        </div>
        <div class="divmainbody_cd">
            <div class="grayboxtop_cl">
                <p class="grayboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="6" alt="" />
                </p>
                <p class="grayboxheader_cl">
                    Current Registration Summary
                </p>
                <div class="lgtgraybox_cl">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" />
                    </p>
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletext_default">Event (ID:<span id="spEventID" runat="server"></span>):
                        </span><span class="ttxtnowidthnormal_default"><span id="spHost" runat="server"></span>
                            , <span id="spAddress" runat="server"></span></span>
                    </p>
                    <%-- Added event status--%>
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletext_default">Event Status:</span> <span class="ttxtnowidthnormal_default">
                            <span id="_spnEventStatus" runat="server"></span></span>
                    </p>
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletext_default">Appointment Time:</span> <span class="ttxtnowidthnormal_default">
                            <span id="spAppointmentTime" runat="server"></span></span>
                    </p>
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletext_default">Order:</span> <span class="ttxtnowidthnormal_default">
                            <span id="spPackage" runat="server"></span></span>
                    </p>
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletext_default">Cost:</span> <span class="ttxtnowidthnormal_default">$<span id="spCost" runat="server"></span></span> <span class="titletextnowidth_default">| </span><span class="titletextnowidth_default">Source Code:</span> <span class="ttxtnowidthnormal_default">
                            <span id="spCoupon" runat="server"></span></span>
                    </p>
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" />
                    </p>
                </div>
            </div>
            <p class="grayboxbotbg_cl">
                <img src="/App/Images/specer.gif" width="746" height="4" />
            </p>
        </div>
    </div>
    <div class="main_area_bdrnone">
        <div>
            <img src="/App/Images/specer.gif" width="740px" height="10px" />
        </div>
        <div id="Div1" class="pgnosymbol_common" runat="server">
            <img src="/App/Images/page1symbolsmall.gif" />
        </div>
        <div class="orngheadtxt16_common">
            Select type of rescheduling
        </div>
    </div>
    <p class="main_area_bdrnone">
        <span class="ttxtnowidthnormal_default">
            <img src="/App/Images/specer.gif" width="35px" height="25px" /></span> <span class="ttxtnowidthnormal_default">
                <asp:RadioButton ID="rdbYes" runat="server" GroupName="grpEvent" AutoPostBack="true"
                    OnCheckedChanged="rdbNo_CheckedChanged" Text="Reschedule to a different time for the same event" /></span>
    </p>
    <p class="main_area_bdrnone">
        <span class="ttxtnowidthnormal_default">
            <img src="/App/Images/specer.gif" width="35px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                <asp:RadioButton ID="rdbNo" runat="server" GroupName="grpEvent" AutoPostBack="true"
                    OnCheckedChanged="rdbNo_CheckedChanged" Text="Reschedule to a different event" /></span>
    </p>
    <div class="main_area_bdrnone">
        <div>
            <img src="/App/Images/specer.gif" width="740px" height="10px" />
        </div>
        <div class="pgnosymbol_common">
            <img src="/App/Images/page2symbolsmall.gif" />
        </div>
        <div class="orngheadtxt16_common">Reason of rescheduling</div>
    </div>
    <div class="main_area_bdrnone">
        <span class="ttxtnowidthnormal_default">
            <img src="/App/Images/specer.gif" width="35px" height="20px" />
        </span>
        <span class="ttxtnowidthnormal_default" style="width: 70px">Reason:
        </span>
        <span class="ttxtnowidthnormal_default" id="reasonReschedulingddl">
            <asp:DropDownList runat="server" ID="RescheduleReasonDropdownList" />
        </span>
    </div>
    <div class="main_area_bdrnone" id="RescheduleSubReasonContainerDiv">
        <span class="ttxtnowidthnormal_default">
            <img src="/App/Images/specer.gif" width="35px" height="20px" />
        </span>
        <span class="ttxtnowidthnormal_default" style="width: 70px">Sub Reason:
        </span>
        <span class="ttxtnowidthnormal_default" id="subReasonReschedulingddl">
            <asp:DropDownList runat="server" ID="RescheduleSubReasonDropdownList" />
        </span>
    </div>
    <div class="main_area_bdrnone" id="reschedule-reason-div" style="display: none;">
        <span class="ttxtnowidthnormal_default">
            <img src="/App/Images/specer.gif" width="35px" height="20px" />
        </span>
        <span class="ttxtnowidthnormal_default" style="width: 70px">Notes:
        </span>
        <span class="ttxtnowidthnormal_default" id="reasonReschedulingtxtArea">
            <asp:TextBox ID="ReasonNotesTextbox" runat="server" TextMode="MultiLine" Rows="3" CssClass="inputf_def" Width="600px"></asp:TextBox>
        </span>
    </div>
    <div id="DVEvent" runat="server" style="display: none; visibility: hidden;">
        <div class="main_area_bdrnone">
            <div>
                <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
            </div>
            <div id="Div2" class="pgnosymbol_common" runat="server">
                <img src="/App/Images/page3symbolsmall.gif" />
            </div>
            <div class="orngheadtxt16_common">
                Search the new event to reschedule
            </div>
        </div>
        <div>
            <img src="/App/Images/specer.gif" width="740px" height="10px" />
        </div>
        <div id="showhidediv" class="main_area_bdrnone">
            <div class="divmainbody_cd">
                <div class="grayboxtop_cl">
                    <p class="grayboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="6" alt="" />
                    </p>
                    <p class="grayboxheader_cl">
                        Filter/Search Event
                    </p>
                    <div class="lgtgrayboxrow_cl">
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" />
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titlenowdth_cl" style="width: 50px;">State:</span> <span class="inputfldnowidth_cl">
                                <asp:TextBox ID="txtState" runat="server" CssClass="inputf_def auto-search-states"
                                    Width="110px"></asp:TextBox></span> <span class="titlenowdth_cl" style="width: 50px;">City:</span>
                            <span class="inputfldnowidth_cl">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="inputf_def auto-search-city"
                                    Width="110px"></asp:TextBox></span><span class="titlenowdth_cl">Date:</span>
                            <span class="inputfldnowidth_cl" style="width: 80px; margin-right: 10px;">
                                <asp:TextBox ID="txtFrom" runat="server" CssClass="inputf_def date-picker"
                                    Width="70px"></asp:TextBox></span> <span style="width: 80px; margin-right: 0px;" class="inputfldnowidth_cl">
                                        <asp:TextBox ID="txtTo" runat="server" CssClass="inputf_def date-picker" Width="70px"></asp:TextBox></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titlenowdth_cl" style="width: 50px;">Zip:</span>
                            <span class="inputfldnowidth_cl">
                                <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_def" Width="110px"></asp:TextBox></span>
                            <span class="titlenowdth_cl" style="width: 50px;">Radius:</span>
                            <span class="inputfldnowidth_cl" style="margin-right: 70px;">
                                <asp:DropDownList runat="server" ID="ZipRadius" Style="width: 80px;">
                                </asp:DropDownList>
                            </span>
                            <span runat="server" id="spEventSearchType">
                                <span class="titlenowdth_cl">Type:</span>
                                <span class="inputfldnowidth_cl">
                                    <asp:DropDownList runat="server" ID="EventSearchTypeDropdownList" />
                                </span>
                            </span>
                        </p>
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="15px" />
                        </p>
                    </div>
                    <div class="lgtgraybox_cl">
                        <span class="buttoncon_default">
                            <asp:ImageButton ID="ibtnSearch" OnClientClick="return Validate();" OnClick="ibtnSearch_Click"
                                runat="server" ImageUrl="~/App/Images/search-smallbtn.gif" /></span> <span class="buttoncon_default">
                                    <asp:ImageButton ID="ibtnReset" OnClientClick="return Reset();" runat="server" ImageUrl="~/App/Images/reset-btn.gif" /></span>
                    </div>
                    <p class="grayboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="4" />
                    </p>
                </div>
            </div>
        </div>
        <div>
            <img src="/App/Images/specer.gif" width="740px" height="10px" />
        </div>
        <div id="dvgrid" class="dgeventhistory_common" runat="server" style="display: none; visibility: hidden;">
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $(document).keypress(function (e) {
            var element = e.target ? e.target : e.srcElement;
            var key = (e.which ? e.which : ((e.charCode) ? e.charCode : ((e.keyCode) ? e.keyCode : 0)));
            if ($(element).parents("#showhidediv").length > 0 && key == 13) {
                $("#<%= ibtnSearch.ClientID %>").click();
            }
            else if (key == 13)
                return false;
        });
    </script>
    <div class="maindivredmsgbox" enableviewstate="false" id="errordiv" runat="server"
        style="display: none; visibility: hidden;">
    </div>
    <div id="Div3" class="dgeventhistory_common" runat="server" style="display: none;">
        <asp:GridView ID="dgEvent" runat="server" CssClass="divgrid_clnew" AutoGenerateColumns="false"
            GridLines="None" AllowPaging="true" PageSize="5" AllowSorting="false" EnableSortingAndPagingCallbacks="False"
            OnPageIndexChanging="dgEvent_PageIndexChanging" OnRowDataBound="dgEvent_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                <%--<asp:BoundField DataField="Name" HeaderText="Event Name" SortExpression="Name"></asp:BoundField>--%>
                <asp:TemplateField SortExpression="Name" HeaderText="Event">
                    <HeaderStyle Width="150" />
                    <ItemStyle Width="150" />
                    <ItemTemplate>
                        <span id="spnName" runat="server">
                            <%# DataBinder.Eval(Container.DataItem, "Name")%>
                        </span>
                        <span>
                            <img src="/Content/Images/bca.gif" style='display: <%# Convert.ToBoolean(Eval("HasBreastCancer")) ?"block":"none" %>' />
                            <img src="/Content/Images/female-sign.png" style='display: <%# Convert.ToBoolean(Eval("IsFemaleOnly"))?"block":"none" %>' />
                        </span>
                        <br />
                        <input class="hasBreastCancer" type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "HasBreastCancer")%>" />
                        <input class="isAllowNonMammoPatients" type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "AllowNonMammoPatients")%>" />
                        <span id="_spnEventStatus"><b>Status:</b>
                            <%# DataBinder.Eval(Container.DataItem, "EventStatus")%></span>
                        <br />
                        <b>Pod:</b><span>
                            <%# DataBinder.Eval(Container.DataItem, "Pods")%></span>
                        <br />
                        <b>Sponsored By:</b>
                        <span><%# DataBinder.Eval(Container.DataItem, "SponseredBy")%></span>
                        <br />
                        <span id="Span1" runat="server">
                            <%# DataBinder.Eval(Container.DataItem, "EventTypeImage")%>
                        </span><span id="spnEventID" runat="server" style="display: none;">
                            <%# DataBinder.Eval(Container.DataItem, "ID")%>
                        </span><span id="spnEventType" runat="server" style="display: none;">
                            <%# DataBinder.Eval(Container.DataItem, "EventType")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="Date" HeaderText="Event Date" SortExpression="Date" DataFormatString="{0:dddd dd MMMM yyyy}"
                    HtmlEncode="False"></asp:BoundField>--%>
                <asp:TemplateField SortExpression="Date" HeaderText="Event Date">
                    <ItemTemplate>
                        <span id="spndate1" runat="server">
                            <%# ((DateTime)DataBinder.Eval(Container.DataItem, "Date")).ToString("dddd dd MMMM yyyy")%>
                        </span>
                        <span id="SpanInvtCode" style="<%# (string)DataBinder.Eval(Container.DataItem, "InvitationCode") == ""?"display:none": "display:block" %>"><b>InvitationCode:</b>
                            <%# DataBinder.Eval(Container.DataItem, "InvitationCode")%>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Event Venue
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Host")%>
                        <br />
                        <font size="1px">
                            <%# DataBinder.Eval(Container.DataItem, "Address")%>
                            <br />
                            <a href="<%# DataBinder.Eval(Container.DataItem, "GoogleMap")%>" target="_blank">[Map
                                To Location]</a></font><a href="#" onclick="ShowDialog('<%# DataBinder.Eval(Container.DataItem, "ID")%>');">
                                    <img src="/App/Images/info-icon.gif" alt="Click to view instruction" /></a>
                        <br />
                        <span><font size="1px">
                            <%# DataBinder.Eval(Container.DataItem, "GoogleAddressVerified")%></font></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Distance" HeaderText="Distance(Miles)" SortExpression="Distance"></asp:BoundField>
                <asp:TemplateField HeaderText="Available/Total No Of Slots">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Slots")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div style="text-align: center;">
                            Actions
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center;">
                            <%--<asp:LinkButton ID="lnkSelectEvent1" runat="server" CommandName="SelectEvent" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                        Text="Select Event" OnClick="lnkSelectEvent_Click"></asp:LinkButton>--%>
                            <span id="spSlots" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "IsSlotsAvailable")%>'>
                                <asp:LinkButton ID="lnkSelectEvent1" runat="server" CommandName="SelectEvent" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    Text="Select" OnClick="lnkSelectEvent_Click" OnClientClick="return CheckhasMammoEvent(this)"></asp:LinkButton>
                                <%-- <asp:ImageButton ID="lnkSelectEvent" runat="server" CommandName='<%# DataBinder.Eval(Container.DataItem, "Name")%>'
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' OnClick="lnkSelectEvent_Click"
                                    ImageUrl="~/App/Images/CCRep/select-icon.gif"></asp:ImageButton>--%>
                            </span><span id="spNoSlots" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "IsNoSlotsAvailable")%>'>
                                <img src="/App/Images/no-slots-available-icongif.gif" alt="" /></span> <span
                                    id="spTempUnavailable" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "TempUnavailable")%>'>
                                    <img src="/App/Images/temp-unavailable-icon.gif" alt="" class="jtip" title='Suspended|<%# DataBinder.Eval(Container.DataItem, "EventNotes")%>' /></span>
                            <span id="spCancelled" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "Cancelled")%>'>
                                <img src="/App/Images/canceled-icon.gif" alt="" class="jtip" title='Canceled|<%# DataBinder.Eval(Container.DataItem, "EventNotes")%>' /></span>
                        </div>
                    </ItemTemplate>
                    <%--     <ItemStyle CssClass="imgageicngrid_ccrep" />--%>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="row1" />
            <RowStyle CssClass="row2" />
            <AlternatingRowStyle CssClass="row2" />
        </asp:GridView>
    </div>
    <a name="setposition"></a>
    <!-- to set focus on the div -->
    <div id="spAppointment" runat="server" style="display: block; visibility: visible;">
        <div class="main_area_bdrnone">
            <div>
                <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
            </div>
            <div id="Div4" class="pgnosymbol_common" runat="server">
                <img runat="server" id="imgAppointment" src="/App/Images/page3symbolsmall.gif" />
            </div>
            <div class="orngheadtxt16_common">
                <span id="spHeading" runat="server">Select type new time for the appointment</span>
            </div>
        </div>
        <div>
            <img src="/App/Images/specer.gif" width="740px" height="10px" />
        </div>
        <div class="main_area_bdrnone">
            <div style="float: left; font: bold 12px Arial; display: none; margin-left: 30px; margin-right: 20px" id="divEventHeading" runat="server">
                <div style="font: bold 12px Arial; display: none;" id="divEventID" runat="server">
                </div>
            </div>
            <div id="divEventName" class="inputfldnowidth_cl" runat="server" style="width: 70%;"></div>

            <div id="orderpaneldiv" runat="server" visible="False">
                <div class="lgtgrayboxrow_cl">
                    <span class="titletext_default" style="font: bold 12px Arial; margin-left: 15px;">Order:</span>
                    <span class="ttxtnowidthnormal_default" runat="server" id="spNewpackagename" style="width: 70%;"></span>
                </div>
                <div class="lgtgrayboxrow_cl">
                    <span class="titletext_default" style="font: bold 12px Arial; margin-left: 15px; margin-right: 15px">Cost:</span>
                    <span class="ttxtnowidthnormal_default" runat="server" id="spNewPackagecost">XXX</span>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hfAppointmentID" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="hfAppointmentTime" runat="server"></asp:HiddenField>
        <div style="float: left; margin-top: 10px; margin-left: 40px">
            <uc1:UcEventAppointment ID="_ucEventAppointment1" runat="server" />
        </div>
    </div>
    <p class="graylinefull_common" style="margin-top: 5px;">
    </p>
    <div id="PaymentContainrerDiv" style="display: none">
        <payment:appointmentPayment ID="appointmentPaymentControl" runat="server" Visible="False"></payment:appointmentPayment>
    </div>

    <div id="divCnfrmMsg" style="float: right; width: 350px; display: none; visibility: hidden;">
        <div style="float: right; width: 350px; padding-right: 25px;">
            <div style="float: left; border: solid 1px #ddd; padding: 5px; background-color: #f8f8f8">
                <div id="divEventInfo" style="display: none; visibility: hidden;">
                    <p style="float: left; width: 300px; padding-right: 20px">
                        <span style="float: left; width: 110px;"><b>Previous Event:</b></span> <span style="float: left; width: 190px;"><span id="spOldHostName"></span><span>(ID: </span><span id="spOldEventID"></span><span>)</span>
                        </span>
                    </p>
                    <p style="float: left; width: 300px; padding-right: 20px">
                        <span style="float: left; width: 110px;"><b>New Event:</b></span> <span style="float: left; width: 190px;"><span id="spNewHostName"></span><span>(ID: </span><span id="spNewEventID"></span><span>)</span>
                        </span>
                    </p>
                </div>
                <p style="float: left; width: 300px; padding-right: 20px">
                    <span style="float: left; width: 110px;"><b>Prev. Appt. Time:</b></span><span id="spPrevAppTime"></span>
                </p>
                <p style="float: left; width: 300px; padding-right: 20px">
                    <span style="float: left; width: 110px;"><b>New Appt. Time:</b></span><span id="spNextAppTime"></span>
                </p>
            </div>
        </div>
        <div style="float: right; width: 350px; padding-right: 25px;">
            <p style="float: left; width: 300px; padding-left: 7px">
                <span style="float: left; padding-top: 4px">Are you sure to change this</span> <span
                    style="float: left;">
                    <asp:RadioButtonList ID="rBtnCnfrm" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </span>
            </p>
        </div>
    </div>
    <div class="buttonrow_bottom_capp" id="changeAppointmentbtnContainer">
        <span class="buttoncon_default" style="display: none; text-align: center;" id="spnIndicator">
            <img src="/App/Images/indicator.gif" alt="Saving record..." />
        </span>
        <span class="buttoncon_default" id="spnSave">
            <asp:ImageButton runat="server" ImageUrl="~/App/Images/save-button.gif" ID="ibtnSave" OnClientClick="return CheckAppointment();" CssClass="" OnClick="ibtnSave_Click" Visible="True" />
        </span>
        <span class="buttoncon_default">
            <asp:ImageButton ImageUrl="~/App/Images/cancel-btn.gif" ID="ibtnCancel" runat="server" CssClass="" OnClick="ibtnCancel_Click" />
        </span>
    </div>
</div>
<asp:LinkButton runat="server" ID="lnk_temp"></asp:LinkButton>
<asp:Panel ID="pnlInvitation" runat="server" Style="display: none;">
    <div class="wrapper_pop">
        <div class="wrapperin_pop">
            <div class="innermain_pop">
                <p class="innermain_pop">
                    <span class="orngbold16_default" id="Span4" style="float: left">Invitation Code Verification</span>
                    <span style="float: right">
                        <asp:ImageButton OnClientClick="return HideInvitationPopup();" ID="ibtnClose" runat="server"
                            ImageUrl="~/App/Images/close-button-symbol.gif" />
                    </span>
                </p>
                <p class="innermain_1_pop" style="border-top: solid 1px #ccc;">
                    <span class="titletext1b_default">
                        <img src="/App/Images/specer.gif" width="1px" height="1px" /></span>
                </p>
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="inputfield110px_anp">Invitation Code:
                                <asp:TextBox ID="txtInvitationCode" runat="server" CssClass="inputf_def" Width="200px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="innermain_pop">
                        <span class="buttoncon_default">
                            <asp:ImageButton runat="server" OnClick="ibtnVerifyInvitation_Click" CausesValidation="true"
                                ID="ibtnVerifyInvitation" ImageUrl="~/App/Images/submit-button.gif" OnClientClick="return ValidateInvitation();" />
                        </span><span class="buttoncon_default">
                            <asp:ImageButton runat="server" ID="ibnCancelInvitation" ImageUrl="~/App/Images/cancel-button.gif"
                                OnClientClick="return HideInvitationPopup();" />
                        </span>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnk_temp"
    PopupControlID="pnlInvitation" BackgroundCssClass="modalBackground" CancelControlID="lnk_temp"
    BehaviorID="mdlPopup1" />
<div style="display: none">
    <div id="ShowDiffrenceInPackagesContainer">
        <div style="clear: both; float: left;">
            <asp:Panel ID="missingTestPanel" runat="server" Visible="False">
                <div style="clear: both; float: left"><b>Following addtional test(s) are available in the package on the new event selected. Please click OK to continue. </b></div>
                <div style="clear: both; float: left;">
                    <span class="ttxtnowidthnormal_default" runat="server" id="TestMissingInPackage">XXX</span>
                </div>
            </asp:Panel>
        </div>
        <div style="clear: both; float: left; padding-top: 10px;">
            <asp:Panel ID="newTestPanel" runat="server" Visible="False">
                <div style="clear: both; float: left">
                    <b>Following Test(s) are not available in the package on the new event selected. Please click OK to continue.</b>
                </div>
                <div style="clear: both; float: left;">
                    <span class="ttxtnowidthnormal_default" runat="server" id="newTestInPackage">XXX</span>
                </div>
            </asp:Panel>
        </div>
        <div style="clear: both; float: left; padding-top: 10px;">
            <asp:Panel ID="differenceOfTests" runat="server" Visible="False">
                <div style="clear: both; float: left">There is a difference of tests available in the package availed by you on the new event.</div>
                <div style="clear: both; float: left;">
                    <b>Tests not available:</b>
                    <br />
                    <span class="ttxtnowidthnormal_default" runat="server" id="testNotAvilable">XXX</span>
                </div>
                <div style="clear: both; float: left;">
                    <b>New Tests added:</b>
                    <br />
                    <span class="ttxtnowidthnormal_default" runat="server" id="newTestAdded">XXX</span>
                </div>
            </asp:Panel>
        </div>
    </div>

</div>
<script type="text/javascript" language="javascript">

    function setFocustoApptblock() {
        window.location.hash = "#setposition";
    }

    $(document).ready(function () {

        $('.auto-search-states').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetStateByPrefixText")%>',
            type: "POST",
            data: "prefixText"
        });

        $(".date-picker").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-10:+50"
        });

        $('.auto-search-city').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyNameAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: $('.auto-search-states').val()
        });

        $('.auto-search-states').change(function () {
            $('.auto-search-city').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyNameAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('.auto-search-states').val()
            });
        });

        $('.auto-search').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByPrefixText")%>',
            type: "POST",
            data: "prefixText"
        });

        $(".info-tip").qtip({
            content: {
                text: function (api) {
                    return $(this).parent().find('.prop-tip-info').html();
                }
            },
            position: {
                viewport: $(window),
                adjust: {
                    method: 'shift'
                }
            },
            style: {
                width: '540px'
            }
        });
        $('#' + '<%=RescheduleReasonDropdownList.ClientID %>').val("0");
        $("#<%= RescheduleReasonDropdownList.ClientID%>").bind("change", function () { bindSubReasonDropdown($("#<%= RescheduleReasonDropdownList.ClientID%>").val()); });
        bindSubReasonDropdown();
    });

</script>
<div style="display: none" id="pacageSelectionPopupContainer">
    <div id="packageSelectionPopup">
        <Order:ItemCart ID="ItemCartControl" runat="server" Visible="False" />
        <div class="buttonrow_bottom_capp">
            <span class="buttoncon_default" style="display: none; text-align: center;" id="spnIndicator">
                <img src="/App/Images/indicator.gif" alt="Saving record..." />
            </span>
            <%--<span class="buttoncon_default" id="spnClosePackageSelection">
                <asp:ImageButton runat="server" ImageUrl="~/App/Images/save-button.gif" ID="ImageButton1" OnClientClick="return closePackageSelectionPopup();" OnClick="closePackageSelectionPopup" />
            </span>--%>
        </div>
    </div>
    <div id="ShowPackageSelectionPopupConfirmation">
        Your Current Package/Test missing on this event. Do you want to Change your Package/Test?
    </div>
</div>
<div class="itemCartHiddenValues" style="display: none;">
    <asp:TextBox ID="hidNewEvent" runat="server" CssClass="hidNewEvent" />
    <asp:TextBox ID="hfNewEventID" runat="server" />
    <asp:TextBox ID="PackageIdHiddenControl" runat="server" CssClass="PackageIdHiddenControl" />
    <asp:TextBox ID="TestIdsHiddenControl" runat="server" CssClass="TestIdsHiddenControl" />
    <asp:TextBox ID="IndependentTestIdsHiddenControl" runat="server" CssClass="IndependentTestIdsHiddenControl" />
    <asp:TextBox ID="CurrentOrderPriceHiddenControl" runat="server" CssClass="CurrentOrderPriceHiddenControl" />
    <asp:TextBox ID="OrderChangedHiddenControl" runat="server" CssClass="OrderChangedHiddenControl" />

    <asp:TextBox ID="hfQuestionAnsTestId" runat="server" CssClass="QuestionAnsTestId" />
    <asp:TextBox ID="hfDisqualifedTest" runat="server" CssClass="DisqualifedTest" />
</div>
<asp:HiddenField runat="server" ID="hfTemplateIds" />
<asp:HiddenField runat="server" ID="hfQuestionIdAnswerTestId" />
<asp:HiddenField runat="server" ID="hfAllowNonMammoPatients" />
<asp:HiddenField runat="server" ID="hfIsSearchNonMammoEvent" />
<asp:HiddenField runat="server" ID="hfDisqualifedTestIds" />
<asp:HiddenField runat="server" ID="hfPreviousEventId" Value="0" />

<div class="saveWaitAnimationnew" style="display: none">
</div>
<div id="div_preQualificationQuestion" title="Pre Qualification Test Questions" style="display: none; background: #fff; padding: 10px">
</div>
<script type="text/javascript">
    var subReasons;
    $(function () {
        if ("<%=ShowPackagePopup %>" === "True") {
            $("#PaymentContainrerDiv").hide();
            $("#changeAppointmentbtnContainer").show();

            $("#ShowPackageSelectionPopupConfirmation").dialog({
                modal: true,
                autoOpen: true,
                resizable: false,
                title: "Package Selection Confirmation",
                height: 200,
                buttons: {
                    Cancel: function () {
                        $(this).dialog("close");
                    },
                    "OK": function () {
                        $("#packageSelectionPopup").dialog("open");
                        $(this).dialog("close");
                    }
                }
            });
        }


        $("#packageSelectionPopup").dialog({
            modal: true,
            autoOpen: false,
            title: "Select your Package/Test",
            maxHeight: 730,
            width: 730,
            buttons: {
                Cancel: function () {
                    $(this).dialog("close");
                },
                "Save": function () {
                    if (closePackageSelectionPopup()) {
                        $(this).dialog("close");
                    }
                }
            }
        });

        subReasons = <%= GetSubReason() %>;
    });



    function ShowDiffrenceInPackagesPopup() {
        $("#ShowDiffrenceInPackagesContainer").dialog({
            modal: true,
            width: 500,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            },
            autoOpen: true
        });
    }

    function SelectPackage() {
        $('#<%= PackageIdHiddenControl.ClientID %>').val($('#PackageIdHiddenControl').val());
        $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val($('#IndependentTestIdsHiddenControl').val());
        $('#<%=TestIdsHiddenControl.ClientID %>').val($('#TestIdsHiddenControl').val());
        $('#<%= CurrentOrderPriceHiddenControl.ClientID %>').val($('#OfferPriceSpan').text());
        $('#spNewPackage').text($('#PackageDescriptionHidden').val());
        $('#<%= OrderChangedHiddenControl.ClientID %>').val($('#OrderChangedHiddenControl').val());
    }

    function closePackageSelectionPopup() {

        if (!ValidationMessage()) {
            return false;
        }

        __doPostBack('ChangePackage_Click', '');

        return true;
    }

    function ValidationMessage() {
        var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
        var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

        if (packageId == '0' && testIds == '0') {
            if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
                alert("Please select a Package or tests.");
            else
                alert("Please select a Package.");
            return false;
        }

        return true;
    }

    function showHideProcessPaymentbtn(show) {
        if (show) {
            SetPackageAtChangeAppointmentPayment();
            ShowChangeOrderStatus();
            $("#PaymentContainrerDiv").show();
            $("#changeAppointmentbtnContainer").hide();
        } else {
            $("#PaymentContainrerDiv").hide();
            $("#changeAppointmentbtnContainer").show();
        }
    }

    var scriptPopup = null;
    
    function openScriptWindow() {
        var properties = "width=" + Number($(window).width() / 2) + ", height=" + Number($(window).height()) + ", resizable=1, scrollbars=1";

        scriptPopup = window.open(window.localStorage.scriptUrl, "Call Center Script", properties);
        window.localStorage.setItem("isScriptOpen", true);
        checkScriptPopupOpen();
    }

    function checkScriptPopupOpen() {
        if (scriptPopup && scriptPopup.closed) {
            window.localStorage.removeItem("isScriptOpen");
            window.localStorage.removeItem("scriptUrl");
        } else {
            window.setTimeout(checkScriptPopupOpen, 500);
        }
    }

    function bindSubReasonDropdown(lookupId) {
        
        $('#' + '<%=RescheduleSubReasonDropdownList.ClientID %>').html('');
        $('#' + '<%=ReasonNotesTextbox.ClientID %>').text('');

        if (lookupId > 0) {
            if (lookupId === '<%= (long)RescheduleAppointmentReason.PersonalReasons%>') {
                $("#RescheduleSubReasonContainerDiv").hide();
                $("#reschedule-reason-div").show();
                $('#' + '<%=RescheduleSubReasonDropdownList.ClientID %>').append($('<option></option>').val('0').html('--Select--'));
            }
            else {
                $('#' + '<%=RescheduleSubReasonDropdownList.ClientID %>').append($('<option></option>').val('0').html('--Select--'));
                if (subReasons.length > 0) {
                    for (i = 0; i < subReasons.length; i++) {
                        if (subReasons[i].LookupId == $('#' + '<%=RescheduleReasonDropdownList.ClientID %>').val())
                            $('#' + '<%=RescheduleSubReasonDropdownList.ClientID %>').append($('<option></option>').val(subReasons[i].Id).html(subReasons[i].DisplayName));
                    }
                }
                
                $("#reschedule-reason-div").hide();

                if ($('#' + '<%=RescheduleSubReasonDropdownList.ClientID %> option').length > 1)
                    $("#RescheduleSubReasonContainerDiv").show();
                else
                    $("#RescheduleSubReasonContainerDiv").hide();
            }
        }
        else {
            $("#RescheduleSubReasonContainerDiv").hide();
            $("#reschedule-reason-div").hide();
        }
    }
    
    function CheckhasMammoEvent(ctrl) {
        var customerHasMammo = "<%= CustomerHasMammoTest %>";
        var hasmammo = $(ctrl).closest("tr").find(".hasBreastCancer").val();

        var isAllowNonMammoPatients = $(ctrl).closest("tr").find(".isAllowNonMammoPatients").val();
        $('#<%=hfAllowNonMammoPatients.ClientID%>').val(isAllowNonMammoPatients);

        if (customerHasMammo === "True" && hasmammo == "False") {
            if (confirm("Warning: You are scheduling a Mammo Customer on Non-Mammo Event. Do you want to proceed?")) {
                return true;
            } else {
                return false;
            }
        }

        return true;
    }
</script>
<script src="/Content/JavaScript/PreQualifiedQuestionRules.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>
<script type="text/javascript">

    var prefilledQuestions = '';
    var disQualifiedQuestionandAnswer = '';
    var questionAnsTestId = "";
    function IsPrequalificationQuestions(isSelectPackageRadioClick) {

        var templateIds = new Array();

        var pkgTestIds = '';

        var testIds = $("#IndependentTestIdsHiddenControl").val();
        $('*[id*=PackageTestIdHidden]').each(function () {

            if (pkgTestIds != "" && $(this).val() != 'undefined') {
                pkgTestIds += "," + $(this).val()
            }
            else if ($(this).val() != 'undefined') {
                pkgTestIds = $(this).val()
            }
        });

        if (testIds != "" && pkgTestIds != "") {
            testIds += "," + pkgTestIds
        }
        testIds = testIds.replace(',undefined', '');

        $(_prequalificationTemplateIdandTestId).each(function (index, item) {
            if (testIds.indexOf(item[1]) >= 0) {
                templateIds.push(item[0]);
            }
        });
       
        if ((templateIds.length > 0 && prefilledQuestions == "") || (templateIds.length > 0 && isSelectPackageRadioClick)) {
               
            GetPreQualificationQuestion(templateIds);
        }
    }

    function GetPreQualificationQuestionsforSingleTest(testId) {
        var templateIds = new Array();
      
        $(_prequalificationTemplateIdandTestId).each(function (index, item) {
            if (testId == item[1]) {
                templateIds.push(item[0]);
            }
        });


        if (templateIds.length > 0) {
            GetPreQualificationQuestion(templateIds);
        }
    }

    function GetPreQualificationQuestion(templateIds) {
        
        if ($('#<%= hfIsSearchNonMammoEvent.ClientID %>').val() == 'Yes') {
            __doPostBack('continueWithWarning', '');
            return;
        }

        $(".saveWaitAnimationnew").show();
        $.ajax({
            url: '/CallCenter/CallQueue/GetPreQualificationQuestion',
            type: 'POST',
            cache: false,
            data: JSON.stringify({ templateIds: templateIds }),
            traditional: true,
            contentType: "application/json; charset=utf-8",
            dataType: "html",
        }).done(function (result) {
            $('#div_preQualificationQuestion').html(result);
            
            $.ajax({
                url: '/CallCenter/CallQueue/GetEventCustomerQuestionAnswer',
                type: 'GET',
                cache: false,
                data: { customerId: '<%= CustomerId %>' }
            }).done(function (data) {
                AnswerFilled(data);
            });
        
            $('#div_preQualificationQuestion').dialog('open');
            $(".saveWaitAnimationnew").hide();
        });
    }
    
    var resultObject;
    var disqualifiedTest = '';
    var isMammoQualified = false;

    $(document).ready(function () {
        $('#div_preQualificationQuestion').dialog({
            autoOpen: false, modal: true, width: 550, height: 260, closeOnEscape: false, open: function (event, ui) {
                $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
            }, buttons: {
                'Save':  function () {
                       
                    resultObject = CommonFunctionOfDisqualified();
                        
                    if (resultObject.isComplete == false) {
                        alert("You have to attempt all Questions.");
                        return;
                    }
                        
                    if (resultObject.isComplete) {
                        SaveDisqualifedTest();
                        prefilledQuestions = $('#<%= hfQuestionAnsTestId.ClientID %>').val();
                    }
                }
            }
        });

    });

    function SaveDisqualifedTest()
    {
        $('#<%= hfQuestionAnsTestId.ClientID %>').val(resultObject.answerStr);

        var disqualifedTest = CheckIsEligibleForTest(resultObject.answerStr, $('#<%=hfAllowNonMammoPatients.ClientID%>').val());
        $('#<%= hfDisqualifedTest.ClientID %>').val(disqualifedTest);

        $('#<%= hfIsSearchNonMammoEvent.ClientID %>').val('');

        var testId;
        if (disqualifedTest != null && disqualifedTest != '') {
            $(disqualifedTest.split('|')).each(function (index, item) {
                testId = item.split(',')[0];
            });
        }
        var hidNewEventId = document.getElementById("<%=hfNewEventID.ClientID %>");
        var model = {
            CustomerId: '<%= CustomerId %>',
            EventId: hidNewEventId.value,
            QuestionAnswerTestIds: resultObject.answerStr,
            DisqualifiedTests: disqualifedTest
        };
        if (disqualifedTest == "")
            isMammoQualified = true;
        else
            isMammoQualified = false;
        $.ajax({
            url: '/CallCenter/CallQueue/SavePreQualificationAnswers',
            type: 'POST',
            cache: false,
            data: JSON.stringify(model),
            traditional: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }).done(function () {
            questionAnsTestId = '';
            $('#div_preQualificationQuestion').dialog('close');
                           
            if ('<%= ShowPackagePopup %>' == '<%= Boolean.TrueString %>') {

                $.ajax({
                    url: "/CallCenter/CallQueue/GetDependentTestsToRemove?eventId=" + hidNewEventId.value + "&testId=" + testId,
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    success: function(result) {
                        if (result != null && result != '') {
                            RemoveSingleTest(testId, result);
                            questionAnsTestId = '';
                            $('#div_preQualificationQuestion').dialog('close');

                            if (disqualifedTest != '') {
                                alert("You are not eligible for " + $(".testName").html() + ".");
                            }
                        }
                    
                    }});
                
            } else {
                                
                if (isRedirectNonMammo == 'Yes') {
                                    
                    $('#<%= hfIsSearchNonMammoEvent.ClientID %>').val(isRedirectNonMammo);
                    $('#<%= hfPreviousEventId.ClientID%>').val(hidNewEventId.value);
                    __doPostBack('redirectNonMammoEvent', '');
                }
                else if (isRedirectNonMammo == 'Continue') {
                    alert("You are not eligible for " + $(".testName").html() + ".");
                    __doPostBack('continueWithWarning', '');
                }
                else {
                    if (disqualifedTest != '') {
                        alert("You are not eligible for " + $(".testName").html() + ".");
                        $('#<%= hfIsSearchNonMammoEvent.ClientID %>').val('Yes');
                        $('#<%= hfPreviousEventId.ClientID%>').val(hidNewEventId.value);
                        __doPostBack('redirectNonMammoEvent', '');
                    }
                    else {
                        __doPostBack('continueWithWarning', '');
                    }
                } 
        }
                            
        });
}

function ResetAnswerIfQuestionRemoved(removedTestId) {
    if (prefilledQuestions != "" && prefilledQuestions.indexOf(removedTestId) > 0) {
        prefilledQuestions = "";
        disQualifiedQuestionandAnswer = "";
        $('#<%= hfDisqualifedTest.ClientID %>').val("");
                        $('#<%= hfQuestionAnsTestId.ClientID %>').val("");
                    }
                }

                function GetEventCustomerQuestionAnswer() {
      
                    var questionAns='';
                    var hidNewEventId = document.getElementById("<%=hfNewEventID.ClientID %>");
    $.ajax({
        url: '/CallCenter/CallQueue/GetEventCustomerQuestionAnswer',
        type: 'GET',
        async: false,
        data: { customerId: '<%= CustomerId %>' },
                        success: function (data) {
                  
                            if(data!='error')
                            {
                                $(data).each(function (index, item) {
                                    if (questionAns != "")
                                        questionAns += '|' + item.QuestionId + "," + item.Answer + "," + item.TestId;
                                    else
                                        questionAns += item.QuestionId + "," + item.Answer + "," + item.TestId;
                                });
                            }
                        }
                    });
            
                    prefilledQuestions=questionAns;
                }

</script>


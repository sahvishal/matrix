<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer.RegCustomerSearchEvent"
    CodeBehind="RegCustomerSearchEvent.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<%@ Register Src="~/App/UCCommon/PreQualificationQuestion.ascx" TagName="PreQualificationQuestion" TagPrefix="PreQualification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" IncludeAjax="true" IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" />
    <script type="text/javascript" src="../../../JavascriptFiles/HttpRequest.js"></script>
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
        function Validate() {

            //debugger
            var state = document.getElementById("<%= this.txtState.ClientID %>").value;
            var city = document.getElementById("<%= this.txtCity.ClientID %>").value;
            var zip = document.getElementById("<%= this.txtZip.ClientID %>").value;
            var txtFrom = document.getElementById("<%= this.txtFrom.ClientID %>").value;
            var txtTo = document.getElementById("<%= this.txtTo.ClientID %>").value;
            var txtInvitationCodeSearch = document.getElementById("<%= this.txtInvitationCodeSearch.ClientID %>").value;

            if (state == "" && city == "" && zip == "" && txtInvitationCodeSearch == "") {
                alert("Please input at least one field (state/city/zip/invitationcode) to search.");
                return false;
            }

            if (isNaN(zip)) {
                alert("Please provide a valid zip code to find screening location near you. The zip code has to be 5 digits.");
                return false;
            }

            if (txtFrom == "" && txtTo == "") {
                ///No date range provided
                return true;
            }
            else {
                if (ValidateDate(txtFrom, 'Date Range') == false) {
                    return false;
                }
                if (ValidateDate(txtTo, 'Date Range') == false) {
                    return false;
                }
            }
            if (txtFrom != txtTo) {
                if (CompareDateWithCurrentDate1(txtFrom) && CompareDateWithCurrentDate1(txtTo)) {
                    alert("You are searching for past events. Please search for future events.");
                    return false;
                }
            }

            return true;
        }
        function Reset() {
            //debugger
            document.getElementById("<%= this.txtState.ClientID %>").value = "";
            document.getElementById("<%= this.txtCity.ClientID %>").value = "";
            document.getElementById("<%= this.txtZip.ClientID %>").value = "";
            document.getElementById("<%= this.txtFrom.ClientID %>").value = "";
            document.getElementById("<%= this.txtTo.ClientID %>").value = "";
            document.getElementById("<%= this.txtInvitationCodeSearch.ClientID %>").value = "";
            return false;
        }
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        function requestFailed()
        { }
        function CallEnd() {
            postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
        }


        function onblur_CleanUpCity() {
            document.getElementById('<%= this.txtCity.ClientID %>').value = "";
        }

        function onblur_CleanUpZip() {
            document.getElementById('<%= this.txtZip.ClientID %>').value = "";
        }

        function showTagChangeWarning(customerTag, eventTag, showEligiblityPopup, isSameYear, isTagChangeAllowed) {

            var warningMessag = "WARNING: You are scheduling a " + customerTag + " member for a ";
            if (customerTag == null || customerTag == "") {
                warningMessag = "WARNING: You are scheduling a retail customer for a ";
            }
            var eligibilityWarningMessage = 'You are attempting to schedule a participant who is NOT eligible for testing.  Do you want to proceed?';
            var sameYearWarningMessage = "Customer is already screened for an event this Year. Do you wish to register him for another event in same Year?";
            if (showEligiblityPopup == 'True') {
                if (confirm(eligibilityWarningMessage)) {

                    if (isSameYear == 'True') {
                        if (confirm(sameYearWarningMessage)) {
                            if (eventTag == '') {
                                warningMessag = warningMessag + "retail event.  This is NOT ALLOWED.  Do you want to proceed?";
                            } else {
                                if (isTagChangeAllowed) {
                                    warningMessag = warningMessag + eventTag + " event.  This is NOT ALLOWED.  Do you want to proceed?";
                                } else {
                                    alert("You are scheduling a " + customerTag + " member for a " + eventTag + " event.  This is NOT ALLOWED.");
                                    return;
                                }
                            }
                            if (confirm(warningMessag)) {
                                var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                                if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                                    getPreQualificationQuestion(preQualificationTemplateIdString);
                                } else {
                                    __doPostBack('continueWithSelectedEvent', '');
                                }
                            }
                        }
                    } else {
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
                            var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                            if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                                getPreQualificationQuestion(preQualificationTemplateIdString);
                            } else {
                                __doPostBack('continueWithSelectedEvent', '');
                            }
                        }
                    }

                }
            } else {

                if (isSameYear == 'True') {
                    if (confirm(sameYearWarningMessage)) {
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
                            var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                            if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                                getPreQualificationQuestion(preQualificationTemplateIdString);
                            } else {
                                __doPostBack('continueWithSelectedEvent', '');
                            }
                        }
                    }
                } else {
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
                        var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                        if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                            getPreQualificationQuestion(preQualificationTemplateIdString);
                        } else {
                            __doPostBack('continueWithSelectedEvent', '');
                        }
                    }
                }
            }
        }

        function showCustomerNotEligibleWarning(isSameYear) {
            var warningMessage = 'You are attempting to schedule a participant who is NOT eligible for testing.  Do you want to proceed?';
            var sameYearWarningMessage = "Customer is already screened for an event this Year. Do you wish to register him for another event in same Year?";

            if (confirm(warningMessage)) {
                if (isSameYear == 'True') {
                    if (confirm(sameYearWarningMessage)) {
                        var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                        if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                            getPreQualificationQuestion(preQualificationTemplateIdString);
                        } else {
                            __doPostBack('continueWithSelectedEvent', '');
                        }
                    }

                } else {
                    var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                    if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                        getPreQualificationQuestion(preQualificationTemplateIdString);
                    } else {
                        __doPostBack('continueWithSelectedEvent', '');
                    }
                }

            }
        }

        function showSameYearReturningCustomerWarning() {
            var sameYearWarningMessage = "Customer is already screened for an event this Year. Do you wish to register him for another event in same Year?";

            if (confirm(sameYearWarningMessage)) {

                var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                    getPreQualificationQuestion(preQualificationTemplateIdString);
                } else {
                    __doPostBack('continueWithSelectedEvent', '');
                }

            }
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
        function SelectEvent(eventid, eventtype) {
            //alert(eventid);alert(eventtype);
            var hidEventID = document.getElementById("<%= this.hidEventID.ClientID %>");
            var txtInvitationCode = document.getElementById("<%= this.txtInvitationCode.ClientID %>");
            txtInvitationCode.value = '';
            hidEventID.value = eventid;
            $find('mdlPopup1').show();

            return false;
        }
    </script>
    <link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../jquery/css/JQuery-Selectable/Selectable.css" rel="stylesheet"
        type="text/css" />
    <script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>
    <div class="wrapper_inpg">
        <h1 id="dvTitle" runat="server" style="visibility: hidden">Call Centre Rep Dashboard</h1>
        <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" style="display: none;"
            runat="server">
        </div>

        <div class="contnr_bdr">
            <div class="pgnosymbol_regcust">
                <img src="/App/Images/CCRep/page1symbol.gif" alt="" />
            </div>

            <asp:Panel DefaultButton="imgSearch" runat="server" ID="pnlSearch">
                <div class="middivrow_regcust">
                    <p class="contentrow_regcust">
                        <span class="orngheadtxt_regcust" runat="server" id="StepTitleContainer">Existing Customer</span>
                    </p>
                    <div class="fline_regcust">
                    </div>
                    <p class="contentrow_regcust">
                        <span class="orngsmalltxt_regcust">Search Event</span>
                    </p>
                    <p class="normaltxt_regcust" id="spEventScript" runat="server">
                    </p>
                    <div class="fline_regcust">
                    </div>
                    <p class="middivrow_regcust">
                        <span class="titletxt_regcust">State:</span> <span class="inputconleft_regcust">
                            <asp:TextBox ID="txtState" runat="server" CssClass="inputfield_ccrep auto-search-states"
                                Width="135px"></asp:TextBox></span> <span class="titletxt_regcust">City:</span>
                        <span class="inputconright_regcust">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="inputfield_ccrep auto-search-city"
                                onchange="onblur_CleanUpZip();" Width="140px"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust">
                        <span class="titletxt_regcust">Zip:</span> <span class="inputconleft_regcust">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" onchange="onblur_CleanUpCity();"
                                Width="135px"></asp:TextBox></span> <span class="titletxt_regcust">Date:</span>
                        <span class="inputcondtsmall_regcust">
                            <asp:TextBox ID="txtFrom" runat="server" CssClass="inputfield_ccrep date-picker"
                                Width="70px"></asp:TextBox></span> <span class="inputcondtsmall_regcust">
                                    <asp:TextBox ID="txtTo" runat="server" CssClass="inputfield_ccrep date-picker" Width="70px"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust">
                        <span class="titletxt_regcust">Zip Radius:</span> <span class="inputconleft_regcust">
                            <asp:DropDownList runat="server" ID="ZipRadius">
                            </asp:DropDownList>
                        </span><span class="titletxt_regcust">Invitation Code:</span> <span class="inputconleft_regcust">
                            <asp:TextBox ID="txtInvitationCodeSearch" runat="server" CssClass="inputfield_ccrep"
                                Width="140px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="middivrow_regcust" runat="server" id="pTypeFilter">
                        <span class="titletxt_regcust">Type:</span> <span class="inputfldnowidth_cl">
                            <asp:DropDownList runat="server" ID="EventSearchTypeDropdownList" />
                        </span>
                    </p>
                    <div class="fline_regcust">
                    </div>
                    <p class="buttoncell_ccrep" style="width: 250px;">
                        <span class="buttoncon_ccrep">
                            <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/App/Images/clear-btn.gif"
                                OnClientClick="return Reset()" />
                        </span><span class="buttoncon_ccrep">
                            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                OnClick="imgSearch_Click" OnClientClick="return Validate();" />
                        </span>
                        <span class="buttoncon_ccrep" style="width: 110px; padding-top: 5px" id="CallBackProspectSpan" runat="server"><b>|&nbsp</b><asp:LinkButton
                            class="callbackprospect" runat="server" ID="EventRequestLBtn" OnClick="EventRequestLBtn_Click"><b>Callback Prospect</b></asp:LinkButton>
                        </span>
                    </p>
                </div>
            </asp:Panel>
            <div class="rightdivrow_regcust" id="divCall" runat="server">
                <div class="timeboard_ccrep_dboard">
                    <div class="timeboxbg_ccrep_dboard">
                        <p class="tboxrow_ccrep_dboard">
                            <span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span
                                id="SS"></span></span>
                        </p>
                        <p class="tboxrowformat_ccrep_dboard">
                            <span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
                        </p>
                        <p class="tboxrowbtm_ccrep_dboard">
                            <span class="whttxt_ccrep_dboard">Call in Progress</span>
                        </p>
                    </div>
                </div>
                <div class="endcall_ccrep_dboard" style="margin-top: 5px">
                    <span class="endtbtn_ccrep_dboard">
                        <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                            OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                    </span>
                </div>
            </div>
            <div class="regcust_innerrow">
                <p class="maincontentrow_re" style="margin-top: 10px">
                    <span class="blkheadtxt_regcust" id="dvSearchResult1" runat="server"></span><span
                        class="blueheadtxt_regcust" id="dvSearchResult" runat="server"></span><span class="rgt">
                            <span style="padding-right: 05px;">
                                <img src="/App/Images/public-icon.gif" title="Public Event" />
                                Public Event &nbsp;
                                <img src="/App/Images/private-icon.gif" title="Private Event" />Private Event</span>
                        </span>
                </p>
                <div class="dgeventhistory_ccrep" id="dbsearch" runat="server" style="display: none"
                    visible="false">
                    <div class="dgheadeventhistory1_ccrep">
                        <img src="../../../Images/CCRep/specer.gif" width="20px" height="3px" />
                    </div>
                    <asp:GridView ID="dgEvent" runat="server" CssClass="grideventhistorynew" AutoGenerateColumns="false"
                        GridLines="None" AllowPaging="true" PageSize="10" AllowSorting="true" EnableSortingAndPagingCallbacks="False"
                        OnSorting="dgEvent_Sorting" OnPageIndexChanging="dgEvent_PageIndexChanging" OnRowDataBound="dgEvent_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Event ID"></asp:BoundField>
                            <%--<asp:BoundField DataField="Name" HeaderText="Event Name" SortExpression="Name"></asp:BoundField>--%>
                            <asp:TemplateField SortExpression="Name">
                                <HeaderStyle Width="150" />
                                <ItemStyle Width="150" />
                                <HeaderTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEventName" Text="Event Name" OnClick="lnkEventName_Click">Event Name</asp:LinkButton>
                                </HeaderTemplate>
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
                                    <span id="_spnEventStatus"><b>Sponsored By:</b>
                                        <%# DataBinder.Eval(Container.DataItem, "SponseredBy")%></span>
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
                            <asp:BoundField DataField="Date" HeaderText="Event Date" SortExpression="Date" DataFormatString="{0:dddd dd MMMM yyyy}"
                                HtmlEncode="False"></asp:BoundField>
                            <asp:BoundField DataField="Pods" HeaderText="Pod"></asp:BoundField>
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
                                    <a id='Id_<%# DataBinder.Eval(Container.DataItem, "ID")%>' href="javascript:void(0)">
                                        <%# DataBinder.Eval(Container.DataItem, "Slots")%>
                                    </a>
                                    <br />
                                    <a style='display: <%# Convert.ToBoolean(Eval("IsDynamicScheduling"))?"block":"none" %>' href="javascript:window.open('/Scheduling/AppointmentSlot/ViewAll?eventId=<%# DataBinder.Eval(Container.DataItem, "ID")%>', 'View_Appointment', 'toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=550,height=500'); void(0);">View All</a>
                                    <div id="QtipTitleDiv" style="display: none;">
                                        <div style="float: left">
                                            Slots
                                        </div>
                                        <div class="slotlegends" style='display: <%# Convert.ToBoolean(Eval("IsDynamicScheduling"))?"none":"block" %>'>
                                            <span class="Free legendblocks"></span><span>&nbsp;Free</span> <span class="TemporarilyBooked legendblocks"></span><span>&nbsp;In-Progress</span> <span class="Booked legendblocks"></span><span>&nbsp;Booked</span> <span class="exhausted legendblocks"></span><span>&nbsp;Exhausted</span>
                                        </div>
                                    </div>
                                    <div class="appointment-slots dgselecttime_pw" style="display: none;">
                                        <div id="selectable" style="width: 335px; min-height: 120px;">
                                            <span style="width: 200px; margin-bottom: auto; margin-top: auto;">
                                                <img src="~/App/Images/loading.gif" alt="Loading" />
                                                Loading </span>
                                        </div>
                                    </div>
                                    <script language="javascript" type="text/javascript">
                                        $(document).ready(function () {
                                            var eventId = '<%# DataBinder.Eval(Container.DataItem, "ID")%>';
                                            loadSlots(eventId);

                                            $("#Id_" + eventId).qtip({
                                                position: {
                                                    viewport: $(window),
                                                    adjust: {
                                                        method: 'shift'
                                                    }
                                                },
                                                content: {
                                                    title: function (api) { return $(this).parent().find("#QtipTitleDiv").html(); },
                                                    text: function (api) {
                                                        return $(this).parent().find(".appointment-slots").html();
                                                    }
                                                }
                                            });
                                        });
                                    </script>
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
                                        <span id="spSlots" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "IsSlotsAvailable")%>'>
                                            <asp:LinkButton ID="lnkSelectEvent" runat="server" CommandName="SelectEvent" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                Text="Select" OnClick="lnkSelectEvent_Click" OnClientClick="return CheckhasMammoEvent(this)" />
                                        </span>
                                        <span id="spNoSlots" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "IsNoSlotsAvailable")%>'>
                                            <img src="/App/Images/no-slots-available-icongif.gif" alt="" />
                                        </span>
                                        <span id="spTempUnavailable" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "TempUnavailable")%>'>
                                            <img src="/App/Images/temp-unavailable-icon.gif" alt="" class="jtip" title='Suspended|<%# DataBinder.Eval(Container.DataItem, "EventNotes")%>' />
                                        </span>
                                        <span id="spCancelled" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "Cancelled")%>'>
                                            <img src="/App/Images/canceled-icon.gif" alt="" class="jtip" title='Canceled|<%# DataBinder.Eval(Container.DataItem, "EventNotes")%>' />
                                        </span>
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
                <div style="float: left; display: none;" id="divNoRecord" runat="server" visible="false">
                    <div id="" style="float: left; width: 714px; display: block; padding: 10px 10px 10px 20px; border: solid 1px #DFEEF5;">
                        <div class="divnoitemfound1_custdbrd">
                            <p class="divnoitemtxt_custdbrd">
                                <span class="orngbold18_default">No Record Found </span>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

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

        function loadSlots(eventId) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "html", url: "/scheduling/appointmentslot/EventAppointmentSlotSummary?id=" + eventId, data: '{}',
                success: function (result) { setAppointmentData(eventId, result); }, error: function (a, b, c) { }
            });
        }

        function setAppointmentData(eventId, appointments) {

            $("#Id_" + eventId).parent().find(".appointment-slots").html(appointments);

        }

        $(document).ready(function () {


            $('.callbackprospect').qtip(
                {
                    content: 'If the called in customer could not find any event at her convenience. Please click here and record basic details (Name, Phone Number and email). Whenever any event is organized in that locality we can accomodate her                             appointment.'
                });

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
        });

    </script>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
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
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnktemp"
        PopupControlID="pnlInvitation" BackgroundCssClass="modalBackground" CancelControlID="lnktemp"
        BehaviorID="mdlPopup1" />
    <script type="text/javascript" language="javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>
    <PreQualification:PreQualificationQuestion ID="PreQualificationQuestion1" runat="server" />
    <asp:HiddenField runat="server" ID="hidEventID" />
    <asp:HiddenField runat="server" ID="hfCustomerID" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
            $('#divnotes').dialog({ width: 700, autoOpen: false, resizable: true, draggable: false, modal: true });

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
                    width: '500px'
                }
            });

            checkAndOpenScriptPopup();
        });
        function ShowDialog(EventId) {
            var eventId = EventId;
            var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/GetCcRepInstruction") %>';
            var parameter = "{'eventId':" + eventId + "}";
            InvokeService(messageUrl, parameter);

        }

        function InvokeService(messageUrl, parameter) {
            $('#divloading').show();
            $('#_txtCallCenterNotes').text('');
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function (result) {
                    $('#divnotes').dialog('open');
                    $('#_txtCallCenterNotes').val(result.d);
                    $('#divloading').hide();
                },
                error: function (a, b, c) {
                    alert('Oops some error accured ');
                }
            });
        }

    </script>
    <div style="float: left; width: 690px; display: none; overflow: hidden" id="divnotes"
        title="Instruction for Call Center Rep">
        <textarea id="_txtCallCenterNotes" rows="27" cols="120" readonly="readonly" class="inputf_def"></textarea>
    </div>
    <div style="display: none">
        <asp:Button runat="server" ID="redirectNonMammoEvent" />
        <asp:Button runat="server" ID="continueWithSelectedEvent" />

    </div>

    <asp:HiddenField runat="server" ID="hfTemplateIds" />
    <asp:HiddenField runat="server" ID="hfQuestionIdAnswerTestId" />
    <asp:HiddenField runat="server" ID="hfAllowNonMammoPatients" />
    <asp:HiddenField runat="server" ID="hfIsSearchNonMammoEvent" />
    <asp:HiddenField runat="server" ID="hfPreviousEventId" Value="0" />
    <asp:HiddenField runat="server" ID="hfDisqualifedTest" />

    <div class="saveWaitAnimationnew" style="display: none">
    </div>
    <div id="div_preQualificationQuestion" title="Pre Qualification Test Questions" style="display: none; background: #fff; padding: 10px">
    </div>


    <script src="/Content/JavaScript/PreQualifiedQuestionRules.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>
    <script type="text/javascript">
        var questionAnsTestId = "";

        function getPreQualificationQuestion(templateIds) {

            if ($('#<%= hfIsSearchNonMammoEvent.ClientID %>').val() == 'Yes') {
                __doPostBack('continueWithSelectedEvent', '');
                return;
            }

            var templateIdsArray = templateIds.split(',');
            $(".saveWaitAnimationnew").show();
            $.ajax({
                url: '/CallCenter/CallQueue/GetPreQualificationQuestion',
                type: 'POST',
                cache: false,
                data: { templateIds: templateIdsArray },
                traditional: true,
            }).done(function (result) {
                $('#div_preQualificationQuestion').html(result);
                var prefilledQuestions = $("#<%= hfQuestionIdAnswerTestId.ClientID %>").val();

                AnswerFilled(prefilledQuestions);

                $('#div_preQualificationQuestion').dialog('open');
                $(".saveWaitAnimationnew").hide();
            });
        }

        var resultObject;
        var disqualifiedTest = '';
        $(document).ready(function () {
            $('#div_preQualificationQuestion').dialog({
                autoOpen: false, modal: true, width: 550, height: 260, top: 600, closeOnEscape: false, open: function (event, ui) {
                    //$(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
                }, buttons: {
                    'Save': function () {

                        resultObject = CommonFunctionOfDisqualified();

                        if (resultObject.isComplete == false) {
                            alert("You have to attempt all Questions.");
                            return;
                        }

                        if (resultObject.isComplete) {

                            SaveDisqualifedTest();

                        }
                    }
                }
            });

        });
        function SaveDisqualifedTest() {
            $('#<%= hfQuestionIdAnswerTestId.ClientID %>').val(resultObject.answerStr);

            var disqualifedTest = CheckIsEligibleForTest(resultObject.answerStr, $('#<%=hfAllowNonMammoPatients.ClientID%>').val());


            $('#<%= hfDisqualifedTest.ClientID %>').val(disqualifedTest);
            $('#<%= hfIsSearchNonMammoEvent.ClientID %>').val('');


            var model = {
                CustomerId: '<%= hfCustomerID.Value %>',
                EventId: '<%= hidEventID.Value %>',
                QuestionAnswerTestIds: resultObject.answerStr,
                DisqualifiedTests: disqualifedTest
            };

            $.ajax({
                url: '/CallCenter/CallQueue/SavePreQualificationAnswers',
                type: 'POST',
                cache: false,
                data: JSON.stringify(model),
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
            }).done(function () {
                answerStr = '';
                $('#div_preQualificationQuestion').dialog('close');

                if (isRedirectNonMammo == 'Yes') {
                    alert("You are not eligible for " + $(".testName").html() + ".");
                    $('#<%= hfIsSearchNonMammoEvent.ClientID %>').val(isRedirectNonMammo);
                    $('#<%= hfPreviousEventId.ClientID%>').val('<%= hidEventID.Value %>');
                    __doPostBack('redirectNonMammoEvent', '');
                }
                else if (isRedirectNonMammo == 'Continue') {
                    alert("You are not eligible for " + $(".testName").html() + ".");
                    __doPostBack('continueWithSelectedEvent', '');
                }
                else {
                    if (disqualifedTest != '') {
                        alert("You are not eligible for " + $(".testName").html() + ".");
                        $('#<%= hfIsSearchNonMammoEvent.ClientID %>').val('Yes');
                                        $('#<%= hfPreviousEventId.ClientID%>').val('<%= hidEventID.Value %>');
                                        __doPostBack('redirectNonMammoEvent', '');
                                    }
                                    else {
                                        __doPostBack('continueWithSelectedEvent', '');
                                    }
                                }
            });
                    }

                    function ResetAnswerIfQuestionRemoved(removedTestId) {

                        if (prefilledQuestions != "" && prefilledQuestions.indexOf(removedTestId) > -1) {
                            prefilledQuestions = "";
                            disQualifiedQuestionandAnswer = "";
                <%--$('#<%= hfDisqualifedTest.ClientID %>').val("");--%>
            $('#<%= hfQuestionIdAnswerTestId.ClientID %>').val("");
        }
    }

    function RemoveSingleTest(testId) {

    }

    </script>
    <style type="text/css">
        .saveWaitAnimationnew {
            background-image: url('/Content/Images/loading_Big_orng.gif');
            background-repeat: no-repeat;
            position: fixed;
            top: 0px;
            right: 0px;
            width: 100%;
            height: 100%;
            background-color: #000;
            background-position: center;
            z-index: 10000000;
            opacity: 0.4;
            filter: alpha(opacity=40);
        }

        #jSuggestContainer ul {
            width: 250px;
            max-height: 300px;
            overflow-y: scroll;
            overflow-x: hidden;
        }
    </style>
</asp:Content>

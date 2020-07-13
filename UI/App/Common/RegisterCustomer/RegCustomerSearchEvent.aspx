<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    Inherits="Falcon.App.UI.App.Common.RegisterCustomer.RegCustomerSearchEvent" CodeBehind="RegCustomerSearchEvent.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<%@ Register Src="~/App/UCCommon/PreQualificationQuestion.ascx" TagName="PreQualificationQuestion" TagPrefix="PreQualification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" />
    <script type="text/javascript" src="../../JavascriptFiles/HttpRequest.js"></script>
    <link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
    <script src="/Content/JavaScript/PreQualificationQuestion.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>
    <script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>
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

        .custom-margin {
            margin-left: 85px;
        }

        .custom-margin-2 {
            margin-left: 105px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function Validate() {
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

            if (CompareDateWithCurrentDate1(txtFrom) && CompareDateWithCurrentDate1(txtTo)) {
                alert("You are searching for past events. Please search for future events.");
                return false;
            }
            return true;
        }
        function Reset() {
            document.getElementById("<%= this.txtState.ClientID %>").value = "";
            document.getElementById("<%= this.txtCity.ClientID %>").value = "";
            document.getElementById("<%= this.txtZip.ClientID %>").value = "";
            document.getElementById("<%= this.txtFrom.ClientID %>").value = "";
            document.getElementById("<%= this.txtTo.ClientID %>").value = "";
            document.getElementById("<%= this.txtInvitationCodeSearch.ClientID %>").value = "";

            return false;
        }
        function requestFailed()
        { }
        function CallEnd() {
            postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
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
        function showTagChangeWarning(customerTag, eventTag, showEligiblityPopup, isTagChangeAllowed) {
            var warningMessag = "WARNING: You are scheduling a " + customerTag + " member for a ";
            var eligibilityWarningMessage = 'You are attempting to schedule a participant who is NOT eligible for testing.  Do you want to proceed?';
            if (showEligiblityPopup == 'True') {
                if (confirm(eligibilityWarningMessage)) {
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
                            __doPostBack('continueWithWarning', '');
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
                        __doPostBack('continueWithWarning', '');
                    }
                }
            }
        }

        function showCustomerNotEligibleWarning() {
            var warningMessage = 'You are attempting to schedule a participant who is NOT eligible for testing.  Do you want to proceed?';
            if (confirm(warningMessage)) {
                var preQualificationTemplateIdString = $("#<%= hfTemplateIds.ClientID %>").val();
                if (preQualificationTemplateIdString != null && preQualificationTemplateIdString != '') {
                    getPreQualificationQuestion(preQualificationTemplateIdString);
                } else {
                    __doPostBack('continueWithWarning', '');
                }
            }
        }
    </script>
    <div class="mainbody_outer">
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" />
                    </p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Technician Register Customer
                    </span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" style="display: none;"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innerrow">
                        <div>
                            <img src="../../Images/CCRep/specer.gif" width="740px" height="5px" />
                        </div>
                        <div class="pgnosymbol_regcust">
                            <img src="../../Images/CCRep/page3symbol.gif" id="imgSymbol" runat="server" />
                        </div>
                        <asp:Panel DefaultButton="imgSearch" runat="server" ID="pnlSearch">
                            <div class="middivrow_regcust">
                                <p class="contentrow_regcust" style="visibility: hidden; display: none;">
                                    <span class="orngheadtxt_regcust">Register New Customer</span>
                                </p>
                                <p class="fline_regcust" style="visibility: hidden; display: none;">
                                    <img src="../../Images/CCRep/specer.gif" width="1" height="1" />
                                </p>
                                <p class="contentrow_regcust">
                                    <span class="orngbold16_default">Search Event</span>
                                </p>
                                <p class="normaltxt_regcust" id="spEventScript" runat="server">
                                </p>
                                <p class="fline_regcust">
                                    <img src="../../Images/CCRep/specer.gif" width="1" height="1" />
                                </p>
                                <p class="middivrow_regcust">
                                    <span class="titletxt_regcust">State:</span> <span class="inputconleft_regcust">
                                        <asp:TextBox ID="txtState" runat="server" CssClass="inputfield_ccrep auto-search-states"
                                            Width="135px"></asp:TextBox></span> <span class="titletxt_regcust" style="width: 70px;">City:</span> <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtCity" runat="server" CssClass="inputfield_ccrep auto-search-city"
                                                    Width="180px"></asp:TextBox></span>
                                </p>
                                <p class="middivrow_regcust">
                                    <span class="titletxt_regcust">Zip:</span> <span class="inputconleft_regcust">
                                        <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" onchange="onblur_CleanUpCity();"
                                            Width="135px"></asp:TextBox></span> <span class="titletxt_regcust" style="width: 70px;">Date:</span> <span style="float: left; width: 70px">
                                                <asp:TextBox ID="txtFrom" runat="server" CssClass="inputfield_ccrep date-picker"
                                                    Width="70px"></asp:TextBox></span> <span style="float: left; width: 70px">
                                                        <asp:TextBox ID="txtTo" runat="server" CssClass="inputfield_ccrep date-picker" Width="70px"></asp:TextBox></span>
                                </p>
                                <p class="middivrow_regcust">
                                    <span class="titletxt_regcust">Invitation Code:</span> <span class="inputconleft_regcust">
                                        <asp:TextBox ID="txtInvitationCodeSearch" runat="server" CssClass="inputfield_ccrep" Width="135px"></asp:TextBox>
                                    </span>
                                    <span class="titletxt_regcust" style="width: 70px;">Type:</span> <span class="inputconright_regcust">
                                        <asp:DropDownList runat="server" ID="EventSearchTypeDropdownList" CssClass="inputfield_ccrep" />
                                    </span>
                                </p>
                                <p class="fline_regcust">
                                    <img src="../../Images/CCRep/specer.gif" width="1" height="1" />
                                </p>
                                <p class="buttoncell_ccrep">
                                    <span class="buttoncon_ccrep">
                                        <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/App/Images/clear-btn.gif"
                                            OnClientClick="return Reset()" /></span> <span class="buttoncon_ccrep">
                                                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                                    OnClick="imgSearch_Click" OnClientClick="return Validate();" /></span>
                                </p>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="regcust_innerrow">
                        <p class="middivrow_regcust">
                            <img src="../../Images/CCRep/specer.gif" width="1" height="10" />
                        </p>
                        <p class="maincontentrow_re">
                            <span class="blkheadtxt_regcust" id="dvSearchResult1" runat="server"></span><span
                                class="blueheadtxt_regcust" id="dvSearchResult" runat="server"></span><span class="linkright_default">
                                    <span class="linkright_default">
                                        <img src="/App/Images/public-icon.gif" title="Public Event" alt="" />
                                    </span><span style="float: right">Public Event &nbsp;</span> <span class="linkright_default">
                                        <img src="/App/Images/private-icon.gif" title="Private Event" />
                                    </span><span style="float: right">Private Event &nbsp;</span> </span>
                        </p>
                        <div class="dgeventhistory_ccrep" id="dbsearch" runat="server" style="display: none"
                            visible="false">
                            <div style="float: left; width: 746px">
                                <p class="blueboxtopbg_cl">
                                    <img src="/App/Images/specer.gif" width="746" height="5" alt="" />
                                </p>
                                <div class="griddivnew_default">
                                    <asp:GridView ID="dgEvent" runat="server" AllowPaging="true" AllowSorting="true"
                                        AutoGenerateColumns="false" CssClass="divgrid_cl" EnableSortingAndPagingCallbacks="False"
                                        GridLines="None" OnPageIndexChanging="dgEvent_PageIndexChanging" OnRowDataBound="dgEvent_RowDataBound"
                                        OnSorting="dgEvent_Sorting" PageSize="10">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Event ID" />
                                            <%--<asp:BoundField DataField="Name" HeaderText="Event Name" SortExpression="Name">
                                    </asp:BoundField>--%>
                                            <asp:TemplateField SortExpression="Name">
                                                <HeaderTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkEventName" Text="Event Name" OnClick="lnkEventName_Click">Event Name</asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <span id="spnName" runat="server">
                                                        <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                                    </span>
                                                    <input class="hasBreastCancer" type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "HasBreastCancer")%>" />
                                                    <input class="isAllowNonMammoPatients" type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "AllowNonMammoPatients")%>" />
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
                                            <asp:BoundField DataField="Date" DataFormatString="{0:dddd dd MMMM yyyy}" HeaderText="Event Date"
                                                HtmlEncode="False" SortExpression="Date" />
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
                                                        <a href='<%# DataBinder.Eval(Container.DataItem, "GoogleMap")%>' target="_blank">[Map
                                                            To Location]</a></font>
                                                    <br />
                                                    <span><font size="1px">
                                                        <%# DataBinder.Eval(Container.DataItem, "GoogleAddressVerified")%></font></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="Host" HeaderText="Host Site" SortExpression="Host"></asp:BoundField>
                                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State"></asp:BoundField>
                                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
                                    <asp:BoundField DataField="Zip" HeaderText="Zip"></asp:BoundField>--%>
                                            <asp:BoundField DataField="Distance" HeaderText="Distance(Miles)" SortExpression="Distance" />
                                            <asp:BoundField DataField="Slots" HeaderText="Available/Total No Of Slots" SortExpression="Slots" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <div style="text-align: center;">
                                                        Actions
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                        <asp:LinkButton ID="lnkSelectEvent" runat="server" CommandName="SelectEvent" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                            Text="Select" OnClick="lnkSelectEvent_Click" OnClientClick="return CheckhasMammoEvent(this)" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="row1" />
                                        <RowStyle CssClass="row2" />
                                        <AlternatingRowStyle CssClass="row3" />
                                    </asp:GridView>
                                </div>
                                <p class="blueboxbotbg_cl">
                                    <img src="/App/Images/specer.gif" width="746" height="5" alt="" />
                                </p>
                            </div>
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
                        <p>
                            <img src="../../Images/specer.gif" width="50px" height="20px" />
                        </p>
                        <p class="inputfldnowidth_default">
                            <span class="buttonconleft_default">
                                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="~/App/Images/back-buton.gif"
                                    OnClick="ibtnBack_Click" /></span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

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
        });
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
    <asp:HiddenField runat="server" ID="hidEventID" />
    <asp:HiddenField runat="server" ID="hfCustomerID" />
    <div style="display: none">
        <asp:Button runat="server" ID="continueWithSelectedEvent" />
        <asp:Button runat="server" ID="redirectNonMammoEvent" />
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
                __doPostBack('continueWithWarning', '');
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
                autoOpen: false, modal: true, width: 700, height: 250, top: 600, closeOnEscape: false, open: function (event, ui) {
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
                    $('#<%= hfIsSearchNonMammoEvent.ClientID %>').val(isRedirectNonMammo);
                    $('#<%= hfPreviousEventId.ClientID%>').val('<%= hidEventID.Value %>');
                    alert("You are not eligible for " + $(".testName").html() + ".");
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
                        $('#<%= hfPreviousEventId.ClientID%>').val('<%= hidEventID.Value %>');
                        __doPostBack('redirectNonMammoEvent', '');
                    }
                    else {
                        __doPostBack('continueWithWarning', '');
                    }
                }
            });
    }
    function ResetAnswerIfQuestionRemoved(removedTestId) {

        if (prefilledQuestions != "" && prefilledQuestions.indexOf(removedTestId) > 0) {
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

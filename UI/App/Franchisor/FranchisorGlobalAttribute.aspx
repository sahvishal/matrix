<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="Franchisor_FranchisorGlobalAttribute" Title="Untitled Page"
    CodeBehind="FranchisorGlobalAttribute.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

        function ValidateInput() {
            var txtGCutoffDate = document.getElementById("<%= txtGCutoffDate.ClientID %>");

            var txtSystemVersion = document.getElementById("<%= txtSystemVersion.ClientID %>");
            var txtEventdistance = document.getElementById("<%= txtEventdistance.ClientID %>");
            var txtAdministratorEmailAddress = document.getElementById("<%= txtAdministratorEmailAddress.ClientID %>");

            var txtCouponPrefix = document.getElementById("<%= txtCouponPrefix.ClientID %>");
            var ddlEventScheduleTemp = document.getElementById("<%= ddlEventScheduleTemp.ClientID %>");
            var txtDisplayQABar = document.getElementById("<%= txtDisplayQABar.ClientID %>");
            var txtMaxCommissionDollarAdvocate = document.getElementById("<%= txtMaxCommissionDollarAdvocate.ClientID %>");

            var txtMaxCommissionPercentAdvocate = document.getElementById("<%= txtMaxCommissionPercentAdvocate.ClientID %>");
            var txtMaxCommissionDollarSalesRep = document.getElementById("<%= txtMaxCommissionDollarSalesRep.ClientID %>");
            var txtMaxCommissionPercentSalesRep = document.getElementById("<%= txtMaxCommissionPercentSalesRep.ClientID %>");
            var txtHealthYesCompetitor = document.getElementById("<%= txtHealthYesCompetitor.ClientID %>");

            var txtMinumPurchaseAmount = document.getElementById("<%= txtMinumPurchaseAmount.ClientID %>"); 

            if (isBlank(txtGCutoffDate, "Global CutOff Date")) return false;


            if (isBlank(txtSystemVersion, "System Version")) return false;
            if (isNumeric(txtEventdistance, "Event Distance") == false) {
                return false;
            }

            if (isBlank(txtAdministratorEmailAddress, "Administrator Email Address")) {
                return false;
            }


            if (isBlank(txtCouponPrefix, "Coupon Prefix")) return false;
            if (ddlEventScheduleTemp.value == "0") {
                alert("Please select schedule template");
                ddlEventScheduleTemp.focus();
                return false;
            }

            if (isBlank(txtMaxCommissionDollarAdvocate, "Max Dollar Commission")) return false;
            if (isNumeric(txtMaxCommissionDollarAdvocate, "Max Dollar Commission") == false)
            { return false; }


            if (isBlank(txtMaxCommissionPercentAdvocate, "Max Percent Commission")) return false;
            if (isNumeric(txtMaxCommissionPercentAdvocate, "Max Percent Commission") == false)
            { return false; }

            if (isBlank(txtMaxCommissionDollarSalesRep, "Sales Rep Commission in Dollar")) return false;
            if (isNumeric(txtMaxCommissionDollarSalesRep, "Sales Rep Commission in Dollar") == false)
            { return false; }

            if (isBlank(document.getElementById("<%= CancellationFeeTextbox.ClientID %>"), "Cancellation Fee")) return false;
            if (isNumeric(document.getElementById("<%= CancellationFeeTextbox.ClientID %>"), "Cancellation Fee") == false)
            { return false; }

            if (isBlank(txtMaxCommissionPercentSalesRep, "Sales Rep Commission in Percent")) return false;
            if (isNumeric(txtMaxCommissionPercentSalesRep, "Sales Rep Commission in Percent") == false)
            { return false; }

            if (isBlank(txtHealthYesCompetitor, "Competitor")) {
                return false;
            }

            if (isBlank(txtMinumPurchaseAmount, "Minimum purchase amount")) return false;
            if (isNumeric(txtMaxCommissionPercentSalesRep, "Minimum purchase amount") == false)
            { return false; }

            if (isBlank(document.getElementById("<%= MaxNoOfEventToShowOnlineTextbox.ClientID %>"), "Max No. of Events to Show on Online"))
                return false;

            if (isNumeric(document.getElementById("<%= MaxNoOfEventToShowOnlineTextbox.ClientID %>"), "Max No. of Events to Show on Online") == false) {
                return false;
            }

            if (isBlank(document.getElementById("<%= MaxNoOfAppointmentSlotsToShowOnlineTextbox.ClientID %>"), "Max No. of Appointment Slots to Show on Online"))
                return false;
            if (isNumeric(document.getElementById("<%= MaxNoOfAppointmentSlotsToShowOnlineTextbox.ClientID %>"), "Max No. of Appointment Slots to Show on Online") == false) {
                return false;
            }

            if (isNumeric(document.getElementById("<%= CutoffHoursforOnlineEventSelTextBox.ClientID %>"), "Cut-Off Hours for Event Selection Online") == false) {
                return false;
            }

            if (isBlank(document.getElementById("<%= EventListPageSizeOnlineTextbox.ClientID %>"), "Event List Page Size on Online"))
                return false;
            if (isNumeric(document.getElementById("<%= EventListPageSizeOnlineTextbox.ClientID %>"), "Event List Page Size on Online") == false) {
                return false;
            }

            if (isNumeric(document.getElementById("<%= EventBookingTresholdTextbox.ClientID %>"), "Event Booking Treshold") == false) {
                return false;
            }

            var pwdExpiryDateCount = document.getElementById("<%= passwordExpiryDaysCount.ClientID %>");
            if (isNumeric(pwdExpiryDateCount, "Password Expiry Days Count") == false) {
                return false;
            } else {
                
                if (isGreaterThanZero(pwdExpiryDateCount, "Password Expiry Days Count") == false) {
                    return false;
                }
            }

            var previousPasswordNonRepetitionCount = document.getElementById("<%= previousPasswordNonRepetitionCount.ClientID %>");
            if (isNumeric(previousPasswordNonRepetitionCount, "No of most Recently Used Password which can not be reused") == false) {
                return false;
            } else {
                if (isGreaterThanZero(previousPasswordNonRepetitionCount, "No of most Recently Used Password which can not be reused") == false) {
                    return false;
                }
            }
            var otpExpirationMinutes = document.getElementById("<%= otpExpirationMinutes.ClientID %>");
            if (isNumeric(otpExpirationMinutes, "OTP Expiration Minutes") == false) {
                return false;
            } else {
                if (isGreaterThanZero(otpExpirationMinutes, "OTP Expiration Minutes") == false) {
                    return false;
                }
            }
            var otpMisMatchAttemptCount = document.getElementById("<%= otpMisMatchAttemptCount.ClientID %>");
            if (isNumeric(otpMisMatchAttemptCount, "No of wrong OTP attempts allowed before locking the Account") == false) {
                return false;
            } else {
                if (isGreaterThanZero(otpMisMatchAttemptCount, "No of wrong OTP attempts allowed before locking the Account") == false) {
                    return false;
                }
            }
            
            var safeDeviceExpiryDays = document.getElementById("<%= safeDeviceExpiryDays.ClientID %>");
            if (isNumeric(safeDeviceExpiryDays, "Safe Device Expiry Days") == false) {
                return false;
            } else {
                if (isGreaterThanZero(safeDeviceExpiryDays, "Safe Device Expiry Days") == false) {
                    return false;
                }
            }
            
            var alertPasswordExpirationInDays = document.getElementById("<%= alertBeforePasswordExpirationInDays.ClientID %>");
            if (isNumeric(alertPasswordExpirationInDays, "Alert User Before Password Expiration") == false) {
                return false;
            } else {
                if (isGreaterThanZero(alertPasswordExpirationInDays, "Alert User Before Password Expiration") == false) {
                    return false;
                }
            }
            
            if (MustBeGreaterThan(pwdExpiryDateCount, alertPasswordExpirationInDays, "Password Expiry Days Count", "Alert User Before Password Expiration") == false) {
                return false;
            }

            return true;
        }
        
        function MustBeGreaterThan(Control1, Conrol2, returnmessage, returnmessage1) {
            var val1 = Control1.value;
            var val2 = Conrol2.value;
            if (parseInt(val1, 10) < parseInt(val2, 10)) {
                alert(returnmessage + " must be Greater than " + returnmessage1);
                return false;
            }
            return true;
        }

        function isGreaterThanZero(Control, returnmessage) {
            val = Control.value;
            if (parseInt(val, 10) == 0) {
                alert(returnmessage + " must be greater than zero.");
                Control.focus();
                return false;
            }
            return true;
        }
        function ClearField() {

            var txtGCutoffDate = document.getElementById("<%= txtGCutoffDate.ClientID %>");

            var txtSystemVersion = document.getElementById("<%= txtSystemVersion.ClientID %>");
            var txtEventdistance = document.getElementById("<%= txtEventdistance.ClientID %>");
            var txtAdministratorEmailAddress = document.getElementById("<%= txtAdministratorEmailAddress.ClientID %>");

            var txtCouponPrefix = document.getElementById("<%= txtCouponPrefix.ClientID %>");
            var ddlEventScheduleTemp = document.getElementById("<%= ddlEventScheduleTemp.ClientID %>");
            var txtDisplayQABar = document.getElementById("<%= txtDisplayQABar.ClientID %>");
            var txtMaxCommissionDollarAdvocate = document.getElementById("<%= txtMaxCommissionDollarAdvocate.ClientID %>");

            var txtMaxCommissionPercentAdvocate = document.getElementById("<%= txtMaxCommissionPercentAdvocate.ClientID %>");
            var txtMaxCommissionDollarSalesRep = document.getElementById("<%= txtMaxCommissionDollarSalesRep.ClientID %>");
            var txtMaxCommissionPercentSalesRep = document.getElementById("<%= txtMaxCommissionPercentSalesRep.ClientID %>");
            var txtHealthYesCompetitor = document.getElementById("<%= txtHealthYesCompetitor.ClientID %>");
            var txtMinumPurchaseAmount = document.getElementById("<%= txtMinumPurchaseAmount.ClientID %>");

            txtGCutoffDate.value = "";

            txtSystemVersion.value = "";
            txtEventdistance.value = "";
            txtAdministratorEmailAddress.value = "";

            txtCouponPrefix.value = "";
            ddlEventScheduleTemp.options[0].selected = true;

            txtDisplayQABar.value = "";
            txtMaxCommissionDollarAdvocate.value = '';

            txtMaxCommissionPercentAdvocate.value = '';
            txtMaxCommissionDollarSalesRep.value = '';
            txtMaxCommissionPercentSalesRep.value = '';
            txtHealthYesCompetitor.value = '';
            document.getElementById("<%= CancellationFeeTextbox.ClientID %>").value = "";
            txtMinumPurchaseAmount.nodeValue = '';
            return false;
        }

        function RestoreDefault() {

            var txtGCutoffDate = document.getElementById("<%= txtGCutoffDate.ClientID %>");

            var txtSystemVersion = document.getElementById("<%= txtSystemVersion.ClientID %>");
            var txtEventdistance = document.getElementById("<%= txtEventdistance.ClientID %>");
            var txtAdministratorEmailAddress = document.getElementById("<%= txtAdministratorEmailAddress.ClientID %>");

            var txtCouponPrefix = document.getElementById("<%= txtCouponPrefix.ClientID %>");
            var ddlEventScheduleTemp = document.getElementById("<%= ddlEventScheduleTemp.ClientID %>");
            var txtDisplayQABar = document.getElementById("<%= txtDisplayQABar.ClientID %>");
            var txtMaxCommissionDollarAdvocate = document.getElementById("<%= txtMaxCommissionDollarAdvocate.ClientID %>");

            var txtMaxCommissionPercentAdvocate = document.getElementById("<%= txtMaxCommissionPercentAdvocate.ClientID %>");
            var txtMaxCommissionDollarSalesRep = document.getElementById("<%= txtMaxCommissionDollarSalesRep.ClientID %>");
            var txtMaxCommissionPercentSalesRep = document.getElementById("<%= txtMaxCommissionPercentSalesRep.ClientID %>");
            var txtHealthYesCompetitor = document.getElementById("<%= txtHealthYesCompetitor.ClientID %>");
            var hfHealthYesCompetitor = document.getElementById("<%= hfHealthYesCompetitor.ClientID %>");

            txtGCutoffDate.value = document.getElementById("<%= hidGCutoffDate.ClientID %>").value;

            if (hidOrderCatalog.value == "Yes") {
                document.getElementById("ctl00_ContentPlaceHolder1_rdoOrderCatalog_0").checked = true;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_rdoOrderCatalog_1").checked = true;
            }

            txtSystemVersion.value = document.getElementById("<%= hidSystemVersion.ClientID %>").value;
            txtEventdistance.value = document.getElementById("<%= hidEventdistance.ClientID %>").value;
            txtAdministratorEmailAddress.value = document.getElementById("<%= hidAdministratorEmailAddress.ClientID %>").value;

            txtCouponPrefix.value = document.getElementById("<%= hidCouponPrefix.ClientID %>").value;
            var EventScheduleTemp = document.getElementById("<%= hidEventScheduleTemp.ClientID %>").value;
            for (i = 0; i <= ddlEventScheduleTemp.options.length - 1; i++) {
                if (ddlEventScheduleTemp.options[i].value == EventScheduleTemp) {
                    ddlEventScheduleTemp.options[i].selected = true;
                }
            }
            txtDisplayQABar.value = document.getElementById("<%= hidDisplayQABar.ClientID %>").value;
            txtMaxCommissionDollarAdvocate.value = document.getElementById("<%= hidMaxCommissionDollar.ClientID %>").value;

            txtMaxCommissionPercentAdvocate.value = document.getElementById("<%= hidMaxCommissionPercent.ClientID %>").value;
            txtMaxCommissionDollarSalesRep.value = document.getElementById("<%= hidSalesRepMaxCommissionDollar.ClientID %>").value;
            txtMaxCommissionPercentSalesRep.value = document.getElementById("<%= hidSalesRepMaxCommissionPercent.ClientID %>").value;

            txtHealthYesCompetitor.value = hfHealthYesCompetitor.value;
            document.getElementById("<%= CancellationFeeTextbox.ClientID %>").value = document.getElementById("<%= CancellationFeeHiddenbox.ClientID %>").value;

            document.getElementById("<%= txtMinumPurchaseAmount.ClientID %>").value = document.getElementById("<%= MinimumPurchaseAmountHiddenField.ClientID %>").value;

            return false;
        }

        function ViewDashBoard() {
            window.location.href = "Dashboard.aspx";
            return false;
        }
    </script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" />
                    </p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Global Settings</span>
                </div>
            </div>
            <div class="maindivgreenmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div class="main_area_bdr" runat="server" id="divStartingThree" style="display: none">
                    <p class="main_container_row_default">
                        <span class="titletxteventbig_ga">Change Password:</span> <span class="inputfldnowidth_default">Every&nbsp;<asp:TextBox ID="txtPasswordDay" runat="server" CssClass="inputf_ga" Text=""
                            Width="40" MaxLength="2"></asp:TextBox>&nbsp;days </span>
                    </p>
                    <p class="main_container_row_default">
                        <span class="titletxteventbig_ga">Other Pictures:</span> <span class="inputfldnowidth_default">(No.)&nbsp;<asp:TextBox ID="txtOtherPicture" runat="server" CssClass="inputf_ga"
                            Text="" Width="40" MaxLength="2"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_default">
                        <span class="titletxteventbig_ga">Prospect Key Details:</span> <span class="inputfldnowidth_default">
                            <asp:DropDownList runat="server" ID="ddlProspectKey1" CssClass="" Width="120" Enabled="false">
                                <asp:ListItem Text="Select Key"></asp:ListItem>
                                <asp:ListItem Text="Select Key1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddlProspectKey2" CssClass="" Width="120" Enabled="false">
                                <asp:ListItem Text="Select Key"></asp:ListItem>
                                <asp:ListItem Text="Select Key1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddlProspectKey3" CssClass="" Width="120" Enabled="false">
                                <asp:ListItem Text="Select Key"></asp:ListItem>
                                <asp:ListItem Text="Select Key1"></asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </p>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="5px" />
                </p>
                <div id="diverrorsummary" class="graytxtright_prsmall">
                    <span class="reqiredmark"><sup>*</sup></span> Mandatory fields&nbsp;
                </div>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Global CutOff Date:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtGCutoffDate" runat="server" CssClass="inputf_ga" Width="100px"></asp:TextBox>
                        <asp:ImageButton runat="Server" ID="imgBookingDepCal" ImageUrl="~/App/Images/calendar-icon.gif"
                            AlternateText="Click to show calendar" />
                        <cc1:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtGCutoffDate"
                            PopupButtonID="imgBookingDepCal" Format="MM/dd/yyyy" Animated="true" />
                        <span style="font-size: 7pt;">(mm/dd/yyyy)</span> </span>
                </p>
                <%--Begin SystemVersion --%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">System Version:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtSystemVersion" CssClass="inputf_ga" runat="server" MaxLength="12"
                            Width="100px"></asp:TextBox></span>
                </p>
                <%--End SystemVersion --%>
                <%--Begin Event Distance --%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Event Distance:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtEventdistance" CssClass="inputf_ga" runat="server" MaxLength="12"
                            Width="100px"></asp:TextBox></span>
                </p>
                <%--End Event Distance --%>
                <%--Begin Administrator Email Address --%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Administrator Email Address:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtAdministratorEmailAddress" CssClass="inputf_ga" runat="server"
                            MaxLength="100" Width="200px"></asp:TextBox></span>
                </p>
                <%--End Administrator Email Address --%>
                <%--Begin Coupon Prefix--%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Coupon Prefix:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtCouponPrefix" CssClass="inputf_ga" runat="server" MaxLength="100"
                            Width="100px"></asp:TextBox></span>
                </p>
                <%--End Google Calendar Password --%>
                <%--Begin Schedule Template--%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Schedule Template:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:DropDownList ID="ddlEventScheduleTemp" runat="server" Width="200px">
                        </asp:DropDownList>
                    </span>
                </p>
                <%--End Schedule Template--%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Max Dollar Commission:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtMaxCommissionDollarAdvocate" CssClass="inputf_ga" runat="server"
                            MaxLength="100" Width="50px"></asp:TextBox></span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Max Percent Commission:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtMaxCommissionPercentAdvocate" CssClass="inputf_ga" runat="server"
                            MaxLength="100" Width="50px"></asp:TextBox></span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Max Dollar Commission (Sales Rep):<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtMaxCommissionDollarSalesRep" CssClass="inputf_ga" runat="server"
                            MaxLength="100" Width="50px"></asp:TextBox></span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Max Percent Commission (Sales Rep):<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtMaxCommissionPercentSalesRep" CssClass="inputf_ga" runat="server"
                            MaxLength="100" Width="50px"></asp:TextBox></span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Cancellation Fee:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="CancellationFeeTextbox" CssClass="inputf_ga" runat="server" MaxLength="100"
                            Width="50px"></asp:TextBox></span>
                </p>
                <%--Begin Display QA Bar--%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Top bar Text:<span class="reqiredmark"></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtDisplayQABar" runat="server" MaxLength="200" Width="100px"></asp:TextBox>
                    </span><span style="font-size: 7pt; font-style: italic;">&nbsp;Keep blank to hide the
                        bar for production environment</span>
                </p>
                <%--End Display QA Bar--%>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">
                        <%= IoC.Resolve<ISettings>().CompanyName%>
                        Competitor:<span class="reqiredmark"><sup>*</sup></span></span> <span class="inputfldnowidth_default">
                            <asp:TextBox runat="server" ID="txtHealthYesCompetitor" CssClass="inputf_ga" Width="300px"
                                TextMode="MultiLine" Rows="5"></asp:TextBox>
                            <br />
                            <span style="font-size: 7pt; font-style: italic;">Separate entries by pipe ( | ) separator
                            </span></span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Event Start Time:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:DropDownList ID="ddlHHStartTime" runat="server" Width="50px">
                            <asp:ListItem Text="01" Value="01"></asp:ListItem>
                            <asp:ListItem Text="02" Value="02"></asp:ListItem>
                            <asp:ListItem Text="03" Value="03"></asp:ListItem>
                            <asp:ListItem Text="04" Value="04"></asp:ListItem>
                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlMMStartTime" runat="server" Width="50px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAMPMStartTime" runat="server" Width="50px">
                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Event End Time:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:DropDownList ID="ddlHHEndTime" runat="server" Width="50px">
                            <asp:ListItem Text="01" Value="01"></asp:ListItem>
                            <asp:ListItem Text="02" Value="02"></asp:ListItem>
                            <asp:ListItem Text="03" Value="03"></asp:ListItem>
                            <asp:ListItem Text="04" Value="04"></asp:ListItem>
                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlMMEndTime" runat="server" Width="50px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAMPMEndTime" runat="server" Width="50px">
                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Minimum Purchase Amount:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtMinumPurchaseAmount" CssClass="inputf_ga" runat="server" MaxLength="100"
                            Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Incoming Phone Line Required:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="IncomingPhoneLineRequiredYes" runat="server" name="IncomingPhoneLineRequired" />
                        Yes
                        <input type="radio" id="IncomingPhoneLineRequiredNo" runat="server" name="IncomingPhoneLineRequired" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Ala Carte:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="EnableAlacarteYes" runat="server" name="EnableAlacarte" />
                        Yes
                        <input type="radio" id="EnableAlaCarteNo" runat="server" name="EnableAlacarte" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Area Code:</span> <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtAreaCode" CssClass="inputf_ga" runat="server" MaxLength="100"
                            Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Bar Code:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="EnableBarCodeYes" runat="server" name="EnableBarCode" />
                        Yes
                        <input type="radio" id="EnableBarCodeNo" runat="server" name="EnableBarCode" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Upsell Package:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="UpsellPackageYes" runat="server" name="UpsellPackage" />
                        Yes
                        <input type="radio" id="UpsellPackageNo" runat="server" name="UpsellPackage" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Upsell Cd:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="UpsellCdYes" runat="server" name="UpsellCd" />
                        Yes
                        <input type="radio" id="UpsellCdNo" runat="server" name="UpsellCd" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Upsell A la Carte:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="UpsellAlaCarteYes" runat="server" name="UpsellAlaCarte" />
                        Yes
                        <input type="radio" id="UpsellAlaCarteNo" runat="server" name="UpsellAlaCarte" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Max No. of Events to Show on Online:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="MaxNoOfEventToShowOnlineTextbox" CssClass="inputf_ga" runat="server"
                            MaxLength="100" Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Max No. of Appointment Slots to Show on Online:<span
                        class="reqiredmark"><sup>*</sup></span></span> <span class="inputfldnowidth_default">
                            <asp:TextBox ID="MaxNoOfAppointmentSlotsToShowOnlineTextbox" CssClass="inputf_ga"
                                runat="server" MaxLength="100" Width="50px"></asp:TextBox>
                        </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Event List Page Size on Online:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="EventListPageSizeOnlineTextbox" CssClass="inputf_ga" runat="server"
                            MaxLength="100" Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Paper Size:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:DropDownList ID="PaperSizeDropDownList" runat="server">
                            <asp:ListItem Text="A4" Value="A4"></asp:ListItem>
                            <asp:ListItem Text="Letter" Value="Letter"></asp:ListItem>
                            <asp:ListItem Text="Legal" Value="Legal"></asp:ListItem>
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Display Premium Version:<span class="reqiredmark"><sup>*</sup></span><br />
                        <i>(For Customer Portal) </i></span><span class="inputfldnowidth_default">
                            <input type="radio" id="DisplayPremVersionYes" runat="server" name="DisplayPremVersion" />
                            Yes
                            <input type="radio" id="DisplayPremVersionNo" runat="server" name="DisplayPremVersion" />
                            No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Result Delivery Notification: <span class="reqiredmark">
                        <sup>*</sup></span></span> <span class="inputfldnowidth_default">
                            <input type="radio" id="EnableDelNotificationYes" runat="server" name="EnableDelNotification" />
                            Yes
                            <input type="radio" id="EnableDelNotificationNo" runat="server" name="EnableDelNotification" />
                            No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Newsletter Prompt: <span class="reqiredmark">
                        <sup>*</sup></span></span> <span class="inputfldnowidth_default">
                            <input type="radio" id="EnableNewsletterYes" runat="server" name="EnableNewsletter" />
                            Yes
                            <input type="radio" id="EnableNewsletterNo" runat="server" name="EnableNewsletter" />
                            No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Source Code Label:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="SourceCodeLabelText" CssClass="inputf_ga" runat="server" MaxLength="20"
                            Width="90px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">CutOffHours for Online Event Selection:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="CutoffHoursforOnlineEventSelTextBox" CssClass="inputf_ga" runat="server"
                            MaxLength="2" Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Allow Reschedule Appointment:<span class="reqiredmark"><sup>*</sup></span><br />
                        <i>(For Customer Portal) </i></span><span class="inputfldnowidth_default">
                            <input type="radio" id="DisplayRescheduleAppointmentYes" runat="server" name="DisplayRescheduleAppointment" />
                            Yes
                            <input type="radio" id="DisplayRescheduleAppointmentNo" runat="server" name="DisplayRescheduleAppointment" />
                            No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Show Basic Biometric:<span class="reqiredmark"><sup>*</sup></span><br />
                    </span><span class="inputfldnowidth_default">
                        <input type="radio" id="ShowBasicBiometricYes" runat="server" name="ShowBasicBiometric" />
                        Yes
                        <input type="radio" id="ShowBasicBiometricNo" runat="server" name="ShowBasicBiometric" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Quick Onsite Registration:<span class="reqiredmark"><sup>*</sup></span><br />
                    </span><span class="inputfldnowidth_default">
                        <input type="radio" id="EnableQuickOnsiteRegistrationYes" runat="server" name="EnableQuickOnsiteRegistration" />
                        Yes
                        <input type="radio" id="EnableQuickOnsiteRegistrationNo" runat="server" name="EnableQuickOnsiteRegistration" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Pay later option for Online Registration:<span
                        class="reqiredmark"><sup>*</sup></span><br />
                    </span><span class="inputfldnowidth_default">
                        <input type="radio" id="PayLaterOnlineRegistrationYes" runat="server" name="PayLaterOnlineRegistration" />
                        Yes
                        <input type="radio" id="PayLaterOnlineRegistrationNo" runat="server" name="PayLaterOnlineRegistration" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Restrict Available Time Slot For Corporate:<span
                        class="reqiredmark"><sup>*</sup></span><br />
                    </span><span class="inputfldnowidth_default">
                        <input type="radio" id="RestrictAvailableTimeSlotForCorporateYes" runat="server"
                            name="RestrictAvailableTimeSlotForCorporate" />
                        Yes
                        <input type="radio" id="RestrictAvailableTimeSlotForCorporateNo" runat="server" name="RestrictAvailableTimeSlotForCorporate" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Screening Reminder Notification: </span><span class="inputfldnowidth_default">
                        <input type="radio" id="ScreeningReminderNotificationYes" runat="server" name="ScreeningReminderNotification" />
                        Yes
                        <input type="radio" id="ScreeningReminderNotificationNo" runat="server" name="ScreeningReminderNotification" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Hipaa: </span><span class="inputfldnowidth_default">
                        <input type="radio" id="HipaaEnabledYes" runat="server" name="HipaaEnabled" />
                        Yes
                        <input type="radio" id="HipaaEnabledNo" runat="server" name="HipaaEnabled" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Dynamic Slot:<span class="reqiredmark"><sup>*</sup></span><br />
                    </span><span class="inputfldnowidth_default">
                        <input type="radio" id="EnableDynamicSlotYes" runat="server" name="EnableDynamicSlot" />
                        Yes
                        <input type="radio" id="EnableDynamicSlotNo" runat="server" name="EnableDynamicSlot" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Lunch Start Time:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:DropDownList ID="ddlHHLunchStartTime" runat="server" Width="50px">
                            <asp:ListItem Text="01" Value="01"></asp:ListItem>
                            <asp:ListItem Text="02" Value="02"></asp:ListItem>
                            <asp:ListItem Text="03" Value="03"></asp:ListItem>
                            <asp:ListItem Text="04" Value="04"></asp:ListItem>
                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlMMLunchStartTime" runat="server" Width="50px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAMPMLunchStartTime" runat="server" Width="50px">
                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Send Evaluation Reminder Mail for Empty Queue:<span class="reqiredmark"><sup>*</sup></span><br />
                    </span><span class="inputfldnowidth_default">
                        <input type="radio" id="SendEmptyQueueEvaluationReminderYes" runat="server" name="SendEmptyQueueEvaluationReminder" />Yes
                        <input type="radio" id="SendEmptyQueueEvaluationReminderNo" runat="server" name="SendEmptyQueueEvaluationReminder" />No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Event Booking Threshold:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="EventBookingTresholdTextbox" CssClass="inputf_ga" runat="server" MaxLength="2" Width="50px"></asp:TextBox>%
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Collect Info For Package Selection:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="PackageSelectionInfoYes" runat="server" name="PackageSelectionInfo" />Yes
                        <input type="radio" id="PackageSelectionInfoNo" runat="server" name="PackageSelectionInfo" />No 
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable SMS Notification: </span><span class="inputfldnowidth_default">
                        <input type="radio" id="SmsEnabledYes" runat="server" name="SmsEnabled" />
                        Yes
                        <input type="radio" id="SmsEnabledNo" runat="server" name="SmsEnabled" />
                        No </span>
                </p>
                 <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Voice Mail Notification: </span><span class="inputfldnowidth_default">
                        <input type="radio" id="VoiceMailEnabledYes" runat="server" name="VoicMailEnabled" />
                        Yes
                        <input type="radio" id="VoiceMailEnabledNo" runat="server" name="VoicMailEnabled" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable Physician Partner Customer Fax Result Notification: </span><span class="inputfldnowidth_default">
                        <input type="radio" id="FaxEnabledYes" runat="server" name="FaxEnabled" />
                        Yes
                        <input type="radio" id="FaxEnabledNo" runat="server" name="FaxEnabled" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Enable AWV Customer Fax Result Notification: </span><span class="inputfldnowidth_default">
                        <input type="radio" id="AWVFaxEnabledYes" runat="server" name="AWVFaxEnabled" />
                        Yes
                        <input type="radio" id="AWVFaxEnabledNo" runat="server" name="AWVFaxEnabled" />
                        No </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Ask Pre Qualification Questions: </span>
                    <span class="inputfldnowidth_default">
                        <input type="radio" id="AskPreQualificationQuestionYes" runat="server" name="AskPreQualificationQuestion" />
                        Yes
                        <input type="radio" id="AskPreQualificationQuestionNo" runat="server" name="AskPreQualificationQuestion" />
                        No 
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">Password Expiry Days Count :<span class="reqiredmark"><sup>*</sup></span> </span>
                    <span class="inputfldnowidth_default">
                       <asp:TextBox ID="passwordExpiryDaysCount" CssClass="inputf_ga noDot" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">No of most Recently Used Password which can not be reused:<span class="reqiredmark"><sup>*</sup></span> </span>
                    <span class="inputfldnowidth_default">
                      <asp:TextBox ID="previousPasswordNonRepetitionCount" CssClass="inputf_ga noDot" runat="server" MaxLength="2" Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletxteventbig_ga">OTP Notification Medium : </span>
                    <span class="inputfldnowidth_default">
                        <asp:CheckBox ID="otpEmail"   runat="server" ></asp:CheckBox> Email
                        <asp:CheckBox ID="otpSms"   runat="server"  ></asp:CheckBox> SMS
                        <asp:CheckBox ID="googleAuthenticator"   runat="server"></asp:CheckBox> Google Authenticator
                    </span>
                </p> 

                <p class="main_container_row_default ifOtpAvailable">
                    <span class="titletxteventbig_ga">OTP Expiration Minutes : <span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                       <asp:TextBox ID="otpExpirationMinutes" CssClass="inputf_ga noDot" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default ifOtpAvailable">
                    <span class="titletxteventbig_ga">No of wrong OTP attempts allowed before locking the Account:<span class="reqiredmark"><sup>*</sup></span> </span>
                    <span class="inputfldnowidth_default">
                      <asp:TextBox ID="otpMisMatchAttemptCount" CssClass="inputf_ga noDot" runat="server" MaxLength="2" Width="50px"></asp:TextBox>
                    </span>
                </p>
                
                <p class="main_container_row_default ifOtpAvailable">
                    <span class="titletxteventbig_ga">Remember Computer as safe to Skip OTP : <span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:CheckBox ID="allowSafeComputerRemember"   runat="server" ></asp:CheckBox>
                    </span>
                </p>
                <p class="main_container_row_default ifOtpAvailable" id="safeDeviceExpiryDaysDiv">
                    <span class="titletxteventbig_ga">Safe Device Expiry Days:<span class="reqiredmark"><sup>*</sup></span> </span>
                    <span class="inputfldnowidth_default">
                      <asp:TextBox ID="safeDeviceExpiryDays" CssClass="inputf_ga noDot" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default" id="alertBeforePasswordExpirationDiv">
                    <span class="titletxteventbig_ga">Alert User Before Password Expiration (in Days):<span class="reqiredmark"><sup>*</sup></span> </span>
                    <span class="inputfldnowidth_default">
                      <asp:TextBox ID="alertBeforePasswordExpirationInDays" CssClass="inputf_ga noDot" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                    </span>
                </p>
            </div>
        </div>
        <div class="headbg2_box_default">
            <div class="buttoncon_default">
                <asp:ImageButton ID="Save" runat="server" CssClass="" ImageUrl="../Images/save-button.gif"
                    OnClientClick="return ValidateInput()" OnClick="Save_Click" />
            </div>
            <div class="buttoncon_default">
                <asp:ImageButton ID="Cancel" runat="server" CssClass="" ImageUrl="../Images/clear-button.gif"
                    OnClientClick="return ClearField()" />
            </div>
            <div class="buttoncon4_default" style="width: 57px;">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Images/cancel-button.gif"
                    OnClientClick="return ViewDashBoard();" />
            </div>
            <div class="buttoncon4_default" style="width: 106px;">
                <asp:ImageButton ID="imgRestoreDefault" runat="server" ImageUrl="../Images/restore-default-btn.gif"
                    OnClientClick="return RestoreDefault()" />
            </div>
        </div>
    </div>
    <input type="hidden" id="hidMultipleIPs" runat="server" />
    <input type="hidden" id="hidGCutoffDate" runat="server" />
    <input type="hidden" id="hidSystemVersion" runat="server" />
    <input type="hidden" id="hidEventdistance" runat="server" />
    <input type="hidden" id="hidFromEmail" runat="server" />
    <input type="hidden" id="hidFromName" runat="server" />
    <input type="hidden" id="hidAdministratorEmailAddress" runat="server" />
    <input type="hidden" id="hidGoogleCalendarUsername" runat="server" />
    <input type="hidden" id="hidGoogleCalendarPassword" runat="server" />
    <input type="hidden" id="hidCouponPrefix" runat="server" />
    <input type="hidden" id="hidEventScheduleTemp" runat="server" />
    <input type="hidden" id="hidCCRepDashRefereshTime" runat="server" />
    <input type="hidden" id="hidDisplayQABar" runat="server" />
    <input type="hidden" id="hidMaxCommissionDollar" runat="server" />
    <input type="hidden" id="hidMaxCommissionPercent" runat="server" />
    <input type="hidden" id="hidSalesRepMaxCommissionDollar" runat="server" />
    <input type="hidden" id="hidSalesRepMaxCommissionPercent" runat="server" />
    <input type="hidden" id="hfHealthYesCompetitor" runat="server" />
    <input type="hidden" id="CancellationFeeHiddenbox" runat="server" />
    <input type="hidden" id="EventStartTimeHiddenField" runat="server" />
    <input type="hidden" id="EventEndTimeHiddenField" runat="server" />
    <input type="hidden" id="MinimumPurchaseAmountHiddenField" runat="server" />
    <script type="text/javascript" language="javascript">
        $(".noDot").keydown(function(e) {
            return e.which !== 190 && e.which !== 110 && e.which !== 32;
        });

        $(document).ready(function() {
            if ($('#<%=allowSafeComputerRemember.ClientID %>').is(':checked'))
                $('#safeDeviceExpiryDaysDiv').show();
            else
                $('#safeDeviceExpiryDaysDiv').hide();
        });

        $('#<%=allowSafeComputerRemember.ClientID %>').change(function () {
            if ($('#<%=allowSafeComputerRemember.ClientID %>').is(':checked'))
                $('#safeDeviceExpiryDaysDiv').show();
            else
                $('#safeDeviceExpiryDaysDiv').hide();
        });

        var ifOtpAvailable = function() {
            if ($('#<%=otpEmail.ClientID %>').is(':checked') || $('#<%=otpSms.ClientID %>').is(':checked') || $('#<%=googleAuthenticator.ClientID %>').is(':checked')) {
                $('.ifOtpAvailable').show();

                if ($('#<%=allowSafeComputerRemember.ClientID%>').is(':checked'))
                    $('#safeDeviceExpiryDaysDiv').show();
                else
                    $('#safeDeviceExpiryDaysDiv').hide();

            } else {
                $('.ifOtpAvailable').hide();
            }


        };

        $('#<%=otpEmail.ClientID%>').change(ifOtpAvailable);
        $('#<%=otpSms.ClientID%>').change(ifOtpAvailable);
        $('#<%=googleAuthenticator.ClientID%>').change(ifOtpAvailable);
    </script>
</asp:Content>

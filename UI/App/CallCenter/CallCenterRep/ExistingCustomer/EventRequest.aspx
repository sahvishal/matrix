<%@ Page Title="Event Request - Callback Prospect" Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    AutoEventWireup="true" CodeBehind="EventRequest.aspx.cs" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer.EventRequest" %>
<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Marketing.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Sales.Enum" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="/Content/JavaScript/querystring.js" type="text/javascript"></script>
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryMaskInput="true" />
    <div class="wrapper_inpg">
        <div>
            <div class="middivrow_regcust">
            </div>
            <div class="rightdivrow_regcust" id="divCall" runat="server" style="width:200px">
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
                            OnClientClick="CallNotes(); return false;" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <h1 style="margin-left: 100px;padding-top:20px">Call Back Prospect</h1><br />
    <div style="margin-left: 100px;padding-top:20px">
        <p>
            Please provide your First name, Last name, e-mail address, <b>and/or</b> your phone
            number.</p>
        <p />
        <table width="75%" border="0px" style="margin-left: 10px; padding-top:20px">
            <tr>
                <td>
                    First : <span class="reqiredmark"><sup>*</sup></span>
                </td>
                <td>
                    <input type="text" id="FirstNameTextbox" runat="server" />
                </td>
                <td>
                    Last : <span class="reqiredmark"><sup>*</sup></span>
                </td>
                <td>
                    <input type="text" id="LastNameTextbox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Phone : <span class="reqiredmark"><sup>*</sup></span>
                </td>
                <td>
                    <input type="text" id="PhoneNumberTextbox" class="mask-phone" runat="server" />
                </td>
                <td>
                    Email :
                </td>
                <td>
                    <input type="text" id="EmailTextbox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Street:</td>
                <td>
                    <input type="text" id="StreetAddressLine1Textbox" runat="server" />
                </td>
                <td>Suite:</td>
                <td>
                    <input type="text" id="StreetAddressLine2Textbox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <input type="text" id="StateTextbox" runat="server" />
                </td>
                <td>City:</td>
                <td>
                    <input type="text" id="CityTextbox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Zip:</td>
                <td>
                    <input type="text" id="ZipTextbox" runat="server" />
                </td>
                <td>Call Disposition</td>
                <td>
                    <asp:DropDownList ID="CallDispositionDropdown" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right" style="padding-top:20px">
                    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="~/App/Images/back-button.gif" onclick="imgBack_Click" />
                    <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/App/Images/save-button.gif" OnClientClick="return SaveProspect();" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    We will get back to once we organize any event in your area.
                </td>
            </tr>
        </table>        
    </div> 
    
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <script src="/App/JavascriptFiles/JSonHelper.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $('.mask-phone').mask('(999)-999-9999');
        });

        var isCallStarted='';
        function getQueryString() {
            var qs = new Querystring();
            var url = qs.get("Zip");
            if (qs.contains("Call"))
                isCallStarted = qs.get("Call");
            return url;
        }


        var zipCode = { "Id": 0, "Zip": "", "Latitude": 0, "Longitude": 0, "TimeZone": 0, "IsInDaylightSavingsTime": false };
        var prospectCustomer = { "Id": 0,
            "FirstName": "",
            "LastName": "",
            "Gender": 0,
            "Address": { "StreetAddressLine1": "", "StreetAddressLine2": "", "City": "", "State": "", "Country": "", "ZipCode": zipCode },
            "PhoneNumber": { "CountryCode": 1, "AreaCode": "", "Number": "" },
            "CallBackPhoneNumber": { "CountryCode": 1, "AreaCode": "", "Number": "" },
            "Email": { "Address": "", "DomainName": "" },
            "BirthDate": "",
            "Source": "<%=ProspectCustomerSource.CallCenter %>",
            "Tag": "<%=ProspectCustomerTag.NotServicedZip %>",
            "SourceCodeId": "",
            "MarketingSource": "",
            "CustomerId": "",
            "ConvertedOnDate": ""
        };

        function validateProspectInput() {
            if ($('#<%=EmailTextbox.ClientID %>').val() != '')
                if (!validateEmail($("#<%=EmailTextbox.ClientID %>")[0], "email "))
                { return false; }

                if (($('#<%=FirstNameTextbox.ClientID %>').val() == '') || ($('#<%= LastNameTextbox.ClientID%>').val() == '') || ($('#<%=PhoneNumberTextbox.ClientID %>').val() == '')) {
                alert("Your complete name along with your phone number is required so that we can contact you!");
                return false;
            }
            return true;
        }

        function SaveProspect() {
            if (!validateProspectInput()) return false;
            if (Number('<%= CustomerId %>') > 0) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/App/Controllers/ProspectCustomerController.asmx/GetByCustomerId",
                    data: "{'customerId':" + '<%= CustomerId %>' + "}",
                    success: OnProspectGetComplete,
                    error: function (a, arg2) {
                        if (a.status == 401) {
                            alert("You do not have the permission.");
                        }
                    }
                });
            }
            else if (Number('<%= CurrentProspectCustomerId %>') > 0) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/App/Controllers/ProspectCustomerController.asmx/GetById",
                    data: "{'prospectCustomerId':" + '<%= CurrentProspectCustomerId %>' + "}",
                    success: OnProspectGetComplete,
                    error: function (a, arg2) {
                        if (a.status == 401) {
                            alert("You do not have the permission.");
                        }
                    }
                });
            }
            else {
                
                var prostecCust = $.toJSON(GetCurrentProspectCustomer());
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "/App/Controllers/ProspectCustomerController.asmx/SaveProspectCustomer",
                    data: "{'prospectCustomer':" + prostecCust + "}",
                    success: OnProspectSaveComplete,
                    error: function (a, arg2) {
                        if (a.status == 401) {
                            alert("You do not have the permission.");
                        }
                    }
                });
            }            

            return false;
        }

        function GetCurrentProspectCustomer() {
            prospectCustomer.FirstName = $('#<%=FirstNameTextbox.ClientID %>').val();
            prospectCustomer.LastName = $('#<%= LastNameTextbox.ClientID%>').val();
            prospectCustomer.Address.Country = "USA";
            prospectCustomer.Address.StreetAddressLine1 = $('#<%=StreetAddressLine1Textbox.ClientID %>').val();
            prospectCustomer.Address.StreetAddressLine2 = $('#<%=StreetAddressLine2Textbox.ClientID %>').val();
            prospectCustomer.Address.State = $('#<%= StateTextbox.ClientID %>').val();
            prospectCustomer.Address.City = $('#<%= CityTextbox.ClientID %>').val();
            prospectCustomer.Address.ZipCode.Zip = $('#<%= ZipTextbox.ClientID %>').val();
            var phoneNumber = $('#<%=PhoneNumberTextbox.ClientID %>').val();
            if (phoneNumber != '') {
                phoneNumber = phoneNumber.replace("(", "");
                phoneNumber = phoneNumber.replace(")", "");
                phoneNumber = phoneNumber.replace(/_/gi, "");
                phoneNumber = phoneNumber.replace(/-/gi, "");
                prospectCustomer.CallBackPhoneNumber.AreaCode = phoneNumber.substring(0, 3);
                prospectCustomer.CallBackPhoneNumber.Number = phoneNumber.substring(3, phoneNumber.length);
            }
            var emailSplit = $('#<%=EmailTextbox.ClientID %>').val().split('@');
            prospectCustomer.Email.Address = emailSplit[0];
            prospectCustomer.Email.DomainName = emailSplit[1];
            prospectCustomer.Source = "<%=ProspectCustomerSource.CallCenter %>";
            prospectCustomer.Tag = $('#<%=CallDispositionDropdown.ClientID %>').val();

            if (Number('<%= CustomerId %>') > 0) {
                prospectCustomer.CustomerId = '<%= CustomerId %>';
            }
            prospectCustomer.IsConverted = false;
            prospectCustomer.Status = '<%= (long)ProspectCustomerConversionStatus.NotConverted %>';         
            return prospectCustomer;
        }

        function OnProspectSaveComplete(result) {
            alert("Thanks again for the participation. We will get back to you soon!");
            if (isCallStarted!='' && isCallStarted == 'No')
                CallNotes();
        }


        function OnProspectGetComplete(result) {
            if (result.d != null) {
                prospectCustomer = result.d;
                prospectCustomer.CreatedOn = dateFormat(Date(prospectCustomer.CreatedOn), "mm/dd/yyyy hh:MM:ss tt");
                if (prospectCustomer.BirthDate != null)
                    prospectCustomer.BirthDate = correctDateExpression(prospectCustomer.BirthDate);
                if (prospectCustomer.ConvertedOnDate != null)
                    prospectCustomer.ConvertedOnDate = null;
                if (prospectCustomer.ContactedDate != null)
                    prospectCustomer.ContactedDate = DateDeserialize(prospectCustomer.ContactedDate);
                if (prospectCustomer.TagUpdateDate != null)
                    prospectCustomer.TagUpdateDate = DateDeserialize(prospectCustomer.TagUpdateDate);

                prospectCustomer.IsConverted = false;
            }
          
            var prostecCust = $.toJSON(GetCurrentProspectCustomer());
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "/App/Controllers/ProspectCustomerController.asmx/SaveProspectCustomer",
                data: "{'prospectCustomer':" + prostecCust + "}",
                success: OnProspectSaveComplete
            });
        }
    </script>
</asp:Content>

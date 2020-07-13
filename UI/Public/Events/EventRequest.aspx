<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="EventRequest.aspx.cs" Inherits="Falcon.App.UI.Public.Events.EventRequest" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Sales.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="/Content/JavaScript/querystring.js" type="text/javascript"></script>
<script src="/Content/JavaScript/validations.js?v=<%=DateTime.Now.Ticks %>" type="text/javascript"></script>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryMaskInput="true" />

<script type="text/javascript" language="javascript">

    $(document).ready(function () {
        $('.mask-phone').mask('(999)-999-9999');
    });


    function getQueryString() {
        var qs = new Querystring();
        var url = qs.get("z");
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
        "Source": "<%=ProspectCustomerSource.Online %>",
        "Tag": "<%=ProspectCustomerTag.NotServicedZip %>",
        "SourceCodeId": "",
        "MarketingSource": "",
        "CustomerId": "",
        "ConvertedOnDate": ""
    };

    function validateProspectInput() {

        if (document.getElementById("ProspectEmail").value != '')
            if (!validateEmail(document.getElementById("ProspectEmail"), "email "))
            { return false; }

        if ((document.getElementById("ProspectFirstName").value == '') || (document.getElementById("ProspectLastName").value == '') || (document.getElementById("ProspectPhoneNumber").value == '')) {
            alert("Your complete name along with your phone number is required so that we can contact you!");
            return false;
        }
        return true;
    }

    function SaveProspect() {
        // debugger;
        if (!validateProspectInput()) return false;

        var prostecCust = $.toJSON(GetCurrentProspectCustomer());

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/App/Controllers/ProspectCustomerController.asmx/SaveProspectCustomer",
            data: "{'prospectCustomer':" + prostecCust + "}",
            success: OnProspectSaveComplete,
            error: function (a, b, c) {
                alert("Error!!!");
            }
        });
    }

    function GetCurrentProspectCustomer() {
        prospectCustomer.FirstName = document.getElementById("ProspectFirstName").value;
        prospectCustomer.LastName = document.getElementById("ProspectLastName").value;
        prospectCustomer.Address.Country = "USA";
        prospectCustomer.Address.ZipCode.Zip = getQueryString();
        var phoneNumber = document.getElementById("ProspectPhoneNumber").value;
        if (phoneNumber != '') {
            phoneNumber = phoneNumber.replace("(", "");
            phoneNumber = phoneNumber.replace(")", "");
            phoneNumber = phoneNumber.replace(/_/gi, "");
            phoneNumber = phoneNumber.replace(/-/gi, "");
            prospectCustomer.CallBackPhoneNumber.AreaCode = phoneNumber.substring(0, 3);
            prospectCustomer.CallBackPhoneNumber.Number = phoneNumber.substring(3, phoneNumber.length);
        }
        var emailSplit = document.getElementById("ProspectEmail").value.split('@');
        prospectCustomer.Email.Address = emailSplit[0];
        prospectCustomer.Email.DomainName = emailSplit[1];
        return prospectCustomer;
    }

    function OnProspectSaveComplete(result) {//debugger;
        alert("Thanks again for the participation. We will get back to you soon!");
    }

</script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%-- Header Image --%>

    <div> 
        Dear Valued  <%= IoC.Resolve<ISettings>().CompanyName %> Customer,
        <p>
            At this time we do not have a  <%= IoC.Resolve<ISettings>().CompanyName %> event in your zip code however we are constantly
            updating our locations and would be happy to contact you by email or phone when
            our next event will be in your area.</p>
        <p>
            Please enter your First name, Last name, e-mail address, <b>and/or</b> your phone
            number below.</p>
        <p />
        <table width="75%" border="0px" style="margin-left: 10px">
            <tr>
                <td>
                    First : <span class="reqiredmark"><sup>*</sup></span>
                </td>
                <td>
                    <input type="text" id="ProspectFirstName" />
                </td>
                <td>
                    Last : <span class="reqiredmark"><sup>*</sup></span>
                </td>
                <td>
                    <input type="text" id="ProspectLastName" />
                </td>
            </tr>
            <tr>
                <td>
                    Phone : <span class="reqiredmark"><sup>*</sup></span>
                </td>
                <td>
                    <input type="text" id="ProspectPhoneNumber" class="mask-phone" />
                </td>
                <td>
                    Email :
                </td>
                <td>
                    <input type="text" id="ProspectEmail" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <input id="SavePropspect" type="button" value="Yes, Contact me when you have an event in my area!"
                        onclick="return SaveProspect();" />
                </td>
            </tr>
             <tr>
                <td colspan="4" align="center">
                    You may also contact our customer service department at  <%= IoC.Resolve<ISettings>().PhoneTollFree %> .
                </td>
            </tr>
        </table>
    </div>
    

    <%-- Search Again --%>
    <div style="margin: 10px; padding: 5px;">
        <h3>
            Did not find the Event you were looking for?</h3>
        <h4>
            <a href="/">&lt;&lt; Search Again with a different zip code</a></h4>
    </div>

</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TecnicianManualEntry.Master"
    EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AuditResultEntry.aspx.cs"
    Inherits="Falcon.App.UI.App.Franchisee.Technician.AuditResultEntry" Title="Audit Results" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Application.Extension" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Users.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/Config/Content/Controls/Results/TestSectionContainer.ascx"
    TagName="_TestSection" TagPrefix="uc" %>
<%@ Register Src="~/Config/Content/Controls/Results/BasicBiometric.ascx"
    TagName="_BasicBiometric" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="Message" TagPrefix="uc10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:_jQueryToolKit ID="ucJquery" IncludeAjax="true" runat="server" IncludeJQueryThickBox="true"
        IncudeJQueryJTip="true" IncludeJQueryUI="true" IncludeJTemplate="true" IncludeJQueryMaskInput="true" />
    <script type="text/javascript" src="/Scripts/Video/video.js"></script>
    <link href="/Scripts/Video/video-js.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/PrimaryCarePhysicianFactory.js"></script>
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/EditResult.js"></script>
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/JSonHelper.js"></script>
    <script type="text/javascript" src="/Scripts/json2.min.js"></script>
    <script type="text/javascript" src="/Scripts/flowplayer-3.2.6.js"></script>
    <script type="text/javascript">

        var criticalTestIds = [];
       

        var primaryCarePhysicianData = null;
        $(document).ready(function () {
            if ('<%=IsMedicare%>'=='<%= Boolean.TrueString %>') {
                $('.topintercontainer').hide();
                $('.customerdetails').hide();
                $('.rgtprt').hide();
                $('.footerttxt').hide();
                $('.remove-for-medicare').hide(); 
                //$("span[id*=priorityInQueue]").hide();
                //$('#PriorityInQueueCheckboxDiv').hide();
            }

            $('.ddl-pcpcountry').change(function () {

                PrimaryCarePhysicianFactory.setStateData();
            });

            $("#pcpCityInputText").keyup(function () {
                $("#pcpresult").empty();

                var searchString = $("#pcpCityInputText").val();
                    
                if (searchString.length < 3) {
                    $("#pcpresult").hide();
                    return;
                } 
                        
                var parameter = "{'prefixText':'" + searchString + "'";
                parameter += ",'stateName':'" + "" + "'}";
                var cityByStateUrl = '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByStateAndPrefixText")%>';

                InvokeService(cityByStateUrl, parameter, PrimaryCarePhysicianFactory.CityData);
            });
                
            $('.ddl-pcpMailingcountry').change(function () {
                PrimaryCarePhysicianFactory.setMailingState();
            });

            $("#pcpMailingCityInputText").keyup(function () {
                $("#pcpmailingresult").empty();

                var searchString = $("#pcpMailingCityInputText").val();

                if (searchString.length < 3) {
                    $("#pcpmailingresult").hide();
                    return;
                }

                var parameter = "{'prefixText':'" + searchString + "'";
                parameter += ",'stateName':'" + "" + "'}";
                var cityByStateUrl = '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByStateAndPrefixText")%>';

                InvokeService(cityByStateUrl, parameter, PrimaryCarePhysicianFactory.mailingCityData);
            });

        });
    </script>
    <script language="javascript" type="text/javascript">

        function OpenPopUp(title, width, pageUrl, height) {
            if (height == null) height = 700;

            var windowHeight = $(window).height();
            if (Number(windowHeight) <= Number(height))
                height = Number(windowHeight) - 40;

            tb_show(title, pageUrl + '&keepThis=true&TB_iframe=true&height=' + height + '&width=' + width + '&modal=true', false);
        }

        function ClosePopUp() {
            parent.top.tb_remove();
        }
        var fileTypeImage = '<%= (int)FileType.Image %>';

        // -----------------------------
        function getSelectionStart(o) {
            //debugger
            if (o.createTextRange) {
                var r = document.selection.createRange().duplicate();
                r.moveEnd('character', o.value.length);
                if (r.text == '') return o.value.length;
                return o.value.lastIndexOf(r.text);
            } else return o.selectionStart;
        }

        function KeyPress_NumericAllowedOnly(evt) {
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            var selIndex = getSelectionStart(InpObject);
            if (((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || (key >= 37 && key <= 40) || ((key == 109 || key == 189) && selIndex == 0) || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                return true;
            }

            return false;
        }

        function KeyPress_DecimalAllowedOnly(evt) {

            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                if (key == 46 || key == 110 || key == 190) {
                    if (InpObject.value.indexOf(".") >= 0) return false;
                }
                return true;
            }
            return false;
        }

        function KeyPress_DecimalAllowedOnly_withsigns(evt) {

            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            var selIndex = getSelectionStart(InpObject);

            if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || ((key == 109 || key == 173 || key == 189) && selIndex == 0) || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                if (key == 46 || key == 110 || key == 190) {
                    if (InpObject.value.indexOf(".") >= 0) return false;
                }
                return true;
            }
            return false;
        }

    </script>
    <script language="javascript" type="text/javascript">

        var fileTypeImage = '<%= (int)FileType.Image %>';
        var readingSourceManual = "<%= (short)ReadingSource.Manual %>";
        var currentUser = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>';
        var currentDate = '<%= DateTime.Now %>';

        var statusComplete = '<%= TestResultStatus.Complete %>';
        var statusIncomplete = '<%= TestResultStatus.Incomplete %>';


        function CheckElevatedPP(pulsePressureValue) {
            var bolChecked = false;
            if (pulsePressureValue >= 60) bolChecked = true;

            if ($('.asiDiv:visible').length > 0) {
                ASIAutomateElevatedPP(bolChecked);
            }

            if ($('.padDiv:visible').length > 0) {
                PADAutomateElevatedPP(bolChecked);
            }

            if ($('.AwvAbiDiv:visible').length > 0) {
                AwvAbiAutomateElevatedPP(bolChecked);
            }
        }

        function OnBlurPulsePressure(evt) {
            var pulsePressureValue = $("#" + (evt.srcElement ? evt.srcElement.id : evt.currentTarget.id)).val();

            $(".pressurereading-pulsepressure").each(function () {
                $(this).val(pulsePressureValue);
            });

            CheckElevatedPP(pulsePressureValue);
        }

        function OnBlurPulse(evt) {
            var pulseValue = $("#" + (evt.srcElement ? evt.srcElement.id : evt.currentTarget.id)).val();

            $(".pressurereading-pulse").each(function () {
                $(this).val(pulseValue);
            });
        }
    </script>
    <script language="javascript" type="text/javascript">
        var customerData = null;
        var primaryCarePhysicianData = null;
        function SetCustomerData(customer) {            
            customer.DateOfBirth = correctDateExpression(customer.DateOfBirth);
            customer.LastLoggedInAt = correctDateExpression(customer.LastLoggedInAt);

            customerData = customer;
            $("#FirstNameInputText").val(customer.FullName.FirstName);
            $("#MiddleNameInputText").val(customer.FullName.MiddleName);
            $("#LastNameInputText").val(customer.FullName.LastName);

            if (customer.CustomerProfile.AcesId != null && customer.CustomerProfile.AcesId != "")
                $("#acesIdInputText").val(customer.CustomerProfile.AcesId);
            else
                $("#acesIdInputText").val("N/A");

            $('#CustomerNameAnchor #labelName').text(customer.FullName.FullName + " (" + customer.CustomerProfile.CustomerId + ")");

            $('#AddressInputText').val(customer.Address.StreetAddressLine1);
            $('#StreetAddressLine2').val(customer.Address.StreetAddressLine2);
            $('#CityInputText').val(customer.Address.City);


            $('.ddl-country option').each(function () {
                if ($(this).val() == customer.Address.CountryId)
                    $(this).attr("selected", true);
            });

            changeStateforCountry();

            $('.ddl-states option').each(function () {
                if ($(this).val() == customer.Address.StateId)
                    $(this).attr("selected", true);
            });

            $('#ZipInputText').val(customer.Address.ZipCode);
            $('#PhoneInputText').val(customer.HomeNumber.DomesticPhoneNumber);
            $('#EmailInputText').val(customer.Email);

            if (customer.CustomerProfile.Height != null) {
                var heightFeet = customer.CustomerProfile.Height.Feet;
                var heightInch = customer.CustomerProfile.Height.Inches;

                $('#HeightUnitsFeetInputText').val(heightFeet);
                $('#HeightUnitsInchInputText').val(heightInch);
            }

            if (customer.CustomerProfile.Weight != null) $('#WeightInputText').val(customer.CustomerProfile.Weight.Pounds);

            if (customer.CustomerProfile.Waist != null) $('#WaistInputText').val(customer.CustomerProfile.Waist);

            if ("<%= IsHealthPlanEvent%>" == "<%= Boolean.TrueString%>")
            {
                $('#dvHeightWeight').css('display','none');
                $('#spWaist').css('display','none');
            }

            if (customer.DateOfBirth != null)
                $('#DOBInputText').val((customer.DateOfBirth.getMonth() + 1) + "/" + customer.DateOfBirth.getDate() + "/" + customer.DateOfBirth.getFullYear());

            //customer.CustomerProfile.Gender == "<%= (int)Gender.Male %>" ? $('#GenderMaleInputRadio').attr('checked', true) : $('#GenderFemaleInputRadio').attr('checked', true);

            if (customer.CustomerProfile.Gender == "<%= (int)Gender.Male %>")
                $('#GenderMaleInputRadio').attr('checked', true);
            else if (customer.CustomerProfile.Gender == "<%= (int)Gender.Female %>")
                $('#GenderFemaleInputRadio').attr('checked', true);

            $('.race-radio').each(function () {
                if (customer.CustomerProfile.Race == $(this).val()) {
                    $(this).attr('checked', true);
                }
                else {
                    $(this).attr('checked', false);
                }
            });
        }

        var zipId = "0";
        var cityId = "0";

        function GetCustomerData() {
            var customer = customerData;
            var race = '-1';
            $('.race-radio').each(function () {
                if ($(this).attr('checked')) {
                    race = $(this).val();
                }
            });

            var height = Number($.trim($('#HeightUnitsFeetInputText').val())) * 12 + Number($.trim($('#HeightUnitsInchInputText').val()));
            if (height > 0) {
                customer.CustomerProfile.Height = { 'TotalInches': height };
            }
            else {
                customer.CustomerProfile.Height = null;
            }

            var weight = $('#WeightInputText').val();
            if (!isNaN(weight) && Number(weight) > 0) {
                customer.CustomerProfile.Weight = { 'Pounds': Number(weight) };
            }
            else {
                customer.CustomerProfile.Weight = null;
            }

            var waist = $('#WaistInputText').val();
            if (!isNaN(waist) && Number(waist) > 0) {
                customer.CustomerProfile.Waist = Number(waist);
            }
            else {
                customer.CustomerProfile.Waist = null;
            }

            customer.CustomerProfile.Race = race;

            //customer.CustomerProfile.Gender = $('#GenderMaleInputRadio').attr('checked') ? "<%= (int)Gender.Male %>" : "<%= (int)Gender.Female %>";

            if ($('#GenderMaleInputRadio').attr('checked'))
                customer.CustomerProfile.Gender = "<%= (int)Gender.Male %>";
            else if ($('#GenderFemaleInputRadio').attr('checked'))
                customer.CustomerProfile.Gender = "<%= (int)Gender.Female %>";
            else
                customer.CustomerProfile.Gender = "-1";

        var stringEmail = $('#EmailInputText').val();
        if (stringEmail.length > 0) {
            var emailParts = stringEmail.split("@");
            if (emailParts.length == 2) {
                customer.Email = stringEmail;
            }
        }

        customer.FullName = {
            "FirstName": $("#FirstNameInputText").val(),
            "LastName": $("#LastNameInputText").val(),
            "MiddleName": $("#MiddleNameInputText").val()
        };

        customer.DateOfBirth = $('#DOBInputText').val();

        customer.Address.StreetAddressLine1 = $('#AddressInputText').val();
        customer.Address.StreetAddressLine2 = $('#StreetAddressLine2').val();
        customer.Address.City = $('#CityInputText').val();
        customer.Address.CountryId = $('.ddl-country option:selected').val();
        customer.Address.StateId = $('.ddl-states option:selected').val();
        customer.Address.ZipCode = $('#ZipInputText').val();

        var phoneNumber = $('#PhoneInputText').val();
        if (phoneNumber != '') {
            phoneNumber = phoneNumber.replace("(", "");
            phoneNumber = phoneNumber.replace(")", "");
            phoneNumber = phoneNumber.replace(/_/gi, "");
            phoneNumber = phoneNumber.replace(/-/gi, "");
            customer.HomeNumber = { "PhoneNumberType": "<%= (int)Falcon.App.Core.Enum.PhoneNumberType.Home %>", "Number": phoneNumber };
        }

        customer.DataRecorderMetaData = null;
        return customer;
    }




    $(function () {
        var presentEmail;
        $('#EmailInputText').focus(function () {
            presentEmail = $.trim($(this).val());
        });
        $('#EmailInputText').change(function () {
            if (presentEmail != $.trim($(this).val())) {
                var parameter = "{'customerId':'" + "<%=CustomerId%>" + "'";
                parameter += ",'emailAddress':'" + $.trim($(this).val()) + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/ValidateUniqueEmailAddress")%>';
                InvokeService(messageUrl, parameter, function (result) { if (!result.d) { alert('Email Id already exists. Please provide unique email id.'); $(this).val(presentEmail); } });
            }
        });
    });

    function checkOnGenderChange(isMale) {        
        try {
            checkHdlFindingsForGenderChange(isMale);               
        }
        catch (e) { }

        try {
            checkHemoglobinFindingsForGenderChange(isMale);
        }
        catch (e) { }

        try {
            checkUrineMicroalbuminFindingsForGenderChange(isMale);
        }
        catch (e) { }

    }

    </script>
    <script language="javascript" type="text/javascript">

        function changeStateforCountry() {
            var valueSelectedCountry = $(".ddl-country option:selected").val();
            if (stateCountryList == null || stateCountryList == undefined) return;

            $(".ddl-states").html("");

            $(".ddl-states").append("<option value='0'> -- Select -- </option>");
            $.each(stateCountryList, function () {
                if (this.CountryId == valueSelectedCountry) {
                    $(".ddl-states").append("<option value='" + this.Id + "'> " + this.Name + " </option>");
                }
            });
        }

        $(document).ready(function () {
            fillConductedBy();
           
        });
       
    </script>
    <style type="text/css">
        #results, #pcpresult, #pcpmailingresult {
            position: absolute;
            float: left;
            display: none;
            background-color: #fff;
            height: 100px;
            overflow-y: auto;
            overflow-x: hidden;
            font-size: 11px;
            border: solid 1px #7F9DB9;
        }

        #pcpResults, #pcpmailingresult {
            position: absolute;
            float: left;
            display: none;
            background-color: #fff;
            height: 100px;
            overflow-y: auto;
            overflow-x: hidden;
            font-size: 11px;
            border: solid 1px #7F9DB9;
        }

        .searchresult, .search-pcp-result, .search-pcp-mailing-result {
            height: 20px;
            width: 200px;
            border-bottom: 1px solid #7F9DB9;
            vertical-align: top;
            background: #f5f5f5;
        }

        .small {
            font: normal 9px arial;
        }

        .searchresult:hover, .search-pcp-result:hover, .search-pcp-mailing-result:hover {
            background-color: #ddd;
            cursor: hand;
        }

        .match {
            background-color: Yellow;
        }

        .jdbox {
            float: left;
            width: 350px;
            margin-top: 5px;
        }

        .jdbox-validations {
            float: left;
            width: 560px;
            margin-top: 5px;
        }

        .jdbox-validation-message {
            float: left;
            width: 540px;
            margin-top: 5px;
            padding-left: 10px;
            padding-right: 10px;
            min-height: 70px;
        }

        .jdbox-validation-button {
            float: left;
            width: 560px;
            margin-top: 5px;
            border-top: 1px solid;
            padding-top: 5px;
        }

        .button {
            background: #5996b5 url(/App/Images/btn-bg.gif) repeat-x top;
            height: 25px;
            color: #fff;
            font: bold 12px arial;
            border: 0;
            padding: 0 3px;
        }

        a.medical-history:hover {
            font-weight: bold;
        }

        a.medical-history {
            font-size: 14px;
            text-decoration: none;
        }

        a.checklist-form:hover {
            font-weight: bold;
        }

        a.checklist-form {
            font-size: 14px;
            text-decoration: none;
        }

        .btn-skipnext {
            background: -moz-linear-gradient(center top, #5D99B5, #5D99B5) repeat scroll 0 0 transparent;
            background-color: #5D99B5;
            margin-right: 3px;
            font-weight: 500;
            color: #ffffff;
            height: 24px;
        }

        .critical-question {
            margin-top: 5px;
            margin-bottom: 5px;
        }
    </style>
    <asp:DropDownList runat="server" ID="Conductedby" EnableViewState="false" CssClass="conducted-by"
        Style="display: none;">
        <asp:ListItem Text="-- Conducted By --" Value="0"></asp:ListItem>
    </asp:DropDownList>
    <div id="LoadingGifContainerDiv" class="loading" style="clear: both">
    </div>
    <div id="MainContainerDiv" class="container_all" style="display: none">
        <div runat="server" id="PhysicianCommentsDiv" visible="false" class="contentrow">
            <uc10:Message runat="server" ID="PhysicianCommentsMessageBox" />
        </div>
        <div id="CustomerReloadGifContainerDiv" class="loading customer-info-toggle" style="clear: both; display: none">
        </div>
        <div class="customerdetails customer-info-toggle">
            <div style="float: left;">
                <h1>
                    <span id="HeadingSpan" runat="server">Results Pre Audit </span>
                </h1>
            </div>
            <div style="float: right;">
                <div class="left">
                    <a class="medical-history" href="javascript:OpenMedicalHistory(); void(0);">(Medical History) </a>
                </div>
                <div class="left checklist-form">
                    &nbsp;|&nbsp; <a class="checklist-form" href="javascript:OpenCheckListForm(); void(0);">(Check List Form) </a>
                </div>
            </div>
            <div class="contentrow">
                <img id="CustomerDataToggleImg" src="/App/Images/minus-signs.gif" style="cursor: pointer;"
                    alt="" />
                <label class="labels">
                    Name: <span><a href="javascript:void(0);" onclick="OpenCustomerWindow();" id="CustomerNameAnchor">
                        <label id="labelName" style="cursor: pointer">
                        </label>
                    </a></span>
                </label>
                <input type="text" id="NameBlankLineInput" class="input_bdrbot name-editable-class"
                    style="display: none; width: 270px" />
                <span class="name-editable-class">
                    <input type="text" id="FirstNameInputText" class="input_bdrbot" style="width: 135px;" />
                    <input type="text" id="MiddleNameInputText" class="input_bdrbot" style="width: 110px;" />
                    <input type="text" id="LastNameInputText" class="input_bdrbot" style="width: 135px;" /></span>
            </div>
            <div id="infoShowHide" class="contentrow">
                <div class="contentrow">
                    <div class="left_info">
                        <div class="lrow">
                            <div class="left" style="width: 50%;">
                                <label class="labels">
                                    ACES Id:</label>
                                <input type="text" id="acesIdInputText" readonly="readonly" class="input_bdrbot" style="width: 153px" />
                            </div>
                        </div>

                        <div class="lrow">
                            <div class="left" style="width: 50%;">
                                <label class="labels">
                                    Address:</label>
                                <input type="text" id="AddressInputText" class="input_bdrbot" style="width: 153px" />
                            </div>
                            <div class="left" style="text-align: right;">
                                <label class="labels">
                                    Suite,Apt,etc:</label>
                                <input type="text" id="StreetAddressLine2" class="input_bdrbot" style="width: 140px" />
                            </div>
                        </div>
                        <div class="lrow" style="margin-top: 3px;">
                            <div class="left" style="width: 50%;">
                                <label class="labels2">
                                    City:</label>
                                <input type="text" id="CityInputText" class="input_bdrbot" style="width: 180px;" /><br />
                                <div id="results" class="">
                                </div>
                            </div>
                            <div class="left" style="text-align: right;">
                                <label class="labels2">
                                    Country:</label>
                                <asp:DropDownList ID="CountryDropDown" runat="server" Width="175px" CssClass="ddl-country">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="lrow" style="margin-top: 3px;">
                            <div class="left" style="width: 50%;">
                                <label class="labels2">
                                    State:&nbsp;</label><asp:DropDownList ID="StateDropDown" runat="server" Width="175px"
                                        CssClass="ddl-states">
                                    </asp:DropDownList>
                            </div>
                            <div class="left">
                                <label class="labels2">
                                    Zip:</label>
                                <input type="text" id="ZipInputText" class="input_bdrbot" style="width: 165px;" />
                            </div>
                        </div>
                        <div class="lrow">
                            <label class="labels">
                                Phone:</label>
                            <input type="text" id="PhoneInputText" class="input_bdrbot mask-phone" style="width: 405px;" />
                        </div>
                        <div class="lrow">
                            <label class="labels">
                                Email:</label>
                            <input type="text" id="EmailInputText" class="input_bdrbot" style="width: 410px;" />
                        </div>

                        <div class="lrow" id="dvHeightWeight">
                            <label class="labels">
                                Height:</label>
                            <input type="text" id="HeightUnitsFeetInputText" class="input_bdrbot" style="width: 40px;" />ft
                            <input type="text" id="HeightUnitsInchInputText" class="input_bdrbot" style="width: 40px;" />inch
                            <label class="labels" style="padding-left: 20px">
                                <strong>Weight:</strong></label>
                            <input type="text" id="WeightInputText" class="input_bdrbot" style="width: 110px;" />lbs
                        </div>
                        <div class="lrow">
                            <label class="labels">
                                Date of Birth:</label>
                            <input type="text" id="DOBInputText" class="input_bdrbot date-picker-dob" style="width: 85px;" />
                            <span id="spWaist">
                                <label class="labels" style="padding-left: 20px">
                                    <strong>Waist:</strong></label>
                                <input type="text" id="WaistInputText" class="input_bdrbot" style="width: 110px;" />inch
                            </span>
                        </div>
                        <div class="lrow">
                            <label class="labels">
                                Gender:</label>
                            <span class="checkbox">
                                <input type="radio" name="Gender" id="GenderMaleInputRadio" onclick="checkOnGenderChange(true);" />Male</span>
                            <span class="checkbox">
                                <input type="radio" name="Gender" id="GenderFemaleInputRadio" onclick="checkOnGenderChange(false);" />Female</span>
                        </div>

                    </div>
                    <div class="rgt_info">
                        <div class="rrow">
                            <label class="labels">
                                Race:</label>
                            <span class="checkbox">
                                <input type="radio" name="Race" id="RaceCaucasianInputRadio" class="race-radio" value="<%= (int)Race.Caucasian %>" />
                                Caucasian</span> <span class="checkbox">
                                    <input type="radio" name="Race" id="RaceAfricanAmericanInputRadio" class="race-radio"
                                        value="<%= (int)Race.AfricanAmerican %>" />
                                    AfricanAmerican</span> <span class="checkbox">
                                        <input type="radio" name="Race" id="RaceHispanicInputRadio" class="race-radio" value="<%= (int)Race.Hispanic %>" />
                                        Hispanic</span>
                        </div>
                        <div class="rrow">
                            <label style="visibility: hidden">
                                <strong>Race:</strong></label>
                            <span class="checkbox">
                                <input type="radio" name="Race" id="RaceAsianInputRadio" class="race-radio" value="<%= (int)Race.Asian %>" />
                                Asian</span>
                            <span class="checkbox">
                                <input type="radio" name="Race" id="RaceNativeAmericanInputRadio" class="race-radio" value="<%= (int)Race.NativeAmerican %>" />
                                NativeAmerican
                            </span>
                            <span class="checkbox" style="width: 130px">
                                <input type="radio" name="Race" id="RaceHispanicorLatino" class="race-radio" value="<%= (int)Race.Latino %>" />
                                Latino
                            </span>

                        </div>
                        <div class="rrow">
                            <label style="visibility: hidden"><strong>Race:</strong></label>
                            <span class="checkbox">
                                <input type="radio" name="Race" id="RaceDeclinesToReport" class="race-radio" value="<%= (int)Race.DeclinesToReport %>" />Declines to report
                            </span>
                            <span class="checkbox">
                                <input type="radio" name="Race" id="RaceOtherInputRadio" class="race-radio" value="<%= (int)Race.Other %>" />Other
                            </span>
                            <span class="checkbox">
                                <input type="radio" name="Race" id="RaceNoneInputRadio" class="race-radio" value="<%= (int)Race.None %>" />None
                            </span>
                        </div>
                        <h3 class="pcpInfo" style="margin-left: 0px;">Primary Care Physician Info</h3>
                        <div class="rrow pcpInfo">
                            <div class="left" style="width: 50%;">
                                <label class="labels">First Name</label>
                                <input type="text" id="pcpFirstNameInputText" class="input_bdrbot" style="width: 135px;" />
                            </div>
                            <div class="left" style="width: 50%;">
                                <label class="labels">Last Name</label>
                                <input type="text" id="pcpLastNameInputText" class="input_bdrbot" style="width: 135px;" />
                            </div>
                        </div>
                        <div class="rrow pcpInfo">
                            <div class="left" style="width: 50%;">
                                <label class="labels">
                                    PCP Address:</label>
                                <input type="text" id="pcpAddressInputText" class="input_bdrbot" style="width: 117px" />
                            </div>
                            <div class="left" style="text-align: right;">
                                <label class="labels">
                                    Suite,Apt,etc:</label>
                                <input type="text" id="pcpStreetAddressLine2" class="input_bdrbot" style="width: 110px" />
                            </div>
                        </div>
                        <div class="rrow pcpInfo" style="margin-top: 3px;">
                            <div class="left" style="width: 50%;">
                                <label class="labels2">
                                    City:</label>
                                <input type="text" id="pcpCityInputText" class="input_bdrbot" style="width: 180px;" /><br />
                                <div id="pcpresult" class="">
                                </div>
                            </div>
                            <div class="left" style="text-align: right;">
                                <label class="labels2">
                                    Country:</label>
                                <asp:DropDownList ID="pcpCountryDropDown" runat="server" Width="150px" CssClass="ddl-pcpcountry">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="rrow pcpInfo" style="margin-top: 3px;">
                            <div class="left" style="width: 50%;">
                                <label class="labels2">
                                    State:&nbsp;</label><asp:DropDownList ID="pcpStateDropDown" runat="server" Width="175px"
                                        CssClass="ddl-pcpStates">
                                    </asp:DropDownList>
                            </div>
                            <div class="left">
                                <label class="labels2">
                                    Zip:</label>
                                <input type="text" id="pcpZipInputText" class="input_bdrbot" style="width: 165px;" />
                            </div>
                        </div>
                        <div class="pcpInfo">
                            <div style="margin-bottom: 5px; margin-top: 5px;">
                                <input type="checkbox" class="sameAsPracticeAddress" />
                                <b>Has same mailing address</b>
                            </div>
                            <div class="mailingAddress">
                                <div class="rrow">
                                    <div class="left" style="width: 50%;">
                                        <label class="labels">Mailing Address:</label>
                                    </div>
                                </div>
                                <div class="rrow">
                                    <div class="left" style="width: 50%;">
                                        <label class="labels">
                                            Address 1:</label>
                                        <input type="text" id="pcpMailingAddress1" class="input_bdrbot" style="width: 117px" />
                                    </div>
                                    <div class="left" style="text-align: right;">
                                        <label class="labels">
                                            Suite,Apt,etc:</label>
                                        <input type="text" id="pcpMailingAddress2" class="input_bdrbot" style="width: 110px" />
                                    </div>
                                </div>
                                <div class="rrow" style="margin-top: 3px;">
                                    <div class="left" style="width: 50%;">
                                        <label class="labels2">
                                            City:</label>
                                        <input type="text" id="pcpMailingCityInputText" class="input_bdrbot" style="width: 180px;" /><br />
                                        <div id="pcpmailingresult" class="">
                                        </div>
                                    </div>
                                    <div class="left" style="text-align: right;">
                                        <label class="labels2">
                                            Country:</label>
                                        <asp:DropDownList ID="pcpMailingcountryDropDown" runat="server" Width="150px" CssClass="ddl-pcpMailingcountry">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="rrow" style="margin-top: 3px;">
                                    <div class="left" style="width: 50%;">
                                        <label class="labels2">
                                            State:&nbsp;</label><asp:DropDownList ID="pcpMailingStatesDropDown" runat="server" Width="175px"
                                                CssClass="ddl-pcpMailingStates">
                                            </asp:DropDownList>
                                    </div>
                                    <div class="left">
                                        <label class="labels2">
                                            Zip:</label>
                                        <input type="text" id="pcpMailingZipInputText" class="input_bdrbot" style="width: 165px;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="rrow pcpInfo" style="margin-top: 3px;">
                            <div class="left">
                                <label class="labels2" id="pcpAddressVerifyMessagelbl"></label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="contentrow save-button-container" style="text-align: right; margin-top: 15px; padding-top: 8px; border-top: solid 1px #F37C00; margin-bottom: 0px;">

            <div id="approveDivtop" runat="server" class="rgt">
                <img src="/App/Images/approveallnnext-btn.gif" id="img1" class="approve-all-next"
                    onclick="SaveEvent(true);" alt="Approve All and Next" style="cursor: pointer;" />
                <img src="/App/Images/approveallnclose-btn.gif" id="img2" class="approve-all-close"
                    onclick="SaveEvent(false);" alt="Approve All and Close" style="cursor: pointer;" />
            </div>
            <div id="saveDivTop" runat="server" class="rgt">
                <img src="/App/Images/save-n-next.gif" id="img3" onclick="SaveEvent(true);" class="save-all-next  remove-for-medicare"
                    alt="Save All and Next" style="cursor: pointer;" />
                <img src="/App/Images/save-n-close-gif.gif" id="img4" onclick="SaveEvent(false);"
                    class="save-all-close" alt="Save All and Close" style="cursor: pointer;" />
            </div>
            <div class="rgt">
                <button name="btnskipandnext-top" class="btn-skipnext  remove-for-medicare" id="btnskipandnext-top" onclick="skipAndNext(); return false;"
                    value="Skip and Next">
                    Skip and Next
                </button>
            </div>
            <div id="updateWithCorrectionDivTop" runat="server" class="rgt" visible="false">
                <input type="button" value="Save and Send to Physician" class="button save-and-sendtophysician"
                    onclick="SaveEvent(false);" />
            </div>
            <div class="rgt remove-for-medicare" style="margin-right: 3px">
                <img id="Img5" src="/App/Images/cancel-btn.gif" onclick="onCancel();" />
            </div>
        </div>
        <div class="lrow showHideFastingStatus" style="float: left">
            <label class="labels">
                Is Customer On Fast? :
            </label>
            <input type="radio" name="CustomerOnFast" id="customerOnFastYesRadio" onclick="checkOnCustomerFastChange(true);" />Yes
                <input type="radio" name="CustomerOnFast" id="customerOnFastNoRadio" onclick="checkOnCustomerFastChange(false);" />No
            <input type="hidden" id="customerOnFastHidden" />
        </div>
        <div id="div5" class="saveWaitAnimation save-button-container contentrow" style="display: none;">
        </div>
        <div id="PriorityInQueueReasonDisplayDiv" runat="server" style="margin: 5px; clear: both; display: none;" class="contentrow">
            <div class="ui-state-highlight ui-corner-all" style="padding: 6px; margin-bottom: 10px; height: 25px; vertical-align: middle;">
                <p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span></p>
                <b><u>Reason for priority in Queue  </u>: </b>
                <div id="PriorityInQueueText" runat="server" style="display: inline;">
                </div>
                <a href="javascript:void(0)" id="updatePriorityInQueue" class="button" onclick="onClickSetPriorityInQueueEdit();" style="float: right; text-decoration: none; height: 17px; padding-top: 5px;">Update</a>
            </div>
        </div>
        <div id="revertBackNotes" runat="server" visible="False" style="margin: 5px; clear: both;" class="contentrow">
            <div class="ui-state-highlight ui-corner-all" style="padding: 6px; margin-bottom: 10px; height: 25px; vertical-align: middle;">
                <p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span></p>
                <b><u>Reason for priority in Queue  </u>: </b>
                <div id="ReasonToRevert" runat="server" style="display: inline;">
                </div>
            </div>
        </div>
        <uc:_BasicBiometric runat="server" ID="BasicBiometric" Disabled="false" />
        <%--Put the Test Section Us Here Here--%>
        <uc:_TestSection ID="TestSection" runat="server" />
        <div class="contentrow save-button-container" style="text-align: right; margin-top: 15px; padding-top: 8px; border-top: solid 1px #F37C00;">
            <div style="float: left; text-align: left;" id="PriorityInQueueCheckboxDiv">
                <input type="checkbox" id="PriorityInQueueCheckbox" runat="server" onclick="onClickSetPriorityInQueue();" />&nbsp;<b>Priority In Queue</b>
            </div>
            <div id="skipevaluationdivbottom" runat="server" visible="false" class="left">
                <input type="checkbox" id="skipevaluationcheckbox" class="skip-evaluation-checkbox"
                    onclick="onClickSkipEvaluationBox();" />
                Skip Physician's Evaluation (will not be sent to doctor)
            </div>
            <div id="approveDivbottom" runat="server" class="rgt">
                <img src="/App/Images/approveallnnext-btn.gif" id="imgApproveAllandNext" class="approve-all-next"
                    onclick="SaveEvent(true);" alt="Approve All and Next" style="cursor: pointer;" />
                <img src="/App/Images/approveallnclose-btn.gif" id="imgApproveAllandClose" class="approve-all-close"
                    onclick="SaveEvent(false);" alt="Approve All and Close" style="cursor: pointer;" />
            </div>
            <div id="saveDivbottom" runat="server" class="rgt">
                <img src="/App/Images/save-n-next.gif" id="imgSaveAllandNext" onclick="SaveEvent(true);"
                    class="save-all-next  remove-for-medicare" alt="Save All and Next" style="cursor: pointer;" />
                <img src="/App/Images/save-n-close-gif.gif" id="imgSaveAllandClose" onclick="SaveEvent(false);"
                    class="save-all-close" alt="Save All and Close" style="cursor: pointer;" />
            </div>
            <div class="rgt">
                <button name="btnskipandnext" class="btn-skipnext  remove-for-medicare" id="btnskipandnext" onclick="skipAndNext(); return false;"
                    value="Skip and Next">
                    Skip and Next
                </button>
            </div>
            <div id="updateWithCorrectionsDivbottom" runat="server" class="rgt" visible="false">
                <input type="button" value="Save and Send to Physician" class="button save-and-sendtophysician"
                    onclick="SaveEvent(false);" />
            </div>
            <div class="rgt  remove-for-medicare" style="margin-right: 3px">
                <img id="ibtnCancel" src="/App/Images/cancel-btn.gif" onclick="onCancel();" />
            </div>
        </div>
        <div id="divSaveWaitAnimation" class="saveWaitAnimation save-button-container contentrow"
            style="display: none;">
        </div>
        <input type="hidden" class="smoker-information" runat="server" id="SmokerInfo" />
        <input type="hidden" class="diabetic-information" runat="server" id="DiabeticInfo" />
    </div>
    <%--************************** Jdialog popup ****************************--%>
    <div id="ReasonForSendBackCorrectionDiv" title="Send Back For Correction" style="display: none;"
        class="jdbox">
        <div class="jdbox">
            Please enter any message for the Physician. (optional)
        </div>
        <div class="jdbox">
            <textarea id="CorrectionReasonInputText" rows="5" style="width: 340px"></textarea>
        </div>
        <div class="jdbox">
            <div class="rgt">
                <input type="button" id="CancelSendForCorrectionButton" onclick='$("#ReasonForSendBackCorrectionDiv").dialog("close");'
                    class="button" value="Cancel" />
                <input type="button" id="SaveCorrectionForPhysician" class="button" value="Save And Close"
                    onclick='SaveFranchiseeCommentsForPhysician();' />
            </div>
        </div>
    </div>
    <div id="videoplayerfortestmediadiv" style="display: none; width: 850px;" class="jdbox">
        <table cellspacing="2" style="float: left; width: 100%;">
            <tr>
                <td colspan="3" style="text-align: right; padding-bottom: 5px;">
                    <a href="#" target="_blank" id="ViewImageAnchor">View Image</a>
                </td>
            </tr>
            <tr>
                <td style='width: 40px; text-align: center; vertical-align: middle;'>
                    <img src="/App/Images/left_arrow_black.gif" alt="Previous" style="cursor: pointer;"
                        class="media-navigation-prev" onclick="onPreviousClick_MediaTraversing();" />
                </td>
                <td style='text-align: center; vertical-align: middle;' id="imgcontainer"></td>
                <td style='width: 40px; text-align: center; vertical-align: middle;'>
                    <img src="/App/Images/right_arrow_black.gif" alt="Previous" style="cursor: pointer;"
                        class="media-navigation-next" onclick="onNextClick_MediaTraversing();" />
                </td>
            </tr>
        </table>
    </div>
    <div id="preauditvalidationdiv" style="display: none;" class="jdbox-validations">
        <div class="jdbox-validation-message" id="validationmessagediv">
        </div>
        <div class="jdbox-validation-button">
            <div class="rgt">
                <input type="button" id="btncontinue" onclick='continueWithIncompleteRecords(); return false;' class="button" value="Skip Pre-Audit & Continue" />
                <input type="button" id="btncontinueWithIncompleteData" onclick='continueWithIncompleteData(); return false;' class="button" value="Continue" style="display: none;" />
                <input type="button" id="btncancel" class="button" value="Stay Back & Complete" onclick='$("#preauditvalidationdiv").dialog("close");' />
            </div>
        </div>
    </div>
    <div id="testnotperformedvalidationdiv" style="display: none;" class="jdbox-validations">
        <div class="jdbox-validation-message" id="testnotperformedvalidationmessagediv">
        </div>
        <div class="jdbox-validation-button">
            <div class="rgt">
                <input type="button" id="btncancel" class="button" value="Stay Back & Complete" onclick='$("#testnotperformedvalidationdiv").dialog("close");' />
            </div>
        </div>
    </div>
    <div id="customerCriticalDataDiv" style="display: none;">
        <div class="loading" style="clear: both">
        </div>
    </div>
    <div id="customerPriorityinQueueTestDiv" style="display: none;">
        <div class="loading" style="clear: both">
        </div>
    </div>

    <input type="hidden" id="hfCriticalTestSavedCounter" runat="server" value="0" />
    <div id="priorityInQueue-dialog" class="jdbox" style="display: none;">
        <%
            Response.WriteFile(String.Format("/Areas/Medical/Views/Results/PriorityInQueuePopup.cshtml"));
            
        %>
    </div>


    <div id="critical-question-dialog" style="display: none;">
        <input type="hidden" id="eventCustomerId" value="" />
        <div id="critical-question-div">
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Did patient fast?
                &nbsp;&nbsp;
                </span>
                <span questionid="1" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-1" value="Yes" />Yes&nbsp;&nbsp;<input type="radio" name="questionid-1" value="No" />No
                </span>
                <textarea questionid="1" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Is patient on a statin?
                &nbsp;&nbsp;
                </span>
                <span questionid="2" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-2" value="Yes" />Yes&nbsp;&nbsp;<input type="radio" name="questionid-2" value="No" />No
                </span>
                <textarea questionid="2" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Is patient on cholesterol Med?
                &nbsp;&nbsp;
                </span>
                <span questionid="3" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-3" value="Yes" />Yes&nbsp;&nbsp;<input type="radio" name="questionid-3" value="No" />No
                </span>
                <textarea questionid="3" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Was patient stable at time of transfer?
                &nbsp;&nbsp;
                </span>
                <span questionid="4" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-4" value="Yes" />Yes&nbsp;&nbsp;<input type="radio" name="questionid-4" value="No" />No
                </span>
                <textarea questionid="4" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Was pcp contacted?
                &nbsp;&nbsp;
                </span>
                <span questionid="5" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-5" value="Yes" />Yes&nbsp;&nbsp;<input type="radio" name="questionid-5" value="No" />No
                </span>
                <textarea questionid="5" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Was patient symptomatic?
                &nbsp;&nbsp;
                </span>
                <span questionid="6" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-6" value="Yes" />Yes&nbsp;&nbsp;<input type="radio" name="questionid-6" value="No" />No
                </span>
                <textarea questionid="6" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Did patient refuse transfer?
                &nbsp;&nbsp;
                </span>
                <span questionid="7" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-7" value="Yes" />Yes&nbsp;&nbsp;<input type="radio" name="questionid-7" value="No" />No
                </span>
                <textarea questionid="7" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div class="editor-row critical-question">
                <span style="float: left; width: 280px;">Where was the patient sent?
                &nbsp;&nbsp;
                </span>
                <span questionid="8" style="float: left; width: 175px;">
                    <input type="radio" name="questionid-8" value="ER Office" />ER Office&nbsp;&nbsp;<input type="radio" name="questionid-8" value="PCP Office" />PCP Office
                </span>
                <textarea questionid="8" cols="25" rows="3" style="float: left; max-height: 100px; overflow-y: scroll; resize: none;"></textarea>
            </div>
            <div style="float: right; margin-top: 10px;" class="editor-row">

                <input type="button" value="Close" onclick="closeCriticalDataDialog();" class="save-critical-question" />&nbsp;&nbsp;
                <input type="button" value="Save" class="save-critical-question" onclick="savePatientCriticalInfo();" />

                <img src="/App/Images/loading.gif" class="save-critical-question" style="display: none;" />
            </div>
        </div>
    </div>
    <%--********************** Jdialog popup end here ***********************--%>
    <script language="javascript" type="text/javascript">

        function onClickSkipEvaluationBox() {
            if ($(".skip-evaluation-checkbox").attr("checked") == false) return;

            if ($("#DefaultPhysician").length < 1 || Number($("#DefaultPhysician").val()) == 0) {
                alert("There is no default Physician associated with this Customer/Event. If you continue 'Skip Evaluation', record will not be processed further.\nOR\nUnmark the box for putting the patient in Physician queue.");
            }

            $("#<%= PriorityInQueueCheckbox.ClientID %>").attr("checked", false);
        }

        function SaveFranchiseeCommentsForPhysician() {
            var saveCommentsInvoked = false;
            if ($.trim($("#CorrectionReasonInputText").val()).length > 0) {
                InvokeServicewithErrorMethodName('/App/Controllers/ManualEntryAndAuditController.asmx/SaveCommentsForPhysician', "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'comments' : '" + $.trim($("#CorrectionReasonInputText").val()) + "', 'organizationRoleUserId' : '" + currentUser + "'}",
                    function () { SaveTestResultData(); }, function () { alert('OOPS! Some error occured.'); doNavigation(); });

                saveCommentsInvoked = true;
            }


            $("#ReasonForSendBackCorrectionDiv").dialog("close");
            $(".save-button-container").toggle();
            if (!saveCommentsInvoked) {
                SaveTestResultData();
            }
        }

        function onCloseCommentsForPhysicianBox() {
            $(".save-button-container").toggle();
            $(".save-button-container").toggle();
        }

        function OnCompleteCommentsForPhysician() { }
        function OnTimeOutCommentsForPhysician() { }
        function OnErrorCommentsForPhysician() { }

        function onClickSetPriorityInQueue() {//debugger;
            var isPriorityChecked = $("#<%= PriorityInQueueCheckbox.ClientID %>").is(":checked");
            if (isPriorityChecked) {
                $(".skip-evaluation-checkbox").attr("checked", false);
            }

            if (isPriorityChecked) {
                //$('#PriorityInQueueEventCustomerIdHidden').val(eventCustomerId);
                $("#priorityInQueue-dialog").dialog('open');
            }

        }

    </script>
    <script language="javascript" type="text/javascript">

        var wincustomerinfo = null;
        var winmedicalhistory = null;

        function SetWindowEndOfDay(entity) {
            //            if (!entity.d && $('.role-type').val() == "technician")
            //                window.open("/App/Franchisee/Technician/EndOfDayProcess.aspx?EventID=" + eventId, "EndofDay", "toolbar=no,location=no,directories=no,status=no,scrollbars=no,menubar=no,resizable=yes,width=550,height=620");
        }

        function OpenMedicalHistory() {
            winmedicalhistory = window.open("/App/Common/MedicalHistory.aspx?ReloadParent=false&ReturnPage=entry&Edit=true&CustomerID=" + customerId + "&EventId=" + eventId + "&showkyn=true", "MedicalHistory", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=980,height=500");
        }

        function OpenCustomerWindow() {
            wincustomerinfo = window.open("/App/Common/EditCustomer.aspx?OpenAsPopUp=true&ReloadParent=true&CustomerID=" + customerId, "CustomerInfo", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=820,height=500");
        }
        function OpenCheckListForm() {            
            winmedicalhistory = window.open("/Scheduling/EventCustomerList/CheckListForm?customerId="+customerId+"&eventId="+eventId+"&isAuditEntery=true", "CustomerCheckListForm", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=980,height=500");          
        }

        function CloseAllWindow() {
            if (wincustomerinfo) wincustomerinfo.close();
            if (winmedicalhistory) winmedicalhistory.close();
        }

        function ReloadCustomer(customer) {            
            $('.customer-info-toggle').toggle();
            SetCustomerData(customer);
            $('.customer-info-toggle').toggle();
            
            if ("<%= CapturePcpConsent%>" == "<%= Boolean.TrueString%>") {
                var parameter = "{'customerId':'" + customerId + "'";
                parameter += ",'eventId':'" + eventId + "','urlPath':'<%= Request.Url.AbsolutePath %>'}";
                
                var dataUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetPrimaryCarePhysicianEditModel") %>';

                InvokeServicewithErrorMethodName(dataUrl, parameter, PrimaryCarePhysicianFactory.set, ErrorControlData);
            } else {
                $(".pcpInfo").hide();
            }
        }

        var intMinVal = "<%= Int32.MinValue %>";
        var floatMinVal = "-3.40282347e+38";
        var decimalMinVal = "<%= decimal.MinValue %>";

        var customerId = "<%=CustomerId%>";
        var eventId = "<%=EventId%>";

        var nextCustomerId = 0;

        var medicalHistorySaved = false;
        function setMedicalHistory() {
            medicalHistorySaved = true;
        }

        var reloadForKyn = false;
        function setReloadForKyn() {
            reloadForKyn = true;
        }

        function reloadPageForKyn() {
            if (reloadForKyn)
                window.location.reload();
        }

        $(document).ready(function () {
            window.onbeforeunload = CloseAllWindow;
            $('#CustomerDataToggleImg').click(function () {
                if ($(this).attr("src").indexOf('plus') >= 0) {
                    $(this).attr("src", "/App/Images/minus-signs.gif");
                    $('.name-editable-class').toggle();
                }
                else {
                    $(this).attr("src", "/App/Images/plus-sign.gif");
                    $('.name-editable-class').toggle();
                }
                $('#infoShowHide').toggle();
            });

            $('.ddl-country').change(function () { changeStateforCountry(); });



            $('#ReasonForSendBackCorrectionDiv').dialog({ width: 380, autoOpen: false, title: 'Comments', resizable: false, draggable: true });
            $('#ReasonForSendBackCorrectionDiv').bind('dialogclose', onCloseCommentsForPhysicianBox);

            $('#preauditvalidationdiv').dialog({ width: 580, autoOpen: false, title: 'Pre Audit Validations', resizable: false, draggable: true });
            $('#preauditvalidationdiv').bind('dialogclose', onClosePreAuditvalidationDiv);

            $('#customerCriticalDataDiv').dialog({ width: 650, autoOpen: false, title: 'Preliminary Test Result', resizable: false, draggable: true, modal: true });
            $('#customerCriticalDataDiv').bind('dialogclose', onCloseCustomerCriticalDataDiv);


            $('#customerPriorityinQueueTestDiv').dialog({ width: 650, autoOpen: false, title: 'Priority In Queue Reason', resizable: false, draggable: true, modal: true });
            $('#customerPriorityinQueueTestDiv').bind('dialogclose', onClosePriorityInQueueTest);

            $("#testnotperformedvalidationdiv").dialog({ width: 590, autoOpen: false, title: 'Test Not Performed Validations', resizable: false, draggable: true, modal: true });
            $('#testnotperformedvalidationdiv').bind('dialogclose', onCloseTestNotPerformedDiv);

            $('#critical-question-dialog').dialog({ width: 700, autoOpen: false, title: 'Critical Patient Info', resizable: false, draggable: true, modal: true });

            if ('<%= Mode %>' == '<%= EditResultMode.ResultCorrection %>') {
                setSectionforCorrectionPreEvaluation();
            } else {
                setSectionforEntry();
            }

            if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>') {
                $("#PriorityInQueueCheckboxDiv").hide();
                $("#updatePriorityInQueue").hide();
            }

            $("#CityInputText").keyup(function () {
                $("#results").empty();

                var searchString = $("#CityInputText").val();

                if (searchString.length < 3) {
                    $("#results").hide();
                    return;
                }
                var parameter = "{'prefixText':'" + searchString + "'";
                parameter += ",'stateName':'" + "" + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByStateAndPrefixText")%>';

                InvokeService(messageUrl, parameter, FillCity);
            });



            initialSettingsIncidentalFinding();

            var parameter = "{'customerId':'" + customerId + "'";
            parameter += ",'eventId':'" + eventId + "','urlPath':'<%= Request.Url.AbsolutePath %>'}";
            var messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetCustomerEditModel") %>';
            InvokeServicewithErrorMethodName(messageUrl, parameter, SetControlData, ErrorControlData);

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetTestResults") %>';
            InvokeServicewithErrorMethodName(messageUrl, parameter, SetTestControlData, ErrorControlData);

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetEventCustomerPackageTestDetails") %>';
            InvokeServicewithErrorMethodName(messageUrl, parameter, SetControlEventPackageTestDetails, ErrorControlData);

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetBasicBiometric") %>';
            InvokeServicewithErrorMethodName(messageUrl, parameter, setbiometricdata, ErrorControlData);

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetRetestData") %>';
            InvokeServicewithErrorMethodName(messageUrl, parameter, setRetestCheckbox, ErrorControlData);
            
            if ("<%= ShowHideFastingStatus%>" == "<%= Boolean.TrueString%>") {
                messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetFastingStatus") %>';
                InvokeServicewithErrorMethodName(messageUrl, parameter, setFastingData, ErrorControlData);
                $(".showHideFastingStatus").show();
            } else {
                $(".showHideFastingStatus").hide();
            }

            if ("<%= CapturePcpConsent%>" == "<%= Boolean.TrueString%>") {
                var dataUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetPrimaryCarePhysicianEditModel") %>';
            
                InvokeServicewithErrorMethodName(dataUrl, parameter, PrimaryCarePhysicianFactory.set, ErrorControlData);
            } else {
                $(".pcpInfo").hide();
            }

            SetTabIndex();
            $('.mask-phone').mask('(999)-999-9999');

            if ("<%= CaptureHaf%>" == "<%= Boolean.TrueString%>") {
                $(".medical-history").show();
            } else {
                $(".medical-history").hide();
            }

            if ("<%= ShowCheckList%>" == "<%= Boolean.TrueString%>") {
                $(".checklist-form").show();
            } else {
                $(".checklist-form").hide();
            }

        });
        
        function setFastingData(result)
        {
            if (result.d == null) return;

            if(result.d.IsFasting == null)
            {
                $("#customerOnFastYesRadio").attr("checked", false);
                $("#customerOnFastNoRadio").attr("checked", false);
                $("#customerOnFastHidden").val('');
            }
            else if(result.d.IsFasting == true)
            {
                $("#customerOnFastYesRadio").attr("checked", true);
                $("#customerOnFastNoRadio").attr("checked", false);
                $("#customerOnFastHidden").val(true);
            }
            else if(result.d.IsFasting == false)
            {
                $("#customerOnFastYesRadio").attr("checked", false);
                $("#customerOnFastNoRadio").attr("checked", true);
                $("#customerOnFastHidden").val(false);
            }
        }
        function setbiometricdata(result) {
            if (result.d == null) return;

            if (result.d.SystolicPressure != null)
                $("#systolicbp").val(result.d.SystolicPressure);

            if (result.d.DiastolicPressure != null)
                $("#diastolicbp").val(result.d.DiastolicPressure);

            if (result.d.IsRightArmBpMeasurement) {
                $("#rightArmBp").attr("checked", true);
            }
            else if (result.d.SystolicPressure != null || result.d.DiastolicPressure != null) {
                $("#leftArmBp").attr("checked", true);
            }

            if (result.d.IsBloodPressureElevated == true) {
                $("#isElevatedBp").attr("checked", true);
            }

            if (result.d.PulseRate != null)
                $("#pulseratebb").val(result.d.PulseRate);
        }

        function onCloseCustomerCriticalDataDiv() {
            onCloseCritcalData();
            $('#customerCriticalDataDiv').html("<div class='loading' style='clear: both;'> &nbsp; </div>");
        }

    </script>
    <script language="javascript" type="text/javascript">
        var showScreenCounter = 0;

        function ErrorControlData() {
            alert("Oops! a problem occured in the system.");
            showScreenCounter++;
            CheckCounterToShowScreen();
        }

        function SetTestControlData(entity) {

            $.each(entity.d, function () {
                var testResult = removeTypeAttribute(this);
                testResult = CorrectDateissue(testResult);
                if (this.TestType == '<%= (short)TestType.EKG %>')
                    SetEKGData(testResult);
                else if (this.TestType == '<%= (short)TestType.Echocardiogram %>')
                    SetEchoData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.PulmonaryFunction %>')
                    SetPulmonaryData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.IMT %>')
                    SetImtData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Thyroid %>')
                    SetThyroidData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Lipid %>')
                    SetLipidData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvLipid %>')
                    SetAwvLipidData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AAA %>')
                    SetAAAData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvAAA %>')
                    SetAwvAaaData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Stroke %>')
                    SetStrokeData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvCarotid %>')
                    SetAwvCarotidData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Lead %>')
                    SetLeadData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.PAD %>')
                    SetPadData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvABI %>')
                    SetAwvAbiData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.ASI %>')
                    SetAsiData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Osteoporosis %>')
                    SetOsteoData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Spiro %>')
                    SetSpiroData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.A1C %>')
                    SetA1cData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Psa %>')
                    SetPsaData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.MenBloodPanel %>')
                    SetMenBloodPanelData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.WomenBloodPanel %>')
                    SetWomenBloodPanelData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.VitaminD %>')
                    SetVitaminDData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Hypertension %>')
                    SetHypertensionData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Crp %>')
                    SetCrpData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Colorectal %>')
                    SetColorectalData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvBoneMass %>')
                    SetAwvBoneMassData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvEkg %>')
                    SetAwvEkgData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvEkgIPPE %>')
                    SetAwvEkgIPPEData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvSpiro %>')
                    SetAwvSpiroData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvHBA1C %>')
                    SetAwvHemaglobinData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvGlucose %>')
                    SetAwvGlucoseData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Cholesterol %>')
                    SetCholesterolData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Diabetes %>')
                    SetDiabetesData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Kyn %>')
                    SetKynData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.HKYN %>')
                    SetHkynData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Testosterone %>')
                    SetTestosteroneData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.PPAAA %>')
                    SetPpAAAData(testResult);
                else if (this.TestType == '<%= (short)TestType.PPEcho %>')
                    SetPpEchoData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AWV %>')
                    SetAwvData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Medicare %>')
                    SetMedicareData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvSubsequent %>')
                    SetAwvSubsequentData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Hearing %>')
                    SetHearingData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Vision %>')
                    SetVisionData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Glaucoma %>')
                    SetGlaucomaData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.HCPAAA %>')
                    SetHcpAAAData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.HCPCarotid %>')
                    SetHcpCarotidData(testResult);
                else if (this.TestType == '<%= (short)TestType.HCPEcho %>')
                    SetHcpEchoData(testResult);
                else if (this.TestType == '<%= (short)TestType.AwvEcho %>')
                    SetAwvEchoData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.HPylori %>')
                    SetHPyloriData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Hemoglobin %>')
                    SetHemoglobinData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.DiabeticRetinopathy %>')
                    SetDiabeticRetinopathyData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.eAWV %>')
                    SetEAWVData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.DiabetesFootExam %>')
                    SetDiabetesFootExamData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.RinneWeberHearing %>')
                    SetRinneWeberHearingData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Monofilament %>')
                    SetMonofilamentData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.DiabeticNeuropathy %>')
                    SetDiabeticNeuropathyData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.FloChecABI %>')
                    SetFloChecABIData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.IFOBT %>')
                    SetIFOBTData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.QualityMeasures %>')
                    SetQualityMeasuresData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.PHQ9 %>')
                    SetPhq9Data(testResult);
                else if (testResult.TestType == '<%= (short)TestType.FocAttestation %>')
                    SetFocAttestationData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Mammogram %>')
                    SetMammogramData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.UrineMicroalbumin %>')
                    SetUrineMicroalbuminData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.FluShot %>')
                    SetFluShotData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.AwvFluShot %>')
                    SetAwvFluShotData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Pneumococcal %>')
                    SetPneumococcalData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Chlamydia %>')
                    SetChlamydiaData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.QuantaFloABI %>')
                    SetQuantaFloABIData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.DPN %>')
                    SetDpnData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.MyBioCheckAssessment %>')
                    SetMyBioCheckAssessmentData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Foc %>')
                    SetFocData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Cs %>')
                    SetCsData(testResult);
                else if (testResult.TestType == '<%= (short)TestType.Qv %>')
                    SetQvData(testResult);
            });

    showScreenCounter++;
    CheckCounterToShowScreen();

}

function SetControlData(entity) {
    SetCustomerData(entity.d);

    showScreenCounter++;
    CheckCounterToShowScreen();
}

function setnextCustomerId(id) {
    nextCustomerId = id;

    if (nextCustomerId < 1) {
        $(".approve-all-next").hide();
        $(".save-all-next").hide();
        $(".btn-skipnext").hide();
    }
}

function SetControlEventPackageTestDetails(entity) {
    if (entity.d.Package != null) {
        if (entity.d.Package.Tests != null && entity.d.Package.Tests.length > 0) {
            $.each(entity.d.Package.Tests, function () {
                if (this.IsRecordable)
                    ShowTest(this.Id);
            });
        }
    }

    if (entity.d.Tests != null && entity.d.Tests.length > 0) {
        $.each(entity.d.Tests, function () {
            if (this.IsRecordable)
                ShowTest(this.Id);
        });
    }
    showScreenCounter++;
    CheckCounterToShowScreen();
}

var isKynPurchased = false;
var isHKynPurchased = false;

function ShowTest(testId) {
    //$(".awvCarotidDiv").show();
    if (testId == '<%= (short)TestType.AAA %>') {
        $(".aaaDiv").show();
    } else if (testId == '<%= (short)TestType.AwvAAA %>') {
        $(".AwvAaaDiv").show();
    }
    else if (testId == '<%= (short)TestType.Stroke %>') {
        $(".strokeDiv").show();
    }
    else if (testId == '<%= (short)TestType.AwvCarotid %>') {
        $(".awvCarotidDiv").show();
    }
    else if (testId == '<%= (short)TestType.Lead %>') {
        $(".leadDiv").show();
    }
    else if (testId == '<%= (short)TestType.ASI %>') {
        $(".asiDiv").show();
    }
    else if (testId == '<%= (short)TestType.PAD %>') {
        $(".padDiv").show();
    }
    else if (testId == '<%= (short)TestType.AwvABI %>') {
        $(".AwvAbiDiv").show();
    }
    else if (testId == '<%= (short)TestType.Echocardiogram %>') {
        $(".echoDiv").show();
    }
    else if (testId == '<%= (short)TestType.IMT %>') {
        $(".imtDiv").show();
    }
    else if (testId == '<%= (short)TestType.Thyroid %>') {
        $(".thyroidDiv").show();
    }
    else if (testId == '<%= (short)TestType.PulmonaryFunction %>') {
        $(".pulmonaryDiv").show();
    }
    else if (testId == '<%= (short)TestType.Osteoporosis %>') {
        $(".osteoDiv").show();
    }
    else if (testId == '<%= (short)TestType.Spiro %>') {
        $(".spiroDiv").show();
    }
    else if (testId == '<%= (short)TestType.EKG %>') {
        $(".ekgDiv").show();
    }
    else if (testId == '<%= (short)TestType.Lipid %>') {
        $(".lipidDiv").show();
    }
    else if (testId == '<%= (short)TestType.AwvLipid %>') {
        $(".awvLipidDiv").show();
    }
    else if (testId == '<%= (short)TestType.Cholesterol %>') {
        $(".CholesterolDiv").show();
    }
    else if (testId == '<%= (short)TestType.Diabetes %>') {
                $(".DiabetesDiv").show();
            }
            else if (testId == '<%= (short)TestType.Liver %>') {
                $(".liverDiv").show();
            }
            else if (testId == '<%= (short)TestType.FraminghamRisk %>') {
                $(".framinghamRiskDiv").show();
            }
            else if (testId == '<%= (short)TestType.A1C %>') {
                $(".a1cDiv").show();
            }
            else if (testId == '<%= (short)TestType.Psa %>') {
                $(".PsaDiv").show();
            }
            else if (testId == '<%= (short)TestType.Crp %>') {
                $(".CrpDiv").show();
            }
            else if (testId == '<%= (short)TestType.Colorectal %>') {
                $(".ColorectalDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvBoneMass %>') {
                $(".awvBoneMassDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvEkg %>') {
                $(".awvEkgDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvEkgIPPE %>') {
                $(".awvEkgIPPEDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvSpiro %>') {
                $(".awvSpiroDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvHBA1C %>') {
                $(".awvHemaglobinDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvGlucose %>') {
                $(".awvGlucoseDiv").show();
            }
            else if (testId == '<%= (short)TestType.Kyn %>') {
                isKynPurchased = true;
                $(".KynDiv").show();
            }
            else if (testId == '<%= (short)TestType.HKYN %>') {
                isKynPurchased = true;
                isHKynPurchased = true;
                $(".HkynDiv").show();
            }
            else if (testId == '<%= (short)TestType.Testosterone %>') {
                $(".TestosteroneDiv").show();
            }
            else if (testId == '<%= (short)TestType.PPAAA %>') {
                $(".PpaaaDiv").show();
            }
            else if (testId == '<%= (short)TestType.PPEcho %>') {
                $(".PpechoDiv").show();
            }
            else if (testId == '<%= (short)TestType.AWV %>') {
                $(".AwvDiv").show();
            }
            else if (testId == '<%= (short)TestType.Medicare %>') {
                $(".MedicareDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvSubsequent %>') {
                $(".AwvSubsequentDiv").show();
            }
            else if (testId == '<%= (short)TestType.Hearing %>') {
                $(".HearingDiv").show();
            }
            else if (testId == '<%= (short)TestType.Vision %>') {
                $(".VisionDiv").show();
            }
            else if (testId == '<%= (short)TestType.Glaucoma %>') {
                $(".GlaucomaDiv").show();
            }
            else if (testId == '<%= (short)TestType.HCPAAA %>') {
                $(".HcpaaaDiv").show();
            }
            else if (testId == '<%= (short)TestType.HCPCarotid %>') {
                $(".HcpCarotidDiv").show();
            }
            else if (testId == '<%= (short)TestType.HCPEcho %>') {
                $(".HcpEchoDiv").show();
            }
            else if (testId == '<%= (short)TestType.AwvEcho %>') {
                $(".awvEchoDiv").show();
            }
            else if (testId == '<%= (short)TestType.HPylori %>') {
                $(".HPyloriDiv").show();
            }
            else if (testId == '<%= (short)TestType.MenBloodPanel %>') {
                $(".MenBloodPanelDiv").show();
            }
            else if (testId == '<%= (short)TestType.WomenBloodPanel %>') {
                $(".WomenBloodPanelDiv").show();
            }
            else if (testId == '<%= (short)TestType.Hypertension %>') {
                $(".HypertensionDiv").show();
            }
            else if (testId == '<%= (short)TestType.VitaminD %>') {
                $(".VitaminDDiv").show();
            }
            else if (testId == '<%= (short)TestType.Hemoglobin %>') {
                $(".HemoglobinDiv").show();
            }
            else if (testId == '<%= (short)TestType.DiabeticRetinopathy %>') {
                $(".DiabeticRetinopathyDiv").show();
            }
            else if (testId == '<%= (short)TestType.eAWV %>') {
                $(".EAWVDiv").show();
            }
            else if (testId == '<%= (short)TestType.DiabetesFootExam %>') {
                $(".DiabetesFootExamDiv").show();
            }
            else if (testId == '<%= (short)TestType.RinneWeberHearing %>') {
                $(".RinneWeberHearingDiv").show();
            }
            else if (testId == '<%= (short)TestType.Monofilament %>') {
                $(".MonofilamentDiv").show();
            }
            else if (testId == '<%= (short)TestType.DiabeticNeuropathy %>') {
                $(".DiabeticNeuropathyDiv").show();
            }
            else if (testId == '<%= (short)TestType.FloChecABI %>') {
                $(".FloChecABIDiv").show();
            }
            else if (testId == '<%= (short)TestType.IFOBT %>') {
                $(".IFOBTDiv").show();
            }
            else if (testId == '<%= (short)TestType.QualityMeasures %>') {
                $(".QualityMeasuresDiv").show();
            }
            else if (testId == '<%= (short)TestType.PHQ9 %>') {
                $(".phq9Div").show();
            }
            else if (testId == '<%= (short)TestType.FocAttestation %>') {
                $(".focAttestation").show();
            }
            else if (testId == '<%= (short)TestType.Mammogram %>') {
                $(".mammogramDiv").show();
            }
            else if (testId == '<%= (short)TestType.UrineMicroalbumin %>') {
                $(".UrineMicroalbuminDiv").show();
            }
            else if (testId == '<%= (short)TestType.FluShot %>') {
                $(".fluShotDiv").show();
            } 
            else if (testId == '<%= (short)TestType.AwvFluShot %>') {
                $(".awvFluShotDiv").show();
            }
            else if (testId == '<%= (short)TestType.Pneumococcal %>') {
                $(".PneumococcalDiv").show();
            }
            else if (testId == '<%= (short)TestType.Chlamydia %>') {
                $(".chlamydiaDiv").show();
            }
            else if (testId == '<%= (short)TestType.QuantaFloABI %>') {
                $(".QuantaFloABIDiv").show();
            }
            else if (testId == '<%= (short)TestType.DPN %>') {
                $(".DpnDiv").show();
            }
            else if (testId == '<%= (short)TestType.MyBioCheckAssessment %>') {
                $(".myBioCheckAssessmentDiv").show();
            }
            else if (testId == '<%= (short)TestType.Foc %>') {
                $(".focDiv").show();
            }
            else if (testId == '<%= (short)TestType.Cs %>') {
                $(".csDiv").show();
            }
            else if (testId == '<%= (short)TestType.Qv %>') {
                $(".qvDiv").show();
            }
}

function CheckCounterToShowScreen() {
    if (showScreenCounter == 3) {
        $("#MainContainerDiv").show();
        $("#LoadingGifContainerDiv").hide();
    }
}
    </script>
    <script language="javascript" type="text/javascript">

        function GetControlData() {
            //            if ($("#ResultStatusInputHidden").val() == '4') {
            //                ValidateTestResult();
            //            }
            //            else {
            SaveTestResultData();
            //}
        }


        var bolSaveandNext = false;
        var checkerCounter = 0;
        //var criticalTestSavedCounter = 0;

        function getBasicBiometric() {
            var bioMetric = {
                'SystolicPressure': $.trim($("#systolicbp").val()).length < 1 ? null : $.trim($("#systolicbp").val()),
                'DiastolicPressure': $.trim($("#diastolicbp").val()).length < 1 ? null : $.trim($("#diastolicbp").val()),
                'IsRightArmBpMeasurement': $('#rightArmBp').attr("checked"),
                'IsBloodPressureElevated': $("#isElevatedBp").attr("checked"),
                'PulseRate': $.trim($("#pulseratebb").val()).length < 1 ? null : $.trim($("#pulseratebb").val()),
                'CreatedOn': '<%= DateTime.Now %>',
                'CreatedByOrgRoleUserId': '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>'
            };

            if (bioMetric.SystolicPressure == null && bioMetric.DiastolicPressure == null)
                return null;

            return bioMetric;
        }

        function checkForSkipEvaluation() {
            if ($(".skip-evaluation-checkbox").attr("checked") == false) return;

            if ($("#DefaultPhysician").length < 1 || Number($("#DefaultPhysician").val()) == 0) {
                if ($("#IsNewResultFlowInputHidden").val() == true || $("#IsNewResultFlowInputHidden").val() == "true") {
                    $("#ResultStatusInputHidden").val("<%= (int)NewTestResultStateNumber.ResultEntryPartial %>");    
                } else {
                    $("#ResultStatusInputHidden").val("<%= (int)TestResultStateNumber.ManualEntry %>");    
                }
                
            }
        }

        function checkBeforeSavingResults() {
            if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>') {
                var asiValidationMessage = "";
                var padValidationMessage = "";
                var AwvAbiValidationMessage = "";
                var floChecAbiValidationMessage = "";
                var quantaFloAbiValidationMessage = "";

                var myBioCheckAssessmentValidationMessage = "";
                var lipidValidationMessage = "";
                var awvlipidValidationMessage = "";
                var cholestrolValidationMessage = "";

                if ($(".asiDiv:visible").length > 0 && IsasiResultEntryExternaly == "False") {
                    asiValidationMessage = checkAsiData();
                }

                if ($(".padDiv:visible").length > 0 && IspadResultEntryExternaly == "False") {
                    padValidationMessage = checkPadData();
                }

                if ($(".AwvAbiDiv:visible").length > 0 && IsawvABIResultEntryExternaly == "False") {
                    AwvAbiValidationMessage = checkAwvAbiData();
                }

                if ($(".FloChecABIDiv:visible").length > 0 && isFloChecABIResultEntryType == "False") {
                    floChecAbiValidationMessage = checkFloChecABIData();
                }

                if ($(".QuantaFloABIDiv:visible").length > 0 && isQuantaFloABIResultEntryType == "False") {
                    quantaFloAbiValidationMessage = checkQuantaFloABIData();
                }
                
                if ($(".lipidDiv:visible").length > 0 && IslipidResultEntryExternaly == "False") {
                    lipidValidationMessage = checkLipidAssessment();
                }

                if ($(".myBioCheckAssessmentDiv:visible").length > 0 && isMybiocheckResultentrytype == "False") {
                    myBioCheckAssessmentValidationMessage = checkBioCheckAssessment();
                }
                
                if ($(".awvLipidDiv:visible").length > 0 && IsawvLipidResultEntryExternaly == "False") {
                    awvlipidValidationMessage = checkAwvLipidAssessment();
                }
                
                if ($(".CholesterolDiv:visible").length > 0 && IscholesterolResultEntryExternaly == "False") {
                    cholestrolValidationMessage = checkCholestrolPanel();
                }

                if (medicalHistorySaved != true || $(".conductedby-ddl option:selected[value=-1]").length > 0 ) {
                    var text = "";

                    if (medicalHistorySaved != true) text += "<li> The Health Assesment form for this customer is not filled yet. This is mandatory before you move for Doctor Evaluations. </li>";
                    if ($(".conductedby-ddl option[value=-1]:selected").length > 0) text += "<li> Conducted By Technician is missing for few tests. It is mandatory to mark for all the tests. </li>";

                    if (asiValidationMessage != "")
                        text += "<li>" + asiValidationMessage + "</li>";

                    if (padValidationMessage != "")
                        text += "<li>" + padValidationMessage + "</li>";
                    if (AwvAbiValidationMessage != "")
                        text += "<li>" + AwvAbiValidationMessage + "</li>";

                    if (floChecAbiValidationMessage != "") {
                        text += "<li>" + floChecAbiValidationMessage + "</li>";
                    }

                    if (quantaFloAbiValidationMessage != "") {
                        text += "<li>" + quantaFloAbiValidationMessage + "</li>";
                    }
                    
                    if (myBioCheckAssessmentValidationMessage != "") {
                        text += "<li>" + myBioCheckAssessmentValidationMessage + "</li>";
                    }
                    
                    if (lipidValidationMessage != "") {
                        text += "<li>" + lipidValidationMessage + "</li>";
                    }
                    
                    if (awvlipidValidationMessage != "") {
                        text += "<li>" + awvlipidValidationMessage + "</li>";
                    }
                    
                    if (cholestrolValidationMessage != "") {
                        text += "<li>" + cholestrolValidationMessage + "</li>";
                    }

                    $("#validationmessagediv").html("<ul>" + text + "</ul>");
                    $("#preauditvalidationdiv").dialog("open");

                    return;
                }
                
                if ('<%= IsNewResultFlow %>' == '<%= Boolean.TrueString %>' && '<%= ShowHraQuestionnaire %>' == '<%= Boolean.TrueString %>' && '<%= IsEawvTestPurchased %>' == '<%= Boolean.TrueString %>' && '<%= IsChartSignedOff %>' == '<%= Boolean.FalseString %>' && !isEawvTestNotPerformedChecked()) {
                    
                    var text = "<li> Unable to remove test not performed from eAWV as chart not signed for this patient. </li>";
                    if ($(".conductedby-ddl option[value=-1]:selected").length > 0) text += "<li> Conducted By Technician is missing for few tests. It is mandatory to mark for all the tests. </li>";

                    if (asiValidationMessage != "")
                        text += "<li>" + asiValidationMessage + "</li>";

                    if (padValidationMessage != "")
                        text += "<li>" + padValidationMessage + "</li>";
                    if (AwvAbiValidationMessage != "")
                        text += "<li>" + AwvAbiValidationMessage + "</li>";

                    if (floChecAbiValidationMessage != "") {
                        text += "<li>" + floChecAbiValidationMessage + "</li>";
                    }

                    if (quantaFloAbiValidationMessage != "") {
                        text += "<li>" + quantaFloAbiValidationMessage + "</li>";
                    }
                    
                    if (myBioCheckAssessmentValidationMessage != "") {
                        text += "<li>" + myBioCheckAssessmentValidationMessage + "</li>";
                    }
                    
                    if (lipidValidationMessage != "") {
                        text += "<li>" + lipidValidationMessage + "</li>";
                    }
                    
                    if (awvlipidValidationMessage != "") {
                        text += "<li>" + awvlipidValidationMessage + "</li>";
                    }
                    
                    if (cholestrolValidationMessage != "") {
                        text += "<li>" + cholestrolValidationMessage + "</li>";
                    }

                    $("#validationmessagediv").html("<ul>" + text + "</ul>");
                    $("#preauditvalidationdiv").dialog("open");

                    return;
                }

                if (asiValidationMessage.length > 0 || padValidationMessage.length > 0 || AwvAbiValidationMessage.length > 0 || myBioCheckAssessmentValidationMessage.length > 0 || lipidValidationMessage.length > 0 || awvlipidValidationMessage.length > 0 || cholestrolValidationMessage.lipid > 0) {
                    var text = "";

                    if (asiValidationMessage != "")
                        text += "<li>" + asiValidationMessage + "</li>";

                    if (padValidationMessage != "")
                        text += "<li>" + padValidationMessage + "</li>";

                    if (AwvAbiValidationMessage != "")
                        text += "<li>" + AwvAbiValidationMessage + "</li>";

                    if (floChecAbiValidationMessage != "")
                        text += "<li>" + floChecAbiValidationMessage + "</li>";

                    if (quantaFloAbiValidationMessage != "")
                        text += "<li>" + quantaFloAbiValidationMessage + "</li>";
                    
                    if (myBioCheckAssessmentValidationMessage != "") {
                        text += "<li>" + myBioCheckAssessmentValidationMessage + "</li>";
                    }
                    
                    if (lipidValidationMessage != "") {
                        text += "<li>" + lipidValidationMessage + "</li>";
                    }

                    if (awvlipidValidationMessage != "") {
                        text += "<li>" + awvlipidValidationMessage + "</li>";
                    }

                    if (cholestrolValidationMessage != "") {
                        text += "<li>" + cholestrolValidationMessage + "</li>";
                    }

                    $("#validationmessagediv").html("<ul>" + text + "</ul>");

                    $("#btncontinueWithIncompleteData").show();
                    $("#btncontinue").hide();

                    $("#preauditvalidationdiv").dialog("open");

                    return;
                }
                

                if (floChecAbiValidationMessage.length > 0 || quantaFloAbiValidationMessage.length > 0 || myBioCheckAssessmentValidationMessage.length > 0 || lipidValidationMessage.length > 0 || awvlipidValidationMessage.length > 0 || cholestrolValidationMessage.length > 0) {
                    var text = "";

                    if (floChecAbiValidationMessage != "")
                        text += "<li>" + floChecAbiValidationMessage + "</li>";

                    if (quantaFloAbiValidationMessage != "")
                        text += "<li>" + quantaFloAbiValidationMessage + "</li>";

                    if (myBioCheckAssessmentValidationMessage != "") {
                        text += "<li>" + myBioCheckAssessmentValidationMessage + "</li>";
                    }
                    
                    if (lipidValidationMessage != "") {
                        text += "<li>" + lipidValidationMessage + "</li>";
                    }
                    if (awvlipidValidationMessage != "") {
                        text += "<li>" + awvlipidValidationMessage + "</li>";
                    }
                    
                    if (cholestrolValidationMessage != "") {
                        text += "<li>" + cholestrolValidationMessage + "</li>";
                    }

                    $("#validationmessagediv").html("<ul>" + text + "</ul>");

                    $("#btncontinueWithIncompleteData").hide();
                    $("#btncontinue").hide();

                    $("#preauditvalidationdiv").dialog("open");

                    return;
                }
                
                
            }
           
            SaveTestResultData();
        }
        
        function TestNotPerformedValidation() {
            var patientRefused = <%=(long)TestNotPerformedReasonType.PatientRefused %>;
            var contraindication = <%= (long)TestNotPerformedReasonType.Contraindication %>;
            var equipmentMalfunction = <%=(long)TestNotPerformedReasonType.EquipmentMalfunction %>;
            var testPreviouslyPerformed = <%=(long)TestNotPerformedReasonType.TestPreviouslyPerformedThisYear %>;
            var supplyIssue = <%=(long)TestNotPerformedReasonType.SupplyIssue %>;

            var isAllTestNotPerformedDataProvided = true;
            var isReasonIdProvided = true;
            var isNotesProvided = true;

            $(".test-not-performed-container:visible").each(function () {
                var reasonId = Number($(this).find("select").val());
                var reasonNotes = $(this).find("textarea").val();
                if (reasonId <= 0 && isReasonIdProvided) {
                    isAllTestNotPerformedDataProvided = false;
                    isReasonIdProvided = false;
                }
                if ((reasonId === patientRefused || reasonId === contraindication || reasonId === equipmentMalfunction || reasonId === testPreviouslyPerformed || reasonId===supplyIssue) && reasonNotes === '' && isNotesProvided) {
                    isAllTestNotPerformedDataProvided = false;
                    isNotesProvided = false;
                }
            });

            if (isAllTestNotPerformedDataProvided === false) {
                var validationMessage = '';
                if (isReasonIdProvided === false) {
                    validationMessage = validationMessage + '<li> Test Not Performed Reason is missing for few test. This is mandatory to mark for all the tests marked as "Test Not Performed". ';
                }
                if (isNotesProvided === false) {
                    validationMessage = validationMessage + '<li> If you have selected test not performed reason as "<%= TestNotPerformedReasonType.PatientRefused.GetDescription() %>" or "<%= TestNotPerformedReasonType.Contraindication.GetDescription() %>" or "<%= TestNotPerformedReasonType.EquipmentMalfunction.GetDescription() %>" or "<%= TestNotPerformedReasonType.TestPreviouslyPerformedThisYear.GetDescription() %>" or "<%= TestNotPerformedReasonType.SupplyIssue.GetDescription() %>" then it is mandatory to enter notes.';
                }

                $("#testnotperformedvalidationmessagediv").html("<ul> " + validationMessage + "</ul>");
                $(".save-button-container").toggle();
                $("#testnotperformedvalidationdiv").dialog("open");
            }
            
            return isAllTestNotPerformedDataProvided;
        }

        function continueWithIncompleteRecords() {
            if ($("#IsNewResultFlowInputHidden").val() == true || $("#IsNewResultFlowInputHidden").val() == "true") {
                $("#ResultStatusInputHidden").val("<%= (int)NewTestResultStateNumber.ResultEntryPartial %>");    
            } else {
                $("#ResultStatusInputHidden").val("<%= (int)TestResultStateNumber.ManualEntry %>");    
            }
            

            $(".skip-evaluation-checkbox").removeAttr("checked");
            
            SaveTestResultData();
        }

        function continueWithIncompleteData() {
            $(".skip-evaluation-checkbox").removeAttr("checked");
            SaveTestResultData();
        }

        function onClosePreAuditvalidationDiv() {
            $("#btncontinueWithIncompleteData").hide();
            $("#btncontinue").show();
            $(".save-button-container").toggle();
        }

        function onCloseTestNotPerformedDiv() {
            $(".save-button-container").toggle();
        }
        
        function SaveTestResultData() {
            if ('<%= Mode %>' != '<%= EditResultMode.ResultCorrection %>') {
                checkForSkipEvaluation();
            }

            var newTestArray = new Array();

            if ($(".osteoDiv:visible").length > 0) {
                var osteoTestResult = GetOsteoData();
                if (osteoTestResult != null) {
                    newTestArray.push(correctObject(osteoTestResult));
                }
            }

            if ($(".spiroDiv:visible").length > 0) {
                var spiroTestResult = GetSpiroData();
                if (spiroTestResult != null) {
                    newTestArray.push(correctObject(spiroTestResult));
                }
            }

            if ($(".HPyloriDiv:visible").length > 0) {
                var hPyloriTestResult = GetHPyloriData();
                if (hPyloriTestResult != null) {
                    newTestArray.push(correctObject(hPyloriTestResult));
                }
            }

            if ($(".strokeDiv:visible").length > 0) {
                var strokeTestResult = GetStrokeData();
                if (strokeTestResult != null) {
                    newTestArray.push(correctObject(strokeTestResult));
                }
            }

            if ($(".awvCarotidDiv:visible").length > 0) {
                var awvCrotidTestResult = GetAwvCarotidData();
                if (awvCrotidTestResult != null) {
                    newTestArray.push(correctObject(awvCrotidTestResult));
                }
            }

            if ($(".leadDiv:visible").length > 0) {
                var leadTestResult = GetLeadData();
                if (leadTestResult != null) {
                    newTestArray.push(correctObject(leadTestResult));
                }
            }

            if ($(".aaaDiv:visible").length > 0) {
                var aaaTestResult = GetAAAData();
                if (aaaTestResult != null) {
                    newTestArray.push(correctObject(aaaTestResult));
                }
            }

            if ($(".AwvAaaDiv:visible").length > 0) {

                var awvAaaTestResult = GetAwvAaaData();
                if (awvAaaTestResult != null) {
                    newTestArray.push(correctObject(awvAaaTestResult));
                }
            }

            if ($(".asiDiv:visible").length > 0) {
                var asiTestResult = GetAsiData();
                if (asiTestResult != null) {
                    newTestArray.push(correctObject(asiTestResult));
                }
            }

            if ($(".padDiv:visible").length > 0) {
                var padTestResult = GetPadData();
                if (padTestResult != null) {
                    newTestArray.push(correctObject(padTestResult));
                }
            }

            if ($(".AwvAbiDiv:visible").length > 0) {
                var awvAbiTestResult = GetAwvAbiData();
                if (awvAbiTestResult != null) {
                    newTestArray.push(correctObject(awvAbiTestResult));
                }
            }

            if ($(".echoDiv:visible").length > 0) {
                var echoTestResult = GetEchoData();
                if (echoTestResult != null) {
                    newTestArray.push(correctObject(echoTestResult));
                }
            }

            if ($(".ekgDiv:visible").length > 0) {
                var ekgTestResults = GetEKGData();
                if (ekgTestResults != null) {
                    newTestArray.push(correctObject(ekgTestResults));
                }
            }

            if ($(".lipidDiv:visible").length > 0) {
                var lipidTestResults = GetLipidData();
                if (lipidTestResults != null) {
                    newTestArray.push(correctObject(lipidTestResults));
                }
            }

            if ($(".awvLipidDiv:visible").length > 0) {
                var awvLipidTestResults = GetAwvLipidData();
                if (awvLipidTestResults != null) {
                    newTestArray.push(correctObject(awvLipidTestResults));
                }
            }

            if ($(".CholesterolDiv:visible").length > 0) {
                var cholesterolTestResults = GetCholesterolData();
                if (cholesterolTestResults != null) {
                    newTestArray.push(correctObject(cholesterolTestResults));
                }
            }

            if ($(".DiabetesDiv:visible").length > 0) {
                var diabetesTestResults = GetDiabetesData();
                if (diabetesTestResults != null) {
                    newTestArray.push(correctObject(diabetesTestResults));
                }
            }

            if ($(".imtDiv:visible").length > 0) {
                var imtTestResult = GetImtData();
                if (imtTestResult != null) {
                    newTestArray.push(correctObject(imtTestResult));
                }
            }

            if ($(".thyroidDiv:visible").length > 0) {
                var thyroidTestResult = GetThyroidData();
                if (thyroidTestResult != null) {
                    newTestArray.push(correctObject(thyroidTestResult));
                }
            }

            if ($(".pulmonaryDiv:visible").length > 0) {
                var pulmonaryTestResult = GetPulmonaryData();
                if (pulmonaryTestResult != null) {
                    newTestArray.push(correctObject(pulmonaryTestResult));
                }
            }

            if ($(".a1cDiv:visible").length > 0) {
                var a1cTestResult = GetA1cData();
                if (a1cTestResult != null) {
                    newTestArray.push(correctObject(a1cTestResult));
                }
            }

            if ($(".PsaDiv:visible").length > 0) {
                var PsaTestResult = GetPsaData();
                if (PsaTestResult != null) {
                    newTestArray.push(correctObject(PsaTestResult));
                }
            }
            if ($(".MenBloodPanelDiv:visible").length > 0) {
                var menBloodPanelTestResult = GetMenBloodPanelData();
                if (menBloodPanelTestResult != null) {
                    newTestArray.push(correctObject(menBloodPanelTestResult));
                }
            }
            if ($(".WomenBloodPanelDiv:visible").length > 0) {
                var womenBloodPanelTestResult = GetWomenBloodPanelData();
                if (womenBloodPanelTestResult != null) {
                    newTestArray.push(correctObject(womenBloodPanelTestResult));
                }
            }
            if ($(".VitaminDDiv:visible").length > 0) {
                var VitaminDTestResult = GetVitaminDData();
                if (VitaminDTestResult != null) {
                    newTestArray.push(correctObject(VitaminDTestResult));
                }
            }
            if ($(".HypertensionDiv:visible").length > 0) {
                var HypertensionTestResult = GetHypertensionData();
                if (HypertensionTestResult != null) {
                    newTestArray.push(correctObject(HypertensionTestResult));
                }
            }
            if ($(".CrpDiv:visible").length > 0) {
                var CrpTestResult = GetCrpData();
                if (CrpTestResult != null) {
                    newTestArray.push(correctObject(CrpTestResult));
                }
            }

            if ($(".ColorectalDiv:visible").length > 0) {
                var ColorectalTestResult = GetColorectalData();
                if (ColorectalTestResult != null) {
                    newTestArray.push(correctObject(ColorectalTestResult));
                }
            }

            if ($(".awvBoneMassDiv:visible").length > 0) {
                var awvBoneMassTestResult = GetAwvBoneMassData();
                if (awvBoneMassTestResult != null) {
                    newTestArray.push(correctObject(awvBoneMassTestResult));
                }
            }

            if ($(".awvEkgDiv:visible").length > 0) {
                var awvEkgTestResult = GetAwvEkgData();
                if (awvEkgTestResult != null) {
                    newTestArray.push(correctObject(awvEkgTestResult));
                }
            }
            if ($(".awvEkgIPPEDiv:visible").length > 0) {
                var awvEkgIppeTestResult = GetAwvEkgIPPEData();
                if (awvEkgIppeTestResult != null) {
                    newTestArray.push(correctObject(awvEkgIppeTestResult));
                }
            }
            if ($(".awvSpiroDiv:visible").length > 0) {
                var awvSpiroTestResult = GetAwvSpiroData();
                if (awvSpiroTestResult != null) {
                    newTestArray.push(correctObject(awvSpiroTestResult));
                }
            }
            if ($(".awvHemaglobinDiv:visible").length > 0) {
                var awvHemaglobinDivTestResult = GetAwvHemaglobinData();
                if (awvHemaglobinDivTestResult != null) {
                    newTestArray.push(correctObject(awvHemaglobinDivTestResult));
                }
            }
            if ($(".awvGlucoseDiv:visible").length > 0) {
                var awvGlucoseDivTestResult = GetAwvGlucoseData();
                if (awvGlucoseDivTestResult != null) {
                    newTestArray.push(correctObject(awvGlucoseDivTestResult));
                }
            }

            if ($(".KynDiv:visible").length > 0) {
                var KynTestResult = GetKynData();
                if (KynTestResult != null) {
                    newTestArray.push(correctObject(KynTestResult));
                }
            }

            if ($(".HkynDiv:visible").length > 0) {
                var hkynTestResult = GetHkynData();
                if (hkynTestResult != null) {
                    newTestArray.push(correctObject(hkynTestResult));
                }
            }

            if ($(".TestosteroneDiv:visible").length > 0) {
                var TestosteroneTestResult = GetTestosteroneData();
                if (TestosteroneTestResult != null) {
                    newTestArray.push(correctObject(TestosteroneTestResult));
                }
            }

            if ($(".PpaaaDiv:visible").length > 0) {
                var PpaaaTestResult = GetPpAAAData();
                if (PpaaaTestResult != null) {
                    newTestArray.push(correctObject(PpaaaTestResult));
                }
            }

            if ($(".PpechoDiv:visible").length > 0) {
                var PpechoTestResult = GetPpEchoData();
                if (PpechoTestResult != null) {
                    newTestArray.push(correctObject(PpechoTestResult));
                }
            }

            if ($(".AwvDiv:visible").length > 0) {
                var awvTestResult = GetAwvData();
                if (awvTestResult != null) {
                    newTestArray.push(correctObject(awvTestResult));
                }
            }
            if ($(".MedicareDiv:visible").length > 0) {
                var medicareTestResult = GetMedicareData();
                if (medicareTestResult != null) {
                    newTestArray.push(correctObject(medicareTestResult));
                }
            }
            if ($(".AwvSubsequentDiv:visible").length > 0) {
                var awvSubsequentTestResult = GetAwvSubsequentData();
                if (awvSubsequentTestResult != null) {
                    newTestArray.push(correctObject(awvSubsequentTestResult));
                }
            }
            if ($(".HearingDiv:visible").length > 0) {
                var hearingTestResult = GetHearingData();
                if (hearingTestResult != null) {
                    newTestArray.push(correctObject(hearingTestResult));
                }
            }
            if ($(".VisionDiv:visible").length > 0) {
                var visionTestResult = GetVisionData();
                if (visionTestResult != null) {
                    newTestArray.push(correctObject(visionTestResult));
                }
            }
            if ($(".GlaucomaDiv:visible").length > 0) {
                var glaucomaTestResult = GetGlaucomaData();
                if (glaucomaTestResult != null) {
                    newTestArray.push(correctObject(glaucomaTestResult));
                }
            }

            if ($(".HcpaaaDiv:visible").length > 0) {
                var HcpaaaTestResult = GetHcpAAAData();
                if (HcpaaaTestResult != null) {
                    newTestArray.push(correctObject(HcpaaaTestResult));
                }
            }

            if ($(".HcpCarotidDiv:visible").length > 0) {
                var hcpCarotidTestResult = GetHcpCarotidData();
                if (hcpCarotidTestResult != null) {
                    newTestArray.push(correctObject(hcpCarotidTestResult));
                }
            }

            if ($(".HcpEchoDiv:visible").length > 0) {
                var HcpEchoTestResult = GetHcpEchoData();
                if (HcpEchoTestResult != null) {
                    newTestArray.push(correctObject(HcpEchoTestResult));
                }
            }
            if ($(".awvEchoDiv:visible").length > 0) {
               
                var awvEchoTestResult = GetAwvEchoData();
                if (awvEchoTestResult != null) {
                    newTestArray.push(correctObject(awvEchoTestResult));
                }
            }
            if ($(".HemoglobinDiv:visible").length > 0) {
                var hemoglobinTestResult = GetHemoglobinData();
                if (hemoglobinTestResult != null) {
                    newTestArray.push(correctObject(hemoglobinTestResult));
                }
            }
            if ($(".DiabeticRetinopathyDiv:visible").length > 0) {
                var diabeticRetinopathyTestResult = GetDiabeticRetinopathyData();
                if (diabeticRetinopathyTestResult != null) {
                    newTestArray.push(correctObject(diabeticRetinopathyTestResult));
                }
            }
            if ($(".EAWVDiv:visible").length > 0) {
                var eawvTestResult = GetEAWVData();
                if (eawvTestResult != null) {
                    newTestArray.push(correctObject(eawvTestResult));
                }
            }

            if ($(".DiabetesFootExamDiv:visible").length > 0) {
                var diabetesFootExamTestResult = GetDiabetesFootExamData();
                if (diabetesFootExamTestResult != null) {
                    newTestArray.push(correctObject(diabetesFootExamTestResult));
                }
            }

            if ($(".RinneWeberHearingDiv:visible").length > 0) {
                var rinneWeberHearingTestResult = GetRinneWeberHearingData();
                if (rinneWeberHearingTestResult != null) {
                    newTestArray.push(correctObject(rinneWeberHearingTestResult));
                }
            }
            
            if ($(".MonofilamentDiv:visible").length > 0) {
                var monofilamentTestResult = GetMonofilamentData();
                if (monofilamentTestResult != null) {
                    newTestArray.push(correctObject(monofilamentTestResult));
                }
            }

            if ($(".DiabeticNeuropathyDiv:visible").length > 0) {
                var diabeticNeuropathyTestResult = GetDiabeticNeuropathyData();
                if (diabeticNeuropathyTestResult != null) {
                    newTestArray.push(correctObject(diabeticNeuropathyTestResult));
                }
            }

            if ($(".FloChecABIDiv:visible").length > 0) {
                var floChecABITestResult = GetFloChecABIData();
                if (floChecABITestResult != null) {
                    newTestArray.push(correctObject(floChecABITestResult));
                }
            }

            if ($(".IFOBTDiv:visible").length > 0) {
                var iFOBTTestResult = GetIFOBTData();
                if (iFOBTTestResult != null) {
                    newTestArray.push(correctObject(iFOBTTestResult));
                }
            }
            
            if ($(".QualityMeasuresDiv:visible").length > 0) {
                var qualityMeasuresTestResult = GetQualityMeasuresData();
                if (qualityMeasuresTestResult != null) {
                    newTestArray.push(correctObject(qualityMeasuresTestResult));
                }
            }
            
            if ($(".phq9Div:visible").length > 0) {
                var phq9TestResult = GetPhq9Data();
                if (phq9TestResult != null) {
                    newTestArray.push(correctObject(phq9TestResult));
                }
            }
            
            if ($(".focAttestation:visible").length > 0) {
                var focAttestationTestResult = GetFocAttestationData();
                if (focAttestationTestResult != null) {
                    newTestArray.push(correctObject(focAttestationTestResult));
                }
            }
            if ($(".mammogramDiv:visible").length > 0) {
                var mammogramTestResult = GetMammogramData();
                if (mammogramTestResult != null) {
                    newTestArray.push(correctObject(mammogramTestResult));
                }
            }
            if ($(".UrineMicroalbuminDiv:visible").length > 0) {
                var urineMicroalbuminTestResult = GetUrineMicroalbuminData();
                if (urineMicroalbuminTestResult != null) {
                    newTestArray.push(correctObject(urineMicroalbuminTestResult));
                }
            }
            
            if ($(".fluShotDiv:visible").length > 0) {
                var fluShotTestResult = GetFluShotData();
                if (fluShotTestResult != null) {
                    newTestArray.push(correctObject(fluShotTestResult));
                }
            }
            
            if ($(".awvFluShotDiv:visible").length > 0) {
                var awvFluShotTestResult = GetAwvFluShotData();
                if (awvFluShotTestResult != null) {
                    newTestArray.push(correctObject(awvFluShotTestResult));
                }
            }
            
            if ($(".PneumococcalDiv:visible").length > 0) {
                var pneumococcalTestResult = GetPneumococcalData();
                if (pneumococcalTestResult != null) {
                    newTestArray.push(correctObject(pneumococcalTestResult));
                }
            }
            if ($(".chlamydiaDiv:visible").length > 0) {
                var chlamydiaTestResult = GetChlamydiaData();
                if (chlamydiaTestResult != null) {
                    newTestArray.push(correctObject(chlamydiaTestResult));
                }
            }
            
            if ($(".QuantaFloABIDiv:visible").length > 0) {
                var quantaFloAbiTestResult = GetQuantaFloABIData();
                if (quantaFloAbiTestResult != null) {
                    newTestArray.push(correctObject(quantaFloAbiTestResult));
                }
            }
            
            if ($(".DpnDiv:visible").length > 0) {
                var dpnTestResult = GetDpnData();
                if (dpnTestResult != null) {
                    newTestArray.push(correctObject(dpnTestResult));
                }
            }
            if ($(".myBioCheckAssessmentDiv:visible").length > 0) {
                var myBioCheckTestResult = GetMyBioCheckAssessmentData();
                if (myBioCheckTestResult != null) {
                    newTestArray.push(correctObject(myBioCheckTestResult));
                }
            }
            if ($(".focDiv:visible").length > 0) {
                var focTestResult = GetFocData();
                if (focTestResult != null) {
                    newTestArray.push(correctObject(focTestResult));
                }
            }
            if ($(".csDiv:visible").length > 0) {
                var csTestResult = GetCsData();
                if (csTestResult != null) {
                    newTestArray.push(correctObject(csTestResult));
                }
            }
            debugger;
            if ($(".qvDiv:visible").length > 0) {
                var qvTestResult = GetQvData();
                if (qvTestResult != null) {
                    newTestArray.push(correctObject(qvTestResult));
                }
            }
            if ("<%= CapturePcpConsent%>" == "<%= Boolean.TrueString%>") {
                if (!PrimaryCarePhysicianFactory.isValid()) {
                    $(".save-button-container").toggle();
                    return false;
                }
                var model = PrimaryCarePhysicianFactory.get();
                if (model == null && primaryCarePhysicianData != null) {
                    var deleteComfrim = confirm("Are you sure want to delete Primary Care Physician");
                    if (deleteComfrim == false) {
                        $(".save-button-container").toggle();
                        return false;
                    }
                }
            }
            if ("<%= CapturePcpConsent%>" == "<%= Boolean.TrueString%>") {
                checkerCounter += 3;
            } else {
                checkerCounter += 2;
            }
            
            var customer = GetCustomerData();
            
            var isCustomerOnFastValue= null;
            
            if ("<%= ShowHideFastingStatus%>" == "<%= Boolean.TrueString%>") {
                var customerOnFast = $("#customerOnFastHidden").val();
                if (typeof(customerOnFast) !== "undefined" || customerOnFast != "") {
                    isCustomerOnFastValue = customerOnFast;
                }
            } else {
                isCustomerOnFastValue = false;
            }

            if ("<%= CapturePcpConsent%>" == "<%= Boolean.TrueString%>") {
                
                var pcpUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetPrimaryCarePhysician") %>';
                var pcpparameter = "{'model' : " + JSON.stringify(model) + ",'customerId' : " + customerId + "}";
                InvokeServicewithErrorMethodName(pcpUrl, pcpparameter, OnComplete, OnError);
            }
            

            var messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetCustomer") %>';
            var parameter = "{'model' : " + JSON.stringify(customer) + "}";
            InvokeServicewithErrorMethodName(messageUrl, parameter, OnComplete, OnError);

            var basicBiometric = getBasicBiometric();
            var priorityInQueueNote = $.trim($('#PriorityInQueueNote').val());
            priorityInQueueNote = priorityInQueueNote.replace(/\?\?+/gi, "?");

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetAllResultswithBasicBiometric") %>';
       
            

            parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testResultStrings' : " + JSON.stringify(newTestArray) + ", 'basicBiometric' : " + (basicBiometric == null ? "null" : JSON.stringify(basicBiometric)) + ", 'sendToOverreadPhysician' : '<%= SendToOvereadPhysician %>', 'organizationRoleUserId' : '" + $("#hfTechnicianId").val() + "','numberOfCriticalTestSaved' : '" + parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) + "', 'isPriorityInQueue' : '" + $("#<%= PriorityInQueueCheckbox.ClientID %>").attr('checked') + "', 'priorityInQueueNote' : " + JSON.stringify(priorityInQueueNote) + ",'isFastingStatus' : '" + isCustomerOnFastValue +
                "','criticalTestIds' : "+JSON.stringify(criticalTestIds)+"}";
            
            var isCriticalPatient = false;
            if($('span[id*="critical-span"] input[type="checkbox"]:checked').length > 0 || $('span[id*="priorityInQueue-span"] input[type="checkbox"]:checked').length > 0 || $('input[name*="PriorityInQueueCheckbox"]').is(":checked"))
                isCriticalPatient=true;

            /*if (isCriticalPatient) {
                openCriticalQuestionDialog(InvokeServicewithErrorMethodName, messageUrl, parameter);
            } else {*/
            InvokeServicewithErrorMethodName(messageUrl, parameter,
                function (result) {
                  
                    if (result.d.CriticalMailSent) {
                        alert("Critical email notification sent successfully.");
                    }
                    OnComplete(result);
                },
                OnError);
            //}
        }

        function GetTestIdCriticalMark()
        {
            var testIds;
            $('span[id*="critical-span"] input[type="checkbox"]').each(function(index,item){
                console.log(item);
            });
        
        }


        function correctObject(obj) {
            obj.TechnicianNotes = obj.TechnicianNotes.replace(/\?\?+/gi, "?");;
            if (obj.PhysicianInterpretation != null && obj.PhysicianInterpretation.Remarks != null && obj.PhysicianInterpretation.Remarks !="")
            {
                obj.PhysicianInterpretation.Remarks = obj.PhysicianInterpretation.Remarks.replace(/\?\?+/gi, "?");
            }
             
            return JSON.stringify(obj);
        }

        function skipevaluationFornotContainingReviewable() {
            var isNewResultFlow = $("#IsNewResultFlowInputHidden").val();
            InvokeServicewithErrorMethodName('/App/Franchisee/Technician/AuditResultEntry.aspx/SkipEvaluationfornotContainingReviewableTest', "{'eventId' : '" + eventId + "', 'customerId' : '" + customerId + "', 'isNewResultFlow' : '" + isNewResultFlow + "'}",
                function () { doNavigation(); }, function () { alert('OOPS! Some error occured.'); doNavigation(); });
        }

        function skipevaluation() {
            var isNewResultFlow = $("#IsNewResultFlowInputHidden").val();
            InvokeServicewithErrorMethodName('/App/Franchisee/Technician/AuditResultEntry.aspx/UpdateRecordforSkipEvaluation', "{'eventId' : '" + eventId + "', 'customerId' : '" + customerId + "', 'isNewResultFlow' : '" + isNewResultFlow + "'}",
                function () { doNavigation(); }, function () { alert('OOPS! Some error occured.'); doNavigation(); });
        }


        function unMarkSkipevaluation() {
            InvokeServicewithErrorMethodName('/App/Franchisee/Technician/AuditResultEntry.aspx/UnmarkSkipEvaluation', "{'eventId' : '" + eventId + "', 'customerId' : '" + customerId + "'}",
                function () { doNavigation(); }, function () { alert('OOPS! Some error occured.'); doNavigation(); });
        }

        var count = 0;
        var faultCount = 0;

        function OnComplete(arg) {
            count++;
            
            if ((faultCount + count) == checkerCounter) {
                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>' && (medicalHistorySaved != true || $(".conductedby-ddl option:selected").val() == "0")) {
                    doNavigation();
                    return;
                }

                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>' && '<%= TestSection.ContainsReviewableTests %>' == '<%= Boolean.FalseString %>') {
                    skipevaluationFornotContainingReviewable();
                }
                else if ($(".skip-evaluation-checkbox").attr("checked")) {
                    skipevaluation();
                }
                else {
                    unMarkSkipevaluation();
                }
            }
        }

        var onceEnterTimeOut = false;
        var onceEnterError = false;

        function OnTimeOut(arg) {
            if (!onceEnterTimeOut) {
                $(".save-button-container").toggle();
                onceEnterTimeOut = true;
            }
            alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");

            faultCount++;

            if ((faultCount + count) == checkerCounter) {
                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>' && (medicalHistorySaved != true || $(".conductedby-ddl option:selected").val() == "0")) {
                    doNavigation();
                    return;
                }

                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>' && '<%= TestSection.ContainsReviewableTests %>' == '<%= Boolean.FalseString %>') {
                    skipevaluationFornotContainingReviewable();
                }
                else if ($(".skip-evaluation-checkbox").attr("checked")) {
                    skipevaluation();
                } else {
                    doNavigation();
                }
            }
        }

        function OnError(arg) {
            //debugger;
            if (!onceEnterError) {
                $(".save-button-container").toggle();
                onceEnterError = true;
            }
            alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");

            faultCount++;
            if ((faultCount + count) == checkerCounter) {
                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>' && (medicalHistorySaved != true || $(".conductedby-ddl option:selected").val() == "0")) {
                    doNavigation();
                    return;
                }

                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>' && '<%= TestSection.ContainsReviewableTests %>' == '<%= Boolean.FalseString %>') {
                    skipevaluationFornotContainingReviewable();
                }
                else if ($(".skip-evaluation-checkbox").attr("checked")) {
                    skipevaluation();
                } else {
                    doNavigation();
                }
            }
        }

        function skipAndNext() {

            if (parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) > 0) {
                alert("You have marked test(s) critical, so critical email notification will be sent.");
                sendCriticalMail(function () {
                    navigateNext();
                });
            }
            else {
                navigateNext();
            }
        }

        function doNavigation() {
            if ('<%=IsMedicare%>' == '<%= Boolean.TrueString %>') {
                window.parent.postMessage({ Action: 'ClosePopupWindowFromHip'}, '*');
            }
            
            if (!bolSaveandNext) {
                window.location = '<%= RedirecttoReferrerPageUrl() %>';
            }
            else {
                navigateNext();
            }
        }

        function navigateNext() {
            checkNoShowOrLeftWithoutScreening(nextCustomerId,true);
           
        }

        function SaveEvent(bolSaveOption) {
            var isTestNotPerformedDataProvied = TestNotPerformedValidation();
            if (isTestNotPerformedDataProvied) {
                if (isKynPurchased) {

                    var height = Number($.trim($('#HeightUnitsFeetInputText').val())) * 12 + Number($.trim($('#HeightUnitsInchInputText').val()));
                    var weight = $('#WeightInputText').val();

                    if (height < 1 || (isNaN(weight) || Number(weight) < 1)) {
                        if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>') {
                            alert("Please provide height and weight, this is mandatory for " + (isHKynPurchased? "HKYN" : "KYN") + " evaluation.");
                            return;
                        }
                        else if ('<%= Mode %>' == '<%= EditResultMode.ResultEntry %>') {
                            var ans = confirm("Height and weight are mandatory for " + (isHKynPurchased? "HKYN" : "KYN") + " evaluation. Are you sure you want to continue?");
                            if (ans == false) {
                                return;
                            }
                        }
                    }
                }
                if ("<%= ShowHideFastingStatus%>" == "<%= Boolean.TrueString%>") {
                    var isCustomerOnFast = $("#customerOnFastHidden").val();
                    //if(typeof(isCustomerOnFast)  === "undefined" || isCustomerOnFast == "") {
                    //    alert("Please select 'Is Customer On Fast ?'");
                    //    return;
                    //}    
                }
                var dobInput = $("#DOBInputText").val();
                if(typeof(dobInput)  === "undefined" || dobInput == "") {
                    alert("Please enter Date Of Birth.");
                    return;
                }

                <%--if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>') {
                    Validate();
                    if ($.trim(validationString).length > 0) {
                        alert(validationString);
                        return;
                    }   
                }--%>

                $(".save-button-container").toggle();
                bolSaveandNext = bolSaveOption;
                checkNoShowOrLeftWithoutScreening(customerId,false);

              
               
            }
        }

        function OnsuccessNoShowForSave(result){
            if(result.d.IsMarkedNoShowAndLeftWithoutScreening){
                alert("The Next Patient has been marked as No show/Patient left by another agent.");
                window.location = '<%= RedirecttoReferrerPageUrl() %>';
            }
            else if(result.d.IsNewResultFlow && result.d.IsChartSignedOff == false && '<%= Mode %>' != '<%= EditResultMode.ResultEntry %>'){
                alert("The Patient chart has not been signed, Please wait for Chart signed before Pre-Audit..");
                window.location = '<%= RedirecttoReferrerPageUrl() %>';
            }
            else
            {
                if ('<%= Mode %>' == '<%= EditResultMode.ResultCorrection %>') {
                    $("#ReasonForSendBackCorrectionDiv").dialog("open");
                }
                else
                    checkBeforeSavingResults();
            }
    }

    function OnsuccessNoShowForNext(result) {
        if(result.d.IsMarkedNoShowAndLeftWithoutScreening){
            alert("The Next Patient has been marked as No show/Patient left by another agent.");
            window.location = '<%= RedirecttoReferrerPageUrl() %>';
            }
            else if(result.d.IsNewResultFlow && result.d.IsChartSignedOff == false && '<%= Mode %>' != '<%= EditResultMode.ResultEntry %>'){
                alert("The Patient chart has not been signed, Please wait for Chart signed before Pre-Audit.");
                window.location = '<%= RedirecttoReferrerPageUrl() %>';
            }
            else {
                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>')
                    window.location = '/App/Franchisee/Technician/AuditResultEntry.aspx?modeaudit&EventId=' + eventId + '&CustomerId=' + nextCustomerId;
                else
                    window.location = '/App/Franchisee/Technician/AuditResultEntry.aspx?EventId=' + eventId + '&CustomerId=' + nextCustomerId;
            }
           <%-- if(result.d){
                alert("The Next Patient has been marked as No show/Patient left by another agent.");
                window.location = '<%= RedirecttoReferrerPageUrl() %>';
            }
            else {
                if ('<%= Mode %>' == '<%= EditResultMode.ResultPreAudit %>')
                    window.location = '/App/Franchisee/Technician/AuditResultEntry.aspx?modeaudit&EventId=' + eventId + '&CustomerId=' + nextCustomerId;
                else
                    window.location = '/App/Franchisee/Technician/AuditResultEntry.aspx?EventId=' + eventId + '&CustomerId=' + nextCustomerId;
            } --%>
        }

        function checkNoShowOrLeftWithoutScreening(custId,isNextCustomer) {
            
            var isNewResultFlow = $("#IsNewResultFlowInputHidden").val();
            var parameters = "{'customerId':'" + custId + "'";
            parameters += ",'eventId':'" + eventId +"','isNewResultFlow':'" + isNewResultFlow + "','urlPath':'<%= Request.Url.AbsolutePath %>'}";
            var url = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/CheckCustomerNoShowOrLeftWithoutScreening") %>';
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: url,
                data: parameters,
                success: function (result) {
                    if(isNextCustomer){
                        OnsuccessNoShowForNext(result);
                    }else{
                        OnsuccessNoShowForSave(result);
                    }
                },
                error: function (a, b, c) {
                }
            });
            
        }
        function customerMarkNoShow()
        {
            alert("The Patient has been marked as No show/Patient left by another agent.");
            window.location = '<%= RedirecttoReferrerPageUrl() %>';
        }
        
        function customerChartIsUnsigned()
        {
            alert("The Patient chart has not been signed, Please wait for Chart signed before Pre-Audit.");
            window.location = '<%= RedirecttoReferrerPageUrl() %>';
        }

        function checkOnCustomerFastChange(isFast){
            $("#customerOnFastHidden").val(isFast);
        }

        /*var validationString = "";
        function Validate() {
            validationString = "";

            if ($(".FloChecABIDiv").is(":visible")) {
                validateTest($(".FloChecABIDiv"), "Flo Chec");
            }
            if ($(".QuantaFloABIDiv").is(":visible")) {
                validateTest($(".QuantaFloABIDiv"), "QuantaFlo ABI");
            }
        }

        function validateTest(sectionToCheck, testname) {
            if (sectionToCheck.length < 1) return true;

            var message = "";
            if (sectionToCheck.find(".unable-to-screen-section").find("input[type='checkbox']:checked").length > 0)
                return true;

            if (sectionToCheck.find("input[type='checkbox'].alt-conclusion-skipfinding-check:checked").length > 0)
                return true;

            if (sectionToCheck.find("input[type='radio'].alt-conclusion-skipfinding-check:checked").length > 0)
                return true;

            if (sectionToCheck.find(".test-not-performed-container:visible").length > 0)
                return true;

            if (sectionToCheck.find(".finding-section:visible").length > 1) {
                var allFindings = true;
                sectionToCheck.find(".finding-section:visible").each(function() {
                    if ($(this).find("input[type='radio']:checked").length < 1) {
                        allFindings = false;
                    }
                });
                if (!allFindings) message += "<li> Findings are not marked. </li>";
            } else if (sectionToCheck.find(".finding-section:visible").length > 0 && sectionToCheck.find(".finding-section:visible").find("input[type='radio']:checked").length < 1) {
                message += "<li> Findings are not marked. </li>";
            }
            
            if (sectionToCheck.find(".finding-section-checkbox:visible").length > 1) {
                var allFindings = true;
                sectionToCheck.find(".finding-section-checkbox:visible").each(function() {
                    if ($(this).find("input[type='checkbox']:checked").length < 1) {
                        allFindings = false;
                    }
                });
                if (!allFindings) message += "<li> Findings are not marked. </li>";
            } else if (sectionToCheck.find(".finding-section-checkbox:visible").length > 0 && sectionToCheck.find(".finding-section-checkbox:visible").find("input[type='checkbox']:checked").length < 1) {
                message += "<li> Findings are not marked. </li>";
            }

            //PP Echo
            if (sectionToCheck.find("#PpDiastolicDysfunctionCheckbox").length == 1 && $("#PpDiastolicDysfunctionCheckbox").is(":checked") && $(".Ppdiastolic-dysfunction-finding input[type='radio']:checked").length == 0) {
                message += "<li> Please select Grade for Diastolic dysfunction. </li>";
            }

            if ($.trim(message).length > 0)
                validationString += "<div style='clear:both;'> <b>"+testname + "</b><br/> <ul>" + message + "</ul></div>";
            return false;
        }*/
    </script>
    <script language="javascript" type="text/javascript">
        function DefaultErrorMethod() {
            alert("Oops! a problem occured in the system.");
        }

        function InvokeService(messageUrl, parameter, successFunction) {
            InvokeServicewithErrorMethodName(messageUrl, parameter, successFunction, DefaultErrorMethod);
        }

        function InvokeServicewithErrorMethodName(messageUrl, parameter, successFunction, errorMethod) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function (result) {
                    successFunction(result);
                },
                error: function (a, b, c) {

                    errorMethod();
                }

            });
        }


        function FillCity(cities) {
            for (var i = 0; i < cities.d.length; i++) {
                var currentSearchItem = cities.d[i];
                var htmlElement = $("<div class='searchresult'>" + currentSearchItem.Name + "</div>");
                $("#results").append(htmlElement);
            }

            $(".searchresult").each(function (i) {
                $(this).click(function () {
                    $("#CityInputText").val(cities.d[i].Name);
                    $(".city_id").val(cities.d[i].CityID);
                    $("#results").hide();
                    $("#results").empty();
                });
            });

            $(document).bind("click", function () {
                $('#results').hide();
                $("#results").empty();
            });

            $("#results").show();
        }

        function SetTabIndex() {
            var tabIndex = 0;
            $('#NameBlankLineInput').focus();
            $('input, select').each(function () {
                $(this).attr('tabindex', tabIndex);
                tabIndex++;
            });

        }
    </script>
    <script language="javascript" type="text/javascript">
        var _saveCriticalDataForm = false;
        var _criticalCheckBoxRef = null;

        function onCloseCritcalData() {
            if (!_saveCriticalDataForm && _criticalCheckBoxRef != null) {
                alert("Critical patient form is required for the followups with this patient. Please fill it!");
                _criticalCheckBoxRef.attr("checked", false);
                _criticalCheckBoxRef.click();
                _criticalCheckBoxRef.attr("checked", false);
            }
        }

        function loadScreen(testId, technicianControl, setMethodRef) {
            _saveCriticalDataForm = false;

            $.ajax({
                type: "GET",
                cache: false,
                dataType: "html",
                url: "/Medical/CustomerEventCriticalData/Edit?theeventId=" + eventId + "&thecustomerId=" + customerId + "&thetestId=" + testId,
                data: "{}",
                success: function (result) {
                    $("#customerCriticalDataDiv").empty();
                    $("#customerCriticalDataDiv").append(result);

                    loadControl(setMethodRef, (function () { $("#customerCriticalDataDiv").dialog('close'); }), '<%= TestResultStateNumber.PreAudit %>');
                    if (isCriticalFormOpenForEdit) {
                        _saveCriticalDataForm = true;
                    }
                },
                error: function (a, b, c) { alert('Some error loading the Customer Critical Data. Please try opening the page again'); $("#customerCriticalDataDiv").dialog('close'); }
            });
        }

        function openCriticalDataDialog(testId, technicianControl, criticalCheckboxRef, setMethodRef) {
            //$("#customerCriticalDataDiv").dialog('open');
            //_criticalCheckBoxRef = criticalCheckboxRef;
            //loadScreen(testId, technicianControl, setMethodRef);
        }

        function saveSingleTestResult(testResult, criticalTestData, criticalSpanJobj, loadMethodstring, setDataMethod, printAfterSave) {

            var testResultString = '';
            if (testResult != null) {
                testResultString = JSON.stringify(testResult);
            }

            var criticalTestDataString = '';
            if (criticalTestData != null) {
                criticalTestDataString = JSON.stringify(criticalTestData);
                criticalTestDataString = criticalTestDataString.replace(/'/gi, "\\\'").replace(/\\\"/gi, "\\\\\"");
            }

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetTestResult") %>';
            parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testResultString' : " + JSON.stringify(testResultString) + ", 'criticalDataString' : '" + criticalTestDataString + "', 'organizationRoleUserId' : '" + $("#hfTechnicianId").val() + "', 'resultState' : '" + '<%= (long)TestResultStateNumber.PreAudit %>' + "', 'pageUrl':'<%= Request.Url.AbsolutePath %>'}";
            InvokeServicewithErrorMethodName(messageUrl, parameter, function (result) {
                //debugger;
                _saveCriticalDataForm = true;
                //$("#<%=hfCriticalTestSavedCounter.ClientID %>").val(parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) + 1);
                var testResult = removeTypeAttribute(result.d);
                testResult = CorrectDateissue(testResult);
                setDataMethod(testResult);
                $("#customerCriticalDataDiv").dialog('close');
                if (printAfterSave) {
                    var linkTag = criticalSpanJobj.find("img.critical-data-print-img").parents("a:first");
                    if (linkTag.length > 0) {
                        window.open(linkTag.attr("href"), "Print", "width=500, height=100");
                    }

                }
                alert("Critical email notification sent successfully.");
            }, function () { alert("Some error occured while saving the data."); $("#customerCriticalDataDiv").dialog('close'); });
        }

        
        function loadCriticalLink(criticalSpanJobj, loadMethodstring, testId) {
            criticalTestIds.push(testId);
         
            //if (criticalSpanJobj.find("img.critical-data-load-img").length < 1) {
            //    criticalSpanJobj.append("<img class='critical-data-load-img' src='/App/Images/info-icon-red.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' onclick='" + loadMethodstring + "' /> ");
            //    criticalSpanJobj.append("<a target='_blank' href='/Medical/CustomerEventCriticalData/Print?eventId=" + eventId + "&customerId=" + customerId + "&testId=" + testId + "'><img class='critical-data-print-img' src='/App/Images/printer.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' /></a>");
            //}
        }

        function unloadCriticalLink(criticalSpanJobj, testId) {//debugger;
            for(var i = criticalTestIds.length - 1; i >= 0; i--) {
                if(criticalTestIds[i] === testId) {
                    criticalTestIds.splice(i, 1);
                }
            }
          
          <%--  if (criticalSpanJobj.find("img.critical-data-load-img").length > 0) {

                messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/DeleteCriticalData") %>';
                parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testId' : '" + testId + "'}";
                InvokeServicewithErrorMethodName(messageUrl, parameter, function (result) {
                    if (parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) > 0) {
                        $("#<%=hfCriticalTestSavedCounter.ClientID %>").val(parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) - 1);
                    }
                    criticalSpanJobj.find("img.critical-data-load-img").remove();
                    criticalSpanJobj.find("img.critical-data-print-img").remove();
                }, function (a, b, c) { alert("Some error occured while deleting critical data."); });
            }--%>
        }

    </script>

    <script language="javascript" type="text/javascript">
        
        var _savePriorityInQueTestForm = false;
        var _priorityInqueueTestCheckBoxRef = null;
        function onClosePriorityInQueueTest() {
            if (!_savePriorityInQueTestForm && _priorityInqueueTestCheckBoxRef != null) {

                _priorityInqueueTestCheckBoxRef.attr("checked", false);
                _priorityInqueueTestCheckBoxRef.click();
                _priorityInqueueTestCheckBoxRef.attr("checked", false);
            }
        }

        function loadPriorityInQueueTestScreen(testId, technicianControl, setMethodRef) {

            $.ajax({
                type: "GET",
                cache: false,
                dataType: "html",
                url: "/Medical/CustomerEventPriorityInQueueData/Edit?theeventId=" + eventId + "&thecustomerId=" + customerId + "&thetestId=" + testId,
                data: "{}",
                success: function (result) {
                    $("#customerPriorityinQueueTestDiv").empty();
                    $("#customerPriorityinQueueTestDiv").append(result);

                    loadPriorityinQueueTestPopup(setMethodRef, (function () { $("#customerPriorityinQueueTestDiv").dialog('close'); }), '<%= TestResultStateNumber.PreAudit %>');

                    if (isPriorityInQueueTestOpenForEdit) {
                        _savePriorityInQueTestForm = true;
                    }
                },
                error: function (a, b, c) { alert('Some error loading the Priority in queue note. Please try opening the page again'); $("#customerPriorityinQueueTestDiv").dialog('close'); }
            });
        }

        function openPriorityInQueueTestDialog(testId, technicianControl, priorityInQueueCheckboxRef, setMethodRef) {
            $("#customerPriorityinQueueTestDiv").dialog('open');
            _priorityInqueueTestCheckBoxRef = priorityInQueueCheckboxRef;
            loadPriorityInQueueTestScreen(testId, technicianControl, setMethodRef);
        }

        function saveSingleTestPriorityInQueueResult(testResult, priorityInQueueTestData, priorityInQueueSpanJobj, loadMethodstring, setDataMethod) {

            var testResultString = '';
            if (testResult != null) {
                testResultString = JSON.stringify(testResult);
            }

            var priorityInQueueTestDataString = '';
            if (priorityInQueueTestData != null) {
                priorityInQueueTestDataString = JSON.stringify(priorityInQueueTestData);
                priorityInQueueTestDataString = priorityInQueueTestDataString.replace(/'/gi, "\\\'").replace(/\\\"/gi, "\\\\\"");
            }

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetTestResultForPiq") %>';
            parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testResultString' : " + JSON.stringify(testResultString) + ", 'priorityInQueueTestDataString' : '" + priorityInQueueTestDataString + "', 'organizationRoleUserId' : '" + $("#hfTechnicianId").val() + "', 'resultState' : '" + '<%= (long)TestResultStateNumber.PreAudit %>' + "'}";
            InvokeServicewithErrorMethodName(messageUrl, parameter, function (result) {

                _savePriorityInQueTestForm = true;
                var testResult = removeTypeAttribute(result.d);
                testResult = CorrectDateissue(testResult);
                setDataMethod(testResult);
                $("#customerPriorityinQueueTestDiv").dialog('close');

            }, function () { alert("Some error occured while saving the data."); $("#customerPriorityinQueueTestDiv").dialog('close'); });
        }

        function loadPriorityInQueueLink(piqSpanJobj, loadMethodstring, testId) {
            if (piqSpanJobj.find("img.priorityInQueue-data-load-img").length < 1) {
                piqSpanJobj.append("<img class='priorityInQueue-data-load-img' src='/App/Images/info-icon-red.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' onclick='" + loadMethodstring + "' /> ");
            }
        }

        function unloadPriorityInQueueLink(priorityInQueueSpanJobj, testId) {
            if (priorityInQueueSpanJobj.find("img.priorityInQueue-data-load-img").length > 0) {
                messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/DeletePriorityinQueueTestData") %>';
                parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testId' : '" + testId + "','modifiedByOrgRoleUserId' : '" + $("#hfTechnicianId").val() + "'}";
                InvokeServicewithErrorMethodName(messageUrl, parameter, function (result) {
                    <%-- if (parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) > 0) {
                        $("#<%=hfCriticalTestSavedCounter.ClientID %>").val(parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) - 1);
                    }--%>
                    priorityInQueueSpanJobj.find("img.priorityInQueue-data-load-img").remove();
                }, function (a, b, c) { alert("Some error occured while deleting Priority In Queue note."); });
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function onCancel() {
            if (parseInt($("#<%=hfCriticalTestSavedCounter.ClientID %>").val()) > 0) {
                alert("You have marked test(s) critical, so critical email notification will be sent.");
                sendCriticalMail(function () {
                    window.location = '<%= RedirecttoReferrerPageUrl() %>';
                });
            }
            else {
                window.location = '<%= RedirecttoReferrerPageUrl() %>';
            }
        }

        function sendCriticalMail(onsucessMethod) {
            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SendCriticalMail") %>';
            parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'organizationRoleUserId' : '" + $("#hfTechnicianId").val() + "'}";
            InvokeServicewithErrorMethodName(messageUrl, parameter, function (result) {
                alert("Critical email notification sent successfully.");
                onsucessMethod();
            }, function () { alert("Some error occured while saving the data."); });
        }
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            
            $("#priorityInQueue-dialog").dialog({ width: 650, autoOpen: false, title: 'Priority in Queue Reason', modal: true, resizable: false, draggable: true, dialogClass: 'no-close' });
            $("#priorityInQueue-dialog").bind('dialogclose', closePriorityInQueueInAuditResult);
            $('#PriorityInQueueNote').val($.trim($('#<%= PriorityInQueueText.ClientID %>').html()));
        });

        var isPriorityInQueueForEdit = false;
        function closePriorityInQueueInAuditResult() {

            if ($('#IsPriorityInQueueSetHidden').val() == 'False' && isPriorityInQueueForEdit == false) {
                $('#<%= PriorityInQueueCheckbox.ClientID %>').attr("checked", false);
            } else {
                $('#IsPriorityInQueueSetHidden').val('False');
            }
            if ($('#<%= PriorityInQueueText.ClientID%>').html().trim() != '') {
                $('#<%= PriorityInQueueReasonDisplayDiv.ClientID %>').show();
            }
            isPriorityInQueueForEdit = false;
        }

        function savePriorityInQueue(eventCustomerId, ctrl, notes) {
            $('#<%= PriorityInQueueText.ClientID %>').html(notes);
        }

        function onClickSetPriorityInQueueEdit() {
            var note = $.trim($('#<%= PriorityInQueueText.ClientID %>').html());
            $('#PriorityInQueueNote').val(note);
            isPriorityInQueueForEdit = true;
            onClickSetPriorityInQueue();
        }

        $(".sameAsPracticeAddress").click(function() {
            if ($(this).is(":checked")) {
                $(".mailingAddress").hide();
            } else {
                $(".mailingAddress").show();
            }
            PrimaryCarePhysicianFactory.copyAddress();
        });
    </script>
    <script type="text/javascript">

        var _submitFormAfterSavingCriticalData = false;

        function SetTestNotPerformedEnableDisabled(controlId) {
            var isAdminUser = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.FranchisorAdmin) %>';
            var contraller = $("#" + controlId);
            var booleanFalse = '<%= Boolean.FalseString %>';
            var selectedValue = $(contraller).find("select :selected").val();
            var testNotReadable = '<%= (long) TestNotPerformedReasonType.TestUnreadable %>';
            if (selectedValue === testNotReadable && isAdminUser === booleanFalse ) {
                //$(contraller).find("input").attr("disabled", true);
                $(contraller).find("select,input,textArea").attr("disabled", true);
            } else if(isAdminUser === booleanFalse) {
                $(contraller).find("select option").each(function() {
                    if ($(this).val() === testNotReadable) {
                        $(this).hide();
                    }
                });
            }
        }

        function openCriticalQuestionDialog(saveCallback, callbackUrl, callbackParameter) {
            $.ajax({
                type:"GET",
                url:"/Medical/CustomerEventCriticalData/GetCriticalPatientData?eventId=<%=EventId%>&customerId=<%=CustomerId%>",
                success:function(result) {
                    $("#critical-question-dialog").dialog("open");
                    $("#critical-question-dialog").bind("dialogclose", function() {
                        clearCriticalAnswers();
                        $(".save-button-container").toggle();
                        $("#critical-question-dialog").unbind("dialogclose");

                        if (!_submitFormAfterSavingCriticalData) return false;

                        saveCallback(callbackUrl, callbackParameter,
                            function (callbackResult) {
                                if (callbackResult.d.CriticalMailSent) {
                                    alert("Critical email notification sent successfully.");
                                }
                                OnComplete(callbackResult);
                            },
                            OnError);
                    });
                    if (result != null) {
                        $("#critical-question-dialog #eventCustomerId").val(result.EventCustomerId);
                        if (result.Answers != null && result.Answers.length > 0) {
                            setAnswers(result.Answers);
                        }
                    }
                },
                error:function() {
                    alert("Some error occurred while getting critical patient data.");
                }
            });
        }

        function closeCriticalDataDialog() {
            $("#critical-question-dialog").dialog("close");
        }

        function savePatientCriticalInfo() {
            if (isCriticalDataValid()) {
                var answers = new Array();
                $('span[questionid]:visible').each(function (spanIndex, spanElement) {
                    $(spanElement).find('input').each(function (inputIndex, inputElement) {
                        if ($(inputElement).is(':radio') && $(inputElement).is(':checked')) {
                            var questionId = $(spanElement).attr('questionid');
                            var note = $("textarea[questionid=" + questionId + "]").val();
                            answers.push({ QuestionId: questionId, Answer: $(inputElement).val(), Note: note });
                        }
                    });
                });
                if (answers.length <= 0) {
                    alert('Please answer all the questions.');
                    return;
                }

                var model = {
                    EventCustomerId: $("#critical-question-dialog #eventCustomerId").val(),
                    Answers:answers
                };

                $("#critical-question-dialog .save-critical-question").toggle();

                $.ajax({
                    type:"POST",
                    data:model,
                    url:"/Medical/CustomerEventCriticalData/SaveCriticalPatientData",
                    success:function(result) {
                        $("#critical-question-dialog .save-critical-question").toggle();
                        if (result.toLowerCase() == '<%=Boolean.TrueString.ToLower()%>') {
                            _submitFormAfterSavingCriticalData = true;
                            $(".save-button-container").toggle();
                            closeCriticalDataDialog();
                        } else {
                            alert("Some error occurred while saving critical patient data.");
                        }
                    },error:function() {
                        alert("Some error occurred while saving critical patient data.");
                    }
                });
            } else {
                alert('Please answer all the questions.');
            }
        }

        function isCriticalDataValid() {
            var allQuestionsAnswered = true;

            var radios = $("#critical-question-div").find(':radio');
            var radioNames={};
            radios.each(function(){
                radioNames[this.name] = true;
            });

            for(name in radioNames){
                var radioGroup = $("#critical-question-div").find('[name=' + name + ']');
                if( !radioGroup.filter(':checked').length ) {
                    allQuestionsAnswered = false;
                }
            }
            return allQuestionsAnswered;
        }

        function setAnswers(questionAnswers) {

            $.each(questionAnswers, function(index, qa) {
                var span = $("span[questionId='" + qa.QuestionId + "']");

                if (qa.Answer !== '') {
                    var values = qa.Answer;
                    var radio = $(span).find("input[name='questionid-" + qa.QuestionId + "'][value='" + values + "']");
                    $(radio).attr("checked", true);
                }
                    
                if (qa.Note !== '') {
                    var textarea = $("textarea[questionid='" + qa.QuestionId + "']");
                    $(textarea).val(qa.Note);
                }
            });
        }

        function clearCriticalAnswers() {
            var radios = $("#critical-question-div").find(':radio');
            $(radios).attr("checked", false);

            var textareas = $("#critical-question-div").find('textarea');
            $(textareas).val("");
        }

        function setRetestCheckbox(entity) {
            if (entity != null && entity.d != null) {
                $.each(entity.d, function(index, testId) {
                    $("#Retest_" + testId).attr("checked", true);
                });
            }
        }
    </script>
</asp:Content>

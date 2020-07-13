<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true"
    CodeBehind="UpdateEventCustomerProfile.aspx.cs" Inherits="Falcon.App.UI.App.Customer.UpdateEventCustomerProfile"
    Title="Update Personal Information" EnableEventValidation="false" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
    <style type="text/css">
        #results {
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

        .searchresult {
            height: 20px;
            width: 200px;
            border-bottom: 1px solid #7F9DB9;
            vertical-align: top;
            background: #f5f5f5;
        }

        .small {
            font: normal 9px arial;
        }

        .searchresult:hover {
            background-color: #ddd;
            cursor: hand;
        }

        .match {
            background-color: Yellow;
        }
    </style>

    <link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>

    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true" IncludeJTemplate="true"
        IncludeSexyComboBox="true" IncludeJQueryMaskInput="true" IncudeJQueryAutoComplete="true" />

    <script type="text/javascript" src="/Content/JavaScript/actb.js"></script>

    <script type="text/javascript" src="/Content/JavaScript/common.js"></script>

    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR ="../../Wizard/greybox/";
    
        function validateControls()
        {
            var enableTexting = $("input:radio[name$='enableTexting']");
            var txtCPhone = $("input:text[name$='txtPhoneCell']");
            var txtPHome = $("input:text[name$='txtPhoneHome']");

            if(isBlank(document.getElementById('<%= _txtFirstName.ClientID %>'), 'First Name'))
                return false;
                
            if(isBlank(document.getElementById('<%= _txtLastName.ClientID %>'), 'Last Name'))
                return false;
                
            // date of brith
            if(isBlank(document.getElementById('<%= _txtDateOfBrith.ClientID %>'), 'Date of Birth'))
                return false;
            
            var _txtDateOfBrith = document.getElementById("<%= _txtDateOfBrith.ClientID %>");

            if (ValidateDate(_txtDateOfBrith.value, "Date Of Birth") == false) {
                return false;
            }

            if (checkDate(_txtDateOfBrith.value, "Date Of Birth") == false) {
                return false;
            }

            if (CheckValidDOB(_txtDateOfBrith, "Date Of Birth can't be future date") == false) {
                return false;
            }

            if (Validate_CheckForBlank('<%= _txtEmail.ClientID %>') == true) {
                if (validateEmail(document.getElementById('<%= _txtEmail.ClientID %>'), "Email") != true)
                    return false;
            }

            if (document.getElementById('<%= _ddlGender.ClientID %>').value == "Select Gender") {
                alert('Please select Gender');
                document.getElementById('<%= _ddlGender.ClientID %>').focus();
                return false;
            }

            if(isBlank(document.getElementById('<%= _txtAddress.ClientID %>'), 'Address'))
                return false;
          
            if(!checkDropDown(document.getElementById('<%= ddlState.ClientID %>'), 'State'))
                return false;
                
            if(isBlank(document.getElementById('<%= _txtCity.ClientID %>'), 'City'))
                return false;
            
            if(isBlank(document.getElementById('<%= _txtZip.ClientID %>'), 'Zip Code'))
                return false;
            
            
            if(isBlank(document.getElementById('<%= _txtEmail.ClientID %>'), 'Email'))
                return false;
            
            if ('<%= IsUpdateProfile%>' == '<%= Boolean.FalseString%>') {
                if ($("input[name='<%=MarketingSourceDropDown.UniqueID %>_hidden']").val() == '') {
                    alert("Option for How did you hear about <%= IoC.Resolve<ISettings>().CompanyName %>?");
                    return false;
                }
            }
            
            if ('<%= EnableSmsNotification %>' == '<%= Boolean.TrueString %>') {
                if ($(enableTexting).is(":checked") == false) {
                    alert("Please select SMS alert");
                    return false;
                }
                
                if ($(enableTexting).is(":checked") && $(enableTexting+":checked").val() == 'rbtnEnableTexting' && $(txtCPhone).val() == "") {
                    alert("Please provide your cell number");
                    return false;
                }
            }



            if ('<%= EnableVoiceMailNotification %>' == '<%= Boolean.TrueString %>') {
                if('<%= rbtnEnableVoiceMail.Checked %>' == '<%= Boolean.FalseString %>' && '<%= rbtnDisableVoiceMail.Checked %>' == '<%= Boolean.FalseString %>')
                { alert("Please select Voice Mail alert");
                        return false;
                }
                if('<%= rbtnEnableVoiceMail.Checked %>' == '<%= Boolean.TrueString %>' && $(txtPHome).val() == "")
                {
                    alert("Please provide your Phone (Home) number");
                    return false;
                }
            }

            if ($('#<%= txtDownloadFilePin.ClientID %>').is(':visible') && '<%= IsPinRequiredForRole %>' == '<%= Boolean.TrueString %>') {
                if ($("#<%=txtDownloadFilePin.ClientID%>").val().length <4) {
                    alert("Download File Pin must be 4 digits");
                    return false;
                }
            }
            
            if($('#<%= UseSms.ClientID %>').is(':checked:visible')) {
                if ($("#<%= _txtPhoneCell.ClientID %>").val().length == 0) {
                    alert("Phone (Cell) is required to send otp by SMS.");
                    return false;
                }
            }
            if ($('#<%= sendOpt.ClientID %>').is(":checked")) {
                if ($('#<%= UseEmail.ClientID %>').is(":checked") || $('#<%= UseSms.ClientID %>').is(":checked")) {
                } else {
                    alert("Please select sms or email as Authentication mode");
                    return false;
                }
            }
            return true;
        }
    </script>

    <div class="maindiv_custdbrd">
        <div class="topbluebar top-bar">
            Register Event
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
        </div>
        <div class="wrapperuecp">
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" style="display: none;"
                runat="server">
            </div>
            <div class="divsteps_re" id="StepDiv" runat="server">
                <img src="../Images/Customer_step2n.gif" alt="" />
            </div>
            <div class="hrowh">
                <h2>Personal Information</h2>
            </div>
            <hr />
            <div class="hrow" style="display: none;">
                <label>
                    First Name:<sup>*</sup></label>
                <asp:TextBox ID="_txtFirstName" runat="server" CssClass="txtfldl"></asp:TextBox>
                <label>
                    Middle Name:</label>
                <asp:TextBox ID="_txtMiddleName" runat="server" CssClass="txtfldr" Width="120px"></asp:TextBox>
                <label>
                    Last Name:<sup>*</sup></label>
                <asp:TextBox ID="_txtLastName" runat="server" CssClass="txtfldl"></asp:TextBox>
            </div>
            <div class="hrow">
                <label>Name:</label>
                <label id="NameLabel" runat="server" style="width: 230px;"></label>
                <label>Waist:</label>
                <span class="left">
                    <asp:TextBox ID="_txtWaist" runat="server" CssClass="txtfldr" Width="120px" Style="margin-right: 10px;"></asp:TextBox>inch
                </span>
            </div>

            <div class="hrow">
                <label>
                    Date of Birth:<sup>*</sup></label>
                <span class="spndfld" id="DobTextboxSpan" runat="server">
                    <asp:TextBox ID="_txtDateOfBrith" runat="server" Width="95px" CssClass="txtfldr date-picker-dob"></asp:TextBox>
                    <span class="vsmall">mm/dd/yyyy</span>
                </span>
                <span id="DobLabelSpan" runat="server" class="spnfld">
                    <label id="DobLabel" runat="server" style="width: 75px;"></label>
                    <a id="dob-help-qtip"><b>?</b></a>
                    <span style="display: none" class="dob-help">If you change your Date of Birth then it will have direct implication on your medical results. If you really want to change it
                        then call <%= (!string.IsNullOrEmpty(IoC.Resolve<ISettings>().CustomerPortalPhoneTollFree) ? IoC.Resolve<ISettings>().CustomerPortalPhoneTollFree : IoC.Resolve<ISettings>().PhoneTollFree) %> (Toll-free).
                    </span>
                </span>
                <label>
                    Height:</label>
                <span class="left">
                    <asp:DropDownList ID="_ddlFeet" runat="server" Width="50px">
                        <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    </asp:DropDownList>
                    feet
                    <asp:DropDownList ID="_ddlInch" runat="server" Width="50px">
                        <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    </asp:DropDownList>
                    inch</span>
            </div>
            <div class="hrow">
                <label>
                    Gender<sup>*</sup></label>
                <span class="spnfld">
                    <asp:DropDownList ID="_ddlGender" runat="server" Width="80px" CssClass="txtfldl">
                        <asp:ListItem Text="Select Gender"></asp:ListItem>
                        <asp:ListItem Text="Male"></asp:ListItem>
                        <asp:ListItem Text="Female"></asp:ListItem>
                    </asp:DropDownList>
                </span>
                <label>
                    Weight <span class="vsmall">(lbs)</span> :</label>
                <asp:TextBox ID="_txtWeight" runat="server" CssClass="txtfldr" Width="120px"></asp:TextBox>
            </div>
            <div class="hrow">
                <label>
                    Race</label>
                <span class="spnfld">
                    <asp:DropDownList ID="_ddlRace" runat="server" Width="120px" CssClass="txtfldl">
                        <asp:ListItem Text="Select Race"></asp:ListItem>
                        <asp:ListItem Text="Caucasian"></asp:ListItem>
                        <asp:ListItem Text="African American"></asp:ListItem>
                        <asp:ListItem Text="Hispanic"></asp:ListItem>
                        <asp:ListItem Text="Asian"></asp:ListItem>
                        <asp:ListItem Text="Native American"></asp:ListItem>
                        <asp:ListItem Text="Other"></asp:ListItem>
                    </asp:DropDownList>
                </span>
                 <label style="display: none;">
                    SSN:</label>
                <asp:TextBox ID="_txtSsnNumber" runat="server" CssClass="txtfldr mask-ssn" Width="120px" Style="margin-right: 10px;display: none;"></asp:TextBox>
            </div>
            <div class="hrowh">
                <h2>Contact Details </h2>
            </div>
            <hr />
            <div class="hrow">
                <label>
                    Address:<sup>*</sup></label>
                <asp:TextBox ID="_txtAddress" runat="server" CssClass="txtfldl"></asp:TextBox>
                <label>
                    Phone (Cell):</label>
                <asp:TextBox ID="_txtPhoneCell" runat="server" CssClass="txtfldr mask-phone" Width="120px"></asp:TextBox>
            </div>
            <div class="hrow">
                <label>
                    Suite,Appts,etc.:</label>
                <asp:TextBox ID="_txtSuit" runat="server" CssClass="txtfldl"></asp:TextBox>
                <label>
                    Phone (Home):
                </label>
                <asp:TextBox ID="_txtPhoneHome" runat="server" CssClass="txtfldr mask-phone" Width="120px"></asp:TextBox>
            </div>
            <div class="hrow">
                <label>
                    Country:<sup>*</sup></label>
                <span class="spnfld">
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="120px" CssClass="">
                    </asp:DropDownList>
                </span>
                <label>
                    State:<sup>*</sup></label>
                <asp:DropDownList ID="ddlState" runat="server" Width="130px" CssClass="">
                </asp:DropDownList>
            </div>
            <div class="hrow">
                <label>
                    City:<sup>*</sup></label>
                <div class="spnfld">
                    <asp:TextBox ID="_txtCity" runat="server" Width="120px" CssClass="txtSearch" autocomplete="off"></asp:TextBox>
                    <br />
                    <div id="results" class=""></div>
                </div>
                <label>
                    Zip:<sup>*</sup></label>
                <asp:TextBox ID="_txtZip" runat="server" Width="100px"></asp:TextBox>
            </div>
            <div class="hrow">
                <label>
                    Phone (Office):
                </label>
                <asp:TextBox ID="_txtPhoneOffice" runat="server" CssClass="txtfldr mask-phone" Width="120px"></asp:TextBox>
                <div style="float: left; width: 100px; margin-right: 10px;">
                    <label style="width: 30px; margin-left: 5px;">Ext:</label>
                    <asp:TextBox ID="PhoneOfficeExtension" runat="server" Width="50px"></asp:TextBox>
                </div>
                <label>
                    Email:<sup>*</sup></label>
                <asp:TextBox ID="_txtEmail" runat="server" CssClass="txtfldr" Width="120px"></asp:TextBox>


            </div>
            <div class="hrow marketing-source">
                <div style="float: left; width: 350px;">
                    <span class="orngbold12_default">How did you hear about this Event!?</span>
                    <br />
                    <label>
                        Marketing Source:<sup>*</sup></label>
                    <br />
                    <asp:DropDownList runat="server" ID="MarketingSourceDropDown" Style="width: 200px;">
                    </asp:DropDownList>
                    <span class="small">E.g. Internet, Radio, Email, Flyer, Friend, Magazine, Television
                    etc.</span>
                </div>
                <div style="float: left">
                    <div class="enableTexting" style="width: 275px!important">
                        <label>Please confirm if you wish to receive SMS Alert?:<sup>*</sup></label>
                        <asp:RadioButton runat="server" ID="rbtnEnableTexting" GroupName="enableTexting" />
                        Yes
                        <asp:RadioButton runat="server" ID="rbtnDisableTexting" GroupName="enableTexting" />
                        No
                    </div>
                </div>
            </div>

            <div class="hrow marketing-source">
                <div style="float: left">
                    <div class="enableVoiceMail" style="width: 275px!important">
                        <label>Please confirm if you wish to receive Voice Mail Alert?:<sup>*</sup></label>
                        <asp:RadioButton runat="server" ID="rbtnEnableVoiceMail" GroupName="enableVoiceMail" />
                        Yes
                        <asp:RadioButton runat="server" ID="rbtnDisableVoiceMail" GroupName="enableVoiceMail" />
                        No
                    </div>
                </div>
            </div>
            <div class="hrow marketing-source">
            </div>
            <div class="hrowh authSetting">
                <h2>Authentication Settings </h2>
            </div>
            <hr class="authSetting"/>
            <div class="hrow" id="downLoadPinhrow">
                <label>
                    Download File Pin:</label>
                <label style="width: 30px; margin-left: 5px;"><a id="viewDownloadPin" href="javascript:void(0)">View</a></label>

                <div id="getPassword" style="display: none;">
                    Please Enter Password
                   
                    <input id="pinPassword" name="pinPassword" style="width: 150px;" value="" type="password" />
                    <input value="Show" id="showPin" type="button" />

                    <input runat="server" class="numericOnly" id="txtDownloadFilePin" maxlength="4" name="DownloadFilePin" style="margin-left: 10px; width: 50px; display: none;" value="" type="text" />
                </div>
            </div>

            <div class="hrow" id="otpModehrow">
                <label>Authentication Mode:</label>
                <asp:RadioButton ID="sendOpt" runat="server" GroupName="otpMode" />
                Send OTP
                <asp:RadioButton ID="useApp" runat="server" GroupName="otpMode" />
                Google Authenticator <a id="displyQrCode" href="javascript:void(0)" style="display: none;">Display QR Code</a>
                
                <br/>
                <div id="otpModes" style="display: none; margin-left: 122px;">
                    <div id="isOtpByEmailEnabled" style="display: none;">
                        <asp:CheckBox ID="UseEmail" runat="server" />
                        Email
                    </div>
                    <div id="isOtpBySmsEnabled" style="display: none;">
                        <asp:CheckBox ID="UseSms" runat="server" />
                        Sms
                    </div>
                </div>
                <div id="appModes" style="display: none; margin-left: 2px;">
                    <p>
                        Use the QR code to add Matrix Medical Network account to Google Authenticator app:
                    </p>
                    <p>
                        <div id="qrCodeDiv" style="margin-left: 120px;">
                            Qr code will be ajaxed here

                        </div>
                    </p>
                </div>
            </div>


        <div class="hrow marketing-source">
        </div>
        <div class="hrow marketing-source">
        </div>
        <div class="hrowh">
            <div class="buttoncon_default">
                <asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="~/App/Images/next-buton.gif"
                    OnClientClick="return validateControls();" OnClick="ibtnNext_Click" />
            </div>
            <div class="buttoncon_default">
                <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/App/Images/cancel-btn.gif"
                    OnClick="ibtnCancel_Click" />
            </div>
        </div>

    </div>
    </div>
    <input type="hidden" id="_hfCountryId" runat="server" />

    <script language="javascript" type="text/javascript">
        
        $(document).ready(function() { 
            if ('<%= IsAuthenticationForUserEnabled %>' == '<%= Boolean.TrueString %>' || '<%= IsPinRequiredForRole %>' == '<%= Boolean.TrueString %>') {
                $('.authSetting').show();
            }
            else { 
                $('.authSetting').hide();
            }
            if ('<%= IsPinRequiredForRole %>' == '<%= Boolean.TrueString %>') {
                $('#downLoadPinhrow').show();
                
                $('#viewDownloadPin').click(function() {
                    $('#getPassword').show();
                });


                $('#showPin').click(function loadPriorityInQueueTestScreen() {
                    var userId = '<%= UserId %>';
                    var pwd = $('#pinPassword').val();
                    if (pwd == '') {
                        alert('Please Enter Password');
                        return;
                    }
                    $.ajax({
                        type: "GET",
                        cache: false,
                        url: "/Users/Profile/ValidateUserAndGetPin?password=" + pwd + "&userId=" + userId,
                        success: function(result) {
                            if (result.IsValid == true) {
                                $("#<%=txtDownloadFilePin.ClientID%>").val(result.Pin).show();
                            } else {
                                $("#txtDownloadFilePin").val('').hide();
                                alert('Password is not valid');
                                $('#pinPassword').val('').focus();
                            }
                        },
                        error: function() { alert('Some error'); }
                    });
                });
            } else {
                $('#downLoadPinhrow').hide();
            }
            

            if ('<%=IsAuthenticationForUserEnabled%>' == '<%= Boolean.TrueString %>' && ('<%= IsOtpBySmsEnabled %>' == '<%= Boolean.TrueString %>' || '<%= IsOtpByEmailEnabled %>' == '<%= Boolean.TrueString %>'|| '<%= IsOtpByAppEnabled %>' == '<%= Boolean.TrueString %>')) {

                $('#otpModehrow').show();
                
                ('<%= IsOtpByEmailEnabled %>' == '<%= Boolean.TrueString %>')?$('#isOtpByEmailEnabled').show() : $('#isOtpByEmailEnabled').hide();
                ('<%= IsOtpBySmsEnabled %>' == '<%= Boolean.TrueString %>')?$('#isOtpBySmsEnabled').show() : $('#isOtpBySmsEnabled').hide();
                ('<%= IsOtpByAppEnabled %>' == '<%= Boolean.TrueString %>')?$('#<%=useApp.ClientID%>').show() : $('#<%=useApp.ClientID%>').hide();
                    
                $('#<%= sendOpt.ClientID %>').change(function () {

                    onSendOptChange();
                });

                function onSendOptChange() {
                    if ($('#<%= sendOpt.ClientID %>').is(":checked")) {
                        $('#otpModes').show();
                    }
                    else {
                        $('#otpModes').hide();
                    }

                    if ($('#<%= useApp.ClientID %>').is(":checked")) {
                        $('#appModes').show();
                    }
                    else {
                        $('#appModes').hide();
                    }
                    $('#displyQrCode').hide();
                }


                $('#<%= useApp.ClientID %>').change(function () {
                    onSendOptChange();
                });

                if ('<%=AuthenticationModeId%>' != 'null' && ('<%=AuthenticationModeId%>' == '<%=(long)AuthenticationMode.Email%>') || ('<%=AuthenticationModeId%>' == '<%=(long)AuthenticationMode.Sms%>')|| ('<%=AuthenticationModeId%>' == '<%=(long)AuthenticationMode.BothSmsEmail%>')) {
                    $('#<%= sendOpt.ClientID %>').attr('checked', true);
                    onSendOptChange();
                    if('<%=AuthenticationModeId%>' == '<%=(long)AuthenticationMode.Email%>')
                    {$('#<%= UseEmail.ClientID %>').attr('checked', true);}
                    if('<%=AuthenticationModeId%>' == '<%=(long)AuthenticationMode.Sms%>')
                    { $('#<%= UseSms.ClientID %>').attr('checked', true);}
                    if('<%=AuthenticationModeId%>' == '<%=(long)AuthenticationMode.BothSmsEmail%>')
                    {  
                        $('#<%= UseSms.ClientID %>').attr('checked', true);
                        $('#<%= UseEmail.ClientID %>').attr('checked', true);
                    }
                } else if ('<%=AuthenticationModeId%>' != 'null' && ('<%=AuthenticationModeId%>' == '<%=(long)AuthenticationMode.AuthenticatorApp%>')){
                    $('#<%= useApp.ClientID %>').attr('checked', true);
                    $('#displyQrCode').show();
                    $('#displyQrCode').click(function() {
                        $('#appModes').show();
                    });
                }

                if ('<%= IsOtpByAppEnabled %>' == '<%= Boolean.TrueString %>') {
                    var userId = '<%= UserId %>';
                    $.ajax({
                        type: "GET",
                        cache: false,
                        url: "/Users/Profile/GetQrCode?userId=" + userId,
                        success: function(result) {
                            $('#qrCodeDiv').html(result);
                        },
                        error: function() { alert('Some error'); }
                    });
                }
            

            } else {
                $('#otpModehrow').hide();
            }



        });
    </script>
    <script type="text/javascript" language="javascript">

        function BindSateDropDown(stateList) {//debugger;
            $('#' + '<%=ddlState.ClientID %> >option').remove();

            if (stateList.length > 0) {
                $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val('0').html('Select State'));
                for (var i = 0; i < stateList.length; i++) {
                    if (stateList[i].CountryId == $('#' + '<%=ddlCountry.ClientID %>').val())
                        $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val(stateList[i].Id).html(stateList[i].Name));
                }
            }
            else {
                $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val('0').html('No State Found'));
            }
            if ($('#<%=hfstate.ClientID %>').val() != '') {
                $("#<%= ddlState.ClientID %> option:contains('" + $('#<%=hfstate.ClientID %>').val() + "')").first().attr('selected', true);
            }
        }

        function SetState() {
            $('#<%=hfstate.ClientID %>').val($('#<%=ddlState.ClientID %> option:selected').text());
        }

    </script>
    <script language="javascript" type="text/javascript">
        var states;
        
        $(document).ready(function () {
            states=<%= GetStates() %>;
            BindSateDropDown(states);

            $("#<%= MarketingSourceDropDown.ClientID %>").sexyCombo({hiddenSuffix: '_hidden', emptyText: 'Type here for quick search', triggerSelected: true});

            $('#<%=ddlCountry.ClientID %>').bind("change", function () { BindSateDropDown(states); });
            $('#<%=ddlState.ClientID %>').bind("change", function () { SetState(); });
            $(".txtSearch").keyup(function () {
                $("#results").empty();

                var searchString = $(".txtSearch").val();

                if (searchString.length < 3) {
                    return;
                }

                var parameter = "{'prefixText':'" + searchString + "'}";

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCitiesByPrefixText")%>',
                    data: parameter,
                    success: function(result) {
                        for (var i = 0; i < result.d.length; i++) {
                            var currentSearchItem = result.d[i];
                            var htmlElement = $("<div class='searchresult'>" + currentSearchItem.Name + "</div>");
                            $("#results").append(htmlElement);
                        }

                        $(".searchresult").each(function(i) {
                            $(this).click(function() {
                                //On click of a result div, the fullname will be written into the seachfield
                                var cityName = result.d[i].Name;
                                $(".txtSearch").val(cityName);
                                //Hide autocomplete suggestions
                                $("#results").hide();
                            });
                        });
                        $("#results").show();
                    },
                    error: function(a, b, c) {
                        alert(errorMessage);
                        $('#' + containerDiv).removeClass('loading');
                    }
                });

            });
            $('.mask-phone').mask('(999)-999-9999');
            $('.mask-ssn').mask('999-99-9999');
            
            if ('<%= IsUpdateProfile%>' == '<%= Boolean.TrueString%>') {
                $('.marketing-source').hide();
                $('.top-bar').html("Update Profile");
            }
            
            $("#dob-help-qtip").qtip({
                position: {
                    my: 'left top'
                },
                style: {
                    width: '500px'
                },
                content: {
                    title: "Help",
                    text: function (api) {
                        return $(this).parent().find(".dob-help").html();
                    }
                }
            });

            if('<%= EnableSmsNotification %>' == '<%= Boolean.FalseString %>')
            {
                $(".enableTexting").hide();
            }
            else
            {
                $(".enableTexting").show();
            }

            if('<%= EnableVoiceMailNotification %>' == '<%= Boolean.FalseString %>')
            {
                $(".enableVoiceMail").hide();
            }
            else
            {
                $(".enableVoiceMail").show();
            }
        });
    
    </script>
    <script language="javascript" type="text/javascript">
        $('.numericOnly').bind('keypress', function(evt) {
            console.log(evt.charCode);
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            if (evt.shiftKey == false) {
                if ((key >= 48 && key <= 57) ) {
                    return true;
                }
            }  
            evt.preventDefault();
            return false;
        });
    </script>
    <asp:HiddenField ID="hfstate" runat="server" />
</asp:Content>

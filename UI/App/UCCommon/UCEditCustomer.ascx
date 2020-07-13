<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCEditCustomer"
    CodeBehind="UCEditCustomer.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/ucupdatephotopanel.ascx" TagName="ucupdatephotopanel"
    TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/UCPCPInfo.ascx" TagName="UCPCPInfo" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>

<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" IncludeSexyComboBox="true" />
<%--<script src='<%=ResolveUrl("~/App/JavascriptFiles/actb.js") %>' language="javascript"
    type="text/javascript"></script>--%>
<script src='<%=ResolveUrl("~/App/JavascriptFiles/common.js") %>' language="javascript"
    type="text/javascript"></script>
<script language="javascript" type="text/javascript">

    function validatecontrols() {

        var txtOPhone = $("input:text[name$='txtphoneoffice']");
        var phoneHomeConsent = document.getElementById("<%=this.ddlPatientConsentPrimary.ClientID %>");
        var phoneCellConsent = document.getElementById("<%=this.ddlPatientConsentCell.ClientID %>");
        var phoneOfficeConsent = document.getElementById("<%=this.ddlPatientConsentOffice.ClientID %>");
        
        // if ($("#<%= ReasonDoNotContactDropdown.ClientID %> option[value=0]:selected").length > 0 && $("#<%= TypeDoNotContactDropdown.ClientID %> option[value=0]:selected").length > 0) {
        if (isBlank(document.getElementById('<%= this.txtfname.ClientID %>'), 'First Name'))
            return false;
        if (isBlank(document.getElementById('<%= this.txtlname.ClientID %>'), 'Last Name'))
            return false;

        if (isBlank(document.getElementById('<%= this.txtDOB.ClientID %>'), 'Date of Birth'))
            return false;

        var txtDOB = document.getElementById("<%= this.txtDOB.ClientID %>");
        if (ValidateDate(txtDOB.value, "Date Of Birth") == false)
        { return false; }

        if (checkDate(txtDOB.value, "Date Of Birth") == false)
        { return false; }
        if (CheckValidDOB(txtDOB, "Date Of Birth can't be future date") == false)
        { return false; }
            <%--if (rlstcntmethod.rows[0].cells[0].childNodes[0].checked == true) {
                if ((document.getElementById('<%= this.txtEmail1.ClientID %>')).value != "") {
                    if (Validate_CheckForBlank('<%= this.txtEmail1.ClientID %>') == true) {
                        if (validateEmail(document.getElementById('<%= this.txtEmail1.ClientID %>'), "Email") != true)
                            return false;
                    }
                }
            }--%>
        if (document.getElementById('<%= this.ddlgender.ClientID %>').value == "Select Gender") {
            alert('Please select Gender');
            document.getElementById('<%= this.ddlgender.ClientID %>').focus();
            return false;
        }

        if ($.trim($("#<%=LastScreeningDateTextbox.ClientID %>").val()).length > 0) {
            if (ValidateDate($("#<%=LastScreeningDateTextbox.ClientID %>").val(), "Last Screening Date") == false) {
                return false;
            }

            var dateToCompare = $("#<%=LastScreeningDateTextbox.ClientID %>").val();

            var today = new Date();
            var defyear = today.getYear();
            var y = defyear % 100;
            y += (y < 38) ? 2000 : 1900;

            var currentDate = new Date(y, today.getMonth(), today.getDate());

            var dateCompare = new Date(dateToCompare.split('/')[2], dateToCompare.split('/')[0] - 1, dateToCompare.split('/')[1]);

            if (currentDate.getTime() <= dateCompare.getTime()) {
                alert("Last Screening Date should be past date.");
                return false;
            }
        }

            <%-- if (rlstcntmethod.rows[0].cells[1].childNodes[0].checked == true) {
                if (!(document.getElementById('<%= this.txtphonecell.ClientID %>')).value.length > 0) {

                    if (!(document.getElementById('<%= this.txtphonehome.ClientID %>')).value.length > 0) {

                        if (!(document.getElementById('<%= this.txtphoneoffice.ClientID %>')).value.length > 0) {
                            alert('Please input any of the Phone(Cell),Phone(Home) or Phone(Other).')
                            return false;
                        }

                    }
                }
            }--%>

        if (isBlank(document.getElementById('<%= txtaddress1.ClientID %>'), 'Address1'))
            return false;

        if (!checkDropDown(document.getElementById('<%= ddlState.ClientID %>'), 'State'))
            return false;

        if (isBlank(document.getElementById('<%= txtcity.ClientID %>'), 'City'))
            return false;

        if (isBlank(document.getElementById('<%= txtzip.ClientID %>'), 'Zip Code'))
            return false;

        var email1 = $(document.getElementById('<%= txtEmail1.ClientID %>'));
        if ($.trim(email1.val()) != "") {
            if (validateEmail(email1, "Email") != true)
            { email1.focus(); return false; }
        }

        var otheremail = $(document.getElementById('<%= txtotheremail.ClientID %>'));
        if ($.trim(otheremail.val()) != "") {
            if (validateEmail(otheremail, "Other Email") != true)
            { otheremail.focus(); return false; }
        }

        var txtCPhone = $("input:text[name$='txtphonecell']");
        var txtPhonePrimary = $("input:text[name$='txtphonehome']");
        <%--if (isBlank(document.getElementById('<%= PreferredLanguageTextbox.ClientID %>'), 'Language')) {
            return false;
        }--%>
        if ($(document.getElementById('<%= PreferredLanguageDropDown.ClientID %>')).val() == "0") {
            alert("Please select preferred language");
            return false;
        }

        if ('<%= EnableSmsNotification %>' == '<%= Boolean.TrueString %>') {
            if ($("input:radio[name$='rbtnEnableTexting']").is(":checked") == false) {
                alert("Please select SMS alert");
                return false;
            }

            if ($("input:radio[name$='rbtnEnableTexting']").is(":checked") && $("input:radio[name$='rbtnEnableTexting']:checked").val() == 'true' && $(txtCPhone).val() == "") {
                alert("Please provide your cell number");
                return false;
            }
        }

        if ('<%= EnableVoiceMailNotification %>' == '<%= Boolean.TrueString %>') {
            if ($("input:radio[name$='rbtnEnableVoiceMail']").is(":checked") == false) {
                alert("Please select Voice Mail alert");
                return false;
            }

            if ($("input:radio[name$='rbtnEnableVoiceMail']").is(":checked") && $("input:radio[name$='rbtnEnableVoiceMail']:checked").val() == 'true' && $(txtPhonePrimary).val() == "") {
                alert("Please provide your Phone (Home) number");
                return false;
            }
        }
            
            <%--chkPCPDetails = document.getElementById('<%= chkPCPDetails.ClientID %>');
            if (chkPCPDetails.checked == true) {
                return ValidatePCP();
            }--%>
        //}
        
        if ($.trim($("#<%= ReasonDoNotContactnotes.ClientID %>").val()).length > 0 && $("#<%= ReasonDoNotContactDropdown.ClientID %> option[value=0]:selected").length > 0) {
            alert("Please select a reason for 'Do Not Contact' from the Dropdown provided");
            return false;
        }
        
        if ($.trim($("#<%= ReasonDoNotContactnotes.ClientID %>").val()).length > 0 && $("#<%= TypeDoNotContactDropdown.ClientID %> option[value=0]:selected").length > 0) {
            alert("Please select a Type for 'Do Not Contact' from the Dropdown provided");
            return false;
        }

        var reasonSelected = Number($("#<%= ReasonDoNotContactDropdown.ClientID %> option:selected").val());
        var typeSelected = Number($("#<%= TypeDoNotContactDropdown.ClientID %> option:selected").val());
        
        if (reasonSelected <= 0 && typeSelected > 0) {
            alert("Please select a reason for 'Do Not Contact' from the Dropdown provided");
            return false;
        }
        
        if (reasonSelected > 0 && typeSelected <= 0) {
            alert("Please select a Type for 'Do Not Contact' from the Dropdown provided");
            return false;
        }

        var preferredContact = $(document.getElementById('<%= ddlPreferredContactType.ClientID %>')).val();
        
        if (Number(preferredContact) > 0 && preferredContact === '<%= (long)Falcon.App.Core.Users.Enum.PreferredContactType.Email %>' && $.trim($(email1).val())=='') {
            $(email1).focus();
            alert("Please provide email id as you have selected Email as your Preferred Contact.");
            return false;
        }

        if ($(phoneOfficeConsent).val() != '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>' && ($(txtOPhone).val() == "(___)-___-____" || $(txtOPhone).val() == "")) {
            alert("Enter Phone(Office) to save consent");
            return false;
        }
        if ($(phoneCellConsent).val() != '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>' && ($(txtCPhone).val() == "(___)-___-____" || $(txtCPhone).val() == "")) {
            alert("Enter Phone(Cell) to save consent");
            return false;
        }
            
        if((email1.val() != "" || otheremail.val() != "") && $("input:radio[name$='rbtnEnableEmail'][value='false']").is(":checked"))
        {
            $("input:radio[name$='rbtnEnableEmail']").focus();
            var isContinue = confirm('Consent for Email is set to No. Do you wish to continue?');

            if(!isContinue)
                return false;
        }

        if ($(phoneCellConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>'
            && $(phoneOfficeConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>'
                && $(phoneHomeConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>') {
            var isContinue = confirm("Consent for all phone numbers is set to Unknown. Do you want to continue?");
                
            if (!isContinue)
                return false;
        }
        
        return PCPValidation();

        // return true;
    }


    function HandlePCPPanel() {
        var checkboxPCP = document.getElementById('<%= this.chkPCPDetails.ClientID %>');

        if (checkboxPCP.checked == false) {
            document.getElementById('divphysiciancare').style.visibility = 'hidden';
            document.getElementById('divphysiciancare').style.display = 'none';
        }
        else {
            document.getElementById('divphysiciancare').style.visibility = 'visible';
            document.getElementById('divphysiciancare').style.display = 'block';
        }

    }

    function txtkeypress(evt) {
        return KeyPress_NumericAllowedOnly(evt);
    }

    function validateEmail(Control, returnmessage) {

        var emailStr = $(Control).val();
        var reg1 = /(@.*@)|(\.\.)|(@\.)|(\.@)|(^\.)/; // not valid
        var reg2 = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/; // valid
        if (!reg1.test(emailStr) && reg2.test(emailStr)) {
            return true;
        } else {
            alert(returnmessage + ' is not a valid email address.');
            $(Control).focus();
            return false;
        }
    }

    function CheckContactMethod() {
        <%--var rlstcntmethod = document.getElementById("<%=this.rlstcntmethod.ClientID %>");
        var spEmailRequired = document.getElementById("<%=this.spEmailRequired.ClientID %>");
        if (rlstcntmethod.rows[0].cells[1].childNodes[0].checked == true) {
            spEmailRequired.style.display = "none";
            spEmailRequired.style.visibility = "hidden";
        }
        else {
            spEmailRequired.style.display = "";
            spEmailRequired.style.visibility = "visible";

        }--%>

    }

    function hideShowEmailConsentDiv()
    {
        var email1 = $(document.getElementById('<%= txtEmail1.ClientID %>'));
        var otheremail = $(document.getElementById('<%= txtotheremail.ClientID %>'));

        if($.trim(email1.val()) != "" || $.trim(otheremail.val()) != "")
            $("#dvEmailConsent").show();
        else
            $("#dvEmailConsent").hide();
    }
    
</script>
<style type="text/css">
    .inputf_accm {
        border: 1px solid #7F9DB9;
        background-color: #fff;
        font: normal 12px arial;
        color: #333;
        padding: 2px;
    }

    .list_amv {
        border: 1px solid #7F9DB9;
        background-color: #fff;
        font: normal 12px arial;
        color: #333;
        padding: 2px;
    }
</style>
<div class="mainbody_outer_fcr">
    <div class="mainbody_inner_fcr">
        <div class="main_area_bdrnone">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" />
                    </p>
                    <span class="orngheadtxt_heading" runat="server" id="sptitle">Edit Customer</span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="2px" />
                </p>
            </div>
            <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr_Editdata_fcr">
                <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>--%>
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" />
                    </div>
                    <div class="pgnosymbol_common">
                        <img src="/App/Images/page1symbolsmall.gif" />
                    </div>
                    <div class="orngheadtxt16_common">
                        About Customer
                    </div>
                </div>
                <%--<div class="uploadresumelnk_editp"> <a href="#"> Upload Resume</a></div>--%>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">First Name: <span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldcon_editp">
                        <asp:TextBox ID="txtfname" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox></span>
                    <span class="titletext_editp">Middle Name: </span><span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtmname" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox></span>
                </p>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Last Name:<span class="reqiredmark"><sup>*</sup> </span></span>
                    <span class="inputfieldcon_editp">
                        <asp:TextBox ID="txtlname" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                    </span>
                    <span class="titletext_editp">Date of Birth:<span class="reqiredmark"><sup>*</sup> </span></span>
                    <span class="inputfieldob_editp">
                        <asp:TextBox ID="txtDOB" ReadOnly="false" runat="server" CssClass="inputf_editp date-picker-dob" Width="100px"></asp:TextBox>
                        <span style="font-size: 7pt;">mm/dd/yyyy</span>
                    </span>
                </p>

                <p class="main_container_row_editp">
                    <span class="titletext_editp">Gender:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldcon_editp">
                        <asp:DropDownList ID="ddlgender" runat="server">
                            <asp:ListItem Text="Select Gender"></asp:ListItem>
                            <asp:ListItem Text="Male"></asp:ListItem>
                            <asp:ListItem Text="Female"></asp:ListItem>
                            <asp:ListItem Text="Others"></asp:ListItem>
                        </asp:DropDownList>
                    </span><span class="titletext_editp">Height: </span><span class="inputfieldrightcon_editp">
                        <span class="inputfldnowidth_default">
                            <asp:DropDownList ID="ddlFeet" runat="server" Width="40px">
                                <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                        </span><span class="ttxtnowidthnormal_default">feet</span> <span class="inputfldnowidth_default">
                            <asp:DropDownList ID="ddlInch" runat="server" Width="45px">
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
                        </span><span class="ttxtnowidthnormal_default">inch</span> </span>
                </p>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Race: </span><span class="inputfieldcon_editp">
                        <asp:DropDownList ID="ddlrace" runat="server">
                        </asp:DropDownList>
                    </span><span class="titletext_editp">Weight: </span><span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtweight" runat="server" CssClass="inputf_editp" Width="100px"></asp:TextBox>
                        lbs </span>
                </p>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Marketing Resource: </span>
                    <span class="inputfieldcon_editp">
                        <asp:DropDownList runat="server" ID="MarketingSourceDropDown" Style="width: 200px;">
                        </asp:DropDownList>
                    </span>
                    <span class="titletext_editp">Waist: </span>
                    <span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtwaist" runat="server" CssClass="inputf_editp" Width="100px"></asp:TextBox>
                        inch 
                    </span>
                </p>
                <p class="main_container_row_editp">
                    <span id="LastScreeningDateContainerSpan" runat="server">
                        <span class="titletext_editp">Last Screening Date: </span>
                        <span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="LastScreeningDateTextbox" runat="server" Width="100px" CssClass="inputf_editp date-picker"></asp:TextBox>
                        </span>
                    </span>
                </p>
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" />
                    </div>
                    <div class="pgnosymbol_common">
                        <img src="/App/Images/page2symbolsmall.gif" />
                    </div>
                    <div class="orngheadtxt16_common">
                        Contact Details (Home)
                    </div>
                    <div style="padding-top: 10px; margin-left: 10px;">
                        <asp:CheckBox ID="UpdateShippingAddressCheckbox" runat="server" Checked="true" Text="Update Shipping Address" />
                    </div>
                </div>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Address:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfieldcon_editp">
                        <asp:TextBox ID="txtaddress1" runat="server" CssClass="inputf_editp" Width="170px" TextMode="multiLine"></asp:TextBox>
                    </span>

                    <span class="titletext_editp">Suite,Apt,etc: </span>
                    <span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtaddress2" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                    </span>
                </p>

                <p class="main_container_row_editp">
                    <span class="titletext_editp">Country:<span class="reqiredmark"><sup>*</sup></span>
                    </span><span class="inputfieldcon_editp">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="inputf_accm" Width="110px"
                            AutoPostBack="False">
                        </asp:DropDownList>
                    </span><span class="titletext_editp">State:<span class="reqiredmark"><sup>*</sup></span>
                    </span><span class="inputfieldrightcon_editp">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="inputf_accm ddl-states"
                            Width="120px" AutoPostBack="False">
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">City:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldcon_editp">
                        <asp:TextBox ID="txtcity" runat="server" CssClass="inputf_accm auto-search-city"></asp:TextBox></span>
                    <span class="titletext_editp">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                    <span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtzip" runat="server" CssClass="inputf_accm"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Email:<span class="reqiredmark" id="spEmailRequired" runat="server"></span>
                    </span>

                    <span class="inputfieldcon_editp">
                        <asp:TextBox ID="txtEmail1" runat="server" CssClass="inputf_editp" Width="170px" onchange="hideShowEmailConsentDiv()"
                            MaxLength="500"></asp:TextBox>
                    </span>

                    <span class="titletext_editp">Other Email:</span>
                    <span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtotheremail" runat="server" Text="dwwekkan@hotmail.com" Width="170px" onchange="hideShowEmailConsentDiv()"
                            CssClass="inputf_editp"></asp:TextBox>
                    </span>

                </p>

                <div id="dvEmailConsent" style="clear: both; padding: 0px 10px;">
                    <div class="titletext_editp enableTexting">
                        Do you wish to receive Email?
                    </div>
                    <div class="radiobuttoncon_editp enableTexting">
                        <asp:RadioButtonList runat="server" Width="100px" CellPadding="1" RepeatDirection="horizontal"
                            RepeatColumns="2" ID="rbtnEnableEmail">
                            <asp:ListItem Text="Yes" Value="true"></asp:ListItem>
                            <asp:ListItem Text="No" Value="false"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="main_container_row_editp">
                    <div class="titletext_editp">Employer: </div>
                    <div class="inputfieldcon_editp">
                        <asp:TextBox ID="Employer" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                    </div>
                </div>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Emergency Contact Name:</span> <span class="inputfieldcon_editp">
                        <asp:TextBox ID="EmergencyContactName" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox></span>
                    <span class="titletext_editp">Relationship:</span> <span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="EmergencyContactRelationship" runat="server" CssClass="inputf_editp"
                            Width="170"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Emergency Contact PhoneNumber:</span>
                    <span class="inputfieldcon_editp">
                        <asp:TextBox ID="EmergencyContactPhoneNumber" runat="server" CssClass="inputf_editp mask-phone" Width="170"></asp:TextBox>
                    </span>
                    <span class="titletext_editp">SSN:</span>
                    <span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="SsnTextbox" runat="server" CssClass="inputf_editp mask-ssn" Width="170"></asp:TextBox>
                    </span>
                </p>
                <div class="main_container_row_editp" id="EmployeeIdInsuranceIdContainer" runat="server">
                    <div id="EmployeeIdContainer" runat="server">
                        <span class="titletext_editp">Employee Id:</span>
                        <span class="inputfieldcon_editp">
                            <asp:TextBox ID="EmployeeIdTextbox" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                        </span>
                    </div>
                    <div id="InsuranceIdContainer" runat="server">
                        <span class="titletext_editp" id="InsuranceIdLabel" runat="server">Insurance Id:</span>
                        <span class="inputfieldcon_editp">
                            <asp:TextBox ID="InsuranceIdTextbox" runat="server" CssClass="inputf_editp" Width="170"></asp:TextBox>
                        </span>
                    </div>
                    <div>
                        <span class="titletext_editp">Medicare Advantage Plan Name:</span>
                        <span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="MedicareAdvantagePlanName" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                        </span>
                    </div>
                </div>
                <% 
                    if (!IsRoleCallCenterAgentOrTechnician)
                    {
                %>
                <div class="main_container_row_editp">
                    <div>
                        <span class="titletext_editp">Is Eligible:</span>
                        <span class="inputfieldcon_editp">
                            <asp:DropDownList ID="ddlIsEligible" runat="server">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div>
                        <span class="titletext_editp">Activity:</span>
                        <span class="inputfieldrightcon_editp">
                            <asp:DropDownList runat="server" ID="ddActivity" CssClass="inputf_accm"></asp:DropDownList>
                        </span>
                    </div>
                </div>
                <% } %>
                <div class="main_container_row_editp">
                    <div>
                        <span class="titletext_editp">Medicare Id:</span>
                        <span class="inputfieldcon_editp">
                            <asp:TextBox ID="MedicareIdTextbox" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                        </span>
                    </div>
                    <div>
                        <span class="titletext_editp">Medicare Advantage Number:</span>
                        <span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="MedicareAdvantageNumber" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                        </span>
                    </div>
                </div>
                <div class="main_container_row_editp">
                    <div>
                        <span class="titletext_editp">MBI Number:</span>
                        <span class="inputfieldcon_editp">
                            <asp:TextBox ID="MbiNumberTextbox" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                        </span>
                    </div>
                    <div>
                        <span class="titletext_editp">Preferred Language:<sup class="reqiredmark">*</sup></span>
                        <span class="inputfieldrightcon_editp">
                            <asp:DropDownList runat="server" ID="PreferredLanguageDropDown" Style="width: 170px;"></asp:DropDownList>
                        </span>
                    </div>
                </div>
                <p class="main_container_row_editp">
                    <span class="titletext_editp">Preferred Contact:</span>
                    <span class="inputfieldcon_editp">
                        <asp:DropDownList runat="server" ID="ddlPreferredContactType" Style="width: 170px;">
                        </asp:DropDownList>
                    </span>
                    <span class="titletext_editp">Best Time to Call:</span>
                    <span class="inputfieldrightcon_editp">
                        <asp:DropDownList runat="server" ID="BestTimeToCallDropdown" CssClass="inputf_accm" Style="width: 170px;"></asp:DropDownList>
                    </span>
                </p>

                <br />
                <div class="main_container_row_editp">
                    <fieldset style="width: 95%;">
                        <legend><b>Phone and Consent</b></legend>

                        <div style="clear: both; padding-bottom: 5px;">
                            <span class="titletext_editp">Phone (Home): </span>
                            <span class="inputfieldcon_editp" style="margin: 0; width: 140px; padding-right: 10px;">
                                <asp:TextBox ID="txtphonehome" runat="server" CssClass="inputf_editp mask-phone" Width="140px"></asp:TextBox>
                            </span>

                            <span class="titletxt_regcust" style="width: 50px;"><b>Consent:</b></span>
                            <asp:DropDownList ID="ddlPatientConsentPrimary" runat="server" Width="90px" CssClass="inputf_pw">
                            </asp:DropDownList>
                        </div>

                        <br />

                        <div style="clear: both; padding-bottom: 5px;">
                            <span class="titletext_editp">Phone (Office): </span>
                            <span class="inputfieldcon_editp" style="width: 90px; margin: 0; padding-right: 10px;">
                                <asp:TextBox ID="txtphoneoffice" runat="server" CssClass="inputf_editp mask-phone"
                                    Width="90px"></asp:TextBox>
                            </span>

                            <span class="inputfieldcon_editp" style="width: 40px; margin: 0; padding-right: 10px;">
                                <asp:TextBox ID="PhoneOfficeExtension" placeholder="Ext" runat="server" CssClass="inputf_editp" Width="40px" />
                            </span>

                            <span class="titletxt_regcust" style="width: 50px;"><b>Consent:</b></span>
                            <asp:DropDownList ID="ddlPatientConsentOffice" runat="server" Width="90px" CssClass="inputf_pw">
                            </asp:DropDownList>
                        </div>

                        <br />

                        <div style="clear: both; padding-bottom: 5px;">
                            <span class="titletext_editp">Phone (Cell):</span>
                            <span class="inputfieldcon_editp" style="margin: 0; width: 140px; padding-right: 10px;">
                                <asp:TextBox ID="txtphonecell" runat="server" CssClass="inputf_editp mask-phone" Width="140px"></asp:TextBox>
                            </span>

                            <span class="titletxt_regcust" style="width: 50px;"><b>Consent:</b></span>
                            <asp:DropDownList ID="ddlPatientConsentCell" runat="server" Width="90px" CssClass="inputf_pw">
                            </asp:DropDownList>
                        </div>

                        <br />

                        <div style="clear: both; padding-bottom: 10px;">
                            <div class="titletext_editp enableTexting">
                                Do you wish to receive SMS alert?
                            </div>
                            <div class="radiobuttoncon_editp enableTexting">
                                <asp:RadioButtonList runat="server" Width="155px" CellPadding="1" RepeatDirection="horizontal"
                                    RepeatColumns="2" ID="rbtnEnableTexting">
                                    <asp:ListItem Text="Yes" Value="true" onclick="AlertMessage();"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="false" onclick="AlertMessage();"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>

                        <br />

                        <div style="clear: both; padding-bottom: 10px;">
                            <div class="titletext_editp enableVoicMail">
                                Do you wish to receive Voice Mail alert?
                            </div>
                            <div class="radiobuttoncon_editp enableVoicMail">
                                <asp:RadioButtonList runat="server" Width="155px" CellPadding="1" RepeatDirection="horizontal"
                                    RepeatColumns="2" ID="rbtnEnableVoiceMail">
                                    <asp:ListItem Text="Yes" Value="true"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </fieldset>
                </div>

                <div class="main_container_row_editp">
                    <fieldset style="width: 95%;">
                        <legend><b>Do Not Contact </b></legend>
                        <div style="float: left; padding-bottom: 10px;">
                            <span class="titletext_editp">Type:</span> <span class="inputfieldcon_editp">
                                <asp:DropDownList ID="TypeDoNotContactDropdown" runat="server" CssClass="inputf_editp"
                                    Width="170px">
                                </asp:DropDownList>
                            </span>
                        </div>
                        <div style="float: left;">
                            <span class="titletext_editp">Reason:</span> <span class="inputfieldcon_editp">
                                <asp:DropDownList ID="ReasonDoNotContactDropdown" runat="server" CssClass="inputf_editp"
                                    Width="170px">
                                </asp:DropDownList>
                            </span>
                        </div>
                        <div style="clear: both; margin-top: 4px; float: left;">
                            <b>Notes: </b>
                            <br />
                            <asp:TextBox runat="server" ID="ReasonDoNotContactnotes" Width="500px" Rows="3" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div class="main_container_row_editp">
                    <fieldset style="width: 95%">
                        <legend><b>Primary Care Physician</b></legend>
                        <span class="chkboxcon_editp">
                            <asp:CheckBox ID="chkPCPDetails" runat="server" Checked="false" />
                        </span><span class="titletextbig_editp">Enter Primary Care Physician Details</span>

                        <div id="divPcp" runat="server" style="display: none;">
                            <div id="divExistingPcp">
                                <div class="headbg_boxtop_editp" style="width: 699px !important">
                                    <div class="head_text_editp" style="width: 699px !important">Find Primary Care Physician</div>
                                </div>
                                <div class="lineheight_pw"></div>
                                <div class="contentrow_pw" style="font: bold 12px arial; color: #EE8111; padding: 10px">
                                    <u>Enter</u> your Primary Care Physician's details and<u>Click</u> Search.
                                </div>
                                <div class="lineheight_pw">
                                    <img src="/App/Images/specer.gif" height="5px" width="1px" />
                                </div>

                                <p class="contentrow_pw">
                                    <span class="titletextbold_pw" style="width: 80px; padding-left: 20px;">First Name:</span>
                                    <span class="inputfieldleftconnew_pw">
                                        <input type="text" class="txtFirstName inputf_pw" style="width: 175px" />
                                    </span>
                                    <span class="titletextbold_pw" style="width: 80px; padding-left: 20px;">Last Name:</span>
                                    <span class="inputfieldleftconnew_pw">
                                        <input type="text" class="txtLastName inputf_pw" style="width: 175px" />
                                    </span>
                                </p>
                                <p class="contentrow_pw" style="margin-top: 10px;">
                                    <span class="titletextbold_pw" style="width: 80px; padding: 18px">Zipcode:</span>
                                    <span class="inputfieldleftconnew_pw">
                                        <input type="text" class="txtZipcode inputf_pw" style="width: 175px" maxlength="5" />
                                    </span>
                                    <span style="float: right; padding-right: 18px;" id="SearchButton">
                                        <input type="button" value="Search" onclick="ValidateSearch();" />
                                    </span>
                                    <span style="float: right; padding-right: 50px; display: none;" id="spnIndicator">
                                        <img src="/App/Images/indicator.gif" />
                                    </span>
                                </p>
                                <div class="lineheight_pw"></div>
                                <div class="lineheight_pw"></div>
                                <%--<div id="divHeading" style="display: none;">
                            <p class="contentrow_pw" style="font: bold 12px arial; color: #EE8111;">
                                <span><b>(b)</b>&nbsp;&nbsp;<u>Select</u> your primary care physician and <u>Click</u> Next. </span>
                            </p>
                        </div>--%>
                                <div class="lineheight_pw"></div>
                                <div class="contentrow_pw" id="divGridPcp" style="display: none; margin-top: 10px;">
                                    <fieldset>
                                        <legend>Found Results</legend>
                                        <div id="divPcpResult">
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="contentrow_pw" id="divNewPcpButton" style="display: none; margin: 10px;">
                                    <span class="titletextbold_pw" style="width: 150px; text-align: left;">Not able find PCP?</span>
                                    <span class="titletextbold_pw">
                                        <input type="button" id="NewPcpButton" value="Add PCP" onclick="ShowNewPcpDiv(true);" />
                                    </span>
                                </div>
                                <div class="contentrow_pw" id="divVerifiedPcpInfo" style="display: none;">
                                    <input type="checkbox" id="chkVerifiedPcpInfo" runat="server" />
                                    <b>Is PCP Info Verified ?  </b>
                                </div>
                            </div>
                            <div class="contentrow_pw" id="divNewPCP" style="display: none;">
                                <%--<p style="float: left; font: bold 12px arial; color: #EE8111; display: none;">
                            <span class=""><b><span id="spNewDetails" runat="server">(c)</span></b>&nbsp;&nbsp;<u>Enter</u> information about your physician and <u>Click</u>
                                Next. </span>
                        </p>--%>
                                <p style="float: right; padding: 10px 18px;">

                                    <span style="float: right;">
                                        <input type="button" id="SearchPcpButton" value="Search PCP" onclick="ShowNewPcpDiv(false);" />
                                    </span>
                                </p>
                                <div id="divphysiciancare" style="visibility: hidden; display: none;">
                                    <div class="headbg_boxtop_editp" style="width: 699px !important">
                                        <div class="head_text_editp" style="width: 699px !important">
                                            Primary Care Physician Contact Details
                                        </div>
                                    </div>
                                    <span style="float: left;">
                                        <asp:CheckBox ID="chkChangePcp" runat="server" Checked="false" />
                                        Have you changed primary care physician ?
                                    </span>
                                    <uc1:UCPCPInfo ID="UCPCPInfo1" runat="server" />
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <div class="main_area_bdrnone" style="float: left; margin-top: 5px;">
            <div class="buttoncon_default">
                <asp:ImageButton ID="ibtnsave" runat="server" CssClass="" ImageUrl="../Images/save-button.gif"
                    OnClientClick="return validatecontrols()" OnClick="ibtnsave_Click" />
            </div>
            <div class="buttoncon_default">
                <asp:ImageButton ID="ibtncancel" runat="server" CssClass="" ImageUrl="../Images/cancel-button.gif"
                    OnClick="ibtncancel_Click" />
            </div>
        </div>
    </div>
</div>

<asp:HiddenField runat="server" ID="FirstNameHiddenField" Value="" />
<asp:HiddenField runat="server" ID="LastNameHiddenField" Value="" />
<asp:HiddenField runat="server" ID="ZipcodeHiddenField" Value="" />
<asp:HiddenField runat="server" ID="PageNumberHiddenField" Value="1" />

<%--<input type="hidden" class="firstNameHiddenfield" value="" />
<input type="hidden" class="lastNameHiddenField" value="" />
<input type="hidden" class="zipcodeHiddenField" value="" />
<input type="hidden" class="pageNumberHiddenField" value="1" />--%>

<input type="hidden" class="total-records" id="TotalRecordsHiddenField" runat="server" value="0" />

<asp:HiddenField runat="server" ID="PhysicianMasterIdHiddenField" Value="0" />

<input type="hidden" class="newPcpHiddenField" value="False" />
<asp:HiddenField runat="server" ID="HasPcpHiddenField" Value="False" />

<asp:HiddenField runat="server" ID="hfstate" />
<script type="text/javascript" language="javascript">
    var states;
    $(document).ready(function () {
        states = <%= GetStates() %> ;
        BindSateDropDown(states);

        $("#<%= MarketingSourceDropDown.ClientID %>").sexyCombo({hiddenSuffix: '_hidden', emptyText: 'Type here for quick search', triggerSelected: true});

        $('#<%=ddlCountry.ClientID %>').bind("change", function() { BindSateDropDown(states); });
        
        SetContextKey($('.ddl-states option:selected').val());

        $('.ddl-states').change(function () {
            SetContextKey($('.ddl-states option:selected').val());
            SetState();
        });
        $('.mask-phone').mask('(999)-999-9999');
        
        $('.mask-ssn').mask('***-**-****');

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
            $(".enableVoicMail").hide();
        }
        else
        {
            $(".enableVoicMail").show();
        }

        hideShowEmailConsentDiv();
    });

    function SetContextKey(stateId) {
        $('.auto-search-city').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: stateId
        });
    }
    
</script>
<script type="text/javascript" language="javascript">

    function BindSateDropDown(stateList) {
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
            $("#<%= ddlState.ClientID %> option[value=" + $('#<%=hfstate.ClientID %>').val() + "]").attr('selected', true);
        }
    }

    function SetState() {
        $('#<%=hfstate.ClientID %>').val($('#<%=ddlState.ClientID %> option:selected').val());
    }
   
</script>
<script type="text/javascript">
    function ShowNewPcpDiv(isNew) {
        if (isNew) {
            $(".newPcpHiddenField").val("<%= Boolean.TrueString%>");
        } else {
            $(".newPcpHiddenField").val("<%= Boolean.FalseString%>");
        }

        ShowHidePcpDiv();
    }

    $("#<%=chkPCPDetails.ClientID%>").click(function() {
        showhidedvPCP($(this).is(":checked"));
    });


    function showhidedvPCP(isChecked) {
        if (isChecked) {
            ShowdvPCP();
        } else {
            HidedvPCP();
        }
    }
    function ShowHidePcpDiv() {
        if ($(".newPcpHiddenField").val() == "<%= Boolean.TrueString%>") {
            $("#divNewPCP").show();

            $("#divPcpResult").html("");
            $("#divGridPcp").hide();
            $("#divNewPcpButton").hide();
            $("#divExistingPcp").hide();

            $("#<%= FirstNameHiddenField.ClientID%>").val("");
            $("#<%= LastNameHiddenField.ClientID%>").val("");
            $("#<%= ZipcodeHiddenField.ClientID%>").val("");
            $("#<%= PageNumberHiddenField.ClientID%>").val("1");


            $(".txtFirstName").val("");
            $(".txtLastName").val("");
            $(".txtZipcode").val("");

            $("#<%= PhysicianMasterIdHiddenField.ClientID%>").val("0");
            searchedForPcp = false;
        } else {

            $("#divNewPCP").hide();
            $("#divNewPcpButton").hide();
            $("#divExistingPcp").show();
        }
    }

    $(document).ready(function () {
        if ($("#<%= HasPcpHiddenField.ClientID %>").val() == "<%= Boolean.TrueString%>") {
            $(".newPcpHiddenField").val("<%= Boolean.TrueString%>");
        }
        ShowHidePcpDiv();
        SearchPcp();
        showhidedvPCP($("#<%=chkPCPDetails.ClientID%>").is(":checked"));
    });

    function ShowdvPCP() {
        var divPcp = document.getElementById("<%= divPcp.ClientID %>");
        divPcp.style.display = "block";
    }

    function HidedvPCP() {
        var divPcp = document.getElementById("<%=divPcp.ClientID %>");
        divPcp.style.display = "none";
    }
</script>
<script type="text/javascript">
    var searchedForPcp = false;
    function SearchPcp() {
            
        var firstName = $("#<%= FirstNameHiddenField.ClientID%>").val().trim();
        var lastName = $("#<%= LastNameHiddenField.ClientID%>").val().trim();
        var zipcode = $("#<%= ZipcodeHiddenField.ClientID%>").val().trim();
        var pageNumber = $("#<%= PageNumberHiddenField.ClientID%>").val();

        if ((firstName == "" && lastName == "") || zipcode == "") {
            return;
        }

        $("#SearchButton").hide();
        $("#spnIndicator").show();
            
        //Action method to search
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "html", url: "/Medical/PrimaryCarePhysician/SearchPcp?firstName=" + firstName + "&lastName=" + lastName + "&zipcode=" + zipcode + "&pageNumber=" + pageNumber, data: '{}',
            success: function (result) {
                $("#SearchButton").show();
                $("#spnIndicator").hide();
                    
                $("#divPcpResult").html(result);
                setTotalRecords();
                SetButton();
                    
                $("#divGridPcp").show();
                $("#divNewPcpButton").show();
                searchedForPcp = true;
            }, error: function(a, b, c) {
                $("#SearchButton").show();
                $("#spnIndicator").hide();
            }
        });
    }
        
    function setPage(currentPage) {
        $("#<%= PageNumberHiddenField.ClientID%>").val(currentPage);
        SearchPcp();
    }
        
    function SetPhysicianMaster(physicianMasterId) {
        $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val(physicianMasterId);
        SetButton();
    }
    function SetButton() {
            
        var physicianMasterId = $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val();
        $("#divPcpResult .physician-master input[type=button]").css({ "background": "-moz-linear-gradient(center top , #f5f5f5, #cbcbcb) repeat scroll 0 0 transparent" });
        $("#divPcpResult .physician-master input[type=button]").attr("value", "Select");

        $("#divPcpResult .physician-master input[type=hidden][value='" + physicianMasterId + "']").parent().find("input[type=button]").css({ "background": "-moz-linear-gradient(center top , #bdb76b, #388c2c) repeat scroll 0 0 transparent" });
        $("#divPcpResult .physician-master input[type=hidden][value='" + physicianMasterId + "']").parent().find("input[type=button]").attr("value", "Selected");
        if (physicianMasterId>0)
            $("#divVerifiedPcpInfo").show();
    }

    function ValidateSearch() {
        var firstName = $(".txtFirstName").val();
        var lastName = $(".txtLastName").val().trim();
        var zipcode =  $(".txtZipcode").val().trim();
           
        if ((firstName == "" && lastName == "")  || zipcode == "") {
            alert("To search a PCP, please enter either first name or last name and zip code");
            return;
        }

        $("#<%= FirstNameHiddenField.ClientID%>").val(firstName);
        $("#<%= LastNameHiddenField.ClientID%>").val(lastName);
        $("#<%= ZipcodeHiddenField.ClientID%>").val(zipcode);
        $("#<%= PageNumberHiddenField.ClientID%>").val("1");

        $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val("0");
            
        SearchPcp();
    }
        
    function PCPValidation() 
    {
        var physicianMasterIdHiddenField = $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val();
        var rbtnYes = document.getElementById("<%= chkPCPDetails.ClientID %>");

        var totalRecords = $("#<%= TotalRecordsHiddenField.ClientID %>").val();
        if (rbtnYes.checked == true) {
            if (searchedForPcp == false && $(".newPcpHiddenField").val() == "<%= Boolean.FalseString%>") {
                alert("Please search your Primary Care Physician.");
                return false;
            }
            else if (searchedForPcp == true && totalRecords == 0 && $(".newPcpHiddenField").val() == "<%= Boolean.FalseString%>") {
                alert("Please search again your Primary Care Physician or Add PCP.");
                return false;
            }
            else if (searchedForPcp == true && totalRecords > 0 && physicianMasterIdHiddenField == 0 && $(".newPcpHiddenField").val() == "<%= Boolean.FalseString%>") {
                alert("Please select Primary Care Physician from list.");
                return false;
            }
            else if ($(".newPcpHiddenField").val() == "<%= Boolean.TrueString%>") {
                return ValidatePCP();
            }
             
            if (physicianMasterIdHiddenField > 0 && (!$("input:checkbox[name$='chkVerifiedPcpInfo']").is(":checked")))
            {
                return confirm("You have not verified the PCP Info. Do you want to continue?");                 
            }
        }

        return true;
    }

    $("input:checkbox[name$='chkVerifiedPcpInfo']").click(function(){
        if($(this).is(":checked"))
        {            
            alert('Pcp info will be verified for all the events (if any).');           
        }
    });
    function AlertMessage()
    {
        alert("It will change the SMS status for all future appointments of this customer?");
    }
</script>

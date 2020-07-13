<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUserLoginInfo.ascx.cs"
    Inherits="Falcon.App.UI.Public.UCPublic.ucUserLoginInfo" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncludeJQueryMaskInput="true" IncudeJQueryJTip="true" />
<script src="/Content/JavaScript/validations.js?v=<%=DateTime.Now.Ticks %>" language="javascript" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        if ('<%=IsGiftCertificate %>' == 'True') {
            $('.information-span').text('create account.');
        }
    });
</script>
<script language="javascript" type="text/javascript" src="/Content/JavaScript/actb.js"></script>
<script language="javascript" type="text/javascript" src="/Content/JavaScript/common.js"></script>
<script language="javascript" type="text/javascript">
    function RegistrationValidation() {
        var txtEmail = document.getElementById("<%= this.txtEmail.ClientID %>");
        if (isBlank(txtEmail, "Email"))
        { return false; }

        if (!validateEmail(txtEmail, "Email "))
        { return false; }
        //debugger
        var txtRegUserName = document.getElementById("<%=this.txtRegUserName.ClientID %>");
        if (isBlank(txtRegUserName, "User name")) {
            return false;
        }
        var str = txtRegUserName.value;
        if (str.length < 6) {
            alert("Username length can not be less than 6 characters.");
            return false;
        }
        pass = document.getElementById('<%= this.txtNewPassword.ClientID %>').value
        newpass = document.getElementById('<%= this.txtCrfmPassword.ClientID %>').value

        if (pass == "") {
            alert("New Password is mandatory.");
            return false;
        }

        if (pass.length < 8) {
            alert("Password length can not be less than 8 characters.");
            return false;
        }

        if (pass != newpass) {
            alert("Verify Password should be same as New Password.");
            return false;
        }
        //checks string contains numeric and alphanumeric both
        var IsContainNumeric = false;
        var IsContainAlphanumeric = false;
        for (var i = 0; i < pass.length; i++) {
            var singleChar = pass.charAt(i);
            var singleCharCode = singleChar.charCodeAt(0);
            if (singleCharCode > 47 && singleCharCode < 58) {
                IsContainNumeric = true;
            }

            if ((singleCharCode > 64 && singleCharCode < 91) || (singleCharCode > 96 && singleCharCode < 123)) {
                IsContainAlphanumeric = true;
            }
        }
        if ((!IsContainNumeric) || (!IsContainAlphanumeric)) {
            alert("New Password should contain at least one alphabet and one numeric ");
            return false;
        }

        var txtQuestion = document.getElementById("<%= this.txtQuestion.ClientID %>");
        if (isBlank(txtQuestion, "Hint Question"))
        { return false; }

        if (minimum_fourcharacters(txtQuestion, "Hint Question") == false) {
            return false;
        }

        if (three_samecharacters(txtQuestion, "Hint Question") == false) {
            return false;
        }
        if (check_sequential(txtQuestion, "Hint Question") == false) {
            return false;
        }

        var txtAnswer1 = document.getElementById("<%= this.txtAnswer1.ClientID %>");
        if (isBlank(txtAnswer1, "Hint Answer"))
        { return false; }

        if (minimum_threecharacters(txtAnswer1, "Hint Answer") == false) {
            return false;
        }
        if (three_samecharacters(txtAnswer1, "Hint Answer") == false) {
            return false;
        }
        if (check_sequential(txtAnswer1, "Hint Answer") == false) {
            return false;
        }
        if (txtQuestion.value == txtAnswer1.value) {
            alert("Hint Question cannot match answer.");
            return false;
        }
        return true;
    }
    function keyUp_userName(evt) {//debugger
        var spNotAvailable = document.getElementById("<%=this.spNotAvailable.ClientID %>");
        var spAvailable = document.getElementById("<%=this.spAvailable.ClientID %>");
        var spCheckAvailable = document.getElementById("divCheckAvailable");
        var spMinChar = document.getElementById("<%=this.spMinChar.ClientID %>");

        if (document.getElementById("<%=this.txtRegUserName.ClientID %>").value.length > 5) {
            spMinChar.style.display = "none";
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            if (evt.shiftKey == false) {
                if ((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || key == 190 || key == 189 || key == 109 || (key >= 65 && key <= 90) || (key >= 96 && key <= 105)) {
                    spNotAvailable.style.display = "none";
                    spAvailable.style.display = "none";
                    spCheckAvailable.style.display = "block";
                    CheckUserNameAvailability();
                }
            }
            else if (evt.shiftKey == true) {
                if (key == 109 || key == 189 || key == 95 || (key >= 65 && key <= 90)) {
                    spNotAvailable.style.display = "none";
                    spAvailable.style.display = "none";
                    spCheckAvailable.style.display = "block";
                    CheckUserNameAvailability();
                }
            }

        }
        else {
            spMinChar.style.display = "block";
            spNotAvailable.style.display = "none";
            spAvailable.style.display = "none";
            spCheckAvailable.style.display = "none";
        }
        return true;
    }
    function keypress_userName(evt) {//debugger

        var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
        if (evt.shiftKey == false) {
            if ((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || key == 190 || key == 189 || key == 109 || (key >= 65 && key <= 90) || (key >= 96 && key <= 105)) {
                return true;
            }
        }
        else if (evt.shiftKey == true) {
            if (key == 109 || key == 189 || key == 95 || (key >= 65 && key <= 90)) {

                return true;
            }
        }
        return false;

    }


    function OnComplete(arg) {
        var spAvailable = document.getElementById("<%=this.spAvailable.ClientID %>");
        var spNotAvailable = document.getElementById("<%=this.spNotAvailable.ClientID %>");
        var spCheckAvailable = document.getElementById("divCheckAvailable");
        spCheckAvailable.style.display = "none";
        if (arg.d == true) {
            spAvailable.style.display = "block";
            spNotAvailable.style.display = "none";

        }
        else {
            spNotAvailable.style.display = "block";
            spAvailable.style.display = "none";
        }
    }




    function CheckUserNameAvailability() {
        var txtRegUserName = document.getElementById("<%=this.txtRegUserName.ClientID %>");
        var hfUserID = document.getElementById("<%=this.hfUserID.ClientID %>");
        if (isBlank(txtRegUserName, "User name")) {
            return false;
        }
        
        var parameter = "{'userName' : '" + txtRegUserName.value + "', 'userId' : '" + hfUserID.value + "'}";

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/App/AutoCompleteService.asmx/CheckUserNameAvailability",
            data: parameter,
            success: OnComplete,
            error: function (a, b, c) {
                alert("Error occurred while checking username availibility!");
            }

        });
        return (true);
    }

    //TempPassword textbox Hide/Show
    function checkTempPassword() {
        var chkTempPassword = document.getElementById("<%=this.chkTempPassword.ClientID %>");
        var divTempPassword = document.getElementById("divTempPassword");
        if (chkTempPassword.checked == true) {
            divTempPassword.style.display = "block";
            divTempPassword.style.visibility = "visible";
        }
        else {
            divTempPassword.style.display = "none";
            divTempPassword.style.visibility = "hidden";
        }
    }

    function showError() {
        $find('mdlPopupError').show();
    }
</script>
<script type="text/javascript">
    function password_strength(password) {

        var desc = new Array();
        desc[0] = "Very Weak";
        desc[1] = "Weak";
        desc[2] = "Better";
        desc[3] = "Medium";
        desc[4] = "Strong";
        desc[5] = "Strongest";
        desc[6] = "";

        if (password.length > 0) {
            document.getElementById("password_strength").style.display = 'Block';
        }
        else {
            document.getElementById("password_strength").style.display = 'none';
            document.getElementById("password_description").innerHTML = desc[6];
            return false;
        }

        var points = 0;

        //---- if password is bigger than 4 , give 1 point.
        if (password.length > 4) points++;

        //---- if password has both lowercase and uppercase characters , give 1 point.	
        if ((password.match(/[a-z]/)) && (password.match(/[A-Z]/))) points++;

        //---- if password has at least one number , give 1 point.
        if (password.match(/\d+/)) points++;

        //---- if password has at least one special caracther , give 1 point.
        if (password.match(/.[!,@,#,$,%,^,&,*,?,_,~,-,(,)]/)) points++;

        //---- if password is bigger than 12 ,  give 1 point.
        if (password.length > 12) points++;

        //---- Showing  description for password strength.
        document.getElementById("password_description").innerHTML = desc[points];

        //---- Changeing CSS class.
        document.getElementById("password_strength").className = "strength" + points;
    }
</script>
<style type="text/css">
    #password_description
    {
        font-size: 12px;
    }
    #password_strength
    {
        height: 5px;
        display: block;
    }
    #password_strength_border
    {
        width: 100px;
        height: 5px;
        border: 1px solid black;
    }
    .strength0
    {
        width: 100px;
        background: #cccccc;
    }
    .strength1
    {
        width: 100px;
        background: #ff0000;
    }
    .strength2
    {
        width: 100px;
        background: #ff5f5f;
    }
    .strength3
    {
        width: 100px;
        background: #56e500;
    }
    .strength4
    {
        background: #4dcd00;
        width: 100px;
    }
    .strength5
    {
        background: #399800;
        width: 100px;
    }
</style>

<div class="maindivouterloginnew_pw" style="margin-left: 10px; width: 650px;">
    <div class="lftboxlogin_pw" id="divMain" runat="server">
        <div>
            <div id="divNewCustomer" runat="server">
                <p class="contentrownlogin_pw">
                    <span class="normaltxt_pw email-message" style="font: bold 12px arial; color: #EE8111;">
                        <u>Enter</u> your Email address to <span class="information-span">Register for this
                            event </span></span>
                </p>
                <p class="pclass_def">
                    <img src="/Content/Images/spacer.gif" height="5px" width="300px" /></p>
                <p class="contentrownlogin_pw">
                    <span class="titletxtbrwn_pw">Email<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputconnowidthlogin_pw">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputf_pw" Width="200px"></asp:TextBox></span>
                
                        <a href="#" class="jtip" style="font: bold 14px arial; color: #287AA8;"
                        title='Why we need this? |<%= IoC.Resolve<ISettings>().CompanyName %> requires an Email address so that we can communicate with clients in
                        various situations, including : screening appointment reminders, special offers,
                        password notification, result status notification, etc. Under no circumstances will
                        <%= IoC.Resolve<ISettings>().CompanyName %> share or sell your personal information. <%= IoC.Resolve<ISettings>().CompanyName %> is committed to keeping
                        your information secure by following the industry best practices for information
                        gathering and dissemination.'>?</a>                
                </p>

                <p class="pclass_def">
                <img src="/Content/Images/spacer.gif" height="5px" width="300px" /></p>

                <p class="contentrownlogin_pw">
                    <span class="normaltxt_pw" style="font: bold 12px arial; color: #EE8111;"><u>Select</u>
                        a Username to access your online account</span>
                </p>
                <p class="contentrownlogin_pw">
                    <span class="titletxtbrwn_pw">UserName<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputconnowidthlogin_pw"><span style="float: left">
                        <asp:TextBox ID="txtRegUserName" runat="server" CssClass="inputf_pw" Width="200px"></asp:TextBox></span>
                    </span>

                    <a href="#" class="jtip"  style="font: bold 14px arial; color: #287AA8;"
                        title='Why we need this? |<%= IoC.Resolve<ISettings>().CompanyName %> requires an UserName of six characters or more so that we can maintain
                            the highest level of security possible. After registration, you will be emailed
                            a password. The UserName you provide here, combined with the password provided,
                            will allow you access to your personalized <%= IoC.Resolve<ISettings>().CompanyName %> Wellness Portal. Store your
                            <%= IoC.Resolve<ISettings>().CompanyName %> UserName in a secure place. <%= IoC.Resolve<ISettings>().CompanyName %> does not recommend that you share
                            your UserName or Password with anyone. <%= IoC.Resolve<ISettings>().CompanyName %> is committed to keeping your information
                            secure by following the industry best practices for information gathering and dissemination.'>
                            ?</a> 
                </p>

                <p class="contentrownlogin_pw">
                        <div id="divCheckAvailable" style="display:none;margin-left:150px;" >
                            <img id="img1" runat="server" src="~/Content/Images/check_available.gif" alt="Username available" />Checking for username availability... 
                        </div>
                                
                        <span id="spMinChar" runat="server"
                            style="float: left; width: 215px; padding: 4px 2px 0px 0px; font-size: 11px;
                            color: Red; display: none;">
                            <img id="img2" runat="server" src="~/Content/Images/not-available.gif" alt="Minimum of 6 characters required" />Minimum
                            of 6 characters required! </span><span id="spNotAvailable" runat="server" style="float: left;
                                width: 215px; padding: 4px 2px 0px 0px; font-size: 11px; color: Red; display: none;">
                                <img id="imgAvailable" runat="server" src="~/Content/Images/not-available.gif" alt="Username not available" />Not
                                Available! </span><span id="spAvailable" runat="server" style="float: left; width: 215px;
                                    padding: 4px 0px 0px 0px; display: none; font-size: 11px; color: Green">
                                    <img id="imgNotAvailable" runat="server" src="~/Content/Images/available.gif" alt="Username available" />Available!
                                </span>

                </p>


                <p class="contentrownlogin_pw">
                    <span class="normaltxt_pw" style="font: bold 12px arial; color: #EE8111;"><span style="display: none;
                        visibility: hidden;">
                        <asp:CheckBox ID="chkTempPassword" runat="server" /></span> <u>Select</u> if you
                        wish to <u>Enter</u> password to immediate access your account online </span>
                </p>
                <div id="divTempPassword">
                    <p class="pclass_def">
                        <img src="/Content/Images/spacer.gif" height="2px" width="300px" /></p>
                    <p class="contentrownlogin_pw">
                        <span class="titletxtbrwn_pw">New Password:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputconnowidthlogin_pw"><span style="float: left">
                            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="inputf_pw" Width="80px"
                                TextMode="Password" onkeyup='password_strength(this.value)'></asp:TextBox></span>
                            <span style="float: left; width: 100px; padding-left: 5px;"><span id="password_strength"
                                class="strength0" style="margin: 4px 0px 0px 5px; display: none"></span><span style="float: left;
                                    padding-top: 2px;"><span style="float: left; font-size: 10px; margin-left: 5px;"
                                        id="password_description"></span></span></span></span>
                    </p>
                    <p class="contentrownlogin_pw">
                        <span class="greytxt10px_default">(Minimum 8 characters, At least 1 letter and 1 number)</span>
                    </p>
                    <p class="pclass_def">
                        <img src="/Content/Images/spacer.gif" height="2px" width="300px" /></p>
                    <p class="contentrownlogin_pw">
                        <span class="titletxtbrwn_pw">Verify Password:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputconnowidthlogin_pw"><span style="float: left">
                            <asp:TextBox ID="txtCrfmPassword" runat="server" CssClass="inputf_pw" Width="80px"
                                TextMode="Password"></asp:TextBox></span> </span>
                    </p>
                </div>
                <p class="pclass_def">
                    <img src="/Content/Images/spacer.gif" height="8px" width="300px" /></p>
                <p class="contentrownlogin_pw">
                    <span class="normaltxt_pw" style="font: bold 12px arial; color: #EE8111;"><u>Provide</u>
                        a Hint Question and <u>Enter</u> your Answer</span></p>
                <p class="pclass_def">
                    <img src="/Content/Images/spacer.gif" height="5px" width="300px" /></p>
                <p class="contentrownlogin_pw">
                    <span class="titletxtbrwn_pw">Hint Question<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputconlogin_pw">
                        <asp:TextBox ID="txtQuestion" runat="server" CssClass="inputf_pw" Width="200px"></asp:TextBox>
                    </span>
                </p>
                <p class="contentrownlogin_pw">
                    <span class="titletxtbrwn_pw">Hint Answer<span class="reqiredmark"><sup>*</sup></span></span>
                   
                       <asp:TextBox ID="txtAnswer1" runat="server" CssClass="inputf_pw" Width="200px"></asp:TextBox>
               
                        <a href="#" style="font: bold 14px arial; color: #287AA8;"
                            class="jtip" title='Why we need this? |<%= IoC.Resolve<ISettings>().CompanyName %> requires a Hint Question and Hint Answer so that we can maintain the
                            highest level of security possible. Should you ever misplace your UserName or Password,
                            you will be required to contact <%= IoC.Resolve<ISettings>().CompanyName %> at <%= IoC.Resolve<ISettings>().PhoneTollFree %>. Upon calling you will
                            be asked for your Hint Answer. Should you not recall your Hint Answer, a <%= IoC.Resolve<ISettings>().CompanyName %>
                            representative will provide you with your Hint Question to help you recall your
                            Hint Answer. It is best to provide a Hint Question that leads you to a Hint Answer
                            that only you would know. For Example a Hint Question of "What was your college
                            mascot?" and a Hint Answer of "Notre Dame Fighting Irish" might be appropriate.
                            <%= IoC.Resolve<ISettings>().CompanyName %> does not recommend that you share your Hint Question or Hint Answer with
                            anyone. <%= IoC.Resolve<ISettings>().CompanyName %> is committed to keeping your information secure by following
                            the industry best practices for information gathering and dissemination.'>?</a>                  
                </p>

                <p class="pclass_def">
                    <img src="/Content/Images/spacer.gif" height="5px" width="300px" /></p>
                <p class="hline_pw">
                    <img src="/Content/Images/hline-login.gif" height="1px" /></p>
                <p class="contentrownlogin_pw">
                    <span class="smalltxt">YOUR PRIVACY IS IMPORTANT TO US: By joining
                        <%= IoC.Resolve<ISettings>().CompanyName %>, you will receive emails
                        and/or direct mail containing personalized health content, opportunities to take
                        surveys and other special free offers from us. We NEVER share or sell your personal
                        information.</span>
                </p>
                <p class="contentrownlogin_pw">
                    <img src="/Content/Images/spacer.gif" height="8px" width="1px" /></p>
                <p class="hline_pw">
                    <img src="/Content/Images/hline-login.gif" height="1px" /></p>
                <p class="contentrownlogin_pw">
                    <span id="spErrorMsg" runat="server" class="txt_errormsgnew" style="padding-left: 10px">
                    </span>
                </p>
                <p class="contentrownlogin_pw">
                    <img src="/Content/Images/spacer.gif" height="10px" width="1px" /></p>
                <p class="contentrownlogin_pw">
                    <span class="createacclogin_pw" style="padding-right: 10px; width: auto;">
                        <asp:ImageButton ID="ibtnSaveCustomer" runat="server" CssClass="" ImageUrl="~/Content/Images/Register-orngbtn-PW.gif"
                            OnClientClick='return RegistrationValidation();' OnClick="ibtnSaveCustomer_Click" />
                    </span>
                </p>
            </div>
        </div>
    </div>
    <div class="left" id="GiftCertificateSummary" runat="server">
        <div class="wrap_gcsummary">
            <div class="leftbg_gcsummary">
                <div>
                    Summary of Gift Certificate</div>
            </div>
            <div class="div_gcsummary">
                <div class="hrow orngbold12_default">
                    Here is the summary of your gift certificate
                </div>
                <div class="hrow">
                    Amount: <b><span id="AmountSpan" runat="server">$</span></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[
                    <a href="#" runat="server" id="ChangeAmount" onserverclick="ChangeAmount_ServerClick">
                        Change this</a> ]
                </div>
                <div class="hrow" style="padding-top: 10px">
                    <fieldset style="border-color: #ccc">
                        <legend style="color: #F37C00">Personalization Information</legend>
                        <div class="fldrow">
                            <label class="lbl">
                                For:</label>
                            <span class="detailt" id="ForNameSpan" runat="server"></span>
                        </div>
                        <div class="fldrow">
                            <label class="lbl">
                                Email:</label>
                            <span class="detailt" id="ForEmailSpan" runat="server"></span>
                        </div>
                        <div class="fldrow">
                            <label class="lbl">
                                Occasion:</label>
                            <span class="detailt" id="OccasionSpan" runat="server"></span>
                        </div>
                        <div class="fldrow">
                            <label class="lbl">
                                Message:</label>
                            <span class="detailt" id="MessageSpan" runat="server"></span>
                        </div>
                        <div class="fldrow">
                            <span style="float: right"><a href="#" id="ChangeDetails" runat="server" onserverclick="ChangeDetails_ServerClick">
                                Change this </a></span>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
<asp:HiddenField ID="hfUserID" Value="0" runat="server" />
<asp:HiddenField ID="hfUserType" Value="0" runat="server" />
<script type="text/javascript" language="javascript">
    $(function () {
        $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 400 });
    });
</script>

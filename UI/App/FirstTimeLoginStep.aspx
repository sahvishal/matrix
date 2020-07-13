<%@ Page Language="C#" MasterPageFile="~/App/NoRole.master" AutoEventWireup="true"
    Inherits="FirstTimeLoginStep" Title="New User Password Reset" CodeBehind="FirstTimeLoginStep.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

        function Validate() {

            pass = document.getElementById('<%= this.txtNewPassword.ClientID %>').value
            newpass = document.getElementById('<%= this.txtNewPasswordVerify.ClientID %>').value

            if (pass == "") {
                alert("New Password is mandatory.");
                return false;
            }

            if (pass.length < 8) {
                alert("Password length can not be less than 8 characters.");
                return false;
            }

            if (pass != newpass) {
                alert("New Password should be same as Confirm New Password.");
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

           
            if (document.getElementById("<%=this.trSecQues.ClientID %>").visible == "hidden") {
                var txtQuestion = document.getElementById("<%=this.txtQuestion.ClientID %>");
                var txtAnswer = document.getElementById("<%=this.txtAnswer.ClientID %>");

                if (isBlank(txtQuestion, "Hint question")) {
                    return false;
                }
                if (minimum_fourcharacters(txtQuestion, "Hint Question") == false) {
                    return false;
                }

                if (three_samecharacters(txtQuestion, "Hint Question") == false) {
                    return false;
                }
                if (check_sequential(txtQuestion, "Hint Question") == false) {
                    return false;
                }

                if (isBlank(txtAnswer, "Hint Answer")) {
                    return false;
                }
                if (minimum_threecharacters(txtAnswer, "Hint Answer") == false) {
                    return false;
                }
                if (three_samecharacters(txtAnswer, "Hint Answer") == false) {
                    return false;
                }
                if (check_sequential(txtAnswer, "Hint Answer") == false) {
                    return false;
                }
                if (txtQuestion.value == txtAnswer.value) {
                    alert("Hint Question cannot match answer.");
                    return false;
                }
            }
            $("#<%=btnCancel.ClientID %>").hide();
            $("#<%=btnSubmit.ClientID %>").hide();
            $("#loadingImg").show();

            return true;
        }
        //190 -- "."
        //109 -- "-"
        //95 -- "_"
        function txtkeypressPassword(evt) {
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            if (evt.shiftKey == false && key == 32) return false;
        }

        function txtkeypress(evt) {

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
            else if (evt.shiftKey == false && key == 32) {
                return false;
            }

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
            width: 144px;
            height: 5px;
            border: 1px solid black;
        }
        .strength0
        {
            width: 144px;
            background: #cccccc;
        }
        
        .strength1
        {
            width: 40px;
            background: #ff0000;
        }
        
        .strength2
        {
            width: 60px;
            background: #ff5f5f;
        }
        
        .strength3
        {
            width: 80px;
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
            width: 144px;
        }
    </style>
    <style>
        .mainbg_login
        {
            width: 527px;
            height: 295px;
            background: url(Images/firsttimelogin-bg.gif) no-repeat;
        }
        .inputf_def
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            z-index: -5;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .greytxt10px_default
        {
            float: left;
            padding-left: 150px;
            font: normal 10px arial;
            color: #666;
        }
        td
        {
            font: normal 12px arial;
        }
    </style>
    <asp:Panel ID="LoginInfoPanel" runat="server" DefaultButton="btnSubmit">
        <div align="center">
            <table width="527px" border="0" cellpadding="0" cellspacing="0" style="height: 360px">
                <tr>
                    <td align="left">
                        <span style="float:left; font: bold 18px arial; color: #F37C00; width:98%"><%=Heading %> </span>
                        <span style="float:left; width:98%; margin-top:5px; font-style:italic; <%=isResetPassword || isPasswordExpired?"display:none":"" %>">
                            Since this is your first attempt to login, we request you to update the following information for security reasons.
                        </span>
                    </td>
                </tr>
                <tr>                    
                    <td width="527px" height="100%">
                        <table width="99%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left" valign="middle" class="mainbg_login">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td valign="top" class="main_bg_errorpage" style="padding-left: 30px;">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <%--<tr>
                                                        <td align="left" style="font: bold 14px arial; color: #F37C00;">
                                                            Update Following Details
                                                        </td>
                                                    </tr>  --%>                                                  
                                                    <tr id="trResetPass" runat="server">
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td height="5">
                                                                        <img src="/App/Images/spacer.gif" height="5" width="1" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 150px; color: #666; padding-bottom: 5px;">
                                                                        <span>New Password:</span>
                                                                    </td>
                                                                    <td align="left">
                                                                        <span>
                                                                            <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" CssClass="inputf_def"
                                                                                Width="150px" onkeydown='return txtkeypressPassword(event)' onkeyup='password_strength(this.value)'></asp:TextBox></span>
                                                                        <span style="float: left; color: #999; font: normal 8px arial;">(cAsE SeNsItIvE)</span>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <a href="javascript:var popup=window.open('PasswordHelp.html', 'theconfirmWin','width=600, height=600, location=no, menubar=no,status=no, toolbar=no, scrollbars=yes, resizable=yes');"
                                                                            style="font-size: 11px;"  tabindex="-1">Password strength: </a><span style="float: left; font-size: 11px"
                                                                                id="password_description"></span>
                                                                        <p style="float: left; width: 170px">
                                                                            <span id="password_strength" class="strength0" style="margin: 4px 0px 0px 5px;">
                                                                            </span>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <span class="greytxt10px_default">(Minimum 8 characters, At least 1 letter and 1 number)</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3" style="height: 2px">
                                                                        <img src="~/App/Images/spacer.gif" height="2px" width="1" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 150px; color: #666; padding-bottom: 5px;">
                                                                        <span>Confirm New Password:</span>
                                                                    </td>
                                                                    <td align="left" class="inputfield_ftl">
                                                                        <span>
                                                                            <asp:TextBox ID="txtNewPasswordVerify" TextMode="Password" runat="server" CssClass="inputf_def"
                                                                                Width="150px" onkeydown='return txtkeypressPassword(event)'></asp:TextBox></span>
                                                                        <span style="float: left; color: #999; font: normal 8px arial;">(cAsE SeNsItIvE)</span>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>                                                                
                                                                <tr>
                                                                    <td height="10px" colspan="3">
                                                                        <img src="/App/Images/spacer.gif" height="10px" width="1" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <span style="float: left; color: #666666; font: normal 10px arial; font-style:italic;">
                                                                        (Note: The password typed above will be set as your password. You will have to provide this password if you attempt to login to system in near future.)
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="trSecQues" runat="server">
                                                        <td>
                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td height="5">
                                                                        <img src="/App/Images/spacer.gif" height="5" width="1" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="titletxt_ftl" style="width: 150px; color: #666;">
                                                                        Hint Question:
                                                                    </td>
                                                                    <td align="left" class="inputfield_ftl">
                                                                        <asp:TextBox ID="txtQuestion" runat="server" CssClass="inputf_def" Width="200px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="4px">
                                                                        <img src="~/App/Images/spacer.gif" height="4px" width="1" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="titletxt_ftl" style="width: 150px; color: #666;">
                                                                        Hint Answer:
                                                                    </td>
                                                                    <td align="left" class="inputfield_ftl">
                                                                        <asp:TextBox ID="txtAnswer" TextMode="Password" runat="server" CssClass="inputf_def"
                                                                            Width="200px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10px">
                                                                        <img src="/App/Images/spacer.gif" height="10px" width="1" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 240px;">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="120px">
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="btnCancel" runat="server" CssClass="" ImageUrl="/App/Images/cancel-button1.gif"
                                                                            OnClick="btnCancel_Click" />
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="btnSubmit" OnClientClick="return Validate();" runat="server"
                                                                            CssClass="" ImageUrl="/App/Images/submit-button.gif" OnClick="btnSubmit_Click" />
                                                                        <img id="loadingImg" src="Images/loading.gif" alt="Loading" style="display:none;"/>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>

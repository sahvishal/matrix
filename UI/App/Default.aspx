<%@ Page Language="C#" AutoEventWireup="True" Inherits="_Default" CodeBehind="Default.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/SystemVersion.ascx" TagName="SystemVersionControl"
    TagPrefix="SystemVersion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%= IoC.Resolve<ISettings>().CompanyName%> User Login</title>
    <link rel="shortcut icon" href="../favicon.ico" />
    <link href="StyleSheets/login.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function Validate() {
            //debugger1

            if (document.getElementById("<%= this.txtUserName.ClientID %>").value == "") {
                document.getElementById("divUserName").style.display = "";
                document.getElementById("<%= this.txtUserName.ClientID %>").focus();

                //if(document.getElementById("<%= this.txtPassword.ClientID %>").value != "")
                document.getElementById("divPassword").style.display = "none";
                document.getElementById("errormsg").style.display = "none";
                return false;
            }
            else if (document.getElementById("<%= this.txtPassword.ClientID %>").value == "") {
                document.getElementById("divPassword").style.display = "";
                document.getElementById("<%= this.txtPassword.ClientID %>").focus();

                //if(document.getElementById("<%= this.txtUserName.ClientID %>").value != "")
                document.getElementById("divUserName").style.display = "none";
                document.getElementById("errormsg").style.display = "none";
                return false;
            }
            else
                return true;
        }   
    </script>
    <style type="text/css">
        .style1
        {
            width: 420px;
        }
    </style>
</head>
<body style="margin: 0px 0px 0px 0px;">
    <form id="form1" runat="server">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="100%">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="720" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="30">
                                        <img src="Images/Login/spacer.gif" width="30" height="1">
                                    </td>
                                    <td height="50" valign="top" class="style1">
                                        <a href="/">
                                            <img src="<%= ResolveUrl(IoC.Resolve<ISettings>().MediumLogo) %>" ></a>
                                    </td>
                                    <td align="right" valign="bottom" class="back_btn">
                                        <span class="copyright" style="font-weight: bold">
                                            <SystemVersion:SystemVersionControl ID="SystemVersionControl" runat="server" />
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="720" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top" class="login_bg">
                                        <table border="0" cellpadding="0" cellspacing="0" class="rg_table_login">
                                            <tr valign="middle">
                                                <td height="40" class="signin_heading">
                                                    Login:
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td class="Signin_txt">
                                                    Please <u>enter</u> your username and password
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom">
                                                    <img src="Images/Login/spacer.gif" width="1" height="6" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom">
                                                    <span class="Signin_heading_txt">User Name</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="txt_fldlogin"></asp:TextBox>
                                                    <div id="divUserName" style="display: none">
                                                        <span class="errrmsg_txt">Required field cannot be left blank.</span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom" class="Signin_heading_txt">
                                                    <img src="Images/Login/spacer.gif" width="1" height="15">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom" class="Signin_heading_txt">
                                                    Password
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="txt_fldpass" autocomplete="off"></asp:TextBox>
                                                    <div id="divPassword" style="display: none;">
                                                        <span class="errrmsg_txt">We cannot log you into your account at this time. Please try
                                                            again later.</span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="Images/Login/spacer.gif" width="1" height="8" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="290" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left" class="Signin_heading_txtS">
                                                                <a href="../Public/Account/ResetPasswordStep1.aspx">I've forgotten my Username
                                                                    or Password?</a>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnSubmit" OnClientClick="return Validate();" runat="server"
                                                                    CssClass="" ImageUrl="Images/Login/btn_submit.gif" OnClick="btnSubmit_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="errrmsg_txt">
                                                    <div id="errormsg" runat="server">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" valign="top" class="login_bg_left">
                                        <table border="0" cellpadding="0" cellspacing="0" class="rgt_tbl">
                                            <tr valign="middle">
                                                <td height="37" class="signin_heading">
                                                    Trouble Logging in?
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td class="errrmsg_txt">
                                                    Note: If you have registered for or attended a
                                                    <%= IoC.Resolve<ISettings>().CompanyName%>
                                                    screening, you <u>already</u> have an account with us.
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td valign="bottom">
                                                    <span class="steps_txt">Step 1: Try to recover your username or password</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="note_txt">
                                                    Please <a href="../Public/Account/ResetPasswordStep1.aspx"><b>Click Here</b></a>
                                                    and follow the instructions to recover your username and/or password.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom" class="Signin_heading_txt">
                                                    <img src="Images/Login/spacer.gif" width="1" height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom">
                                                    <span class="steps_txt">Step 2: Customer Service Call</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="note_txt">
                                                    If you are not able to log in to your account after following the instructions in
                                                    Step 1, please email or call us.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="Images/Login/spacer.gif" width="1" height="15">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td valign="bottom">
                                                                <img src="/App/Images/login/call-icon.gif" alt="" />
                                                            </td>
                                                            <td>
                                                                <span class="callno">
                                                                    <%= IoC.Resolve<ISettings>().PhoneTollFree%>
                                                                </span><span class="note_txt"><u>OR</u>&nbsp; Email Us: <a href="mailto:<%= IoC.Resolve<ISettings>().SupportEmail.ToString()%>"
                                                                    target="_blank">
                                                                    <%= IoC.Resolve<ISettings>().SupportEmail.ToString()%>
                                                                </a></span>
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
                    <tr>
                        <td>
                            <table width="700" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                                <tr>
                                    <td width="50%" class="copyright" style="display: none;">
                                        &copy;
                                        <span>"2007 -" & <%=DateTime.Today.Year%> </span>
                                        Falcon<sup>&#0174;</sup> All rights reserved.
                                    </td>
                                    <td width="50%" align="right" class="copyright">
                                        <a target="_blank" href="<%= IoC.Resolve<ISettings>().PrivacyPolicyUrl%>">Privacy Policy</a>&nbsp; |&nbsp; 
                                        <a target="_blank" href="<%= IoC.Resolve<ISettings>().TermsConditionsUrl%>">Terms and Conditions</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="500" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" class="copyright">
                            Personal information maintained on this site is protected by using industry standard
                            security precautions against loss and unauthorized access. All financial transactions
                            and information transmitted over the Internet to/from this site are transmitted
                            using industry standard, SSL (secure socket layer) encryption to protect that information.<br >
                            <br >
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <%--	<div id="box">
		<p>Looks like you are having trouble logging in.</p>
	</div>
	<div id="main hide">
		<a class="button" href="#" id="HitMe">Click Me</a>
	</div>--%>
    <script language="javascript" type="text/javascript">
        document.onload = Init();
        function Init() {
            document.getElementById("divUserName").style.display = "none";
            document.getElementById("divPassword").style.display = "none";
        }  
    </script>
</body>
</html>

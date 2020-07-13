<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Common_ChangePassword" Codebehind="ChangePassword.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../StyleSheets/Wizardstyle.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" language="javascript">
    function Validate()
    {
        password = document.getElementById("<%= this.txtPassword.ClientID %>").value;

        if ('<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId %>' != '<%=(int)Falcon.App.Core.Enum.Roles.Customer  %>' || '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.ParentRoleId %>' != '<%=(int)Falcon.App.Core.Enum.Roles.Customer  %>') {
            if (password.length < 4) {
                alert("Password length can not be less than 4 characters.");
                return false;
            }
        }
        else {
            if (password.length < 8) {
                alert("Password length can not be less than 8 characters.");
                return false;
            }

            if (!IsNumeric(password) || !IsString(password)) {
                alert("New Password should contain at least one alphabet and one numeric ");
                return false;
            }
        }
        return true;
    }
    function IsNumeric(strString)
    {
        //  check for valid numeric strings	
       var strValidChars = "0123456789";
       var strChar;
       var blnResult = false;

       if (strString.length == 0) return false;

        // test strString consists of valid characters listed above
        for (i = 0; i < strString.length ;i++)
        {
            strChar = strString.charAt(i);
            if (strValidChars.indexOf(strChar) != -1)
            {
                blnResult = true;
                break;
            }
        }      
        return blnResult;
     }
     function IsString(strString)
     {
        //  check for valid numeric strings	
       var strValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
       var strChar;
       var blnResult = false;

       if (strString.length == 0) return false;

        // test strString consists of valid characters listed above
        for (i = 0; i < strString.length ;i++)
        {
            strChar = strString.charAt(i);
            if (strValidChars.indexOf(strChar) != -1)
            {
                blnResult = true;
                break;
            }
        }      
        return blnResult;
     }
     function txtkeypressPassword(evt) {
         var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
         if (evt.shiftKey == false && key == 32) return false;
     }

     function GeneratePassword() {
         var randVal = Math.round(10000 + (Math.random() * (99999 - 10000)));
         var txtPassword = document.getElementById("<%=txtPassword.ClientID %>");
         var txtNewPassword = document.getElementById("<%=txtNewPassword.ClientID %>");
         txtPassword.value = randVal;
         txtNewPassword.value = randVal;
         return false;
     }
    </script>
    <script type="text/javascript">
        window.onresize = function () {
            window.resizeTo(392, 250);
        }       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="msgbox_urm">
            <div class="msgboxrow_urm">
                <div class="midbg_mbox_urm">
                    <p class="msgboxinnerrow_urm">
                        <span class="headtxtmsgbox_urm"> Change Password  </span>            
                    </p>
                    <p><img src="../Images/specer.gif" height="2" width="8" /></p>
                    <p class="graylinembox_urm"><img src="../Images/specer.gif" width="1" height="1" /></p>
                    <p><img src="../Images/specer.gif" height="5" width="8" /></p>
                    <p class="msgboxinnerrow_urm" style="width:374px;">
                        <span class="titletxt_urm">New Password:</span>
                        <span class="inputfldconmbox_urm">
                            <asp:TextBox runat="server" ID="txtPassword" Width="140px" CssClass="inputf_def" MaxLength="15" onkeydown='return txtkeypressPassword(event)'></asp:TextBox>
                        </span>
                        <% 
                            if (!IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.Customer))
                            {
                         %>
                        <span style="float:right; width:100px;" id="">
                            <a id="lnkGeneratePassword" onclick="GeneratePassword();" href="javascript:void(0);">Generate</a>
                        </span>
                        <% } %>
                    </p>            
                    <p class="msgboxinnerrow_urm" style="display:none;">
                        <span class="titletxt_urm">Re-type Password:</span>
                        <span class="inputfldconmbox_urm"><asp:TextBox runat="server" ID="txtNewPassword" Width="140px" CssClass="inputf_def" MaxLength="10" onkeydown='return txtkeypressPassword(event)'></asp:TextBox></span>
                    </p>
                    <%--<p class="msgboxinnerrow_urm">
                    <span class="chkboxmbox_urm"><asp:CheckBox ID="chkPasswordChangeAtNextLogon" runat="server" /></span>
                    <span class="txtchkbox_urm" runat="server" id="spnPasswordChange">User Must Change Password on Next Login</span>
                    </p>--%>
            
                    <%--<p class="msgboxinnerrow_urm">
                    <span class="chkboxmbox_urm"><asp:CheckBox ID="chkNotifyUser" runat="server" /></span>
                    <span class="txtchkbox_urm" runat="server" id="spnMailSent">Notify user via mail</span>
                    </p>--%>
            
                    <p style="float:right">
                      <span class="buttoncon_default"><a href="javascript:void(0);" onclick="javascript:window.close();"><img src="../Images/cancel-btn.gif" /></a></span>
                      <span class="buttoncon_default"><asp:ImageButton ID="ibtnChange" runat="server" ImageUrl="~/App/Images/change-btn.gif" OnClick="ibtnChange_Click" OnClientClick="return Validate();" /></span>
                    </p>
                    <% 
                        if (!IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.Customer))
                        {
                    %>
                    <p class="msgboxinnerrow_urm" style="width:374px;">
                        <i>You will be asked to change your password when you login.</i>
                    </p>
                    <% } else {%>
                    <p class="msgboxinnerrow_urm" style="width:374px;">
                        <i>(Minimum 8 characters, At least 1 letter and 1 number)</i>
                    </p>
                    <% }%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

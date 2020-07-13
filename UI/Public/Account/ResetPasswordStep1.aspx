<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master"
    Inherits="Falcon.App.UI.Public.Account.ResetPasswordStep1" CodeBehind="ResetPasswordStep1.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>

<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function ValidationReset() {
            ///Validate UserId
            var txtUserId = document.getElementById("<%= this.txtUserId.ClientID %>").value;
            if (txtUserId == '') {
                alert('Username can not left blank ');
                document.getElementById("<%= this.txtUserId.ClientID %>").focus();
                return false;
            }
            else
                return true;

        }
        function ValidateEmailCustomerID() {
            ///Validate UserId
            var txtEmailOrCustomerId = document.getElementById("<%= this.txtEmailOrCustomerId.ClientID %>").value;
            if (txtEmailOrCustomerId == '') {
                alert('Email/CustomerId can not left blank');
                document.getElementById("<%= this.txtEmailOrCustomerId.ClientID %>").focus();
                return false;
            }
            else
                return true;

        }   
    </script>
    <!-- Start your error div here -------------- -->
    <!-- End your error div here -------------- -->
    <div class="maindivouterlogin1_pw" style="margin-left: 10px;">
        <div class="maindivredmsgbox_pw" id="divError" runat="server" enableviewstate="false"
            visible="false" style="margin-left: 10px;">
        </div>
        <div class="maindivouterlogin_pw" style="margin-left: 10px; margin-top: 10px">
            <div class="header_pw">
                <div class="headertxt_pw">
                    Forgot Login?</div>
            </div>
            <div class="body_border_pw" style="padding: 10px; width: 622px">
                <table cellpadding="0px" cellspacing="0px" border="0" width="100%">
                    <tr>
                        <td style="width: 280px; padding: 5px" valign="top">
                            <asp:Panel runat="server" DefaultButton="btnResetPassword" ID="panel1">
                                <table cellpadding="0px" cellspacing="0px" border="0" width="100%">
                                    <tr>
                                        <td colspan="2" style="color: #00A5E6">
                                            <b>Retrieve Your Password</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            If you forgot your password, enter your Username&nbsp; to retrieve it.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <b>Enter Your Username:</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtUserId" runat="server" CssClass="inputf_pw" Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;<asp:ImageButton ID="btnResetPassword" runat="server" ImageUrl="~/Content/Images/ResetPassword.gif"
                                                OnClick="btnResetPassword_Click1" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td style="width: 280px; padding: 5px" valign="top">
                            <asp:Panel runat="server" DefaultButton="btnRetriveUserId" ID="panel2">
                                <table cellpadding="0px" cellspacing="0px" border="0" width="100%">
                                    <tr>
                                        <td colspan="2" style="color: #00A5E6">
                                            <b>Retrieve Your Username</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 45px">
                                            If you forgot your Username , enter your e-mail address or Customer Id to retrieve
                                            your Username .&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="15px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <b>Enter Your E-mail/Customer ID:</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtEmailOrCustomerId" runat="server" CssClass="inputf_pw" Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnRetriveUserId" runat="server" ImageUrl="~/Content/Images/RetrieveUserID-btn.gif"
                                                OnClick="btnRetriveUserId_Click1" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="bottombg_pw">
            </div>
            <div style="text-align: center; font-size: 14px; width: 644px; margin: 5px 0px 0px 10px;">
                Call at <span style="color: #00A5E6; font-weight: bold">
                    <%= IoC.Resolve<ISettings>().PhoneTollFree%></span>
                for more assistance</div>
        </div>
    </div>
</asp:Content>

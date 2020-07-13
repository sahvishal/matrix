<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master"
    Inherits="Falcon.App.UI.Public.Account.ResetPasswordStep2" EnableEventValidation="false" CodeBehind="ResetPasswordStep2.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function Validation() {
            ///Validate Answer 
            var txtAnswer = document.getElementById("<%= this.txtAnswer.ClientID %>");
            // Answer can not be null or blank
            if (isBlank(txtAnswer, "Answer"))
            { return false; }
            return true;
        }
    
    </script>
    <div class="maindivouterlogin1_pw" style="margin-left: 10px;">
        <div class="maindivredmsgbox_pw" id="divError" runat="server" enableviewstate="false"
            visible="false" style="margin-left: 10px;">
        </div>
        <asp:Panel runat="server" DefaultButton="ibtnContinue" ID="panel1">
            <div class="maindivouterlogin_pw" style="margin-left: 10px; margin-top: 10px">
                <div class="header_pw">
                    <div class="headertxt_pw" id="divHeading" runat="server">
                        Retrieve Username
                    </div>
                </div>
                <div class="body_border_pw">
                    <div class="headbgnonelm_pw">
                        <div class="headtxt_pw">
                            For your protection, please enter the following information:</div>
                    </div>
                    <div class="contentrowlm_pw">
                        <div class="titletextlm_pw">
                            Hint Question</div>
                        <div id="divQues" runat="server" class="normaltextlm_pw">
                            Favorite teacher?</div>
                    </div>
                    <p class="contentrowlm_pw">
                        <span class="titletextlm_pw">Hint Answer</span> <span class="inputfieldbig_pw">
                            <asp:TextBox ID="txtAnswer" runat="server" CssClass="inputf_pw" Width="150px"></asp:TextBox></span>
                    </p>
                </div>
                <div class="bottombg_pw">
                </div>
                <div class="buttonrow_pw">
                    <div class="buttoncelllm_pw">
                        <div class="conbuttonlm_pw">
                            <asp:ImageButton ID="ibtnContinue" runat="server" CssClass="" ImageUrl="~/Content/Images/Submitbutton-pw.gif"
                                OnClientClick="return Validation();" OnClick="ibtnContinue_Click" /></div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

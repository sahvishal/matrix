<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiftCertificateDetails.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.GiftCertificateDetails" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="uc" %>
<uc:JQueryToolkit ID="JQueryToolkit" runat="server" IncludeJQueryThickBox="true"
    IncludeJQueryCookie="true" IncludeJQueryValidators="true" />
<link href="/App/StyleSheets/GiftCertificate.css" rel="Stylesheet" type="text/css" />
<style type="text/css">
    input
    {
        border: 1px solid #cad2c3;
        margin-bottom: .5em;
    }
    input.error
    {
        border: 1px solid red;
    }
</style>

<script type="text/javascript" language="javascript">
    $(function() {

        $.validator.setDefaults({
            success: "ValidForm"
        });

        $('form').validate();

        $('.ddl-type').change(function() {
            if ($.trim($('.ddl-type option:selected').text()) != "Other")
                DefaultMessage();
            else
                $('.message-text').val('');
        });

        $('.to-name-text').change(function() {
            DefaultMessage();
        });
    });

    function DefaultMessage() {
        if ($.trim($('.ddl-type option:selected').text()) == "Anniversary")
            $('.message-text').val('Happy ' + $.trim($('.ddl-type option:selected').text()) + ' ' + $.trim($('.to-name-text').val()) + '!');
        if ($.trim($('.ddl-type option:selected').text()) == "Father's Day" || $.trim($('.ddl-type option:selected').text()) == "Mother's Day")
            $('.message-text').val('Happy ' + $.trim($('.ddl-type option:selected').text()) + '!');
        if ($.trim($('.ddl-type option:selected').text()) == "Christmas")
            $('.message-text').val('Merry ' + $.trim($('.ddl-type option:selected').text()) + ' ' + $.trim($('.to-name-text').val()) + '!');
        if ($.trim($('.ddl-type option:selected').text()) == "Birthday")
            $('.message-text').val('Happy ' + $.trim($('.ddl-type option:selected').text()) + ' ' + $.trim($('.to-name-text').val()) + '!');
    }

    function ValidForm() {
        return true;
    }
    
    
</script>
<div class="divouter_pw main-div">
    <div class="leftbg_headgftc">
        
            Enter the information of the person who will receive this gift certificate
    </div>
    <asp:Panel runat="server" ID="DetailsContainerDiv" DefaultButton="SubmitButton" CssClass="bodydiv2_gftc">
        <div class="amntinfobox_gftc">
            <div class="inner">
                <span class="amonttxt">
                    <asp:Literal ID="TotalAmountLiteral" runat="server" Text="$" /></span>
            </div>
        </div>
        <div class="amnttxtbox_gftc">
            Gift certificate value:<b>
                <asp:Label ID="AmountLabel" runat="server" Text="$" CssClass="amount-label" /></b>
            <br />
            <span runat="server" id="ChangeAmountAnchorContainer" class="stxt_gftc"><a href="#" id="ChangeAmountAnchor" runat="server" onserverclick="ChangeAmountAnchor_ServerClick">
                Click here</a> to change the amount of your gift certificate</span>
        </div>
        <div class="bdrow2_gftc">
            <div class="lfttxtfld_gftc">
                To:(<i>Recipient’s name</i>)
                <asp:TextBox runat="server" ID="RecipientNameText" Width="225px" CssClass="to-name-text required" />
            </div>
            <div class="lfttxtfld_gftc">
                From:
                <asp:TextBox runat="server" ID="FromNameText" Width="240px" CssClass="from-name-text required" />
            </div>
        </div>
        <div class="bdrow2_gftc">
            <div class="lfttxtfld_gftc">
                Recipient’s Email Address:
                <asp:TextBox runat="server" ID="RecipientEmailText" Width="225px" CssClass="required email" />
            </div>
            <div class="lfttxtfld_gftc">
                Occasion:
                <asp:DropDownList ID="GiftCertificateTypeCombo" runat="server" CssClass="required ddl-type"
                    Width="240px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="bdrow2_gftc">
            <div class="lfttxtfld_gftc" style="width: 550px">
                Personalized Message:
                <asp:TextBox runat="server" ID="MessageTextBox" TextMode="MultiLine" Rows="2" Width="515px"
                    CssClass="message-text" />
            </div>
        </div>
        <div class="bdrow2_gftc" style="text-align: center; margin-top: 10px">
        </div>
    </asp:Panel>
    <div class="footbg_gftc">
    </div>
</div>
<div class="btnrow_gftc">
    <div class="right">
        <asp:ImageButton ID="SubmitButton" runat="server" ImageUrl="~/Content/Images/next-orngbtn-PW.gif"
            OnClick="SubmitButton_Click" />
    </div>
    <div class="right stxt_gftc" style="padding: 3px 5px 0 0">
        &nbsp;|&nbsp;</div>
    <div class="right stxt_gftc" style="padding: 3px 5px 0 0">
        <a href="#" onclick="OpenPopUp();">Preview Gift Certificate</a></div>
    <div class="right stxt_gftc" style="padding: 3px 5px 0 0">
        &nbsp;|&nbsp;</div>
    <div class="right stxt_gftc" style="padding: 3px 5px 0 0">
        <a href="#" id="BackAnchor" runat="server" onserverclick="ChangeAmountAnchor_ServerClick">
            Back</a>
    </div>
</div>

<script type="text/javascript" language="javascript">
    function OpenPopUp() {
        var pageUrl = '/App/Common/PreviewGiftCertificate.aspx?P=true&keepThis=true&TB_iframe=true&width=660&height=450&modal=true&scroll=false';
        tb_show('Gift Certificate Preview', pageUrl, false);
    }
        
    function getAmount()
    {
        return $('.amount-label').text();
    }
        
    function getFromName()
    {
        return $('.from-name-text').val();
    }
        
    function getToName()
    {
        return $('.to-name-text').val();
    }
        
    function getMessage()
    {
        return $('.message-text').val();
    }
    
</script>


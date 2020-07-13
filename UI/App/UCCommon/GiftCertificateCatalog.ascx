<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiftCertificateCatalog.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.GiftCertificateCatalog" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc" %>
<uc:_jQueryToolKit ID="ucJquery" runat="server" IncludeJQueryUI="true" IncludeJTemplate="true" />
<script language="javascript" type="text/javascript">

    $(document).ready(function () {
        $('#divSaveWaitAnimation').show();
        var isOnlinePurchase = '<%=IsOnlinePurchase %>' == 'True' ? true : false;
        var messageUrl = '';
        //        if (isOnlinePurchase)
        //            messageUrl = '<%= ResolveUrl("~/App/Controllers/GiftCertificateController.asmx/GetNewGiftCertificateOfferingViewData") %>';
        //        else
        messageUrl = '<%= ResolveUrl("~/App/Controllers/GiftCertificateController.asmx/GetCompleteGiftCertificateOfferingViewData") %>';
        InvokeService(messageUrl);
    });

    function InvokeService(messageUrl) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: '{}',
            success: function (result) {
                $("#GiftCertificateContainerDiv").setTemplateURL('<%= ResolveUrl("~/App/Templates/GiftCertificateCatalog.htm") %>');
                $("#GiftCertificateContainerDiv").processTemplate(result.d);
                $('#divSaveWaitAnimation').hide();
            },
            error: function (a, b, c) {
                alert("Oops! a problem occured in the system.");
                $('#divSaveWaitAnimation').hide();
            }

        });
    }

    function MoveNextStep(amount) {
        __doPostBack("MoveNextStep", amount);
    }

    function MoveNextStepwithCustomAmount() {

        var amount = $('.customamount-input-text').val();
        if ($.trim(amount).length < 1) {
            alert('Please input some amount.');
            return false;

        }
        if (parseFloat($.trim(amount)) < 20 || parseFloat($.trim(amount)) > 1000) {
            alert('Please enter amount between $20 and $1000');
            return false;
        }
        __doPostBack("MoveNextStep", amount);

        return false;
    }
    function KeyPress_DecimalAllowedOnly(evt) {
        var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
        var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

        if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
            if (key == 46 || key == 190) {
                if (InpObject.value.indexOf(".") >= 0) return false;
            }
            return true;
        }
        return false;
    }
</script>
<style type="text/css">
    .bckImage
    {
        background-image: url(<%= IoC.Resolve<ISettings>().GiftCertificateThumbnailPath %>);
        background-repeat: no-repeat;
    }
</style>
<link href="/App/StyleSheets/GiftCertificate.css" rel="Stylesheet" type="text/css" />
<div class="divouter_pw">
    <div class="leftbg_headgftc">
        <div>
            Choose from our most popular gift certificates, or enter a custom amount below</div>
    </div>
    <div class="bodydiv_gftc">
        <div id="divSaveWaitAnimation" class="loading" style="display: none; text-align: center;
            width: 100%">
        </div>
        <div id="GiftCertificateContainerDiv" class="left">
        </div>
        <div class="subheadtop_gftc" style="margin-bottom: 5px">
            Custom Gift Certificate Amount
        </div>
        <div class="sbhead3t_gftc" style="font-size: 13px">
            <b>If you prefer a custom amount, you can enter an amount between $20 and $1000 below.
            </b>
        </div>
        <div class="subhead_gftc" style="background: #f5f5f5; padding: 10px 5px; border: none">
            <span class="left" style="margin-right: 5px"><b>Enter custom amount:&nbsp;</b><span
                style="color: #666">$ </span>
                <asp:TextBox ID="CustomAmountInputText" CssClass="customamount-input-text" runat="server"
                    size="20" Style="width: 150px" onkeydown="return KeyPress_DecimalAllowedOnly(event);" /></span>
            <span class="left">
                <asp:ImageButton runat="server" ID="NextStepImageButton" ImageUrl="~/Content/Images/buy_btn_gftc.gif"
                    OnClientClick="return MoveNextStepwithCustomAmount();" OnClick="SomeFunction" />
            </span>
        </div>
    </div>
    <div class="footbg_gftc">
        <asp:TextBox runat="server" ID="txtHidden" AutoPostBack="true" Style="display: none;"></asp:TextBox>
    </div>
    <div class="grayinfotxt">
        <sup>*</sup><i>No expiration date. All sales are final. Not returnable or refundable
            for cash.</i></div>
</div>

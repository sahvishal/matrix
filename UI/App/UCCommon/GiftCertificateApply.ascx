<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiftCertificateApply.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.GiftCertificateApply" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="Toolkit" TagPrefix="uc1" %>
<uc1:Toolkit ID="_ucJquery" runat="server" />
<link href='/App/StyleSheets/GiftCertificate.css' rel="Stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">
    $(function() {
        $('#CancelGC').click(function(e) {
            CancelAppliedGC();
        });
        
        $('#GCApplychk').click(function(e) {
            RemoveGiftCertificate();
            if ($('#GCApplychk').attr('checked')) {
                $('.gc_row').show();
            }
            else {
                RemoveGiftCertificate();
            }

        });

        $('#_gcApplyimgBtn').click(function(e) {
            $('#gcMessage').hide();
            var claimCode = $('#_gcClaimCode').val();
            var messageUrl = '<%= ResolveUrl("~/App/Controllers/GiftCertificateController.asmx/GetGiftCertificateByClaimCode") %>';
            var parameter = "{'claimCode':'" + claimCode + "'}";
            InvokeService(messageUrl, parameter);
        });

    });

    function InvokeService(messageUrl, parameter) {
        $('#divloading').show();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: parameter,
            success: function(result) {
                
                if (result.d.IsSuccess) {
                    $('#<%= this._gcId.ClientID %>').val(result.d.Data.Id);
                    $('#<%= this._gcPaidAmount.ClientID %>').val(parseFloat(result.d.Data.BalanceAmount).toFixed(2));
                    $('#BalanceAmount').text("$" + parseFloat(result.d.Data.BalanceAmount).toFixed(2));
                    $('#divloading').hide();

                    if ($('.total-amount-span').length > 0 && $.trim($('.total-amount-span').text()).length > 0) {
                        var totalAmount = parseFloat($.trim($('.total-amount-span').text().replace('$', '')));
                        var balanceAmount = parseFloat(result.d.Data.BalanceAmount).toFixed(2);

                        if (totalAmount > balanceAmount) {
                            $('.message-row').show();
                            var amountLeft = totalAmount - balanceAmount;
                            $('#LeftAmount').text('$' + parseFloat(amountLeft).toFixed(2));
                            $('.remaining-amount-p').show();
                            $('.error-message-row').hide();
                            $('.cancel-other-payment-mode').removeAttr("disabled");
                            $('.other-payment-mode-detail').show();
                        } else {
                            $('#BalanceAmount').text("$" + parseFloat(totalAmount).toFixed(2));
                            $('.message-row').show();
                            $('.remaining-amount-p').hide();
                            $('.error-message-row').hide();
                            $('.cancel-other-payment-mode').attr("disabled", "disabled");
                            $('.other-payment-mode-detail').hide();
                        }
                    }
                } else {
                    $('#<%= this._gcId.ClientID %>').val('0');
                    $('#<%= this._gcPaidAmount.ClientID %>').val('0');
                    $('#divloading').hide();
                    $('.error-message-row').show();
                    $('.error-message-row').text(result.d.Message);
                    $('.message-row').hide();
                    $('.cancel-other-payment-mode').removeAttr("disabled");
                    $('.other-payment-mode-detail').show();
                }
                
            },
            error: function(a, b, c) {

                $('#<%= this._gcId.ClientID %>').val('0');
                $('#<%= this._gcPaidAmount.ClientID %>').val('0');
                $('#divloading').hide();
                $('.error-message-row').show();
                var errorData = eval("(" + a.responseText + ")");
                $('.error-message-row').text(errorData.Message);
                $('.message-row').hide();
                $('.cancel-other-payment-mode').removeAttr("disabled");
                $('.other-payment-mode-detail').show();
            }
        });
    }

    function RemoveGiftCertificate() {
        $('.gc_row').hide();
        $('#_gcClaimCode').val('');
        $('#<%= this._gcId.ClientID %>').val('0');
        $('#<%= this._gcPaidAmount.ClientID %>').val('0');
        $('#BalanceAmount').text('');
        $('#LeftAmount').text('');
        $('.message-row').hide();
        $('.error-message-row').hide();
        $('.cancel-other-payment-mode').removeAttr("disabled");
        $('.other-payment-mode-detail').show();

    }

    function onlyGCApplied(amountToBeBilled) {
        
        var GiftCertificateBalanceAmount = ($('#<%= _gcPaidAmount.ClientID %>').length <= 0) ? 0 : $('#<%= _gcPaidAmount.ClientID %>').val();
        var GiftCertificateId = ($('#<%= _gcId.ClientID %>').length <= 0) ? 0 : $('#<%= this._gcId.ClientID %>').val();
        var totalAmount = amountToBeBilled;
        if ((GiftCertificateId > 0) && (parseFloat(GiftCertificateBalanceAmount) >= parseFloat(totalAmount)))
            return true;
        else
            return false;
    }
    function CancelAppliedGC() {

        $('#GCApplychk').attr('checked', false);

        RemoveGiftCertificate();
    }

    function SelectGC() {
        $('.gc_row').show();
        $('#GCApplychk').attr('checked', true);
        
    }
</script>

<div class="paythroughgc">
    <div class="drow">
        <div id="divloading" class="loadingdiv_ucecustlist" style="display: none">
            <span class="ltxt">Loading...</span> <span class="left">
                <img src="/App/Images/loading.gif" alt="" /></span>
        </div>
        <p class="drowin">
            <input type="checkbox" id="GCApplychk" />
            <span class="boldblulbl">Pay through Gift Certificates</span></p>
        <p class="drowin gc_row" style="display: none">
            <span class="labelb">Enter the Claim Code:</span> <span class="inptbox">
                <input type="text" id="_gcClaimCode" class="inputf_pw" /></span> <span class="applybtn">
                    <img src="/Content/Images/apply-btn.gif" id="_gcApplyimgBtn" /></span> <span style="float: left;
                        padding: 8px 0 0 0px"><a href="#" id="CancelGC">Cancel</a></span>
        </p>
        <p class="drowin2 error-message-row" style="display: none;">
        </p>
        <p class="drowin2 message-row" style="display: none;">
            Amount Paid through Gift Certificate : <span id="BalanceAmount" style="color: #000;
                font-weight: bold"></span>
        </p>
        <p class="drowin2 remaining-amount-p message-row" style="display: none; padding-top: 5px">
            Balance Amount (To be paid through other mode): <span id="LeftAmount" style="color: #000;
                font-weight: bold"></span>
        </p>
    </div>
    <asp:HiddenField ID="_gcId" runat="server" />
    <asp:HiddenField ID="_gcPaidAmount" runat="server" />
</div>

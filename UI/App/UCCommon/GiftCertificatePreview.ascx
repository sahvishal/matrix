<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiftCertificatePreview.ascx.cs"
    Inherits="Falcon.App.UI.Public.UCPublic.GiftCertificatePreview" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="uc" %>
<style type="text/css">
    .image-button {
        background-color: #FD8F2D;
        color: #ffffff !important;
        font-weight: bold;
        border: 0 solid !important;
        vertical-align: top;
        height: 22px;
    }
</style>
<div class="divouter_pw">
    <uc:JQueryToolkit ID="JQueryToolkit" runat="server" IncludeJQueryCookie="true" IncludeJQueryUI="true"
        IncludeJQueryThickBox="true" />
    <link href='/App/StyleSheets/GiftCertificate.css' rel="Stylesheet" type="text/css" />
    <div class="headingtxt" style="display: none">
        Step 6: Gift Certificate Purchase Confirmation</div>
    <div id="SendOptionDiv" class="divsendoption" runat="server">
        Your Gift Certificate for <span class="amonttxt" id="MainAmountSpan" runat="server">
        </span> has been generated.
        <div class="graybox">
             <div class="hrows">
                <asp:CheckBox runat="server" ID="SendGCNotification" Text="Send email notification" Checked="True" />
            </div>
            <div class="hrows" style="padding-left: 13px;">
                <span class="hlfarea">
                    <asp:RadioButton ID="SendEmailRadio" runat="server" Text="Send an email now" GroupName="EmailRadio"
                        Checked="true" CssClass="send-email-now" /></span> <span class="hlfarea">
                            <asp:CheckBox ID="CopyToMeCheck" runat="server" Text="Send me a copy of the certificate"
                                Checked="true" />
                        </span>
            </div>
            <div class="hrows" style="padding-left: 13px;">
                <asp:RadioButton ID="SendOnRadioButton" runat="server" Text="Send Gift Certificate On"
                    GroupName="EmailRadio" CssClass="send-on-date" />
                <asp:TextBox ID="SendOnDate" runat="server" CssClass="date-picker" Width="80px"></asp:TextBox>
                (MM/DD/YYYY)
            </div>
        </div>
    </div>
    <style type="text/css">
        .bckImage
        {
            background-image: url(<%= IoC.Resolve<ISettings>().GiftCertificateImagePath %>);
            background-repeat: no-repeat;
        }
    </style>
    <div id="PreviewGC">
        <div class="divcertificate">
            <div class="inner bckImage">
                <div class="divamount">
                    <label> Amount: </label> <span class="amonttxt amount-span" id="AmountInput" runat="server"
                        enableviewstate="true"> $</span>
                </div>
                <div class="custdtlsbox">
                    <div class="hrow">
                        <label>
                            To:</label>
                        <span class="totxt to-name-span" id="ToNameInput" runat="server" enableviewstate="true">
                        </span>
                    </div>
                    <div class="hrow" style="height: 70px">
                        <label class="labelmsg">
                            Personal Message:</label>
                        <span class="prsnlmsg message-span" id="MessageInput" runat="server" enableviewstate="true"
                            style="overflow: hidden;"></span>
                    </div>
                    <div class="hrow" style="height: 50px">
                        <label class="labeld">
                            Claim Code #:</label>
                        <span class="cupncode claim-code-span" id="ClaimCodeSpan" runat="server" enableviewstate="true">
                            <i>The code will be generated after you buy the gift certificate.</i></span>
                    </div>
                    <div class="hrow">
                        <label>
                            From:</label>
                        <span class="cupncode from-name-span" id="FromNameInput" runat="server" enableviewstate="true">
                        </span>
                    </div>
                </div>
            </div>
            <div class="grayinfotxt" style="padding: 0px">
                <sup>*</sup><i>No expiration date. All sales are final. Not returnable or refundable
                    for cash.</i></div>
        </div>
    </div>
</div>
<div class="divouter_pw" runat="server" id="PrintFinishDiv" style="border:none;">
    <div class="right">
        <img src="/App/Images/indicator.gif" style="display: none;" alt="" id="ProcessingImage" />
    </div>
    <div class="right" style="padding-right: 10px">
        <asp:ImageButton ID="PrintGiftCertificate" runat="server" ImageUrl="/App/Images/print-gc-btn.gif"
            OnClientClick="return Print();" />
        <asp:Button runat="server" ID="FinishGCGeneration" Text="Finish" CssClass="image-button image-send" OnClick="FinishButton_Click" OnClientClick="return ValidateDate();"/>
        <%--<asp:ImageButton ID="FinishButton" runat="server" ImageUrl="/App/Images/sendemailnfinish-gc-btn.gif"
            OnClick="FinishButton_Click" OnClientClick="return ValidateDate();" CssClass="image-send" />--%>
    </div>
</div>

<script type="text/javascript" language="javascript">
    $(function () {
        var currentDate = new Date();
        currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1);
        $(".date-picker").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: (currentDate.getFullYear() + ":" + currentDate.getFullYear() + 1),
            defaultDate: currentDate,
            maxDate: new Date("01/01/2011"),
            minDate: currentDate,
            dateSelected: function () { ('.send-on-date input:radio').attr('checked', true); }
        });

        $('.send-email-now').click(function () {
            if ($('.send-email-now input:radio').attr('checked')) {
                $('.date-picker').val('');
            }
        });

        $("input[id$='SendGCNotification']").change(function () {
            if ($(this).is(":checked") == false) {
                $("input[name$='EmailRadio']").removeAttr("checked");
                $("input[id$='CopyToMeCheck']").removeAttr("checked");
                $("input[name$='EmailRadio']").attr("disabled", "disabled");
                $("input[id$='CopyToMeCheck']").attr("disabled", "disabled");
                $('.date-picker').val('');
            } else {
                $("input[name$='EmailRadio']").removeAttr("disabled", "disabled");
                $("input[id$='CopyToMeCheck']").removeAttr("disabled", "disabled");
                $('.send-email-now input:radio').attr('checked', 'checked');
                $("input[id$='CopyToMeCheck']").attr('checked', 'checked');
                $('.date-picker').val('');
            }
        });
    });

    function ValidateDate() {
        if ($('.send-on-date').find('input:radio').attr('checked')) {
            if ($.trim($('.date-picker').val()).length <= 0) {
                alert('Please enter a valid date for sending an email.');
                return false;
            }

            if (!IsValidDate($.trim($('.date-picker').val()), "'Send On Date'")) return false;
        }
        $('.image-send').hide();
        $('#ProcessingImage').show();
        return true;
    }
   
</script>
<script type="text/javascript" language="javascript">
    function Print() {
        var pageUrl = '<%= PDFURLPath %>';
        var printWindow = window.open(pageUrl, '', 'left=0,top=0,width=500,height=600,toolbar=0,scrollbars=0,status=0');

        return false;
    }

    function SetValuesForPreview() {
        $(".amount-span").text(parent.getAmount());
        $(".to-name-span").text(parent.getToName());
        $(".message-span").text(parent.getMessage());
        $(".from-name-span").text(parent.getFromName());
    }

    function IsValidDate(dateStr, returnmessage) {
        // var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;
        var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
        if (dateStr.match(RegExPattern))
            return true;
        else {
            alert("Please provide a valid " + returnmessage);
            return false;
        }
    }
    
</script>

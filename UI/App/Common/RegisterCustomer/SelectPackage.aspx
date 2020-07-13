<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    Inherits="Falcon.App.UI.App.Common.RegisterCustomer.SelectPackage" CodeBehind="SelectPackage.aspx.cs"
    Title="Select Package" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/OrderItemCart.ascx" TagName="ItemCart" TagPrefix="Order" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="/App/JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>
    <script src="/Content/JavaScript/PreQualificationQuestion.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var isSourceCodeApplied = false;

        var isPrefilledQuestionsShow = true;


        var prefilledQuestions = '<%=QuestionIdAnswerTestId %>';
        var disQualifiedQuestionandAnswer = '<%=DisqualifiedTest %>';

        function SelectPackage() {
            // Set the shopping cart data from the control on the page....
            $('#<%= PackageIdHiddenControl.ClientID %>').val($('#PackageIdHiddenControl').val());
            $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val($('#IndependentTestIdsHiddenControl').val());
            $('#<%=TestIdsHiddenControl.ClientID %>').val($('#TestIdsHiddenControl').val());
            $('#<%= dvSelectedPackageAmt.ClientID %>').text($('#OfferPriceSpan').text());
            $('#<%= hfPackageCost.ClientID %>').val($('#OfferPriceSpan').text());
            $('#<%= dvSelectedPackageDesc.ClientID %>').text($('#PackageDescriptionHidden').val());
            $('#<%= hfPackageDesc.ClientID %>').val($('#PackageDescriptionHidden').val());

            var packageAndTestCost = parseFloat($('#OfferPriceSpan').text());

            $('#<%= dvTotalAmount.ClientID %>').text((packageAndTestCost).toFixed(2));
            $('#<%= dvTotalBill.ClientID %>').text((packageAndTestCost).toFixed(2));
            $('#<%= hfTotalAmount.ClientID %>').val($('#<%= dvTotalAmount.ClientID %>').text());

            //Since the package is changed cancel the previous applied coupon....
            $('#dvCoupon').hide();
            $('#dvCouponDesc').text('');
            $('#<%= dvCouponAmt.ClientID %>').text('0.00');

            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
            if ($.trim(txtCouponCode.val()).length > 0 && isSourceCodeApplied)
                CouponValidation();
            return true;
        }

        function fnToggle() {
            oTransContainer.filters[0].Apply();
            oTransContainer.filters[0].Play();
        }

        function NextButtonClick() {
            PlaceOrderClick(Validation);
            return false;
        }

        function Validation() {
            var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
            var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

            if (packageId == '0' && testIds == '0') {
                if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
                    alert("Please select a Package or tests.");
                else
                    alert("Please select a Package.");
                return false;
            }

            if (parseFloat($('#<%= dvSelectedPackageAmt.ClientID %>').text()) < parseFloat('<%=MinimumPurchaseAmount %>')) {
                alert('The minimum price of the order should be ' + '<%=MinimumPurchaseAmount %>');
                return false;
            }


            __doPostBack('NextButton', 'Click');
        }



        function CancelClick() {
            return confirm("Are you sure you want to cancel.");
        }
        /// format the value passed as a numeric value with 2 decimal places
        function formatAmount(num) {
            if (isNaN(parseFloat(num))) {
                num = '0.00';
            }
            return parseFloat(num);
            try {
                num = num.replace(/^\s+|\s+$/g, "");
            }
            catch (err) {
                num = num
            }
            num = parseFloat(num);
            if (isNaN(num)) {
                num = '0.00';
            }
            return parseFloat(num.toFixed(2));
        }

        function CouponValidation() {//debugger;
            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
            if (txtCouponCode.val() == '') {
                alert('Please enter source code.');
                return false;
            }
            var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
            var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

            if (packageId == '0' && testIds == '0') {
                if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
                    alert("Please select atlest one package or a test to avail the coupon.");
                else
                    alert("Please select atlest one package to avail the coupon.");
                return false;
            }

            var spIndicator = document.getElementById("spIndicator");
            spIndicator.style.visibility = "visible";
            spIndicator.style.display = "block";

            var dvSelectedPackageAmt = $("#<%= dvSelectedPackageAmt.ClientID %>");
            var hfEventID = $("#<%= hfEventID.ClientID %>");

            var parameter = "{'packageId':'" + $.trim(packageId) + "'";
            parameter += ",'addOnTestIds':'" + $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val() + "'";
            parameter += ",'orderTotal':'" + dvSelectedPackageAmt.text() + "'";
            parameter += ",'couponCode':'" + txtCouponCode.val() + "'";
            parameter += ",'eventId':'<%= EventId %>'";
            parameter += ",'customerId':'<%= CustomerId %>'}";
            var messageUrl = '<%=ResolveUrl("~/App/Common/RegisterCustomer/SelectPackage.aspx/GetCoupon")%>';
            var successFunction = function (result) {
                ApplyCouponAmount(result.d);
            };
            var errorFunction = function () {
                alert('There was a problem retrieving the data, please try again later.');
                spIndicator.style.visibility = "hidden";
                spIndicator.style.display = "none";
            }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
            return false;
        }

        function ApplyCouponAmount(result) {
            //for maintaing state after postback made for applying coupon
            var hfPackageCost = document.getElementById("<%= hfPackageCost.ClientID %>");
            var hfPackageDesc = document.getElementById("<%=hfPackageDesc.ClientID %>");
            var dvSelectedPackageAmt = document.getElementById("<%= dvSelectedPackageAmt.ClientID %>");
            var dvSelectedPackageDesc = document.getElementById("<%= dvSelectedPackageDesc.ClientID %>");
            dvSelectedPackageAmt.innerHTML = (formatAmount(hfPackageCost.value)).toFixed(2);
            dvSelectedPackageDesc.innerHTML = hfPackageDesc.value;

            var spIndicator = document.getElementById("spIndicator");
            spIndicator.style.visibility = "hidden";
            spIndicator.style.display = "none";

            var model = result;

            var dvCouponError = document.getElementById("dvCouponError");
            var hfCouponCode = document.getElementById("<%= hfCouponCode.ClientID %>");
            var CouponDiscount = formatAmount(model.DiscountApplied).toFixed(2);
            var dvTotalAmount = document.getElementById("<%= dvTotalAmount.ClientID %>");
            var txtCouponCode = document.getElementById("<%= txtCouponCode.ClientID %>");

            var dvTotalBill = document.getElementById("<%= dvTotalBill.ClientID %>");

            var dvCouponDesc = document.getElementById("dvCouponDesc");
            var dvCouponAmt = document.getElementById("<%= dvCouponAmt.ClientID %>");
            var hfTotalAmount = document.getElementById("<%= hfTotalAmount.ClientID %>");
            ///Reset every thing
            dvCouponDesc.innerHTML = "";

            hfCouponCode.value = " ";
            var previousCouponDisc = dvCouponAmt.innerHTML;
            dvCouponAmt.innerHTML = " ";
            var dvSelectedPackageAmt = document.getElementById("<%= dvSelectedPackageAmt.ClientID %>");
            dvTotalAmount.innerHTML = (parseFloat(formatAmount(dvSelectedPackageAmt.innerHTML))).toFixed(2);
            dvTotalBill.innerHTML = (parseFloat(dvTotalAmount.innerHTML)).toFixed(2);

            hfTotalAmount.value = dvCouponAmt.innerHTML;
            var dvCoupon = document.getElementById("dvCoupon");

            ////// If the Coupon return error
            if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
                alert(model.FeedbackMessage.Message);
                hfCouponCode.value = "";
                dvCoupon.style.display = 'none';
                SetSourceCodeDiscount(0);
                ShowHideSourceCodeAmountDiv(false);
                isSourceCodeApplied = false;
                return false;
            } //if coupon amount is 0.00
            else if (model.SourceCodeId > 0 && formatAmount(model.DiscountApplied).toFixed(2) == "0.00") {
                hfCouponCode.value = "";
                dvCoupon.style.display = 'none';
                SetSourceCodeDiscount(0);
                ShowHideSourceCodeAmountDiv(true);
                isSourceCodeApplied = true;
                return false;
            }

            dvCoupon.style.display = '';
            dvCouponError.innerHTML = "";
            var divErrortop = document.getElementById("<%= divErrortop.ClientID %>");
            divErrortop.style.display = 'none';

            hfCouponCode.value = model.SourceCode;   //txtCouponCode.value;

            dvCouponAmt.innerHTML = (parseFloat(formatAmount(CouponDiscount))).toFixed(2);

            dvTotalAmount.innerHTML = (parseFloat(formatAmount(dvSelectedPackageAmt.innerHTML)) - formatAmount(CouponDiscount)).toFixed(2);
            dvTotalBill.innerHTML = (parseFloat(dvTotalAmount.innerHTML)).toFixed(2);

            hfTotalAmount.value = dvCouponAmt.innerHTML;
            var hfTempTotalAmount = document.getElementById("<%=hfTempTotalAmount.ClientID %>");
            var hfCouponDesc = document.getElementById("<%=hfCouponDesc.ClientID %>");
            hfTempTotalAmount.value = dvTotalBill.innerHTML;
            hfCouponDesc.value = dvCouponDesc.innerHTML;
            SetSourceCodeDiscount((parseFloat(formatAmount(CouponDiscount))).toFixed(2));
            ShowHideSourceCodeAmountDiv(true);
            isSourceCodeApplied = true;
            if (hfTempTotalAmount.value == "0.00") {

            }
            return false;
        }

        function MaintainAfterFailedPostBack() {
            //for maintaing state after postback made for applying coupon
            var hfPackageCost = document.getElementById("<%= this.hfPackageCost.ClientID %>");
            var hfPackageDesc = document.getElementById("<%=this.hfPackageDesc.ClientID %>");
            var dvSelectedPackageAmt = document.getElementById("<%= this.dvSelectedPackageAmt.ClientID %>");
            var dvSelectedPackageDesc = document.getElementById("<%= this.dvSelectedPackageDesc.ClientID %>");
            dvSelectedPackageAmt.innerHTML = (formatAmount(hfPackageCost.value)).toFixed(2);
            dvSelectedPackageDesc.innerHTML = hfPackageDesc.value;
        }

        function enableTestAndPackageSelection() {
            if ($('input[id*="SingleTestOverrideYes"]').is(":checked")) {
                singleTestOverride = '<%=Boolean.TrueString %>';

                $("#ViewPackagesTestsDiv input[type='radio'], #ViewPackagesTestsDiv input[type='checkbox']").removeAttr("disabled");
                $("#ViewPackagesTemplateDiv").find("input[type='radio']").click(function () {
                    SelectPackageRadioClick(this);
                });

                $("#ViewSelectedPackageAndTests").find("input[type='checkbox']").removeAttr("disabled");

                $("#ViewSelectedPackageAndTests #RemoveSelectedButton").show();

            } else {
                singleTestOverride = '<%=Boolean.FalseString %>';

                var prequalifiedTestIds = GetDataArrayFromString(preQualifiedTest);

                if (allowPrequalifiedTestOnly == '<%=Boolean.TrueString %>' || (prequalifiedTestIds != null && prequalifiedTestIds.length > 0) || preApprovedPackage == '<%= Boolean.TrueString %>') {

                    packageId = preApprovedPackageId;
                    currentPackageId = preApprovedPackageId;

                    packageTests = preApprovedPackageTestIds;
                    currentPackageTestIds = preApprovedPackageTestArray;

                    addOnTests = preApprovedIndependentTestIds;
                    currentAddOnTestIds = GetDataArrayFromString(preApprovedIndependentTestIds);

                    currentSelectedTestIds = new Array();

                    GetPackagesAndTestsForEventByRole(eventId, roleId, currentPackageId, currentPackageTestIds, currentAddOnTestIds, true);
                }
            }
        }
    </script>

    <style type="text/css">
        /*---------- bubble tooltip -----------*/ a.tt {
            position: relative;
            z-index: 24;
            color: #287AA8;
            font-weight: normal;
            text-decoration: none;
        }

            a.tt span {
                display: none;
            }
            /*background:; ie hack, something must be changed in a for ie to execute it*/ a.tt:hover {
                z-index: 25;
                color: #ff6600;
                text-decoration: none;
            }

                a.tt:hover span.tooltip {
                    display: block;
                    position: absolute;
                    top: 0px;
                    left: 0;
                    padding: 15px 0 0 0;
                    width: 200px;
                    color: #287AA8;
                    text-align: left;
                    filter: alpha(opacity:90);
                    khtmlopacity: 0.90;
                    mozopacity: 0.90;
                    opacity: 0.90;
                    text-decoration: none;
                }

                a.tt:hover span.top {
                    display: block;
                    padding: 30px 8px 0;
                    background: url(/App/Images/bubble.gif) no-repeat top;
                    text-decoration: none;
                }

                a.tt:hover span.middle {
                    /* different middle bg for stretch */
                    display: block;
                    padding: 0 8px;
                    background: url(/App/Images/bubble_filler.gif) repeat bottom;
                    color: #000;
                    text-decoration: none;
                }

                a.tt:hover span.bottom {
                    display: block;
                    padding: 3px 8px 10px;
                    color: #ff6600;
                    background: url(/App/Images/bubble.gif) no-repeat bottom;
                    text-decoration: none;
                }

        .greybox_anp {
            float: left;
            width: 500px;
            padding: 10px;
            background-color: #fff;
            border: solid 2px #ccc;
        }

            .greybox_anp .row {
                float: left;
                width: 494px;
                font-weight: bold;
            }

        .inputfield110px_anp {
            float: left;
            width: 110px;
            font: bold 12px arial;
            color: #000;
        }
    </style>
    <style type="text/css">
        .wrapper_pop {
            float: left;
            width: 502px;
            padding: 10px;
            background-color: #f5f5f5;
        }

        .wrapperin_pop {
            float: left;
            width: 478px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }

        .innermain_pop {
            float: left;
            width: 458px;
            padding: 0px 5px 0px 5px;
        }

        .innermain_1_pop {
            float: left;
            width: 463px;
            padding-top: 5px;
        }
    </style>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" />
                    </p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Technician Register Customer</span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
                33333
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innercon">
                        <span>
                            <img src="/App/Images/specer.gif" width="740px" height="5px" /></span>
                        <div class="regcust_innerrow">
                            <div class="pgnosymbol_regcust">
                                <img src="/App/Images/CCRep/page4symbol.gif" id="imgSymbol" runat="server" />
                            </div>
                            <div class="middivrow_regcust" style="width: 690px;">
                                <p class="contentrow_regcust" style="visibility: hidden; display: none;">
                                    <span class="orngheadtxt_regcust">Register New Customer</span>
                                </p>
                                <p class="fline_regcust" style="visibility: hidden; display: none;">
                                    <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" />
                                </p>
                                <p class="contentrow_regcust">
                                    <span class="orngbold16_default">Place Order</span>
                                </p>
                                <div class="contentrow_regcust" style="width: 690px">
                                    <Order:ItemCart ID="ItemCartControl" runat="server" />
                                    <div class="sourcecode" id="SourceCodeApplyDiv">
                                        <asp:Panel ID="PnlApplySourceCode" runat="server" DefaultButton="imgCouponApply">
                                            <span id="spnSourceCodeMessage" runat="server"><b>Enter Source Code:</b></span>
                                            <span style="padding-left: 10px;">
                                                <asp:TextBox ID="txtCouponCode" runat="server" CssClass="inputfield_ccrep" Width="95px"></asp:TextBox></span>
                                            <span class="button_con_nowidth" style="margin: 5px 10px 0px 0px; float: right;">
                                                <asp:ImageButton ID="imgCouponApply" runat="server" ImageUrl="~/App/Images/apply-btn.gif"
                                                    OnClientClick="return CouponValidation();"></asp:ImageButton>
                                            </span>
                                        </asp:Panel>
                                        <span id="spnSourcecodeNotes" runat="server" style="float: left; display: none; margin-top: 3px;"><a href="javascript:void(0);" class="tt" runat="server" id="ahrefToolTipIsPaid">
                                            <b>Notes</b> <span class="tooltip"><span class="top"></span><span class="middle"
                                                id="spndefcursor" onmouseover="changetodefault('spndefcursor');" onmouseout="changetopointer('spndefcursor');">Source code is not applicable for this private event. </span>
                                                <span class="bottom"></span></span></a></span>
                                        <span id="spIndicator" style="visibility: hidden; display: none;">
                                            <img id="imgIdicator" src="/App/Images/indicator.gif" />
                                        </span>
                                    </div>
                                </div>
                                <div id="BillingInformationDiv" style="display: none">
                                    <p class="fline_regcust" style="visibility: hidden; display: none">
                                        <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" />
                                    </p>
                                    <p class="contentrow_regcust">
                                        <span class="orngbold12_default">Billing Information</span>
                                    </p>
                                    <p class="fline_regcust" style="width: 420px;">
                                        <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" />
                                    </p>
                                    <p class="normaltxt_regcust" style="width: 420px;">
                                        Your Total Billing amout is <strong>$<span runat="server" id="dvTotalAmount">0.00</span></strong>.
                                    </p>
                                    <div class="dgselectpackage_ccrep" style="width: 420px;">
                                        <table class="gridbillinfo" cellspacing="0" border="0" id="dgBill" style="border-collapse: collapse;">
                                            <tr class="row1">
                                                <td style="width: 300px">Name/Description
                                                </td>
                                                <td style="width: 50px">Quantity
                                                </td>
                                                <td style="width: 61px" align="right">Amount
                                                </td>
                                            </tr>
                                            <tr class="row2" id="dvSelectedPackage">
                                                <td id="dvSelectedPackageDesc" runat="server" style="width: 300px">Please select Package
                                                </td>
                                                <td style="width: 50px">01
                                                </td>
                                                <td align="right" style="width: 61px;">
                                                    <span style="width: 25px; text-align: left;">$</span> <span id="dvSelectedPackageAmt"
                                                        runat="server">0.00</span>
                                                </td>
                                            </tr>
                                            <tr id="dvCoupon" style="display: none" class="row2">
                                                <td id="dvCouponDesc" style="width: 300px">&nbsp;
                                                </td>
                                                <td style="width: 50px">01
                                                </td>
                                                <td align="right" style="width: 61px;">
                                                    <span style="width: 25px; text-align: left;">(-)$</span> <span id="dvCouponAmt" runat="server">0.00</span>
                                                </td>
                                            </tr>
                                            <tr class="footer">
                                                <td style="width: 300px">Total
                                                </td>
                                                <td style="width: 50px"></td>
                                                <td align="right" style="width: 70px">
                                                    <span>$</span> <span id="dvTotalBill" runat="server">0.00</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <img src="/App/Images/CCRep/specer.gif" width="1px" height="20px" />
                                    </div>
                                    <div id="divErrortop" runat="server" style="display: none; width: 420px; float: left;">
                                        <p class="topbg_ccreperrormsg">
                                        </p>
                                        <div class="midbg_ccreperrormsg">
                                            <span style="float: left; width: 20px; padding: 0px 10px 0px 10px">
                                                <img src="/App/Images/error-icon.gif" alt="" /></span> <span id="dvCouponError" class="txt_errormsgyellow"></span>
                                        </div>
                                        <p class="botbg_ccreperrormsg">
                                        </p>
                                    </div>
                                    <p class="fline_regcust" style="width: 420px;">
                                        <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" />
                                    </p>
                                </div>
                                <div class="fline_regcust">
                                </div>
                                <div class="wrapper_sd">
                                    <div style="float: left; width: 80%;">
                                        <span class="left blutxt_sd" style="font: normal 12px Arial; padding-top: 5px;">Override package/test selection?</span>
                                        <span>
                                            <asp:RadioButton ID="SingleTestOverrideYes" runat="server" Text="Yes" GroupName="SingleTestOverride" onClick="javascript:enableTestAndPackageSelection();" Style="font: normal 12px Arial;" />
                                            <asp:RadioButton ID="SingleTestOverrideNo" runat="server" Text="No" GroupName="SingleTestOverride" onClick="javascript:enableTestAndPackageSelection();" Style="font: normal 12px Arial;" />
                                        </span>
                                    </div>
                                </div>
                                <div class="fline_regcust">
                                </div>
                                <div class="wrapper_sd">
                                    <div style="float: left; width: 80%;">
                                        <span class="left blutxt_sd" style="font: normal 12px Arial; padding-top: 5px;">Is this screening a Retest?</span>
                                        <span>
                                            <asp:RadioButton ID="RetestYes" runat="server" Text="Yes" GroupName="Retest" Style="font: normal 12px Arial;" />
                                            <asp:RadioButton ID="RetestNo" runat="server" Text="No" GroupName="Retest" Style="font: normal 12px Arial;" />
                                        </span>
                                    </div>
                                </div>
                                <div class="fline_regcust"></div>

                                <div>
                                    <p class="buttoncell_ccrep">
                                        <span class="buttoncon_ccrep">
                                            <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-button.gif"
                                                OnClick="ibtnBack_Click" /></span> <span class="buttoncon_ccrep">
                                                    <asp:ImageButton ID="ibtnSubmit" runat="server" ImageUrl="~/App/Images/next-buton.gif"
                                                        OnClientClick="return NextButtonClick();" />
                                                </span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="PackageIdHiddenControl" runat="server" />
    <asp:HiddenField ID="TestIdsHiddenControl" runat="server" />
    <asp:HiddenField ID="IndependentTestIdsHiddenControl" runat="server" />
    <asp:HiddenField ID="hfEventID" runat="server" />
    <asp:HiddenField ID="hfCouponCode" runat="server" />
    <asp:HiddenField ID="hfTotalAmount" runat="server" />
    <asp:HiddenField runat="server" ID="HiddenField1" />
    <asp:HiddenField ID="hfOnsitePayment" runat="server" Value="0" />
    <asp:HiddenField ID="hfBillingAddress" runat="server" Value="1" />
    <asp:HiddenField ID="hfTempTotalAmount" runat="server" />
    <asp:HiddenField ID="hfTempNetAmount" runat="server" />
    <asp:HiddenField ID="hfCouponDesc" runat="server" />
    <asp:HiddenField ID="hfEmailRprt" runat="server" Value="0" />
    <asp:HiddenField ID="hfPackageCost" runat="server" />
    <asp:HiddenField ID="hfPackageDesc" runat="server" />
    <asp:HiddenField ID="hfHaveSlots" runat="server" Value="1" />
    <asp:HiddenField ID="hfSelectedPackageRadio" runat="server" Value="" />

    <asp:HiddenField ID="hfQuestionAnsTestId" runat="server" />
    <asp:HiddenField ID="hfDisqualifedTest" runat="server" />

    <div class="saveWaitAnimationnew" style="display: none">
    </div>
    <div id="div_preQualificationQuestion" title="Pre Qualification Test Questions" style="display: none; background: #fff; padding: 10px">
    </div>


    <script src="/Content/JavaScript/PreQualifiedQuestionRules.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>
    <script type="text/javascript">
        var questionAnsTestId = "";
        function IsPrequalificationQuestions(isSelectPackageRadioClick) {

            var templateIds = new Array();

            var pkgTestIds = '';

            var testIds = $("#IndependentTestIdsHiddenControl").val();
            $('*[id*=PackageTestIdHidden]').each(function () {

                if (pkgTestIds != "" && $(this).val() != 'undefined') {
                    pkgTestIds += "," + $(this).val()
                }
                else if ($(this).val() != 'undefined') {
                    pkgTestIds = $(this).val()
                }
            });

            if (testIds != "" && pkgTestIds != "") {
                testIds += "," + pkgTestIds
            }
            testIds = testIds.replace(',undefined', '');

            $(_prequalificationTemplateIdandTestId).each(function (index, item) {
                if (testIds.indexOf(item[1]) >= 0) {
                    templateIds.push(item[0]);
                }
            });
            if ((templateIds.length > 0 && prefilledQuestions == "") || (templateIds.length > 0 && isSelectPackageRadioClick)) {

                GetPreQualificationQuestion(templateIds);
            }
        }

        function GetPreQualificationQuestionsforSingleTest(testId) {
            var templateIds = new Array();
            $(_prequalificationTemplateIdandTestId).each(function (index, item) {
                if (testId == item[1]) {
                    templateIds.push(item[0]);
                }
            });


            if (templateIds.length > 0) {
                GetPreQualificationQuestion(templateIds);
            }
        }

        function GetPreQualificationQuestion(templateIds) {
            $(".saveWaitAnimationnew").show();
            $.ajax({
                url: '/CallCenter/CallQueue/GetPreQualificationQuestion',
                type: 'POST',
                cache: false,
                data: { templateIds: templateIds },
                traditional: true,
            }).done(function (result) {
                $('#div_preQualificationQuestion').html(result);

                prefilledQuestions = $("#<%= hfQuestionAnsTestId.ClientID %>").val();
                AnswerFilled(prefilledQuestions);
                $('#div_preQualificationQuestion').dialog('open');
                $(".saveWaitAnimationnew").hide();
            });
        }


      
        var resultObject;
        var disqualifiedTest = '';
        var isMammoQualified = false;

        $(document).ready(function () {

            isMammoQualified = IsCustomerMammoQualified('<%= CustomerId %>');

            $('#div_preQualificationQuestion').dialog({
                autoOpen: false, modal: true, width: 700, height: 300, top: 600, closeOnEscape: false, open: function (event, ui) {
                    $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
                }, buttons: {
                    'Save': function () {

                        resultObject = CommonFunctionOfDisqualified();

                        if (resultObject.isComplete == false) {
                            alert("You have to attempt all Questions.");
                            return;
                        }
                        if (resultObject.isComplete) {
                            SaveDisqualifedTest();
                            prefilledQuestions = $('#<%= hfQuestionAnsTestId.ClientID %>').val();
                        }
                    }
                }
            });

        });

        function SaveDisqualifedTest() {
            $('#<%= hfQuestionAnsTestId.ClientID %>').val(resultObject.answerStr);

            var disqualifedTest = CheckIsEligibleForTest(resultObject.answerStr);
            $('#<%= hfDisqualifedTest.ClientID %>').val(disqualifedTest);

            var testId;
            if (disqualifedTest != null && disqualifedTest != '') {
                $(disqualifedTest.split('|')).each(function (index, item) {
                    testId = item.split(',')[0];
                });
            }

            var model = {
                CustomerId: '<%= CustomerId %>',
                                EventId: '<%= EventId %>',
                                QuestionAnswerTestIds: resultObject.answerStr,
                                DisqualifiedTests: disqualifedTest
                            };
                            if (disqualifedTest == "")
                                isMammoQualified = true;
                            else
                                isMammoQualified = false;
                            $.ajax({
                                url: '/CallCenter/CallQueue/SavePreQualificationAnswers',
                                type: 'POST',
                                cache: false,
                                data: JSON.stringify(model),
                                traditional: true,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                            }).done(function () {
                                if (testId != null && testId != '') {
                                    $.ajax({
                                        url: "/CallCenter/CallQueue/GetDependentTestsToRemove?eventId=" + eventId + "&testId=" + testId,
                                        type: "GET",
                                        contentType: "application/json; charset=utf-8",
                                        success: function (result) {
                                            if (result != null && result != '') {
                                                RemoveSingleTest(testId, result);
                                                questionAnsTestId = '';
                                                $('#div_preQualificationQuestion').dialog('close');

                                                if (disqualifedTest != '') {
                                                    alert("You are not eligible for " + $(".testName").html() + ".");
                                                }
                                            } else {
                                                RemoveSingleTest(testId, '');
                                                questionAnsTestId = '';
                                                $('#div_preQualificationQuestion').dialog('close');

                                                if (disqualifedTest != '') {
                                                    alert("You are not eligible for " + $(".testName").html() + ".");
                                                }
                                            }
                                        }
                                    });
                                } else {
                                    resultObject.answerStr = '';
                                    $('#div_preQualificationQuestion').dialog('close');
                                }
                            });
                        }
                        function ResetAnswerIfQuestionRemoved(removedTestId) {

                            if (prefilledQuestions != "" && prefilledQuestions.indexOf(removedTestId) > 0) {
                                prefilledQuestions = "";
                                disQualifiedQuestionandAnswer = "";
                                $('#<%= hfDisqualifedTest.ClientID %>').val("");
                $('#<%= hfQuestionAnsTestId.ClientID %>').val("");
            }
        }

    </script>
    <style type="text/css">
        .saveWaitAnimationnew {
            background-image: url('/Content/Images/loading_Big_orng.gif');
            background-repeat: no-repeat;
            position: fixed;
            top: 0px;
            right: 0px;
            width: 100%;
            height: 100%;
            background-color: #000;
            background-position: center;
            z-index: 10000000;
            opacity: 0.4;
            filter: alpha(opacity=40);
        }

        #jSuggestContainer ul {
            width: 250px;
            max-height: 300px;
            overflow-y: scroll;
            overflow-x: hidden;
        }
    </style>


</asp:Content>

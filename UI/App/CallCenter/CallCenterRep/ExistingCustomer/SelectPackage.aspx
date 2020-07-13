<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    Title="Select Package and Test" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer.SelectPackage"
    CodeBehind="SelectPackage.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/App/UCCommon/OrderItemCart.ascx" TagName="ItemCart" TagPrefix="Order" %>
<%@ Register Src="~/App/UCCommon/PreQualificationQuestion.ascx" TagName="PreQualificationQuestion" TagPrefix="PreQualification" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Content/colorbox/colorbox.css" rel="stylesheet" />
    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>
    <script type="text/javascript" src="/Content/colorbox/jquery.colorbox.js"></script>
    <script src="/Content/JavaScript/PreQualificationQuestion.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        var isSourceCodeApplied = false;

        var prefilledQuestions = '<%=QuestionIdAnswerTestId %>';
        var disQualifiedQuestionandAnswer = '<%=DisqualifiedTest %>';

        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        function requestFailed()
        { }

        function SetSourceCode(sourceCode) {
            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
            txtCouponCode.val(sourceCode);
        }
        var isClinicalQuestionairFilled = false;

        if ('<%= IsClinicalQuestionaireFilled %>' == '<%=Boolean.TrueString %>') {
            isClinicalQuestionairFilled = true;

        }
        var fillClinicialQuestionnaireDiv = false;
        if ('<%= FillClinicialQuestionnaireDiv.Visible%>' == '<%=Boolean.TrueString %>') {
            fillClinicialQuestionnaireDiv = true;
        }

        function NextButtonClick() {

            if (fillClinicialQuestionnaireDiv && isClinicalQuestionairFilled == false) {
                var result = confirm("Clinical Questionnaire has not been filled. Do you want continue?");
                if (result) {
                    PlaceOrderClick(Validation);
                }

            } else {
                PlaceOrderClick(Validation);
            }

            return false;
        }



        function SelectPackage() {

            // Set the shopping cart data from the control on the page....
            $('#<%= PackageIdHiddenControl.ClientID %>').val($('#PackageIdHiddenControl').val());
		    $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val($('#IndependentTestIdsHiddenControl').val());
		    $('#<%=TestIdsHiddenControl.ClientID %>').val($('#TestIdsHiddenControl').val());

		    $('#<%= hfPackageCost.ClientID %>').val($('#OfferPriceSpan').text());

		    $('#<%= hfPackageDesc.ClientID %>').val($('#PackageDescriptionHidden').val());

		    var packageAndTestCost = parseFloat($('#OfferPriceSpan').text());

		    $('#<%= hfTotalAmount.ClientID %>').val((packageAndTestCost).toFixed(2));

		    //Since the package is changed cancel the previous applied coupon....							

		    var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
		    if ($.trim(txtCouponCode.val()).length > 0 && $('#IsFreshLoadOfControlHiddenControl').val() == 'false' && isSourceCodeApplied)
		        CouponValidation();
		    return true;
		}

		function fnToggle() {
		    oTransContainer.filters[0].Apply();
		    oTransContainer.filters[0].Play();
		}

		function Validation() {
		    //debugger;
		    var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
		    var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

		    if (packageId == '0' && testIds == '0') {
		        if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
		            alert("Please select a Package or tests.");
		        else
		            alert("Please select a Package.");
		        return false;
		    }

            if (parseFloat($('#OfferPriceSpan').text()) < parseFloat('<%=MinimumPurchaseAmount %>')) {
		        alert('The minimum price of the order should be ' + '<%=MinimumPurchaseAmount %>');
                return false;
            }
            __doPostBack('NextButton', 'Click');
        }




        function CancelClick() {
            return confirm("Are you sure you want to cancel.");
        }

        function formatAmount(num) {
            if (isNaN(parseFloat(num))) {
                num = '0.00';
            }
            return parseFloat(num);
            try {
                num = num.replace(/^\s+|\s+$/g, "");
            }
            catch (err) {
                num = num;
            }
            num = parseFloat(num);
            if (isNaN(num)) {
                num = '0.00';
            }
            return parseFloat(num.toFixed(2));
        }

        function CallEnd() {
            postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
        }

        function CouponValidation() {
            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
            if (txtCouponCode.val() == '') {
                alert('Please enter source code.');
                return false;
            }
            var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
            var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

            if (packageId == '0' && testIds == '0') {
                if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
                    alert("Please select at least one package or a test to avail the coupon.");
                else
                    alert("Please select at least one package to avail the coupon.");
                return false;
            }

            var hfCouponApplied = document.getElementById("<%= hfCouponApplied.ClientID %>");
            hfCouponApplied.Value = "1";

            var spIndicator = document.getElementById("spIndicator");
            spIndicator.style.visibility = "visible";
            spIndicator.style.display = "block";

            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
            var dvSelectedPackageAmt = $('#OfferPriceSpan');
            var hfEventID = $("#<%= hfEventID.ClientID %>");

            var parameter = "{'packageId':'" + $.trim(packageId) + "'";
            parameter += ",'addOnTestIds':'" + $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val() + "'";
		    parameter += ",'orderTotal':'" + dvSelectedPackageAmt.text() + "'";
		    parameter += ",'couponCode':'" + txtCouponCode.val() + "'";
		    parameter += ",'eventId':'" + hfEventID.val() + "'";
		    parameter += ",'customerId':'<%= CustomerId %>'}";
			var messageUrl = '<%=ResolveUrl("~/App/CallCenter/CallCenterRep/ExistingCustomer/SelectPackage.aspx/GetCoupon")%>';
            var successFunction = function (result) {
                ApplyCouponAmount(result.d);
            };
            var errorFunction = function () { alert('There was a problem retrieving the data, please try again later.'); }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
            return false;
        }

        function ApplyCouponAmount(result) {

            //for maintaing state after postback made for applying coupon
            var hfPackageCost = document.getElementById("<%= hfPackageCost.ClientID %>");
            var hfPackageDesc = document.getElementById("<%=hfPackageDesc.ClientID %>");

            var spIndicator = document.getElementById("spIndicator");
            spIndicator.style.visibility = "hidden";
            spIndicator.style.display = "none";

            var model = result;

            var hfCouponCode = document.getElementById("<%= hfCouponCode.ClientID %>");
            var CouponDiscount = formatAmount(model.DiscountApplied).toFixed(2);

            var txtCouponCode = document.getElementById("<%= txtCouponCode.ClientID %>");

		    var hfTotalAmount = document.getElementById("<%= hfTotalAmount.ClientID %>");

            hfCouponCode.value = " ";

            ////// If the Coupon return error
            if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
                alert(model.FeedbackMessage.Message);
                hfCouponCode.value = "";
                SetSourceCodeDiscount(0);
                ShowHideSourceCodeAmountDiv(false);
                isSourceCodeApplied = false;
                return false;
            } //if coupon amount is 0.00
            else if (model.SourceCodeId > 0 && formatAmount(model.DiscountApplied).toFixed(2) == "0.00") {
                hfCouponCode.value = "";
                SetSourceCodeDiscount(0);
                ShowHideSourceCodeAmountDiv(true);
                isSourceCodeApplied = true;
                return false;
            }

            hfCouponCode.value = model.SourceCode;   //txtCouponCode.value;

            hfTotalAmount.value = (parseFloat(formatAmount(CouponDiscount))).toFixed(2);
            SetSourceCodeDiscount((parseFloat(formatAmount(CouponDiscount))).toFixed(2));
            ShowHideSourceCodeAmountDiv(true);
            isSourceCodeApplied = true;

            return false;
        }

        function MaintainAfterFailedPostBack() {
            //for maintaing state after postback made for applying coupon
            var hfPackageCost = document.getElementById("<%= this.hfPackageCost.ClientID %>");
            var hfPackageDesc = document.getElementById("<%=this.hfPackageDesc.ClientID %>");

        }
        function ShowNextButton() {
            var spnNextButtonIndicator = document.getElementById("spnNextButtonIndicator");
            var SpanNextButton = document.getElementById("SpanNextButton");
            spnNextButtonIndicator.style.visibility = "hidden";
            spnNextButtonIndicator.style.display = "none";
            SpanNextButton.style.visibility = "visible";
            SpanNextButton.style.display = "block";
        }

        var winclinicalhistory = null;
        function ShowClinicalQuestion() {
            var customerId = '<%=CustomerId %>';
		    var eventId = '<%=EventId %>';
		    var guid = '<%=GuId %>';
		    var clinicalQuestionTemplateId = '<%=ClinicalQuestionTemplateId %>';
		    winclinicalhistory = window.open("/Medical/ClinicalQuestion/GetClinicalQuestion?guid=" + guid + "&customerId=" + customerId + "&eventId=" + eventId + "&clinicalQuestionTemplateId=" + clinicalQuestionTemplateId, "ClinicalQuestion", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=1100,height=500");
		    return false;
		}
		function closeClinicalQuestion() {
		    if (winclinicalhistory != null) {
		        winclinicalhistory.close();
		        GetRecommandation();
		    }

		}

		function GetRecommandation() {
		    var customerId = '<%=CustomerId %>';
		    var eventId = '<%=EventId %>';
		    var guid = '<%=GuId %>';
		    $.ajax({
		        url: '/Medical/ClinicalQuestion/GetRecommendations?guid=' + guid + "&customerId=" + customerId + "&eventId=" + eventId,
		        type: 'Get',
		        data: '{}',
		        contentType: "application/json; charset=utf-8",
		        dataType: 'json',
		        success: function (result) {
		            isClinicalQuestionairFilled = true;
		            if (result.Result.length <= 0) {
		                $(".recommended-test").html("<b>Recommended Tests: </b>None");
		                $(".disqualified-test").html('');
		                $(".disqualified-test").hide();
		            } else {
		                var testids = [];
		                var testNames = [];
		                var disqualifiedTest = [];
		                $.each(result.Result, function (index, obj) {

		                    if (obj.IsDisqualified == false) {
		                        testids.push(obj.TestId);
		                        testNames.push(obj.Name);
		                    } if (obj.IsDisqualified == true) {
		                        disqualifiedTest.push(obj.Name);
		                    }

		                });

		                UpdateOrderWithRecommendations(testids);
		                if (testNames.length > 0) {
		                    $(".recommended-test").html("<b>Recommended Tests: </b>" + testNames.join(","));
		                } else {
		                    $(".recommended-test").html("<b>Recommended Tests: </b>None");
		                }

		                if (disqualifiedTest.length > 0) {
		                    $(".disqualified-test").html("<b>Disqualified Tests: </b>" + disqualifiedTest.join(","));
		                    $(".disqualified-test").show();
		                } else {
		                    $(".disqualified-test").html('');
		                    $(".disqualified-test").hide();
		                }
		            }
		            $(".recommended-test").show();
		        },
		        error: function (a, b, c) {

		        }
		    });
		}

		function UpdateOrderWithRecommendations(testids) {
		    $.each(testids, function (index, value) {
		        var checkbox = $("input:hidden[id='TestIdHidden'][value='" + value + "']").parent().find("input:checkbox");
		        $(checkbox).attr("checked", "checked");
		        $(checkbox).click();
		        $(checkbox).attr("checked", "checked");
		    });
		}

		function addHraColorBox(url, visitId) {

		    $("#hraLink").colorbox({
		        iframe: true, width: "100%", height: "100%", href: url, onClosed: function () {
		            // location.reload();

		            if (visitId != undefined) {
		                $.ajax({
		                    url: '/CallCenter/CallQueue/UnlockMedicarePatient?visitId=' + visitId,
		                    type: 'GET',
		                    contentType: "application/json; charset=utf-8",
		                    dataType: 'json',
		                    success: function (result) {

		                    },
		                    error: function (a, b, c) {
		                        console.log('Patient Unlock failed in EHR');
		                    }
		                });
		            }
		        }
		    });
		}

		$(document).ready(function () {

			<% if (!string.IsNullOrWhiteSpace(HraQuestionerAppUrl))
      { %>
		    addHraColorBox('<%= HraQuestionerAppUrl %>');
		    //stop colorbox scroll
		    $(document).bind('cbox_open', function () {
		        $('body').css({ overflow: 'hidden' });
		    }).bind('cbox_closed', function () {
		        $('body').css({ overflow: '' });
		    });

		    <%  } %>

		    checkAndOpenScriptPopup();

		});

		window.addEventListener("message", function (event) {

		    if (event.data.Action == 'UpdateVisit') {
		        setVisitId(event.data.VisitId);
		    } else if (event.data.Action == 'ClosePopupWindow') {
		        $.colorbox.close();
		        //location.reload();
		    }
		}, false);

		function setVisitId(visitId) {
		    $.ajax({
		        url: '/CallCenter/CallQueue/UpdateCustomerVisitInfo?guid=' + guid + "&visitId=" + visitId,
		        type: 'POST',
		        data: '{}',
		        contentType: "application/json; charset=utf-8",
		        dataType: 'json',
		        success: function (result) {

		        },
		        error: function (a, b, c) {
		            console.log('VisitId update failed in EHR');
		        }
		    });

		    var url = '<%= HraQuestionerAppUrlWithoutVisit %>' + '&visitId=' + visitId;
		    addHraColorBox(url, visitId);

        };

        function enableTestAndPackageSelection() {
            //debugger;
            disqualifiedquestion = '';
            prefilledQuestions = '';
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

        .fill_clinical_questionaire {
            float: left;
            clear: both;
        }

        .head_link_regcust {
            color: #287aa8;
            font-size: 14px !important;
            text-decoration: underline;
        }

            .head_link_regcust:hover {
                color: #287aa8;
            }

            .head_link_regcust:visited {
                color: #287aa8;
            }

        .error {
            font-weight: bold;
            margin: 10px 5px;
            color: #D8000C;
            background-color: #FFBABA;
            padding: 10px 7px;
            background-repeat: no-repeat;
            background-position: 10px center;
            border: 1px solid;
        }
    </style>
    <div class="wrapper_inpg">
        <asp:HiddenField ID="PackageIdHiddenControl" runat="server" />
        <asp:HiddenField ID="TestIdsHiddenControl" runat="server" />
        <asp:HiddenField ID="IndependentTestIdsHiddenControl" runat="server" />
        <% if (!string.IsNullOrWhiteSpace(HraQuestionerAppUrl))
           { %>
        <div style="width: 100%; float: left; clear: both;"><a href="javascript:void(0)" class="hra-pop-link" id="hraLink" style="display: none;">HRA Questionnaire</a></div>
        <% } %>

        <% else if (!string.IsNullOrWhiteSpace(ChatQuestionerAppUrl))
           { %>
        <div style="width: 100%; float: left; clear: both;"><a href='<%=ChatQuestionerAppUrl %>">' target="_blank" class="hra-pop-link" id="chatLink" style="display: none;">CHAT Questionnaire</a></div>
        <% } %>



        <div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
        </div>
        <div id="disqulifiedTests" runat="server" class="left-float disqualified-test error" style="width: 50%; display: none; font-size: 13px; margin-bottom: 15px;">
        </div>
        <div id="recommended_test_text" runat="server" class="left-float recommended-test info-box" style="width: 50%; display: none; font-size: 13px; margin-bottom: 15px;">
        </div>
        <div class="left-float disclaimer-normal-message-header warning-message" style="width: 50%; display: none;">
        </div>
        <div class="rightdivrow_regcust" id="divCall" runat="server" style="float: right; width: 40%;">
            <div class="endcall_ccrep_dboard">
                <span class="endtbtn_ccrep_dboard">
                    <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                        OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                </span>

            </div>

            <div class="timeboard_ccrep_dboard">
                <div class="timeboxbg_ccrep_dboard">
                    <p class="tboxrow_ccrep_dboard">
                        <span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span
                            id="SS"></span></span>
                    </p>
                    <p class="tboxrowformat_ccrep_dboard">
                        <span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
                    </p>
                    <p class="tboxrowbtm_ccrep_dboard">
                        <span class="whttxt_ccrep_dboard">Call in Progress</span>
                    </p>
                </div>
            </div>
        </div>
        <div class="fill_clinical_questionaire" runat="server" id="FillClinicialQuestionnaireDiv">
            <a href="javascript:void(0)" onclick="ShowClinicalQuestion()">
                <span class="head_link_regcust"><b>FILL CLINICAL QUESTIONNAIRE</b></span>
            </a>
        </div>
        <div class="main_bdrccrep">
            <div class="maincontentrow_ccrep">
                <div class="regcust_innercon">
                    <div class="regcust_innerrow">
                        <div class="pgnosymbol_regcust">
                            <img src="/App/Images/CCRep/page3symbol.gif" alt="" />
                        </div>
                        <div class="middivrow_regcust" style="width: 690px;">
                            <p class="contentrow_regcust">
                                <span class="orngheadtxt_regcust" runat="server" id="StepTitleContainer">Existing Customer</span>
                            </p>
                            <div class="contentrow_regcust" style="width: 690px;">
                                <Order:ItemCart ID="ItemCartControl" runat="server" />
                                <div class="sourcecode" id="SourceCodeApplyDiv">
                                    <asp:Panel DefaultButton="imgCouponApply" ID="SourceCodePanel" runat="server">
                                        <span id="spnSourceCodeMessage" runat="server"><b>Enter Source Code:</b></span> <span style="margin-left: 10px;">
                                            <asp:TextBox ID="txtCouponCode" runat="server" CssClass="inputfield_ccrep" Width="95px"></asp:TextBox>
                                        </span><span class="button_con_nowidth" style="margin: 5px 10px 0px 0px; float: right;">
                                            <asp:ImageButton ID="imgCouponApply" runat="server" ImageUrl="~/App/Images/apply-btn.gif"
                                                OnClientClick="return CouponValidation();"></asp:ImageButton>
                                        </span><span id="spnSourcecodeNotes" runat="server" style="float: left; display: none; margin-top: 3px;"><a href="javascript:void(0);" class="tt" runat="server" id="ahrefToolTipIsPaid">
                                            <b>Notes</b> <span class="tooltip"><span class="top"></span><span class="middle"
                                                id="spndefcursor" onmouseover="changetodefault('spndefcursor');" onmouseout="changetopointer('spndefcursor');">Source code is not applicable for this private event. </span><span class="bottom"></span></span></a></span><span id="spIndicator" style="visibility: hidden; display: none;">
                                                    <img id="imgIdicator" src="/App/images/indicator.gif" />
                                                </span>
                                    </asp:Panel>
                                </div>
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
                                            OnClick="ibtnBack_Click" />
                                    </span>
                                    <span class="buttoncon_ccrep" style="visibility: hidden; display: none;" id="spnNextButtonIndicator">
                                        <img src="/App/Images/indicator.gif" />
                                    </span>
                                    <span class="buttoncon_ccrep" style="visibility: visible; display: block;" id="SpanNextButton">
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
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <PreQualification:PreQualificationQuestion ID="PreQualificationQuestion1" runat="server" />
    <script language="javascript" type="text/javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>

    <asp:HiddenField ID="hfEventID" runat="server" />
    <asp:HiddenField ID="hfCouponCode" runat="server" />
    <asp:HiddenField ID="hfTotalAmount" runat="server" />
    <asp:HiddenField runat="server" ID="HiddenField1" />
    <asp:HiddenField ID="hfOnsitePayment" runat="server" Value="0" />
    <asp:HiddenField ID="hfBillingAddress" runat="server" Value="1" />
    <asp:HiddenField ID="hfCouponApplied" runat="server" Value="0" />
    <asp:HiddenField ID="hfTempTotalAmount" runat="server" />
    <asp:HiddenField ID="hfTempNetAmount" runat="server" />
    <asp:HiddenField ID="hfEmailRprt" runat="server" Value="0" />
    <asp:HiddenField ID="hfPackageCost" runat="server" />
    <asp:HiddenField ID="hfPackageDesc" runat="server" />
    <asp:HiddenField ID="hfQuestionAnsTestId" runat="server" />
    <asp:HiddenField ID="hfDisqualifedTest" runat="server" />

    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
			m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-957361-18', 'auto');
        ga('send', 'pageview');


    </script>



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
                autoOpen: false, modal: true, width: 550, height: 260, closeOnEscape: false, open: function (event, ui) {
                    $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
                }, buttons: {
                    'Save': function () {

                        resultObject = CommonFunctionOfDisqualified();

                        if (resultObject.isComplete == false) {
                            alert("You have to attempt all Questions.");
                            return;
                        }

                        if (resultObject.isComplete) {
                            SaveDisqualifedTest()
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
                                EventId: '<%= hfEventID.Value %>',
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

                            if (prefilledQuestions != "" && prefilledQuestions.indexOf(removedTestId) >= 0) {
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

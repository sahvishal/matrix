<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderItemCart.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.OrderItemCart" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_jQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" IncudeJQueryJTip="true" />
<style type="text/css">
    .loading {
        background: url(/App/Images/indicator_chartbox.gif) no-repeat;
        text-align: center;
        width: 100%;
        height: 150px;
    }

    .loading-div {
        float: left;
        width: 110px;
        background: #ffb10a;
        padding: 5px;
        z-index: 100;
        left: 50%;
        top: 250px;
        position: fixed;
    }

        .loading-div .left-text {
            float: left;
            padding-right: 5px;
            font: bold 14px arial;
            z-index: 100;
        }

    .line-height {
        float: left;
        width: 100%;
        display: block;
        height: 10px;
    }

    .selected-row {
        background: #e8f9ff;
    }

    a:link {
        color: #FF6600;
        text-decoration: none;
    }

    a:visited {
        color: #FF6600;
        text-decoration: none;
    }

    a:hover {
        color: #FF6600;
        text-decoration: none;
    }

    .ordersummary {
        font: 12px Arial;
    }

        .ordersummary .hd {
            padding-left: 8px;
            margin: 0px;
            background: url(/App/Images/shoppingcart_orngcorners.gif) no-repeat;
            height: 34px;
        }

            .ordersummary .hd div {
                padding: 0px 10px 0px 2px;
                margin: 0px;
                background: #e1eaf3 url(/App/Images/shoppingcart_orngcorners.gif) no-repeat right -36px;
                height: 34px;
                color: #F37C00;
                font: 13px Arial, Helvetica, sans-serif;
                font-weight: bold;
                line-height: 34px;
            }

        .ordersummary .discription {
            border: 1px solid #ccc;
            padding: 8px;
            background: #fff;
        }

    .packagesummary {
        margin-top: 10px;
    }

    .paymentsummary {
        margin-top: 10px;
        text-align: right;
    }

    .productname {
        width: 100px;
        float: left;
    }

    .rates {
        color: #F00;
        float: right;
        width: auto;
    }

    .topbtm_bdr {
        border-top: 1px dashed #ccc;
        border-bottom: 1px dashed #ccc;
        width: 100%;
        float: left;
        padding: 5px 0px;
        margin: 5px 0px;
    }

    .sourcecode_hd {
        font: 13px Arial, Helvetica, sans-serif;
        color: #F60;
        font-weight: bold;
    }

    .remove_button {
        margin: 0px;
        width: auto;
        padding: 3px 5px;
        background: #fe912a;
        color: #fff;
        font: 12px Verdana, Geneva, sans-serif;
        font-weight: bold;
        overflow: visible;
    }

    .MsoNormal_hd {
        font: 13px Arial, Helvetica, sans-serif;
        color: #F79646;
        font-weight: bold;
        margin-bottom: 10px;
    }

    .MsoNormal {
        font: 12px Arial, Helvetica, sans-serif;
        margin-bottom: 10px;
        text-align: justify;
    }

    .no-test-div {
        height: 235px;
        background: url(/App/Images/no-test-available.gif) no-repeat bottom center;
    }

    .no-package-div {
        height: 198px;
        background: url(/App/Images/no-packages-available.gif) no-repeat;
    }
</style>
<div id="LoadingDiv" class="loading-div" style="display: none">
    <span class="left-text">Please Wait...</span> <span class="left">
        <img src="/App/Images/loading.gif" alt="" /></span>
</div>
<div>

    <input type="hidden" id="PackageIdHiddenControl" />
    <input type="hidden" id="PackageDescriptionHidden" />
    <input type="hidden" id="PackageNameHidden" />
    <input type="hidden" id="IndependentTestsNameHidden" />
    <input type="hidden" id="TestIdsHiddenControl" />
    <input type="hidden" id="PackageTestIdsHiddenControl" />
    <input type="hidden" id="IndependentTestIdsHiddenControl" />
    <input type="hidden" id="OrderChangedHiddenControl" />
    <input type="hidden" id="IsFreshLoadOfControlHiddenControl" />
    <input type="hidden" id="PackageChangedHiddenControl" />
    <input type="hidden" id="CurrentSelectedTestIdsHiddenControl" />
</div>
<div id="AlertMessageDialogDiv" style="display: none" title="Alert!!!">
    <span class="graytxtnormal" id="AlertMessageSpan"></span>
</div>
<div id="RequiredAdditionalTestWarningDialogDiv" style="display: none" title="Required Additional Test Warning!!!">
    <span class="graytxtnormal" id="RequiredAdditionalTestWarningSpan"></span>
</div>
<div id="SavingsMessageDialogDiv" style="display: none; overflow: auto;" title="Your Savings">
    <table id="SavingsMessageTable">
    </table>
</div>
<div id="PackageDetailsDialogDiv" style="display: none; overflow: auto; height: 410px">
    <span class="graytxtnormal" id="PackageDetailsSpan"></span>
</div>
<div id="UpgradeOrderDialogDiv" style="display: none; overflow: auto;" title="May We Recommend!">
    <div id="UpgradeOrderTemplateDiv" style="height: 300px;">
    </div>
</div>
<div id="ViewPackagesTestsDiv" style="width: 420px; float: left; margin-right: 5px;">

    <div id="ViewPackagesDiv" class="pkgtst_bg" style="margin-bottom: 10px;">
        <div id="ViewPackagesTemplateDiv">
        </div>
    </div>
    <div style="clear: both">
    </div>
    <div style="width: 420px; float: left; min-height: 350px;" class="order-summary view-test">
        <div class="pkgtst_bg" style="margin-bottom: 10px;">
            <div id="ViewTestsTemplateDiv">
            </div>
        </div>
    </div>
    <div style="clear: both">
    </div>
    <div style="clear: both">
    </div>
    <div style="clear: both">
    </div>
</div>

<div class="ordersummary" style="float: left; width: 255px; margin-left: 5px; margin-top: 10px; font: 12px Arial;">

    <div class="hd">
        <div>
            My Order Summary
        </div>
    </div>

    <div class="discription">
        <div class="locationsummary">
            <div>
                <p style="margin: 0px 0px 0px 5px; font: 12px arial;">
                    <strong>My Screening Location</strong>
                </p>
                <div style="padding-left: 10px;">
                    <asp:Label ID="EventNameLabel" runat="server" /><br />
                    <asp:Label ID="EventAddressLabel" runat="server" />


                </div>
            </div>
            <div>
                <p style="margin: 10px 0px 0px 5px; font: 12px arial;">
                    <strong>My Screening Date</strong>
                </p>
                <div style="padding-left: 10px;">
                    <asp:Label ID="EventDateLabel" runat="server" /><br />
                </div>
            </div>
            <div id="SponsoredInfoDiv" runat="server" visible="false">
                <p style="margin: 10px 0px 0px 5px; font: 12px arial;">
                    <strong>Sponsored By</strong>
                </p>
                <div style="padding-left: 10px;">
                    <asp:Label ID="HospitalPartnerLabel" runat="server" /><br />
                </div>
            </div>
        </div>
        <div class="packagesummary">
            <p style="margin: 0px 0px 0px 5px; font: 12px arial;">
                <strong>My Screening Package</strong>
            </p>
            <div>
                <div id="ViewSelectedPackageAndTests" style="padding-left: 10px;">
                    No Items Selected.
                </div>
                <div class="both"></div>
            </div>
        </div>
        <div id="PackageSummaryDiv" style="display: none">
            <div class="paymentsummary">
                <div>
                    <label>
                        <strong>Retail Price :</strong></label>
                    <span style="color: #f39814;">$</span> <span id="RetailPriceSpan" style="color: #f39814;"></span>
                    <br />
                    <label>
                        <strong>You Saved :</strong></label>
                    <span style="color: #f39814;">$</span> <span id="SavingAmountSpan" style="color: #f39814;"></span>
                    <br />
                    <a id="SavingsDetailsAnchor" href="javascript:void(0);" onclick="javascript:ShowSavingsDetails();">
                        <b>(more info)</b></a>
                    <br />
                    <div id="SourceCodeAmountDiv" style="display: none">
                        <label>
                            <strong>Source Code Applied :</strong></label>
                        <span style="color: #f39814;">$</span> <span id="SourceCodeAmountSpan" style="color: #f39814;"></span>
                    </div>
                    <br />
                    <label>
                        <strong>Amount Due :</strong></label>
                    <strong><span style="color: #ff6600;">$</span> <span id="OfferPriceSpan" style="color: #ff6600;"></span></strong>
                </div>
            </div>
        </div>
        <div id="PackageUpgradeMessageDiv" style="background: #f37c00; border: 1px solid #ccc; padding: 5px; margin-top: 10px; display: none">
            <span id="PackageUpgradeMessageSpan"></span>
        </div>
        <div id="RecommendationMessageDiv" style="background: #f37c00; border: 1px solid #ccc; padding: 5px; margin-top: 10px; display: none">
            <span id="RecommendationMessageSpan"></span>
        </div>
    </div>
</div>

<br />

<script type="text/javascript" language="javascript">

    $.ajaxSetup({ cache: false });

    var eventId = '<%=EventId %>';
    var roleId = '<%=RoleId %>';
    var eventType = '<%=RegistrationMode %>';
    var packageId = '<%=PackageId %>';
    var packageTests = '<%=SelectedPackageTestIds %>';
    var addOnTests = '<%=SelectedIndependentTestIds %>';
    var preQualifiedTest = '<%=PrequalifedTestIds %>';
    var singleTestOverride = '<%=SingleTestOverride %>';
    var allowPrequalifiedTestOnly = '<%= AllowPrequalifiedTestOnly %>';
    var preApprovedPackage = '<%= PreApprovedPackage %>';

    var preApprovedPackageId = '<%= PreApprovedPackageId %>';
    var preApprovedPackageTestIds = '<%= PreApprovedPackageTestIds %>';
    var preApprovedIndependentTestIds = '<%= PreApprovedIndependentTestIds %>';

    <%--var requiredTestIds = '<%= RequiredTestIds %>';--%>

    var packages = null;
    var tests = null;
    var testDependencyData = null;
    var currentPackageId = 0;
    var currentPackageTestIds = new Array();
    var currentAddOnTestIds = new Array();
    var currentSelectedTestIds = new Array();

    var preApprovedPackageTestArray = new Array();

    $(function () {
        
        SetTestView(roleId);      
        $('#PackageIdHiddenControl').val(packageId);
        $('#PackageTestIdsHiddenControl').val(packageTests);
        $('#IndependentTestIdsHiddenControl').val(addOnTests);

        currentPackageId = packageId;
        currentPackageTestIds = GetDataArrayFromString(packageTests);
        currentAddOnTestIds = GetDataArrayFromString(addOnTests);

        preApprovedPackageTestArray = GetDataArrayFromString(preApprovedPackageTestIds);

        if (packageId == 0 && packageTests == '0' && addOnTests == '0') $('#IsFreshLoadOfControlHiddenControl').val(true);
        else $('#IsFreshLoadOfControlHiddenControl').val(false);

        AttachDialogBoxes();
        GetTestDependencyData();
       
        if (currentAddOnTestIds != null && currentAddOnTestIds.indexOf(disqualifiedTestId) > -1)
        {
            preQualificationPopShow = true;
        }
        else if (currentPackageTestIds != null && currentPackageTestIds.indexOf(disqualifiedTestId) > -1)
        {
            preQualificationPopShow = true;
        }
        else {
            preQualificationPopShow = false;
           
        }

        if (typeof(isPrefilledQuestionsShow) != "undefined" && !isPrefilledQuestionsShow) {
            preQualificationPopShow = false;
            //isAnswerGiven = true;
        }
        GetPackagesAndTestsForEventByRole(eventId, roleId, currentPackageId, currentPackageTestIds, currentAddOnTestIds, preQualificationPopShow);      
    });

</script>

<script type="text/javascript" language="javascript">

    function IsPackageChange(currentPackageId) {
        if (currentPackageId != parseInt(packageId)) return true;

        return false;
    }

    function IsCurrentSelctionOfOrderDifferentFromOriginal(currentPackageId, currentPackageTestIds, currentAddOnTestIds) {
        if (currentPackageId != parseInt(packageId)) return true;

        var packageTestIds = GetDataArrayFromString(packageTests);
        var addOnTestIds = GetDataArrayFromString(addOnTests);

        if (packageTestIds == null && addOnTestIds == null && currentPackageTestIds == null && currentAddOnTestIds == null && currentPackageId == 0 && parseInt(packageId) == 0) return false;

        if ((packageTestIds != null && packageTestIds.length > 0) && (currentPackageTestIds == null || currentPackageTestIds.length <= 0)) return true;

        if ((addOnTestIds != null && addOnTestIds.length > 0) && (currentAddOnTestIds == null || currentAddOnTestIds.length <= 0)) return true;

        if ((currentPackageTestIds != null && currentPackageTestIds.length > 0) && (packageTestIds == null || packageTestIds.length <= 0)) return true;

        if ((currentAddOnTestIds != null && currentAddOnTestIds.length > 0) && (addOnTestIds == null || addOnTestIds.length <= 0)) return true;

        if (packageTestIds != null && packageTestIds.length > 0)
            GetContainsFunction(packageTestIds);

        var isElementMissing = false;
        if (currentPackageTestIds != null && currentPackageTestIds.length > 0) {
            $.each(currentPackageTestIds, function () {
                if (!packageTestIds.contains(this)) isElementMissing = true;
            });
        }
        if (isElementMissing) return true;

        if (currentPackageTestIds != null && currentPackageTestIds.length > 0)
            GetContainsFunction(currentPackageTestIds);

        if (packageTestIds != null && packageTestIds.length > 0) {
            $.each(packageTestIds, function () {
                if (!currentPackageTestIds.contains(this)) isElementMissing = true;
            });
        }
        if (isElementMissing) return true;

        if (addOnTestIds != null && addOnTestIds.length > 0)
            GetContainsFunction(addOnTestIds);

        if (currentAddOnTestIds != null && currentAddOnTestIds.length > 0) {
            $.each(currentAddOnTestIds, function () {
                if (!addOnTestIds.contains(this)) isElementMissing = true;
            });
        }

        if (isElementMissing) return true;

        if (currentAddOnTestIds != null && currentAddOnTestIds.length > 0)
            GetContainsFunction(currentAddOnTestIds);

        if (addOnTestIds != null && addOnTestIds.length > 0) {
            $.each(addOnTestIds, function () {
                if (!currentAddOnTestIds.contains(this)) isElementMissing = true;
            });
        }

        if (isElementMissing) return true;

        return false;
    }

</script>

<script type="text/javascript" language="javascript">

    function AttachDialogBoxes() {
        $('#AlertMessageDialogDiv').dialog({ autoOpen: false, width: 310, closeOnEscape: true, buttons: { 'Close': function () { $(this).dialog('close'); } } });
        $('#RequiredAdditionalTestWarningDialogDiv').dialog({ autoOpen: false, width: 310, closeOnEscape: true, buttons: { 'Close': function () { $(this).dialog('close'); } } });
        $('#SavingsMessageDialogDiv').dialog({ autoOpen: false, width: 400, closeOnEscape: true, buttons: { 'Close': function () { $(this).dialog('close'); } } });
        $('#PackageDetailsDialogDiv').dialog({ autoOpen: false, width: 500, height: 400, closeOnEscape: true, buttons: { 'Close': function () { $(this).dialog('close'); } } });
        $('#UpgradeOrderDialogDiv').dialog({ autoOpen: false, hide: 'slide', width: 500, height: 450, modal: true, buttons: { 'No Thanks': function () { NoThanksForPackageClick(); } }, close: function () { UpdateOrderDialogClosing(); } });
    }

    function CloseAllDialogBoxes() {
        $('#RequiredAdditionalTestWarningDialogDiv').dialog('close');
        $('#AlertMessageDialogDiv').dialog('close');
        $('#PackageDetailsDialogDiv').dialog('close');
        $('#SavingsMessageDialogDiv').dialog('close');
        HidePackageUpgradeAndRecommendationMessages();
    }

    function ShowRecommendationMessage(recommendationMessage) {
        $('#RecommendationMessageSpan').html(recommendationMessage);
        $('#RecommendationMessageDiv').show();
    }

    function ShowPackageUpgradeMessage(packageUpgradeMessage) {
        $('#PackageUpgradeMessageSpan').html(packageUpgradeMessage);
        $('#PackageUpgradeMessageDiv').show();
    }

    function ShowAlertMessage(alertMessage) {
        $('#AlertMessageSpan').text(alertMessage);
        $('#AlertMessageDialogDiv').dialog('open');
    }

    function ShowRequiredAdditionalTestMessage(alertMessage) {
        $('#RequiredAdditionalTestWarningSpan').text(alertMessage);
        $('#RequiredAdditionalTestWarningDialogDiv').dialog('open');
    }

    function ShowSavingsDetails() {
        $('#SavingsMessageDialogDiv').dialog('open');
    }

    function HidePackageUpgradeAndRecommendationMessages() {
        $('#RecommendationMessageDiv').hide();
        $('#PackageUpgradeMessageDiv').hide();
    }

</script>

<script type="text/javascript" language="javascript">

    function SelectPackageRadioClick(currentRadioButton) {

        var tempPackage = null;
        $.each(packages, function () {
            if (this.Id == parseInt($(currentRadioButton).parent('td').find('#PackageId').val())) {
                tempPackage = this;
                return;
            }
        });

        if (!CheckPackageTestForAge(tempPackage.Tests)) {
            $(currentRadioButton).attr('checked', false);
            if (parseInt(currentPackageId) > 0) {
                var PackageIdHiddenControl = $(currentRadioButton).parents('table').find('#PackageId[value="' + currentPackageId + '"]');
                if (PackageIdHiddenControl != null) {

                    PackageIdHiddenControl.parent('td').find('#SelectPackageRadio').attr('checked', true);
                }
            }
            return;
        }

        $(currentRadioButton).attr('checked', true);
        $('#IsFreshLoadOfControlHiddenControl').val(false);
        var packageId = parseInt($(currentRadioButton).parent('td').find('#PackageId').val());

        currentPackageTestIds = ClearArray(currentPackageTestIds);
        currentAddOnTestIds = ClearArray(currentAddOnTestIds);

        $('.my-order-independent-test-select').find(':hidden').each(function () {
            currentAddOnTestIds.push(parseInt($(this).val()));
        });

        var prequalifiedTestIds = GetDataArrayFromString(preQualifiedTest);
        GetContainsFunction(currentAddOnTestIds);

        if (prequalifiedTestIds != null && prequalifiedTestIds.length > 0) {
            if (currentAddOnTestIds != null && currentAddOnTestIds.length > 0) {
                $.each(prequalifiedTestIds, function (item, index) {

                    if (!currentAddOnTestIds.contains(item)) {
                        currentAddOnTestIds.push(item);
                    }
                });
            } else {
                currentAddOnTestIds = prequalifiedTestIds;
            }
        }

        if ((currentAddOnTestIds.indexOf(disqualifiedTestId) > -1) && isAnswerGiven && !isMammoQualified) {
            currentAddOnTestIds = jQuery.grep(currentAddOnTestIds, function (value) {
                return (value != disqualifiedTestId && value != dependentTestId);
            });
        }

        currentPackageId = RecommendPackage(packages, packageId, currentPackageTestIds, currentAddOnTestIds);
        CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds);

        if (!isAnswerGiven) {
            IsPrequalificationQuestions(true);
            isAnswerGiven = true;
        }
        else if (currentPackageTestIds.contains(disqualifiedTestId)) {
            IsPrequalificationQuestions(true);
            isAnswerGiven = true;
        }
    }

    function UpgradePackageButtonClick(selectedPackageId) {
        var tempPackage = null;
        $.each(packages, function () {
            if (this.Id == selectedPackageId) {
                tempPackage = this;
                return;
            }
        });

        if (!CheckPackageTestForAge(tempPackage.Tests)) {
            return;
        }

        $('#IsFreshLoadOfControlHiddenControl').val(false);
        currentPackageId = parseInt(selectedPackageId);

        currentPackageTestIds = ClearArray(currentPackageTestIds);
        currentAddOnTestIds = ClearArray(currentAddOnTestIds);

        $('.my-order-independent-test-select').find(':hidden').each(function () {
            currentAddOnTestIds.push(parseInt($(this).val()));
        });

        CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds);

        if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>' && '<%= UpsellTest %>' == '<%= Boolean.TrueString %>')
            OpenUpsellAddOnTests(tests, currentAddOnTestIds);
        else
            $('#UpgradeOrderDialogDiv').dialog('close');

    }

    function PackageChangeMessage(packageId, currentPackageId) {
        if (packageId == currentPackageId) return;
        var previousPackage = null;
        var currentPackage = null;
        if (packages != null && packages.length > 0) {
            $.each(packages, function () {
                if (this.Id == packageId)
                    previousPackage = this;
                else if (this.Id == currentPackageId)
                    currentPackage = this;
            });
            if (previousPackage != null && currentPackage != null) {
                ShowPackageUpgradeMessage('We have changed your package from ' + previousPackage.Name + ' to ' + currentPackage.Name + '. This Package will save you $' + $('#SavingAmountSpan').text() + ' for the same set of test(s).');
            }
            else if (previousPackage == null && currentPackage != null) {
                ShowPackageUpgradeMessage('We have changed your package to ' + currentPackage.Name + '. This Package will save you $' + $('#SavingAmountSpan').text() + ' for the same set of test(s).');
            }
        }
    }


</script>

<script type="text/javascript" language="javascript">



    function SelectOrderRemoveItemsClick() {

        var isElementChecked = false;
        $('.select-table :checkbox').each(function () {
            if ($(this).is(':checked'))
                isElementChecked = true;
        });
        if (!isElementChecked) return;

        if (ValidateTestUnCheckedDependency()) {
            $('#IsFreshLoadOfControlHiddenControl').val(false);
            if ($('.my-order-package-select').find(':checkbox').is(':checked'))
                currentPackageId = 0;

            currentPackageTestIds = ClearArray(currentPackageTestIds);
            currentAddOnTestIds = ClearArray(currentAddOnTestIds);
            var removeTestIds = new Array();
            $('.my-order-package-test-select').find(':checkbox').each(function () {
                if ($(this).is(':checked')) {
                    currentPackageId = 0;
                    var rtestId = $(this).parent('td').find(':hidden').val();
                    removeTestIds.push(parseInt(rtestId))
                }
                else if (!$(this).is(':checked')) {
                    var testId = $(this).parent('td').find(':hidden').val();
                    currentPackageTestIds.push(parseInt(testId));
                }
            });

            if (currentPackageId == 0 && currentPackageTestIds != null && currentPackageTestIds.length > 0) {
                $.each(currentPackageTestIds, function () {
                    currentAddOnTestIds.push(this);
                });
                currentPackageTestIds = ClearArray(currentPackageTestIds);
            }

            $('.my-order-independent-test-select').find(':checkbox').each(function () {
                if (!$(this).is(':checked')) {
                    var testId = $(this).parent('td').find(':hidden').val();
                    currentAddOnTestIds.push(parseInt(testId));
                }
                else {
                    var independentTestId = $(this).parent('td').find(':hidden').val();
                    removeTestIds.push(parseInt(independentTestId))
                }
            });
           
            var prequalifiedTestIds = GetDataArrayFromString(preQualifiedTest);
            GetContainsFunction(currentAddOnTestIds);

            var isMammoAlreadyAdded = false;
            if (currentAddOnTestIds.length > 0 && currentAddOnTestIds.contains(disqualifiedTestId)) {
                isMammoAlreadyAdded = true;
            }
            else if (currentPackageTestIds.length > 0 && currentPackageTestIds.contains(disqualifiedTestId))
            {
                isMammoAlreadyAdded = true;
            }

            if (prequalifiedTestIds != null && prequalifiedTestIds.length > 0 && currentPackageId == 0) {
                if (currentAddOnTestIds != null && currentAddOnTestIds.length > 0) {
                    if (singleTestOverride != '<%=Boolean.TrueString %>') {
                        $.each(prequalifiedTestIds, function () {

                            if (!currentAddOnTestIds.contains(this)) {
                                currentAddOnTestIds.push(this);
                            }
                        });
                    }
                } else {
                    if (singleTestOverride != '<%=Boolean.TrueString %>')
                        currentAddOnTestIds = prequalifiedTestIds;
                }
            }
            
            if (removeTestIds.indexOf(disqualifiedTestId) > -1) {
                isMammoQualified = false;
                isAnswerGiven = true;
            }

            if (currentAddOnTestIds.indexOf(disqualifiedTestId) > -1 && isAnswerGiven && !isMammoQualified) {
                currentAddOnTestIds = jQuery.grep(currentAddOnTestIds, function (value) {
                    return (value != disqualifiedTestId && value != dependentTestId);
                });
            }
            
            currentPackageId = RecommendPackage(packages, currentPackageId, currentPackageTestIds, currentAddOnTestIds);
            CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds);
            $('#CurrentSelectedTestIdsHiddenControl').val('');
            $('#CurrentSelectedTestIdsHiddenControl').val((currentSelectedTestIds != null && currentSelectedTestIds.length > 0) ? currentSelectedTestIds.join(',') : 0);

            if (!isAnswerGiven && !isMammoAlreadyAdded) {
                IsPrequalificationQuestions(true);
                isAnswerGiven = true;
            }
        }
    }

    var isAnswerGiven = false;

     var dependentTestId = 0;    function RemoveSingleTest(removeTestId, dependentTestsString) {
        $('#IsFreshLoadOfControlHiddenControl').val(false);
        if ($('.my-order-package-select').find(':checkbox').is(':checked'))
            currentPackageId = 0;

        var dependentTests = [];
        if (dependentTestsString != '' || dependentTestsString != 'undefined')
            dependentTests = dependentTestsString.split(',');

        currentPackageTestIds = ClearArray(currentPackageTestIds);
        currentAddOnTestIds = ClearArray(currentAddOnTestIds);

        $('.my-order-package-test-select').find(':checkbox').each(function () {
            //debugger;
            var testId = $(this).parent('td').find(':hidden').val();
            if (testId == removeTestId || dependentTests.includes(testId)) currentPackageId = 0;
            else if (testId != removeTestId && !dependentTests.includes(testId)) {
                currentPackageTestIds.push(parseInt(testId));
            }
        });

        if (currentPackageId == 0 && currentPackageTestIds != null && currentPackageTestIds.length > 0) {
            $.each(currentPackageTestIds, function () {
                currentAddOnTestIds.push(this);
            });
            currentPackageTestIds = ClearArray(currentPackageTestIds);
        }

        $('.my-order-independent-test-select').find(':checkbox').each(function () {
            //debugger;
            var testId = $(this).parent('td').find(':hidden').val();
            if (testId != removeTestId && !dependentTests.includes(testId))
                currentAddOnTestIds.push(parseInt(testId));
        });

        var prequalifiedTestIds = GetDataArrayFromString(preQualifiedTest);
        GetContainsFunction(currentAddOnTestIds);

        if (prequalifiedTestIds != null && prequalifiedTestIds.length > 0 && currentPackageId == 0) {
            if (currentAddOnTestIds != null && currentAddOnTestIds.length > 0) {
                if (singleTestOverride != '<%=Boolean.TrueString %>') {
                    $.each(prequalifiedTestIds, function () {
                        //debugger;
                        if (!currentAddOnTestIds.contains(this) && this != removeTestId && !dependentTests.includes(this)) {
                            currentAddOnTestIds.push(this);
                        }
                    });
                }
            } else {
                //debugger;
                if (singleTestOverride != '<%=Boolean.TrueString %>')
                    currentAddOnTestIds = prequalifiedTestIds;
            }
        }

        if (removeTestId == disqualifiedTestId && dependentTests != "" && !isMammoQualified) {
            currentAddOnTestIds = jQuery.grep(currentAddOnTestIds, function (value) {
                return (value != dependentTestId);
            });
            isAnswerGiven = true;
        }

        currentPackageId = RecommendPackage(packages, currentPackageId, currentPackageTestIds, currentAddOnTestIds);
        CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds);
        $('#CurrentSelectedTestIdsHiddenControl').val('');
        $('#CurrentSelectedTestIdsHiddenControl').val((currentSelectedTestIds != null && currentSelectedTestIds.length > 0) ? currentSelectedTestIds.join(',') : 0);

    }

</script>

<script type="text/javascript" language="javascript">

    function SelectTestCheckBoxClick(currentCheckBox) {
        //debugger;
        var checkedTestId = parseInt($(currentCheckBox).parent('td').find(':hidden').val());

        var tempTest = null;
        $.each(tests, function () {
            if (this.Id == checkedTestId) {
                tempTest = this;
                return;
            }
        });
        if (!CheckTestForAge(tempTest)) {
            $(currentCheckBox).attr('checked', false);
            return;
        }

        if (ValidateTestCheckedDependency(checkedTestId)) {
            $('#IsFreshLoadOfControlHiddenControl').val(false);
            var packageId = parseInt($('.package-select').find('#SelectPackageRadio:checked').parent('td').find(':hidden').val());
            packageId = isNaN(packageId) ? 0 : packageId

            currentPackageTestIds = ClearArray(currentPackageTestIds);
            currentAddOnTestIds = ClearArray(currentAddOnTestIds);

            $('.my-order-package-test-select').find(':hidden').each(function () {
                currentPackageTestIds.push(parseInt($(this).val()));
            });

            $('.my-order-independent-test-select').find(':hidden').each(function () {
                currentAddOnTestIds.push(parseInt($(this).val()));
            });
            $('.package-test-select').find('#SelectTestCheckBox:checked').each(function () {
                var testId = $(this).parent('td').find(':hidden').val();
                currentAddOnTestIds.push(parseInt(testId));
            });

            currentPackageId = RecommendPackage(packages, packageId, currentPackageTestIds, currentAddOnTestIds);
            CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds);
            //PackageChangeMessage(packageId, currentPackageId);
            $('#CurrentSelectedTestIdsHiddenControl').val('');
            currentSelectedTestIds.push(checkedTestId);
            $('#CurrentSelectedTestIdsHiddenControl').val((currentSelectedTestIds != null && currentSelectedTestIds.length > 0) ? currentSelectedTestIds.join(',') : 0);
        }
        else $(currentCheckBox).attr('checked', false);

        GetPreQualificationQuestionsforSingleTest(checkedTestId);

    }

    function AddTestsClick() {
        //debugger;
        if ($('#UpgradeOrderDialogDiv').find('.package-test-select').find('#SelectTestCheckBox:checked').length <= 0) {
            ShowAlertMessage('Please select atleast one test.');
            return;
        }

        $('#IsFreshLoadOfControlHiddenControl').val(false);
        currentPackageId = parseInt($('.package-select').find('#SelectPackageRadio:checked').parent('td').find(':hidden').val());
        currentPackageId = isNaN(currentPackageId) ? 0 : currentPackageId

        currentPackageTestIds = ClearArray(currentPackageTestIds);
        currentAddOnTestIds = ClearArray(currentAddOnTestIds);

        $('.my-order-package-test-select').find(':hidden').each(function () {
            currentPackageTestIds.push(parseInt($(this).val()));
        });

        $('.my-order-independent-test-select').find(':hidden').each(function () {
            currentAddOnTestIds.push(parseInt($(this).val()));
        });
        $('.package-test-select').find('#SelectTestCheckBox:checked').each(function () {
            var testId = $(this).parent('td').find(':hidden').val();
            currentAddOnTestIds.push(parseInt(testId));
        });
        currentPackageId = RecommendPackage(packages, currentPackageId, currentPackageTestIds, currentAddOnTestIds);
        CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds);
        NoThanksForAddOnTestClick();
    }

</script>

<script type="text/javascript" language="javascript">

    var callBackValidationMethod = null;

    function PlaceOrderClick(validationMethod) {//debugger;
        callBackValidationMethod = validationMethod;
        if (currentPackageId == 0 && (currentPackageTestIds == null || currentPackageTestIds.length == 0) && (currentAddOnTestIds == null || currentAddOnTestIds.length == 0)) {
            if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
                alert("Please select a Package or tests.");
            else
                alert("Please select a Package.");
            return;
        }

        var selectedPackagePrice = 0;
        var maxPrice = 0;

        if (packages != null) {
            $.each(packages, function () {
                var price = parseFloat(this.Price);
                if (maxPrice < price)
                    maxPrice = price;

                if (this.Id == currentPackageId)
                    selectedPackagePrice = price;
            });
        }

        if (currentPackageId > 0 && packages != null && packages.length > 0 && selectedPackagePrice < maxPrice)
            OpenUpsellPackageDialog(packages, currentPackageId);
        else if (tests != null && tests.length > 0 && ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>' && '<%= UpsellTest %>' == '<%= Boolean.TrueString %>'))
            OpenUpsellAddOnTests(tests, currentAddOnTestIds);
        else if ($('#UpgradeOrderDialogDiv').dialog('isOpen'))
            $('#UpgradeOrderDialogDiv').dialog('close');
        else Validation();
    }

    function NoThanksForPackageClick() {//debugger;
        if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>' && '<%= UpsellTest %>' == '<%= Boolean.TrueString %>')
            OpenUpsellAddOnTests(tests, currentAddOnTestIds);
        else
            $('#UpgradeOrderDialogDiv').dialog('close');
    }

    function UpdateOrderDialogClosing() {
        if (callBackValidationMethod != null)
            callBackValidationMethod();
    }

    function NoThanksForAddOnTestClick() {
        $('#UpgradeOrderDialogDiv').dialog('close');
    }

</script>

<script type="text/javascript" language="javascript">

    function InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: parameter,
            success: function (result) {
                successFunction(result);
            },
            error: function (a, b, c) {
                errorFunction();
            }
        });
    }

    function GetDataArrayFromString(tests) {
        var dataArray = tests != null && tests != '0' && tests.length > 0 ? tests.split(',') : null;

        if (dataArray != null) {
            dataArray = $.map(dataArray, function (element) {
                return parseInt(element);
            });
        }
        return dataArray;
    }

    function GetContainsFunction(collection) {
        if (collection == null) collection = new Array();

        collection.contains = function (currentElement) {
            for (var counter = 0; counter < this.length; counter++) {
                if (parseInt(this[counter]) == parseInt(currentElement))
                    return true;
            }
            return false;
        };
    }

    function RemoveElementFromArray(collection, elementName) {
        if (collection == null) return (collection = new Array());

        for (var counter = 0; counter < collection.length; counter++) {
            if (collection[counter] == elementName)
                collection.splice(counter, 1);
        }
    }

    function ClearArray(collection) {
        if (collection == null) return (collection = new Array());

        for (var counter = 0; counter < collection.length; counter++) {
            collection.splice(0, collection.length);
        }
        return collection;
    }

    function ConcatArrays(arrayOne, arrayTwo) {
        var combinedArray = new Array();

        if (arrayOne != null && arrayOne.length > 0) {
            $.each(arrayOne, function () {
                combinedArray.push(this);
            });
        }
        if (arrayTwo != null && arrayTwo.length > 0) {
            $.each(arrayTwo, function () {
                combinedArray.push(this);
            });
        }
        return combinedArray;
    }

</script>

<script type="text/javascript" language="javascript">

    function SetTestView(roleId) {
        var pageUrl = this.location.pathname;
        if (pageUrl.match(/ChangePackage/i)) {
            $('.view-test').css({
                width: 420 + "px",
                display: "block",
                height: "auto"
            });
        }
    }

</script>

<script type="text/javascript" language="javascript">

    function ShowPackageDetails(packageName, packageId) {
        //debugger;
        var packageMoreInfo;
        if (packages != null && packages.length > 0) {
            $.each(packages, function () {
                if (this.Id == packageId)
                    packageMoreInfo = this;
            });
        }
        var PackageDetailsDialogDiv = $('#PackageDetailsDialogDiv');

        PackageDetailsDialogDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/PackageDetail.html") %>');

        PackageDetailsDialogDiv.setParam('PackageName', packageName);
        PackageDetailsDialogDiv.setParam('PackageDescription', packageMoreInfo.Description);
        PackageDetailsDialogDiv.processTemplate(packageMoreInfo.Tests);

        $('#PackageDetailsDialogDiv').dialog("option", 'title', packageName);
        $('#PackageDetailsDialogDiv').dialog('open');
    }

    function ShowUpgradeTestDetails(testName) {
        if (testName.match(/Osteoporosis/i))
            $('#PackageDetailsDialogDiv').load('<%= ResolveUrl("~/App/Templates/OsteoporosisAddonTestDetails.html") %>', null, function () { $('#PackageDetailsDialogDiv').dialog("option", 'title', 'Osteoporosis/Bone Density  Details'); $('#PackageDetailsDialogDiv').dialog('open'); });
        else if (testName.match(/Liver/i))
            $('#PackageDetailsDialogDiv').load('<%= ResolveUrl("~/App/Templates/LiverFunctionAddonTestDetails.html") %>', null, function () { $('#PackageDetailsDialogDiv').dialog("option", 'title', 'Liver Function(ALT/AST) Details'); $('#PackageDetailsDialogDiv').dialog('open'); });
        else if (testName.match(/Colorectal/i))
            $('#PackageDetailsDialogDiv').load('<%= ResolveUrl("~/App/Templates/ColorectalCancerAddonTestDetails.html") %>', null, function () { $('#PackageDetailsDialogDiv').dialog("option", 'title', 'Colorectal Cancer(take-home test) Details'); $('#PackageDetailsDialogDiv').dialog('open'); });
}

</script>

<script type="text/javascript" language="javascript">

    function ValidateTestCheckedDependency(testId) {
        var isValid = true;

        var checkedTestIds = new Array();

        $('.my-order-package-test-select').find(':checkbox').each(function () {
            var testId = $(this).parent('td').find(':hidden').val();
            checkedTestIds.push(parseInt(testId));
        });
        $('.my-order-independent-test-select').find(':checkbox').each(function () {
            var testId = $(this).parent('td').find(':hidden').val();
            checkedTestIds.push(parseInt(testId));
        });

        if (testDependencyData != null && testDependencyData.length > 0 && testId > 0 && tests != null && tests.length > 0) {
            GetContainsFunction(checkedTestIds);
            $.each(testDependencyData, function () {
                if (this.FirstValue == testId && (checkedTestIds.length == 0 || !checkedTestIds.contains(this.SecondValue))) {
                    isValid = false;
                    var dependentTestName = null;
                    var testName = null;
                    var testDependency = this;
                    $.each(tests, function () {
                        if (this.Id == testDependency.FirstValue)
                            dependentTestName = this.Name;
                        else if (this.Id == testDependency.SecondValue)
                            testName = this.Name;
                    });
                    ShowRequiredAdditionalTestMessage(dependentTestName + ' requires ' + testName + '. Please select ' + testName + ' first');
                }
            });
        }
        return isValid;
    }

    function ValidateTestUnCheckedDependency() {
        var isValid = true;

        var testIds = new Array();
        $('.my-order-package-test-select').find(':checkbox').each(function () {
            var testId = $(this).parent('td').find(':hidden').val();
            testIds.push(parseInt(testId));
        });
        $('.my-order-independent-test-select').find(':checkbox').each(function () {
            var testId = $(this).parent('td').find(':hidden').val();
            testIds.push(parseInt(testId));
        });

        var checkedTestIds = new Array();

        $('.my-order-package-test-select').find(':checkbox').each(function () {
            if ($(this).is(':checked')) {
                var testId = $(this).parent('td').find(':hidden').val();
                checkedTestIds.push(parseInt(testId));
            }
        });
        $('.my-order-independent-test-select').find(':checkbox').each(function () {
            if ($(this).is(':checked')) {
                var testId = $(this).parent('td').find(':hidden').val();
                checkedTestIds.push(parseInt(testId));
                currentSelectedTestIds.push(parseInt(testId));
            }
        });

        if (testDependencyData != null && testDependencyData.length > 0 && checkedTestIds.length > 0 && tests != null && tests.length > 0) {
            GetContainsFunction(checkedTestIds);
            GetContainsFunction(testIds);
            $.each(checkedTestIds, function () {
                var testId = this;
                $.each(testDependencyData, function () {
                    if (this.SecondValue == testId && !checkedTestIds.contains(this.FirstValue) && testIds.contains(this.FirstValue)) {
                        isValid = false;
                        var dependentTestName = null;
                        var testName = null;
                        var testDependency = this;
                        $.each(tests, function () {
                            if (this.Id == testDependency.FirstValue)
                                dependentTestName = this.Name;
                            else if (this.Id == testDependency.SecondValue)
                                testName = this.Name;
                        });
                        ShowRequiredAdditionalTestMessage(dependentTestName + ' requires ' + testName + '. Please remove ' + dependentTestName + ' first');
                    }
                });
            });
        }

        return isValid;
    }

</script>

<script type="text/javascript" language="javascript">

    var _prequalificationTemplateIdandTestId = new Array();

    function GetPrequalificationTemplateIdandTestId(tests) {
        $.each(tests, function (index, obj) {
            if (obj.PreQualificationQuestionTemplateId != null) {
                var item = [obj.PreQualificationQuestionTemplateId, obj.Id];
                _prequalificationTemplateIdandTestId.push(item);
            }
        });

    }

    function GetPackagesAndTestsForEventByRole(eventId, roleId, currentPackageId, currentPackageTestIds, currentAddOnTestIds, showPreQualificationPopup) {//debugger;
        $('#LoadingDiv').show();
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/PackageController.asmx/GetPackagesAndTests")%>';
        var parameter = "{'eventId':" + eventId + ",";
        parameter += "'roleId':" + roleId + "}";

        var successFunction = function (resultData) {
            if (resultData != null && resultData.d != null) {
                if (resultData.d.FirstValue != null && resultData.d.FirstValue.length > 0)
                    packages = resultData.d.FirstValue;
                if (resultData.d.SecondValue != null && resultData.d.SecondValue.length > 0)
                    tests = resultData.d.SecondValue;
            }
            if (packages != null) {
                var tempPackages = new Array();
                $.each(packages, function (index, obj) {
                    obj.IsDisabled = ('<%= PreApprovedPackage %>' == '<%= Boolean.TrueString %>' && singleTestOverride != '<%=Boolean.TrueString %>');
                    tempPackages.push(obj);
                });
                packages = tempPackages;
                }

            if ($('#IsFreshLoadOfControlHiddenControl').val() == 'false')
                currentPackageId = RecommendPackage(packages, packageId, currentPackageTestIds, currentAddOnTestIds);

            CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds);

            GetPrequalificationTemplateIdandTestId(tests);
           
            if (showPreQualificationPopup && !isMammoQualified) {
                IsPrequalificationQuestions(false);
                isAnswerGiven = true;
            }
            $('#LoadingDiv').hide();
        };

            var errorFunction = function () {
                $('#LoadingDiv').hide();
                ShowAlertMessage('Some error occured while processing your request, please try again later.');
            };


            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
        }

        function GetTestDependencyData() {
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/PackageController.asmx/GetTestDependencyData")%>';
            var parameter = "{}";

            var successFunction = function (resultData) {
                if (resultData.d != null && resultData.d.length > 0)
                    testDependencyData = resultData.d;
            };
            var errorFunction = function () {
                ShowAlertMessage('Some error occured while processing your request, please try again later.');
            };

            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
        }

        function GetPackageTests(selectedPackage) {
            var packageTests = new Array();
            if (selectedPackage != null && selectedPackage.Tests != null && selectedPackage.Tests.length > 0) {
                $.each(selectedPackage.Tests, function () {
                    packageTests.push(this);
                });
            }
            return packageTests;
        }

        function GetPackageTestIds(selectedPackage) {
            var packageTestIds = new Array();
            if (selectedPackage != null && selectedPackage.Tests != null && selectedPackage.Tests.length > 0) {
                $.each(selectedPackage.Tests, function () {
                    packageTestIds.push(this.Id);
                });
            }
            return packageTestIds;
        }

        function GetTestIds(selectedTests) {
            var testIds = new Array();
            if (selectedTests != null && selectedTests.length > 0) {
                $.each(selectedTests, function () {
                    testIds.push(this.Id);
                });
            }
            return testIds;
        }

</script>

<script type="text/javascript" language="javascript">
    var selectedTemplateViewData = { "Package": { "PackageId": 0, "PackageName": '', "OfferPrice": parseFloat(0) }, "PackageTests": new Array(), "AddOnTests": new Array() };

    function CreateTemplateData(packages, tests, currentPackageId, currentPackageTestIds, currentAddOnTestIds) {//debugger;
        CloseAllDialogBoxes();

        var selectedPackage = null;
        var selectedPackageTests = null;
        var selectedAddOnTests = null;

        if (currentPackageId > 0 && packages != null && packages.length > 0) {
            $.each(packages, function () {
                if (this.Id == currentPackageId) {
                    selectedPackage = this;
                    return;
                }
            });
        }

        currentPackageTestIds = ClearArray(currentPackageTestIds);
        if (currentPackageId > 0 && selectedPackage != null && packages != null && packages.length > 0) {
            selectedPackageTests = GetPackageTests(selectedPackage);
            if (selectedPackageTests != null && selectedPackageTests.length > 0) {
                $.each(selectedPackageTests, function () {
                    var selectedPackageTest = this;
                    currentPackageTestIds.push(selectedPackageTest.Id);
                    if (tests != null && tests.length > 0) {
                        $.each(tests, function () {
                            if (selectedPackageTest.Id == this.Id)
                                selectedPackageTest.PackagePrice = this.PackagePrice;
                        });
                    }
                });
            }
        }

        if (currentAddOnTestIds != null && currentAddOnTestIds.length > 0 && tests != null && tests.length > 0) {
            GetContainsFunction(currentAddOnTestIds);

            if (currentPackageTestIds != null && currentPackageTestIds.length > 0) {
                GetContainsFunction(currentPackageTestIds);
                var addOnTestsToBeRemoved = new Array();

                $.each(currentAddOnTestIds, function () {
                    if (currentPackageTestIds.contains(this))
                        addOnTestsToBeRemoved.push(this);
                });
                if (addOnTestsToBeRemoved.length > 0)
                    $.each(addOnTestsToBeRemoved, function () {
                        RemoveElementFromArray(currentAddOnTestIds, this);
                    });
            }

            selectedAddOnTests = new Array();
            $.each(tests, function () {
                if (currentAddOnTestIds.contains(this.Id))
                    selectedAddOnTests.push(this);
            });
        }

        var remainingTests = CreateTestTemplateViewData(currentPackageTestIds, currentAddOnTestIds, tests);
        remainingTests = RemovePanelTestIfPanelIsSelected(currentPackageTestIds, remainingTests, currentAddOnTestIds);
        BindPackageAndTestTemplates(packages, remainingTests);

        selectedAddOnTests = RemovePanelTestIfPanelIsSelected(currentPackageTestIds, selectedAddOnTests, currentAddOnTestIds);

        if (selectedAddOnTests != null && selectedAddOnTests.length > 0) {
            currentAddOnTestIds = new Array();
            $.each(selectedAddOnTests, function () {
                currentAddOnTestIds.push(this.Id);
            });
        } else {
            currentAddOnTestIds = selectedAddOnTests;
        }

        selectedTemplateViewData = CreateSelectedOrderTemplateData(selectedPackage, selectedPackageTests, selectedAddOnTests);
        BindSelectedOrderTemplate(selectedTemplateViewData);
        var offerPrice = CalculateAndSetPrice(selectedPackage, selectedPackageTests, selectedAddOnTests);
        SetSelectedDataToHiddenControls(currentPackageId, currentPackageTestIds, currentAddOnTestIds, selectedTemplateViewData);
        SelectPackageRadioButton(currentPackageId);
        SetSavingDisplay(selectedTemplateViewData);
        SuggestBetterOption(offerPrice, selectedPackage, selectedPackageTests, selectedAddOnTests, packages);

        SelectPackage();
    }
    function RemovePanelTestIfPanelIsSelected(currentPackageTestIds, remainingTests, currentAddOnTestIds) {
        if (remainingTests == null)
            return null;

        var mensBloodTestId = [<%= (long)TestType.MenBloodPanel %>];//64;
        var womensBloodTestId = [<%= (long)TestType.WomenBloodPanel %>];//  65;
        var mensBloodPanelTestIds = [<%=MensBloodPanelTestIds %>];
        var woMensBloodPanelTestIds = [<%=WomensBloodPanelTestIds %>];
        var testIdsToRemove = [];
        GetContainsFunction(currentPackageTestIds);
        GetContainsFunction(currentAddOnTestIds);


        if ((currentPackageTestIds != null && currentPackageTestIds.contains(mensBloodTestId)) || (currentAddOnTestIds != null && currentAddOnTestIds.contains(mensBloodTestId))) {
            GetContainsFunction(mensBloodPanelTestIds);
            $.each(remainingTests, function (i, item) {
                if (mensBloodPanelTestIds.contains(item.Id))
                    testIdsToRemove.push(item.Id);
            });
        }
        if ((currentPackageTestIds != null && currentPackageTestIds.contains(womensBloodTestId)) || (currentAddOnTestIds != null && currentAddOnTestIds.contains(womensBloodTestId))) {
            GetContainsFunction(woMensBloodPanelTestIds);
            $.each(remainingTests, function (i, item) {
                if (woMensBloodPanelTestIds.contains(item.Id))
                    testIdsToRemove.push(item.Id);
            });
        }

        var finalremainingTests = [];

        if (testIdsToRemove.length > 0) {
            GetContainsFunction(testIdsToRemove);
            $.each(remainingTests, function (i, item) {
                if (!testIdsToRemove.contains(item.Id))
                    finalremainingTests.push(item);
            });
            return finalremainingTests;
        }

        return remainingTests;
    }
    function CreateTestTemplateViewData(currentPackageTestIds, currentAddOnTestIds, tests) {
        var remainingTests = new Array();

        GetContainsFunction(currentPackageTestIds);
        GetContainsFunction(currentAddOnTestIds);

        $.each(tests, function () {
            if ((currentAddOnTestIds == null || currentAddOnTestIds.length == 0 || !currentAddOnTestIds.contains(this.Id)) && (currentPackageTestIds == null || currentPackageTestIds.length == 0 || !currentPackageTestIds.contains(this.Id)))
                remainingTests.push(this);
        });

        return remainingTests;
    }

    function CreateSelectedOrderTemplateData(selectedPackage, selectedPackageTests, selectedAddOnTests) {
                if (selectedPackage != null) {
            selectedTemplateViewData.Package = { "PackageId": 0, "PackageName": '', "OfferPrice": parseFloat(0) };
            selectedTemplateViewData.Package.PackageId = selectedPackage.Id;
            selectedTemplateViewData.Package.PackageName = selectedPackage.Name;
            selectedTemplateViewData.Package.OfferPrice = selectedPackage.Price;
            selectedTemplateViewData.Package.IsDisabled = ('<%= PreApprovedPackage %>' == '<%= Boolean.TrueString %>' && singleTestOverride != '<%=Boolean.TrueString %>');
        }
        else selectedTemplateViewData.Package = null;

        selectedTemplateViewData.PackageTests = ClearArray(selectedTemplateViewData.PackageTests);
        if (selectedPackageTests != null && selectedPackageTests.length > 0) {
            $.each(selectedPackageTests, function () {
                var packageTest = { "TestId": 0, "TestName": '', "TestDescription": 'INCLUDED', "RetailPrice": parseFloat(0), "OfferPrice": parseFloat(0) };
                packageTest.TestId = this.Id;
                packageTest.TestName = this.Name;
                packageTest.RetailPrice = parseFloat(this.Price);
                packageTest.OfferPrice = parseFloat(this.PackagePrice);
                packageTest.IsDisabled = ('<%= PreApprovedPackage %>' == '<%= Boolean.TrueString %>' && singleTestOverride != '<%=Boolean.TrueString %>');
                selectedTemplateViewData.PackageTests.push(packageTest);
            });
        }

        selectedTemplateViewData.AddOnTests = ClearArray(selectedTemplateViewData.AddOnTests);
        var prequalifiedTestIds = GetDataArrayFromString(preQualifiedTest);
        GetContainsFunction(prequalifiedTestIds);

        if (selectedAddOnTests != null && selectedAddOnTests.length > 0) {
            $.each(selectedAddOnTests, function () {
                var addOnTest = { "TestId": 0, "TestName": '', "RetailPrice": parseFloat(0), "OfferPrice": parseFloat(0) };
                addOnTest.TestId = this.Id;
                addOnTest.TestName = this.Name;
                addOnTest.PrequalifiedTest = false;

                if (selectedPackage != null) {
                    addOnTest.RetailPrice = parseFloat(this.WithPackagePrice);
                    addOnTest.OfferPrice = parseFloat(this.WithPackagePrice);
                }
                else {
                    addOnTest.RetailPrice = parseFloat(this.Price);
                    addOnTest.OfferPrice = parseFloat(this.Price);
                }
                if (prequalifiedTestIds != null && prequalifiedTestIds.length > 0 && prequalifiedTestIds.contains(this.Id) && singleTestOverride != '<%=Boolean.TrueString %>')
                    addOnTest.PrequalifiedTest = true;

                selectedTemplateViewData.AddOnTests.push(addOnTest);
            });
        }

        return selectedTemplateViewData;
    }

</script>

<script type="text/javascript" language="javascript">

    function BindPackageAndTestTemplates(packages, tests) {//debugger;
        var viewPackagesTemplateDiv = $('#ViewPackagesTemplateDiv');
        var viewTestsTemplateDiv = $('#ViewTestsTemplateDiv');

        if (packages != null && packages.length > 0) {
            viewPackagesTemplateDiv.removeClass('no-package-div');
            viewPackagesTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/Packages.html") %>');
            viewPackagesTemplateDiv.setParam('CurrentPackageId', currentPackageId);
            viewPackagesTemplateDiv.processTemplate(packages);

            // TODO: This is done for private events in order to hide the price descrapancy.
            if (eventType == '3') {
                viewPackagesTemplateDiv.find('#PackageDetailsAnchor').hide();
            }
        }
        else {
            viewPackagesTemplateDiv.html('');
            viewPackagesTemplateDiv.addClass('no-package-div');
        }

        if (tests != null && tests.length > 0) {
            viewTestsTemplateDiv.removeClass('no-test-div');
            viewTestsTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/Tests.html") %>');
            viewTestsTemplateDiv.setParam('PackageId', currentPackageId);
            viewTestsTemplateDiv.processTemplate(tests);
        }
        else {
            viewTestsTemplateDiv.html('<h3 class="orngbold14_default mt_medium">(2) "A La Carte" Tests</h3>');
            viewTestsTemplateDiv.addClass('no-test-div');
        }

        DisableForPhysicianPartnerCustomer();
    }

    function BindSelectedOrderTemplate(selectedTemplateViewData) {
                 var viewSelectedPackageAndTests = $('#ViewSelectedPackageAndTests');
        viewSelectedPackageAndTests.setTemplateURL('<%= ResolveUrl("~/App/Templates/SelectedOrder.html") %>');

        if (selectedTemplateViewData.Package != null || (selectedTemplateViewData.AddOnTests != null && selectedTemplateViewData.AddOnTests.length > 0)) {
            var selectedTemplateViewDataArray = new Array();
            selectedTemplateViewDataArray.push(selectedTemplateViewData);
            viewSelectedPackageAndTests.setParam('EnableTest', ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>'));
            viewSelectedPackageAndTests.processTemplate(selectedTemplateViewDataArray);
            AttachCheckBoxSelect();

            DisableSelectedPackageTest();

        }
        else
            viewSelectedPackageAndTests.html('<p>No Items Selected.</p>');

             

        if ($('input[id*="SingleTestOverrideYes"]').is(":checked")) {
            singleTestOverride = '<%=Boolean.TrueString %>';

            $("#ViewPackagesTestsDiv input[type='radio'], #ViewPackagesTestsDiv input[type='checkbox']").removeAttr("disabled");
            $("#ViewPackagesTemplateDiv").find("input[type='radio']").click(function () {
                SelectPackageRadioClick(this);
            });

            $("#ViewSelectedPackageAndTests").find("input[type='checkbox']").removeAttr("disabled");

            $("#ViewSelectedPackageAndTests #RemoveSelectedButton").show();
        }
    }

    function SetSelectedDataToHiddenControls(currentPackageId, currentPackageTestIds, currentAddOnTestIds, selectedTemplateViewData) {
        $('#PackageIdHiddenControl').val(currentPackageId);
        $('#PackageTestIdsHiddenControl').val((currentPackageTestIds != null && currentPackageTestIds.length > 0) ? currentPackageTestIds.join(',') : 0);
        $('#IndependentTestIdsHiddenControl').val((currentAddOnTestIds != null && currentAddOnTestIds.length > 0) ? currentAddOnTestIds.join(',') : 0);


        if (selectedTemplateViewData.Package != null) {
            $('#PackageNameHidden').val(selectedTemplateViewData.Package.PackageName);
            $('#PackageDescriptionHidden').val(selectedTemplateViewData.Package.PackageName);
        }
        else {
            $('#PackageNameHidden').val('');
            $('#PackageDescriptionHidden').val('');
        }
        if (selectedTemplateViewData.AddOnTests != null && selectedTemplateViewData.AddOnTests.length > 0) {

            var addOnTestNames = new Array();
            $.each(selectedTemplateViewData.AddOnTests, function () {
                if (this.TestName.length > 0)
                    addOnTestNames.push(this.TestName);
            });

            if (addOnTestNames.length > 0) {
                $('#IndependentTestsNameHidden').val(addOnTestNames.join(', '));
                var packageDescription = $('#PackageDescriptionHidden').val();

                if ($('#PackageDescriptionHidden').val() != '')
                    packageDescription += ', ';

                packageDescription += $('#IndependentTestsNameHidden').val();
                $('#PackageDescriptionHidden').val(packageDescription);
            }
            else
                $('#IndependentTestsNameHidden').val('');
        }
        else
            $('#IndependentTestsNameHidden').val('');

        var selectedTestIds = ConcatArrays(currentPackageTestIds, currentAddOnTestIds);
        $('#TestIdsHiddenControl').val((selectedTestIds != null && selectedTestIds.length > 0) ? selectedTestIds.join(',') : 0);

        var isOrderChanged = IsCurrentSelctionOfOrderDifferentFromOriginal(currentPackageId, currentPackageTestIds, currentAddOnTestIds);
        $('#OrderChangedHiddenControl').val(isOrderChanged);

        var isPackageChanged = IsPackageChange(currentPackageId);
        $('#PackageChangedHiddenControl').val(isPackageChanged);
    }

    function SelectPackageRadioButton(currentPackageId) {
        $('.package-select').find('#SelectPackageRadio').each(function () {
            var packageId = parseInt($(this).parent('td').find(':hidden').val());
            if (currentPackageId == packageId)
                $(this).attr('checked', true);
        });
    }
</script>

<script type="text/javascript" language="javascript">

    function CalculateAndSetPrice(selectedPackage, selectedPackageTests, selectedAddOnTests) {//debugger;
        var retailPrice = 0.00;
        var offerPrice = 0.00;

        if (selectedPackage != null && selectedPackageTests != null && selectedPackageTests.length > 0) {
            offerPrice += selectedPackage.Price;
            $.each(selectedPackageTests, function () {
                retailPrice += this.Price;
            });
        }

        if (selectedAddOnTests != null && selectedAddOnTests.length > 0) {//debugger;
            $.each(selectedAddOnTests, function () {
                if (selectedPackage != null) {
                    retailPrice += this.WithPackagePrice;
                    offerPrice += this.WithPackagePrice;
                }
                else {
                    retailPrice += this.Price;
                    offerPrice += this.Price;
                }
            });
        }
        var savings = retailPrice - offerPrice;

        if (retailPrice > 0.00 && retailPrice > offerPrice) {
            $('#RetailPriceSpan').text(retailPrice.toFixed(2));
            $('#SavingAmountSpan').text(savings.toFixed(2));
            $('#OfferPriceSpan').text(offerPrice.toFixed(2));
            $('#PackageSummaryDiv').show();
        } else if (offerPrice > 0) {
            $('#RetailPriceSpan').text(retailPrice.toFixed(2));
            $('#SavingAmountSpan').text(0.00);
            $('#OfferPriceSpan').text(offerPrice.toFixed(2));
            $('#PackageSummaryDiv').show();
        }
        else {
            $('#RetailPriceSpan').text(0.00);
            $('#SavingAmountSpan').text(0.00);
            $('#OfferPriceSpan').text(0.00);
            $('#PackageSummaryDiv').hide();
        }
        return offerPrice;
    }

</script>

<script type="text/javascript" language="javascript">

    function ShowHideSourceCodeAmountDiv(show) {
        if (show)
            $('#SourceCodeAmountDiv').show();
        else
            $('#SourceCodeAmountDiv').hide();
    }

    function SetSourceCodeDiscount(discountAmount) {
        var retailPrice = parseFloat($('#RetailPriceSpan').text());
        var savings = parseFloat($('#SavingAmountSpan').text());
        var offerPrice = ((retailPrice - savings) - parseFloat(discountAmount)).toFixed(2);
        $('#SourceCodeAmountSpan').text(parseFloat(discountAmount).toFixed(2));
        $('#OfferPriceSpan').text(offerPrice);
    }

</script>

<script type="text/javascript" language="javascript">

    function OpenUpsellPackageDialog(packages, currentPackageId) {
        var upgradeOrderTemplateDiv = $('#UpgradeOrderTemplateDiv');

        var upgradePackages = new Array();

        var selectedPackage = null;
        if (currentPackageId > 0 && packages != null && packages.length > 0) {
            $.each(packages, function () {
                if (this.Id == currentPackageId) {
                    selectedPackage = this;
                    return;
                }
            });
        }

        if (packages != null && packages.length > 0) {
            $.each(packages, function (index) {
                if (index < packages.length) {
                    //var nextPackage = packages[++index];
                    var upgradePackage = { "Id": parseInt(0), "Name": '', "Description": '', "ButtonName": '' };
                    if (this.Id != selectedPackage.Id && this.Price > selectedPackage.Price && selectedPackage != null) {// && nextPackage != null
                        upgradePackage.Id = this.Id;
                        upgradePackage.Name = this.Name;

                        var splitName = this.Name.split(' ');
                        var dynamicName = splitName.length > 0 ? splitName[0] : this.Name;
                        upgradePackage.ButtonName = 'Upgrade to ' + dynamicName;

                        var retailPriceOfTestsNotInSelectedPackage = 0.00;
                        var testNamesNotInSelectedPackage = new Array();
                        if (this.Tests != null && this.Tests.length > 0 && selectedPackage.Tests != null && selectedPackage.Tests.length > 0) {//&& nextPackage.Tests != null && nextPackage.Tests.length > 0
                            var nextPackageTestIds = GetPackageTestIds(selectedPackage); //nextPackage
                            GetContainsFunction(nextPackageTestIds);
                            $.each(this.Tests, function () {
                                if (!nextPackageTestIds.contains(this.Id)) {
                                    testNamesNotInSelectedPackage.push(this.Name);
                                    retailPriceOfTestsNotInSelectedPackage += this.Price;
                                }
                            });
                        }
                        var differenceInPrice = (this.Price - selectedPackage.Price).toFixed(2); //nextPackage
                        var percentSavings = parseFloat((((retailPriceOfTestsNotInSelectedPackage - differenceInPrice) * 100) / retailPriceOfTestsNotInSelectedPackage)).toFixed(0);
                        var additionalTestNames = testNamesNotInSelectedPackage.length > 0 ? testNamesNotInSelectedPackage.join(', ') : '';
                        if ($.trim(this.DescriptiononUpsellSection).length > 0) {
                            upgradePackage.Description = this.DescriptiononUpsellSection;
                        }
                        else {
                            upgradePackage.Description = 'add the ' + additionalTestNames + ' test(s) (normally $' + retailPriceOfTestsNotInSelectedPackage.toFixed(2) + ') to the ' + selectedPackage.Name + ' for only $' + differenceInPrice + ' more (a ' + percentSavings + '% savings)'; //nextPackage.Name
                        }
                        upgradePackages.push(upgradePackage);
                    }
                }
            });
        }

        if (upgradePackages.length > 0) {
            upgradeOrderTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/UpgradePackages.html") %>');
            upgradeOrderTemplateDiv.processTemplate(upgradePackages.reverse());
            $('#UpgradeOrderDialogDiv').dialog("option", "buttons", { 'No Thanks': function () { NoThanksForPackageClick(); } });
            $('#UpgradeOrderDialogDiv').dialog('open');
        }
    }

</script>

<script type="text/javascript" language="javascript">

    function OpenUpsellAddOnTests(tests, addOnTestIds) {//debugger;
        var upgradeOrderTemplateDiv = $('#UpgradeOrderTemplateDiv');
        var addOnTestsNotSelected = new Array();

        GetContainsFunction(addOnTestIds);

        $.each(tests, function () {
            //debugger;
		    <%--if ((this.Id == parseInt('<%=(long)TestType.Colorectal %>') ||
					this.Id == parseInt('<%=(long)TestType.Osteoporosis %>') ||
					this.Id == parseInt('<%=(long)TestType.Liver %>'))
                    && (currentPackageTestIds == null || !currentPackageTestIds.contains(this.Id)))--%>
            if (currentPackageTestIds == null || !currentPackageTestIds.contains(this.Id)) {
                if (addOnTestIds == null || addOnTestIds.length == 0 || !addOnTestIds.contains(this.Id))
                    addOnTestsNotSelected.push(this);
            }
        });

        if (addOnTestsNotSelected.length > 0) {
            upgradeOrderTemplateDiv.html('');
            upgradeOrderTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/UpgradeAddOnTests.html") %>');
            upgradeOrderTemplateDiv.processTemplate(addOnTestsNotSelected);
            if (!$('#UpgradeOrderDialogDiv').dialog('isOpen')) $('#UpgradeOrderDialogDiv').dialog('open');
            $('#UpgradeOrderDialogDiv').dialog("option", "buttons", { 'Add Tests': function () { AddTestsClick(); }, 'No Thanks': function () { NoThanksForAddOnTestClick(); } });
        }
        else if ($('#UpgradeOrderDialogDiv').dialog('isOpen'))
            $('#UpgradeOrderDialogDiv').dialog('close');
        else Validation();
    }

</script>

<script type="text/javascript" language="javascript">

    function SetSavingDisplay(selectedTemplateViewData) {
        var retailPrice = parseFloat($('#RetailPriceSpan').text());
        var savings = parseFloat($('#SavingAmountSpan').text());
        var offerPrice = parseFloat($('#OfferPriceSpan').text());

        // TODO: This is done for private events in order to hide the price descrapancy
        if (savings > 0.00 && eventType != '3' && selectedTemplateViewData != null && selectedTemplateViewData.PackageTests.length > 0) {
            $('#SavingsMessageTable').html('<tr><td colspan="4" id="DescriptionTd" style="font:12px Arial;"></td></tr><tr style="font:12px Arial;"><td id="NameTd" style="width:300px;"><u><strong>Preventive Test</strong></u></td><td id="RetailPriceTd" align="right"><u><strong>Retail</strong></u></td><td id="SavingPriceTd" align="right"><u><strong>Savings</strong></u></td><td id="OfferPriceTd" align="right"><u><strong>YourCost</strong></u></td></tr>');
            $('#SavingsMessageTable').find('#DescriptionTd').html('Our Value Priced PreventionPAKs are Discounted. You have decided to buy <b>' + selectedTemplateViewData.Package.PackageName + '</b> at a price of <u><b>$' + selectedTemplateViewData.Package.OfferPrice.toFixed(2) + '</b></u>. This Package includes following test(s) with retail prices as -');

            var clonedSavingsTableRow = $('#SavingsMessageTable').find("tr:last").clone();

            $.each(selectedTemplateViewData.PackageTests, function () {
                clonedSavingsTableRow.find('#NameTd').text(this.TestName);
                clonedSavingsTableRow.find('#RetailPriceTd').text('$' + this.RetailPrice.toFixed(2));
                clonedSavingsTableRow.find('#SavingPriceTd').text('$' + (this.RetailPrice - this.OfferPrice).toFixed(2));
                clonedSavingsTableRow.find('#OfferPriceTd').text(this.OfferPrice == 0.00 ? 'FREE' : '$' + this.OfferPrice.toFixed(2));
                $('#SavingsMessageTable').append(clonedSavingsTableRow);
                clonedSavingsTableRow = $('#SavingsMessageTable').find("tr:last").clone();
            });

            if (selectedTemplateViewData.AddOnTests != null && selectedTemplateViewData.AddOnTests.length > 0) {
                $.each(selectedTemplateViewData.AddOnTests, function () {
                    clonedSavingsTableRow.find('#NameTd').text(this.TestName);
                    clonedSavingsTableRow.find('#RetailPriceTd').text('$' + this.RetailPrice.toFixed(2));
                    clonedSavingsTableRow.find('#SavingPriceTd').text('$' + '0.00');
                    clonedSavingsTableRow.find('#OfferPriceTd').text('$' + this.RetailPrice.toFixed(2));
                    $('#SavingsMessageTable').append(clonedSavingsTableRow);
                    clonedSavingsTableRow = $('#SavingsMessageTable').find("tr:last").clone();
                });
            }
            clonedSavingsTableRow.find('#NameTd').text('');
            clonedSavingsTableRow.find('#RetailPriceTd').text('$' + retailPrice.toFixed(2));
            clonedSavingsTableRow.find('#SavingPriceTd').text('($' + savings.toFixed(2) + ')');
            clonedSavingsTableRow.find('#OfferPriceTd').text('$' + offerPrice.toFixed(2));
            $('#SavingsMessageTable').append(clonedSavingsTableRow);
            $('#SavingsDetailsAnchor').show();
        }
        else $('#SavingsDetailsAnchor').hide();
    }

</script>

<script type="text/javascript" language="javascript">

    function AttachCheckBoxSelect() {
        //  debugger
        if ($(".select-table :checkbox :checked").length <= 0) {
            $('#RemoveSelectedButton').css({ "cursor": "default" });
            $('#RemoveSelectedButton').attr('src', '/App/Images/DeteletTest_disable.gif');
            $('#RemoveSelectedButton').attr('disabled', true);

        }
        else {
            $('#RemoveSelectedButton').css({ "cursor": "hand" });
            $('#RemoveSelectedButton').attr('src', '/App/Images/DeteletTest.gif');
            $('#RemoveSelectedButton').attr('disabled', false);
        }

        $(".select-table").find('.chkSelectAll').click(function () {
            if ($(this).is(':checked'))
                $(".select-table").find(".check-all").attr("checked", true);
            else
                $(".select-table").find(".check-all").attr("checked", false);
        });

        $(".select-table").find(".check-all").click(function () {
            if ($(this).is(':checked')) {
                var allCheckBoxChecked = true;
                $(".select-table").find(".check-all").each(function () {
                    if (!$(this).is(':checked'))
                        allCheckBoxChecked = false;
                });
                if (allCheckBoxChecked)
                    $(".select-table").find('.chkSelectAll').attr("checked", true);
            }
            else
                $(".select-table").find('.chkSelectAll').attr("checked", false);
        });

        $(".select-table :checkbox").click(function () {
            $('#RemoveSelectedButton').css({ "cursor": "default" });
            $('#RemoveSelectedButton').attr('src', '/App/Images/DeteletTest_disable.gif');
            $('#RemoveSelectedButton').attr('disabled', true);
            $(".select-table :checkbox").each(function () {
                if ($(this).is(':checked')) {
                    $('#RemoveSelectedButton').css({ "cursor": "hand" });
                    $('#RemoveSelectedButton').attr('src', '/App/Images/DeteletTest.gif');
                    $('#RemoveSelectedButton').attr('disabled', false);
                }
            });
        });
    }

</script>

<script type="text/javascript" language="javascript">

    function RecommendPackage(packages, currentPackageId, currentPackageTestIds, currentAddOnTestIds) {
        //Switching off for now - Bidhan / Yasir
        //return 0;
        var selectedPackage = null;
        if (currentPackageId > 0 && packages != null && packages.length > 0) {
            $.each(packages, function () {
                if (this.Id == currentPackageId) {
                    selectedPackage = this;
                    return;
                }
            });
        }
        if (selectedPackage != null)
            currentPackageTestIds = GetPackageTestIds(selectedPackage);
        else if (parseInt(currentPackageId) > 0 && selectedPackage == null && currentPackageTestIds != null && currentPackageTestIds.length > 0) {
            if (currentAddOnTestIds == null) currentAddOnTestIds = new Array();
            GetContainsFunction(currentAddOnTestIds);
            $.each(currentPackageTestIds, function () {
                if (currentAddOnTestIds.length == 0 || !currentAddOnTestIds.contains(this))
                    currentAddOnTestIds.push(this);
            });
            currentPackageId = 0;
            currentPackageTestIds = ClearArray(currentPackageTestIds);
        }
        else currentPackageTestIds = ClearArray(currentPackageTestIds);

        if (currentPackageTestIds != null && currentPackageTestIds.length > 0 && currentAddOnTestIds != null && currentAddOnTestIds.length > 0) {
            GetContainsFunction(currentPackageTestIds);
            var addOnTestsToBeRemoved = new Array();

            $.each(currentAddOnTestIds, function () {
                if (currentPackageTestIds.contains(this))
                    addOnTestsToBeRemoved.push(this);
            });
            if (addOnTestsToBeRemoved != null && addOnTestsToBeRemoved.length > 0)
                $.each(addOnTestsToBeRemoved, function () {
                    RemoveElementFromArray(currentAddOnTestIds, this);
                });
        }

        var selectedTestIds = new Array();

        if (currentPackageTestIds != null && currentPackageTestIds.length > 0) {
            $.each(currentPackageTestIds, function () {
                selectedTestIds.push(this);
            });
        }

        if (currentAddOnTestIds != null && currentAddOnTestIds.length > 0) {
            $.each(currentAddOnTestIds, function () {
                GetContainsFunction(selectedTestIds);
                if (selectedTestIds.length == 0 || !selectedTestIds.contains(this))
                    selectedTestIds.push(this);
            });
        }

        return selectedPackage != null ? selectedPackage.Id : 0;
    }

</script>

<script type="text/javascript" language="javascript">

    function SuggestBetterOption(offerPrice, selectedPackage, selectedPackageTests, selectedAddOnTests, packages) {
        var selectedTests = ConcatArrays(selectedPackageTests, selectedAddOnTests);

        if (selectedTests.length <= 0) return;
        if (packages != null && packages.length > 0 && selectedPackage != null && packages[0].Id == selectedPackage.Id) return;

        var suggestedPackage = null;
        var savings = 0.00;
        var remainingTestIds = new Array();
        if (packages != null) {
            $.each(packages, function () {
                if (selectedPackage == null || (selectedPackage.Id != this.Id)) {
                    var packageTestIds = GetPackageTestIds(this);
                    GetContainsFunction(packageTestIds);

                    var remainingTestsPrice = 0.00;
                    $.each(selectedTests, function () {
                        if (!packageTestIds.contains(this.Id))
                            remainingTestsPrice += parseFloat(this.OfferPrice);
                    });
                    if ((parseFloat(this.Price) + parseFloat(remainingTestsPrice)) < parseFloat(offerPrice)) {
                        suggestedPackage = this;
                        savings = (parseFloat(offerPrice) - (parseFloat(this.Price) + parseFloat(remainingTestsPrice))).toFixed(2);
                        return false;
                    }
                }
            });
        }
        if (suggestedPackage != null) {
            var additionalTestNames = new Array();
            var suggestedPackageTests = GetPackageTests(suggestedPackage);

            if (selectedTests != null && selectedTests.length > 0) {
                var selectedTestIds = GetTestIds(selectedTests);
                GetContainsFunction(selectedTestIds);
                $.each(suggestedPackageTests, function () {
                    if (!selectedTestIds.contains(this.Id))
                        additionalTestNames.push(this.Name);
                });
            }

            var suggestionMessage = 'If you purchase the ' + suggestedPackage.Name + ', you will save $' + savings;
            suggestionMessage += additionalTestNames.length > 0 ? ' and get ' + additionalTestNames.join(', ') + ' for FREE !!' : ' and get same set of test(s).';
            ShowRecommendationMessage(suggestionMessage);
        }
    }

</script>

<script type="text/javascript">
    $(document).ready(function () {
        if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>') {
            $('.view-test').show();
        }
        else {
          
            $('.view-test').show(); //.hide()
        }

        var decoded = $("<textarea/>").html($("#<%= EventAddressLabel.ClientID %>").html()).text();
        $("#<%= EventAddressLabel.ClientID %>").html(decoded);
     
       
    });
    var age = parseInt('<%= Age %>');
    function CheckPackageTestForAge(tests) {

        if (tests != null && tests.length > 0) {
            for (var index = 0; index < tests.length; index++) {
                var test = tests[index];

                if (test.MinAge != null && test.MinAge != 0 && test.MinAge > age) {
                    alert("Current selected package includes " + test.Name + " for which minimum age is " + test.MinAge);
                    return false;
                }

                if (test.MaxAge != null && test.MaxAge != 0 && test.MaxAge < age) {
                    alert("Current selected package includes " + test.Name + " for which maximum age is " + test.MaxAge);
                    return false;
                }
            }
        }
        return true;
    }

    function CheckTestForAge(test) {
        if (test != null) {

            if (test.MinAge != null && test.MinAge != 0 && test.MinAge > age) {
                alert("To purchase " + test.Name + " minimum age should be " + test.MinAge);
                return false;
            }

            if (test.MaxAge != null && test.MaxAge != 0 && test.MaxAge < age) {
                alert("To purchase " + test.Name + " maximum age should be " + test.MaxAge);
                return false;
            }
        }
        return true;
    }
</script>

<script type="text/javascript">

    function DisableForPhysicianPartnerCustomer() {
        //debugger;
        if ('<%= AllowPrequalifiedTestOnly %>' == '<%= Boolean.TrueString %>' && singleTestOverride != '<%=Boolean.TrueString %>') {
            $("#ViewPackagesTestsDiv input[type='radio'], #ViewPackagesTestsDiv input[type='checkbox']").attr("disabled", "disabled");
        }//else {
        //    $("#ViewPackagesTestsDiv input[type='radio'], #ViewPackagesTestsDiv input[type='checkbox']").removeAttr("disabled");
        //}
    }

    function DisableSelectedPackageTest() {

        if ('<%= AllowPrequalifiedTestOnly %>' == '<%= Boolean.TrueString %>' && singleTestOverride != '<%=Boolean.TrueString %>') {
            $("#ViewSelectedPackageAndTests input[type='radio'], #ViewSelectedPackageAndTests input[type='checkbox']").attr("disabled", "disabled");
            $("#ViewSelectedPackageAndTests #RemoveSelectedButton").hide();
        }
    }



</script>


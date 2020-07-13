<%@ Control Language="C#" AutoEventWireup="true" Inherits="Falcon.App.UI.App.UCCommon.UcChangePackage"
    CodeBehind="ucChangePackage.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/UCCommon/GiftCertificateApply.ascx" TagName="GCApply" TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/OrderItemCart.ascx" TagName="OrderItem" TagPrefix="ShoppingCart" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
<script language="javascript" type="text/javascript" src="/Scripts/jquery.unobtrusive-ajax.js"></script>
<script src="/Content/JavaScript/PreQualificationQuestion.js?v=<%= DateTime.Now.Ticks%>" type="text/javascript"></script>

<script language="javascript" type="text/javascript">

   
    var prefilledQuestions = '';
    var disQualifiedQuestionandAnswer = '';
    
    var isPrefilledQuestionsShow = false;

    function txtkeypress(evt) {
        return KeyPress_DecimalAllowedOnly(evt);
    }

    function formatAmount(num) {
        if (isNaN(parseFloat(num)))
        { num = '0.00'; }
        return parseFloat(num);

    }
    /* ************************************************** */

    function txtkeypress_NumericAlphanumeric(evt) {//debugger

        var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
        if (evt.shiftKey == false) {
            if ((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || (key >= 65 && key <= 90) || (key >= 96 && key <= 105)) {
                return true;
            }
        }
        else if (evt.shiftKey == true) {
            if ((key >= 65 && key <= 90)) {
                return true;
            }
        }
        return false;

    }

    function OpenCloseDiv(ddlpaymentmode_clientid) {
        var ddlpaymentmode = document.getElementById(ddlpaymentmode_clientid);
        if (ddlpaymentmode.selectedIndex == 0)
            return;

        var paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;

        document.getElementById('<%= this.bycreditcard.ClientID %>').style.display = 'none';
        document.getElementById('<%= this.bycheque.ClientID %>').style.display = 'none';
        document.getElementById('<%= this.byCreditCardOld.ClientID %>').style.display = 'none';
        document.getElementById('<%= this.byCash.ClientID %>').style.display = 'none';
        document.getElementById('<%= this.byECheck.ClientID %>').style.display = 'none';

        if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
            document.getElementById('<%= this.bycreditcard.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
            document.getElementById('<%= this.bycheque.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.Cash.PersistenceLayerId %>') {
            document.getElementById('<%= this.byCash.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.CreditCardOnFile_Value %>') {
            document.getElementById('<%= this.byCreditCardOld.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {
            document.getElementById('<%= this.byECheck.ClientID %>').style.display = 'block';
        }

    document.getElementById('<%= this.hfPaymentMode.ClientID %>').value = paymentmode;
    }

    function CheckPackageAndTestHAFTemplate(){
        try{

            //debugger;
            if( Validation())
            {
                
                var divCnfrmMsg = document.getElementById("divCnfrmMsg");
                var rBtnCnfrm = document.getElementById("<%=this.rBtnCnfrm.ClientID %>");

                if((divCnfrmMsg.style.display == "block" && rBtnCnfrm.rows[0].cells[0].childNodes[0].checked == true) || ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>' && Number($('#<%= hfamountpayable.ClientID %>').val()) < 0))
                {
                    
                    if(("<%= (long)CurrentOrgRole.GetSystemRoleId %>" == "<%= (long)Falcon.App.Core.Enum.Roles.Technician%>" ) || ("<%= (long)CurrentOrgRole.GetSystemRoleId %>" == "<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>" ))
                    {
                        if ($('#OrderChangedHiddenControl').val() != 'false')
                        {
                            var packageId = 0;
                            var testIds = null;

                            packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();                    
            
                            eval('testIds = [' + $("#TestIdsHiddenControl").val() + ']');

                            $.ajax({
                                url: '/Scheduling/AppointmentSlot/CheckPackageAndTestHafTemplate',
                                type: 'Post',
                                contentType: "application/json; charset=utf-8",
                                dataType: 'json',
                                data: "{'eventId' : <%= EventId.Value %> ,'customerId' : <%= CustomerId.Value %> , 'packageId' :" + packageId + ", 'testIds' : " + JSON.stringify(testIds) + "}",
                                success: function(result) {
                                    
                                    if (result != null && result.length > 0) {
                                        var message = "<ul style='padding-left:20px;'>";
                                        for (var i = 0; i < result.length; i++) {
                                            message = message +"<li>"+ result[i] + "</li>";
                                        }
                                        message = message + "</ul>";
                                        $("#test-Package-list").html(message);
                                        
                                        $("#regenerate-HAF-form-div-diaglog").dialog('open');
                                    } else {
                                        $("#<%=AdjustOrder_btn.ClientID%>").click();
                                    }
                                    
                                    //if (result != '' && result.length > 0) {
                                    //    alert("Please regenerate the bulk HAF file for the customer as the questions\nmight change because of addition/removal of " + result + " to customer's order");
                                    //}

                                    //__doPostBack('AdjustOrder', '');
                                },
                                error: function(xhr, errorType, exception) {
                                    alert("some exception occured");

                                    return false;
                                }
                            });
                        }
                        else if($('#<%= hfDisqualifedTest.ClientID %>').val()!="") {
                            $("#<%=AdjustOrder_btn.ClientID%>").click();
                        }
                        else {
                            return false;
                        }
                }else{
                    $("#<%=AdjustOrder_btn.ClientID%>").click();
                    }
                }   
            }
        }
        catch(e){
        
            alert("some exception occured");
        }

        return false;
    }

    function Validation() {        
        var originalPackagePrice = parseFloat($('#<%=hfCurrentPackagePrice.ClientID %>').val());
        var currentPackagePrice = parseFloat($('#<%=CurrentOrderPriceHiddenControl.ClientID %>').val());
        
        if (isDynamicScheduling == "<%= Boolean.TrueString %>" && (("<%= (long)CurrentOrgRole.GetSystemRoleId %>" != "<%= (long)Falcon.App.Core.Enum.Roles.Technician %>" && "<%= (long)CurrentOrgRole.GetSystemRoleId %>" != "<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner %>")  || currentPackagePrice < originalPackagePrice)) {//&& newScreeningTime > oldScreeningTime && newScreeningTime > selectedSlotInterval
            if (isSlotsAvailable == false) {
                alert("Since we donot have any slot to adjust the screening time of the new package availed. You will not be able to continue. Please contact your admin.");
                return false;
            }
            else if (isAppointmentSelected() == false) {
                alert("Please select appointment.");
                //Open select appointment model popup
                getSlotView();
                $("#appointment-div").dialog('open');
                return false;
            }
        } 
        
        if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>' && Number($('#<%= hfamountpayable.ClientID %>').val()) < 0) {
          
            if ($("textarea[id='Reason']").val() == '') {
                alert("Refund reason is required.");
                return false;
            }
            return true;
        }

        var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
        var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

        if (packageId == '0' && testIds == '0') {
            alert("Please select a Package or tests.");
            return false;
        }

        if (parseFloat($('#OfferPriceSpan').text()) < parseFloat('<%=MinimumPurchaseAmount %>')) {
            alert('The minimum price of the order should be ' + '<%=MinimumPurchaseAmount %>');
            return false;
        }

        if (!isRefund) {
            var ddlpaymentmode = document.getElementById('<%= ddlpaymentmode.ClientID %>');

            if (ddlpaymentmode != null && ddlpaymentmode.selectedIndex == 0 && ddlpaymentmode.disabled != true) {
                alert('Please select payment mode.');
                return false;
            }

            var paymentmode = '';
            paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;

            if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                var ddlCCType = document.getElementById("<%= this.ddlcardtype.ClientID %>");
                var txtCCNo = document.getElementById("<%= this.txtCardNo.ClientID %>");
                var txtExpirationDate = document.getElementById("<%= this.txtExpirationDate.ClientID %>");
                var txtSecurityNo = document.getElementById("<%= this.txtSecurityNum.ClientID %>");
                var txtCName = document.getElementById("<%= this.txtCardHolderName.ClientID %>");

                if ((checkDropDown(ddlCCType, "Credit Card Type") == false))
                    return false;

                if (isBlank(txtCCNo, "Credit Card Number"))
                    return false;

                if (isValidCreditCard(ddlCCType.options[ddlCCType.selectedIndex].text, txtCCNo.value) == false) {
                    alert('Invalid Credit Card format.');
                    ddlCCType.focus();
                    return false;
                }

                if (isBlank(txtCName, "Name on Card"))
                    return false;

                if (isBlank(txtExpirationDate, "Expiry Date"))
                    return false;
                if (!validateExpiryDate(txtExpirationDate, "Expiry Date"))
                    return false;
                if (isBlank(txtSecurityNo, "Security Number"))
                    return false;

                    
                var txtAddress1 = document.getElementById("<%= this.txtAddress1.ClientID %>");
                var txtCity = document.getElementById("<%= this.txtCity.ClientID %>");
                var ddlState = document.getElementById("<%= this.ddlstate.ClientID %>");
                var txtZip = document.getElementById("<%= this.txtZip.ClientID %>");

                if (isBlank(txtAddress1, "Address")) { return false; }
                if (checkLength(txtAddress1, 500, "Address")) { return false; }
                if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                if (isBlank(txtCity, "City for  Address")) { return false; }
                if (isBlank(txtZip, "Zip")) { return false; }
            }
            else if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
                if (isBlank(document.getElementById('<%= this.txtChequeNum.ClientID %>'), "Check Number")) { return false; }
                if (Validate_CheckForSpecialCharacters("<%= this.txtChequeNum.ClientID %>") == false) { alert('Please enter only alphanumeric characters'); return false; }
            }
            else if (paymentmode == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {
                var txtERoutingNo = document.getElementById("<%=this.txtERoutingNo.ClientID %>");
                var txtEAccountNo = document.getElementById("<%=this.txtEAccountNo.ClientID %>");
                var ddlEAccountType = document.getElementById("<%=this.ddlEAccountType.ClientID %>");
                var txtECheckNo = document.getElementById("<%=this.txtECheckNo.ClientID %>");
                var txtEBankName = document.getElementById("<%=this.txtEBankName.ClientID %>");
                var txtEAccHolderName = document.getElementById("<%=this.txtEAccHolderName.ClientID %>");

                if (isBlank(txtERoutingNo, "Routing No."))
                    return false;
                if (isBlank(txtEAccountNo, "Account No."))
                    return false;
                if (checkDropDown(ddlEAccountType, "Account Type") == false)
                    return false;
                if (isBlank(txtECheckNo, "Check No."))
                    return false;
                if (isBlank(txtEBankName, "Bank Name."))
                    return false;
                if (isBlank(txtEAccHolderName, "A/C Holder Name."))
                    return false;

                var txtEAddress1 = document.getElementById("<%= this.txtEAddress1.ClientID %>");
                var txtECity = document.getElementById("<%= this.txtECity.ClientID %>");
                var ddlEstate = document.getElementById("<%= this.ddlEstate.ClientID %>");
                var txtEZip = document.getElementById("<%= this.txtEZip.ClientID %>");

                if (isBlank(txtEAddress1, "Address")) { return false; }
                if (checkLength(txtEAddress1, 500, "Address")) { return false; }
                if (checkDropDown(ddlEstate, "State for  Address") == false) { return false; }
                if (isBlank(txtECity, "City for  Address")) { return false; }
                if (isInteger(txtEZip, "Zip") != true) { return false; }

            }
}

    var divCnfrmMsg = document.getElementById("divCnfrmMsg");
    var rBtnCnfrm = document.getElementById("<%=this.rBtnCnfrm.ClientID %>");
    var spOldPackage = document.getElementById("spOldPackage");
    var spNewPackage = document.getElementById("spNewPackage");

    var sppackagename = document.getElementById("<%=this.sppackagename.ClientID %>");

    if (divCnfrmMsg.style.display == "none") {
        rBtnCnfrm.rows[0].cells[1].childNodes[0].checked = true;
    }

    divCnfrmMsg.style.display = "block";
    divCnfrmMsg.style.visibility = "visible";

    spOldPackage.innerHTML = sppackagename.innerHTML;
    if(disqualifiedTest!="")
        document.getElementById("pDisqualifiedTest").style.display = 'block';
       
       
    if (divCnfrmMsg.style.display == "block" && rBtnCnfrm.rows[0].cells[0].childNodes[0].checked == true) {
            
        document.getElementById("spansave").style.display = 'none';
        document.getElementById("spnIndicator").style.visibility = 'visible';
        document.getElementById("spnIndicator").style.display = 'block';
        return true;
    }
    return false;
}
    
</script>
<script language="javascript" type="text/javascript">

    function SetValuesafterFailedPostBack() {
        OpenCloseDiv('<%= this.ddlpaymentmode.ClientID %>');

    }
</script>
<script type="text/javascript">
    
    var bookedSlotIds = null;
    if ($.trim('<%= BookedSlotIds %>').length > 0) {
        eval('bookedSlotIds = [' + '<%= BookedSlotIds %>' + ']');
    }

</script>
<script type="text/javascript" language="javascript">
    var oldScreeningTime = parseInt('<%= ScreeningTime %>');
    var isDynamicScheduling = '<%= IsDynamicScheduling %>';
    var selectedSlotInterval = parseInt('<%= SelectedSlotInterval %>');

    var newScreeningTime = 0;

    var callBackMethodAfterReleaseSlots = null;

    var isSlotsAvailable = true;

    function getScreeningTime() {//debugger;

        var hfIsNewAppoitmentSelected = $("#<%=hfIsNewAppoitmentSelected.ClientID %>");
        var packageId = parseInt($('#<%= PackageIdHiddenControl.ClientID %>').val());
        var testIds = null;

        if ($.trim($("#<%= IndependentTestIdsHiddenControl.ClientID %>").val()).length > 0 && $.trim($("#<%= IndependentTestIdsHiddenControl.ClientID %>").val()) != "0") {
            eval('testIds = [' + $("#<%= IndependentTestIdsHiddenControl.ClientID %>").val() + ']');
        }

        if (packageId > 0 || (testIds != null && testIds.length > 0)) {
            $.ajax({
                url: '/Scheduling/Online/GetScreeningTime',
                type: 'Post',
                cache: false,
                contentType: "application/json; charset=utf-8",
                dataType: 'html',
                data: "{'eventId' : <%= EventId.Value %>, 'packageId' :" + packageId + ", 'testIds' : " + JSON.stringify(testIds) + "}",
                success: function (result) {
                    //debugger;
                    var currentScreeningTime = parseInt(result);
                    if (isOrderChanged) {
                        if (newScreeningTime > 0 && hfIsNewAppoitmentSelected.val() == "<%= Boolean.TrueString %>") {
                            newScreeningTime = currentScreeningTime;
                            
                            callBackMethodAfterReleaseSlots = adjustAppointment;
                            releaseAppointment();
                        }
                        else {
                            newScreeningTime = currentScreeningTime;
                        }

                        if (hfIsNewAppoitmentSelected.val() == "<%= Boolean.FalseString %>")
                            adjustAppointment();
                    }
                    else {
                        if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
                            releaseAppointment();
                        }
                    }
                },
                error: function (arg1, arg2) {

                }
            });

        }
        else {
            newScreeningTime = 0;        
            if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
                releaseAppointment();
            }
        }

    }

    function adjustAppointment() {//debugger;
        var arr = null;
        if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
            eval('arr = [' + $("#<%= hfSlotIds.ClientID %>").val() + ']');
        }
    
        var hfIsNewAppoitmentSelected = $("#<%=hfIsNewAppoitmentSelected.ClientID %>");
        var packageId = parseInt($('#<%= PackageIdHiddenControl.ClientID %>').val());
        var testIds = null;

        if ($.trim($("#<%= IndependentTestIdsHiddenControl.ClientID %>").val()).length > 0) {
            eval('testIds = [' + $("#<%= IndependentTestIdsHiddenControl.ClientID %>").val() + ']');
        }
    
        $.ajax({
            url: '/Scheduling/AppointmentSlot/AdjustAppointment',
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: "{'eventId' : <%= EventId.Value %>, 'eventCustomerId' :<%= EventCustomerId %>, 'screeningTime' : " + newScreeningTime + ", 'selectedSlotIds' : " + JSON.stringify(arr)  + ", 'packageId' : " + packageId + ", 'testIds' : " + JSON.stringify(testIds) + "}",
            success: function (result) {
                //debugger;
                if (result.IsAdjusted) {
                    var slotString = "";

                    var count = 1;
                    $.each(result.Slots, function () {
                        if (count < result.Slots.length)
                            slotString += this.Id + ", ";
                        else
                            slotString += this.Id;
                        count++;
                    });

                    $("#<%= hfSlotIds.ClientID %>").val(slotString);
                    hfIsNewAppoitmentSelected.val("<%=Boolean.FalseString %>");
                    $("#ChangeAppointmentDiv").hide();
                    isSlotsAvailable = true;
                }
                else if (result.IsAdjusted == false && result.IsSlotsAvailable == true) {
                    callBackMethodAfterReleaseSlots = getSlotView;
                    //Release previously temporary booked slots.
                    //Book another appointment
                    releaseAppointment();
                    $("#appointment-div").dialog('open');
                    $("#ChangeAppointmentDiv").show();
                    isSlotsAvailable = true;
                }
                else {
                    callBackMethodAfterReleaseSlots = null;
                    releaseAppointment();
                    hfIsNewAppoitmentSelected.val("<%=Boolean.FalseString %>");
                    $("#ChangeAppointmentDiv").hide();
                    alert("Since we donot have any slot to adjust the screening time of the new package availed. You will not be able to continue. Please contact your admin.");
                    isSlotsAvailable = false;
                }
            },
            error: function (arg1, arg2) {
                alert("Some error occured while processing the request! Please try again.");
            }
        });
}

function releaseAppointment() {

    var hfIsNewAppoitmentSelected = $("#<%=hfIsNewAppoitmentSelected.ClientID %>");
    var arr = null;
    if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
        eval('arr = [' + $("#<%= hfSlotIds.ClientID %>").val() + ']');
    }

    $.ajax({
        url: '/Scheduling/AppointmentSlot/ReleaseAppointment',
        type: 'Post',
        contentType: "application/json; charset=utf-8",
        dataType: 'html',
        data: "{'selectedSlotIds' : " + JSON.stringify(arr) + "}",
        success: function (result) {
            $("#<%= hfSlotIds.ClientID %>").val("");
            hfIsNewAppoitmentSelected.val("<%=Boolean.FalseString %>");
            if (callBackMethodAfterReleaseSlots != null)
                callBackMethodAfterReleaseSlots();
        },
        error: function (arg1, arg2) {
            alert("Some error occured while processing the request! Please try again.");
        }
    });
}

function isAppointmentSelected() {
    if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
        return true;
    }

    return false;
}
</script>

<script type="text/javascript" language="javascript">
    var _appointmentTime = "";
    var isChangePackage = true;
    function getSlotView() {//debugger;        
        var arr = null;
        if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
            eval('arr = [' + $("#<%= hfSlotIds.ClientID %>").val() + ']');
        }
        
        var packageId = parseInt($('#<%= PackageIdHiddenControl.ClientID %>').val());
        var testIds = null;

        if ($.trim($("#<%= IndependentTestIdsHiddenControl.ClientID %>").val()).length > 0) {
            eval('testIds = [' + $("#<%= IndependentTestIdsHiddenControl.ClientID %>").val() + ']');
        }
        
        $.ajax({
            url: '/Scheduling/AppointmentSlot/Select',
            type: 'Post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'html',
            data: "{'eventId' : <%= EventId.Value %>, 'screeningTime' :" + newScreeningTime + ", 'selectedSlotIds' : " + JSON.stringify(arr) + ", 'packageId' : " + packageId + ", 'testIds' : " + JSON.stringify(testIds) + ", 'bookedSlotIds' : " + JSON.stringify(bookedSlotIds) +"}",
            success: function (result) {
                $("#time-slot-container").html(result);
                _bookedSlotIds = bookedSlotIds;
                _isChangePackage = isChangePackage;
                // debugger;
                _methodReffromParentForSuccessonSelectAppointment = onSuccessSelectAppointment;
                _methodReffromParentForSuccessonChangeAppointment = onSuccessChangeAppointment;
                _methodReffromParentForFailureonSelectAppointment = getSlotView;                
            },
            error: function (arg1, arg2) {

            }
        });
    }

    function onSuccessSelectAppointment(slots) {             
        var slotString = "";
        var count = 1;
        $.each(slots, function () {
            if (count < slots.length)
                slotString += this.Id + ", ";
            else
                slotString += this.Id;
            count++;
        });

        $("#<%= hfSlotIds.ClientID %>").val(slotString);
        //debugger;
        _appointmentTime = slots[0].StartTimeString;
        $("#<%=hfIsNewAppoitmentSelected.ClientID %>").val("<%=Boolean.TrueString %>");        
        getSlotView();        
    }

    function onSuccessChangeAppointment() {//debugger;
        _appointmentTime = "";      
        $("#<%=hfIsNewAppoitmentSelected.ClientID %>").val("<%=Boolean.FalseString %>");
        $("#<%= hfSlotIds.ClientID %>").val("");        
        getSlotView();
    }

    function appointmentDialogClose() {//debugger;
        $("#appointment-div").dialog('close');
    }

    function appointmentDialogOpen() {//debugger;
        getSlotView();
        $("#appointment-div").dialog('open');
    }
</script>
<script type="text/javascript" language="javascript">
    var isRefund = false;
    var isOrderChanged = false;
    var newExistingCouponAmt = 0.00;

    function SelectPackage() {
        newExistingCouponAmt = 0.00;
        $('#<%= PackageIdHiddenControl.ClientID %>').val($('#PackageIdHiddenControl').val());
        $('#<%=TestIdsHiddenControl.ClientID %>').val($('#TestIdsHiddenControl').val());
        $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val($('#IndependentTestIdsHiddenControl').val());
        $('#<%= CurrentOrderPriceHiddenControl.ClientID %>').val($('#OfferPriceSpan').text());
        $('#spNewPackage').text($('#PackageDescriptionHidden').val());

        if ($('#OrderChangedHiddenControl').val() == 'false')
            isOrderChanged = false;
        else
            isOrderChanged = true;

        ShowChangeOrderStatus();
        
        var originalPackagePrice = parseFloat($('#<%=hfCurrentPackagePrice.ClientID %>').val());
        var currentPackagePrice = parseFloat($('#<%=CurrentOrderPriceHiddenControl.ClientID %>').val());
        //debugger;
        if (isDynamicScheduling == "<%= Boolean.TrueString %>" && (("<%= (long)CurrentOrgRole.GetSystemRoleId %>" != "<%= (long)Falcon.App.Core.Enum.Roles.Technician %>" && "<%= (long)CurrentOrgRole.GetSystemRoleId %>" != "<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner %>")  || currentPackagePrice < originalPackagePrice))
            getScreeningTime();
    }



    function ShowChangeOrderStatus() {
        //debugger;
        AddOnsiteOption();
        AddECheckOption();
        AddCreditCardOption();
        AddCardonFileOption();

        var originalPackagePrice = parseFloat($('#<%=hfCurrentPackagePrice.ClientID %>').val());
        var currentPackagePrice = parseFloat($('#<%=CurrentOrderPriceHiddenControl.ClientID %>').val());

        var differenceInAmount = parseFloat((currentPackagePrice - originalPackagePrice));
        var hfcurrentcouponamount = $('#<%= hfcurrentcouponamount.ClientID %>');
        var totalOutstandingAmount = (parseFloat($('#<%=UnpaidAmountHiddenControl.ClientID %>').val()) + differenceInAmount + parseFloat(hfcurrentcouponamount.val())).toFixed(2);

        $('#<%= hfamountpayable.ClientID %>').val(totalOutstandingAmount);
        var isFailedPostBack = '<%=IsFailedPostBack %>';
        if (isFailedPostBack == "True")
            isOrderChanged = true;
        if (!isOrderChanged) {
            $('#<%= divChangePackage.ClientID %>').hide();
            $('#<%= divCancel.ClientID %>').show();
            return;
        }
        else
            $('#<%= divCancel.ClientID %>').hide();

        $('#<%= spamountpaid.ClientID %>').text("$" + $('#<%= PaidAmountHiddenControl.ClientID %>').val());

        $("#RefundRequestDiv").hide();
        $("#RefundRequestContentDiv").empty();
        $("#PaymentDiv").show();
        isRefund = false;

        if (isOrderChanged && totalOutstandingAmount > 0.00) {
            $('#<%= divChangePackage.ClientID %>').show();
            $('#<%= spchangeeffect.ClientID %>').text('Amount Owed : ');
            $('#<%= spchangeamount.ClientID %>').text('$' + totalOutstandingAmount);
            $('#<%= txtamount.ClientID %>').val(totalOutstandingAmount);
            $('#<%= ddlpaymentmode.ClientID %>').attr('disabled', false);
            $('#GCApplyContainerDiv').show();
        }
        else if (isOrderChanged && totalOutstandingAmount < 0.00) {
            if ('<%= IsProcessRequest %>' == '<%= bool.FalseString %>' && '<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>') {
                isRefund = true;
                LoadUiforRefundRequest(totalOutstandingAmount);
                $("#PaymentDiv").hide();
                $('#<%= divChangePackage.ClientID %>').show();
            }
            else {
                $('#<%= divChangePackage.ClientID %>').show();
                $('#<%= spchangeeffect.ClientID %>').text('Amount to Refund : ');
                $('#<%= spchangeamount.ClientID %>').text('$' + (totalOutstandingAmount * (-1)));
                $('#<%= txtamount.ClientID %>').val((totalOutstandingAmount * (-1)));
                $('#<%= ddlpaymentmode.ClientID %>').attr('disabled', false);
                $('#GCApplyContainerDiv').hide();
                RemoveOnsiteOption();
                RemoveECheckOption();
                RemoveCreditCardOption();

                if ($('#<%= IsValidCardHiddenFieldName %>').val() == '<%= Boolean.FalseString %>') {
                    RemoveCardonFileOption();
                }
                $("#InsurancePaymentModeDiv").hide();
            }
        }
        else if (isOrderChanged && totalOutstandingAmount == 0.00) {
            $('#<%= divChangePackage.ClientID %>').show();
            $('#<%= spchangeeffect.ClientID %>').text('Amount Owed : ');
            $('#<%= spchangeamount.ClientID %>').text('$' + totalOutstandingAmount);
            $('#<%= txtamount.ClientID %>').val(totalOutstandingAmount);
            $('#<%= ddlpaymentmode.ClientID %>').attr('disabled', true);
        }

    var isCouponApplied = $('#<%= hfIsAppliedCoupon.ClientID %>').val();
        var txtCouponCode = $("#<%= txtcoupon.ClientID %>");
        var existingCouponCode = $("#<%= ExistingCouponCodeHiddenControl.ClientID %>").val();

        if (isCouponApplied == "true" || txtCouponCode.val().length > 0) {
            if (txtCouponCode.val().length > 0)
                ApplyExistingCoupon(txtCouponCode.val());
            else if (isCouponApplied == "true")
                ApplyExistingCoupon(existingCouponCode);
        } 
        else
            checkTestCoveredByInsurance();

    }
    
</script>
<input type="hidden" runat="server" id="RefundRequestAmount" value="0.00" />
<script language="javascript" type="text/javascript">
    function LoadUiforRefundRequest(amount) {

        amount = (-1 * amount);
        var refundRequestAmount = $('#<%= RefundRequestAmount.ClientID%>').val();
        amount = amount - refundRequestAmount;

        $.ajax({ type: "GET",
            cache: false,
            dataType: "html", url: "/Finance/RefundRequest/Create?orderId=<%= OrderId %>&amount=" + amount + "&requestType=<%= (int)RefundRequestType.ChangePackage %>", data: '{}',
            success: function (result) {

                $("#RefundRequestDiv").show();
                $("#RefundRequestContentDiv").empty();
                $("#RefundRequestContentDiv").append(result);
            },
            error: function (a, b, c) { $("#RefundRequestDiv").hide(); alert('Some error loading the Request window. Please try opening the page again'); }
        });

    } 
    
</script>
<script type="text/javascript" language="javascript">

    var isOnSiteOptionRemoved = false;
    var isECheckOptionRemoved = false;
    var onsiteOptionText = '<%= (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId == (int)Falcon.App.Core.Enum.Roles.Technician || IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId == (int)Falcon.App.Core.Enum.Roles.NursePractitioner) ? PaymentType.PayLater_Text : PaymentType.Onsite_Text %>';
    var onsiteOptionValue = '<%= PaymentType.Onsite_Value %>';
    var eCheckOptionText = '<%= PaymentType.ElectronicCheck.Name %>';
    var eCheckOptionValue = '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>';


    function AddOnsiteOption() {
        if (isOnSiteOptionRemoved) {
            $('#<%=ddlpaymentmode.ClientID %>').append($('<option></option>').val(onsiteOptionValue).html(onsiteOptionText));
            isOnSiteOptionRemoved = false;
        }
    }

    function AddECheckOption() {
        if (isECheckOptionRemoved) {
            $('#<%=ddlpaymentmode.ClientID %>').append($('<option></option>').val(eCheckOptionValue).html(eCheckOptionText));
            isECheckOptionRemoved = false;
        }
    }

    function RemoveOnsiteOption() {
        if (!isOnSiteOptionRemoved) {
            var ddlpaymentmode = document.getElementById('<%= ddlpaymentmode.ClientID %>');
            var count = 0;
            for (count = 0; count < ddlpaymentmode.length; count++) {
                if (ddlpaymentmode.options[count].text == onsiteOptionText) {
                    isOnSiteOptionRemoved = true;
                    onStiteOptionText = ddlpaymentmode.options[count].text;
                    onStiteOptionValue = ddlpaymentmode.options[count].value;
                    ddlpaymentmode.options[count] = null;
                    isOnSiteOptionRemoved = true;
                    break;
                }
            }
        }
    }

    function RemoveECheckOption() {
        if (!isECheckOptionRemoved) {
            var ddlpaymentmode = document.getElementById('<%= this.ddlpaymentmode.ClientID %>');
            var count = 0;
            for (count = 0; count < ddlpaymentmode.length; count++) {
                if (ddlpaymentmode.options[count].text == eCheckOptionText) {
                    isECheckOptionRemoved = true;
                    eCheckOptionText = ddlpaymentmode.options[count].text;
                    eCheckOptionValue = ddlpaymentmode.options[count].value;
                    ddlpaymentmode.options[count] = null;
                    isECheckOptionRemoved = true;
                    break;
                }
            }
        }
    }

    function RemoveCreditCardOption() {
        $('#<%= ddlpaymentmode.ClientID %> option[value=<%= PaymentType.CreditCard.PersistenceLayerId %>]').attr("disabled", "disabled");
    }

    function RemoveCardonFileOption() { $('#<%= ddlpaymentmode.ClientID %> option[value=<%= PaymentType.CreditCardOnFile_Value %>]').attr("disabled", "disabled"); }

    function AddCreditCardOption() {
        $('#<%= ddlpaymentmode.ClientID %> option[value=<%= PaymentType.CreditCard.PersistenceLayerId %>]').attr("disabled", "");
    }

    function AddCardonFileOption() {
        $('#<%= ddlpaymentmode.ClientID %> option[value=<%= PaymentType.CreditCardOnFile_Value %>]').attr("disabled", "");
    }

</script>
<script type="text/javascript" language="javascript">

    var newCouponCode = "";
    var currentsignupmode = "<%=  (int)SignUpMode.Online %>";
    if ("<%= EventRegisteredBy.Equals(Falcon.App.Core.Enum.Roles.Customer)%>" == "<%= Boolean.TrueString%>")
        currentsignupmode = "<%= (int)SignUpMode.Online%>";
    else if ("<%= EventRegisteredBy.Equals(Falcon.App.Core.Enum.Roles.Technician)%>" == "<%= Boolean.TrueString%>" || "<%= EventRegisteredBy.Equals(Falcon.App.Core.Enum.Roles.NursePractitioner)%>" == "<%= Boolean.TrueString%>")
        currentsignupmode = "<%= (int)SignUpMode.Walkin%>";
    else if ("<%= EventRegisteredBy.Equals(Falcon.App.Core.Enum.Roles.CallCenterRep)%>" == "<%= Boolean.TrueString%>")
        currentsignupmode = "<%= (int)SignUpMode.CallCenter%>";

function ApplyExistingCoupon(couponCode) {//debugger;
    var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
    var testIds = $('#<%=IndependentTestIdsHiddenControl.ClientID %>').val();

    if (packageId == '0' && testIds == '0') {
        alert("Please select atlest one package or a test to avail the coupon.");
        return false;
    }

    var customerId = '<%=CustomerId %>';
    var currentPackagePrice = parseFloat($('#<%=CurrentOrderPriceHiddenControl.ClientID %>').val());

    var parameter = "{'couponCode':'" + couponCode + "'";
    parameter += ",'packageId':'" + packageId + "'";
    parameter += ",'addOnTestIds':'" + testIds + "'";
    parameter += ",'eventId':'" + $("#<%= EventIdHiddenControl.ClientID %>").val() + "'";
    parameter += ",'customerId':'" + customerId + "'";
    parameter += ",'signUpMode':'" + currentsignupmode + "'";
    parameter += ",'packageTestCost':'" + currentPackagePrice + "'}";

    var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/GetCoupon")%>';
    var successFunction = function (result) {
        newCouponCode = couponCode;
        ApplyCouponAmount(result.d);
    };
    var errorFunction = function() {
        alert('There was a problem retrieving the data, please try again later.');
    };
    InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
    return false;
}

function CouponValidation() {

    if (isBlank(document.getElementById("<%= this.txtcoupon.ClientID %>"), "Source Code "))
        return false;

    if (document.getElementById("ExistingCouponCodeInputHidden")) {
        if (document.getElementById("ExistingCouponCodeInputHidden").value == trim(document.getElementById("<%= this.txtcoupon.ClientID %>").value)) {
            alert("This coupon has already been applied. Please apply different code");
            return false;
        }
    }
    var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
    var testIds = $('#<%=IndependentTestIdsHiddenControl.ClientID %>').val();

    if (packageId == '0' && testIds == '0') {
        alert("Please select atlest one package or a test to avail the coupon.");
        return false;
    }

    var customerId = '<%=CustomerId %>';
    var txtCouponCode = $("#<%= txtcoupon.ClientID %>");
    var currentPackagePrice = parseFloat($('#<%=CurrentOrderPriceHiddenControl.ClientID %>').val());
    var hfEventID = $("#<%= EventIdHiddenControl.ClientID %>");

    var parameter = "{'couponCode':'" + txtCouponCode.val() + "'";
    parameter += ",'packageId':'" + packageId + "'";
    parameter += ",'addOnTestIds':'" + testIds + "'";
    parameter += ",'eventId':'" + hfEventID.val() + "'";
    parameter += ",'customerId':'" + customerId + "'";
    parameter += ",'signUpMode':'" + currentsignupmode + "'";
    parameter += ",'packageTestCost':'" + currentPackagePrice + "'}";

    var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/GetCoupon")%>';
    var successFunction = function (result) {
        newCouponCode = txtCouponCode.val();
        ApplyCouponAmount(result.d);
    };
    var errorFunction = function() {
        alert('There was a problem retrieving the data, please try again later.');
    };
    InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
    return false;
}

function ApplyCouponAmount(result) {

    var originalPackagePrice = parseFloat($('#<%=hfCurrentPackagePrice.ClientID %>').val());
    var currentPackagePrice = parseFloat($('#<%=CurrentOrderPriceHiddenControl.ClientID %>').val());

    var differenceInAmount = parseFloat((currentPackagePrice - originalPackagePrice));
    var valtodisplay = 0.00;
                
    document.getElementById('<%= this.divChangePackage.ClientID %>').style.display = "block";

    var model = result;

    var hfcouponid = document.getElementById('<%= this.hfcouponid.ClientID %>');
    var hfcouponamount = document.getElementById('<%= this.hfcouponamount.ClientID %>');
    var hfcouponapplied = document.getElementById('<%= this.hfcouponapplied.ClientID %>');
    var hfcurrentcouponamount = document.getElementById('<%= this.hfcurrentcouponamount.ClientID %>');
    var spcouponamount = document.getElementById('<%= this.spcouponadjust.ClientID %>');

    if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
        alert(model.FeedbackMessage.Message);
        hfcouponid.value = "";
        hfcouponapplied.value = false;
        //SetValuesafterFailedPostBack();
        var isCouponAppliedBefore = $('#<%= hfIsAppliedCoupon.ClientID %>').val();

        if (isCouponAppliedBefore == "true")
            hfcouponamount.value = newExistingCouponAmt;
        else
            hfcouponamount.value = 0.00;

        var spcouponamount = document.getElementById('<%= this.spcouponadjust.ClientID %>');
        valtodisplay = -1 * parseFloat(hfcouponamount.value);
        if (parseFloat(hfcurrentcouponamount.value) > 0.00) {
            valtodisplay = parseFloat(hfcurrentcouponamount.value) - parseFloat(hfcouponamount.value);
        }


        if (isCouponAppliedBefore == "true") {
            $("#<%= txtcoupon.ClientID %>").val('');
            if (valtodisplay <= 0)
                spcouponamount.innerHTML = "$" + (-1 * valtodisplay).toFixed(2) + " (" + $("#<%= ExistingCouponCodeHiddenControl.ClientID %>").val() + ")";
            else if (valtodisplay > 0)
                spcouponamount.innerHTML = "(-) $" + (valtodisplay).toFixed(2) + " (" + $("#<%= ExistingCouponCodeHiddenControl.ClientID %>").val() + ")";
    }
    else {
        spcouponamount.innerHTML = "$ 0.00";
    }
}
else {

    var isCouponAppliedBefore = $('#<%= hfIsAppliedCoupon.ClientID %>').val();
        if (newCouponCode != $("#<%= ExistingCouponCodeHiddenControl.ClientID %>").val())
            alert('Coupon applied successfully.');
        else {
            newExistingCouponAmt = formatAmount(model.DiscountApplied).toFixed(2);
        }
        if (isCouponAppliedBefore == "true") { $("#<%= txtcoupon.ClientID %>").val(''); }
        hfcouponamount.value = formatAmount(model.DiscountApplied).toFixed(2);
        hfcouponid.value = model.SourceCodeId;
        hfcouponapplied.value = true;

        valtodisplay = -1 * parseFloat(hfcouponamount.value);
        if (parseFloat(hfcurrentcouponamount.value) > 0.00) {
            valtodisplay = parseFloat(hfcurrentcouponamount.value) - parseFloat(hfcouponamount.value);
        }

        if (valtodisplay <= 0)
            spcouponamount.innerHTML = "$" + (-1 * valtodisplay).toFixed(2) + " (" + newCouponCode + ")";
        else if (valtodisplay > 0)
            spcouponamount.innerHTML = "(-) $" + (valtodisplay).toFixed(2) + " (" + newCouponCode + ")";
    }
    var totalOutstandingAmount = (parseFloat($('#<%=UnpaidAmountHiddenControl.ClientID %>').val()) + differenceInAmount + valtodisplay).toFixed(2);
    $('#<%= hfamountpayable.ClientID %>').val(totalOutstandingAmount);

    isRefund = false;
    if (totalOutstandingAmount > 0.00) {
        $('#<%= divChangePackage.ClientID %>').show();
        $('#<%= spchangeeffect.ClientID %>').text('Amount Owed : ');
        $('#<%= spchangeamount.ClientID %>').text('$' + totalOutstandingAmount);
        $('#<%= txtamount.ClientID %>').val(totalOutstandingAmount);
        $('#<%= ddlpaymentmode.ClientID %>').attr('disabled', false);
        $('#GCApplyContainerDiv').show();
        AddOnsiteOption();
        AddECheckOption();
        checkTestCoveredByInsurance();
    }
    else if (totalOutstandingAmount < 0.00) {
        if ('<%= IsProcessRequest %>' == '<%= bool.FalseString %>' && '<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>') {
            isRefund = true;
            LoadUiforRefundRequest(totalOutstandingAmount);
            $("#PaymentDiv").hide();
            $('#<%= divChangePackage.ClientID %>').show();
        }
        else {
            $('#<%= divChangePackage.ClientID %>').show();
            $('#<%= spchangeeffect.ClientID %>').text('Amount to Refund : ');
            $('#<%= spchangeamount.ClientID %>').text('$' + (totalOutstandingAmount * (-1)));
            $('#<%= txtamount.ClientID %>').val((totalOutstandingAmount * (-1)));
            $('#<%= ddlpaymentmode.ClientID %>').attr('disabled', false);
            $('#GCApplyContainerDiv').hide();
            RemoveOnsiteOption();
            RemoveECheckOption();
            $("#InsurancePaymentModeDiv").hide();
        }
    }
    else if (totalOutstandingAmount == 0.00) {
        $('#<%= divChangePackage.ClientID %>').show();
        $('#<%= spchangeeffect.ClientID %>').text('Amount Owed : ');
        $('#<%= spchangeamount.ClientID %>').text('$' + totalOutstandingAmount);
        $('#<%= txtamount.ClientID %>').val(totalOutstandingAmount);
        $('#<%= ddlpaymentmode.ClientID %>').attr('disabled', true);
    }
}
$(document).ready(function() { $("form :input").attr("autocomplete", "off"); });
</script>
<div class="mainbody_outer">
    <input type="hidden" id="hfSlotIds" runat="server" />
    <input type="hidden" id="hfIsNewAppoitmentSelected" runat="server" value="False" />
    <asp:HiddenField ID="PackageIdHiddenControl" runat="server" />
    <asp:HiddenField ID="TestIdsHiddenControl" runat="server" />
    <asp:HiddenField ID="IndependentTestIdsHiddenControl" runat="server" />
    <asp:HiddenField ID="CurrentOrderPriceHiddenControl" runat="server" />
    <asp:HiddenField ID="PaidAmountHiddenControl" runat="server" />
    <asp:HiddenField ID="UnpaidAmountHiddenControl" runat="server" />
    <asp:HiddenField ID="EventIdHiddenControl" runat="server" />
    <asp:HiddenField ID="ExistingCouponCodeHiddenControl" runat="server" />

    <asp:HiddenField ID="hfQuestionAnsTestId" runat="server" />
    <asp:HiddenField ID="hfDisqualifedTest" runat="server" />

    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_top_body">
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="5px" />
                </p>
                <span class="orngheadtxt_heading">Adjust Order <span runat="server" id="spcustomername"></span><span runat="server" id="spcustomerid"></span></span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="2px" />
            </p>
            <p class="graylinefull_common">
                <img src="/App/Images/specer.gif" width="1px" height="1px" />
            </p>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" />
            </p>
            <div class="divmainbody_cd">
                <div class="grayboxtop_cl">
                    <p class="grayboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="6" alt="" />
                    </p>
                    <p class="grayboxheader_cl">
                        Current Registration Summary
                    </p>
                    <div class="lgtgraybox_cl">
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" />
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Event (ID:<span runat="server" id="speventid"></span>):
                            </span><span class="ttxtnowidthnormal_default"><span runat="server" id="sphostname"></span>, <span runat="server" id="spaddress"></span></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Appointment Time:</span> <span class="ttxtnowidthnormal_default">
                                <span runat="server" id="speventdate"></span>, <span runat="server" id="spapptime"></span></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Order:</span> <span class="ttxtnowidthnormal_default"
                                runat="server" id="sppackagename"></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Cost:</span> <span class="ttxtnowidthnormal_default"
                                runat="server" id="sppackagecost">XXX</span> <span class="titletextnowidth_default">| </span><span class="titletextnowidth_default">Source Code:</span> <span class="ttxtnowidthnormal_default"
                                    runat="server" id="spcoupon"></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Payment Details:</span> <span runat="server" id="sppaymentdetails"
                                class="ttxtnowidthnormal_default"><span><< None >></span>,Or <span><< PAID with payment
                                    details >></span> </span>
                        </p>
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" />
                        </p>
                    </div>
                    <p class="grayboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="4" />
                    </p>
                </div>
            </div>
            <div class="main_area_bdrnone">
                <div class="pgnosymbolvsmall_common">
                    <img src="/App/Images/page1symbolvsmall.gif" />
                </div>
                <div class="orngheadtxt16_common">
                    Place Order                    
                </div>
                <div style="float: left; padding-left: 50px; padding-top: 10px; display: none;" id="ChangeAppointmentDiv">
                    <a href="javascript:void(0);" onclick="appointmentDialogOpen();"><b>Select/Edit Appointment</b></a>
                </div>
            </div>
            <div class="main_area_bdrnone" style="width: 700px">
                <ShoppingCart:OrderItem ID="ItemCartControl" runat="server" />
            </div>
            <div id="divCancel" class="buttonrow_bottom_common" runat="server">
                <span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="imgCancelBefore" ImageUrl="~/App/Images/cancel-btn.gif"
                        OnClick="imgCancelBefore_Click" />
                </span>
            </div>
            <div class="main_area_bdrnone" runat="server" style="display: none;" id="divChangePackage">
                <%--********************* Apply Coupon *********************--%>
                <div class="main_area_bdrnone">
                    <div id="Div2" class="pgnosymbolvsmall_common" runat="server">
                        <img src="/App/Images/page2symbolvsmall.gif" />
                    </div>
                    <div class="orngheadtxt16_common">
                        <span runat="server" id="spApplySCodeTitle">Apply Source Code</span>(Optional)?
                    </div>
                </div>
                <p class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="38px" height="10px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="inputfldnowidth_default">
                                <asp:TextBox ID="txtcoupon" runat="server" CssClass="inputf_def" Width="150px"></asp:TextBox>
                            </span><span class="button_con_nowidth">
                                <asp:ImageButton runat="server" ID="ibtnapplycoupon" OnClientClick="return CouponValidation();"
                                    ImageUrl="~/App/Images/apply-btn.gif" />
                            </span></span>
                </p>
                <div style="float: left;" id="PaymentDiv">
                    <div class="main_area_bdrnone">
                        <div>
                            <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
                        </div>
                        <div id="Div4" class="pgnosymbolvsmall_common" runat="server">
                            <img src="/App/Images/page3symbolvsmall.gif" />
                        </div>
                        <div class="orngheadtxt16_common">
                            Payment Adjustment
                        </div>
                    </div>
                    <p class="main_area_bdrnone">
                        <span class="ttxtnowidthnormal_default">
                            <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                                <span class="titletext1a_default">Amount Paid:</span> <span class="ttxtnowidthnormal_default"
                                    runat="server" id="spamountpaid"></span></span>
                    </p>
                    <p class="main_area_bdrnone">
                        <span class="ttxtnowidthnormal_default">
                            <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                                <span class="titletext1a_default">Source Code Adjustment:</span> <span class="ttxtnowidthnormal_default"
                                    runat="server" id="spcouponadjust">$0.00 </span></span>
                    </p>
                    <p class="main_area_bdrnone">
                        <span class="ttxtnowidthnormal_default">
                            <img src="/App/Images/specer.gif" width="40px" height="20px" />
                        </span><span class="ttxtnowidthnormal_default"><span class="titletext1a_default "
                            runat="server" id="spchangeeffect">Amount Owed:</span> <span class="ttxtnowidthnormal_default total-amount-span"
                                runat="server" id="spchangeamount"></span></span>
                    </p>
                    <p class="main_area_bdrnone">
                        <span class="ttxtnowidthnormal_default">
                            <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                                <span class="titletext1a_default">Payment Method:</span> <span class="ttxtnowidthnormal_default">
                                    <asp:DropDownList ID="ddlpaymentmode" runat="server" CssClass="inputf_def cancel-other-payment-mode"
                                        Width="150px">
                                    </asp:DropDownList>
                                </span></span>
                    </p>
                    <div class="main_area_bdrnone">
                        <div>
                            <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
                        </div>
                        <div id="Div3" class="pgnosymbolvsmall_common" runat="server">
                            <img src="/App/Images/page4symbolvsmall.gif" />
                        </div>
                        <div class="orngheadtxt16_common">
                            Payment Details
                        </div>
                    </div>
                    <div class="sourcecode_cc" id="InsurancePaymentModeDiv">
                        <div>
                            <b>Do you have insurance?</b>
                            <input type="radio" onclick="insurancePaymentMode(true)" name="eligibility" id="EligibilityYesRadioButton" />Yes
                            <input type="radio" title="No" onclick="insurancePaymentMode(false)" name="eligibility" id="EligibilityNoRadioButton" />No
                        </div>
                        <div class="insurance-payment-detail" style="display: none;">
                            <span>Amount covered by insurance:</span>
                            <span id="insurance-amount"></span>
                        </div>
                        <div class="insurance-payment-detail" style="display: none;">
                            <span>Co Pay:</span>
                            <span id="copay-amount"></span>
                        </div>
                        <input type="hidden" id="EligibilityIdHiddenField" runat="server" value="0" />
                        <input type="hidden" id="ChargeCardIdHiddenField" runat="server" value="0" />
                        <input type="hidden" id="InsuranceAmountHiddenField" runat="server" value="0" />
                        <input type="hidden" id="CoPayAmountHiddenField" runat="server" value="0" />
                        <input type="hidden" id="IsTestCoveredByInsuranceHiddenField" runat="server" value="False" />
                        <input type="hidden" id="ExistingChargeCardId" runat="server" value="0" />
                    </div>
                    <div id="GCApplyContainerDiv" class="main_area_bdrnone">
                        <uc1:GCApply ID="GCApply" runat="server" />
                    </div>
                    <div class="main_area_bdrnone">
                        <div class="ttxtnowidthnormal_default">
                            <img src="/App/Images/specer.gif" width="28px" height="20px" />
                        </div>
                        <div class="ttxtnowidthnormal_default other-payment-mode-detail">
                            <div id="bycreditcard" runat="server" style="float: left; width: 680px; display: none;">
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:DropDownList runat="server" ID="ddlcardtype" Width="140px" CssClass="inputf_def">
                                        </asp:DropDownList>
                                    </span><span class="titletxt_popup_pd">Credit Card No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtCardNo" MaxLength="16" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox></span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputf_def" Width="105px"
                                            MaxLength="7"></asp:TextBox>
                                    </span><span class="titletxt_popup_pd">Security No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtSecurityNum" TextMode="Password" runat="server" CssClass="inputf_def"
                                            Width="80px" MaxLength="4"></asp:TextBox></span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Card Holder<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtCardHolderName" runat="server" CssClass="inputf_def" Width="105px"></asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Address<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox></span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Country<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:DropDownList ID="ddlcountry" runat="server" Width="140px" CssClass="inputf_def">
                                        </asp:DropDownList>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:DropDownList runat="server" ID="ddlstate" Width="140px" CssClass="inputf_def ddl-states">
                                        </asp:DropDownList>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox runat="server" ID="txtCity" Width="100px" CssClass="inputf_def auto-search-city">
                                        </asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_def" Width="70px"></asp:TextBox></span>
                                </p>
                            </div>
                            <div id="byCreditCardOld" runat="server" style="float: left; width: 680px; display: none;">
                                <p>
                                    <img src="/App/Images/specer.gif" width="700px" height="5px" />
                                </p>
                                <p class="fline_chngepack">
                                    <img src="/App/Images/specer.gif" width="1px" height="1px" />
                                </p>
                                <p>
                                    <img src="/App/Images/specer.gif" width="700px" height="5px" />
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd"><b>Credit Card Type:</b></span> <span runat="server"
                                        id="spcctype" class="inputconleft_popup_pd"></span><span class="titletxt_popup_pd"><b>Credit Card No:</b></span> <span runat="server" id="spccnumber" class="inputconright_popup_pd"></span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd"><b>Expiration Date:</b></span> <span runat="server"
                                        id="spexpdate" class="inputconleft_popup_pd"></span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd"><b>Card Holder:</b></span> <span runat="server" id="spcardholder"
                                        class="inputconleft_popup_pd"></span>
                                </p>
                            </div>
                            <div id="bycheque" runat="server" style="float: left; width: 680px; display: none;">
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Bank Name:</span> <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtBankName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox>
                                    </span><span class="titletxt1_regcust">A/C Holder:</span> <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtAccHolderName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Type of Account:</span> <span class="inputconleft_popup_pd">
                                        <asp:DropDownList runat="server" ID="ddlaccounttype" Width="110px" CssClass="inputf_def">
                                        </asp:DropDownList>
                                    </span><span class="titletxt1_regcust">Account No:</span> <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtAccountNum" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Routing No:</span> <span class="inputconleft_popup_pd">
                                        <asp:TextBox runat="server" ID="txtRoutingNum" Width="110px" CssClass="inputf_def">
                                        </asp:TextBox>
                                    </span><span class="titletxt1_regcust">Check No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtChequeNum" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox>
                                    </span>
                                </p>
                            </div>
                            <div id="byCash" runat="server" style="float: left; width: 680px; display: none;">
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Enter Amount:</span> <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtamount" runat="server" CssClass="inputf_def" Width="100px" ReadOnly="true"></asp:TextBox>
                                    </span>
                                </p>
                            </div>
                            <div id="byECheck" runat="server" style="float: left; width: 680px; display: none;">
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Routing No:<span class="reqiredmark"><sup>*</sup></span></span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtERoutingNo" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                    </span><span class="titletxt1_regcust">Account No:<span class="reqiredmark"><sup>*</sup></span></span>
                                    <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtEAccountNo" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Account Type:<span class="reqiredmark"><sup>*</sup></span></span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:DropDownList runat="server" ID="ddlEAccountType" Width="135px" CssClass="inputf_def">
                                        </asp:DropDownList>
                                    </span><span class="titletxt1_regcust">Check No:<span class="reqiredmark"><sup>*</sup></span></span>
                                    <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtECheckNo" runat="server" CssClass="inputfield_ccrep" Width="120px"
                                            MaxLength="20"></asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Bank Name:<span class="reqiredmark"><sup>*</sup></span></span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtEBankName" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                    </span><span class="titletxt1_regcust">A/C Holder:<span class="reqiredmark"><sup>*</sup></span></span>
                                    <span class="inputconright_popup_pd">
                                        <asp:TextBox ID="txtEAccHolderName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Address<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtEAddress1" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox></span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Country<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:DropDownList ID="ddlEcountry" runat="server" Width="140px" CssClass="inputf_def">
                                        </asp:DropDownList>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:DropDownList runat="server" ID="ddlEstate" Width="140px" CssClass="inputf_def ddl-states">
                                        </asp:DropDownList>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox runat="server" ID="txtECity" Width="135px" CssClass="inputf_def auto-search-e-city">
                                        </asp:TextBox>
                                    </span>
                                </p>
                                <p class="ccdiv_common">
                                    <span class="titletxt_popup_pd">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                                    <span class="inputconleft_popup_pd">
                                        <asp:TextBox ID="txtEZip" runat="server" CssClass="inputf_def" Width="70px"></asp:TextBox></span>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="main_area_bdrnone" style="display: none;" id="RefundRequestDiv">
                    <div style="float: left;">
                        <div class="pgnosymbolvsmall_common">
                            <img src="/App/Images/page3symbolvsmall.gif" />
                        </div>
                        <div class="orngheadtxt16_common">
                            Refund Requests
                        </div>
                    </div>
                    <div id="RefundRequestContentDiv" style="clear: both; float: left;">
                        <img src="/App/Images/indicator.gif" alt="" />
                        Loading Request Window
                    </div>
                </div>
                <div class="main_area_bdrnone" id="ButtonsDiv">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="2px" />
                    </p>
                    <p class="graylinefull_common">
                        <img src="/App/Images/specer.gif" width="1px" height="1px" />
                    </p>
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="2px" />
                    </p>
                    <div id="divCnfrmMsg" style="float: right; width: 350px; display: none; visibility: hidden;">
                        <div style="float: left; border: solid 1px #ddd; padding: 5px; background-color: #f8f8f8">
                            <div id="divPackageInfo">
                                <p style="float: left; width: 300px; padding-right: 20px">
                                    <span style="float: left; width: 110px;"><b>Old Order:</b></span> <span style="float: left; width: 190px;"><span id="spOldPackage"></span></span>
                                </p>
                                <p style="float: left; width: 300px; padding-right: 20px">
                                    <span style="float: left; width: 110px;"><b>New Order:</b></span> <span style="float: left; width: 190px;"><span id="spNewPackage"></span></span>
                                </p>
                                <p style="float: left; width: 300px; padding-right: 20px;">
                                    <span style="float: left; width: 110px;"><b>Disqualified Test:</b></span> <span style="float: left; width: 190px;"><span id="spDisqualifiedtest">N/A</span></span>
                                </p>
                            </div>
                        </div>
                        <p style="float: right; width: 300px; padding-right: 20px">
                            <span style="float: left;">Are you sure to change the Order</span> <span style="float: left;">
                                <asp:RadioButtonList ID="rBtnCnfrm" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </span>
                        </p>
                    </div>
                    <div class="buttonrow_bottom_common">
                        <span class="buttoncon4_default" id="spansave">
                            <asp:ImageButton runat="server" ID="ibtnchangepackage" ImageUrl="~/App/Images/change-package-btn.gif"
                                OnClientClick="return CheckPackageAndTestHAFTemplate();" />
                        </span><span class="buttoncon4_default" style="float: right; visibility: hidden; display: none;"
                            id="spnIndicator">
                            <img src="/App/Images/indicator.gif" alt="" />
                        </span><span class="buttoncon_default">
                            <asp:ImageButton runat="server" ID="ibtncancel" ImageUrl="~/App/Images/cancel-btn.gif"
                                OnClick="ibtncancel_Click" />
                        </span>
                    </div>
                    <div style="display: none">
                        <asp:ImageButton runat="server" ID="AdjustOrder_btn" OnClick="ibtnchangepackage_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="appointment-div" title="Select Appointment" style="min-height: 50px; width: 60%;">
        <div style="width: 95%; float: left; margin-bottom: 10px;">
            The screening time of the package availed by you  does not fit in the slot booked for the event. You need to reschedule the appointment.
        </div>
        <div style="width: 80%; float: left;" id="time-slot-container">
        </div>
    </div>

    <div id="insurance-eligibility-div-dialog">
    </div>

    <div id="regenerate-HAF-form-div-diaglog">
        <div style="padding: 5px;">Please regenerate the bulk HAF file for the customer as the questions might change because of addition/removal of following Package/Test to customer's order.</div>
        <div id="test-Package-list" style="padding: 5px;"></div>
    </div>
</div>
<%-- **************************** ALL HIDDEN FIELDS ************************** --%>
<asp:HiddenField runat="server" ID="hfCurrentPackagePrice" Value="0.00" />
<asp:HiddenField runat="server" ID="hfamountpayable" Value="0.00" />
<%--<asp:HiddenField runat="server" ID="hfpaidamount" Value="0.00" />--%>
<asp:HiddenField runat="server" ID="hfcouponid" Value="0" />
<asp:HiddenField runat="server" ID="hfcouponamount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfcouponapplied" Value="false" />
<asp:HiddenField runat="server" ID="hfIsAppliedCoupon" Value="false" />
<asp:HiddenField runat="server" ID="hfAppliedCouponPercentage" Value="false" />
<asp:HiddenField runat="server" ID="hfAppliedCouponValue" Value="0.00" />
<asp:HiddenField runat="server" ID="hfAppliedMinPurchaseAmount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfAppliedCouponAmount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfAppliedCouponID" Value="0" />
<asp:HiddenField runat="server" ID="hfcurrentcouponamount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfPaymentMode" Value="" />
<asp:HiddenField runat="server" ID="hfPackageCost" Value="0.00" />
<asp:HiddenField runat="server" ID="hfAppliedCouponDiscountTypePackageWise" Value="false" />
<asp:HiddenField ID="hfstate" runat="server" />
<asp:HiddenField ID="hfEstate" runat="server" />
<asp:HiddenField ID="hfCardTypeId" runat="server" />
<%-- ************************************************************************* --%>
<div class="saveWaitAnimationnew" style="display: none">
</div>
<div id="div_preQualificationQuestion" title="Pre Qualification Test Questions" style="display: none; background: #fff; padding: 10px">
</div>
<script type="text/javascript">
    function checkTestCoveredByInsurance() {
        //debugger;
        var packageId = parseInt($('#<%= PackageIdHiddenControl.ClientID %>').val());
        var testIds = null;

        if ($.trim($("#<%= IndependentTestIdsHiddenControl.ClientID %>").val()).length > 0) {
            eval('testIds = [' + $("#<%= IndependentTestIdsHiddenControl.ClientID %>").val() + ']');
        }
            
        var parameter = "{'eligibilityId':'" + $("#<%= EligibilityIdHiddenField.ClientID%>").val() + "'"; 
        parameter += ",'eventId':'" + <%= EventId.Value %> + "'";
        parameter += ",'packageId':'" + packageId + "'"; 
        parameter += ",'addOnTestIds':" + JSON.stringify(testIds) + "}";  
            
        $.ajax({
            url: '/Scheduling/Insurance/CheckTestCoveredByInsurance',
            type: 'Post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'html',
            data: parameter,
            success: function(result) {
                //debugger;
                $('#<%=IsTestCoveredByInsuranceHiddenField.ClientID %>').val(result);
                if (result == "<%=Boolean.TrueString %>") {
                    $("#InsurancePaymentModeDiv").show();
                    onCloseEligibilityDialog();
                } 
                else {
                    $("#InsurancePaymentModeDiv").hide();
                    //$("#EligibilityNoRadioButton").attr("checked", true);
                    //$("#EligibilityYesRadioButton").attr("checked", false);
                    //insurancePaymentMode(false);
                    $("#<%= InsuranceAmountHiddenField.ClientID%>").val(0);
                    $("#<%= CoPayAmountHiddenField.ClientID%>").val(0);
                    calculateInsuranceAmount();
                }
            },
            error: function(arg1, arg2) {

            }
        });

        
    }
    
    function calculateAmount() { //debugger;
        var originalPackagePrice = parseFloat($('#<%=hfCurrentPackagePrice.ClientID %>').val());
        var currentPackagePrice = parseFloat($('#<%=CurrentOrderPriceHiddenControl.ClientID %>').val());

        var differenceInAmount = parseFloat((currentPackagePrice - originalPackagePrice));

        var hfcouponamount = $("#<%= hfcouponamount.ClientID%>");
        var hfcurrentcouponamount = $("#<%= hfcurrentcouponamount.ClientID%>");
        var valtodisplay = 0.00;
        
        valtodisplay = -1 * parseFloat(hfcouponamount.val());
        if (parseFloat(hfcurrentcouponamount.val()) > 0.00) {
            valtodisplay = parseFloat(hfcurrentcouponamount.val()) - parseFloat(hfcouponamount.val());
        }

        var totalOutstandingAmount = (parseFloat($('#<%=UnpaidAmountHiddenControl.ClientID %>').val()) + differenceInAmount + valtodisplay);
        
        totalOutstandingAmount = (totalOutstandingAmount - insuranceAmount + copayamount).toFixed(2);
            
        $("#<%= hfamountpayable.ClientID %>").val(totalOutstandingAmount);
        $('#<%= spchangeamount.ClientID %>').text('$' + totalOutstandingAmount);
        $('#<%= txtamount.ClientID %>').val(totalOutstandingAmount);
        
        if (totalOutstandingAmount == 0.00) {
            $('#<%= divChangePackage.ClientID %>').show();            
            $('#<%= ddlpaymentmode.ClientID %>').attr('disabled', true);
        }
    }
</script>
<script type="text/javascript">
    var insuranceAmount = 0;
    var copayamount = 0;
    function calculateInsuranceAmount() {
        //debugger;
        insuranceAmount = (parseFloat(formatAmount($("#<%= InsuranceAmountHiddenField.ClientID%>").val())));
        copayamount = (parseFloat(formatAmount($("#<%= CoPayAmountHiddenField.ClientID%>").val())));
            
        var value = parseFloat($('#<%= hfamountpayable.ClientID %>').val());
            
        if (insuranceAmount > 0) {
            if (isNaN(value))
                value = 0;

            if (value <= insuranceAmount) {
                insuranceAmount = value;
                    
                $("#<%= InsuranceAmountHiddenField.ClientID%>").val(insuranceAmount);
                    
                $('.other-payment-mode-detail').hide();
                $('#GCApplyContainerDiv').hide();
            }
            else {
                $('.other-payment-mode-detail').show();
                $('#GCApplyContainerDiv').show();
            }
        }
        else if (value > 0) {
            $('.other-payment-mode-detail').show();
            $('#GCApplyContainerDiv').show();
        }
        calculateAmount();
    }
        
    function insurancePaymentMode(hasInsurance) {
        //debugger;
        if (hasInsurance) {
            $("#insurance-eligibility-div-dialog").dialog("open");
            checkEligibility();
        } else {
            $("#<%= EligibilityIdHiddenField.ClientID%>").val(0);
            $("#<%= ChargeCardIdHiddenField.ClientID%>").val(0);
            $("#<%= InsuranceAmountHiddenField.ClientID%>").val(0);
            $("#<%= CoPayAmountHiddenField.ClientID%>").val(0);
            $(".insurance-payment-detail").hide();
            calculateInsuranceAmount();
        }
    }
        
    function setCardDetails(cardDetails) {
        //debugger;
        $("#<%= txtCardHolderName.ClientID%>").val(cardDetails.NameOnCard);

        var expiryDate = "";
        if (cardDetails.ExpirationDate != null) {
            var parts = cardDetails.ExpirationDate.split("/");
            if (parts[0].length == 1)
                expiryDate = "0" + cardDetails.ExpirationDate;
            else 
                expiryDate = cardDetails.ExpirationDate;
        }
        $("#<%= txtExpirationDate.ClientID%>").val(expiryDate);

        $("#<%= txtCardNo.ClientID%>").val(cardDetails.Number);
        $("#<%= txtSecurityNum.ClientID%>").val(cardDetails.CVV);
        $("#<%= ddlcardtype.ClientID%> option[value=" + cardDetails.TypeId + "]").attr("selected", true);
    }

    function saveEligibilityInfo(eligibilityId, chargeCardId, cardDetails) {
        //debugger;
        $("#<%= EligibilityIdHiddenField.ClientID%>").val(eligibilityId);
        $("#<%= ChargeCardIdHiddenField.ClientID%>").val(chargeCardId);
        if (eligibilityId > 0 && chargeCardId > 0) {
            setCardDetails(cardDetails);
        }
    }

    function getEligibilityDetail() {
        //debugger;
        var packageId = parseInt($('#<%= PackageIdHiddenControl.ClientID %>').val());
        var testIds = null;

        if ($.trim($("#<%= IndependentTestIdsHiddenControl.ClientID %>").val()).length > 0) {
            eval('testIds = [' + $("#<%= IndependentTestIdsHiddenControl.ClientID %>").val() + ']');
        }
            
        var parameter = "{'eligibilityId':'" + $("#<%= EligibilityIdHiddenField.ClientID%>").val() + "'"; 
        parameter += ",'eventId':'" + <%= EventId.Value %> + "'";
        parameter += ",'packageId':'" + packageId + "'"; 
        parameter += ",'addOnTestIds':" + JSON.stringify(testIds) + "}";  
            
        $.ajax({
            url: '/Scheduling/Insurance/GetInsuranceDetail',
            type: 'Post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: parameter,
            success: function(result) {
                //debugger;
                $("#<%= InsuranceAmountHiddenField.ClientID%>").val(result.AmountCovered);
                $("#<%= CoPayAmountHiddenField.ClientID%>").val(result.CoPayAmount);
                    
                $("#insurance-amount").html("$ " + result.AmountCovered.toFixed(2));
                $("#copay-amount").html("$ " + result.CoPayAmount.toFixed(2));
                    
                $(".insurance-payment-detail").show();
                    
                calculateInsuranceAmount();
            },
            error: function(arg1, arg2) {

            }
        });
    }
        
    function onCloseEligibilityDialog() {
        //debugger;
        var eligibilityId = parseInt($("#<%= EligibilityIdHiddenField.ClientID%>").val());
        var chargeCardId = parseInt($("#<%= ChargeCardIdHiddenField.ClientID%>").val());
        
        if (eligibilityId <= 0 || chargeCardId <= 0) {
            $("#EligibilityNoRadioButton").attr("checked", true);
            $("#EligibilityYesRadioButton").attr("checked", false);
            insurancePaymentMode(false);
        } else {
            $("#EligibilityNoRadioButton").attr("checked", false);
            $("#EligibilityYesRadioButton").attr("checked", true);
            getEligibilityDetail();
        }
            
        if ($("#insurance-eligibility-div-dialog").dialog("isOpen") == true) {
            $("#insurance-eligibility-div-dialog").dialog("close");
        }
    }
        
    function closeEligibilityDialog() {
        if ($("#insurance-eligibility-div-dialog").dialog("isOpen") == true) {
            $("#insurance-eligibility-div-dialog").dialog("close");
        }
    }
        
    function checkEligibility() {
        $("#insurance-eligibility-div-dialog").html("<div style='width:90%; margin: 10px auto; text-align: center; padding: 30px 0px;'> <img src='/App/Images/loading.gif' alt=''> Loading.... </div>");
            
        $.ajax({
            url: '/Scheduling/Insurance/Edit',
            type: 'Post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'html',
            data: "{'chargeCardId': " + $("#<%= ExistingChargeCardId.ClientID%>").val() + "}",
            success: function(result) {
                $("#insurance-eligibility-div-dialog").html(result);
                setSuccessandCloseMethod(saveEligibilityInfo, closeEligibilityDialog);
            },
            error: function(arg1, arg2) {

            }
        });
    }

</script>
<script type="text/javascript" language="javascript">
    var states;
    $(document).ready(function() {
	    
        states=<%= GetStates() %>;
        
        BindSateDropDown(states);
        BindESateDropDown(states);
        $('#<%=ddlcountry.ClientID %>').bind("change", function () { BindSateDropDown(states); });
        $('#<%=ddlEcountry.ClientID %>').bind("change", function () { BindESateDropDown(states); });
	    
        $('.auto-search-city').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: $('.ddl-states option:selected').val()
        });

        $('.ddl-states').change(function() {
            $('.auto-search-city').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('.ddl-states option:selected').val()
            });
            SetState();
            SetEState();
        });

        $('.mask-phone').mask("(999)-999-9999");

        $('.auto-search-e-city').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByPrefixText")%>',
            type: "POST",
            data: "prefixText"
        });

        $('#appointment-div').dialog({ autoOpen: false, hide: 'slide', width: 650, height: 450, modal: true, buttons: { 'Close': function () { appointmentDialogClose(); } } });
        
        $('#regenerate-HAF-form-div-diaglog').dialog({ autoOpen: false, hide: 'slide', width: 550, height: 'auto', modal: true, buttons: { 'Close': function () { $("#regenerate-HAF-form-div-diaglog").dialog("close"); } } });

        $("#regenerate-HAF-form-div-diaglog").bind('dialogclose', function() { $("#<%=AdjustOrder_btn.ClientID%>").click(); });

        if($("#<%=hfIsNewAppoitmentSelected.ClientID %>").val()== "<%=Boolean.TrueString %>")
        {
            $("#ChangeAppointmentDiv").show();
        }
        
        $("#insurance-eligibility-div-dialog").dialog({ width: 650, autoOpen: false, title: 'Check Eligibility', modal: true, resizable: false, draggable: true });
        $("#insurance-eligibility-div-dialog").bind('dialogclose', function() { onCloseEligibilityDialog(); });
            
        if ($('#<%=IsTestCoveredByInsuranceHiddenField.ClientID %>').val() == '<%=Boolean.FalseString %>') {
            $("#InsurancePaymentModeDiv").hide();
        } else {
            $("#InsurancePaymentModeDiv").show();
            onCloseEligibilityDialog();
        }
       
    });
    
</script>
<script type="text/javascript" language="javascript">

    function BindSateDropDown(stateList) {//debugger;
        $('#' + '<%=ddlstate.ClientID %> >option').remove();

        if (stateList.length > 0) {
            $('#' + '<%=ddlstate.ClientID %>').append($('<option></option>').val('0').html('Select State'));
            for (var i = 0; i < stateList.length; i++) {
                if (stateList[i].CountryId == $('#' + '<%=ddlcountry.ClientID %>').val())
                    $('#' + '<%=ddlstate.ClientID %>').append($('<option></option>').val(stateList[i].Id).html(stateList[i].Name));
            }
        }
        else {
            $('#' + '<%=ddlstate.ClientID %>').append($('<option></option>').val('0').html('No State Found'));
        }
        if ($('#<%=hfstate.ClientID %>').val() != '') {
            $("#<%= ddlstate.ClientID %> option:contains('" + $('#<%=hfstate.ClientID %>').val() + "')").first().attr('selected', true);
        }
    }

    function SetState() {
        $('#<%=hfstate.ClientID %>').val($('#<%=ddlstate.ClientID %> option:selected').text());
    }


    function BindESateDropDown(stateList) {//debugger;
        $('#' + '<%=ddlEstate.ClientID %> >option').remove();

        if (stateList.length > 0) {
            $('#' + '<%=ddlEstate.ClientID %>').append($('<option></option>').val('0').html('Select State'));
            for (var i = 0; i < stateList.length; i++) {
                if (stateList[i].CountryId == $('#' + '<%=ddlEcountry.ClientID %>').val())
                    $('#' + '<%=ddlEstate.ClientID %>').append($('<option></option>').val(stateList[i].Id).html(stateList[i].Name));
            }
        }
        else {
            $('#' + '<%=ddlEstate.ClientID %>').append($('<option></option>').val('0').html('No State Found'));
        }
        if ($('#<%=hfEstate.ClientID %>').val() != '') {
            $("#<%= ddlEstate.ClientID %> option:contains('" + $('#<%=hfEstate.ClientID %>').val() + "')").first().attr('selected', true);
        }
    }

    function SetEState() {//debugger;
        $('#<%=hfEstate.ClientID %>').val($('#<%=ddlEstate.ClientID %> option:selected').text());
    }
    
</script>
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
        
        if(prefilledQuestions == "")
            GetEventCustomerQuestionAnswer();
       
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
            
            if (prefilledQuestions == "") {
                $.ajax({
                    url: '/CallCenter/CallQueue/GetEventCustomerQuestionAnswer',
                    type: 'GET',
                    cache: false,
                    data: { customerId: '<%= CustomerId.Value %>' }
                }).done(function (data) {
                    AnswerFilled(data);
                });
            }
            else {
                AnswerFilled(prefilledQuestions);
            }
           
            $('#div_preQualificationQuestion').dialog('open');
            $(".saveWaitAnimationnew").hide();
        });
    }
    var resultObject;
    var disqualifiedTest = '';

    var isMammoQualified = false;

    $(document).ready(function () {
        $('#div_preQualificationQuestion').dialog({
            autoOpen: false, modal: true, width: 550, height: 260, closeOnEscape: false, open: function (event, ui) {
                $(".ui-dialog-titlebar-close", ui.dialog | ui).hide();
            }, buttons: {
                'Save':  function () {
                       
                    resultObject = CommonFunctionOfDisqualified();
                        
                    if (resultObject.isComplete == false) {
                        alert("You have to attempt all Questions.");
                        return;
                    }
                        
                    if (resultObject.isComplete) {
                       
                        SaveDisqualifedTest();

                        //questionAnsTestId = '';
                        prefilledQuestions = $('#<%= hfQuestionAnsTestId.ClientID %>').val();
                        // $('#div_preQualificationQuestion').dialog('close');
                    }
                }
            }
        });

    });
    
    function ResetAnswerIfQuestionRemoved(removedTestId) {
        if (prefilledQuestions != "" && prefilledQuestions.indexOf(removedTestId) > 0) {
            prefilledQuestions = "";
            isDisqualified = "";
            $('#<%= hfDisqualifedTest.ClientID %>').val("");
            $('#<%= hfQuestionAnsTestId.ClientID %>').val("");
        }
    }
   
    function SaveDisqualifedTest()
    {
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
            EventId: '<%= EventId.Value %>',
            QuestionAnswerTestIds: resultObject.answerStr,
            DisqualifiedTests: disqualifedTest
        };
        
        if(disqualifedTest == "")
            isMammoQualified = true;
        else 
            isMammoQualified = false;
        //debugger;
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
                    success: function(result) {
                        if (result != null && result != '') {
                            dependentTestId = result;
                            RemoveSingleTest(testId, result);
                            questionAnsTestId = '';
                            $('#div_preQualificationQuestion').dialog('close');

                            if (disqualifedTest != '') {
                                alert("You are not eligible for " + $(".testName").html() + ".");
                            }
                        } else {
                            RemoveSingleTest(testId,'');
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

    function GetEventCustomerQuestionAnswer() {
        $.ajax({
            url: '/CallCenter/CallQueue/GetEventCustomerQuestionAnswer',
            type: 'GET',
            async: false,
            data: { customerId: '<%= CustomerId.Value %>' },
                    success: function (data) {
                        if(data!='error')
                        {
                            prefilledQuestions = data;
                        }
                    }
               });
            }
</script>

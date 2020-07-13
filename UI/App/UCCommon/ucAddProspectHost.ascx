<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_ucAddProspectHost"
    CodeBehind="ucAddProspectHost.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Sales.Enum" %>
<%@ Register Src="~/App/UCCommon/ucMiniAddNewContact.ascx" TagName="ucMiniAddNewContact"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryUI="true" IncudeJQueryAutoComplete="true"
    IncludeJQueryMaskInput="true" IncludeJQueryThickBox="true" />
<style type="text/css">
    /*---------- bubble tooltip -----------*/a.tt
    {
        position: relative;
        z-index: 24;
        color: #287AA8;
        font-weight: normal;
        text-decoration: underline;
    }
    a.tt span
    {
        display: none;
    }
    /*background:; ie hack, something must be changed in a for ie to execute it*/a.tt:hover
    {
        z-index: 25;
        color: #ff6600;
    }
    a.tt:hover span.tooltip
    {
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
    }
    a.tt:hover span.top
    {
        display: block;
        padding: 30px 8px 0;
        background: url(/App/Images/bubble.gif) no-repeat top;
    }
    a.tt:hover span.middle
    {
        /* different middle bg for stretch */
        display: block;
        padding: 0 8px;
        background: url(/App/Images/bubble_filler.gif) repeat bottom;
        color: #000;
        text-decoration: none;
    }
    a.tt:hover span.bottom
    {
        display: block;
        padding: 3px 8px 10px;
        color: #ff6600;
        background: url(/App/Images/bubble.gif) no-repeat bottom;
    }
</style>
<style type="text/css">
    /*common classes for same layout */.divmain
    {
        float: left;
        width: 751px;
        margin-top: 5px;
    }
    .divmain p
    {
        float: left;
        width: 720px;
        padding-left: 32px;
    }
    .divrow
    {
        float: left;
        width: 720px;
        padding-left: 32px;
    }
    .divmain .grdrow
    {
        float: left;
        width: 715px;
        padding-left: 32px;
    }
    .divmain .row
    {
        float: left;
        width: 720px;
        padding-left: 32px;
    }
    .divmain .btnrow
    {
        float: left;
        width: 720px;
        padding-left: 32px;
    }
    .divmain .btnrow .btns
    {
        float: right;
        padding-right: 5px;
    }
    .divmain .row label
    {
        float: left;
        width: 180px;
        margin-right: 5px;
        padding-top: 4px;
        font-weight: bold;
        color: #000;
    }
    .divmain .row input
    {
        float: left;
    }
    .divmain .nrow
    {
        float: left;
        width: 720px;
        padding-left: 32px;
    }
    .divmain .nrowp
    {
        float: left;
        width: 720px;
        padding-top: 4px;
        padding-left: 32px;
    }
    .divmain .row label sup
    {
        color: red;
    }
    .divmain p .ttxt
    {
        float: left;
        width: 180px;
        margin-right: 5px;
        padding-top: 4px;
        font-weight: bold;
        color: #000;
    }
    .divmain p .label sup
    {
        color: red;
    }
    .divmain p .inputl
    {
        float: left;
        width: 255px;
        margin-right: 5px;
    }
    .divmain p .inputr
    {
        float: left;
        width: 180px;
    }
    .divmain p .inputd
    {
        float: left;
        width: 100px;
    }
    .divmain p img
    {
        float: left;
        padding: 5px 0px 0px 10px;
    }
    .smltxt
    {
        float: left;
        padding-top: 5px;
        font: normal 7pt arial;
        font-style: italic;
    }
    .headrgt_lnk
    {
        float: right;
        padding-top: 4px;
    }
    .subhead
    {
        float: left;
        width: 750px;
        margin-top: 5px;
    }
    .subhead img
    {
        float: left;
        margin-right: 5px;
    }
    .smalltxt
    {
        float: left;
        font-size: 7pt;
        color: #666;
    }
    .left
    {
        float: left;
    }
    .inputf_def
    {
        border: 1px solid #7F9DB9;
        background-color: #fff;
        z-index: -5;
        font: normal 12px arial;
        color: #333;
        padding: 2px;
    }
    .btn_def
    {
        float: right;
        width: 57px;
        height: 32px;
        padding-right: 5px;
    }
    /*Host Page specific classes */.txtinput180px
    {
        float: left;
        width: 185px;
        margin-right: 45px;
        font-weight: bold;
        color: #000;
    }
    .txtinput300px
    {
        float: left;
        width: 300px;
        font-weight: bold;
        color: #000;
    }
    .txtinput200px
    {
        float: left;
        width: 200px;
        font-weight: bold;
        color: #000;
    }
    .orngtxt_madd
    {
        font-weight: bold;
        color: #F37C00;
        float: left;
        width: 150px;
        padding-top: 5px;
    }
    .orngtxtchkbox
    {
        float: left;
        padding-top: 5px;
        margin-right: 5px;
    }
    .txtinput140px
    {
        float: left;
        width: 140px;
        margin-right: 30px;
        font-weight: bold;
        color: #000;
    }
    .txtinput140pxnm
    {
        float: left;
        width: 140px;
        font-weight: bold;
        color: #000;
    }
    .hiptxt
    {
        float: right;
        width: 135px;
        padding-right: 4px;
        margin-top: 4px;
    }
    .greybox_anp
    {
        float: left;
        width: 500px;
        padding: 10px;
        background-color: #eee;
        border: solid 1px #e6e6e6;
    }
    .greybox_anp .row
    {
        float: left;
        width: 480px;
        font-weight: bold;
        padding: 0px;
    }
    .txtinput480px
    {
        float: left;
        width: 458px;
        font: bold 12px arial;
        color: #000;
        padding-left: 22px;
    }
    .errorbox
    {
        float: left;
        width: 100%;
        border: solid 1px #eee;
    }
    .Pt-large
    {
        padding-top: 8px;
    }
    .preimghdr
    {
        float: left;
        width: 641px;
        background: #f5f5f5;
        padding: 2px;
        border: solid 1px #ccc;
        border-bottom: 0;
    }
    .preimg
    {
        float: left;
        width: 635px;
        border: solid 1px #ccc;
        padding: 5px;
        overflow-x: scroll;
    }
    .preimg .brow
    {
        float: left;
        width: 635px;
        background: #f5f5f5;
    }
    .preimg_small
    {
        float: left;
        width: 260px;
        border-bottom: solid 1px #ccc;
        padding: 5px;
    }
    .mainimgdiv
    {
        width: 270px;
        float: left;
    }
    .mainimgdiv .inrdiv
    {
        width: 270px;
        height: 200px;
        float: left;
        border: solid 1px #ccc;
        disply: block;
    }
</style>
<script type="text/javascript">

    function slideSwitch(imgToShow, activetr) {

        $(".next-img-navigator").hide();
        $(".previous-img-navigator").hide();

        activetr.addClass('last-active');

        imgToShow.css({ opacity: 0.0 })
            .addClass('active')
            .animate({ opacity: 1.0 }, 1000, function () {
                activetr.removeClass('active last-active');
            });

        SortVisibility(imgToShow);
    }

    function FetchNext() {
        var $active = $('.slideshow div.active');

        if ($active.length == 0) $active = $('.slideshow div:last');

        // use this to pull the images in the order they appear in the markup
        var $next = FindNext($active);

        if ($active.html() == $next.html())
        { return; }

        slideSwitch($next, $active);
    }

    function FindNext(activeDiv) {
        var $next = $('.slideshow div:last');
        if (activeDiv.parent('td').parent('tr').next().length > 0) {
            $next = activeDiv.parent('td').parent('tr').next().find('div');
        }

        return $next;
    }

    function FindPrevious(activeDiv) {
        var $prev = $('.slideshow div:first');

        if (activeDiv.parent('td').parent('tr').prev().length > 0) {
            $prev = activeDiv.parent('td').parent('tr').prev().find('div');
        }

        return $prev;
    }

    function FetchPrevious() {
        var $active = $('.slideshow div.active');

        if ($active.length == 0) $active = $('.slideshow div:first');

        var $prev = FindPrevious($active);

        if ($active.html() == $prev.html())
        { return; }

        slideSwitch($prev, $active);
    }

    function SortVisibility(currentDiv) {
        var nextDiv = FindNext(currentDiv);
        var prevDiv = FindPrevious(currentDiv);

        $(".next-img-navigator").show();
        $(".previous-img-navigator").show();

        if (nextDiv.html() == currentDiv.html()) {
            $(".next-img-navigator").hide();
        }

        if (prevDiv.html() == currentDiv.html()) {
            $(".previous-img-navigator").hide();
        }
    }

</script>
<style type="text/css">
    /*** set the width and height to match your images **/
    .slideshow
    {
        position: relative;
        height: 150px;
        width: 260px;
        text-align: center;
    }
    
    .slideshow div
    {
        position: absolute;
        z-index: 8;
        opacity: 0.0;
        width: 260px;
    }
    
    .slideshow div IMG
    {
        width: 150px;
    }
    
    .slideshow div.active
    {
        z-index: 10;
        opacity: 1.0;
    }
    
    .slideshow div.last-active
    {
        z-index: 9;
    }
</style>
<script type="text/javascript" src="../JavascriptFiles/actb.js"></script>
<script type="text/javascript" src="../JavascriptFiles/common.js"></script>
<script src="/App/JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>
<script language="javascript" type="text/javascript">

    function FeeRequires() {

        var rbtnFeeRequired = document.getElementById("<%=this.rbtnFeeRequired.ClientID %>");
        var divFee = document.getElementById("<%=this.divFee.ClientID %>");

        var txtFacilitiesFee = document.getElementById("<%=this.txtFacilitiesFee.ClientID %>");
        var chkPaymentMethod = document.getElementById("<%=this.chkPaymentMethod.ClientID %>");
        var rbtnDepositsRequired = document.getElementById("<%=this.rbtnDepositsRequired.ClientID %>");
        var txtAmount = document.getElementById("<%=this.txtAmount.ClientID %>");
        var spnDepositeAmount = document.getElementById("<%=this.spnDepositeAmount.ClientID %>");

        if (rbtnFeeRequired.rows[0].cells[0].childNodes[0].checked == true) {
            divFee.style.display = "block";
        }
        else {

            txtFacilitiesFee.value = "";
            chkPaymentMethod.rows[0].cells[0].childNodes[0].checked = false;
            chkPaymentMethod.rows[0].cells[1].childNodes[0].checked = false;
            rbtnDepositsRequired.rows[0].cells[1].childNodes[0].checked = true;
            spnDepositeAmount.style.display = "none";
            txtAmount.value = "";
            divFee.style.display = "none";

        }
    }

    function ConfirmContactDelete() {
        var answer = confirm("Are you sure you want to delete this contact? ")

        return answer;
    }

    function GridFMasterCheck() {
        Grid_MasterCheckBoxClick("<%= this.dgFranchiseeList.ClientID %>");
    }

    function GridFChildCheck() {
        Grid_ChildCheckBoxClick("<%= this.dgFranchiseeList.ClientID %>");
    }

    function ValidateInputs() {

        var HostProspect = 'Prospect Name';

        if (document.getElementById('<%= this.hfViewType.ClientID %>').value == 'host')
            HostProspect = 'Host Name';

        if (isBlank(document.getElementById('<%= this.txtOrgName.ClientID %>'), HostProspect))
            return false;

        if (document.getElementById('<%= this.hfViewType.ClientID %>').value == 'host') {
            if (isBlank(document.getElementById('<%= this.txtaddress1Billing.ClientID %>'), 'Address'))
                return false;

            if (isBlank(document.getElementById('<%= this.txtcityBilling.ClientID %>'), 'City for Host'))
                return false;

            if (checkDropDown(document.getElementById('<%= this.ddlstateBilling.ClientID %>'), "State for Host") == false)
            { return false; }

            if (isBlank(document.getElementById('<%= this.txtzipBilling.ClientID %>'), 'Zip for host'))
                return false;

            var chkMailingAddress = document.getElementById("<%=this.chkMailingAddress.ClientID %>");
            if (chkMailingAddress.checked == true) {
                if (isBlank(document.getElementById('<%= this.txtaddress1Mailing.ClientID %>'), 'Mailing Address '))
                    return false;

                if (isBlank(document.getElementById('<%= this.txtcityMailing.ClientID %>'), 'City for mailing address'))
                    return false;

                if (checkDropDown(document.getElementById('<%= this.ddlstateMailing.ClientID %>'), "State for mailing address ") == false)
                { return false; }

                if (isBlank(document.getElementById('<%= this.txtzipMailing.ClientID %>'), 'Zip for mailing address'))
                    return false;
            }

            if (document.getElementById('<%= this.txtcphoneoffice.ClientID %>').value == '(___)-___-____') {
                alert('Phone cannot left blank ');
                document.getElementById('<%= this.txtcphoneoffice.ClientID %>').focus();
                return false;
            }

            if (isBlank(document.getElementById('<%= this.txtcphoneoffice.ClientID %>'), 'Phone Main'))
                return false;

            if (!checkDropDown(document.getElementById('<%= this.ddlHostType.ClientID %>'), 'Host Type'))
                return false;


            //var chkPaymentMethod = document.getElementById("<%=this.chkPaymentMethod.ClientID %>");
            var rbtnFeeRequired = document.getElementById("<%=this.rbtnFeeRequired.ClientID %>");
            if (rbtnFeeRequired.rows[0].cells[0].childNodes[0].checked == true) {
                if (isBlank(document.getElementById('<%= this.txtFacilitiesFee.ClientID %>'), 'Host Facilities Fee'))
                    return false;
            }

            //In case of Franchisor it is not visible.
            if ($("#<%= this.HostFacilityContainerDiv.ClientID %>:visible").length > 0) {
                var checkedHostConfirmationRadioButton = $('#<%=HostConfirmationRadioButtonList.ClientID %> input:checked')
                if (checkedHostConfirmationRadioButton.length == 0) {
                    alert('Please select an option for "How have you verified the above information?"');
                    return false;
                }
            }
        }

        if ((document.getElementById('<%= this.txtEmail.ClientID %>')).value != '') {
            if (validateEmail(document.getElementById('<%= this.txtEmail.ClientID %>'), "Email") != true) {
                return false;
            }
        }

        var radioFollowAction = document.getElementById("<%=this.radioFollowAction.ClientID %>");
        if (radioFollowAction.checked == true) {
            var chkboxCall = document.getElementById("<%=this.chkboxCall.ClientID %>");
            var chkboxMeeting = document.getElementById("<%=this.chkboxMeeting.ClientID %>");
            var chkboxTask = document.getElementById("<%=this.chkboxTask.ClientID %>");

            var txtCallSubject = document.getElementById("<%=this.txtCallSubject.ClientID %>");
            var txtCallStartDate = document.getElementById("<%=this.txtCallStartDate.ClientID %>");
            //var txtCallStartTime=document.getElementById("<%=this.txtCallStartTime.ClientID %>");
            var txtMeetingStartDate = document.getElementById("<%=this.txtMeetingStartDate.ClientID %>");
            var txtMeetingStartTime = document.getElementById("<%=this.txtMeetingStartTime.ClientID %>");
            var txtTask = document.getElementById("<%=this.txtTask.ClientID %>");

            if (chkboxCall.checked == true) {
                if (isBlank(txtCallSubject, 'Follow Up Call Subject'))
                    return false;
                if (isBlank(txtCallStartDate, 'Follow Up Call Start Date'))
                    return false;
                //if(isBlank(txtCallStartTime, 'Follow Up Call Start Time'))
                //  return false;
            }
            if (chkboxMeeting.checked == true) {
                if (isBlank(txtMeetingStartDate, 'Follow Up Meeting Start Date'))
                    return false;
                if (isBlank(txtMeetingStartTime, 'Follow Up Meeting Start Time'))
                    return false;
            }
            if (txtCallStartDate.value != "") {
                if (ValidateDate(txtCallStartDate.value, 'Follow Up Call Start Date') == false) {
                    return false;
                }
                if (checkDate(txtCallStartDate.value, 'Follow Up Call Start Date') == false)
                { return false; }
            }
            if (txtMeetingStartDate.value != "") {
                if (ValidateDate(txtMeetingStartDate.value, 'Follow Up Meeting Start Date') == false) {
                    return false;
                }
                if (checkDate(txtMeetingStartDate.value, 'Follow Up Meeting Start Date') == false)
                { return false; }
            }
            var txtTaskDueDate = document.getElementById("<%=this.txtTaskDueDate.ClientID %>");
            if (txtTaskDueDate.value != "") {
                if (ValidateDate(txtTaskDueDate.value, 'Follow Up Task Due Date') == false) {
                    return false;
                }
                if (checkDate(txtTaskDueDate.value, 'Follow Up Task Due Date') == false)
                { return false; }
            }
        }

        if ($("#<%= this.HostFacilityContainerDiv.ClientID %>:visible").length > 0) {
            var isValidated = ValidateHostRanking();
            if (isValidated == false) return false;
        }
        // validate zip against the assigned zip territory.
        var _userRole = '<%=UserRole%>';
        if (_userRole == '<%= (long)Falcon.App.Core.Enum.Roles.SalesRep %> ') {
            var txtzipBilling = document.getElementById("<%=this.txtzipBilling.ClientID %>");
            if (txtzipBilling.value != '') {
                var successMethod = function (isProspectHostInTerritoryZip) {

                    if (!isProspectHostInTerritoryZip.d) {
                        if (confirm('The prospect/host which you are trying to create does not fall in your territory and you will not be able to see it in your list once added/updated.')) {
                            __doPostBack('SaveProspectHost', '');
                        }
                    }
                    else {
                        __doPostBack('SaveProspectHost', '');
                    }
                }
                var organizationRoleUserId = '<%=OrganizationRoleUserId%>';
                var parameter = "{'organizationRoleUserId':'" + organizationRoleUserId + "'";
                parameter += ",'zipCode':'" + txtzipBilling.value + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/IsZipCodePresentInTerritory")%>';
                InvokeService(messageUrl, parameter, successMethod);
                return false;
            }
        }
    }

    function InvokeService(messageUrl, parameter, successFunction) {
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
                alert(a.responseText);
            }
        });
    }

    function CompareTodayDate(dateToCompare, msg) {
        var today = new Date();
        var defyear = today.getYear();
        var y = defyear % 100;
        y += (y < 38) ? 2000 : 1900;

        var currentDate = new Date(y, today.getMonth(), today.getDate());

        var dateCompare = new Date(dateToCompare.value.split('/')[2], dateToCompare.value.split('/')[0] - 1, dateToCompare.value.split('/')[1]);

        if (currentDate.getTime() >= dateCompare.getTime()) {
            alert(msg);
            return false;
        }
        else
            return true;
    }

    function CheckMailingAddress() {
        var chkMailingAddress = document.getElementById("<%=this.chkMailingAddress.ClientID %>");
        var divMailingAddress = document.getElementById("<%=this.divMailingAddress.ClientID %>");
        if (chkMailingAddress.checked == true) {
            divMailingAddress.style.display = "block";
        }
        else {
            divMailingAddress.style.display = "none";
        }

    }
    function ShowAddContactPopup() {
        ClearContactFields();
        SetContactTitle('Add New Contact');
        $find('mdlPopup1').show();
        return false;
    }
    function HideAddContactPopup() {
        $find('mdlPopup1').hide();
        return false;
    }

    function AllowNumericOnly(evt) {
        return KeyPress_DecimalAllowedOnly(evt);

    }
    function txtkeypress(evt) {
        return KeyPress_NumericAllowedOnly(evt);
    }
    function DepositeRequires() {

        var rbtnDepositsRequired = document.getElementById("<%=this.rbtnDepositsRequired.ClientID %>");
        var spnDepositeAmount = document.getElementById("<%=this.spnDepositeAmount.ClientID %>");
        var txtAmount = document.getElementById("<%=this.txtAmount.ClientID %>");

        if (rbtnDepositsRequired.rows[0].cells[0].childNodes[0].checked == true) {
            spnDepositeAmount.style.display = "block";
        }
        else {
            spnDepositeAmount.style.display = "none";
            txtAmount.value = "";
        }
    }


    function PromoteChange() {
        var ddlFeederPromotionStatus = document.getElementById("<%=this.ddlFeederPromotionStatus.ClientID %>");
        var spWillPromote = document.getElementById("<%=this.spWillPromote.ClientID %>");
        if (ddlFeederPromotionStatus.value == "0") {
            spWillPromote.style.display = "block";
        }
        else {
            spWillPromote.style.display = "none";

        }

    }

    function HostStatusChange() {
        var ddlhostStatus = document.getElementById("<%=this.ddlhostStatus.ClientID %>");
        var spWillHost = document.getElementById("<%=this.spWillHost.ClientID %>");
        if (ddlhostStatus.value == "0") {
            spWillHost.style.display = "block";
        }
        else {
            spWillHost.style.display = "none";

        }
    }


    function ViableHostChange() {
        var ddlViableHost = document.getElementById("<%=this.ddlViableHost.ClientID %>");
        var spViableHostSite = document.getElementById("<%=this.spViableHostSite.ClientID %>");
        if (ddlViableHost.value == "0") {
            spViableHostSite.style.display = "block";
        }
        else {
            spViableHostSite.style.display = "none";

        }
    }

    function CheckValiable() {
        var ddlHostedInPast = document.getElementById("<%=this.ddlHostedInPast.ClientID %>");
        var spnHostedInPast = document.getElementById("<%=this.spnHostedInPast.ClientID %>");
        var spHostInPast = document.getElementById("<%=this.spHostInPast.ClientID %>");

        if (ddlHostedInPast.value == "1") {
            spnHostedInPast.style.display = "block";
            spHostInPast.style.display = "none";
        }
        else if (ddlHostedInPast.value == "0") {
            spHostInPast.style.display = "block";
            spnHostedInPast.style.display = "none";
        }
        else {
            spHostInPast.style.display = "none";
            spnHostedInPast.style.display = "none";
        }
    }

    function hideDivFollwoUpAction() {
        var divFollwoUpAction = document.getElementById("divFollwoUpAction");
        divFollwoUpAction.style.display = "none";
    }
    function ShowDivFollwoUpAction() {
        var divFollwoUpAction = document.getElementById("divFollwoUpAction");
        divFollwoUpAction.style.display = "block";
    }
    function HideShowCall() {
        var chkboxCall = document.getElementById("<%=this.chkboxCall.ClientID %>");
        var divCall = document.getElementById("divCall");
        if (chkboxCall.checked == true) {
            divCall.style.display = "block";
        }
        else {
            divCall.style.display = "none";
        }
    }

    function HideShowMeeting() {
        var chkboxMeeting = document.getElementById("<%=this.chkboxMeeting.ClientID %>");
        var divMetting = document.getElementById("divMetting");
        if (chkboxMeeting.checked == true) {
            divMetting.style.display = "block";
        }
        else {
            divMetting.style.display = "none";
        }
    }
    function HideShowTask() {
        var chkboxTask = document.getElementById("<%=this.chkboxTask.ClientID %>");
        var pTask = document.getElementById("pTask");
        if (chkboxTask.checked == true) {
            pTask.style.display = "block";
        }
        else {
            pTask.style.display = "none";
        }
    }
    function FilterTime(key, textbox, dFilterMask) {
        return dFilter(key, textbox, dFilterMask);
    }

    function AddSlotAutoFill(textbox) {
        dFilter_AutoFill(textbox);
    }  
</script>
<script language="javascript" type="text/javascript">

    function OpenMandatoryfields() {
        document.getElementById('spaddress').innerHTML = document.getElementById('spaddress').innerHTML.replace('Address:', 'Address:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spzip').innerHTML = document.getElementById('spzip').innerHTML.replace('Zip:', 'Zip:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spstate').innerHTML = document.getElementById('spstate').innerHTML.replace('State:', 'State:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spcity').innerHTML = document.getElementById('spcity').innerHTML.replace('City:', 'City:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spmailzip').innerHTML = document.getElementById('spmailzip').innerHTML.replace('Zip:', 'Zip:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spmailaddress').innerHTML = document.getElementById('spmailaddress').innerHTML.replace('Address:', 'Address:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spmailstate').innerHTML = document.getElementById('spmailstate').innerHTML.replace('State:', 'State:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spmailcity').innerHTML = document.getElementById('spmailcity').innerHTML.replace('City:', 'City:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spphonemain').innerHTML = document.getElementById('spphonemain').innerHTML.replace('Phone(Main):', 'Phone(Main):<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('sptype').innerHTML = document.getElementById('sptype').innerHTML.replace('Type:', 'Type:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spmembers').innerHTML = document.getElementById('spmembers').innerHTML.replace('Members/Employees:', 'Members/Employees:</span>');
        document.getElementById('spfeefacility').innerHTML = document.getElementById('spfeefacility').innerHTML.replace('Any fee to use facility:', 'Any fee to use facility:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spfee').innerHTML = document.getElementById('spfee').innerHTML.replace('Fee($):', 'Fee($):<span class="reqiredmark"><sup>*</sup></span>');

    }

    function ValidateHostRanking() {
        if ($.trim($("#<%= this.NumberPlugPointsTextBox.ClientID %>").val()).length > 0
            && isNaN($.trim($("#<%= this.NumberPlugPointsTextBox.ClientID %>").val()))) {
            alert("Please input a number for [Number of Plug Points].")
            return false;
        }

        if ($("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.Difficult.PersistenceLayerId %>"
            || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.LastResort.PersistenceLayerId %>"
            || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.DoNotSchedule.PersistenceLayerId %>") {
            if ($('.slideshow img').length < 1) {
                alert('Host Infrstructure Images are mandatory to upload, for the ranking provided.');
                return false;
            }

            var gotOneInfraImage = false;
            $('.slideshow div').each(function () {
                if ($(this).find('select option:selected').length > 0) {
                    if ($(this).find('select option:selected').attr("value") == "<%= HostImageType.HostInfrastructure.PersistenceLayerId %>")
                        gotOneInfraImage = true;
                }
            });

            if (!gotOneInfraImage) {
                alert('Host Infrstructure Images are mandatory to upload, for the ranking provided.');
                return false;
            }
        }

        return true;
    }

    function onChangeHostRanking() {
        if ($("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.Difficult.PersistenceLayerId %>"
            || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.LastResort.PersistenceLayerId %>"
            || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.DoNotSchedule.PersistenceLayerId %>") {
            $("#LowRankWarningDiv").show();
        }
        else
            $("#LowRankWarningDiv").hide();
    }

</script>
<asp:Panel ID="PanelMainPage" runat="server" DefaultButton="ibtnSave">
    <div class="wrapper_inpg">
        <div class="divmain">
            <h1 id="divheading" runat="server">
                Create New Prospect</h1>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="subhead">
                <img src="/App/Images/page1symbolvsmall.gif" alt="" />
                <h2 id="divTitle" runat="server">
                    Prospect</h2>
            </div>
            <div class="row">
                <label>
                    Name:<sup>*</sup></label>
                <asp:TextBox ID="txtOrgName" runat="server" Width="645px"></asp:TextBox>
            </div>
            <div class="row">
                <label id="spaddress">
                    Address:</label>
                <asp:TextBox ID="txtaddress1Billing" runat="server" Rows="1" Width="645px"></asp:TextBox>
            </div>
            <div class="row">
                <label>
                    Suite,Apt,etc:</label>
                <asp:TextBox ID="txtaddress2Billing" runat="server" Width="645px"></asp:TextBox>
            </div>
            <div class="row">
                <div id="spcity" class="txtinput180px">
                    City:
                    <asp:TextBox ID="txtcityBilling" runat="server" Width="185px" CssClass="auto-search-billing-city"></asp:TextBox>
                </div>
                <div id="spstate" class="txtinput180px">
                    State:
                    <asp:DropDownList ID="ddlstateBilling" runat="server" Width="185px" AutoPostBack="False"
                        CssClass="ddl-states-billing">
                    </asp:DropDownList>
                </div>
                <div id="spzip" class="txtinput180px">
                    Zip:
                    <asp:TextBox ID="txtzipBilling" runat="server" Width="185px"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <span class="orngtxt_madd" id="spnMailingAddress" runat="server">Prospect Mailing Address:
                </span><span class="orngtxtchkbox">
                    <asp:CheckBox ID="chkMailingAddress" runat="server" /></span> <span class="left"
                        style="padding-top: 4px">(if different from above)</span>
            </div>
            <div style="display: none" id="divMailingAddress" runat="server">
                <%--Begin Mailing Address--%>
                <div class="row">
                    <label id="spmailaddress">
                        Address:</label>
                    <asp:TextBox ID="txtaddress1Mailing" runat="server" Rows="1" Width="645px"></asp:TextBox>
                </div>
                <div class="row">
                    <label>
                        Suite,Apt,etc:</label>
                    <asp:TextBox ID="txtaddress2Mailing" runat="server" Width="645px"></asp:TextBox>
                </div>
                <div class="row">
                    <div id="spmailcity" class="txtinput180px">
                        City:
                        <asp:TextBox ID="txtcityMailing" runat="server" Width="185px" CssClass="auto-search-mailing-city"></asp:TextBox>
                    </div>
                    <div id="spmailstate" class="txtinput180px">
                        State:
                        <asp:DropDownList ID="ddlstateMailing" runat="server" Width="185px" AutoPostBack="False"
                            CssClass="ddl-states-mailing">
                        </asp:DropDownList>
                    </div>
                    <div id="spmailzip" class="txtinput180px">
                        Zip:
                        <asp:TextBox ID="txtzipMailing" runat="server" Width="185px"></asp:TextBox>
                    </div>
                </div>
                <%--End Mailing Address--%>
            </div>
            <div class="row">
                <div id="spphonemain" class="txtinput180px">
                    Phone(Main):
                    <asp:TextBox ID="txtcphoneoffice" runat="server" Width="185px" CssClass="mask-phone"></asp:TextBox></div>
                <div class="txtinput300px">
                    Website:<asp:TextBox ID="txtwebaddress" runat="server" Width="300px"></asp:TextBox></div>
            </div>
            <div class="row">
                <div class="txtinput180px">
                    Fax:<asp:TextBox ID="txtFax" runat="server" Width="185px" CssClass="mask-phone"></asp:TextBox></div>
                <div class="txtinput300px">
                    Email (General):<asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox></div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page2symbolvsmall.gif" alt="" id="Div2" />
                <h2 id="H1" runat="server">
                    Contacts</h2>
            </div>
            <div class="grdrow">
                <div class="linkright_default">
                    <asp:LinkButton ID="lnkNewContact" runat="server" Text="+ Add New Contact" OnClientClick="return ShowAddContactPopup();"></asp:LinkButton>
                    <%--<a href="#" onclick="return ShowAddContactPopup()">+ Add New Contact</a>--%>
                </div>
            </div>
            <div class="grdrow">
                <asp:GridView runat="server" GridLines="None" ID="grdContacts" AutoGenerateColumns="False"
                    CssClass="divgrid_cl" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <span id="spnProspectName" runat="server">
                                    <%# DataBinder.Eval(Container.DataItem, "ID")%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                            <ItemTemplate>
                                <span id="spnName" runat="server">
                                    <%# DataBinder.Eval(Container.DataItem, "FirstName")%>
                                    <%# DataBinder.Eval(Container.DataItem, "LastName")%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone">
                            <ItemTemplate>
                                <span id="spnPhone" runat="server">
                                    <%# DataBinder.Eval(Container.DataItem, "Phone")%>
                                    <%# BindExtension(DataBinder.Eval(Container.DataItem, "PhoneExtension"))%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <span id="spnEmail" runat="server">
                                    <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Email").ToString()) ? DataBinder.Eval(Container.DataItem, "SecondaryEmail") : DataBinder.Eval(Container.DataItem, "Email")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <ItemTemplate>
                                <span id="spnTitle" runat="server">
                                    <%# DataBinder.Eval(Container.DataItem, "Title")%></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notes">
                            <ItemTemplate>
                                <a id="A1" href="javascript:void(0);" class="tt" runat="server">View notes <span
                                    class="tooltip"><span class="top"></span><span class="middle" id="spndefcursor" onmouseover="changetodefault('spndefcursor');"
                                        onmouseout="changetopointer('spndefcursor');">
                                        <%# DataBinder.Eval(Container.DataItem, "ContactNote")%>
                                    </span><span class="bottom"></span></span></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ToolTip="Edit Contact" ID="lnkEditContact" ImageUrl="~/App/Images/smallicon/icon_edit.gif"
                                    OnCommand="Command_Button_Click" CommandName="EditContact" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' />
                                |<asp:ImageButton runat="server" ToolTip="Delete Contact" ID="lnkDeleteContact" ImageUrl="~/App/Images/smallicon/icon_delete.gif"
                                    OnClientClick="return ConfirmContactDelete();" OnCommand="Command_Button_Click"
                                    CommandName="DeleteContact" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false"></asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1" />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
            <div class="row" style="display: none;" id="dvNoContactFound" runat="server">
                <div class="errorbox">
                    <div class="divnoitemtxt_custdbrd" style="padding: 5px 0px 5px 0px;">
                        <span class="graybold12_default" style="color: #999">No Records Found</span>
                    </div>
                </div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page3symbolvsmall.gif" alt="" id="Div3" />
                <h2 id="divProspectDetails" runat="server">
                    Prospect Details</h2>
            </div>
            <div id="divPrimaryContact">
                <div class="row">
                    <label id="sptype">
                        Type:</label>
                    <asp:DropDownList ID="ddlHostType" runat="server" CssClass="inputf_def" Width="645px">
                    </asp:DropDownList>
                </div>
                <div class="row">
                    <div id="spmembers" class="txtinput180px">
                        Members/Employees:
                        <asp:TextBox ID="txtActualMembers" runat="server" MaxLength="10" Width="185px"></asp:TextBox>
                    </div>
                    <div class="txtinput180px">
                        Attendance:
                        <asp:TextBox ID="txtAttendence" runat="server" MaxLength="10" Width="185px"></asp:TextBox>
                    </div>
                </div>
                <div class="nrow">
                    <div id="spfeefacility" class="titletextnowidth_default">
                        Any fee to use facility:</div>
                    <div class="left">
                        <asp:RadioButtonList ID="rbtnFeeRequired" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="divrow" id="divFee" runat="server" style="display: none;">
                    <fieldset style="margin: 0px; padding: 0px;">
                        <legend class="legendhead_default">Fee Details</legend>
                        <div class="legendrowsmall_default">
                            <div class="lrow">
                                <label id="spfee">
                                    Fee($):</label>
                                <asp:TextBox ID="txtFacilitiesFee" runat="server" CssClass="inputf_def" MaxLength="10"
                                    Width="185px"></asp:TextBox>
                            </div>
                            <div class="lrow">
                                <label>
                                    Payment Method:</label>
                                <div class="chkboxlist">
                                    <asp:CheckBoxList ID="chkPaymentMethod" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Check" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="CreditCard" Value="2"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="lrow">
                                <label>
                                    Deposits Required:</label>
                                <div class="chkboxlist">
                                    <asp:RadioButtonList ID="rbtnDepositsRequired" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="No" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div id="spnDepositeAmount" runat="server">
                                    <label id="spnAmount" runat="server">
                                        Amount($)</label>
                                    <div class="left">
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="inputf_def" MaxLength="12" Width="100px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="lrow" id="_divTaxNumber" runat="server">
                                <label>
                                    TaxId Number:</label>
                                <asp:TextBox ID="_taxIdNumber" runat="server" MaxLength="50" Width="185px"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="row" style="margin-top: 5px;">
                <div class="txtinput140px">
                    <div class="txtinput140px">
                        Will Promote:<asp:DropDownList ID="ddlFeederPromotionStatus" runat="server" Width="140px">
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Unknown" Value="2" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="txtinput140px">
                        <div class="txtinput140px" id="spWillPromote" runat="server" style="display: none">
                            Reason:<asp:TextBox ID="txtWillPromote" runat="server" TextMode="MultiLine" Height="50px"
                                Width="134px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="txtinput140px">
                    <div class="txtinput140px">
                        Will Host:<asp:DropDownList ID="ddlhostStatus" runat="server" Width="140px">
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Unknown" Value="2" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="txtinput140px">
                        <div class="txtinput140px" id="spWillHost" runat="server" style="display: none">
                            Reason:<asp:TextBox ID="txtWillHost" runat="server" TextMode="MultiLine" Height="50px"
                                Width="134px"></asp:TextBox></div>
                    </div>
                </div>
                <div class="txtinput140px">
                    <span id="spnProspectStatus" runat="server">Prospect Category:</span>
                    <asp:DropDownList ID="ddlProspectStatus" runat="server" Width="140px">
                        <asp:ListItem Text="Unknown" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Hot" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Warm" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Cold" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <div class="txtinput140px" style="display: none">
                        Viable Host Site:<asp:DropDownList ID="ddlViableHost" runat="server" Width="140px">
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Unknown" Value="2" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="txtinput140px" style="display: none">
                        <div class="txtinput140px" id="spViableHostSite" runat="server" style="display: none">
                            Reason:<asp:TextBox ID="txtViableHostSite" runat="server" TextMode="MultiLine" Height="50px"
                                Width="134px"></asp:TextBox></div>
                    </div>
                </div>
                <div class="txtinput140px">
                    <div class="txtinput140pxnm">
                        Hosted In Past:
                        <asp:DropDownList ID="ddlHostedInPast" runat="server" Width="140px">
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Unknown" Value="2" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="txtinput140px">
                        <div class="txtinput140px" id="spHostInPast" runat="server" style="display: none;
                            margin-right: 0px;">
                            Reason:<asp:TextBox ID="txtHostInPast" runat="server" TextMode="MultiLine" Height="50px"
                                Width="134px"></asp:TextBox></div>
                        <div class="hiptxt" id="spnHostedInPast" runat="server" style="display: none">
                            <span class="left" style="width: 28px">for:</span><asp:TextBox ID="txtHostedInPast"
                                runat="server" CssClass="left" Width="101px"></asp:TextBox>
                            <div class="smltxt">
                                Type in a Competitor's Name</div>
                        </div>
                    </div>
                </div>
            </div>
            <div runat="server" id="HostFacilityContainerDiv" style="display: none;">
                <div class="subhead">
                    <img src="/App/Images/page4symbolvsmall.gif" alt="" id="Img1" />
                    <h2 id="divHostRanking" runat="server">
                        Ranking and Facility Details</h2>
                </div>
                <div class="row">
                    <div class="txtinput300px" style="width: 215px">
                        Ranking:
                        <asp:DropDownList ID="HostRankingDropDown" runat="server" onchange="onChangeHostRanking();">
                        </asp:DropDownList>
                    </div>
                    <div class="txtinput300px" id="LowRankWarningDiv" style="font-weight: normal; width: 400px;
                        display: none;">
                        <a href="#" style="font: bold 16px arial; text-decoration: none; display: none;">?</a>
                        <span class="MiniWarningMessage">You need to upload images for this level of ranking</span></div>
                </div>
                <div class="row">
                    <div class="graysmalltxt_default">
                        Please rank the host, based on guidelines provided by your supervisor.</div>
                </div>
                <div class="divrow">
                    <fieldset style="margin-top: 10px; padding: 0">
                        <legend class="legendhead_default">Host Facility Details</legend>
                        <div class="legendrowsmall_default">
                            <div class="lrow">
                                <div class="txtinput200px">
                                    Does the room need to be cleared?</div>
                                <div class="chkboxlist" style="width: 200px">
                                    <asp:RadioButtonList ID="RoomClearedRadioButtonList" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="txtinput140pxnm">
                                    Number of Plug Points:</div>
                                <div class="left">
                                    <asp:TextBox ID="NumberPlugPointsTextBox" runat="server" Width="100px" /></div>
                            </div>
                            <div class="lrow">
                                <div class="txtinput200px">
                                    Internet Access:</div>
                                <div class="left" style="width: 200px">
                                    <asp:DropDownList runat="server" ID="InternetAccessDropDown">
                                    </asp:DropDownList>
                                </div>
                                <div class="txtinput140pxnm">
                                    Room Size:</div>
                                <div class="left">
                                    <asp:TextBox ID="RoomSizeTextBox" runat="server" Width="100px" />
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="nrow" style="margin-top: 10px">
                    <div class="titletextnowidth_default">
                        How have you verified the above information?<sup class="reqiredmark">*</sup></div>
                    <div class="chkboxlist">
                        <asp:RadioButtonList ID="HostConfirmationRadioButtonList" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Visually" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Verbally" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="row" style="font-weight: bold;">
                    Images</div>
                <div class="row" style="display: block;">
                    <div class="mainimgdiv">
                        <div class="inrdiv hostimageviewer">
                            <div class="preimg_small" style="text-align: center;">
                                <asp:DataList runat="server" ID="HostImagesDataList" DataKeyField="Id" CssClass="slideshow"
                                    OnItemDataBound="HostImagesDataList_ItemDataBound">
                                    <ItemTemplate>
                                        <div class='<%# (Container.ItemIndex == 0 ? "active" : "") %>'>
                                            <img onclick="OpenImageDisplyDialog(this.src);" src='<%# DataBinder.Eval(Container.DataItem, "Path") %>'
                                                alt="" style="width: 150px; height: 90px;" />
                                            <br />
                                            <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Delete" OnClick="DeleteLinkButton_Click"> </asp:LinkButton>
                                            <br />
                                            <asp:DropDownList runat="server" ID="ImageTypeDropDown">
                                            </asp:DropDownList>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                            <div class="preimg_small" style="text-align: center;">
                                <img src="../Images/calander-leftarrow-btn.gif" alt="" class="previous-img-navigator"
                                    onclick="FetchPrevious();" />
                                <img src="../Images/calander-rightarrow-btn.gif" alt="" class="next-img-navigator"
                                    onclick="FetchNext();" />
                            </div>
                        </div>
                        <div class="inrdiv hostimageviewer" style="display: none;">
                            <img src="/App/Images/no-img-available.gif" alt="No Image Available" />
                        </div>
                    </div>
                    <div class="fltrdv" style="width: 360px; margin: 0 0 0 20px">
                        <div class="left" style="background: #f5f5f5; padding: 5px; width: 350px; font-weight: bold;">
                            Upload Image
                        </div>
                        <asp:FileUpload ID="HostImageUploader" runat="server" size="20" />
                        <div class="fldrow graysmalltxt_default">
                            Max Image Size:3 MB
                        </div>
                        <div class="fldrow">
                            <span class="titletextsmallbld1_default">Image Type:</span> <span class="left">
                                <asp:DropDownList ID="UploaderImageTypeDropDown" runat="server" Width="160px">
                                </asp:DropDownList>
                            </span>
                        </div>
                        <div class="fldrow mt_medium graysmalltxt_default">
                            Please make sure the marketing images are of recomended sizes and high quality.</div>
                        <div class="fldrow">
                            <span class="rgt">
                                <asp:Button ID="UploadButton" runat="server" CssClass="button" Text="Upload" OnClientClick="return ValidateUploadImages();"
                                    OnClick="UploadButton_Click" /></span></div>
                    </div>
                </div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page5symbolvsmall.gif" alt="" />
                <h2 id="H2" runat="server">
                    Notes</h2>
            </div>
            <div class="row">
                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" MaxLength="12" Rows="4"
                    Width="645px" CssClass="inputf_def"></asp:TextBox>
            </div>
            <div class="row" style="margin-top: 5px; display:none;" runat="server" id="CallCenterNotesDiv">
            <div><b>Call Center Notes:</b> </div>
                <div>
                    <asp:TextBox ID="CallCenterNotesTextbox" runat="server" TextMode="MultiLine" MaxLength="12"
                        Rows="4" Width="645px" CssClass="inputf_def"></asp:TextBox></div>
            </div>
            <div class="row" style="margin-top: 5px; display:none;" runat="server" id="TechnicianNotesDiv">
                <div> <b>Technician Notes:</b> </div>
                <div>
                    <asp:TextBox ID="TechnicianNotesTextbox" runat="server" TextMode="MultiLine" MaxLength="12"
                        Rows="4" Width="645px" CssClass="inputf_def"></asp:TextBox></div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page6symbolvsmall.gif" alt="" />
                <h2>
                    Future Action</h2>
            </div>
            <p>
                <asp:RadioButton ID="radioNone" runat="server" Text="None" Checked="true" GroupName="FollowUpAction" />
            </p>
            <p>
                <asp:RadioButton ID="radioFollowAction" runat="server" Text="Follow up Action" GroupName="FollowUpAction" /></p>
            <div class="row" id="divFollwoUpAction" style="display: none;">
                <div class="greybox_anp">
                    <div class="row">
                        <asp:CheckBox ID="chkboxCall" runat="server" Text="Follow up Call" />
                    </div>
                    <div id="divCall" style="display: none;">
                        <div class="row">
                            <span class="txtinput480px">Subject:<span class="reqiredmark"><sup>*</sup></span><asp:TextBox
                                ID="txtCallSubject" runat="server" Width="458px"></asp:TextBox></span>
                        </div>
                        <div class="row">
                            <div class="txtinput480px">
                                <div class="txtinput140px">
                                    Start Date:<span class="reqiredmark"><sup>*</sup></span>(mm/dd/yyyy)
                                    <asp:TextBox ID="txtCallStartDate" runat="server" Width="100px" CssClass="inputf_def date-picker"></asp:TextBox>
                                </div>
                                <div class="txtinput140px">
                                    Time:
                                    <asp:TextBox ID="txtCallStartTime" runat="server" Width="140px" CssClass="inputf_def"
                                        onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                    (hh:mm)</div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:CheckBox ID="chkboxMeeting" runat="server" Text="Follow up Meeting" />
                    </div>
                    <div id="divMetting" style="display: none;">
                        <div class="row">
                            <div class="txtinput480px">
                                <div class="txtinput140px">
                                    Start Date:<sup>*</sup>(mm/dd/yyyy)
                                    <asp:TextBox ID="txtMeetingStartDate" runat="server" Width="100px" CssClass="inputf_def date-picker"></asp:TextBox>
                                </div>
                                <div class="txtinput140px">
                                    Time:<sup>*</sup>
                                    <asp:TextBox ID="txtMeetingStartTime" runat="server" Width="140px" CssClass="inputf_def"
                                        onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                    (hh:mm)
                                </div>
                                <div class="inputfield110px_anp">
                                    Venue:
                                    <asp:TextBox ID="txtVenue" runat="server" Width="110px" CssClass="inputf_def"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:CheckBox ID="chkboxTask" runat="server" Text="Follow up Task" />
                    </div>
                    <div id="pTask" style="display: none;">
                        <div class="row">
                            <div class="txtinput480px">
                                <asp:TextBox ID="txtTask" runat="server" Width="458px" CssClass="inputf_def"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="txtinput480px">
                                <div class="txtinput140px">
                                    Due Date:(mm/dd/yyyy)
                                    <asp:TextBox ID="txtTaskDueDate" runat="server" Width="100px" CssClass="inputf_def date-picker"></asp:TextBox>
                                </div>
                                <div class="txtinput140px">
                                    Time:
                                    <asp:TextBox ID="txtTaskDueTime" runat="server" Width="140px" CssClass="inputf_def"
                                        onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                    (hh:mm)
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="btnrow">
                <div class="btns">
                    <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="~/App/Images/save-button.gif"
                        OnClientClick="return ValidateInputs();" OnClick="ibtnSave_Click" />
                </div>
                <div class="btns">
                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="ibtnCancel_Click" />
                </div>
                <div id="divAssign" runat="server" style="display: none;" class="btns">
                    <asp:ImageButton ID="ibtnAssign" runat="server" ImageUrl="~/App/Images/assign-franchisee_btn.gif"
                        OnClick="ibtnAssign_Click" />
                </div>
                <div class="btns">
                    <asp:ImageButton ID="ibtnConvert" runat="server" ImageUrl="~/App/Images/converttohost-butt.gif"
                        OnClick="ibtnConvert_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
<div id="ImageDisplayDiv" title="Host Image" style="float: left; width: 640px;">
    <img src="" alt="" width="640px" id="HostImageImg" />
</div>
<asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
<asp:Panel ID="pnlAddContact" runat="server" Style="display: none;">
    <uc1:ucMiniAddNewContact ID="ucMiniAddNewContact1" runat="server" Onclicking="HandleSave" />
</asp:Panel>
<%--//TODO Bidhan Replace this--%>
<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkNewContact"
    PopupControlID="pnlAddContact" BackgroundCssClass="modalBackground" CancelControlID="lnktemp"
    BehaviorID="mdlPopup1" />
<asp:Panel ID="pnlFranchisee" runat="server" CssClass="PopUpb" Style="display: none;">
    <div id="PopUpDiv4">
        <div class="headers_fdetails">
            <div class="headertitle_popup_si">
                Franchisee Details
            </div>
            <div class="headerclose_button_si">
                <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/App/Images/close-button-symbol.gif" />
            </div>
        </div>
        <div class="dgfdetails_prospect">
            <asp:DataGrid runat="server" GridLines="None" ID="dgFranchiseeList" AutoGenerateColumns="false"
                CssClass="gridchkbox" DataKeyField="Id" OnItemDataBound="dgFranchiseeList_ItemDataBound">
                <Columns>
                    <asp:BoundColumn DataField="" Visible="false"></asp:BoundColumn>
                    <asp:TemplateColumn>
                        <HeaderTemplate>
                            <input type="checkbox" id="chklistname1" runat="server" class="" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input type="checkbox" id="chkRowChild" runat="server" class="" /></ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Name" HeaderText="Franchisee Name"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Address">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "Address").ToString()%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="PhoneNumber" HeaderText="PhoneNo"></asp:BoundColumn>
                </Columns>
                <HeaderStyle CssClass="row1" />
                <ItemStyle CssClass="row2" />
                <AlternatingItemStyle CssClass="row3" />
            </asp:DataGrid>
        </div>
        <div class="pagealerttxtCNT" id="errordivFranchisee" runat="server" enableviewstate="false">
            <br />
            &nbsp;</div>
        <div class="buttons_master">
            <div class="button_save_master" style="padding: 10px 0px 0px 260px;">
                <a href="javascript:hidediv()"></a>
                <asp:ImageButton runat="server" CausesValidation="true" ID="ibtnAssignFranchisee"
                    ImageUrl="~/App/Images/save-button.gif" OnClick="ibtnAssignFranchisee_Click" />
            </div>
        </div>
    </div>
</asp:Panel>
<%--//TODO - Bidhan Replace this--%>
<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFranchisee" BackgroundCssClass="modalBackground"
    TargetControlID="ibtnAssign" PopupControlID="pnlFranchisee" CancelControlID="ImageButton2"
    runat="server">
</ajaxToolkit:ModalPopupExtender>
<script type="text/javascript" language="javascript">


    //    function ShowAddContactPopup() {
    //        //tb_show('Add / Edit Contact', '/App/UCCommon/ucMiniAddNewContact.ascx?keepThis=true&TB_iframe=true&width=775&modal=true', false);
    //        $('#pnlAddContact').dialog('open');
    //        return false;
    //    }
    //    function HideAddContactPopup() {
    //        $('#pnlAddContact').dialog('close');
    //        $('#pnlAddContact').dialog("destroy");
    //        $('#pnlAddContact').dialog({ autoOpen: false, width: 775, modal: true, title: 'Add / Edit Contact', resizable: false });
    //         return false;
    //    }


    function ValidateUploadImages() {
        var bolGetOne = false;

        if ($.trim($("#<%= this.HostImageUploader.ClientID %>").val()).length > 0)
            return true;
        else {
            alert('Select a file to upload.');
            return false;
        }
    }

    $(document).ready(function () {
        if ($('.slideshow div').length < 1) {
            $('.hostimageviewer').toggle();
        }
        else {
            $('.slideshow div').each(function () {
                if (navigator.appName == 'Microsoft Internet Explorer') {
                    $(this).css("top", "0");
                    $(this).css("left", "0");
                }
                else {
                    $(this).css("top", $('.slideshow').offset().top);
                    $(this).css("left", $('.slideshow').offset().left);
                }
            });

            if ($('.slideshow div.active').length > 0) {
                SortVisibility($('.slideshow div.active'));
            }
        }
        //Add Contact popup
        //$('#pnlAddContact').dialog({ autoOpen: false, width: 775, modal: true, title: 'Add / Edit Contact', resizable: false });    

        $('.auto-search-billing-city').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: $('.ddl-states-billing option:selected').val()
        });

        $(".date-picker").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-10:+50"
        });

        $('.ddl-states-billing').change(function () {
            $('.auto-search-billing-city').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('.ddl-states-billing option:selected').val()
            });
        });
    });
    
</script>
<script type="text/javascript" language="javascript">

    function OpenImageDisplyDialog(sourcePath) {
        $('#HostImageImg').attr('src', sourcePath);
        $('#ImageDisplayDiv').dialog('open');
    }

    $(document).ready(function () {
        $('#ImageDisplayDiv').dialog({ width: 680, height: 510, autoOpen: false, resizable: false, draggable: false, overflow: "visible" });

        //$('.mask-phone').mask("(999)-999-9999"); //Enable it when you remove ucMiniAddNewContact

        $('.auto-search-mailing-city').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: $('.ddl-states-mailing option:selected').val()
        });


        $('.ddl-states-mailing').change(function () {
            $('.auto-search-mailing-city').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('.ddl-states-mailing option:selected').val()
            });
        });
    });
    
</script>
<asp:Panel runat="server" ID="pnlCCity" Height="100px" Width="100px" ScrollBars="Vertical"
    Style="display: none; overflow: hidden; text-overflow: ellipsis">
</asp:Panel>
<input type="hidden" id="hidContactID" runat="server" />
<asp:HiddenField runat="server" ID="hfViewType" Value="" />

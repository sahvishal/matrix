<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" CodeBehind="Step1.aspx.cs" Inherits="Falcon.App.UI.App.Common.CreateEventWizard.Step1"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="messages" TagPrefix="messagecontrol" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Extensions" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Users.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncudeJQueryJTip="true" />
    <script type="text/javascript" src="/App/JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>"></script>

    <style type="text/css">
        .infobar {
            float: left;
            width: 97%;
            background: #fff0a5;
            padding: 5px 10px;
            margin-top: 5px;
            border: solid 1px #fed22f;
        }

        .maindivpagemainrow_anp {
            float: left;
            padding-left: 31px;
            width: 718px;
        }

        .pagemainrow_anp {
            float: left;
            width: 718px;
            padding-top: 2px;
        }

        .inputfield150px_anp {
            float: left;
            width: 150px;
            margin-right: 45px;
            font: bold 12px arial;
            color: #000;
        }

        .inputfield250px_anp {
            float: left;
            width: 250px;
            margin-right: 45px;
            font: bold 12px arial;
            color: #000;
        }

        .greybox_cew {
            background: #f5f5f5;
            float: left;
            padding: 5px;
            width: 700px;
            border: solid 1px #eee;
        }

        .greybox_rols {
            background: #f5f5f5;
            float: left;
            padding: 5px;
            width: 736px;
            border: solid 1px #eee;
        }

        .greybox_cew .row {
            float: left;
            width: 698px;
        }

        .greybox_cew .row2 {
            float: left;
            width: 698px;
            margin-top: 3px;
        }

            .greybox_cew .row2 .lbl1 {
                float: left;
                width: 151px;
                padding-left: 20px;
            }

            .greybox_cew .row2 .lbl2 {
                float: left;
                padding-left: 20px;
                width: 40px;
            }

        .innerboxes_cew {
            float: left;
            width: 265px;
            padding-right: 9px;
            margin-right: 5px;
            height: 120px;
            overflow: visible;
            border-right: solid 1px #ccc;
        }

            .innerboxes_cew .row {
                float: left;
                width: 265px;
            }

        .innerboxes1_cew {
            float: left;
            width: 170px;
            padding-right: 9px;
            margin-right: 5px;
            overflow: visible;
            border-right: solid 1px #ccc;
        }

            .innerboxes1_cew .row {
                float: left;
                width: 170px;
            }

        .innerboxes_cews {
            float: left;
            width: 160px;
            padding-right: 9px;
            overflow: visible;
            margin-right: 5px;
            border-right: solid 1px #ccc;
        }

            .innerboxes_cews .row {
                float: left;
                width: 160px;
            }

        .bdrwhitebox_cew {
            background: #fff;
            float: left;
            width: 300px;
            padding: 5px;
            border: solid 1px #ccc;
        }

        .subhead {
            float: left;
            width: 750px;
            margin-top: 5px;
        }

            .subhead img {
                float: left;
                margin-right: 5px;
            }

            .subhead .toppad {
                float: left;
                padding-top: 5px;
            }

        .greybar {
            float: left;
            width: 97%;
            background: #e5e5e5;
            padding: 5px 10px;
            margin-top: 5px;
        }

        .infobar {
            float: left;
            width: 97%;
            background: #fff0a5;
            padding: 5px 10px;
            margin-top: 5px;
            border: solid 1px #fed22f;
        }

        .add_box {
            float: left;
            background: #fafafa;
            border: solid 1px #e5e5e5;
            padding: 5px;
            width: 510px;
            margin-top: 3px;
        }

            .add_box .hrow {
                float: left;
                width: 510px;
                margin-top: 3px;
            }

                .add_box .hrow .lbln {
                    margin-right: 10px;
                    float: left;
                }

        .gglmap {
            float: left;
            width: 170px;
            margin: 5px 0;
            padding-top: 3px;
            border-top: dashed 1px #ccc;
        }

        .comntsbox {
            width: 99%;
            display: block;
            padding: 10px 5px;
            background: #fff;
        }

        .inputfield150px_anp {
            float: left;
            width: 150px;
            margin-right: 25px;
            font: bold 12px arial;
            color: #000;
        }

        .inputfield170px_anp {
            float: left;
            width: 180px;
            margin-right: 20px;
            font: bold 12px arial;
            color: #000;
        }

        .inputfield350px_anp {
            float: left;
            width: 350px;
            margin-right: 50px;
            font: bold 12px arial;
            color: #000;
        }

        .msgtxt_cew {
            float: left;
            width: 350px;
            padding-top: 9px;
            font: normal 10px arial;
        }

        .wrapper_pop {
            background: #f5f5f5;
            float: left;
            width: 552px;
            padding: 10px;
        }

        .wrapperin_pop {
            background: #fff;
            float: left;
            width: 528px;
            border: solid 2px #4888ab;
            padding: 10px;
        }

        .innermain_pop {
            float: left;
            width: 528px;
        }

        .prenextband {
            background: #dfe7ed;
            float: left;
            width: 516px;
            border: solid 1px #ccc;
            padding: 4px 5px 4px 5px;
        }
    </style>
    <style type="text/css">
        .room-grid {
            float: left;
            width: 100%;
        }

            .room-grid td {
                float: left;
                width: 100%;
                border: none;
                padding: 4px;
            }

            .room-grid input[type="text"] {
                background-color: #FFFFFF;
                border: 1px solid #7F9DB9;
                color: #333333;
                font: 12px arial;
                padding: 2px;
                z-index: -5;
            }

        .test-grid {
            float: left;
            width: 100%;
        }

            .test-grid tr {
                float: left;
                width: 16%;
                border: none;
            }
    </style>

    <div id="Step1Div" runat="server">
        <script type="text/javascript" language="javascript">

            function OpenGoogleMapStep() {
                var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=815,height=600";
                window.open('GoogleMapHints.htm', 'ResultsWindow', winOpts);
            }

            String.prototype.trim = function () {
                a = this.replace(/^\s+/, '');
                return a.replace(/\s+$/, '');
            };

            var _hostID = '';
            var hostDetails;
            var IsMapStatus = '';

            function selectHost(HostID) {

                InitiateLoadHostRankingData(HostID);
                GetHostNotes(HostID);
                var divHostID = "div" + HostID;
                divHostID = document.getElementById(divHostID);
                hostDetails = $(divHostID);
                var divHostDetails = document.getElementById("<%=divHostDetails.ClientID %>");
                var divGVHostDetails = document.getElementById("<%=divGVHostDetails.ClientID %>");
                var divNoHostFound = document.getElementById("<%=divNoHostFound.ClientID %>");
                var hfHostID = document.getElementById("<%=hfHostID.ClientID %>");
                var aSelectID = "aSelect" + HostID;
                var aRemoveID = "aRemove" + HostID;
                var aEditHostID = "aEditHost" + HostID;
                var aEditSelectedHostID = "aEditSelectedHost" + HostID;
                // show google map status
                var divGoogleMapStatus = "googleMapStatus" + HostID;
                divGoogleMapStatus = document.getElementById(divGoogleMapStatus);
                divGoogleMapStatus.style.display = "block";

                var AddressID = "AddressID" + HostID;
                AddressID = document.getElementById(AddressID);
                if (AddressID.value != '') document.getElementById("<%=_addressId.ClientID %>").value = AddressID.value;
                // show div to updated logitute and latitude
                var _googleMapDiv = document.getElementById("<%=_googleMapDiv.ClientID %>");
                _hostID = HostID;

                // set latitude
                var Latitude = "Latitude" + HostID;
                Latitude = document.getElementById(Latitude);
                if (Latitude.value != '') document.getElementById("<%=_latitudeLongitudeText.ClientID %>").value = Latitude.value;
                else document.getElementById("<%=_latitudeLongitudeText.ClientID %>").value = '';
                // set longitude
                var Longitude = "Longitude" + HostID;
                Longitude = document.getElementById(Longitude);
                if (Longitude.value != '') document.getElementById("<%=_latitudeLongitudeText.ClientID %>").value = document.getElementById("<%=_latitudeLongitudeText.ClientID %>").value + ',' + Longitude.value;

                // Is google map correct
                var IsManuallyVerified = "IsManuallyVerified" + HostID;
                IsManuallyVerified = document.getElementById(IsManuallyVerified);
                // Yes
                var googleMapCorrect = "googleMapCorrect" + HostID;
                googleMapCorrect = document.getElementById(googleMapCorrect);
                //No

                var googleMapInCorrect = "googleMapInCorrect" + HostID;
                googleMapInCorrect = document.getElementById(googleMapInCorrect);

                googleMapCorrect.disabled = 'disabled';
                googleMapInCorrect.disabled = 'disabled';
                _googleMapDiv.style.display = "none";
                if (IsManuallyVerified && IsManuallyVerified.value == 'True') {
                    if (googleMapCorrect) {
                        googleMapCorrect.checked = true;
                        _googleMapDiv.style.display = "none";
                        IsMapStatus = 'false';
                    }
                }
                else if (IsManuallyVerified && IsManuallyVerified.value == 'False' && Longitude.value != '' && Latitude.value != '') {
                    if (googleMapInCorrect) {
                        googleMapInCorrect.checked = true;
                        _googleMapDiv.style.display = "block";
                    }
                }
                else {
                    if (googleMapCorrect) {
                        googleMapCorrect.checked = false;
                    }
                    if (googleMapInCorrect) {
                        googleMapInCorrect.checked = false;
                    }
                    _googleMapDiv.style.display = "none";
                }

                // Is UseLatLogForMapping allowed to use map.
                var UseLatLogForMapping = "UseLatLogForMapping" + HostID;
                UseLatLogForMapping = document.getElementById(UseLatLogForMapping);

                aSelectID = document.getElementById(aSelectID);
                aRemoveID = document.getElementById(aRemoveID);
                aEditHostID = document.getElementById(aEditHostID);
                aEditSelectedHostID = document.getElementById(aEditSelectedHostID);

                aSelectID.style.display = "none";
                aRemoveID.style.display = "block";
                aEditHostID.style.display = "none";
                aEditSelectedHostID.style.display = "block";
                divHostDetails.innerHTML = divHostID.innerHTML;
                $('.jtipMapDiv').unbind();
                $('.jtipMapDiv').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 300 });

                divHostDetails.style.display = "block";
                divGVHostDetails.style.display = "none";
                divNoHostFound.style.display = "none";
                hfHostID.value = HostID;

                var hfPaymentRequired = document.getElementById("<%=hfPaymentRequired.ClientID %>");
                var divPayment = document.getElementById("<%=divPayment.ClientID %>");
                var divNoPayment = document.getElementById("<%=divNoPayment.ClientID %>");

                var divTaxIdNumber = document.getElementById('divTaxIdNumber' + HostID);
                var divFacilitiesFee = document.getElementById('divFacilitiesFee' + HostID);
                var divDepositsAmount = document.getElementById('divDepositsAmount' + HostID);
                var divPaymentMethod = document.getElementById('divPaymentMethod' + HostID);
                var FacilitiesFee = parseInt(divFacilitiesFee.innerHTML);

                var txtCostOfHost = document.getElementById("<%=txtCostOfHost.ClientID %>");
                var txtDepositAmount = document.getElementById("<%=txtDepositAmount.ClientID %>");

                // TaxIdNumber
                var _taxIdNumber = document.getElementById("<%=_taxIdNumber.ClientID %>");
                if (divTaxIdNumber != null && ($.trim(divTaxIdNumber.innerHTML) != ''))
                    _taxIdNumber.value = $.trim(divTaxIdNumber.innerHTML);


                GetSelectedHostDetail(HostID);

                if (FacilitiesFee > 0) {
                    txtCostOfHost.value = FacilitiesFee;
                    txtDepositAmount.value = $.trim(divDepositsAmount.innerHTML);
                    hfPaymentRequired.value = "1";
                    divPayment.style.display = "block";

                    $('#<%=_rbtnNPayment.ClientID %>').attr("checked", false);
                    $('#<%=_rbtnYPayment.ClientID %>').attr("checked", true);

                }
                else {
                    txtCostOfHost.value = "";
                    txtDepositAmount.value = "";
                    hfPaymentRequired.value = "0";
                    divPayment.style.display = "none";
                    $('#<%=_rbtnYPayment.ClientID %>').attr("checked", false);
                    $('#<%=_rbtnNPayment.ClientID %>').attr("checked", true);

                }
            }

            function SetNewMap() {
                var latitudeLongitude = document.getElementById("<%=_latitudeLongitudeText.ClientID %>").value;

                if (latitudeLongitude != '') {
                    var address = document.getElementById("<%=_hostaddress.ClientID %>");
                    var newGoogleMap = document.getElementById('_newGoogleMap');
                    var newMapLink = '';
                    if (newGoogleMap && address.value != '') {
                        newMapLink = 'http://maps.google.com/maps?f=q&hl=en&geocode=&q=' + latitudeLongitude + '(' + address.value + ')';
                    }
                    else if (newGoogleMap && hostDetails) {
                        newMapLink = 'http://maps.google.com/maps?f=q&hl=en&geocode=&q=' + latitudeLongitude + '(' + hostDetails.find('#_completeAddress').text().trim() + ')';
                    }
                    var newWindow = window.open(newMapLink, '_blank');
                    newWindow.focus();
                    return false;
                }
                else alert('To view the map, Please enter latitude and longitude for correct location.');
            }

            function setIsMap(status) {
                if (status == 'Yes') {
                    IsMapStatus = 'false';
                    // show div to updated logitute and latitude
                    var _googleMapDiv = document.getElementById("<%=_googleMapDiv.ClientID %>");
                    _googleMapDiv.style.display = "none";
                }
                else if (status == 'No') {
                    IsMapStatus = 'true';
                    // show div to updated logitute and latitude
                    var _googleMapDiv = document.getElementById("<%=_googleMapDiv.ClientID %>");
                    _googleMapDiv.style.display = "block";
                }
                // update google map status.
            UpdateGoogleMapVerificatioStatus(true);
        }

        function EnableAddressVerification(hostId) {
            if (hostId == 0) {
                var googleMapCorrectVirtual = document.getElementById("<%=googleMapCorrectVirtual.ClientID %>");
                    var googleMapInCorrectVirtual = document.getElementById("<%=googleMapInCorrectVirtual.ClientID %>");

                    if (googleMapCorrectVirtual) googleMapCorrectVirtual.disabled = false;
                    if (googleMapInCorrectVirtual) googleMapInCorrectVirtual.disabled = false;
                    var checkLatLongUseForMap = document.getElementById("<%=checkLatLongUseForMap.ClientID %>");
                    if (checkLatLongUseForMap) checkLatLongUseForMap.disabled = false;
                    $('.LatLogCheckBox').removeAttr("disabled");
                    $('.LatLongText').attr('disabled', '');
                    if (googleMapCorrectVirtual.checked == true) {
                        IsMapStatus = 'false';
                    }
                    else if (googleMapInCorrectVirtual.checked == true) {
                        IsMapStatus = 'true';
                        googleMapInCorrectVirtual.Disabled = true;
                    }
                }
                else {
                    $('.YesRadio').attr('disabled', '');
                    $('.NoRadio').attr('disabled', '');
                    $('.YesRadio').attr("checked", false);
                    $('.NoRadio').attr("checked", false);
                }
            }

            function removeSelectedHost() {//debugger;
                var divHostDetails = document.getElementById("<%=divHostDetails.ClientID %>");
                var divGVHostDetails = document.getElementById("<%=divGVHostDetails.ClientID %>");
                var divNoHostFound = document.getElementById("<%=divNoHostFound.ClientID %>");
                var hfHostID = document.getElementById("<%=hfHostID.ClientID %>");
                var txtCostOfHost = document.getElementById("<%=txtCostOfHost.ClientID %>");
                var txtDepositAmount = document.getElementById("<%=txtDepositAmount.ClientID %>");

                var aSelectID = "aSelect" + hfHostID.value;
                var aRemoveID = "aRemove" + hfHostID.value;
                var aEditHostID = "aEditHost" + hfHostID.value;
                var aEditSelectedHostID = "aEditSelectedHost" + hfHostID.value;

                aSelectID = document.getElementById(aSelectID);
                aRemoveID = document.getElementById(aRemoveID);
                aEditHostID = document.getElementById(aEditHostID);
                aEditSelectedHostID = document.getElementById(aEditSelectedHostID);

                aSelectID.style.display = "block";
                aRemoveID.style.display = "none";
                aEditHostID.style.display = "block";
                aEditSelectedHostID.style.display = "none";

                divHostDetails.innerHTML = "";
                divHostDetails.style.display = "none";
                divGVHostDetails.style.display = "block";
                divNoHostFound.style.display = "none";
                hfHostID.value = "0";
                txtCostOfHost.value = "";
                txtDepositAmount.value = "";

                var divPayment = document.getElementById("<%=divPayment.ClientID %>");
                var divNoPayment = document.getElementById("<%=divNoPayment.ClientID %>");
                divPayment.style.display = "block";

                // show google map status
                var divGoogleMapStatus = "googleMapStatus" + _hostID;
                divGoogleMapStatus = document.getElementById(divGoogleMapStatus);
                divGoogleMapStatus.style.display = "none";

                // show div to updated logitute and latitude
                var _googleMapDiv = document.getElementById("<%=_googleMapDiv.ClientID %>");
                _googleMapDiv.style.display = "none";

                // set latitude
                var Latitude = "Latitude" + _hostID;
                Latitude = document.getElementById(Latitude);
                if (Latitude.value != '') {
                    document.getElementById("<%=_latitudeLongitudeText.ClientID %>").value = '';
                }

                $('#<%=_addressVerified.ClientID %>').val('');
            }

            function removeSelectedHost_Back() {
                var divHostDetails = document.getElementById("<%=divHostDetails.ClientID %>");
                var divGVHostDetails = document.getElementById("<%=divGVHostDetails.ClientID %>");
                var divNoHostFound = document.getElementById("<%=divNoHostFound.ClientID %>");
                var hfHostID = document.getElementById("<%=hfHostID.ClientID %>");

                divHostDetails.innerHTML = "";
                divHostDetails.style.display = "none";
                divGVHostDetails.style.display = "none";
                divNoHostFound.style.display = "none";
                _hostID = hfHostID;
                hfHostID.value = "0";

                // show google map status
                var divGoogleMapStatus = "googleMapStatus" + _hostID;
                divGoogleMapStatus = document.getElementById(divGoogleMapStatus);
                if (divGoogleMapStatus) divGoogleMapStatus.style.display = "none";

                // show div to updated logitute and latitude
                var _googleMapDiv = document.getElementById("<%=_googleMapDiv.ClientID %>");
                if (_googleMapDiv) _googleMapDiv.style.display = "none";

                // set latitude
                var Latitude = "Latitude" + _hostID;
                Latitude = document.getElementById(Latitude);
                if ((Latitude) && Latitude.value != '') document.getElementById("<%=_latitudeLongitudeText.ClientID %>").value = '';

                $('#<%=_addressVerified.ClientID %>').val('');

            }

            function showHidePaymentDue() {
                return true;
            }

            function showMinReqDetails() {
                var divMinReqDetails = document.getElementById("<%=divMinReqDetails.ClientID %>");
                divMinReqDetails.style.display = "block";
            }

            function hideMinReqDetails() {
                var divMinReqDetails = document.getElementById("<%=divMinReqDetails.ClientID %>");
                divMinReqDetails.style.display = "none";
            }

            function GetSelectedHostDetail(HostId) {

                var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/GetProspectByID") %>';
                var parameter = "{'HostId':'" + HostId + "'}";
                InvokeService(messageUrl, parameter, FillHostDetail);
            }

            function FillHostDetail(result) {//debugger;
                try {
                    //                $('#<%=_rbtnYPayment.ClientID %>').attr("checked", true);
                    //                divPayment.style.display = "block";
                    $('#<%= _txtPayableToForCost.ClientID %>').val(result.d.OrganizationName);
                    $('#<%= _txtCostMailingOrganization.ClientID %>').val(result.d.OrganizationName);
                    $('#<%= _txtCostDeliverAddress1.ClientID %>').val(result.d.Address.Address1);
                    $('#<%= _txtCostDeliverAddress2.ClientID %>').val(result.d.Address.Address2);
                    $('#<%= _txtCostDeliverCity.ClientID %>').val(result.d.Address.City);
                    var optVal = $("#<%= _ddlCostState.ClientID %> option:contains('" + result.d.Address.State + "')").attr('value');

                    $('#<%= _ddlCostState.ClientID %>').val(optVal);

                    $('#<%= _txtCostDeliverZip.ClientID %>').val(result.d.Address.Zip);
                    ///            result.d.ProspectDetails.PaymentMethod
                    $('#<%= _txtPayableToForDeposit.ClientID %>').val(result.d.OrganizationName);
                    $('#<%= _txtDepositeOrganization.ClientID %>').val(result.d.OrganizationName);
                    $('#<%= _txtDepositDeliverAddress1.ClientID %>').val(result.d.Address.Address1);
                    $('#<%= _txtDepositDeliverAddress2.ClientID %>').val(result.d.Address.Address2);
                    $('#<%= _txtDepositDeliverCity.ClientID %>').val(result.d.Address.City);
                    $('#<%= _ddlDepositState.ClientID %>').val(optVal);
                    $('#<%= _txtDepositDeliverZip.ClientID %>').val(result.d.Address.Zip);
                    if (result.d.Contact[0] != null) {
                        $('#<%= _txtAttentionOfForDeposit.ClientID %>').val(result.d.Contact[0].FirstName + ' ' + result.d.Contact[0].LastName);
                        $('#<%= _txtAttentionOfForCost.ClientID %>').val(result.d.Contact[0].FirstName + ' ' + result.d.Contact[0].LastName);
                    }
                }
                catch (ex) {
                }
            }

            function UpdateGoogleMapVerificatioStatus(status) {
                var AddressId = "AddressID" + _hostID;
                AddressId = document.getElementById(AddressId);
                if (!AddressId) {
                    AddressId = document.getElementById("<%=_addressId.ClientID %>");
                }
                var successFunctionAddress = function (result) {
                    if (result.d) {
                    }
                }
                var OrganizationRoleUserId = '<%=OrganizationRoleUserId%>';
                var parameter = "{'addressId':'" + AddressId.value + "'";
                parameter += ",'isManuallyVerified':'" + status + "'";
                parameter += ",'verificationOrganizationRoleUserId':'" + OrganizationRoleUserId + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/AddressController.asmx/UpdateGoogleMapVerificatioStatus")%>';
                InvokeService(messageUrl, parameter, successFunctionAddress);
            }

        </script>

        <script language="javascript" type="text/javascript">
            function validateHostInfo() {//debugger;

                var hfHostID = document.getElementById("<%=hfHostID.ClientID %>");
                var salesRepresentative = $('#' + '<%=_salesRepDropDownList.ClientID %>').val();
                var _hidSalesRep = document.getElementById("<%=_hidSalesRep.ClientID %>").value;

                if (_hidSalesRep == "0") {
                    if (salesRepresentative == '' || salesRepresentative == '0') {
                        alert("Please select HSC.");
                        return false;
                    }
                }

                if (hfHostID.value == "0") {
                    alert("Please select a host.");
                    return false;
                }
                var hfPaymentRequired = document.getElementById("<%=hfPaymentRequired.ClientID %>");
                if ($('#<%=_rbtnYPayment.ClientID %>').is(':checked')) {
                    if (ValidateHostPayment() == false) {
                        return false;
                    }
                }
                var ddlScheduledBy = document.getElementById("<%=ddlScheduledBy.ClientID %>");

                var ddlCommunicationMode = document.getElementById("<%=ddlCommunicationMode.ClientID %>");
                if (checkDropDown(ddlCommunicationMode, "Preferred communication Method") == false)
                { return false; }

                var rbtnMinReqYes = document.getElementById("<%=rbtnMinReqYes.ClientID %>");
                var rbtnMinReqNo = document.getElementById("<%=rbtnMinReqNo.ClientID %>");
                if ((rbtnMinReqYes.checked == false) && (rbtnMinReqNo.checked == false)) {
                    alert("Please select the host site conformation.");
                    return false;
                }
                if (rbtnMinReqYes.checked) {
                    var rbtnCrfmVisually = document.getElementById("<%=rbtnCrfmVisually.ClientID %>");
                    var rbtnCrfmVerbally = document.getElementById("<%=rbtnCrfmVerbally.ClientID %>");
                    if ((rbtnCrfmVisually.checked == false) && (rbtnCrfmVerbally.checked == false)) {
                        alert("Please select the mode of confirmation.");
                        return false;
                    }
                }

                // Validate for Address verification
                if (document.getElementById("<%=_addressVerified.ClientID %>").value != '') {
                    if (IsMapStatus == '') IsMapStatus = document.getElementById("<%=_addressVerified.ClientID %>").value;
                }
                if (IsMapStatus == '') {
                    alert("The Host address is not verified from Google map. Please Click on the Map link to Verify the Address.");
                    return false;
                }
                if (IsMapStatus == 'true') {
                    var latitude = document.getElementById("<%=_latitudeLongitudeText.ClientID %>");
                    if (latitude.value == '') {
                        alert('Latitude and Longitude can not left blank for the correct location.');
                        return false;
                    }
                    else if (latitude.value.indexOf(",") == -1) {
                        alert('Latitude and Longitude values should be comma seperated like "29.517834,-98.310024".');
                        return false;
                    }
                    else if (latitude.value != '') {
                        var LatitudeLongitude = latitude.value.split(',');
                        if (LatitudeLongitude.length == 1) {
                            alert('Latitude and Longitude values should be comma seperated like "29.517834,-98.310024".');
                            return false;
                        }
                        if (LatitudeLongitude.length != 2) {
                            alert('Latitude and Longitude can not left blank for the correct location.');
                            return false;
                        }
                    }
                }
                return true;
            }

            function AllowNumericOnly(evt) {
                return KeyPress_DecimalAllowedOnly(evt);
            }
            function validateSearch() {
                var txtSearch = document.getElementById("<%=txtSearch.ClientID %>");
                if (txtSearch.value.trim() == "") {
                    alert("Please enter text to search host.");
                    return false;
                }

            }
            function ValidateHostPayment() {
                var txtCostOfHost = document.getElementById("<%=txtCostOfHost.ClientID %>");
                if (isBlank(txtCostOfHost, "Cost Of Hosting Event")) { return false; }

                if ($('#<%=_chkCheckForCost.ClientID %>').is(':checked') == false && ($('#<%=_chkCreditCardForCost.ClientID %>').is(':checked') == false)) {
                    alert("Please select payment method for cost");
                    return false;
                }
                var eventId = "<%=EventId %>";
                if ($('#' + '<%=HostPaymentPaidHidden.ClientID %>').val() == "False") {
                    if (isBlank(document.getElementById('<%= _txtPayableToForCost.ClientID %>'), "Payable to for Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtAttentionOfForCost.ClientID %>'), "Attention of for Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtCostMailingOrganization.ClientID %>'), "Organization name for Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtCostDeliverAddress1.ClientID %>'), "Address of Delivery for Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtCostDeliverCity.ClientID %>'), "City of Delivery for Payment")) { return false; }
                    if (checkDropDown(document.getElementById('<%= _ddlCostState.ClientID %>'), "State of Delivery for Payment") == false) { return false; }
                    if (isBlank(document.getElementById('<%= _txtCostDeliverZip.ClientID %>'), "Zip of Delivery for Payment")) { return false; }
                    if (isInteger(document.getElementById('<%= _txtCostDeliverZip.ClientID %>'), "Zip of Delivery for Payment") != true) { return false; }
                }
                if ($('#<%=_rbtDepositY.ClientID %>').is(':checked') && $('#' + '<%=HostDepositPaidHidden.ClientID %>').val() == "False") {
                    var txtDepositAmount = document.getElementById("<%=txtDepositAmount.ClientID %>");
                    if (isBlank(txtDepositAmount, "Deposit amount"))
                    { return false; }

                    var txtDepositDue = document.getElementById("<%=txtDepositDue.ClientID %>");
                    if (txtDepositDue.value != "") {
                        if (!ValidateDate(txtDepositDue.value, 'Deposit Due By Date'))
                            return false;
                    }
                    if ($('#<%=_chkCheckForDeposit.ClientID %>').is(':checked') == false && ($('#<%=_chkCreditCardForDeposit.ClientID %>').is(':checked') == false)) {
                        alert("Please select payment method for deposit");
                        return false;
                    }
                    if (isBlank(document.getElementById('<%= _txtPayableToForDeposit.ClientID %>'), "Payable To for Payment of Deposit Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtAttentionOfForDeposit.ClientID %>'), "Attention of for Payment of Deposit Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtDepositeOrganization.ClientID %>'), "Organization name for Payment of Deposit Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtDepositDeliverAddress1.ClientID %>'), "Address for Delivery of Deposit Payment")) { return false; }
                    if (isBlank(document.getElementById('<%= _txtDepositDeliverCity.ClientID %>'), "City for Delivery of Deposit Payment")) { return false; }
                    if (checkDropDown(document.getElementById('<%= _ddlDepositState.ClientID %>'), "State for Delivery of Deposit Payment") == false) { return false; }
                    if (isBlank(document.getElementById('<%= _txtDepositDeliverZip.ClientID %>'), "Zip for Delivery of Deposit Payment")) { return false; }
                    if (isInteger(document.getElementById('<%= _txtDepositDeliverZip.ClientID %>'), "Zip for Delivery of Deposit Payment") != true) { return false; }


                    if ((!$('#<%= _rbtAppliedToCost.ClientID %>').is(':checked')) && (!$('#<%= _rbtReturnToOffice.ClientID %>').is(':checked'))) {
                        alert("Please select whether deposit will be adjusted with the cost of event or will be refunded to the corporate office");
                        return false;
                    }
                    // check if deposit amount is adjusted in payment , it should be less than room rent.
                    if ($('#<%= _rbtAppliedToCost.ClientID %>').is(':checked') && txtCostOfHost.value != '' && txtDepositAmount.value != '')
                        if (parseFloat(txtCostOfHost.value) < parseFloat(txtDepositAmount.value)) {
                            alert("In case the deposit amount is applied to cost of the event,The deposit amount should be less or equals to the cost of hosting event.");
                            txtDepositAmount.focus();
                            return false;
                        }

                    var _txtEventCancelBy = document.getElementById("<%=_txtEventCancelBy.ClientID %>");

                    if (_txtEventCancelBy.value.trim() == "") {
                        alert('Please enter the date before which <%= IoC.Resolve<ISettings>().CompanyName%> should cancel  the event to receive total refund.');
                        return false;
                    }
                    if (_txtEventCancelBy.value != "") {
                        if (!ValidateDate(_txtEventCancelBy.value, 'Event Cancelation date to get full refund'))
                            return false;
                    }
                    // check for dates are in correct format and alert of date is after event date
                }



                /////
            }
        </script>

        <script language="javascript" type="text/javascript">
            function ShowPaymentDetails() {
                var divPayment = document.getElementById("<%=divPayment.ClientID %>");
                var hfPaymentRequired = document.getElementById("<%=hfPaymentRequired.ClientID %>");
                divPayment.style.display = "block";
                hfPaymentRequired.value = "1";
                $('#<%=_rbtDepositY.ClientID %>').attr("checked", true);
                ShowDepositDetails();

            }

            function HidePaymentDetails() {
                var divPayment = document.getElementById("<%=divPayment.ClientID %>");
                var divNoPayment = document.getElementById("<%=divNoPayment.ClientID %>");
                var hfPaymentRequired = document.getElementById("<%=hfPaymentRequired.ClientID %>");
                divPayment.style.display = "none";
                hfPaymentRequired.value = "0";
                $('#<%=_rbtDepositY.ClientID %>').attr("checked", false);
                $('#<%=_rbtDepositN.ClientID %>').attr("checked", true);
                HideDepositDetails();
            }

            function ShowDepositDetails() {
                $('#dvDeposit').show();
            }

            function HideDepositDetails() {
                $('#dvDeposit').hide();
            }
        </script>

        <script language="javascript" type="text/javascript">
            // get salesRepresentatives 
            var territoryChecked = false;
            $(document).ready(function () {

                var decoded = $("<textarea/>").html($("#<%= divToolTip.ClientID %>").html()).text();
                $("#<%= divToolTip.ClientID %>").html(decoded);

                $('#' + '<%=_franchiseeDropDownList.ClientID %>').change(function () {
                    var franchiseeId = $('#' + '<%=_franchiseeDropDownList.ClientID %>').val();
                    var _hidFranchiseeId = document.getElementById("<%=_hidFranchiseeId.ClientID %>");
                    if (franchiseeId > 0) {
                        _hidFranchiseeId.value = franchiseeId;
                        var parameter = "{'franchiseeId':" + franchiseeId + "}";
                        var messageUrl = '<%=ResolveUrl("~/App/Controllers/FranchiseeUserController.asmx/GetSalesRepresentativesForFranchisee")%>';
                        InvokeService(messageUrl, parameter, FillSalesRep);
                    }
                    else {
                        $('#' + '<%=_salesRepDropDownList.ClientID %> >option').remove();
                        $('#' + '<%=_salesRepDropDownList.ClientID %>').append($('<option></option>').val('0').html('No HSC Found'));
                    }
                });

                $('#' + '<%=_salesRepDropDownList.ClientID %>').change(function () {
                    var salesRepresentative = $('#' + '<%=_salesRepDropDownList.ClientID %>').val();
                    var zipCode = '<%=ZipCode %>';
                    if (salesRepresentative > 0 && zipCode != "" && !territoryChecked) {
                        var parameter = "{'salesRepId':'" + salesRepresentative + "',";
                        parameter += "'zipCode':'" + zipCode + "'}";
                        var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/CheckTerritoryForSalesRepByZipcode")%>';
                        return InvokeService(messageUrl, parameter, CheckTerritoryForNewsalesRep);
                    }
                    else {
                        var salesRepresentative = $('#' + '<%=_salesRepDropDownList.ClientID %>').val();
                        var _hidSalesRepId = document.getElementById("<%=_hidSalesRepId.ClientID %>");

                        if (salesRepresentative > 0) {
                            _hidSalesRepId.value = salesRepresentative;
                        }
                    }
                });

                var franchiseeId = $('#' + '<%=_franchiseeDropDownList.ClientID %>').val();
                var _hidFranchiseeId = document.getElementById("<%=_hidFranchiseeId.ClientID %>");

                if (franchiseeId > 0) {
                    _hidFranchiseeId.value = franchiseeId;
                    var parameter = "{'franchiseeId':" + franchiseeId + "}";
                    var messageUrl = '<%=ResolveUrl("~/App/Controllers/FranchiseeUserController.asmx/GetSalesRepresentativesForFranchisee")%>';
                    InvokeService(messageUrl, parameter, FillSalesRep);
                }

            });
            // fill salesRepresentatives
            function FillSalesRep(salesRepresentatives) {//debugger;
                $('#' + '<%=_salesRepDropDownList.ClientID %> >option').remove();
                if (salesRepresentatives.d.length > 0) {
                    for (var i = 0; i < salesRepresentatives.d.length; i++) {
                        var currentSearchItem = salesRepresentatives.d[i];
                        $('#' + '<%=_salesRepDropDownList.ClientID %>').append($('<option></option>').val(salesRepresentatives.d[i].SalesRepresentativeId).html(salesRepresentatives.d[i].Name.FullName));
                    }

                    var _hidSalesRepId = document.getElementById("<%=_hidSalesRepId.ClientID %>");
                    if (_hidSalesRepId.value != '' && _hidSalesRepId.value != '0') {
                        $('#' + '<%=_salesRepDropDownList.ClientID %>').val(_hidSalesRepId.value);
                    }
                    var salesRepresentative = $('#' + '<%=_salesRepDropDownList.ClientID %>').val();

                    if (salesRepresentative > 0) {
                        _hidSalesRepId.value = salesRepresentative;
                    }
                }
                else {
                    $('#' + '<%=_salesRepDropDownList.ClientID %>').append($('<option></option>').val('0').html('No HSC Found'));
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
                        //alert(a.responseText);
                    }
                })
            }

            function CheckTerritoryForNewsalesRep(territoryAvailable) {
                var _hidSalesRepId = document.getElementById("<%=_hidSalesRepId.ClientID %>");
                if (territoryAvailable.d == false) {
                    var confirmSalesRepCahnge = confirm("The selected host for the event doesnot falls in the territory of the salesrep selected by you. You need to select another host for the event. Do you wish to continue?");
                    if (confirmSalesRepCahnge) {
                        var salesRepresentative = $('#' + '<%=_salesRepDropDownList.ClientID %>').val();
                        if (salesRepresentative > 0) {
                            _hidSalesRepId.value = salesRepresentative;
                            document.getElementById("<%=divHostDetails.ClientID %>").style.display = "none";
                            document.getElementById("<%=divGVHostDetails.ClientID %>").style.display = "none";
                            document.getElementById("<%=divNoHostFound.ClientID %>").style.display = "none";
                            territoryChecked = true;
                        }
                    }
                    else {
                        $('#' + '<%=_salesRepDropDownList.ClientID %>').val(_hidSalesRepId.value);
                    }
                }
                else {
                    var salesRepresentative = $('#' + '<%=_salesRepDropDownList.ClientID %>').val();
                    if (salesRepresentative > 0) {
                        _hidSalesRepId.value = salesRepresentative;
                    }
                }
            }
            function DisableEditing(CostOrDeposit) {

                if (CostOrDeposit == 'Deposit') {
                    $('.depositDisable').attr('disabled', true);
                    $('#' + '<%=_chkCheckForDeposit.ClientID %>').attr('disabled', 'disabled');
                    $('#' + '<%=_chkCreditCardForDeposit.ClientID %>').attr('disabled', 'disabled');
                    $('#' + '<%=_rbtAppliedToCost.ClientID %>').attr('disabled', 'disabled');
                    $('#' + '<%=_rbtReturnToOffice.ClientID %>').attr('disabled', 'disabled');
                    $('#' + '<%=HostDepositPaidHidden.ClientID %>').val('True');

                }
                if (CostOrDeposit == 'Cost') {
                    $('.costDisable').attr('disabled', true);
                    $('#' + '<%=_chkCheckForCost.ClientID %>').attr('disabled', 'disabled');
                    $('#' + '<%=_chkCreditCardForCost.ClientID %>').attr('disabled', 'disabled');
                    $('#' + '<%=HostPaymentPaidHidden.ClientID %>').val('True');
                }
            }
        </script>

        <asp:HiddenField ID="HostPaymentPaidHidden" runat="server" Value="False" />
        <asp:HiddenField ID="HostDepositPaidHidden" runat="server" Value="False" />
        <div class="wrapper_inpg">
            <h1 class="left" id="headingEventWizard" runat="server">Create Event Wizard</h1>
            <div class="hr left">
            </div>
            <div class="headingbox_top_body">
                Here you can create your event and setup all event related activities – like selecting
            advocates
            </div>
            <div class="headingbox_top_body">
                <img src="/App/Images/createeventwizardsteps.gif" alt="" />
            </div>
            <div style="float: left; overflow: hidden; width: 400px; height: 80px; margin: -80px 0px 0px 250px; background: rgba(0, 0, 0, 0.3); border: 1px solid #cdcdcd;">
                &nbsp;
            </div>

            <div class="headingbox_top_body" style="margin-top: 10px;">
                <span class="orngbold18_default">Step 1 : Select and Verify Host Information </span>
            </div>
            <div class="hr left">
            </div>
            <div class="greybox_rols" id="_divrolewrapper" runat="server">
                <div class="maindivpagemainrow_anp">
                    <span id="_spnFranchisee" runat="server">
                        <label class="titletextsmallbld_default">
                            Franchisee:</label>
                        <asp:DropDownList ID="_franchiseeDropDownList" runat="server" CssClass="inputfieldconleft_default"
                            Width="180px">
                        </asp:DropDownList>
                    </span><span id="_spnSalesRep" runat="server">
                        <label class="titletextsmallbld_default">
                            Coordinator:<span class="reqiredmark"><sup>*</sup></span></label>
                        <asp:DropDownList ID="_salesRepDropDownList" runat="server" CssClass="inputfieldright_default"
                            Width="180px">
                        </asp:DropDownList>
                    </span>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;" id="_divFranchisor"
                    runat="server">
                    <i>Note: Since you are creating this event as a Franchisor - you need to select the
                    Franchisee and HSC that going to own this event.</i>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;" id="_divFranchisee"
                    runat="server">
                    <i>Since you are creating the event as a Franchisee - you need to select the HSC that
                    is going to own this event.</i>
                </div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page1symbolvsmall.gif" alt="" />
                <h2 class="toppad">Select Location where you want the event to be hosted</h2>
            </div>
            <div class="main_area_bdrnone">
                <div class="maindivpagemainrow_anp">
                    <div id="_divSearchHost" runat="server">
                        <p class="pagemainrow_anp">
                            &nbsp;<asp:Panel ID="pnlSearchHost" runat="server" DefaultButton="ibtnFind">
                                <span class="titletextnowidth_default" style="margin-right: 5px">Host Name/ID:<span
                                    class="reqiredmark"><sup>*</sup></span> </span><span class="inputfldnowidth_default"
                                        style="margin-right: 5px;">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="inputf_def" Width="200px"></asp:TextBox>
                                    </span><span class="titletextnowidth_default" style="margin-right: 5px;">City:</span>
                                <span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtCity" runat="server" CssClass="inputf_def auto-Search" Width="80px"></asp:TextBox>
                                </span><span class="button_con_nowidth">
                                    <asp:ImageButton ID="ibtnClear" runat="server" ImageUrl="~/App/Images/clear-btn.gif"
                                        OnClick="ibtnClear_Click" />
                                </span><span class="button_con_nowidth">
                                    <asp:ImageButton ID="ibtnFind" runat="server" ImageUrl="~/App/Images/find-btn.gif"
                                        OnClick="ibtnFind_Click" OnClientClick="return validateSearch();" />
                                </span>
                            </asp:Panel>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="left">Type in the name, so the system can list it for you, or click on
                            find to do a more advanced search.</span> <span class="rgt" id="grdLegend" runat="server"
                                style="display: none;"><a href="#">
                                    <img src="/App/Images/good-legend.gif" alt="legend" class="jtiphostperformance" title='Good| If the average number of customers registered for conducted events on this host is greater than 35.<br /><b>Note</b>: If no event is conducted till date on the host then "NA" will appear.' /></a>
                                <a href="#" class="jtiphostperformance" title='Average| If the average number of customers registered for conducted events on this host is between 15 to 35.<br /><b>Note</b>: If no event is conducted till date on the host then "NA" will appear. '>
                                    <img src="/App/Images/average-legend.gif" alt="legend" /></a> <a href="#" class="jtiphostperformance"
                                        title='Bad| If the average number of customers registered for conducted events on this host is less than 15.<br /> <b>Note</b>: If no event is conducted till date on the host then "NA" will appear.'>
                                        <img src="/App/Images/bad-legend.gif" alt="legend" /></a> </span>
                        </p>
                    </div>
                    <div id="divGVHostDetails" runat="server" class="left">
                        <asp:GridView ID="gvHostDetails" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                            GridLines="None" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvHostDetails_PageIndexChanging"
                            OnRowDataBound="gvHostDetails_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div id='div<%#DataBinder.Eval(Container.DataItem, "HostID")%>'>
                                            <div class="pagemainrow_anp">
                                                <div class="greybox_cew">
                                                    <div class="row">
                                                        <div class="innerboxes1_cew">
                                                            <p class="row">
                                                                <span class="blktext13px_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "HostName")%></span>
                                                            </p>
                                                            <p class="row" id="_hostaddress1">
                                                                <%#DataBinder.Eval(Container.DataItem, "Address1")%>
                                                            </p>
                                                            <p class="row" id="pAddress2" runat="server">
                                                                <%#DataBinder.Eval(Container.DataItem, "Address2")%>
                                                            </p>
                                                            <p class="row" id="_cityStateZip">
                                                                <%#DataBinder.Eval(Container.DataItem, "City")%>,&nbsp;<%#DataBinder.Eval(Container.DataItem, "State")%>&nbsp;&nbsp;<%#DataBinder.Eval(Container.DataItem, "Zip")%>
                                                            </p>
                                                            <p class="row" id="_completeAddress" style="display: none">
                                                                <%#DataBinder.Eval(Container.DataItem, "Address1")%>
                                                            </p>
                                                            <p class="row">
                                                                <span class="left"><a id='aEditHost<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                    href='/App/Common/AddNewHost.aspx?HostID=<%#DataBinder.Eval(Container.DataItem, "HostID")%>'>Edit</a></span> <span class="left"><a id='aEditSelectedHost<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                        href='/App/Common/AddNewHost.aspx?Type=Selected&HostID=<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                        style="display: none;">Edit</a> </span><span class="left">&nbsp;|&nbsp;</span>
                                                                <span class="left"><a onclick="javascript:EnableAddressVerification();" id="_googleMapUrl"
                                                                    runat="server" target="_blank">Map</a></span> </span> <span style="margin-left: 5px">
                                                                        <a href="#" class="jtipMap" title='What is this | Please click on the "Map" link to open the address on a map in a new window. Once you have visually verified that the map location, come back to this screen and the "Is Google Map Correct?" will be enabled. Please select "Yes" or "No" to complete the verification.'
                                                                            style="text-decoration: none; font: bold 14px arial">?</a></span>
                                                            </p>
                                                            <div class="gglmap" id='googleMapStatus<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                style="display: none">
                                                                <label class="blkbold12_default">
                                                                    Is Google Map Correct?<span class="reqiredmark"><sup>*</sup></span></label><br />
                                                                <input type="radio" class="YesRadio" id='googleMapCorrect<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                    value="Yes" name="GoogleMap" onclick="setIsMap('Yes');">Yes
                                                            <input type="radio" class="NoRadio" id='googleMapInCorrect<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                value="No" name="GoogleMap" onclick="setIsMap('No');">No
                                                            </div>
                                                            <input type="hidden" id='AddressID<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                value='<%#DataBinder.Eval(Container.DataItem, "AddressID")%>' />
                                                            <input type="hidden" id='Latitude<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                value='<%#DataBinder.Eval(Container.DataItem, "Latitude")%>' />
                                                            <input type="hidden" id='Longitude<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                value='<%#DataBinder.Eval(Container.DataItem, "Logitude")%>' />
                                                            <input type="hidden" id='IsManuallyVerified<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                value='<%#DataBinder.Eval(Container.DataItem, "IsManuallyVerified")%>' />
                                                            <input type="hidden" id='UseLatLogForMapping<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                value='<%#DataBinder.Eval(Container.DataItem, "UseLatLogForMapping")%>' />
                                                        </div>
                                                        <div class="innerboxes_cew">
                                                            <p class="row">
                                                                <span class="blktext13px_default">Primary Contact</span>
                                                            </p>
                                                            <p class="row">
                                                                <span class="ttxtnowidthnormal_default">Name:</span> <span class="ttxtnowidthnormal_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "ContactName")%>
                                                                </span>
                                                            </p>
                                                            <p class="row">
                                                                <span class="ttxtnowidthnormal_default">Phone (Home):</span> <span class="ttxtnowidthnormal_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "PhoneHome")%>
                                                                </span>
                                                            </p>
                                                            <p class="row">
                                                                <span class="ttxtnowidthnormal_default">Phone (Cell):</span> <span class="ttxtnowidthnormal_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "PhoneCell")%>
                                                                </span>
                                                            </p>
                                                            <p class="row">
                                                                <span class="ttxtnowidthnormal_default">Email:</span> <span class="ttxtnowidthnormal_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "EMail")%>
                                                                </span>
                                                            </p>
                                                            <p class="row">
                                                                <asp:LinkButton ID="lbtnEditContact" runat="server" Text="Edit" CommandName='<%#DataBinder.Eval(Container.DataItem, "ContactID")%>'
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "HostID")%>' OnClick="lbtnEditContact_Click"></asp:LinkButton>
                                                            </p>
                                                        </div>
                                                        <div class="innerboxes_cews" style="border-right: none">
                                                            <p class="row">
                                                                <span class="blktext13px_default">Host Performance</span>
                                                            </p>
                                                            <p class="row">
                                                                <span class="ttxtnowidthnormal_default">Total Event:</span> <span class="ttxtnowidthnormal_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "TotalEvent")%>
                                                                </span>
                                                            </p>
                                                            <p class="row">
                                                                <span class="ttxtnowidthnormal_default">Customers Per Event:</span> <span class="ttxtnowidthnormal_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "CustomersPerEvent")%>
                                                                </span>
                                                            </p>
                                                            <p class="row" style="width: 170px;">
                                                                <span class="ttxtnowidthnormal_default">Overall Rank:</span> <span class="ttxtnowidthnormal_default"
                                                                    id="spRank" runat="server" style="width: 80px;"><< >> </span>
                                                            </p>
                                                            <p class="row">
                                                                <img id="imgRanking" runat="server" src="/App/Images/good-sign.gif " />
                                                            </p>
                                                        </div>
                                                        <div style="float: right;">
                                                            <a href="javascript:void(0);" id='aSelect<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                onclick='selectHost(<%#DataBinder.Eval(Container.DataItem, "HostID")%>)'>
                                                                <img src="/App/Images/select-button.gif" alt="Select" />
                                                            </a><a href="javascript:void(0);" id='aRemove<%#DataBinder.Eval(Container.DataItem, "HostID")%>'
                                                                onclick="removeSelectedHost();" style="display: none;">Remove</a>
                                                        </div>
                                                        <div id='divFacilitiesFee<%#DataBinder.Eval(Container.DataItem, "HostID")%>' style="display: none;">
                                                            <%#DataBinder.Eval(Container.DataItem, "FacilitiesFee")%>
                                                        </div>
                                                        <div id='divDepositsAmount<%#DataBinder.Eval(Container.DataItem, "HostID")%>' style="display: none;">
                                                            <%#DataBinder.Eval(Container.DataItem, "DepositsAmount")%>
                                                        </div>
                                                        <div id='divPaymentMethod<%#DataBinder.Eval(Container.DataItem, "HostID")%>' style="display: none;">
                                                            <%#DataBinder.Eval(Container.DataItem, "PaymentMethod")%>
                                                        </div>
                                                        <div id='divTaxIdNumber<%#DataBinder.Eval(Container.DataItem, "HostID")%>' style="display: none;">
                                                            <%#DataBinder.Eval(Container.DataItem, "TaxIdNumber")%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div id="divNoHostFound" runat="server" style="display: none; color: Red; font-style: italic;">
                        No Records Found
                    </div>
                    <div id="divHostDetails" runat="server" style="display: none;">
                        <div class="pagemainrow_anp">
                            <div class="greybox_cew">
                                <div class="row">
                                    <div class="innerboxes1_cew">
                                        <p class="row">
                                            <span class="blktext13px_default" id="spHostName" runat="server">Full Host Name Host
                                            Name</span>
                                        </p>
                                        <p class="row" id="pAddress1" runat="server">
                                            << Street 1 >>
                                        </p>
                                        <p class="row" id="pAddress2" runat="server">
                                            << apt, suite >>
                                        </p>
                                        <p class="row" id="pCityStateZip" runat="server">
                                            << City State Zip >>
                                        </p>
                                        <p class="row">
                                            <a href="javascript:void(0);" id="aEditHost" runat="server">Edit</a>&nbsp;|&nbsp;<a
                                                onclick="javascript:EnableAddressVerification(0);" href="javascript:void(0);"
                                                id="aMapHost" runat="server">Map</a><span style="margin-left: 5px"><a href="#" class="jtipMapDiv"
                                                    title='What is this | Please click on the "Map" link to open the address on a map in a new window. Once you have visually verified that the map location, come back to this screen and the "Is Google Map Correct?" will be enabled. Please select "Yes" or "No" to complete the verification.'
                                                    style="text-decoration: none; font: bold 14px arial">?</a></span>
                                        </p>
                                        <div class="gglmap" style="display: block">
                                            <label>
                                                <strong>Is Google Map Correct? <span class="reqiredmark"><sup>*</sup></span></strong></label><br />
                                            <input type="radio" id="googleMapCorrectVirtual" value="Yes" name="GoogleMap" onclick="setIsMap('Yes');"
                                                runat="server" />Yes
                                        <input type="radio" id="googleMapInCorrectVirtual" value="No" name="GoogleMap" onclick="setIsMap('No');"
                                            runat="server" />No
                                        </div>
                                    </div>
                                    <div class="innerboxes_cew">
                                        <p class="row">
                                            <span class="blktext13px_default">Primary Contact</span>
                                        </p>
                                        <p class="row">
                                            <span class="ttxtnowidthnormal_default">Name:</span> <span class="ttxtnowidthnormal_default"
                                                id="spContactName" runat="server">-N/A- </span>
                                        </p>
                                        <p class="row">
                                            <span class="ttxtnowidthnormal_default">Phone (Home):</span> <span class="ttxtnowidthnormal_default"
                                                id="spPhHome" runat="server">XXX </span>
                                        </p>
                                        <p class="row">
                                            <span class="ttxtnowidthnormal_default">Phone (Cell):</span> <span class="ttxtnowidthnormal_default"
                                                id="spPhCell" runat="server">XXX </span>
                                        </p>
                                        <p class="row">
                                            <span class="ttxtnowidthnormal_default">Email:</span> <span class="ttxtnowidthnormal_default"
                                                id="spEmail" runat="server">aaa </span>
                                        </p>
                                        <p class="row">
                                            <a href="javascript:void(0);" id="aEditContact" runat="server">Edit</a>
                                        </p>
                                    </div>
                                    <div class="innerboxes_cews" style="border-right: none">
                                        <p class="row">
                                            <span class="blktext13px_default">Host Performance</span>
                                        </p>
                                        <p class="row">
                                            <span class="ttxtnowidthnormal_default">Total Event:</span> <span class="ttxtnowidthnormal_default"
                                                id="spTotalEvent" runat="server">XXX </span>
                                        </p>
                                        <p class="row">
                                            <span class="ttxtnowidthnormal_default">Customers Per Event:</span> <span class="ttxtnowidthnormal_default"
                                                id="spCustPerEvent" runat="server">XXX </span>
                                        </p>
                                        <p class="row" style="width: 170px;">
                                            <span class="ttxtnowidthnormal_default">Overall Rank:</span> <span class="ttxtnowidthnormal_default"
                                                id="spRank" runat="server"><< >> </span>
                                        </p>
                                        <p class="row">
                                            <img id="imgRanking" runat="server" src="/App/Images/good-sign.gif" />
                                        </p>
                                    </div>
                                    <div style="float: right;" id="_divRemoveHost" runat="server">
                                        <a href="javascript:void(0);" onclick="removeSelectedHost_Back();">Remove</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="HostRatingDiv" style="display: none;">
                        <div class="pagemainrow_anp">
                            <div class="greybox_cew">
                                <div class="row">
                                    <span class="graybold14_default">
                                        <img src="/App/Images/plus-sign.gif" class="coll-exp-img plus-img" onclick="ManageHideShowHostFacilityDiv('show');" style="cursor: pointer; display: block;" />
                                        <img src="/App/Images/minus-signs.gif" class="coll-exp-img" onclick="ManageHideShowHostFacilityDiv('hide');" style="cursor: pointer; display: none;" />
                                        <u>Host Facility Details</u> <span id="hostDetailsNASpan">Not Available </span></span>
                                </div>
                                <div id="HostFacilityDetailsDiv" class="hostfacility-detail-div" style="display: none;">
                                    <div class="row">
                                        <span class="titletextlarge_default">Number of Plug Points:</span> <span id="NumberofPlugPointsSpan"
                                            class="ttxtwidthnormalsmall_default"></span><span class="titletext1a_default">Room Size:</span>
                                        <span id="RoomSizeSpan" class="ttxtwidthnormalsmall_default"></span>
                                    </div>
                                    <div class="row">
                                        <span class="titletextlarge_default">Room Needs Cleared:</span> <span id="RoomNeedClearedSpan"
                                            class="ttxtwidthnormalsmall_default"></span><span class="titletext1a_default">Internet
                                            Access:</span> <span id="InternetAccessSpan" class="ttxtwidthnormalsmall_default"></span>
                                    </div>
                                    <div class="row">
                                        <span class="titletextlarge_default">Host Ranking: </span><span id="HostRankingSpan"
                                            class="ttxtwidthnormalsmall_default"></span>
                                    </div>
                                    <div class="hr left">
                                    </div>
                                    <div class="row">
                                        <span class="titletextnowidth_default">Comments:</span> <span class="ttxtwidthnormal_default"
                                            id="CommentsByFranchisee" style="width: 500px"></span>
                                    </div>
                                    <div class="row">
                                        <span class="titletextnowidth_default">Images:</span><br />
                                        <div id="HostImagesDiv" class="inrrow" style="width: 600px; border: solid 1px #ccc; overflow-x: scroll;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="pagemainrow_anp" id="_googleMapDiv" runat="server" style="display: none">
                        <div class="greybox_cew">
                            <div class="row">
                                <strong>Corrected Latitude&nbsp;&amp;&nbsp;Longitude:&nbsp;</strong><asp:TextBox
                                    ID="_latitudeLongitudeText" runat="server" Width="250px" MaxLength="255" CssClass="LatLongText" />
                                &nbsp;&nbsp;<a href="javascript:void(0);" onclick="OpenGoogleMapStep();">How do I get
                                this?</a>&nbsp;&nbsp;<br />
                                <asp:CheckBox ID="checkLatLongUseForMap" runat="server" Text="This location is correct - use this for displaying the "
                                    Checked="true" CssClass="LatLogCheckBox" />
                                &nbsp;<a href="#" id="_newGoogleMap" onclick="SetNewMap();">Map</a>&nbsp;&nbsp;
                            <%--<input type="button" id="inputsave" class="button" value="Save" onclick="return SaveHostAddressLogitudeLatitude();" />--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="subhead">
                    <img src="/App/Images/page2symbolvsmall.gif" alt="" />
                    <h2 class="toppad">Event Payment Details</h2>
                </div>
                <div class="maindivpagemainrow_anp">
                    <div class="pagemainrow_anp" style="margin-top: 10px; display: block;" id="divNoPayment"
                        runat="server">
                        <div class="greybox_cew" id="_dvPaymentOption" runat="server">
                            <div class="row" style="color: #000">
                                Are there any fees associated with this event?
                            <asp:RadioButton ID="_rbtnYPayment" runat="server" GroupName="Payment" Text="Yes"
                                Checked="true" />
                                <asp:RadioButton ID="_rbtnNPayment" runat="server" GroupName="Payment" Text="No" />
                            </div>
                        </div>
                    </div>
                    <div class="pagemainrow_anp" id="divPayment" runat="server">
                        <div class="greybox_cew">
                            <div class="infobar" id="_dvPaymentStatus" runat="server" style="background: #fff0a5; display: none">
                                Status : Paid [ <a href="#" class="jtip" title='Note|<%=PaymentNotes%>'>Detail</a> ]
                            </div>
                            <p class="row">
                                <span class="blktext14px_default" style="float: left; margin-right: 10px;">Cost of Hosting
                                Event:<span class="reqiredmark"><sup>*</sup></span></span> <span class="inputfldnowidth_default"
                                    style="margin-right: 25px;">
                                    <asp:TextBox ID="txtCostOfHost" runat="server" CssClass="inputf_def costDisable"
                                        Width="120px" MaxLength="6"></asp:TextBox>
                                </span><span class="blktext14px_default" style="float: left; margin-right: 10px;">Payment
                                    Method:<span class="reqiredmark"><sup>*</sup></span></span> <span class="inputfldnowidth_default"
                                        style="float: left;">
                                        <asp:CheckBox runat="server" ID="_chkCheckForCost" Text="Check" CssClass="costDisable" />
                                        <asp:CheckBox runat="server" ID="_chkCreditCardForCost" Text="Credit Card" CssClass="costDisable" />
                                    </span>
                            </p>
                            <p class="row2">
                                <label class="lbl1">
                                    Due Date:</label>
                                <span class="left" style="margin-right: 5px">
                                    <asp:TextBox ID="txtPaymentDue" runat="server" CssClass="inputf_def date-picker costDisable"
                                        Width="120px"></asp:TextBox>
                                    <span id="nodate"><a href="#" style="font-size: 18px; font-weight: bold; text-decoration: none"
                                        class="jtip" title='Note |<span class="smallttextnowidth_default" >You can leave due date blank, it will be set to 14 days prior to the event date, if you explicitly want to set it – it must be ATLEAST one day ahead of the event date. </span>'>?</a></span> </span>
                                <label style="width: 80px" class="lbl1">
                                    Payable to:<span class="reqiredmark"><sup>*</sup></span></label>
                                <span class="left">
                                    <asp:TextBox ID="_txtPayableToForCost" runat="server" CssClass="inputf_def costDisable"
                                        Width="214px" /></span>
                            </p>
                            <p class="row2">
                                <label class="lbl1">
                                    Mail to the attention of:<span class="reqiredmark"><sup>*</sup></span></label>
                                <span class="left">
                                    <asp:TextBox ID="_txtAttentionOfForCost" runat="server" CssClass="inputf_def costDisable"
                                        Width="120px" /></span>
                            </p>
                            <p class="row2">
                                <label class="lbl1">
                                    Deliver to:</label>
                                <span class="add_box"><span class="hrow">
                                    <label class="lbln">
                                        Organization name :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox
                                            ID="_txtCostMailingOrganization" runat="server" CssClass="inputf_def left costDisable"
                                            Width="329px" /></span> <span class="hrow">
                                                <label class="lbln">
                                                    Address :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox ID="_txtCostDeliverAddress1"
                                                        runat="server" CssClass="inputf_def left costDisable" Width="120px" />
                                                <label class="lbln">
                                                    &nbsp;&nbsp; Suite, Apt, etc :</label><asp:TextBox ID="_txtCostDeliverAddress2" runat="server"
                                                        CssClass="inputf_def left costDisable" Width="163px" /></span>
                                    <span class="hrow">
                                        <label class="lbln" style="width: 56px">
                                            City :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox ID="_txtCostDeliverCity"
                                                runat="server" CssClass="inputf_def left auto-search-cost costDisable" Width="120px" />
                                        <label class="lbln">
                                            &nbsp;&nbsp;State :<span class="reqiredmark"><sup>*</sup></span></label><asp:DropDownList
                                                runat="server" ID="_ddlCostState" class="cost-state-dropdown left costDisable"
                                                Style="width: 100px;">
                                            </asp:DropDownList>
                                        <label class="lbln">
                                            &nbsp;&nbsp;Zip :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox
                                                ID="_txtCostDeliverZip" runat="server" CssClass="inputf_def left costDisable"
                                                Width="60px" /></span> </span>
                            </p>
                            <div class="infobar" id="_dvDepositStatus" runat="server" style="background: #fff0a5; display: none">
                                Status : Paid [ <a href="#" class="jtip" title='Notes |<span class="smallttextnowidth_default" runat="server" id="_spDepositNotes"></span>'>Detail</a> ]
                            </div>
                            <div class="greybar" id="_dvDepositOption" runat="server">
                                Is Deposit required?
                            <asp:RadioButton ID="_rbtDepositY" runat="server" GroupName="Deposit" Text="Yes"
                                Checked="true" />
                                <asp:RadioButton ID="_rbtDepositN" runat="server" GroupName="Deposit" Text="No" />
                            </div>
                            <div class="row" id="dvDeposit">
                                <p class="row" style="margin-top: 15px">
                                    <span class="blktext14px_default" style="float: left; margin-right: 52px;">Deposit Amount:<span
                                        class="reqiredmark"><sup>*</sup></span></span> <span class="inputfldnowidth_default"
                                            style="margin-right: 25px;">
                                            <asp:TextBox ID="txtDepositAmount" runat="server" CssClass="inputf_def depositDisable"
                                                Width="120px" MaxLength="6"></asp:TextBox>
                                        </span><span class="blktext14px_default" style="float: left; margin-right: 10px;">Payment
                                        Method:<span class="reqiredmark"><sup>*</sup></span></span> <span class="inputfldnowidth_default"
                                            style="float: left;">
                                            <asp:CheckBox runat="server" ID="_chkCheckForDeposit" Text="Check" CssClass="depositDisable" />
                                            <asp:CheckBox runat="server" ID="_chkCreditCardForDeposit" Text="Credit Card" CssClass="depositDisable" />
                                        </span>
                                </p>
                                <p class="row2">
                                    <label class="lbl1">
                                        Due Date:</label>
                                    <span class="left" style="margin-right: 5px">
                                        <asp:TextBox ID="txtDepositDue" runat="server" CssClass="inputf_def date-picker depositDisable"
                                            Width="120px"></asp:TextBox>
                                        <span id="Span1"><a href="#" style="font-size: 18px; font-weight: bold; text-decoration: none"
                                            class="jtip" title='Notes |<span class="smallttextnowidth_default" >You can leave due date blank, it will be set to 14 days prior to the event date, if you explicitly want to set it – it must be ATLEAST one day ahead of the event date. </span>'>?</a></span></span>
                                    <label class="lbl1" style="width: 80px">
                                        Payable to:<span class="reqiredmark"><sup>*</sup></span></label>
                                    <span class="left">
                                        <asp:TextBox ID="_txtPayableToForDeposit" runat="server" CssClass="inputf_def depositDisable"
                                            Width="214px" /></span>
                                </p>
                                <p class="row2">
                                    <label class="lbl1">
                                        Mail to the attention of:<span class="reqiredmark"><sup>*</sup></span></label>
                                    <span class="left">
                                        <asp:TextBox ID="_txtAttentionOfForDeposit" runat="server" CssClass="inputf_def depositDisable"
                                            Width="120px" /></span>
                                </p>
                                <p class="row2">
                                    <label class="lbl1">
                                        Deliver to:</label>
                                    <span class="add_box"><span class="hrow">
                                        <label class="lbln">
                                            Organization name :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox
                                                ID="_txtDepositeOrganization" runat="server" CssClass="inputf_def left depositDisable"
                                                Width="329px" /></span> <span class="hrow">
                                                    <label class="lbln">
                                                        Address :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox ID="_txtDepositDeliverAddress1"
                                                            runat="server" CssClass="inputf_def left depositDisable" Width="120px" />
                                                    <label class="lbln">
                                                        &nbsp;&nbsp; Suite, Apt, etc :</label><asp:TextBox ID="_txtDepositDeliverAddress2"
                                                            runat="server" CssClass="inputf_def left depositDisable" Width="163px" /></span>
                                        <span class="hrow">
                                            <label class="lbln" style="width: 56px">
                                                City :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox ID="_txtDepositDeliverCity"
                                                    runat="server" CssClass="inputf_def left auto-search-deposit depositDisable"
                                                    Width="120px" />
                                            <label class="lbln">
                                                &nbsp;&nbsp;State :<span class="reqiredmark"><sup>*</sup></span></label><asp:DropDownList
                                                    runat="server" ID="_ddlDepositState" class="deposit-state-dropdown left depositDisable"
                                                    Style="width: 100px;">
                                                </asp:DropDownList>
                                            <label class="lbln">
                                                &nbsp;&nbsp;Zip :<span class="reqiredmark"><sup>*</sup></span></label><asp:TextBox
                                                    ID="_txtDepositDeliverZip" runat="server" CssClass="inputf_def left depositDisable"
                                                    Width="60px" /></span> </span>
                                </p>
                                <p class="row2" style="margin-top: 10px;">
                                    <label class="bold lbl1" style="color: #000">
                                        Deposit will be:<span class="reqiredmark"><sup>*</sup></span></label>
                                    <span class="left">
                                        <asp:RadioButton ID="_rbtAppliedToCost" runat="server" Text="Applied to Cost of the event"
                                            GroupName="DepositApplied" CssClass="depositDisable" />
                                        <asp:RadioButton ID="_rbtReturnToOffice" runat="server" Text="Returned to corporate offices"
                                            GroupName="DepositApplied" CssClass="depositDisable" /></span>
                                </p>
                                <p class="row2" style="margin-top: 5px;">
                                    <label class="bold lbl1" style="color: #000">
                                        Must Cancel event by:<span class="reqiredmark"><sup>*</sup></span></label>
                                    <span class="left">
                                        <asp:TextBox ID="_txtEventCancelBy" runat="server" CssClass="inputf_def date-picker depositDisable"
                                            Width="120px" />
                                        to receive a full refund </span>
                                </p>
                            </div>
                            <p class="row" style="margin-top: 15px;">
                                <span class="blktext14px_default">TaxId Number:
                                <asp:TextBox ID="_taxIdNumber" runat="server" CssClass="inputf_def" MaxLength="50"></asp:TextBox>
                                </span>
                            </p>
                            <p class="row" style="margin-top: 15px;">
                                <span class="blktext14px_default">
                                    <asp:CheckBox ID="chkReminderTask" runat="server" Text="Create Reminder task for Payment Due & Deposit Due"
                                        Checked="false" />
                                </span>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="subhead">
                    <img src="/App/Images/page3symbolvsmall.gif" alt="" />
                    <h2 class="toppad">Event Details</h2>
                </div>
                <div class="maindivpagemainrow_anp">
                    <div class="pagemainrow_anp">
                        <span id="spcity" class="inputfield250px_anp">Schedule Method:<span class="reqiredmark"><sup>*</sup></span>
                            <asp:DropDownList ID="ddlScheduledBy" runat="server" Width="240px" CssClass="list_anp"
                                AutoPostBack="False">
                            </asp:DropDownList>
                        </span><span id="spstate" class="inputfield250px_anp">Preferred communication Method:<span
                            class="reqiredmark"><sup>*</sup></span>
                            <asp:DropDownList ID="ddlCommunicationMode" runat="server" Width="240px" CssClass="list_anp"
                                AutoPostBack="False">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="pagemainrow_anp" style="margin-top: 10px;">
                        <span style="float: left">Host site conforms to all minimum site requirements:</span>
                        <span style="float: right; padding-right: 20px;">
                            <asp:RadioButton ID="rbtnMinReqYes" runat="server" Text="Yes" GroupName="MiniumReq" />
                            <asp:RadioButton ID="rbtnMinReqNo" runat="server" Text="No" GroupName="MiniumReq" />
                        </span>
                    </div>
                    <div class="pagemainrow_anp" id="divMinReqDetails" runat="server" style="display: none;">
                        <p class="pagemainrow_anp">
                            <span class="titletext_default">
                                <img src="/App/Images/specer.gif" width="110px" height="1px" /></span> <span class="inputfldnowidth_default"
                                    style="margin-right: 40px;">
                                    <asp:RadioButton ID="rbtnCrfmVisually" runat="server" Text="Confirm Visually" GroupName="Confirm" />
                                </span><span class="inputfldnowidth_default">
                                    <asp:RadioButton ID="rbtnCrfmVerbally" runat="server" Text="Confirm Verbally" GroupName="Confirm" />
                                </span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletextlarge_default" style="width: 160px">Technician Instructions: <a
                                href="#" class="jtip" title='Instruction for Technician |<b><%=TechInstructionTip %></b>'
                                style="font-size: 18px; font-weight: bold; text-decoration: none">?</a> </span>
                            <asp:TextBox ID="txtComments" runat="server" CssClass="inputf_def" Width="710px"
                                TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletextlarge_default" style="width: 160px">Call Center Instructions:
                            <a href="#" class="jtip" title='Instruction for Call Center |<b><%=CallCenterInstructionTip%></b>'
                                style="font-size: 18px; font-weight: bold; text-decoration: none">?</a>
                            </span>
                            <asp:TextBox ID="_txtInstructionForCallCenter" runat="server" CssClass="inputf_def"
                                Width="710px" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </p>
                    </div>
                </div>
            </div>
            <div class="main_area_bdrnone" style="margin-top: 10px;">
                <span class="buttoncon_default">
                    <asp:ImageButton ID="ibtnnext" runat="server" ImageUrl="~/App/Images/next-button.gif"
                        OnClick="ibtnnext_Click" OnClientClick="return validateHostInfo();" />
                </span><span class="buttoncon_default">
                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/App/Images/cancel-btn.gif"
                        OnClick="ibtnCancel_Click" />
                </span>
                <div class="main_area_bdrnone" style="margin-top: 0px">
                    <span style="float: right; font: normal 10px arial;">Next step you get to define the
                    Date of the event, Time, POD, etc. </span><span style="float: right; padding-top: 3px;">
                        <img src="/App/Images/small-orng-arrow.gif" /></span>
                </div>
            </div>
        </div>

        <div id="ImageDisplayDiv" title="Host Image" style="float: left; width: 640px;">
            <img src="" alt="" width="640px" id="HostImageImg" />
        </div>
        <%--<a id="aEditContact" runat="server" href='/App/Franchisor/AddNewContact.aspx?ContactID=<%#DataBinder.Eval(Container.DataItem, "ContactID")%>'>Edit</a>--%>
        <div id="divEditAddress" style="display: none" title="Edit Address">
            <div class="wrow">
                <label>
                    First Name:<sup>*</sup></label>
                <input type="text" id="_firstName" style="width: 190px" />
            </div>
            <div class="wrow">
                <label>
                    Middle Name:</label>
                <input type="text" id="_middleName" style="width: 190px" />
            </div>
            <div class="wrow">
                <label>
                    Last Name:<sup>*</sup></label>
                <input type="text" id="_lastName" style="width: 190px" />
            </div>
            <div class="wrow">
                <label>
                    Address1:<sup>*</sup></label>
                <input type="text" id="txtAddress1" style="width: 190px" />
            </div>
            <div class="wrow">
                <label>
                    Suite,Appt:</label>
                <input type="text" id="txtAddress2" style="width: 190px" />
            </div>
            <div class="wrow">
                <label>
                    <span class="spnheight">City:</span><sup>*</sup></label>
                <input type="text" id="Text1" style="width: 120px" class="auto-complete-city" />
            </div>
            <div class="wrow">
                <label>
                    State:<sup>*</sup></label>
                <asp:DropDownList ID="ddlState" runat="server" CssClass="inputf_def" Height="25px">
                </asp:DropDownList>
            </div>
            <div class="wrow">
                <label>
                    <span class="spnheight">Zip:</span><sup>*</sup></label>
                <input type="text" id="txtZip" />
            </div>
            <div class="wrow">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="btnedit" runat="server" ImageUrl="/App/Images/save-button.gif" />
                </div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="btnsave" runat="server" ImageUrl="/App/Images/cancel-button.gif" />
                </div>
            </div>
        </div>
        <input type="hidden" id="hfHostID" runat="server" value="0" />
        <input type="hidden" id="hfPaymentRequired" runat="server" value="1" />
        <input type="hidden" id="_hidSalesRep" runat="server" value="1" />
        <input type="hidden" id="_hidSalesRepId" runat="server" />
        <input type="hidden" id="_hidFranchiseeId" runat="server" />
        <input type="hidden" id="_addressId" runat="server" />
        <input type="hidden" id="_hostaddress" runat="server" />
        <input type="hidden" id="_addressVerified" runat="server" value='' />

        <script type="text/javascript" language="javascript">


            function ManageHideShowHostFacilityDiv(actionToPerform) {
                if (actionToPerform == 'show')
                    $(".hostfacility-detail-div").show();
                else
                    $(".hostfacility-detail-div").hide();

                $(".coll-exp-img").toggle();
            }


            function OpenImageDisplyDialog(sourcePath) {
                $('#HostImageImg').attr('src', sourcePath);
                $('#ImageDisplayDiv').dialog('open');
            }


            function LoadHostRating(result) {
                if (result.d == null) {
                    $("#hostDetailsNASpan").show();
                    $("#HostRatingDiv").show();
                    return;
                }

                $("#HostRatingDiv").show();
                $(".plus-img").show();

                if (result.d.NumberOfPlugPoints != null)
                    $("#NumberofPlugPointsSpan").html(result.d.NumberOfPlugPoints);

                if (result.d.RoomNeedsCleared != null)
                    $("#RoomNeedClearedSpan").html(result.d.RoomNeedsCleared ? "Yes" : "No");

                $("#RoomSizeSpan").html(result.d.RoomSize);

                if (result.d.InternetAccess != null)
                    $("#InternetAccessSpan").html(result.d.InternetAccess.Name);

                if (result.d.Ranking != null)
                    $("#HostRankingSpan").html(result.d.Ranking.Name);

                $("#CommentsByFranchisee").html(result.d.Notes);
            }

            function ClearHostRankingData() {
                $("#NumberofPlugPointsSpan").html("");
                $("#RoomNeedClearedSpan").html("");
                $("#RoomSizeSpan").html("");
                $("#InternetAccessSpan").html("");
                $("#HostRankingSpan").html("");

                $("#CommentsByFranchisee").html("");

                $("#HostRatingDiv").hide();
                $(".coll-exp-img").hide();
                $(".hostfacility-detail-div").hide();
                $("#hostDetailsNASpan").hide();
            }

            function InitiateLoadHostRankingData(hostId) {
                ClearHostRankingData();
                var parameter = "{'hostId' : '" + hostId + "'}";

                var messageUrl = '<%= ResolveUrl("~/App/Controllers/HostFacilityRankingController.asmx/GetHostFacilityViabilityforEventWizard") %>';
                InvokeService(messageUrl, parameter, LoadHostRating);

                messageUrl = '<%= ResolveUrl("~/App/Controllers/HostFacilityRankingController.asmx/GetHostImages") %>';
                InvokeService(messageUrl, parameter, LoadImages);
            }

            function GetHostNotes(hostId) {
                var parameter = "{'hostId' : '" + hostId + "'}";
                var messageUrl = '<%= ResolveUrl("~/App/Common/CreateEventWizard/Step1.aspx/GetHostNotes") %>';
                InvokeService(messageUrl, parameter, LoadNotes);
            }

            function LoadNotes(result) {
                if (result.d == null) return;
                $("#<%= txtComments.ClientID %>").val(result.d.SecondValue);
                $("#<%= _txtInstructionForCallCenter.ClientID %>").val(result.d.FirstValue);
            }

            function LoadImages(result) {
                if (result.d == null || result.d.length < 1)
                    return;

                $("#HostImagesDiv").html("");

                $.each(result.d, function () {
                    $("#HostImagesDiv").append(GetHTMLforanImageObject(this));
                });
            }

            function GetHTMLforanImageObject(imgObject) {
                var html = " <span style='float:left; padding:5px;'> " +
                    " <img src='" + imgObject.Path + "' style='height:80px; wdith:120px; cursor:pointer;' alt='' onclick='OpenImageDisplyDialog(this.src);' />" +
                    " </span>";

                return html;
            }

            $(document).ready(function () {
                $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 400 });
                $('.jtiphostperformance').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 300 });
                $('.jtipMap').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 300 });
                $('.jtipMapDiv').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 300 });
                $('.auto-Search').autoComplete({
                    autoChange: true,
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                    type: "POST",
                    data: "prefixText",
                    contextKey: ''
                });

                $('#ImageDisplayDiv').dialog({ width: 680, height: 510, autoOpen: false, resizable: false, draggable: false, overflow: "visible" });

                $(".date-picker").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-10:+50"
                });

                $('.auto-search-cost').autoComplete({
                    autoChange: true,
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                    type: "POST",
                    data: "prefixText",
                    contextKey: $('.cost-state-dropdown option:selected').val()
                });

                $('.cost-state-dropdown').change(function () {
                    $('.auto-search-cost').autoComplete({
                        autoChange: true,
                        url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                        type: "POST",
                        data: "prefixText",
                        contextKey: $('.cost-state-dropdown option:selected').val()
                    });
                });

                $('.auto-search-deposit').autoComplete({
                    autoChange: true,
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                    type: "POST",
                    data: "prefixText",
                    contextKey: $('.deposit-state-dropdown option:selected').val()
                });
                $('.deposit-state-dropdown').change(function () {
                    $('.auto-search-deposit').autoComplete({
                        autoChange: true,
                        url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                        type: "POST",
                        data: "prefixText",
                        contextKey: $('.deposit-state-dropdown option:selected').val()
                    });
                });
                if (!$('#<%=_rbtDepositY.ClientID %>').is(':checked')) {
                    $('#dvDeposit').hide();
                }
            });



        </script>

    </div>
    <div id="Step2div" runat="server" style="display: none;">

        <script type="text/javascript" language="javascript">

            var GB_ROOT_DIR = "/App/Wizard/greybox/";

            /* Called by child window, TemplateTimeSlots.aspx */
            function ReturnChangeScheduleTemplate() {
                var templatedropdown = document.getElementById('<%= ddlScheduleTemplate.ClientID %>');

                var selvalue = templatedropdown.options[templatedropdown.selectedIndex].value;

                return selvalue;
            }

            function CheckChangeDropDown() {
                var templatedropdown = document.getElementById('<%= ddlScheduleTemplate.ClientID %>');
                if (templatedropdown.selectedIndex == 0) {
                    document.getElementById('spnlinkviewslots').style.visibility = 'hidden';
                    document.getElementById('spnlinkviewslots').style.display = 'none';
                }
                else {
                    document.getElementById('spnlinkviewslots').style.visibility = 'visible';
                    document.getElementById('spnlinkviewslots').style.display = 'block';
                }
            }


        </script>
        <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js" language="javascript"></script>

        <%--Reset Package test--%>
        <script type="text/javascript" language="javascript">

            function ResetPackageAndTest() {
                var PackageAvailableDiv = $('#<%= PackageAvailableDiv.ClientID %>');
                var NoPackageAvailableDiv = $('#<%= NoPackageAvailableDiv.ClientID %>');
                var _testDiv = $('#<%=_testDiv.ClientID %>')
                var grdSelectPackage = $('#<%=grdSelectPackage.ClientID %>');
                var _testGrid = $('#<%=_testGrid.ClientID %>');
                var NoPackageAvailableSpan = $('#<%=NoPackageAvailableSpan.ClientID %>');

                PackageAvailableDiv.hide();
                _testDiv.hide();
                grdSelectPackage.html('');
                _testGrid.html('');
                NoPackageAvailableSpan.html('');
                NoPackageAvailableDiv.show();
                $("#resultEntryNote").hide();
            }

        </script>

        <%--Fill Pod--%>
        <script type="text/javascript" language="javascript">

            function FillPOD(franchiseeid) {//debugger
                var ddlTerritory = $('#<%= ddlTerritory.ClientID %>');

                if ($('#<%= ddlTerritory.ClientID %> option').length == 1 || ddlTerritory.val() != "0") {
                    var divPODDetails = document.getElementById("divPODDetails");
                    var grdPOD = document.getElementById('<%= gvPOD.ClientID %>');


                    divPODDetails.style.display = "none";
                    $('#<%=hfPodID.ClientID %>').val('');
                    if (grdPOD != null)
                        divPODDetails.innerHTML = "";

                    var parameter = "{'franchiseeId':'" + franchiseeid + "',";
                    parameter += "territoryId:'" + ddlTerritory.val() + "'}";

                    var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodController.asmx/GetPodsAvailableForEvent")%>';
                    InvokeService(messageUrl, parameter, FillPODDropDown);
                    return false;
                }
                else {
                    document.getElementById("divInvalidEventDate").style.display = "block";
                    document.getElementById("divValidEventDate").style.display = "none";
                    return true;
                }

            }

            function FillPODDropDown(podList) {
                $('#' + '<%=ddlPOD.ClientID %> >option').remove();
                if (podList.d.length > 0) {
                    $('#' + '<%=ddlPOD.ClientID %>').append($('<option></option>').val('0').html('Select Pod'));
                    for (var i = 0; i < podList.d.length; i++) {
                        $('#' + '<%=ddlPOD.ClientID %>').append($('<option></option>').val(podList.d[i].Id).html(podList.d[i].Name));
                    }
                }
                else {
                    $('#' + '<%=ddlPOD.ClientID %>').append($('<option></option>').val('0').html('No Pod Found'));
                }

                document.getElementById("divInvalidEventDate").style.display = "none";
                document.getElementById("divValidEventDate").style.display = "block";
            }
        </script>

        <script type="text/javascript" language="javascript">
            function GetHealthAssessmentTemplate() {//debugger;
                var parameter = "{'hospitalPartnerId':'" + $("#<%= ddlHospitalPartner.ClientID %>").val() + "'}";

                var messageUrl = '/Medical/HealthAssessment/GetHealthAssessmentTemplateForEvent';
                InvokeService(messageUrl, parameter, FillHealthAssessmentTemplateDropdown);

            }

            function FillHealthAssessmentTemplateDropdown(templateList) {//debugger;
                $('#' + '<%=HealthAssessmentDropdown.ClientID %> >option').remove();

                var selectedTemplate = $("#<%= hfHealthAssessmentTemplateId.ClientID %>");
                if (templateList.length > 0) {
                    //                $('#' + '<%=HealthAssessmentDropdown.ClientID %>').append($('<option></option>').val('0').html('Select Template'));
                    for (var i = 0; i < templateList.length; i++) {
                        if (parseInt(selectedTemplate.val()) == templateList[i].Id) {
                            $('#' + '<%=HealthAssessmentDropdown.ClientID %>').append($('<option selected="selected"></option>').val(templateList[i].Id).html(templateList[i].Name + " - " + templateList[i].TemplateType));
                        }
                        else if (templateList[i].IsDefault && parseInt(selectedTemplate.val()) < 1) {
                            $('#' + '<%=HealthAssessmentDropdown.ClientID %>').append($('<option selected="selected"></option>').val(templateList[i].Id).html(templateList[i].Name + " - " + templateList[i].TemplateType));
                        }
                        else {
                            $('#' + '<%=HealthAssessmentDropdown.ClientID %>').append($('<option></option>').val(templateList[i].Id).html(templateList[i].Name + " - " + templateList[i].TemplateType));
                        }
                }
            }
            else {
                $('#' + '<%=HealthAssessmentDropdown.ClientID %>').append($('<option></option>').val('0').html('No Template Found'));
                }


                selectedTemplate.val($('#' + '<%=HealthAssessmentDropdown.ClientID %>').val());
            }

            function SetHealthAssessmentTemplate() {//debugger;
                var selectedTemplate = $("#<%= hfHealthAssessmentTemplateId.ClientID %>");
                selectedTemplate.val($('#' + '<%=HealthAssessmentDropdown.ClientID %>').val());
            }

            function viewHealthAssessmentTemplateQuestion() {
                var templateId = $("#<%=HealthAssessmentDropdown.ClientID %>").val();
                if (parseInt(templateId) > 0) {
                    window.open("/Medical/HealthAssessment/View?id=" + templateId, "Template_Question", "width=720, height=620, scrollbars=1");
                }
            }

        </script>

        <script type="text/javascript" language="javascript">

            function checkEventDate() {

                var markEventSuspended = false;;

                var EventDate = document.getElementById('<%= txtEventDate.ClientID %>');
                var eventId = '<%= EventId.HasValue ? EventId.Value : 0 %>';
                var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;

                var date = getFutureDate(<%=EventSuspentionCutoffDays + 1 %>);
                var ddlEventStatus = document.getElementById("<%=ddlEventStatus.ClientID %>");
                if (EventDate.defaultValue != EventDate.value) {
                    if ("<%= CurrentOrganizationRole.GetSystemRoleId %>" == "<%= (long) Falcon.App.Core.Enum.Roles.FranchisorAdmin %>" || "<%= CurrentOrganizationRole.GetSystemRoleId %>" == "<%= (long) Falcon.App.Core.Enum.Roles.SalesRep %>") {
                        if (ddlEventStatus.value != "<%= EventStatus.Canceled.ToString() %>" && "<%= IsEventLocked %>" != "<%= bool.TrueString %>") {

                            if (CompareTwoDates1(date, EventDate.value)) {
                                markEventSuspended = true;
                            }

                            if (markEventSuspended && ddlEventStatus.value === "<%= EventStatus.Active.ToString() %>") {
                                ddlEventStatus.value = "<%= EventStatus.Suspended.ToString() %>";
                                $("#<%=ddlEventStatus.ClientID %>").trigger("change");
                            } else if (markEventSuspended == false && ddlEventStatus.value === "<%= EventStatus.Suspended.ToString() %>") {
                                ddlEventStatus.value = "<%= EventStatus.Active.ToString() %>";
                                $("#<%=ddlEventStatus.ClientID %>").trigger("change");
                            }
                    }
                } else {
                    if (CompareTwoDates1(date, EventDate.value)) {
                        markEventSuspended = true;
                    } else {
                        if (ddlEventStatus.value === "<%= EventStatus.Suspended.ToString() %>") {
                                ddlEventStatus.value = "<%= EventStatus.Active.ToString() %>";
                                $("#pEventNotes").hide();
                            } else if (ddlEventStatus.value === "<%= EventStatus.Active.ToString() %>") {
                                $("#pEventNotes").hide();
                            }
                        }
                    }
                }

                <%--if ("<%= CurrentOrganizationRole.GetSystemRoleId %>" == "<%= (long) Falcon.App.Core.Enum.Roles.SalesRep %>") {
                    if (CompareTwoDates1(date, EventDate.value)) {
                        markEventSuspended = true;
                        skippValidation = true;
                        $(".eventStatus_div").hide();
                    } else {
                        $(".eventStatus_div").show();
                    }
                }--%>

                if (EventDate.value.match(RegExPattern) && $('#<%=hfPodID.ClientID %>').val() != '') {

                    eventDate = EventDate.value;
                    var parameter;

                    if ($('#<%=hfPodID.ClientID %>').val().length > 1) {
                        var podArr = $('#<%=hfPodID.ClientID %>').val().split(',');

                        parameter = "{'podId':'" + podArr[0] + "',";
                    }
                    else
                        parameter = "{'podId':'" + $('#<%=hfPodID.ClientID %>').val() + "',";
                    parameter += "'eventDate':'" + EventDate.value + "',";

                    parameter += "'eventId':'" + eventId + "'}";

                    var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodController.asmx/GetPodBookedInformation")%>';
                    InvokeService(messageUrl, parameter, ShowPodBookedInformation);
                    return true;
                }

            }

            function ShowPodBookedInformation(podBookedInformationList) {//debugger;
                var PodBookedDetailDiv = document.getElementById("PodBookedDetailDiv");
                if (podBookedInformationList.d.length > 0) {

                    for (var i = 0; i < podBookedInformationList.d.length; i++) {

                        PodBookedDetailDiv.innerHTML = "Warning:Pod has been booked for event " + podBookedInformationList.d[i].FirstValue + " on " + eventDate + " from " + podBookedInformationList.d[i].SecondValue.FirstValue + " to " + podBookedInformationList.d[i].SecondValue.SecondValue;
                    }
                }
                else {
                    PodBookedDetailDiv.innerHTML = "";
                }
            }
        </script>


        <script type="text/javascript" language="javascript">

            var eventDate;
            $(function () {
                var EventDate = document.getElementById('<%= txtEventDate.ClientID %>')
                $(EventDate).focus(function () {
                    eventDate = $.trim($(this).val());
                });
            });

            var postRequest = new HttpRequest();
            postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            postRequest.failureCallback = requestFailed();

            function requestFailed() {

            }

            function GetPodDetails() {//debugger
                var txtEventDate = document.getElementById("<%=txtEventDate.ClientID %>");
                var ddlPOD = document.getElementById("ddlPOD");
                if (ddlPOD == null) {
                    ddlPOD = document.getElementById("<%=ddlPOD.ClientID %>");
                }
                if (ddlPOD.value == "0") {
                    alert("Please select a Pod.");
                    return false;
                }
                var hfPodID = $("#<%=hfPodID.ClientID %>");
                if (hfPodID.val() == "")
                    hfPodID.val(ddlPOD.value);
                else
                    hfPodID.val(hfPodID.val() + "," + ddlPOD.value);

                return true;
            }

            function CheckPodSelected() {
                var packageTimeOnlyCheckbox = document.getElementById("<%= PackageTimeOnlyCheckbox.ClientID %>");
                if (packageTimeOnlyCheckbox == null)
                    return true;

                var gvPod = document.getElementById("<%=gvPOD.ClientID %>");

                //alert(packageTimeOnlyCheckbox.checked);
                if (packageTimeOnlyCheckbox.checked) {
                    if (gvPod == null || gvPod.rows.length == 0) {
                        alert("Please select a Pod.");
                        return false;
                    }
                }
                return true;
            }

            function CheckPodDelete() {
                return confirm('Are you sure about deleting the pod?');
            }


            function checkDuration() {//debugger
                var hh1 = document.getElementById("<%=ddlHHStartTime.ClientID %>");
                var mm1 = document.getElementById("<%=ddlMMStartTime.ClientID %>");
                var fromampm = document.getElementById("<%=ddlAMPMStartTime.ClientID %>");

                var hh2 = document.getElementById("<%=ddlHHEndTime.ClientID %>");
                var mm2 = document.getElementById("<%=ddlMMEndTime.ClientID %>");
                var toampm = document.getElementById("<%=ddlAMPMEndTime.ClientID %>");

                var txtDuration = document.getElementById("<%=txtDuration.ClientID %>");

                hh1v = hh1.value;
                mm1v = mm1.value;
                hh2v = hh2.value;
                mm2v = mm2.value;

                if (fromampm.value == "PM" && parseInt(hh1v) < 12)
                    hh1v = Number(hh1v) + 12;

                if (toampm.value == "PM" && parseInt(hh2v) < 12)
                    hh2v = Number(hh2v) + 12;

                timefrom = Number(hh1v * 60 * 60 + mm1v * 60);

                //if(hh2v > 12) hh2v = parseInt(hh2v - 2); //24 hr time

                timeto = Number(hh2v * 60 * 60 + mm2v * 60);

                var difference = timeto - timefrom;
                var hr = 0;
                var min = 0;
                if (difference > 0) {
                    hr = difference / 3600;
                    hr = parseInt(hr);
                    min = (difference % 3600) / 60;
                    txtDuration.value = hr + " hrs " + min + " mins";
                }
            }


            function CheckRoomForSelectedPackages() {
                var result = true;
                for (var i = 0; i < $('.package-checkbox:checked').length; i++) {
                    var packageCheckBox = $('.package-checkbox:checked')[i];
                    var screeingRoomId = parseInt($(packageCheckBox).parents('tr').find('.package-screening-room').val());
                    if (screeingRoomId < 0) {
                        alert("Please select the room for all selected packages.");
                        result = false;
                        break;
                    }
                }
                return result;
            }


            function VaidateEvent() {//debugger;

                if (isBlank(document.getElementById('<%= txtEventDate.ClientID %>'), 'Event date'))
                    return false;
                if (!ValidateDate(document.getElementById('<%= txtEventDate.ClientID %>').value, 'Event date'))
                    return false;
                if (!CompareDateWithCurrentDate2(document.getElementById('<%= txtEventDate.ClientID %>'), 'Event date should be of future date.'))
                    return false;

                if (isBlank(document.getElementById('<%= ddlTimeZone.ClientID %>'), 'Time zone'))
                    return false;

                if ($("#<%= DynamicSchedulingNoRadioBtn.ClientID %>").is(":checked")) {
                    if (!checkDropDown(document.getElementById('<%= ddlScheduleTemplate.ClientID %>'), 'Schedule Template'))
                        return false;
                }
                else {

                    if ($("#<%= EnableLunchDuration.ClientID %>").is(":checked")) {
                        var hhLunchStartTime = $("#<%=ddlHHLunchStartTime.ClientID %>");
                        var mmLunchStartTime = $("#<%=ddlMMLunchStartTime.ClientID %>");
                        var fromLunchAMPM = $("#<%=ddlAMPMLunchStartTime.ClientID %>");

                        if (hhLunchStartTime.val() == "0" || mmLunchStartTime.val() == "0" || fromLunchAMPM.val() == "0") {
                            alert("Please select Lunch Start Time.");
                            return false;
                        }

                        if (!checkDropDown(document.getElementById('<%= ddlLunchDuration.ClientID %>'), 'Lunch Duration'))
                            return false;


                        var packageTimeOnlyCheckbox = document.getElementById("<%= PackageTimeOnlyCheckbox.ClientID %>");
                        if (packageTimeOnlyCheckbox != null && packageTimeOnlyCheckbox.checked) {
                            if (!CheckRoomForSelectedPackages()) {
                                return false;
                            }
                        }
                    }
                    //debugger;
                    if ($("#<%= ddlFixedAncillaryScreeningTime.ClientID %>").val() == "0") {
                        alert("Please select Ancillary Fixed Screening Time.");
                        return false;
                    }

                    if (CheckScreeingTime() == false)
                        return false;

                }

                var ddlRegigtrationMode = document.getElementById("<%=ddlRegigtrationMode.ClientID %>");
                if (ddlRegigtrationMode.options[ddlRegigtrationMode.selectedIndex].text == "Private") {
                    if (isBlank(document.getElementById('<%= txtInvitationCode.ClientID %>'), 'Invitation Code'))
                        return false;
                }

                if ($('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.Corporate%>') {
                    var ddlCooperateAccounts = $('#<%=ddlCooperateAccounts.ClientID %>');
                    if ($('#<%=ddlEventType.ClientID %> option').length == 1) {
                        alert("You can't create a cooperate event since there is no cooperate account.");
                        return false;
                    }
                    else if (ddlCooperateAccounts.val() == "0") {
                        alert("Please select a cooperate account.");
                        return false;
                    }
                }
                else if ($('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.HealthPlan%>') {
                    var ddlHealthPlanAccounts = $('#<%=ddlHealthPlan.ClientID %>');
                    if ($('#<%=ddlEventType.ClientID %> option').length == 1) {
                        alert("You can't create a healthPlan event since there is no HealthPlan.");
                        return false;
                    }
                    else if (ddlHealthPlanAccounts.val() == "0") {
                        alert("Please select a Health Plan.");
                        return false;
                    }
                    else if ($('#ctl00_ContentPlaceHolder1_EventProductType :checkbox:checked').length==0) {
                        alert("Please Select Product.");
                        return false;
                    }
                }
                if ($('#<%=ddlEventType.ClientID %> option:selected').text() != '<%=EventType.HealthPlan%>') {
                    $('[id = ctl00_ContentPlaceHolder1_EventProductType]').find('input[type="checkbox"]').each(function () {
                        $(this).attr("checked", false);
                    });
                }

            if ($('#<%=HospitalPartnerYesRadioBtn.ClientID %>').attr('checked')) {
                    var ddlHospitalPartner = $('#<%=ddlHospitalPartner.ClientID %>');
                    if ($('#<%=HospitalPartnerYesRadioBtn.ClientID %> option').length == 1) {
                        alert("You can't associate a hospital partner since there is no hospital partner.");
                        return false;
                    }
                    else if (ddlHospitalPartner.val() == "0") {
                        alert("Please select a hospital partner.");
                        return false;
                    }
                }

                var grdPOD = document.getElementById('<%= gvPOD.ClientID %>');
                if (grdPOD == null || grdPOD.rows == null || grdPOD.rows.length == 0) {
                    if (document.getElementById('<%= ddlPOD.ClientID %>') != null) {
                        if (!checkDropDown(document.getElementById('<%= ddlPOD.ClientID %>'), 'POD'))
                            return false;
                    }
                    else {
                        if (!checkDropDown(document.getElementById('ddlPOD'), 'POD'))
                            return false;
                    }
                }

                if (grdPOD == null || grdPOD.rows == null || grdPOD.rows.length == 0) {
                    alert("Please attach the selected POD.");
                    return false;
                }

                var TargetBaseControl = document.getElementById('<%=grdSelectPackage.ClientID %>');
                if (TargetBaseControl == null || TargetBaseControl.rows.length == 0) {
                    alert("Please select atleast one package.");
                    return false;
                }

                var TargetChildControl = "chkRowChild";
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                var packageSelected = false;
                for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                    if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                        packageSelected = Inputs[iCount].checked;
                        if (packageSelected)
                            break;
                    }
                }
                var testSelected = true;
                var selectTestLength = $('.test-checkbox:checked').length;

                if (selectTestLength == 0)
                    testSelected = false;

                if (packageSelected == false && testSelected == false) {
                    alert("Please select atleast one package or atleast one test.");
                    return false;
                }

                var ddlEventStatus = document.getElementById("<%=ddlEventStatus.ClientID %>");

                var ddlEventCancellationReason = document.getElementById("<%= ddlEventCancellationReason.ClientID %>");
                if (ddlEventStatus.value == "<%= EventStatus.Canceled.ToString() %>") {
                    if (ddlEventCancellationReason.value == "-1") {
                        alert("Please select event cancelation reason.");
                        return false;
                    }
                }

                if ((ddlEventStatus.value == "<%= EventStatus.Suspended.ToString() %>") || ddlEventStatus.value == "<%= EventStatus.Canceled.ToString() %>") {
                    if (isBlank(document.getElementById('<%= txtNotes.ClientID %>'), 'Notes'))
                        return false;
                }

                var currentRole = '<%=CurrentRole %>';
                var hhStartIme = document.getElementById("<%=ddlHHStartTime.ClientID %>");
                var mmStartTime = document.getElementById("<%=ddlMMStartTime.ClientID %>");
                var fromAMPM = document.getElementById("<%=ddlAMPMStartTime.ClientID %>");

                var hhEndIme = document.getElementById("<%=ddlHHEndTime.ClientID %>");
                var mmEndTime = document.getElementById("<%=ddlMMEndTime.ClientID %>");
                var toAMPM = document.getElementById("<%=ddlAMPMEndTime.ClientID %>");

                $("#<%= ibtnSaveClose.ClientID %>").hide();
                $("#loading-image-save-event").show();
                return true;

            }

            function SelectAllPackage(CheckBox) {
                var TargetBaseControl = document.getElementById('<%=grdSelectPackage.ClientID %>');
                var TargetChildControl = "chkRowChild";
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                    if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                        Inputs[iCount].checked = CheckBox.checked;

                    }
                }
            }

            function SelectAllTest(checkBox) {
                if ($(checkBox).attr("checked") == true)
                    $('.test-checkbox').attr("checked", true);
                else
                    $('.test-checkbox').attr("checked", false);
            }

            function showHideInvitaionCode() {//debugger;
                var ddlRegigtrationMode = document.getElementById("<%=ddlRegigtrationMode.ClientID %>");
                var divInvitaionCode = document.getElementById("divInvitaionCode");
                var spPrivateMsg = document.getElementById("spPrivateMsg");
                if (ddlRegigtrationMode.options[ddlRegigtrationMode.selectedIndex].text == "Private") {
                    divInvitaionCode.style.display = "block";
                    spPrivateMsg.style.display = "block";
                }
                else {
                    divInvitaionCode.style.display = "none";
                    spPrivateMsg.style.display = "none";
                }
            }

            function showToolTip() {//debugger
                var divToolTip = document.getElementById("<%= divToolTip.ClientID %>");
                var aToolTip = document.getElementById("aToolTip");
                var dim = GetTopLeft(aToolTip);
                divToolTip.style.top = parseInt(dim.Top) - 100 + 'px';
                divToolTip.style.left = (parseInt(dim.Left) + 10) + 'px';
                divToolTip.style.display = "block";
            }
            function hideToolTip() {
                var divToolTip = document.getElementById("<%= divToolTip.ClientID %>");
                var aToolTip = document.getElementById("aToolTip");
                divToolTip.style.display = "none";
            }

            function GetTopLeft(elm) {

                var x, y = 0;

                //set x to elm’s offsetLeft
                x = elm.offsetLeft;

                //set y to elm’s offsetTop
                y = elm.offsetTop;

                //set elm to its offsetParent
                elm = elm.offsetParent;

                //use while loop to check if elm is null
                // if not then add current elm’s offsetLeft to x
                //offsetTop to y and set elm to its offsetParent 
                while (elm != null) {

                    x = parseInt(x) + parseInt(elm.offsetLeft);
                    y = parseInt(y) + parseInt(elm.offsetTop);
                    elm = elm.offsetParent;
                }

                //here is interesting thing
                //it return Object with two properties
                //Top and Left
                return { Top: y, Left: x };

            }

            function AllowNumericOnly(evt) {
                return KeyPress_DecimalAllowedOnly(evt);

            }
            var currentMonth;
            var currentYear;
            function showCalendar() {//debugger
                var ddlPOD = document.getElementById("ddlPOD");
                if (ddlPOD == null) {
                    ddlPOD = document.getElementById("<%=ddlPOD.ClientID %>");
                }
                if (ddlPOD.value == "" || ddlPOD.value == "0") {
                    alert("Please select a Pod.");
                    return false;
                }
                var now;
                var txtEventDate = document.getElementById("<%=txtEventDate.ClientID %>");
                if (txtEventDate.value != '')
                    now = new Date(txtEventDate.value);
                else
                    now = new Date();

                currentYear = now.getFullYear();
                currentMonth = (now.getMonth()) + 1;
                postRequest.url = "AsyncPodCalendar.aspx?PodID=" + ddlPOD.value + "&Month=" + currentMonth + "&Year=" + currentYear;
                postRequest.successCallback = FillPodCalendar;
                postRequest.post("");
            }

            function FillPodCalendar(httpRequest) {//debugger
                var divCalendar = document.getElementById("divCalendar");
                divCalendar.innerHTML = httpRequest.responseText;
                $('#ViewPodCalendar').dialog('open');
                var zIndex = $('#ViewPodCalendar').dialog('option', 'zIndex');
                $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, cluezIndex: 5000 + zIndex });

            }

            function showPrevMonthPodCal() {//debugger

                currentMonth = currentMonth - 1;
                if (currentMonth == 0) {
                    currentYear = currentYear - 1;
                    currentMonth = 12;
                }
                var ddlPOD = document.getElementById("ddlPOD");
                if (ddlPOD == null) {
                    ddlPOD = document.getElementById("<%=ddlPOD.ClientID %>");
                }
                postRequest.url = "AsyncPodCalendar.aspx?PodID=" + ddlPOD.value + "&Month=" + currentMonth + "&Year=" + currentYear;
                postRequest.successCallback = FillPodCalendar;
                postRequest.post("");
            }

            function showNextMonthPodCal() {//debugger

                currentMonth = currentMonth + 1;
                if (currentMonth == 13) {
                    currentYear = currentYear + 1;
                    currentMonth = 1;
                }
                var ddlPOD = document.getElementById("ddlPOD");
                if (ddlPOD == null) {
                    ddlPOD = document.getElementById("<%=ddlPOD.ClientID %>");
                }
                postRequest.url = "AsyncPodCalendar.aspx?PodID=" + ddlPOD.value + "&Month=" + currentMonth + "&Year=" + currentYear;
                postRequest.successCallback = FillPodCalendar;
                postRequest.post("");
            }

            function showEventTemplateActivity() {
                var ddlEventTaskTemplate = document.getElementById("<%=ddlEventTaskTemplate.ClientID %>");
                if (ddlEventTaskTemplate.value == "" || ddlEventTaskTemplate.value == "0") {
                    alert("Please select a Template.");
                    return false;
                }
                postRequest.url = "AsyncEventActivityTemplate.aspx?EventActivityTemplateID=" + ddlEventTaskTemplate.value;
                postRequest.successCallback = FillTemplateActivity;
                postRequest.post("");
            }
            function FillTemplateActivity(httpRequest) {//debugger
                var divActivity = document.getElementById("divActivity");
                divActivity.innerHTML = httpRequest.responseText;
                $find('mdlEventActivity').show();
            }

            function maintainAfterPostBack() {//debugger;
                CheckChangeDropDown();
                checkEventDate();
                ShowHideEventNotes();
                ShowHideEventCancellationReason();
                showHideInvitaionCode();
                checkDuration();
            }
        </script>
        <%--Show/Hide EventNotes--%>
        <script language="javascript" type="text/javascript">
            function ShowHideEventNotes() {
                var ddlEventStatus = document.getElementById("<%=ddlEventStatus.ClientID %>");
                var pEventNotes = document.getElementById("pEventNotes");
                if (ddlEventStatus.value == "Suspended" || ddlEventStatus.value == "Canceled") {
                    pEventNotes.style.display = "block";
                }
                else {
                    pEventNotes.style.display = "none";
                }
            }
            function ShowHideEventCancellationReason() {
                var ddlEventStatus = document.getElementById("<%=ddlEventStatus.ClientID %>");
                var pEventCancellationReason = document.getElementById("pEventCancellationReason");
                if (ddlEventStatus.value == "Canceled") {
                    pEventCancellationReason.style.display = "block";
                }
                else {
                    pEventCancellationReason.style.display = "none";
                    var ddlEventCancellationReason = document.getElementById("<%= ddlEventCancellationReason.ClientID %>");
                    ddlEventCancellationReason.selectedIndex = 0;
                }
            }
        </script>

        <script language="javascript" type="text/javascript">
            function CheckScreeingTime() {//debugger;
                var valid = true;
                var minDuration = 0;
                var maxDuration = 0;

                if ($(".duration").length == 0) {
                    alert("The attached pod does not have rooms defined to dynamic scheduling. Please contact the administrator.");
                    return false;
                }

                $(".duration").each(function () {
                    if ($.trim($(this).val()) == "" || $.trim($(this).val()) == "0") {
                        alert("Please enter valid room duration.");
                        valid = false;
                        return;
                    }
                    var roomDuration = parseInt($(this).val());
                    if (maxDuration == 0)
                        maxDuration = roomDuration;
                    if (minDuration == 0)
                        minDuration = roomDuration;

                    if (roomDuration > maxDuration) {
                        maxDuration = roomDuration;
                    }
                    else if (roomDuration < minDuration) {
                        minDuration = roomDuration;
                    }
                });

                if (!valid)
                    return false;


                var minimumScreeningTime = 0;
                var maximumScreeningTime = 0;

                for (var i = 0; i < $('.package-checkbox:checked').length; i++) {
                    var packageCheckBox = $('.package-checkbox:checked')[i];
                    var screeingTime = parseInt($(packageCheckBox).parents('tr').find('.package-screening-time').val());
                    if (screeingTime == 0)
                        return true;

                    if (maximumScreeningTime == 0)
                        maximumScreeningTime = screeingTime;
                    if (minimumScreeningTime == 0)
                        minimumScreeningTime = screeingTime;

                    if (screeingTime > maximumScreeningTime)
                        maximumScreeningTime = screeingTime;
                    else if (screeingTime < minimumScreeningTime)
                        minimumScreeningTime = screeingTime;
                }

                for (var i = 0; i < $('.test-checkbox:checked').length; i++) {
                    var testCheckBox = $('.test-checkbox:checked')[i];
                    var screeingTime = parseInt($(testCheckBox).parents('tr').find('.test-screening-time').val());
                    if (screeingTime == 0)
                        return true;

                    if (maximumScreeningTime == 0)
                        maximumScreeningTime = screeingTime;
                    if (minimumScreeningTime == 0)
                        minimumScreeningTime = screeingTime;

                    if (screeingTime > maximumScreeningTime)
                        maximumScreeningTime = screeingTime;
                    else if (screeingTime < minimumScreeningTime)
                        minimumScreeningTime = screeingTime;
                }
                //debugger;
                if (maxDuration > maximumScreeningTime) {
                    alert("Maximum screeing time of selected package(s) and test(s) is " + maximumScreeningTime + ". Room Duration should not be greater than " + maximumScreeningTime + ".");
                    return false;
                }
                else if (minDuration < minimumScreeningTime) {
                    var isContinue = confirm("Minimum screeing time of selected package(s) and test(s) is " + minimumScreeningTime + ". Room Duration should not be less than " + minimumScreeningTime + ". Are you sure you want to continue with this slot interval.")
                    return isContinue;
                }
                return true;
            }

            function ValidateSelectedPackage() {

                var selectPackages = '';
                var selectedTests = '';

                for (var i = 0; i < $('.package-checkbox:checked').length; i++) {
                    var packageCheckBox = $('.package-checkbox:checked')[i];
                    var packageid = $(packageCheckBox).parents('tr').find('.package-id').html();
                    selectPackages = selectPackages + packageid + ",";
                }
                for (var i = 0; i < $('.test-checkbox:checked').length; i++) {
                    var testCheckBox = $('.test-checkbox:checked')[i];
                    var testid = $(testCheckBox).parents('tr').find('.test-id').html();
                    selectedTests = selectedTests + testid + ",";
                }

                var successFunction = function (result) {
                    //debugger;
                    var testIds = result.d;
                    if (testIds != '') {
                        var IsContinue = confirm("The selected test is not the combination of all tests for seleted package,please click ok to continue and will select all combination of tests for selected package.");
                        if (!IsContinue)
                            return false;

                        var testIds_array = testIds.split(",");
                        // Split TestIds and select those tests
                        for (var i = 0; i < $('.test-checkbox').length; i++) {
                            var testCheckBox = $('.test-checkbox')[i];
                            var testid = $(testCheckBox).parents('tr').find('.test-id').html();
                            for (var j = 0; j < testIds_array.length; j++) {
                                if (testid == testIds_array[j]) {
                                    $(testCheckBox).attr("checked", true);
                                }
                            }
                        }
                        return true;
                    }
                    else return false;
                }
                var parameter = "{'packageIds':'" + selectPackages + "'";
                parameter += ",'testIds':'" + selectedTests + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/PackageTestDependencyRule.asmx/CheckPackageTestDependencyRule")%>';
                InvokeService(messageUrl, parameter, successFunction);
            }

            function checkPrice(ctrlRef) {
                if ($(ctrlRef).val().trim() == "") {
                    $(ctrlRef).val("0");
                }
            }
        </script>
        <script type="text/javascript" src="/App/Wizard/greybox/AJS.js"></script>
        <script type="text/javascript" src="/App/Wizard/greybox/AJS_fx.js"></script>
        <script type="text/javascript" src="/App/Wizard/greybox/gb_scripts.js"></script>
        <link href="/App/Wizard/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
        <div class="wrapper_inpg">
            <div class="maindivredmsgbox" runat="server" id="divtopmessage" style="display: none">
            </div>
            <h1 class="left" id="h1" runat="server">Create Event Wizard</h1>
            <div class="hr left">
            </div>
            <div id="_divMessage" runat="server" style="display: none">
                <messagecontrol:messages ID="_messageControlPrivatePublic" runat="server" />
            </div>
            <div class="headingbox_top_body">
                Here you can create your event and setup all event related activities – like selecting
            advocates
            </div>
            <div class="headingbox_top_body">
                <img src="../../Images/createeventwizardstep2.gif" alt="" />
            </div>
            <div style="float: left; overflow: hidden; width: 400px; height: 80px; margin: -80px 0px 0px 250px; background: rgba(0, 0, 0, 0.3); border: 1px solid #cdcdcd;">
                &nbsp;
            </div>
            <div class="headingbox_top_body">
                <span class="graysmalltxt_default" id="HostNameStep2" runat="server"></span>
                <br />
                <span class="graysmalltxt_default" id="spHostAddress" runat="server"></span>
                <br />
                <span class="graysmalltxt_default">[<a href="Step1.aspx" style="font-size: 11px">Change</a>]</span><br />
            </div>
            <div class="headingbox_top_body" style="margin-top: 10px">
                <span class="orngbold18_default">Step 2 : Event Information </span>
            </div>
            <div class="hr left">
            </div>
            <div class="subhead">
                <img src="/App/Images/page1symbolvsmall.gif" alt="" />
                <h2 class="toppad">Date and time of the event</h2>
            </div>
            <div class="main_area_bdrnone">
                <div class="maindivpagemainrow_anp">
                    <p class="pagemainrow_anp">
                        <span class="inputfield150px_anp">Event Date:<span class="reqiredmark"><sup>*</sup></span>
                            <asp:TextBox ID="txtEventDate" runat="server" CssClass="inputf_def date-picker" Width="140px"></asp:TextBox>
                        </span><span class="inputfield170px_anp">Team Arrival Time:<span class="reqiredmark"><sup>*</sup></span><span
                            class="inputfield170px_anp">
                            <asp:DropDownList ID="ddlHHStartTime" runat="server" CssClass="inputf_def" Width="45px">
                                <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMMStartTime" runat="server" CssClass="inputf_def" Width="45px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlAMPMStartTime" runat="server" CssClass="inputf_def" Width="50px">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList>
                            <span class="chkboxtxt_prsmall"><em>(Standard time is 08:00 AM)</em></span> </span>
                        </span><span class="inputfield170px_anp" style="margin-right: 5px;"><span class="inputfield170px_anp"
                            style="margin-right: 5px;">Team Departure Time:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfield170px_anp" style="margin-right: 5px;">
                                <asp:DropDownList ID="ddlHHEndTime" runat="server" CssClass="inputf_def" Width="45px">
                                    <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                    <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                    <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                    <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMMEndTime" runat="server" CssClass="inputf_def" Width="45px">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlAMPMEndTime" runat="server" CssClass="inputf_def" Width="50px">
                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                </asp:DropDownList>
                                <span class="chkboxtxt_prsmall"><em>(Standard time is 05:00 PM)</em></span>
                            </span></span><span style="float: left; padding-top: 14px;">
                                <asp:TextBox ID="txtDuration" runat="server" CssClass="inputf_def" Width="80px" ReadOnly="true"></asp:TextBox>
                                Duration </span>
                    </p>
                    <div id="DynamicSlotDiv" runat="server">
                        <div class="pagemainrow_anp">
                            <span class="inputfield150px_anp" style="margin-right: 0;">Scheduling:</span>
                            <span class="inputfield250px_anp" style="float: left;">
                                <input type="radio" value="No" name="DynamicScheduling" id="DynamicSchedulingNoRadioBtn" runat="server" />
                                Static      
                            <input type="radio" value="Yes" name="DynamicScheduling" id="DynamicSchedulingYesRadioBtn" runat="server" />Dynamic               
                            </span>
                        </div>
                        <div class="pagemainrow_anp dynamic-scheduling-div" style="margin-top: 5px;">
                            <fieldset>
                                <legend>Dynamic</legend>
                                <div>
                                    <span class="inputfield150px_anp" style="margin-right: 0px;">
                                        <input type="checkbox" id="EnableLunchDuration" runat="server" />
                                        Enable lunch
                                    </span>
                                    <span class="inputfield170px_anp" style="width: 245px; margin-right: 5px;">
                                        <span class="inputfield170px_anp" style="width: 245px; margin-right: 5px;">Lunch Start Time:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputfield170px_anp" style="width: 245px; margin-right: 5px;">
                                            <asp:DropDownList ID="ddlHHLunchStartTime" runat="server" CssClass="inputf_def" Width="50px">
                                                <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMMLunchStartTime" runat="server" CssClass="inputf_def" Width="50px">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlAMPMLunchStartTime" runat="server" CssClass="inputf_def" Width="50px">
                                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                            </asp:DropDownList>
                                        </span>
                                    </span>
                                    <span class="inputfield150px_anp">
                                        <span class="inputfield150px_anp">Lunch Duration:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputfield150px_anp">
                                            <asp:DropDownList ID="ddlLunchDuration" runat="server">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                            </asp:DropDownList>
                                        </span>
                                    </span>
                                </div>
                                <div style="float: left; margin-top: 10px;">
                                    <span class="inputfield150px_anp">
                                        <span class="inputfield250px_anp">Ancillary Fixed Screening Time:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputfield150px_anp">
                                            <asp:DropDownList ID="ddlFixedAncillaryScreeningTime" runat="server">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                            </asp:DropDownList>
                                        </span>
                                    </span>
                                    <span class="inputfield170px_anp" style="margin-left: 20px;">
                                        <input type="checkbox" id="PackageTimeOnlyCheckbox" runat="server" />
                                        Package Time Only
                                    </span>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <p class="pagemainrow_anp" style="padding-top: 5px;">
                        <span class="inputfield250px_anp" style="margin-right: 10px;">Time Zone:<span class="reqiredmark"><sup>*</sup></span>
                            <asp:DropDownList ID="ddlTimeZone" runat="server" CssClass="inputf_def" Width="250px" Enabled="false">
                                <asp:ListItem Text="">---  Select Time Zone -------</asp:ListItem>
                                <asp:ListItem Text="-10">GMT -10:00  U.S. Hawaiian Time</asp:ListItem>
                                <asp:ListItem Text="-9.5">GMT -09:30  Marquesas</asp:ListItem>
                                <asp:ListItem Text="-9">GMT -09:00  U.S. Alaska Time</asp:ListItem>
                                <asp:ListItem Text="-8">GMT -08:00  Pacific Time</asp:ListItem>
                                <asp:ListItem Text="-7">GMT -07:00  U.S. Mountain Time</asp:ListItem>
                                <asp:ListItem Text="az">GMT -07:00  U.S. Mountain Time (Arizona)</asp:ListItem>
                                <asp:ListItem Text="-6">GMT -06:00  U.S. Central Time</asp:ListItem>
                                <asp:ListItem Text="mx">GMT -06:00  Mexico</asp:ListItem>
                                <asp:ListItem Text="-5" Selected="True">GMT -05:00  U.S. Eastern Time</asp:ListItem>
                                <asp:ListItem Text="in">GMT -05:00  U.S. Eastern Time (Indiana)</asp:ListItem>
                            </asp:DropDownList>
                        </span>
                        <span class="inputfield250px_anp" style="margin-right: 10px;" id="ScheduleTemplateSpan">Schedule Template:
                        <span class="reqiredmark"><sup>*</sup></span>
                            <span id="spnlinkviewslots" style="float: right;">
                                <a href="/App/Franchisee/SalesRep/TemplateTimeSlots.aspx" id="ancTemplate" runat="server" rel="gb_page_center[270, 250]">View Template</a>
                            </span>
                            <asp:DropDownList ID="ddlScheduleTemplate" runat="server" CssClass="inputf_def" Width="250px" onChange="CheckChangeDropDown();">
                            </asp:DropDownList>
                        </span>
                    </p>

                </div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page2symbolvsmall.gif" alt="" />
                <h2 class="toppad">Event Configuration</h2>
            </div>
            <div class="main_area_bdrnone">
                <div class="maindivpagemainrow_anp">
                    <div class="pagemainrow_anp">
                        <span class="inputfield150px_anp" style="margin-right: 0;">Registration Mode:</span>
                        <span class="inputfield250px_anp">
                            <asp:DropDownList ID="ddlRegigtrationMode" runat="server" CssClass="inputf_def" Width="90px">
                            </asp:DropDownList>
                        </span><span class="msgtxt_cew" id="spPrivateMsg">Private events will not show on general
                        registration on the website or call center. Private events will need an invitation
                        code to register. </span>
                    </div>
                    <div class="pagemainrow_anp" style="margin-top: 10px" id="divInvitaionCode">
                        <div class="greybox_cew" style="width: 400px;">
                            <asp:UpdatePanel ID="pnlCouponCode" runat="server">
                                <ContentTemplate>
                                    <div class="row" style="font-weight: bold">
                                        <span class="titletextnowidth_default">Invitation Code:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputfldnowidth_default" style="margin-right: 5px;">
                                            <asp:TextBox ID="txtInvitationCode" runat="server" CssClass="inputf_def" Width="180px"></asp:TextBox>
                                        </span><span class="titletextnowidth_default">
                                            <asp:LinkButton ID="lnkGenerate" OnClick="lnkGenerate_Click" runat="server">Generate</asp:LinkButton>
                                        </span>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;">
                    <div class="pagemainrow_anp">
                        <span class="inputfield150px_anp" style="margin-right: 0;">Event Type:</span>
                        <span class="inputfield250px_anp">
                            <asp:DropDownList ID="ddlEventType" runat="server">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="pagemainrow_anp corporate-div" style="margin-top: 5px; display: none;">
                        <span class="inputfield150px_anp" style="margin-right: 0;">Account:</span>
                        <span class="inputfield250px_anp">
                            <asp:DropDownList ID="ddlCooperateAccounts" runat="server" CssClass="inputf_def" Width="140px">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="pagemainrow_anp healthPlan-div" style="margin-top: 5px; display: none;">
                        <span class="inputfield150px_anp" style="margin-right: 0;">Health Plan:</span>
                        <span class="inputfield250px_anp">
                            <asp:DropDownList ID="ddlHealthPlan" runat="server" CssClass="inputf_def" Width="140px">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="pagemainrow_anp corporate-member-div">
                        <input type="checkbox" id="CaptureInsuranceIdCheckbox" runat="server" />
                        Capture Member Id
                    <input type="checkbox" id="InsuranceIdRequiredCheckbox" runat="server" />
                        Is Member Id required
                    </div>
                    <div class="pagemainrow_anp corporate-image-div">
                        <input type="checkbox" id="EnableProductCheckbox" runat="server" />
                        Enable Images
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;">
                    <div class="pagemainrow_anp">
                        <span class="inputfield150px_anp" style="margin-right: 0;"><b>Hospital Partner:</b></span>
                        <span class="inputfield250px_anp" style="float: left;">
                            <input type="radio" value="No" name="HospitalPartner" id="HospitalPartnerNoRadioBtn" runat="server" />
                            No      
                        <input type="radio" value="Yes" name="HospitalPartner" id="HospitalPartnerYesRadioBtn" runat="server" />Yes               
                        </span>
                    </div>
                    <div class="pagemainrow_anp hospitalpartner-div" style="display: none;">
                        <span class="inputfield150px_anp" style="margin-right: 0; margin-top: 5px;">Specify Hospital Partner:</span>
                        <span class="inputfield250px_anp">
                            <asp:DropDownList ID="ddlHospitalPartner" runat="server" CssClass="inputf_def" Width="190px">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="pagemainrow_anp hospitalpartner-div">
                        <input type="checkbox" id="AttachHospitalMaterialCheckbox" runat="server" />
                        Hospital Material to Result Package
                    </div>
                    <div class="pagemainrow_anp hospitalpartner-div">
                        <input type="checkbox" id="CaptureSsnCheckbox" runat="server" />
                        Capture SSN
                    </div>
                    <div class="pagemainrow_anp hospitalpartner-div">
                        <input type="checkbox" id="RestrictEvaluationCheckbox" runat="server" />
                        Restrict Physician Evaluation
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;">
                    <div class="pagemainrow_anp">
                        <input type="checkbox" id="RecommendPackageCheckbox" runat="server" />
                        Recommend Package
                    </div>
                    <div class="pagemainrow_anp ask-prequalification-qestion">
                        <input type="checkbox" id="AskPreQualificationQuestion" runat="server" />
                        Ask PreQualification Question
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;">
                    <div class="pagemainrow_anp">
                        <input type="checkbox" id="EnableForCallCenter" runat="server" />
                        Allow Call Center Registration/Rescheduling
                    </div>
                    <div class="pagemainrow_anp" style="display: none;">
                        <input type="checkbox" id="EnableForTechnician" runat="server" />
                        Enable For Technician
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;">
                    <div class="pagemainrow_anp">
                        <b>Is Female Only? </b>
                        <input type="checkbox" id="FemaleOnlyCheckbox" runat="server" />
                    </div>
                </div>
                 <div class="maindivpagemainrow_anp NonMammoPatients-div" style="margin-top: 5px; display: none;">
                    <div class="pagemainrow_anp">
                        <b>Allow Non-Mammo Patients on Mammo Events? </b>
                        <input type="checkbox" id="AllowNonMammoPatientsCheckbox" runat="server" />
                    </div>
                </div>
                  <div class="maindivpagemainrow_anp EventProductType-div" style="margin-top: 5px; display: none;">
                    <div class="pagemainrow_anp">
                       <span class="inputfield150px_anp" style="margin-right: 0;margin-top: 5px; width:102px"><b>Select Product:</b></span>
                        <span style="float: left;">
                        <asp:CheckBoxList type="checkboxList" id="EventProductType" runat="server" RepeatDirection="Horizontal"
                                    RepeatColumns="3">
                                </asp:CheckBoxList>
                            </span>
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;" id="EnableAlaCarteDiv" runat="server">
                    <div class="pagemainrow_anp">
                        <b>Enable A la Carte:</b>
                        <input type="checkbox" id="EnableAlaCarteOnlineCheckbox" runat="server" />Online
                    <input type="checkbox" id="EnableAlaCarteCallCenterCheckbox" runat="server" />Call Center
                    <input type="checkbox" id="EnableAlaCarteTechnicianCheckbox" runat="server" />Technician                    
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="margin-top: 5px;">
                    <div class="pagemainrow_anp">
                        <span class="inputfield150px_anp" style="margin-right: 0; margin-top: 5px; width: 200px;">Health Assessment Template:</span>
                        <span class="inputfield250px_anp">
                            <asp:DropDownList ID="HealthAssessmentDropdown" runat="server" CssClass="inputf_def" Width="250px">
                            </asp:DropDownList>
                        </span>
                        <span style="float: left;">
                            <a href="javascript:void(0);" onclick="viewHealthAssessmentTemplateQuestion();" style="margin-left: 5px;">View</a>
                        </span>
                    </div>
                </div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page3symbolvsmall.gif" alt="" />
                <h2 class="toppad">Pod</h2>
            </div>
            <div class="main_area_bdrnone" style="display: block" id="divInvalidEventDate">
                <div class="maindivpagemainrow_anp">
                    <div class="greybox_cew">
                        <div class="row" style="font-weight: bold; color: #D60202;">
                            Please select a territory before you can select a pod
                        </div>
                    </div>
                </div>
            </div>
            <div class="main_area_bdrnone">
                <div class="maindivpagemainrow_anp">
                    <div class="pagemainrow_anp">
                        <span class="inputfield150px_anp" style="margin-right: 0;">Territory:</span>
                        <span class="inputfield250px_anp" style="margin-bottom: 5px;">
                            <asp:DropDownList ID="ddlTerritory" runat="server" CssClass="inputf_def" Width="200px">
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
            </div>
            <div class="main_area_bdrnone" style="display: none" id="divValidEventDate">
                <div class="maindivpagemainrow_anp">
                    <div class="row" style="font-weight: bold; color: #F47E1C;" id="PodBookedDetailDiv">
                    </div>
                    <div class="pagemainrow_anp">
                        <span class="inputfield250px_anp" style="margin-right: 10px;">
                            <span id="spddlPOD">
                                <asp:DropDownList ID="ddlPOD" runat="server" CssClass="inputf_def" Width="250px">
                                </asp:DropDownList>
                            </span>
                        </span>
                        <span class="inputfldnowidth_default" style="padding-top: 12px; margin-right: 10px">
                            <a href="javascript:void(0);" onclick="showCalendar();">View Pod Calendar</a>
                        </span>
                        <span class="inputfldnowidth_default" style="padding-top: 12px;">
                            <asp:ImageButton ID="ibtnAtach" runat="server" ImageUrl="~/App/Images/attach-btn.gif" OnClientClick="return GetPodDetails();" OnClick="ibtnAtach_Click" />
                        </span>
                    </div>
                    <div class="pagemainrow_anp" id="divPODDetails">
                        <div style="float: left; width: 700px; padding: 2px;">
                            <asp:GridView ID="gvPOD" GridLines="None" runat="server" CssClass="grid" DataKeyNames="PodId" ShowHeader="false" AutoGenerateColumns="false" OnRowDataBound="gvPOD_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="divaddpod_sne" id="Div2">
                                                <p class="middivrownopad_sne">
                                                    <span class="boldtxt_sne">
                                                        <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                                        <asp:HiddenField ID='hfPodId' runat='server' Value='<%#DataBinder.Eval(Container.DataItem, "PodId")%>' />
                                                    </span>
                                                    <span class="removelnkright_sne">
                                                        <asp:LinkButton runat="server" ID="lnkRemovePod" Text="Remove" OnClick="lnkRemovePod_Click"
                                                            OnClientClick="return CheckPodDelete();" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PodId")%>'></asp:LinkButton>
                                                    </span>
                                                </p>
                                                <div style="float: left; width: 100%;" class="pod-room-detail">
                                                    <asp:GridView runat="server" ID="RoomGridView" GridLines="None" ShowHeader="false" AutoGenerateColumns="false" OnRowDataBound="RoomGridView_RowDataBound" CssClass="room-grid">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <fieldset>
                                                                        <legend>Room <%#DataBinder.Eval(Container.DataItem, "RoomNo")%></legend>
                                                                        <asp:HiddenField runat="server" ID="hfRoomNo" Value='<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>' />
                                                                        <div style="float: left; width: 100%;">
                                                                            Duration:
                                                                            <asp:TextBox ID='txtDuration' CssClass="duration" runat='server' Text='<%#DataBinder.Eval(Container.DataItem, "Duration")%>' Width='60px'></asp:TextBox>
                                                                            (minutes)
                                                                        </div>
                                                                        <div style="float: left; width: 100%;">
                                                                            <asp:GridView runat="server" ID="TestGridView" GridLines="None" ShowHeader="false" AutoGenerateColumns="false" CssClass="test-grid">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <div>
                                                                                                <input type="checkbox" id="chkIsSelected" runat="server" checked='<%#DataBinder.Eval(Container.DataItem, "IsSelected")%>' />
                                                                                                <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                                                                                <asp:HiddenField runat="server" ID="hfTestId" Value='<%#DataBinder.Eval(Container.DataItem, "TestId")%>' />
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </fieldset>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="White" />
                                <RowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="subhead">
                <img src="/App/Images/page4symbolvsmall.gif" alt="" />
                <h2 class="toppad">Select Packages/Tests</h2>
                <div style="text-align: right; display:none;" id="resultEntryNote">
                    <span>
                        <input type="text" style="background-color: #00a3cc; width: 10px; height: 10px;" disabled="disabled" />
                        Result Entry in CHAT*</span>
                </div>

            </div>

            <div class="main_area_bdrnone" style="display: block" id="NoPackageAvailableDiv"
                runat="server">
                <div class="maindivpagemainrow_anp">
                    <div class="greybox_cew">
                        <div class="row" style="font-weight: bold; color: #D60202;">
                            <asp:LinkButton ID="LoadPackageLinkBtn" runat="server" OnClick="LoadPackageLinkBtn_Click" OnClientClick="return CheckPodSelected();" Text="Load Package "></asp:LinkButton>
                        </div>
                        <span class="row" style="font-weight: bold; color: #D60202;" id="NoPackageAvailableSpan" runat="server"></span>
                    </div>
                </div>
            </div>
            <div class="main_area_bdrnone">
                <div class="maindivpagemainrow_anp" style="display: none" id="PackageAvailableDiv"
                    runat="server">
                    <div class="pagemainrow_anp">
                        <asp:GridView runat="server" ID="grdSelectPackage" AutoGenerateColumns="False" CssClass="divgrid_cl"
                            GridLines="None" OnRowDataBound="grdSelectPackage_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAllPackage" runat="server" onclick="SelectAllPackage(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input class="package-checkbox" type="checkbox" id="chkRowChild" checked='<%#DataBinder.Eval(Container.DataItem, "IsSelectedByDefaultForEvent")%>'
                                            runat="server" />
                                        <span style="display: none;" class="package-id">
                                            <%#DataBinder.Eval(Container.DataItem, "PackageId")%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Package Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackageName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                        <br />
                                        <span>
                                            <b>Available For Gender:</b> <span id="PackageGender" runat="server"><%# ((Gender)Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Gender"))).GetDescription()  %></span>
                                        </span>
                                        <div class="showHideMostPopularBestValue">
                                            <span>
                                                <input type="checkbox" id="MostPopular" runat="server" checked='<%#DataBinder.Eval(Container.DataItem, "MostPopular")%>' />
                                                Most Popular
                                            </span>
                                            <span>
                                                <input type="checkbox" id="BestValue" runat="server" checked='<%#DataBinder.Eval(Container.DataItem, "BestValue")%>' />
                                                Best Value
                                            </span>
                                        </div>
                                        <asp:HiddenField ID='hfPackageID' runat='server' Value='<%#DataBinder.Eval(Container.DataItem, "PackageId")%>' />
                                        <asp:HiddenField ID='hfPackageGenderId' runat='server' Value='<%#DataBinder.Eval(Container.DataItem, "Gender")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Standard Package Price">
                                    <ItemTemplate>
                                        $&nbsp;<%#DataBinder.Eval(Container.DataItem, "Price")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Package Price">
                                    <ItemTemplate>
                                        <asp:TextBox ID='txtEPPrice' runat='server' onblur="checkPrice(this);" Text='<%#DataBinder.Eval(Container.DataItem, "Price")%>'
                                            Width='60px'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recommend" HeaderStyle-CssClass="recommend-package" ItemStyle-CssClass="recommend-package">
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkRecommendSelected" checked='<%#DataBinder.Eval(Container.DataItem, "IsRecommended")%>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Screening Time" HeaderStyle-CssClass="screening-time" ItemStyle-CssClass="screening-time">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPackageScreeningTime" runat="server" CssClass="package-screening-time">
                                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Room" HeaderStyle-CssClass="screening-room" ItemStyle-CssClass="screening-room">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPackageScreeningRoom" runat="server" CssClass="package-screening-room">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hdfPackageScreeningRoomID" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="row2" />
                            <HeaderStyle CssClass="row1" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="maindivpagemainrow_anp" style="display: none" id="_testDiv" runat="server">

                    <div class="pagemainrow_anp">
                        <asp:GridView runat="server" ID="_testGrid" AutoGenerateColumns="False" CssClass="divgrid_cl"
                            GridLines="None" OnRowDataBound="testGrid_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAllTest" runat="server" onclick="SelectAllTest(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <span style="display: none;" class="test-id" id="_testIdSpan" runat="server"><%#DataBinder.Eval(Container.DataItem, "Id")%></span>
                                        <input class="test-checkbox" type="checkbox" id="chkTestSelected" checked='<%#DataBinder.Eval(Container.DataItem, "IsSelectedByDefaultForEvent")%>' runat="server" />
                                        <input type="hidden" id="hdn_ResultentryTypeId" value='<%#DataBinder.Eval(Container.DataItem, "ResultEntryTypeId")%>' />
                                        <input type="hidden" id="hdn_ChatStartDate" value='<%#DataBinder.Eval(Container.DataItem, "ChatStartDate")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <span id="_testName" runat="server"><%#DataBinder.Eval(Container.DataItem, "Name")%></span>
                                        <span>
                                            <br />
                                            <b>Group: </b><%# ((TestGroupType)Convert.ToInt64(DataBinder.Eval(Container.DataItem, "GroupId"))).GetDescription() %>
                                        </span>
                                        <asp:HiddenField ID='hfTestId' runat='server' Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Standard Test Price">
                                    <ItemTemplate>
                                        $&nbsp;<%#DataBinder.Eval(Container.DataItem, "Price")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Test Price">
                                    <ItemTemplate>
                                        <asp:TextBox ID='_txtEventTestPrice' onblur="checkPrice(this);" runat='server' Text='<%#DataBinder.Eval(Container.DataItem, "Price")%>'
                                            Width='60px'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Test Price (With Package)">
                                    <ItemTemplate>
                                        <asp:TextBox ID='_txtEventTestWithPackagePrice' onblur="checkPrice(this);" runat='server' Text='<%#DataBinder.Eval(Container.DataItem, "WithPackagePrice")%>'
                                            Width='60px'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Screening Time" HeaderStyle-CssClass="screening-time" ItemStyle-CssClass="screening-time">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTestScreeningTime" runat="server" CssClass="test-screening-time">
                                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Show in A la carte Online">
                                    <ItemTemplate>
                                        <input class="alacarte-checkbox" type="checkbox" id="chkAlaCarteSelected" checked='<%#DataBinder.Eval(Container.DataItem, "ShowInAlaCarte")%>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <RowStyle CssClass="row2" />
                            <HeaderStyle CssClass="row1" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="main_area_bdrnone eventStatus_div">
                <div class="subhead">
                    <img src="/App/Images/page4symbolvsmall.gif" alt="" />
                    <h2 class="toppad">Event Status</h2>
                </div>
                <div class="maindivpagemainrow_anp">
                    <p class="pagemainrow_anp">
                        <span class="inputfield250px_anp" style="margin-right: 10px;">
                            <asp:DropDownList ID="ddlEventStatus" runat="server" CssClass="inputf_def" Width="250px">
                            </asp:DropDownList>
                        </span><span class="inputfldnowidth_default"><a id="aToolTip" href="javascript:void(0);"
                            style="font-size: 18px; font-weight: bold" onmouseover="showToolTip();" onmouseout="hideToolTip();">?</a> </span>
                    </p>

                    <p class="pagemainrow_anp" id="pEventCancellationReason" style="display: none;">
                        <span class="inputfield250px_anp" style="margin-right: 5px;">Event Cancelation Reason:<span class="reqiredmark"><sup>*</sup></span>
                            <asp:DropDownList ID="ddlEventCancellationReason" runat="server" CssClass="inputf_def"
                                Width="250px">
                            </asp:DropDownList>
                        </span>
                    </p>

                    <p class="pagemainrow_anp" id="pEventNotes" style="display: none;">
                        <span class="inputfield250px_anp">Notes<span class="reqiredmark"><sup>*</sup></span>
                            <asp:TextBox ID="txtNotes" runat="server" CssClass="inputf_def" Width="250px" TextMode="MultiLine"></asp:TextBox>
                        </span>
                    </p>
                </div>
            </div>
            <div class="main_area_bdrnone taskandSales_div">
                <div class="subhead" id="divTaskAndSalesRepHeading" runat="server">
                    <img src="/App/Images/page5symbolvsmall.gif" alt="" />
                    <h2 class="toppad">Task and Sales Rep assignment</h2>
                </div>
                <div class="maindivpagemainrow_anp" id="divTaskAndSalesRepDetails" runat="server">
                    <p class="pagemainrow_anp">
                        <span class="inputfield250px_anp" style="margin-right: 5px;">Event Task Template:
                        <asp:DropDownList ID="ddlEventTaskTemplate" runat="server" CssClass="inputf_def"
                            Width="250px">
                        </asp:DropDownList>
                        </span><span class="inputfldnowidth_default" style="padding-top: 12px;"><a href="javascript:void(0);"
                            onclick="showEventTemplateActivity();">View Activities</a> </span>
                    </p>
                </div>
            </div>
            <div class="main_area_bdrnone">

                <div class="maindivpagemainrow_anp" style="margin-top: 10px">
                    <%--<span class="buttoncon_default">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App/Images/next-button.gif"
                        OnClick="ibtnNext_Click" OnClientClick="return VaidateEvent();" />
                </span>--%>
                    <span class="buttoncon4_default">
                        <asp:ImageButton ID="ibtnSaveClose" runat="server" ImageUrl="~/App/Images/save-n-close-gif.gif"
                            OnClick="ibtnSaveClose_Click" OnClientClick="return VaidateEvent();" />
                        <img src="/App/Images/loading.gif" id="loading-image-save-event" style="display: none;" />
                    </span><span class="buttoncon_default">
                        <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-buton.gif"
                            OnClick="ibtnBack_Click" />
                    </span><span class="buttoncon_default">
                        <asp:ImageButton ID="Step2CancelImgButton" runat="server" ImageUrl="~/App/Images/cancel-btn.gif"
                            OnClick="Step2CancelImgButton_Click" />
                    </span>
                </div>
                <div class="main_area_bdrnone">
                    <span style="float: right; font: normal 10px arial; margin-bottom: 5px;">Next step you
                    get to define the advocates that can help promote the event. </span><span style="float: right; padding-top: 3px; margin-bottom: 5px;">
                        <img src="/App/Images/small-orng-arrow.gif" /></span>
                </div>
            </div>
        </div>
        <div id="divToolTip" runat="server" style="position: absolute; display: none; border: solid 1px #FEF399; background-color: #FFFCDF; padding: 2px;">
        </div>
        <asp:HiddenField ID="hfPodID" runat="server" />
        <asp:LinkButton ID="lnkbtnTemp" runat="server"></asp:LinkButton>
        <asp:HiddenField ID="hfHealthAssessmentTemplateId" runat="server" Value="0" />
        <%--BEGIN Pod Calendar DIV --%>
        <div id="ViewPodCalendar" title="View Pod Calendar" style="display: none">
            <div class="wrapperin_pop">
                <div class="innermain_pop" id="divCalendar">
                </div>
                <div class="prenextband" style="border-top: none;">
                    <span style="float: left"><a href="javascript:void(0)" onclick="showPrevMonthPodCal();">
                        <img src="/App/Images/premonth-cal_event.gif" alt="Previous Month" /></a></span>
                    <span style="float: right"><a href="javascript:void(0)" onclick="showNextMonthPodCal();">
                        <img src="/App/Images/nextmonth-cal_event.gif" alt="Next Month" /></a></span>
                </div>
            </div>
        </div>
        <%--END Pod Calendar DIV --%>
        <div id="screening-time-message" title="Screeing Time Alert" style="display: none">
        </div>
        <div id="screening-package-room-validate" title="Room Package Alert" style="display: none">
        </div>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lnkbtnTemp"
            PopupControlID="pnlEventActivity" BackgroundCssClass="modalBackground" CancelControlID="imgBtnCloseActivity"
            BehaviorID="mdlEventActivity" />
        <asp:Panel ID="pnlEventActivity" runat="server">
            <div class="wrapper_pop">
                <div class="wrapperin_pop">
                    <div class="innermain_pop" id="divActivity">
                    </div>
                    <div class="innermain_pop" style="text-align: right; margin-top: 5px">
                        <asp:ImageButton runat="server" ID="imgBtnCloseActivity" ImageUrl="~/App/Images/close-btn.gif" />
                    </div>
                </div>
            </div>
        </asp:Panel>
        <script type="text/javascript">
            function showHidePackageRecommendation() {
                if ($("#<%=RecommendPackageCheckbox.ClientID %>").is(":checked")) {
                    $(".recommend-package").show();
                } else {
                    $(".recommend-package").hide();
                }
            }

            function showHideAskPreQualificationQuestion() {
                if ("<%= GlobalAskPreQualificationQuestion%>" == "<%= Boolean.TrueString%>") {
                    $(".ask-prequalification-qestion").show();
                } else {
                    $(".ask-prequalification-qestion").hide();
                    $("#<%= AskPreQualificationQuestion.ClientID%>").attr("checked", false);
                }
            }



            $(document).ready(function () {
                //debugger;

                $('#ViewPodCalendar').dialog({ width: 580, height: 380, autoOpen: false, resizable: false, draggable: false });
                $('#screening-time-message').dialog({ width: 500, height: 250, autoOpen: false });
                $('#screening-package-room-validate').dialog({ width: 500, height: 250, autoOpen: false });

                $(".date-picker").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-10:+50"
                });

                $('#<%=ddlEventType.ClientID %>').bind("change", function () {
                    //debugger;
                    ShowHideCooperateAccount();
                    setOnlineAlaCarte();
                    ResetPackageAndTest();
                    CheckCorporateAccount();

                    if ($('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.Retail%>') {
                        $("#<%=RecommendPackageCheckbox.ClientID %>").attr('checked', true);
                    }
                   
                });

                $("#<%=RecommendPackageCheckbox.ClientID %>").bind("click", function () { showHidePackageRecommendation(); });
                $('#<%=ddlTerritory.ClientID %>').bind("change", function () { ResetPackageAndTest(); });
                var eventId = "<%=EventId %>";
                if (eventId == null || eventId == 0) {
                    $('#<%=PackageTimeOnlyCheckbox.ClientID %>').bind("change", function () { ResetPackageAndTest(); });
                }
                $('#<%=ddlCooperateAccounts.ClientID %>').bind("change", function () { ResetPackageAndTest(); CheckCorporateAccount(); });
                $('#<%=ddlHealthPlan.ClientID %>').bind("change", function () { ResetPackageAndTest(); CheckCorporateAccount(); });
                $('#<%=ddlHospitalPartner.ClientID %>').bind("change", function () { ResetPackageAndTest(); CheckHospitalMaterial(this); ResetHafTemplate(); GetHealthAssessmentTemplate(); CheckHospitalPartner(); });

                $('#<%=HospitalPartnerNoRadioBtn.ClientID %>').bind("click", function () { ShowHideddlHospitalPartner(); ResetPackageAndTest(); ResetHafTemplate(); GetHealthAssessmentTemplate(); CheckHospitalPartner(); });

                $('#<%=HospitalPartnerYesRadioBtn.ClientID %>').bind("click", function () { ShowHideddlHospitalPartner(); });

                $("#<%= AttachHospitalMaterialCheckbox.ClientID %>").bind("click", function () { CheckHospitalMaterial(this); });

                if (!$('#<%=HospitalPartnerYesRadioBtn.ClientID %>').attr("checked")) {
                    $('#<%=HospitalPartnerNoRadioBtn.ClientID %>').attr("checked", true);
                }

                $('#<%=DynamicSchedulingNoRadioBtn.ClientID %>').bind("click", function () { clickGenerateDynamicSlot(); });

                $('#<%=DynamicSchedulingYesRadioBtn.ClientID %>').bind("click", function () { clickGenerateDynamicSlot(); });

                $("#<%= EnableLunchDuration.ClientID %>").bind("click", function () { EnableDisableLunch(); });

                $("#<%= PackageTimeOnlyCheckbox.ClientID %>").bind("click", function () { HideShowPackagePodRoom(); });

                ShowHideCooperateAccount();
                ShowHideddlHospitalPartner();
                ShowHidePodDropDown();
                clickGenerateDynamicSlot();
                CheckInsuranceId();
                showHidePackageRecommendation();
                showHideAskPreQualificationQuestion();

                if (showScreeningMessage) {
                    $("#screening-time-message").dialog('open');
                }
                else {
                    $("#screening-time-message").dialog('close');
                }

                if (showScreeningPackageRoomAlertMessage) {
                    $("#screening-package-room-validate").dialog('open');
                }
                else {
                    $("#screening-package-room-validate").dialog('close');
                }

                GetHealthAssessmentTemplate();
                $('#<%=HealthAssessmentDropdown.ClientID %>').bind("change", function () { SetHealthAssessmentTemplate(); });

                $("#<%= CaptureInsuranceIdCheckbox.ClientID %>").bind("click", function () { CheckInsuranceId(); });

                changeBGColorifChat();

            });

            function ShowHideCooperateAccount() {
                if ($('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.Corporate%>') {
                    $('.corporate-div').show();
                    $('.healthPlan-div').hide();
                    $('.corporate-member-div').show();
                    $('.corporate-image-div').show();
                    $('.NonMammoPatients-div').hide();
                    $('.EventProductType-div').hide();
                    $('#<%=ddlHealthPlan.ClientID %>').val('0');
                }
                else if ($('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.HealthPlan%>') {
                    $('.healthPlan-div').show();
                    $('.corporate-div').hide();
                    $('.corporate-member-div').show();
                    $('.corporate-image-div').show();
                    $('.NonMammoPatients-div').show();
                    $('.EventProductType-div').show();
                    $('#<%=ddlCooperateAccounts.ClientID %>').val('0');
                }
                else {
                    $('.corporate-div').hide();
                    $('.healthPlan-div').hide();
                    $('.corporate-member-div').hide();
                    $('.corporate-image-div').hide();
                    $('.NonMammoPatients-div').hide();
                    $('.EventProductType-div').hide();
                    $('#<%=ddlCooperateAccounts.ClientID %>').val('0');
                    $('#<%=ddlHealthPlan.ClientID %>').val('0');
                    $("#<%= CaptureInsuranceIdCheckbox.ClientID %>").attr("checked", false);
                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("checked", false);
                }
              
        }

        function ShowHideddlHospitalPartner() {//debugger;
            if ($('#<%=HospitalPartnerNoRadioBtn.ClientID %>').attr('checked')) {
                    $('.hospitalpartner-div').hide();
                    $('#<%=ddlHospitalPartner.ClientID %>').val('0');
                }
                else if ($('#<%=HospitalPartnerYesRadioBtn.ClientID %>').attr('checked'))
                    $('.hospitalpartner-div').show();
            }

            function ResetHafTemplate() {
                var selectedTemplate = $("#<%= hfHealthAssessmentTemplateId.ClientID %>");
                var eventId = '<%= EventId.HasValue ? EventId.Value : 0 %>';
                if (parseInt(eventId) < 1) {
                    selectedTemplate.val("0");
                }
            }

            function ShowHidePodDropDown() {
                var ddlTerritory = $('#<%= ddlTerritory.ClientID %>');
                if ($('#<%= ddlTerritory.ClientID %> option').length == 1 || ddlTerritory.val() != "0") {
                    document.getElementById("divInvalidEventDate").style.display = "none";
                    document.getElementById("divValidEventDate").style.display = "block";
                }
                else {
                    document.getElementById("divInvalidEventDate").style.display = "block";
                    document.getElementById("divValidEventDate").style.display = "none";
                }

            }

            function EnableDisableLunch() {
                if ($("#<%= EnableLunchDuration.ClientID %>").is(":checked")) {

                    $("#<%=ddlHHLunchStartTime.ClientID %>").removeAttr("disabled");
                    $("#<%=ddlMMLunchStartTime.ClientID %>").removeAttr("disabled");
                    $("#<%=ddlAMPMLunchStartTime.ClientID %>").removeAttr("disabled");
                    $("#<%=ddlLunchDuration.ClientID %>").removeAttr("disabled");
                }
                else {
                    $("#<%=ddlHHLunchStartTime.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlMMLunchStartTime.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlAMPMLunchStartTime.ClientID %>").attr("disabled", "disabled");
                    $("#<%=ddlLunchDuration.ClientID %>").attr("disabled", "disabled");
                }
            }

            function CheckInsuranceId() {
                if ($("#<%= CaptureInsuranceIdCheckbox.ClientID %>").is(":checked") == false) {
                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("checked", false);
                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("disabled", "disabled");
                } else {
                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").removeAttr("disabled");
                }
            }

            function changeBGColorifChat() {

                var eventDate = $("#<%=txtEventDate.ClientID %>").val();
              
                if (parseInt($('#<%=ddlEventType.ClientID %>').val()) == '<%=(int)EventType.HealthPlan %>')
                {
                    $("#<%=_testGrid.ClientID %> tr").each(function () {

                        $(this).closest('tr').css('background-color', '');
                        var hdn_ResultentryTypeId = $(this).find("#hdn_ResultentryTypeId").val();
                        var hdn_ChatStartDate = $(this).find("#hdn_ChatStartDate").val();
                        var chatDate = new Date(hdn_ChatStartDate);
                        var validChatDate = new Date();
                        if (chatDate != "Invalid Date") {

                            validChatDate = (chatDate.getMonth() + 1) + "/" + (chatDate.getDate()) + "/" + chatDate.getFullYear();

                            if (hdn_ResultentryTypeId == '<%=(long)ResultEntryType.Chat %>' && (eventDate != "") && Date.parse(eventDate) >= Date.parse(validChatDate)) {
                                $("#resultEntryNote").show();
                                $(this).closest('tr').css('background-color', '#00a3cc');
                            }
                        }
                     });
                }
               
            }
            $("#<%=txtEventDate.ClientID %>").datepicker({
                onSelect: function (dateText) {
                    changeBGColorifChat();
                }
            });


        </script>

        <script type="text/javascript">
            function CheckHospitalMaterial(sourceControl) {
                if (parseInt($('#<%=ddlHospitalPartner.ClientID %>').val()) > 0 || $("#<%= AttachHospitalMaterialCheckbox.ClientID %>").attr("checked")) {

                    $.ajax({
                        type: "POST",
                        cache: false,
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "/Users/MedicalVendor/GetMedicalVendor?medicalVendorId=" + $('#<%=ddlHospitalPartner.ClientID %>').val(),
                        data: "{}",
                        success: function (result) {
                            if (result.ResultLetterCoBrandingFileId != null && result.ResultLetterCoBrandingFileId > 0) {
                                if ($(sourceControl).attr("id") == '<%=ddlHospitalPartner.ClientID %>') {
                                    $("#<%= AttachHospitalMaterialCheckbox.ClientID %>").attr("checked", true);
                                }
                            }
                            else {
                                $("#<%= AttachHospitalMaterialCheckbox.ClientID %>").attr("checked", false);
                                alert("Since the Result letter for the selected Hospital is not uploaded yet, you will not be able to attach hospital material with result Package of this event!");
                            }
                        },
                        error: function (a, b, c) {

                        }
                    });
                }
            }

            function CheckHospitalPartner() {
                if (parseInt($('#<%=ddlHospitalPartner.ClientID %>').val()) > 0) {

                    $.ajax({
                        type: "POST",
                        cache: false,
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "/Users/MedicalVendor/GetHospitalPartner?hospiatalPartnerId=" + $('#<%=ddlHospitalPartner.ClientID %>').val(),
                        data: "{}",
                        success: function (result) {
                            //debugger;
                            if (result.CaptureSsn) {
                                $("#<%= CaptureSsnCheckbox.ClientID %>").attr("checked", true);
                            }
                            else {
                                $("#<%= CaptureSsnCheckbox.ClientID %>").attr("checked", false);
                                //$("#<%= CaptureSsnCheckbox.ClientID %>").attr("disabled", "disabled");
                            }

                            if (result.RestrictEvaluation) {
                                $("#<%= RestrictEvaluationCheckbox.ClientID %>").attr("checked", true);
                            }
                            else {
                                $("#<%= RestrictEvaluationCheckbox.ClientID %>").attr("checked", false);
                            }

                            if (parseInt($('#<%=ddlCooperateAccounts.ClientID %>').val()) <= 0 || parseInt($('#<%=ddlHealthPlan.ClientID %>').val()) <= 0) {
                            
                                                           <%-- if (result.RecommendPackage) {
                                $("#<%= RecommendPackageCheckbox.ClientID %>").attr("checked", true);
                            }
                            else {
                                $("#<%= RecommendPackageCheckbox.ClientID %>").attr("checked", false);
                            }--%>

                                if (result.AskPreQualificationQuestion) {
                                    $("#<%= AskPreQualificationQuestion.ClientID %>").attr("checked", true);
                                }
                                else {
                                    $("#<%= AskPreQualificationQuestion.ClientID %>").attr("checked", false);
                                }
                                showHidePackageRecommendation();
                                showHideAskPreQualificationQuestion();
                            }
                        },
                        error: function (a, b, c) {

                        }
                    });
                } else {
                    $("#<%= CaptureSsnCheckbox.ClientID %>").attr("checked", false);
                    //$("#<%= CaptureSsnCheckbox.ClientID %>").attr("disabled", "disabled");

                    if (parseInt($('#<%=ddlCooperateAccounts.ClientID %>').val()) <= 0 || parseInt($('#<%=ddlHealthPlan.ClientID %>').val()) <= 0) {
                        $("#<%= RecommendPackageCheckbox.ClientID %>").attr("checked", false);
                        $("#<%= AskPreQualificationQuestion.ClientID %>").attr("checked", true);
                        showHidePackageRecommendation();
                        showHideAskPreQualificationQuestion();
                    }
                }

            }

            function CheckCorporateAccount() {
                if (parseInt($('#<%=ddlCooperateAccounts.ClientID %>').val()) > 0 || parseInt($('#<%=ddlHealthPlan.ClientID %>').val()) > 0) {
                    var accountId;
                    if (parseInt($('#<%=ddlCooperateAccounts.ClientID %>').val()) > 0)
                        accountId = $('#<%=ddlCooperateAccounts.ClientID %>').val();
                    else if (parseInt($('#<%=ddlHealthPlan.ClientID %>').val()) > 0)
                        accountId = $('#<%=ddlHealthPlan.ClientID %>').val();

                $.ajax({
                    type: "POST",
                    cache: false,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "/Users/CorporateAccount/GetCorporateAccount?accountId=" + accountId,
                    data: "{}",
                    success: function (result) {
                        if (result.CaptureInsuranceId) {
                            $("#<%= CaptureInsuranceIdCheckbox.ClientID %>").attr("checked", true);
                                $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").removeAttr("disabled");

                                if (result.CaptureInsuranceId && result.InsuranceIdRequired) {
                                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("checked", true);
                                }
                                else {
                                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("checked", false);
                                }
                            }
                            else {
                                $("#<%= CaptureInsuranceIdCheckbox.ClientID %>").attr("checked", false);
                                $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("checked", false);
                                $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("disabled", "disabled");
                            }

                                                   <%-- if (result.RecommendPackage) {
                            $("#<%= RecommendPackageCheckbox.ClientID %>").attr("checked", true);
                        }
                        else {
                            $("#<%= RecommendPackageCheckbox.ClientID %>").attr("checked", false);
                        }--%>

                            if (result.AskPreQualificationQuestion) {
                                $("#<%= AskPreQualificationQuestion.ClientID %>").attr("checked", true);
                            } else {
                                $("#<%= AskPreQualificationQuestion.ClientID %>").attr("checked", false);
                            }
                            showHidePackageRecommendation();
                            showHideAskPreQualificationQuestion();
                        },
                        error: function (a, b, c) {

                        }
                    });
                } else {
                    $("#<%= CaptureInsuranceIdCheckbox.ClientID %>").attr("checked", false);
                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("checked", false);
                    $("#<%= InsuranceIdRequiredCheckbox.ClientID %>").attr("disabled", "disabled");
                    CheckHospitalPartner();
                }
            }

            function clickGenerateDynamicSlot() {
                var ddlScheduleTemplate = $("#<%= ddlScheduleTemplate.ClientID %>");
                var ScheduleTemplateSpan = $("#ScheduleTemplateSpan");
                var dynamicSchedulingDiv = $(".dynamic-scheduling-div");

                if ($("#<%= DynamicSchedulingYesRadioBtn.ClientID %>").is(":checked")) {
                    ddlScheduleTemplate.val("0");
                    CheckChangeDropDown();
                    ScheduleTemplateSpan.hide();
                    dynamicSchedulingDiv.show();
                    $(".screening-time").show();
                    $(".pod-room-detail").show();
                    EnableDisableLunch();
                }
                else {
                    ScheduleTemplateSpan.show();
                    dynamicSchedulingDiv.hide();
                    $(".screening-time").hide();
                    $(".pod-room-detail").hide();
                }
                HideShowPackagePodRoom();
            }

            function HideShowPackagePodRoom() {
                if ($("#<%= DynamicSchedulingYesRadioBtn.ClientID %>").is(":checked")) {
                    if ($("#<%= PackageTimeOnlyCheckbox.ClientID %>").is(":checked")) {
                        $(".screening-room").show();
                    }
                    else {
                        $(".screening-room").hide();
                    }
                }
                else {
                    $(".screening-room").hide();
                }
            }

            var showScreeningMessage = false;
            function screeningTimeMessage(message) {
                $("#screening-time-message").html(message);
                showScreeningMessage = true;
            }
            var showScreeningPackageRoomAlertMessage = false;
            function screeningPackageRoomValidateMessage(message) {
                $("#screening-package-room-validate").html(message);
                showScreeningPackageRoomAlertMessage = true;
            }


            function setOnlineAlaCarte() {
                if ($('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.Corporate%>' || $('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.HealthPlan%>') {
                    $("#<%=EnableAlaCarteOnlineCheckbox.ClientID %>").attr("checked", false);
                }
                else {
                    $("#<%=EnableAlaCarteOnlineCheckbox.ClientID %>").attr("checked", true);
                }
            }
        </script>
        <script type="text/javascript">

            $(document).ready(function () {
                if ($('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.Corporate%>' || $('#<%=ddlEventType.ClientID %> option:selected').text() == '<%=EventType.HealthPlan%>') {
                    $(".showHideMostPopularBestValue").hide();
                }
            });
        </script>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="MedicalVendor_MedicalVendor" Title="Untitled Page"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="MedicalVendor.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Register Src="../UCCommon/UCAddress.ascx" TagName="UCAddress" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <style type="text/css">
        .main_content_area_amv
        {
            float: left;
            width: 751px;
        }
        .inputf_amv
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .headbg_boxtop_amv
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-bottom: 0px;
        }
        .headbg_box_amv
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 5px;
        }
        .headbg_boxprates_amv
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 5px;
            margin-bottom: 3px;
        }
        .head_text_amv
        {
            float: left;
            width: 740px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .maindivwiringdetails_amv
        {
            float: left;
            width: 753px;
        }
        .main_container_row_amv
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 3px;
            padding-right: 5px;
            padding-bottom: 3px;
        }
        .titletext_amv
        {
            float: left;
            width: 110px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldcon_amv
        {
            float: left;
            width: 180px;
            margin-right: 85px;
            padding-top: 0px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldcon1_amv
        {
            float: left;
            width: 200px;
            margin-right: 65px;
            padding-top: 0px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldareacon_amv
        {
            float: left;
            width: 600px;
            padding-top: 0px;
        }
        .inputfieldrightcon_amv
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldrightcon1_amv
        {
            float: left;
            width: 200px;
            font: normal 12px arial;
            color: #000;
            font: bold 12px arial;
            color: #000;
        }
        .main_containerreff_row_amv
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-right: 5px;
        }
        .main_containerreff2_row_amv
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-right: 5px;
            padding-bottom: 5px;
        }
        .titlenamereff_amv
        {
            float: left;
            width: 180px;
            padding-top: 5px;
            padding-right: 85px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfielddatecon_amv
        {
            float: left;
            width: 180px;
            margin-right: 85px;
        }
        .divgrid_amv
        {
            float: left;
            width: 520px;
        }
        .gridptestandrate_amv
        {
            float: left;
            width: 520px;
        }
        .gridrows_amv
        {
            width: 515px;
            padding: 4px;
            text-align: left;
            font: bold 12px arial;
        }
        .headerchkboxgrid_amv
        {
            float: left;
            width: 20px;
            padding-left: 5px;
            font: normal 12px arial;
            color: #000;
        }
        .itemschkboxgrid_amv
        {
            float: left;
            width: 20px;
            padding-left: 5px;
            font: normal 12px arial;
            color: #000;
        }
        .headerstyle_amv
        {
            float: left;
            width: 260px;
            font: bold 12px arial;
            color: #000;
            text-align: left;
        }
        .itemstyle_amv
        {
            float: left;
            width: 260px;
            font: normal 12px arial;
            color: #000;
            text-align: left;
        }
        .left_maincontainer_afse
        {
            float: left;
            width: 350px;
            margin-right: 2px;
        }
        .headbg_boxleft_afse
        {
            float: left;
            width: 350px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 10px;
            margin-bottom: 3px;
        }
        .head_textleftbox_afse
        {
            float: left;
            width: 325px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .left_container_rows_afse
        {
            float: left;
            width: 325px;
            padding-left: 10px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
        .titletext_afse
        {
            float: left;
            width: 110px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldleftcon_afse
        {
            float: left;
            width: 180px;
            padding-top: 0px;
        }
        .inputf_afse
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .inputf_accm
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .right_maincontainer_amv
        {
            float: left;
            width: 399px;
        }
        .headbg_boxright_amv
        {
            float: left;
            width: 399px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 10px;
            margin-bottom: 3px;
        }
        .head_chkboxright_afse
        {
            float: left;
            width: 22px;
            padding-left: 1px;
            padding-top: 2px;
        }
        .head_textrightbox_afse
        {
            float: left;
            width: 85px;
            padding-left: 1px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .divmessagetext_afse
        {
            float: left;
            width: 285px;
            padding-left: 2px;
            padding-top: 6px;
            font: normal 11px Arial;
            color: #FF0000;
        }
        .right_container_rows_afse
        {
            float: left;
            width: 325px;
            padding-left: 37px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
        .inputfieldcon_afse
        {
            float: left;
            width: 180px;
            margin-right: 85px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldrightcon_afse
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
            font: bold 12px arial;
            color: #000;
        }
        .main_container_row_afse
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 3px;
            padding-right: 5px;
            padding-bottom: 3px;
        }
    </style>

    <style type="text/css">
        .headbg_boxtop_acc
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-bottom: 0px;
        }
        .head_text_acc
        {
            float: left;
            width: 740px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .main_container_row_acc
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 3px;
            padding-right: 5px;
            padding-bottom: 3px;
        }
        .titletext_acc
        {
            float: left;
            width: 110px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldcon_acc
        {
            float: left;
            width: 180px;
            margin-right: 85px;
            padding-top: 0px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldrightcon_acc
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
            font: bold 12px arial;
            color: #000;
        }
        .inputf_acc
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .input_area_fcr
        {
            width: 700px;
            margin-top: 5px;
            margin-bottom: 10px;
            margin-left: 10px;
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
    </style>

    <script language="javascript" type="text/javascript">

        function Validation() {

            ///Validate Medical Vendor Details 
            var txtVendorName = document.getElementById("<%= txtVendorName.ClientID %>");

            if (isBlank(txtVendorName, "Vendor name"))
            { return false; }

            var txtDateApplied = document.getElementById("<%= txtDateApplied.ClientID %>");

            if (isBlank(txtDateApplied, "Date"))
            { return false; }

            var ddlVendorType = document.getElementById("<%= ddlVendorType.ClientID %>");

            if ((checkDropDown(ddlVendorType, "Vendor Type") == false)) {
                return false;
            }

            var chkHospitalPartner = document.getElementById("<%=this.chkHospitalPartner.ClientID %>");
            var ddlTerritory = document.getElementById("<%=this.ddlTerritory.ClientID %>");
            if (chkHospitalPartner.checked == true) {
                var rbtnLHosPrtTerOption = document.getElementById("<%=this.rbtnLHosPrtTerOption.ClientID %>");
                count = 0;
                for (count = 0; count < rbtnLHosPrtTerOption.rows[0].childNodes.length; count++) {
                    if (rbtnLHosPrtTerOption.rows[0].childNodes[count].tagName == "TD")
                        break;
                }
                if (rbtnLHosPrtTerOption.rows[0].childNodes[count].childNodes[0].checked == true) {

                }
                else if (rbtnLHosPrtTerOption.rows[1].childNodes[count].childNodes[0].checked == true) {
                    if (ddlTerritory.options[ddlTerritory.selectedIndex].value == "0") {
                        alert("Please select the Territory.");
                        return false;
                    }
                }
            }

            var txtAddress1 = document.getElementById("<%= this.txtAddress1.ClientID %>");
            var txtAddress2 = document.getElementById("<%= this.txtAddress2.ClientID %>");
            if (isBlank(txtAddress1, "Business Address"))
            { return false; }

            var ddlState = document.getElementById("<%= this.ddlState.ClientID %>");
            var txtCity = document.getElementById("<%= this.txtCity.ClientID %>");

            if ((checkDropDown(ddlState, "State for Business Address") == false) ||
             (isBlank(txtCity, "City for Business Address")))
            { return false; }


            var txtZip = document.getElementById("<%= this.txtZip.ClientID %>");

            if (!isInteger(txtZip, "Business Zip")) {
                return false;
            }

            var chkBiAddress = document.getElementById("<%= this.chkBiAddress.ClientID %>");
            var txtBiAddress1 = document.getElementById("<%= this.txtBiAddress1.ClientID %>");
            var txtBiAddress2 = document.getElementById("<%= this.txtBiAddress2.ClientID %>");
            var ddlBiState = document.getElementById("<%= this.ddlBiState.ClientID %>");
            var txtBiCity = document.getElementById("<%= this.txtBiCity.ClientID %>");
            var txtBiZip = document.getElementById("<%= this.txtBiZip.ClientID %>");
            if (chkBiAddress.checked == true) // only then validations are applicable
            {
                if (isBlank(txtBiAddress1, "Billing Address"))
                { return false; }
                //  if (checkLength(txtBiAddress2,500,"Billing Address 1"))
                //  {return false;}
                if ((checkDropDown(ddlBiState, "State for Billing Address") == false) ||
                  (isBlank(txtBiCity, "City for Billing Address")))
                { return false; }
                if ((isInteger(txtBiZip, "Zip") != true))
                { return false; }
            }
            else {
                txtBiAddress1.value = txtAddress1.value;
                txtBiAddress2.value = txtAddress2.value;
                ddlBiState.selectedIndex = ddlState.selectedIndex;
                txtBiCity.value = txtCity.value;
                txtBiZip.value = txtZip.value;
            }

            //debugger
            ///Contact Person Details 
            var txtFirstName = document.getElementById("<%= this.txtFirstName.ClientID %>");
            var txtLastName = document.getElementById("<%= this.txtLastName.ClientID %>");

            if (isBlank(txtFirstName, "First Name") ||
             isBlank(txtLastName, "Last Name")
             )
            { return false; }

            var txtMiddleName = document.getElementById("<%= this.txtMiddleName.ClientID %>");

            var txtCDOB = document.getElementById("<%= this.txtCDOB.ClientID %>");

            if (isBlank(txtCDOB, "Date Of Birth"))
            { return false; }

            if (ValidateDate(txtCDOB.value, "Date Of Birth") == false)
            { return false; }

            if (checkDate(txtCDOB.value, "Date Of Birth") == false)
            { return false; }

            var txtCDOB = document.getElementById("<%= this.txtCDOB.ClientID %>");
            // DOB can not be null or blank
            if (isBlank(txtCDOB, "Date of Birth"))
            { return false; }

            /// Validate Address UserControl
            if (UCValidateAddress('contact ') == false)
            { return false; }

            var txtSplInstruction = document.getElementById("<%= this.txtSplInstruction.ClientID %>");
            var txtAccountHolder = document.getElementById("<%= this.txtAccountHolder.ClientID %>");
            var txtAccountNo = document.getElementById("<%= this.txtAccountNo.ClientID %>");
            var ddlAccountType = document.getElementById("<%= this.ddlAccountType.ClientID %>");
            var txtBankName = document.getElementById("<%= this.txtBankName.ClientID %>");
            var txtRoutingNumber = document.getElementById("<%= this.txtRoutingNumber.ClientID %>");
            var txtMemo = document.getElementById("<%= this.txtMemo.ClientID %>");
            var ddlPayMode = document.getElementById("<%= this.ddlPayMode.ClientID %>");
            var ddlInterval = document.getElementById("<%= this.ddlInterval.ClientID %>");


            if (checkDropDown(ddlPayMode, "Payment Mode") == false) { return false; }
            if (isBlank(txtBankName, "Bank Name")) { return false; }
            if (isBlank(txtAccountHolder, "Account Holder")) { return false; }
            if (checkDropDown(ddlAccountType, "Account Type") == false) { return false; }
            if (isBlank(txtAccountNo, "Account No")) { return false; }
            if (checkDropDown(ddlInterval, "Payment Interval") == false) { return false; }

            var ddlContracts = document.getElementById("<%= ddlContracts.ClientID %>");
            if (checkDropDown(ddlContracts, "Contract") == false) { return false; }

            if (Number('<%= MedicalVendorId %>') == 0) {
                if (isBlank($("#<%= txtUserName.ClientID %>")[0], "Login Id"))
                { return false; }
                if (isBlank($("#<%= txtPassword.ClientID %>")[0], "Password"))
                { return false; }
                if (isBlank($("#<%= txtConfirmPassword.ClientID %>")[0], "Confirm Password"))
                { return false; }


                if ($("#<%= txtConfirmPassword.ClientID %>").val() != $("#<%= txtPassword.ClientID %>").val()) {
                    alert('Password not confirmed. Please type in the same password.');
                    return false;
                }
            }
            
            if ($("#<%= PermittedTestCheckboxList.ClientID %> input[type=checkbox]:checked").length == 0) {
                alert("Please select atleast one test.");return false;
            }

            var txtCustPayRate = document.getElementById("<%= txtPayRateCustomer.ClientID %>");
            if (isBlank(txtCustPayRate, "Pay Rate for Customer Mode")) { return false; }            

            return true;
        }

        function txtkeypress(evt) {
            return KeyPress_DecimalAllowedOnly(evt);
        }

        function CheckBillingAddress() {
            var chkBiAddress = document.getElementById("<%= chkBiAddress.ClientID %>");
            var divBillingAddress = document.getElementById("<%= divBillingAddress.ClientID %>");
            var txtBiAddress1 = document.getElementById("<%= txtBiAddress1.ClientID %>");
            var txtBiAddress2 = document.getElementById("<%= txtBiAddress2.ClientID %>");
            var ddlBiState = document.getElementById("<%= ddlBiState.ClientID %>");
            var txtBiCity = document.getElementById("<%= txtBiCity.ClientID %>");
            var txtBiZip = document.getElementById("<%= txtBiZip.ClientID %>");

            divBillingAddress.disabled = !(chkBiAddress.checked);
            txtBiAddress1.disabled = !(chkBiAddress.checked);
            txtBiAddress2.disabled = !(chkBiAddress.checked);
            ddlBiState.disabled = !(chkBiAddress.checked);
            txtBiCity.disabled = !(chkBiAddress.checked);
            txtBiZip.disabled = !(chkBiAddress.checked);
        }


        function setdropdownvalue(ddlclientid, selectedid) {
            var ddlControl = document.getElementById(ddlclientid);
            var icount = 0;
            while (icount < ddlControl.options.length) {
                if (ddlControl.options[icount].value == selectedid) {
                    ddlControl.options[icount].selected = true;
                    break;
                }
                icount = icount + 1;
            }
        }


        function VendorTypeChanged() {
            var ddlVendorType = document.getElementById("<%= ddlVendorType.ClientID %>");

            if ((ddlVendorType.options[ddlVendorType.selectedIndex].value) == "<%= (int)MedicalVendorType.Hospital %>") {
                document.getElementById("divHospitalPrtnerHeading").style.display = "block";
            }
            else {
                document.getElementById("divHospitalPrtnerHeading").style.display = "none";
                var chkHospitalPartner = document.getElementById("<%=chkHospitalPartner.ClientID %>");
                chkHospitalPartner.checked = false;
                showHideHospitalPartnerDeatils();
            }
        }



        function oncontractstatechange(stateclientid, contractclientid, isedit) {

            var ddlstate = document.getElementById(stateclientid);
            var ddlcontract = document.getElementById(contractclientid);

            var contractname = '';
            var chksearch = '-' + ddlstate.options[ddlstate.selectedIndex].value;

            ddlcontract.innerHTML = '';
            if (arrjscontractstateids != null) {
                var arrlng = 0;
                while (arrlng < arrjscontractstateids.length) {
                    var res = arrjscontractstateids[arrlng].indexOf(chksearch);
                    if (res != '-1') {
                        var opt = document.createElement('option');

                        opt.text = arrjscontractnames[arrlng];
                        opt.value = arrjscontractids[arrlng];

                        ddlcontract.options.add(opt);
                    }
                    arrlng = arrlng + 1;
                }
            }

        }

        function showHideHospitalPartnerDeatils() {//debugger
            var ddlVendorType = document.getElementById("<%= ddlVendorType.ClientID %>");
            if (ddlVendorType.options[ddlVendorType.selectedIndex].text == "Hospital") {
                document.getElementById("divHospitalPrtnerHeading").style.display = "block";
            }
            else {
                document.getElementById("divHospitalPrtnerHeading").style.display = "none";
            }

            var divHospitalPartnerDetail = document.getElementById("divHospitalPartnerDetail");
            var chkHospitalPartner = document.getElementById("<%=chkHospitalPartner.ClientID %>");
            if (chkHospitalPartner.checked == true) {
                divHospitalPartnerDetail.style.display = "block";
            }
            else {
                divHospitalPartnerDetail.style.display = "none";
            }

            var rbtnLHosPrtTerOption = document.getElementById("<%=rbtnLHosPrtTerOption.ClientID %>");
            var ddlTerritory = document.getElementById("<%=ddlTerritory.ClientID %>");
            count = 0;
            for (count = 0; count < rbtnLHosPrtTerOption.rows[0].childNodes.length; count++) {
                if (rbtnLHosPrtTerOption.rows[0].childNodes[count].tagName == "TD")
                    break;
            }
            if (rbtnLHosPrtTerOption.rows[0].childNodes[count].childNodes[0].checked == true) {
                ddlTerritory.disabled = "disabled";
                ddlTerritory.selectedIndex = 0;
            }
            else if (rbtnLHosPrtTerOption.rows[1].childNodes[count].childNodes[0].checked == true) {
                ddlTerritory.disabled = "";
            }
        }
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="gridtitle" runat="server">Add Medical Vendor</span>
                </div>
            </div>
            <div id="divErrorMsg" class="maindivredmsgbox" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div class="headbg_boxtop_amv">
                    <div class="head_text_amv">
                        Medical Vendor Details</div>
                </div>
                <div class="main_content_area_amv">
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Vendor Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtVendorName" runat="server" TabIndex="1" CssClass="inputf_amv"
                                Width="170px"></asp:TextBox></span> <span class="titletext_amv">Date Applied:<span
                                    class="reqiredmark"><sup>*</sup> </span></span><span class="inputfieldrightcon_amv">
                                        <asp:TextBox ID="txtDateApplied" runat="server" TabIndex="2" CssClass="inputf_amv"
                                            Width="170px"></asp:TextBox></span> <span></span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Vendor Type:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_amv">
                            <asp:DropDownList ID="ddlVendorType" runat="server" TabIndex="3" CssClass="inputf_amv"
                                Width="175px" OnChange="VendorTypeChanged()">
                            </asp:DropDownList>
                        </span><span class="titletext_amv">Contract:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldrightcon_amv">
                            <asp:DropDownList ID="ddlContracts" runat="server" TabIndex="50" CssClass="inputf_amv"
                                Width="170px">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Description: </span>
                        <asp:TextBox ID="DescriptionTextbox" runat="server" TabIndex="6" CssClass="input_area_fcr"
                            TextMode="multiLine" Rows="4">
                        </asp:TextBox></p>
                    <div class="headbg_box_amv" id="divHospitalPrtnerHeading" style="display: none; height: 24px;">
                        <div class="head_text_amv" style="padding-top: 2px;">
                            <span style="float: left;">
                                <asp:CheckBox ID="chkHospitalPartner" runat="server" Text="Hospital Partner" />
                            </span>
                        </div>
                    </div>
                    <div id="divHospitalPartnerDetail" style="display: none;">
                        <div style="float: left; padding-left: 50px; padding-top: 10px;">
                            <div class="boxgrey_cnt">
                                <p class="boxgreyinner_cnt">
                                    <span class="titletextnowidth_default">Associated Phone Number:</span> <span class="inputfldnowidth_default"
                                        style="padding-top: 3px; margin-right: 100px">
                                        <asp:TextBox ID="txtAssociatedPhNo" runat="server" Width="120px" CssClass="mask-phone"></asp:TextBox>
                                    </span>
                                </p>
                            </div>
                        </div>
                        <p class="main_container_row_amv">
                            <span class="titletextnowidth_default">Territory</span>
                        </p>
                        <span class="main_container_row_amv">
                            <span class="ttxtnowidthnormal_default">
                                <asp:RadioButtonList ID="rbtnLHosPrtTerOption" runat="server">
                                    <asp:ListItem Text="Not restricted by territory" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Restricted to a specific territory" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </span>
                        </span>
                        <div style="float: left; padding-left: 50px; padding-top: 5px;">
                            <div class="boxgrey_cnt">
                                <p class="boxgreyinner_cnt">
                                    <span class="titletextnowidth_default">Select a Territory:</span> <span class="inputfldnowidth_default"
                                        style="padding-top: 3px; margin-right: 50px">
                                        <asp:DropDownList ID="ddlTerritory" runat="server" Width="250px">
                                        </asp:DropDownList>
                                    </span>
                                </p>
                            </div>
                        </div>
                        <div style="float: left; padding-left: 50px; padding-top: 5px;">
                            <div class="boxgrey_cnt">
                                <p class="boxgreyinner_cnt">
                                    <span class="titletextnowidth_default">Select Packages to Attach:</span> <span class="inputfldnowidth_default"
                                        style="padding-top: 3px; margin-right: 50px">
                                        <asp:CheckBoxList ID="packagesList" runat="server">
                                        </asp:CheckBoxList>
                                    </span>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="left_maincontainer_afse">
                        <div class="headbg_boxleft_afse">
                            <div class="head_textleftbox_afse">
                                Business Address</div>
                        </div>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">Address:<span class="reqiredmark"><sup>*</sup> </span>
                            </span><span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtAddress1" TabIndex="7" runat="server" Width="180px" CssClass="inputf_afse"
                                    TextMode="multiLine"></asp:TextBox>
                            </span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">Suite,Apt,etc:</span> <span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtAddress2" TabIndex="8" runat="server" Width="180px" CssClass="inputf_afse"></asp:TextBox>
                            </span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">City:<span class="reqiredmark"><sup>*</sup> </span>
                            </span><span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtCity" runat="server" TabIndex="9" Width="100" CssClass="inputf_afse auto-search-city"></asp:TextBox></span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">State:<span class="reqiredmark"></span><span class="reqiredmark"><sup>*</sup>
                            </span></span><span class="inputfieldleftcon_afse">
                                <asp:DropDownList ID="ddlState" TabIndex="10" runat="server" Width="120px" CssClass="inputf_accm"
                                    AutoPostBack="False">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                            <span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtZip" TabIndex="11" runat="server" Width="100" CssClass="inputf_afse"></asp:TextBox></span>
                        </p>
                    </div>
                    <div class="right_maincontainer_amv">
                        <div class="headbg_boxright_amv">
                            <div class="head_chkboxright_afse">
                                <input id="chkBiAddress" tabindex="14" type="checkbox" runat="server" onclick="CheckBillingAddress()" /></div>
                            <div class="head_textrightbox_afse">
                                Billing Address</div>
                            <div class="divmessagetext_afse">
                                (if the billing address is different than business address)</div>
                        </div>
                        <div id="divBillingAddress" runat="server">
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">Address:<span class="reqiredmark"><sup>*</sup> </span>
                                </span><span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiAddress1" TabIndex="15" runat="server" Width="180px" CssClass="inputf_afse"
                                        TextMode="multiLine" Enabled="False"></asp:TextBox></span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">Suite,Apt,etc:</span> <span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiAddress2" TabIndex="16" runat="server" Width="180px" CssClass="inputf_afse"
                                        Enabled="False"></asp:TextBox></span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">City:<span class="reqiredmark"><sup>*</sup> </span>
                                </span><span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiCity" runat="server" TabIndex="17" Width="100" CssClass="inputf_afse auto-search-city"></asp:TextBox></span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">State:<span class="reqiredmark"><sup>*</sup></span></span><span
                                    class="inputfieldleftcon_afse"><asp:DropDownList ID="ddlBiState" TabIndex="18" runat="server"
                                        AutoPostBack="False" Width="120px" CssClass="inputf_accm" Enabled="False">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                                <span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiZip" TabIndex="19" runat="server" Width="100" CssClass="inputf_afse"
                                        Enabled="False"></asp:TextBox></span>
                            </p>
                        </div>
                    </div>
                    <%-- Make the completion list transparent and then show it --%>
                    <div class="main_container_row_amv">
                        <span class="titletext_amv">Business Phone: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtBusinessPhone" TabIndex="12" runat="server" MaxLength="120" CssClass="inputf_afse mask-phone"></asp:TextBox></span>
                        <span class="titletext_amv">Business Fax: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtBusinessFax" TabIndex="13" runat="server" MaxLength="120" CssClass="inputf_afse mask-phone"></asp:TextBox></span>
                    </div>
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Contact Details</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">First Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtFirstName" runat="server" TabIndex="20" CssClass="inputf_amv"
                                Width="170px"></asp:TextBox></span> <span class="titletext_amv">Middle Name:
                        </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtMiddleName" runat="server" TabIndex="21" CssClass="inputf_amv"
                                Width="170px"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Last Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtLastName" runat="server" TabIndex="22" CssClass="inputf_amv"
                                Width="170px"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Date of Birth: <span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfielddatecon_amv">
                            <asp:TextBox ID="txtCDOB" runat="server" TabIndex="23" CssClass="inputf_amv date-picker-dob"
                                Width="150px"></asp:TextBox>
                            <span style="font-size: 7pt;">(mm/dd/yyyy)</span> </span><span class="titletext_amv">
                                SSNo:</span> <span class="inputfieldrightcon_amv">
                                    <asp:TextBox ID="txtCSno" runat="server" TabIndex="25" CssClass="inputf_amv" Width="170px"></asp:TextBox>
                                </span>
                    </p>
                    <uc1:UCAddress ID="UCAddress1" runat="server" TabIndex="23" />
                    <% if (MedicalVendorId == 0) %>
                    <% { %>
                    <div class="headbg_boxtop_acc">
                        <div class="head_text_acc">
                            Login Details<span class="reqiredmark"><sup>*</sup> </span>
                        </div>
                    </div>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">User Name: </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="inputf_acc"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Password: </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="inputf_acc"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Confirm Password: </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="inputf_acc"></asp:TextBox>
                        </span>
                    </p>
                    <% } %>
                    <%-- Expand from 0px to the appropriate size while fading in --%>
                    <div id="" class="maindivwiringdetails_amv">
                        <div class="headbg_box_amv">
                            <div class="head_text_amv">
                                Wiring Details</div>
                        </div>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Payment Mode:<span class="reqiredmark"><sup>*</sup></span>
                            </span><span class="inputfieldcon_amv">
                                <asp:DropDownList runat="server" TabIndex="41" ID="ddlPayMode" CssClass="inputf_accm"
                                    Width="175px">
                                </asp:DropDownList>
                            </span><span class="titletext_amv">Payment Interval:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldrightcon_amv">
                                <asp:DropDownList runat="server" ID="ddlInterval" TabIndex="42" CssClass="inputf_accm"
                                    Width="130px">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Bank Name:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtBankName" runat="server" TabIndex="43" CssClass="inputf_amv"
                                    Width="150px" MaxLength="50"></asp:TextBox>
                            </span><span class="titletext_amv">Account Holder:<span class="reqiredmark"><sup>*</sup></span>
                            </span><span class="inputfieldrightcon_amv">
                                <asp:TextBox ID="txtAccountHolder" runat="server" TabIndex="44" CssClass="inputf_amv"
                                    Width="150px" MaxLength="50"></asp:TextBox></span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Account No:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtAccountNo" runat="server" TabIndex="45" CssClass="inputf_amv"
                                    Width="150px" MaxLength="50"></asp:TextBox>
                            </span><span class="titletext_amv">Account Type:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldrightcon_wi">
                                <asp:DropDownList ID="ddlAccountType" runat="server" TabIndex="46" CssClass="inputf_accm"
                                    Width="155px">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Routing number: </span><span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtRoutingNumber" runat="server" TabIndex="47" CssClass="inputf_amv"
                                    Width="150px" MaxLength="50"></asp:TextBox></span> <span class="titletext_amv">Memo:
                                    </span><span class="inputfieldrightcon_amv">
                                        <asp:TextBox ID="txtMemo" runat="server" TabIndex="48" CssClass="inputf_amv" Width="170px"
                                            TextMode="multiLine"></asp:TextBox></span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Special Instructions: </span><span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtSplInstruction" runat="server" TabIndex="49" CssClass="inputf_amv"
                                    Width="170px" TextMode="multiLine"></asp:TextBox></span>
                        </p>
                    </div>
                    <div class="headbg_boxprates_amv">
                        <div class="head_text_amv">
                            Permitted Test<span class="reqiredmark"><sup>*</sup></span></div>
                    </div>
                    <div class="divgrid_amv">
                        <asp:CheckBoxList runat="server" ID="PermittedTestCheckboxList" RepeatColumns="2"
                            RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </div>
                </div>
                <div id="dvEvalBlock" style="float: left;">
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Evaluation Details and Pay Rates<span class="reqiredmark"><sup>*</sup></span></div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Evaluation By:</span> <span class="inputfieldareacon_amv">
                            <asp:DropDownList ID="ddlEvaluation" runat="server" TabIndex="52" CssClass="inputf_amv"
                                Width="175px">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <div id="divCustomer" class="main_container_row_amv">
                        <span class="titletext_amv">Pay Rate:</span> <span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtPayRateCustomer" runat="server" Width="170px" CssClass="inputf_amv"></asp:TextBox>
                        </span>
                    </div>
                </div>
            </div>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtnsave" runat="server" CssClass="" TabIndex="55" ImageUrl="~/App/Images/save-button.gif"
                        OnClientClick='return Validation();' OnClick="ibtnsave_Click" /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtncancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="ibtncancel_Click" /></div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            $('.auto-search-city').autoComplete({
                minchar: 3,
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByPrefixText")%>',
                type: "POST",
                data: "prefixText"
            });

            $('.mask-phone').mask("(999)-999-9999");
        });
    
    </script>
    <asp:HiddenField ID="hfSpecification" runat="server" Value="1" />
</asp:Content>

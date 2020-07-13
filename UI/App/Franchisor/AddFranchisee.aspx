<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="Franchisor_AddFranchisee" Title="Add Franchisee"
    CodeBehind="AddFranchisee.aspx.cs" %>

<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="../UCCommon/UCAddress.ascx" TagName="UCAddress" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <style type="text/css">
        .mainbody_outer_afse
        {
            float: right;
            width: 777px;
            background-color: #fff;
            margin-top: 5px;
        }
        .mainbody_inner_afse
        {
            width: 763px;
            margin-left: 14px;
            margin-bottom: 5px;
        }
        .main_area_bdr_afse
        {
            float: left;
            width: 751px;
            border: 1px solid #E5E5E5;
            padding-bottom: 10px;
            margin-top: 5px;
        }
        .main_content_area_afse
        {
            float: left;
            width: 753px;
        }
        .inputfieldob_amv
        {
            float: left;
            width: 100px;
        }
        .inputf_afse
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .headbg_boxtop_afse
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-bottom: 0px;
        }
        .headbg_box_afse
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 5px;
            margin-bottom: 3px;
        }
        .headbg_boxreff_afse
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 5px;
        }
        .head_text_afse
        {
            float: left;
            width: 740px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 0px;
            font: bold 12px arial;
            color: #000000;
        }
        .inputf_anp
        {
            float: left;
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 1px;
        }
        .inputtbig_afse
        {
            float: left;
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
            height: 50px;
            width: 600px;
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
        .divmessagetext_afse
        {
            float: left;
            width: 285px;
            padding-left: 4px;
            padding-top: 6px;
            font: normal 11px Arial;
            color: #FF0000;
        }
        .headbg_boxright_afse
        {
            float: left;
            width: 400px;
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
        .dividerh_afse
        {
            float: left;
            width: 753px;
            border-bottom: 1px dotted #E5E5E5;
            height: 2px;
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
        .main_containerreff_row_afse
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-right: 5px;
        }
        .main_containerreff2_row_afse
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-right: 5px;
            padding-bottom: 5px;
        }
        .left_maincontainer_afse
        {
            float: left;
            width: 350px;
            margin-right: 2px;
        }
        .right_maincontainer_afse
        {
            float: left;
            width: 400px;
        }
        .left_container_rows_afse
        {
            float: left;
            width: 325px;
            padding-left: 10px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
        .right_container_rows_afse
        {
            float: left;
            width: 325px;
            padding-left: 37px;
            padding-top: 3px;
            padding-bottom: 3px;
        }
        .inputfieldleftcon_afse
        {
            float: left;
            width: 180px;
            padding-top: 0px;
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
        .inputfieldcon_afse
        {
            float: left;
            width: 180px;
            margin-right: 85px;
            font: bold 12px arial;
            color: #000;
        }
        .titlenamereff_afse
        {
            float: left;
            width: 180px;
            padding-top: 5px;
            margin-right: 85px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldareacon_afse
        {
            float: left;
            width: 600px;
            padding-top: 0px;
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
        .inputf_amv
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .calendarcntrl_amv
        {
            float: left;
            width: 20px;
            padding-left: 10px;
            padding-top: 5px;
        }
    </style>
    <script language="javascript" type="text/javascript">


        // If Billing address is different from Business address then enabled the Div
        function CheckBillingAddress() { //debugger

            var chkBiAddress = document.getElementById("<%= this.chkBiAddress.ClientID %>");
            var divBillingAddress = document.getElementById("<%= this.divBillingAddress.ClientID %>");
            var txtBiAddress1 = document.getElementById("<%= this.txtBiAddress1.ClientID %>");
            var txtBiAddress2 = document.getElementById("<%= this.txtBiAddress2.ClientID %>");
            var ddlBiState = document.getElementById("<%= this.ddlBiState.ClientID %>");
            var txtBiCity = document.getElementById("<%= this.txtBiCity.ClientID %>");
            var txtBiZip = document.getElementById("<%= this.txtBiZip.ClientID %>");

            divBillingAddress.disabled = !(chkBiAddress.checked);
            txtBiAddress1.disabled = !(chkBiAddress.checked);
            txtBiAddress2.disabled = !(chkBiAddress.checked);
            ddlBiState.disabled = !(chkBiAddress.checked);
            txtBiCity.disabled = !(chkBiAddress.checked);
            txtBiZip.disabled = !(chkBiAddress.checked);
        }

        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }

        function Validation() { ////debugger

            ///Validate Franchisee Details 
            var txtFranchiseeName = document.getElementById("<%= this.txtFranchiseeName.ClientID %>");
            // Name can not be null or blank
            if (isBlank(txtFranchiseeName, "Business name"))
            { return false; }

            var txtDesciption = document.getElementById("<%= this.txtDesciption.ClientID %>");

            if (checkLength(txtDesciption, 1000, "Franchisee Description"))
            { return false; }            

            var txtbuaddress1 = document.getElementById("<%= this.txtbuaddress1.ClientID %>");
            var txtbuaddress2 = document.getElementById("<%= this.txtbuaddress2.ClientID %>");
            if (isBlank(txtbuaddress1, "Business Address"))
            { return false; }            

            var ddlBuState = document.getElementById("<%= this.ddlBuState.ClientID %>");
            var txtBuCity = document.getElementById("<%= this.txtBuCity.ClientID %>");

            if ((checkDropDown(ddlBuState, "state for Business Address") == false) ||
             (isBlank(txtBuCity, "City for Business Address")))
            { return false; }


            var txtBuZip = document.getElementById("<%= this.txtBuZip.ClientID %>");
            var txtBuPhone = document.getElementById("<%= this.txtBuPhone.ClientID %>");
            if (isBlank(txtBuPhone, "Business Phone"))
            { return false; }
            var txtBuFax = document.getElementById("<%= this.txtBuFax.ClientID %>");
            if ((isInteger(txtBuZip, "Zip") != true))
            { return false; }
            ///Billing Address

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
                // if (checkLength(txtBiAddress2,500,"Billing Address 1"))
                //  {return false;}
                if ((checkDropDown(ddlBiState, "state for Billing Address") == false) ||
                  (isBlank(txtBiCity, "City for Billing Address")))
                { return false; }
                if ((isInteger(txtBiZip, "Zip") != true))
                { return false; }
            }
            else {
                txtBiAddress1.value = txtbuaddress1.value;
                txtBiAddress2.value = txtbuaddress2.value;
                ddlBiState.selectedIndex = ddlBuState.selectedIndex;
                txtBiCity.value = txtBiCity.value;
                txtBiZip.value = txtBuZip.value;
            }

            ///Contact Person Details 
            var txtFName = document.getElementById("<%= this.txtFName.ClientID %>");
            var txtLName = document.getElementById("<%= this.txtLName.ClientID %>");

            if (isBlank(txtFName, "First Name") ||
                 isBlank(txtLName, "Last Name"))
            { return false; }

            var txtDOB = document.getElementById("<%= this.txtDOB.ClientID %>");

            if (isBlank(txtDOB, "Date of Birth"))
            { return false; }

            if (ValidateDate(txtDOB.value, "Date Of Birth") == false)
            { return false; }

            if (checkDate(txtDOB.value, "Date Of Birth") == false)
            { return false; }

            var txtMName = document.getElementById("<%= this.txtMName.ClientID %>");

            if (Number('<%= FranchiseeId %>') == 0) {
                if (isBlank($("#<%= LoginIdTextbox.ClientID %>")[0], "Login Id"))
                { return false; }
                if (isBlank($("#<%= PasswordTextbox.ClientID %>")[0], "Password"))
                { return false; }
                if (isBlank($("#<%= ConfirmPasswordTextbox.ClientID %>")[0], "Confirm Password"))
                { return false; }


                if ($("#<%= ConfirmPasswordTextbox.ClientID %>").val() != $("#<%= PasswordTextbox.ClientID %>").val()) {
                    alert('Password not confirmed. Please type in the same password.');
                    return false;
                } 
            }
           
            return UCValidateAddress('contact');

        }
    </script>
    <div class="mainbody_outer_afse">
        <div class="mainbody_inner_afse">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sppoptitle" runat="server">Add Franchisee</span>
                    <span class="headingright_default"></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr_afse">
                <div class="main_content_area_afse">
                    <div class="headbg_boxtop_afse">
                        <div class="head_text_afse">
                            Franchisee Details
                        </div>
                    </div>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">Business Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_afse">
                            <asp:TextBox ID="txtFranchiseeName" runat="server" CssClass="inputf_anp" Width="170px"
                                TabIndex="1" MaxLength="500"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">Description: </span><span class="inputfieldareacon_afse">
                            <asp:TextBox ID="txtDesciption" runat="server" CssClass="inputtbig_afse" TextMode="multiLine"
                                TabIndex="2" MaxLength="1000"></asp:TextBox></span>
                    </p>                    
                    <div class="left_maincontainer_afse">
                        <div class="headbg_boxleft_afse">
                            <div class="head_textleftbox_afse">
                                Business Address</div>
                        </div>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">Address:<span class="reqiredmark"><sup>*</sup> </span>
                            </span><span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtbuaddress1" TabIndex="5" runat="server" Width="180px" CssClass="inputf_afse"
                                    TextMode="multiLine"></asp:TextBox>
                            </span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">Suite,Apt,etc:</span> <span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtbuaddress2" TabIndex="6" runat="server" Width="180px" CssClass="inputf_afse"></asp:TextBox>
                            </span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">City:<span class="reqiredmark"><sup>*</sup> </span>
                            </span><span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtBuCity" TabIndex="7" runat="server" Width="100" CssClass="inputf_afse auto-search-bu-city"></asp:TextBox></span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">State:<span class="reqiredmark"></span><span class="reqiredmark"><sup>*</sup>
                            </span></span><span class="inputfieldleftcon_afse">
                                <asp:DropDownList ID="ddlBuState" TabIndex="8" runat="server" Width="120px" CssClass="inputf_accm"
                                    AutoPostBack="False">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="left_container_rows_afse">
                            <span class="titletext_afse">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                            <span class="inputfieldleftcon_afse">
                                <asp:TextBox ID="txtBuZip" TabIndex="9" runat="server" Width="100" CssClass="inputf_afse"></asp:TextBox></span>
                        </p>
                    </div>
                    <div class="right_maincontainer_afse">
                        <div class="headbg_boxright_afse">
                            <div class="head_chkboxright_afse">
                                <input id="chkBiAddress" tabindex="10" onclick="CheckBillingAddress();" type="checkbox"
                                    runat="server" /></div>
                            <div class="head_textrightbox_afse">
                                Billing Address</div>
                            <div class="divmessagetext_afse">
                                (if the billing address is different than business address)</div>
                        </div>
                        <div id="divBillingAddress" runat="server">
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">Address:<span class="reqiredmark"><sup>*</sup> </span>
                                </span><span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiAddress1" TabIndex="11" runat="server" Width="180px" CssClass="inputf_afse"
                                        TextMode="multiLine" Enabled="False"></asp:TextBox></span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">Suite,Apt,etc:</span> <span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiAddress2" TabIndex="12" runat="server" Width="180px" CssClass="inputf_afse"
                                        Enabled="False"></asp:TextBox></span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">City:<span class="reqiredmark"><sup>*</sup> </span>
                                </span><span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiCity" TabIndex="13" runat="server" Width="100" CssClass="inputf_afse auto-search-bi-city"></asp:TextBox></span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">State:<span class="reqiredmark"><sup>*</sup></span></span><span
                                    class="inputfieldleftcon_afse"><asp:DropDownList ID="ddlBiState" TabIndex="14" runat="server"
                                        Width="120px" CssClass="inputf_accm" AutoPostBack="False" Enabled="False">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="right_container_rows_afse">
                                <span class="titletext_afse">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                                <span class="inputfieldleftcon_afse">
                                    <asp:TextBox ID="txtBiZip" TabIndex="15" runat="server" Width="100" CssClass="inputf_afse"
                                        Enabled="False"></asp:TextBox></span>
                            </p>
                        </div>
                    </div>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">Business Phone:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_afse">
                            <asp:TextBox ID="txtBuPhone" TabIndex="16" runat="server" MaxLength="100" CssClass="inputf_afse mask-phone"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">Business Fax: </span><span class="inputfieldrightcon_afse">
                            <asp:TextBox ID="txtBuFax" TabIndex="17" runat="server" MaxLength="100" CssClass="inputf_afse mask-phone"></asp:TextBox></span>
                    </p>
                    <div class="headbg_box_afse">
                        <div class="head_text_afse">
                            Contact Person Details
                        </div>
                    </div>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">First Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_afse">
                            <asp:TextBox ID="txtFName" TabIndex="18" runat="server" Width="150px" CssClass="inputf_afse"></asp:TextBox></span>
                        <span class="titletext_afse">Middle Name: </span><span class="inputfieldrightcon_afse">
                            <asp:TextBox ID="txtMName" TabIndex="19" runat="server" Width="150px" CssClass="inputf_afse"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">Last Name: <span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_afse">
                            <asp:TextBox ID="txtLName" TabIndex="20" runat="server" Width="150px" CssClass="inputf_afse"></asp:TextBox></span>
                        <span class="titletext_afse">Date of Birth:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldob_amv">
                            <asp:TextBox ID="txtDOB" runat="server" TabIndex="21" CssClass="inputf_amv date-picker-dob"
                                Width="100px"></asp:TextBox>
                            <span style="font-size: 7pt;">mm/dd/yyyy</span> </span>
                    </p>
                    <uc1:UCAddress ID="UCAddress1" runat="server" TabIndex="23" />                    
                    <% if (FranchiseeId == 0) %>
                    <% { %>
                    <div class="headbg_box_afse">
                        <div class="head_text_afse">
                            Login Details
                        </div>
                    </div>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">Login Id:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_afse">
                            <asp:TextBox ID="LoginIdTextbox" runat="server" Width="150px" CssClass="inputf_afse"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_afse">
                        <span class="titletext_afse">Password:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_afse">
                            <asp:TextBox ID="PasswordTextbox" runat="server" Width="150px" TextMode="Password" autocomplete="off"
                                CssClass="inputf_afse"></asp:TextBox></span> <span class="titletext_afse">Confirm Password:<span
                                    class="reqiredmark"><sup>*</sup> </span></span><span class="inputfieldrightcon_afse">
                                        <asp:TextBox ID="ConfirmPasswordTextbox" runat="server" TextMode="Password" Width="150px" autocomplete="off"
                                            CssClass="inputf_afse"></asp:TextBox></span>
                    </p>
                    <% } %>
                    <div class="headbg_box_afse">
                        <div class="head_text_afse">
                            Other Details
                        </div>
                    </div>                    
                    <div class="main_container_row_afse">
                        <div class="titletext_afse">
                            Pod:
                        </div>
                        <div class="inputfieldcon_afse">
                            <div>
                                <input type="checkbox" id="selectAllCheckbox" onclick="CheckUncheckAll(this);" />
                                <b>Select All </b>
                            </div>
                            <div>
                                <asp:CheckBoxList runat="server" ID="PodCheckboxList" RepeatDirection="Horizontal"
                                    RepeatColumns="3">
                                </asp:CheckBoxList>
                            </div>
                            <script language="javascript" type="text/javascript">

                                function CheckUncheckAll(masterCheckbox) {
                                    if ($(masterCheckbox).attr("checked")) {
                                        $("#<%= PodCheckboxList.ClientID %> input[type=checkbox]").attr("checked", true);
                                    }
                                    else {
                                        $("#<%= PodCheckboxList.ClientID %> input[type=checkbox]").attr("checked", false);
                                    }
                                }

                                function CheckAllselected() {
                                    var allSelected = true;
                                    $("#<%= PodCheckboxList.ClientID %> input[type=checkbox]").each(function () {
                                        if (!$(this).attr("checked")) { allSelected = false; return false; }
                                    });

                                    if (!allSelected) $("#selectAllCheckbox").attr("checked", false);
                                    else $("#selectAllCheckbox").attr("checked", true);
                                }

                                $(window).ready(function () {
                                    $("#<%= PodCheckboxList.ClientID %> input[type=checkbox]").click(function () {
                                        CheckAllselected();
                                    });

                                    CheckAllselected();
                                });
                                
                            </script>
                        </div>
                    </div>
                    <div class="main_container_row_afse" id="errormsg" runat="server">
                    </div>
                </div>
            </div>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="Save" runat="server" CssClass="" ImageUrl="~/App/Images/save-button.gif"
                        OnClientClick='return Validation()' OnClick="Save_Click" TabIndex="42" /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="Cancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="Cancel_Click" TabIndex="43" /></div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            $('.auto-search-bi-city').autoComplete({
                minchar: 3,
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByPrefixText")%>',
                type: "POST",
                data: "prefixText"
            });

            $('.auto-search-bu-city').autoComplete({
                minchar: 3,
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByPrefixText")%>',
                type: "POST",
                data: "prefixText"
            });
            $('.mask-phone').mask('(999)-999-9999');

        });
    
    </script>
</asp:Content>

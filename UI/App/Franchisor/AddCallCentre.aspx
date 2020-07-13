<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    EnableEventValidation="false" AutoEventWireup="true" Inherits="CallCenter_AddCallCentre"
    Title="Untitled Page" CodeBehind="AddCallCentre.aspx.cs" %>

<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
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

        function validatecontrols() {
            if (isBlank(document.getElementById('<%= this.txtbname.ClientID %>'), 'Business Name'))
                return false;

            if (isBlank(document.getElementById('<%= this.txtaddress1.ClientID %>'), 'Business Address'))
                return false;

            if (!checkDropDown(document.getElementById('<%= this.ddlstate1.ClientID %>'), 'Business Address State'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtBuCity.ClientID %>'), 'Business Address City'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtzip1.ClientID %>'), 'Business Address Zip Code'))
                return false;

            if (isBlank(document.getElementById('<%= this.txtfname.ClientID %>'), 'First Name'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtlname.ClientID %>'), 'Last Name'))
                return false;

            var txtDOB = document.getElementById("<%= this.txtDOB.ClientID %>");
            if (isBlank(txtDOB, 'Date Of Birth'))
                return false;
            if (ValidateDate(txtDOB.value, "Date Of Birth") == false)
            { return false; }

            if (checkDate(txtDOB.value, "Date Of Birth") == false)
            { return false; }

            if (isBlank(document.getElementById('<%= this.txtcntaddress1.ClientID %>'), 'Contact Address'))
                return false;

            if (!checkDropDown(document.getElementById('<%= this.ddlstate2.ClientID %>'), 'State'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtCCity.ClientID %>'), 'City'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtzip2.ClientID %>'), 'Zip Code'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtEmail1.ClientID %>'), 'Email'))
                return false;
            if (validateEmail(document.getElementById('<%= this.txtEmail1.ClientID %>'), "Email") != true)
                return false;

            if (Number('<%= CallCenterId %>') == 0) {
                if (isBlank(document.getElementById('<%= this.txtUserName.ClientID %>'), 'User Name'))
                    return false;

                if (isBlank(document.getElementById('<%= this.txtPassword.ClientID %>'), 'Password'))
                    return false;

                if (isBlank(document.getElementById('<%= this.txtConfirmPassword.ClientID %>'), 'Confirm Password'))
                    return false;

                if ((document.getElementById('<%= this.txtConfirmPassword.ClientID %>').value) != (document.getElementById('<%= this.txtPassword.ClientID %>').value)) {
                    alert("Password and Confirm Password should be same!");
                    return false;
                }
            }

            return true;
        }


        function settextbox(txtclientid, disabledtext) {
            var txtbox = document.getElementById(txtclientid);
            if (disabledtext != '')
                txtbox.disabled = 'disabled';
            else
                txtbox.disabled = '';

        }

        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }

    </script>
    <div class="mainbody_outer_fcr">
        <div class="mainbody_inner_fcr">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" runat="server" id="sptitle">Add/Edit Call Center</span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr_Editdata_fcr">
                <div class="main_content_area_fcr">
                    <div class="headbg_boxtop_acc">
                        <div class="head_text_acc">
                            About Call Center</div>
                    </div>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Business Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" ID="txtbname" Width="170px" CssClass="inputf_acc"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Business Phone: </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" Width="130px" ID="txtbphone" CssClass="inputf_acc mask-phone"></asp:TextBox></span>
                        <span class="titletext_acc">Business Fax: </span><span class="inputfieldrightcon_acc">
                            <asp:TextBox runat="server" Width="130px" ID="txtbfax" CssClass="inputf_acc mask-phone"></asp:TextBox></span>
                    </p>
                    <div class="about_txt_area">
                        <asp:TextBox runat="server" ID="txtabtmself" CssClass="input_area_fcr" TextMode="multiLine"
                            Rows="4">
                        </asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtabtmself"
                            WatermarkCssClass="" WatermarkText="Please write some description here" runat="server">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                    <div class="headbg_boxtop_acc">
                        <div class="head_text_acc">
                            Business Address &nbsp;Details</div>
                    </div>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Address:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" Width="170px" ID="txtaddress1" CssClass="inputf_acc"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">City:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_acc">
                            <asp:TextBox ID="txtBuCity" runat="server" Width="100" CssClass="inputf_acc auto-search-bu-city"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">State:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_acc">
                            <asp:DropDownList ID="ddlstate1" runat="server" CssClass="inputf_acc" Width="130px"
                                AutoPostBack="False">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" Width="100px" ID="txtzip1" CssClass="inputf_acc" MaxLength="8"></asp:TextBox></span>
                    </p>
                    <div class="headbg_boxtop_acc">
                        <div class="head_text_acc">
                            Contact Person</div>
                    </div>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">First Name:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" Width="170px" ID="txtfname" CssClass="inputf_acc"></asp:TextBox></span>
                        <span class="titletext_acc">Middle Name: </span><span class="inputfieldrightcon_acc">
                            <asp:TextBox runat="server" Width="170px" ID="txtmname" CssClass="inputf_acc"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Last Name:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" ID="txtlname" Width="170px" CssClass="inputf_acc"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Date of Birth:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" ID="txtDOB" CssClass="inputf_acc date-picker-dob" Width="144px"></asp:TextBox>
                            <span style="font-size: 7pt;">(mm/dd/yyyy)</span> </span><span class="titletext_acc">
                                SSN: </span><span class="inputfieldrightcon_acc">
                                    <asp:TextBox runat="server" ID="txtSSN" Width="120px" CssClass="inputf_acc"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Address:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_acc">
                            <asp:TextBox runat="server" Width="170px" ID="txtcntaddress1" CssClass="inputf_acc"></asp:TextBox></span>
                        <span class="titletext_acc">Phone (Cell):</span> <span class="inputfieldrightcon_acc">
                            <asp:TextBox runat="server" ID="txtphonecell" CssClass="inputf_acc mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">City:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_acc">
                            <asp:TextBox ID="txtCCity" runat="server" CssClass="inputf_acc auto-search-bi-city"
                                Width="100"></asp:TextBox></span> <span class="titletext_acc">Phone (Home):
                        </span><span class="inputfieldrightcon_acc">
                            <asp:TextBox runat="server" ID="txtphonehome" CssClass="inputf_acc  mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">State:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_acc">
                            <asp:DropDownList ID="ddlstate2" runat="server" CssClass="inputf_acc" Width="130px"
                                AutoPostBack="False">
                            </asp:DropDownList>
                        </span><span class="titletext_acc">Phone (Other): </span><span class="inputfieldrightcon_acc">
                            <asp:TextBox runat="server" ID="txtphoneother" CssClass="inputf_acc mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_acc">
                            <asp:TextBox ID="txtzip2" runat="server" CssClass="inputf_acc" Width="100px" MaxLength="8"></asp:TextBox></span><span
                                class="titletext_acc">Other Email:</span> <span class="inputfieldrightcon_acc">
                                    <asp:TextBox ID="txtEmail2" runat="server" CssClass="inputf_acc"></asp:TextBox>
                                </span>
                    </p>
                    <p class="main_container_row_acc">
                        <span class="titletext_acc">Email:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_acc">
                            <asp:TextBox ID="txtEmail1" runat="server" CssClass="inputf_acc"></asp:TextBox>
                        </span>
                    </p>
                    <% if (CallCenterId == 0) %>
                    <%
                       {%>
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
                        <span class="titletext_acc">Password: </span><span class="inputfieldrightcon_acc">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="inputf_acc" autocomplete="off"></asp:TextBox>
                        </span><span class="titletext_acc">Confirm Password: </span><span class="inputfieldrightcon_acc">
                            <asp:TextBox runat="server" ID="txtConfirmPassword" autocomplete="off" TextMode="Password" CssClass="inputf_acc"></asp:TextBox>
                        </span>
                    </p>
                    <%
                       }%>
                </div>
            </div>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibtnsave" ImageUrl="~/App/Images/save-button.gif"
                        OnClick="ibtnsave_Click" OnClientClick='return validatecontrols();' /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibtncancel" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="ibtncancel_Click" /></div>
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

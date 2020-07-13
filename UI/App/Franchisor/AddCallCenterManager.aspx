<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="CallCenter_AddCallCenterManager" Title="Untitled Page"
    CodeBehind="AddCallCenterManager.aspx.cs" %>

<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <style type="text/css">
        .mainbody_outer_accm
        {
            float: right;
            width: 777px;
            background-color: #fff;
            margin-top: 5px;
        }
        .mainbody_inner_accm
        {
            width: 763px;
            margin-left: 14px;
            margin-bottom: 5px;
        }
        .main_area_bdr_accm
        {
            float: left;
            width: 751px;
            border: 1px solid #E5E5E5;
            padding-bottom: 10px;
            margin-top: 5px;
        }
        .main_content_area_accm
        {
            float: left;
            width: 745px;
        }
        .inputf_accm
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .selecttype_accm
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            height: 18px;
        }
        .headbg_box_accm
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 5px;
            margin-bottom: 3px;
        }
        .head_text_accm
        {
            float: left;
            width: 740px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .headbg2_box_accm
        {
            float: left;
            width: 753px;
            padding-top: 5px;
            padding-bottom: 10px;
        }
        .save_button_accm
        {
            float: left;
            width: 56px;
            height: 32px;
            margin-bottom: 10px;
            padding-left: 630px;
        }
        .cancel_button_accm
        {
            float: left;
            width: 56px;
            height: 32px;
            padding-left: 5px;
            margin-bottom: 10px;
        }
        .singlerow_ref_accm
        {
            float: left;
            width: 745px;
        }
        .inputboxleftb_accm
        {
            float: left;
            width: 560px;
            margin-top: 5px;
        }
        .inputtbig_accm
        {
            float: left;
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
            height: 50px;
            width: 620px;
        }
        .inputbox_calndr_accm
        {
            float: left;
            width: 105px;
            margin-top: 4px;
            margin-right: 5px;
        }
        .calendarcntrl_accm
        {
            float: left;
            width: 20px;
            padding-left: 5px;
            padding-top: 5px;
        }
        .main_container_row_accm
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 3px;
            padding-right: 5px;
            padding-bottom: 3px;
        }
        .titletext_accm
        {
            float: left;
            width: 110px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldcon_accm
        {
            float: left;
            width: 180px;
            margin-right: 85px;
            padding-top: 0px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldareacon_accm
        {
            float: left;
            width: 600px;
            padding-top: 0px;
        }
        .inputfieldrightcon_accm
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldob_accm
        {
            float: left;
            width: 100px;
        }
        .textlnk_accm
        {
            float: left;
            width: 85px;
            font: normal 12px arial;
            color: #000;
            padding-top: 3px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function checkvalidations() {
            //debugger
            if (!checkDropDown(document.getElementById('<%= this.ddlcallcenter.ClientID %>'), 'Call Center'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtfname.ClientID %>'), 'First Name'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtlname.ClientID %>'), 'Last Name'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtdob.ClientID %>'), 'Date of Birth'))
                return false;
            var txtdob = document.getElementById("<%= this.txtdob.ClientID %>");
            if (ValidateDate(txtdob.value, "Date Of Birth") == false)
            { return false; }

            if (checkDate(txtdob.value, "Date Of Birth") == false)
            { return false; }

            if (isBlank(document.getElementById('<%= this.txtaddress1.ClientID %>'), 'Address1'))
                return false;

            if (!checkDropDown(document.getElementById('<%= this.ddlstate.ClientID %>'), 'State'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtCity.ClientID %>'), 'City'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtzip.ClientID %>'), 'Zip'))
                return false;

            if (isBlank(document.getElementById('<%= this.txtemail.ClientID %>'), 'Email'))
                return false;
            if (validateEmail(document.getElementById('<%= this.txtemail.ClientID %>'), "Email") != true)
                return false;

            if (Number('<%= ManagerId %>') == 0) {
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

        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }
    
    
    </script>
    <asp:HiddenField runat="server" ID="hfCountryID" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" runat="server" id="sptitle">Add Call Center Manager</span>
                    <span class="headingright_default"></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div class="main_content_area_accm">
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">Call Center:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfldnowidth_default">
                            <asp:DropDownList runat="server" ID="ddlcallcenter" CssClass="inputf_def" Width="180px">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">First Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtfname" runat="server" CssClass="inputf_accm" Width="150px" TabIndex="2"></asp:TextBox></span>
                        <span class="titletext_accm">Middle Name: </span><span class="inputfieldrightcon_accm">
                            <asp:TextBox ID="txtmname" runat="server" CssClass="inputf_accm" Width="150px" TabIndex="3"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">Last Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtlname" runat="server" CssClass="inputf_accm" Width="150px" TabIndex="3"></asp:TextBox>
                        </span><span class="titletext_accm"></span><span class="inputfieldrightcon_accm">
                        </span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">Date Of Birth:</span> <span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtdob" runat="server" CssClass="inputf_accm date-picker-dob" Width="95px" TabIndex="5"></asp:TextBox>
                            </span>
                    </p>
                    <div class="headbg_box_accm">
                        <div class="head_text_accm">
                            Contact Details</div>
                    </div>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">Address1:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtaddress1" runat="server" CssClass="inputf_accm" Width="170px"
                                TextMode="multiLine" TabIndex="6"></asp:TextBox></span> <span class="titletext_accm">
                                    Phone (Cell):</span><span class="inputfieldrightcon_accm">
                                        <asp:TextBox ID="txtphonecell" runat="server" CssClass="inputf_accm mask-phone" TabIndex="12"></asp:TextBox>
                                    </span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">Address2: </span><span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtaddress2" runat="server" CssClass="inputf_accm" Width="170px"
                                TextMode="multiLine" TabIndex="7"></asp:TextBox>
                        </span><span class="titletext_accm">Phone (Home):</span><span class="inputfieldrightcon_accm">
                            <asp:TextBox ID="txtphonehome" runat="server" CssClass="inputf_accm mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">City:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtCity" runat="server" TabIndex="9" Width="100" CssClass="inputf_accm auto-Search"></asp:TextBox>
                        </span><span class="titletext_accm">Phone (Other): </span><span class="inputfieldrightcon_accm">
                            <asp:TextBox ID="txtphoneother" runat="server" CssClass="inputf_accm mask-phone"
                                TabIndex="14"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">State:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_accm">
                            <asp:DropDownList ID="ddlstate" TabIndex="10" runat="server" CssClass="inputf_accm"
                                AutoPostBack="False" Width="120px" __designer:wfdid="w8">
                            </asp:DropDownList>
                        </span><span class="titletext_accm">Email:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldrightcon_accm">
                            <asp:TextBox ID="txtemail" TabIndex="15" runat="server" CssClass="inputf_accm" Width="170px"
                                __designer:wfdid="w9"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtzip" runat="server" CssClass="inputf_accm" Width="100px" MaxLength="8"
                                TabIndex="11"></asp:TextBox></span> <span class="titletext_accm">Other Email:
                        </span><span class="inputfieldrightcon_accm">
                            <asp:TextBox ID="txtemailother" TabIndex="16" runat="server" CssClass="inputf_accm"
                                Width="170px"></asp:TextBox>
                        </span>
                    </p>
                    <% if (ManagerId == 0) %>
                    <%
                       {%>
                    <div class="headbg_box_accm">
                        <div class="head_text_accm">
                            Login Details</div>
                    </div>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">UserId:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="inputf_accm" Width="100px" TabIndex="11"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_accm">
                        <span class="titletext_accm">Password:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_accm">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="inputf_accm"
                                Width="100px" MaxLength="8" TabIndex="11"></asp:TextBox></span> <span class="titletext_accm"
                                    style="width: 125px">Confirm Password:<span class="reqiredmark"><sup>*</sup> </span>
                                </span><span class="inputfieldrightcon_accm">
                                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="inputf_accm"
                                       autocomplete="off"  Width="100px" MaxLength="8" TabIndex="11"></asp:TextBox></span>
                    </p>
                    <%
                       }%>
                </div>
            </div>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtnSave" OnClientClick="return checkvalidations();" runat="server"
                        CssClass="" ImageUrl="~/App/Images/save-button.gif" OnClick="ibtnSave_Click"
                        TabIndex="17" /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtnCancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="ibtnCancel_Click" TabIndex="18" /></div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            $('.auto-Search').autoComplete({
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

<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/CallCenterMaster.master"
    AutoEventWireup="true" Inherits="CallCenter_AddCallCenterRep" Title="Untitled Page"
    CodeBehind="AddCallCenterRep.aspx.cs" %>

<%@ Register Src="../UCCommon/ucupdatephotopanel.ascx" TagName="ucupdatephotopanel"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <script language="JavaScript" type="text/javascript">
        function Validation() {

            var txtMiddleName = document.getElementById("<%= this.txtMiddleName.ClientID %>");
            var txtTerminationDate = document.getElementById("<%= this.txtTerminationDate.ClientID %>");

            var txtStartDate = document.getElementById("<%= this.txtStartDate.ClientID %>");
            var txtfname = document.getElementById("<%= this.txtfname.ClientID %>");
            var txtlname = document.getElementById("<%= this.txtlname.ClientID %>");
            var txtaddress1 = document.getElementById("<%= this.txtaddress1.ClientID %>");
            var txtAddress2 = document.getElementById("<%= this.txtAddress2.ClientID %>");
            var txtCity = document.getElementById("<%= this.txtCity.ClientID %>");
            var ddlState = document.getElementById("<%= this.ddlState.ClientID %>");

            var txtzip1 = document.getElementById("<%= this.txtzip1.ClientID %>");
            var txtphonehome = document.getElementById("<%= this.txtphonehome.ClientID %>");
            var txtphoneother = document.getElementById("<%= this.txtphoneother.ClientID %>");
            var txtphonecell = document.getElementById("<%= this.txtphonecell.ClientID %>");
            var txtDob = document.getElementById("<%= this.txtDob.ClientID %>");
            var txtEmail1 = document.getElementById("<%= this.txtEmail1.ClientID %>");
            var txtEmail2 = document.getElementById("<%= this.txtEmail2.ClientID %>");

            if (isBlank(txtfname, "First Name")) { return false; }
            if (isBlank(txtlname, "Last Name")) { return false; }
            if (isBlank(txtDob, "Date of Brith")) { return false; }

            if (ValidateDate(txtDob.value, "Date Of Birth") == false)
            { return false; }

            if (checkDate(txtDob.value, "Date Of Birth") == false)
            { return false; }

            if (txtTerminationDate.value != "") {
                if (ValidateDate(txtTerminationDate.value, "Termination Date") == false)
                { return false; }

                if (checkDate(txtTerminationDate.value, "Termination Date") == false)
                { return false; }
            }

            if (isBlank(txtStartDate, "Start Date")) { return false; }
            if (isBlank(txtaddress1, "Address1")) { return false; }
            if (checkLength(txtaddress1, 500, "Address1")) { return false; }
            if (checkLength(txtAddress2, 500, "Address2")) { return false; }

            if (checkDropDown(ddlState, "State for contact details") == false) { return false; }
            if (isBlank(txtCity, "City for contact details")) { return false; }
            if (isNumeric(txtzip1, "Zip") != true) { return false; }
            if (isBlank(txtEmail1, "Email")) { return false; }
            if (validateEmail(txtEmail1, "Email") != true) { return false; }
            if (txtEmail2.value != "") {
                if (validateEmail(txtEmail2, "Other Email") != true) { return false; }
            }

            if (Number('<%= CallCenterRepId %>') == 0) {
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

    
    </script>
    <asp:HiddenField ID="hfCounrtyID" runat="server" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Add Call Centre Rep</span>
                </div>
            </div>
            <div class="pagealerttxtCNT" id="errordiv" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <p class="main_container_row_accr">
                    <span class="titletext_default">First Name:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtfname" runat="server" CssClass="inputf_def" MaxLength="50" Width="150px"
                            TabIndex="1"></asp:TextBox></span> <span class="titletext_default">Middle Name:
                    </span><span class="inputfieldright_default">
                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="inputf_def" Width="150px"
                            TabIndex="2"></asp:TextBox></span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">Last Name:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtlname" runat="server" CssClass="inputf_def" Width="150px" TabIndex="3"></asp:TextBox></span>
                    <span class="titletext_default">Date of Birth: <span class="reqiredmark"><sup>*</sup>
                    </span></span><span class="inputfieldob_accr">
                        <asp:TextBox ID="txtDob" runat="server" CssClass="inputf_def date-picker-dob" Width="100px"
                            TabIndex="4"></asp:TextBox>
                        <span style="font-size: 7pt;">mm/dd/yyyy</span> </span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">Start Date: </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputf_def date-picker" Width="100px"
                            TabIndex="6"></asp:TextBox>
                        <span style="font-size: 7pt;">mm/dd/yyyy</span></span> <span class="titletext_default">
                            Termination Date: </span><span class="inputfieldob_accr">
                                <asp:TextBox ID="txtTerminationDate" runat="server" CssClass="inputf_def date-picker"
                                    TabIndex="7" Width="100px"></asp:TextBox>
                                <span style="font-size: 7pt;">mm/dd/yyyy</span> </span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">Can Do Refund:</span>
                    <span class="inputfieldob_accr">
                        <asp:CheckBox ID="chkCanDoRefund" runat="server" TabIndex="8" />
                    </span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default" style="width:130px;">Can Edit/Delete Notes:</span>
                    <span class="inputfieldob_accr">
                        <asp:CheckBox ID="chkChangeNotes" runat="server" TabIndex="8" />
                    </span>
                </p>
                <div class="headbg_boxtop_accr">
                    <div class="head_text_accr">
                        Contact Details</div>
                </div>
                <p class="main_container_row_accr">
                    <span class="titletext_default">Address1:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtaddress1" runat="server" CssClass="inputf_def" Width="170px"
                            TabIndex="9" TextMode="multiLine"></asp:TextBox></span> <span class="titletext_default">
                                Phone (Cell):</span> <span class="inputfieldright_default">
                                    <asp:TextBox ID="txtphonecell" runat="server" CssClass="inputf_def mask-phone" TabIndex="10"></asp:TextBox>
                                </span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">Address2: </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputf_def" Width="170px"
                            TextMode="multiLine" TabIndex="11"></asp:TextBox>
                    </span><span class="titletext_default">Phone (Home): </span><span class="inputfieldright_default">
                        <asp:TextBox ID="txtphonehome" runat="server" CssClass="inputf_def mask-phone" TabIndex="12"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">City:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtCity" runat="server" TabIndex="13" Width="100" CssClass="inputf_accm auto-Search"></asp:TextBox>
                    </span><span class="titletext_default">Phone (Other): </span><span class="inputfieldright_default">
                        <asp:TextBox ID="txtphoneother" TabIndex="14" runat="server" CssClass="inputf_def mask-phone"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">State:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldconleft_default">
                        <asp:DropDownList ID="ddlState" TabIndex="15" runat="server" Width="120px" CssClass="inputf_accm"
                            AutoPostBack="False">
                        </asp:DropDownList>
                    </span><span class="titletext_default">Email:<span class="reqiredmark"><sup>*</sup>
                    </span></span><span class="inputfieldright_default">
                        <asp:TextBox ID="txtEmail1" TabIndex="17" runat="server" Width="170px" CssClass="inputf_def"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">Zip: <span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtzip1" runat="server" CssClass="inputf_def" Width="100" TabIndex="18"></asp:TextBox></span>
                    <span class="titletext_default">Other Email: </span><span class="inputfieldright_default">
                        <asp:TextBox ID="txtEmail2" TabIndex="19" runat="server" Width="170px" CssClass="inputf_def"></asp:TextBox>
                    </span>
                </p>
                <% if (CallCenterRepId == 0) %>
                <%
                   {%>
                <div class="headbg_boxtop_accr">
                    <div class="head_text_accr">
                        Login Details</div>
                </div>
                <p class="main_container_row_accr">
                    <span class="titletext_default">User Name: <span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="inputf_def" Width="100" TabIndex="20"></asp:TextBox></span>
                </p>
                <p class="main_container_row_accr">
                    <span class="titletext_default">Password: </span><span class="inputfieldconleft_default">
                        <asp:TextBox ID="txtPassword" TabIndex="21" TextMode="Password" runat="server" CssClass="inputf_def" Width="100" autocomplete="off"></asp:TextBox>
                    </span><span class="titletext_default">Confirm Password: <span class="reqiredmark"><sup>
                        *</sup> </span></span><span class="inputfieldright_default">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="inputf_def"
                                Width="100" TabIndex="22"></asp:TextBox></span>
                </p>
                <%
                   }%>
            </div>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtnsave" runat="server" CssClass="" ImageUrl="../Images/save-button.gif"
                        OnClick="ibtnsave_Click" OnClientClick="return Validation()" TabIndex="24" /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtncancel" runat="server" CssClass="" ImageUrl="../Images/cancel-button.gif"
                        OnClick="ibtncancel_Click" TabIndex="23" /></div>
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

            $(".date-picker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-10:+50"
            });
            $('.mask-phone').mask('(999)-999-9999');
        });
    
    </script>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPCPInfo.ascx.cs" Inherits="Falcon.App.UI.Public.UCPublic.UCPCPInfo" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
<style type="text/css">
    .main_containerbig_editp {
        float: left;
        width: 640px;
        padding: 3px 5px 3px 10px;
        margin: 0px;
    }

    .titletext_editp {
        float: left;
        width: 110px;
        margin-right: 5px;
        padding-top: 3px;
        font: bold 12px arial;
        color: #000;
    }

    .inputfieldcus_editp {
        float: left;
        width: 150px;
        margin-right: 40px;
        padding-top: 0px;
        font: bold 12px arial;
        color: #000;
    }

    .inputf_editp {
        border: 1px solid #7F9DB9;
        background-color: #fff;
        font: normal 12px arial;
        color: #333;
        padding: 2px;
    }

    .inputfieldrightcon_editp {
        float: left;
        width: 180px;
        font: normal 12px arial;
    }

    .list_amv {
        border: 1px solid #7F9DB9;
        background-color: #fff;
        font: normal 12px arial;
        color: #333;
        padding: 2px;
    }

    .radiobuttoncon_sendmail_editp {
        float: left;
        width: 280px;
        font: normal 12px arial;
        color: #000;
    }

    .inputf_accm {
        border: 1px solid #7F9DB9;
        background-color: #fff;
        font: normal 12px arial;
        color: #333;
        padding: 2px;
    }
</style>

<script language="javascript" type="text/javascript">
    function ValidatePCP() {
        var txtFName = document.getElementById("<%= txtphyfname.ClientID %>");
        var txtLName = document.getElementById("<%= txtphylname.ClientID %>");

        var txtphyaddress1 = document.getElementById("<%= txtphyaddress1.ClientID %>");
        var txtphyzip = document.getElementById("<%= txtphyzip.ClientID %>");
        var ddlState = document.getElementById("<%= ddlphystate.ClientID %>");
        var txtphyCity = document.getElementById("<%= txtphyCity.ClientID %>");

        var txtphyMaillingaddress1 = document.getElementById("<%= txtphyMaillingaddress1.ClientID %>");
        var txtphyMaillingzip = document.getElementById("<%= txtphyMaillingzip.ClientID %>");
        var ddlphyMaillingstate = document.getElementById("<%= ddlphyMaillingstate.ClientID %>");
        var txtphyMaillingCity = document.getElementById("<%= txtphyMaillingCity.ClientID %>");
        var isMaillingAddressSame = $("#" + '<%=chkMaillingAddressSame.ClientID%>').is(":checked");

        if (isBlank(txtFName, "First Name")) { return false; }
        if (isBlank(txtLName, "Last Name")) { return false; }

        if (isMaillingAddressSame == false) {
            if (isBlank(txtphyaddress1, "Address 1")) { return false; }
            if (isBlank(txtphyCity, "City")) { return false; }
            if ((checkDropDown(ddlState, "State") == false)) { return false; }
            if (isBlank(txtphyzip, "Zip Code")) { return false; }

            if (isBlank(txtphyMaillingaddress1, "Mailling Address 1")) { return false; }
            if (isBlank(txtphyMaillingCity, "Mailling City")) { return false; }
            if ((checkDropDown(ddlphyMaillingstate, "Mailling State") == false)) { return false; }
            if (isBlank(txtphyMaillingzip, "Mailling Zip Code")) { return false; }
        }
        
        if ((!$("input:checkbox[name$='chkVerifiedPcpInfo']").is(":checked"))) {
            return confirm("You have not verified the PCP Info. Do you want to continue?");            
        }
        else if (isBlank(txtphyaddress1, 'Address1') || (checkDropDown(ddlState, "State") == false) || isBlank(txtphyCity, 'City') || isBlank(txtphyzip, 'Zip Code')) {
            return false;
        }

        return true;
    }
</script>

<asp:Panel ID="pnlPCpDetails" runat="server">
    <div class="contentrow_pw" id="divNewPCP" runat="server">
        <p class="lineheight_pw">
            <img src="/App/Images/spacer.gif" height="10px" width="1px" />
        </p>
        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">First Name<span class="reqiredmark"><sup>*</sup></span>: </span><span class="inputfieldcus_editp"
                style="margin-left: 0px">
                <asp:TextBox ID="txtphyfname" runat="server" CssClass="inputf_editp" Width="170px"
                    MaxLength="500"></asp:TextBox></span> <span class="titletext_editp" style="width: 80px;">Middle Name: </span><span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtphymname" runat="server" CssClass="inputf_editp" Width="170px"
                            MaxLength="500"></asp:TextBox></span>
        </p>
        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">Last Name<span class="reqiredmark"><sup>*</sup></span>:
            </span><span class="inputfieldcus_editp">
                <asp:TextBox ID="txtphylname" runat="server" CssClass="inputf_editp" Width="170px"
                    MaxLength="500"></asp:TextBox></span>
        </p>
        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">Address 1<span class="reqiredmark"></span>:<%--<span class="reqiredmark"><sup>*</sup> </span>--%>
            </span><span class="inputfieldcus_editp">
                <asp:TextBox ID="txtphyaddress1" runat="server" CssClass="inputf_editp" Width="445px"></asp:TextBox></span>
        </p>
        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">Address 2<span class="reqiredmark"></span>:<%--<span class="reqiredmark"><sup>*</sup> </span>--%>
            </span><span class="inputfieldcus_editp">
                <asp:TextBox ID="txtphyaddress2" runat="server" CssClass="inputf_editp" Width="445px"></asp:TextBox></span>
        </p>
        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">State : </span><span class="inputfieldcus_editp" style="width: 100px;">
                <asp:DropDownList ID="ddlphystate" runat="server" Width="120px" CssClass="inputf_accm ddl-states">
                </asp:DropDownList>
            </span>
            <span class="titletext_editp" style="width: 40px;">City : </span><span class="inputfieldcus_editp" style="width: 73px;">
                <asp:TextBox ID="txtphyCity" runat="server" Width="90" CssClass="inputf_accm auto-search-city"></asp:TextBox>
            </span>
            <span class="titletext_editp" style="width: 60px;">Zip Code<span class="reqiredmark"></span>:<%--<span class="reqiredmark"><sup>*</sup> </span>--%></span>
            <span class="inputfieldcus_editp">
                <asp:TextBox ID="txtphyzip" runat="server" CssClass="inputf_accm" Width="82"></asp:TextBox>
            </span>
        </p>
        <p class="main_containerbig_editp">
            <asp:CheckBox ID="chkMaillingAddressSame" runat="server" onclick="" Checked="True" />
            <b>Has same mailing address</b>
        </p>
        <div class="mailling-address-block">
            <p class="main_containerbig_editp">
                <span class="titletext_editp" style="width: 80px;">Address 1<span class="reqiredmark"></span>:<%--<span class="reqiredmark"><sup>*</sup> </span>--%>
                </span><span class="inputfieldcus_editp">
                    <asp:TextBox ID="txtphyMaillingaddress1" runat="server" CssClass="inputf_editp" Width="445px"></asp:TextBox></span>
            </p>
            <p class="main_containerbig_editp">
                <span class="titletext_editp" style="width: 80px;">Address 2<span class="reqiredmark"></span>:<%--<span class="reqiredmark"><sup>*</sup> </span>--%>
                </span><span class="inputfieldcus_editp">
                    <asp:TextBox ID="txtphyMaillingaddress2" runat="server" CssClass="inputf_editp" Width="445px"></asp:TextBox></span>
            </p>
            <p class="main_containerbig_editp">
                <span class="titletext_editp" style="width: 80px;">State : </span><span class="inputfieldcus_editp" style="width: 100px;">
                    <asp:DropDownList ID="ddlphyMaillingstate" runat="server" Width="120px" CssClass="inputf_accm ddl-mailling-states">
                    </asp:DropDownList>
                </span>
                <span class="titletext_editp" style="width: 40px;">City : </span><span class="inputfieldcus_editp" style="width: 73px;">
                    <asp:TextBox ID="txtphyMaillingCity" runat="server" Width="90" CssClass="inputf_accm auto-mailling-city"></asp:TextBox>
                </span>
                <span class="titletext_editp" style="width: 60px">Zip Code<span class="reqiredmark"></span>:<%--<span class="reqiredmark"><sup>*</sup> </span>--%></span>
                <span class="inputfieldcus_editp">
                    <asp:TextBox ID="txtphyMaillingzip" runat="server" CssClass="inputf_accm" Width="82"></asp:TextBox>
                </span>
            </p>
        </div>


        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">Phone: </span><span class="inputfieldcus_editp">
                <asp:TextBox ID="txtPhyPhone" runat="server" CssClass="inputf_editp mask-phone-derived" Width="170px"
                    MaxLength="50"></asp:TextBox></span> <span class="titletext_editp" style="width: 100px;">Alternate Phone:</span> <span class="inputfieldrightcon_editp">
                        <asp:TextBox ID="txtPhyPhoneOther" runat="server" CssClass="inputf_editp mask-phone-derived" Width="150"
                            MaxLength="50"></asp:TextBox>
                    </span>
        </p>
        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">Email: </span>
            <span class="inputfieldcus_editp">
                <asp:TextBox ID="txtphyemail" runat="server" CssClass="inputf_editp" MaxLength="500"></asp:TextBox>
            </span>
            <span class="titletext_editp" style="width: 100px;">Fax:</span>
            <span class="inputfieldrightcon_editp">
                <asp:TextBox ID="txtPhyFax" runat="server" CssClass="inputf_editp mask-phone-derived" Width="150"
                    MaxLength="500"></asp:TextBox>
            </span>
            <span class="titletext_editp" style="width: 100px; display: none;">Alternate Email:</span>
            <span class="inputfieldrightcon_editp" style="display: none;">
                <asp:TextBox ID="txtPhyEmailOther" runat="server" CssClass="inputf_editp" Width="150"
                    MaxLength="500"></asp:TextBox>
            </span>
        </p>
        <p class="main_containerbig_editp">
            <span class="titletext_editp" style="width: 80px;">Website<span class="reqiredmark"></span>:<%--<span class="reqiredmark"><sup>*</sup> </span>--%></span>
            <span class="inputfieldcus_editp">
                <asp:TextBox ID="txtWebsite" runat="server" CssClass="inputf_accm" Width="170" MaxLength="1000"></asp:TextBox>
            </span>
        </p>
        <p class="main_containerbig_editp">
            <asp:CheckBox ID="chkVerifiedPcpInfo" runat="server" />
            <b>Is PCP Info Verified?</b>
        </p>        
    </div>
</asp:Panel>

<script type="text/javascript" language="javascript">

    function showHideMailingAddressBlock(show) {
        if (show) {
            $(".mailling-address-block").show();
        } else {
            $(".mailling-address-block").hide();
        }
    }

    function SetAutoCompleteToControl(controlId, contextKey) {
        $(controlId).autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: contextKey
        });
    }

    $("#" + '<%=chkMaillingAddressSame.ClientID%>').click(function () {
        
        $("#" + '<%=txtphyMaillingaddress1.ClientID%>').val($("#" + '<%=txtphyaddress1.ClientID%>').val());
        $("#" + '<%=txtphyMaillingaddress2.ClientID%>').val($("#" + '<%=txtphyaddress2.ClientID%>').val());
        $("#" + '<%=txtphyMaillingCity.ClientID%>').val($("#" + '<%=txtphyCity.ClientID%>').val());
        $("#" + '<%=txtphyMaillingzip.ClientID%>').val($("#" + '<%=txtphyzip.ClientID%>').val());
        $('.ddl-mailling-states').val($('.ddl-states option:selected').val());

        if ($(this).is(":checked")) {
            $(".mailling-address-block").hide();
        } else {
            $(".mailling-address-block").show();
        }
    });

    $(document).ready(function () {
        SetAutoCompleteToControl('.auto-search-city', $('.ddl-states option:selected').val());
        $('.ddl-states').change(function () {
            SetAutoCompleteToControl('.auto-search-city', $('.ddl-states option:selected').val());
        });
        $('.mask-phone-derived').mask('(999)-999-9999');
        SetAutoCompleteToControl('.auto-mailling-city', $('.ddl-mailling-states option:selected').val());
        $('.ddl-mailling-states').change(function () {
            SetAutoCompleteToControl('.auto-mailling-city', $('.ddl-mailling-states option:selected').val());
        });
        if ('<%=IsMaillingAddressSame%>' === '<%=Boolean.TrueString %>') {
            showHideMailingAddressBlock(false);
        } else {
            showHideMailingAddressBlock(true);
        }
    });
</script>


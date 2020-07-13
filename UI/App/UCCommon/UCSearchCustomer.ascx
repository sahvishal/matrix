<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCSearchCustomer"
    CodeBehind="UCSearchCustomer.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<style type="text/css">
    .mainrow1_ccrep_dboard
    {
        float: right;
        width: 748px;
    }
    .maindivgrids_hd
    {
        float: left;
        width: 749px;
    }
    .dgviewcalls_hd
    {
        float: left;
        width: 749px;
    }
    .gridtabon_vesv_CV
    {
        float: left;
        width: 189px;
        height: 27px;
        background: url(/App/images/Customer/tab-ziptxt-on.gif) no-repeat;
    }
    .gridtaboff_vesv_CV
    {
        float: left;
        width: 189px;
        margin-left: 2px;
        height: 27px;
        background: url(/App/images/Customer/tab-ziptxt-off.gif) no-repeat;
    }
    .grayboxtop_cl
    {
        float: left;
        width: 746px;
    }
    .tabtxton_vesv
    {
        float: left;
        padding: 5px 0px 0px 10px;
        color: #ED8315;
        font-weight: bold;
    }
    .tabtxton_vesv a:link
    {
        text-decoration: none;
    }
    .tabtxton_vesv a:visited
    {
        text-decoration: none;
    }
    .tabtxton_vesv a:hover
    {
        text-decoration: none;
    }
    .tabtxtoff_vesv
    {
        float: left;
        padding: 5px 0px 0px 10px;
        color: #286E92;
        font-weight: bold;
    }
    .tabtxtoff_vesv a:link
    {
        text-decoration: none;
    }
    .tabtxtoff_vesv a:visited
    {
        text-decoration: none;
    }
    .tabtxtoff_vesv a:hover
    {
        text-decoration: none;
    }
    .divgrid_cl
    {
        border-collapse: collapse;
        background-color: #FFF;
        width: 100%;
    }
    .divgrid_cl TD
    {
        border: none;
        padding: 4px 4px 4px 10px;
        border-bottom: solid 1px #D0D9E0;
    }
    .divgrid_cl TH
    {
        border: none;
        text-align: left;
        padding: 8px 4px 12px 10px;
    }
    .divgrid_cl .row1
    {
        background-color: #DDF0F7;
        font: bold 12px arial;
        color: #1E6EA1;
        vertical-align: top;
    }
    .divgrid_cl .row2
    {
        background-color: #EFF8FD;
        vertical-align: top;
        color: #333;
    }
    .divgrid_cl .row2 a:link
    {
        text-decoration: none;
    }
    .divgrid_cl .row2 a:visited
    {
        text-decoration: none;
    }
    .divgrid_cl .row2 a:hover
    {
        text-decoration: none;
    }
    .divgrid_cl .row3
    {
        background-color: #F8FCFF;
        vertical-align: top;
        color: #333;
    }
    .divgrid_cl .row3 a:link
    {
        text-decoration: none;
    }
    .divgrid_cl .row3 a:visited
    {
        text-decoration: none;
    }
    .divgrid_cl .row3 a:hover
    {
        text-decoration: none;
    }
    .blueboxbotbg_cl
    {
        float: left;
        width: 746px;
        background: url(/App/images/Customer/botbgbluebox_cl.gif) no-repeat;
    }

    .detailheader {
        width: 25px;
    }
</style>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryMaskInput="true" />
<script language="javascript" type="text/javascript">

    String.prototype.trim = function () {
        a = this.replace(/^\s+/, '');
        return a.replace(/\s+$/, '');
    };

    function Validation() {
        //debugger;
        var hfCnfrmCust = document.getElementById("<%=this.hfCnfrmCust.ClientID %>");


        var txtFirstName = document.getElementById("<%=this.txtFirstName.ClientID %>");
        var txtLastName = document.getElementById("<%=this.txtLastName.ClientID %>");
        var txtCustomerID = document.getElementById("<%=this.txtCustomerID.ClientID %>");
        var txtZipCode = document.getElementById("<%= this.txtZipCode.ClientID %>");
        var txtStartDate = document.getElementById('<%= this.txtStartDate.ClientID %>');
        var txtEventStartDate = document.getElementById('<%= this.txtEventStartDate.ClientID %>');
        var txtEventEndDate = document.getElementById('<%= this.txtEventEndDate.ClientID %>');
        var txtEndDate = document.getElementById('<%= this.txtEndDate.ClientID %>');
        var txtEventId = document.getElementById('<%= this.txtEventId.ClientID %>');
        var txtEmail = document.getElementById('<%= this.txtEmail.ClientID %>');
        var txtPhoneNumber = document.getElementById('<%= this.txtPhoneNumber.ClientID %>');
        var txtMemberId = document.getElementById('<%= this.txtMemberId.ClientID%>');
        var txtHICN = document.getElementById('<%= this.txtHICN.ClientID%>');
        var txtDOB = document.getElementById('<%= this.txtDOB.ClientID%>');
        
        var txtMbiNumber = document.getElementById('<%= this.txtMBINumber.ClientID%>');

        if (hfCnfrmCust.value == "0") {
            if (txtEventId.value == "" && txtCustomerID.value == "" && txtEventStartDate.value == '' && txtEventEndDate.value == '' && txtEmail.value == '' && txtLastName.value.trim() == '' && txtFirstName.value == '' && txtPhoneNumber.value == '' && txtMemberId.value == '' && txtHICN.value == '' & txtDOB.value == '' && txtMbiNumber.value == '') {
                alert("Please provide atleast one search criteria.");
                return false;               
            }

            if (txtLastName.value.trim() != "" && (txtLastName.value.trim()).length < 2) {
                alert("Please enter atleast 2 character for the Last Name.");
                return false;
            }

            if (txtEventStartDate.value != '') {
                if (ValidateDate(txtEventStartDate.value, "Event Start Date") == false) {
                    return false;
                }
            }
            if (txtEventEndDate.value != '') {
                if (ValidateDate(txtEventEndDate.value, "Event End Date") == false) {
                    return false;
                }
            }
            if (txtDOB.value != '') {
                if (ValidateDate(txtDOB.value, "DOB") == false) {
                    return false;
                }
            }
            if (document.getElementById('<%= this.txtEventStartDate.ClientID %>').value != '' && document.getElementById('<%= this.txtEventEndDate.ClientID %>').value != '') {
                var dateFrom = new Date(document.getElementById('<%= this.txtEventStartDate.ClientID %>').value);
                var dateTo = new Date(document.getElementById('<%= this.txtEventEndDate.ClientID %>').value);

                var datefrom = dateFrom.getTime(); // milliseconds
                var dateto = dateTo.getTime();

                if (datefrom > dateto) {
                    alert("Please enter a valid date range in search criteria.");
                    return false;
                }

                var one_day = 1000 * 60 * 60 * 24;
                var day_diff = Math.ceil((dateto - datefrom) / (one_day));
//                if (day_diff > 30) {
//                    alert("Date range difference can not be greater than 30 days.");
//                    return false;
//                }
            }
        }
        else if (hfCnfrmCust.value == "1") {
            if (txtStartDate.value == '') {
                alert("Please enter Start Date.");
                return false;
            }
            if (txtEndDate.value == '') {
                alert("Please enter End Date.");
                return false;
            }

            if (txtStartDate.value != '') {
                if (ValidateDate(txtStartDate.value, "Start Date") == false) {
                    return false;
                }
            }
            if (txtEndDate.value != '') {
                if (ValidateDate(txtEndDate.value, "End Date") == false) {
                    return false;
                }
            }
            if (document.getElementById('<%= this.txtStartDate.ClientID %>').value != '' && document.getElementById('<%= this.txtEndDate.ClientID %>').value != '') {
                var dateFrom = new Date(document.getElementById('<%= this.txtStartDate.ClientID %>').value);
                var dateTo = new Date(document.getElementById('<%= this.txtEndDate.ClientID %>').value);

                var datefrom = dateFrom.getTime(); // milliseconds
                var dateto = dateTo.getTime();

                if (datefrom > dateto) {
                    alert("Please enter a valid date range in search criteria.");
                    return false;
                }

                var one_day = 1000 * 60 * 60 * 24;
                var day_diff = Math.ceil((dateto - datefrom) / (one_day));
                if (day_diff > 30) {
                    alert("Date range difference can not be greater than 30 days.");
                    return false;
                }

            }
        }
        return true;
    }
    function Reset() {//debugger
        var txtFirstName = document.getElementById("<%=this.txtFirstName.ClientID %>");
        var txtLastName = document.getElementById("<%=this.txtLastName.ClientID %>");
        var txtZipCode = document.getElementById("<%= this.txtZipCode.ClientID %>");
        var txtCustomerID = document.getElementById("<%=this.txtCustomerID.ClientID %>");
        var txtStartDate = document.getElementById('<%= this.txtStartDate.ClientID %>');
        var txtEndDate = document.getElementById('<%= this.txtEndDate.ClientID %>');
        var txtEventId = document.getElementById('<%= this.txtEventId.ClientID %>');
        var hfCnfrmCust = document.getElementById("<%=this.hfCnfrmCust.ClientID %>");
        var txtDOB = document.getElementById('<%= this.txtDOB.ClientID %>');

        var txtMbiNumber = document.getElementById('<%= this.txtMBINumber.ClientID %>');
        var txtHicn = document.getElementById('<%= this.txtHICN.ClientID %>');
        var txtMemberId = document.getElementById('<%= this.txtMemberId.ClientID %>');

        if (hfCnfrmCust.value == "0") {
            txtFirstName.value = "";
            txtLastName.value = "";
            txtZipCode.value = "";
            txtCustomerID.value = "";
            txtEventId.value = "";
            txtDOB.value = "";
            txtMbiNumber.value = "";
            txtHicn.value = "";
            txtMemberId.value = "";
        }
        else {
            txtStartDate.value = "";
            txtEndDate.value = "";
        }



    }
    function NextBuild() {
        alert('Please check this in next release');
        return false;
    }

    function txtkeypress(evt) {
        return KeyPress_NumericAllowedOnly(evt);

    }

    function txtkeypress_AlphanumericOnly(evt)//Allows only alphanumeric
    {
        var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
        if (key == 9 || key == 13 || key == 8 || key == 222 || (key >= 65 && key <= 90)) {
            return true;
        }
        return false;
    }

    function popupmenu2(choice, wt, ht) {

        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=no,scrollbars=no,menubar=no,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);
    }

    function CheckCnfrmCust() {
        var imgBtnSearchCfrmCust = document.getElementById("<%=this.imgBtnSearchCfrmCust.ClientID %>");
        imgBtnSearchCfrmCust.src = "/App/Images/srchconfirmcustomer-on.gif";
        var imgSearchCustomerPros = document.getElementById("<%=this.imgSearchCustomerPros.ClientID %>");
        imgSearchCustomerPros.src = "/App/Images/srchcustomerprospect-off.gif";
        var hfCnfrmCust = document.getElementById("<%=this.hfCnfrmCust.ClientID %>");
        hfCnfrmCust.value = "0";
        var chkAbdCustomer = document.getElementById("<%=this.chkAbdCustomer.ClientID %>");
        chkAbdCustomer.checked = false;
        var pDateRange = document.getElementById("<%=this.pDateRange.ClientID %>");
        pDateRange.style.display = "none";
        var pName = document.getElementById("<%=this.pName.ClientID %>");
        pName.style.display = "block";
        var pCustIDZip = document.getElementById("<%=this.pCustIDZip.ClientID %>");
        pCustIDZip.style.display = "block";

       <%-- var pEventId = document.getElementById("<%=this.pEventId.ClientID %>");
        pEventId.style.display = "block";--%>
        <%--var pEventDate = document.getElementById("<%=this.pEventDate.ClientID %>");
        pEventDate.style.display = "block";--%>
        
        var divNote = document.getElementById("<%=this.divNote.ClientID %>");
        divNote.style.display = "block";

        var mHICN = document.getElementById("<%=this.mHICN.ClientID %>");
        mHICN.style.display = "block";

        var mMbi = document.getElementById("<%=this.mMbi.ClientID %>");
        mMbi.style.display = "block";

        var divProspectCust = document.getElementById("<%=this.divProspectCust.ClientID %>");
        divProspectCust.style.display = "none";
        divProspectCust.style.visibility = "hidden";

        var spanDOB = document.getElementById("spanDOB");
        spanDOB.style.display = "block";

        var hfCnfrmCustResults = document.getElementById("<%=this.hfCnfrmCustResults.ClientID %>");
        var divConfrmCust = document.getElementById("<%=this.divConfrmCust.ClientID %>");
        if (hfCnfrmCustResults.value == "1") {
            divConfrmCust.style.display = "block";
            divConfrmCust.style.visibility = "visible";
        }
        else {
            divConfrmCust.style.display = "none";
            divConfrmCust.style.visibility = "hidden";
        }

        return false;
    }

    function CheckProspect() {
        var imgBtnSearchCfrmCust = document.getElementById("<%=this.imgBtnSearchCfrmCust.ClientID %>");
        imgBtnSearchCfrmCust.src = "/App/Images/srchconfirmcustomer-off.gif";
        var imgSearchCustomerPros = document.getElementById("<%=this.imgSearchCustomerPros.ClientID %>");
        imgSearchCustomerPros.src = "/App/Images/srchcustomerprospect-on.gif";
        var hfCnfrmCust = document.getElementById("<%=this.hfCnfrmCust.ClientID %>");
        hfCnfrmCust.value = "1";
        var chkAbdCustomer = document.getElementById("<%=this.chkAbdCustomer.ClientID %>");
        chkAbdCustomer.checked = true;
        var pDateRange = document.getElementById("<%=this.pDateRange.ClientID %>");
        pDateRange.style.display = "block";
        var pName = document.getElementById("<%=this.pName.ClientID %>");
        pName.style.display = "none";
        var pCustIDZip = document.getElementById("<%=this.pCustIDZip.ClientID %>");
        pCustIDZip.style.display = "none";

        var pEventId = document.getElementById("<%=this.pEventId.ClientID %>");
        pEventId.style.display = "none";
        var pEventDate = document.getElementById("<%=this.pEventDate.ClientID %>");
        pEventDate.style.display = "none";

        var divNote = document.getElementById("<%=this.divNote.ClientID %>");
        divNote.style.display = "none";

        var mHICN = document.getElementById("<%=this.mHICN.ClientID %>");
        mHICN.style.display = "none";
        
        var mMbi = document.getElementById("<%=this.mMbi.ClientID %>");
        mMbi.style.display = "none";

        var divConfrmCust = document.getElementById("<%=this.divConfrmCust.ClientID %>");
        divConfrmCust.style.display = "none";
        divConfrmCust.style.visibility = "hidden";

        var spanDOB = document.getElementById("spanDOB");
        spanDOB.style.display = "none";

        var divProspectCust = document.getElementById("<%=this.divProspectCust.ClientID %>");
        var hfProsCustResults = document.getElementById("<%=this.hfProsCustResults.ClientID %>");
        if (hfProsCustResults.value == "1") {
            divProspectCust.style.display = "block";
            divProspectCust.style.visibility = "visible";
        }
        else {
            divProspectCust.style.display = "none";
            divProspectCust.style.visibility = "hidden";
        }
        return false;
    }

    function MaintainCheckCnfrmCust() {
        var hfCnfrmCust = document.getElementById("<%=this.hfCnfrmCust.ClientID %>");
        hfCnfrmCust.value = "0";
        var chkAbdCustomer = document.getElementById("<%=this.chkAbdCustomer.ClientID %>");
        chkAbdCustomer.checked = false;
        var pDateRange = document.getElementById("<%=this.pDateRange.ClientID %>");
        pDateRange.style.display = "none";
        var pName = document.getElementById("<%=this.pName.ClientID %>");
        pName.style.display = "block";
        var pCustIDZip = document.getElementById("<%=this.pCustIDZip.ClientID %>");
        pCustIDZip.style.display = "block";
        
       <%-- var pEventId = document.getElementById("<%=this.pEventId.ClientID %>");
        pEventId.style.display = "block";--%>
        <%--var pEventDate = document.getElementById("<%=this.pEventDate.ClientID %>");
        pEventDate.style.display = "block";--%>

        var divNote = document.getElementById("<%=this.divNote.ClientID %>");
        divNote.style.display = "block";
        
        var mHICN = document.getElementById("<%=this.mHICN.ClientID %>");
        mHICN.style.display = "block";

        var mMbi = document.getElementById("<%=this.mMbi.ClientID %>");
        mMbi.style.display = "block";

        var imgBtnSearchCfrmCust = document.getElementById("<%=this.imgBtnSearchCfrmCust.ClientID %>");
        imgBtnSearchCfrmCust.src = "/App/Images/srchconfirmcustomer-on.gif";
        var imgSearchCustomerPros = document.getElementById("<%=this.imgSearchCustomerPros.ClientID %>");
        imgSearchCustomerPros.src = "/App/Images/srchcustomerprospect-off.gif";
        var divProspectCust = document.getElementById("<%=this.divProspectCust.ClientID %>");
        divProspectCust.style.display = "none";
        divProspectCust.style.visibility = "hidden";

        var spanDOB = document.getElementById("spanDOB");
        spanDOB.style.display = "block";
        return false;
    }

    function MaintainCheckProspect() {
        var hfCnfrmCust = document.getElementById("<%=this.hfCnfrmCust.ClientID %>");
        hfCnfrmCust.value = "1";
        var chkAbdCustomer = document.getElementById("<%=this.chkAbdCustomer.ClientID %>");
        chkAbdCustomer.checked = true;
        var pDateRange = document.getElementById("<%=this.pDateRange.ClientID %>");
        pDateRange.style.display = "block";
        var pName = document.getElementById("<%=this.pName.ClientID %>");
        pName.style.display = "none";
        var pCustIDZip = document.getElementById("<%=this.pCustIDZip.ClientID %>");
        pCustIDZip.style.display = "none";

        var pEventId = document.getElementById("<%=this.pEventId.ClientID %>");
        pEventId.style.display = "none";
        var pEventDate = document.getElementById("<%=this.pEventDate.ClientID %>");
        pEventDate.style.display = "none";

        var divNote = document.getElementById("<%=this.divNote.ClientID %>");
        divNote.style.display = "none";
        
        var mHICN = document.getElementById("<%=this.mHICN.ClientID %>");
        mHICN.style.display = "none";

        var mMbi = document.getElementById("<%=this.mMbi.ClientID %>");
        mMbi.style.display = "none";
        
        var imgBtnSearchCfrmCust = document.getElementById("<%=this.imgBtnSearchCfrmCust.ClientID %>");
        imgBtnSearchCfrmCust.src = "/App/Images/srchconfirmcustomer-off.gif";
        var imgSearchCustomerPros = document.getElementById("<%=this.imgSearchCustomerPros.ClientID %>");
        imgSearchCustomerPros.src = "/App/Images/srchcustomerprospect-on.gif";
        var divConfrmCust = document.getElementById("<%=this.divConfrmCust.ClientID %>");
        divConfrmCust.style.display = "none";
        divConfrmCust.style.visibility = "hidden";

        var spanDOB = document.getElementById("spanDOB");
        spanDOB.style.display = "none";

        return false;
    } 
</script>
<asp:HiddenField ID="hfQueryString" runat="server" Value="0" />
<div class="mainbody_outer">
    <div class="mainbody_inner">
        <div class="main_area_bdr" style="border: 0px">
            <div class="maincontentrow_ccrep">
                <div class="regcust_innercon">
                    <div style="float: left; height: 31px; width: 746px; border-bottom: solid 1px #F08A2F;
                        margin-bottom: 2px;" id="divTab" runat="server">
                        <asp:ImageButton ID="imgBtnSearchCfrmCust" runat="server" ImageUrl="/App/Images/srchconfirmcustomer-on.gif"
                            Text="SearchConfirmCustomer" OnClientClick="return CheckCnfrmCust();"></asp:ImageButton>
                        <asp:ImageButton ID="imgSearchCustomerPros" runat="server" ImageUrl="/App/Images/srchcustomerprospect-off.gif"
                            Text="SearchCustomerProspect" OnClientClick="return CheckProspect();"></asp:ImageButton>
                    </div>
                    <div class="regcust_innerrow">
                        <asp:Panel DefaultButton="ibtnSearch" ID="pnlSearch" runat="server">
                            <div class="grayboxtop_cl">
                                <p class="grayboxtopbg_cl">
                                    <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                                <p class="grayboxheader_cl">
                                    Filter/Search Customer</p>
                                <div class="lgtgraybox_cl">
                                    <p>
                                    </p>
                                    <p class="lgtgrayboxrow_cl" id="pName" runat="server">
                                        <span class="titletxt_regcust">First Name:<span class="reqiredmark"></span></span>
                                        <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                        <span class="titletxt_regcust">Last Name:</span>
                                        <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                    </p>
                                    <p class="lgtgrayboxrow_cl" id="pCustIDZip" runat="server">
                                        <span class="titletxt_regcust">Customer ID:<span class="reqiredmark"><sup>&#8224;</sup></span></span>
                                        <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtCustomerID" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                        <span class="titletxt_regcust">Zip Code:</span> <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                    </p>
                                    <p class="lgtgrayboxrow_cl" id="mHICN" runat="server">
                                        <span class="titletxt_regcust">Member Id:</span> <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtMemberId" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                         <span class="titletxt_regcust">HICN:</span> <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtHICN" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                    </p>
                                    <p class="lgtgrayboxrow_cl" id="pEventDate" runat="server" style="display: none;">
                                        <span class="titletxt_regcust">Start Date:</span> <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtEventStartDate" runat="server" CssClass="inputfield_ccrep date-picker"
                                                Width="100px"></asp:TextBox>
                                            <span style="font-size: 7pt; padding: 0px; margin: 0px;">(mm/dd/yyyy)</span>
                                        </span><span class="titletxt_regcust">End Date:</span> <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtEventEndDate" runat="server" CssClass="inputfield_ccrep date-picker"
                                                Width="100px"></asp:TextBox>
                                            <span style="font-size: 7pt; padding: 0px; margin: 0px;">(mm/dd/yyyy)</span>
                                        </span>
                                    </p>
                                    <p class="lgtgrayboxrow_cl" id="pDateRange" runat="server" style="display: none;">
                                        <span class="titletxt_regcust">Start Date:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputfield_ccrep date-picker"
                                                Width="100px"></asp:TextBox>
                                            <span style="font-size: 7pt; padding: 0px; margin: 0px;">(mm/dd/yyyy)</span>
                                        </span><span class="titletxt_regcust">End Date:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="inputfield_ccrep date-picker"
                                                Width="100px"></asp:TextBox>
                                            <span style="font-size: 7pt; padding: 0px; margin: 0px;">(mm/dd/yyyy)</span>
                                        </span>
                                    </p>
                                    
                                    <p class="lgtgrayboxrow_cl" id="p1" runat="server">
                                        <span class="titletxt_regcust">Email:<sup>&#12345;</sup></span> <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span> 
                                        <span id="spanDOB">
                                        <span class="titletxt_regcust">DOB:</span> <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="inputfield_ccrep date-picker" Width="120px"></asp:TextBox></span>
                                            </span>
                                    </p>
                                    <p class="lgtgrayboxrow_cl" id="pEventId" runat="server" >
                                        <span class="titletxt_regcust" style="display: none;">Event ID:<sup>&#12345;</sup></span> <span class="inputconleft_regcust" style="display: none;">
                                            <asp:TextBox ID="txtEventId" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>   
                                       
                                    </p>
                                     <p class="lgtgrayboxrow_cl" id="mMbi" runat="server">
                                        <span class="titletxt_regcust">MBI:</span> <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtMBINumber" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                          <span class="titletxt_regcust">Phone Number:</span> <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="inputfield_ccrep mask-phone" Width="120px"></asp:TextBox></span>
                                    </p>
                                    <p class="lgtgrayboxrow_cl" id="pChkAbdCustomer" runat="server" style="display: none;">
                                        <span style="float: left;">
                                            <asp:CheckBox ID="chkAbdCustomer" Text="Show Customers who did not register for any event."
                                                runat="server" />
                                        </span>
                                    </p>
                                    <p>
                                        <img src="/App/Images/CCRep/specer.gif" width="600px" height="5px" /></p>
                                    <div class="lgtgrayboxrow_cl">
                                        <div id="divNote" runat="server">
                                            <div style="float: left; width: 35px; color: #287AA8; font-weight: bold;">
                                                Note:
                                            </div>
                                            <div style="float: left; width: 520px; color: #287AA8; padding-right: 15px;">
                                                <span style="float: left; width: 10px;">&#8226;&nbsp;</span> <span style="width: 510px;">
                                                    Please provide a minimum of two (2) charcaters of the Last Name for exact searches
                                                    or three &nbsp;&nbsp;(3) or more characters of the Last Name for generic searches.<br />
                                                </span><span style="width: 10px;">&#8224;&nbsp;</span> <span style="width: 350px;">If
                                                    a Customer ID is entered, no other mandatory fields are required.<br />
                                                </span><span style="width: 10px;">&#12345;&nbsp;</span> <span style="width: 350px;">
                                                    If a Event ID or Email is entered, no other mandatory fields are required.</span>
                                            </div>
                                        </div>
                                        <span style="float: right; padding-right: 5px;">
                                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                                OnClick="ibtnSearch_Click" OnClientClick="return Validation();" />
                                        </span><span class="buttoncon_default">
                                            <asp:ImageButton ID="ibtnReset" OnClientClick="return Reset();" runat="server" ImageUrl="~/App/Images/reset-btn.gif"
                                                OnClick="ibtnReset_Click" /></span>
                                    </div>
                                    <p>
                                        <img src="../../Images/CCRep/specer.gif" width="600px" height="5px" /></p>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div id="divConfrmCust" runat="server">
                    <p>
                        <img src="../../Images/CCRep/specer.gif" width="700px" height="10px" /></p>
                    <p class="divmainbody_cd">
                        <span class="blkheadtxt_regcust" id="dvSearchResultCrfmCust1" runat="server"></span>
                        <span class="blueheadtxt_regcust" id="dvSearchResultCrfmCust" runat="server" style="float: left">
                        </span>
                    </p>
                    <p>
                        <img src="../../Images/CCRep/specer.gif" width="1px" height="5px" /></p>
                    <p>
                        <img src="../../Images/CCRep/specer.gif" width="1px" height="5px" /></p>
                    <div class="grayboxtop_cl" id="divGridCrfmCust" runat="server">
                        <p class="blueboxtopbg_cl">
                            <img src="../../Images/CCRep/specer.gif" width="746" height="6" /></p>
                        <div class="grayboxtop_cl">
                            <asp:GridView ID="grdCustomerList" DataKeyNames="CustomerID" runat="server" CssClass="divgrid_cl"
                                AutoGenerateColumns="false" AllowPaging="False" EnableSortingAndPagingCallbacks="False"
                                AllowSorting="true" GridLines="None" 
                                OnSorting="grdCustomerList_Sorting" OnRowDataBound="grdCustomerList_RowDataBound">
                                <Columns>
                                    <asp:BoundField SortExpression="CustomerID" DataField="CustomerID" HeaderText="ID">
                                    </asp:BoundField>
                                    <asp:TemplateField SortExpression="Name" HeaderText="Customer Info.">
                                        <ItemTemplate>
                                            <span><a id="CustomerName" runat="server" href="Javascript:void(0)">
                                                <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                            </a></span>
                                            <br />
                                            <span><a href="mailto:<%# DataBinder.Eval(Container.DataItem, "Email")%>">
                                                <%# DataBinder.Eval(Container.DataItem, "Email")%>
                                            </a></span>
                                            <br />
                                            <span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "Phone")%>
                                            </span>
                                            <br />
                                            <%# DataBinder.Eval(Container.DataItem, "RegDate")%>
                                            <br />
                                            Mode:<span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "AddedBY")%>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField SortExpression="Marketing" HeaderText="Marketing Source">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Marketing") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField SortExpression="Address" HeaderText="Address">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Address")%>
                                            <br />
                                            <span style="color: #287AA8; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "RestAddress")%>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField SortExpression="Event" HeaderText="Most Recent Event">
                                        <ItemTemplate>
                                            <a id="EventName" runat="server" href="Javascript:void(0)">
                                                <%# DataBinder.Eval(Container.DataItem, "Event")%>
                                            </a>
                                            <br />
                                            <%# DataBinder.Eval(Container.DataItem, "EventDate")%>
                                            <%--<br />
                                            <span style="color: #287AA8; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "Host")%>
                                            </span>--%>
                                            <br />
                                            <span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "Package")%>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="TotalRevenue" HeaderText="Total Revenue">
                                        <ItemTemplate>
                                            $<%# DataBinder.Eval(Container.DataItem, "TotalRevenue")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField SortExpression="TotalRevenue" DataField="TotalRevenue" HeaderText="Total Revenue"></asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="detailheader" >
                                        <ItemTemplate>
                                            <%--<asp:ImageButton ImageUrl="/App/Images/reg.gif" ID="ibtnCustomer" runat="server" OnClientClick="return NextBuild();" />--%>
                                            <a id="customerlist" runat="server" href='javascript:void(0);'>
                                                <img src="/App/Images/reg.gif" alt="Click here to view Details" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="row1" />
                                <RowStyle CssClass="row2" />
                                <AlternatingRowStyle CssClass="row3" />
                            </asp:GridView>
                        </div>
                        <div runat="server" id="tblGridPagingConFirmCust" style="float: left; width: 750px;"></div>
                        <p class="blueboxbotbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" /></p>
                        <div id="divCnfrmCustMoreResults" runat="server" visible="false" style="color: #D60202;
                            font-weight: bold;">
                            <span>“Results are always limited to 50, there may be more results available”</span>
                        </div>
                    </div>
                </div>
                <div id="divProspectCust" runat="server">
                    <p>
                        <img src="../../Images/CCRep/specer.gif" width="700px" height="10px" /></p>
                    <p class="divmainbody_cd">
                        <span class="blkheadtxt_regcust" id="dvSearchResultProsCust1" runat="server"></span>
                        <span class="blueheadtxt_regcust" id="dvSearchResultProsCust" runat="server" style="float: left">
                        </span>
                    </p>
                    <p>
                        <img src="../../Images/CCRep/specer.gif" width="1px" height="5px" /></p>
                    <p>
                        <img src="../../Images/CCRep/specer.gif" width="1px" height="5px" /></p>
                    <div class="grayboxtop_cl" id="divGridProsCust" runat="server">
                        <p class="blueboxtopbg_cl">
                            <img src="../../Images/CCRep/specer.gif" width="746" height="6" /></p>
                        <div class="grayboxtop_cl">
                            <asp:GridView ID="grdProsCustomerList" DataKeyNames="CustomerID" runat="server" CssClass="divgrid_cl"
                                AutoGenerateColumns="false" AllowPaging="False" EnableSortingAndPagingCallbacks="False"
                                AllowSorting="true" GridLines="None" 
                                OnSorting="grdProsCustomerList_Sorting" OnRowDataBound="grdProsCustomerList_RowDataBound">
                                <Columns>
                                    <asp:BoundField SortExpression="CustomerID" DataField="CustomerID" HeaderText="ID">
                                    </asp:BoundField>
                                    <asp:TemplateField SortExpression="Name" HeaderText="Customer Info.">
                                        <ItemTemplate>
                                            <span><a id="ProsCustomerName" runat="server" href="Javascript:void(0)">
                                                <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                            </a></span>
                                            <br />
                                            <span><a href="mailto:<%# DataBinder.Eval(Container.DataItem, "Email")%>">
                                                <%# DataBinder.Eval(Container.DataItem, "Email")%>
                                            </a></span>
                                            <br />
                                            <span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "Phone")%>
                                            </span>
                                            <br />
                                            <%# DataBinder.Eval(Container.DataItem, "RegDate")%>
                                            <br />
                                            Mode:<span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "AddedBY")%>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Marketing" HeaderText="Marketing Source">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Marketing") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Address" HeaderText="Address">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Address")%>
                                            <br />
                                            <span style="color: #287AA8; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "RestAddress")%>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Event" HeaderText="Most Recent Event">
                                        <ItemTemplate>
                                            <a id="ProsEventName" runat="server" href="Javascript:void(0)">
                                                <%# DataBinder.Eval(Container.DataItem, "Event")%>
                                            </a>
                                            <br />
                                            <%# DataBinder.Eval(Container.DataItem, "EventDate")%>
                                            <%--<br />
                                            <span style="color: #287AA8; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "Host")%>
                                            </span>--%>
                                            <br />
                                            <span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "Package")%>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="TotalRevenue" HeaderText="Total Revenue">
                                        <ItemTemplate>
                                            $<%# DataBinder.Eval(Container.DataItem, "TotalRevenue")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField SortExpression="TotalRevenue" DataField="TotalRevenue" HeaderText="Total Revenue"></asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%--<asp:ImageButton ImageUrl="/App/Images/reg.gif" ID="ibtnCustomer" runat="server" OnClientClick="return NextBuild();" />--%>
                                            <a id="Proscustomerlist" runat="server" href='javascript:void(0);'>
                                                <img src="/App/Images/reg.gif" alt="Click here to view Details" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="row1" />
                                <RowStyle CssClass="row2" />
                                <AlternatingRowStyle CssClass="row3" />
                            </asp:GridView>
                        </div>
                        <div runat="server" id="tblGridPagingProspectCust" style="float: left; width: 750px;"></div>
                        <p class="blueboxbotbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" /></p>
                        <div id="divProsCustMoreResults" runat="server" visible="false" style="color: #D60202;
                            font-weight: bold;">
                            <span>“Results are always limited to 20, there may be more results available”</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {

        $(".date-picker").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-10:+50"
        });

        $('.mask-phone').mask('(999)-999-9999');
    });

</script>
<asp:HiddenField ID="hfCnfrmCust" Value="0" runat="server" />
<asp:HiddenField ID="hfCnfrmCustResults" Value="0" runat="server" />
<asp:HiddenField ID="hfProsCustResults" Value="0" runat="server" />

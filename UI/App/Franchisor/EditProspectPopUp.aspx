<%@ Page Language="C#" AutoEventWireup="True" Inherits="App_Franchisor_EditProspectPopUp" Codebehind="EditProspectPopUp.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .mainbody_outer_anp
        {
            float: right;
            width: 777px;
            background-color: #fff;
            margin-top: 5px;
        }
        .mainbody_inner_anp
        {
            width: 763px;
            margin-left: 14px;
            margin-bottom: 5px;
        }
        .main_area_bdr_anp
        {
            float: left;
            width: 751px;
            border: 1px solid #E5E5E5;
            padding-bottom: 6px;
            padding-top: 6px;
            margin-top: 5px;
        }
        .main_container_row_anp
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 3px;
            padding-right: 5px;
            padding-bottom: 3px;
        }
        .titletext_anp
        {
            float: left;
            width: 100px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .titletext1_anp
        {
            float: left;
            width: 120px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
             .titletext2_anp
        {
            float: left;
            width: 130px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldcon_anp
        {
            float: left;
            width: 180px;
            margin-right: 85px;
            padding-top: 0px;
        }
        .inputfieldcontype_anp
        {
            float: left;
            width: 220px;
            margin-right: 45px;
            padding-top: 0px;
        }
    .inputfieldcontype1_anp
        {
            float: left;
            width: 220px;
            margin-right: 35px;
            padding-top: 0px;
   }
        .inputfieldbigcon_anp
        {
            float: left;
            width: 350px;
            padding-top: 4px;
        }
        .inputfieldrightcon_anp
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
        }
        .inputareacon_anp
        {
            float: left;
            width: 580px;
            font: normal 12px arial;
            color: #000;
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
        .headbg_box_anp
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 5px;
            margin-bottom: 3px;
        }
        .head_text_anp
        {
            float: left;
            width: 740px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .list_anp
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .bigbtnconlft_anp
        {
            float: left;
            width: 110px;
            padding-left: 5px;
        }
        .bigbtncon2_anp
        {
            float: right;
            width: 135px;
            padding-right: 5px;
        }
        .headbg2_box_anp
        {
            float: left;
            width: 757px;
            padding-top: 5px;
            padding-bottom: 10px;
        }
        .save_button1_anp
        {
            float: right;
            width: 56px;
            height: 32px;
            padding: 0px 5px 0px 0px;
            margin-bottom: 10px;
        }
        .bigbtncon_anp
        {
            float: right;
            padding: 0px 5px 0px 0px;
            margin-bottom: 10px;
        }
        .cancel_button_anp
        {
            float: right;
            width: 56px;
            height: 32px;
            padding: 0px 5px 0px 0px;
            margin-bottom: 10px;
        }
        .headerclose_button_si
        {
            float: left;
            width: 120px;
            text-align: right;
            padding-top: 1px;
        }
        .headertitle_popup_si
        {
            float: left;
            width: 540px;
            padding-left: 10px;
            padding-top: 4px;
        }
        .maindivpagemainrow_anp
        {
            float: left;
            padding-left: 31px;
            width: 718px;
        }
        .pagemainrow_anp
        {
            float: left;
            width: 718px;
            padding-top: 2px;
        }
        .inputfieldcontypenew_anp
        {
            float: left;
            width: 220px;
            margin-right: 40px;
            padding-top: 0px;
        }
          .inputfield_pdetails_anp
        {
            float: left;
            width: 210px;
            margin-right: 25px;
            padding-top: 0px;
        }
        .inputfield180px_anp  { float: left; width: 185px; margin-right: 45px; Font:bold 12px arial; color:#000; } 
        .inputfield300px_anp  { float: left; width: 300px; Font:bold 12px arial; color:#000; } 
        .inputfield480px_anp  { float: left; width: 458px; Font:bold 12px arial; color:#000; padding-left:22px; }  
        .inputfield140px_anp  { float: left; width: 140px; margin-right: 30px; Font:bold 12px arial; color:#000; }
        .inputfield110px_anp  { float: left; width: 110px; Font:bold 12px arial; color:#000; }
        .greybox_anp{ float: left; width: 500px; padding:10px; background-color:#eee; border:solid 1px #e6e6e6; } 
        .greybox_anp .row{ float: left; width: 480px; font-weight:bold;}
        

    </style>
    
    <style type="text/css">
    /*---------- bubble tooltip -----------*/
        a.tt{
            position:relative;
            z-index:24;
            color:#287AA8;
              font-weight:normal;
            text-decoration:underline;
        }
        a.tt span{ display: none; }
        /*background:; ie hack, something must be changed in a for ie to execute it*/
        a.tt:hover{ z-index:25; color: #ff6600;}
        a.tt:hover span.tooltip{
            display:block;
            position:absolute;
            top:0px; left:0;
              padding: 15px 0 0 0;
              width:200px;
              color: #287AA8;
            text-align: left;
              filter: alpha(opacity:90);
              KHTMLOpacity: 0.90;
              MozOpacity: 0.90;
              opacity: 0.90;
        }

        a.tt:hover span.top{
              display: block;
              padding: 30px 8px 0;
            background: url(/App/Images/bubble.gif) no-repeat top;
        }

        a.tt:hover span.middle{ /* different middle bg for stretch */
              display: block;
              padding: 0 8px; 
              background: url(/App/Images/bubble_filler.gif) repeat bottom; 
              color:#000;
              text-decoration:none;
        }

        a.tt:hover span.bottom{
              display: block;
              padding:3px 8px 10px;
              color: #ff6600;
            background: url(/App/Images/bubble.gif) no-repeat bottom;
        }
</style>
        
    <link href="../StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/Commonstyle.css" rel="Stylesheet" type="text/css" />
    <link href="../StyleSheets/UC.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/Coupon.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/App/JavascriptFiles/actb.js"></script>    
    <script type="text/javascript" src="/App/JavascriptFiles/common.js"></script>
    <script src="/App/JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>
    <script src="/App/JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>" language="javascript" type="text/javascript"></script>
    <script src="/App/JavascriptFiles/gridcommon.js" language="javascript" type="text/javascript"></script>
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

    function AllowNumericOnly(evt) {
        return KeyPress_DecimalAllowedOnly(evt);

    }
    
    function CloseWindow()
    {
        window.close();
        
        if (window.opener && !window.opener.closed)
        {
            window.opener.location.reload();
        }
    }

    function CancelWindow()
    {
        window.close();
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
 
 function ValidateInputs() 
 {
        
        var txtOrgName = document.getElementById("<%=txtOrgName.ClientID %>");
        var txtEmail = document.getElementById("<%=txtEmail.ClientID %>");

        if (isBlank(txtOrgName, 'Prospect Name'))
            return false;

        if (txtEmail.value != '')
        {
            if (validateEmail(txtEmail, "Email") != true)
            {
                return false;
            }
        }
        
        if(document.getElementById('<%= this.hidProspectType.ClientID %>').value == 'host')
        {
            if(isBlank(document.getElementById('<%= this.txtaddress1Billing.ClientID %>'), 'Address1 for Organization '))
                return false;
                
            if(isBlank(document.getElementById('<%= this.txtcityBilling.ClientID %>'), 'City for Organization  '))
                return false;    
                                
            if(checkDropDown(document.getElementById('<%= this.ddlstateBilling.ClientID %>'),"State for Organization ")==false)  
                {return false;}     
            
            if(isBlank(document.getElementById('<%= this.txtzipBilling.ClientID %>'), 'Zip for Organization '))
                return false;
            
            var chkMailingAddress = document.getElementById("<%=this.chkMailingAddress.ClientID %>");         
            if(chkMailingAddress.checked==true)
            {
                if(isBlank(document.getElementById('<%= this.txtaddress1Mailing.ClientID %>'), 'Mailing Address1 '))
                    return false;
                    
                if(isBlank(document.getElementById('<%= this.txtcityMailing.ClientID %>'), 'Mailing City '))
                    return false;
                    
                if(checkDropDown(document.getElementById('<%= this.ddlstateMailing.ClientID %>'),"Mailing State ")==false)  
                    {return false;}    
                                
                if(isBlank(document.getElementById('<%= this.txtzipMailing.ClientID %>'), 'Mailing Zip '))
                    return false;
            }
                
            if (document.getElementById('<%= this.txtcphoneoffice.ClientID %>').value=='(___)-___-____')
            {
                alert('Phone can not left blank ');
                document.getElementById('<%= this.txtcphoneoffice.ClientID %>').focus();
                return false;
            }
            
            if(isBlank(document.getElementById('<%= this.txtcphoneoffice.ClientID %>'), 'Phone Main'))
               return false;
             
            if(!checkDropDown(document.getElementById('<%= this.ddlHostType.ClientID %>'), 'Host Type'))
               return false;
            
            if(isBlank(document.getElementById('<%= this.txtActualMembers.ClientID %>'), 'Host Actual Members'))
               return false;

            var chkPaymentMethod = document.getElementById("<%=this.chkPaymentMethod.ClientID %>");
        
            if(chkPaymentMethod.rows[0].cells[0].childNodes[0].checked == true)
            {
                if(isBlank(document.getElementById('<%= this.txtFacilitiesFee.ClientID %>'), 'Host Facilities Fee'))
                    return false;  
            }                           
        }
        
        if((document.getElementById('<%= this.txtEmail.ClientID %>')).value != '')
        {      
            if(validateEmail(document.getElementById('<%= this.txtEmail.ClientID %>'), "Email")!=true)
            {
               return false;
            }
        }
        
        
    }
</script>
<script language="javascript" type="text/javascript">

    function OpenMandatoryfields()
    {
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
        document.getElementById('spmembers').innerHTML = document.getElementById('spmembers').innerHTML.replace('Members/Employees:', 'Members/Employees:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spfeefacility').innerHTML = document.getElementById('spfeefacility').innerHTML.replace('Any fee to use facility:', 'Any fee to use facility:<span class="reqiredmark"><sup>*</sup></span>');
        document.getElementById('spfee').innerHTML = document.getElementById('spfee').innerHTML.replace('Fee($):', 'Fee($):<span class="reqiredmark"><sup>*</sup></span>');        
    }
</script>
</head>
<body>    
   <form id="form1" runat="server">
     <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true"/>   
   <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       </div>
   <asp:HiddenField ID="hidProspectType" runat="server" />
 <asp:Panel ID="pnlEditProspect" Width="780px" Height="450px"  runat="server" DefaultButton="ibtnSaveProspect" >
  <div class="mainbody_outer" style="margin:0px; padding:0px; background-color:#fff;">
            <div class="mainbody_inner">
                <div class="main_area_bdrnone">
                    <div class="headingbox_top_body">
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" alt="" /></p>
                        <span class="orngheadtxt_heading" id="gridtitle" runat="server">Create New Prospect</span>
                        <span class="rightclosebtn_crlist">
                            
                        </span>
                    </div>
                </div>
                <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                    runat="server">
                </div>
                              
                <div class="main_area_bdrnone" style="margin-top: 0px;">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                    <div id="Div1" class="pgnosymbolvsmall_common" runat="server">
                        <img src="/App/Images/page1symbolvsmall.gif" /></div>
                    <div class="orngheadtxt16_common" id="spnProspectHostTitle" runat="server">
                        Prospect</div>
                </div>
                <div class="main_area_bdrnone">
                    <div class="maindivpagemainrow_anp">
                      <p class="pagemainrow_anp">
                            <span class="titletext_anp"> Name:<span class="reqiredmark"><sup>*</sup></span>
                             <asp:TextBox ID="txtOrgName" runat="server" CssClass="inputf_anp" Width="645px"></asp:TextBox>
                            </span>                           
                        </p>
                        <p class="pagemainrow_anp">
                        <span id="spaddress" class="titletext1_anp">Address:
                         <asp:TextBox ID="txtaddress1Billing" runat="server" CssClass="inputf_anp" Rows="1"
                                Width="645px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                        <span class="titletext1_anp">Suite,Apt,etc:<asp:TextBox ID="txtaddress2Billing" runat="server"
                            CssClass="inputf_anp" Width="645px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                        <span id="spcity" class="inputfield180px_anp">City:
                            <asp:TextBox ID="txtcityBilling" runat="server" CssClass="inputf_anp" Width="185px"></asp:TextBox></span>
                        <span id="spstate" class="inputfield180px_anp">State:<asp:DropDownList
                            ID="ddlstateBilling" runat="server" Width="185px" CssClass="list_anp" AutoPostBack="False">
                        </asp:DropDownList>
                        </span>
                        <span id="spzip" class="inputfield180px_anp">Zip:<asp:TextBox ID="txtzipBilling" runat="server"
                                CssClass="inputf_anp" Width="185px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="orngbold12_default" style="float: left; width: 150px; padding-top:5px;">Prospect Mailing Address:</span>
                                <span class="titletextnowidth_default"><asp:CheckBox ID="chkMailingAddress" runat="server" /></span>
                                    <span style="float:left; padding-top:4px">(if different from above)</span>
                                
                        </p>
                        <div style="float:left;display:none" id="divMailingAddress" runat="server">
                            <%--Begin Mailing Address--%>
                             <p class="pagemainrow_anp">
                                <span id="spmailaddress" class="titletext_anp">Address:<asp:TextBox ID="txtaddress1Mailing" runat="server"
                                        CssClass="inputf_anp" Rows="1" Width="645px"></asp:TextBox></span>
                            </p>
                            <p class="pagemainrow_anp">
                                <span class="titletext_anp">Suite,Apt,etc:<asp:TextBox ID="txtaddress2Mailing" runat="server"
                                    CssClass="inputf_anp" Width="645px"></asp:TextBox></span>
                            </p>
                            <p class="pagemainrow_anp">
                                <span id="spmailcity" class="inputfield180px_anp">City:<asp:TextBox ID="txtcityMailing" runat="server"
                                        CssClass="inputf_anp" Width="185px"></asp:TextBox></span> 
                                <span id="spmailstate" class="inputfield180px_anp">State:
                                    <asp:DropDownList ID="ddlstateMailing" runat="server" Width="185px" CssClass="list_anp" AutoPostBack="False">
                                            </asp:DropDownList>
                                        </span><span id="spmailzip" class="inputfield180px_anp">Zip:<asp:TextBox ID="txtzipMailing" runat="server"
                                                CssClass="inputf_anp" Width="185px"></asp:TextBox>
                                        </span>
                            </p>
                            <%--End Mailing Address--%>
                        </div>
                        <p class="pagemainrow_anp">
                            <span id="spphonemain" class="inputfield180px_anp">Phone(Main):<asp:TextBox ID="txtcphoneoffice" runat="server" CssClass="inputf_anp mask-phone" Width="185px"></asp:TextBox></span>
                           
                            
                            <span class="inputfield300px_anp">Website:<asp:TextBox
                                ID="txtwebaddress" runat="server" CssClass="inputf_anp" Width="300px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="inputfield180px_anp">Fax:<asp:TextBox ID="txtFax" runat="server" CssClass="inputf_anp mask-phone" Width="185px"></asp:TextBox></span>
                     
                            <span class="inputfield300px_anp">Email (General):<asp:TextBox
                                ID="txtEmail" runat="server" CssClass="inputf_anp" Width="300px"></asp:TextBox></span>
                        </p>
                    
                        <%--<span class="titletext1_anp">Method Obtained:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldrightcon_anp">
                                <asp:DropDownList ID="ddlMethodObtained" runat="server" CssClass="inputf_anp" Width="150px">
                                </asp:DropDownList>
                            </span>
                        </p>--%>
                    </div>
                </div>
                
                
                <div class="main_area_bdrnone" style="margin-top: 0px;">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                    <div id="Div3" class="pgnosymbolvsmall_common" runat="server">
                        <img src="/App/Images/page2symbolvsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Prospect Details</div>
                </div>
                <div class="main_area_bdrnone">
                    <div class="maindivpagemainrow_anp">
                       <div id="divPrimaryContact">
                            <p class="pagemainrow_anp">
                            <span id="sptype" class="titletext_anp">Type:<asp:DropDownList ID="ddlHostType" runat="server" CssClass="inputf_anp" Width="645px">
                                </asp:DropDownList></span>
                            </p>
                            <p class="pagemainrow_anp">
                            <span class="inputfield180px_anp" id="spmembers">Members/Employees: <asp:TextBox ID="txtActualMembers" runat="server" MaxLength="10" CssClass="inputf_anp" Width="185px"></asp:TextBox></span>
                            <span class="inputfield180px_anp">Attendance: <asp:TextBox ID="txtAttendence" runat="server" MaxLength="10" CssClass="inputf_anp" Width="185px"></asp:TextBox></span>
                            
                            </p>
                            
                             <p class="pagemainrow_anp">
                                <span class="titletextnowidth_default" id="spfeefacility">Any fee to use facility:</span>
                                    <span class="ttxtnowidthnormal_default" style="margin-right:25px; padding-top:0px;">
                                    <asp:RadioButtonList ID="rbtnFeeRequired" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="1" ></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList></span>
                            </p>
                            
                             <div id="divFee" runat="server" style="display: none;float:left;width:718px">
                             <fieldset style="margin: 0px; padding: 0px;">
                                <legend class="legendhead_default">Fee Details</legend>
                                <div style="float:left;width:718px">
                              <p class="pagemainrow_anp">
                                <span class="titletext_anp" id="spfee">
                                    Fee($): </span><span class="inputfield_pdetails_anp">
                                    <asp:TextBox ID="txtFacilitiesFee" runat="server" CssClass="inputf_anp" 
                                        MaxLength="10" Width="185px"></asp:TextBox>
                                    </span>
                                </p>
                            <p class="pagemainrow_anp">
                                <span class="titletext_anp">Payment Method:</span>
                                    <span class="inputfield_pdetails_anp">
                                    <asp:CheckBoxList ID="chkPaymentMethod" runat="server" RepeatDirection="Horizontal">
                                     <asp:ListItem Text="Check" Value="1" ></asp:ListItem>
                                     <asp:ListItem Text="CreditCard" Value="2"></asp:ListItem>   
                                     </asp:CheckBoxList>
                                    </span>                               
                            </p>
                             <p class="pagemainrow_anp">
                             <span class="titletextnowidth_default">Deposits Required:</span>
                                    <span class="ttxtnowidthnormal_default" style="margin-right:25px; padding-top:0px;">
                                    <asp:RadioButtonList ID="rbtnDepositsRequired" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0" ></asp:ListItem>
                                    </asp:RadioButtonList></span>
                                    <span id="spnDepositeAmount" runat="server" style="float:left">
                                    <span  class="titletextsmallbld_default" id="spnAmount" runat="server">Amount($): </span>
                                    <span  class="titletextnowidth_default"><asp:TextBox ID="txtAmount" runat="server" MaxLength="12" Width="100px" CssClass="inputf_anp"></asp:TextBox></span>
                                    </span>
                             </p>
                              </div>
                                </fieldset>
                                </div>
                            <p class="pagemainrow_anp">
                                <span class="inputfield140px_anp">Will Promote:<asp:DropDownList ID="ddlFeederPromotionStatus" runat="server" Width="140px">
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Unknown" Value="2" Selected="True"></asp:ListItem>
                                    </asp:DropDownList></span> 
                                <span class="inputfield140px_anp">Will Host:<asp:DropDownList ID="ddlhostStatus" runat="server" Width="140px">
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Unknown" Value="2"></asp:ListItem>
                                    </asp:DropDownList></span> 
                              <span class="inputfield140px_anp">Viable Host Site:<asp:DropDownList ID="ddlViableHost" runat="server" Width="140px">
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Unknown" Value="2" Selected="True"></asp:ListItem>
                                    </asp:DropDownList></span>
                                <span class="inputfield140px_anp" style="margin-right:0px;">Hosted In Past:<asp:DropDownList ID="ddlHostedInPast" runat="server" Width="140px">
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Unknown" Value="2" Selected="True"></asp:ListItem>
                                    </asp:DropDownList></span>     
                                    
                            </p>
                            
                           <p class="pagemainrow_anp">
                             <span style="float:left; width:680px">
                             <span style="float:left; width:510px">
                             <span style="float:left; width:340px">
                             <span style="float:left; width:170px">
                             
                                <span  class="inputfield140px_anp"><span class="inputfield140px_anp" id="spWillPromote" runat="server" style="display:none">Reason:<asp:TextBox ID="txtWillPromote" runat="server" TextMode="MultiLine" Height="50px" Width="134px" ></asp:TextBox></span></span>
                             </span>
                             <span style="float:right;width:170px">
                                <span  class="inputfield140px_anp"><span class="inputfield140px_anp" id="spWillHost" runat="server" style="display:none">Reason:<asp:TextBox ID="txtWillHost" runat="server" TextMode="MultiLine" Height="50px" Width="134px" ></asp:TextBox></span></span>
                             </span>
                             </span>
                             <span style="float:right; width:170px">
                                <span  class="inputfield140px_anp"><span class="inputfield140px_anp" id="spViableHostSite" runat="server" style="display:none">Reason:<asp:TextBox ID="txtViableHostSite" runat="server" TextMode="MultiLine" Height="50px" Width="134px" ></asp:TextBox></span></span>
                             </span>
                                </span>
                                <span style="float:right; width:170px">
                                <span  class="inputfield140px_anp"><span class="inputfield140px_anp" id="spHostInPast" runat="server" style="display:none;margin-right: 0px;">Reason:<asp:TextBox ID="txtHostInPast" runat="server" TextMode="MultiLine" Height="50px" Width="134px" ></asp:TextBox></span>
                                <span class="" id="spnHostedInPast" runat="server" style="display: none; float: left; width: 150px">
                                    <asp:TextBox ID="txtHostedInPast" runat="server" CssClass="inputf_anp" Width="135px"></asp:TextBox>
                                    <span style="float: left; padding-top: 5px; font: normal 7pt arial"><i>Type in some
                                        words to get the list</i></span> </span>
                                </span>
                                </span>
                                </span>
                            </p>
                          <%--   <p class="pagemainrow_anp" style="display:block; width:660px;">
                                  <span class="" id="spnHostedInPast" runat="server" style="display:none; float:right; width:150px">
                                    <asp:TextBox ID="txtHostedInPast" runat="server" CssClass="inputf_anp" Width="135px"></asp:TextBox>
                                    <span style=" float:left; padding-top:5px; font:normal 7pt arial"><i>Type in some words to get the list</i></span>
                                    </span>
                            </p> --%>                   
                        </div>
                    </div>
                </div>
                
                <div class="main_area_bdrnone" style="margin-top: 0px;">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                    <div id="Div4" class="pgnosymbolvsmall_common" runat="server">
                        <img src="/App/Images/page3symbolvsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Notes</div>
                </div>            
                   
                <div class="main_area_bdrnone">
                    <div class="maindivpagemainrow_anp">
                        <p class="pagemainrow_anp">
                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" MaxLength="12" Rows="2" Width="645px" CssClass="inputf_anp"></asp:TextBox>
                        </p>
                    
                    </div>
                </div>
                
                   <div class="headbg2_box_anp">
                    <div class="cancel_button_anp">
                        <asp:ImageButton ID="ibtnSaveProspect" runat="server" CssClass="" ImageUrl="~/App/Images/save-button.gif"
                            OnClientClick="return ValidateInputs();" OnClick="ibtnSave_Click"/></div>
                    <div class="save_button1_anp">
                        <asp:ImageButton ID="ibtnCancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                          /></div>
                    </div>
                </div>
            </div>
            </asp:Panel>
      
    </form>
</body>
<script type="text/javascript" language="javascript">
    $(document).ready(function(){
    $('.mask-phone').mask('(999)-999-9999');
    });
    </script>
</html>

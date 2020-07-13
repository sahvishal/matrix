<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="True" CodeBehind="AddHospitalFacility.aspx.cs" Inherits="HealthYes.Web.App.Franchisor.HospitalPartner.AddHospitalFacility" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true"/>

<script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js" language="javascript"></script>
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
           .inputfielddatecon_amv
        {
            float: left;
            width: 180px;
            margin-right: 65px;
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
            padding-top: 5px;
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
    </style>
<script language="javascript" type="text/javascript">

    var pagenumber = 1;
    var pagesize = 10;
    var url ='';    
    var CampaignName='';
    function Validation()
    {
        var txtFacilityName= document.getElementById("<%= this.txtFacilityName.ClientID %>");
        var ddlMedicalVendor= document.getElementById("<%= this.ddlMedicalVendor.ClientID %>");
        var txtAddress1= document.getElementById("<%= this.txtAddress1.ClientID %>");
        var txtPhonePrimary= document.getElementById("<%= this.txtPhonePrimary.ClientID %>");
        var ddlState= document.getElementById("<%= this.ddlState.ClientID %>");
        var txtCity= document.getElementById("<%= this.txtCity.ClientID %>");
        var txtZip= document.getElementById("<%= this.txtZip.ClientID %>");
        
        
         
         // facility name can not be null
         if (isBlank(txtFacilityName,"Facility name"))
         {
            return false;
         }         
         // medical partner 
         else if (ddlMedicalVendor.value=='')
         {
            alert('Please select medical vendor');
            ddlMedicalVendor.focus();
            return false;
         }
         else if (isBlank(txtAddress1,"Address"))
         { return false;}
        
         else if (isBlank(txtPhonePrimary,"Phone Primary"))
         { return false;}
         else if(txtPhonePrimary.value=='(___)-___-____')
         { 
            alert('Phone Primary cannot be left blank');
            txtPhonePrimary.focus();
            return false;
         }
        else if(isBlank(txtCity,"City for address"))
        {
            return false;
        }
        else if (ddlState.value=='' || ddlState.value=="0")
        {
            alert('Please select state for address');
            ddlState.focus();
            return false;
        }
        else if (isBlank(txtZip,"Zipcode for address"))
         { return false;}
        
        if((document.getElementById('<%= this.txtEmail.ClientID %>')).value != '')
        {      
            if(validateEmail(document.getElementById('<%= this.txtEmail.ClientID %>'), "Email")!=true)
            {
               return false;
            }
        }
        return true;
     }
     
     function SelectCampaign(chkCampaign,CampaignId)
     {
       var hidCampaignID= document.getElementById("<%= this.hidCampaignID.ClientID %>");
        if(chkCampaign!=null)
        {
            
            if(chkCampaign.checked==true)
            {
                hidCampaignID.value = hidCampaignID.value + CampaignId + "," 
            }
            else 
            {
                var Campaign = hidCampaignID.value;
                if (Campaign.indexOf(CampaignId+",") >= 0)
                {
                    Campaign = Campaign.replace(CampaignId+",","");
                    hidCampaignID.value = Campaign;
                }
            }
            //alert(hidCampaignID.value);
        }
     }
     function SetCampaign(CampaignId)
     {
       var hidCampaignID= document.getElementById("<%= this.hidCampaignID.ClientID %>");
        if(CampaignId!=null)
        {
            hidCampaignID.value = hidCampaignID.value + CampaignId + "," 
        }
     }
     
     // -------------------------------------------------------------------------------------------------
	//  Begin Manage Host Async Call JS Code	
	// -------------------------------------------------------------------------------------------------
    
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        
        function requestFailed(){}
	
        function LoadCampaignTableonPageChange(selpagenumber)
        {
            pagenumber = selpagenumber;
            GetCampaignGridTable();
        }
        
        function GetCampaignGridTable()
        {
                document.getElementById('<%= this.divCampaign.ClientID %>').disabled='disabled';                
                GetUrl();
                postRequest.url = url;
	            postRequest.successCallback = SetGrid;
	            postRequest.failureCallback = requestFailed();
                postRequest.post("");
        }
        
        function GetUrl()
        {
        
            url="AsyncGetCampaign.aspx?type=campaign";
            // search details
            var hidFacilityId = document.getElementById("<%= this.hidFacilityId.ClientID %>");
            var ddlMedicalVendor = document.getElementById("<%= this.ddlMedicalVendor.ClientID %>");
            
            if (hidFacilityId.value!='')
            {
                url=url + "&facilityid=" + hidFacilityId.value;
            }
            else if (ddlMedicalVendor.value!='')
            {
                url=url + "&medicalvendorid=" + ddlMedicalVendor.value;
            }
            url=url + "&compaignname=" + CampaignName;
            url=url + "&pageno=" + pagenumber;
            url=url + "&pagesize=" + pagesize;
            //alert(url);
        }
        
        function SetGrid(httpRequest)
        {        
            
           var result= httpRequest.responseText;
           //alert(result); 
           if(result.indexOf('Some Error occured') > -1 )
            {
                document.getElementById('<%= this.divCampaign.ClientID %>').innerHTML = httpRequest.responseText;
            }
            else 
            {
                document.getElementById('<%= this.divCampaign.ClientID %>').innerHTML = httpRequest.responseText ;
            }
            //alert(httpRequest.responseText);
            document.getElementById('<%= this.divCampaign.ClientID %>').disabled = '';            
        }
        
	// -------------------------------------------------------------------------------------------------
	//  End Manage Host Async Call JS Code	
	// -------------------------------------------------------------------------------------------------
    </script>


<div class="mainbody_outer">
              
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Add/Edit Hospital Partner Facility</span>
                    <span class="headingright_default" style="padding-right:5px;"><a href="ManageHospitalPartnerFacility.aspx"
                    runat="server" id="lnkManageFacility">Manage Existing Facilities</a></span>
                </div>
                 <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                <p> <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
            </div>
            <div id="divErrorMsg" class="maindivredmsgbox" enableviewstate="false" style="display:none;"  runat="server">
            </div>
            <div class="main_area_bdrnone" style="margin-top: 0px;">
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                <div id="Div1" class="pgnosymbolvsmall_common" runat="server">
                    <img src="/App/Images/page1symbolvsmall.gif" /></div>
                <div class="orngheadtxt16_common">
                    Facility Basic Information</div>
            </div>
           <div class="main_area_bdrnone">
             <div class="maindivpagemainrow_anp">
                 <p class="pagemainrow_anp">
                    <span class="titletext_anp">Name of Facility:<span class="reqiredmark"><sup>*</sup> </span></span>
                    <span class="inputfieldcon_prospect"><asp:TextBox ID="txtFacilityName" runat="server" CssClass="inputf_amv" Width="170px"></asp:TextBox></span>
                    <span class="titletext_anp">Medical Vendor:<span class="reqiredmark"><sup>*</sup> </span></span>
                    <span class="inputfieldcon_prospect">
                         <asp:DropDownList ID="ddlMedicalVendor" runat="server" CssClass="inputf_amv" Width="175px">                         
                         </asp:DropDownList>
                    </span>
                 </p>
                 <p class="pagemainrow_anp">
                        <span class="titletext_anp">Address:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_prospect"> <asp:TextBox ID="txtAddress1" runat="server" Width="170px" CssClass="inputf_afse" TextMode="multiLine"></asp:TextBox></span>
                        <span class="titletext_anp">Phone Primary:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputfieldrightcon_anp"><asp:TextBox ID="txtPhonePrimary" runat="server" Width="110px" CssClass="inputf_afse mask-phone" ></asp:TextBox>
                        </span>
                  </p>
                   <p class="pagemainrow_anp">
                           <span class="titletext_anp">Suite,Apt,etc:</span>
                           <span class="inputfieldcon_prospect"> <asp:TextBox ID="txtAddress2" runat="server" Width="170px" CssClass="inputf_afse"></asp:TextBox></span>
                            <span class="titletext_anp">Phone Cell:</span>
                            <span class="inputfieldrightcon_anp"> <asp:TextBox ID="txtPhoneCell" runat="server" Width="110px" CssClass="inputf_afse mask-phone"></asp:TextBox></span>
                   </p>
                   <p class="pagemainrow_anp">
                           <span class="titletext_anp">City:<span class="reqiredmark"><sup>*</sup> </span></span>
                           <span class="inputfieldcon_prospect">
                            <asp:TextBox ID="txtCity" runat="server"  Width="170" CssClass="inputf_afse auto-search-city"></asp:TextBox>
                           </span>
                   </p>
                    <p class="pagemainrow_anp">
                            <span class="titletext_anp">State:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldcon_prospect">
                            <asp:DropDownList ID="ddlState" runat="server" Width="175px" CssClass="inputf_accm" AutoPostBack="False"> </asp:DropDownList>
                            </span>
                    </p>
                     <p class="pagemainrow_anp">
                              <span class="titletext_anp">Zip:<span class="reqiredmark"><sup>*</sup></span></span>
                              <span class="inputfieldcon_prospect"> <asp:TextBox ID="txtZip" runat="server" Width="170" CssClass="inputf_afse"></asp:TextBox></span>
                     </p>
                     <p class="pagemainrow_anp">
                              <span class="titletext_anp">Email:</span>
                              <span class="inputfieldcon_prospect"> <asp:TextBox ID="txtEmail" runat="server" Width="170" CssClass="inputf_afse"></asp:TextBox></span>
                     </p>
             </div>
           </div>
           <div class="main_area_bdrnone" style="margin-top: 0px;">
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                <div id="Div2" class="pgnosymbolvsmall_common" runat="server">
                    <img src="/App/Images/page2symbolvsmall.gif" /></div>
                <div class="orngheadtxt16_common"> Associated Campaigns</div>
            </div>
            <p> <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
            <%--Begin Main Div For Campaign--%>
                <div style="float:left; width:746px" id="divCampaign" runat="server">
                </div>
                <%--End Main Div For Campaign--%>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtnsave" runat="server" CssClass="" ImageUrl="~/App/Images/save-button.gif"
                        OnClientClick="return Validation();" onclick="ibtnsave_Click" />
                </div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtncancel" runat="server" CssClass="" 
                        ImageUrl="~/App/Images/cancel-button.gif" onclick="ibtncancel_Click"
                        />
                </div>
            </div>
        </div>
    </div>

<asp:HiddenField runat="server" ID="hfCountryID" />
<asp:HiddenField runat="server" ID="hidCampaignID" />
<asp:HiddenField runat="server" ID="hidMedicalVendorId" />
<asp:HiddenField runat="server" ID="hidFacilityId" />

<script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
    
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

</asp:Content>
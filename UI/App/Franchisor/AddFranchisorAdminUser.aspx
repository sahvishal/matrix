<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="Franchisor_AddFranchisorAdminUser"
    EnableEventValidation="false" Codebehind="AddFranchisorAdminUser.aspx.cs" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>

<%@ Register Src="../UCCommon/ucupdatephotopanel.ascx" TagName="ucupdatephotopanel"
    TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true"/>

<style type="text/css">
.mainbody_outer_fcr{ float:right; width:777px; background-color:#fff; margin-top:5px; }.mainbody_inner_fcr{ width:763px; margin-left:14px; margin-bottom:5px}
.mainbody_inner_fcr{ width:763px; margin-left:14px; margin-bottom:5px}
.main_area_bdr_Editdata_fcr{ float:left; width:753px; border:1px solid #E5E5E5; margin-top:5px;}
.main_content_area_fcr{ float:left; width:745px; padding-bottom:5px;}
.headbg_boxtop_editp{ float:left; width:753px; background-color:#E1F1F8; height:24px; margin-bottom:0px; }
.head_text_editp{ float:left; width:740px; padding-left:10px; padding-top:5px; padding-bottom:5px; font:bold 12px arial; color:#000000;}
.input_area_fcr{  width:700px;  margin-top:5px; margin-bottom:10px;  margin-left:10px; border: 1px solid #7F9DB9; Background-color:#fff; font: normal 12px arial; color:#333; padding:2px; }
.main_container_row_editp{ float:left; width:734px; padding-left:10px; padding-top:3px; padding-right:5px; padding-bottom:3px;}
.titletext_editp{ float:left; width:110px; margin-right:5px; padding-top:3px; font:bold 12px arial; color:#000;}
.inputfieldrightcon_editp{ float:left; width:180px; font:normal 12px arial; color:#000; font:bold 12px arial; color:#000;}
.inputfieldcon_editp{ float:left; width:180px; margin-right:85px; padding-top:0px; font:bold 12px arial; color:#000;}
.inputfieldob_editp{ float:left; width:100px;}
.calendarcntrl_editp{float:left; width:20px; padding-left:10px; padding-top:5px; }
.main_containerreff2_row_amv{ float:left; width:734px; padding-left:10px; padding-right:5px; padding-bottom:5px;}

</style>

    <script language="JavaScript" type="text/javascript">
        function load() 
        {
            var load = window.open('PhotoManagement.aspx','','scrollbars=no,menubar=no,height=600,width=500,resizable=no,toolbar=no,location=no,status=no');
        }
       
        function Validation()
        { 
          //debugger
         ///Contact Person Details 
         var txtfname= document.getElementById("<%= this.txtfname.ClientID %>");
         var txtlname= document.getElementById("<%= this.txtlname.ClientID %>");
         var txtaddress1= document.getElementById("<%= this.txtaddress1.ClientID %>");
         
         var txtCity= document.getElementById("<%= this.txtCity.ClientID %>");
         var ddlState= document.getElementById("<%= this.ddlstate.ClientID %>");

         var txtzip1= document.getElementById("<%= this.txtzip1.ClientID %>");
         //var txtSSN= document.getElementById("<%= this.txtSSN.ClientID %>");
         //var txtphonehome= document.getElementById("<%= this.txtphonehome.ClientID %>");
         //var txtphoneother= document.getElementById("<%= this.txtphoneother.ClientID %>");
         //var txtphonecell= document.getElementById("<%= this.txtphonecell.ClientID %>");
         var txtDOB= document.getElementById("<%= this.txtDOB.ClientID %>");
         var txtEmail1= document.getElementById("<%= this.txtEmail1.ClientID %>");
       //  var txtEmail2= document.getElementById("<%= this.txtEmail2.ClientID %>");
         
         if (isBlank(txtfname,"First Name")                 ||
             isBlank(txtlname,"Last Name")                  || 
             isBlank(txtaddress1,"Address")                ||
             isBlank(txtEmail1,"Email")                ||
             isBlank(txtCity,"City")                ||
             isBlank(document.getElementById("<%=this.txtzip1.ClientID %>"),"Zip")                ||
             isBlank(txtDOB,"Date of Brith"))
         {return false;}
         
         if(ValidateDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
          if(checkDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
        if (checkLength(txtaddress1,500,"Address1"))
         {return false;}
        
         
          if ( checkDropDown(ddlState,"state for  Address")==false)
         {return false;}

         if ((validateEmail(txtEmail1, "Email")!=true))
         {return false;}
        }
  

    </script>

   <asp:HiddenField runat="server" ID="hfCountryID" />
   
    <div class="mainbody_outer_fcr">
        <div class="mainbody_inner_fcr">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Add New Franchisor Admin User</span>
                </div>
            </div>        
            <%--<div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
                <div class="mainbody_titletxtleft">
                    Add new Franchisor Admin User</div>
            </div>
            <div class="mainbody_inner_right">
            </div>--%>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr_Editdata_fcr">
                <div class="main_content_area_fcr">
                    <%--<div class="headbg_box_fcr">
                 
                        
                            <div class="head_text_fcr">
                                About Franchisor <asp:HiddenField runat="server" ID="hfcityid" />
                                <asp:HiddenField runat="server" ID="hfstateid" />
                                </div>
                        </div>--%>
                    <div class="headbg_boxtop_editp">
                        <div class="head_text_editp">
                            About Franchisor</div>
                    </div>
                    <%--<div class="uploadresumelnk_editp"> <a href="#"> Upload Resume</a></div>--%>
                    <div class="about_txt_area" style="display:none; visibility:hidden;">
                        <asp:TextBox ID="txtabtmself" runat="server" CssClass="input_area_fcr" Enabled="False"
                            Text="With a twist to the common list of habits that are useful to establish, here are 7 habits that you do best to avoid. Just like finding habits that can be useful for you it’s important to find the habits that are holding you back. They can easily become such a normal, everyday part of life that you hardly notice it (or how it’s affecting you)."
                            Rows="4" TextMode="multiLine"></asp:TextBox>
                    </div>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">First Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtfname" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox></span>
                        <span class="titletext_editp">Middle Name: </span><span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Last Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtlname" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">SSN: </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtSSN" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox></span>
                        <span class="titletext_editp">Date of Birth:<span class="reqiredmark"><sup>*</sup> </span>
                        </span>
                        <span class="inputfieldob_editp">
                            <asp:TextBox ID="txtDOB" runat="server" CssClass="inputf_editp date-picker-dob" Enabled="true" Width="100px"></asp:TextBox>
                            <span style="font-size:7pt;">mm/dd/yyyy</span>
                        </span>
                        
                    </p>
                    <div class="headbg_boxtop_editp">
                        <div class="head_text_editp">
                            Contact Details</div>
                    </div>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Address:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtaddress1" runat="server" CssClass="inputf_editp" TextMode="multiLine"
                                Width="170px"></asp:TextBox></span> <span class="titletext_editp">Phone (Cell):</span>
                        <span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtphonecell" runat="server" CssClass="inputf_editp mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_editp">
                       <span class="titletext_editp">City:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_editp">  <asp:TextBox ID="txtCity" runat="server" CssClass="inputf_accm auto-search-city"></asp:TextBox></span>
                       <span class="titletext_editp">Phone (Home): </span><span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtphonehome" runat="server" CssClass="inputf_editp mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>--%>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">State:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfieldcon_editp"> <asp:DropDownList ID="ddlstate" runat="server" CssClass="inputf_accm" Width="120px"
                                AutoPostBack="False"></asp:DropDownList></span><span class="titletext_editp">Phone (Other): </span><span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtphoneother" runat="server" CssClass="inputf_editp mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_editp">
                     <span class="titletext_editp">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfieldcon_editp"><asp:TextBox ID="txtzip1" runat="server" CssClass="inputf_accm" Width="100"></asp:TextBox></span>
                        <span class="titletext_editp">Email:<span class="reqiredmark"><sup>*</sup>
                            </span></span><span class="inputfieldrightcon_editp">
                                <asp:TextBox ID="txtEmail1" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                            </span>
                        <asp:HiddenField ID="hfstateid" runat="server"></asp:HiddenField>
                    </p>
                    <p class="main_container_row_editp">
                       <span class="titletext_editp">Other Email: </span>
                        <span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtEmail2" runat="server" CssClass="inputf_editp" Width="170px"></asp:TextBox>
                        </span>
                        <asp:HiddenField ID="hfcityid" runat="server"></asp:HiddenField>
                        <%--</p></contenttemplate>
                </asp:UpdatePanel>--%>
                        <p class="main_container_row_editp">
                            <span class="titletext_editp"></span>
                            <span class="inputfieldcon_editp">
                                
                            </span>
                        </p>
                    <div class="headbg_boxtop_editp">
                        <div class="head_text_editp">
                            Photo</div>
                    </div>
                    <p class="main_containerreff2_row_amv">
                        <uc1:ucupdatephotopanel ID="Ucupdatephotopanel1" runat="server" />
                    </p>
                </div>
            </div>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtnsave" runat="server" CssClass="" ImageUrl="../Images/save-button.gif"
                        OnClientClick="return Validation()" OnClick="ibtnsave_Click" /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="ibtncancel" runat="server" CssClass="" ImageUrl="../Images/cancel-button.gif"
                        OnClick="ibtncancel_Click" /></div>
            </div>
        </div>
    </div>
    
    <script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
    
        $('.auto-search-city').autoComplete({
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

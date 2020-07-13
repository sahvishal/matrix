<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="Franchisor_UpdateFranchisorData"
    Title="Untitled Page" EnableEventValidation="false" Codebehind="UpdateFranchisorData.aspx.cs" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true"/>

<style type="text/css">
.mainbody_outer_fcr{ float:right; width:777px; background-color:#fff; margin-top:5px; }
.mainbody_inner_fcr{ width:763px; margin-left:14px; margin-bottom:5px}
.main_area_bdr_Editdata_fcr{ float:left; width:753px; border:1px solid #E5E5E5; margin-top:5px;}
.main_content_area_fcr{ float:left; width:745px; padding-bottom:5px;}
.input_area_fcr{  width:700px;  margin-top:5px; margin-bottom:10px;  margin-left:10px; border: 1px solid #7F9DB9; Background-color:#fff; font: normal 12px arial; color:#333; padding:2px; }

</style>

    <script language="JavaScript" type="text/javascript">
        function load() 
        {
            var load = window.open('PhotoManagement.aspx','','scrollbars=no,menubar=no,height=600,width=500,resizable=no,toolbar=no,location=no,status=no');
        }

        function Validation()
     { //debugger
         ///Contact Person Details 
         var txtfname= document.getElementById("<%= this.txtfname.ClientID %>");
         var txtlname= document.getElementById("<%= this.txtlname.ClientID %>");
         var txtaddress1= document.getElementById("<%= this.txtaddress1.ClientID %>");
         var txtAddress2= document.getElementById("<%= this.txtAddress2.ClientID %>");
         var txtCity= document.getElementById("<%= this.txtCity.ClientID %>");
         var ddlState= document.getElementById("<%= this.ddlState.ClientID %>");
        
         var txtzip1= document.getElementById("<%= this.txtzip1.ClientID %>");
         var txtSSN= document.getElementById("<%= this.txtSSN.ClientID %>");
         var txtphonehome= document.getElementById("<%= this.txtphonehome.ClientID %>");
         var txtphoneother= document.getElementById("<%= this.txtphoneother.ClientID %>");
         var txtphonecell= document.getElementById("<%= this.txtphonecell.ClientID %>");
         var txtDOB= document.getElementById("<%= this.txtDOB.ClientID %>");
         var txtEmail1= document.getElementById("<%= this.txtEmail1.ClientID %>");
         var txtEmail2= document.getElementById("<%= this.txtEmail2.ClientID %>");
         
         if (isBlank(txtfname,"First Name")                 ||
             isBlank(txtlname,"Last Name")                  || 
             isBlank(txtaddress1,"Address1")                ||
             isBlank(txtDOB,"Date of Brith"))
         {return false;}
         
         if(ValidateDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
         if(checkDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
         
         if (checkLength(txtaddress1,500,"Address1")         ||
             checkLength(txtAddress2,500,"Address2"))
         {return false;}
        
         
          if ((checkDropDown(ddlState,"State for  Address")==false)      ||
              (isBlank(txtCity,"City for  Address")) )
         {return false;}
        
       if (isBlank(txtEmail1,"Email")){return false;}
         if ((validateEmail(txtEmail1, "Email")!=true)  )
         {return false;}
        
         if (txtEmail2.value !="")
         {
          if ((validateEmail(txtEmail2, "Other Email")!=true)  )
         {return false;}
         }
         
          if ((isInteger(txtzip1, "Zip")!=true)     )
         {return false;}
         
         var txtPassword=document.getElementById("<%=this.txtPassword.ClientID %>");
         var txtCnfrmPassword=document.getElementById("<%=this.txtCnfrmPassword.ClientID %>");
         if(txtPassword.value!="" || txtCnfrmPassword.value!="")
         {
            if(txtPassword.value.length < 8)
            {
                alert("Password length can not be less than 8 characters.");
                return false;
            }
            if(txtPassword.value != txtCnfrmPassword.value)
            {
                alert("Confirm Password should be same as Password.");
                return false;
            }
            
            //checks string contains numeric and alphanumeric both
            var IsContainNumeric=false;
            var IsContainAlphanumeric=false;
            for(var i=0; i<txtPassword.value.length; i++)
            {
                var singleChar=txtPassword.value.charAt(i);
                var singleCharCode=singleChar.charCodeAt(0);
                if(singleCharCode>47 && singleCharCode<58)
                {
                    IsContainNumeric=true;
                }
                
                if((singleCharCode>64 && singleCharCode<91)||(singleCharCode>96 && singleCharCode<123))
                {
                    IsContainAlphanumeric=true;
                }
            }
            if((!IsContainNumeric) || (!IsContainAlphanumeric))
            {
                alert("Password should contain at least one alphabet and one numeric ");
                return false;
            }
         }
     }
   
    </script>
<asp:HiddenField ID="hfCountryID" runat="server" />

    <div class="mainbody_outer_fcr">
        <div class="mainbody_inner_fcr">
        
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Edit Profile</span>
                    <span class="headingright_default"></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="main_area_bdr_Editdata_fcr">
                <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>--%>
                <div class="main_content_area_fcr">
                    <div class="headbg_boxtop_editp">
                        <div class="head_text_editp">
                            About Franchisor</div>
                    </div>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">First Name:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtfname" runat="server" CssClass="inputf_editp" Width="170px" MaxLength="500"></asp:TextBox></span>
                        <span class="titletext_editp">Middle Name: </span><span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="inputf_editp" Width="170px"
                                MaxLength="500"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Last Name:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtlname" runat="server" CssClass="inputf_editp" Width="170px" MaxLength="500"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">SSN: </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtSSN" runat="server" CssClass="inputf_editp" Width="170px" MaxLength="500"></asp:TextBox></span>
                        <span class="titletext_editp">Date of Birth:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldob_editp">
                            <asp:TextBox ID="txtDOB" runat="server" CssClass="inputf_editp date-picker-dob" Width="100px" MaxLength="500"
                                Enabled="true"></asp:TextBox>
                            <span style="font-size:7pt;">mm/dd/yyyy</span></span>
                        
                    </p>
                    <div class="about_txt_area" style="display:none;">
                        <asp:TextBox ID="txtabtmself" runat="server" CssClass="input_area_fcr" Text="With a twist to the common list of habits that are useful to establish, here are 7 habits that you do best to avoid. Just like finding habits that can be useful for you it’s important to find the habits that are holding you back. They can easily become such a normal, everyday part of life that you hardly notice it (or how it’s affecting you)."
                            Rows="4" TextMode="multiLine">
                        </asp:TextBox>
                    </div>
                    <div class="headbg_boxtop_editp">
                        <div class="head_text_editp">
                            Contact Details</div>
                    </div>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Address1:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtaddress1" runat="server" CssClass="inputf_editp" Width="170px"
                                MaxLength="500" TextMode="multiLine"></asp:TextBox></span> <span class="titletext_editp">
                                    Phone (Cell):</span> <span class="inputfieldrightcon_editp">
                                        <asp:TextBox ID="txtphonecell" runat="server" CssClass="inputf_editp mask-phone" MaxLength="500"></asp:TextBox>
                                    </span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Suite,Apt,etc:</span><span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputf_editp" Width="170px"
                                MaxLength="500"></asp:TextBox>
                        </span><span class="titletext_editp">Phone (Home): </span><span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtphonehome" runat="server" CssClass="inputf_editp mask-phone" MaxLength="500"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_editp">
                     <span class="titletext_editp">City:<span class="reqiredmark"><sup>*</sup></span> </span>
                        <span class="inputfieldcon_editp">

                            <asp:TextBox ID="txtCity" runat="server" TabIndex="11" Width="100" CssClass="inputf_accm auto-search-city"></asp:TextBox>
                        </span>
                        <span class="titletext_editp">Phone (Other): </span><span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtphoneother" runat="server" CssClass="inputf_editp mask-phone" MaxLength="500"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">State:<span class="reqiredmark"><sup>*</sup></span> </span>
                        <span class="inputfieldcon_editp">
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="inputf_accm" Width="120px"
                                AutoPostBack="False" >
                            </asp:DropDownList></span> <span class="titletext_editp">Email:<span class="reqiredmark"><sup>*</sup></span>
                            </span><span class="inputfieldrightcon_editp">
                                <asp:TextBox ID="txtEmail1" runat="server" CssClass="inputf_editp" Width="170px"
                                    MaxLength="500"></asp:TextBox>
                            </span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Zip:<span class="reqiredmark"><sup>*</sup></span> </span>
                        <span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtzip1" runat="server" CssClass="inputf_accm" Width="100" MaxLength="9"></asp:TextBox>
                        </span>
                        <span class="titletext_editp">Other Email: </span>
                        <span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtEmail2" runat="server" CssClass="inputf_editp" Width="170px"
                                MaxLength="500"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Password:</span>
                        <span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtPassword" runat="server" Width="170px" TextMode="Password"></asp:TextBox>
                        </span>
                        <span class="titletext_editp">Confirm Password:</span>
                        <span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtCnfrmPassword" runat="server" Width="170px" TextMode="Password"></asp:TextBox>
                        </span>
                    </p>
                    <div class="headbg_boxtop_editp">
                        <div class="head_text_editp">
                            Photo</div>
                    </div>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Upload Photos: </span><span class="textlnk_editp"><a
                            href="javascript:load()">Click here to edit </a></span>
                    </p>
                </div>
                <%--</contenttemplate>
                </asp:UpdatePanel>--%>
            </div>
            <div class="headbg2_box_editp">
                <div class="save_button_editp">
                    <asp:ImageButton ID="ibtnsave" runat="server" CssClass="" ImageUrl="../Images/save-button.gif"
                        OnClientClick="return Validation()" OnClick="ibtnsave_Click" /></div>
                <div class="cancel_button_editp">
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
        
        $('.mask-phone').mask("(999)-999-9999");
    });
    
    </script>
    
</asp:Content>

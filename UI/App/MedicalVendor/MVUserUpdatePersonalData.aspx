<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master"
    AutoEventWireup="true" Inherits="MedicalVendor_MVUserUpdatePersonalData" CodeBehind="MVUserUpdatePersonalData.aspx.cs" %>

<%@ Register Src="../UCCommon/ucupdatephotopanel.ascx" TagName="ucupdatephotopanel"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />

    <script language="javascript" type="text/javascript">

function Validation()
{
 ///Validate Medical Vendor Details 
         var ddlVendorName= document.getElementById("<%= this.ddlVendorName.ClientID %>");
         // Name can not be null or blank
         if ( (checkDropDown(ddlVendorName,"Vendor Name")==false))
         {return false;}
         
          var ddlSpecialization= document.getElementById("<%= this.ddlSpecialization.ClientID %>");
         if ( (checkDropDown(ddlSpecialization,"Specialization")==false) )
         {
            return false;
         }
         
         var txtFirstName= document.getElementById("<%= this.txtFirstName.ClientID %>");
         var txtLastName= document.getElementById("<%= this.txtLastName.ClientID %>");
         if (isBlank(txtFirstName,"First Name") ||
             isBlank(txtLastName,"Last Name"))  
         
         {return false;}
         

         
          var txtSSN= document.getElementById("<%= this.txtSSN.ClientID %>");
         
         //if (isBlank(txtSSN,"Social Security number"))
         //{return false;}
         
         // DOB can not be null or blank
          var txtDOB= document.getElementById("<%= this.txtDOB.ClientID %>");
         // Sno can not be null or blank
         if (isBlank(txtDOB,"Date of Birth"))
         {return false;}
         
         if(ValidateDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
         if(checkDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
        
         
         //////////////////////////////////////
          
        ///Business Address
         
         var txtAddress1= document.getElementById("<%= this.txtAddress1.ClientID %>");
         if (isBlank(txtAddress1,"Business Address1"))
         { return false;}
         
         
          var txtPhoneC= document.getElementById("<%= this.txtPhoneC.ClientID %>");
          //if (isBlank(txtPhoneC,"Cell Phone"))
            //return false;
          
          var txtPhoneH= document.getElementById("<%= this.txtPhoneH.ClientID %>");
          //if (isBlank(txtPhoneH,"Home Phone"))
            //return false;
         
         var txtPhoneO= document.getElementById("<%= this.txtPhoneO.ClientID %>");
          //if (isBlank(txtPhoneO,"Office Phone"))
            //return false;
         var ddlState= document.getElementById("<%= this.ddlState.ClientID %>");
         if ((checkDropDown(ddlState,"state for Business Address")==false))  
            {return false;}
        
        var txtEmail1= document.getElementById("<%= this.txtEmail1.ClientID %>");
        if (!validateEmail(txtEmail1,"Email "))
             return false; 
        
        var txtCity= document.getElementById("<%= this.txtCity.ClientID %>");
        if ((isBlank(txtCity,"city for Business Address")))  
            {return false;}
         
         var txtZip= document.getElementById("<%= this.txtZip.ClientID %>");
         
         if(!isInteger(txtZip,"Business Zip"))
         {
             return false;   
         }
         
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
                
         return true;
     }


function savemedicalvendoruser()
        {
        
        var ddlstate = document.getElementById(arrelemjsmv[1]);
        var txtcity = document.getElementById(arrelemjsmv[2]);
        document.getElementById(jselemshiddenfields[0]).value = txtcity.value;
        document.getElementById(jselemshiddenfields[1]).value = ddlstate.options[ddlstate.options.selectedIndex].value;
        __doPostBack('save');
        return false;
        }  
        
        function setdropdownvalue(ddlclientid, selectedid)
        {
            var ddlControl = document.getElementById(ddlclientid);
            var icount = 0;
            while(icount < ddlControl.options.length)
            {
                if(ddlControl.options[icount].value == selectedid)
                {
                    ddlControl.options[icount].selected = true;
                    break;
                }
                icount = icount + 1;
            }
        }



        function enabletextbox(chkclientid, txtclientid)
        {
       
            var chkbox = document.getElementById(chkclientid);
            var txtpayrates = document.getElementById(txtclientid);
            
            alert(chkbox.checked)
            
            if(chkbox.checked == true)
            {
                txtpayrates.disabled = '';
            }
            else
            {
                txtpayrates.disabled = 'disabled';
                txtpayrates.innerHTML = '';
            }
        }
 
        
    </script>

    <script type="text/javascript" language="javascript">

    function ShowUpResume()
    {
        
        var disFileResume=document.getElementById("<%= this.pFileResume.ClientID %>");
        disFileResume.style.display='Block';
        var hfResume=document.getElementById("<%= this.hfResume.ClientID %>");
        var spResume = document.getElementById("<%= this.spResume.ClientID %>");
        hfResume.value="1";
        spResume.style.display='none'  
        return false;
    }
    
    function CloseUpResume()
    {
        var disFileResume=document.getElementById("<%= this.pFileResume.ClientID %>");
        var fileResume=document.getElementById("<%= this.fileResume.ClientID %>");
        var hfResume=document.getElementById("<%= this.hfResume.ClientID %>");
        var spResume = document.getElementById("<%= this.spResume.ClientID %>");
        spResume.style.display='block';
        hfResume.value="0";
        disFileResume.style.display='none';
        return false;
    }
    
    function CloseUpSignature()
    {
        var disFileSignature=document.getElementById("<%= this.pFileSignature.ClientID %>");
        var fileSignature=document.getElementById("<%= this.fileSignature.ClientID %>");
        var hfSignature=document.getElementById("<%= this.hfSignature.ClientID %>");
        var spSign = document.getElementById("<%= this.spSign.ClientID %>");
        spSign.style.display='block';
        hfSignature.value="0";
        disFileSignature.style.display='none';
        return false;
    }

    function ShowUpSignature()
    {
        var disFileSignature=document.getElementById("<%= this.pFileSignature.ClientID %>");
        disFileSignature.style.display='Block';
        var hfSignature=document.getElementById("<%= this.hfSignature.ClientID %>");
        hfSignature.value="1";
        var spSign = document.getElementById("<%= this.spSign.ClientID %>");
        spSign.style.display='none'
        return false;
    }
    </script>

    <asp:HiddenField ID="hfCountryID" runat="server" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Edit MV User Profile</span>
                    <span class="headingright_default"></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="main_area_bdr">
                <div class="pagealerttxtCNT" id="errordiv" runat="server">
                </div>
                <div id="divErrorMsg" class="maindivredmsgbox" enableviewstate="false" visible="false"
                    runat="server">
                </div>
                <div class="main_content_area_anh">
                    <div class="headbg_boxtop_amv">
                        <div class="head_textsmall_amv">
                            Medical Vendor Users Details</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Vendor Name: </span><span class="inputfieldcon_amv">
                            <asp:DropDownList ID="ddlVendorName" runat="server" CssClass="inputf_amv" Width="170px">
                            </asp:DropDownList>
                        </span><span class="titletext_amv">Specialization:</span> <span class="inputfieldrightcon_amv">
                            <asp:DropDownList ID="ddlSpecialization" runat="server" CssClass="inputf_amv" Width="150px">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <%--<p class="main_container_row_amv">
                        <span class="titletext_amv">Resume: </span>
                        <span class="ttxtnowidthnormal_default" style="margin-right:40px;">
                            <asp:FileUpload ID="flResume" runat="server" CssClass="inputf_pw" Width="180px" />&nbsp;
                        </span>
                        <span class="ttxtnowidthnormal_default" style="font-style: italic">&nbsp;(Resume file
                            must be either of type ".doc",".docx",".txt" or ".rtf")</span>
                    </p>--%>
                    <div class="main_container_row_amv">
                        <div class="titletext_amv">
                            Resume:
                        </div>
                        <div class="ttxtnowidthnormal_default" id="spResume" runat="server">
                            <span id="spDwnResume" runat="server" style="display: block"><a id="aDwnResume" href="">
                                Download Resume</a> </span><span id="spUploadResume" runat="server" style="display: none">
                                    <asp:LinkButton ID="lnkUploadResume" runat="server" OnClientClick="return ShowUpResume();">Upload Resume</asp:LinkButton>
                                </span>
                            <asp:HiddenField ID="hfResume" Value="0" runat="server" />
                        </div>
                        <div id="pFileResume" style="float: left; display: none" runat="server">
                            <span class="ttxtnowidthnormal_default"><span>
                                <asp:FileUpload ID="fileResume" runat="server" CssClass="inputf_pw" Width="220px" />
                                <span id="spResumeClose" runat="server" style="display: block">
                                    <asp:LinkButton ID="lnkCloseResume" runat="server" OnClientClick="return CloseUpResume();">Close</asp:LinkButton>
                                </span></span></span><span class="ttxtnowidthnormal_default" style="font-style: italic">
                                    (Resume file must be either of type ".doc",".docx",".txt" or ".rtf") </span>
                        </div>
                    </div>
                    <%--<p class="main_container_row_amv">
                      <span class="titletext_amv">Signature: </span><span class="ttxtnowidthnormal_default" style="margin-right:40px;">
                            <asp:FileUpload ID="flSignature" runat="server" CssClass="inputf_pw" Width="180px" />
                        </span>
                        <span class="ttxtnowidthnormal_default" style="font-style: italic">&nbsp;(Signature
                            file must be of ".jpeg" or ".jpg" type)</span>
                     </p>--%>
                    <div class="main_container_row_amv">
                        <div class="titletext_amv">
                            Signature:</div>
                        <div class="ttxtnowidthnormal_default" id="spSign" runat="server">
                            <span id="spDwnSignature" runat="server" style="display: block"><a id="aDwnSign"
                                href="" target="_blank">Download Signature</a> </span><span id="spUploadSignature"
                                    runat="server" style="display: none">
                                    <asp:LinkButton ID="lnkUpSignature" runat="server" OnClientClick="return ShowUpSignature();">Upload Signature</asp:LinkButton>
                                </span>
                            <asp:HiddenField ID="hfSignature" Value="0" runat="server" />
                        </div>
                        <div id="pFileSignature" runat="server" style="display: none; float: left">
                            <span class="ttxtnowidthnormal_default"><span>
                                <asp:FileUpload ID="fileSignature" runat="server" CssClass="inputf_pw" Width="220px" />
                                <span id="spSignClose" runat="server" style="display: block">
                                    <asp:LinkButton ID="lnkCloseSignature" runat="server" OnClientClick="return CloseUpSignature();">Close</asp:LinkButton>
                                </span></span></span><span class="ttxtnowidthnormal_default" style="font-style: italic">
                                    (Signature file must be of ".jpeg" or ".jpg" type)</span>
                        </div>
                    </div>
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Primary Contact Details</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">First Name: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputf_amv" Width="170px"></asp:TextBox></span>
                        <span class="titletext_amv">Middle Name: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="inputf_amv" Width="170px"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Last Name: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtLastName" runat="server" Width="170px" CssClass="inputf_amv"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Date of Birth: </span><span class="inputfieldcon_amv"><span
                            class="inputfieldob_amv">
                            <asp:TextBox ID="txtDOB" runat="server" CssClass="inputf_amv date-picker-dob" Width="100px"></asp:TextBox>
                            <span style="font-size: 7pt;">mm/dd/yyyy</span> </span></span> <span class="titletext_amv">SSN:
                        </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtSSN" runat="server" CssClass="inputf_amv" Width="170px"></asp:TextBox>
                        </span>
                    </p>
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Primary Contact Address Details</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Address1: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputf_amv" Width="170px"
                                TextMode="multiLine"></asp:TextBox></span> <span class="titletext_amv">Phone (Cell):</span>
                        <span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtPhoneC" runat="server" CssClass="inputf_amv mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Address2: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputf_amv" Width="170px"
                                TextMode="multiLine"></asp:TextBox>
                        </span><span class="titletext_amv">Phone (Home): </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtPhoneH" runat="server" CssClass="inputf_amv mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>--%>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">City: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtCity" runat="server" Width="100" CssClass="inputf_accm auto-search-city"></asp:TextBox>
                        </span><span class="titletext_amv">Phone (Other): </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtPhoneO" runat="server" CssClass="inputf_amv mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">State: </span><span class="inputfieldcon_amv">
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="inputf_accm" Width="120px"
                                AutoPostBack="False">
                            </asp:DropDownList>
                        </span><span class="titletext_amv">Email: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtEmail1" runat="server" CssClass="inputf_amv" Width="170px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Zip: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_accm" Width="100"></asp:TextBox>
                        </span><span class="titletext_amv">Other Email: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtEmail2" runat="server" CssClass="inputf_amv" Width="170px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_editp">
                        <span class="titletext_editp">Password:</span> <span class="inputfieldcon_editp">
                            <asp:TextBox ID="txtPassword" runat="server" Width="170px" TextMode="Password"></asp:TextBox>
                        </span><span class="titletext_editp">Confirm Password:</span> <span class="inputfieldrightcon_editp">
                            <asp:TextBox ID="txtCnfrmPassword" runat="server" Width="170px" TextMode="Password"></asp:TextBox>
                        </span>
                    </p>
                    <%--</contenttemplate>
                </asp:UpdatePanel>--%>
                </div>
                <div class="headbg_boxprates_amv">
                    <div class="head_text_amv">
                        Photo</div>
                </div>
                <p class="main_containerreff2_row_amv">
                    <uc1:ucupdatephotopanel ID="Ucupdatephotopanel1" runat="server" />
                </p>
            </div>
            <div class="headbg2_box_amv">
                <div class="save_button_amv">
                    <asp:ImageButton ID="ibtnsave" runat="server" CssClass="" ImageUrl="~/App/Images/save-button.gif"
                        OnClientClick="return Validation();" OnClick="ibtnsave_Click" /></div>
                <div class="cancel_button_amv">
                    <asp:ImageButton ID="ibtncancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="ibtncancel_Click" /></div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfcityid" runat="server" />
    <asp:HiddenField ID="hfstateid" runat="server" />

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

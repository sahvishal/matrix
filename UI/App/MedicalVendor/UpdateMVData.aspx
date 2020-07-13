<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master"
    AutoEventWireup="true" Inherits="MedicalVendor_UpdateMVData" Title="Untitled Page"
    CodeBehind="UpdateMVData.aspx.cs" %>

<%@ Register Src="../UCCommon/ucupdatephotopanel.ascx" TagName="ucupdatephotopanel"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true"/>

    <script language="JavaScript" type="text/javascript">
        function load() 
        {
            var load = window.open('PhotoManagement.aspx','','scrollbars=no,menubar=no,height=600,width=500,resizable=no,toolbar=no,location=no,status=no');
        }
 function Validation()
     { ////debugger
        
         var txtVName       = document.getElementById("<%= this.txtVName.ClientID %>");
         var txtFName       = document.getElementById("<%= this.txtFName.ClientID %>");
         var txtLName       = document.getElementById("<%= this.txtLName.ClientID %>");
         var txtAddress1    = document.getElementById("<%= this.txtAddress1.ClientID %>");
         var txtAddress2    = document.getElementById("<%= this.txtAddress2.ClientID %>");
         var txtBAddress1   = document.getElementById("<%= this.txtBAddress1.ClientID %>");
         var txtBAddress2   = document.getElementById("<%= this.txtBAddress2.ClientID %>");
         var txtDOB         = document.getElementById("<%= this.txtDOB.ClientID %>");
         
         if(ValidateDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
         if(checkDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
         var txtCity        = document.getElementById("<%= this.txtCity.ClientID %>");
         var ddlState       = document.getElementById("<%= this.ddlState.ClientID %>");
         
         
         var txtBuCity       = document.getElementById("<%= this.txtBuCity.ClientID %>");
         var ddlBState      = document.getElementById("<%= this.ddlBState.ClientID %>");
        
         
         var txtZip         = document.getElementById("<%= this.txtZip.ClientID %>");
         var txtBZip        = document.getElementById("<%= this.txtBZip.ClientID %>");
         
         var txtBPhone      = document.getElementById("<%= this.txtBPhone.ClientID %>");
         var txtBFax        = document.getElementById("<%= this.txtBFax.ClientID %>");
        
        
         var txtPhoneHome   = document.getElementById("<%= this.txtPhoneHome.ClientID %>");
         var txtPhoneOther  = document.getElementById("<%= this.txtPhoneOther.ClientID %>");
         var txtPhoneCell   = document.getElementById("<%= this.txtPhoneCell.ClientID %>");
        
         var txtEmail       = document.getElementById("<%= this.txtEmail.ClientID %>");
         var txtEmail2      = document.getElementById("<%= this.txtEmail2.ClientID %>");
         
         
         var txtSplInstruction= document.getElementById("<%= this.txtSplInstruction.ClientID %>");
         var txtAccountHolder = document.getElementById("<%= this.txtAccountHolder.ClientID %>");
         var txtAccountNo     = document.getElementById("<%= this.txtAccountNo.ClientID %>");
         var txtAccountType   = document.getElementById("<%= this.txtAccountType.ClientID %>");
         var txtBankName      = document.getElementById("<%= this.txtBankName.ClientID %>");
         var txtRoutingNumber = document.getElementById("<%= this.txtRoutingNumber.ClientID %>");
         var txtMemo          = document.getElementById("<%= this.txtMemo.ClientID %>");
        var ddlPayMode        = document.getElementById("<%= this.ddlPayMode.ClientID %>");
         var ddlInterval      = document.getElementById("<%= this.ddlInterval.ClientID %>");
         
         
        if (isBlank(txtVName,"Vendor Name"))                                {return false;}
        if (isBlank(txtBAddress1,"Business Address1"))                      {return false;} 
        if (checkLength(txtBAddress1,500,"Business Address1"))              {return false;}
        if (checkLength(txtBAddress2,500,"Business Address2"))              {return false;}
        if (isBlank(txtBPhone,"Business Phone"))                            {return false;} 
         // if (isBlank(txtBFax,"Business Fax"))               {return false;} 
        if ((checkDropDown(ddlBState,"State for  Address")    ==false))     {return false;}
        if ((isBlank(txtBuCity,"City for  Address")))                       {return false;}
        if ((isInteger(txtBZip, "Zip")                         !=true))     {return false;}
        if (isBlank(txtFName,"First Name"))                                 {return false;} 
        if (isBlank(txtLName,"Last Name"))                                  {return false;} 
        if (isBlank(txtDOB,"Date of Brith"))                                {return false;}
        
        if(ValidateDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
         if(checkDate(txtDOB.value,"Date Of Birth")==false)
            {return false;}
            
        if (isBlank(txtAddress1,"Address1"))                                {return false;}
        if (checkLength(txtAddress1,500,"Address1"))                        {return false;}
        if (checkLength(txtAddress2,500,"Address2"))                        {return false;}
        if (isBlank(txtPhoneCell,"Phone (Cell)"))                           {return false;} 
        if ((checkDropDown(ddlState,"State for  Address")     ==false))     {return false;}
        if ((isBlank(txtCity,"City for  Address")))                         {return false;}
        if ((isInteger(txtZip, "Zip")                         !=true) )     {return false;}
        if ((validateEmail(txtEmail, "Email")                 !=true))      {return false;}
        if ((checkDropDown(ddlPayMode,"Payment Mode")         ==false))     {return false;}
        if ((checkDropDown(ddlInterval,"Payment Interval")    ==false))     {return false;}
        if (isBlank(txtBankName,"Bank Name"))                               {return false;} 
        if (isBlank(txtAccountHolder,"Account Holder"))                     {return false;} 
        if (isBlank(txtAccountNo,"Account No"))                             {return false;} 
        if (isBlank(txtAccountType,"Type of Account"))                      {return false;} 
        if (checkLength(txtMemo,500,"Memo"))                                {return false;}
        if (checkLength(txtSplInstruction,500,"Spl. Instruction"))          {return false;}
        
         
         
         
         

         
          
            
     }

    

    </script>

    <asp:HiddenField ID="hfCountryID" runat="server" />
    <asp:HiddenField ID="hfBusinessCountryID" runat="server" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Edit Profile</span>
                    <span class="headingright_default"></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="main_area_bdr">
                <div class="main_content_area_amv">
                    <div class="headbg_boxtop_editp">
                        <div class="head_text_editp">
                            About Medical Vendor</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Vendor Name:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtVName" runat="server" CssClass="inputf_amv" Width="175px" MaxLength="500"></asp:TextBox></span>
                        <span class="titletext_amv">Vendor Type: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtVendorType" runat="server" MaxLength="500" CssClass="inputf_amv"
                                ReadOnly="True"></asp:TextBox></span>
                    </p>
                    <p class="about_txt_area" style="display: none;">
                        <asp:TextBox runat="server" ID="txtMVDesc" CssClass="input_area_fcr" TextMode="multiLine"
                            Rows="4" Text="With a twist to the common list of habits that are useful to establish, here are 7 habits that you do best to avoid. Just like finding habits that can be useful for you it’s important to find the habits that are holding you back. They can easily become such a normal, everyday part of life that you hardly notice it (or how it’s affecting you).">
                        </asp:TextBox>
                    </p>
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Business Address</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Address1:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtBAddress1" runat="server" CssClass="inputf_amv" Width="170px"
                                TextMode="multiLine" MaxLength="500"></asp:TextBox></span> <span class="titletext_amv">
                                    Business Phone:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtBPhone" runat="server" CssClass="inputf_amv mask-phone" MaxLength="500"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Address2: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtBAddress2" runat="server" CssClass="inputf_amv" Width="170px"
                                TextMode="multiLine" MaxLength="500"></asp:TextBox>
                        </span><span class="titletext_amv">Business Fax: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtBFax" runat="server" CssClass="inputf_amv mask-phone" MaxLength="500"></asp:TextBox>
                        </span>
                    </p>
                    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>--%>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">City:<span class="reqiredmark"><sup>*</sup></span> </span>
                        <span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtBuCity" runat="server" Width="100" CssClass="inputf_accm auto-search-city"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">State:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_amv">
                            <asp:DropDownList ID="ddlBState" runat="server" Width="120px" CssClass="inputf_accm"
                                AutoPostBack="False">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <%--</contenttemplate>
                    </asp:UpdatePanel>--%>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Zip:<span class="reqiredmark"><sup>*</sup></span> </span>
                        <span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtBZip" runat="server" CssClass="inputf_accm" Width="100" MaxLength="9"></asp:TextBox>
                        </span>
                    </p>
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Primary Contact Details</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">First Name:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtFName" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                        <span class="titletext_amv">Middle Name: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtMName" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Last Name:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtLName" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                        <span class="titletext_amv">Specialization: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtSpecialization" runat="server" CssClass="inputf_accm" Width="100"
                                ReadOnly="True"></asp:TextBox></span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Date of Birth: <span class="reqiredmark"><sup>*</sup></span></span><span
                            class="inputfieldcon_amv"> <span class="inputfieldob_amv">
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="inputf_amv date-picker-dob" Width="100px"></asp:TextBox>
                                <span style="font-size: 7pt;">mm/dd/yyyy</span> </span></span><span class="titletext_amv">
                                    SSN: </span><span class="inputfieldrightcon_amv">
                                        <asp:TextBox ID="txtSSN" runat="server" CssClass="inputf_amv" Width="170px"></asp:TextBox></span>
                    </p>
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Primary Contact Address Details</div>
                    </div>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Address1:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputf_amv" Width="170px"
                                TextMode="multiLine"></asp:TextBox></span> <span class="titletext_amv">Phone (Cell):<span
                                    class="reqiredmark"><sup>*</sup></span></span> <span class="inputfieldrightcon_amv">
                                        <asp:TextBox ID="txtPhoneCell" runat="server" CssClass="inputf_amv mask-phone" MaxLength="500"></asp:TextBox>
                                    </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Address2:</span><span class="inputfieldcon_amv"><asp:TextBox
                            ID="txtAddress2" runat="server" CssClass="inputf_amv" Width="170px" TextMode="multiLine"></asp:TextBox>
                        </span><span class="titletext_amv">Phone (Home):</span><span class="inputfieldrightcon_amv"><asp:TextBox
                            ID="txtPhoneHome" runat="server" CssClass="inputf_amv mask-phone" MaxLength="500"></asp:TextBox>
                        </span>
                    </p>
                    <%--<asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>--%>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">City:<span class="reqiredmark"><sup>*</sup></span> </span>
                        <span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtCity" runat="server" Width="100" CssClass="inputf_accm auto-search-city"></asp:TextBox>
                        </span><span class="titletext_amv">Phone (Office): </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtPhoneOther" runat="server" MaxLength="500" CssClass="inputf_amv mask-phone"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">State:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldcon_amv">
                            <asp:DropDownList ID="ddlState" runat="server" Width="130px" CssClass="inputf_accm"
                                AutoPostBack="False">
                            </asp:DropDownList>
                        </span><span class="titletext_amv">Email:<span class="reqiredmark"><sup>*</sup></span>
                        </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="500" Width="170px" CssClass="inputf_amv"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Zip:<span class="reqiredmark"><sup>*</sup></span> </span>
                        <span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_accm" Width="100" MaxLength="9"></asp:TextBox>
                        </span><span class="titletext_amv">Other Email: </span><span class="inputfieldrightcon_amv">
                            <asp:TextBox ID="txtEmail2" runat="server" MaxLength="500" Width="170px" CssClass="inputf_amv"></asp:TextBox>
                        </span>
                    </p>
                    <%--</contenttemplate>
                    </asp:UpdatePanel>--%>
                    <p class="main_container_row_amv">
                        <span class="titletext_amv">Contract: </span><span class="inputfieldcon_amv">
                            <asp:TextBox ID="txtContract" runat="server" CssClass="inputf_accm" ReadOnly="True"
                                Width="100" MaxLength="500"></asp:TextBox></span> <span class="titletext_amv" style="visibility: hidden">
                                    My Signature </span><span class="textlnk2_amv" style="visibility: hidden"><a href="#">
                                        Add Signature</a></span>
                    </p>
                    <%--<div id="" class="maindivwiringdetails_amv">
                        <div class="headbg_box_amv">
                            <div class="head_text_amv">
                                Other Details:</div>
                        </div>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Contract: </span><span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtContract" runat="server" CssClass="inputf_accm" ReadOnly="True"
                                    Width="100" MaxLength="500"></asp:TextBox></span> <span class="titletext_amv">Payment
                                        Interval: </span><span class="inputfieldrightcon_amv">
                                            <asp:DropDownList ID="ddlInterval" runat="server" CssClass="inputf_amv" Width="175px">
                                                <asp:ListItem Text="Select " Value="0"></asp:ListItem>
                                                <asp:ListItem Text="By Cash" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="By Cheque" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </span>
                        </p>
                    </div>
                    <div id="Payment">
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Payment Mode:<span class="reqiredmark"><sup>*</sup></span>
                            </span><span class="inputfieldcon_amv">
                                <asp:DropDownList runat="server" ID="ddlPayMode" CssClass="inputf_accm" Width="175px">
                                </asp:DropDownList></span>
                        </p>
                        <div class="" id="ByCreditCard">
                            <p class="main_container_row_amv">
                                <span class="titletext_amv">Credit Card No:<span class="reqiredmark"><sup>*</sup></span>
                                </span><span class="inputfieldcon_amv">
                                    <asp:TextBox ID="ccno" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                                <span class="titletext_amv">Expiration date: </span><span class="inputfieldrightcon_amv">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                            </p>
                            <p class="main_container_row_amv">
                                <span class="titletext_amv">Security No:<span class="reqiredmark"><sup>*</sup></span>
                                </span><span class="inputfieldcon_amv">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                                <span class="chkboxtxt_amv">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    "I agree" consent </span>
                            </p>
                        </div>
                        <div class="" id="ByCheque">
                            <p class="main_container_row_amv">
                                <span class="titletext_amv">Bank Name:<span class="reqiredmark"><sup>*</sup></span>
                                </span><span class="inputfieldcon_amv">
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                                <span class="titletext_amv">A/c Holder Name: </span><span class="inputfieldrightcon_amv">
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                            </p>
                            <p class="main_container_row_amv">
                                <span class="titletext_amv">Bank Account#:<span class="reqiredmark"><sup>*</sup></span>
                                </span><span class="inputfieldcon_amv">
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                                <span class="titletext_amv">Bank Routing#:<span class="reqiredmark"><sup>*</sup></span>
                                </span><span class="inputfieldrightcon_amv">
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox>
                                </span>
                            </p>
                            <p class="main_container_row_amv">
                                <span class="titletext_amv">Check #:<span class="reqiredmark"><sup>*</sup></span> </span>
                                <span class="inputfieldcon_amv">
                                    <asp:TextBox ID="TextBox7" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox></span>
                                <span class="titletext_amv">Special Instructions:<span class="reqiredmark"><sup>*</sup></span>
                                </span><span class="inputfieldrightcon_amv">
                                    <asp:TextBox ID="TextBox8" runat="server" CssClass="inputf_amv" Width="170px" MaxLength="500"></asp:TextBox>
                                </span>
                            </p>
                            <p class="main_container_row_amv">
                                <span class="chkboxtxt_amv">
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                    "I agree" consent </span>
                            </p>
                        </div>
                    </div>--%>
                    <div id="" class="maindivwiringdetails_amv">
                        <div class="headbg_box_amv">
                            <div class="head_text_amv">
                                Other Details</div>
                        </div>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Payment Mode:<span class="reqiredmark"><sup>*</sup></span>
                            </span><span class="inputfieldcon_amv">
                                <asp:DropDownList runat="server" ID="ddlPayMode" CssClass="inputf_accm" Width="175px">
                                </asp:DropDownList>
                            </span><span class="titletext_amv">Payment Interval:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldrightcon_amv">
                                <asp:DropDownList runat="server" ID="ddlInterval" CssClass="inputf_accm" Width="130px">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Bank Name:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtBankName" runat="server" CssClass="inputf_amv" Width="150px"
                                    MaxLength="50"></asp:TextBox>
                            </span><span class="titletext_amv">Account Holder:<span class="reqiredmark"><sup>*</sup></span>
                            </span><span class="inputfieldrightcon_amv">
                                <asp:TextBox ID="txtAccountHolder" runat="server" CssClass="inputf_amv" Width="150px"
                                    MaxLength="50"></asp:TextBox></span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Account No:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtAccountNo" runat="server" CssClass="inputf_amv" Width="150px"
                                    MaxLength="50"></asp:TextBox>
                            </span><span class="titletext_amv">Account Type:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldrightcon_amv">
                                <asp:TextBox ID="txtAccountType" runat="server" CssClass="inputf_amv" Width="150px"
                                    MaxLength="50"></asp:TextBox>
                            </span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Routing number: </span><span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtRoutingNumber" runat="server" CssClass="inputf_amv" Width="150px"
                                    MaxLength="50"></asp:TextBox></span> <span class="titletext_amv">Memo: </span>
                            <span class="inputfieldrightcon_amv">
                                <asp:TextBox ID="txtMemo" runat="server" CssClass="inputf_amv" Width="170px" TextMode="multiLine"></asp:TextBox></span>
                        </p>
                        <p class="main_container_row_amv">
                            <span class="titletext_amv">Special Instructions: </span><span class="inputfieldcon_amv">
                                <asp:TextBox ID="txtSplInstruction" runat="server" CssClass="inputf_amv" Width="170px"
                                    TextMode="multiLine"></asp:TextBox></span>
                        </p>
                    </div>
                    <div class="headbg_box_amv">
                        <div class="head_text_amv">
                            Photo</div>
                    </div>
                    <p class="main_container_row_amv">
                        <uc1:ucupdatephotopanel ID="Ucupdatephotopanel1" runat="server" />
                    </p>
                </div>
            </div>
            <div class="headbg2_box_amv">
                <div class="save_button_anh">
                    <asp:ImageButton ID="Save" runat="server" CssClass="" ImageUrl="../Images/save-button.gif"
                        OnClientClick="return Validation()" OnClick="Save_Click" /></div>
                <div class="cancel_button_anh">
                    <asp:ImageButton ID="Cancel" runat="server" CssClass="" ImageUrl="../Images/cancel-button.gif"
                        OnClick="Cancel_Click" /></div>
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

<%@ Page Language="C#" AutoEventWireup="True" Inherits="App_Common_ShippingInfo" Codebehind="ShippingInfo.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../StyleSheets/UC.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/Wizardstyle.css" rel="stylesheet" type="text/css" />
    <script src="/App/JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>" language="javascript" type="text/javascript"></script>
    <script src="/App/JavascriptFiles/CalendarPopup.js" language="javascript" type="text/javascript"></script>
    
    <SCRIPT language=JavaScript>	
        var cal = new CalendarPopup();	
    </SCRIPT>
    
 <style type="text/css">
     p{padding:0px; margin:0px;}
.maindiv_popup{float:left; width:555px; padding:5px;}
.maindivinner_popup{float:left; width:540px; margin-left:5px;}
.middivrow_regcust_popup{float:left; width:540px; padding:3px 0 3px 0;}
.headtxtleft_popup{float:left; font:bold 12px arial; color:#000; padding-top:2px;}
.headingrighttxt_popup{float:right; padding:3px 10px 0px 0px; font:normal 12px arial; color:#000; }
.headingrightinput_popup{float:right; padding-right:20px; font:normal 12px arial; color:#000; }
.titletextblueboldpopup_ccrep {float:left; width:305px; margin-right:5px; padding:9px 0px 0px 5px; font:bold 12px arial; color:#009FC3;}
.normaltxtpopup_popup{float:left; padding-left:5px;}
.subheadingbgpopup_pd{float:left; width:530px; height:29px; padding:5px 0px 0px 5px; margin:5px 0px 5px 0px; font-weight:bold; background:url(../Images/CCRep/subheadedingtab_ccrep.gif) no-repeat;}
.titletxt_popup_pd{float:left; width:100px; padding:0px 5px 0px 5px; font:normal 12px arial; }
.inputconleft_popup_pd{float:left; width:140px; margin-right:10px;}
.inputconright_popup_pd{float:left; width:140px;}
.radiatxtbox1_popup_pd{float:left; width:50px; padding-top:6px;}
.radiatxtbox_popup_pd{float:left; width:50px; padding-top:6px;}
.radiatxtbox2_popup_pd{float:left; width:60px; padding-top:6px;}
.titletxt1_regcust{float:left; width:110px; padding:0px 5px 0px 0px }
.buttoncell_ccrep{float:right; width:125px;}
.fline_popup_pdt{float:left; width:540px; background:url(../Images/CCRep/fadeline-hz.gif) no-repeat;height:1px; margin:5px 0px 0px 0px;}
.reqiredmark{font:normal 11px arial; color:Red; }
.inputf_def{ border: 1px solid #7F9DB9; Background-color:#fff; z-index:-5; font: normal 12px arial; color:#333; padding:2px;}
.calendarcntrl_ccrep{float:left; width:15px; padding:5px 0px 0px 5px; }



 </style>   
 <script language="javascript" type="text/javascript">
    function validatecontrols()
    {
        if(!checkDropDown(document.getElementById('<%= this.ddlcarrier.ClientID %>'), 'Carrier'))
                return false;
        
        if(isBlank(document.getElementById('<%= this.txtShippingDate.ClientID %>'), 'Shipping Date'))
            return false;
            
        var txtShippingDate = document.getElementById("<%= this.txtShippingDate.ClientID %>");
        if(ValidateDate(txtShippingDate.value,"Shipping Date")==false)
                {return false;}
            
        if(checkDate(txtShippingDate.value,"Shipping Date")==false)
            {return false;}  
                 
        return true;
    }
 </script>   
</head>
<body style="background-color:#fff;">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager id="ScriptManger1" runat="server">
    </cc1:ToolkitScriptManager>
    <div class="maindiv_popup" style="background-color:#fff;" >
    <p class="subheadingbgpopup_pd">
     <span class="headtxtleft_popup">Shipping Information</span> 
     </p>
         <p class="middivrow_regcust_popup">
                 <span class="titletxt_popup_pd">Carrier<span class="reqiredmark"><sup>*</sup></span>:</span>
                 <span class="inputconleft_popup_pd">
                 <asp:DropDownList runat="server" ID="ddlcarrier" Width="140px" CssClass="inputf_def">
                </asp:DropDownList></span> <span class="titletxt_popup_pd" style="width:135px">Carrier Transaction No:</span>
              <span class="inputconright_popup_pd" style="width:110px">
                  <asp:TextBox ID="txtcarriertno" MaxLength="16" runat="server" CssClass="inputf_def" Width="110px"></asp:TextBox></span>
        </p>
        <p class="middivrow_regcust_popup">
        <span class="titletxt_popup_pd">Tracking No:</span>
        <span class="inputconleft_popup_pd">
            <asp:TextBox ID="txtTrackingNo" runat="server" CssClass="inputf_def" Width="105px"></asp:TextBox>
        </span>
        <span class="titletxt_popup_pd" style="width:135px">Shipping Date<span class="reqiredmark"><sup>*</sup></span>:</span>
        <span class="inputconright_popup_pd" style="width:100px; margin-right:5px;">
            <asp:TextBox ID="txtShippingDate" runat="server" CssClass="inputf_def" Width="70px"></asp:TextBox>
            
            <a href="#" onclick="cal.select(document.getElementById('<%= this.txtShippingDate.ClientID %>'),'anchor1','MM/dd/yyyy'); return false;"  
                    name="anchor1" id="anchor1"><asp:Image ImageUrl="~/App/Images/calendar-icon.gif" runat="server" /></A>
            
            <span style="font-size: 7pt; padding: 0px; margin: 0px;">(mm/dd/yyyy)</span>
        </span>
        <span class="calendarcntrl_ccrep"> 
<%--            <asp:ImageButton runat="Server" ID="ibtnregdate" ImageUrl="~/App/Images/calendar-icon.gif" AlternateText="Click to show calendar" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtShippingDate" PopupButtonID="ibtnregdate">
            </cc1:CalendarExtender>--%>
        </span>
        </p>

        <p class="middivrow_regcust_popup">
        <span class="titletxt_popup_pd">Shipping Notes:</span>
        <span class="inputconleft_popup_pd">
            <asp:TextBox ID="txtShippingNotes" runat="server" TextMode="MultiLine"  CssClass="inputf_def" Width="400px"></asp:TextBox>
        </span>

        </p>

        <div class="flinerowbg_ccrep" style="width:530px; float:left;">
        <p class="contentrow_pw" style="width:520px; float:left;">
            <span class="titletextblueboldpopup_ccrep">Shipping Address:</span>
           </p>
        </div>
        <p class="middivrow_regcust_popup">
            <span class="titletxt_popup_pd">Address1:</span>
            <span class="inputconleft_popup_pd">
                <asp:TextBox ID="txtAddress1" runat="server" TextMode="MultiLine" CssClass="inputf_def" Width="180px" Enabled="false"></asp:TextBox>
            </span>
        
        </p>
        <p class="middivrow_regcust_popup">
        <span class="titletxt_popup_pd">Address2:</span>
        <span class="inputconleft_popup_pd">
            <asp:TextBox ID="txtAddress2" runat="server" TextMode="MultiLine" CssClass="inputf_def" Width="180px" Enabled="false"></asp:TextBox></span>
        </p>
        <p class="middivrow_regcust_popup">
        <span class="titletxt_popup_pd">State<span class="reqiredmark"><sup>*</sup></span>:</span>
        <span class="inputconleft_popup_pd">
            <asp:DropDownList runat="server" ID="ddlstate" Width="140px" CssClass="inputf_def" Enabled="false">
            </asp:DropDownList>
        </span>
        </p>
        <p class="middivrow_regcust_popup">
        <span class="titletxt_popup_pd">City<span class="reqiredmark"><sup>*</sup></span>:</span>
        <span class="inputconleft_popup_pd">
            <asp:TextBox runat="server" ID="txtCity" Width="135px" CssClass="inputf_def" Enabled="false">
            </asp:TextBox>
        </span>
        </p>
        <p class="middivrow_regcust_popup">
        <span class="titletxt_popup_pd">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
        <span class="inputconleft_popup_pd">
            <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_def" Width="70px" Enabled="false"></asp:TextBox></span>
        </p>
        <p class="middivrow_regcust_popup">
            <span style="float:right; padding-right:5px;">
                <asp:ImageButton ID="imgBtnSubmit" runat="server" ImageUrl="~/App/Images/save-shipping-info-btn.gif" OnClientClick="return validatecontrols();" onclick="imgBtnSubmit_Click" />
            </span>
        </p>

         <asp:HiddenField ID="hfAddressID" runat="server" Value="0" />

     </div>
    
    </form>
</body>
</html>

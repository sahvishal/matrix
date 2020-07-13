<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true" Inherits="App_MarketingPartner_Monetization" Title="Untitled Page" Codebehind="Monetization.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
 
   var GB_ROOT_DIR = "/App/Wizard/greybox/";
    function Validation()
     {
  var name= document.getElementById("<%= this.chkAgreement.ClientID %>");
          if(!name.checked)
          {
             alert("Please confirm that you have read and you agree to advocate agreement.");
             return false;
          }
   }
   
    </script>

   <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd"><%= IoC.Resolve<ISettings>().CompanyName %> Advocate Dashboard</span>
          <%--  <div style="float: right; width: 340px; padding-top: 3px;" id="divLastLogin" runat="server">
                <span style="float: left; width: 7px;">
                    <img src="/App/Images/leftroundlastlogin.gif" /></span> <span style="float: left;
                        width: 320px; padding: 1px; text-align: center; background-color: #FFD4A8; border-top: solid 1px #F1B678;
                        border-bottom: solid 1px #F1B678;"><span style="color: #000;" id="spLastLogin" runat="server">
                            Your last login time:</span></span> <span style="float: left">
                                <img src="/App/Images/rightroundlastlogin.gif"></span>
            </div>--%>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server"  AdvocateView="true" />
        </div>
        <div class="main_area_custdbrd">
           <%-- <div class="main_row_custdbrd">
                <img src="../Images/MarketingPartner/Congratulations-banner.jpg" /></div>--%>
                 <div class="main_row_custdbrd">
                 <p class="main_row_custdbrd">
                  <span class="orngheadtxt_heading">Monetize your Referrals </span>
                  </p>
             <div class="main_row_custdbrd">
                 If you refer friends and family you can earn money that you can use for:<ol>
               <li>Donating to your favorite charity.</li>
                <li>Credit towards your next screening.</li>
                 <li>Direct cash that you can use as you please.</li>
               </ol>
             </div>
             
             <p class="main_row_custdbrd">
             <span class="orngbold16_default">Advocate MonetizationTerms and Conditions  </span>             
             </p>
             
             <div class="main_row_custdbrd" style="background-color:#e5e5e5">
                <div style=" float:left; padding:10px; ">
                Praesent eget sapien eu risus ornare molestie. Ut convallis, est ac fermentum elementum, dolor ligula mollis neque, ut scelerisque nisi magna at sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nec diam eget leo interdum bibendum. Aenean adipiscing, dolor in tincidunt tincidunt, metus magna suscipit turpis, at semper sem nunc id ante. Morbi erat justo, commodo cursus, porta non, interdum vel, eros. Donec diam sem, condimentum at, accumsan a, pharetra nec, quam. Sed dui dui, pulvinar vitae, cursus sed, tristique nec, pede. Donec rhoncus est sollicitudin leo. In eget augue. Cras turpis. Mauris dapibus sem sed sapien. Nunc tincidunt. Fusce nisl. Nullam condimentum lorem vel diam. Suspendisse adipiscing aliquam sapien. Maecenas odio. Sed quam. Duis a nisi. 
                 </div> 
             </div>

            </div>
            <p><img src="../Images/specer.gif" width="740px" height="10px" /></p>
        </div>
        <div class="main_row_custdbrd">
        <span style="float:left; padding-left:10px;"><asp:CheckBox ID="chkAgreement" runat="server" Text="I agree with these terms." /></span>
           <span class="button_con_nowidth" style="float:right">
                  <asp:ImageButton ID="ibtnsave" runat="server" OnClientClick='return Validation()'
                    CssClass="" ImageUrl="~/App/Images/marketingpartner/Startmonetize-btn.gif" 
                    onclick="ibtnsave_Click"  />
                
                </span>
                 <span class="button_con_nowidth" style="float:right">
                <asp:ImageButton ID="ibtncancel" runat="server" 
                ImageUrl="~/App/Images/cancel-btn.gif" onclick="ibtncancel_Click" />       
            </span>
        
    </div>
    </div>
    
    
    
    <%-- <div class="headbg2_box_default">
            <div class="buttoncon_default">
                <asp:ImageButton ID="ibtnsave" runat="server" OnClientClick='return Validation()'
                    CssClass="" ImageUrl="~/App/Images/iagrree-btn.gif" 
                    onclick="ibtnsave_Click"  /></div>
        </div>--%>
    </asp:Content>
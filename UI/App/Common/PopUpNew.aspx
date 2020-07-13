<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="App_Common_PopUpNew" Codebehind="PopUpNew.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="arrowrows_msgbox">
   <p class="arrowrows_msgbox">
  <span id="arrowlefttop" class="arrowboxleft_msgbox"><img src="../Images/top-left-arrow-popup.gif" /></span>
  <span id="arrowrighttop" class="arrowboxright_msgbox"><img src="../Images/top-right-arrow-popup.gif" /></span>
  </p>
  <div id="dvEventDescShow" class="divmousehovertxt_mbox">
  
            <p class="headertxt_mbox">
                <span class="hdrtxtbold_mbox">Event Details</span></p>
            <div id="dvPackageDescText" class="divinnerbody_mbox">
                <p class='tooltippopuprow'>
                    <span class='ttitletxt_ecl_popup'>Event Date:</span><span class='detailtxt_ecl_popup'
                        id="EventDate"></span></p>
                <p class='tooltippopuprow'>
                    <span class='ttitletxt_ecl_popup'>Start Time:</span><span class='detailtxt_ecl_popup'
                        id="EventStartTime"></span></p>
                <p class='tooltippopuprow'>
                    <span class='ttitletxt_ecl_popup'>End Time:</span><span class='detailtxt_ecl_popup'
                        id="EventEndTime"> </span>
                </p>
                <p class='tooltippopuprow'>
                    <span class='ttitletxt_ecl_popup'>TimeZone:</span><span class='detailtxt_ecl_popup'
                        id="TimeZone"> </span>
                </p>
                <p class='tooltippopuprow'>
                    <span class='ttitletxt_ecl_popup'>Customer:</span><span class='detailtxt_ecl_popup'
                        id="CustomerCount"> </span>
                </p>
                <p class='tooltippopuprow'>
                    <span class='ttitletxt_ecl_popup'>Address:</span><span class='detailtxt_ecl_popup'
                        id="Address"></span></p>
            </div>             
        </div>
        <p class="arrowrows_msgbox">
  <span class="arrowboxleft_msgbox"><img src="../Images/left-down-arrow-popup.gif" /></span>
  <span class="arrowboxright_msgbox"><img src="../Images/right-down-arrow-popup.gif" /></span>
  </p>
</div>



</asp:Content>

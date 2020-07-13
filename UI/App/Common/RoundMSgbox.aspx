<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="App_Common_RoundMSgbox" Codebehind="RoundMSgbox.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="maindiv_roundmbox">
<div class="innerdiv_roundmbox">
<div class="roundcorner_roundmbox"></div>
<div class="midinner_roundmbox">
<p class="headertxt_roundmbox">Event Details:</p>
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
<div class="arrowlb_roundmbox"></div>
</div>
</div>
</asp:Content>

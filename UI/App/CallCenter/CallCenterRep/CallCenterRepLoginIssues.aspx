<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    Inherits="App_CallCenter_CallCenterRepLoginIssues" CodeBehind="CallCenterRepLoginIssues.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
    function accountLockedChecked()
    {
        var chkUserName=document.getElementById("<%= this.chkUserName.ClientID %>");
        var chkPassword=document.getElementById("<%= this.chkPassword.ClientID %>");
        var chkAccountLocked=document.getElementById("<%= this.chkAccountLocked.ClientID %>");
        if(chkAccountLocked.checked==true)
        {
            chkUserName.disabled=true;
            chkPassword.disabled=true;
            chkUserName.checked=false;
            chkPassword.checked=false;
        }
        else
        {       
            chkUserName.disabled=false;
            chkPassword.disabled=false;
        }
        
    }
    function ValidateLoginIssues()
    {
        var chkUserName=document.getElementById("<%= this.chkUserName.ClientID %>");
        var chkPassword=document.getElementById("<%= this.chkPassword.ClientID %>");
        var chkAccountLocked=document.getElementById("<%= this.chkAccountLocked.ClientID %>");
        if(chkUserName.checked==false && chkPassword.checked==false && chkAccountLocked.checked==false)
        {
            alert("Please select some option and/or click next button to solve the login issue");
            return false;
        }
        return true;
    }
    function checkLoginIssues()
    {
        
        var spbtnNext=document.getElementById("<%=this.spbtnNext.ClientID %>");
        if((spbtnNext.style.display=="" || spbtnNext.style.display=="block"))
        {
            alert("Please select some option and/or click next button to solve the login issue");
            return false;
        }
        return true;
    }

    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750" height="5" /></p>
                    <div class="orngheadtxt_heading" id="dvTitle" runat="server">
                        Login Issues Resolution
                    </div>
                    <div class="headingright_default" id="divCall" runat="server">
                        <div class="endcall_ccrep_dboard">
                            <span class="endtbtn_ccrep_dboard" style="padding-top: 4px;">
                                <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                                    OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                            </span>
                        </div>
                        <div class="timeboard_ccrep_dboard">
                            <div class="timeboxbg_ccrep_dboard">
                                <p class="tboxrow_ccrep_dboard">
                                    <span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span
                                        id="SS"></span></span>
                                </p>
                                <p class="tboxrowformat_ccrep_dboard">
                                    <span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
                                </p>
                                <p class="tboxrowbtm_ccrep_dboard">
                                    <span class="whttxt_ccrep_dboard">Call in Progress</span>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div id="divMessage" runat="server" style="display: none">
                    </div>
                    <div id="divMail" runat="server" style="display: none; font-weight: bold">
                    </div>
                    <%--<div class="headingbox_top_body">
      <p>
      <img src="/App/Images/specer.gif" width="750" height="5" /></p>
      <span class="orngheadtxt_heading" id="sptitle" runat="server"></span>
      <p><img src="/App/Images/specer.gif" width="750" height="5" /></p>
      <div id="divMessage" runat="server" style="display:none"></div>
      <div id="divMail" runat="server" style="display:none;font-weight:bold"> </div>
     </div>--%>
                    <div class="grayboxtop_metr">
                        <p class="grayboxtopbg_metr">
                            <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                        <p class="grayboxheader_metr">
                            Customer Details</p>
                        <div class="lgtgraybox_metr">
                            <div class="lgtgraybow_row_metr">
                                <div style="float: left; width: 130px; height: 137px;">
                                    <p>
                                        <asp:Image runat="server" ID="imgMyPicture" Width="130px" Height="137px" ImageUrl="~/App/Images/No-Image-Found.gif" /></p>
                                </div>
                                <div class="divcustdetails_metr">
                                    <p class="divcustdetailsrow_metr">
                                        <span class="orngheadtxt16_default" style="float: left" runat="server" id="spCustomerName">
                                        </span>
                                    </p>
                                    <p class="divcustdetailsrow_metr">
                                        <span class="titletext1a_default">Address:</span> <span id="spAddress" runat="server"
                                            class="normaltextnowidth_default"></span>
                                    </p>
                                    <p class="divcustdetailsrow_metr" runat="server" id="pmedhistory">
                                        <span class="titletext1a_default">Date of Birth:</span> <span id="spdob" runat="server"
                                            class="normaltextnowidth_default"></span>
                                    </p>
                                    <p class="divcustdetailsrow_metr">
                                        <span class="titletext1a_default">Email:</span> <span runat="server" id="spEmail">
                                        </span>
                                    </p>
                                    <p class="divcustdetailsrow_metr">
                                        <span class="titletext1a_default">User Name:</span> <span id="spUserName" runat="server"
                                            class="normaltextnowidth_default"></span>
                                    </p>
                                    <p class="divcustdetailsrow_metr">
                                        <span class="titletext1a_default">Phone Number:</span> <span id="spPhone" runat="server"
                                            class="normaltextnowidth_default"></span>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <p class="grayboxbotbg_metr">
                            <img src="/App/Images/specer.gif" width="746" height="4" alt="" /></p>
                    </div>
                    <div class="main_area_bdrnone">
                        <div>
                            <img src="/App/Images/CCRep/specer.gif" width="740" height="10" /></div>
                        <div id="Div1" class="pgnosymbolvsmall_common" runat="server">
                            <img id="image1" runat="server" src="/App/Images/page1symbolvsmall.gif" /></div>
                        <div class="orngheadtxt16_common">
                            What issues do you have?
                        </div>
                    </div>
                    <p class="main_area_bdrnone">
                        <span class="ttxtnowidthnormal_default">
                            <img src="/App/Images/specer.gif" width="20" height="20" />
                        </span><span class="ttxtnowidthnormal_default"><span style="float: left; width: 140px;">
                            <asp:CheckBox ID="chkUserName" runat="server" Text="I forgot my username." /></span>
                            <span style="float: left; width: 140px;">
                                <asp:CheckBox ID="chkPassword" runat="server" Text="I forgot my password." /></span>
                            <span style="float: left; width: 140px;">
                                <asp:CheckBox ID="chkAccountLocked" runat="server" Text="My account is locked." /></span>
                        </span>
                    </p>
                    <div id="divSecurityQuestionHeading" style="display: none;" runat="server" class="main_area_bdrnone">
                        <div>
                            <img src="/App/Images/CCRep/specer.gif" width="740" height="10" /></div>
                        <div id="Div2" class="pgnosymbolvsmall_common" runat="server">
                            <img id="image2" runat="server" src="/App/Images/page2symbolvsmall.gif" /></div>
                        <div class="orngheadtxt16_common">
                            Security Question Verification</div>
                    </div>
                    <div id="divSecurityQuestion" style="display: none" runat="server">
                        <div class="main_area_bdrnone">
                            <div class="detailsbox_li">
                                <p class="topbg_li">
                                    <img src="/App/Images/CCRep/topbggbox_logini.gif" /></p>
                                <div class="divmidbox_li">
                                    <p class="divmidboxrow_li">
                                        <span class="ttxtnowidthnormal_default" style="font-weight: bold">Hint Question:
                                        </span><span id="spHintSecurityQuestion" runat="server" class="normaltextnowidth_default">
                                        </span>
                                    </p>
                                    <p>
                                        <img src="../../Images/specer.gif" width="380px" height="5px" /></p>
                                    <p class="divmidboxrow_li">
                                        <span class="ttxtnowidthnormal_default" style="font-weight: bold">Answer: </span>
                                        <span id="spAnswer" runat="server" class="normaltextnowidth_default"></span>
                                    </p>
                                </div>
                                <p class="topbg_li">
                                    <img src="/App/Images/CCRep/botbggbox_logini.gif" /></p>
                            </div>
                        </div>
                    </div>
                    <div class="main_area_bdrnone" id="divVerificationHeading" style="display: none"
                        runat="server">
                        <div>
                            <img src="/App/Images/CCRep/specer.gif" width="740" height="10" /></div>
                        <div id="Div3" class="pgnosymbolvsmall_common" runat="server">
                            <img id="image3" runat="server" src="/App/Images/page3symbolvsmall.gif" /></div>
                        <div class="orngheadtxt16_common">
                            Address/Date of Birth Verification</div>
                    </div>
                    <div style="display: none" id="divVerification" runat="server">
                        <div class="detailsbox_li">
                            <p class="topbg_li">
                                <img src="/App/Images/CCRep/topbggbox_logini.gif" /></p>
                            <div class="divmidbox_li">
                                <p class="divmidboxrow_li">
                                    <span class="ttxtnowidthnormal_default" style="float: left; width: 120px; font-weight: bold">
                                        Address:</span> <span id="spAddress1" runat="server" class="normaltextnowidth_default">
                                        </span>
                                </p>
                                <p>
                                    <img src="../../Images/specer.gif" width="380px" height="5px" /></p>
                                <p class="divmidboxrow_li">
                                    <span class="ttxtnowidthnormal_default" style="float: left; width: 120px; font-weight: bold">
                                        Date of Birth: </span><span id="spDOB1" runat="server" class="ttxtnowidthnormal_default">
                                        </span>
                                </p>
                            </div>
                            <p class="topbg_li">
                                <img src="/App/Images/CCRep/botbggbox_logini.gif" /></p>
                        </div>
                    </div>
                </div>
                <div id="divResolutionheading" style="display: none" runat="server" class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740" height="10" /></div>
                    <div id="Div4" class="pgnosymbolvsmall_common" runat="server">
                        <img id="image4" runat="server" src="/App/Images/page4symbolvsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Resolution
                    </div>
                </div>
                <div id="divResolution" style="display: none" runat="server">
                    <div class="detailsbox_li">
                        <p class="topbg_li">
                            <img src="/App/Images/CCRep/topbggbox_logini.gif" /></p>
                        <div class="divmidbox_li">
                            <p class="divmidboxrow_li">
                                <span id="spYourUserName" class="ttxtnowidthnormal_default" runat="server" style="font-weight: bold">
                                    Your User Name:</span> <span id="spUserN" runat="server" class="normaltextnowidth_default">
                                    </span>
                            </p>
                            <p>
                                <img src="../../Images/specer.gif" width="380px" height="5px" /></p>
                            <p class="divmidboxrow_li">
                                <span id="spYourPwd" class="ttxtnowidthnormal_default" runat="server" style="font-weight: bold">
                                    Your Password:</span> <span id="spPwd" runat="server" class="normaltextnowidth_default">
                                    </span>
                            </p>
                            <p class="divmidboxrow_li">
                                <span id="spMsg" runat="server" class="normaltextnowidth_default" style="float: left;
                                    font-weight: bold;"></span>
                            </p>
                        </div>
                        <p class="topbg_li">
                            <img src="/App/Images/CCRep/botbggbox_logini.gif" /></p>
                    </div>
                </div>
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740" height="20" /></div>
                <p class="graylinefull_feedback">
                    <img src="../../Images/specer.gif" width="1" height="1" /></p>
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740" height="5" /></div>
                <p class="main_area_bdrnone">
                    <span class="buttoncon_default" style="width: 135px;">
                        <asp:ImageButton Style="display: none;" ID="imgbtnResolved" runat="server" ImageUrl="~/App/Images/resolvelogin-btn.gif"
                            OnClick="imgbtnResolved_Click" OnClientClick="return checkLoginIssues();" />
                    </span>
                    <span class="buttoncon_default" style="float: right;" runat="server" id="spbtnNext">
                                <asp:ImageButton ID="imgbtnSubmit" runat="server" ImageUrl="~/App/Images/next-buton.gif"
                                    OnClick="imgbtnSubmit_Click" OnClientClick="return ValidateLoginIssues();"/>
                    </span>
                    <span class="buttoncon_default">
                        <asp:ImageButton ID="ibtncancel" runat="server" ImageUrl="~/App/Images/cancel-btn.gif"
                            OnClick="ibtncancel_Click" />
                    </span>
                    <span class="buttoncon_default" style="float: right;display: none;" runat="server" id="spbtnReset">
                                <asp:ImageButton ID="ibtReset" runat="server" ImageUrl="~/App/Images/reset-btn.gif"
                                    OnClick="ibtReset_Click" />
                    </span>
                </p>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <asp:HiddenField ID="hfSecurityQustion" Value="False" runat="server" />
    <asp:HiddenField ID="hfEmail" Value="False" runat="server" />

    <script type="text/javascript" language="javascript">
     //// this will run after page is load
      var hfCallStartTime= document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);

        $(document).ready(function () {
            checkAndOpenScriptPopup();
        });
    </script>

</asp:Content>

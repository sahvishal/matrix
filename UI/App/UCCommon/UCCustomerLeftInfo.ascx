<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCCustomerLeftInfo"
    CodeBehind="UCCustomerLeftInfo.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>


<script type="text/javascript">
    
    function NextBuild() {
        alert('Please check this in next release');
        return false;


    }

    function popupmenu(choice, wt, ht) {
        //debugger;
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=no,scrollbars=no,menubar=no,resizable=0,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);
    }
</script>
<%--////// Links for Express advocate--%>
<div id="AdvocateLink" runat="server" class="wrapperleft_cstmr" style="display: none">
    <div class="leftheader">
        <div>
            Quick Nav</div>
    </div>
    <div class="wrapper_left2">
        <div class="lftpnlnavnew">
            <a href="../MarketingPartner/AffiliateDashboard.aspx">Advocate DashBoard </a>
            <div id="divPaymentHistory" runat="server">
                <a href="../MarketingPartner/PaymentDetails.aspx">Payment History </a>
            </div>
            <a href="../MarketingPartner/LeadDetails.aspx">Lead History </a><a href="../MarketingPartner/ManageCampaign.aspx">
                Manage Campaign </a><a href="../MarketingPartner/MarketingMaterialSelectionWizard1.aspx">
                    Marketing Material </a><a href="../MarketingPartner/thankyoupage.aspx">Invite Friends
                    </a>
        </div>
    </div>
</div>
<%--////// Links for Advanced advocate--%>
<div id="divAdvanceAdvocate" runat="server" class="wrapperleft_cstmr" style="display: none">
    <div class="leftheader">
        <div>
            Quick Nav</div>
    </div>
    <div class="wrapper_left2">
        <div class="lftpnlnavnew">
            <a href="../MarketingPartner/AffiliateDashboard.aspx">Advocate DashBoard </a><a href="../MarketingPartner/thankyoupage.aspx">
                Invite Friends </a>
        </div>
    </div>
</div>
<%--////// Links for Customer info--%>
<div class="lftpnlcust_midbg" id="dvCustInfo" runat="server">
    <asp:Image runat="server" ID="imgMyPicture" Width="130px" Height="178px" ImageUrl="~/App/Images/No-Image-Found.gif" Visible="false" />
    <div class="cdetails">
        <div runat="server" id="spCustomerName" class="htxt">
        </div>
        <div id="spAddress" runat="server">
        </div>
        <div>
            <a href="/App/Customer/UpdateEventCustomerProfile.aspx?Ref=DashBoard">Edit Profile</a>&nbsp;|&nbsp;
            <a runat="server" id="achangepassword" href="#">Reset Password</a>
        </div>
    </div>
</div>


<%--////// Links to switch between Express and Advcanced version --%>
<div id="dvChangeAdvocateType" style="display: none" runat="server">
    <div class="left" style="display: none" id="dvToExpress" runat="server">
        <asp:ImageButton OnClientClick="if(confirm('Are you sure you want to become express advocate?')){window.location='../MarketingPartner/ChangeAdvanceAdvocate.aspx';}return false;"
            runat="server" ID="Image2" ImageUrl="~/App/Images/downloadtoexpress-banner.jpg" />
    </div>
    <div class="left" style="display: none" id="dvToAdvanced" runat="server">
        <asp:ImageButton OnClientClick="window.location='../MarketingPartner/Welcome.aspx';return false;"
            runat="server" ID="Image1" ImageUrl="~/App/Images/Upgradetoadvance-banner.jpg" />
    </div>
</div>

<%--////// Help Text--%>
<div class="needhlpbox">
    Need Help:<br />
    <span class="greentxt_lft"><%= !string.IsNullOrEmpty(IoC.Resolve<ISettings>().CustomerPortalPhoneTollFree) ? IoC.Resolve<ISettings>().CustomerPortalPhoneTollFree : IoC.Resolve<ISettings>().PhoneTollFree %> (Toll-free)</span>
</div>

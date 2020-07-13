<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Customer/CustomerMaster.master"
    CodeBehind="CustomerFullfillmentOption.aspx.cs" Inherits="Falcon.App.UI.App.Customer.CustomerFullfillmentOption"
    Title="Choose Shipping Option" EnableEventValidation="false" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/UcShippingDetails.ascx" TagPrefix="uc" TagName="ShippingDetail" %>
<%@ Register Src="~/App/UCCommon/EventCustomerInformation.ascx" TagPrefix="EventCustomer"
    TagName="Information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        var GB_ROOT_DIR = "/App/Wizard/greybox/";
        function FirstTimeLoad(resultOrderId) {
            var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
            SelectedOrderRadio.checked = true;
            selectResultOrder(resultOrderId);
        }

        function selectResultOrder(resultOrderId) {

            var hfResultOrderID = document.getElementById("<%= ResultOrderId.ClientID %>");
            var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
            var hfnetpayment = document.getElementById("<%= ResultOrderPrice.ClientID %>");
            if (SelectedOrderRadio.checked == true) {
                var spSalePrice = document.getElementById("spSalePrice" + resultOrderId);
                var spTitle = document.getElementById("spTitle" + resultOrderId);
                hfResultOrderID.value = resultOrderId;
                hfnetpayment.value = spSalePrice.innerHTML;
                var spbillingamount = document.getElementById("<%=spbillingamount.ClientID %>");
                spbillingamount.innerHTML = "$" + spSalePrice.innerHTML;
            }
            return true;
        }

        function showOrderCatalog() {
            var hfResultOrderID = document.getElementById("<%= ResultOrderId.ClientID %>");
            if (parseInt(hfResultOrderID.value) > 0) {
                var SelectedOrderRadio = document.getElementById("rbtn" + hfResultOrderID.value);
                SelectedOrderRadio.checked = true;
                selectResultOrder(parseInt(hfResultOrderID.value));
            }
        }

        function MaintainAfterFailedPostBack() {
        }
        
    </script>

    <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd"><%= IoC.Resolve<ISettings>().CompanyName %> Wellness Dashboard</span>
            <div class="wrapper_llb" id="divLastLogin" runat="server" style="padding-top: 3px">
                <div class="wrapperin_llb">
                    <div>
                        <span id="spLastLogin" runat="server"></span>
                    </div>
                </div>
            </div>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server" />
        </div>
        <div class="wrapper_inpg">
            <h1>
                Shipping Option
            </h1>
            <EventCustomer:Information ID="EventCustomerControl" runat="server" />
            <div class="main_area_bdrnone" style="margin-top: 10px">
                <uc:ShippingDetail ID="ShippingDetailControl" runat="server" />
                <div class="normaltxtpopup_popup" style="margin-top: 10px; width: 100%">
                    <strong>Your total Billing amount is</strong> <span id="spbillingamount" runat="server"
                        class="total-amount-span orngbold12_default">$ 300</span>.</div>
                <div class="main_area_bdrnone">
                    <div class="rgt" style="padding-right: 10px">
                        <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Back"
                            CssClass="button" />
                        <asp:Button ID="NextButton" runat="server" OnClick="NextButton_Click" Text="Next"
                            CssClass="button" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="ResultOrderId" Value="0" />
    <asp:HiddenField runat="server" ID="ResultOrderPrice" Value="0" />
    <asp:HiddenField runat="server" ID="hfGuId" />
</asp:Content>

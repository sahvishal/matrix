<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Customer/CustomerMaster.master" CodeBehind="CustomerAddOnProduct.aspx.cs" 
Inherits="Falcon.App.UI.App.Customer.CustomerAddOnProduct" Title="Purchase Images" EnableEventValidation="false" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/UcShippingDetails.ascx" TagPrefix="uc" TagName="ShippingDetail" %>
<%@ Register Src="~/App/UCCommon/EventCustomerInformation.ascx" TagPrefix="EventCustomer" TagName="Information" %>
<%@ Register Src="~/App/UCCommon/ProductOptions.ascx" TagPrefix="ucProductOption" TagName="ProductOption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                Purchase Images
            </h1>
            <div class="maindivredmsgbox" id="ErrorDiv" runat="server" style="display: none">
            </div>
            <EventCustomer:Information ID="EventCustomerControl" runat="server" />
            <div class="main_area_bdrnone" style="margin-top: 10px; width:450px;">
                <ucProductOption:ProductOption ID="ProductOption" runat="server" />
            </div>
            <div class="fline_regcust"></div>
            <div class="main_area_bdrnone" style="margin-top: 10px">
                <p class="contentrow_regcust">
					<span class="orngsmalltxt_regcust">Select your fulfillment option</span>
                </p>
                <uc:ShippingDetail ID="ShippingDetailControl" runat="server" />
                <div class="normaltxtpopup_popup" style="margin-top: 10px; width: 100%">
                    <strong>Your total Billing amount is</strong> 
                    <span id="spbillingamount" runat="server" class="total-amount-span orngbold12_default"></span>.
                </div>
                <div class="main_area_bdrnone">
                    <div class="rgt" style="padding-right: 10px">
                        <asp:Button ID="BackButton" runat="server" Text="Back" CssClass="button" OnClick="BackButton_Click" />
                        <asp:Button ID="NextButton" runat="server"  Text="Next" CssClass="button" OnClick="NextButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="ResultOrderId" Value="0" />
    <asp:HiddenField runat="server" ID="ResultOrderPrice" Value="0" />
    <asp:HiddenField runat="server" ID="hfGuId" />

    <script type="text/javascript" language="javascript">
        function FirstTimeLoad(resultOrderId) {
            $("#rbtn" + resultOrderId).attr("checked", true);
            selectResultOrder(resultOrderId);
        }

        var imagePrice = 0;
        var shippingPrice = 0;
        function selectResultOrder(resultOrderId) {//debugger;
            var resultOrderPrice = document.getElementById("<%= ResultOrderPrice.ClientID %>");
            if ($("#rbtn" + resultOrderId).is(':checked')) {
                shippingPrice = parseFloat($('#spSalePrice' + resultOrderId).html());          
                $("#<%= ResultOrderId.ClientID %>").val(resultOrderId);                
                $("#<%= ResultOrderPrice.ClientID %>").val(shippingPrice)
                var totalPrice = imagePrice + shippingPrice;
                $('#<%=spbillingamount.ClientID %>').html("$" + totalPrice.toFixed(2));
            }
            return true;
        }

        function showOrderCatalog() {
            var hfResultOrderID = $("#<%= ResultOrderId.ClientID %>");       
            if (parseInt(hfResultOrderID.val()) > 0) {
                $("#rbtn" + hfResultOrderID.val()).attr("checked", true);
                selectResultOrder(parseInt(hfResultOrderID.val()));
            }
        }

        function MaintainAfterFailedPostBack() {
            var hfResultOrderID = $("#<%= ResultOrderId.ClientID %>");            
            $("#rbtn" + hfResultOrderID.val()).attr("checked", true);
            selectResultOrder(parseInt(hfResultOrderID.val()));
        }

        function SetProduct(productName, productPrice, test) {
            imagePrice = productPrice;
            $('#<%=spbillingamount.ClientID %>').html("$" + imagePrice.toFixed(2));
        }

        $(document).ready(function () {
            ShowHideProduct();
        });
    </script>
</asp:Content>

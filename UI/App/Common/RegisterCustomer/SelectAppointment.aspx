<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    CodeBehind="SelectAppointment.aspx.cs" Inherits="Falcon.App.UI.App.Common.RegisterCustomer.SelectAppointment"
    Title="Select Appointment and Fullfillment Option" EnableEventValidation="false" %>

<%@ Register Src="~/App/UCCommon/UCEventAppointment.ascx" TagName="UCEventAppointment"
    TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/OrderSummary.ascx" TagName="OrderSummary" TagPrefix="SummaryControl" %>
<%@ Register Src="~/App/UCCommon/UcShippingDetails.ascx" TagPrefix="uc" TagName="ShippingOption" %>
<%@ Register Src="~/App/UCCommon/ProductOptions.ascx" TagPrefix="uc" TagName="Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <script type="text/javascript" language="javascript">

        function NextButtonClick() {//debugger;
            OpenUpsellCDDialog(Validation);
            return false;
        }

        function Validation() {

            if (!isAppointmentSelected()) {
                alert("Please select an appointment.");
                return false;
            }

            var hfResultOrderID = document.getElementById("<%= hfResultOrderId.ClientID %>");
            if (!ValidateShippingAddress())
                return false;
            __doPostBack('NextButton', 'Click');
        }

        function selectResultOrder(resultOrderId) {//debugger

            var hfResultOrderID = document.getElementById("<%= hfResultOrderId.ClientID %>");
            var hfResultOrderPrice = document.getElementById("<%= hfResultOrderPrice.ClientID %>");
            var hfResultOrderDesc = document.getElementById("<%= hfResultOrderDesc.ClientID %>");

            var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
            if (SelectedOrderRadio.checked == true) {
                var spSalePrice = document.getElementById("spSalePrice" + resultOrderId);
                var spTitle = document.getElementById("spTitle" + resultOrderId);
                hfResultOrderID.value = resultOrderId;
                hfResultOrderPrice.value = spSalePrice.innerHTML;
                hfResultOrderDesc.value = spTitle.innerHTML;

                SetFulfillmentOption(spTitle.innerHTML, spSalePrice.innerHTML);
            }
            return true;
        }

        function FirstTimeLoad(resultOrderId) {//debugger
            var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
            SelectedOrderRadio.checked = true;
            selectResultOrder(resultOrderId);
        }

        function MaintainAfterFailedPostBack() {
            //for maintaing state after postback made for applying coupon
            var hfResultOrderID = document.getElementById("<%= this.hfResultOrderId.ClientID %>");
            var SelectedOrderRadio = document.getElementById("rbtn" + hfResultOrderID.value);
            SelectedOrderRadio.checked = true;
            selectResultOrder(parseInt(hfResultOrderID.value));
        }
    </script>
    
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="TitleDiv" runat="server">Technician Register Customer</span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="ErrorDiv" runat="server" visible="false">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div>
                        <img src="/App/Images/specer.gif" width="740px" height="10px" /></div>
                    <div class="pgnosymbol_regcust">
                        <img src="/App/Images/CCRep/page4symbol.gif" id="SymbolImage" runat="server" />
                    </div>
                    <div class="middivrow_regcust" style="width: 420px;">
                        <div id="divSlots" runat="server" style="float: left; width: 420px;">
                            <div style="display: none;">
                                <p class="contentrow_regcust" style="width: 420px;">
                                    <span class="orngbold16_default">Select Appointment Time most suitable for you:</span></p>
                                <p class="fline_regcust" style="width: 420px;">
                                    <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                <p class="contentrow_regcust" style="width: 420px;">
                                    <span class="orngbold12_default">Select time most suitable for you:</span></p>
                                <p class="contentrow_regcust" style="text-align: center; width: 420px;">
                                    <span class="centertxtfieldcon_pw">
                                        <asp:TextBox ID="txtSlot" runat="server" CssClass="inputblue_pw" ReadOnly="true"
                                            Text="" Width="180px"></asp:TextBox>
                                    </span>
                                </p>
                                <p class="both">
                                </p>
                                <p class="contentrow_pw" style="text-align: center">
                                    <span class="centertxtfieldcon_pw">
                                        <asp:Label runat="server" ID="lblTimeZone" CssClass="gridselectpackage_testname" />
                                    </span>
                                </p>
                            </div>
                            <div style="float: left;">
                                <uc1:UCEventAppointment ID="_ucEventAppointment1" runat="server" />
                            </div>
                        </div>                        
                        <p class="fline_regcust">
                            <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                        <div style="float: left; width: 420px;" id="ProductOptionDiv">
                            <div class="dgselectpackage_ccrep">
                                <uc:Product ID="ProductOption" runat="server" />
                            </div>
                            <div class="fline_regcust" style="width: 420px;">
                            </div>
                        </div>
                        <div id="divOrderCatalog" runat="server" style="width: 420px; float: left;">
                            <p class="contentrow_regcust" style="margin-top: 15px; width: 420px;">
                                <span class="orngbold12_default">Select your fulfillment option</span></p>
                            <p class="fline_regcust" style="width: 420px;">
                                <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                            <div class="dgselectpackage_ccrep" style="width: 420px;">
                                <uc:ShippingOption ID="ResultOption" runat="server" />
                            </div>
                        </div>
                        <p class="fline_regcust" style="width: 420px;">
                            <img src="/App/Images/CCRep/specer.gif" width="1px" height="10px" /></p>
                        <p class="buttoncell_ccrep">
                            <span class="buttoncon_ccrep">
                                <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-button.gif"
                                    OnClick="ibtnBack_Click" />
                            </span><span class="buttoncon_ccrep">
                                <asp:ImageButton ID="ibtnSubmit" runat="server" ImageUrl="~/App/Images/next-buton.gif"
                                    OnClientClick="return NextButtonClick();" />
                            </span>
                        </p>
                    </div>
                    <div style="width: 255px; float: right; margin-top: 50px">
                        <SummaryControl:OrderSummary ID="OrderSummaryControl" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <asp:HiddenField runat="server" ID="hfResultOrderId" Value="0" />
    <asp:HiddenField runat="server" ID="hfResultOrderPrice" Value="" />
    <asp:HiddenField runat="server" ID="hfResultOrderDesc" />
    
    <script type="text/javascript">
        $(document).ready(function () {
            _setOrderSummaryAppointmentTime = SetAppointmentTime;
        });
    </script>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true"
	CodeBehind="SelectAppointment.aspx.cs" Inherits="Falcon.App.UI.App.Customer.SelectAppointment" EnableEventValidation="false" %>

<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/UCEventAppointment.ascx" TagName="UCEventAppointment"
	TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/UcShippingDetails.ascx" TagPrefix="uc" TagName="ShippingOption" %>
<%@ Register Src="~/App/UCCommon/OrderSummary.ascx" TagName="OrderSummary" TagPrefix="SummaryControl" %>
<%@ Register Src="~/App/UCCommon/ProductOptions.ascx" TagPrefix="uc" TagName="Product" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

			if (!ValidateShippingAddress())
				return false;
			__doPostBack('NextButton', 'Click');
		}

		function selectResultOrder(resultOrderId, disclaimer) {//debugger

			var hfResultOrderID = document.getElementById("<%= this.hfResultOrderID.ClientID %>");
			var hfResultOrderPrice = document.getElementById("<%= this.hfResultOrderPrice.ClientID %>");
			var hfResultOrderDesc = document.getElementById("<%= this.hfResultOrderDesc.ClientID %>");

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

		function FirstTimeLoad(resultOrderId, disclaimer) {//debugger
			var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
			var hfHideDisclaimer = document.getElementById("<%=this.hfHideDisclaimer.ClientID %>");
			hfHideDisclaimer.value = resultOrderId;
			SelectedOrderRadio.checked = true;
			selectResultOrder(resultOrderId, disclaimer);
		}
	</script>
	
	<div class="maindiv_custdbrd">
		<div class="mindivbgblue_custdbrd">
			<span class="divheadtxt_custdbrd">Register Event</span>
		</div>
		<div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
			<CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
		</div>
		<div class="main_area_custdbrd">
			<div class="main_row_custdbrd">
				<div class="divsteps_re">
					<img src="../Images/Customer_step4n.gif" alt="" />
				</div>
				<div class="maindivredmsgbox" id="ErrorDiv" runat="server" visible="false">
				</div>
				<div class="main_area_bdrnone" style="width: 485px;">					
					<div class="dgselecttime_pw" style="width: 470px;">
						<uc1:UCEventAppointment ID="_ucEventAppointment1" runat="server" />
					</div>
					<div id="divOrderCatalog" runat="server">
                        <p class="fline_re" style="width: 470px;">
							<img src="../Images/specer.gif" width="1px" height="1px" /></p>
                        <div class="dgselectpackage_re" style="width: 470px;" id="ProductOptionDiv">
                            <uc:Product ID="ProductOption" runat="server" />
                        </div>
						<p class="fline_re" style="width: 470px;">
							<img src="../Images/specer.gif" width="1px" height="1px" /></p>
						<p class="contentrow_regcust" style="width: 470px;">
							<span class="orngsmalltxt_regcust">Select your fullfillment option</span></p>
						<p class="fline_regcust" style="width: 470px;">
							<img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
						<div class="dgselectpackage_re" style="width: 470px;">
							<uc:ShippingOption ID="ResultOtion" runat="server" />
							<p class="fline_re" style="width: 470px;">
								<img src="../Images/specer.gif" width="1px" height="1px" /></p>
						</div>
					</div>
					<p style="width: 470px; margin-bottom: 10px;">
						<img src="../Images/specer.gif" width="1px" height="1px" /></p>
					<div class="btnrows_re" style="width: 470px;">
						<span class="buttoncon_re">
							<asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="~/App/Images/next-buton.gif"
								OnClientClick="return NextButtonClick();" />
						</span><span class="buttoncon_re">
							<asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-button.gif"
								OnClick="ibtnBack_Click" />
						</span>
					</div>
				</div>
				<div style="width: 255px; float: right; margin-top: 50px">
					<SummaryControl:OrderSummary ID="OrderSummaryControl" runat="server" />
				</div>
			</div>
			<div class="both">
				<img src="../Images/specer.gif" width="1px" height="10px" /></div>
		</div>
	</div>
	<asp:HiddenField ID="hfAppointmentID" runat="server"></asp:HiddenField>
	<asp:HiddenField ID="hfAppointTime" runat="server" />
	<asp:HiddenField runat="server" ID="hfResultOrderID" Value="0" />
	<asp:HiddenField runat="server" ID="hfResultOrderPrice" Value="0" />
	<asp:HiddenField runat="server" ID="hfResultOrderDesc" />
	<asp:HiddenField runat="server" ID="hfHideDisclaimer" Value="0" />
    
    <script type="text/javascript">
        $(document).ready(function () {
            _setOrderSummaryAppointmentTime = SetAppointmentTime;
        });
    </script>
</asp:Content>

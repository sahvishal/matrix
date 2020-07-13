<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="True"
	Inherits="Falcon.App.UI.App.Customer.SelectPackage" CodeBehind="SelectPackage.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/OrderItemCart.ascx" TagName="ItemCart" TagPrefix="Order" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<uc:_jQueryToolKit ID="ucJquery" IncludeAjax="true" runat="server" IncludeJQueryUI="true" />

	<script language="javascript" type="text/javascript">

		var GB_ROOT_DIR = "/App/Wizard/greybox/";
		var isSourceCodeApplied = false;
		//var isShowPreQualificationQuestions = true;
		function SelectPackage() {

			// Set the shopping cart data from the control on the page....
			$('#<%= PackageIdHiddenControl.ClientID %>').val($('#PackageIdHiddenControl').val());
			$('#<%= IndependentTestIdsHiddenControl.ClientID %>').val($('#IndependentTestIdsHiddenControl').val());
			$('#<%=TestIdsHiddenControl.ClientID %>').val($('#TestIdsHiddenControl').val());
			$('#<%= dvSelectedPackageAmt.ClientID %>').text($('#OfferPriceSpan').text());
			$('#<%= hfPackageCost.ClientID %>').val($('#OfferPriceSpan').text());
			$('#<%= dvSelectedPackageDesc.ClientID %>').text($('#PackageDescriptionHidden').val());
			$('#<%= hfPackageDesc.ClientID %>').val($('#PackageDescriptionHidden').val());

			var packageAndTestCost = parseFloat($('#OfferPriceSpan').text());

			$('#<%= dvTotalAmount.ClientID %>').text((packageAndTestCost).toFixed(2));
			$('#<%= dvTotalBill.ClientID %>').text((packageAndTestCost).toFixed(2));
			$('#<%= hfTotalAmount.ClientID %>').val($('#<%= dvTotalAmount.ClientID %>').text());

			//Since the package is changed cancel the previous applied coupon....
			$('#dvCoupon').hide();
			$('#dvCouponDesc').text('');
			$('#<%= dvCouponAmt.ClientID %>').text('0.00');

			var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
			if ($.trim(txtCouponCode.val()).length > 0 && isSourceCodeApplied)
				CouponValidation();
			return true;
		}        
	</script>

	<script language="javascript" type="text/javascript">
		function fnToggle() {
			oTransContainer.filters[0].Apply();
			oTransContainer.filters[0].Play();
		}

		function NextButtonClick() {
			PlaceOrderClick(Validation);
			return false;
		}

		function Validation() {
			var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
			var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

			if (packageId == '0' && testIds == '0') {
			    if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
			        alert("Please select a Package or tests.");
			    else
			        alert("Please select a Package.");
			    return false;
			}

			if (parseFloat($('#<%= dvSelectedPackageAmt.ClientID %>').text()) < parseFloat('<%=MinimumPurchaseAmount %>')) {
				alert('The minimum price of the order should be ' + '<%=MinimumPurchaseAmount %>');
				return false;
			}

			__doPostBack('NextButton', 'Click');
		}



		function CancelClick() {
			return confirm("Are you sure you want to cancel.");
		}
		/// format the value passed as a numeric value with 2 decimal places

		function formatAmount(num) {
			if (isNaN(parseFloat(num))) {
				num = '0.00';
			}
			return parseFloat(num);
			try {
				num = num.replace(/^\s+|\s+$/g, "");
			}
			catch (err) {
				num = num
			}
			num = parseFloat(num);
			if (isNaN(num)) {
				num = '0.00';
			}
			return parseFloat(num.toFixed(2));
		}


		function ApplyCouponAmount(result) {
			//for maintaing state after postback made for applying coupon
			var hfPackageCost = document.getElementById("<%= hfPackageCost.ClientID %>");
			var hfPackageDesc = document.getElementById("<%=hfPackageDesc.ClientID %>");
			var dvSelectedPackageAmt = document.getElementById("<%= dvSelectedPackageAmt.ClientID %>");
			var dvSelectedPackageDesc = document.getElementById("<%= dvSelectedPackageDesc.ClientID %>");
			dvSelectedPackageAmt.innerHTML = (formatAmount(hfPackageCost.value)).toFixed(2);
			dvSelectedPackageDesc.innerHTML = hfPackageDesc.value;

			var spIndicator = document.getElementById("spIndicator");
			spIndicator.style.visibility = "hidden";
			spIndicator.style.display = "none";

			var model = result;

			var dvCouponError = document.getElementById("dvCouponError");
			var hfCouponCode = document.getElementById("<%= hfCouponCode.ClientID %>");
			var CouponDiscount = formatAmount(model.DiscountApplied).toFixed(2);
			var dvTotalAmount = document.getElementById("<%= dvTotalAmount.ClientID %>");
			var txtCouponCode = document.getElementById("<%= txtCouponCode.ClientID %>");
			
			var dvTotalBill = document.getElementById("<%= dvTotalBill.ClientID %>");

			var dvCouponDesc = document.getElementById("dvCouponDesc");
			var dvCouponAmt = document.getElementById("<%= dvCouponAmt.ClientID %>");
			var hfTotalAmount = document.getElementById("<%= hfTotalAmount.ClientID %>");
			///Reset every thing
			dvCouponDesc.innerHTML = "";

			hfCouponCode.value = " ";
			var previousCouponDisc = dvCouponAmt.innerHTML;
			dvCouponAmt.innerHTML = " ";

			var dvSelectedPackageAmt = document.getElementById("<%= dvSelectedPackageAmt.ClientID %>");
			dvTotalAmount.innerHTML = (parseFloat(formatAmount(dvSelectedPackageAmt.innerHTML))).toFixed(2);
			dvTotalBill.innerHTML = (parseFloat(dvTotalAmount.innerHTML)).toFixed(2);

			hfTotalAmount.value = dvCouponAmt.innerHTML;
			var dvCoupon = document.getElementById("dvCoupon");

			////// If the Coupon return error
			if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
			    alert(els.childNodes[1].childNodes[0].nodeValue);
			    hfCouponCode.value = "";
			    dvCoupon.style.display = 'none';
			    SetSourceCodeDiscount(0);
			    ShowHideSourceCodeAmountDiv(false);
			    isSourceCodeApplied = false;
			    return false;
			} //if coupon amount is 0.00
			else if (model.SourceCodeId > 0 && formatAmount(model.DiscountApplied).toFixed(2) == "0.00") {
			    hfCouponCode.value = "";
			    dvCoupon.style.display = 'none';
			    SetSourceCodeDiscount(0);
			    ShowHideSourceCodeAmountDiv(true);
			    isSourceCodeApplied = true;
			    return false;
			}
			

			dvCoupon.style.display = '';
			dvCouponError.innerHTML = "";
			var divErrortop = document.getElementById("<%= divErrortop.ClientID %>");
			divErrortop.style.display = 'none';


			hfCouponCode.value = model.SourceCode;   //txtCouponCode.value;			
			dvCouponAmt.innerHTML = (parseFloat(formatAmount(CouponDiscount))).toFixed(2);

			dvTotalAmount.innerHTML = (parseFloat(formatAmount(dvSelectedPackageAmt.innerHTML)) - formatAmount(CouponDiscount)).toFixed(2);
			dvTotalBill.innerHTML = (parseFloat(dvTotalAmount.innerHTML)).toFixed(2);

			hfTotalAmount.value = dvCouponAmt.innerHTML;
			var hfTempTotalAmount = document.getElementById("<%=hfTempTotalAmount.ClientID %>");
			var hfCouponDesc = document.getElementById("<%=hfCouponDesc.ClientID %>");
			hfTempTotalAmount.value = dvTotalBill.innerHTML;
			SetSourceCodeDiscount((parseFloat(formatAmount(CouponDiscount))).toFixed(2));
			ShowHideSourceCodeAmountDiv(true);
			isSourceCodeApplied = true;
			hfCouponDesc.value = dvCouponDesc.innerHTML;

			if (hfTempTotalAmount.value == "0.00") {

			}
			return false;

		}

		function CouponValidation() {
		    var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
		    if(txtCouponCode.val()=='')
		    {
		        alert('Please enter source code.');
		        return false;
		    }
			var packageId = $('#<%= PackageIdHiddenControl.ClientID %>').val();
			var testIds = $('#<%=TestIdsHiddenControl.ClientID %>').val();

			if (packageId == '0' && testIds == '0') {
			    if ('<%= EnableAlaCarte %>' == '<%= Boolean.TrueString %>')
			        alert("Please select atlest one package or a test to avail the coupon.");
			    else
			        alert("Please select atlest one package to avail the coupon.");
			    return false;
			}

			var hfCouponApplied = document.getElementById("<%= hfCouponApplied.ClientID %>");
			hfCouponApplied.Value = "1";

			var spIndicator = document.getElementById("spIndicator");
			spIndicator.style.visibility = "visible";
			spIndicator.style.display = "block";

			var dvSelectedPackageAmt = $("#<%= dvSelectedPackageAmt.ClientID %>");
			var hfEventID = $("#<%= hfEventID.ClientID %>");

			var parameter = "{'packageId':'" + $.trim(packageId) + "'";
			parameter += ",'addOnTestIds':'" + $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val() + "'";
			parameter += ",'orderTotal':'" + dvSelectedPackageAmt.text() + "'";
			parameter += ",'couponCode':'" + txtCouponCode.val() + "'";
			parameter += ",'eventId':'<%= EventId %>'";
			parameter += ",'customerId':'<%= CustomerId %>'}";

			var messageUrl = '<%=ResolveUrl("~/App/Customer/SelectPackage.aspx/GetCoupon")%>';
			var successFunction = function(result) {
				ApplyCouponAmount(result.d);
			};
			var errorFunction = function() {
				alert('There was a problem retrieving the data, please try again later.');
				spIndicator.style.visibility = "hidden";
				spIndicator.style.display = "none";
			}
			InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
			return false;
		}

		function MaintainAfterFailedPostBack() {

			//for maintaing state after postback made for applying coupon
			var hfPackageCost = document.getElementById("<%= this.hfPackageCost.ClientID %>");
			var hfPackageDesc = document.getElementById("<%=this.hfPackageDesc.ClientID %>");
			var dvSelectedPackageAmt = document.getElementById("<%= this.dvSelectedPackageAmt.ClientID %>");
			var dvSelectedPackageDesc = document.getElementById("<%= this.dvSelectedPackageDesc.ClientID %>");
			dvSelectedPackageAmt.innerHTML = (formatAmount(hfPackageCost.value)).toFixed(2);
			dvSelectedPackageDesc.innerHTML = hfPackageDesc.value;
		}
	</script>

	<style type="text/css">
		/*---------- bubble tooltip -----------*/a.tt
		{
			position: relative;
			z-index: 24;
			color: #3CA3FF;
			font-weight: bold;
			text-decoration: none;
		}
		a.tt span
		{
			display: none;
		}
		/*background:; ie hack, something must be changed in a for ie to execute it*/a.tt:hover
		{
			z-index: 25;
			color: #EE8111;
		}
		a.tt:hover span.tooltip
		{
			display: block;
			position: absolute;
			top: 0px;
			left: 0;
			padding: 10px 0 0 50px;
			width: 480px;
			color: #000;
			text-align: right;
			filter: alpha(opacity:90);
			khtmlopacity: 0.90;
			mozopacity: 0.90;
			opacity: 0.90;
			text-decoration: none;
		}
		a.tt:hover span.top
		{
			display: block;
			padding: 30px 8px 0px;
			background: url(/Public/Images/bubblebig25.gif) no-repeat top;
			text-decoration: none;
		}
		a.tt:hover span.middle
		{
			/* different middle bg for stretch */
			display: block;
			padding: 0 8px;
			background: url(/Public/Images/bubblefillerbig25.gif) repeat bottom;
			text-decoration: none;
		}
		a.tt:hover span.bottom
		{
			display: block;
			padding: 3px 8px 10px;
			color: #548912;
			background: url(/Public/Images/bubblebig25.gif) no-repeat bottom;
			text-decoration: none;
		}
	</style>
	<div class="maindiv_custdbrd">
		<div class="mindivbgblue_custdbrd">
			<span class="divheadtxt_custdbrd">Register Event</span>
		</div>
		<div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
			<CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
		</div>
		<div class="main_area_custdbrd">
			<div class="main_row_custdbrd">
				<div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
				</div>
				<div class="main_area_bdrnone">
					<div class="divsteps_re">
						<img src="../Images/Customer_step3n.gif" alt="" />
					</div>
					<div class="maincontentrow_re">
						<p class="maincontentrow_re">
							<span class="orngheadtxt_regcust">Place Order</span></p>
					</div>
					<div class="dgselectpackage_re" style="width: 700px;">
						<Order:ItemCart ID="ItemCartControl" runat="server" />
						<div class="sourcecode" id="SourceCodeApplyDiv">
							<asp:Panel ID="pnlSourceCode" DefaultButton="imgCouponApply" runat="server">
								<p >
									<span><b>Enter Source Code:</b></span>
									<span style="padding-left:10px">
										<asp:TextBox ID="txtCouponCode" runat="server" CssClass="inputfield_ccrep" Width="100px"></asp:TextBox></span>
									<span class="applycpnbtncon_ccrep" style="float:right;width:auto;padding-top:5px;">
										<asp:ImageButton ID="imgCouponApply" runat="server" ImageUrl="~/App/Images/apply-btn.gif"
											OnClientClick="return CouponValidation();"></asp:ImageButton>
									</span>
									<span id="spIndicator" style="visibility: hidden; display: none;">
										<img id="imgIdicator" src="/Public/images/indicator.gif" />
									</span>
								</p>
							</asp:Panel>
							<div style="clear:both;"></div>
						</div>
					</div>
					<div id="BillingInformationDiv" style="display: none">
						<p class="fline_re" style="width: 430px;">
						</p>
						<p class="contentrow_regcust" style="width: 430px;">
							<span class="orngsmalltxt_regcust">Billing Information</span></p>
						<p class="fline_re" style="width: 430px;">
						</p>
						<p class="contentrow_regcust" style="font: 12px arial">
							Amount due: <strong>$<span runat="server" id="dvTotalAmount">0.00</span></strong>.
						</p>
						<div class="dgselectpackage_ccrep" style="width: 430px;">
							<table class="gridbillinfo" cellpadding="0" cellspacing="0" border="0" id="dgBill"
								style="border-collapse: collapse;">
								<tr class="row1">
									<td>
										Name / Description
									</td>
									<td style="width: 50px">
										Quantity
									</td>
									<td style="width: 61px" align="right">
										Amount
									</td>
								</tr>
								<tr class="row2" id="dvSelectedPackage">
									<td id="dvSelectedPackageDesc" runat="server">
										Please select Package
									</td>
									<td style="width: 50px">
										01
									</td>
									<td align="right" style="width: 61px;">
										<span style="width: 25px; text-align: left;">$</span> <span id="dvSelectedPackageAmt"
											runat="server">0.00</span>
									</td>
								</tr>
								<tr id="dvCoupon" style="display: none" class="row2">
									<td id="dvCouponDesc">
										&nbsp;
									</td>
									<td style="width: 50px">
										01
									</td>
									<td align="right" style="width: 61px;">
										<span style="width: 25px; text-align: left;">(-)$</span> <span id="dvCouponAmt" runat="server">
											0.00</span>
									</td>
								</tr>
								<tr class="footer">
									<td>
										Total
									</td>
									<td style="width: 50px">
									</td>
									<td align="right" style="width: 70px">
										<span>$</span> <span id="dvTotalBill" runat="server">0.00</span>
									</td>
								</tr>
							</table>
						</div>
						<div>
							<img src="/App/Images/CCRep/specer.gif" width="430px" height="10px" /></div>
						<div id="divErrortop" runat="server" style="display: none;">
							<p class="topbg_ccreperrormsg">
							</p>
							<div class="midbg_ccreperrormsg">
								<span style="float: left; width: 20px; padding: 0px 10px 0px 10px">
									<img src="/App/Images/error-icon.gif" alt="" /></span> <span id="dvCouponError" class="txt_errormsgyellow">
									</span>
							</div>
							<p class="botbg_ccreperrormsg">
							</p>
						</div>
						<p style="width: 430px">
							<img src="../Images/specer.gif" width="1px" height="10px" border="1px solid red" /></p>
						<p>
							<img src="../Images/specer.gif" width="600px" height="10px" border="1px solid red" /></p>
					</div>
					
					<p class="fline_re"></p>
					
					<div class="btnrows_re">
						<span class="buttoncon_re">
							<asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="~/App/Images/next-buton.gif"
								OnClientClick="return NextButtonClick();" />
						</span><span class="buttoncon_re">
							<asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-button.gif"
								OnClick="ibtnBack_Click" />
						</span>
					</div>
				</div>
			</div>
		</div>
	</div>
	<asp:HiddenField ID="hfEventID" runat="server" />
	<asp:HiddenField ID="hfCouponCode" runat="server" />
	<asp:HiddenField ID="hfTotalAmount" runat="server" />
	<asp:HiddenField runat="server" ID="HiddenField1" />
	<asp:HiddenField ID="hfOnsitePayment" runat="server" Value="0" />
	<asp:HiddenField ID="hfBillingAddress" runat="server" Value="1" />
	<asp:HiddenField ID="hfCouponApplied" runat="server" Value="0" />
	<asp:HiddenField ID="hfTempTotalAmount" runat="server" />
	<asp:HiddenField ID="hfTempNetAmount" runat="server" />
	<asp:HiddenField ID="hfCouponDesc" runat="server" />
	<asp:HiddenField ID="hfEmailRprt" runat="server" Value="0" />
	<asp:HiddenField ID="hfPackageCost" runat="server" />
	<asp:HiddenField ID="hfPackageDesc" runat="server" />
	<asp:HiddenField ID="hfSelectedPackageRadio" runat="server" Value="" />
	<asp:HiddenField ID="PackageIdHiddenControl" runat="server" />
	<asp:HiddenField ID="TestIdsHiddenControl" runat="server" />
	<asp:HiddenField ID="IndependentTestIdsHiddenControl" runat="server" />
</asp:Content>

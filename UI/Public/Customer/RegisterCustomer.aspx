<%@ Page Language="C#" MasterPageFile="~/Public/Public.master" AutoEventWireup="true"
	Inherits="Falcon.App.UI.Public.Customer.RegisterCustomer" CodeBehind="RegisterCustomer.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc" %>

<%@ Register Src="~/App/UCCommon/OrderItemCart.ascx" TagName="ItemCart" TagPrefix="Order" %>
<%@ Register Src="~/App/UCCommon/SponsoredByInfo.ascx" TagPrefix="uc2" TagName="SponsoredByInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<uc:_jQueryToolKit ID="ucJquery" IncludeAjax="true" runat="server" IncludeJQueryUI="true" />

	<script language="javascript" type="text/javascript">
		$(function() {
			$('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 400 });
		});

		//script for hand icon change in baloons tooltip 
		function changetodefault(spanId) {
			document.getElementById(spanId).style.cursor = "default";
		}
		function changetopointer(spanId) {
			document.getElementById(spanId).style.cursor = "pointer";
		}

		$(document).ready(function () {
		    var decoded = $("<textarea/>").html($("#<%=spErrorMsgtop.ClientID %>").html()).text();
		    $("#<%=spErrorMsgtop.ClientID %>").html(decoded);

		    decoded = $("<textarea/>").html($("#<%=spErrorMsgbottom.ClientID %>").html()).text();
		    $("#<%=spErrorMsgbottom.ClientID %>").html(decoded);
         });
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
			background: url(/Content/images/bubblebig25.gif) no-repeat top;
			text-decoration: none;
		}
		a.tt:hover span.middle
		{
			/* different middle bg for stretch */
			display: block;
			padding: 0 8px;
			background: url(/Content/images/bubblefillerbig25.gif) repeat bottom;
			text-decoration: none;
		}
		a.tt:hover span.bottom
		{
			display: block;
			padding: 3px 8px 10px;
			color: #548912;
			background: url(/Content/images/bubblebig25.gif) no-repeat bottom;
			text-decoration: none;
		}
	</style>

	<script type="text/javascript" src="/Content/JavaScript/HttpRequest.js"></script>    

	<script language="javascript" type="text/javascript">

		String.prototype.trim = function() {
			a = this.replace(/^\s+/, '');
			return a.replace(/\s+$/, '');
		};
		var isSourceCodeApplied = false;
		
		function NextButtonClick() {
			PlaceOrderClick(Validation);
			return false;
		}

		function SelectPackage() {

			// Set the shopping cart data from the control on the page....
			$('#<%= PackageIdHiddenControl.ClientID %>').val($('#PackageIdHiddenControl').val());
			$('#<%= IndependentTestIdsHiddenControl.ClientID %>').val($('#IndependentTestIdsHiddenControl').val());
			$('#<%=TestIdsHiddenControl.ClientID %>').val($('#TestIdsHiddenControl').val());
			$('#dvSelectedPackageAmt').text($('#OfferPriceSpan').text());
			$('#<%= hfPackageCost.ClientID %>').val($('#OfferPriceSpan').text());
			$('#dvSelectedPackageDesc').text($('#PackageDescriptionHidden').val());

			var shippingCost = parseFloat(formatAmount($('#dvReportEmailAmt').text()));
			var packageAndTestCost = parseFloat($('#OfferPriceSpan').text());

			$('#<%= dvTotalAmount.ClientID %>').text((shippingCost + packageAndTestCost).toFixed(2));
			$('#dvTotalBill').text((shippingCost + packageAndTestCost).toFixed(2));
			$('#<%= hfTotalAmount.ClientID %>').val($('#<%= dvTotalAmount.ClientID %>').text());

			//Since the package is changed cancel the previous applied coupon....
			$('#dvCoupon').hide();
			$('#dvCouponDesc').text('');
			$('#dvCouponAmt').text('0.00');

			var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
			if ($.trim(txtCouponCode.val()).length > 0 && isSourceCodeApplied) {
			    CouponValidation();
			}
			return true;
		}
            
	</script>

	<script language="javascript" type="text/javascript">
		var postRequest = new HttpRequest();
		postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		postRequest.failureCallback = requestFailed();

		function requestFailed() {

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

			var spIndicator = document.getElementById("spIndicator");
			spIndicator.style.visibility = "visible";
			spIndicator.style.display = "block";

			var dvSelectedPackageAmt = $("#dvSelectedPackageAmt");
			var hfEventID = $("#<%= hfEventID.ClientID %>");

			var customerId = '<%=CustomerId %>';

			var parameter = "{'packageId':'" + $.trim(packageId) + "'";
			parameter += ",'addOnTestIds':'" + $('#<%= IndependentTestIdsHiddenControl.ClientID %>').val() + "'";
			parameter += ",'orderTotal':'" + dvSelectedPackageAmt.text() + "'";
			parameter += ",'couponCode':'" + txtCouponCode.val() + "'";
			parameter += ",'eventId':'" + hfEventID.val() + "'";
			parameter += ",'customerId':'<%= CustomerId %>'}";
			var messageUrl = '<%=ResolveUrl("~/Public/Customer/RegisterCustomer.aspx/GetCoupon")%>';
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


		function ApplyCouponAmount(result) {
			var spIndicator = document.getElementById("spIndicator");
			spIndicator.style.visibility = "hidden";
			spIndicator.style.display = "none";

			var model = result;

			var dvCouponError = document.getElementById("dvCouponError");
			var hfCouponCode = document.getElementById("<%= hfCouponCode.ClientID %>");
			var CouponDiscount = formatAmount(model.DiscountApplied).toFixed(2);
			var dvTotalAmount = document.getElementById("<%= dvTotalAmount.ClientID %>");
			var txtCouponCode = document.getElementById("<%= txtCouponCode.ClientID %>");
			var dvTotalBill = document.getElementById("dvTotalBill");
			var dvCouponDesc = document.getElementById("dvCouponDesc");
			var dvCouponAmt = document.getElementById("dvCouponAmt");
			var dvCouponDlr = document.getElementById("dvCouponDlr");
			var hfTotalAmount = document.getElementById("<%= hfTotalAmount.ClientID %>");
			var hfCouponAmt = document.getElementById("<%= hfCouponAmt.ClientID %>");
			var hfCouponID = document.getElementById("<%= hfCouponID.ClientID %>");

			///Reset every thing
			dvCouponDesc.innerHTML = "";
			dvCouponDlr.innerHTML = "";
			hfCouponCode.value = " ";
			var previousCouponDisc = dvCouponAmt.innerHTML;
			dvCouponAmt.innerHTML = " ";
			dvTotalAmount.innerHTML = (parseFloat(formatAmount(dvTotalAmount.innerHTML) + formatAmount(previousCouponDisc))).toFixed(2);
			dvTotalBill.innerHTML = (parseFloat(dvTotalAmount.innerHTML)).toFixed(2);
			hfTotalAmount.value = dvTotalBill.innerHTML;

			////// If the Coupon return error
			if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
			    alert(model.FeedbackMessage.Message);
			    hfCouponCode.value = "";
			    hfCouponID.value = "";
			    hfCouponAmt.value = "0";
			    SetSourceCodeDiscount(0);
			    ShowHideSourceCodeAmountDiv(false);
			    isSourceCodeApplied = false;
			    return false;
			} //if coupon amount is 0.00
			else if (model.SourceCodeId > 0 && formatAmount(model.DiscountApplied).toFixed(2) == "0.00") {
			    alert("Source code has been applied successfully.");
			    hfCouponCode.value = "";
			    hfCouponAmt.value = "0";
			    SetSourceCodeDiscount(0);
			    ShowHideSourceCodeAmountDiv(true);
			    isSourceCodeApplied = true;
			    return false;
			}
			$('#dvCoupon').show();
			dvCouponError.innerHTML = "";
			var divErrtop = document.getElementById("<%= divErrtop.ClientID %>");
			divErrtop.style.display = 'none';

			
			hfCouponID.value = model.SourceCodeId;
			hfCouponCode.value = model.SourceCode;
			dvCouponAmt.innerHTML = (parseFloat(formatAmount(CouponDiscount))).toFixed(2);
			dvCouponDlr.innerHTML = "(-)$";
			dvTotalAmount.innerHTML = (parseFloat(formatAmount(dvTotalAmount.innerHTML) - formatAmount(CouponDiscount))).toFixed(2);
			dvTotalBill.innerHTML = (parseFloat(dvTotalAmount.innerHTML)).toFixed(2);

			hfTotalAmount.value = dvTotalBill.innerHTML;
			hfCouponAmt.value = dvCouponAmt.innerHTML;
			SetSourceCodeDiscount((parseFloat(formatAmount(CouponDiscount))).toFixed(2));
			ShowHideSourceCodeAmountDiv(true);
			isSourceCodeApplied = true;
			return false;
		}

		function fnToggle() {
			oTransContainer.filters[0].Apply();
			oTransContainer.filters[0].Play();
		}


		function popupmenu2(choice, wt, ht) {
			var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
			confirmWin = window.open(choice, 'theconfirmWin', winOpts);
			window.open(choice, 'theconfirmWin', winOpts);
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

			if (parseFloat($('#dvSelectedPackageAmt').text()) < parseFloat('<%=MinimumPurchaseAmount %>')) {
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
			if (isNaN(parseFloat(num)))
			{ num = '0.00'; }
			return parseFloat(num);
			try
         { num = num.replace(/^\s+|\s+$/g, ""); }
			catch (err)
         { num = num }

			num = parseFloat(num);
			if (isNaN(num))
			{ num = '0.00'; }

			return parseFloat(num.toFixed(2));
		}

		function HidePackageDesc() {
			document.getElementById('dvPackageDescShow').style.display = "none";
		}

		function findPos(obj) {

			var curleft = curtop = 0;
			var curWidth = obj.offsetWidth;
			var curHeight = obj.offsetHeight;
			if (obj.offsetParent) {
				curleft = obj.offsetLeft
				curtop = obj.offsetTop

				while (obj = obj.offsetParent) {
					curleft += obj.offsetLeft
					curtop += obj.offsetTop


				}
			}

			return { left: curleft - 10 * curWidth - 20, top: curtop, right: curleft - curWidth, bottom: curtop - curHeight };
		}


		function showTipBubble(Package) {
			//debugger
			var bubble = document.getElementById('dvPackageDescShow');

			var pos = findPos(Package);
			bubble.style.top = pos.top + 'px';
			bubble.style.left = pos.left + 'px';
			bubble.style.display = 'block';
			bubble.style.position = 'absolute';
		}

		function MaintainAfterFailedPostBack() {
			var hfSelectedPackageRadio = document.getElementById("<%=this.hfSelectedPackageRadio.ClientID %>");
			//            PackageSelect(hfSelectedPackageRadio.value);
			var txtCouponCode = document.getElementById("<%= this.txtCouponCode.ClientID %>");
			if (txtCouponCode.value != "") {
				getCouponDiscount();
			}
		}
	</script>

	<div id="dvPackageDescShow" class="divmousehovertxt_mbox">
		<div id="dvPackageDescText">
		</div>
		<div id="dvArrow">
			<%-- <img src="../images/arrow.jpg" />--%>
		</div>
	</div>
	<div class="clr">
	</div>
	<div class="divheadingtxtnew" id="headingtxt" runat="server" style="text-align: center;">
	</div>
    <div style="width:885px; clear: both;">
        <uc2:SponsoredByInfo ID="SponsoredByInfo" runat="server" />
    </div>
	<div class="clr">
	</div>
	<div class="maindivouter_pw" style="margin-left: 10px;">
		<div class="maindiv_errormsgnew" enableviewstate="false" visible="false" id="divErrortop"
			runat="server" style="margin-left: 0px;">
			<p class="topbg_errormsgnew">
				<img src="/Content/images/specer.gif" width="663px" height="7px" /></p>
			<div class="midbg_errormsgnew">
				<span style="float: left; padding: 0px 10px 0px 10px">
					<img src="/Content/images/error-icon.gif" /></span> <span id="spErrorMsgtop" runat="server"
						class="txt_errormsgnew"></span>
			</div>
			<p class="botbg_errormsgnew">
				<img src="/Content/images/specer.gif" width="663px" height="7px" /></p>
		</div>
		<p class="reuirdfieldrow_pw">
		</p>
		<div class="header_pbregbg">
			<div class="headertxt_pw">
				Step 3: Select Package with <%= IoC.Resolve<ISettings>().CompanyName %></div>
		</div>
		<div class="body_border_pbreg" style="width: 718px;">
			<div class="lineheight_pw">
			</div>
			<%-----------------   For Package info    --%>
			<div class="EventDetails_Contentarea" style="padding-left: 10px; width: auto;">
				<span style="font: bold 12px arial; color: #EE8111;"><u>Select</u>
					a Value Priced PreventionPAKS</span>
			</div>
			<div style="float: left; width: 718px; padding: 0px 15px 10px 15px;">
				<Order:ItemCart ID="ItemCartControl" runat="server" />
				<div class="sourcecode" id="SourceCodeApplyDiv">
					<div class="EventDetails_Contentarea" style="width: 235px; float: left; font: bold 12px arial;
						color: #EE8111;">
                        If you <u>have</u> a source code, please enter here and <u>Click</u> Apply button. 
						<span style="padding:5px 0px 1px;"><a href="#" class="jtip"
							title='What is This? |
                                    &lt;u&gt;Special Offers and Discounts?&lt;/u&gt; :&lt;br /&gt;
                                    &lt;br /&gt;
                                    Source Codes are directly tied to Special Offers and Discounts that are currently
                                    valid. If you wish to take advantage of any special offer or discount, you must
                                    &lt;u&gt;Enter&lt;/u&gt; your Source Code in the box provided, and &lt;u&gt;Click&lt;/u&gt; on Apply, prior
                                    to &lt;u&gt;clicking&lt;/u&gt; the Next button.
                                    &lt;br /&gt;
                                    &lt;br /&gt;
                                    &lt;u&gt;Disclaimer&lt;/u&gt; :&lt;br /&gt;
                                    Many Special Offers and Discounts have special conditions that must be met to qualify.
                                    Please ensure that you qualify and that the offer date is still valid. If you have
                                    questions, please call <%= IoC.Resolve<ISettings>().CompanyName %> .' style="font: normal 12px arial;
							color: #287AA8;"><b>?</b></a> </span>
					</div>
					<asp:Panel ID="pnlSourceCode" DefaultButton="imgCouponApply" runat="server">
						<p>
							<span><b>Source Code:</b></span> 
							<span style="margin-left:10px">
								<asp:TextBox ID="txtCouponCode" runat="server" CssClass="inputf_pw" MaxLength="50" Width="110px"></asp:TextBox>
							</span>
							<span style="float:right;margin-top:5px;">
								<asp:ImageButton ID="imgCouponApply" runat="server" CssClass="" ImageUrl="~/Content/images/apply-btn.gif"
									OnClientClick="return CouponValidation();"></asp:ImageButton>
							</span>
							<span id="spIndicator" style="visibility: hidden; display: none;">
								<img id="imgIdicator" src="/Content/images/indicator.gif" />
							</span>
						</p>
					</asp:Panel>
				</div>
			</div>
			<div class="buttonrow_pw">
				<div class="leftlinkcon_pw">
				</div>
				<div class="buttoncell_pw">
					<div class="resetbutton_pw">
						<asp:ImageButton ID="ibtnSubmit" runat="server" CssClass="" ImageUrl="~/Content/images/next-orngbtn-PW.gif"
							OnClientClick="return NextButtonClick();" /></div>
					<div class="resetbutton_pw">
					</div>
				</div>
			</div>
		</div>
		<div class="bottombg_pbregbg">
		</div>
		<div style="width: auto; float: left; display: none" id="BillingInformationDiv">
			<p class="lineheight_pw">
			</p>
			<div class="EventDetails_Contentarea" style="font: bold 12px arial; color: #EE8111;">
				<b><span id="spSecD">(b)</span></b>&nbsp;&nbsp<u>Review</u> Your Selection
			</div>
			<div class="dgselectpackage_pw">
				<table class="gridcoupon" cellspacing="0" border="0" id="dgBill" style="border-collapse: collapse;">
					<tr class="row1">
						<td style="width: 535px">
							Name/Description
						</td>
						<td style="width: 20px; text-align: right;" align="right">
						</td>
						<td align="right">
							Amount
						</td>
					</tr>
					<tr class="row2" id="dvSelectedPackage">
						<td style="width: 535px">
							<span id="dvSelectedPackageDesc">Please select Package</span>
							<br />
							<span class="gridselectpackage_testname" id="spanPackageTestDes"></span>
						</td>
						<td id="dvSelectedPackageDlr" style="width: 20px; text-align: right;" align="right">
							$
						</td>
						<td id="dvSelectedPackageAmt" align="right">
							0.00
						</td>
					</tr>
					<tr class="row2" id="dvCoupon">
						<td id="dvCouponDesc" style="width: 535px">
							&nbsp;
						</td>
						<td id="dvCouponDlr" style="width: 20px; text-align: right;" align="right">
						</td>
						<td id="dvCouponAmt" align="right">
							&nbsp;
						</td>
					</tr>
					<tr class="footer">
						<td style="width: 535px">
							Your Total Due will be
						</td>
						<td id="dvTotalDlr" style="width: 20px; text-align: right;" align="right">
							$
						</td>
						<td id="dvTotalBill" align="right">
							0.00
						</td>
					</tr>
				</table>
			</div>
			<div class="maindiv_errormsgysmall" id="divErrtop" style="display: none" runat="server">
				<p class="topbg_errormsgysmall">
					<img src="/Content/images/specer.gif" width="600px" height="7px" /></p>
				<div class="midbg_errormsgysmall">
					<span style="float: left; width: 20px; padding: 0px 10px 0px 10px">
						<img src="/Content/images/error-icon.gif" alt="" /></span> <span id="dvCouponError"
							style="width: 450px;" class="txt_errormsgysmall"></span>
				</div>
				<p class="botbg_errormsgysmall">
					<img src="/Content/images/specer.gif" width="600px" height="7px" /></p>
			</div>
			<div class="lineheight_pw">
			</div>
	    </div>
		<div class="maindiv_errormsgnew" enableviewstate="false" visible="false" id="divErrorbottom"
			runat="server" style="margin-left: 0px">
			<p class="topbg_errormsgnew">
				<img src="/Content/images/spacer.gif" width="663px" height="7px" alt="" /></p>
			<div class="midbg_errormsgnew">
				<span id="spErrorMsgbottom" runat="server" class="txt_errormsgnew" style="padding-left: 10px">
				</span>
			</div>
			<p class="botbg_errormsgnew">
				<img src="/Content/images/spacer.gif" width="663px" height="7px" alt="" /></p>
		</div>
		<div class="lineheight_pw">
		</div>
	</div>
	<asp:HiddenField ID="hfEventID" runat="server" />
	<asp:HiddenField ID="hfTotalAmount" runat="server" />
	<asp:HiddenField ID="hfCouponCode" runat="server" />
	<asp:HiddenField ID="hfEmailRprt" runat="server" Value="0" />
	<asp:HiddenField ID="hfCouponAmt" runat="server" />
	<asp:HiddenField ID="hfCouponID" runat="server" />
	<asp:HiddenField ID="hfPackageCost" runat="server" />
	<asp:HiddenField ID="hfSelectedPackageRadio" runat="server" Value="" />
	<%--<asp:HiddenField ID="hfPackageID" runat="server" />--%>
	<asp:HiddenField ID="PackageIdHiddenControl" runat="server" />
	<asp:HiddenField ID="TestIdsHiddenControl" runat="server" />
	<asp:HiddenField ID="IndependentTestIdsHiddenControl" runat="server" />
	<div style="visibility: hidden; display: none;">
		<p class="contentrow_pw" style="visibility: hidden; display: none;">
			Your Total Billing amout is <strong>$<span runat="server" id="dvTotalAmount">0.00</span></strong>.
		</p>
	</div>
	<div class="lineheight_pw" style="visibility: hidden; display: none;">
	</div>
	
</asp:Content>

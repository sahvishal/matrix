<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomRentPrintReciept.aspx.cs" Inherits="Falcon.App.UI.App.Franchisee.Reports.RoomRentPrintReciept" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title><%= IoC.Resolve<ISettings>().CompanyName %> Room Rent Payment Details</title>
<script type="text/javascript" language="javascript">
    function CallPrint()
    {
        //debugger
        
        var prtContent = document.getElementById("container");
            
        var dvPrintHead='<html xmlns="http://www.w3.org/1999/xhtml" ><head>'
        dvPrintHead=dvPrintHead + "<style type='text/css' media='print'>";
        dvPrintHead=dvPrintHead + "#container{float:left;width:590px;padding:30px;font:normal 14px Arial;}";
        dvPrintHead=dvPrintHead + "#header{width:100%;float:left;text-align:center;margin-bottom:30px}";
        dvPrintHead=dvPrintHead + "#container .wrapert{float:left;width:100%;float:left;margin-bottom:30px;}";
        dvPrintHead=dvPrintHead + "#container .wrapert label{float:left;width:350px;margin-bottom:15px;}";
        dvPrintHead=dvPrintHead + "#container .wrapert .dtls{float:left;width:170px;margin-bottom:15px;display:block;}";
        dvPrintHead=dvPrintHead + "h1{font-size:18px;font-weight:bold;margin:0;padding:0}";
        dvPrintHead=dvPrintHead + "</style></head><body> <div id='container'>";
        var dvPrintFooter='</div></body></html>'
        var WinPrint = window.open('','','left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
        WinPrint.document.write(dvPrintHead + prtContent.innerHTML + dvPrintFooter);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        $(document).ready(function() {
            var decoded = $("<textarea/>").html($("#<%= _lblPaymentAddress.ClientID %>").html()).text();
            $("#<%= _lblPaymentAddress.ClientID %>").html(decoded);

            decoded = $("<textarea/>").html($("#<%= _lblDepositAddress.ClientID %>").html()).text();
            $("#<%= _lblDepositAddress.ClientID %>").html(decoded);

        });

    }
</script>
<style type="text/css" media="screen">
#container{float:left;width:590px;padding:30px;font:normal 14px Arial;}
#header{width:100%;float:left;text-align:center;margin-bottom:30px}
#container .wrapert{float:left;width:100%;float:left;margin-bottom:30px;}
#container .wrapert label{float:left;width:350px;margin-bottom:15px;}
#container .wrapert .dtls{float:left;width:170px;margin-bottom:15px;display:block;}
h1{font-size:18px;font-weight:bold;margin:0;padding:0}
</style>


</head>
<body onload="CallPrint();">
    <form id="form1" runat="server">
    <div id="container">
		<div id="header">
			<h1><%= IoC.Resolve<ISettings>().CompanyName %><sup>&reg;</sup> ROOM RENT PAYMENT DETAILS</h1>(Note that Credit Card payment is reserved for very rare occasions)			
		</div>
		<div class="wrapert">
			<label>Cost of Hosting Event $:</label>
			<label class="dtls" id="_lblHostingEventCost" runat="server">&nbsp;</label>
			<label>Tax ID:</label>
			<label class="dtls" id="_lblTaxId" runat="server">&nbsp;</label>
			<label>Payment Method:</label>
			<label class="dtls" id="_lblPaymentMethod" runat="server"></label>
			<label>Due Date: </label>
			<label class="dtls" id="_lblPaymentDueDate" runat="server">&nbsp;</label>
			<label>Payable to:</label>
			<label class="dtls" id="_lblPaymentPayableTo" runat="server">&nbsp;</label>
			<label>Mail to the attention of:</label>
			<label class="dtls" id="_lblPaymentAttentionOf" runat="server">&nbsp;</label>
			<label>Deliver to Organization name:</label>
			<label class="dtls" id="_lblPaymentOrganizationName" runat="server">&nbsp;</label>
			<label> Address:</label>
			<label class="dtls" id="_lblPaymentAddress" runat="server">&nbsp;</label>
		</div>
		<div class="wrapert">
			<label>Is Deposit required:</label>
			<label class="dtls" id="_lblIsDepositRequired" runat="server"></label>
			<label>Deposit Amount $:</label>
			<label class="dtls" id="_lblDepositAmount" runat="server">&nbsp;</label>
			<label>Deposit Amount Payment Method:</label>
			<label class="dtls" id="_lblDepositMethod" runat="server"></label>
			<label>Due Date: </label>
			<label class="dtls" id="_lblDepositDueDate" runat="server">&nbsp;</label>
			<label>Payable to:</label>
			<label class="dtls" id="_lblDepositPayableTo" runat="server">&nbsp;</label>
			<label>Mail to the attention of:</label>
			<label class="dtls" id="_lblDepositAttentionOf" runat="server">&nbsp;</label>
			<label>Deliver to Organization name:</label>
			<label class="dtls" id="_lblDepositOrganizationName" runat="server">&nbsp;</label>
			<label> Address:</label>
			<label class="dtls" id="_lblDepositAddress" runat="server">&nbsp;</label>
		</div>
		<div class="wrapert">
			<label>Deposit will be: </label>
			<label class="dtls" id="_lblDepositApplicablityMode" runat="server"></label>
			<label>To Receive Full Refund, Must Cancel Event by (Date):</label>
			<label class="dtls" id="_lblFullRefundDate" runat="server"> </label>
		</div>
	</div>
    </form>
</body>
</html>

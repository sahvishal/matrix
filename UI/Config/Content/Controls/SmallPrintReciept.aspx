<%@ Page Language="C#" AutoEventWireup="true" Inherits="Falcon.App.UI.Config.Content.Controls.SmallPrintReciept"
    CodeBehind="SmallPrintReciept.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="height: 95%">
<head>
    <title>Print Reciept</title>
    <link href="/App/StyleSheets/Commonstyle.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .receipt-font
        {
            font: 16px Arial;
        }
        .bldtxt-receipt
        {
            float: left;
            width: 120px;
            font: bold 16px arial;
            padding-right: 5px;
        }
        .lbltxt-receipt
        {
            float: left;
            width: 175px;
            font: normal 16px arial;
            border-bottom: 1px dotted #666;
        }
    </style>
    <script type="text/javascript" src="/Scripts/jquery-1.5.2.min.js"></script>
    <script src="/App/JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>" type="text/javascript">
    </script>
    <script language="javascript" type="text/javascript">
        function CallPrint() {
            //debugger;
            var decoded = $("<textarea/>").html($("#<%=_payments.ClientID %>").html()).text();
            $("#<%=_payments.ClientID %>").hide();
            $("#payment-table").append(decoded);
            
            decoded = $("<textarea/>").html($("#<%=lblVenue3.ClientID %>").html()).text();
            $("#<%=lblVenue3.ClientID %>").html(decoded);
            
            //debugger
            var hfPageCallBackFrom = document.getElementById("<%=this.hfPageCallBackFrom.ClientID %>");
            if (hfPageCallBackFrom.value != "AcceptPayment") {
                var prtContent = document.getElementById("<%= this.divPrint.ClientID %>");

                var dvPrintHead = '<html xmlns="http://www.w3.org/1999/xhtml" style="height:95%"><head id="Head1"><title>Small Receipt</title><link href="/Content/Styles/main.css" rel="stylesheet" type="text/css" /> <style type="text/css"> .receipt-font {font:16px Arial;} .bldtxt-receipt{float:left; width:120px; font:bold 16px arial; padding-right:5px; } .lbltxt-receipt {float:left; width:175px; font:normal 16px arial; border-bottom:1px dotted #666;} </style> </head><body style="width:950px; height:700px; padding-left:50px; background-color: #FFFFFF;">  <div class="maindiv_prsmall">';
                var dvPrintFooter = '</div></body></html>';
                var WinPrint = window.open('', '', 'left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
                WinPrint.document.write(dvPrintHead + prtContent.innerHTML + dvPrintFooter);
                WinPrint.document.close();
                WinPrint.focus();
                WinPrint.print();
                WinPrint.close();
                //prtContent.innerHTML=strOldOne;
            }
        }

        function CallPrint_btnClick() {
            //debugger
            var prtContent = document.getElementById("<%= this.divPrint.ClientID %>");

            var dvPrintHead = '<html xmlns="http://www.w3.org/1999/xhtml" ><head id="Head1"><title>Small Receipt</title><link href="/Content/Styles/main.css" rel="stylesheet" type="text/css" /> <style type="text/css"> .receipt-font {font:16px Arial;} .bldtxt-receipt{float:left; width:120px; font:bold 16px arial; padding-right:5px; } .lbltxt-receipt {float:left; width:175px; font:normal 16px arial; border-bottom:1px dotted #666;} </style> </head><body style="width:950px; height:700px; padding-left:50px; background-color: #FFFFFF;">  <div class="maindiv_prsmall">';
            var dvPrintFooter = '</div></body></html>';
            var WinPrint = window.open('', '', 'left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(dvPrintHead + prtContent.innerHTML + dvPrintFooter);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            //prtContent.innerHTML=strOldOne;
        }
        
    </script>
</head>
<body onload="CallPrint();" onunload="ReloadParentPage();">
    <form id="form1" runat="server">
    <div style="float: left; padding-left: 0px;" id="divAlignCenter" runat="server">
        <div style="float: left; width: 100%;">
            <p class="maindivnone_prsmall" style="visibility: hidden; display: none;" id="pPrintBtn"
                runat="server">
                <span class="graytxtright_prsmall">
                    <asp:ImageButton ID="imgBtnSmallRec" runat="server" ImageUrl="~/App/Images/printer-icon1.gif"
                        OnClientClick="javascript:CallPrint_btnClick()" />
                    <%--<img src="../Images/printer-icon1.gif" onclick="javascript:CallPrint()" />--%>
                </span>
            </p>
            <div class="maindiv_prsmall" id="divPrint" runat="server">
                <div class="contentrow_prsmall">
                    <div class="left-side_prsmall">
                        <img src="/Config/Content/Images/Logo-Small-160x60.gif" alt="" />
                    </div>
                    <div class="right-side-prsmall">
                        <span class="bldtxt-receipt">Name:</span> <span class="lbltxt-receipt">
                            <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                        </span>
                        <br />
                        <span class="bldtxt-receipt">Customer ID:</span> <span class="lbltxt-receipt">
                            <asp:Label ID="lblCustomerID" runat="server"></asp:Label>
                        </span>
                        <br />
                        <span class="bldtxt-receipt">Address:</span> <span class="lbltxt-receipt">
                            <asp:Label ID="Address" runat="server" Style="border-bottom: 1px dotted #666666;
                                float: left; padding-top: 1px; width: 175px;"></asp:Label>
                        </span>
                    </div>
                </div>
                <div class="contentrow_prsmall">
                    <hr />
                </div>
                <div class="txtrow_prsmall" style="display: inline">
                    <span class="bldtext-header"><u>Order Detail:</u></span>
                </div>
                <table width="98%" border="0" cellpadding="0" cellspacing="3" align="center" class="receipt-font">
                    <tr>
                        <th width="50%" align="left" valign="top">
                            Tests
                        </th>
                        <th width="15%" align="right" valign="top" id="_tdDiagnosisCode" runat="server">
                            Diagnosis Code
                        </th>
                        <th width="15%" align="right" valign="top" id="_tdCPT" runat="server">
                            CPT Code
                        </th>
                        <th width="20%" align="right" valign="top" id="_tdPrice" runat="server">
                            Price
                        </th>
                    </tr>
                    <div id="_orderDetail" runat="server">
                    </div>
                    <tr>
                        <td colspan="4" height="1px" style="background-color: #CCC;">
                        </td>
                    </tr>
                    <tr id="_discountRow" runat="server">
                        <td align="right">
                            <strong>Discount</strong>
                        </td>
                        <td colspan="3" align="right">
                            <span id="_spnDiscount" runat="server"></span>
                        </td>
                    </tr>
                    <tr id="_productRow" runat="server">
                        <td align="right" id="ProductName" runat="server">
                            <strong>Product</strong>
                        </td>
                        <td colspan="3" align="right">
                            <span id="_spnProduct" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>Shipping</strong>
                        </td>
                        <td colspan="3" align="right">
                            <span id="_spnshipping" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="1px" style="background-color: #CCC;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>Total Amount</strong>
                        </td>
                        <td colspan="3" align="right">
                            <strong><span id="_totalAmount" runat="server"></span></strong>
                        </td>
                    </tr>
                </table>
                <p class="headerbg_prsmall">
                    <span class="bldtext-header"><u>Payment Details</u></span></p>
                <table width="78%" border="1" cellpadding="5" cellspacing="0" id="payment-table" class="receipt-font">
                    <tr>
                        <th width="38%" align="left" valign="top">
                            <u>By</u>
                        </th>
                        <th width="38%" align="left" valign="top">
                            <u>On</u>
                        </th>
                        <th width="44%" align="left" valign="top">
                            <u>Details</u>
                        </th>
                        <th width="18%" align="right" valign="top">
                            <u>Amount</u>
                        </th>
                    </tr>
                    <span id="_payments" runat="server"></span>
                </table>
                <br />
                <br />
                <p class="headerbg_prsmall">
                    <span class="bldtext-header"><u>Appointment Details </u></span>
                </p>
                <p class="txtrow_prsmall">
                    <span class="bldtxt-receipt">Venue:</span> <span class="lbltxt-receipt" style="width: 70%;">
                        <asp:Label ID="lblVenue1" runat="server"></asp:Label></span>
                </p>
                <p class="txtrow_prsmall">
                    <span class="bldtxt-receipt">
                        <img src="/App/Images/specer.gif" width="90px" height="1px" /></span> <span class="lbltxt-receipt"
                            style="width: 70%;">
                            <asp:Label ID="lblVenue2" runat="server"></asp:Label></span>
                </p>
                <p class="txtrow_prsmall">
                    <span class="bldtxt-receipt">
                        <img src="/App/Images/specer.gif" width="90px" height="1px" /></span> <span class="lbltxt-receipt"
                            style="width: 70%;">
                            <asp:Label ID="lblVenue3" runat="server"></asp:Label></span>
                </p>
                <div class="txtrow_prsmall">
                    <div style="float: left; width: 50%;">
                        <span class="bldtxt-receipt">Date:</span> <span class="lbltxt-receipt receipt-font">
                            <asp:Label ID="lblDate" runat="server"></asp:Label></span>
                    </div>
                    <div style="float: left; width: 50%;">
                        <span class="bldtxt-receipt" style="width: 50px;">Time:</span> <span class="lbltxt-receipt">
                            <asp:Label ID="lblTime" runat="server"></asp:Label></span>
                    </div>
                </div>
                <p class="txtrow_prsmall">
                    <span class="bldtxt-receipt">Event ID:</span> <span class="lbltxt-receipt" style="width: 70%;">
                        <asp:Label ID="lblEventID" runat="server"></asp:Label></span>
                </p>
                <p class="txtrow_prsmall">
                    <span class="bldtxt-receipt">Amount Paid:</span> <span class="lbltxt-receipt" style="width: 70%;">
                        <asp:Label ID="lblAmountPaid" runat="server"></asp:Label></span>
                </p>
                <div class="contentrow_prsmall">
                    <hr />
                </div>
                <p class="headerbg_prsmall" align="center">
                    <% 
                        var settings = IoC.Resolve<ISettings>();
                    %>
                    <span class="receipt-font" style="padding-top: 10px;">Issued By
                        <br />
                        <b>
                            <%= settings.CompanyName %></b>
                        <%= settings.Address1%>
                        ,
                        <%= settings.Address2%>
                        <br />
                        <%= settings.City%>,
                        <%= settings.State%>
                        -
                        <%= settings.ZipCode%>.
                        <br />
                        Phone (Toll Free) -
                        <%= settings.PhoneTollFree%>
                        <br />
                        <%if (settings.BusinessTaxId != "")
                          {%>
                        <span>Business Tax Id Number <b>
                            <%= settings.BusinessTaxId%>.</b></span>
                        <%}%>
                    </span> 
                </p>
                <div class="contentrow_prsmall">
                    <hr />
                </div>
                <p class="headerbg_prsmall">
                     <span class="receipt-font" style="padding-top: 10px;">
                         * Government insurance such as Medicare and/or Medicaid do not cover preventive cardiovascular 
                            screenings like the ones provided by Matrix Medical Network. These screenings are typically non-covered as they are 
                            limited screening protocols and are performed on asymptomatic individuals without prior authorization 
                            from a treating physician. Matrix Medical Network does not guarantee reimbursement for any services by any third 
                            party.
                     </span>
                </p>
                <div class="contentrow_prsmall">
                    <hr />
                </div>
                <p class="headerbg_prsmall" align="center">
                    <span class="receipt-font" style="padding-top: 10px;">
                        You may view your records, once made available, online at <b><%=settings.LoginUrl%></b>. Your username is <b><span runat="server" id="username"></span></b>. 
                        <%--If you do not know your password please contact our Customer Support Center at <b><%=settings.CustomerPortalPhoneTollFree%></b>.--%>
                    </span>
                </p>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfPageCallBackFrom" runat="server" />
    </form>
</body>
</html>

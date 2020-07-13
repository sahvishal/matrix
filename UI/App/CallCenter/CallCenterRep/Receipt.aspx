<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" AutoEventWireup="true" Inherits="App_CallCenter_CallCenterRep_Receipt" Title="Untitled Page" Codebehind="Receipt.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <script language="javascript" type="text/javascript">
function CallPrint()
{
//debugger
var prtContent = document.getElementById("<%= this.divPrint.ClientID %>");
var WinPrint =
window.open('','','left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
WinPrint.document.write(prtContent.innerHTML);
WinPrint.document.close();
WinPrint.focus();
WinPrint.print();
WinPrint.close();
//prtContent.innerHTML=strOldOne;
}
    </script>
    
    <div style="width:650px;">
    <div id="divPrint" runat="server">
    <div> <img src="~/Content/Images/spacer.gif" height="20px" width="650px" />  </div>
    <p class="thankumsgrow_prsmall"><b>Registration Successful!</b> Thank you for your time.</p>
    <div> <img src="~/Content/Images/spacer.gif" height="5px" width="650px" />  </div>
   <p class="maindivnone_prsmall">
   <span class="graytxtright_prsmall"><img src="~/Content/Images/printer-icon.gif" onclick="javascript:CallPrint()" /></span>
   </p>
   <div class="maindiv_prsmall">
    <p class="contentrow_prsmall"> <img src="~/Content/Images/header-smallprintrec.gif" /> </p>
    <p class="grayline_prsmall"><img src="~/Content/Images/specer.gif" width="1px" height="1px" /></p>
    <p class="headerbg_prsmall">Patient Details</p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Name:</span>
    <span class="lbltxt_prsmall"> <asp:Label ID="lblCustomerName" runat="server"></asp:Label></span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Customer ID:</span>
    <span class="lbltxt_prsmall"> <asp:Label ID="lblCustomerID" runat="server"></asp:Label></span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Package Name:</span>
    <span class="lbltxt_prsmall"> <asp:Label ID="lblPackageName" runat="server"></asp:Label></span>
    </p>
    
    
    <div id="dvPackageDetail" runat="server">
            </div>
            
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Event ID:</span>
    <span class="lbltxt_prsmall"> <asp:Label ID="lblEventID" runat="server"></asp:Label></span>
    </p>
    
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Event Name:</span>
    <span class="lbltxt_prsmall">  <asp:Label ID="lblEventName" runat="server"></asp:Label></span>
    </p>
    
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Event Location:</span>
    <span class="lbltxt_prsmall"> <asp:Label ID="lblEventLocation" runat="server"></asp:Label></span>
    </p>
        
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Time:</span>
    <span class="lbltxt_prsmall"> <asp:Label ID="lblAppointmentSlot" runat="server"></asp:Label></span>
    </p>
    
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Payment Type:</span>
    <span class="lbltxt_prsmall">Credit Card</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Amount Paid:</span>
    <span class="lbltxt_prsmall">$<asp:Label ID="lblAmountPaid" runat="server"></asp:Label></span>
    </p>
    <p class="graylinedotted_prsmall"><img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
    
    </div>
<%--    <div style="float:right; width:150px">
    <p style="float: right; width: 88px; padding: 2px 0px 2px 4px;">
      
      <%--<asp:ImageButton ID="ibtnsave" CssClass="" ImageUrl="~/Images/printer-icon.gif" OnClientClick="javascript:CallPrint()" Visible="True" />

    </p>
    </div>--%>
 </div>
  </div>
  </asp:Content>


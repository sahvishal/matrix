<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCInvoice.ascx.cs" Inherits="Falcon.App.UI.App.UCCommon.UCInvoice" %>
<div>
    <div id="invoiceSummaryDiv" runat="server">        
        <div style="float:left;width:33%;overflow:hidden;">                
            Invoice Number: <asp:Literal ID="invoiceNumberLiteral" runat="server" /><br />
            Period: <asp:Literal ID="payPeriodLiteral" runat="server" />                    
        </div>

        <div style="float:left;width:34%">            
            Physician Name: <asp:Literal ID="physicianNameLiteral" runat="server" /><br />
            Payable To: <asp:Literal ID="medicalVendorNameLiteral" runat="server" />    
        </div>
        <div style="float:left;width:33%">
            Number of Evaluations: <asp:Literal ID="NumberOfEvaluationsLiteral" runat="server" /><br />
            <% if(CanSeeEarnings) { %>Total Amount Earned: <asp:Literal ID="TotalAmountEarnedLiteral" runat="server" /> <% } %>
        </div>
    </div>
     
    <div style="clear:both;">
        &nbsp;
    </div>
    <%--Invoice items--%>
    <div id="invoiceItemRepeaterDiv" runat="server">
        <table cellspacing="3" width="99%">         
            <tr>
                <td >
                    <b>Review Date</b>
                </td>
                <td style="white-space:nowrap;">
                    <b>Event Name</b> 
                </td>                        
                <td style="white-space:nowrap;">
                    <b>Customer Name</b>
                </td>
                <td style="white-space:nowrap;">
                    <b>Package Name</b>
                </td>
                <% if(CanSeeEarnings) { %>
                <td>
                    <b>Amount</b>
                </td>
                <% } %>
            </tr>
            <asp:Repeater ID="invoiceItemRepeater" runat="server">
                <ItemTemplate>  
                <tr>
                    <td style="white-space:nowrap;">
                        <%# ((DateTime)Eval("ReviewDate")).ToShortDateString() %> @ <%# ((DateTime)Eval("ReviewDate")).ToShortTimeString() %>
                    </td>
                    <td style="white-space:nowrap;">
                        <%# Eval("EventName") %> 
                    </td>                        
                    <td style="white-space:nowrap;">
                        <%# Eval("CustomerName") %>
                    </td>
                    <td style="white-space:nowrap;">
                        <%# Eval("PackageName") %>
                    </td>
                    <% if(CanSeeEarnings) { %>
                    <td style="white-space:nowrap;">
                        <%# string.Format("{0:c}",(decimal)Eval("OrganizationRoleUserAmountEarned")) %> 
                    </td>
                    <% } %>                   
                </tr>                                
                </ItemTemplate>
                                
            </asp:Repeater>
        </table>
    </div>
</div>

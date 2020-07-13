<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncRescheduledCustomers.aspx.cs" Inherits="Falcon.App.UI.App.Franchisee.Technician.AsyncRescheduledCustomers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" runat="server" style="float:left;">
    <div id="innerDivRescheduledCustomers" runat="server"  enableviewstate="true" style="float:left;">
        <div class="grayboxtop_custlist">
            <asp:GridView ID="grdeventRescheduledCustomers" runat="server" EnableViewState="false" DataKeyNames="EventCustomerID"
                CssClass="divgrid_clnew" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdeventCancelledcustomers_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Appointment Detail">
                        <ItemTemplate>
                            <span runat="server" id="spcustomerdetail"><a id="CustomerEdit" runat="server"
                                href="Javascript:void(0)">
                                <%# DataBinder.Eval(Container.DataItem, "CustomerName")%>
                                (ID:
                                <%# DataBinder.Eval(Container.DataItem, "CustomerID")%>) </a>
                                <br />
                                <a id="aCustomerDetail" href='/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=<%# DataBinder.Eval(Container.DataItem, "CustomerID")%>'>(more details)</a>
                                <br />
                                <%# DataBinder.Eval(Container.DataItem, "Email").ToString().Trim().Length > 0 ? Convert.ToString(DataBinder.Eval(Container.DataItem, "Email").ToString() + "<br />") : ""%>
                                <span><%# DataBinder.Eval(Container.DataItem, "Phone")%></span>
                                <span id="_customerName" runat="server" style="display:none;"><%# DataBinder.Eval(Container.DataItem, "CustomerName")%></span>
                                <span id="_customerId" runat="server" style="display:none;"><%# DataBinder.Eval(Container.DataItem, "CustomerID")%></span>
                                <span id="_eventId" runat="server" style="display:none;"><%# DataBinder.Eval(Container.DataItem, "EventId")%></span>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Order Detail">
                        <ItemTemplate>
                            <span runat="server" id="ViewOrderDetailsSpan" style="width: 80px; float: left" visible="true"></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="row1" />
                <RowStyle CssClass="row2" />
                <AlternatingRowStyle CssClass="row3" />
            </asp:GridView>
        </div>
    </div>
    <div style="float:left; width:735px; border:solid 1px #ccc; padding:5px;" id="divNoRecordsFound" runat="server">
        <span class="redtxt_default" style="font-weight:bold;">No rescheduled customers</span>
    </div>
    </div>
   </form>
</body>
</html>

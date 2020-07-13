<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Async_CancelledCustomers.aspx.cs" Inherits="Falcon.App.UI.App.Franchisee.Technician.Async_CancelledCustomers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" runat="server" style="float:left;">
    <div id="innerDivCancelledCustomers" runat="server"  enableviewstate="true" style="float:left;">
        <div class="grayboxtop_custlist">
            <asp:GridView ID="grdeventCancelledcustomers" runat="server" EnableViewState="false" DataKeyNames="EventCustomerID"
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
                                <span runat="server" id="spAcctDetail" style="display: none;">Acct Created:<%# DataBinder.Eval(Container.DataItem, "UserCreationMode")%>
                                    [<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "UserDateCreated")).ToString("MM/dd/yyyy")%>]
                                    <br />
                                    Repeat Count:[<%# DataBinder.Eval(Container.DataItem, "EventCount")%>]
                                    <br />
                                </span>
                                <%# DataBinder.Eval(Container.DataItem, "Email").ToString().Trim().Length > 0 ? Convert.ToString(DataBinder.Eval(Container.DataItem, "Email").ToString() + "<br />") : ""%>
                                <span><%# DataBinder.Eval(Container.DataItem, "Phone")%></span>
                                <span id="_customerName" runat="server" style="display:none;"><%# DataBinder.Eval(Container.DataItem, "CustomerName")%></span>
                                <span id="_customerId" runat="server" style="display:none;"><%# DataBinder.Eval(Container.DataItem, "CustomerID")%></span>
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
        <span class="redtxt_default" style="font-weight:bold;">No cancelled customers</span>
    </div>
    </div>
   </form>
</body>
</html>

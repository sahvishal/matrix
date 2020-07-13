<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="App_Common_ucWeekCalendar" Codebehind="ucWeekCalendar.ascx.cs" %>
<div class="divmainmonth_clnder">
    <asp:DataList ID="lstWeekView" Width="750px" runat="server" GridLines="Vertical"
        BorderColor="#d2d2d2" BorderWidth="1px" RepeatColumns="1" RepeatDirection="vertical"
        CellPadding="0" CellSpacing="0" DataKeyField="Date" ShowHeader="true" ShowFooter="true">
        <ItemTemplate>
            <td id='lstWeekView(<%# DataBinder.Eval(Container.DataItem, "Date")%>)' valign="top">
                <div class="headerdiv_week_clnder">
                    <%# DataBinder.Eval(Container.DataItem, "Day")%>
                </div>
                <p class="cellheadbg_week_clnder">
                    <span class="datestyle_week_clnder">
                        <%# DataBinder.Eval(Container.DataItem, "Date")%>
                    </span>
                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                </p>
            <br />
            </td>
            
            
                        
        </ItemTemplate>
        <ItemStyle VerticalAlign="top" />
    </asp:DataList>
</div>

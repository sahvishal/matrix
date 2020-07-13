<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncPodCalendar.aspx.cs"
    Inherits="HealthYes.Web.App.Common.CreateEventWizard.AsyncPodCalendar" EnableEventValidation="false" %>

<%@ Register Assembly="DataCalendar" Namespace="DataControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divPodCalendar" runat="server">
        <cc1:DataCalendar ID="dcEvents" runat="server" Width="100%" DayField="EventDate"
            DayNameFormat="Full" NextMonthText="" PrevMonthText="" BorderColor="#C3D5E2"
            BorderWidth="1px" ToolTip="" UseAccessibleHeader="false" >
            <itemtemplate>
                <span style="float:right; width:15px; height:15px;">
                <img src="/App/Images/addevent-square.gif" class="jtip" title="<%# Container.DataItem["JtipInfo"]%>"/>
                </span>
            </itemtemplate>
            <noeventstemplate> 
                <span style="float:right; width:15px;  height:15px;"></span>
            </noeventstemplate>
            <OtherMonthDayStyle ForeColor="#999999" BackColor="#F2F2F2" />
            <DayStyle HorizontalAlign="left" VerticalAlign="top" Font-Names="Arial" BorderStyle="Solid"
                BorderWidth="1px" BorderColor="#C3D5E2" Font-Size="8pt" CssClass="" />
            <DayHeaderStyle BackColor="#DFE7ED" ForeColor="#000000" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#6FBBE1" Font-Bold="True" Font-Size="9pt" ForeColor="#ffffff" />
        </cc1:DataCalendar>
    </div>
    </form>
</body>
</html>

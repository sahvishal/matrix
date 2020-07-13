<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncCalendar.aspx.cs"
    Inherits="Falcon.App.UI.App.Common.AsyncCalendar" EnableEventValidation="false" %>

<%@ Register Assembly="DataCalendar" Namespace="DataControls" TagPrefix="cc1" %>
<%@ Register Src="~/App/Common/ucYearCalendar.ascx" TagName="cc2" TagPrefix="cc2" %>
<%@ Register Src="~/App/Common/ucWeekCalendar.ascx" TagName="cc3" TagPrefix="cc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvCalendar" runat="server">
        <div id="dvLegands" style="display: none">
        </div>
        <div class="maindivredmsgbox" id="dvMonth" style="display: none">
        </div>
        <div id="dvCalMonth" class="divmainmonth_clnder" runat="server">
            <cc1:DataCalendar ID="dcAppointments" runat="server" Width="100%" DayField="EventDate"
                DayNameFormat="Full" NextMonthText="" PrevMonthText="" BorderColor="#d2d2d2"
                BorderWidth="1px" ToolTip="" UseAccessibleHeader="false">
                <itemtemplate>                     
                              
               <p class="cellblock_clnder" >
               <span  class="celltxt_clnder" id='<%# Container.DataItem["AppointmentID"] %>'style="cursor:hand"   >                                    
                        <%# Container.DataItem["AppointmentInfo"] %> </span></p></itemtemplate>
                <noeventstemplate> 
                     <span   class="activecell_clndr">
                            <br /><br />&nbsp;
                                                         
                        </span> 
                </noeventstemplate>
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <TodayDayStyle BackColor="#E2F1F9" ForeColor="#006BC2" />
                <SelectorStyle BackColor="#FFCC66" />
                <OtherMonthDayStyle ForeColor="#999999" BackColor="#F2F2F2" />
                <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Font-Names="Arial" BorderStyle="Solid"
                    BorderWidth="1px" BorderColor="#d2d2d2" Font-Size="8pt" CssClass="cellheadbg_clnder" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <DayHeaderStyle BackColor="#6FBBE1" ForeColor="#000" Font-Bold="True" Height="1px" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            </cc1:DataCalendar>
        </div>
        <div id="dvCalYear" class="divmainmonth_clnder" runat="server">
            <cc2:cc2 EventDate="" ID="YearView" runat="server" />
        </div>
        <div id="dvCalWeek" class="divmainmonth_clnder" runat="server">
            <cc3:cc3 ID="WeekView" runat="server" />
        </div>
        &nbsp;<br />
        <br />
        <span id="tt" style="background-image: url(../Images/calendarcell.gif)"></span>
        <!-- *DR* This is the admin login area, upon login the admin controls at the top become visible.-->
    </div>
    </form>
</body>
</html>

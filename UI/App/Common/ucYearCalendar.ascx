<%@ Control Language="C#" AutoEventWireup="True"
    Inherits="App_Common_ucYearCalendar" Codebehind="ucYearCalendar.ascx.cs" %>
<%@ Register Assembly="DataCalendar" Namespace="DataControls" TagPrefix="cc1" %>
   
<div class="divmainmonth_clnder">
    <cc1:DataCalendar ID="dcAppointments1" Width="750px" runat="server" DayField="EventDate"
        DayNameFormat="Short" NextMonthText="" PrevMonthText="" BorderColor="#d2d2d2"
        BorderWidth="1px" ToolTip="" UseAccessibleHeader="false" OnDayRender="dcAppointments_DayRender"  >
        <itemtemplate>
                      
                              
                         <span  class="celltxt_clnder" id= '<%# Container.DataItem["AppointmentID"] %>' style="cursor:hand"   >
                                    
                        <%# Container.DataItem["AppointmentInfo"]%> </span>  
                
                </itemtemplate>
        <noeventstemplate> 
                     
               <span  class="celltxt_clnder" >
                           &nbsp;        
                         </span>
                                                                                   
                        
                </noeventstemplate>
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <TodayDayStyle BackColor="#E2F1F9" ForeColor="#006BC2" />
        <SelectorStyle BackColor="#FFCC66" />
        <OtherMonthDayStyle ForeColor="#999999" BackColor="#F2F2F2" />
        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Font-Names="Arial" BorderStyle="Solid"
            BorderWidth="1px" BorderColor="#d2d2d2" Font-Size="8pt" CssClass="cellblock_clnder1" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#6FBBE1" ForeColor="#000" Font-Bold="True" Height="1px" />
        <TitleStyle BackColor="#f7f7f7" Font-Bold="True" Font-Size="9pt" ForeColor="#ff6600" CssClass="hedingmonthview_clnder" />
    </cc1:DataCalendar>
</div>
<div><img src="../Images/specer.gif" width="750px" height="10px" /></div>
<div class="divmainmonth_clnder">
    <cc1:DataCalendar ID="dcAppointments2" Width="750px" runat="server" DayField="EventDate"
        DayNameFormat="Short" NextMonthText="" PrevMonthText="" BorderColor="#d2d2d2"
        BorderWidth="1px" ToolTip="" UseAccessibleHeader="false" OnDayRender="dcAppointments_DayRender">
        <itemtemplate>
                      
                              
                          <span  class="celltxt_clnder" id='<%# Container.DataItem["AppointmentID"] %>' style="cursor:hand"   >
                                    
                        <%# Container.DataItem["AppointmentInfo"] %> </span> 
                
                </itemtemplate>
        <noeventstemplate> 
                     
               <span  class="celltxt_clnder">
                           &nbsp;        
                         </span>
                                                                                   
                        
                </noeventstemplate>
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <TodayDayStyle BackColor="#E2F1F9" ForeColor="#006BC2" />
        <SelectorStyle BackColor="#FFCC66" />
        <OtherMonthDayStyle ForeColor="#999999" BackColor="#F2F2F2" />
        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Font-Names="Arial" BorderStyle="Solid"
            BorderWidth="1px" BorderColor="#d2d2d2" Font-Size="8pt" CssClass="cellblock_clnder1" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#6FBBE1" ForeColor="#000" Font-Bold="True" Height="1px" />
         <TitleStyle BackColor="#f7f7f7" Font-Bold="True" Font-Size="9pt" ForeColor="#ff6600" CssClass="hedingmonthview_clnder" />
    </cc1:DataCalendar>
</div>
<div><img src="../Images/specer.gif" width="750px" height="10px" /></div>
<div class="divmainmonth_clnder">
    <cc1:DataCalendar ID="dcAppointments3" Width="750px" runat="server" DayField="EventDate"
        DayNameFormat="Short" NextMonthText="" PrevMonthText="" BorderColor="#d2d2d2"
        BorderWidth="1px" ToolTip="" UseAccessibleHeader="false" OnDayRender="dcAppointments_DayRender">
        <itemtemplate>
                      
                              
          <span  class="celltxt_clnder" id='<%# Container.DataItem["AppointmentID"] %>' style="cursor:hand"   >
                                    
                        <%# Container.DataItem["AppointmentInfo"] %> </span>  
                
                </itemtemplate>
        <noeventstemplate> 
                 
               <span  class="celltxt_clnder">
                           &nbsp;        
                         </span> 
                                                                                   
                        
                </noeventstemplate>
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <TodayDayStyle BackColor="#E2F1F9" ForeColor="#006BC2" />
        <SelectorStyle BackColor="#FFCC66" />
        <OtherMonthDayStyle ForeColor="#999999" BackColor="#F2F2F2" />
        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Font-Names="Arial" BorderStyle="Solid"
            BorderWidth="1px" BorderColor="#d2d2d2" Font-Size="8pt" CssClass="cellblock_clnder1" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#6FBBE1" ForeColor="#000" Font-Bold="True" Height="1px" />
         <TitleStyle BackColor="#f7f7f7" Font-Bold="True" Font-Size="9pt" ForeColor="#ff6600" CssClass="hedingmonthview_clnder" />
    </cc1:DataCalendar>
</div>
<div><img src="../Images/specer.gif" width="750px" height="10px" /></div>

<div class="clndrdivmonthtr_clnder">
    <cc1:DataCalendar ID="dcAppointments4" Width="750px" runat="server" DayField="EventDate"
        DayNameFormat="Short" NextMonthText="" PrevMonthText="" BorderColor="#d2d2d2"
        BorderWidth="1px" ToolTip="" UseAccessibleHeader="false" OnDayRender="dcAppointments_DayRender">
        <itemtemplate>
                      
                              
            <span  class="celltxt_clnder" id='<%# Container.DataItem["AppointmentID"] %>' style="cursor:hand"   >
                                    
                        <%# Container.DataItem["AppointmentInfo"] %> </span>  
                
                </itemtemplate>
        <noeventstemplate> 
                      
               <span  class="celltxt_clnder">
                           &nbsp;        
                         </span>
                                                                                   
                        
                </noeventstemplate>
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <TodayDayStyle BackColor="#E2F1F9" ForeColor="#006BC2" />
        <SelectorStyle BackColor="#FFCC66" />
        <OtherMonthDayStyle ForeColor="#999999" BackColor="#F2F2F2" />
        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Font-Names="Arial" BorderStyle="Solid"
            BorderWidth="1px" BorderColor="#d2d2d2" Font-Size="8pt" CssClass="cellblock_clnder1" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#6FBBE1" ForeColor="#000" Font-Bold="True" Height="1px" />
         <TitleStyle BackColor="#f7f7f7" Font-Bold="True" Font-Size="9pt" ForeColor="#ff6600" CssClass="hedingmonthview_clnder" />
    </cc1:DataCalendar>
</div>
<div><img src="../Images/specer.gif" width="750px" height="10px" /></div>
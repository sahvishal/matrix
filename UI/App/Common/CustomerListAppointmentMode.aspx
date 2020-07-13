<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Common_CustomerListAppointmentMode" Codebehind="CustomerListAppointmentMode.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="mainbody_outer">
 <div class="mainbody_inner">
     <div class="main_area_bdrnone">
     <div class="headingbox_feedback">
            <p><img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <span class="orngheadtxt_feedback">Customer List (Appointment Mode)</span>
            </div>
            <p><img src="../Images/specer.gif" width="700px" height="2px" /></p>
            <p class="graylinefull_feedback"><img src="../Images/specer.gif" width="1px" height="1px" /></p>
            <p><img src="../Images/specer.gif" width="700px" height="5px" /></p>
            <div class="maindivinnerrow_feedback">
            <span class="orngbold14_default" style="float:left">Event on << Event Date >> at << Host Name >> </span>            
            </div>
            <p><img src="../Images/specer.gif" width="700px" height="5px" /></p>
            <div class="maindivinnerrow_feedback">
            <span> << Host Address >> [ <a href="#">Map to Location</a> ] &nbsp;&nbsp;|&nbsp;&nbsp; << Pod Name >>  (<a href="#">More Info</a>) </span>            
            </div>
            <p><img src="../Images/specer.gif" width="700px" height="5px" /></p>
    <div class="grayboxtop_cl">
    <p class="grayboxtopbg_cl"><img src="../Images/specer.gif" width="746" height="6" /></p>
    <p class="grayboxheader_cl"> Event Summary (ID:<span>XX</span>) </p>
    <div class="lgtgraybox_cl">
     <p class="lgtgrayboxrow_ea">
     <span class="titlefixwdth_ea">Customers:</span>
    <span class="normaltxtnowdth_ea">Registered:&nbsp;<a href="#">28</a>&nbsp;|&nbsp;Actual:&nbsp;<a href="#">22</a>&nbsp;|&nbsp;Paid:&nbsp;<a href="#">22</a>&nbsp;|&nbsp;Unpaid:&nbsp;<a href="#">4</a>&nbsp;|&nbsp;Canceled:&nbsp;<a href="#">2</a>&nbsp;|&nbsp;No Show:&nbsp;<a href="#">2</a></span>
     </p>
     <p class="lgtgrayboxrow_ea">
        <span class="titlefixwdth_ea">Slots:</span>
    <span class="normaltxtnowdth_ea">Total:<b>$3200</b>&nbsp;|&nbsp;Filled:<b>10</b>&nbsp;|&nbsp;Blocked:<b>2</b></span>
     </p>
    </div>
    <p class="grayboxbotbg_cl"><img src="../Images/specer.gif" width="746" height="4" /></p>
    </div> 
    <p><img src="../Images/specer.gif" width="700px" height="20px" /></p>
    <p class="maindivinnerrow_feedback">
            <span class="orngbold14_default" style="float:left">Appointment List</span>
            <span class="smalltxtlnk_hd"> <asp:ImageButton ID="ibtn" runat="server" ImageUrl="~/App/Images/save-button.gif" /></span>
            <span class="smalltxtlnk_hd"> <asp:DropDownList ID="DropDownList1" runat="server" CssClass="inputf_def" Width="110px">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>At Event</asp:ListItem>
            <asp:ListItem>Filled</asp:ListItem>
            <asp:ListItem>Blocked</asp:ListItem>
             </asp:DropDownList></span>
            </p>
            <p><img src="../Images/specer.gif" width="700px" height="5px" /></p>
            <p class="graylinefull_feedback"><img src="../Images/specer.gif" width="1px" height="1px" /></p>
            <p><img src="../Images/specer.gif" width="700px" height="10px" /></p>         
             
    <p class="blueboxtopbg_cl"><img src="../Images/specer.gif" width="746" height="6" /></p>
    <div class="grayboxtop_cl">
    <asp:GridView ID="dgcustomerlist" runat="server" CssClass="divgrid_clnew" AutoGenerateColumns="false" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="Time" HeaderText="Time">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Event Name">
                        <ItemTemplate>
                        <span>John Doe (M)<br /><a href="#">email@domain.com<%# DataBinder.Eval(Container.DataItem, "CustName")%> </a><br />PH:555-123-1234</span></ItemTemplate>                
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="Package" HeaderText="Package">
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="Coupon" HeaderText="Coupon">
                        </asp:BoundField>                       
                      
                        <asp:BoundField DataField="Amount" HeaderText="Amount">
                        </asp:BoundField> 
                        
                        <asp:TemplateField HeaderText="Status">
                         <ItemTemplate>
                          Paid <br /> <a href="#">reciept <%# DataBinder.Eval(Container.DataItem, "Status")%> </a></ItemTemplate>                                        
                                              
                        </asp:TemplateField>
                        
                                                                
                        <asp:TemplateField>
                        <HeaderTemplate>Action</HeaderTemplate>
                        <ItemTemplate>
                        <a href="#">Reschedule <%# DataBinder.Eval(Container.DataItem, "Action")%> </a>|<br />
                        <a href="#">Change Package <%# DataBinder.Eval(Container.DataItem, "Action")%> </a>|<br />
                        <a href="#">Apply Coupon <%# DataBinder.Eval(Container.DataItem, "Action")%> </a>|<br />
                        <a href="#">Cancel <%# DataBinder.Eval(Container.DataItem, "Action")%> </a> |<br />
                        <a href="#">Health Assessment <%# DataBinder.Eval(Container.DataItem, "Action")%> </a>|<br />
                         <a href="#">Results <%# DataBinder.Eval(Container.DataItem, "Action")%> </a>|
                        </ItemTemplate> 
                        <ItemStyle CssClass="smalllnkgrid" />               
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1"  />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>    
    </div>
     <p class="blueboxbotbg_cl"><img src="../Images/specer.gif" width="746" height="6" /></p>
     
     </div>
     <p><img src="../Images/specer.gif" width="700px" height="20px" /></p> 
</div>
</div>
</asp:Content>

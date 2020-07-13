<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" Inherits="App_Franchisee_Technician_SignIn" Codebehind="SignIn.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="mainbody_outer">
            <div class="mainbody_inner">
				
			    <div class="mainbody_inner_left"></div>
			    
			    <div class="mainbody_inner_mid">
			        <div class="mainbody_titletxtleft">Sign In</div>
			        <div class="mainbody_titlelnkright"></div>
			           </div>
			    
			    <div class="mainbody_inner_right"></div>
			
			    <div class="main_area_bdr">
			    <div class="maindivredmsgbox" id="divMsg" visible="false" enableviewstate="false" runat="server"></div>
			    
			    
			    <div class="singlerow_sc" style="margin-bottom: 10px;">
			        <div style="background: #f08618; width: 744px; padding: 5px 0px 5px 10px; font-weight:bold; color:#fff;">Event Details</div>
                    <div class="eventdetailsbox">
                        <p class="eventlabel">Event ID:</p>
                        <p class="event_label_desc">0765</p>
                        <p class="eventlabel">Event Name:</p>
                        <p class="event_label_desc">Event1</p>
                        <p class="eventlabel">Host Name:</p>
                        <p class="event_label_desc">Host1</p>
                    </div>
                    
                    <div class="eventdetailsbox">
                        <p class="eventlabel">Event Location:</p>
                        <p class="event_label_desc">abc</p>
                        <p class="eventlabel">Total No. of Customers:</p>
                        <p class="event_label_desc">865</p>
                    </div>
                </div>
                
                               
			    <div class="divgridprintroasters" runat="server" id="divError">
			            <div style="background: #6c8cb3; width: 744px; padding: 5px 0px 5px 10px; font-weight:bold; color:#fff;">Customers Registered For This Event</div>
                        <asp:GridView runat="server" GridLines="None" ID="grdPrintRoster" AutoGenerateColumns="false" CssClass="gridprintroasters_new">
                            <Columns>
                                <asp:BoundField DataField="AppointmentTime" HeaderText="Appointment Time">
                                <HeaderStyle CssClass="atime_pr"/>
                                <ItemStyle CssClass="atime_pr" />
                                 </asp:BoundField>
                                
                                <asp:BoundField DataField="Serial" HeaderText="ID">
                                <HeaderStyle CssClass="idcolmn_pr"/>
                                <ItemStyle CssClass="idcolmn_pr" />
                                </asp:BoundField>  
                                
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name">
                                <HeaderStyle CssClass="custname_pr"/>
                                <ItemStyle CssClass="custname_pr" />
                                 </asp:BoundField>
                                
                                <asp:BoundField DataField="PackageTests" HeaderText="Package Tests">
                                <HeaderStyle CssClass="ptests_pr"/>
                                <ItemStyle CssClass="ptests_pr" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PackageCost" HeaderText="Package Cost">
                                <HeaderStyle CssClass="pcost_pr"/>
                                <ItemStyle CssClass="pcost_pr" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Discount" HeaderText="Discount">
                                <HeaderStyle CssClass="discount_pr"/>
                                <ItemStyle CssClass="discount_pr" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Paymentstatus" HeaderText="Payment Status">
                                <HeaderStyle CssClass="paymentstatus_pr"/>
                                <ItemStyle CssClass="paymentstatus_pr" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                <HeaderTemplate>Checkin / Checkout Time</HeaderTemplate>
                                <ItemTemplate> <a href="#"><%# DataBinder.Eval(Container.DataItem, "CheckinTime")%></a></ItemTemplate>
                                <HeaderStyle CssClass="chkin_chkout_pr"/>
                                <ItemStyle CssClass="chkin_chkout_pr" />
                                </asp:TemplateField>
                             
                                <asp:BoundField DataField="Action" HeaderText="Action">
                                <HeaderStyle CssClass="action_pr"/>
                                <ItemStyle CssClass="action_pr" />
                                </asp:BoundField>
                             
                                
                            </Columns>
                            <HeaderStyle CssClass="row1" />
                            <RowStyle CssClass="row2" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                    </div>
			    </div>
			    
    </div>
    </div>

</asp:Content>
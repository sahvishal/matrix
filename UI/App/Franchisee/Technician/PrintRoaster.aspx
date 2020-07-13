<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" Inherits="App_Franchisee_Technician_PrintRoaster" Codebehind="PrintRoaster.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">

    function OpenPDFPage(servername)
    {//debugger
          window.location= "http://" + servername +"/App/Franchisee/Technician/OpenPDF.aspx";
        
        //window.open("http://" + servername +"/App/Franchisee/Technician/OpenPDF.aspx", "EventPDF", "location=1,status=1,scrollbars=1, menubar=1, toolbar=2, width=900,height=500");
        return false;
    }

</script>



<div class="mainbody_outer">
            <div class="mainbody_inner">
				
			    <div class="mainbody_inner_left"></div>
			    
			    <div class="mainbody_inner_mid">
			        <div class="mainbody_titletxtleft">Print Roster</div>
			        <div class="mainbody_titlelnkright"></div>
			           </div>
			    
			    <div class="mainbody_inner_right"></div>
			
			    <div class="main_area_bdr">
			    <div class="maindivredmsgbox" id="divMsg" visible="false" enableviewstate="false" runat="server"></div>
			    
			    <div class="master_buttons_row">
                <div class="master_buttons_con"><asp:ImageButton runat="server" ID="img_btnPrint" ImageUrl="~/App/Images/printpdf-btn.gif" /></div>
                </div>
			    
			    <div class="divgridprintroasters" runat="server" id="divError">
                        <asp:GridView runat="server" GridLines="None" ID="grdPrintRoster" AutoGenerateColumns="false" 
                            CssClass="gridprintroasters" AllowSorting="true" OnSorting="grdPrintRoster_Sorting">
                            <Columns>
                                 <asp:BoundField DataField="Serial" HeaderText="S No.">
                                     </asp:BoundField>  
                                
                                <asp:BoundField DataField="AppointmentTime" HeaderText="Appointment Time" SortExpression="AppointmentTime"   HtmlEncode="false"    DataFormatString="{0:hh:mm tt }">
                                 </asp:BoundField>
                                 
                                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID"> 
                                 </asp:BoundField>
                                
                                <%--<asp:BoundField DataField="CustomerName" HeaderText="Customer Name">
                                </asp:BoundField>--%>
                                <asp:TemplateField HeaderText="Customer Name">
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem,"CustomerName") %>
                                        <br />
                                        <%#DataBinder.Eval(Container.DataItem,"Email") %>
                                        <br />
                                        <%#DataBinder.Eval(Container.DataItem,"Phone") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PackageTests" HeaderText="Package/Tests">
                                </asp:BoundField>
                                <asp:BoundField DataField="CouponCode" HeaderText="Coupon">
                                </asp:BoundField>
                                <asp:BoundField DataField="Amount" HeaderText="Amount">
                                </asp:BoundField>
                                
                                 <asp:TemplateField HeaderText="Disc.">
                                <ItemTemplate>
                                   <%# DataBinder.Eval(Container.DataItem, "Discount")%>
                                </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status">
                                </asp:BoundField>
                              
                                <asp:TemplateField HeaderText="CheckIn Time">
                                <ItemTemplate>
                                   <%# DataBinder.Eval(Container.DataItem, "CheckInTime")%>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CheckOut Time">
                                <ItemTemplate>
                                   <%# DataBinder.Eval(Container.DataItem, "CheckOutTime")%>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Signature">
                                <ItemTemplate>
                                  ________
                                </ItemTemplate>
                                </asp:TemplateField>
                              

                                
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

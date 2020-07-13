<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true" Inherits="App_Customer_CustomerDashboardLatest" Codebehind="CustomerDashboardLatest.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="maincontainer_cdb">
        <div class="headingcontainer_cdb">
            <div class="headingbgleft_cdb">
            </div>
            <div class="headingbgmid_cdb">
                <div class="mainbody_titletxt_cdb">
                    Customer Dashboard</div>
            </div>
            <div class="headingbgright_cdb">
            </div>
            <div class="mainborder_cdb">
                <%--<p class="headingtxtcon_cdb">
                    <span class="headingblack_cdb">Welcome</span> <span class="headingblue_cdb">XYZ</span>
                </p>--%>
                <p class="alertbox_cdb">
                    <span class="redtxtheadalert_cdb">Alerts!</span> <span class="titletxtalert_cdb">Event
                        Name:</span> <span class="normaltxtalert_cdb">Event 1</span> <span class="titletxtalert_cdb">
                            Package Name:</span> <span class="normaltxtalert_cdb">Package 1</span> <span class="normaltxtalert_cdb">
                                <a href="#">Results are Ready</a></span>
                </p>
                <div class="mainconinnerboxes_cdb">
                    <%--***************/ Upcoming box start here /************************--%>
                    
                    <div class="upcomingeventboxmain_cdb">
                        <p class="uceventheadingbg_cdb"><span class="uceventheadingtxt_cdb">My Health Summary</span>
                                                   
                        </p>
                        <div class="maindivhealthsum">
                        <p class="healthsummeryrow">
                        <span class="blktitlehealthsumm">My Weight:</span>
                        <span class="blutitlehealthsumm">60 Kgs</span>
                        <span class="blktitlehealthsumm">My Height:</span>
                        <span class="blutitlehealthsumm">157.5 Cms</span>
                        <span class="blktitlehealthsumm">My BMI:</span>
                        <span class="blutitlehealthsumm">24.2</span>                        
                        </p>
                        
                        <div class="divgridhealthsummery">
                            
                        <asp:GridView runat="server" ID="dghealthsummery" ShowHeader="false" GridLines="None" AutoGenerateColumns="false" CssClass="gridcustomerdashboard">
                        <Columns>
                         <asp:BoundField DataField="" Visible="false"></asp:BoundField>
                          
                        <asp:BoundField DataField="col1" HeaderText="Event Name">                                   
                                    </asp:BoundField>
                                    
                        
                        <asp:TemplateField >
                        <ItemTemplate> <a href="#">View Results</a></ItemTemplate>     
                        </asp:TemplateField>
                        
                                   
                        <asp:TemplateField>
                        <ItemTemplate><a href="#" ><img src="../Images/highriskred-btn.gif" /></a>     
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
                         
                         <RowStyle CssClass="row2" />
                         <AlternatingRowStyle CssClass="row3" />
                         
                        </asp:GridView> 
                        </div>
                        

                          <p class="mainrowhealthsumm">
                          <span class="viewhistorybtncon"><asp:ImageButton ID="ImageButton4" runat="server" CssClass="" ImageUrl="../Images/view-history-btn.gif" /></span>
                          </p>
                        
                        </div>
                        <div class="uceventbotbg_cdb">
                        </div>
                    </div>
                    <%--***************/ Upcoming box end here /************************--%>
                    <%--***************/ Recentally Attended Events start here /************************--%>
                    <div class="recentlyattevent_cdb">
                        <div class="boxrighttopbg_cdb"><img src="../Images/specer.gif" width="1" height="1" /></div>
                        <div class="boxmidbg_cdb">
                            <div class="titlerightbox_cdb">
                                <div class="titletext_cdb">
                                    Recently Attended Events</div>
                                 <p class="raeventsdetailstxt_cdb">
                                <span class="raeventtitletxt_cdb">Date:</span>
                                  <span class="raeventtxt_cdb">15-12-2007</span> </p>
                                  
                                  <p class="raeventsdetailstxt_cdb">
                                  <span class="raeventtitletxt_cdb">Event Name:</span>
                                  <span class="raeventtxt_cdb">Event 1</span> </p> 
                                  
                                  <p class="raeventsdetailstxt_cdb">
                                  <span class="raeventtitletxt_cdb">Zip:</span>
                                  <span class="raeventtxt_cdb">653258</span> </p> 
                                  
                                  <p class="raeventsdetailstxt_cdb">
                                  <span class="raeventtitletxt_cdb">Event Status:</span>
                                  <span class="raeventtxt_cdb">Attended</span> </p> 
                                  
                                  <p class="raeventsdetailstxt_cdb">
                                  <span class="raeventtitletxt_cdb">Package Name:</span>
                                  <span class="raeventtxt_cdb">ABC</span> </p> 
                                  
                                  <p class="preevents_cdb"><img src="../Images/specer.gif" width="1" height="55" /></p>
                                  <p class="preevents_cdb">
                                <span class="preeventsbutton_cdb"><asp:ImageButton ID="ImageButton2" runat="server" CssClass="" ImageUrl="~/App/Images/previous_events.gif" /></span>
                                <span class="nexteventsbutton_cdb"><asp:ImageButton ID="ImageButton3" runat="server" CssClass="" ImageUrl="~/App/Images/next-events.gif" /></span>
                                </p> 
                            </div>
                        </div>
                        <div class="boxrightbotbg_cdb">
                        </div>
                    </div>
                    <div class="divlineheight"><img src="../Images/specer.gif" width="751" height="10" /></div>
                    <%--***************/ Recentally Attended Events end here /************************--%>
                    <div class="upcomingeventboxmain_cdb">
                        <p class="uceventheadingbg_cdb"><span class="uceventheadingtxt_cdb">Upcoming Events</span> <span class="seventtitletxt_cdb">
                                Search Event:</span> <span class="seventinput_cdb">
                                    <asp:TextBox ID="txtSearchevent" runat="server" Text="" CssClass="inputf_cdb" Width="100px"></asp:TextBox></span>
                            <span class="gobutton_cdb">
                                <asp:ImageButton ID="ibtnGo" runat="server" CssClass="" ImageUrl="../Images/go-button.gif" OnClick="ibtnGo_Click" /></span>
                            
                        </p>
                        <div class="divgriduceventgrid">
                            
                        <asp:GridView id="grdEventDetails" DataKeyNames="EventID" runat="server" CssClass="gridmvdashboard" GridLines="None" AutoGenerateColumns="false" >
                                <Columns>
                                    
                                    <asp:BoundField DataField="EventID" Visible="false" ></asp:BoundField >
                                    <asp:BoundField DataField="EventName" HeaderText="Event Name">
                                        <HeaderStyle CssClass="" />
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    
                                    <asp:TemplateField HeaderText="Date">
                                        <HeaderStyle CssClass="" />
                                        <ItemStyle CssClass="" />
                                        <ItemTemplate>
                                           <%-- <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "Date")).ToShortDateString() %>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="Zip" HeaderText="Zip">
                                        <HeaderStyle CssClass="" />
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <HeaderStyle CssClass="" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Save" runat="server" CssClass="" ImageUrl="../Images/registernow_cdb.gif" /></ItemTemplate>
                                        <ItemStyle CssClass="" />
                                    </asp:TemplateField>
                                    
                                </Columns>
                                <HeaderStyle CssClass="row1" />
                                <RowStyle CssClass="row2" />
                                <AlternatingRowStyle CssClass="row3" />
                            </asp:GridView> 
                        </div>
                        <div class="uceventbotbg_cdb">
                        </div>
                    </div>
                    <div class="refferafriend_cdb"><p class="boxrightgraytopbg_cdb"><img src="../Images/specer.gif" width="1" height="1" /></p>
                        <div class="boxgraymidbg_cdb">
                            <div class="titlerightbox_cdb">
                                <div class="titletext_cdb">
                                    Refer a Friend</div>
                                <p class="raeventsdetailstxt_cdb">
                                    <span class="raeventtxt_cdb">Please enter an email address to refer this to a friend.</span>
                                </p>
                                
                                <p class="raeventsdetailstxt_cdb">
                                    <span class="raeventrow_cdb">
                                        
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="inputfld" Width="220px"></asp:TextBox>
                                        </span>
                                </p>
                                <p class="raeventsdetailstxt_cdb">
                                    <span class="raeventrow_cdb">
                                        <asp:TextBox ID="txtreferralemail" CssClass="inputfld" runat="server" Width="220px"></asp:TextBox>

                                    </span>
                                </p>
                                <p class="raeventsdetailstxt_cdb">
                                    <span class="buttnrow_cdb">
                                        <asp:ImageButton ID="ibtnsubmit" runat="server" CssClass="" ImageUrl="../Images/submit-button.gif" />
                                    </span>
                                </p>
                            </div>
                        </div>
                        <p class="boxrightgraybotbg_cdb"><img src="../Images/specer.gif" width="1" height="1" /></p>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
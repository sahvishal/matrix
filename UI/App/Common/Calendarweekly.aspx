<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Common_Calendarweekly" Codebehind="Calendarweekly.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
                <div class="mainbody_titletxtleft">
                    <span runat="server" id="sptitle">Calander</span>
                  </div>               
               <div class="mainbody_titlelnkright"></div>                
            </div>
            <div class="mainbody_inner_right"></div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server">
            </div>
            <div class="main_area_bdrnone">
            <div class="mainarearow_clndr">
            <p class="intotxt_clndr">This interactive calander will help you quickly fit your schedule. Maecenas faucibus tortor vel tortor. Fusce congue ante eget tellus. Vivamus dictum lacus quis nunc. Praesent venenatis massa eu est scelerisque hendrerit. Quisque ut dolor id nisi lobortis commodo. Pellentesque a quam sed massa vulputate mattis.</p>
            <p class="lefttxtcon_clndr">
            <span class="printclndr_clndr">
            <a href="#" onclick="">     <img src="../Images/print-calander-icon.gif"      />
                Print this Calander" </a> </span>
            </p>
            </div>
            <div class="mainarearow_clndr">
            <div class="arrowcntrol_clndr"><asp:ImageButton runat="server"  ID="imgPreviousMonth" ImageUrl="~/App/Images/calander-leftarrow-btn.gif"/></div>
            <p class="middivarrow_clndr">
            <span class="headtxt_clndr" id="spDateRange" runat=server>February 01- February 29, 2008</span>
            <span class="rightlnktext_clndr"><a href="#">3 Month View</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#">Month View</a>&nbsp;&nbsp;|&nbsp;&nbsp;Week View&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#">Day View</a> </span>
            
            </p>
            <div class="arrowcntrol_clndr"><asp:ImageButton runat="server"  ID="imgNextMonth" ImageUrl="~/App/Images/calander-rightarrow-btn.gif"/></div>
            </div>
            <p><img src="../Images/specer.gif" width="700px" height="20px" /></p>          
            <div id="dvCalendar">
            <asp:GridView ID="dgcalendarweekly" runat="server" CssClass="gridcalendar" AutoGenerateColumns="false" GridLines="None" AllowPaging="true" PageSize="15">
                    <Columns>
                    <asp:BoundField DataField="Time" HeaderText="">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="01/02/2008">
                        <ItemTemplate>
                        <div class="maindivinnercell">
                        <p class="gridcellrow">Event 0253</p>
                        <p class="gridcellrow">Event 0253</p>
                        </div>              
                         </ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="02/02/2008">
                        <ItemTemplate>
                        <div class="maindivinnercell">
                        <p class="gridcellrow">Event 0253</p>
                        <p class="gridcellrow">Event 0253</p>
                        </div></ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="03/02/2008">
                        <ItemTemplate>
                        <div class="maindivinnercell">
                        <p class="gridcellrow">Event 0253</p>
                        <p class="gridcellrow">Event 0253</p>
                        </div></ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="04/02/2008">
                        <ItemTemplate>
                        <div class="maindivinnercell">
                        <p class="gridcellrow">Event 0253</p>
                        <p class="gridcellrow">Event 0253</p>
                        </div>
                        </ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="05/02/2008">
                        <ItemTemplate>
                        <div class="maindivinnercell">
                        <p class="gridcellrow">Event 0253</p>
                        <p class="gridcellrow">Event 0253</p>
                        </div>
                        </ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="06/02/2008">
                        <ItemTemplate>
                        <div class="maindivinnercell">
                        <p class="gridcellrow">Event 0253</p>
                        <p class="gridcellrow">Event 0253</p>
                        </div>
                        </ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="07/02/2008">
                        <ItemTemplate>
                        <div class="maindivinnercell">
                        <p class="gridcellrow">Event 0253</p>
                        <p class="gridcellrow">Event 0253</p>
                        </div></ItemTemplate>                
                        </asp:TemplateField>                
                    </Columns>
                    <HeaderStyle CssClass="row1"  />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row2" />
                </asp:GridView>
            
            </div>
            </div>
            
            
            
            
          
 </div>
</div>

</asp:Content>

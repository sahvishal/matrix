<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_FranchisorHostDetails" Codebehind="FranchisorHostDetails.aspx.cs" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
<style type="text/css">
.mainbody_outer_contactf{ float:right; width:777px; background-color:#fff; margin-top:5px; }
.mainbody_inner_contactf{ width:763px; margin-left:14px; margin-bottom:5px;}
.main_area_bdr_contactf{ float:left; width:753px; border:1px solid #E5E5E5; margin-top:5px;}

</style>
<div class="mainbody_outer_contactf">
            <div class="mainbody_inner_contactf">
                
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">View Host</span>
                    <p><img src="/App/Images/specer.gif" width="700px" height="1px" /></p>
                </div>
            </div>
                <%--<div class="mainbody_inner_left">
                </div>
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft"> View Host</div>
                    <div class="titlelnkright_contactf">
                    </div>
                </div>
                <div class="mainbody_inner_right">
                </div>--%>
                <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false" runat="server"></div>
                <div class="main_area_bdr_contactf" id="divGrdHost" runat="server">
                <div class="dgdefault">
                        <asp:GridView runat="server" GridLines="None" ID="grdHost" AutoGenerateColumns="false" DataKeyNames="ProspectID" 
                            CssClass="grid" AllowPaging="true" PageSize="10" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="grdHost_PageIndexChanging" OnRowDataBound="grdHost_RowDataBound" 
                             AllowSorting="true" OnSorting="grdHost_Sorting"  >
                            <Columns>
                                <asp:BoundField DataField="" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ></asp:BoundField>
                                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="true">
                                </asp:BoundField>
                                <asp:BoundField DataField="Capacity" HeaderText="Capacity" SortExpression="Capacity" >
                                </asp:BoundField>
                                <asp:BoundField DataField="Franchisee" HeaderText="Franchisee">
                                </asp:BoundField>
                                <asp:BoundField DataField="Count" HeaderText="Event Count">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Last Event Scheduled">
                                <ItemTemplate>
                                <b>
                                <%#DataBinder.Eval(Container.DataItem,"EventName") %></b>
                                <br />
                                <%#DataBinder.Eval(Container.DataItem,"EventDate") %>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Customer Count" DataField="CustomerCount" />
                            </Columns>
                            
                            <RowStyle CssClass="row2" />
                            <HeaderStyle CssClass="row1" />
                            <AlternatingRowStyle CssClass="row3" />
                            </asp:GridView>
                            
                    </div>
    </div>
    </div>
    </div>
</asp:Content>



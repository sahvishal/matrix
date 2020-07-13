<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="Franchisor_ContactFranchisee" Codebehind="ContactFranchisee.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">

.divgridcontactf{float:left; width:750px;}
</style>
<div class="mainbody_outer">
            <div class="mainbody_inner">
            
                <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Contact Franchisee</span>
                    <span class="headingright_default"></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            
                <%--<div class="mainbody_inner_left">
                </div>
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft"> Contact Franchisee</div>
                    <div class="titlelnkright_contactf">
                    </div>
                </div>
                <div class="mainbody_inner_right">
                </div>--%>
                
                
                <div class="main_area_bdr">
                        <div style="float:left; width:746px">
                        <asp:GridView runat="server" GridLines="None" ID="gridcontactfranchisee" AutoGenerateColumns="false" DataKeyField="FranhiseeFranchiseeUserID" 
                            CssClass="divgrid_cl" AllowPaging="true" PageSize="10" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="gridcontactfranchisee_PageIndexChanging"
                            AllowSorting="True" OnSorting="gridcontactfranchisee_Sorting"   >
                            <Columns>
                                <asp:BoundField DataField="" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="name">
                                 </asp:BoundField>
                                
                                <asp:BoundField DataField="Address" HeaderText="Address">
                                </asp:BoundField>
                                <asp:BoundField DataField="Phone" HeaderText="Phone">
                                 </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                </asp:BoundField>
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
<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master" AutoEventWireup="true" Inherits="MedicalVendor_ContactMV" Title="Untitled Page" Codebehind="ContactMV.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
<div class="mainbody_outer">
            <div class="mainbody_inner">
            
                <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Contact Medical Vendor</span>
                    <span class="headingright_default"></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            
                <%--<div class="mainbody_inner_left">
                </div>
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft"> Contact Medical Vendor</div>
                    <div class="titlelnkright_contactf">
                    </div>
                </div>
                <div class="mainbody_inner_right">
                </div>--%>
                <div class="main_area_bdr">
                <div class="divgridcontactf">
                        <asp:GridView runat="server" GridLines="None" ID="gridcontactfranchisee" AutoGenerateColumns="false"  
                            CssClass="grid" AllowPaging="true" PageSize="10" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="gridcontactfranchisee_PageIndexChanging"
                            AllowSorting="True" OnSorting="gridcontactfranchisee_Sorting"   >
                            <Columns>
                               <asp:BoundField DataField="Name" HeaderText="Medical Vendor">

                                </asp:BoundField>
                               <%-- <asp:TemplateField HeaderText="Name" SortExpression="name">
                                    
                                    <HeaderStyle CssClass="headername_contactf" />
                                    <ItemTemplate>
                                        <a href='<%# this.ResolveUrl("~/App/Franchisor/AddFranchisee.aspx?FranhiseeFranchiseeUserID=" + DataBinder.Eval(Container.DataItem, "FranhiseeFranchiseeUserID")) %>'>
                                            <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="itemname_contactf" />
                                </asp:TemplateField>--%>
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

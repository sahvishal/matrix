<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="Franchisor_ViewFranchisee" CodeBehind="ViewFranchisee.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .mainbody_outer_contactf
        {
            float: right;
            width: 777px;
            background-color: #fff;
            margin-top: 5px;
        }
        .mainbody_inner_contactf
        {
            width: 763px;
            margin-left: 14px;
            margin-bottom: 5px;
        }
        .main_area_bdr_contactf
        {
            float: left;
            width: 753px;
            border: 1px solid #E5E5E5;
            margin-top: 5px;
        }
    </style>
    <div class="mainbody_outer_contactf">
        <div class="mainbody_inner_contactf">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Franchisee</span>
                    <span class="headingright_default">
                        <a href="/App/Franchisor/AddFranchisee.aspx" >Add Franchisee</a>
                    </span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
            </div>
            <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdrnone">
                <div class="griddivnew_default">
                    <p class="blueboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="5" alt="" /></p>
                    <div class="griddivnew_default">
                        <asp:GridView runat="server" GridLines="None" ID="gridcontactfranchisee" AutoGenerateColumns="false"
                            DataKeyField="Id" CssClass="divgrid_cl" AllowPaging="false"
                            PageSize="10" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="gridcontactfranchisee_PageIndexChanging"
                            AllowSorting="false" OnSorting="gridcontactfranchisee_Sorting" OnRowDataBound="gridcontactfranchisee_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="BusinessName" SortExpression="businessname">
                                    <ItemTemplate>
                                        <a href='<%# this.ResolveUrl("~/App/Franchisor/AddFranchisee.aspx?FranchiseeId=" + DataBinder.Eval(Container.DataItem, "Id")) %>'>
                                            <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HtmlEncode="false" DataField="Address" HeaderText="Address"></asp:BoundField>
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone"></asp:BoundField>
                                <asp:ButtonField ButtonType="Link" CommandName="Delete" Text="Delete" />
                            </Columns>
                            <RowStyle CssClass="row2" />
                            <HeaderStyle CssClass="row1" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                    </div>
                    <p class="blueboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="5" alt="" /></p>
                </div>
                <span style="width: 40%; float: left;">
                    <img src="../Images/Unallocated-star.png" />
                    - Franchisee with no allocated Pod(s). </span>
            </div>
        </div>
    </div>
</asp:Content>

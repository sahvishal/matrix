<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Common_ViewNotifications" Codebehind="ViewNotifications.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="mainbody_outer">
<div class="mainbody_inner">
<%--<--Left container start here-->--%>
<%--<--Left container End here-->--%>
<%--<--Main Body start here-->--%>
<div class="maindivinner_vn">
<div class="maindivinnerrow_vn">
<div class="headingbox_vn">
<span class="orngheadtxt_vn">View Notifications</span>
<span class="normaltxt_vn"><a href="#">[ Add New Post ]</a></span></div>
<div class="searchbox_vn">
<span class="titletextnowidth_vn">Search:</span>
<span class="inputfldnowidth_vn"><asp:TextBox ID="TextBox8" runat="server" CssClass="inputf_def" Width="170px"></asp:TextBox></span>
<span class="gobtn_vn"><asp:ImageButton ID="btnEvaluate" runat="server" CssClass="" ImageUrl="~/App/Images/goblue-btn.gif" /></span>

</div>
</div>
<p><img src="../Images/specer.gif" width="1px" height="5px" /></p>
<p class="graylinefull_vn"><img src="../Images/specer.gif" width="1px" height="1px" /></p>
<div class="dgviewntopbg"><img src="../Images/specer.gif" width="5px" height="6px" /></div><div class="dgjobposting">
<asp:GridView ID="dgnotifications" runat="server" CssClass="gridjobp" AutoGenerateColumns="false" GridLines="None" AllowPaging="true" PageSize="15">
                    <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date">
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject" HeaderText="Subject">
                        </asp:BoundField>
                        <asp:BoundField DataField="PeopleNotified" HeaderText="People Notified">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Read">
                        <ItemTemplate>
                        <a href="#"><%# DataBinder.Eval(Container.DataItem, "Read")%> </a></ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unread">
                        <ItemTemplate></ItemTemplate>                
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Failure">
                        <ItemTemplate> </ItemTemplate>                
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1"  />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>

</div>
</div>
<%--<--Main Body End here-->--%>

</div>
</div>

</asp:content>

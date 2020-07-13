<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Async_MyActivities.aspx.cs"
    Inherits="HealthYes.Web.App.Franchisee.SalesRep.Async_MyActivities" EnableEventValidation="false" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="messages" TagPrefix="messagecontrol" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grdMyActivities" runat="server" CssClass="dgmyact all-activity-table" AutoGenerateColumns="false"
            OnRowDataBound="grdMyActivities_RowDataBound" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                    <span class="edit-activity-link" style="display: none"><%#DataBinder.Eval(Container.DataItem, "ProspectHostEventLink")%></span>
                    <span class="activity-link" style="display: none"><%#DataBinder.Eval(Container.DataItem, "ActivityLink")%></span>
                    <span class="contact-id" style="display: none"><%#DataBinder.Eval(Container.DataItem, "ContactID")%></span>
                    <span class="activity-id" style="display: none">
                                <%#DataBinder.Eval(Container.DataItem,"ActivityID")%></span> <span class="activity-type"
                                    style="display: none">
                            <%#DataBinder.Eval(Container.DataItem,"ActivityType")%></span>
                            <span id="ActivityStatus" runat="server" class="Activity-Status" style="display:none"><%#DataBinder.Eval(Container.DataItem,"ActivityStatus")%></span>
                        <%# DataBinder.Eval(Container.DataItem, "ActivityTypeImage")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due On">
                    <ItemTemplate>
                        <span class="redtxt_default" style="float: left">
                            <%# DataBinder.Eval(Container.DataItem, "ActivityTime") %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Subject") %>
                        <%# DataBinder.Eval(Container.DataItem, "ContactWith")%>
                        <a class="contact-link" href='/App/Franchisor/AddNewContact.aspx?ContactID=<%# DataBinder.Eval(Container.DataItem, "ContactID") %>'>
                            <%# DataBinder.Eval(Container.DataItem, "Contact") %>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Related To">
                    <ItemTemplate>
                        <a class="related-to-link" href='<%# DataBinder.Eval(Container.DataItem, "ProspectHostEventLink") %>'>
                            <%# DataBinder.Eval(Container.DataItem, "Prospect") %>
                        </a>&nbsp; (<%# DataBinder.Eval(Container.DataItem, "ActivityText")%>)
                        <%# DataBinder.Eval(Container.DataItem, "EventStatus")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
						<div style="width:90px">
                        <a class="edit-link" href='<%# DataBinder.Eval(Container.DataItem, "ActivityLink") %>'>Edit</a> |
                        <a class="delete-link" href='javascript:void(0);' onclick="javascript:DeleteActivity(this);">
                            Delete</a><a href="javascript:void(0)">
                                <img src="/App/Images/flag-orng.gif" alt="Mark Activity" title="Mark Activity"
                                 id="markedUnmarked" runat="server" class="Mark-UnMark" onclick="javascript:MarkActivity(this);" /></a>
						</div>
					</ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="rostyle" />
            <HeaderStyle CssClass="hdrstyle" Font-Size="11px" />
            <AlternatingRowStyle CssClass="rostyle" />
        </asp:GridView>
        <div id="activityDiv" runat="server" style="display:none"><br /><messagecontrol:messages id="activityMessage" runat="server"/></div>
    </div>
    </form>
</body>
</html>

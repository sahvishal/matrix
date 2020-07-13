<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncEventActivityTemplate.aspx.cs" 
    Inherits="Falcon.App.UI.App.Common.CreateEventWizard.AsyncEventActivityTemplate" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divEventActivity" runat="server">
        <asp:GridView runat="server" ID="gridActivitytime" AutoGenerateColumns="False" CssClass="divgrid_cl"
            GridLines="None" DataKeyNames="ActivityID" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="When">
                    <ItemTemplate>
                        <%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "ForAfterEvent")) == false ? "T - " : "T + "%> <%# DataBinder.Eval(Container.DataItem, "ActivityDay")%> days
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="What?">
                    <ItemTemplate>
                        <b><%# DataBinder.Eval(Container.DataItem, "ActivityName")%>:</b> <%# DataBinder.Eval(Container.DataItem, "Notes")%></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Who?">
                    <ItemTemplate>
                       <%# DataBinder.Eval(Container.DataItem, "RoleName")%>
                       <%# DataBinder.Eval(Container.DataItem, "SpecifiedUserName").ToString().Length > 0 ? "<br />" + DataBinder.Eval(Container.DataItem, "SpecifiedUserName").ToString() : ""%>
                       <%# DataBinder.Eval(Container.DataItem, "SpecifiedEmail").ToString().Length > 0 ? "<br />" + DataBinder.Eval(Container.DataItem, "SpecifiedEmail").ToString() : ""%>
                       </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <RowStyle CssClass="row2" />
            <HeaderStyle CssClass="row1" />
            <AlternatingRowStyle CssClass="row3" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>

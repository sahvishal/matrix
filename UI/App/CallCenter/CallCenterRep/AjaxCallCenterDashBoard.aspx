<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_CallCenter_CallCenterRep_AjaxCallCenterDashBoard"
    CodeBehind="AjaxCallCenterDashBoard.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMain" runat="server">
        <p>
            <div class="graybdrbox950_blankblock" id="dvNoItemFound" runat="server" style="display: none">
                <span style="font-weight: bold; font-size: 15px; color: #4490B2;">No Record(s) Found
                </span>
            </div>
            <img src="../../Images/specer.gif" width="500px" height="5px" /></p>
        <div style="float: left; width: 730px;" id="divGrid" runat="server">
            <asp:GridView ID="grdCustomerList" runat="server" CssClass="divgrid_cl" AutoGenerateColumns="false"
                GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Call Type">
                        <ItemTemplate>
                            <span>
                                <%# DataBinder.Eval(Container.DataItem, "NotificationTypeName")%>
                                <br />
                                <%#Eval("Tag")%></span>
                            <br />
                            <span><b>HSC: </b>
                                <%# DataBinder.Eval(Container.DataItem, "SalesRep")%>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Caller Details">
                        <ItemTemplate>
                            <span>
                                <%# DataBinder.Eval(Container.DataItem, "CustomerName")%></span>
                            <br />
                            Office:<span><%# DataBinder.Eval(Container.DataItem, "PhoneOffice")%></span>
                            <br />
                            Cell:<span><%# DataBinder.Eval(Container.DataItem, "PhoneCell")%></span>
                            <br />
                            Home:<span><%# DataBinder.Eval(Container.DataItem, "PhoneHome")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Queued Date">
                        <ItemTemplate>
                            <span>
                                <%# DataBinder.Eval(Container.DataItem, "DeadLine")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <div style="vertical-align: middle">
                                <%--<a href="CustomerOptions.aspx?CallType=OutBound&CustomerID=<%# DataBinder.Eval(Container.DataItem, "CustomerID")%>&Name=<%# DataBinder.Eval(Container.DataItem, "CustomerName")%>"/>--%>
                                <a onclick="return ChangeStatus();" href="/CallCenter/CallCenterRepDashBoard/Index?CallType=OutBound&CustomerID=<%# DataBinder.Eval(Container.DataItem, "CustomerID")%>&Name=<%# (DataBinder.Eval(Container.DataItem, "CustomerName")).ToString().Replace("\"","@")%>&NotificationPhoneID=<%# DataBinder.Eval(Container.DataItem, "NotificationPhoneID")%>&Source=<%#DataBinder.Eval(Container.DataItem,"Source") %>&ProspectCustomerId=<%#Eval("ProspectCustomerId")%>&Tag=<%#Eval("Tag") %>" />
                                <img alt="StartCall" id="ibtnstartcall" runat="server" src="~/App/Images/CCRep/startcall-small-btn.gif" /></a></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="row1" />
                <RowStyle CssClass="row2" />
                <AlternatingRowStyle CssClass="row3" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>

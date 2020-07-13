<%@ Page Language="C#" AutoEventWireup="True"
    Inherits="Franchisee_SalesRep_PhotoManagement" Title="Photo Management" Codebehind="PhotoManagement.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/ucphotopanel.ascx" TagName="ucphotopanel" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Photos</title>
    <link href="../../StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
    <link href="../../StyleSheets/UC.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server" style="background-color: #fff;">
        <div style="float: left; width: 500px; padding: 10px;">
            <%-- <div style=" float:left; width:482px; text-align:right;">
                <asp:Button runat="server" ID="btnupdate" Text="Update" />
            </div>--%>
            <div id="divmyphoto" style="margin-bottom: 5px; float: left; width: 500px;">
                <asp:Panel runat="server" ID="pnlmphoto" GroupingText="My Photo" Width="475px">
                    <uc1:ucphotopanel ID="ucmyphoto" runat="server" ImageCaption="My Photo" ImageX="150px"
                        ImageY="107px" />
                </asp:Panel>
            </div>
            <div id="divteamphoto" style="margin-bottom: 5px; margin-top: 5px; float: left; width: 500px;">
                <asp:Panel runat="server" ID="pnltphoto" GroupingText="Team Photo" Width="475px">
                    <uc1:ucphotopanel ID="ucteamphoto" runat="server" ImageCaption="Team Photo" ImageX="150px"
                        ImageY="107px" />
                </asp:Panel>
            </div>
            <asp:Panel runat="server" GroupingText="Other Photos" ID="pnlgrid" Width="475px">
                <div id="divotherphoto" style="margin-bottom: 5px; margin-top: 5px; float: left;
                    width: 473px; height: 200px; overflow: scroll;">
                    <asp:GridView runat="server" ShowHeader="false" ID="grdphotoother" AutoGenerateColumns="false"
                        Width="450px">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <uc1:ucphotopanel ID="Ucphotopanel1" runat="server" ImageCaption='<%# DataBinder.Eval(Container.DataItem, "Caption") %>'
                                        ImagePath='<%# DataBinder.Eval(Container.DataItem, "Path") %>' ImageX="90px"
                                        ImageY="57px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <div style="margin-bottom: 5px; margin-top: 5px; float: left; width: 482px; text-align: right;">
                <asp:Button runat="server" ID="btnupdatedown" Text="Update" OnClick="btnupdatedown_Click" />
            </div>
        </div>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
    </form>
</body>
</html>

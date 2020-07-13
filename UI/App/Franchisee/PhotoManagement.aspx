<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoManagement.aspx.cs"
    Inherits="Franchisee_PhotoManagement" Title="Photo Management" %>

<%@ Register Src="~/App/UCCommon/ucphotopanel.ascx" TagName="ucphotopanel" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Photos</title>
    <link href="../StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/UC.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server" style="background-color: #fff;">
        <div class="divmain_photomgmt">

            <div id="divmyphoto" class="divmyphoto_photomgmt">
                <asp:Panel runat="server" ID="pnlmphoto" GroupingText="My Photo" CssClass="headtxtpanel_photomgmt">
                    <uc1:ucphotopanel ID="ucmyphoto" runat="server" ImageCaption="My Photo" ImageX="150px"
                        ImageY="107px" />
                </asp:Panel>
            </div>
            <div id="divteamphoto" class="divteamphoto_photomgmt">
                <asp:Panel runat="server" ID="pnltphoto" GroupingText="Team Photo" CssClass="headtxtpanel_photomgmt">
                    <uc1:ucphotopanel ID="ucteamphoto" runat="server" ImageCaption="Team Photo" ImageX="150px"
                        ImageY="107px" />
                </asp:Panel>
            </div>
            <div class="divmainotherphoto_photomgmt">
            <asp:Panel runat="server" GroupingText="Other Photos" ID="pnlgrid" CssClass="headtxtpanel_photomgmt">
                <div id="divotherphoto" class="divotherphoto_photomgmt">
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
            </div>
            <div class="divbtnrow_photomgmt">
                <asp:Button runat="server" ID="btnupdatedown" Text="Update" OnClick="btnupdatedown_Click" />
            </div>
        </div>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" Inherits="CheckCityZip" Codebehind="CheckCityZip.aspx.cs" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
    <div>
        <table>
            <tr>
                <td>Country</td>
                <td><asp:DropDownList ID="ddlCountry" runat="server" Width="170">
                    <asp:ListItem Value="0">select country</asp:ListItem>
                    <asp:ListItem Value="68">USA</asp:ListItem>
                </asp:DropDownList>
                    
                    </td>
            </tr>
            <tr>
                <td>State</td>
                <td><asp:DropDownList ID="ddlState" runat="server" Width="170" /></td>
            </tr>
            <tr>
                <td>City</td>
                <td><asp:DropDownList ID="ddlCity" runat="server" Width="170" AutoPostBack="true"/></td>
            </tr>
        </table>
        <br />
        
        <ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlCountry"
            Category="Make"  PromptText="Please select a country"  LoadingText="[Loading country...]" ServicePath="AutoCompleteService.asmx"
            ServiceMethod="GetCountry" />
            
        <ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlState"
            Category="Model" PromptText="Please select a state" LoadingText="[Loading city...]"
            ServiceMethod="GetState" ParentControlID="ddlCountry" ServicePath="AutoCompleteService.asmx" />
            
        <ajaxToolkit:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlCity"
            Category="Color" PromptText="Please select a city" LoadingText="[Loading city...]" ServiceMethod="GetCountry"
            ParentControlID="ddlState" ServicePath="AutoCompleteService.asmx" />
    </div>
    </form>
</body>
</html>

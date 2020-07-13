<%@ Page Language="C#" Title="Calculate CPM Commission" AutoEventWireup="true" Inherits="App_MarketingPartner_CalculateService" Codebehind="CalculateService.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Calculate" 
            onclick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Click here to generate CPM Commission"></asp:Label>
    </div>
    </form>
</body>
</html>

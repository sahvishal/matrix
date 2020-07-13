<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="Falcon.App.UI.App.Common.Results" %>

<%@ Register Src="~/Config/Content/Controls/Results/ViewableResult.ascx" TagName="ViewableResult"
    TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Content/Styles/Style.css" rel="stylesheet" type="text/css" />
    <link href="/app/StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
    <link href="/App/StyleSheets/Commonstyle.css" rel="Stylesheet" type="text/css" />
    <link href="/app/StyleSheets/UC.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            currentScreenMode = ScreenMode.ViewResults;
            $(".clear-all-selection").hide();
            hideAll();
        });

    </script>
    <div class="maintopcontainer">
        <div class="mainbodyouter">
            <uc:ViewableResult runat="server" ID="ViewableResult" />
        </div>
    </div>
    </form>
</body>
</html>

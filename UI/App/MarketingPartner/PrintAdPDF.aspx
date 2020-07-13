<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_MarketingPartner_PrintAdPDF" CodeBehind="PrintAdPDF.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">

        $(document).ready(function () {
            var decoded = $("<textarea/>").html($("#<%=dvPrintAd.ClientID %>").html()).text();
            $("#<%=dvPrintAd.ClientID %>").html(decoded);
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dvPrintAd" runat="server">
        </div>
    </form>
</body>
</html>

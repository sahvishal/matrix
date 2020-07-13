<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewGiftCertificate.aspx.cs"
    Inherits="HealthYes.App.Common.PreviewGiftCertificate" %>

<%@ Register Src="~/App/Uccommon/GiftCertificatePreview.ascx" TagName="Preview" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gift Certificate Preview</title>    
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Preview ID="GiftCertificatePreview" runat="server" />
    <div class="closepreview" style="text-align: center">
        <a href="#" onclick="return Close();">Close Preview</a>
    </div>
    <script type="text/javascript" language="javascript">
        function Close() {
            parent.top.tb_remove();
            return true;
        }
    </script>
    </form>
</body>
</html>

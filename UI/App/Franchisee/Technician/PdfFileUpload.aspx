<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfFileUpload.aspx.cs"
    Inherits="Falcon.App.UI.App.Franchisee.Technician.PdfFileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .left
        {
            float: left;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function setValues() {
            document.getElementById("<%= ImageLocationPrefix.ClientID %>").value = parent.getLocationPrefix();
            document.getElementById("<%= ImageUrlPrefix.ClientID %>").value = parent.getUrlPrefix();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="left" style="padding: 5px;">
        <span class="left">
            <asp:FileUpload runat="server" ID="fileUpload" /></span> <span class="left" style="padding: 2px 0 0 5px">
                <asp:ImageButton runat="server" ID="UploadImageButton" ImageUrl="~/App/Images/uploadnew-button.gif"
                    OnClick="UploadImageButton_Click" /></span>
    </div>
    <asp:HiddenField runat="server" ID="ImageLocationPrefix" Value="" />
    <asp:HiddenField runat="server" ID="ImageUrlPrefix" Value="" />
    </form>
</body>
</html>

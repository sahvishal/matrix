<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadAwvTestResultFile.aspx.cs" Inherits="Falcon.App.UI.App.Franchisee.Technician.UploadAwvTestResultFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="/Scripts/jquery-1.5.2.min.js"></script>
    <style type="text/css">
        .left {
            float: left;
        }
    </style>
    <script type="text/javascript">

        function setValues() {
            document.getElementById("<%= ImageLocationPrefix.ClientID %>").value = parent.getLocationPrefix();
            document.getElementById("<%= ImageUrlPrefix.ClientID %>").value = parent.getUrlPrefix();
        }
        
        function UploadClick() {
            
            var fileExpression = /^.+(.pdf|.PDF)$/;
            

            if ($.trim($("#<%= fileUpload.ClientID%>").val()).length > 0 && fileExpression.exec($.trim($("#<%= fileUpload.ClientID%>").val())) == null) {
                alert('File format not supported. Only PDF file allowed.');
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="left" style="padding: 5px;">
            <span class="left">
                <asp:FileUpload runat="server" ID="fileUpload" /></span> <span class="left" style="padding: 2px 0 0 5px">
                    <asp:ImageButton runat="server" ID="UploadImageButton" ImageUrl="~/App/Images/uploadnew-button.gif" OnClientClick="return UploadClick();"
                        OnClick="UploadImageButton_Click" /></span>
        </div>
        
        <asp:HiddenField runat="server" ID="ImageLocationPrefix" Value="" />
        <asp:HiddenField runat="server" ID="ImageUrlPrefix" Value="" />
    </form>
</body>
</html>

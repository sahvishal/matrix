<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Security Code Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="0px" cellpadding="0px" width="270px" style="border: 1px solid #00A5E6">
            <tr>
                <td style="padding: 10px; font: bold 12px arial; color: #666;">
                    <img src="/Content/Images/CodeshowSample.gif" /><br />
                    <br />
                    Why Do I Need to Enter This Code?
                </td>
            </tr>
            <tr>
                <td style="padding: 10px; font: normal 12px arial; color: #666; text-align: justify">
                    By entering the code you see in the box, you help prevent automated transactions.
                    This reduces system loads and ensures better performance of our services.
                    <br />
                    <br />
                    If no image appears, please make sure your browser is set to display images and
                    try again. If you are not sure what the code is, make your best guess. If you guess
                    incorrectly, you will have another oppurtunity by clicking the image to have a different
                    code.
                </td>
                <tr>
                    <td style="padding: 10px;">
                        <asp:Button Text="Close" OnClientClick="javascript:window.close()" runat="server"
                            ID="bthClose" />
                    </td>
                </tr>
            </tr>
        </table>
    </form>
</body>
</html>

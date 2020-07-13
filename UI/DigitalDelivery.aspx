<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DigitalDelivery.aspx.cs"
    Inherits="Falcon.App.UI.DigitalDelivery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generating PDF...</title>
    <style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 275px;
        }
        .wrapperin_pop
        {
            float: left;
            width: 261px;
            padding: 5px;
            background-color: #fff;
        }
        .innermain_pop
        {
            float: left;
            width: 251px;
            border: solid 2px #4888AB;
            padding: 0px 5px 0px 5px;
        }
        .innermain_1_pop
        {
            float: left;
            width: 163px;
            padding-top: 5px;
        }
    </style>
    <script type="text/javascript" language="javascript">
    function ResizePopup()
    {
        //WinPrint = window.open(pdfPath,'_parent','left=0,top=0,width=500,height=500,toolbar=0,scrollbars=0,status=0,titlebar=0');
        window.parent.resizeTo(800,600);
        
    }
    </script>
</head>
<body>
    <div class="wrapper_pop">
        <div class="wrapperin_pop" id="_divProgressBar" style="display: block;" runat="server">
        <div class="innermain_pop">
            <p style="float: left; font: bold 14px Arial; color: #F47E1C;">
                Generating PDF
            </p>
            <p style="margin-top:10px; float:left">
                <span>
                    <img src="/App/Images/loading_pdf.gif" alt="" width="145px" height="32px" />
                </span>
            </p>
          </div>
        </div>
        <div id="_divMessageMsg" style="display:none; font: bold 14px Arial; color: red; float:left; width:100%" runat="server">
            <span id="_spErrorMsg" runat="server"></span>
        </div>
    </div>
</body>
</html>

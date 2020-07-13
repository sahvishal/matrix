<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkPrintResult.aspx.cs"
    Inherits="BulkPrintResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <title>Generating PDF...</title>

    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js" language="javascript"></script>

    <script type="text/javascript" language="javascript">
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();
        
        var WinPrint;
        function requestFailed()
        {//debugger
            
        }
        
        function asynLoadBulkPDF(pdfType)
        {//debugger
            var hfEventID=document.getElementById("<%=this.hfEventID.ClientID %>");
            postRequest.url ="BulkPDF.ashx?EventID=" + hfEventID.value + "&PDFType=" + pdfType;
	        postRequest.successCallback = CallPrint;
	        postRequest.post("");
        	 
	        return false;
        }
        function CallPrint(httpRequest)
        {//debugger
            //debugger
            var result= httpRequest.responseText;
            if(result.indexOf("http")>=0)
            {
                var divProgressBar=document.getElementById("divProgressBar");
                divProgressBar.style.display="none";
                var pdfPath=httpRequest.responseText;
                WinPrint = window.open(pdfPath,'_parent','left=0,top=0,width=500,height=500,toolbar=0,scrollbars=0,status=0,titlebar=0');
                WinPrint.resizeTo(800,600);
                //setTimeout("timeOut()",60000);
            }
            else
            {
                errorMsg();
            }
        }
        
        function timeOut()
        {//debugger
            if (WinPrint !=null)
            {
                WinPrint.focus();
                WinPrint.print();
                WinPrint.close();
            } 
            else
            {
                alert(pdfPath);
            }
                      
        }
        
        function errorMsg()
        {
            var divErrorMsg=document.getElementById("divErrorMsg");
            divErrorMsg.style.display="block";
            var spErrorMsg=document.getElementById("spErrorMsg");
            spErrorMsg.innerHTML="No Results has been uploaded";
            spErrorMsg.style.display="block";
            
            var divProgressBar=document.getElementById("divProgressBar");
            divProgressBar.style.display="none";
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper_pop">
        <div class="wrapperin_pop" id="divProgressBar" style="display: block;">
            <p style="float: left; font: bold 14px Arial; color: #F47E1C;">
                Generating PDF
            </p>
            <p class="innermain_pop" style="margin-top: 10px;">
                <span>
                    <img src="/App/Images/loading_pdf.gif" alt="" />
                </span>
            </p>
        </div>
        <div id="divErrorMsg" style="display: none; font: bold 14px Arial; color:red;">
            <span id="spErrorMsg" style="display: none;"></span>
        </div>
    </div>
    <asp:HiddenField ID="hfEventID" runat="server" />
    </form>
</body>
</html>

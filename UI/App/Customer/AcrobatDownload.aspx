<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcrobatDownload.aspx.cs"
    Inherits="Falcon.App.UI.App.Customer.AcrobatDownload" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%= IoC.Resolve<ISettings>().CompanyName%> - Acrobat Reader Information</title>
    <link href="/App/StyleSheets/Customer.css" rel="Stylesheet" type="text/css" />
    <link href="/App/StyleSheets/Commonstyle.css" rel="Stylesheet" type="text/css" />
</head>
<body style="overflow-y:scroll;overflow-x:hidden;background:#fff">
    <form id="form1" runat="server">
    <div id="content">
        <h1>
            How to View PDF Files</h1>
        <p>
            Your results are in PDF format (Portable Document Format). These files are created
            by Adobe Acrobat software and can be viewed with Adobe Acrobat Reader.</p>
        <p>
            If you do not have the latest version of Acrobat installed on your computer, you
            may download the free version from <a href="http://get.adobe.com/reader/" target="_blank">
                Adobe's Web site</a>.</p>
        <p>
            Once you reach Adobe's website click on the download icon.
            <img src="/App/Images/customer/adobe-reader-download-icon.gif" alt="Acrobat Reader Download" />
        </p>
        <p>
            After clicking the icon, you will be guided through the installation process. Once
            Acrobat Reader is installed, you can review your results.</p>
        <p>            
            <%= IoC.Resolve<ISettings>().CompanyName%><br />
            <%= IoC.Resolve<ISettings>().Address1%><br />
            <%= IoC.Resolve<ISettings>().Address2%><br />
            <%= IoC.Resolve<ISettings>().City%>, <%= IoC.Resolve<ISettings>().State%> <%= IoC.Resolve<ISettings>().ZipCode%><br />
            <%= IoC.Resolve<ISettings>().PhoneTollFree%> (Toll free)
        </p>
    </div>
    </form>
</body>
</html>

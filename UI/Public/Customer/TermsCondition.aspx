<%@ Page Language="C#" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Terms and Condition</title>
    <link href="/Config/Content/Styles/Scheduling.css" type="text/css" rel="Stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Cabin">
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 550px; margin: 0 auto;">
        <p class="tm-header">
            Terms and conditions for
            <%= IoC.Resolve<ISettings>().CompanyName%>
        </p>
        <p class="tm-content">
            <%= IoC.Resolve<ISettings>().CompanyName%>
            expressly disclaims all warranties and responsibilities of any kind, whether express
            or implied, for the accuracy or reliability of the content of any information contained
            in this Web Site. While we have made a concerted effort to provide you with the
            best possible information, this website is not a substitute for a visit with your
            healthcare professional, and any reliance upon or use of this information by you
            is at your own independent discretion and risk. By using this site you agree to
            these terms.
        </p>
        <p class="tm-header">
            Cancelation Policy
        </p>
        <p class="tm-content">
            All appointments require prepayment at the time of scheduling. Should you need to
            cancel your appointment; a full refund will be issued minus a $25.00 cancellation
            fee. If less than 48 hours notice is given, Matrix Medical Network will issue a Gift Certificate
            for the full amount to be used by you, or anyone you choose, to purchase future
            screening products or services. Gift Certificates are valid for 365 days from the
            date of issue.
            <br />
            <br />
            If you miss your scheduled appointment time, no refund will be issued. We will do
            our best to schedule your appointment for the next available appointment date and
            time. If there are no events scheduled, we will issue a Gift Certificate for the
            full amount to be used by you, or anyone you choose, to purchase future screening
            products or services.
        </p>
        <p style="border-top: solid 1px #1a5ea1; padding-top: 10px; text-align: right;">
            <%-- <input name="Accept" type="button" id="Accept" value="Accept" onClick="terms();self.close();">--%>
            <input name="Accept1" type="button" id="Accept1" value="Close" class="action-button"
                onclick="self.close();">
        </p>
    </div>
    </form>
</body>
</html>

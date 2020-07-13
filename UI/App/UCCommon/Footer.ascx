<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Falcon.App.UI.App.UCCommon.Footer" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<div class="mainbodyouter">
    <div class="footerttxt">
        &copy; Matrix Medical Network <sup>&#0174;</sup> 2007 -
        <asp:Literal ID="YearLiteral" runat="server" />. All Rights Reserved.
        <asp:Literal ID="VersionNumberLiteral" runat="server" />
        <div>
            Last Logged In:  <%= IoC.Resolve<ISessionContext>().LastLoggedInTime%>
         </div>
    </div>
   
    <br />
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-957361-18', 'auto');
        ga('send', 'pageview');

    </script>
</div>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="Falcon.App.UI.Public.Controls.Footer"
    CodeBehind="Footer.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="System.IO" %>

<div style="float:left;width:40%;overflow:hidden;">
        <a target="_blank" href="<%=IoC.Resolve<ISettings>().PrivacyPolicyUrl%>"> Privacy Policy</a> |
        <a target="_blank" href="<%=IoC.Resolve<ISettings>().TermsConditionsUrl%>" class="linksbbottom">Terms and Conditions</a>
</div>

<div style="text-align:right;float:right;width:55%;">
      &copy; 2007 - <%= DateTime.Today.Year %>       <%= IoC.Resolve<ISettings>().CompanyName %> All rights reserved.
</div>                    

<div style="text-align:right;float:right;width:300px;">
      <%if (File.Exists(Server.MapPath("/Config/Content/Html/BuySafe.htm")))
        {
            Response.WriteFile("/Config/Content/Html/BuySafe.htm");
            
        }  %>
</div>                    

      
      
<%@ Control Language="C#" AutoEventWireup="true"  Inherits="Public_Header" Codebehind="Header.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="System.IO" %>
<link rel="stylesheet" type="text/css" href="../../Config/Content/Styles/Style.css" />
<%if (File.Exists(Server.MapPath("/Config/Content/Html/Header.htm")))
        {
           Response.WriteFile("/Config/Content/Html/Header.htm");
            
        } 
     else {%>
     
        <a href="/"><img src="<%=IoC.Resolve<ISettings>().LargeLogo%>" alt="<%=IoC.Resolve<ISettings>().CompanyName%>" /></a>

   <%}%>

   <script language="javascript">
        $(document).ready(function () {
            <%if (File.Exists(Server.MapPath("/Config/Content/Html/Header.htm")))
                {%>
            $("#tollfreenumber").html("<%=IoC.Resolve<ISettings>().PhoneTollFree%>" );
            
                <% } %>
        })
   </script>
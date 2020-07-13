<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucmenucontrol" Codebehind="ucmenucontrol.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Users" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%--Include JQuery as it is used in Menu
TODO: Control the Menu JQuery file through toolkit.--%>
<%@ Register src="../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQToolKit" %>

<%--Include JQueryToolkit For UI as it is used in Menu--%>
<JQToolKit:jQueryToolKit ID="ucJquery" runat="server" IncludeJQueryUI="true"/>

<link rel="stylesheet" type="text/css" href="/Content/Styles/Menu.css" />
   
    <%  
        if (RoleName!=null && RoleName != Falcon.App.Core.Enum.Roles.Customer.ToString())
        {
              string extendedRole = String.Empty;  
              if (RoleName == Falcon.App.Core.Enum.Roles.Technician.ToString() && 
                  IoC.Resolve<ITechnicianRepository>().IsTeamLead(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId))
              {
                  extendedRole = "TeamLead";
              }
            //Changed the name of the files so that this becomes simple - yasir
              Response.WriteFile(String.Format("/Views/Menu/{0}.cshtml", RoleName + extendedRole));
              Response.WriteFile(String.Format("/Views/Shared/SessionTimeOut.cshtml"));
        }

%>



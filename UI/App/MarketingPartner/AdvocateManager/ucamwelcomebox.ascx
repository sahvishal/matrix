<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucamwelcomebox" CodeBehind="ucamwelcomebox.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Application.Impl" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<script type="text/javascript">
window.setTimeout(slowAlert, <%=mintTimeout%>);

function slowAlert()
{
  alert("Your session has expired. You are now redirected to the login page!");
}

</script>
<div class="franchiseenamenew_hrow" id="pFranchiseeNameHeader" runat="server">
    <span id="sFranchiseeNameHeader" runat="server"></span><span class="nametxtbold_header"
        id="dvFranchiseeNameHeader" runat="server"></span>
</div>
<div class="welcometextbg">
    <div>
        Welcome
        <%=IoC.Resolve<ISessionContext>().UserSession.FullName%>
        (<%=IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleDisplayName%>)
        <br />
        <ul>
            <li><a runat="server" id="lnkdashboard" href="Dashboard.aspx">Dashboard</a></li>
            <li>|</li>
            <li>
                <asp:LinkButton ID="lnkContact" runat="server"></asp:LinkButton></li>
            <li>|</li>
            <li><a runat="server" id="lnkProfile">Profile</a></li>
            <li>|</li>
            <li><a runat="server" id="lnkhelp" href="">Help</a></li>
            <li>|</li>
            <li><a href="/App/Logoff.aspx">Logout</a></li>
            <%if (IoC.Resolve<ISessionContext>().UserSession.AvailableOrganizationRoles.Count() > 1)%>
            <%{ %>
            <ul id="drop-down-menu" style="float: right; z-index: 10000;">
                <li><a href="#">Switch Roles</a>
                    <ul>
                        <% var userSession = IoC.Resolve<ISessionContext>().UserSession;
                           foreach (var orgRole in IoC.Resolve<ISessionContext>().UserSession.AvailableOrganizationRoles)
                           {
                               if (userSession.CurrentOrganizationRole.RoleId == orgRole.RoleId) continue;
                        %>
                        <li><a href="/Users/Role/Switch?roleId=<%=orgRole.RoleId%>&organizationId=<%=orgRole.OrganizationId%>">
                            <%=orgRole.RoleDisplayName%></a> </li>
                        <%
                                
                            } %>
                    </ul>
                </li>
            </ul>
            <%}%>
        </ul>
    </div>
</div>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucwelcomebox" CodeBehind="ucwelcomebox.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>


<link rel="stylesheet" type="text/css" href="/Content/Styles/Menu.css" />
<style type="text/css">
    /*---------- bubble tooltip ----- < these classes has been renamed because of overwriting classes > ------*/
    a.tt1
    {
        position: relative;
        z-index: 24;
        color: #333;
        font-weight: bold;
        text-decoration: none;
    }
    a.tt1 span
    {
        display: none;
    }
    /*background:; ie hack, something must be changed in a for ie to execute it*/a.tt1:hover
    {
        z-index: 25;
        color: #333;
        background: ;}
    a.tt1:hover span.tooltip
    {
        display: block;
        position: absolute;
        top: 0px;
        left: 0;
        padding: 15px 0 0 0;
        width: 320px;
        color: #333;
        font-size:11px;
        line-height:17px;
        text-align: left;
        filter: alpha(opacity:90);
        khtmlopacity: 0.90;
        mozopacity: 0.90;
        opacity: 0.90;
    }
    a.tt1:hover span.top
    {
        display: block;
        padding: 30px 8px 0;
        background: url(/App/Images/bubblebig.gif) no-repeat top;
    }
    a.tt1:hover span.middle
    {
        /* different middle bg for stretch */
        display: block;
        padding: 0 8px;
        background: url(/App/Images/bubblefillerbig.gif) repeat bottom;
    }
    a.tt1:hover span.bottom
    {
        display: block;
        padding: 3px 8px 10px;
        color: #548912;
        background: url(/App/Images/bubblebig.gif) no-repeat bottom;
    }
</style>
<div class="franchiseenamenew_header">
    <div class="left" id="pBeta" runat="server" style="display: none; float: left;">
        <span class="smalltxtlnk" style="float: left; width: 200px;">
            <img src="/App/Images/beta-version.gif" alt="" />
            [ <a href="javascript:void(0);" class="tt1" runat="server" id="ahrefToolTipIsPaid">What
                is this? <span class="tooltip"><span class="top"></span><span class="middle"><strong>
                    " Beta"</strong> is a nickname for software which has passed the alpha testing stage
                    of development and has been released to users for software testing before its official
                    release. It is the prototype of the software that is released to the public. Beta
                    testing allows the software to undergo usability testing with users who provide
                    feedback, so that any malfunctions these users find in the software can be reported
                    to the developers and fixed. </span><span class="bottom"></span></span></a>
            ] </span>
    </div>
    <div class="franchiseenamenew_hrow" id="pFranchiseeNameHeader" runat="server">
        <span id="sFranchiseeNameHeader" runat="server"></span><span class="nametxtbold_header"
            id="dvFranchiseeNameHeader" runat="server"></span>
    </div>
</div>
<%-- nav links --%>
<div class="welcometextbg">
    <div>
        Welcome
        <%=IoC.Resolve<ISessionContext>().UserSession.FullName%>
        (<%=IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleDisplayName%>)
        <br />
        <a href="/Users/Dashboard/<%=IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias%>">
            <% if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Falcon.App.Core.Enum.Roles.Customer) %>
            <%{ %>
            Home
            <%} else {%>
            Dashboard
            <%} %>
        </a> | 
        <% if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Falcon.App.Core.Enum.Roles.Customer) %>
        <%{ %>
            <a href="/App/Customer/UpdateEventCustomerProfile.aspx?Ref=DashBoard">Profile</a>
        <%} else {%>
            <a href="/Users/Profile/Edit/?id=<%=IoC.Resolve<ISessionContext>().UserSession.UserId%>&roleId=<%=IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId%>">Profile</a>
        <%} %>
        | <a href="/App/Logoff.aspx">Logout</a>
        <%if (IoC.Resolve<ISessionContext>().UserSession.AvailableOrganizationRoles.Count() > 1)%>
        <%{ %>
        <ul id="drop-down-menu" style="float: right; z-index: 10000;">
            <li><a href="#">Switch Roles</a>
                <ul>
                    <%
              var userSession = IoC.Resolve<ISessionContext>().UserSession;
              var multipleItemsforSameRole = userSession.AvailableOrganizationRoles.GroupBy(m => m.RoleId).Select(m => new { m.Key, Count = m.Count() }).Distinct().ToArray(); 
              foreach (var orgRole in userSession.AvailableOrganizationRoles)
              {
                  if (userSession.CurrentOrganizationRole.OrganizationRoleUserId == orgRole.OrganizationRoleUserId) continue;
                    %>
                    <li><a href="/Users/Role/Switch?roleId=<%=orgRole.RoleId%>&organizationId=<%=orgRole.OrganizationId%>">
                        <%=orgRole.RoleDisplayName%> <%= (multipleItemsforSameRole.Where(m => m.Key == orgRole.RoleId).Select(m => m.Count).SingleOrDefault() > 1 ? "(" + orgRole.OrganizationName + ")" : "") %></a> </li>
                    <%
              } %>
                </ul>
            </li>
        </ul>
        <%}%>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('#drop-down-menu > li').bind('mouseover', openDropDown);
        $('#drop-down-menu > li').bind('mouseout', dropDownTimer);
    });    
</script>

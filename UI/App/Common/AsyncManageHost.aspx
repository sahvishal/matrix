<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncManageHost.aspx.cs" Inherits="Falcon.App.UI.App.Common.AsyncManageHost" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" GridLines="None" ID="grdProspect" AutoGenerateColumns="false"
            CssClass="divgrid_cl" DataKeyNames="ProspectId" OnRowDataBound="grdProspect_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "ProspectId")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkProspectNameColumn" runat="server" Text="Name" OnClientClick="return LoadProspectTableonSort('ProspectName');">Name</asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a title="Host Details" href="<%=_prospectDetailsPage%>&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                            <%# DataBinder.Eval(Container.DataItem, "ProspectName")%>
                        </a>
                        <br />
                        <%# DataBinder.Eval(Container.DataItem, "ProspectCompleteAddress")%>
                        <br />
                        <%# DataBinder.Eval(Container.DataItem, "PhoneOffice")%>
                        <span id="googleAddressVerification" runat="server"></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Primary Contact">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkContactNameColumn" runat="server" Text="Primary Contact" OnClientClick="return LoadProspectTableonSort('ContactName');">Primary Contact</asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div id="divNamePhoneEmail" runat="server" style="display: block; visibility: visible">
                            <span id="spnName" runat="server">
                                <%# DataBinder.Eval(Container.DataItem, "ContactFirstName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "ContactLastName")%></span>
                            <br />
                            Ph:<span id="spnPhone" runat="server"><%# DataBinder.Eval(Container.DataItem, "ContactPhone")%></span>
                            <br />
                            Email:<span id="spnEmail" runat="server"><%# DataBinder.Eval(Container.DataItem, "ContactEmail")%></span>
                            <br />
                        </div>
                        <span id="spnAddPrimaryContact" runat="server"><a style="visibility: visible; display: block"
                            href="/App/Franchisor/AddNewContact.aspx?PrimaryContact=True&HostID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                            <%# DataBinder.Eval(Container.DataItem, "LnkAddContact")%>Add Primary Contact </a>
                        </span><a href="/App/Franchisor/AddCallProspect.aspx?Parent=True&IsHost=True&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                            <%# DataBinder.Eval(Container.DataItem, "LnkContactViewAll")%>Add Call </a>&nbsp;|&nbsp;
                                    <a href="/App/Franchisor/AddMeeting.aspx?Parent=True&IsHost=True&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                        <%# DataBinder.Eval(Container.DataItem, "LnkContactAddMeeting")%>Add Meeting
                                    </a>
                        <br />
                        <a title="Add Quick Task" href="#" title="Add Quick Task" onclick='return AddTask(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>);'>
                            Add Quick Task</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Call Activity">
                    <ItemTemplate>
                        Call:
                        <%# DataBinder.Eval(Container.DataItem, "ContactCallStatus")%>
                        <br />
                        Date:
                        <%# DataBinder.Eval(Container.DataItem, "ContactCallDate")%>
                        <br />
                        <a href="javascript:void(0);" class="tt" runat="server" id="ahrefToolTipIsPaid"><b>Notes</b>
                            <span class="tooltip"><span class="top"></span><span class="middle" id="spndefcursor<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>"
                                onmouseover="changetodefault('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>');"
                                onmouseout="changetopointer('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>');">
                                <%# DataBinder.Eval(Container.DataItem, "NotesToolTip")%>
                            </span><span class="bottom"></span></span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Activity Summary
                    </HeaderTemplate>
                    <ItemTemplate>
                        Status:
                        <%# DataBinder.Eval(Container.DataItem, "ProspectStatus")%><br />
                        Call:<a title="View Calls" href="javascript:RedirectCall(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,<%# DataBinder.Eval(Container.DataItem, "NoOFCalls")%>);">
                            <%# DataBinder.Eval(Container.DataItem, "NoOFCalls")%>
                        </a>
                        <br />
                        Meeting: <a title="View Meetings" href="javascript:RedirectMeeting(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,<%# DataBinder.Eval(Container.DataItem, "NoOFMeeting")%>);">
                            <%# DataBinder.Eval(Container.DataItem, "NoOFMeeting")%>
                        </a>
                        <br />
                        Contacts: <a title="View Contacts" href="javascript:RedirectContact(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,<%# DataBinder.Eval(Container.DataItem, "NoOfContacts")%>);">
                            <%# DataBinder.Eval(Container.DataItem, "NoOfContacts")%>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Owned By">
                    <ItemTemplate>
                        <span id="spSalesPerson" runat="server">Owned By:<br />
                            <span class="btextblu">
                                <%# DataBinder.Eval(Container.DataItem, "SalesPersonFirstName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "SalesPersonLastName")%></span>
                        </span><span id="spFranchisee" runat="server" style="display: none">Franchisee:<br />
                            <span class="btextblu">
                                <%# DataBinder.Eval(Container.DataItem, "FranchiseeName")%></span> </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div style="float: left;">
                            <span class="lnktxtbot_urm" style="float: right; font-size: 12px;"><a href="javascript:void(0);"
                                id='aAction<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>' onmouseover='ShowActionList(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,this);'
                                onmouseout='HideActionList(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,event);'>
                                <b>ACTION </b></a>
                                <img src="/App/Images/downarrowsmall.gif" />
                            </span>
                            <div id='divActionList<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>' style="display: none;"
                                class="spaction_cdpage" onmouseout="this.style.display = 'none';" onmouseover="this.style.display = 'block';">
                                <div id="innerCustomerLinks" onmouseout="HideActionLinksITSELF(this, event);" onmouseover="this.parentNode.style.display = 'block';"
                                    class="spactioninner_cdpage">
                                    <span id="spLnkRegBtn" runat="server" class="spactionelement_cdpage"><a href="<%=_prospectDetailsPage%>&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                        View Details </a></span><span id="Span4" runat="server" class="spactionelement_cdpage">
                                            <a href="/App/Common/AddNewHost.aspx?Parent=Host&HostID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                                Edit Host </a></span><span id="Span7" runat="server" class="spactionelement_cdpage">
                                                    <a href="/App/Franchisor/AddNewContact.aspx?IsHost=True&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                                        <%# DataBinder.Eval(Container.DataItem, "LnkAddContact")%>Add Contact </a>
                                    </span><span id="spnAddEvent" runat="server" class="spactionelement_cdpage"><a href="/App/Common/CreateEventWizard/Step1.aspx?Type=Create&HostID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                        <%# DataBinder.Eval(Container.DataItem, "LnkAddContact")%>Add Event </a></span>
                                    <span id="Span9" runat="server" class="spactionelement_cdpage"><a href="#" onclick="DeleteHost(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>);">
                                        Delete Host </a></span><span id="HostRatingSpan" runat="server" class="spactionelement_cdpage" style="display: none;">
                                            <a href='/App/Franchisee/HostRanking.aspx?HostId=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>'>Rate
                                                This Host</a> </span>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false"></asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="row1" />
            <RowStyle CssClass="row2" />
            <AlternatingRowStyle CssClass="row3" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>

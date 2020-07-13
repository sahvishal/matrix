<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncManageProspect.aspx.cs" Inherits="HealthYes.Web.App.Common.AsyncManageProspect" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView runat="server" GridLines="None" ID="grdProspect" AutoGenerateColumns="false"
                        CssClass="divgrid_cl"
                        onrowdatabound="grdProspect_RowDataBound" 
                        DataKeyNames="ProspectId">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "ProspectId")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <HeaderTemplate>
                                        <asp:LinkButton id="lnkProspectNameColumn" runat="server" Text="Name" OnClientClick="return LoadProspectTableonSort('ProspectName');">Name</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <a  title="Prospect Details" href="<%=strProspectDetailsPage%>&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                      <%# DataBinder.Eval(Container.DataItem, "ProspectName")%>  
                                    </a> 
                                    <br />
                                    <%# DataBinder.Eval(Container.DataItem, "ProspectCompleteAddress")%>
                                    <br />
                                    <%# DataBinder.Eval(Container.DataItem, "PhoneOffice")%>
                                    <br /><span id="spnStatus" runat="server"><%# DataBinder.Eval(Container.DataItem, "ProspectStatusImage")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Primary Contact" SortExpression="ContactName">
                            <HeaderTemplate>
                                        <asp:LinkButton ID="lnkContactNameColumn" runat="server" Text="Primary Contact" OnClientClick="return LoadProspectTableonSort('ContactName');">Primary Contact</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                <div id="divNamePhoneEmail" runat="server" style="display:block;visibility:visible">
                                    <span id="spnName" runat="server"><%# DataBinder.Eval(Container.DataItem, "ContactFirstName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "ContactLastName")%></span>
                                    <br />
                                    Ph:<span id="spnPhone" runat="server"><%# DataBinder.Eval(Container.DataItem, "ContactPhone")%></span>
                                    <br />                                     
                                    Email:<span id="spnEmail" runat="server"><%# DataBinder.Eval(Container.DataItem, "ContactEmail")%></span>
                                    <br />
                                    </div>
                                    <span id="spnAddPrimaryContact" runat="server">
                                    <a style="visibility:visible;display:block" href="/App/Franchisor/AddNewContact.aspx?PrimaryContact=True&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                        <%# DataBinder.Eval(Container.DataItem, "LnkAddContact")%>Add Primary Contact
                                    </a></span>
                                     <a  title="Add Call" href="/App/Franchisor/AddCallProspect.aspx?Parent=True&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                        <%# DataBinder.Eval(Container.DataItem, "LnkContactViewAll")%>Add Call
                                    </a> 
                                    &nbsp;|&nbsp;
                                    <a  title="Add Meeting" href="/App/Franchisor/AddMeeting.aspx?Parent=True&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                        <%# DataBinder.Eval(Container.DataItem, "LnkContactAddMeeting")%>Add Meeting
                                    </a> 
                                    <br />
                                    <a  title="Add Quick Task" href="#" title="Add Quick Task" onclick='return AddTask(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,<%# DataBinder.Eval(Container.DataItem, "AssignedStatus")%>);'>
                                    Add Quick Task</a>
                                                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Call Activity" >
                                <ItemTemplate>                                  
                                    Call: 
                                    <%# DataBinder.Eval(Container.DataItem, "ContactCallStatus")%>
                                    <br />
                                    Date:
                                    <%# DataBinder.Eval(Container.DataItem, "ContactCallDate")%>
                                    <br />
                                    <a href="javascript:void(0);" class="tt" runat="server" id="ahrefToolTipIsPaid"><b>Notes</b> 
                                        <span class="tooltip">
                                            <span class="top"></span>
                                            <span class="middle" id="spndefcursor<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>" onmouseover="changetodefault('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>');" onmouseout="changetopointer('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>');">                                            
                                           <%# DataBinder.Eval(Container.DataItem, "NotesToolTip")%>
                                            </span>
                                            <span class="bottom"></span>
                                        </span>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
								<HeaderTemplate>Activity Summary </HeaderTemplate>
                                <ItemTemplate>
                                <span id="spnSummary" runat="server">
                                    Call:<a title="View Calls"  href="javascript:RedirectCall(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,<%# DataBinder.Eval(Container.DataItem, "NoOFCalls")%>);">
                                    <%# DataBinder.Eval(Container.DataItem, "NoOFCalls")%>
                                    </a>
                                    <br />
                                    Meeting: <a title="View Meetings" href="javascript:RedirectMeeting(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,<%# DataBinder.Eval(Container.DataItem, "NoOFMeeting")%>);">
                                    <%# DataBinder.Eval(Container.DataItem, "NoOFMeeting")%>
                                    </a>
                                    <br />
                                    Contacts:
                                    <a title="View Contacts" href="javascript:RedirectContact(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,<%# DataBinder.Eval(Container.DataItem, "NoOfContacts")%>);">
                                    <%# DataBinder.Eval(Container.DataItem, "NoOfContacts")%>
                                    </a>
                                    <span id="spnAssigned" runat="server" style="display:none"><%# DataBinder.Eval(Container.DataItem, "AssignedStatus")%></span>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owned By">
                             <ItemTemplate>
                                     <span id="spSalesPerson" runat="server">
                                    Owned By:<br /><span class="btextblu"><%# DataBinder.Eval(Container.DataItem, "SalesPersonFirstName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "SalesPersonLastName")%></span>
                                    </span>
                                    <span id="spFranchisee" runat="server" style="display:none">
                                     Franchisee:<br /><span class="btextblu"><%# DataBinder.Eval(Container.DataItem, "FranchiseeName")%></span>
                                    </span>
                             </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                  <div style="float:left;">
                                  <span class="lnktxtbot_urm" style="float:right; font-size:12px;">
                                    <a href="javascript:void(0);" id='aAction<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>' onmouseover='ShowActionList(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,this);' onmouseout='HideActionList(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>,event);'>                                    
                                    <b>ACTION </b> </a><img src="/App/Images/downarrowsmall.gif" />
                                  </span>
                                   <div id='divActionList<%# DataBinder.Eval(Container.DataItem, "ProspectID")%>' style="display: none;" class="spaction_cdpage" onmouseout="this.style.display = 'none';" onmouseover="this.style.display = 'block';">
                                        <div id="innerCustomerLinks" onmouseout="HideActionLinksITSELF(this, event);" onmouseover="this.parentNode.style.display = 'block';" class="spactioninner_cdpage">
                                            <span id="_spnViewDetails" runat="server" class="spactionelement_cdpage">
                                                <a href="<%=strProspectDetailsPage%>&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">View Details</a>
                                            </span>
                                            <span id="Span7" runat="server" class="spactionelement_cdpage">
                                                <a href="/App/Common/AddNewProspect.aspx?Parent=Prospect&ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                                    Edit Prospect
                                                </a>
                                            </span>
                                            <span id="spnConvertToHost" runat="server" class="spactionelement_cdpage">                                                
                                               <a href="/App/Common/AddNewHost.aspx?HostID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>&Action=ConvertToHost">
                                               Convert To Host</a>
                                            </span>
                                            <span id="spLnkRegBtn" runat="server" class="spactionelement_cdpage">
                                                <a href="/App/Franchisor/AddNewContact.aspx?ProspectID=<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>">
                                                <%# DataBinder.Eval(Container.DataItem, "LnkAddContact")%>Add Contact</a>
                                            </span>
                                            <span id="Span9" runat="server" class="spactionelement_cdpage">
                                                <a href="#" onclick="RelatedProspect(<%# DataBinder.Eval(Container.DataItem, "ProspectZip")%>,<%# DataBinder.Eval(Container.DataItem, "AssignedStatus")%>);">
                                                Related Prospects
                                                </a>
                                            </span>
                                            <span id="Span10" runat="server" class="spactionelement_cdpage">
                                                <a id="aMapToLoc" href="http://maps.google.com/maps?f=q&hl=en&geocode=&q=<%# DataBinder.Eval(Container.DataItem, "ProspectAddress1")%>,<%# DataBinder.Eval(Container.DataItem, "ProspectCity")%>,<%# DataBinder.Eval(Container.DataItem, "ProspectState")%>,<%# DataBinder.Eval(Container.DataItem, "ProspectZip")%>&ie=UTF8&z=16"
                                                 target="_blank">[Map To Location]</a>           
                                            </span>
                                            <span id="Span11" runat="server" class="spactionelement_cdpage">
                                                <a href="#" onclick="DeleteProspect(<%# DataBinder.Eval(Container.DataItem, "ProspectId")%>);">
                                                    Delete Prospect
                                                </a>
                                            </span>
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

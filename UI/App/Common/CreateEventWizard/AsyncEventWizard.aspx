<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncEventWizard.aspx.cs" 
Inherits="Falcon.App.UI.App.Common.CreateEventWizard.AsyncEventWizard" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="divPOD" runat="server">
            <asp:DropDownList ID="ddlPOD" runat="server" CssClass="inputf_def" Width="250px">
            </asp:DropDownList>
        </div>
        <div id="divPODDetails" runat="server">
            <div style="float: left; width: 600px; padding: 2px;">
                <asp:GridView ID="gvPOD" GridLines="None" runat="server" CssClass="grid" DataKeyNames="PodID"
                    ShowHeader="false" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="divaddpod_sne" id="Div2">
                                    <p class="middivrownopad_sne">
                                        <span class="boldtxt_sne">
                                            <%# DataBinder.Eval(Container.DataItem, "PodName")%>
                                        </span><span class="removelnkright_sne">
                                            <asp:LinkButton runat="server" ID="lnkRemovePod" Text="Remove" 
                                                OnClientClick="return CheckPodDelete();" ></asp:LinkButton>
                                        </span>
                                    </p>
                                    <p class="middivrownopad_sne">
                                        <span class="titletxtgraynowidth_sne">
                                            <%# DataBinder.Eval(Container.DataItem, "VanName")%>(<%# DataBinder.Eval(Container.DataItem, "Make")%>)
                                            -
                                            <%# DataBinder.Eval(Container.DataItem, "RegistrationNumber")%>
                                        </span>
                                    </p>
                                    <p class="middivrownopad_sne">
                                        <span class="boldtxt_sne">Team Members</span>&nbsp;&nbsp; <span><a href="<%# DataBinder.Eval(Container.DataItem, "AddMemberURL")%>"
                                            rel="gb_page_center[290, 285]">[ Add Member ]</a></span>
                                    </p>
                                    <div class="middivrownopad_sne">
                                        <%# DataBinder.Eval(Container.DataItem, "TeamDescription")%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" />
                    <RowStyle BackColor="White" />
                </asp:GridView>
            </div>
        </div>
        <div id="divAdvocate" runat="server">
            <div class="main_area_bdrnone">
                <div class="maindivpagemainrow_anp">
                    <div class="pagemainrow_anp" id="divSearchResults" runat="server" style="display:none;">
                        <span class="blkheadtxt_regcust" id="Span1" runat="server" style="float: left;">Total:</span>
                        <span class="blueheadtxt_regcust" id="Span2" runat="server" style="float: left;">0 Results
                            Found</span>
                         <div style="float: right; padding: 0px 12px 0px 0px;">
                            <a href="javascript:void(0);" id="lnkAddNewAdvocate" runat="server" onclick="showAddAdvocatePopup();">+ Add New Advocate </a>
                         </div>   
                    </div>
                    <div style="float: left; width: 710px; display:none;" id="divSearchGrd" runat="server">
                        <asp:GridView runat="server" ID="gdAdvocates" AutoGenerateColumns="False" CssClass="divgrid_cl"
                            GridLines="None" AllowPaging="True" PageSize="5" PagerSettings-Visible="false"
                            onrowdatabound="gdAdvocates_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAllAdovcate" runat="server" onclick="SelectAllAdvocate(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBxAdovcate" runat="server" />
                                        <span style="display:none;"><%# DataBinder.Eval(Container.DataItem, "AffiliateID")%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Organization Name">
                                    <ItemTemplate>
                                        <a href="#"><%# DataBinder.Eval(Container.DataItem, "CompanyName")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Person">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                        <br />
                                        <%# DataBinder.Eval(Container.DataItem, "PhoneHome")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Address")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Type" DataField="Type" />
                                <asp:BoundField HeaderText="Distance" DataField="Distance" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <a href="javascript:void(0);" onclick="alert('Pending functionality.');">Edit</a>&nbsp; | &nbsp; 
                                        <a href="javascript:void(0);" onclick='addSingleAdvocate(<%# DataBinder.Eval(Container.DataItem, "AffiliateID")%>);'>Add</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                            <RowStyle CssClass="row2" />
                            <HeaderStyle CssClass="row1" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                        <div runat="server" id="tblGridPagingAdvocate" style="float: left; width: 750px;">
                        </div>
                    </div>
                    <div class="pagemainrow_anp" style="margin-top: 5px; display:none;" id="divAddBtn" runat="server">
                        <asp:ImageButton ID="ibtnAddselected" runat="server" ImageUrl="~/App/Images/addselected-btn.gif" OnClientClick="return addMultipleAdvocate();" />
                    </div>
                    <div id="divNoRecords" runat="server" style="float: left; width: 714px; display: block; padding: 10px 10px 10px 20px;
                        border: solid 1px #DFEEF5;">
                        <div class="divnoitemfound1_custdbrd">
                            <p class="divnoitemtxt_custdbrd">
                                <span class="orngbold18_default">No Advocate Record Found</span>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="main_area_bdrnone" style="margin-top: 0px; display:none;" id="divAddedHeading" runat="server">
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                <div style="float: left">
                    <div id="Div1" class="pgnosymbolvsmall_common" runat="server">
                        <img src="/App/Images/page2symbolvsmall.gif" />
                    </div>
                    <div id="div2" runat="server" class="orngheadtxt16_common">
                        Selected Advocates
                    </div>
                </div>
            </div>
            <div class="maindivpagemainrow_anp" id="divAddedGrd" runat="server" style="display:none">
                <div style="float: left; width: 710px">
                    <asp:GridView runat="server" ID="gdAddedAdvocate" AutoGenerateColumns="False" CssClass="divgrid_cl"
                        GridLines="None" AllowPaging="True" PageSize="5" PagerSettings-Visible="false"  onrowdatabound="gdAddedAdvocate_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAllAddedAdovcate" runat="server" onclick="SelectAllAddedAdvocate(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkBxAddedAdovcate" runat="server" />
                                    <span style="display:none;"><%# DataBinder.Eval(Container.DataItem, "AffiliateID")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Organization Name">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "CompanyName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Person">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                    <br />
                                    <%# DataBinder.Eval(Container.DataItem, "PhoneHome")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Address")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Type" DataField="Type" />
                            <asp:BoundField HeaderText="Distance" DataField="Distance" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="alert('Pending functionality.');">Edit</a>&nbsp; | &nbsp; 
                                    <a href="javascript:void(0);" onclick='removeSingle(<%# DataBinder.Eval(Container.DataItem, "AffiliateID")%>);'>Remove</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                    <div runat="server" id="tblGridPagingAddedAdvocate" style="float: left; width: 750px;">
                    </div>
                </div>
                <div class="pagemainrow_anp" style="margin-top: 5px">
                    <asp:ImageButton ID="ibtnRemoveSelected" runat="server" ImageUrl="~/App/Images/removeselected-btn.gif" OnClientClick=" return removeMultiple();" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

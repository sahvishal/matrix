<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_Admin_ManageEmailTemplate" ValidateRequest="false"
    CodeBehind="ManageEmailTemplate.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Import Namespace="Falcon.App.Core.Extensions" %>
<%@ Import Namespace="Falcon.App.Core.Communication.Enum" %>
<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">



        function ResetSearch() {
            var txtEmailSubject = document.getElementById('<%= this.txtEmailSubject.ClientID %>');
            txtEmailSubject.value = ''
            __doPostBack('__Page', 'Reset');
            return false;
        }

        function SearchValidate() {
            var txtEmailSubject = document.getElementById('<%= this.txtEmailSubject.ClientID %>');

            if (txtEmailSubject.value == '') {
                alert("Please provide email subject to search ");
                txtEmailSubject.focus();
                return false;
            }
            else {
                return true;
            }
        }

        $(document).ready(function () {
            $("input[name$='rbtLstTemplateType']").change(function () {

                if ($(this).val() == '412') {
                    $("input[id$='rbtLstCoverLetterType_2']").attr('checked', 'checked');
                    $('#pCoverLetterType').show();
                }
                else
                    $('#pCoverLetterType').hide();
            });

            if ($("input[name$='rbtLstTemplateType'][value='412']").is(':checked'))
                $('#pCoverLetterType').show();
            else {
                $("input[id$='rbtLstCoverLetterType_2']").attr('checked', 'checked');
                $('#pCoverLetterType').hide();
            }
        });
        
    </script>
    <asp:Panel runat="server" DefaultButton="ibtnSearch" ID="panel2">
        <div class="mainbody_outer">
            <div class="mainbody_inner">
                <div class="main_area_bdrnone">
                    <div class="headingbox_top_body">
                        <p>
                            <img src="/App/Images/specer.gif" width="750px" height="5px" />
                        </p>
                        <span class="orngheadtxt_heading" id="sptitle" runat="server">Email / SMS Templates</span>
                    </div>
                    <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false"
                        runat="server">
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="2px" />
                    </p>
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="2px" />
                    </p>
                    <p class="graylinefull_common" id="P1" onclick="return P1_onclick()">
                        <img src="/App/Images/specer.gif" width="1px" height="1px" />
                    </p>
                </div>
                <div class="main_area_bdrnone">
                    <p>
                        <img src="/App/Images/specer.gif" width="720px" height="5px" />
                    </p>
                    <div class="grayboxtop_cl">
                        <p class="grayboxtopbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" alt="" />
                        </p>
                        <p class="grayboxheader_cl">
                            Filter / Search Email Template <span style="float: right;margin-right: 15px;display: none;"><a href="/Communication/EmailTemplate/Create">Create New Template</a></span>
                        </p>
                        <div class="lgtgraybox_cl" id="divStartCallSearch" runat="server">
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titletextsmallbld_default" style="width: 120px;">Email Subject:</span>
                                <span class="titletextnowidth_default">
                                    <asp:TextBox ID="txtEmailSubject" runat="server" CssClass="inputf_def" Width="150px"></asp:TextBox>
                                </span>
                            </p>
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titletextsmallbld_default" style="width: 120px;">Template Type:</span>
                                <span>
                                    <asp:RadioButtonList ID="rbtLstTemplateType" runat="server"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Text="Email" Value="174"></asp:ListItem>
                                        <asp:ListItem Text="SMS" Value="175"></asp:ListItem>
                                        <asp:ListItem Text="Cover Letter" Value="412"></asp:ListItem>
                                        <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </span>
                            </p>
                            <p class="lgtgrayboxrow_cl" id="pCoverLetterType" style="padding-top: 10px; display:none">
                                <span class="titletextsmallbld_default" style="width: 120px;">Cover Letter Type:</span>
                                <span>
                                    <asp:RadioButtonList ID="rbtLstCoverLetterType" runat="server"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Text="Member Cover Letter" Value="410"></asp:ListItem>
                                        <asp:ListItem Text="PCP Cover Letter" Value="411"></asp:ListItem>
                                        <asp:ListItem Text="All" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </span>
                            </p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700" height="6" alt="" />
                            </p>
                        </div>
                        <div class="lgtgraybox_cl">
                            <span class="buttoncon_default">
                                <%--  <asp:ImageButton ToolTip="Search Services" ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                    OnClick="ibtnSearch_Click" OnClientClick="return SearchValidate();" /></span>--%>
                                <asp:ImageButton ToolTip="Search Services" ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                    OnClick="ibtnSearch_Click" /></span>
                            <span class="buttoncon_default">
                                <asp:ImageButton ToolTip="Reset to default" ID="ibtnReset" runat="server" ImageUrl="~/App/Images/reset-btn.gif"
                                    OnClientClick="return ResetSearch();" /></span>
                        </div>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="720px" height="5px" />
                    </p>
                    <asp:UpdatePanel runat="server" ID="btnGrid">
                        <ContentTemplate>
                            <p class="main_row_custdbrd">
                                <span class="orngbold14_default" style="float: left; padding-top: 8px;"><span id="spnRecords"
                                    runat="server"></span></span><span class="rightlnktxt_cl" style="padding-top: 3px">
                                        <asp:DropDownList ID="ddlRecords" runat="server" Width="50px" CssClass="inputf_def"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlRecords_SelectedIndexChanged">
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="40">40</asp:ListItem>
                                            <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
                                        </asp:DropDownList>
                                    </span><span class="rightlnktxt_cl" style="padding-top: 5px">Records Per Page :&nbsp;</span>
                            </p>
                            <p>
                                <img src="/App/Images/specer.gif" width="720px" height="5px" />
                            </p>
                            <p class="blueboxtopbg_cl">
                                <img src="/App/Images/specer.gif" width="746" height="5" />
                            </p>
                            <div style="float: left; width: 746px;">
                                <asp:GridView ID="grdManageEmailTemplate" runat="server" CssClass="divgrid_clnew"
                                    GridLines="None" AutoGenerateColumns="false" AllowSorting="true" DataKeyNames="EmailTemplateID"
                                    AllowPaging="True" OnSorting="grdManageEmailTemplate_Sorting" OnPageIndexChanging="grdManageEmailTemplate_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                            <ItemTemplate>
                                                <a href="#">
                                                    <%# DataBinder.Eval(Container.DataItem, "EmailTemplateID")%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email Subject" SortExpression="EmailSubject">
                                            <ItemTemplate>
                                                <span>
                                                    <%# DataBinder.Eval(Container.DataItem, "EmailSubject")%></span>
                                                <%--<asp:LinkButton ID="lnkServiceName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailSubject")%>'
                                                    OnCommand="Command_Button_Click" CommandName="EditService" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmailTemplateID")%>'></asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type" SortExpression="TemplateType">
                                            <ItemTemplate>
                                                <span>
                                                    <%# DataBinder.Eval(Container.DataItem, "TemplateType")%>
                                                </span>
                                                <%--<asp:LinkButton ID="lnkServiceName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmailSubject")%>'
                                                    OnCommand="Command_Button_Click" CommandName="EditService" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmailTemplateID")%>'></asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <span><a href="/Communication/EmailTemplate/ViewTemplate?emailTemplateAlias=<%# DataBinder.Eval(Container.DataItem, "EmailTitle")%>&emailSubject=<%# DataBinder.Eval(Container.DataItem, "EmailSubject")%>">View</span>&nbsp;&nbsp;<span><a href="/Communication/EmailTemplate/Edit?id=<%# DataBinder.Eval(Container.DataItem, "EmailTemplateId")%>">
                                                        Edit</span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="row1" />
                                    <RowStyle CssClass="row2" />
                                    <AlternatingRowStyle CssClass="row3" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:HiddenField ID="hfNotificationTypeID" runat="server" Value="" />
                </div>
                <p class="blueboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" />
                </p>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

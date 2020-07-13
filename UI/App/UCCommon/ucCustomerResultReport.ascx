<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_ucCustomerResultReport"
    CodeBehind="ucCustomerResultReport.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" />
<div class="mainbody_outer">
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_top_body">
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                <span class="orngheadtxt_heading" runat="server" id="sptitle">Missing Results Report</span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="2px" /></p>
            <p class="graylinefull_common">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <div class="main_area_bdrnone">
                <div class="divmainbody_cd">
                    <div runat="server" id="divsearchpanel" class="grayboxtop_cl">
                        <p class="grayboxtopbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                        <p class="grayboxheader_cl">
                            Search Event</p>
                        <div class="maindivredmsgbox" id="errordiv" runat="server" style="display: none;
                            width: 736px">
                        </div>
                        <div class="lgtgraybox_cl">
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="lgtgrayboxrow_cl">
                                <span class="titletextnowidth_default" style="width: 100px;">Event:</span> <span
                                    class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtEvent" runat="server" CssClass="inputf_def auto-search-event" Width="480px"></asp:TextBox></span>
                                <br />
                            </p>
                            <p>
                                <span style="float: left; font-size: 8pt; color: #666; width: 485px; padding-left: 120px;">
                                    <i>e.g. [Event Id] or Type some characters from the event name and select from the auto
                                        complete list.</i></span>
                            </p>
                            <cc1:TextBoxWatermarkExtender runat="server" ID="ccTxtEvent" TargetControlID="txtEvent"
                                WatermarkCssClass="watermark_mecss" WatermarkText="Future Events are not allowed."
                                BehaviorID="wtxtEvent">
                            </cc1:TextBoxWatermarkExtender>
                            <p class="lgtgrayboxrow_cl">
                                <span class="titletextnowidth_default" style="width: 100px;">Held Between:</span>
                                <span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtDateFrom" runat="server" CssClass="inputf_def" Width="120px"></asp:TextBox>
                                    <asp:ImageButton ID="ibtnfromdate" runat="server" CssClass="" ImageUrl="~/App/Images/calendar-icon.gif" />
                                    &nbsp; - &nbsp;</span> <span class="inputfldnowidth_default">
                                        <asp:TextBox ID="txtDateTo" runat="server" CssClass="inputf_def" Width="120px"></asp:TextBox>
                                        <asp:ImageButton ID="ibtntodate" runat="server" CssClass="" ImageUrl="~/App/Images/calendar-icon.gif" />
                                    </span>
                                <cc1:CalendarExtender ID="caleventfrom" runat="server" Format="MM/dd/yyyy" PopupButtonID="ibtnfromdate"
                                    TargetControlID="txtDateFrom">
                                </cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="caleventto" runat="server" Format="MM/dd/yyyy" PopupButtonID="ibtntodate"
                                    TargetControlID="txtDateTo">
                                </cc1:CalendarExtender>
                            </p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                        </div>
                        <div class="lgtgraybox_cl">
                            <span class="buttoncon_default">
                                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                    OnClick="ibtnSearch_Click" /></span> <span class="buttoncon_default">
                                        <asp:ImageButton ID="ibtnReset" runat="server" OnClick="ibtnReset_Click" ImageUrl="~/App/Images/reset-btn.gif" /></span>
                        </div>
                        <p class="grayboxbotbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="4" /></p>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="740px" height="10px" /></p>
                    <div style="float: left;">
                        <p class="divmainbody_cd">
                            <span class="orngbold16_default" style="float: left">List Customers: </span>
                        </p>
                        <div class="divmainbody_cd">
                            <div style="float: left; padding-top: 3px;">
                                <asp:RadioButton runat="server" ID="chkNoResults" GroupName="MissingReport" Text="No Results"
                                    AutoPostBack="True" Checked="true" OnCheckedChanged="chkNoResults_CheckedChanged" />
                                <asp:RadioButton runat="server" ID="chkParResults" GroupName="MissingReport" Text="Partial Results"
                                    AutoPostBack="True" OnCheckedChanged="chkParResults_CheckedChanged" />
                                <asp:RadioButton runat="server" ID="chkNoImages" GroupName="MissingReport" Text="No Images"
                                    AutoPostBack="True" OnCheckedChanged="chkNoImages_CheckedChanged" />
                            </div>
                            <div class="rightlnktxt_cl">
                                <asp:DropDownList ID="ddlRecords" AutoPostBack="true" CssClass="inputf_def" Width="50px"
                                    runat="server" OnSelectedIndexChanged="ddlRecords_SelectedIndexChanged">
                                    <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    <asp:ListItem Value="40">40</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="rightlnktxt_cl" style="padding-top: 3px">
                                Show :&nbsp;</div>
                        </div>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <p class="graylinefull_default">
                        <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                    <p>
                        <img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
                </div>
            </div>
            <div>
                <img src="/App/Images/specer.gif" width="740px" height="10px" /></div>
            <div id="divResults" runat="server" style="display: block;" class="main_area_bdrnone">
                <div class="lgtgraybox_cl">
                    <p class="blueboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746px" height="6px" /></p>
                    <div style="float: left; width: 746px">
                        <asp:GridView ID="grdResults" runat="server" CssClass="gridjobp" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true" AllowPaging="true" PageSize="10" EnableSortingAndPagingCallbacks="False">
                            <Columns>
                                <asp:BoundField DataField="CustomerID" HeaderText="ID" />
                                <asp:TemplateField HeaderText="Customer">
                                    <ItemTemplate>
                                        <a href='<%# DataBinder.Eval(Container.DataItem, "CustomerURL") %>'>
                                            <%# DataBinder.Eval(Container.DataItem, "CustomerName") %>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event">
                                    <ItemTemplate>
                                        <a href='<%# DataBinder.Eval(Container.DataItem, "EventURL") %>'>
                                            <%# DataBinder.Eval(Container.DataItem, "EventName") %>
                                        </a>(<%# DataBinder.Eval(Container.DataItem, "EventID") %>)
                                        <br />
                                        Held On:
                                        <%# DataBinder.Eval(Container.DataItem, "EventDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="RegisteredOn" HeaderText="Registered On" />
                            </Columns>
                            <HeaderStyle CssClass="row1a" />
                            <RowStyle CssClass="row2a" />
                            <AlternatingRowStyle CssClass="row3a" />
                        </asp:GridView>
                    </div>
                    <div runat="server" id="tblPostAuditPaging" style="float: left; width: 746px;">
                    </div>
                    <p class="blueboxbotbg_cl">
                        <img src="/App/Images/specer.gif" alt="" width="746px" height="6px" /></p>
                </div>
            </div>
            <div>
                <img src="/App/Images/specer.gif" width="740px" height="10px" /></div>
        </div>
    </div>
</div>

<script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
    
        $('.auto-search-event').autoComplete({
            minchar: 3,
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetAllHeldEventsByPrefixText")%>',
		    type: "POST",
		    data: "prefixText"
        });
    });
    
    </script>

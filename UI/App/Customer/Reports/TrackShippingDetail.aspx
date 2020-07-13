<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" CodeBehind="TrackShippingDetail.aspx.cs" Inherits="Falcon.App.UI.UtilityReports.TrackShippingDetail"
    Title="Track Shipping Detail" EnableEventValidation="false" %>

<%@ Register Src="~/App/UCCommon/ListPager.ascx" TagName="Pager" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="Message" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagPrefix="ToolKit" TagName="JQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ToolKit:JQuery ID="JQuryToolkit" runat="server" IncludeJQueryUI="true" />
    <script language="javascript" type="text/javascript">

        function ShowPdf(url) {
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,resizable=yes,width=800,height=600,titlebar=0";
            confirmWin = window.open(url, 'Result Report', winOpts);
        }

        $(function () {
            $('.clear-button').click(function () {
                $('.dropdown-list').val(0);
                $('.text-box').val('');
                $('.boxrow input[type=checkbox], .boxrow input[type=radio]').removeAttr("checked");
                $('#<%= RequestedAllInputRadio.ClientID %>').attr("checked", "checked");
                $('#<%= GetButton.ClientID %>').click();
            });

            $(".boxrow input, .boxrow select").keypress(function (evt) {
                var keyCode = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));

                if (keyCode == 0) return;

                if (keyCode == 13) {
                    $('#<%= GetButton.ClientID %>').click();
                }
            });

            $(document).keypress(function (evt) {
                var keyCode = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));

                if (keyCode == 0) return;
                if (keyCode == 13) {
                    return false;
                }
            })
        });

        function BulkUpdate() {
            if ($(".list-options").filter('.disabled').length > 0) {
                return false;
            }
            return true;
        }
    
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            if ($(".select-table tbody :checkbox").filter(':checked').length < 1) {
                $(".list-options").addClass("disabled");
            }
            else
                $(".list-options").removeClass("disabled");

            $(".select-table tbody tr :checkbox").click(function () {
                if ($(this).is(':checked')) {
                    $(this).attr("checked", true);
                    $(".list-options").removeClass("disabled");
                } else {
                    $(this).attr("checked", false);
                    $(".check-all :checkbox").attr("checked", false);
                    if ($(".select-table tbody :checkbox").filter(':checked').length < 1) {
                        $(".list-options").addClass("disabled");
                    }
                }
            });

            $(".check-all :checkbox").click(function () {
                if ($(this).is(':checked')) {
                    $(".select-table tbody :checkbox").attr("checked", true);
                    $(".list-options").removeClass("disabled");
                } else {
                    $(".select-table tbody :checkbox").attr("checked", false);
                    $(".list-options").addClass("disabled");
                }
            });

            var currentDate = new Date();
            currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1);
            $(".date-picker-from").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2000 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2000, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $(".date-picker-to").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2000 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2000, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $(".date-picker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2000 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2000, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $('.auto-search-event').numeric();
        });
    </script>
    <div class="wrapper_ecl">
        <h1>
            Track Shipping Detail</h1>
        <uc:Message ID="MessageBox" runat="server" />
        <div class="chklistdiv">
            <div class="boxrow">
                <label class="fstlbl">
                    Shipment Status:&nbsp;</label>
                <asp:DropDownList ID="ShipmentStatusDropDown" runat="server" AppendDataBoundItems="true"
                    Height="22px" CssClass="mrgnrgt dropdown-list" Width="90px" EnableViewState="true" />
            </div>
            <div class="boxrow">
                <label>
                    Shipping Option:&nbsp;&nbsp;</label>
                <asp:CheckBoxList ID="ShippingOptionCheckboxList" EnableViewState="true" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" runat="server">
                </asp:CheckBoxList>
            </div>
            <div class="boxrow">
                <label class="fstlbl">
                    Event Id:&nbsp;</label>
                <asp:TextBox ID="EventId" runat="server" Width="80px" CssClass="mrgnrgt text-box auto-search-event" />
                <label>
                    Event Date Range:&nbsp;</label>
                <asp:TextBox ID="EventDateFrom" runat="server" Width="80px" CssClass="text-box date-picker-from" />
                -To-
                <asp:TextBox ID="EventDateTo" runat="server" Width="80px" CssClass="mrgnrgt text-box date-picker-to" />
                <label>
                    Pod List:&nbsp;</label>
                <asp:DropDownList ID="PodsDropDown" runat="server" AppendDataBoundItems="true" CssClass="dropdown-list" />
                <asp:CheckBox ID="ResultsReadyCheckBox" runat="server" Text="Results Ready" />
            </div>
            <div class="boxrow">
                <div style="float: left; width: 25%;">
                    <label class="fstlbl">
                        Has Email:&nbsp;&nbsp;&nbsp;</label>
                    <asp:DropDownList ID="HasEmailDropDown" runat="server">
                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="float: left; width: 40%;">
                    Requested Exclusively:&nbsp;&nbsp;&nbsp;<input type="radio" id="RequestedExclInputRadio"
                        name="requestedExcl" runat="server" enableviewstate="true" />&nbsp;Yes&nbsp;&nbsp;<input
                            id="RequestedNotExclInputRadio" type="radio" name="requestedExcl" runat="server"
                            enableviewstate="true" />&nbsp;No&nbsp;&nbsp;<input id="RequestedAllInputRadio" type="radio"
                                name="requestedExcl" checked="true" runat="server" enableviewstate="true" />All
                </div>
                <div style="float: left; width: 35%; text-align: right;">
                    <input type="button" id="ClearButton" value="Clear" class="button clear-button" />
                    <asp:Button ID="GetButton" Text="Filter" runat="server" OnClick="GetButton_Click"
                        CssClass="button" />
                </div>
                <div style="margin-top: 10px;">
                    <span style="float: left; color: White; background-color: Red; margin-right: 5px;
                        border: 2px solid; border-radius: 14px; width: 15px; text-align: center;" title="Unpaid Patient">
                        <b>U</b> </span><span style="float: left;">- Unpaid Customer</span>
                </div>
            </div>
        </div>
        <div class="divgrd_tsd">
            <uc:Pager ID="ShippingDetailPagerTop" runat="server" OnPageIndexChanged="ShippingDetailPager_PageIndexChanged" />
            <asp:GridView ID="ShippingDetailsGrid" runat="server" GridLines="none" OnRowCommand="ShippingDetailsGrid_RowCommand"
                OnRowDataBound="ShippingDetailsGrid_RowDataBound" AutoGenerateColumns="false"
                CssClass="grd_tsd select-table">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <div>
                                <asp:CheckBox ID="chkSelectAll" runat="server" /></div>
                        </HeaderTemplate>
                        <HeaderStyle CssClass="check-all" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Literal ID="NameItemLiteral" runat="server" />
                            <div style="float: left; color: White; background-color: Red; margin-right: 5px;
                                border: 2px solid; border-radius: 14px; width: 15px; text-align: center;" title="Unpaid Customer"
                                id="UnpiadDiv" runat="server">
                                <b>U</b>
                            </div>
                            <asp:Literal ID="ShippingDetailIdLiteral" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ShippingDetailId") %>'
                                Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Event">
                        <ItemTemplate>
                            <a href="javascript:void(0);" title="<%# DataBinder.Eval(Container.DataItem,"EventName") %>">
                                <asp:Literal ID="EventIdItemLiteral" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"EventId")%>' />
                            </a>
                            <br />
                            <strong>On: </strong>
                            <asp:Literal ID="EventDateItemLiteral" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"EventDate")).ToString("MM/dd/yyyy")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Package/Test">
                        <ItemTemplate>
                            <asp:Literal ID="PackageNameItemLiteral" runat="server" />
                            <%--    <br /><asp:Literal ID="AdditionalTestLiteral" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "AdditionalTest"))!=string.Empty? "<b>Add. Test: </b>" + DataBinder.Eval(Container.DataItem,"AdditionalTest"):"" %>' />
                            --%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipping Option">
                        <ItemTemplate>
                            <asp:Literal ID="ShippingOptionItemLiteral" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ShippingOptionName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Requested On" DataField="ShippingRequestedOn" ItemStyle-Width="80px"
                        DataFormatString="{0:dd MMM, yyyy}" />
                    <asp:BoundField HeaderText="Requested Exclusively" DataField="IsExclusivelyRequested" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:DropDownList ID="ShipmentStatusDropDown" runat="server" AppendDataBoundItems="true"
                                Height="22px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Results">
                        <ItemTemplate>
                            <a id="ResultPdfAnchor" runat="server">View Results</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:Button ID="UpdateButton" CssClass="button" runat="server" CommandName="UpdateShippingStatus"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ShippingDetailId") %>'
                                Text="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="row2" />
                <AlternatingRowStyle CssClass="row3" />
                <HeaderStyle CssClass="row1" />
            </asp:GridView>
        </div>
        <div class="left" style="padding-left: 100px; margin-top: 20px">
            <div class="divnoitemfound_custdbrd" id="dvNoQueueItemFound" runat="server">
                <p class="divnoitemtxt_custdbrd">
                    <span class="orngbold18_default">No Record Found!</span>
                </p>
            </div>
        </div>
        <div class="chklistdiv list-options">
            <label class="fstlbl">
                Change Shipment Status:&nbsp;</label>
            <asp:DropDownList ID="ShipmentStatusUpdateDropDown" runat="server" AppendDataBoundItems="true"
                Height="22px" CssClass="mrgnrgt dropdown-list" Width="90px" />
            <asp:Button ID="UpdateButton" Text="Update" runat="server" OnClick="UpdateButton_Click"
                OnClientClick="return BulkUpdate()" CssClass="button" />
        </div>
    </div>
</asp:Content>

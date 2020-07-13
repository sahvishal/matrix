<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcCallCenterMetricsDetail.ascx.cs" Inherits="Falcon.App.UI.App.UCCommon.UcCallCenterMetricsDetail" %>
<%@ Register Src="~/App/UCCommon/ListPager.ascx" TagName="Pager" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc1" %>
<uc1:_jQueryToolKit ID="ucJquery" runat="server" IncludeJQueryUI="true" IncludeJQueryMaskInput="true" />
<script type="text/javascript" language="javascript">

    function Validations() {
        if ($(".ccrep-ddl").val() == "0") {
            alert('Please select a CCRep from the drop down.');
            return false;
        }

        startDate = $('.startdate-dp').val();
        endDate = $('.enddate-dp').val();
        if (!IsValidDate(startDate)) {
            alert('Please enter a valid start date.');
            $('.startdate-dp').focus();
            return false;
        }
        else if (!IsValidDate(endDate)) {
            alert('Please enter a valid end date.');
            $('.enddate-dp').focus();
            return false;
        }
    }


    $(document).ready(function () {
        var currentDate = new Date();

        $(".date-picker").datepicker({
            changeMonth: true,
            changeYear: true,
            defaultDate: currentDate,
            minDate: new Date("01/01/2011")
        });
    });

</script>

<div class="wrapper_inpg">
    <h1>
        <%# PageHeader %>
    </h1>
    <div class="fltrdv">
        <div class="boxrow">
            <label>
                Rep:</label>
            <asp:DropDownList ID="CallCenterRepDropDown" runat="server" CssClass="mrgnrgt ccrep-ddl"
                Width="150px">
            </asp:DropDownList>
            <label>
                Show:</label>
            <asp:DropDownList ID="DisplayTypeList" runat="server" CssClass="mrgnrgt ccrep-ddl"
                Width="150px">
            </asp:DropDownList>
            <label>
                From:</label>
            <asp:TextBox ID="DateFromTextBox" runat="server" Width="80px" class="startdate-dp date-picker"
                MaxLength="12" />&nbsp;-To-&nbsp;
            <asp:TextBox ID="DateToTextBox" runat="server" Width="80px" CssClass="mrgnrgt enddate-dp date-picker"
                MaxLength="12" />
            <asp:Button ID="SearchRecordButton" Text="Filter" OnClientClick="return Validations();"
                OnClick="SearchRecordButton_Click" CssClass="button" runat="server" />
        </div>
        <div class="dtlsrow_mtrcs">
            <div class="dtls_mtrcs">
                <label>
                    Total Customers:</label><span id="TotalCustomerSpan" runat="server">120</span>
            </div>
            <div class="dtls_mtrcs">
                <label>
                    Cancelled:</label><span id="TotalCancelledSpan" runat="server">120</span>
            </div>
            <div class="dtls_mtrcs">
                <label>
                    No Shows:</label><span id="TotalNoShowSpan" runat="server">120</span>
            </div>
            <div class="dtls_mtrcs">
                <label>
                    Attended:</label><span id="TotalAttendedSpan" runat="server">120</span>
            </div>
            <div class="dtls_mtrcs">
                <label id="SalesLabel" runat="server">
                    Total Sales</label><span id="TotalAmountSpan" runat="server">120</span>
            </div>
            <div class="dtls_mtrcs">
                <label id="AverageSalesLabel" runat="server">
                    Average Sales</label><span id="AverageAmountSpan" runat="server">120</span>
            </div>
        </div>
    </div>
    <div class="divgrd_mtrcs">
        <uc:Pager ID="MetricsDetailPagerTop" runat="server" OnPageIndexChanged="MetricsDetailPagerTop_PageIndexChanged" />
        <asp:GridView ID="MetricsDetailsGridView" runat="server" GridLines="none" AutoGenerateColumns="false"
            CssClass="grd_tsd">
            <Columns>
                <asp:TemplateField HeaderText="Event Sign Up Date">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EventSignUp")).ToString("MM/dd/yyyy")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Customer").ToString()%>
                        (<%# DataBinder.Eval(Container.DataItem, "CustomerId") %>)<br />
                        <asp:Literal ID="AddressLiteral" runat="server" Visible="false" Text="Address: "/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Event">
                    <ItemTemplate>
                        ID:<%# DataBinder.Eval(Container.DataItem, "EventId") %><br />
                        Date:
                        <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EventDate")).ToString("MM/dd/yyyy")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Package">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Package") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Payment">
                    <ItemTemplate>
                        $<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Amount")).ToString("0.00") %><br />
                        Paid On:
                        <%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsPrePaid")) == false ? "N/A" : Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PaymentDate")).ToString("MM/dd/yyyy")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Is PrePaid">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "IsPrePaid") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "AttendedState")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="row2" />
            <AlternatingRowStyle CssClass="row3" />
            <HeaderStyle CssClass="row1" />
        </asp:GridView>
    </div>
</div>

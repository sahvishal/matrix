<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    CodeBehind="HSCReport.aspx.cs" Inherits="Falcon.App.UI.App.Franchisee.SalesRep.HSCReport"
    Title="Workshop Prospect Status Report" %>
<%@ Register Src="~/App/UCCommon/ListPager.ascx" TagName="Pager" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagPrefix="ToolKit" TagName="JQuery" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="Message" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ToolKit:JQuery ID="JQuryToolkit" runat="server" IncludeJQueryUI="true" IncudeJQueryJTip="true" />
    <script type="text/javascript">
    function ValidateFilter()
    {
        var ProspectCustomerDateFrom = document.getElementById("<%=this._startDate.ClientID %>");
        var ProspectCustomerDateTo = document.getElementById("<%=this._endDate.ClientID %>");
        
        if (ProspectCustomerDateFrom.value != "")
        {
            if (!ValidateDate(ProspectCustomerDateFrom.value, 'Prospect customer "from date".'))
            {
                return false;
            }
        }
        if (ProspectCustomerDateTo.value != "")
        {
            if (!ValidateDate(ProspectCustomerDateTo.value, 'Prospect customer "to date".'))
            {
                return false;
            }
        }
        if ( (ProspectCustomerDateFrom.value != "") && (ProspectCustomerDateTo.value != ""))
        {
            if(!CompareTwoDates1(ProspectCustomerDateFrom.value, ProspectCustomerDateTo.value))
            {
                alert('Prospect customer "to date" should be greater or equals to "from date".');
                return false;
            }
        }
        
        if(isNaN(document.getElementById("<%=this._eventIdText.ClientID %>").value))
        {
            alert('EventId inserted should be numeric.');
            return false;
        }
        return true;    
    }
</script>
    <div class="wrapper_inpg">
    <h1>Workshop Prospect Status Report</h1>
    <uc:Message ID="MessageBox" runat="server" />
        <div class="chklistdiv" style="width: 737px">
            <div class="boxrow">
                <label>
                    Prospect Name:</label>
                <asp:TextBox ID="_prospectName" runat="server" Width="110px" CssClass="mrgnrgt"
                    MaxLength="100" />
                <label>
                    Date Inserted:</label>
                <asp:TextBox ID="_startDate" runat="server" Width="100px" CssClass="date-picker-from"
                    MaxLength="12" />&nbsp;-To-&nbsp;<asp:TextBox ID="_endDate" runat="server"
                        Width="100px" CssClass="mrgnrgt date-picker-to" MaxLength="12" />
                <label>
                    Status:</label>
                <asp:DropDownList ID="_prospectStatus" runat="server" AppendDataBoundItems="true"
                    Height="22px" EnableViewState="true" Width="116px">                    
                </asp:DropDownList>
            </div>
             <div class="boxrow" style="margin-top:5px">
               <div class="left">
				<label class="left" style="width:92px">
                    Event ID:</label>
                <asp:TextBox ID="_eventIdText" runat="server" Width="110px" CssClass="mrgnrgt"
                    MaxLength="255" />
					<label>
                    Source Code:</label>
				&nbsp;<asp:TextBox ID="_sourceCodeText" runat="server" Width="100px" MaxLength="255" CssClass="mrgnrgt" />
                    <label>
                    Workshop:</label>
                <asp:TextBox ID="_seminarNameText" runat="server" Width="110px"
                    MaxLength="255" />
				
				</div>
				<div class="rgt">
                    <asp:Button ID="resetSearch" Text="Clear" CssClass="button clear-button" 
                    runat="server" onclick="resetSearch_Click" Width="50px" />
                <asp:Button ID="searchRecord" Text="Filter" CssClass="button" runat="server" 
                    onclick="searchRecord_Click" OnClientClick="return ValidateFilter();" Width="50px" />
				</div>
             </div>
        </div>
        <div class="prowtopad">
            <uc:Pager ID="_pagerTop" runat="server" OnPageIndexChanged="pagerTop_PageIndexChanged" />
            <asp:GridView runat="server" ID="_hscReport" AutoGenerateColumns="False" GridLines="None"
                AllowPaging="false" Width="750px" CssClass="divgrid_cl select-table" OnRowDataBound="hscReport_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <span>
                                <%#DataBinder.Eval(Container.DataItem,"FirstName")%>&nbsp;<%#DataBinder.Eval(Container.DataItem,"LastName")%></span>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
					<HeaderTemplate>Workshop / <br />Sourcecode</HeaderTemplate>
                        <ItemTemplate>
                            <span>
                                <%#DataBinder.Eval(Container.DataItem,"WellnessSeminar")%></span>
                            <br />
                            <span>
                                <%#DataBinder.Eval(Container.DataItem, "SourceCode")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Event Details">
                        <ItemTemplate>
                           <label class="grayb"> Event Id:</label>&nbsp;<a href="#" id="_eventDetailsAnchor" runat="server"><%# DataBinder.Eval(Container.DataItem,"EventId")%></a>
                            <br />
                           <label class="grayb"> Event Date:</label>&nbsp;<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EventDate")).ToString("MM-dd-yyyy")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inserted On">
                        <ItemTemplate>
                            <span>
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"DateCreated")).ToString("MM-dd-yyyy @ hh:mm:ss tt")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Current Status">
                        <ItemTemplate>
                            <span id="_prospectStatus" runat="server"></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
						<HeaderTemplate>Call Log / Count</HeaderTemplate>
                        <ItemTemplate>
                            <a href='#' class="jtip" id="_callDetails" runat="server">Call Details</a> <span id="_callCount" runat="server" class="ccountico"></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="smalltxt11" />
                <HeaderStyle CssClass="row1" Font-Size="11px" />
                <AlternatingRowStyle CssClass="smalltxt12" />
            </asp:GridView>
        </div>
        <div class="left" style="display: none" id="dvNoQueueItemFound"
            runat="server">
            <div class="divnoitemfound_custdbrd">
                <p class="divnoitemtxt_custdbrd">
                    <span class="orngbold18_default">No Record Found!</span>
                </p>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 300 });
            var currentDate = new Date();
             $(".date-picker-from").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $(".date-picker-to").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });
        });
    </script>

</asp:Content>

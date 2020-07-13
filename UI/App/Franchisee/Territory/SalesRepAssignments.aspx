<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesRepAssignments.aspx.cs"
    Title="Manage Sales Rep Territory Assignments" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    Inherits="Falcon.App.UI.App.Franchisee.Territory.SalesRepAssignments" %>

<%@ Register Src="../../UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJTemplate="true"
        IncludeJQueryUI="true" />
    <div class="wrapper_inpg">
        <h1>
            <%= Page.Title %></h1>
        <div class="hr left">
        </div>
        <div id="FranchiseeSalesRepsDiv" style="width: 750px">
        </div>
    </div>
    <div id="ConfirmUnassignmentDialogDiv" title="Confirm Unassignment" style="display: none">
        <p>
            <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>
            Are you sure you want to unassign this sales rep from this territory?</p>
    </div>
    <div id="ConfirmPodUnassignmentDialogDiv" title="Confirm Pod Unassignment" style="display: none">
        <p>
            <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>
            Are you sure you want to unassign this pod from this sales rep?</p>
    </div>

    <script type="text/javascript">
        $(function()
        {
            LoadFranchiseeSalesReps();
        });

        function LoadFranchiseeSalesReps()
        {
            var franchiseeSalesRepsDiv = $('#FranchiseeSalesRepsDiv');
            franchiseeSalesRepsDiv.addClass('loading');
            var messageUrl = '/App/Controllers/FranchiseeUserController.asmx/GetSalesRepresentativesForFranchisee';
            var parameter = "{'franchiseeId':'<%= FranchiseeId %>'}";
            var successFunction = function(returnData)
            {
                franchiseeSalesRepsDiv.setTemplateURL('/App/Templates/SalesRepTerritories.html');
                franchiseeSalesRepsDiv.setParam('franchiseeId', '<%= FranchiseeId %>');
                franchiseeSalesRepsDiv.processTemplate(returnData.d);

                // TODO: Move to CSS
                $('#SalesRepTerritoriesTable th').css('background-color', '#DDF0F7');
                $('#SalesRepTerritoriesTable tr:even').css('background-color', '#EFF8FD');
                $('#SalesRepTerritoriesTable tr:odd').css('background-color', '#F8FCFF');
                $('#SalesRepTerritoriesTable a').addClass('SmallLinks');
            }
            var numberOfRecordsFunction = function(returnData) { return returnData.d.length; }
            var noRecordsFunction = function() { alert('No sales reps found.'); }
            var completeFunction = function() { franchiseeSalesRepsDiv.removeClass('loading'); }
            var errorFunction = function() { alert('The list of your sales reps could not be loaded due to an internal server error.'); }
            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction);
        }
    </script>

</asp:Content>
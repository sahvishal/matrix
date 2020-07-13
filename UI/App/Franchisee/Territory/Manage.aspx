<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Title="Manage Territories"
MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="Falcon.App.UI.App.Franchisee.Territory.Manage" %>
<%@ Register src="../../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQueryControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true" IncludeJTemplate="true" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <h1>Manage Territories</h1>
            <div id="FranchiseeTerritoryListDiv"></div>
        </div>
    </div>
    <script type="text/javascript">
        $(function()
        {
            LoadFranchiseeTerritories();
        })

        function LoadFranchiseeTerritories()
        {
            var franchiseeTerritoryListDiv = $('#FranchiseeTerritoryListDiv');
            franchiseeTerritoryListDiv.addClass('loading');
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/GetFranchiseeTerritoryViewData")%>';
            var parameter = "{'franchiseeId':'<%= FranchiseeId %>'}";
            var successFunction = function(returnData)
            {
                franchiseeTerritoryListDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/Territory.html") %>');
                franchiseeTerritoryListDiv.setParam('PageType', 'Franchisee');
                franchiseeTerritoryListDiv.processTemplate(returnData.d);

                // TODO: Move to CSS
                $('#TerritoryTable th').css('background-color', '#DDF0F7');
                $('#TerritoryTable tr:even').css('background-color', '#EFF8FD');
                $('#TerritoryTable tr:odd').css('background-color', '#F8FCFF');
            }
            var numberOfRecordsFunction = function(returnData) { return returnData.d.length; }
            var noRecordsFunction = function() { alert('No territories found.'); }
            var completeFunction = function() { franchiseeTerritoryListDiv.removeClass('loading'); }
            var errorFunction = function() { alert('Your territories could not be loaded due to an internal server error.'); }
            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction);
        }
    </script>
</asp:Content>
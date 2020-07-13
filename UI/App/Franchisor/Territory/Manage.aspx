<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Title="Manage Territories"
MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="Falcon.App.UI.App.Franchisor.Territory.Manage" %>
<%@ Import Namespace="Falcon.App.Core.Enum"%>
<%@ Register src="../../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQueryControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true" IncludeJTemplate="true" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <h1>
                Manage Territories
                <a href="Edit.aspx" style="float: right; padding-right: 5px">Add Territory</a>
            </h1>
            <div id="FranchisorTerritoryListDiv"></div>
        </div>
    </div>
    <script type="text/javascript">
        $(function()
        {
            LoadFranchisorTerritories();
        })

        function LoadFranchisorTerritories()
        {
            var franchisorTerritoryListDiv = $('#FranchisorTerritoryListDiv');
            franchisorTerritoryListDiv.addClass('loading');
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/GetAllParentTerritoryViewData")%>';
            var parameter = '{}';
            var successFunction = function(returnData)
            {
                franchisorTerritoryListDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/Territory.html") %>');
                franchisorTerritoryListDiv.setParam('PageType', 'Franchisor');
                franchisorTerritoryListDiv.processTemplate(returnData.d);

                // TODO: Move to CSS
                $('#TerritoryTable th').css('background-color', '#DDF0F7');
                $('#TerritoryTable tr:even').css('background-color', '#EFF8FD');
                $('#TerritoryTable tr:odd').css('background-color', '#F8FCFF');
            }
            var numberOfRecordsFunction = function(returnData) { return returnData.d.length; }
            var noRecordsFunction = function() { alert('No territories found.'); }
            var completeFunction = function() { franchisorTerritoryListDiv.removeClass('loading'); }
            var errorFunction = function () { alert('Territories could not be loaded due to an internal server error.'); }
            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction,false);
        }
    </script>
</asp:Content>
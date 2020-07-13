<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    Inherits="Falcon.App.UI.App.Franchisee.Territory.Edit" Title="Add Subterritory" %>
<%@ Register src="../../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQueryControl" %>
<%@ Register src="../../UCCommon/Message.ascx" tagname="Messages" tagprefix="MessageControl" %>
<%@ Import Namespace="Falcon.App.Core.Enum"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true" IncludeSexyComboBox="true" />

<div style="padding: 10px; width:750px">
    <h1 style="float: left"><%= Page.Title %> for <asp:Literal runat="server" id="ParentTerritoryNameLiteral" /></h1>
    <div style="text-align: right"><a href="Manage.aspx">Manage Territories</a></div>
    <MessageControl:Messages ID="MessageControl1" runat="server" />
    <div>
        <label for="<%= TerritoryNameTextBox.ClientID %>">Territory Name:</label><br />
        <asp:TextBox ID="TerritoryNameTextBox" runat="server" Width="200px" />
    </div>
    <div>
        <label for="<%= TerritoryDescriptionTextBox.ClientID %>">Territory Description:</label><br />
        <asp:TextBox ID="TerritoryDescriptionTextBox" runat="server" TextMode="MultiLine" Rows="5" Columns="40" />
    </div>
    <div>
        <label for="TerritoryTypeDDL">Territory Type:</label><br />
        <asp:DropDownList ID="TerritoryTypeDDL" runat="server" />
        <asp:Label ID="WhyTypeDDLIsDisabledLabel" runat="server" Visible="false" CssClass="MiniWarningMessage">
            Once a territory has been created, its type cannot be altered.
        </asp:Label>
    </div>
    <div id="AvailableZipCodesDiv">
        <h2><label for="<%= TerritoryZipCodesTextBox.ClientID %>">Available Zip Codes</label></h2>
        <asp:TextBox ID="AvailableZipCodesTextBox" runat="server" TextMode="MultiLine" Rows="10" Columns="80" />
    </div>
    <div id="ZipCodesToAddDiv">
        <h2><label for="<%= TerritoryZipCodesTextBox.ClientID %>">Zip Codes for Territory</label></h2>
        <p style="width: 600px">Select from the above list of available zip codes. They can be separated by
        whitespace, new lines, or commas. Any duplicate zip codes entered will be removed.</p>
        <asp:TextBox ID="TerritoryZipCodesTextBox" runat="server" TextMode="MultiLine" Rows="10" Columns="80" />
    </div>
    <div id="SubmitDiv" style="margin-top: 10px">
        <asp:Button id="SubmitButton" runat="server" CssClass="ui-state-default ui-corner-all"
            CommandName="SuccessAction" CommandArgument="RefreshPage" OnClick="SubmitButtonClick" Text="Save Territory &amp; Continue" />
        <asp:Button ID="SaveAndCloseButton" runat="server" CssClass="ui-state-default ui-corner-all"
            CommandName="SuccessAction" CommandArgument="ClosePage" OnClick="SubmitButtonClick" Text="Save Territory &amp; Exit" />
        <a id="CancelLink" href="Manage.aspx">Cancel</a>
    </div>
</div>
<script type="text/javascript">
    var submitButtonIdentifier = '#<%= SubmitButton.ClientID %>';
    var saveAndCloseButtonIdentifier = '#<%= SaveAndCloseButton.ClientID %>';
    var territoryTypeDDLIdentifier = '#<%= TerritoryTypeDDL.ClientID %>';
    var zipCodeTextBoxIdentifier = '#<%= TerritoryZipCodesTextBox.ClientID %>';
    var zipCodeRBLIdentifier = "input[name='ZipCodeEntryOptionRadioButton']";
    var stateId = 0;

    $(function()
    {
        $(territoryTypeDDLIdentifier).change(ChangeTerritoryTypeOwner);
        $('#<%= AvailableZipCodesTextBox.ClientID %>').attr('readonly', 'readonly');
        ChangeTerritoryTypeOwner();
        $(submitButtonIdentifier).click(DisableSubmitButton);
        $(saveAndCloseButtonIdentifier).click(DisableSubmitButton);
    });

    function DisableSubmitButton()
    {
        $(submitButtonIdentifier).hide();
        $(saveAndCloseButtonIdentifier).hide();
        $('#CancelLink').hide();
        $('#SubmitDiv').addClass('loading').append('<h3>Saving territory...</h3>');
    }

    function AppendZipsToTextBox(returnData)
    {
        var zipCodesToAppend = '';
        if ($(zipCodeTextBoxIdentifier).val().length != 0)
        {
            zipCodesToAppend += '\r';
        }
        $.each(returnData.d, function(d, zipCode)
        {
            zipCodesToAppend += zipCode.Zip + ', ';
        });
        zipCodesToAppend = zipCodesToAppend.substring(0, zipCodesToAppend.length - 2);
        $(zipCodeTextBoxIdentifier).val($(zipCodeTextBoxIdentifier).val() + zipCodesToAppend);
    }

    function ChangeTerritoryTypeOwner()
    {
        var selected = $(territoryTypeDDLIdentifier + ' option:selected');
        $('#SalesRepOwnersDiv').hide();
        if (selected.val() == <%= (byte)TerritoryType.SalesRep %>)
        {
            $('#SalesRepOwnersDiv').fadeIn('fast');
        }
    }
</script>
</asp:Content>
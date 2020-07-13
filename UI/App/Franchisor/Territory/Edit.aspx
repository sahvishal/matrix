<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    Inherits="Falcon.App.UI.App.Franchisor.Territory.Edit" Title="Add Territory" %>
<%@ Register src="../../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQueryControl" %>
<%@ Register src="../../UCCommon/Message.ascx" tagname="Messages" tagprefix="MessageControl" %>
<%@ Import Namespace="Falcon.App.Core.Enum"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true" IncludeSexyComboBox="true" />

<div class="wrapper_inpg">
     <h1 class="left"><%= Page.Title %></h1>
    <div class="headingright_default"><a href="Manage.aspx">Manage Territories</a></div>
     <div class="hr left"></div>
    <MessageControl:Messages ID="MessageControl1" runat="server" />
    <div class="prowtopad">
        <b><label for="<%= TerritoryNameTextBox.ClientID %>">Territory Name:</label></b><br />
        <asp:TextBox ID="TerritoryNameTextBox" runat="server" Width="200px" />
    </div>
    <div class="prowtopad">
        <b><label for="<%= TerritoryDescriptionTextBox.ClientID %>">Territory Description:</label></b><br />
        <asp:TextBox ID="TerritoryDescriptionTextBox" runat="server" TextMode="MultiLine" Rows="5" Columns="40" />
    </div>
    <div class="prowtopad">
        <b><label for="TerritoryTypeDDL">Territory Type:</label></b><br />
        <asp:DropDownList ID="TerritoryTypeDDL" runat="server" /><br />
        <asp:Label ID="WhyTypeDDLIsDisabledLabel" runat="server" Visible="false" CssClass="MiniWarningMessage">
            Once a territory has been created, its type cannot be altered.
        </asp:Label>
    </div>
    <div id="OwnerDiv" class="prowtopad">
        <div id="FranchiseeOwnerDiv" style="display: none">
            <b><label for="<%= TerritoryFranchiseeOwnerDDL.ClientID %>">Owning Franchisee:</label></b><br />
            <asp:DropDownList ID="TerritoryFranchiseeOwnerDDL" runat="server" />
        </div>
        <div id="HospitalPartnerOwnersDiv" style="display: none">
            Owning Hospital Partners:<br />
            <asp:CheckBoxList id="TerritoryHospitalPartnerOwnersCBL" runat="server" />
        </div>
        <div id="PodPackageDiv" style="display: none">
            Associate Packages:<br />
            <asp:CheckBoxList ID="TerritoryPackageCBL" runat="server" />
        </div>
        <div>
            <asp:Label ID="WhyOwnerSelectionIsDisabledLabel" runat="server" Visible="false" CssClass="MiniWarningMessage">
                Once a territory has been created, its owner(s) cannot be altered.
            </asp:Label>
        </div>
    </div>
    <div class="prowtopad">
        Zip Code Auto-Entry Options:
        <div>
            <input type="radio" name="ZipCodeEntryOptionRadioButton" value="ByState" />
            <label for="ZipCodeEntryOptionRadioButton02">Add Zip Codes from Given State</label>&nbsp;&nbsp;
            <input type="radio" name="ZipCodeEntryOptionRadioButton" value="ByRadius" />
            <label for="ZipCodeEntryOptionRadioButton03">Add Zip Codes By Radius</label>
        </div>
    </div>
    <div id="ZipCodeEntryDiv" class="prowtopad">
        <div id="ZipStateDiv" style="display: none">
            <label for="<%= StateDDL.ClientID %>">Enter State:</label>
            <asp:DropDownList ID="StateDDL" runat="server" Width="200px" />
            <input type="button" id="AddZipsByStateButton" class="ui-state-default ui-corner-all" style="margin: 10px 0 10px 0"
                onclick="AddZipCodesFromState()" value="Add Zip Codes" />
        </div>
        <div id="ZipRadiusDiv" style="display: none">
            <label for="RadiusMilesTextBox">All zip codes within </label>
            <input type="text" id="RangeInMilesTextBox" maxlength="3" style="width: 30px" />
            miles of zip
            <input type="text" id="OriginatingZipCodeTextBox" maxlength="5" style="width: 40px" />
            <input type="button" id="AddZipsByRadiusButton" class="ui-state-default ui-corner-all"
                onclick="AddZipCodesByRadius()" value="Add Zip Codes" />
        </div>
    </div>
    <div id="ZipCodeEntryLoadingDiv" class="loading" style="display:none"><h3>Adding zip codes...</h3></div>
    <div id="ZipCodesToAddDiv" class="prowtopad" style="margin-top: 10px">
        <h2><label for="<%= TerritoryZipCodesTextBox.ClientID %>">Zip Codes for Territory</label></h2>
       Zip codes can be entered manually or through one of the auto-entry options listed above. They can be separated by
        whitespace, new lines, or commas. Any duplicate zip codes entered will be removed.
        <asp:TextBox ID="TerritoryZipCodesTextBox" runat="server" TextMode="MultiLine" Rows="10" Columns="80" Width="720px" />
    </div>
    <div id="SubmitDiv" style="margin-top: 10px" class="prowtopad">
      <div class="wrapbtn">
       <a id="CancelLink" href="Manage.aspx">Cancel</a>
       <asp:Button ID="SaveAndCloseButton" runat="server" CssClass="ui-state-default ui-corner-all"
            CommandName="SuccessAction" CommandArgument="ClosePage" OnClick="SubmitButtonClick" Text="Save Territory &amp; Exit" />
       <asp:Button id="SubmitButton" runat="server" CssClass="ui-state-default ui-corner-all"
            CommandName="SuccessAction" CommandArgument="RefreshPage" OnClick="SubmitButtonClick" Text="Save Territory &amp; Continue" />
      </div>
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
        ChangeTerritoryTypeOwner();
        $(zipCodeRBLIdentifier).click(ChangeZipCodeEntryOptions);
        $(submitButtonIdentifier).click(DisableSubmitButtons);
        $(saveAndCloseButtonIdentifier).click(DisableSubmitButtons);
        $('#<%= StateDDL.ClientID %>').sexyCombo(
        {
            emptyText: 'Choose a state...',
            changeCallback: function()
            {
                var hiddenValue = this.getHiddenValue();
                if (hiddenValue == parseInt(hiddenValue))
                {
                    stateId = hiddenValue;
                }
            }
        });
        var comboBoxWidth = 200;
        $('#ZipStateDiv')
            .find('input[type=text]').css('width', comboBoxWidth).end()
            .find('.icon').css('left', comboBoxWidth).end()
            .find('.list-wrapper').css('width', comboBoxWidth-2).end();
    });

    function DisableSubmitButtons()
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

    function ChangeZipCodeEntryOptions()
    {
        $('#ZipStateDiv').hide();
        $('#ZipRadiusDiv').hide();
        var selected = $(zipCodeRBLIdentifier + ':checked').val();
        if (selected == 'ByState')
        {
            $('#ZipStateDiv').fadeIn('fast');
        }
        else if (selected == 'ByRadius')
        {
            $('#ZipRadiusDiv').fadeIn('fast');
        }
    }

    function ChangeTerritoryTypeOwner()
    {//debugger;
        var selected = $(territoryTypeDDLIdentifier + ' option:selected');
        $('#FranchiseeOwnerDiv').hide();
        $('#HospitalPartnerOwnersDiv').hide();
        $('#PodPackageDiv').hide();

        if(selected.val() == <%= (byte)TerritoryType.Franchisee %>)
        {
            $('#FranchiseeOwnerDiv').fadeIn('fast');
        }
        else if (selected.val() == <%= (byte)TerritoryType.HospitalPartner %>)
        {
            $('#HospitalPartnerOwnersDiv').fadeIn('fast');
        }
        else if(selected.val()==<%=(byte)TerritoryType.Pod %>)
        {
            $('#<%=WhyOwnerSelectionIsDisabledLabel.ClientID %>').hide();
            $('#PodPackageDiv').fadeIn('fast');
        }
    }

    function AddZipCodesFromState()
    {
        var messageUrl = '<%=ResolveUrl("./Edit.aspx/GetZipCodesByState")%>';
        var parameter = "{'stateId':'" + stateId + "'}";
        var errorMessage = 'An internal server error occurred when attempting to retrieve the zip codes for the given state.';
        AddZipCodes(messageUrl, parameter, errorMessage);
    }

    function AddZipCodesByRadius()
    {
        var rangeInMiles = $('#RangeInMilesTextBox').val();
        var originatingZipCode = $('#OriginatingZipCodeTextBox').val();
        if (rangeInMiles != parseInt(rangeInMiles) || rangeInMiles < 1 || rangeInMiles > 999)
        {
            alert('Please enter a valid mile range (1-999, whole numbers only).');
            $('#RangeInMilesTextBox').focus();
            return;
        }        
        //if (originatingZipCode != parseInt(originatingZipCode) || originatingZipCode.length != 5)        
        if (isNaN(originatingZipCode) || originatingZipCode.length != 5)
        {
            alert('Please enter a valid zip code.');
            $('#OriginatingZipCodeTextBox').focus();
            return;
        }
        var messageUrl = '<%=ResolveUrl("./Edit.aspx/GetZipCodesInRange") %>';
        var parameter = "{'originatingZipCode':'" + originatingZipCode + "',"
        parameter += "'rangeInMiles':'" + rangeInMiles + "'}";
        var errorMessage = 'An internal server error occurred when attempting to retrieve the zip codes for the given state.';
        AddZipCodes(messageUrl, parameter, errorMessage);
    }

    function AddZipCodes(messageUrl, parameter, errorMessage)
    {
        $('#ZipCodeEntryDiv').hide();
        $('#ZipCodeEntryLoadingDiv').show();
        var successFunction = function(returnData)
        {
            AppendZipsToTextBox(returnData);
        }
        var numberOfRecordsFunction = function(returnData)
        {
            return returnData.d.length;
        }
        var noRecordsFunction = function()
        {
            alert('No records found');
        }
        var finallyFunction = function()
        {
            $('#ZipCodeEntryDiv').fadeIn('fast');
            $('#ZipCodeEntryLoadingDiv').hide();
        }
        var errorFunction = function()
        {
            alert(errorMessage);
        }
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, finallyFunction, numberOfRecordsFunction, noRecordsFunction);
    }
</script>
</asp:Content>
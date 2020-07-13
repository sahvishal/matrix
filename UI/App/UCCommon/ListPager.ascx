<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPager.ascx.cs" Inherits="Falcon.App.UI.Controls.ListPager" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="uc" %>
<%-- TODO: 
	 The first two may be mutually exclusive.
	 -	Make result sizes configuable per instance of the control
	 -	Cookie chosen result size.
	 -	Hide pager when results are less then the smallest result size. 
--%>
<uc:JQueryToolkit ID="JQueryToolkit" runat="server" IncludeJQueryUI="true" />
<asp:Panel ID="PagerPanel" runat="server" DefaultButton="GoToPageButton">
    <div class="hide" style="display: none">
        <asp:Button ID="GoToPageButton" runat="server" CausesValidation="false" OnClick="GoToPageButton_Click" />
    </div>
    <div class="paging">
        <div class="rgt">
            <asp:LinkButton ID="PreviousPage" runat="server" Text="Previous" CssClass="previous"
                OnClick="PreviousPage_Click" CausesValidation="false" />
            <div class="page-number">
                Page
                <asp:TextBox ID="CurrentPage" runat="server" CausesValidation="false" CssClass="page-number-input whole-number"></asp:TextBox>
                of
                <asp:Literal ID="TotalPages" runat="server"></asp:Literal>
            </div>
            <asp:LinkButton ID="NextPage" runat="server" Text="Next" CssClass="next" OnClick="NextPage_Click"
                CausesValidation="false" />
            <div class="results-per-page">
                Results per page
                <asp:DropDownList ID="ResultsPerPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ResultsPerPage_SelectedIndexChanged">
                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                    <asp:ListItem Text="75" Value="75"></asp:ListItem>
                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
</asp:Panel>

<script type="text/javascript" language="javascript">
    $(function() {
        $(".whole-number").numeric();
    });
</script>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pulmonary.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Pulmonary" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<asp:GridView runat="server" Style="float: left;" CssClass="gv-findings-pulmonary finding-section"
    EnableViewState="false" ID="StandardFindingPulmonaryGridView" AutoGenerateColumns="False"
    ShowHeader="False" GridLines="None">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <div class="lrow small">
                    <div class="listchkbox">
                        <input type="radio" name="rbtFindingsPulmonary" class="rbt-finding" /></div>
                    <div class="lfttoppad">
                        <%# DataBinder.Eval(Container.DataItem, "Label")%>
                    </div>
                </div>
                <input type="hidden" id="FindingPulmonaryInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:DataList runat="server" ID="UnableToScreenPulmonaryDataList" EnableViewState="false"
    RepeatLayout="Flow" CssClass="dtl-unabletoscreen-pulmonary unable-to-screen-section"
    GridLines="None" RepeatDirection="Horizontal">
    <ItemTemplate>
        <input type="checkbox" id="chkUnableScreenReason" />
        <b>Unable To Screen</b>
        <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
    </ItemTemplate>
</asp:DataList>
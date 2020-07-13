7<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncChartCampaignCategory.aspx.cs"
    Inherits="Falcon.App.UI.App.MarketingPartner.MarketingBreakUps.AsyncChartCampaignCategory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float: left; width: 400px;">
        <aspchart:Chart ID="chartCategoryCustomer" runat="server" Width="446px" Height="248px"
            BorderColor="181, 64, 1" Palette="BrightPastel" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
            BorderWidth="2" BackColor="white" ImageLocation="~/TempImages"  ImageStorageMode="UseImageLocation"
            ImageType="Jpeg" >
            <Titles>
                <aspchart:Title Font="arial, 16px, style=Bold" Text="Marketing Break-Up" ForeColor="#EF8200"
                    Alignment="TopLeft">
                </aspchart:Title>
            </Titles>
            <Legends>
                <aspchart:Legend IsTextAutoFit="False" Docking="Right" Name="Default" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"
                    BackColor="Transparent" Font="Trebuchet MS, 8pt, style=Bold" Alignment="Center"
                    IsEquallySpacedItems="True">
                </aspchart:Legend>
            </Legends>
            <BorderSkin SkinStyle="none"></BorderSkin>
            <Series>
                <aspchart:Series ChartArea="chartAreaCategoryCustomer" XValueType="String" Name="Series1"
                    ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" BorderColor="64, 64, 64, 64"
                    Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
                    <Points>
                    </Points>
                </aspchart:Series>
            </Series>
            <ChartAreas>
                <aspchart:ChartArea Name="chartAreaCategoryCustomer" BorderColor="64, 64, 64, 64"
                    BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent"
                    BackGradientStyle="TopBottom">
                    <AxisY2>
                        <MajorGrid Enabled="False" />
                        <MajorTickMark Enabled="False" />
                    </AxisY2>
                    <AxisX2>
                        <MajorGrid Enabled="False" />
                        <MajorTickMark Enabled="False" />
                    </AxisX2>
                    <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25"
                        IsClustered="False" />
                    <AxisY LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                        <MajorTickMark Enabled="False" />
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                        <MajorTickMark Enabled="False" />
                    </AxisX>
                </aspchart:ChartArea>
            </ChartAreas>
        </aspchart:Chart>
    </div>
    <!--Start Category Grid-->
        <asp:GridView runat="server" GridLines="None" ID="grdCategoryCustomer" AutoGenerateColumns="false" 
        
            CssClass="divgrid_cl">
            <Columns>
               <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                    <a id="aCategory" href="javascript:void(0);" onclick='getSummary(<%# DataBinder.Eval(Container.DataItem, "CategoryId")%>);ViewAdvocate(<%# DataBinder.Eval(Container.DataItem, "CategoryId")%>);'><%# DataBinder.Eval(Container.DataItem, "CategoryName")%></a>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="eCPA">
                    <ItemTemplate>
                        $<%# DataBinder.Eval(Container.DataItem, "CostPerCustomer")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Customers" DataField="NoOfCustomers" />
            </Columns>
            <HeaderStyle CssClass="row1" />
            <RowStyle CssClass="row2" />
            <AlternatingRowStyle CssClass="row3" />
        </asp:GridView><!--End Category Grid-->
    </form>
</body>
</html>

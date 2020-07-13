<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncChartCampaignCustomer.aspx.cs" Inherits="Falcon.App.UI.App.MarketingPartner.AdvocateSalesManager.AsyncChartCampaignCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../StyleSheets/MarketingPartner.css" rel="stylesheet" type="text/css" />
    <link href="../../StyleSheets/Commonstyle.css" rel="Stylesheet" type="text/css" />
    <link href="../../StyleSheets/UC.css" rel="stylesheet" type="text/css" />
    <link href="../../StyleSheets/Coupon.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function ViewMM(CampaignID,CampaignName,CampaignStart,CampaignEnd,Commission)
    {
    //var strQueryString='CampaignID='+ CampaignID + '&CampaignName='+ CampaignName +'&Strat='+ CampaignStart +'&End='+ CampaignEnd +'&Commission='+ Commission ;
    var strQueryString='CampaignID='+ CampaignID  ;
    var load = window.open('/App/MarketingPartner/MMPopup.aspx?'+ strQueryString,'','scrollbars=no,menubar=no,height=650,width=904,resizable=no,toolbar=no,left=50,top=10');

    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <div style="float: left; width: 426px;" id="dvChartCampaignCustomer" >
            <!-- Start Campaign Customer Chart -->
                <aspchart:Chart ID="chartCampaignCustomer" runat="server" Width="426px" Height="228px"
                    BorderColor="181, 64, 1" Palette="BrightPastel" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                    BorderWidth="2" BackColor="white"  ImageLocation="~/TempImages"  ImageStorageMode="UseImageLocation"
                    ImageType="Jpeg">
                    <Titles>
                        <aspchart:Title Font="arial, 16px, style=Bold" Text="Marketing Break-Up" ForeColor="#EF8200"
                            Alignment="TopLeft">
                        </aspchart:Title>
                    </Titles>
                    <Legends>
                        <aspchart:Legend IsTextAutoFit="false" Docking="Bottom" LegendStyle="Table" Name="Default" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"
                            BackColor="Transparent" Font="Trebuchet MS, 8pt, style=Bold" Alignment="Center"
                            IsEquallySpacedItems="false">
                        </aspchart:Legend>
                    </Legends>
                    <BorderSkin SkinStyle="none"></BorderSkin>
                    <Series>
                        <aspchart:Series ChartArea="chartAreaCampaignCustomer" XValueType="String" Name="Series1"
                            ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" BorderColor="64, 64, 64, 64"
                            Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
                            <Points>
                            </Points>
                        </aspchart:Series>
                    </Series>
                    <ChartAreas>
                        <aspchart:ChartArea Name="chartAreaCampaignCustomer" BorderColor="64, 64, 64, 64"
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
            <!-- End Campaign Customer Chart -->
            </div>
            <div style="float: left; width:300px; height:310px; background-color: #EFF8FD;" id="dvGrdCampaignCustomer">
            <!--Start Campaign Customer Grid-->
                <asp:GridView runat="server" GridLines="None" ID="grdCampaignCustomer" AutoGenerateColumns="false" 
                
                    CssClass="divgrid_cl">
                    <Columns>
                       <asp:TemplateField HeaderText="Campaign">
                            <ItemTemplate>
                            <a id="aCampaign" href="javascript:void(0);" onclick='ViewCamp(<%# DataBinder.Eval(Container.DataItem, "CampaignId")%>);'><%# DataBinder.Eval(Container.DataItem, "CampaignName")%></a>
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
                </asp:GridView>
                <!--End Campaign Customer Grid-->
                <!-- Start Campaign Customer Paging -->
                <div runat="server" id="tblCampaignCustomerGridPaging" style="background-color: #EFF8FD;float: left; width: 300px;">
                </div>
                <!-- End Campaign Customer Paging -->
                </div>
             
             
             <div style="float: left; width:300px; height:310px; background-color: #EFF8FD;" id="dvGrdAdvocateCustomer">
            <!--Start Advocate Customer Grid-->
                <asp:GridView runat="server" GridLines="None" ID="grdAdvocateCustomer" AutoGenerateColumns="false" 
                
                    CssClass="divgrid_cl">
                    <Columns>
                       <asp:TemplateField HeaderText="Advocate">
                            <ItemTemplate>
                            <a id="aCampaign" href="javascript:void(0);" onclick='ViewCamp(<%# DataBinder.Eval(Container.DataItem, "AffiliateId")%>);'><%# DataBinder.Eval(Container.DataItem, "FullName")%></a>
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
                </asp:GridView>
                <!--End Advocate Customer Grid-->
                <!-- Start Advocate Customer Paging -->
                <div runat="server" id="tblAdvocateCustomerGridPaging" style="background-color: #EFF8FD;float: left; width: 300px;">
                </div>
                <!-- End Advocate Customer Paging -->
                </div>
    </div>
    </form>
</body>
</html>

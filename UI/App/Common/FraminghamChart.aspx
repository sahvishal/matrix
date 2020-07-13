<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FraminghamChart.aspx.cs"
    Inherits="Falcon.App.UI.App.Common.FraminghamChart" %>

<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Framingham Chart</title>
   <link href="../StyleSheets/Commonstyle.css" rel="Stylesheet" type="text/css" />
    <link href="../StyleSheets/UC.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .divframingham
        {
            width: 422px;
            border: solid 1px #666;
            padding: 5px;
            background: #eeebe4;
        }
        .divframingham .header
        {
            width: 100%;
            font: normal 14px arial;
            line-height: 20px;
        }
        .divframingham .bodydiv
        {
            width: 100%;
            font: normal 14px arial;
            margin: 10px 0;
        }
        .divframingham .bodydiv .lftpart
        {
            width: 200px;
            float: left;
        }
        .divframingham .bodydiv .rgtpart
        {
            width: 200px;
            float: left;
        }
        .divframingham .bodydiv .tbl1
        {
            border-collapse: collapse;
            font: normal 14px arial;
            border-left: solid 2px #ccc;
            border-top: solid 2px #ccc;
            border-right: solid 2px #666;
            border-bottom: solid 2px #666;
        }
     
       .divframingham .bodydiv .tbl1 td
        {
            border-collapse: collapse;
            border: solid 1px #666;
            text-align: center;
        }
            .divframingham .bodydiv .tblcalchart
        {
            width:820px;
            border-collapse: collapse;
            font: normal 14px arial;
            border-left: solid 2px #ccc;
            border-top: solid 2px #ccc;
            border-right: solid 2px #666;
            border-bottom: solid 2px #666;
        }
        .divframingham .bodydiv .tblcalchart td
        {
            border-collapse: collapse;
            border: solid 1px #666;
            text-align: center;
        }
          .divframingham .bodydiv .tblcalchart .tdtitle
        {
            width:170px;
            font-weight:bold;
        }
           .divframingham .bodydiv .tblcalchart .tdtxt
        {
            width:80px;
        }
        
        .btmrdiv
        {
            width: 420px;
            overflow-x: auto;
            overflow-y: hidden;
            height:100px;
        }
        .divframingham .bodydiv .tbl1 th
        {
            border-collapse: collapse;
            border: solid 1px #666;
            text-align: center;
        }
        .headfont
        {
            font: bold 20px arial;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc:JQueryToolkit ID="JQueryToolkit" runat="server" />
    <div class="divframingham" style="background:#fff;">
            <h1>
            Framingham Heart Study <span style="font-size: x-small">circulation 1998:97:1837
            
            
            
            </span>
        </h1>
        <div style="width: 420px; padding-bottom: 5px; background: #F37C00; color: #fff;
            height: 20px; line-height: 20px; margin-top: 5px">
            10-YEAR CARDIOVASCULAR RISK FOR MEN(M) AND WOMEN(F)</div>
        <div class="bodydiv">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="50%" align="center" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center">
                                    <asp:GridView runat="server" ID="AgeChartGridView" CssClass="tbl1" CellPadding="1"
                                        CellSpacing="1" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="AgeChartGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120" ItemStyle-Width="120">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="AgeHeaderLiteral" runat="server" Text="AGE" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="RangeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Range") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="MaleScoreHeaderLiteral" runat="server" Text="M" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="MaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="FemaleScoreHeaderLiteral" runat="server" Text="F" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="FemaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FemaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView runat="server" ID="BPGridView" CssClass="tbl1" CellPadding="1" CellSpacing="1"
                                        GridLines="None" AutoGenerateColumns="false" OnRowDataBound="BPGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120" ItemStyle-Width="120">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="BPHeaderLiteral" runat="server" Text="BP" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="RangeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Range") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="MaleScoreHeaderLiteral" runat="server" Text="M" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="MaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="FemaleScoreHeaderLiteral" runat="server" Text="F" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="FemaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FemaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView runat="server" ID="SmokerGridView" CssClass="tbl1" CellPadding="1"
                                        CellSpacing="1" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="SmokerGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120" ItemStyle-Width="120">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="SmokerHeaderLiteral" runat="server" Text="SMOKER" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="RangeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Range") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="MaleScoreHeaderLiteral" runat="server" Text="M" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="MaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="FemaleScoreHeaderLiteral" runat="server" Text="F" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="FemaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FemaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="50%" align="center" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center">
                                    <asp:GridView runat="server" ID="TCholGridView" CssClass="tbl1" CellPadding="1" CellSpacing="1"
                                        GridLines="None" AutoGenerateColumns="false" OnRowDataBound="TCholGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120" ItemStyle-Width="120">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="TCholHeaderLiteral" runat="server" Text="T-CHOL" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="RangeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Range") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="MaleScoreHeaderLiteral" runat="server" Text="M" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="MaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="FemaleScoreHeaderLiteral" runat="server" Text="F" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="FemaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FemaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView runat="server" ID="LDLGridView" CssClass="tbl1" CellPadding="1" CellSpacing="1"
                                        GridLines="None" AutoGenerateColumns="false" OnRowDataBound="LDLGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120" ItemStyle-Width="120">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="LDLHeaderLiteral" runat="server" Text="LDL-CHOL" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="RangeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Range") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="MaleScoreHeaderLiteral" runat="server" Text="M" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="MaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="FemaleScoreHeaderLiteral" runat="server" Text="F" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="FemaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FemaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView runat="server" ID="HDLGridView" CssClass="tbl1" CellPadding="1" CellSpacing="1"
                                        GridLines="None" AutoGenerateColumns="false" OnRowDataBound="HDLGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120" ItemStyle-Width="120">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="HDLHeaderLiteral" runat="server" Text="HDL-CHOL" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="RangeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Range") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="MaleScoreHeaderLiteral" runat="server" Text="M" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="MaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="FemaleScoreHeaderLiteral" runat="server" Text="F" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="FemaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FemaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView runat="server" ID="DiabetesGridView" CssClass="tbl1" CellPadding="1"
                                        CellSpacing="1" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="DiabetesGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="120" ItemStyle-Width="120">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="DiabetesHeaderLiteral" runat="server" Text="DIABETES" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="RangeLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Range") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="MaleScoreHeaderLiteral" runat="server" Text="M" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="MaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40" ItemStyle-Width="40" ItemStyle-BackColor="#ffffff">
                                                <HeaderTemplate>
                                                    <asp:Literal ID="FemaleScoreHeaderLiteral" runat="server" Text="F" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="FemaleScoreLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FemaleScore") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="btmrdiv">
                            <table border="1" cellspacing="1" cellpadding="1" class="tblcalchart score-table">
                                <tr class="main-tr">
                                    <td class="tdtitle">
                                        TOTAL POINTS
                                    </td>
                                    <td class="tdtxt">
                                        < -2
                                    </td>
                                    <td class="tdtxt">
                                        -2
                                    </td>
                                    <td class="tdtxt">
                                        -1
                                    </td>
                                    <td class="tdtxt">
                                        0
                                    </td>
                                    <td class="tdtxt">
                                        1
                                    </td>
                                    <td class="tdtxt">
                                        2
                                    </td>
                                    <td class="tdtxt">
                                        3
                                    </td>
                                    <td class="tdtxt">
                                        4
                                    </td>
                                    <td class="tdtxt">
                                        5
                                    </td>
                                    <td class="tdtxt">
                                        6
                                    </td>
                                    <td class="tdtxt">
                                        7
                                    </td>
                                    <td class="tdtxt">
                                        8
                                    </td>
                                    <td class="tdtxt">
                                        9
                                    </td>
                                    <td class="tdtxt">
                                        10
                                    </td>
                                    <td class="tdtxt">
                                        11
                                    </td>
                                    <td class="tdtxt">
                                        12
                                    </td>
                                    <td class="tdtxt">
                                        13
                                    </td>
                                    <td class="tdtxt">
                                        14
                                    </td>
                                    <td class="tdtxt">
                                        15
                                    </td>
                                    <td class="tdtxt">
                                        16
                                    </td>
                                    <td class="tdtxt">
                                        > 17
                                    </td>
                                </tr>
                                <tr class="male-tr">
                                    <td class="tdtitle">
                                        %Risk (M):
                                    </td>
                                    <td bgcolor="#FFFFFF" class="tdtxt">
                                        &nbsp;1
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;2
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;2
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;3
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;4
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;4
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;5
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;7
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;8
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;10
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;13
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;17
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;21
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;26
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;32
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;38
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;46
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;54
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;54
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;54
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;54
                                    </td>
                                </tr>
                                <tr class="female-tr">
                                    <td width="120" class="tdtitle">
                                        %Risk (F):
                                    </td>
                                    <td bgcolor="#FFFFFF" class="tdtxt">
                                        &nbsp;1
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;1
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;2
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;2
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;2
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;3
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;3
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;4
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;5
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;6
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;7
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;8
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;9
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;11
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;12
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;14
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;16
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;20
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;22
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;25
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        &nbsp;30
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript" language="javascript">
    var isDone = false;
        $(document).ready(function() {
            var isScoreCalculated = '<%=IsScoreCalculated%>';
            if (isScoreCalculated == 'True') {
                var score = '<%=Score%>';
                if (parseInt(score) >= 17) {
                    score = '17 >';
                }
                else if (parseInt(score) < -2) {
                    score = '< -2';
                }
                var isMale = '<%=IsMale%>'
                $('.score-table td').each(function(){
                    if ($.trim($(this).text()) == score && !isDone){
                        $(this).css('background-color', '#ffc600');
                        var cellIndex = this.cellIndex;
                        isDone = true;
                        if (isMale == 'True'){
                            $(this).parents('table .score-table').find('.male-tr td').each(function(){
                                if (this.cellIndex == cellIndex) {
                                    $(this).css('background-color', '#ffc600');
                                }
                            });
                        }
                        else if (isMale != 'True'){
                            $(this).parents('table .score-table').find('.female-tr td').each(function(){
                                if (this.cellIndex == cellIndex){
                                    $(this).css('background-color', '#ffc600');
                                }
                            });
                        }
                    }
                    else if($.trim($(this).text()) != score){
                    }
                });
            }
        });
    </script>

    </form>
</body>
</html>

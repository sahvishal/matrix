<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" CodeBehind="PodPerformanceStatistics.aspx.cs" Inherits="Falcon.App.UI.App.Franchisor.PodPerformanceStatistics" Title="Pod Performance Statistics" %>
<%@ Register Src="../UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" IncludeJQueryThickBox="true" IncudeJQueryJTip="true"
    IncludeJQueryCorner="true" />
<style type="text/css">
.tblsdata{float:left;width:47%;margin-right:5px;padding:5px;height:200px;overflow-y:auto;overflow-x:hidden;border:solid 1px #ccc;}
.listsrch{width:120px;margin-top:3px}
.graybox{float:left;width:725px;background:#f2f2f2;padding:5px;height:25px}
</style>
<div class="wrapper_inpg">
    <h1><%= Page.Title%></h1>
    <div class="hr left"></div>
    <div id="topgreybox" class="graybox">
        <select id="DropDownList1" class="left listsrch">
            <option selected="selected">Weekly</option>
            <option value="Daily">Daily</option>
            <option value="Monthly">Monthly</option>
            <option value="Yearly">Yearly</option>
        </select>
         <input type="button" id="btnFilter" value="Filter" class="left button" />
         </div>
         
         <div class="grdlnk_lftpnl" style="margin-top:5px">
         <div id="arpc" class="tblsdata">
               <h2> ARPC</h2>
             <table id="tablearpc" class="divgrid_cl" cellspacing="0" cellpadding="0" width="100%" style="font-size:xx-small;">
            <tr class="row2">
                <td>POD # 1; Austin, TX ($179.59/customer)</td>
            </tr>
            <tr class="row3">
                <td>POD # 3; Houston 1, TX ($179.01/customer)</td> 
            </tr>
            <tr class="row2">
                <td>POD # 4; Dallas 1, TX ($178.98/customer)</td>
            </tr>
            <tr class="row3">
                <td>POD # 5; Houston 2, TX ($175.08/customer)</td>
            </tr>
            <tr class="row2">
                <td>POD # 6; Fort Worth 2, TX ($174.56/customer)</td>
            </tr>
            <tr class="row2">
                <td>POD # 6; Fort Worth 2, TX ($174.56/customer)</td>
                
            </tr>            
            </table>
         </div>
         <div id="Div1" class="tblsdata">
               <h2>HIPAA</h2>
             <table id="table1" class="divgrid_cl" cellspacing="0" cellpadding="0" width="100%" style="font-size:xx-small;">
            <tr class="row2">
                <td>POD # 1; Austin, TX (92%)</td>
            </tr>
            <tr class="row3">
                <td>POD # 5; Houston 2, TX (90%)</td>                
            </tr>
            <tr class="row2">
                <td>POD # 3; Houston 1, TX (89%)</td>
            </tr>
            <tr class="row3">
                <td>POD # 2; San Antonio, TX (88%)</td>
            </tr>
            <tr class="row2">
                <td>POD # 4; Dallas 1, TX (78%)</td>
            </tr>
            <tr class="row2">
                <td>POD # 6; Fort Worth 2, TX (76%)</td>                
            </tr>            
            </table>
         </div>         
         
         </div>
         <div class="grdlnk_lftpnl" style="margin-top:5px">
         <div id="Div2" class="tblsdata">
               <h2> Upgrades</h2>
             <table id="table2" class="divgrid_cl" cellspacing="0" cellpadding="0" width="100%" style="font-size:xx-small;">
            <tr class="row2">
                <td>POD # 1; Austin, TX ($179.59/customer)</td>
            </tr>
            <tr class="row3">
                <td>POD # 3; Houston 1, TX ($179.01/customer)</td>                
            </tr>
            <tr class="row2">
                <td>POD # 4; Dallas 1, TX ($178.98/customer)</td>
            </tr>
            <tr class="row3">
                <td>POD # 5; Houston 2, TX ($175.08/customer)</td>
            </tr>
            <tr class="row2">
                <td>POD # 6; Fort Worth 2, TX ($174.56/customer)</td>
            </tr>
            <tr class="row2">
                <td>POD # 6; Fort Worth 2, TX ($174.56/customer)</td>
                
            </tr>            
            </table>
         </div>
         <div id="Div3" class="tblsdata">
               <h2>Downgrades</h2>
             <table id="table3" class="divgrid_cl" cellspacing="0" cellpadding="0" width="100%" style="font-size:xx-small;">
            <tr class="row2">
                <td>POD # 2; San Antonio, TX ($890/event)</td>
            </tr>
            <tr class="row3">
                <td>POD # 6; Fort Worth 2, TX ($500.00/event)</td>                
            </tr>
            <tr class="row2">
                <td>POD # 5; Houston 2, TX ($450.00/event)</td>
            </tr>
            <tr class="row3">
                <td>POD # 3; Houston 1, TX ($198.00/event)</td>
            </tr>
            <tr class="row2">
                <td>POD # 1; Austin, TX ($180.00/event)</td>
            </tr>
            <tr class="row2">
                <td>POD # 4; Dallas 1, TX ($178.98/event)</td>                
            </tr>            
            </table>
         </div>         
         
         </div>
</div>
<script type="text/javascript">        
         $(document).ready(function(){
            $('#topgreybox').corner("8px");
            
          });
    </script>
</asp:Content>

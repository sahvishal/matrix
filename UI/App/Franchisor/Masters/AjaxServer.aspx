<%@ Page Language="C#" AutoEventWireup="true" Inherits="Franchisor_Masters_AjaxServer" Codebehind="AjaxServer.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rowbdr" id="divZip" runat="server">
        <div class="largepopup_inrow"><span class="orngbold12_default" id="spZipAvail" runat="server"> Zip Available</span></div>
        <div class="largepopup_inrow" id="divZipDetails" runat="server" style="display:block;">
            <span class="titletextnowidth_default">Latitude:</span>
            <span class="ttxtnowidthnormal_default" style="margin-right:25px;" id="spLatitude" runat="server">29.966345</span>
            <span class="titletextnowidth_default">Longitude:</span>
            <span class="ttxtnowidthnormal_default" style="margin-right:25px;" id="spLongitude" runat="server">-92.129672</span>
            <span class="titletextnowidth_default">Time Zone:</span>
            <span class="ttxtnowidthnormal_default" id="spTimeZone" runat="server">6</span>
        </div>
        <div class="largepopup_inrow" style="overflow-y:scroll; overflow-x:hidden; height:80px; display:block;" id="divCityStateGrd" runat="server">
            <asp:GridView runat="server" ID="grdCityDetails" AutoGenerateColumns="False" CssClass="divgrid_cl"
                GridLines="None">
                <Columns>
                    <asp:BoundField DataField="ZipCode" HeaderText="Zip" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="State" HeaderText="State" />                          
                </Columns>
                <RowStyle CssClass="row2" />
                <HeaderStyle CssClass="row1" />
                <AlternatingRowStyle CssClass="row3" />
            </asp:GridView>                    
        </div>
    </div> 
    </form>
</body>
</html>

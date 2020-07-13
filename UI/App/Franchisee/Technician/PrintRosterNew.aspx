<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Franchisee_Technician_PrintRoasterNew" CodeBehind="PrintRosterNew.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #fff;">
<head runat="server">
    <title>Untitled Page</title>
    <link href="/App/StyleSheets/Technician.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
     <style type="text/css">
        table, tbody {
            -moz-page-break-inside: auto;
            page-break-inside: auto;
            position: relative;
        }

        tr, td {
            position: relative;
            page-break-before: auto;
            -moz-page-break-inside: avoid;
            page-break-inside: avoid;
        }

            tr.avoid-page-break, td.avoid-page-break {
                position: relative;
                display: block;
                clear: both;
                page-break-before: auto;
                -moz-page-break-inside: avoid;
                page-break-inside: avoid;
            }
    </style>
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server">
        <div class="maindiv_prnew" style="border: solid 1px #000;">
            <div class="maininnerdiv_prnew" style="float: none;">
                <p class="header_prnew">
                    <img runat="server" id="imgHeader" src="../../Images/header-Printroster-new.gif" />
                </p>
                <p>
                    <img src="../../Images/specer.gif" width="535px" height="10px" />
                </p>
                <div class="toptbl_prnew">
                    <table cellpadding="0" cellspacing="0" border="0" class="tbl_pr">
                        <tr>
                            <td class="titletxt_prnew">Event ID
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="speventid"></td>
                            <td class="titletxt_prnew">Host
                            </td>
                            <td class="rightetails_prnew" runat="server" id="speventname"></td>
                        </tr>
                        <tr>
                            <td class="titletxt_prnew">Event Date
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="speventdate"></td>
                            <td class="titletxt_prnew">Address
                            </td>
                            <td class="rightetails_prnew" runat="server" id="speventloc"></td>
                        </tr>
                        <tr>
                            <td class="titletxt_prnew">Total Customer
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="spcustomercount"></td>
                            <td class="titletxt_prnew">Phone
                            </td>
                            <td class="rightetails_prnew" runat="server" id="sphostdetail"></td>
                        </tr>
                        <tr>
                            <td class="titletxt_prnew">Contact Name
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="tdContactName"></td>
                            <td class="titletxt_prnew">Contact Phone
                            </td>
                            <td class="rightetails_prnew" runat="server" id="tdContactPhone"></td>
                        </tr>
                        <tr>
                            <td class="titletxt_prnew">Contact Email
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="tdContactEmail"></td>
                            <td class="titletxt_prnew">Need to Clear Room?
                            </td>
                            <td class="rightetails_prnew" runat="server" id="tdRoomNeedCleared"></td>
                        </tr>
                        <tr>
                            <td class="titletxt_prnew">Plug points
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="tdPlugPoints"></td>
                            <td class="titletxt_prnew">Room Size
                            </td>
                            <td class="rightetails_prnew" runat="server" id="tdRoomSize"></td>
                        </tr>
                        <tr>
                            <td class="titletxt_prnew">Internet Access
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="tdInternetAccess"></td>
                            <td class="titletxt_prnew">Host Ranking
                            </td>
                            <td class="rightetails_prnew" runat="server" id="tdHostRanking"></td>
                        </tr>
                        <tr>
                            <td class="titletxt_prnew">Sponsor
                            </td>
                            <td class="leftdetails_prnew" runat="server" id="tdSponsor" colspan="3" style="width: 600px;"></td>
                        </tr>
                        <tr>
                            <td class="leftdetails_prnew" style="width: 95%;" runat="server" id="CalCenternotes" colspan="4"></td>
                        </tr>
                    </table>
                </div>
                <p>
                    <img src="../../Images/specer.gif" width="535px" height="20px" />
                </p>
                <p class="maininnerdiv_prnew">
                    <span class="blackheadtxt_prnew" runat="server" id="spGridHeader">Registered Customers</span>
                </p>
                <p>
                    <img src="../../Images/specer.gif" width="535px" height="5px" />
                </p>
                <div class="maininnerdiv_prnew" style="float: none;">
                    <asp:GridView ID="dgprintroster" runat="server" CssClass="gridprintroasters_new" AutoGenerateColumns="false" GridLines="None" OnRowDataBound="dgprintroster_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Serial" HeaderText="S No"></asp:BoundField>
                            <asp:TemplateField HeaderText="Time">
                                <HeaderStyle Width="100" />
                                <ItemStyle Width="100" />
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "AppointmentTime")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Info">
                                <HeaderStyle Width="100" />
                                <ItemStyle Width="100" />
                                <ItemTemplate>
                                    <span>
                                        <%# DataBinder.Eval(Container.DataItem, "CustomerName")%></span>
                                    <br />
                                    <span><b>Id:</b><%# DataBinder.Eval(Container.DataItem, "CustomerID")%></span><br />
                                    <span><b>Ph:</b>
                                        <%# DataBinder.Eval(Container.DataItem, "Phone")%></span><br />
                                    <span><b>PCP Info:</b><%# DataBinder.Eval(Container.DataItem, "PCPInfo")%></span>
                                    <span><b>MSP Form Filled:</b><%# DataBinder.Eval(Container.DataItem, "MSPInfo")%></span>
                                    <div class="Bar-Code" style="display: none">
                                        <div style="font-size: 9px; display: <%# (DataBinder.Eval(Container.DataItem, "CustomerID").ToString() == "0" ? "none" : "block") %>">* for cardiovision use only </div>
                                        <div style="text-align: center; float: left; display: <%# (DataBinder.Eval(Container.DataItem, "CustomerID").ToString() == "0" ? "none" : "block") %>">
                                            <img alt="" src="../../Common/BarCodeFeeder.aspx?Text=<%#DataBinder.Eval(Container.DataItem, "CustomerID")%>" /><br />
                                            <%#DataBinder.Eval(Container.DataItem, "CustomerID")%>
                                        </div>
                                        <div style="text-align: center; float: left; padding-left: 20px">
                                            <img src="../../Common/BarCodeFeeder.aspx?Text=<%#DataBinder.Eval(Container.DataItem, "firstName")%>" /><br />
                                            <%#DataBinder.Eval(Container.DataItem, "firstName")%>
                                        </div>
                                        <div style="text-align: center; padding-left: 20px; float: left; display: <%# (DataBinder.Eval(Container.DataItem, "lastName").ToString() == "" ? "none" : "block") %>">
                                            <img src="../../Common/BarCodeFeeder.aspx?Text=<%# DataBinder.Eval(Container.DataItem, "lastName")%>" /><br />
                                            <%# DataBinder.Eval(Container.DataItem, "lastName")%>
                                        </div>
                                        <div style="text-align: center; float: left; padding-left: 20px">
                                            <img src="../../Common/BarCodeFeeder.aspx?Text=<%# DataBinder.Eval(Container.DataItem, "CustomerName")%>" /><br />
                                            <%# DataBinder.Eval(Container.DataItem, "CustomerName")%>
                                        </div>
                                    </div>
                                    <span class="customer-notes" style="display: none;">
                                        <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Package" HeaderText="Package"></asp:BoundField>
                            <asp:BoundField DataField="AdditionalTests" HeaderText="Additional Test(s)"></asp:BoundField>
                            <asp:BoundField DataField="AddOn" HeaderText="Images"></asp:BoundField>
                            <asp:BoundField DataField="CouponCode" HeaderText="Coupon"></asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount"></asp:BoundField>
                            <asp:BoundField DataField="Discount" HeaderText="Disc"></asp:BoundField>
                            <asp:BoundField DataField="PaymentStatus" HeaderText="Paid"></asp:BoundField>
                            <asp:TemplateField HeaderText="Kyn Pre-Filled">
                                <HeaderStyle Width="100" />
                                <ItemStyle Width="100" />
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "KynStatus")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CheckInTime" HeaderText="Checkin"></asp:BoundField>
                            <asp:BoundField DataField="CheckOutTime" HeaderText="Checkout"></asp:BoundField>
                            <asp:BoundField DataField="Signature" HeaderText="Signature"></asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="row11" />
                        <RowStyle CssClass="row22 item-row" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <script language="javascript" type="text/javascript">
            $(function () {
                $("tr.item-row").each(function () {
                    if ($(this).find(".customer-notes").html() != null && $.trim($(this).find(".customer-notes").html()) != "") {
                        $(this).after("<tr><td colspan='14'>" + $(this).find(".customer-notes").html() + "</td></tr>");
                    }
                    if ('<%=EnableBarCode %>' == '<%= Boolean.TrueString %>' && '<%= Request.QueryString["barCodeVersion"]%>' == '<%= Boolean.TrueString %>' && $(this).find(".Bar-Code").html() != null) {
                        $(this).after("<tr><td colspan='14'> " + $(this).find(".Bar-Code").html() + " </td></tr>");
                    }
                });
            });
        </script>
    </form>
</body>
</html>

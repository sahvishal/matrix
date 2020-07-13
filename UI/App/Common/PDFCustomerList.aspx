<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="App_Common_PDFCustomerList" Title="CustomerList" Codebehind="PDFCustomerList.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="background: white">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../StyleSheets/UC.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/Commonstyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: white">
    <form id="form1" runat="server" style="background: white">
        <div class="regcust_innerrow">
            <div style=" float:left; width:744px;">
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                <span class="orngbold14_default" id="spHeaderText" runat="server" style="float:left;">Customer List</span>
                <span id="spDate" runat="server" style=" float:right; font-size:8pt;"></span>
            </div>
            <div style="float:left; width:744px; border:solid 1px #ccc; background-color:#f8f8f8; margin-bottom:1px;">
                <p>
                    <img src="../Images/specer.gif" width="700px" height="5px" /></p>
                                     <p class="lgtgrayboxrow_cl">
                <span class="orngbold12_default"> Search Criteria</span>
                 </p>
                <p class="lgtgrayboxrow_cl">
                    <span class="titletext_default">Name:</span> <span class="ttxtwidthnormalsmall_default"><span
                        id="spCustomerName" runat="server"></span></span><span class="titlenowdth_cl">
                            State:</span> <span class="inputfldnowidth_cl"><span runat="server" id="spState">
                            </span></span><span class="titlenowdth_cl">City:</span> <span class="inputfldnowidth_cl">
                                <span runat="server" id="spCity"></span></span><span class="titlenowdth_cl">Zip:</span>
                    <span class="inputfldnowidth_cl"><span id="spZip" runat="server"></span></span>
                </p>
                <p>
                    <img src="../Images/specer.gif" width="700px" height="5px" /></p>
                <p class="lgtgrayboxrow_cl">
                    <span class="titletext_default">Customer ID:</span> <span class="ttxtwidthnormalsmall_default"><span
                        runat="server" id="spCustomerID"></span></span><span class="titlenowdth_cl">Date
                            Range:</span> <span class="dateinputfldnowidth_cl">Start Date &nbsp;<span id="spStartDate"
                                runat="server"> </span></span><span class="dateinputfldnowidth_cl">&nbsp;&nbsp;
                                    End Date &nbsp;<span id="spEndDate" runat="server"> </span></span>
                    <span></span>
                </p>
                <p>
                    <img src="../Images/specer.gif" width="700px" height="5px" /></p>
                <div id="divCustomer" runat="server">
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletext_default">Franchisee:</span> <span class="ttxtwidthnormalsmall_default" id="spFranchiseeID" runat="server">
                             </span>
                      <span class="titlenowdth_cl">Date Range Bucket:</span> <span class="ttxtwidthnormal_default" id="spDateRangeBucket" runat="server">-NA-</span>
                             
                    </p>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="15px" /></p>
            </div>
            <div class="grayboxtop_cl">
                <asp:GridView ID="grdCustomerList" DataKeyNames="CustomerID" runat="server" CssClass="divgrid_cl"
                    AutoGenerateColumns="false" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="CustomerID" HeaderText="ID"></asp:BoundField>
                        <asp:TemplateField HeaderText="FullName">
                            <ItemTemplate>
                                <span>
                                    <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                </span>
                                <br />
                                <span>
                                    <%# DataBinder.Eval(Container.DataItem, "Email")%>
                                </span>
                                <br />
                                <span style="color: #666; font-size: 11px">
                                    <%# DataBinder.Eval(Container.DataItem, "Phone")%>
                                </span>
                                <br />
                                <%# DataBinder.Eval(Container.DataItem, "RegDate")%>
                                <br />
                                Mode:<span style="color: #666; font-size: 11px">
                                    <%# DataBinder.Eval(Container.DataItem, "AddedBY")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Source">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Marketing")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Address")%>
                                <br />
                                <span style="color: #287AA8; font-size: 11px">
                                    <%# DataBinder.Eval(Container.DataItem, "RestAddress")%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Event Attended">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Event")%>
                                <br />
                                <%# DataBinder.Eval(Container.DataItem, "EventDate")%>
                                <br />
                                <span style="color: #287AA8; font-size: 11px">
                                    <%# DataBinder.Eval(Container.DataItem, "Host")%>
                                </span>
                                <br />
                                <span style="color: #666; font-size: 11px">
                                    <%# DataBinder.Eval(Container.DataItem, "Package")%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="TotalRevenue" HeaderText="Total Revenue">
                            <ItemTemplate>
                                $<%# DataBinder.Eval(Container.DataItem, "TotalRevenue")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1" />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

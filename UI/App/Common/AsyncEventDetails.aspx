<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncEventDetails.aspx.cs" Inherits="HealthYes.Web.App.Common.AsyncEventDetails" EnableEventValidation="false" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="UC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <UC:JQueryToolkit ID="_jQuesryToolkit" runat="server" IncludeJQueryThickBox="true" />
    <div style="float:left;" id="divMain" runat="server">
    <%--Begin Customer--%>    
            <asp:GridView ID="_eventCustomerGrid" runat="server" EnableViewState="false" DataKeyNames="EventCustomerID"
                    CssClass="divgrid_clnew" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="_eventCustomerGrid_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Time">
                            <HeaderStyle Width="100" />
                            <ItemStyle Width="100" />
                            <ItemTemplate>
                                <asp:Literal ID="_appointmentTimeLiteral" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appointment Detail">
                            <HeaderStyle Width="150" />
                            <ItemStyle Width="150" />
                            <ItemTemplate>
                                <span runat="server" id="spcustomerdetail"><a id="CustomerEdit" runat="server" href="Javascript:void(0)">
                                    <asp:Literal ID="_customerNameLiteral" runat="server" />
                                    (ID:
                                    <asp:Literal ID="_customerIdLiteral" runat="server" />) </a>
                                    <br />
                                    <a id="aCustomerDetail" runat="server" href='/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=<%# DataBinder.Eval(Container.DataItem, "CustomerId")%>'>
                                        (more details)</a>
                                    <br />
                                    <span runat="server" id="spAcctDetail" style="display: none;">Acct Created:<%# DataBinder.Eval(Container.DataItem, "RegisteredBy").ToString()%>
                                        [<asp:Literal ID="_userCreatedDateLiteral" runat="server" />]
                                        <br />
                                        Repeat Count:[<%# (Convert.ToInt32(DataBinder.Eval(Container.DataItem, "EventCount")) - 1).ToString()%>]
                                        <br />
                                    </span>
                                    <%# Convert.ToString(DataBinder.Eval(Container.DataItem, "Email1")).Length > 0 ? Convert.ToString(DataBinder.Eval(Container.DataItem, "Email1") + "<br />") : ""%>
                                    <span id="spPhone" runat="server"></span></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Package/Test">
                            <HeaderStyle Width="200" />
                            <ItemStyle Width="200" />
                            <ItemTemplate>
                                <span><asp:Literal ID="PackageNameLiteral" runat="server" />
                                </span><span runat="server" id="spApptDetail" style="display: none;">Appt. Created:
                                    <%# DataBinder.Eval(Container.DataItem, "SignUpMode")%>
                                    [<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EventSignupDate")).ToString("MM/dd/yyyy")%>]</span>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Source Code">
                            <ItemTemplate>
                                <asp:Literal ID="_couponCodeLiteral" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:Literal ID="_paymentDetailLiteral" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>                      
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <span runat="server" id="spStatus" style="width: 80px; float: left">NOT PAID</span><br />
                                <%--<span runat="server" id="ViewOrderDetailsSpan" style="width: 80px; float: left" visible="false">
                                </span>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Check In/Out" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span runat="server" id="spfiledcheckin" style="text-align: center; float: left; width: 110px">                                    
                                    <p>
                                        <span runat="server" id="spCheckInInsert"><span class="gridinnertxtdiv">In:</span> </span>
                                    </p>
                                    <p>
                                        <span runat="server" id="spCheckOutInsert"><span class="gridinnertxtdiv">Out:</span></span>
                                    </p>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Action</HeaderTemplate>
                            <ItemTemplate>
                                <span runat="server" id="spAction" style="width: 110px; float: left;">N/A </span>
                            </ItemTemplate>
                            <ItemStyle CssClass="smalllnkgrid" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1" />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
    <%--End Customer--%>
    
    
    </div>
    </form>
</body>
</html>

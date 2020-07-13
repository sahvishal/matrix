<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_ucManageOrder" Codebehind="ucManageOrder.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript" language="javascript">

    var GB_ROOT_DIR = "/App/Wizard/greybox/";
    function txtkeypress(evt)
    {
        return KeyPress_NumericAllowedOnly(evt);
                
    }
    
    function Reset() 
    {
        document.getElementById("<%= this.txtCustName.ClientID %>").value="";
        document.getElementById("<%= this.txtCustID.ClientID %>").value="";
        document.getElementById("<%= this.txtStartDate.ClientID %>").value = ""; 
        document.getElementById("<%= this.txtEndDate.ClientID %>").value = ""; 
        document.getElementById("<%= this.ddlOrderStatus.ClientID %>").selectedIndex=0;
        document.getElementById("<%= this.ddlDeliveryMode.ClientID %>").selectedIndex=0;

        return false; 
    }
    
    function OnComplete(arg) 
    {//debugger
        var hfOrderID=document.getElementById("<%=this.hfOrderID.ClientID %>");
        var hfNotAccepted=document.getElementById("<%=this.hfNotAccepted.ClientID %>");
        var hfAccepted=document.getElementById("<%=this.hfAccepted.ClientID %>");
        var hfPrint=document.getElementById("<%=this.hfPrint.ClientID %>");
        var hfspShippingInfo=document.getElementById("<%=this.hfspShippingInfo.ClientID %>");
        
        
        var spNotAccepted=document.getElementById(hfNotAccepted.value);
        var spAccepted=document.getElementById(hfAccepted.value);
        var spPrint=document.getElementById(hfPrint.value);
        var spShippingInfo=document.getElementById(hfspShippingInfo.value);
        
        spNotAccepted.style.display="none";
        spAccepted.style.display="block";
        spPrint.style.display="block";
        spShippingInfo.style.display="block";
        //aShippingInfo.href="/App/Common/ShippingInfo.aspx?OrderID=" + hfOrderID.value + "&OrderShippingInformationID=" + hfOrderShippingInformationID.value;
        //aShippingInfo.rel='gb_page_center[565, 428]';
        //"<a href='/App/Common/ShippingInfo.aspx?OrderID=" + hfOrderID.value + "&OrderShippingInformationID=" + hfOrderShippingInformationID.value + "' id='aShippingInfo' rel='gb_page_center[565, 428]'>" + hfOrderID.value + "</a>";
        
        document.getElementById('div').style.visibility = "hidden";
        document.getElementById('div').style.display = "none";
    }

    function OnTimeOut(arg) 
    {
        alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");
    }

    function OnError(arg) 
    {
        alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");
    }
    
    function AcceptOrder(OrderID,NotAcceptedID,AcceptedID,PrintID,spShippingInfoID)
    {//debugger
        var IsAccept=confirm("Do you want to accept the order?");
        if(IsAccept==true)
        {
            document.getElementById('div').style.visibility = "visible";
            document.getElementById('div').style.display = "block";
            
            var UserID=document.getElementById("<%=this.hfUserID.ClientID %>");
            var RoleID=document.getElementById("<%=this.hfRoleID.ClientID %>");
            var hfOrderID=document.getElementById("<%=this.hfOrderID.ClientID %>");
            
            var hfNotAccepted=document.getElementById("<%=this.hfNotAccepted.ClientID %>");
            var hfAccepted=document.getElementById("<%=this.hfAccepted.ClientID %>");
            var hfPrint=document.getElementById("<%=this.hfPrint.ClientID %>");
            var hfspShippingInfo=document.getElementById("<%=this.hfspShippingInfo.ClientID %>");
            
            hfNotAccepted.value=NotAcceptedID;
            hfAccepted.value=AcceptedID;
            hfPrint.value=PrintID;
            hfspShippingInfo.value=spShippingInfoID;
            hfOrderID.value=OrderID;
            
            ret = AutoCompleteService.AcceptOrder(OrderID, UserID.value, RoleID.value, OnComplete, OnTimeOut, OnError);
        }
        
    }
    
    function validate()
    {
        var txtStartDate = document.getElementById("<%= this.txtStartDate.ClientID %>");
        if(txtStartDate.value!="")
        {
            if(ValidateDate(txtStartDate.value,"Start Date")==false)
                    {return false;}
                
            if(checkDate(txtStartDate.value,"Start Date")==false)
                {return false;}
            
        }  
        var txtEndDate = document.getElementById("<%= this.txtEndDate.ClientID %>");
        if(txtEndDate.value!="")
        {
            if(ValidateDate(txtEndDate.value,"Start Date")==false)
                    {return false;}
                
            if(checkDate(txtEndDate.value,"Start Date")==false)
                {return false;} 
        }
    }
</script>
<style type="text/css">
#div {
position: fixed;
top: 20px;
left: 10px;
}
</style>
<script type="text/javascript" src="/App/Wizard/greybox/AJS.js"></script>

<script type="text/javascript" src="/App/Wizard/greybox/AJS_fx.js"></script>

<script type="text/javascript" src="/App/Wizard/greybox/gb_scripts_reloadonclose.js"></script>

<link href="../Wizard/greybox/gb_styles.css" rel="stylesheet" type="text/css" />


<div class="mainbody_outer">
    <div id="div" class="loadingdiv_ucecustlist" style="visibility:hidden; display:none;">
        <span style="float:left; padding-right:5px" class="blktext14px_default">Loading...</span> 
        <span style="float:left"><img src="/App/Images/loading.gif" /></span> 
    </div>
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_top_body">
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                <span class="orngheadtxt_heading" id="sptitle" runat="server">Manage Orders</span>
                <%--<span class="headingright_default"><a href="#">+ Create New Order</a></span>--%>
            </div>
            <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            <p class="graylinefull_common">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
        </div>
        <div class="main_area_bdrnone">
            <p>
                <img src="../Images/specer.gif" width="720px" height="5px" /></p>
            <div class="grayboxtop_cl">
                <p class="grayboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                <p class="grayboxheader_cl">
                    Filter/Search Orders</p>
                <div class="lgtgraybox_cl" id="divStartCallSearch" runat="server">
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span class="titletext1a_default">Customer Name:</span>
                        <span class="inputfldnowidth_cl" style="width: 145px">
                            <asp:TextBox ID="txtCustName" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox>
                        </span>
                        <span class="titlenowdth_cl">Order Date:</span> 
                        <span class="dateinputfldnowidth_cl">Start Date &nbsp;
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputf_def" Width="65px"></asp:TextBox>
                        </span> 
                        <span class="calendarcntrl_default">
                            <asp:ImageButton ID="imgCalendarStart" runat="server" ImageUrl="/App/Images/calendar-icon.gif" CssClass=""></asp:ImageButton>
                            <cc1:CalendarExtender ID="calStart" runat="server"  TargetControlID="txtStartDate" PopupButtonID="imgCalendarStart"
                                                Animated="true" Format="MM/dd/yyyy">
                                            </cc1:CalendarExtender>
                        </span>
                        <span class="dateinputfldnowidth_cl">End Date &nbsp;
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="inputf_def" Width="65px"></asp:TextBox>
                        </span>
                        <span class="calendarcntrl_default">
                            <asp:ImageButton ID="imgCalendarEnd" runat="server" ImageUrl="/App/Images/calendar-icon.gif" CssClass=""></asp:ImageButton>
                            <cc1:CalendarExtender ID="calEnd" runat="server"  TargetControlID="txtEndDate" PopupButtonID="imgCalendarEnd"
                                                Animated="true" Format="MM/dd/yyyy" >
                                            </cc1:CalendarExtender>
                        </span>
                    </p>
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span class="titletext1a_default">Customer ID:</span> 
                        <span class="inputfldnowidth_cl" style="width: 145px">
                            <asp:TextBox ID="txtCustID" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox>
                        </span>
                        <span class="titlenowdth_cl" style="width:80px; margin-right:3px;">Order Status:</span> 
                        <span style="float: left; width: 140px; margin-right: 5px; padding-top: 2px;">
                            <asp:DropDownList ID="ddlOrderStatus" runat="server" CssClass="inputf_def" Width="140px">
                                <asp:ListItem Value="0">Pending</asp:ListItem>
                                <%--<asp:ListItem Value="1">Printed</asp:ListItem>--%>
                                <asp:ListItem Value="2">Delivered</asp:ListItem>
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span class="titletext1a_default">Delivery Mode:</span> 
                        <span class="inputfldnowidth_cl">
                            <asp:DropDownList ID="ddlDeliveryMode" runat="server" CssClass="inputf_def" Width="140px">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p>
                        <img src="../Images/specer.gif" width="500px" height="10px" /></p>
                </div>
                <div class="lgtgraybox_cl">
                    <span class="buttoncon_default">
                        <asp:ImageButton ID="ibtnSearch" runat="server" 
                        ImageUrl="~/App/Images/search-smallbtn.gif" onclick="ibtnSearch_Click" OnClientClick="return validate();" />
                    </span>
                    <span class="buttoncon_default">
                        <asp:ImageButton ID="ibtnReset" runat="server" ImageUrl="~/App/Images/reset-btn.gif" OnClientClick="return Reset();" />
                    </span>
                </div>
                <p class="grayboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="4" /></p>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="10px" /></p>
            <p class="main_row_custdbrd">
                <span class="orngbold14_default" style="float: left; padding-top: 8px;">Found <span id="spNoOfOrders" runat="server"></span> orders</span>
                <span style="float: right">
                    <span class="rightlnktxt_cl" style="padding-top: 3px">
                        <asp:DropDownList ID="ddlRecords" runat="server" Width="50px" CssClass="inputf_def"
                            AutoPostBack="true" onselectedindexchanged="ddlRecords_SelectedIndexChanged">
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                            <asp:ListItem Value="30">30</asp:ListItem>
                            <asp:ListItem Value="40">40</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                        </asp:DropDownList>
                    </span>
                    <span class="rightlnktxt_cl" style="padding-top: 5px">Records Per Page :&nbsp;</span>
                </span>
            </p>
            <p>
                <img src="../Images/specer.gif" width="720px" height="5px" /></p>
            <p class="graylinefull_default">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
        </div>
        <div class="main_area_bdrnone">
            <div style="float:left; height:27px;">
                 <asp:ImageButton id="imgBtnReadyToShip" runat="server" ImageUrl="~/App/Images/readytoship-tab-on.gif" onclick="imgBtnReadyToShip_Click" />
                 <asp:ImageButton ID="imgBtnDelivered" runat="server" ImageUrl="~/App/Images/Delivered-tab-off.gif" onclick="imgBtnDelivered_Click" />
                 <asp:ImageButton ID="imgBtnUpcomingOrders" runat="server" ImageUrl="~/App/Images/Upcoming-tab-off.gif" onclick="imgBtnUpcomingOrders_Click" />

            </div>
            <div class="grayboxtop_cl" id="divGrid" runat="server">
                <div style="float: left; width: 746px;" >
                    <asp:GridView ID="dgManageOrder" runat="server" CssClass="divgrid_clnew" GridLines="None"
                        AutoGenerateColumns="false" onrowdatabound="dgManageOrder_RowDataBound" 
                        AllowPaging="true" PageSize="10" onpageindexchanging="dgManageOrder_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Order ID">
                                <ItemTemplate>
                                    <span id="spOrder" runat="server" style="display:block;"><%# DataBinder.Eval(Container.DataItem, "OrderID")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recipient Info">
                                <ItemTemplate>
                                    <span><%# DataBinder.Eval(Container.DataItem, "CustomerName")%></span>
                                    <br />
                                    <span>ID:#</span><span><%# DataBinder.Eval(Container.DataItem, "CustomerID")%></span>
                                    <br />
                                    <span><%#DataBinder.Eval(Container.DataItem, "Address1")%></span>
                                    <br />
                                    <span><%#DataBinder.Eval(Container.DataItem, "City")%>, <%#DataBinder.Eval(Container.DataItem, "State")%> <%#DataBinder.Eval(Container.DataItem, "ZipCode")%></span>
                                 </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Order Type">
                                <ItemTemplate>
                                    <span style="float: left; width: 110px">
                                        <%# DataBinder.Eval(Container.DataItem, "OrderType")%>
                                        <%--<br />
                                        This order is placed by Franchisor/Franchisee when a customer pays for reports to
                                        be printed <a href="#">&nbsp; More...<%# DataBinder.Eval(Container.DataItem, "OrderType")%></a>--%>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Placed By">
                                <ItemTemplate>
                                    <span><%#DataBinder.Eval(Container.DataItem,"CreatedBy") %></span><br />
                                    <span>(<%#DataBinder.Eval(Container.DataItem, "CreatedByRole")%>)</span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Count">
                                <ItemTemplate>
                                    <span>1</span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Statistics">
                                <ItemTemplate>
                                    Total: XXXX
                                    <br />
                                    Serviced: YYYY
                                    <br />
                                    Not Served: ZZZZ</a>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Payment Status">
                                <ItemTemplate>
                                    <span><%# DataBinder.Eval(Container.DataItem, "PaymentStatus")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <span id="spPending" runat="server">Pending</span>
                                    <span id="spPrinted" runat="server" style="display:none;">Printed</span>
                                    <span id="spDelivered" runat="server" style="display:none;">
                                        <span style="color: #66A726; font-weight: bold">Delivered</span>
                                        <br />
                                        Date: <%# DataBinder.Eval(Container.DataItem, "ShippingDate")%>
                                        <%--<br />
                                        Time: 02:30:00--%>
                                        <br />
                                        By: <%# DataBinder.Eval(Container.DataItem, "Carrier")%>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <span id='spNotAccepted' runat="server"><a href="javascript:void(0);" id="aNotAccepted" runat="server">Process Order</a></span>
                                    <span id='spAccepted' runat="server" style="display:none;">Accepted</span>
                                    <span id="spShippingInfo" runat="server" style="display:none;"><a href='/App/Common/ShippingInfo.aspx' id='ashippingInfo' runat='server' rel='gb_page_center[565, 458]'>Shipping Info</a></span>
                                    <span id='spPrint'  runat="server" style="display:none;"><a href="javascript:void(0);" id="aPrint" runat="server" onclick="alert('Pending functionality');">Print</a></span>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <RowStyle CssClass="row2" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                
                <p class="blueboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" /></p>
            </div>
            <div style=" float:left; width:746px; border:solid 1px #e5e5e5; padding:20px 0px 20px 0px; display:none;" id="dvNoOrderFound" runat="server">           
                <div class="divnoitemfound_custdbrd">
                    <p class="divnoitemtxt_custdbrd">
                        <span class="orngbold18_default">No Order Found</span>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfUserID" runat="server" />
    <asp:HiddenField ID="hfRoleID" runat="server" />
    <asp:HiddenField ID="hfOrderID" runat="server" />
    <asp:HiddenField ID="hfNotAccepted" runat="server" />
    <asp:HiddenField ID="hfAccepted" runat="server" />
    <asp:HiddenField ID="hfPrint" runat="server" />
    <asp:HiddenField ID="hfspShippingInfo" runat="server" />
    <asp:HiddenField ID="hfOrderShippingInformationID" runat="server" />
    <asp:HiddenField ID="hfspOrder" runat="server" />
    <asp:HiddenField ID="hfaShippingInfo" runat="server" />
</div>

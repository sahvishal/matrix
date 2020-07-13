<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_Admin_NotificationCenter" Codebehind="NotificationCenter.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

function ReServiceNotification()
  {
    var answer = confirm ("Are you sure you want to Re Service Notification ? ")
    return answer;
  }
  
function ResetSearch()
  {
        //var currentDate= new Date();
        var txtNameOrCustomerID = document.getElementById('<%= this.txtNameOrCustomerID.ClientID %>');
        var txtStartDate = document.getElementById('<%= this.txtStartDate.ClientID %>');
        var txtEndDate = document.getElementById('<%= this.txtEndDate.ClientID %>');
        var ddlStatus = document.getElementById('<%= this.ddlStatus.ClientID %>');
        var ddlNotificationType = document.getElementById('<%= this.ddlNotificationType.ClientID %>');
        var ddlMedium = document.getElementById('<%= this.ddlMedium.ClientID %>');

        txtNameOrCustomerID.value='';
        //txtStartDate.value=currentDate;
        //txtEndDate.value=currentDate;
        ddlStatus.options[0].selected = true;
        ddlNotificationType.options[0].selected = true;
        ddlMedium.options[0].selected = true;
        __doPostBack('__Page', 'Reset');
        return false;
  }
  
  function SearchValidate()
  {
        var txtStartDate = document.getElementById('<%= this.txtStartDate.ClientID %>');
        var txtEndDate = document.getElementById('<%= this.txtEndDate.ClientID %>');
        
       if(ValidateDate(txtStartDate.value,"Start Date")==false)
        {
            txtStartDate.focus();
            return false;
        }
        else if(ValidateDate(txtEndDate.value,"End Date")==false)
        {
            txtEndDate.focus();
            return false;
        }
        if (CompareTwoDates1(txtStartDate.value,txtEndDate.value)==false)
        {
            alert("EndDate should be grater than or equals to StartDate ");
            txtEndDate.focus();
            return false;
        }
        else return true;
        
  }
  
  function deleteConfirmation()
  {
    var cfrm=confirm("Are you sure to delete this notification?");
    if(cfrm==true)
    {
        document.getElementById('div').style.visibility = "visible";
        document.getElementById('div').style.display = "block";
    }
    return cfrm;
  }
  
    function hideLoadingImage()
    {
        document.getElementById('div').style.visibility = "hidden";
        document.getElementById('div').style.display = "none";
    }
    </script>
    
    <style type="text/css">
    #div
    {
        position: fixed;
        top: 20px;
        left: 10px;
    }
    </style>
    <asp:Panel runat="server" DefaultButton="ibtnSearch" ID="panel1">
        <div id="div" class="loadingdiv_ucecustlist" style="visibility: hidden; display: none;">
            <span style="float: left; padding-right: 5px" class="blktext14px_default">Loading...</span>
            <span style="float: left">
                <img src="/App/Images/loading.gif" /></span>
        </div>
        <div class="mainbody_outer">
            <div class="mainbody_inner">
                <div class="main_area_bdrnone">
                    <div class="headingbox_top_body">
                        <p>
                            <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                        <span class="orngheadtxt_heading" id="sptitle" runat="server">Notification Center
                        </span>
                    </div>
                    <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false"
                        runat="server">
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                    <p class="graylinefull_common" id="P1" onclick="return P1_onclick()">
                        <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                </div>
                <div class="main_area_bdrnone">
                    <p>
                        <img src="/App/Images/specer.gif" width="720px" height="5px" /></p>
                    <div class="grayboxtop_cl">
                        <p class="grayboxtopbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                        <p class="grayboxheader_cl">
                            Filter/Search Notification</p>
                        <div class="lgtgraybox_cl" id="divStartCallSearch" runat="server">
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titletext1a_default">Recipient Name / ID:</span> <span class="inputfldnowidth_cl">
                                    <asp:TextBox ID="txtNameOrCustomerID" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                                <span class="titlenowdth_cl">Date Range:</span> <span class="dateinputfldnowidth_cl">
                                    Start Date &nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="inputf_def"
                                        Width="65px"></asp:TextBox></span> <span class="calendarcntrl_default">
                                            <cc1:CalendarExtender ID="calStart" runat="server" TargetControlID="txtStartDate"
                                                PopupButtonID="imgCalendarStart" Animated="true" Format="MM/dd/yyyy">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="imgCalendarStart" ToolTip="Start date" runat="server" ImageUrl="/App/Images/calendar-icon.gif"
                                                CssClass=""></asp:ImageButton>
                                        </span><span class="dateinputfldnowidth_cl">End Date &nbsp;<asp:TextBox ID="txtEndDate"
                                            runat="server" CssClass="inputf_def" Width="65px"></asp:TextBox></span>
                                <span class="calendarcntrl_default">
                                    <cc1:CalendarExtender ID="calEnd" runat="server" TargetControlID="txtEndDate" PopupButtonID="imgCalendarEnd"
                                        Animated="true" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="imgCalendarEnd" ToolTip="End date" runat="server" ImageUrl="/App/Images/calendar-icon.gif"
                                        CssClass=""></asp:ImageButton>
                                </span>
                            </p>
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titletext1a_default">Status:</span> <span class="inputfldnowidth_cl"
                                    style="margin-right: 35px">
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="105px">
                                    </asp:DropDownList>
                                </span><span class="titlenowdth_cl" style="width: 70px">Type:</span> <span class="inputfieldright_default"
                                    style="padding-right: 20px;">
                                    <asp:DropDownList runat="server" ID="ddlNotificationType" AutoPostBack="false">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titletext1a_default">Medium:</span> <span class="inputfieldconleft_default">
                                    <asp:DropDownList ID="ddlMedium" runat="server" Width="105px">
                                        <asp:ListItem>All</asp:ListItem>
                                    </asp:DropDownList>
                                </span>
                            </p>
                        </div>
                        <div class="lgtgraybox_cl">
                            <span class="buttoncon_default">
                                <asp:ImageButton ToolTip="Search Notifications" ID="ibtnSearch" runat="server" ImageUrl="/App/Images/search-smallbtn.gif"
                                    OnClientClick="return SearchValidate();" OnClick="ibtnSearch_Click" /></span>
                            <span class="buttoncon_default">
                                <asp:ImageButton ToolTip="Reset to default" ID="ibtnReset" runat="server" ImageUrl="/App/Images/reset-btn.gif"
                                    OnClientClick="return ResetSearch();" /></span>
                        </div>
                        <p class="grayboxbotbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="4" /></p>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="720px" height="10px" /></p>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <div class="main_row_custdbrd" id="divDeleteMsg" runat="server" style="display:none;">
                        <span class="norcrdmsgtxt_acp" style="width:740px">Notification deleted successfully.</span>
                    </div>
                    <p class="main_row_custdbrd">
                        <span class="orngbold14_default" style="float: left; padding-top: 8px;"><span id="spnRecords"
                            runat="server"></span></span><span class="rightlnktxt_cl" style="padding-top: 3px">
                                <asp:DropDownList ID="ddlRecords" runat="server" Width="50px" CssClass="inputf_def"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlRecords_SelectedIndexChanged">
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    <asp:ListItem Value="40">40</asp:ListItem>
                                    <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
                                </asp:DropDownList>
                            </span><span class="rightlnktxt_cl" style="padding-top: 5px">Records Per Page :&nbsp;</span>
                    </p>
                    <p>
                        <img src="/App/Images/specer.gif" width="720px" height="5px" /></p>
                    <p class="blueboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="5" /></p>
                    <div style="float: left; width: 746px;">
                        
                                <asp:GridView ID="grdNotificationCenter" runat="server" CssClass="divgrid_clnew"
                                    GridLines="None" AutoGenerateColumns="false" DataKeyNames="NotificationID" AllowPaging="True"
                                    AllowSorting="true" OnPageIndexChanging="grdNotificationCenter_PageIndexChanging"
                                    OnSorting="grdNotificationCenter_Sorting" 
                                    onrowdeleting="grdNotificationCenter_RowDeleting" OnRowDataBound="grdNotificationCenter_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "NotificationID")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Recipient Info" SortExpression="CustomerName">
                                            <ItemTemplate>
                                                <span>
                                                    <%# DataBinder.Eval(Container.DataItem, "CustomerName")%>
                                                </span>
                                                <br />
                                                <span>ID:
                                                    <%# DataBinder.Eval(Container.DataItem, "CustomerID")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Notification Info" SortExpression="NotificationTypeName">
                                            <ItemTemplate>
                                                <span>
                                                    <%# DataBinder.Eval(Container.DataItem, "NotificationTypeName")%>
                                                </span><br />
                                                Medium: 
                                                <span>
                                                    <img alt='<%# DataBinder.Eval(Container.DataItem, "NotificationMedium")%>' runat="server"
                                                        id="imgMedium" src='<%# ImagePath(DataBinder.Eval(Container.DataItem, "NotificationMedium"))%>' />
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "ServiceStatus")%><br />
                                                <%# DataBinder.Eval(Container.DataItem, "ServicedDate")%>
                                                &nbsp;Attempt:
                                                <%# DataBinder.Eval(Container.DataItem, "AttemptCount")%>
                                                <br />
                                                By:<%# DataBinder.Eval(Container.DataItem, "ServicedBy")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ToolTip="View Notification" runat="server" Text="View Notification"
                                                    ID="lnkViewNotification" OnCommand="Command_Button_Click" CommandName="ViewNotification"
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NotificationID")%>'></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton ToolTip="Re Service Notification" runat="server" Text="Re Service Notification"
                                                    ID="lnkReServiceNotification" OnClientClick="return ReServiceNotification();"
                                                    OnCommand="Command_Button_Click" CommandName="ReServiceNotification" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NotificationID")%>'></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton ToolTip="Delete Notification" runat="server" Text="Delete Notification"
                                                    ID="lnkBtnDelete" OnClientClick="return deleteConfirmation();" CommandName="Delete" 
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NotificationID")%>' onclick="lnkBtnDelete_Click"></asp:LinkButton>
                                                <br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="row1" />
                                    <RowStyle CssClass="row2" />
                                    <AlternatingRowStyle CssClass="row3" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <p class="blueboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="5" /></p>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

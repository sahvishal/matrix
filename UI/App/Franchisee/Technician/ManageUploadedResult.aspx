<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisee_Technician_ManageUploadedResult"
    Title="Untitled Page" Codebehind="ManageUploadedResult.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    
        function ResetAll()
        {
            document.getElementById('<%= this.txtFileName.ClientID %>').value = '';
            document.getElementById('<%= this.txtevent.ClientID %>').value = '';
            document.getElementById('<%= this.txtStartDate.ClientID %>').value = '';
            document.getElementById('<%= this.txtEndDate.ClientID %>').value = '';
            
            document.getElementById('<%= this.ddluploadedby.ClientID %>').options[0].selected = true;
            document.getElementById('<%= this.ddlstatus.ClientID %>').options[0].selected = true;
            
            __doPostBack('Reset', '');
            
            return false;
        }
        
        function msgOnUpcomingFunctionality()
        {
            alert('Pending Functionality');
        }
        
        function CheckSearchClick()
        {
            var txtfilename = document.getElementById('<%= this.txtFileName.ClientID %>');
            var txtevent = document.getElementById('<%= this.txtevent.ClientID %>');
            var txtStartDate = document.getElementById('<%= this.txtStartDate.ClientID %>');
            var txtEndDate = document.getElementById('<%= this.txtEndDate.ClientID %>');
            var ddluploadedby = document.getElementById('<%= this.ddluploadedby.ClientID %>');
            var ddlstatus = document.getElementById('<%= this.ddlstatus.ClientID %>');
            
            if(txtfilename.value == '' && txtevent.value == '' && txtStartDate.value == '' && txtEndDate.value == '' && ddluploadedby.selectedIndex == 0 && ddlstatus.selectedIndex == 0)
            {
                alert('Enter some of the search filter.');
                return false;
            }
            return true;
        }
        
                
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <p>
                        <img src="/App/Images/specer.gif" width="700px" alt="" height="5px" /></p>
                <div class="headingbox_top_body" style="width:753px;">
                    <span class="orngheadtxt_heading">Manage Uploaded Result Files</span> <span class="headingright_default">
                        <a href="uploadresults.aspx">Upload New File</a></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="700px" alt="" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="../../Images/specer.gif" width="1px" alt="" height="1px" /></p>
                <p>
                    <img src="../../Images/specer.gif" width="700px" alt="" height="5px" /></p>
                <div class="main_area_bdrnone">
                    <div class="divmainbody_cd">
                        <div class="grayboxtop_cl">
                            <p class="grayboxtopbg_cl">
                                <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                            <p class="grayboxheader_cl">
                                Search Uploaded File</p>
                            <div class="lgtgraybox_cl">
                                <p>
                                    <img src="../../Images/specer.gif" alt="" width="700px" height="5px" /></p>
                                <p class="lgtgrayboxrow_cl">
                                    <span class="titletext_default">File Name:</span> <span class="inputfieldconleft_default">
                                        <asp:TextBox ID="txtFileName" runat="server" CssClass="inputf_def" Width="170px"></asp:TextBox>
                                    </span><span class="titletext_default">Event ID / Name:</span> <span class="inputfieldright_default">
                                        <asp:TextBox runat="server" ID="txtevent" CssClass="inputf_def" Width="170px">
                                        </asp:TextBox>
                                    </span>
                                </p>
                                <p>
                                    <img src="../../Images/specer.gif" width="700px" height="5px" /></p>
                                <p class="lgtgrayboxrow_cl">
                                    <span class="titletext_default">Date Range:</span> <span class="dateinputfldnowidth_cl">
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputf_def" Width="80px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="clextStartDate" TargetControlID="txtStartDate"
                                            PopupButtonID="imgCalendarStart" Animated="true" Format="MM/dd/yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </span><span class="calendarcntrl_default">
                                        <asp:ImageButton ID="imgCalendarStart" runat="server" ImageUrl="~/App/Images/calendar-icon.gif"
                                            CssClass=""></asp:ImageButton>
                                    </span><span class="dateinputfldnowidth_cl">
                                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="inputf_def" Width="80px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="clextEndDate" TargetControlID="txtEndDate"
                                            PopupButtonID="imgCalendarEnd" Animated="true" Format="MM/dd/yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </span><span class="calendarcntrl_default">
                                        <asp:ImageButton ID="imgCalendarEnd" runat="server" ImageUrl="~/App/Images/calendar-icon.gif"
                                            CssClass=""></asp:ImageButton>
                                    </span><span class="righttitletxt_murf">Uploaded By:</span> <span class="inputfieldright_default">
                                        <asp:DropDownList ID="ddluploadedby" runat="server" CssClass="inputf_def" Width="170px">
                                        </asp:DropDownList>
                                    </span>
                                </p>
                                <p>
                                    <img src="../../Images/specer.gif" width="700px" height="5px" /></p>
                                <p class="lgtgrayboxrow_cl">
                                    <span class="titletext_default">Status:</span> <span class="inputfieldright_default">
                                        <asp:DropDownList ID="ddlstatus" runat="server" CssClass="inputf_def" Width="120px">
                                            <asp:ListItem Text="Status" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Has Errors" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </span>
                                </p>
                                <p>
                                    <img src="/App/Images/specer.gif" width="740px" height="5px" /></p>
                            </div>
                            <div class="lgtgraybox_cl">
                                <span class="buttoncon_default">
                                    <asp:ImageButton ID="ibtnSearch" OnClientClick="return CheckSearchClick();" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                        OnClick="ibtnSearch_Click" /></span> <span class="buttoncon_default">
                                            <asp:ImageButton ID="ibtnReset" runat="server" OnClientClick="return ResetAll();"
                                                ImageUrl="~/App/Images/reset-btn.gif" /></span>
                            </div>
                            <p class="grayboxbotbg_cl">
                                <img src="/App/Images/specer.gif" width="746" height="4" /></p>
                        </div>
                        <p>
                            <img src="/App/Images/specer.gif" width="740px" height="5px" /></p>
                        <p class="divmainbody_cd">
                            <span class="orngheadtxt16_default" style="float: left"> 
                                <span style="float:left;">Uploaded Files&nbsp;</span> 
                                <span class="blueheadtxt_crlist" style="float: left; padding-top:4px; font-size:12px; vertical-align:middle;" runat="server" id="spnumreordsound"></span>
                            </span>
                            <span class="rightlnktxt_cl">
                                <asp:DropDownList ID="ddlRecords" AutoPostBack="true" CssClass="inputf_def" Width="50px"
                                    runat="server" OnSelectedIndexChanged="ddlRecords_SelectedIndexChanged">
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    <asp:ListItem Value="40">40</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                </asp:DropDownList>
                            </span><span class="rightlnktxt_cl" style="padding-top: 3px">Records Per Page:&nbsp;</span>
                        </p>
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                        <p class="graylinefull_default">
                            <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                        <p>
                            <img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
                    </div>
                </div>
                <div>
                    <img src="../../Images/specer.gif" width="740px" height="10px" /></div>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="2px" /></p>
            <div id="divUploadResults" runat="server" class="main_area_bdrnone">
                <div class="grayboxtop_cl">
                    <p class="blueboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746px" height="6px" /></p>
                    <div style="float: left; width: 746px">
                        <asp:GridView ID="dguploadresults" runat="server" CssClass="gridjobp" AutoGenerateColumns="false"
                            GridLines="None" AllowPaging="true" PageSize="10" OnPageIndexChanging="dguploadresults_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="UploadZipInfoID" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        File Details
                                        <br />
                                        Sort:
                                        <asp:LinkButton runat="server" ID="lnkSortFile" CommandName="Sort" CommandArgument="FileName"
                                            Text="FileName" OnClick="lnkSortFile_Click"></asp:LinkButton>|
                                        <asp:LinkButton runat="server" ID="lnkSortDate" CommandName="Sort" CommandArgument="UploadDate"
                                            Text="Date" OnClick="lnkSortFile_Click"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="<%# DataBinder.Eval(Container.DataItem, "FilePath")%>" target="_blank">
                                            <%# DataBinder.Eval(Container.DataItem, "FileName")%>
                                        </a>
                                        <br />
                                        Size:<%# DataBinder.Eval(Container.DataItem, "FileSize")%>MB
                                        <br />
                                        Uploaded:
                                        <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "UploadDate")).ToShortDateString() %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Details">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Host")%>
                                        <br />
                                        on
                                        <%# DataBinder.Eval(Container.DataItem, "EventDate")%>
                                        <br />
                                        Customers Screened:<%# DataBinder.Eval(Container.DataItem, "CustomerScreened")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Uploaded By">
                                    <ItemTemplate>
                                        <span>
                                            <%# DataBinder.Eval(Container.DataItem, "TechnicianName")%>
                                        </span>
                                        <br />
                                        <span class="lgtgraytxt_default"><b>
                                            <%# DataBinder.Eval(Container.DataItem, "HoursAfterEvent")%>
                                        </b>hours
                                            <br />
                                            after event
                                            <br />
                                            completion</span></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <span class="greentxt_default">Success (<%# DataBinder.Eval(Container.DataItem, "SuccessRate")%>%)</span>
                                        <br />
                                        <span>Total Record: <a href='TechnicianEventCustomerResult.aspx?AllRecordsEventID=<%# DataBinder.Eval(Container.DataItem, "EventID")%>'>
                                            <%# DataBinder.Eval(Container.DataItem, "TotalRecords")%>
                                        </a>
                                            <br />
                                            Fail Record: <a href='TechnicianEventCustomerResult.aspx?FailedRecordsEventID=<%# DataBinder.Eval(Container.DataItem, "EventID")%>'>
                                                <%# DataBinder.Eval(Container.DataItem, "FailRecords")%>
                                            </a>
                                            <br />
                                            Record Not In Zip: <a href='TechnicianEventCustomerResult.aspx?NotInFileRecordsEventID=<%# DataBinder.Eval(Container.DataItem, "EventID")%>'>
                                                <%# DataBinder.Eval(Container.DataItem, "RecordsNotInZip")%>
                                            </a></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event">
                                    <ItemTemplate>
                                        Upload:<%# DataBinder.Eval(Container.DataItem, "UploadTime")%>
                                        mins
                                        <br />
                                        Process:
                                        <%# DataBinder.Eval(Container.DataItem, "ParseTime")%>
                                        mins
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <span><%# DataBinder.Eval(Container.DataItem, "LogURL")%></span>
                                        <br />
                                        <a href='TechnicianEventCustomerResult.aspx?AllRecordsEventID=<%# DataBinder.Eval(Container.DataItem, "EventID")%>'>Results </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="row1a" />
                            <RowStyle CssClass="row2a" />
                            <AlternatingRowStyle CssClass="row3a" />
                        </asp:GridView>
                    </div>
                    <p class="blueboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746px" height="6px" /></p>
                </div>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="20px" /></p>
        </div>
    </div>
</asp:Content>

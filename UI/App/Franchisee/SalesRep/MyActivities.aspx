<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    CodeBehind="MyActivities.aspx.cs" Inherits="HealthYes.Web.App.Franchisee.SalesRep.MyActivities" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="messages" TagPrefix="messagecontrol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="JQueryKit" runat="server" IncludeJQueryUI="true" />

    <script language="javascript" type="text/javascript">
        $.ajaxSetup({ cache: false });
        var activityStatus;
        //var currentActivityUpdate;
        function MarkActivity(currentActivity)
        {
            
            var activityId = $(currentActivity).parents('tr').find('.activity-id').html();
            var activityType = $(currentActivity).parents('tr').find('.activity-type').html();
            var activityStatusCheck = $(currentActivity).parents('tr').find('.Activity-Status').html(); 
            var ImageIcon = $(currentActivity).parents('tr').find('.Mark-UnMark');
            activityStatus = activityStatusCheck;
            activityType = jQuery.trim(activityType);
                        
            if (activityStatus=='True' || activityStatus=='true')
            {
                activityStatus=false;
                $(currentActivity).parents('tr').find('.Activity-Status').html('false');
                $(ImageIcon).attr("src", "/App/Images/flag-orng.gif");
                $(currentActivity).parents('tr').find('td').removeClass('strikethru');
                $(currentActivity).parents('tr').find('td').removeClass('rostyle');
                $(currentActivity).parents('tr').removeClass('strikethru');
                $(currentActivity).parents('tr').removeClass('rostyle');
                $(currentActivity).parents('tr').find('td').addClass('rostyle');
                BindAllLink(currentActivity,'false');
            }
            else
            {
               $(currentActivity).parents('tr').find('.Activity-Status').html('true');
               activityStatus=true;
               $(ImageIcon).attr("src", "/App/Images/icon_check.png");
               $(currentActivity).parents('tr').find('td').removeClass('strikethru');
               $(currentActivity).parents('tr').find('td').removeClass('rostyle');
               $(currentActivity).parents('tr').removeClass('strikethru');
               $(currentActivity).parents('tr').removeClass('rostyle');
               $(currentActivity).parents('tr').find('td').addClass('strikethru');
               BindAllLink(currentActivity,'true');
            }
            var activityTypeValue = '';
            if (activityType == 'Task')
            activityTypeValue = '<%=(int)Falcon.App.Core.Enum.ActivityType.Task %>';
            else if (activityType == 'Call')
            activityTypeValue = '<%=(int)Falcon.App.Core.Enum.ActivityType.Call %>';
            else if (activityType == 'Meeting')
            activityTypeValue = '<%=(int)Falcon.App.Core.Enum.ActivityType.Meeting %>';

            var messageUrl = '<%=ResolveUrl("~/App/Controllers/ActivityController.asmx/MarkActivity")%>';

            var parameter = "{'activityType':" + activityTypeValue + ",";
            parameter += "'activityId':" + activityId + ",";
            parameter += "'markActivity':" + activityStatus + "}";
           
            InvokeAsyncServiceMark(messageUrl, parameter); 
                       
        }
       function BindAllLink(currentActivity,activityStatus)
        {
           var activityId = $(currentActivity).parents('tr').find('.activity-id').html();
            var activityType = $(currentActivity).parents('tr').find('.activity-type').html();
            activityType = jQuery.trim(activityType);
                        
            if (activityStatus=='true' || activityStatus=='True')
            {
                $(currentActivity).parents('tr').find('.delete-link').attr("href",'javascript:void(0)');
                var Rows = $(currentActivity).parents('tr');
                Rows.find('td').find('a').attr("href", "javascript:void(0)");                
                //Rows.find('td').find('a').attr('disabled','disabled');                
            }
            else 
            {
                var editActivityLink= $(currentActivity).parents('tr').find('.edit-activity-link').html();
                var activityLink = $(currentActivity).parents('tr').find('.activity-link').html();
                var contactId = $(currentActivity).parents('tr').find('.contact-id').html();
                editActivityLink = jQuery.trim(editActivityLink);              
                activityLink = jQuery.trim(activityLink);
                
                editActivityLink = editActivityLink.replace('&amp;','&');
                activityLink = activityLink.replace('&amp;','&');
                
                $(currentActivity).parents('tr').find('.edit-link').attr("href",editActivityLink);              
                //$(currentActivity).parents('tr').find('.edit-link').attr('disabled','');
                             
                $(currentActivity).parents('tr').find('.delete-link').attr("href",'javascript:void(0)'); 
                
                $(currentActivity).parents('tr').find('.delete-link').attr('disabled','');                
                
                $(currentActivity).parents('tr').find('.related-to-link').attr("href",activityLink);                
                //$(currentActivity).parents('tr').find('.related-to-link').attr('disabled','');
                
                
                $(currentActivity).parents('tr').find('.contact-link').attr("href",'/App/Franchisor/AddNewContact.aspx?ContactID=' + contactId);                
                //$(currentActivity).parents('tr').find('.contact-link').attr('disabled','');
                    
            }
        }
        function InvokeAsyncServiceMark(messageUrl, parameter)
        {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function(result)
                {
                    //$(currentActivity).parents('tr').find('.Activity-Status').html(activityStatus);
                    //location.reload(true);
                },
                error: function(a, b, c)
                {
                 alert('Oops some error occured please try after some times.');                    
                }
            });
        }
    </script>

    <script type="text/javascript" language="javascript">
         function DeleteActivity(currentActivity)
        {
            var activityId = $(currentActivity).parents('tr').find('.activity-id').html();
            var activityType = $(currentActivity).parents('tr').find('.activity-type').html();
            activityType = jQuery.trim(activityType);            
            var activityStatusCheck = $(currentActivity).parents('tr').find('.Activity-Status').html(); 
            activityStatus = activityStatusCheck;
            activityType = jQuery.trim(activityType);
                        
            if (activityStatus!='True' && activityStatus!='true')
            {
                if (confirm('Do You really want to delete this' + activityType + '.'))
                {
                    var activityTypeValue = '';
                    if (activityType == 'Task')
                        activityTypeValue = '<%=(int)Falcon.App.Core.Enum.ActivityType.Task %>';
                    else if (activityType == 'Call')
                        activityTypeValue = '<%=(int)Falcon.App.Core.Enum.ActivityType.Call %>';
                    else if (activityType == 'Meeting')
                        activityTypeValue = '<%=(int)Falcon.App.Core.Enum.ActivityType.Meeting %>';

                    var messageUrl = '<%=ResolveUrl("~/App/Controllers/ActivityController.asmx/DeleteActivity")%>';

                    var parameter = "{'activityType':" + activityTypeValue + ",";
                    parameter += "'activityId':" + activityId + "}";

                    InvokeAsyncService(messageUrl, parameter);
                }
           }
        }

        function InvokeAsyncService(messageUrl, parameter)
        {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function(result) {
                    location.reload(true);
                },
                error: function(a, b, c) {
                    alert('Oops some error occured please try after some times.');
                }
            });
        }
    </script>

    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>

    <script language="javascript" type="text/javascript">

        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        function requestFailed()
        { }

        var pagenumber = 1;
        var pagesize = 10;
        var issearch = false;
        var curviewmode = 'ALL';        
        function LoadActivityTable(viewmode)
        {
            pagenumber = 1;
            pagesize = 10;
            curviewmode = viewmode;
            if (issearch == true)
                SearchActivityGridTable();
            else
                GetActivityGridTable();
        }

        function LoadActivityTableonPageSizeChange() {

            document.getElementById('<%= this._firstLoad.ClientID %>').value='0';
            var newpagesize = document.getElementById('<%= this.ddlRecords.ClientID %>').options[document.getElementById('<%= this.ddlRecords.ClientID %>').selectedIndex].text;
            //var newpagenum = (((pagenumber - 1) * pagesize) / newpagesize) + 1;
            var newpagenum = 1;

            pagenumber = newpagenum;
            pagesize = newpagesize;

            if (issearch == true)
                SearchActivityGridTable();
            else
                GetActivityGridTable();
        }

        function LoadActivityTableonPageChange(selpagenumber)
        {
            document.getElementById('<%= this._firstLoad.ClientID %>').value='0';
            pagenumber = selpagenumber;

            if (issearch == true)
                SearchActivityGridTable();
            else
                GetActivityGridTable();
                
        }

        function GetActivityGridTable()
        {
            document.getElementById('divActivities').disabled = 'disabled';
            document.getElementById('spLoading').style.display = 'block';            
            var salesrepid = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>';

            postRequest.url = "Async_MyActivities.aspx?SalesRepID=" + salesrepid + "&PageNumber=" + pagenumber + "&PageSize=" + pagesize + "&ViewMode=" + curviewmode + "&SearchMode=true";
            postRequest.successCallback = SetGrid;
            postRequest.failureCallback = requestFailed();
            postRequest.post("");
        }

        function SearchActivityGridTable()
        {
            document.getElementById('divActivities').disabled = 'disabled';
            document.getElementById('spLoading').style.display = 'block';
            var salesrepid = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>';

            postRequest.url = "Async_MyActivities.aspx?SalesRepID=" + salesrepid + "&PageNumber=" + pagenumber + "&PageSize=" + pagesize + "&ViewMode=" + curviewmode + "&SearchMode=true";

            if (document.getElementById('<%= this.txtStartDate.ClientID %>').value.length > 0)
                postRequest.url = postRequest.url + "&DateFrom=" + document.getElementById('<%= this.txtStartDate.ClientID %>').value;

            if (document.getElementById('<%= this.txtEndDate.ClientID %>').value.length > 0)
                postRequest.url = postRequest.url + "&DateTo=" + document.getElementById('<%= this.txtEndDate.ClientID %>').value;

            if (document.getElementById('<%= this.txtrelkeyword.ClientID %>').value.length > 0) {
                postRequest.url = postRequest.url + "&RelatedKeyword=" + document.getElementById('<%= this.txtrelkeyword.ClientID %>').value;
                postRequest.url = postRequest.url + "&RelatedMode=" + document.getElementById('<%= this.ddlRelatedMode.ClientID %>').options[document.getElementById('<%= this.ddlRelatedMode.ClientID %>').selectedIndex].text;
            }
            else {
                postRequest.url = postRequest.url + "&RelatedMode=" + document.getElementById('<%= this.ddlRelatedMode.ClientID %>').options[document.getElementById('<%= this.ddlRelatedMode.ClientID %>').selectedIndex].text;
            }


            if (document.getElementById('<%= this.txtkeyword.ClientID %>').value.length > 0) postRequest.url = postRequest.url + "&Keyword=" + document.getElementById('<%= this.txtkeyword.ClientID %>').value;
            document.getElementById('<%= this._firstLoad.ClientID %>').value='0';
            postRequest.successCallback = SetGrid;
            postRequest.failureCallback = requestFailed();
            postRequest.post("");
            return false;
        }

        function SetGrid(httpRequest)
        {
            document.getElementById('divActivities').disabled = '';
            document.getElementById('divActivities').innerHTML = httpRequest.responseText;            
            document.getElementById('spLoading').style.display = 'none';
            if(document.getElementById('<%= this._firstLoad.ClientID %>').value =='0')
            {
                StrickThrough();
                document.getElementById('<%= this._firstLoad.ClientID %>').value='1';
            }
            
        }

        function resetsearchpanel() {
            document.getElementById('<%= this.txtStartDate.ClientID %>').value = '';
            document.getElementById('<%= this.txtEndDate.ClientID %>').value = '';
            document.getElementById('<%= this.ddlRelatedMode.ClientID %>').selectedIndex = 0;
            document.getElementById('<%= this.txtrelkeyword.ClientID %>').value = '';
            document.getElementById('<%= this.txtkeyword.ClientID %>').value = '';            
            issearch = false;
            LoadActivityTable('All');
            return false;
        }
        
    </script>

    <div class="wrapper_inpg">
        <h1 class="left" id="sptitle" runat="server">
            My Activities</h1>
        <div class="rgt">			
            <span class="lgndwrap"><img src="/App/Images/icon-meeting.gif" alt="Meeting" title="Meeting" />  Meeting </span>
                   <span class="lgndwrap">  <img src="/App/Images/icon-task.gif" alt="Task" title="Task" /> Task</span>
                        <span class="lgndwrap"> <img src="/App/Images/icon-call.gif" alt="Call" title="Call" /> Call </span>
				<span class="lgndwrap"> <img src="/App/Images/flag-orng.gif" alt="" /> Not Completed Activity</span>
				<span class="lgndwrap"> <img src="/App/Images/icon_check.png" alt="" /> Completed Activity</span>
        </div>
        <div class="hr left">
        </div>
        <h3 class="left">
            Today's Activities</h3>
        <div class="main_area_bdrnone">
            <div class="scrlldiv" id="todayActivityDiv" runat="server">
            <asp:GridView runat="server" ID="todayactivities" AutoGenerateColumns="false" CssClass="dgmyact select-table-today"
                OnRowDataBound="todayactivities_RowDataBound" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                        <span class="edit-activity-link" style="display: none"><%#DataBinder.Eval(Container.DataItem, "ProspectHostEventLink")%></span>
                    <span class="activity-link" style="display: none"><%#DataBinder.Eval(Container.DataItem, "ActivityLink")%></span>
                    <span class="contact-id" style="display: none"><%#DataBinder.Eval(Container.DataItem, "ContactID")%></span>
                            <span class="activity-id" style="display: none">
                                <%#DataBinder.Eval(Container.DataItem, "ActivityID")%></span> <span class="activity-type"
                                    style="display: none">
                                    <%#DataBinder.Eval(Container.DataItem, "ActivityType")%></span> <span id="ActivityStatus"
                                        runat="server" class="Activity-Status" style="display: none">
                                        <%#DataBinder.Eval(Container.DataItem, "ActivityStatus")%></span>
                            <%# DataBinder.Eval(Container.DataItem, "ActivityTypeImage")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Due On">
                        <ItemTemplate>
                            <span class="redtxt_default">
                                <%# DataBinder.Eval(Container.DataItem, "ActivityTime")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "Subject")%><%# DataBinder.Eval(Container.DataItem, "ContactWith")%>
                            <a class="contact-link" href='/App/Franchisor/AddNewContact.aspx?ContactID=<%# DataBinder.Eval(Container.DataItem, "ContactID") %>'>
                                <%# DataBinder.Eval(Container.DataItem, "Contact")%>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Related To">
                        <ItemTemplate>
                            <a class="related-to-link" href='<%# DataBinder.Eval(Container.DataItem, "ProspectHostEventLink") %>'>
                                <%# DataBinder.Eval(Container.DataItem, "Prospect")%>
                            </a>&nbsp; (<%# DataBinder.Eval(Container.DataItem, "ActivityText")%>)
                            <%# DataBinder.Eval(Container.DataItem, "EventStatus")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
						<div style="width:90px">
                            <a class="edit-link" href='<%# DataBinder.Eval(Container.DataItem, "ActivityLink") %>'>Edit</a> |
                            <a class="delete-link" href='javascript:void(0);' onclick="javascript:DeleteActivity(this);">
                                Delete</a><a href="javascript:void(0)">
                                    <img src="/App/Images/flag-orng.gif" alt="Mark Activity" title="Mark Activity"
                                        id="markedUnmarked" runat="server" class="Mark-UnMark" onclick="javascript:MarkActivity(this);" /></a>
							</div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="rostyle" />
                <HeaderStyle CssClass="hdrstyle" Font-Size="11px" />
                <AlternatingRowStyle CssClass="rostyle" />
            </asp:GridView>
            </div>
            <div id="_noRecordFoundTodayActivity" runat="server" style="display: none">
                <br /><messagecontrol:messages id="todayActivityMessage" runat="server" />
            </div>            
        </div>
        
        <h3 class="lheight">Search/Filter</h3>
        
        <div class="chklistdiv" style="width: 737px">
            <div class="boxrow">
                <label>
                    Start Date:</label>
                <asp:TextBox ID="txtStartDate" runat="server" Width="80px" CssClass="mrgnrgt date-picker-from"
                    MaxLength="100" />
                <label>
                    End Date:</label>
                <asp:TextBox ID="txtEndDate" runat="server" Width="80px" CssClass="mrgnrgt date-picker-to"
                    MaxLength="12" />
                <label>
                    Related To:</label>
                <asp:DropDownList ID="ddlRelatedMode" runat="server" Width="100px">
                    <asp:ListItem Text="All"></asp:ListItem>
                    <asp:ListItem Text="Prospect"></asp:ListItem>
                    <asp:ListItem Text="Host"></asp:ListItem>
                    <asp:ListItem Text="Contact"></asp:ListItem>
                    <asp:ListItem Text="Event"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtrelkeyword" runat="server" Width="200px"></asp:TextBox>
            </div>
            <div class="boxrow" style="margin-top: 5px">
                <div class="left">
                    <label class="left" style="width: 60px">
                        Keywords:</label>
                    <asp:TextBox ID="txtkeyword" runat="server" Width="150px" CssClass="mrgnrgt" MaxLength="255" />
                </div>
                <div class="rgt">
                    <asp:Button ID="ireset" OnClientClick="javascript:return resetsearchpanel();" Text="Clear"
                        CssClass="button clear-button" runat="server" Width="50px" />
                    <asp:Button ID="ibtnSearch" OnClientClick="javascript:issearch = true;return SearchActivityGridTable();"
                        Text="Filter" CssClass="button" runat="server" Width="50px" />
                </div>
            </div>
        </div>
        <div class="main_area_bdrnone mt_medium">
            <h3 class="left">
                Activities</h3>
            <span style="float: right"><span class="rightlnktxt_cl">
                <asp:DropDownList ID="ddlRecords" CssClass="inputf_def" onchange="LoadActivityTableonPageSizeChange();"
                    Width="50px" runat="server">
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="40">40</asp:ListItem>
                    <asp:ListItem Value="50">50</asp:ListItem>
                </asp:DropDownList>
            </span><span class="rightlnktxt_cl" style="padding-top: 3px;">Records Per Page :&nbsp;</span>
            </span>
            <div class="left" style="width:746px">
            <div class="divmainbody_cd">
                <span id="spLoading" style="float: left; display: none;"><span style="float: left;
                    padding-right: 5px" class="blktext14px_default">Loading...</span> <span style="float: left">
                        <img src="/App/Images/loading.gif" /></span> </span>
            </div>
            <div id="divActivities" class="griddivnew_default mt_img">
            </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="_firstLoad" Value="0" />
    <script type="text/javascript">
    
    function StrickThrough()
    {
        //debugger;
        var Grid = $('.all-activity-table');        
        var Rows = Grid.find('.strikethru');
        Rows.removeClass('strikethru');
        Rows.find('td').removeClass('strikethru');
        Rows.addClass('strikethru');
        Rows.find('td').addClass('strikethru');
        // disable activity on load
        Rows.find('td').find('a').attr("href", "javascript:void(0)");
        //Rows.find('td').find('a').attr('disabled','disabled');
     }
     
    function StrickThroughToday()
    {
        var Grid = $('.select-table-today');        
        var Rows = Grid.find('.strikethru');
        Rows.removeClass('strikethru');
        Rows.find('td').removeClass('strikethru');
        Rows.addClass('strikethru');
        Rows.find('td').addClass('strikethru');
        
        // disable activity on load
        Rows.find('td').find('a').attr("href", "javascript:void(0)");
        //Rows.find('td').find('a').attr('disabled','disabled');
     }
    $(document).ready(function()
    {
          
            var currentDate = new Date();
            currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1);
            $(".date-picker-from").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $(".date-picker-to").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $(".date-picker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });
            StrickThroughToday();
        });
        
    
    </script>

</asp:Content>

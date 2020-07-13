<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_ViewMeetings" Codebehind="ViewMeetings.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
    String.prototype.trim = function() 
    {
        a = this.replace(/^\s+/, '');
        return a.replace(/\s+$/, '');
    };
    
    function validateSearch()
    {
        var txtSearchMeeting=document.getElementById("<%=this.txtSearchMeeting.ClientID %>");
        if(txtSearchMeeting.value.trim()=="")
        {
            alert("Please enter text to search.");
            return false;
        }
        return true;
    }
</script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Meetings</span>
                    <span class="headingright_default" style="display:none;">
                        <asp:LinkButton ID="btnAddMeeting" runat="server" Text="+ Add new Meeting" OnClick="btnAddMeeting_Click" /></span>
                </div>
            </div>
            <p><img src="../Images/specer.gif" width="700px" height="5px" alt="" /></p>
            <%--<div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server">
            </div>--%>
            <div class="grayboxtop_cl">
                <p class="grayboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                <p class="grayboxheader_cl">
                    <span style="float: left">Filter/Search</span></p>
                <div class="lgtgraybox_cl">
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span class="titletextnowidth_default">Search Meeting:</span> <span class="inputfieldright_default">
                            <asp:TextBox ID="txtSearchMeeting" runat="server" CssClass="inputf_def" Width="150px"></asp:TextBox>
                        </span><span class="button_con_nowidth">
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif" OnClientClick="return validateSearch();" onclick="ibtnSearch_Click" />
                        </span>
                    </p>
                    <p class="lgtgrayboxrow_cl">
                        <img src="/App/Images/specer.gif" width="10" height="6" alt="" /></p>
                </div>
                <p class="grayboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="4" /></p>
            </div>
            <p>
                <img src="../Images/specer.gif" width="700px" height="10px" alt="" /></p>
            <div class="divmainbody_cd">
                <span class="blkheadtxt_regcust" id="Span1" runat="server" style="float: left;">Total:</span>
                <span class="blueheadtxt_regcust" id="Span2" runat="server" style="float: left;">10 Results Found</span>
            </div>
            <div style="float: left; width: 746px" id="divGrd" runat="server">
                <p class="blueboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" alt="" /></p>
                <div style="float: left; width: 746px">
                    <asp:GridView ID="dgmeetings" runat="server" CssClass="divgrid_cl" AutoGenerateColumns="false"
                        GridLines="None" AllowPaging="true" PageSize="5" AllowSorting="true" EnableSortingAndPagingCallbacks="false"
                        OnPageIndexChanging="dgmeetings_PageIndexChanging" OnSorting="dgmeetings_Sorting">
                        <Columns>
                           <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                <ItemTemplate>
                                    <a href='/App/Franchisor/AddMeeting.aspx?ContactMeetingID=<%#DataBinder.Eval(Container.DataItem, "ContactMeetingID")%>&Parent=ViewMeeting'>
                                    <%#DataBinder.Eval(Container.DataItem, "Subject")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ProspectName" HeaderText="Prospect/Host Name" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                            <asp:BoundField DataField="StartTime" HeaderText="Start Time" />
                            <asp:BoundField DataField="Duration" HeaderText="Duration" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Venue" HeaderText="Venue" />
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <RowStyle CssClass="row2" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
            </div>
            <div class="divmainbody_cd">
                <p><img src="../Images/specer.gif" width="700px" height="10px" alt="" /></p>
         </div>
        </div>
    </div>
</asp:Content>

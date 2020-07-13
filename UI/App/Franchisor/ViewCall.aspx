<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_ViewCall" Codebehind="ViewCall.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<style type="text/css">
    /*---------- bubble tooltip -----------*/
    a.tt
    {
        position: relative;
        z-index: 24;
        color: #287AA8;
        font-weight: normal;
        text-decoration: none;
    }
    a.tt span
    {
        display: none;
    }
    /*background:; ie hack, something must be changed in a for ie to execute it*/
    a.tt:hover
    {
        z-index: 25;
        color: #ff6600;
        text-decoration: none;
    }
    a.tt:hover span.tooltip
    {
        display: block;
        position: absolute;
        top: 0px;
        left: 0;
        padding: 15px 0 0 0;
        width: 200px;
        color: #287AA8;
        text-align: left;
        filter: alpha(opacity:90);
        khtmlopacity: 0.90;
        mozopacity: 0.90;
        opacity: 0.90;
        text-decoration: none;
    }
    a.tt:hover span.top
    {
        display: block;
        padding: 30px 8px 0;
        background: url(/App/Images/bubble.gif) no-repeat top;
        text-decoration: none;
    }
    a.tt:hover span.middle
    {
        /* different middle bg for stretch */
        display: block;
        padding: 0 8px;
        background: url(/App/Images/bubble_filler.gif) repeat bottom;
        color: #000;
        text-decoration: none;
    }
    a.tt:hover span.bottom
    {
        display: block;
        padding: 3px 8px 10px;
        color: #ff6600;
        background: url(/App/Images/bubble.gif) no-repeat bottom;
        text-decoration: none;
    }
</style>
<script language="javascript" type="text/javascript">
    function ConfirmDelete() {
        var answer = confirm("Are you sure you want to delete the call ? ")
        return answer;
    }
    String.prototype.trim = function() 
    {
        a = this.replace(/^\s+/, '');
        return a.replace(/\s+$/, '');
    };
    
    function validateSearch()
    {
        var txtSearchCall=document.getElementById("<%=this.txtSearchCall.ClientID %>");
        if(txtSearchCall.value.trim()=="")
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
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Calls</span>
                    <span class="headingright_default" style="display: none;">
                        <asp:LinkButton ID="btnAddCall" runat="server" Text="+ Add new Call" OnClick="btnAddCall_Click" /></span>
                </div>
            </div>
            <p>
                <img src="../Images/specer.gif" width="700px" height="5px" alt="" /></p>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="grayboxtop_cl">
                <p class="grayboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                <p class="grayboxheader_cl">
                    <span style="float: left">Filter/Search</span></p>
                <div class="lgtgraybox_cl">
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span class="titletextnowidth_default">Search Call:</span> <span class="inputfieldright_default">
                            <asp:TextBox ID="txtSearchCall" runat="server" CssClass="inputf_def" Width="150px"></asp:TextBox>
                        </span><span class="button_con_nowidth">
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif" OnClientClick="return validateSearch();"
                                OnClick="ibtnSearch_Click" />
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
                    <asp:GridView ID="dgcalls" runat="server" CssClass="divgrid_cl" AutoGenerateColumns="false"
                        GridLines="None" AllowPaging="true" PageSize="5" AllowSorting="true" EnableSortingAndPagingCallbacks="false"
                        OnPageIndexChanging="dgcalls_PageIndexChanging" OnSorting="dgcalls_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                <ItemTemplate>
                                    <a href='/App/Franchisor/AddCallProspect.aspx?ContactCallID=<%# DataBinder.Eval(Container.DataItem, "ContactCallID")%>&Parent=ViewCalls'>
                                        <%#DataBinder.Eval(Container.DataItem, "Subject")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="StartDate" HeaderText="Call Date" HtmlEncode="false"></asp:BoundField>
                            <asp:TemplateField HeaderText="Notes">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" class="tt" >Notes
                                        <span class="tooltip">
                                            <span class="top"></span>
                                            <span class="middle" id='spndefcursor<%# DataBinder.Eval(Container.DataItem, "ContactCallID")%>' onmouseover="changetodefault('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ContactCallID")%>');" onmouseout="changetopointer('spndefcursor<%# DataBinder.Eval(Container.DataItem, "ContactCallID")%>');">
                                                <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                            </span>
                                            <span class="bottom"></span>
                                        </span>                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem,"ContactName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="" ImageUrl="~/App/Images/delete.gif" OnClientClick="return ConfirmDelete();"
                                        OnClick="ibtnDelete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ContactCallID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <RowStyle CssClass="row2" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                <p class="blueboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" alt="" /></p>
            </div>
            <div class="divmainbody_cd">
                <p><img src="../Images/specer.gif" width="700px" height="10px" alt="" /></p>
         </div>
        </div>
        
    </div>
</asp:Content>

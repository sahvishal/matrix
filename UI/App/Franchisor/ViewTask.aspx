<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_ViewTask" Codebehind="ViewTask.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script language="javascript" type="text/javascript">
    String.prototype.trim = function() 
    {
        a = this.replace(/^\s+/, '');
        return a.replace(/\s+$/, '');
    };
    
    function validateSearch()
    {
        var txtSearchTask=document.getElementById("<%=this.txtSearchTask.ClientID %>");
        if(txtSearchTask.value.trim()=="")
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
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Task</span>                    
                    <span class="headingright_default" style="display:none;"><asp:LinkButton ID="btnAddTask" runat="server" Text="+ Add new Task" OnClick="btnAddTask_Click" /></span>
            </div>
           </div>
            <p><img src="../Images/specer.gif" width="700px" height="5px" alt="" /></p>
               
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server">
                </div>
                
              <div class="grayboxtop_cl">                
                <p class="grayboxtopbg_cl"><img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                <p class="grayboxheader_cl"><span style="float:left">Filter/Search</span></p>
                   <div class="lgtgraybox_cl">
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span class="titletextnowidth_default">Search Task:</span> 
                        
                        <span class="inputfieldright_default">
                            <asp:TextBox ID="txtSearchTask" runat="server" CssClass="inputf_def" Width="150px"></asp:TextBox>
                            </span>
						 <span class="button_con_nowidth">
                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif" OnClientClick="return validateSearch();" onclick="ibtnSearch_Click" />                      
                    </span>
                    </p>
                  <p class="lgtgrayboxrow_cl"><img src="/App/Images/specer.gif" width="10" height="6" alt="" /></p>     
                       
                    
                    </div>
                    <p class="grayboxbotbg_cl"> <img src="/App/Images/specer.gif" width="746" height="4" /></p>
               </div> 
             <p><img src="../Images/specer.gif" width="700px" height="10px" alt="" /></p>
             <div class="divmainbody_cd">
                 <span class="blkheadtxt_regcust" id="Span1" runat="server" style="float: left;">Total:</span>
                 <span class="blueheadtxt_regcust" id="Span2" runat="server" style="float: left;"> 10 Results Found</span>
             </div>  
                
             <div style="float:left; width:746px">
                 <p class="blueboxtopbg_cl"><img src="/App/Images/specer.gif" width="746" height="5" alt="" /></p>
                <div style="float:left; width:746px">
                    <asp:GridView ID="dgviewtask" runat="server" CssClass="divgrid_cl" AllowSorting="true" EnableSortingAndPagingCallbacks="false" AutoGenerateColumns="false" GridLines="None" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgviewtask_PageIndexChanging"
                        OnSorting="dgviewtask_Sorting">
                        <Columns>
                            <asp:BoundField Visible="False"></asp:BoundField>
                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                <ItemTemplate>
                                    <a href='/App/Franchisor/AddTask.aspx?TaskID=<%#DataBinder.Eval(Container.DataItem, "TaskID")%>&Parent=ViewTask'>
                                        <%#DataBinder.Eval(Container.DataItem, "Subject")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DueDate" HeaderText="Due Date">
                            </asp:BoundField>
                            <asp:BoundField DataField="DueTime" HeaderText="Due Time" HtmlEncode="false"></asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Priority" HeaderText="Priority" />
                            <asp:BoundField DataField="Notes" HeaderText="Notes" />
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <RowStyle CssClass="row2" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                  <div style=" float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:none;" id="dvNoRecordFound" runat="server">
                    <div class="divnoitemfound_custdbrd" style="margin-top:0px;">
                        <p class="divnoitemtxt_custdbrd">
                            <span class="orngbold18_default">No Records Found</span>
                        </p>
                    </div>
                </div>    
            </div>
        </div>
    </div>
</asp:Content>

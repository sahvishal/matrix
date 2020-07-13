<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_ViewTemplate" Codebehind="ViewTemplate.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
    
    function GridMasterCheck()
    {
       Grid_MasterCheckBoxClick("<%= this.dgviewtemplates.ClientID %>");
    }
    
    function GridChildCheck()
    {
    //debugger
        Grid_ChildCheckBoxClick("<%= this.dgviewtemplates.ClientID %>");
            
    }  
 </script>
<div class="mainbody_outer">
        <div class="mainbody_inner">        
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Templates</span>
                    <span class="headingright_default"><a href="ScheduleTemplate.aspx">Add New Template</a></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <%--<div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
                <div class="mainbody_titletxtleft">
                    <span runat="server" id="sptitle">View Templates</span>
                  </div>
               
               <div class="mainbody_titlelnkright">
                <a href="ScheduleTemplate.aspx">Add New Template</a></div>
                <div class="headngrightlist_sne"> <asp:DropDownList ID="DropDownList1" runat="server" CssClass="inputlist_def" Width="150px"> <asp:ListItem>Assigned to me</asp:ListItem>  </asp:DropDownList></div>
            </div>
            <div class="mainbody_inner_right"> </div>--%>
            
            
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdrnone">
            
            <div style="float:left; width:746px">
             <p class="blueboxtopbg_cl"><img src="/App/Images/specer.gif" width="746" height="5" /></p>
            <div style="float:left; width:746px">
            <asp:GridView ID="dgviewtemplates" AllowSorting="True" 
                    OnSorting="dgviewtemplates_Sorting"  runat="server" CssClass="divgrid_cl" 
                    EnableSortingAndPagingCallbacks="False" AutoGenerateColumns="false" 
                    GridLines="None" PageSize="8" OnRowDataBound="dgviewtemplates_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate> 
	                            <input type="checkbox" id="chklistname1" runat="server" />
	                        </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Template Name" SortExpression="TemplateName">
                            <ItemTemplate>
                                <a href='<%# (Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsGlobal")) == false) ? "ScheduleTemplate.aspx?TemplateID=" + DataBinder.Eval(Container.DataItem, "TemplateID") : "javascript:alert(\"Global Templates can not be edited.\");"  %>'><%# DataBinder.Eval(Container.DataItem, "TemplateName")%> </a>
                                
                            </ItemTemplate>                
                        </asp:TemplateField>
                        <asp:BoundField DataField="Global" HeaderText="Is Global">
                        </asp:BoundField>
                        <asp:BoundField DataField="Dateadded" HeaderText="Date Added" SortExpression="Dateadded"  HtmlEncode="true" DataFormatString="{0:MM/dd/yyyy hh:mm:ss tt}">
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="Status" HeaderText="Status">
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="row1" />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
            <p class="blueboxbotbg_cl"><img src="/App/Images/specer.gif" width="746" height="5" /></p>
            </div>
            </div>
            
            
            
            

</div>
</div>


</asp:Content>

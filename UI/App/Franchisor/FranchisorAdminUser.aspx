<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_FranchisorAdminUser" Codebehind="FranchisorAdminUser.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <script language="javascript" type="text/javascript">
    
    function GridMasterCheck()
    {
   
        Grid_MasterCheckBoxClick("<%= this.grdFAUser.ClientID %>");
        var btnEdit= document.getElementById("<%= this.btnEdit.ClientID %>");
        var objtemp = document.createElement("INPUT");
        var numcount2 = Grid_MultiSelect("<%= this.grdFAUser.ClientID %>", objtemp)
        if(numcount2 == 1)
        {
            
             btnEdit.disabled=false;
             btnEdit.src="/App/Images/edit_butt_master.gif";
        }
        else
        {
         btnEdit.disabled=true;
         btnEdit.src="/App/Images/edit-button-d.gif";
        }
    }
    
    function GridChildCheck()
    {////debugger
        Grid_ChildCheckBoxClick("<%= this.grdFAUser.ClientID %>");
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.grdFAUser.ClientID %>", objtemp);
        if(numcount == "1")
            Grid_EnableEditbutton("<%= this.btnEdit.ClientID %>");
        else
            Grid_DisableEditbutton("<%= this.btnEdit.ClientID %>");
                    
    }
    
    function validate(type)
    {
    //debugger
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.grdFAUser.ClientID %>", objtemp);
        
            if (numcount >=1 && (type=="Delete"))
            {
                var answer = confirm ("Are you sure you want to delete User(s) ? ")
                return answer;
            }
            else if (numcount==1 && (type=="Edit"))
            {
                 var answer = confirm ("Are you sure you want to Edit User ? ")
                return answer;
            }
            else if (numcount==0)
            {
                alert("Please select atleast one item from the grid");
                return false;
            }
       
    }
       
    </script>


<div class="mainbody_outer">
            <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Franchisor Admin User</span>
                    <span class="headingright_default"><asp:LinkButton ID="addNewAdminUser" runat="server" Text="+ Add new Admin User" OnClick="addNewAdminUser_Click"  /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            
                <%--<div class="mainbody_inner_left">
                </div>
                
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft">
                        Franchisor Admin User</div>
                    <div class="mainbody_titlelnkright">
                      <a href="javascript:showdiv()"> + Add new Admin User</a>
                        
                    </div>
                </div>
                
                <div class="mainbody_inner_right">
                </div>--%>
                <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server"></div> 
                 <%--******************* Buttons Row above Grid ***************** --%>
                <div class="divbuttonsrow">
                
                
                
                    <div class="master_buttons_row">
                        
                        
                        <div class="master_buttons_con" style="visibility:hidden; display:none;">
                            
                            <asp:ImageButton runat="server" ID="btnEdit" 
                                ImageUrl="~/App/Images/edit-button-d.gif" OnClick="btnEdit_Click" OnClientClick="return validate('Edit');" Enabled="false" />
                        </div>
                        
                                               
                        <div class="master_buttons_con">
                            
                            <asp:ImageButton runat="server" ID="btnDelete" OnClientClick="return validate('Delete');" ImageUrl="~/App/Images/del-button_master.gif"
                                 OnClick="btnDelete_Click" />
                        </div>
                        
                    </div>
                
                </div>
                
                <%--**********************************************************--%>
                <div style="float:left; width:746px">
                 <p class="blueboxtopbg_cl"><img src="/App/Images/specer.gif" width="746" height="5" /></p>
                <div style="float:left; width:746px">
                    <asp:GridView runat="server" ID="grdFAUser" AutoGenerateColumns="false" DataKeyNames="FranchisorFranchisorUserID"
                        CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdFAUser_RowDataBound"
                        EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdFAUser_PageIndexChanging" AllowSorting="True" OnSorting="grdFAUser_Sorting" >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="name" HeaderText="Name" SortExpression="name desc">
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Name" SortExpression="name asc">
                                <ItemTemplate>
                                    <a href='<%# this.ResolveUrl("~/App/Franchisor/AddFranchisorAdminUser.aspx?FranchisorFranchisorUserID=" + DataBinder.Eval(Container.DataItem,"FranchisorFranchisorUserID")) %>'>
                                    <%# DataBinder.Eval(Container.DataItem, "name")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="address" HtmlEncode="false" HeaderText="Address">
                            </asp:BoundField>
                            <asp:BoundField DataField="phonecell" HeaderText="Phone(Cell)">
                            </asp:BoundField>
                            <asp:BoundField DataField="FranchisorFranchisorUserID" Visible="False" />
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                 <p class="blueboxbotbg_cl"><img src="/App/Images/specer.gif" width="746" height="5" /></p>
                 </div>
                <div>
                <asp:HiddenField ID="hfFranchisorUserID" runat="server" />
                </div>
                
                
            </div>
        </div>
                    
</asp:Content>
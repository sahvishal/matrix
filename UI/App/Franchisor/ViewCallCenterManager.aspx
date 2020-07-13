<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="CallCenter_ViewCallCenterManager"
    Title="Untitled Page" Codebehind="ViewCallCenterManager.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">

.mainbody_outer_vccm{ float:right; width:777px; background-color:#fff; margin-top:5px; }
.mainbody_inner_vccm{ width:763px; margin-left:14px; margin-bottom:5px;}
.main_area_bdr_vccm{ float:left; width:753px; border:1px solid #E5E5E5; margin-top:5px;}

.divgridviewccm{ float:left; width:749px; border-style:none; }
</style>
<script type="text/javascript" language="javascript">
    
    function GridMasterCheck()
    {
        Grid_MasterCheckBoxClick("<%= this.gridviewccm.ClientID %>");
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.gridviewccm.ClientID %>", objtemp);
        if(numcount == "1")
            Grid_EnableEditbutton("<%= this.btnEdit.ClientID %>");
        else
            Grid_DisableEditbutton("<%= this.btnEdit.ClientID %>");
    }
    
    function GridChildCheck()
    {
        Grid_ChildCheckBoxClick("<%= this.gridviewccm.ClientID %>");
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.gridviewccm.ClientID %>", objtemp);
        if(numcount == "1")
            Grid_EnableEditbutton("<%= this.btnEdit.ClientID %>");
        else
            Grid_DisableEditbutton("<%= this.btnEdit.ClientID %>");
                    
    }
    
    function CheckForDelete()
    {
        
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.gridviewccm.ClientID %>", objtemp);
        if(numcount == 0)
        {
            alert("Please select atleast one item from the list");
            return false;
        }
        var answer = confirm ("All the selected Items will be deleted. ")
        return answer;
    }
    
    function CheckForEdit()
    {
        
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.gridviewccm.ClientID %>", objtemp);
        if(numcount != 1)
        {
            alert("Please select one item from the list.");
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
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Call Center Manager</span>
                    <span class="headingright_default"><a href="AddCallCenterManager.aspx"> +Add new Call Center Manager </a></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                 <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            <div class="main_area_bdrnone">
                <div class="divbuttonsrow">
                    <div class="pagealerttxtCNT" id="errordiv" runat="server">
                    </div>
                    <div class="master_buttons_row">
                        <div class="master_buttons_con">
                            
                            <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="/App/Images/edit_butt_master.gif" OnClientClick="return CheckForEdit();"
                                 OnClick="btnEdit_Click" />
                        </div>
                        
                        <div class="master_buttons_con">
                            <asp:ImageButton runat="server" OnClientClick="return CheckForDelete();" ID="btnDelete" ImageUrl="/App/Images/del-button_master.gif"
                                OnClick="btnDelete_Click" />
                        </div>
                    </div>
                </div>
			    
                <div class="dgdefault">
                    <asp:GridView runat="server" ID="gridviewccm" AutoGenerateColumns="false" GridLines="None" CssClass="divgrid_cl" DataKeyNames="OrganizationRoleUserId" OnRowDataBound="gridviewccm_RowDataBound">
                        <Columns>
                            
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="OrganizationName" HeaderText="Call Center" >
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name" >
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HtmlEncode="false" HeaderText="Address">
                            </asp:BoundField>
                            <asp:BoundField DataField="Phone" HeaderText="Phone">
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <RowStyle CssClass="row2" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

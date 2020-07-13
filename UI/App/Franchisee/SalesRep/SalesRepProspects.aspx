<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="Franchisee_SalesRep_SalesRepProspects" Codebehind="SalesRepProspects.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.mainbody_outer_v_prospects{ float:right; width:777px; background-color:#fff; margin-top:5px; }
.mainbody_inner_v_prospects{ width:763px; margin-left:14px; margin-bottom:5px;}
.main_area_bdr_v_prospects{ float:left; width:751px; border:1px solid #E5E5E5; margin-top:5px; margin-bottom:5px;}
.titlelnkright_v_prospects {float:right; padding-right:10px; padding-top:5px; font: bold 11px arial; color:#333; text-align:right; }
.titlelnkright_v_prospects a:link {font: bold 11px arial; color:#333; text-decoration:underline; }
.titlelnkright_v_prospects a:visited {font: bold 11px arial; color:#333; text-decoration:underline; }
.titlelnkright_v_prospects a:hover {font: bold 11px arial; color:#000; text-decoration:underline; }
.headbg2_box_v_prospects{ float:left; width:753px; padding:5px 0px 5px 0px;}
.save_button_v_prospects{  float:right; width:60px; height:32px; padding:0px 5px 0px 0px;}
.converthost_v_prospects{  float:right; width:110px; height:32px; margin-bottom:10px; padding-right:5px;}
.converthost_v_prospects1{  float:right; width:110px; height:25px; padding-right:5px;}
.delete_buttons_v_prospects{ float:right; width:57px; padding-right:5px;}
.cancel_button_v_prospects{ float:right; width:56px; height:32px; padding:0px 5px 0px 0px;}
.divgridviewprospects{float:left; width:750px;}
.converthost_buttons_v_prospects{ float:right; width:110px; padding-right:5px;}

.divgridviewcontacts{ float:left; width:751px; border-style:none; }

</style>
<script type="text/javascript" language="javascript">
   
    function GridMasterCheck()
    {
        
        Grid_MasterCheckBoxClick("<%= this.dgProspects.ClientID %>");

             var btnConvert= document.getElementById("<%= this.btnConvertHost.ClientID %>");
             var objtemp = document.createElement("INPUT");
             var numcount2 = Grid_MultiSelect("<%= this.dgProspects.ClientID %>", objtemp)
            if(numcount2 == 1)
            {
                
                 btnConvert.disabled=false;
                 btnConvert.src="/App/Images/converttohost-butt.gif";
            }
            else
            {
             btnConvert.disabled=true;
             btnConvert.src="/App/Images/converttohost-btn-d.gif";
            }

    }
    
    function GridChildCheck()
    {
  
        Grid_ChildCheckBoxClick("<%= this.dgProspects.ClientID %>");
        var objtemp = document.createElement("INPUT");
        var numcount2 = Grid_MultiSelect("<%= this.dgProspects.ClientID %>", objtemp)
        if(numcount2 == 1)
        {
             var btnConvert= document.getElementById("<%= this.btnConvertHost.ClientID %>");
             btnConvert.disabled=false;
             btnConvert.src="/App/Images/converttohost-butt.gif";
        } 
        else
        {
            var btnConvert= document.getElementById("<%= this.btnConvertHost.ClientID %>");
             btnConvert.disabled=true;
             btnConvert.src="/App/Images/converttohost-btn-d.gif";
        } 
    }  
    
    function validate()
    {
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.dgProspects.ClientID %>", objtemp)
        
        if(numcount == 0)
        {
            alert("Select at least Single Prospect to Delete.");
            return false;
        }
        
        var myConfirm = confirm("Sure you want to delete?");
        return myConfirm;
    }
    
    
       

</script>

<div class="mainbody_outer">
            <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Prospects</span>
                    <span class="headingright_default"><asp:LinkButton ID="lbtNewProspect" runat="server" Text="+ Add New Prospect" OnClick="lbtNewProspect_Click" /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            
            
              <%--  <div class="mainbody_inner_left">
                </div>
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft">
                        View Prospects
                    </div>
                    <div class="titlelnkright_v_prospects">
                        <asp:LinkButton ID="lbtNewProspect" runat="server" Text="+ Add New Prospect" OnClick="lbtNewProspect_Click" />
                    </div>
                </div>
                <div class="mainbody_inner_right">
                </div>--%>
                <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false" runat="server"></div>
                <div class="main_area_bdr_v_prospects">
                <div class="divbuttonsrow">
                    <%--<div class="pagealerttxtCNT" id="errordiv" runat="server">
                    </div>--%>
                    <div class="master_buttons_row">
                     <div class="delete_buttons_v_prospects">
                          <asp:ImageButton runat="server" ID="btnDelete" OnClientClick="return validate();" ImageUrl="~/App/Images/del-button.gif" OnClick="btnDelete_Click" />
                    </div>  
                    <div class="converthost_buttons_v_prospects">
                          <asp:ImageButton runat="server" ID="btnConvertHost" ImageUrl="~/App/Images/converttohost-btn-d.gif" OnClick="btnConvertHost_Click"/>
                    </div> 
                    </div>
                </div>
                    <div class="divgridviewprospects" id="divGrdProspect" runat="server">
                        <asp:GridView runat="server" GridLines="None" ID="dgProspects" AutoGenerateColumns="false" CssClass="gridchkbox"
                                DataKeyNames="ProspectID" OnRowDataBound="dgProspects_RowDataBound" EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="10" 
                            OnPageIndexChanging="dgProspects_PageIndexChanging" AllowSorting="True" OnSorting="dgProspects_Sorting">
                            <Columns>
                                <asp:BoundField Visible="False"></asp:BoundField>
                                <asp:TemplateField>
                                 <HeaderTemplate> 
			                         <input type="checkbox" id="chklistname1"   runat="server"   class="" />
			                     </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkRowChild"   runat="server" class="" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="name desc" >
                                    <ItemTemplate>
                                        <div class="divitemname_vp">
                                        <a title='<%# DataBinder.Eval(Container.DataItem, "Name")%>' href='<%# this.ResolveUrl("~/App/Franchisor/NewAddProspect.aspx?ProspectID=" + DataBinder.Eval(Container.DataItem, "ProspectID")) %>'>
                                            <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                        </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Address" HeaderText="Address">
                                </asp:BoundField>
                                <asp:BoundField DataField="Phone" HeaderText="Phone">
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Contacts"  >
                                   <ItemTemplate>
                                        <a href='<%# this.ResolveUrl("~/App/Franchisor/ViewContact.aspx?ProspectID=" + DataBinder.Eval(Container.DataItem, "ProspectID")) %>'>View Contact</a>
                                   </ItemTemplate>
                                    <ItemStyle CssClass="" />
                                <HeaderStyle CssClass="" />
                            
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="row1" />
                            <RowStyle CssClass="row2" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                    </div>
                </div>
              <%--  <div class="headbg2_box_v_prospects">
                    
                    <div class="cancel_button_v_prospects">
                            </div>
                                <div class="converthost_v_prospects">
                            </div>
                </div>--%>
            </div>
        </div>
        
</asp:Content>


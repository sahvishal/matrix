<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Masters_ItemType" Title="Untitled Page" Codebehind="ItemType.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
.wrapper_pop {float: left; width: 352px; padding: 10px; background-color: #f5f5f5; }
.wrapperin_pop {float: left; width: 328px; border: solid 2px #4888AB; padding: 10px; background-color: #fff; }
.innermain_pop {float: left; width: 328px; }
</style>   
    
    
<script language="javascript" type="text/javascript">
      
        function HandleValidators()
        {

            
            if(isBlank(document.getElementById('<%= this.txtName.ClientID %>'), 'Inventory Name'))
                return false;
                
            var ctrl = document.getElementById('divtests');
            if(ctrl.style.visibility == "visible")
            {
                var cboxlistTest = document.getElementById('<%= this.chklsttestassociated.ClientID %>');
                var icount =0;
                var iterpos = 0;
                var nodecount = 0;
                
                while(icount < cboxlistTest.rows.length)
                {
                    if(iterpos == 0)
                    {
                        iterpos = iterpos + 1;
                        while(nodecount < cboxlistTest.rows[icount].cells[0].childNodes.length)
                        {
                            if(cboxlistTest.rows[icount].cells[0].childNodes[nodecount].tagName == "INPUT")
                                break;
                            nodecount = nodecount + 1;
                            
                        }
                    }
                    
                    if(cboxlistTest.rows[icount].cells[0].childNodes[nodecount].checked == true)
                        return true;
                        
                    icount = icount + 1;
                }
                alert("Choose a test for the inventory item.");
                return false;
            }
            
        }
       
        function GridMasterCheck()
        {
            Grid_MasterCheckBoxClick("<%= this.grdItemType.ClientID %>");
            
            var objtemp = document.createElement("INPUT");
            var numcount = Grid_MultiSelect("<%= this.grdItemType.ClientID %>", objtemp);
            
            if(document.getElementById("<%= this.btnEdit.ClientID %>") != null)
            {
                if(numcount == "1")
                    Grid_EnableEditbutton("<%= this.btnEdit.ClientID %>");
                else
                    Grid_DisableEditbutton("<%= this.btnEdit.ClientID %>");
            }
        }
        
        function GridChildCheck()
        { 
            Grid_ChildCheckBoxClick("<%= this.grdItemType.ClientID %>");
            
            var objtemp = document.createElement("INPUT");
            var numcount = Grid_MultiSelect("<%= this.grdItemType.ClientID %>", objtemp);
            
            if(document.getElementById("<%= this.btnEdit.ClientID %>") != null)
            {
                if(numcount == "1")
                    Grid_EnableEditbutton("<%= this.btnEdit.ClientID %>");
                else
                    Grid_DisableEditbutton("<%= this.btnEdit.ClientID %>");
            }
                        
        }


        function ConfirmMultiselect(type)
        {//debugger;
            var objtemp = document.createElement("INPUT");
            var numcount = Grid_MultiSelect("<%= this.grdItemType.ClientID %>", objtemp);
            if (numcount>=1)
            {
                var answer = confirm ("Are you sure you want to " + type + " Item Type(s) ? ")
                return answer;
            }
            else if (numcount==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
               
        }

        function makevisiblediv(bolvisible)
        {
    
            var ctrl = document.getElementById('divtests');
            if(bolvisible == 'True' || bolvisible == 'true')
            {
                ctrl.style.visibility = "visible";
                ctrl.style.display = "block";
            }
            else
            {
                ctrl.style.visibility = "hidden";
                ctrl.style.display = "none";
            }
        }    

        function EditItemType()
        {
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
             popuptitle.InnerHtml = "Edit Inventory Item";
                   
            var objtemp = document.createElement("INPUT");
            var numcount = Grid_MultiSelect("<%= this.grdItemType.ClientID %>", objtemp);
            
            if (numcount!=1)
            {
                alert("You can select only one item from the table to edit!");
                return false;
            }
            
            //return true;
            
            
            var txtName= document.getElementById("<%= this.txtName.ClientID %>");
            var txtDescription= document.getElementById("<%= this.txtDescription.ClientID %>");
            var grdItemType= document.getElementById("<%= this.grdItemType.ClientID %>");
            var hfItemTypeID= document.getElementById("<%= this.hfItemTypeID.ClientID %>");
            var count = Number(objtemp.value);
            
            hfItemTypeID.value = Number(objtemp.value);
            
               
            if(grdItemType.rows[count + 1].cells.length <= 1)
            {
                return false;
                
            }
                
                
                
            txtName.value = grdItemType.rows[count+1].cells[1].childNodes[1].innerHTML;
            if(grdItemType.rows[count+1].cells[2].innerHTML != '&nbsp;')
               txtDescription.value = grdItemType.rows[count+1].cells[2].innerHTML;

            return true;
        }

        function EmptyBoxes()
        {
            
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            var txtName= document.getElementById("<%= this.txtName.ClientID %>");
            var txtDescription= document.getElementById("<%= this.txtDescription.ClientID %>");
            var hfItemTypeID= document.getElementById("<%= this.hfItemTypeID.ClientID %>");
            
            txtName.value = '';
            txtDescription.value = '';
            hfItemTypeID.value = '';
            popuptitle.innerHTML = 'Add New Inventory Name';
            
            var rbtnlistItemTypes = document.getElementById('<%= this.rbtlstconsumable.ClientID %>');
            var nodecount = 0;
         
            while(nodecount < rbtnlistItemTypes.rows[0].cells[0].childNodes.length)
            {
                if(rbtnlistItemTypes.rows[0].cells[0].childNodes[nodecount].tagName == "INPUT")
                {
                    rbtnlistItemTypes.rows[0].cells[0].childNodes[nodecount].checked = true;
                    break;
                }
                nodecount = nodecount + 1;
                
            }
            
            var cboxlistTest = document.getElementById('<%= this.chklsttestassociated.ClientID %>');
            var icount =0;
            var iterpos = 0;
            var nodecount = 0;

            if (document.getElementById('divtests').style.visibility == "visible")
            {
                while(icount < cboxlistTest.rows.length)
                {
                    if(iterpos == 0)
                    {
                        iterpos = iterpos + 1;
                        while(nodecount < cboxlistTest.rows[icount].cells[0].childNodes.length)
                        {
                            if(cboxlistTest.rows[icount].cells[0].childNodes[nodecount].tagName == "INPUT")
                                break;
                            nodecount = nodecount + 1;
                        
                        }
                    }
                
                    cboxlistTest.rows[icount].cells[0].childNodes[nodecount].checked = false;
                    icount = icount + 1;
                }
            }
                        
        }
 
        function EditInventoryName(lnkBtnID)
        {//debugger
              var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
             popuptitle.InnerHtml = "Edit Inventory Item";
            var txtName= document.getElementById("<%= this.txtName.ClientID %>");
            var txtDescription= document.getElementById("<%= this.txtDescription.ClientID %>");
            var grdItemType= document.getElementById("<%= this.grdItemType.ClientID %>");
            var hfItemTypeID= document.getElementById("<%= this.hfItemTypeID.ClientID %>");
            var count = 0;
            var nodecount=0;
            while(count < (grdItemType.rows.length - 1))
            {
                while(nodecount<grdItemType.rows[count+1].cells[1].childNodes.length)
                {
                    if(grdItemType.rows[count+1].cells[1].childNodes[nodecount].nodeName=="A")
                        break;
                    nodecount++;
                }
                if(grdItemType.rows[count+1].cells[1].childNodes[nodecount].id == lnkBtnID)
                {  
                    txtName.value = grdItemType.rows[count+1].cells[1].childNodes[nodecount].innerHTML;
                    if(grdItemType.rows[count+1].cells[2].innerHTML != '&nbsp;')
                        txtDescription.value = grdItemType.rows[count+1].cells[2].innerHTML;
                      
                    hfItemTypeID.value= count;
                    break;
                 }
              
                  count++; 
             }
             
             //$find('mdlPopup').show();

             return true;
        }
     
    </script>
<div class="mainbody_outer">
        <div class="mainbody_inner">
        
        <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Inventory Name</span>
                    <span class="headingright_default"><asp:LinkButton ID="addNewType" runat="server" Text="+ Add new Inventory" OnClientClick="EmptyBoxes();" /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
             <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server"></div> 
            <div class="divbuttonsrow">
            
                <div class="master_buttons_row">
                    
                       <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="../../Images/del-button_master.gif"
                            OnClientClick="return ConfirmMultiselect('Delete')" OnClick="btnDelete_Click" />
                    </div>
                    
                    <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="../../Images/activate_butt_master.gif"
                            OnClientClick="return ConfirmMultiselect('Activate')" OnClick="btnActivate_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="../../Images/deactivate_butt_master.gif"
                            OnClientClick="return ConfirmMultiselect('DeActivate')" OnClick="btnDeActivate_Click" />
                    </div>
                    
                
                     <div class="master_buttons_con" style="visibility:hidden; display:none;">
                        <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditItemType();"
                            ImageUrl="../../Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                    </div>
                    
                </div>
                
            
            </div>
                  
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdItemType" AutoGenerateColumns="False" DataKeyNames="InventoryItemID"
                    CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdItemType_RowDataBound" AllowPaging="True" PageSize="10" OnPageIndexChanging="grdItemType_PageIndexChanging" AllowSorting="True" OnSorting="grdItemType_Sorting">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inventory Name" SortExpression="name desc">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnInventoryName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"name") %>' OnClick="lnkBtnInventoryName_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="description" HeaderText="Description">
                        </asp:BoundField>
                        <asp:BoundField DataField="ItemType" HeaderText="Item Type">
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status">
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfitemtypeid" Value='<%# DataBinder.Eval(Container.DataItem, "ItemTypeID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="InventoryItemID"  Visible="False" InsertVisible="False" />
                    </Columns>
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
            
            <%--<div class="pagevalsummarytxtCNT">
                <asp:ValidationSummary ID="ErrorSummary" runat="server" />
            </div>--%>
         
            
        </div>
    </div>
   
    
    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
    <contenttemplate>--%>
        <asp:Panel ID="Panel1" runat="server" CssClass="PopUp">
        <div class="wrapper_pop"  id="Div1">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Add New Inventory Name</span>
                        <span style="float: right">
                            <asp:ImageButton runat="server" ID="ibtnclosesymbol" ImageUrl="~/App/Images/close-button-symbol.gif" />
                        </span>
                    </p>
                      <p class="innermain_pop" style="border-top: solid 1px #ccc;">
                    <span style="float:right; margin-top:3px;">
                       <span class="graysmalltxt_default"><span class="reqiredmark"><sup>*</sup> </span>Mandatory Fields</span>
                       </span>
                    </p>
                    <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1b_default">Inventory Name:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtName" runat="server" CssClass="inputf_def" Width="205px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletext1b_default">Item Type:<span class="reqiredmark"><sup>*</sup>  </span></span>
                         <span class="inputfldnowidth_default">
                              <asp:RadioButtonList runat="server" ID="rbtlstconsumable" BorderStyle="solid" BorderColor="#7F9DB9"
                                CellPadding="5" BorderWidth="1px" RepeatColumns="1" Width="315px">
                                <asp:ListItem Text="Consumable" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Non Consumable" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                         </span>
                    </p>
                    <div class="innermain_pop">
                   <div class="chkboxmaster_itmtype" id="divtests" style="visibility: hidden; display: none;">
                        <div class="titletext1b_default" >
                            Tests:<span class="reqiredmark"><sup>*</sup>  </span></div>
                        <div class="inputfldnowidth_default">
                            <asp:CheckBoxList runat="server" ID="chklsttestassociated" CssClass="inputf_def" Width="315px">
                                <asp:ListItem Text="Test1" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Test2" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Test3" Value="2" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Test4" Value="3" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Test5" Value="4"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                     </div>
                     <div class="innermain_pop" style="margin-top:5px">
                    <div class="titletext1b_default">
                        Description:</div>
                    <div class="inputfldnowidth_default">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server" CssClass="inputf_def" Width="205px"></asp:TextBox>
                    </div>
                    </div>
                    <asp:HiddenField ID="hfItemTypeID" runat="server" />
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../../Images/cancel-btn.gif" OnClientClick="$find('mdlPopup').hide(); return false;" />  
                    </span>
                     <span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../../Images/save-button.gif"
                            OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />
                     </span>
                    </p>
                    
                </div>
            </div>
        </div>
        
        
        
        
            
        </asp:Panel>
        
        <%--
    
    </contenttemplate>
    </asp:UpdatePanel>
    --%>
    
        
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewType"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup" />
            
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Masters_Item" Title="Untitled Page" Codebehind="Item.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
.wrapper_pop {float: left; width: 352px; padding: 10px; background-color: #f5f5f5; }
.wrapperin_pop {float: left; width: 328px; border: solid 2px #4888AB; padding: 10px; background-color: #fff; }
.innermain_pop {float: left; width: 328px; }
.innermain_pop p{float: left; width: 328px; padding-top:5px; }
.innermain_pop p label{float: left; width: 120px; font-weight:bold; color:#000;}
</style>
    <script language="javascript" type="text/javascript">
        
        
        function HandleValidators()
        {
            var txtItemCode= document.getElementById(arrjsitemselements[1]);
            if  (isBlank(txtItemCode,"Item Code"))                        {return false;}            
//            if(trim(txtItemCode.value) == '')
//            {
//                document.getElementById('diverrorsummary').innerHTML='<li>Please specify the item code.</li>';
//                return false;
//            }
            var ddlInventory= document.getElementById("<%= this.ddlInventory.ClientID %>");
            if  (checkDropDown(ddlInventory,"Inventory Name")==false) {return false;}
            var txtSKUCode= document.getElementById("<%= this.txtSKUCode.ClientID %>");
            var txtManfName= document.getElementById("<%= this.txtManfName.ClientID %>");
            var txtManfID= document.getElementById("<%= this.txtManfID.ClientID %>");
            if  (isBlank(txtSKUCode,"SKU Code"))                        {return false;}  
            if  (isBlank(txtManfName,"Manufacturer Name"))                        {return false;}  
            if  (isBlank(txtManfID,"Manufacturer ID"))                        {return false;}  
                  
            return true;

        }
        
        function ConfirmMultiselect(type)
        {////debugger
            if (MultiSelect()>=1 && (type=='Deleted'))
            {
                var answer = confirm ("Are you sure you want to delete Item(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate Item(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate Item(s)? ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
               
        }
        
        function mastercheckboxclick()
        {
            if(arrjsitemselements == null)
                return;
                
            var grdItem = document.getElementById(arrjsitemselements[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdItem.rows[0].cells[0].childNodes.length)
            {
                if(grdItem.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdItem.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            while(rowcount < grdItem.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdItem.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdItem.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdItem.rows[rowcount].cells.length > 1)
                    grdItem.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                rowcount = rowcount + 1;
            }
            MultiSelect();
            
        }
        
        
        function checkallboxes()
        {
            if(arrjsitemselements == null)
                return;
            
            MultiSelect();
            var grdItem = document.getElementById(arrjsitemselements[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdItem.rows[0].cells[0].childNodes.length)
            {
                if(grdItem.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdItem.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdItem.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdItem.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdItem.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdItem.rows[rowcount].cells.length > 1)
                {
                    if(grdItem.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
                    {
                        mstrchkbox.checked = false;
                        return;
                    }
                }
                rowcount = rowcount + 1;
            }
            
            mstrchkbox.checked = true;
        
        }
        
        function MultiSelect()
        {  // //debugger
        
            if(arrjsitemselements == null)
                return;
                
            var selectcount=0;
            var selectedrow=0;
            
            var grdItem = document.getElementById(arrjsitemselements[0]);

            var arrlength = grdItem.rows.length;
            var count = 1;
            var nodecount = 0;
            while(count < arrlength)
            {
                
                if(count == 1)
                {
                    while(nodecount < grdItem.rows[count].cells[0].childNodes.length)
                    {
                        if(grdItem.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                    
                if(grdItem.rows[count].cells.length <= 1)
                {
                    count = count + 1;
                    continue;
                }
                
                if(grdItem.rows[count].cells[0].childNodes[nodecount].checked == true)
                {
                    selectcount=selectcount+1;
                    selectedrow=count+1;
                                        
                    if (selectcount>1)
                    {
                        var btnEdit= document.getElementById(arrjsitemselements[6]);
                        btnEdit.disabled=true;
                        btnEdit.src="../../Images/edit-button-d.gif"
                        return selectcount
                    }
                }
                count = count + 1;
            }
                        
            var btnEdit= document.getElementById(arrjsitemselements[6]);
            btnEdit.disabled=false;
            btnEdit.src="../../Images/edit_butt_master.gif"
                         
            return selectcount;            
        }
        
        
        function EditItem(bolbeforeclick)
        {
        ////debugger
            if(bolbeforeclick == true)
            {
                if(arrjsitemselements == null)
                    return false;
            
                if (MultiSelect()!=1)
                {
                    alert("You can select only one item from the table to edit!");
                    return false;
                }
                
                return true;
                
            }
            else 
            {
                var grdItem = document.getElementById(arrjsitemselements[0]);
                var txtItemCode = document.getElementById(arrjsitemselements[1]);
                var txtSKUCode = document.getElementById(arrjsitemselements[2]);
                var txtManfName = document.getElementById(arrjsitemselements[3]);
                var txtManfID = document.getElementById(arrjsitemselements[4]);
                var hfItemID = document.getElementById(arrjsitemselements[7]);
                var txtNote=document.getElementById(arrjsitemselements[8]);
                
                var count = 0;
                var nodecount = 0;
                var notepos = 0;
                
                while(count < (grdItem.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdItem.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdItem.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                        var loopcount = 0;
                        var ininput = 0;
                        while(loopcount < grdItem.rows[count + 1].cells[7].childNodes.length)
                        {
                            if(grdItem.rows[count + 1].cells[7].childNodes[loopcount].tagName == "INPUT")
                            {
                                if(ininput == 0)
                                {
                                    notepos = loopcount;
                                }
                                ininput = ininput  + 1;
                            }
                            loopcount = loopcount + 1; 
                            
                        }
                    }
                    
                    if(grdItem.rows[count + 1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    
                    
                    if(grdItem.rows[count+1].cells[0].childNodes[nodecount].checked == true)
                    {  
                         txtItemCode.value = grdItem.rows[count+1].cells[1].childNodes[1].innerHTML;
                         if(grdItem.rows[count+1].cells[2].innerHTML != '&nbsp;')
                            txtSKUCode.value = grdItem.rows[count+1].cells[2].innerHTML;
                         txtNote.value = grdItem.rows[count+1].cells[7].childNodes[notepos].value;
                         txtManfName.value = grdItem.rows[count+1].cells[3].innerHTML;
                         var nodecnt = 0;
                         while(nodecnt  < grdItem.rows[count + 1].cells[5].childNodes.length)
                         {
                            if(grdItem.rows[count + 1].cells[5].childNodes[nodecnt].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecnt = nodecnt + 1;
                         }
                         var inventoryitemvalue = grdItem.rows[count + 1].cells[5].childNodes[nodecnt].value;
                         
                         nodecnt = 0;
                         while(nodecnt  < grdItem.rows[count + 1].cells[6].childNodes.length)
                         {
                            if(grdItem.rows[count + 1].cells[6].childNodes[nodecnt].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecnt = nodecnt + 1;
                         }
                         txtManfID.value = grdItem.rows[count + 1].cells[6].childNodes[nodecnt].value;
                         
                         var ctrl = document.getElementById(arrjsitemselements[5]);
                         
                         var intrwcount = 0;
                         ////debugger
                         while(intrwcount < ctrl.options.length)
                         {
                              if(ctrl.options[intrwcount].value == inventoryitemvalue)
                              {
                                ctrl.options[intrwcount].selected = true;                                                                                    
                                break;
                              }
                              intrwcount = intrwcount + 1;
                         }
                                                    
                         hfItemID.value= count;
                         break;
                     }
                  
                  count++; 
               }
          }
          return true;
     }
        
        function EmptyBoxes()
        {
            var txtItemCode = document.getElementById(arrjsitemselements[1]);
            var txtSKUCode = document.getElementById(arrjsitemselements[2]);
            var txtManfName = document.getElementById(arrjsitemselements[3]);
            var txtManfID = document.getElementById(arrjsitemselements[4]);
            var hfItemID = document.getElementById(arrjsitemselements[7]);
            var txtNote=document.getElementById(arrjsitemselements[8]);
            var sppopuptitle=document.getElementById("sppopuptitle");

            //document.getElementById('<%= this.ddlInventory.ClientID %>').options[0].selected = true;

            document.getElementById('<%= this.ddlInventory.ClientID %>').selectedIndex = 0;
                     
            txtItemCode.value = '';
            txtSKUCode.value = '';
            txtManfName.value = '';
            txtManfID.value = '';
            hfItemID.value = '';
            txtNote.value='';
            sppopuptitle.innerHTML="Add new Item";
        }
        
        function EditItemCode(lnkBtnID)
        {//debugger
            var grdItem = document.getElementById(arrjsitemselements[0]);
            var txtItemCode = document.getElementById(arrjsitemselements[1]);
            var txtSKUCode = document.getElementById(arrjsitemselements[2]);
            var txtManfName = document.getElementById(arrjsitemselements[3]);
            var txtManfID = document.getElementById(arrjsitemselements[4]);
            var hfItemID = document.getElementById(arrjsitemselements[7]);
            var txtNote=document.getElementById(arrjsitemselements[8]);
            var sppopuptitle=document.getElementById("sppopuptitle");
            
            var count = 0;
            var nodecount = 0;
            var notepos = 0;
           
            var nodecount = 0;
            while(count < (grdItem.rows.length - 1))
            {                
                while(nodecount<grdItem.rows[count+1].cells[1].childNodes.length)
                {
                    if(grdItem.rows[count+1].cells[1].childNodes[nodecount].nodeName=="A")
                        break;
                    nodecount++;
                }
                if(grdItem.rows[count+1].cells[1].childNodes[nodecount].id == lnkBtnID)
                {  
                    
                     txtItemCode.value = grdItem.rows[count+1].cells[1].childNodes[nodecount].innerHTML;
                     if(grdItem.rows[count+1].cells[2].innerHTML != '&nbsp;')
                        txtSKUCode.value = grdItem.rows[count+1].cells[2].innerHTML;
                        
                     //txtNote.value = grdItem.rows[count+1].cells[7].childNodes[nodecount].value;
                     txtNote.value = grdItem.rows[count + 1].cells[1].childNodes[nodecount+6].value;
                     
                     txtManfName.value = grdItem.rows[count+1].cells[3].innerHTML;
                     
                     //txtManfID.value = grdItem.rows[count + 1].cells[6].childNodes[nodecount].value;
                     txtManfID.value=grdItem.rows[count+1].cells[1].childNodes[nodecount+4].value;
                     
                    //var inventoryitemvalue = grdItem.rows[count + 1].cells[5].childNodes[nodecount].value;
                    var inventoryitemvalue=grdItem.rows[count+1].cells[1].childNodes[nodecount+2].value;
                    
                    var ctrl = document.getElementById(arrjsitemselements[5]);
                    var intrwcount = 0;
                    while(intrwcount < ctrl.options.length)
                    {
                      if(ctrl.options[intrwcount].value == inventoryitemvalue)
                      {
                        ctrl.options[intrwcount].selected = true;                                                                                    
                        break;
                      }
                      intrwcount = intrwcount + 1;
                    }
                     hfItemID.value= count;
                     break;
                 }
              
                  count++; 
             }
             sppopuptitle.innerHTML="Edit Inventory Item";
             $find('mdlPopup').show();

             return false;
        }
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
        <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Manage Inventory Item</span>
                    <span class="headingright_default"><asp:LinkButton ID="addNewItem" runat="server" Text="+ Add new Item" OnClientClick="EmptyBoxes()" /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
        
           <%-- <div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
                <div class="mainbody_titletxtleft">
                    Item </div>
                <div class="mainbody_titlelnkright">
                    <asp:LinkButton ID="addNewItem" runat="server" Text="+ Add new Item" OnClientClick="EmptyBoxes()" />
                </div>
            </div>
            <div class="mainbody_inner_right">
            </div>--%>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server"></div> 
            <div class="divbuttonsrow">
              
                <div class="master_buttons_row">
                    
                          <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="../../Images/del-button_master.gif"
                            OnClientClick="return ConfirmMultiselect('Deleted')" OnClick="btnDelete_Click" />
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
                        <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditItem(true);"
                            ImageUrl="../../Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                    </div>
                </div>
            </div>
           
        	 <div style="float:left; width:746px">
             <p class="blueboxtopbg_cl"><img src="/App/Images/specer.gif" width="746" height="5" /></p>
            <div style="float:left; width:746px">
                <asp:GridView runat="server" ID="grdItem" AutoGenerateColumns="False" DataKeyNames="ItemID"
                    CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdItem_RowDataBound"
                    AllowPaging="True" OnPageIndexChanging="grdItem_PageIndexChanging"
                    AllowSorting="True" OnSorting="grdItem_Sorting" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Code">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnItemCode" runat="server"><%#DataBinder.Eval(Container.DataItem,"ItemCode") %></asp:LinkButton>
                                <asp:HiddenField runat="server" ID="hfinventoryitemid" Value='<%# DataBinder.Eval(Container.DataItem, "InventoryItemID") %>' />
                                <asp:HiddenField runat="server" ID="hfmanufacturerid" Value='<%# DataBinder.Eval(Container.DataItem, "ManufacturerID") %>' />
                                <asp:HiddenField runat="server" ID="hfnote" Value='<%# DataBinder.Eval(Container.DataItem, "Note") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SKUCode" HeaderText="SKU Code">
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="ManufacturerName" HeaderText="Manufacturer" SortExpression="manufacturername desc">
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="Active" HeaderText="Status">
                        </asp:BoundField>
                        
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfinventoryitemid" Value='<%# DataBinder.Eval(Container.DataItem, "InventoryItemID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfmanufacturerid" Value='<%# DataBinder.Eval(Container.DataItem, "ManufacturerID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfnote" Value='<%# DataBinder.Eval(Container.DataItem, "Note") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="ItemID" Visible="False" />
                    </Columns>
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
            <p class="blueboxbotbg_cl"><img src="/App/Images/specer.gif" width="746" height="5" /></p>
            </div>
            
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <h1 id="sppopuptitle" style="float:left"> Add new Item</h1>
                    <span style="float: right">
                        <asp:ImageButton runat="server" ID="ibtnclosesymbol" ImageUrl="~/App/Images/close-button-symbol.gif" />
                    </span>
                    <p style="border-top:solid 1px #ccc;">
                     <span class="graytxtright_prsmall"> <span class="reqiredmark"><sup>*</sup></span>Mandatory fields</span>
                   </p>
                    <p>
                        <span class="titletext1a_default"> Item Code:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputfldnowidth_default"><asp:TextBox ID="txtItemCode" runat="server" CssClass="inputf_def" Width="190px"></asp:TextBox></span>
                    </p>
                    <p>
                    <span class="titletext1a_default"> Inventory Name:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                          <asp:DropDownList runat="server" ID="ddlInventory" CssClass="inputf_def" Width="195px" >
                        </asp:DropDownList>
                    </span>
                    </p>
                    <p>
                    <span class="titletext1a_default" id="DIV1">SKU Code:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtSKUCode" runat="server" CssClass="inputf_def" Width="190px"></asp:TextBox>
                    </span>
                    </p>
                    <p>
                      <span class="titletext1a_default">Manufacturer Name:<span class="reqiredmark"><sup>*</sup></span></span>
                       <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtManfName" runat="server" CssClass="inputf_def" Width="190px"></asp:TextBox>
                       </span>
                    </p>
                    <p>
                       <span class="titletext1a_default">Manufacturer ID:<span class="reqiredmark"><sup>*</sup></span></span>
                         <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtManfID" runat="server" CssClass="inputf_def" Width="190px"></asp:TextBox>
                         </span>
                    </p>
                    <p>
                     <span class="titletext1a_default"> Notes:</span>
                        <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtNote" TextMode="MultiLine" Rows="3" runat="server" CssClass="inputf_def" Width="190px"></asp:TextBox>
                        </span>
                    </p>
                     <asp:HiddenField ID="hfItemID" runat="server" />
                      <p>
                      <span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../../Images/save-button.gif"
                        OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />  
                    </span>
                    <span class="buttoncon_default">
                     <asp:ImageButton runat="server" ID="btnCancel" ImageUrl="../../Images/cancel-button.gif" OnClientClick="$find('mdlPopup').hide(); return false;" />
                    </span>
                      </p>
                 </div>
            </div>
         </div> 
    </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewItem"
        PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup"
         />
</asp:Content>

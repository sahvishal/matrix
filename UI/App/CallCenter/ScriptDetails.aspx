<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" ValidateRequest="false" AutoEventWireup="true" Inherits="CallCenter_ScriptDetails" Codebehind="ScriptDetails.aspx.cs" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 332px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_pop
        {
            float: left;
            width: 308px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop
        {
            float: left;
            width: 308px;
        }
       .prenextband
        {
            float: left;
            width: 296px;
            border:solid 1px #CCCCCC;
            background-color:#DFE7ED;
            padding:4px 5px 4px 5px;
        }
        .innermain_1_pop
        {
            float: left;
            width: 293px;
            padding-top: 5px;
        }
        .calright{float:right;}
    </style>
<script language="javascript" type="text/javascript">
        function hidediv() 
        { 
            if (document.getElementById) 
            { // DOM3 = IE5, NS6 
                //document.getElementById('bottom_bdr_master').style.visibility = 'hidden'; 
            } 
            else if (document.layers)
            { // Netscape 4
                //document.hideshow.visibility = 'hidden'; 
            } 
            else 
            { // IE 4 
                //document.all.hideshow.style.visibility = 'hidden'; 
            } 
            //HandleValidators(false);
        } 
        
        function showdiv() 
        { 
            if (document.getElementById) 
            { // DOM3 = IE5, NS6 
                //document.getElementById('bottom_bdr_master').style.visibility = 'visible'; 
            } 
            else if (document.layers)
            { // Netscape 4
                //document.hideshow.visibility = 'visible'; 
            } 
            else 
            { // IE 4 
                //document.all.hideshow.style.visibility = 'visible'; 
            } 
            //HandleValidators(true);
        }
        

        function EmptyBoxes()
        {
            ////debugger
            var txtName= document.getElementById(arrscriptelemclientid[2]);
            var txtDescription= document.getElementById(arrscriptelemclientid[3]);
            var ddlScriptType=document.getElementById(arrscriptelemclientid[4]);
            var txtScriptText= document.getElementById("<%= this.txtScriptText.ClientID %>");
             var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            
                
            txtScriptText.value='';
            txtName.value = '';
            txtDescription.value = '';
            ddlScriptType.options[0].selected = true;
            popuptitle.innerHTML = 'Add Script Details';
            
        }
        
        function HandleValidators()
        {
            
            var txtName= document.getElementById(arrscriptelemclientid[2]);
                       
                      
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

            for (var i = 0; i < trim(txtName.value).length; i++) 
            {
  	            if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) 
  	            {
  	                document.getElementById('diverrorsummary').innerHTML='<li>Special characters are not allowed in the script name. Please remove them and try again.</li>';
  	                return false;
  	            }
  	        }
  	        
  	         if(!checkDropDown(document.getElementById('<%= this.ddlscripttype.ClientID %>'), 'Script Type'))
                return false;
  	         if(isBlank(txtName, 'Scrip Name'))
                return false;
  	         if(isBlank(document.getElementById('<%= this.txtScriptText.ClientID %>'), 'Scrip Text'))
                return false;
            
             return true;
  	        
  	    }
        
        function mastercheckboxclick()
        {
            if(arrscriptelemclientid == null)
                return;
            
            var grdScript= document.getElementById(arrscriptelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdScript.rows[0].cells[0].childNodes.length)
            {
                if(grdScript.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdScript.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdScript.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdScript.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdScript.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdScript.rows[rowcount].cells.length > 1)
                    grdScript.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                rowcount = rowcount + 1;
            }
            MultiSelect();
    
        }
        
        
        function checkallboxes()
        {
            if(arrscriptelemclientid == null)
                return;
            
            var grdScript= document.getElementById(arrscriptelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdScript.rows[0].cells[0].childNodes.length)
            {
                if(grdScript.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdScript.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            MultiSelect();
            
            var nodecount = 0;
            while(rowcount < (grdScript.rows.length))
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdScript.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdScript.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdScript.rows[rowcount].cells.length > 1)
                {
                    if(grdScript.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
                    {
                        mstrchkbox.checked = false;
                        return;
                    }
                }
                rowcount = rowcount + 1;
            }
            
            mstrchkbox.checked = true;

        }
        
        function ConfirmMultiselect(type)
        {////debugger
            if (MultiSelect()>=1 && (type=='Deleted'))
            {
                var answer = confirm ("Are you sure you want to delete Script(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate Script(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate Script(s)? ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
               
        }
        
        function OnScriptTypeChange(ddltypeclientid,chkIsdefaultclientid)
        {
            var ddltype=document.getElementById(ddltypeclientid);
        }
        
        
        function MultiSelect()
        {  // //debugger
        
            if(arrscriptelemclientid == null)
                return;
                
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrscriptelemclientid[2]);
            var txtDescription= document.getElementById(arrscriptelemclientid[3]);
            var grdScript= document.getElementById(arrscriptelemclientid[0]);
            var hfScriptID= document.getElementById(arrscriptelemclientid[5]);
            
//            if(arrcheckboxids!= null)
//            {
                var arrlength = grdScript.rows.length;
                var count = 1;
                var nodecount = 0;
                while(count < arrlength )
                {
                    if(count == 1)
                    {
                        while(nodecount < grdScript.rows[count].cells[0].childNodes.length)
                        {
                            if(grdScript.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdScript.rows[count].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    if(grdScript.rows[count].cells[0].childNodes[nodecount].checked == true)
                    {
                        selectcount=selectcount+1;
                        selectedrow=count+1;
                        if (selectcount>1)
                        {
                            var btnEdit= document.getElementById(arrscriptelemclientid[1]);
                            btnEdit.disabled=true;
                            btnEdit.src = "../Images/edit-button-d.gif";
                            hidediv();
                            txtName.value=  "";
                            txtDescription.value= "";
                            hfScriptID.value=  "";
                            return selectcount;
                        }
                    }
                    count = count + 1;
                }
                 
            //}
           // //debugger
            var btnEdit= document.getElementById(arrscriptelemclientid[1]);
            btnEdit.disabled=false;
            btnEdit.src="../Images/edit_butt_master.gif"
            if (selectcount==1)
                {
                }
                else
                {
                    txtName.value=  "";
                    txtDescription.value= "";
                    hfScriptID.value=  "";
                }
                return selectcount;      
        }
        
        function EditScript()
        {
        ////debugger
            if(arrscriptelemclientid == null)
                return;
                
            if (MultiSelect()!=1)
            {
                alert("Select one item from the table to edit!");
                return false;
            }
            else
            {
                var selectcount=0;
                var selectedrow=0;
                var txtName= document.getElementById(arrscriptelemclientid[2]);
                var txtDescription= document.getElementById(arrscriptelemclientid[3]);
                var grdScript= document.getElementById(arrscriptelemclientid[0]);
                var ddlScriptType=document.getElementById(arrscriptelemclientid[4]);
                var hfScriptID= document.getElementById(arrscriptelemclientid[5]);
                var chkisdefault=document.getElementById(arrscriptelemclientid[6]);
                var txtscriptext=document.getElementById(arrscriptelemclientid[7]);
                
                var count = 0;
                var nodecount = 0;
                while(count < (grdScript.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdScript.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdScript.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdScript.rows[count + 1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                
                    if(grdScript.rows[count + 1].cells[0].childNodes[nodecount].checked == true)
                    {//debugger; 
                         showdiv();
                         txtName.value = grdScript.rows[count+1].cells[1].innerHTML;
                         
                         if(grdScript.rows[count+1].cells[2].innerHTML == '&nbsp;')
                            txtDescription.value  = '';
                         else
                            txtDescription.value = grdScript.rows[count+1].cells[2].innerHTML;
                         
                         var scripttypename = grdScript.rows[count+1].cells[3].innerHTML;
                        txtscriptext.value = grdScript.rows[count + 1].cells[4].innerHTML;
                         if(grdScript.rows[count+1].cells[5].innerHTML =="True" )
                         {
                            chkisdefault.checked=true;
                         }
                         else
                         {
                            chkisdefault.checked=false;
                         }
                         var scriptcount = 0;
                         ////debugger
                         while(scriptcount < ddlScriptType.options.length)
                         {
                            if(ddlScriptType.options[scriptcount].innerHTML == scripttypename)
                            {
                                ddlScriptType.options[scriptcount].selected = true;
                                break;
                            }
                            scriptcount = scriptcount + 1;
                         }
                         
                        
                         hfScriptID.value=count;
                         break;
                    }
             
                  count++; 
                }
             }
            return true;
        }
        


</script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
        <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Script</span>
                    <span class="headingright_default"><asp:LinkButton ID="addNewScript" runat="server" Text="+ Add new Script" OnClientClick="EmptyBoxes();" /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>

            </div>       
        
            <%--<div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
                <div class="mainbody_titletxtleft">
                    Script</div>
                <div class="mainbody_titlelnkright">
                    <a href="javascript:showdiv()">+ Add new State</a>
                    
                </div>
            </div>
            <div class="mainbody_inner_right">
            </div>--%>
            <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false" runat="server"></div> 
            <div class="divbuttonsrow">
                <%--<div class="pagealerttxtCNT" id="errordiv" runat="server">
                </div>--%>
                
                <div class="master_buttons_row">
                      
                    <div class="master_buttons_con">
                        <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="../Images/del-button_master.gif"
                                OnClientClick="return ConfirmMultiselect('Deleted')" OnClick="btnDelete_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="../Images/activate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('Activate')" OnClick="btnActivate_Click" />
                    </div>
                    
                    
                    <div class="master_buttons_con">
                        <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="../Images/deactivate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('DeActivate')" OnClick="btnDeActivate_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <a href="javascript:showdiv()"></a>
                        <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="../Images/edit_butt_master.gif"
                            OnClientClick="return EditScript()" OnClick="btnEdit_Click" />
                    </div>
                </div>
            
            </div>
            
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdScript" AutoGenerateColumns="false" DataKeyNames="ScriptID"
                    CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdScript_RowDataBound"
                    EnableSortingAndPagingCallbacks="False" AllowSorting="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdScript_PageIndexChanging" OnSorting="grdScript_Sorting">
                    <Columns>
                        <asp:BoundField DataField="" Visible="false"></asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                               <input type="checkbox" id="chkRowChild" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ScriptID" Visible="false" HeaderText="ScriptID"></asp:BoundField>
                        
                        <asp:BoundField DataField="name" HeaderText="Script" SortExpression="name">
                        </asp:BoundField>
                        <asp:BoundField DataField="description" HeaderText="Description">
                        </asp:BoundField>
                        <asp:BoundField DataField="Type" HeaderText="Script Type" SortExpression="Type">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ScriptText">
                             <ItemTemplate><%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "scripttext").ToString())%></ItemTemplate>
                             <ItemStyle CssClass="scrpttxt"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="default" HeaderText="Default" >
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status">
                        </asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
                               
        </div>
    </div>
        <asp:Panel ID="Panel1" runat="server">
    <div class="wrapper_pop" id="Div2">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server"  id="sppopuptitle"> Add Script Details</span>
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
                        <span class="titletext1b_default" style="margin-right: 10px;">Script Type:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                           <asp:DropDownList runat="server" ID="ddlscripttype" CssClass="inputf_master" Width="185px">
                    </asp:DropDownList>
                        </span>
                      </span>
                    </p>
					 <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1b_default" style="margin-right: 10px;"> Script Name:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                           <asp:TextBox runat="server" ID="txtName" CssClass="inputf_master" Width="180px"> </asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletext1b_default" style="margin-right: 10px;">Description:</span>
                         <span class="inputfldnowidth_default"> 
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" CssClass="inputf_master"> </asp:TextBox>
                         </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletext1b_default" style="margin-right: 10px;">Script Text:</span>
                         <span class="inputfldnowidth_default"> 
                             <asp:TextBox runat="server" ID="txtScriptText" TextMode="MultiLine" Rows="3" CssClass="inputf_master"> </asp:TextBox>
                         </span>
                    </p>
                     <div style =" float:left; width:100px; padding-left:115px; font:bold 12px arial; ">
                    <asp:CheckBox runat="server" ID="chkIsDefault" Text="Default" ></asp:CheckBox>
                    </div>
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                     <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../Images/save-button.gif"
                                OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />
                    </span>
                     <span class="buttoncon_default">
                     <asp:ImageButton runat="server" id="btnCancel" ImageUrl="../Images/cancel-button.gif" width="57" height="25" OnClientClick="$find('mdlPopup').hide(); return false;" OnClick="btnCancel_Click" />
                     </span>
                    </p>
                    <asp:HiddenField ID="hfScriptID" runat="server" />
                    
                </div>
            </div>
        </div>
            
        </asp:Panel>
    
         <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewScript"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup"
            />
            
</asp:Content>

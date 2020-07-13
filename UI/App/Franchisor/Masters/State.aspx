<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Masters_State" Title="Untitled Page" Codebehind="State.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 352px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_pop
        {
            float: left;
            width: 328px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop
        {
            float: left;
            width: 328px;
        }
       .prenextband
        {
            float: left;
            width: 316px;
            border:solid 1px #CCCCCC;
            background-color:#DFE7ED;
            padding:4px 5px 4px 5px;
        }
        .innermain_1_pop
        {
            float: left;
            width: 313px;
            padding-top: 5px;
        }
        
         .wrapper_pop_l
        {
            float: left;
            width: 425px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_pop_l
        {
            float: left;
            width: 401px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop_l
        {
            float: left;
            width: 391px;
        }
       .innermain_pop_2
        {
            float: left;
            width: 369px;
        }
        
         .calright{float:right;}
         .rowbdr { width:389px; padding:5px; float:left; border:solid 1px #ccc; margin-top:5px;}
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
        
//        function HandleValidators(boolvalstatus)
//        {
//            if(arrvalidations != null)
//            {
//                var arrcount = 0;
//                while(arrcount < arrvalidations.length)
//                {
//                    if(arrcount == (arrvalidations.length - 1))
//                    {
//                        if(boolvalstatus == false)
//                        {
//                            document.getElementById(arrvalidations[arrcount]).innerHTML = '';
//                        }
//                    }   
//                    document.getElementById(arrvalidations[arrcount]).enabled = boolvalstatus;
//                    arrcount = arrcount + 1;
//                }
//            }
//            
//        }

        function EmptyBoxes()
        {
            ////debugger
            var txtName= document.getElementById(arrstateelemclientid[2]);
            var txtDescription= document.getElementById(arrstateelemclientid[3]);
            var txtStateCode= document.getElementById(arrstateelemclientid[6]);
            var ddlCountry=document.getElementById(arrstateelemclientid[4]);
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
                
            txtName.value = '';
            txtDescription.value = '';
            txtStateCode.value='';
            ddlCountry.options[0].selected = true;
            popuptitle.innerHTML = 'Add new State';
            
            
        }
        
        function HandleValidators()
        {
       /////debugger
            var txtName= document.getElementById(arrstateelemclientid[2]);
            
             if(isBlank(txtName, 'State Name'))
                return false;
           
            if(isBlank(document.getElementById('<%= this.txtStateCode.ClientID %>'), 'State Code'))
                return false;
            
            var txtStateCode= document.getElementById(arrstateelemclientid[6]); 
            var value=txtStateCode.value;  
            for(var i=0;i<value.length;i++)
	        {
	           
	            if(!isDigit(val.charAt(i)))
		        {
		            alert("State Code Should have some Character value.");
                    
                    return false;
                    
                    break;
                }
		    }
            if  (checkDropDown(document.getElementById('<%= this.ddlcountry.ClientID %>'),"Country")==false) {return false;}
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

            for (var i = 0; i < trim(txtName.value).length; i++) 
            {
  	            if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) 
  	            {
  	                document.getElementById('diverrorsummary').innerHTML='<li>Special characters are not allowed in the state name. Please remove them and try again.</li>';
  	                return false;
  	            }
  	        }
  	    }
        
        function isDigit(num) 
        {
	        if (num.length>1)
	        {
	            return false;
	        }
	        var string="1234567890";
	        if (string.indexOf(num)==-1)
	        {
	            return true;
	        }
	        return false;
	    }
        
        function mastercheckboxclick()
        {
            if(arrstateelemclientid == null)
                return;
            
            var grdState= document.getElementById(arrstateelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdState.rows[0].cells[0].childNodes.length)
            {
                if(grdState.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdState.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdState.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdState.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdState.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdState.rows[rowcount].cells.length > 1)
                    grdState.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                rowcount = rowcount + 1;
            }
            MultiSelect();
    
        }
        
        
        function checkallboxes()
        {
            if(arrstateelemclientid == null)
                return;
            
            var grdState= document.getElementById(arrstateelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdState.rows[0].cells[0].childNodes.length)
            {
                if(grdState.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdState.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            MultiSelect();
            
            var nodecount = 0;
            while(rowcount < (grdState.rows.length))
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdState.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdState.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdState.rows[rowcount].cells.length > 1)
                {
                    if(grdState.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
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
                var answer = confirm ("Are you sure you want to delete State(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate State(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate State(s)? ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
               
        }
        
        function MultiSelect()
        {  // //debugger
        
            if(arrstateelemclientid == null)
                return;
                
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrstateelemclientid[2]);
            var txtDescription= document.getElementById(arrstateelemclientid[3]);
            var grdState= document.getElementById(arrstateelemclientid[0]);
            var hfStateID= document.getElementById(arrstateelemclientid[5]);
            
//            if(arrcheckboxids!= null)
//            {
                var arrlength = grdState.rows.length;
                var count = 1;
                var nodecount = 0;
                while(count < arrlength )
                {
                    if(count == 1)
                    {
                        while(nodecount < grdState.rows[count].cells[0].childNodes.length)
                        {
                            if(grdState.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdState.rows[count].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    if(grdState.rows[count].cells[0].childNodes[nodecount].checked == true)
                    {
                        selectcount=selectcount+1;
                        selectedrow=count+1;
                        if (selectcount>1)
                        {
                            var btnEdit= document.getElementById(arrstateelemclientid[1]);
                            btnEdit.disabled=true;
                            btnEdit.src="../../Images/edit-button-d.gif"
                            hidediv();
                            txtName.value=  "";
                            txtDescription.value= "";
                            hfStateID.value=  "";
                            return selectcount
                        }
                    }
                    count = count + 1;
                }
                 
            //}
           // //debugger
            var btnEdit= document.getElementById(arrstateelemclientid[1]);
            btnEdit.disabled=false;
            btnEdit.src="../../Images/edit_butt_master.gif"
            if (selectcount==1)
                {
                }
                else
                {
                    txtName.value=  "";
                    txtDescription.value= "";
                    hfStateID.value=  "";
                }
                return selectcount;      
        }
        
        function EditState()
        {
        ////debugger
            if(arrstateelemclientid == null)
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
                var txtName= document.getElementById(arrstateelemclientid[2]);
                var txtDescription= document.getElementById(arrstateelemclientid[3]);
                var grdState= document.getElementById(arrstateelemclientid[0]);
                var ddlCountry=document.getElementById(arrstateelemclientid[4]);
                var hfStateID= document.getElementById(arrstateelemclientid[5]);
                var txtStateCode= document.getElementById(arrstateelemclientid[6]);
                
                var count = 0;
                var nodecount = 0;
                var codepos=0;
                while(count < (grdState.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdState.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdState.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                        var loopcount = 0;
                        var ininput = 0;
                        while(loopcount < grdState.rows[count + 1].cells[5].childNodes.length)
                        {
                            if(grdState.rows[count + 1].cells[5].childNodes[loopcount].tagName == "INPUT")
                            {
                                if(ininput == 0)
                                {
                                    codepos = loopcount;
                                }
                                ininput = ininput  + 1;
                            }
                            loopcount = loopcount + 1; 
                            
                        }
                    }
                    
                    if(grdState.rows[count + 1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                
                    if(grdState.rows[count + 1].cells[0].childNodes[nodecount].checked == true)
                    {  
                         showdiv();
                         txtName.value = grdState.rows[count+1].cells[1].innerHTML;
                         
                         if(grdState.rows[count+1].cells[2].innerHTML == '&nbsp;')
                            txtDescription.value  = '';
                         else
                            txtDescription.value = grdState.rows[count+1].cells[2].innerHTML;
                         txtStateCode.value = grdState.rows[count+1].cells[5].childNodes[codepos].value;
                         var countryname = grdState.rows[count+1].cells[3].innerHTML;
                         var countrycount = 0;
                         ////debugger
                         while(countrycount < ddlCountry.options.length)
                         {
                            if(ddlCountry.options[countrycount].innerHTML == countryname)
                            {
                                ddlCountry.options[countrycount].selected = true;
                                break;
                            }
                            countrycount = countrycount + 1;
                         }
                         
                        
                         hfStateID.value=count;
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
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">State</span>
                    <span class="headingright_default"></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            
            <%--<div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
                <div class="mainbody_titletxtleft">
                    State</div>
                <div class="mainbody_titlelnkright">
                    <a href="javascript:showdiv()">+ Add new State</a>
                    
                </div>
            </div>
            <div class="mainbody_inner_right">
            </div>--%>
            
            <div class="divbuttonsrow">
                <div class="pagealerttxtCNT" id="errordiv" runat="server">
                </div>
                
                <div class="master_buttons_row">
                                        
                    <div class="master_buttons_con">
                        <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="../../Images/del-button_master.gif"
                                OnClientClick="return ConfirmMultiselect('Deleted')" OnClick="btnDelete_Click" />
                    </div>
                    
                    
                    
                    <div class="master_buttons_con">
                        <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="../../Images/activate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('Activate')" OnClick="btnActivate_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="../../Images/deactivate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('DeActivate')" OnClick="btnDeActivate_Click" />
                    </div>
                   
                     <div class="master_buttons_con">
                        <a href="javascript:showdiv()"></a>
                        <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="../../Images/edit_butt_master.gif"
                            OnClientClick="return EditState()" OnClick="btnEdit_Click" />
                    </div>
                </div>
            
            </div>
            
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdState" AutoGenerateColumns="false" DataKeyNames="StateID"
                    CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdState_RowDataBound"
                    EnableSortingAndPagingCallbacks="False" AllowSorting="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdState_PageIndexChanging" OnSorting="grdState_Sorting">
                    <Columns>
                        <asp:BoundField DataField="" Visible="false"></asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%--    <asp:CheckBox runat="server" ID="chkMaster" CssClass="master_chkboxbox" />--%>
                                <input type="checkbox" id="chkMaster1" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%--  <asp:CheckBox runat="server" ID="chkRowChild" CssClass="master_chkboxbox" />--%>
                                <input type="checkbox" id="chkRowChild" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StateID" HeaderText="StateID"></asp:BoundField>
                        <asp:BoundField DataField="name" HeaderText="State" SortExpression="name">
                        </asp:BoundField>
                        <asp:BoundField DataField="description" HeaderText="Description">
                        </asp:BoundField>
                        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country">
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status">
                        </asp:BoundField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfStateCode" Value='<%# DataBinder.Eval(Container.DataItem, "StateCode") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
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
    <asp:LinkButton runat="server" ID="lnkhidden"></asp:LinkButton>
        <asp:Panel ID="Panel1" runat="server">
           
     <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Edit State</span>
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
                        <span class="titletextsmallbld_default" style="margin-right: 10px;">State:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                              <asp:TextBox runat="server" ID="txtName" Width="235px" CssClass="inputf_def"> </asp:TextBox>
                        </span>
                      </span>
                    </p>
                     <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;">State Code:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                               <asp:TextBox runat="server" ID="txtStateCode" Width="235px" CssClass="inputf_def" MaxLength="2"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;"> Country:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                            <asp:DropDownList runat="server" ID="ddlcountry" Width="240px" CssClass="inputf_def">
                    </asp:DropDownList>
                          </span>
                    </p>
                     <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;"> Description:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                        <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" Width="235px" CssClass="inputf_def"> </asp:TextBox>
                        </span>
                    </p>
                      <asp:HiddenField ID="hfStateID" runat="server" />
                   <asp:HiddenField ID="hfCityID" runat="server" Value="" />
                    <asp:HiddenField ID="hfZipFlag" runat="server" Value="" />
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                         <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../../Images/save-button.gif"
                                OnClick="btnSave_Click" OnClientClick="return HandleValidators();" /> 
                    </span>
                     <span class="buttoncon_default">
                       <asp:ImageButton runat="server" id="btnCancel" ImageUrl="../../Images/cancel-button.gif" width="57" height="25" OnClientClick="$find('mdlPopup').hide(); return false;"  />
                     </span>
                    </p>
                    
                </div>
            </div>
        </div> 
        </asp:Panel>
    
        
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="lnkhidden"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup"
             />
            
</asp:Content>


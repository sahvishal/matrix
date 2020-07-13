
<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="BMSMastersCommon_VanDetails" Codebehind="VanDetails.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 392px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_pop
        {
            float: left;
            width: 368px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop
        {
            float: left;
            width: 368px;
        }
       .prenextband
        {
            float: left;
            width: 356px;
            border:solid 1px #CCCCCC;
            background-color:#DFE7ED;
            padding:4px 5px 4px 5px;
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
            var txtName= document.getElementById(arrstateelemclientid[2]);
            var txtDescription= document.getElementById(arrstateelemclientid[3]);
            var ddlState=document.getElementById(arrstateelemclientid[4]);
             var txtVin=document.getElementById(arrstateelemclientid[6]);
             var txtMake=document.getElementById(arrstateelemclientid[7]);
             var txtReg=document.getElementById(arrstateelemclientid[8]);
              var hfVanID= document.getElementById(arrstateelemclientid[5]);
               var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
                
            txtName.value = '';
            txtVin.value='';
            txtDescription.value = '';
            txtMake.value='';
            txtReg.value='';
            ddlState.options[0].selected = true;
             hfVanID.value=  "";
             popuptitle.innerHTML = 'Add New Van';
            
        }
        
        function HandleValidators()
        {
        ////debugger
            if(isBlank(document.getElementById('<%= txtName.ClientID %>'), 'Van Name'))
                return false;
            if(!checkDropDown(document.getElementById('<%= ddlstate.ClientID %>'), 'Registration State'))
                return false;
            if(isBlank(document.getElementById('<%= txtVIN.ClientID %>'), 'VIN'))
                return false;
            if (isBlank(document.getElementById('<%= txtMake.ClientID %>'), 'Van Make'))
                return false;
            if(isBlank(document.getElementById('<%= txtReg.ClientID %>'), 'Registration Number'))
                return false;
            if (isBlank(document.getElementById('<%= txtDescription.ClientID %>'), 'Description'))
                return false;
            return true;
            
  	    }
        
        function mastercheckboxclick()
        {
            if(arrstateelemclientid == null)
                return;
            
            var grdVanDetails= document.getElementById(arrstateelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdVanDetails.rows[0].cells[0].childNodes.length)
            {
                if(grdVanDetails.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdVanDetails.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdVanDetails.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdVanDetails.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdVanDetails.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdVanDetails.rows[rowcount].cells.length > 1)
                    grdVanDetails.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                rowcount = rowcount + 1;
            }
            MultiSelect();
    
        }
        
        
        function checkallboxes()
        {
            if(arrstateelemclientid == null)
                return;
            
            var grdVanDetails= document.getElementById(arrstateelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdVanDetails.rows[0].cells[0].childNodes.length)
            {
                if(grdVanDetails.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdVanDetails.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            MultiSelect();
            
            var nodecount = 0;
            while(rowcount < grdVanDetails.rows.length )
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdVanDetails.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdVanDetails.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdVanDetails.rows[rowcount].cells.length > 1)
                {
                    if(grdVanDetails.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
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
                var answer = confirm ("Are you sure you want to delete Van(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate Van(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate Van(s)? ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
               
        }
        
        function MultiSelect()
        {  ////debugger
        
            if(arrstateelemclientid == null)
                return;
                
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrstateelemclientid[2]);
            var txtDescription= document.getElementById(arrstateelemclientid[3]);
            var grdVanDetails= document.getElementById(arrstateelemclientid[0]);
            var hfVanID= document.getElementById(arrstateelemclientid[5]);
             var txtVin=document.getElementById(arrstateelemclientid[6]);
             var txtMake=document.getElementById(arrstateelemclientid[7]);
             var txtReg=document.getElementById(arrstateelemclientid[8]);
//            if(arrcheckboxids!= null)
//            {
                var arrlength = grdVanDetails.rows.length;
                var count = 1;
                var nodecount = 0;
                while(count < arrlength )
                {
                    if(count == 1)
                    {
                        while(nodecount < grdVanDetails.rows[count].cells[0].childNodes.length)
                        {
                            if(grdVanDetails.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdVanDetails.rows[count].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    if(grdVanDetails.rows[count].cells[0].childNodes[nodecount].checked == true)
                    {
                        selectcount=selectcount+1;
                        selectedrow=count+1;
                        if (selectcount>1)
                        {
//                            var btnEdit= document.getElementById(arrstateelemclientid[1]);
//                            btnEdit.disabled=true;
//                            btnEdit.src="../Images/edit-button-d.gif"
                            hidediv();
                            txtName.value=  "";
                            txtDescription.value= "";
                            txtVin.value="";
                            txtMake.value="";
                            txtReg.value="";
                            hfVanID.value=  "";
                            return selectcount
                        }
                    }
                    count = count + 1;
                }
                 
            //}
           // //debugger
//            var btnEdit= document.getElementById(arrstateelemclientid[1]);
//            btnEdit.disabled=false;
//            btnEdit.src="../Images/edit_butt_master.gif"
            if (selectcount==1)
                {
                }
                else
                {
                    txtName.value=  "";
                    txtDescription.value= "";
                    txtVin.value="";
                    txtMake.value="";
                    txtReg.value="";
                    hfVanID.value=  "";
                }
                return selectcount;      
        }
        
        function EditVan()
        {
      // debugger
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
                var grdVanDetails= document.getElementById(arrstateelemclientid[0]);
                var ddlState=document.getElementById(arrstateelemclientid[4]);
                var hfVanID= document.getElementById(arrstateelemclientid[5]);
                var txtVin=document.getElementById(arrstateelemclientid[6]);
                var txtMake=document.getElementById(arrstateelemclientid[7]);
                var txtReg=document.getElementById(arrstateelemclientid[8]);
                
                var count = 0;
                var nodecount = 0;
                var vinpos = 0;
                var makepos=0;
                var regpos=0;
                
                while(count < (grdVanDetails.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdVanDetails.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdVanDetails.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                        var loopcount = 0;
                        var ininput = 0;
                        while(loopcount < grdVanDetails.rows[count + 1].cells[5].childNodes.length)
                        {
                            if(grdVanDetails.rows[count + 1].cells[5].childNodes[loopcount].tagName == "INPUT")
                            {
                                if(ininput == 0)
                                {
                                    vinpos = loopcount;
                                }
                                if(ininput==1)
                                {
                                  makepos=loopcount;
                                }
                                if(ininput==2)
                                {
                                  regpos=loopcount;
                                }
                                ininput = ininput  + 1;
                            }
                            loopcount = loopcount + 1; 
                            
                        }
                    }
                    
                    if(grdVanDetails.rows[count + 1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                
                    if(grdVanDetails.rows[count + 1].cells[0].childNodes[nodecount].checked == true)
                    {  
                         showdiv();
                         txtName.value = grdVanDetails.rows[count+1].cells[1].innerHTML;
                         
                         if(grdVanDetails.rows[count+1].cells[2].innerHTML == '&nbsp;')
                            txtDescription.value  = '';
                         else
                            txtDescription.value = grdVanDetails.rows[count+1].cells[2].innerHTML;
                         
                         txtVin.value = grdVanDetails.rows[count+1].cells[5].childNodes[vinpos].value;
                         txtMake.value = grdVanDetails.rows[count+1].cells[5].childNodes[makepos].value;
                         txtReg.value = grdVanDetails.rows[count+1].cells[5].childNodes[regpos].value;
                         var statename = grdVanDetails.rows[count+1].cells[3].innerHTML;
                         var statecount = 0;
                         ////debugger
                         while(statecount < ddlState.options.length)
                         {
                            if(ddlState.options[statecount].innerHTML == statename)
                            {
                                ddlState.options[statecount].selected = true;
                                break;
                            }
                            statecount = statecount + 1;
                         }
                         
                        
                         hfVanID.value=count;
                         break;
                    }
             
                  count++; 
                }
             }
            return true;
     }
     
     function EditVanName(lnkBtnID)
        {//debugger
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrstateelemclientid[2]);
            var txtDescription= document.getElementById(arrstateelemclientid[3]);
            var grdVanDetails= document.getElementById(arrstateelemclientid[0]);
            var ddlState=document.getElementById(arrstateelemclientid[4]);
            var hfVanID= document.getElementById(arrstateelemclientid[5]);
            var txtVin=document.getElementById(arrstateelemclientid[6]);
            var txtMake=document.getElementById(arrstateelemclientid[7]);
            var txtReg=document.getElementById(arrstateelemclientid[8]);
            
            var count = 0;
                var vinpos = 0;
                var makepos=0;
                var regpos=0;
            var nodecount = 0;
            while(count < (grdVanDetails.rows.length - 1))
            {
                while(nodecount<grdVanDetails.rows[count+1].cells[1].childNodes.length)
                {
                    if(grdVanDetails.rows[count+1].cells[1].childNodes[nodecount].nodeName=="A")
                        break;
                    nodecount++;
                }
                if(grdVanDetails.rows[count+1].cells[1].childNodes[nodecount].id == lnkBtnID)
                {  
                     showdiv();
                     txtName.value = grdVanDetails.rows[count+1].cells[1].childNodes[nodecount].innerHTML;
                     if( grdVanDetails.rows[count+1].cells[2].innerHTML == "&nbsp;")
                        txtDescription.value = '';
                     else
                        txtDescription.value = grdVanDetails.rows[count+1].cells[2].innerHTML;
                      
                      var loopcount = 0;
                        var ininput = 0;
                        while(loopcount < grdVanDetails.rows[count + 1].cells[5].childNodes.length)
                        {
                            if(grdVanDetails.rows[count + 1].cells[5].childNodes[loopcount].tagName == "INPUT")
                            {
                                if(ininput == 0)
                                {
                                    vinpos = loopcount;
                                }
                                if(ininput==1)
                                {
                                  makepos=loopcount;
                                }
                                if(ininput==2)
                                {
                                  regpos=loopcount;
                                }
                                ininput = ininput  + 1;
                            }
                            loopcount = loopcount + 1; 
                            
                        }
                  
                     
                     txtVin.value = grdVanDetails.rows[count+1].cells[5].childNodes[vinpos].value;
                     txtMake.value = grdVanDetails.rows[count+1].cells[5].childNodes[makepos].value;
                     txtReg.value = grdVanDetails.rows[count+1].cells[5].childNodes[regpos].value;
                     var statename = grdVanDetails.rows[count+1].cells[3].innerHTML;
                     var statecount = 0;
                     ////debugger
                     while(statecount < ddlState.options.length)
                     {
                        if(ddlState.options[statecount].innerHTML == statename)
                        {
                            ddlState.options[statecount].selected = true;
                            break;
                        }
                        statecount = statecount + 1;
                     }
                     
                    
                     hfVanID.value=count;
                     break;
                 }
              
                  count++; 
             }
             //debugger
             var sppopuptitle=document.getElementById('<%= this.sppopuptitle.ClientID %>');
             sppopuptitle.innerHTML="Edit Van";
             $find('mdlPopup').show();

             return false;
        }

</script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
        
        <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Vehicle List</span>
                    <span class="headingright_default"><a href="/Operations/Van/Create">+ Add new Van</a></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>           
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server"></div> 
            <div class="divbuttonsrow">
               
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
                    <div class="master_buttons_con" style="visibility:hidden; display:none;">
                        <a href="javascript:showdiv()"></a>                       
                    </div>
                </div>
            
            </div>
            
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdVanDetails" AutoGenerateColumns="false" DataKeyNames="VanID"
                    CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdVanDetails_RowDataBound"
                    EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdVanDetails_PageIndexChanging" AllowSorting="True" OnSorting="grdVanDetails_Sorting">
                    <Columns>
                        <asp:BoundField Visible="False"></asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="VanID" Visible="False" HeaderText="VanID"></asp:BoundField>
                        <%--<asp:BoundField DataField="name" HeaderText="Van" SortExpression="name">
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Van" SortExpression="name">
                            <ItemTemplate>
                                <a href="/Operations/Van/Edit?id=<%#DataBinder.Eval(Container.DataItem,"VanID")%>"> <%#DataBinder.Eval(Container.DataItem,"name")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="description" HeaderText="Description">
                        </asp:BoundField>
                        <asp:BoundField DataField="State" HeaderText="State" SortExpression="State">
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status">
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfvin" Value='<%# DataBinder.Eval(Container.DataItem, "VIN") %>' />
                                <asp:HiddenField runat="server" ID="hfMake" Value='<%# DataBinder.Eval(Container.DataItem, "Make") %>' />
                                <asp:HiddenField runat="server" ID="hfReg" Value='<%# DataBinder.Eval(Container.DataItem, "RegistrationNumber") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
        </div>
    </div>
       
    <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
       
    <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle"> Add New Van</span>
                        <span style="float: right">
                            <asp:ImageButton runat="server" ID="ibtnclosesymbol" ImageUrl="~/App/Images/close-button-symbol.gif" />
                        </span>
                    </p>
                     <p class="innermain_pop" style="border-top: solid 1px #ccc;">
                    <span style="float:right; margin-top:3px;">
                       <span class="graysmalltxt_default" id="Span2"><span class="reqiredmark"><sup>*</sup> </span>Mandatory Fields</span>
                       </span>
                    </p>
                      <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1a_default" style="width:130px">Van Name:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                              <asp:TextBox runat="server" ID="txtName" CssClass="inputf_def" Width="210px"> </asp:TextBox>
                        </span>
                      </span>
                    </p>
                      <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1a_default" style="width:130px">Registration State:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                              <asp:DropDownList runat="server" ID="ddlstate" CssClass="inputf_def" Width="210px" ></asp:DropDownList>
                        </span>
                      </span>
                    </p>
                      <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1a_default" style="width:130px">VIN:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                              <asp:TextBox runat="server" ID="txtVIN" CCssClass="inputf_def" Width="210px"> </asp:TextBox>
                        </span>
                      </span>
                    </p>
                       <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1a_default" style="width:130px">Van Make:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                             <asp:TextBox runat="server" ID="txtMake" CssClass="inputf_def" Width="210px"> </asp:TextBox>
                        </span>
                      </span>
                    </p>
                         <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1a_default" style="width:130px">Registration Number:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                             <asp:TextBox runat="server" ID="txtReg" CssClass="inputf_def" Width="210px"> </asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1a_default" style="width:130px"> Description:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" CssClass="inputf_def" Width="210px"> </asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default" style="padding-right:20px;">
                        <asp:ImageButton  runat="server" ID="btnSave" ImageUrl="../Images/save-button.gif"
                        OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />
                    </span>                     
                    </p>
                        <asp:HiddenField ID="hfVanID" runat="server" /> 
                </div>
            </div>
        </div>
    </asp:Panel>        
            
</asp:Content>
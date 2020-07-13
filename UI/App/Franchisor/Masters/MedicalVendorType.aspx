<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Masters_MedicalVendorType" Title="Untitled Page" Codebehind="MedicalVendorType.aspx.cs" %>

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
        .orngbold16_default
        {
            font: bold 16px arial;
            color: #F37C00;
            float: left;
        }
        .orngbold14_default
        {
            font: bold 14px arial;
            color: #F37C00;
        }
        .btextblu12
        {
            font: bold 12px arial;
            color: #287AA8;
        }
        .titletextnowidth_default
        {
            float: left;
            margin-right: 5px;
            padding-top: 3px;
            font-weight: bold;
            color: #000;
        }
        .ttxtnowidthnormal_default
        {
            float: left;
            margin-right: 5px;
            padding-top: 3px;
            font-weight: normal;
            color: #000;
        }
        .calright{float:right;}
    </style>
    <script language="javascript" type="text/javascript">
        function hidediv() 
        { ////debugger
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
            var txtName= document.getElementById("<%= this.txtName.ClientID %>");
            var txtDescription= document.getElementById("<%= this.txtDescription.ClientID %>");
             var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
               
            
            txtName.value = '';
            txtDescription.value = '';
            popuptitle.innerHTML = 'Add new Medical Vendor Type';
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
        
        function HandleValidators()
        {
        ////debugger
            var txtName= document.getElementById(arrjsmedvendorelems[1]);
            
             if(isBlank(txtName, 'MV Type'))
                return false;
            
           
            
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

            for (var i = 0; i < trim(txtName.value).length; i++) 
            {
  	            if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) 
  	            {
  	                alert("Special characters are not allowed in the MV type. Please remove them and try again.");
  	                return false;
  	            }
  	        }
            
        }
          
        function mastercheckboxclick()
        {
            if(arrjsmedvendorelems == null)
                return;
                
            var grdMedicalVendorType = document.getElementById(arrjsmedvendorelems[0]);   
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdMedicalVendorType.rows[0].cells[0].childNodes.length)
            {
                if(grdMedicalVendorType.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdMedicalVendorType.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdMedicalVendorType.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdMedicalVendorType.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdMedicalVendorType.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdMedicalVendorType.rows[rowcount].cells.length > 1)
                    grdMedicalVendorType.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                rowcount = rowcount + 1;
            }
        
            MultiSelect();
            
        }
        
        
        function checkallboxes()
        {
            
            if(arrjsmedvendorelems == null)
                return;
            
            MultiSelect();
            var grdMedicalVendorType = document.getElementById(arrjsmedvendorelems[0]);   
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdMedicalVendorType.rows[0].cells[0].childNodes.length)
            {
                if(grdMedicalVendorType.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdMedicalVendorType.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdMedicalVendorType.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdMedicalVendorType.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdMedicalVendorType.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
            
                if(grdMedicalVendorType.rows[rowcount].cells.length > 1)
                {
                    if( grdMedicalVendorType.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
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
                var answer = confirm ("Are you sure you want to delete Medical Vendor Type(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate Medical Vendor Type(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate Medical Vendor Type(s)? ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select an item from the table");
                return false;
            }
               
        }
        
        function MultiSelect()
        {  // //debugger
            if(arrjsmedvendorelems == null)
                return;
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrjsmedvendorelems[1]);
            var txtDescription= document.getElementById(arrjsmedvendorelems[2]);
            var grdMedicalVendorType= document.getElementById(arrjsmedvendorelems[0]);
            var hfMedicalVendorTypeID= document.getElementById(arrjsmedvendorelems[3]);

                var arrlength = grdMedicalVendorType.rows.length;
                var count = 1;
                var nodecount = 0;
                while(count < arrlength)
                {
                    if(count == 1)
                    {
                        while(nodecount < grdMedicalVendorType.rows[count].cells[0].childNodes.length)
                        {
                            if(grdMedicalVendorType.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdMedicalVendorType.rows[count].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    
                
                    if(grdMedicalVendorType.rows[count].cells[0].childNodes[nodecount].checked == true)
                    {
                        selectcount=selectcount+1;
                        selectedrow=count+1;
                        if (selectcount>1)
                        {
                       //     var btnEdit= document.getElementById(arrjsmedvendorelems[4]);
                       //     btnEdit.disabled=true;
                       //    btnEdit.src="../../Images/edit-button-d.gif"
                            hidediv();
                            txtName.value=  "";
                            txtDescription.value= "";
                            hfMedicalVendorTypeID.value=  "";
                            return selectcount
                        }
                    }
                    count = count + 1;
                }
                 
            //}
     //      var btnEdit= document.getElementById(arrjsmedvendorelems[4]);
     //      btnEdit.disabled=false;
     //      btnEdit.src="../../Images/edit_butt_master.gif"
           if (selectcount==1)
           {
                        // showdiv();
                         //  txtName.value=  grdCountry.rows[selectedrow].cells[1].innerHTML;
                         // txtDescription.value=  grdCountry.rows[selectedrow].cells[2].innerHTML;
                         // hfCountryID.value=  grdCountry.rows[selectedrow].cells[0].innerHTML;
           }
           else
           {
                txtName.value=  "";
                txtDescription.value= "";
                hfMedicalVendorTypeID.value=  "";
           }
           return selectcount            
    }
    function EditMedicalVendorType()
    {
    
        if(arrjsmedvendorelems == null)
            return;
            
        if (MultiSelect()!=1)
        {
            alert("Please select an item from the table");
            return false;
        }
        else
        {
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrjsmedvendorelems[1]);
            var txtDescription= document.getElementById(arrjsmedvendorelems[2]);
            var grdMedicalVendorType= document.getElementById(arrjsmedvendorelems[0]);
            var hfMedicalVendorTypeID= document.getElementById(arrjsmedvendorelems[3]);
            //var hfpageindex= document.getElementById("hfpageindex");
            var count = 0;
            var nodecount = 0;
            while(count < (grdMedicalVendorType.rows.length - 1))
            {
            
                if(count == 0)
                {
                    while(nodecount < grdMedicalVendorType.rows[count + 1].cells[0].childNodes.length)
                    {
                        if(grdMedicalVendorType.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                    
                if(grdMedicalVendorType.rows[count + 1].cells.length <= 1)
                {
                    count = count + 1;
                    continue;
                }
            
            
                if(grdMedicalVendorType.rows[count + 1].cells[0].childNodes[nodecount].checked == true)
                {  
                    showdiv();
                    txtName.value=  grdMedicalVendorType.rows[count+1].cells[1].childNodes[nodecount].innerHTML;
                    txtDescription.value=  grdMedicalVendorType.rows[count+1].cells[2].innerHTML;
                    hfMedicalVendorTypeID.value= count;
                    break;
                }
                count++; 
             }
        
           }
       return true;
     }
     
     function EditMedical(lnkBtnID)
     {
            //debugger
            var txtName= document.getElementById(arrjsmedvendorelems[1]);
            var txtDescription= document.getElementById(arrjsmedvendorelems[2]);
            var grdMedicalVendorType= document.getElementById(arrjsmedvendorelems[0]);
            var hfMedicalVendorTypeID= document.getElementById(arrjsmedvendorelems[3]);
            var count = 0;
            var nodecount=0;
            while(count < (grdMedicalVendorType.rows.length - 1))
            {
                while(nodecount<grdMedicalVendorType.rows[count+1].cells[1].childNodes.length)
                {
                    if(grdMedicalVendorType.rows[count+1].cells[1].childNodes[nodecount].nodeName=="A")
                        break;
                    nodecount++;
                }
                if(grdMedicalVendorType.rows[count+1].cells[1].childNodes[nodecount].id == lnkBtnID)
                {  
                    txtName.value = grdMedicalVendorType.rows[count+1].cells[1].childNodes[nodecount].innerHTML;
                    if(grdMedicalVendorType.rows[count+1].cells[2].innerHTML != '&nbsp;')
                        txtDescription.value = grdMedicalVendorType.rows[count+1].cells[2].innerHTML;
                      
                    hfMedicalVendorTypeID.value= count;
                    break;
                 }
              
                  count++; 
             }
             
            $find('mdlPopup').show();

             return false;
     }
     
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
        
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Medical Vendor Type</span>
                    <span class="headingright_default"><asp:LinkButton ID="addNewType" runat="server" Text="+ Add new Medical Vendor Type" OnClientClick="EmptyBoxes();" /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            <%--<div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
                <div class="mainbody_titletxtleft">
                    Medical Vendor Type</div>
                <div class="mainbody_titlelnkright">
                   <a href="javascript:showdiv()">+ Add new Type</a>
                    <asp:LinkButton ID="addNewType" runat="server" Text="+ Add new Medical Vendor Type" OnClientClick="EmptyBoxes();" />
                    </div>
            </div>
            <div class="mainbody_inner_right">
            </div>--%>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server"></div> 
            <div class="divbuttonsrow">
                <div class="pagealerttxtCNT" id="errordiv" runat="server">
                </div>
                
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
                    
                     <div class="master_buttons_con" style=" visibility:hidden;display:none">
                        <a href="javascript:showdiv()"></a>
                        <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditMedicalVendorType()"
                            ImageUrl="../../Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                    </div>
                    
                </div>
            
            </div>
            
            
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdMedicalVendorType" AutoGenerateColumns="false"
                    DataKeyNames="MedicalVendorTypeID" CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdMedicalVendorType_RowDataBound"
                    EnableSortingAndPagingCallbacks="False" AllowPaging="true" AllowSorting="true" PageSize="10" OnPageIndexChanging="grdMedicalVendorType_PageIndexChanging" OnSorting="grdMedicalVendorType_Sorting">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--<asp:BoundField DataField="name" HeaderText="Medical Vendor Type" SortExpression="name">
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Medical Vendor Type">
                        <ItemTemplate>                        
                        <asp:LinkButton ID="lnkbtnmedicaltype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"name") %>' >
                        </asp:LinkButton>                        
                        </ItemTemplate>                        
                        </asp:TemplateField>
                        <asp:BoundField DataField="description" HeaderText="Description">
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status">
                        </asp:BoundField>
                        <asp:BoundField DataField="MedicalVendorTypeID" Visible="false" />
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
    
    <asp:Panel ID="Panel1" runat="server" CssClass="PopUp">
    
   <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Add New Medical Vendor Type</span>
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
                        <span class="titletext1b_default">MV Type:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                             <asp:TextBox ID="txtName" runat="server" CssClass="inputf_def" Width="210px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                      <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1b_default"> Description:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server" CssClass="inputf_def" Width="210px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                     <asp:ImageButton runat="server" id="btnCancel"  ImageUrl="../../Images/cancel-button.gif" width="57" height="25" OnClientClick="$find('mdlPopup').hide(); return false;" OnClick="btnCancel_Click" />
                    </span>
                     <span class="buttoncon_default">
                   <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../../Images/save-button.gif"
                        OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />                       </span>
                    </p>
                           <asp:HiddenField ID="hfMedicalVendorTypeID" runat="server" />
                </div>
            </div>
        </div>
    
        </asp:Panel>
    
      <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewType"
        PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup"
        />
    
</asp:Content>


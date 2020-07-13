<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Masters_HostType" Title="Untitled Page" Codebehind="HostType.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
              //  document.getElementById('bottom_bdr_master').style.visibility = 'hidden'; 
               
                
            } 
            else if (document.layers)
            { // Netscape 4
               // document.hideshow.visibility = 'hidden'; 
                
            } 
            else 
            { // IE 4 
               // document.all.hideshow.style.visibility = 'hidden'; 
                
            } 
            //HandleValidators(false);

        } 
        
        function showdiv() 
        { 
            if (document.getElementById) 
            { // DOM3 = IE5, NS6 
               // document.getElementById('bottom_bdr_master').style.visibility = 'visible'; 
            } 
            else if (document.layers)
            { // Netscape 4
               // document.hideshow.visibility = 'visible'; 
            } 
            else 
            { // IE 4 
              //  document.all.hideshow.style.visibility = 'visible'; 
            } 
            //HandleValidators(true);

        }
        
        
//        function DisableAll()
//        {
//            document.getElementById('<%= this.btnEdit.ClientID %>').disabled = 'disabled';
//            document.getElementById('<%= this.btnDelete.ClientID %>').disabled = 'disabled';
//            document.getElementById('<%= this.btnActivate.ClientID %>').disabled = 'disabled';
//            document.getElementById('<%= this.btnDeActivate.ClientID %>').disabled = 'disabled';
//        }
//        
//        function EnableAll()
//        {
//            document.getElementById('<%= this.btnEdit.ClientID %>').disabled = '';
//            document.getElementById('<%= this.btnDelete.ClientID %>').disabled = '';
//            document.getElementById('<%= this.btnActivate.ClientID %>').disabled = '';
//            document.getElementById('<%= this.btnDeActivate.ClientID %>').disabled = '';
//        }
        
        
        function EmptyBoxes()
        {
           // //debugger
           var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            var txtName= document.getElementById(arrhosttypeelemclientid[2]);
            var txtDescription= document.getElementById(arrhosttypeelemclientid[3]);
              var hfHostTypeID= document.getElementById(arrhosttypeelemclientid[4]);
              
            txtName.value = '';
            txtDescription.value = '';
            popuptitle.innerHTML = 'Add New Host Type';
            hfHostTypeID.value=  "";
            
        }
        

        function HandleValidators()
        {
        ////debugger
            var txtName= document.getElementById(arrhosttypeelemclientid[2]);
            var txtDescription= document.getElementById(arrhosttypeelemclientid[3]);
            
            if(isBlank(txtName, 'Host Type'))
                return false;
            
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

            for (var i = 0; i < trim(txtName.value).length; i++) 
            {
  	            if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) 
  	            {
  	                alert("Special characters are not allowed in the host type name. Please remove them and try again.");
  	                return false;
  	            }
  	        }
            
        }
          
        function mastercheckboxclick()
        {
        ////debugger
            if(arrhosttypeelemclientid == null)
                return;
            var grdHostType= document.getElementById(arrhosttypeelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdHostType.rows[0].cells[0].childNodes.length)
            {
                if(grdHostType.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdHostType.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
//            if(mstrchkbox.checked == true)
//                EnableAll();
//            else
//                DisableAll();
            
            rowcount = 1;
            var nodecount = 0;
            while(rowcount < grdHostType.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdHostType.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdHostType.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdHostType.rows[rowcount].cells.length > 1)
                    grdHostType.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked; 
                rowcount = rowcount + 1;
            }
            MultiSelect();

        }
        
        
        function checkallboxes()
        {
        ////debugger
            if(arrhosttypeelemclientid == null)
                return;
            var grdHostType= document.getElementById(arrhosttypeelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdHostType.rows[0].cells[0].childNodes.length)
            {
                if(grdHostType.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdHostType.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            MultiSelect();
            
            var nodecount = 0;
            while(rowcount < grdHostType.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdHostType.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdHostType.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdHostType.rows[rowcount].cells.length > 1)
                {
                    if(grdHostType.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
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
                var answer = confirm ("Are you sure you want to delete Host Type(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate Host Type(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate Host Type(s)? ")
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
            
            if(arrhosttypeelemclientid == null)
                return;
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrhosttypeelemclientid[2]);
            var txtDescription= document.getElementById(arrhosttypeelemclientid[3]);
            var grdHostType= document.getElementById(arrhosttypeelemclientid[0]);
            var hfHostTypeID= document.getElementById(arrhosttypeelemclientid[4]);
                           
    
            var arrlength = grdHostType.rows.length;
            var count = 1;
            var nodecount = 0;
            while(count < arrlength)
            {
                if(count == 1)
                {
                    while(nodecount < grdHostType.rows[count].cells[0].childNodes.length)
                    {
                        if(grdHostType.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdHostType.rows[count].cells.length <= 1)
                {
                    count = count + 1;
                    continue;
                }
                
                if(grdHostType.rows[count].cells[0].childNodes[nodecount].checked == true)
                {
                    selectcount=selectcount+1;
                    selectedrow=count+1;
                    
                    if (selectcount>1)
                    {
//                        var btnEdit= document.getElementById(arrhosttypeelemclientid[1]);
//                        btnEdit.disabled=true;
//                        btnEdit.src="../../Images/edit-button-d.gif"
                        hidediv();
                        txtName.value=  "";
                        txtDescription.value= "";
                        hfHostTypeID.value=  "";
                        return selectcount;
                    }
                }
                count = count + 1;
            }
                 
         //   }
           // //debugger
//            var btnEdit= document.getElementById(arrhosttypeelemclientid[1]);
//            btnEdit.disabled=false;
//            btnEdit.src="../../Images/edit_butt_master.gif"
            if (selectcount==1)
            {
            }
            else
            {
                txtName.value=  "";
                txtDescription.value= "";
                hfHostTypeID.value=  "";
            }
            return selectcount;        
        }
        
        
        function EditHostType()
        {       
        //debugger 
            if(arrhosttypeelemclientid == null)
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
                var txtName= document.getElementById(arrhosttypeelemclientid[2]);
                var txtDescription= document.getElementById(arrhosttypeelemclientid[3]);
                var grdHostType= document.getElementById(arrhosttypeelemclientid[0]);
                var hfHostTypeID= document.getElementById(arrhosttypeelemclientid[4]);
                
                var count = 0;
               
                var nodecount = 0;
                while(count < (grdHostType.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdHostType.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdHostType.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdHostType.rows[count+1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    
                    if(grdHostType.rows[count+1].cells[0].childNodes[nodecount].checked == true)
                    {  
                         showdiv();
                         txtName.value = grdHostType.rows[count+1].cells[1].innerHTML;
                         if( grdHostType.rows[count+1].cells[2].innerHTML == "&nbsp;")
                            txtDescription.value = '';
                         else
                            txtDescription.value = grdHostType.rows[count+1].cells[2].innerHTML;
                          
                         hfHostTypeID.value= count;
                         break;
                     }
                  
                      count++; 
                 }
                                  
             }
             return true;
             
        }
        function EditHostType(lnkBtnID)
        {//debugger
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrhosttypeelemclientid[2]);
            var txtDescription= document.getElementById(arrhosttypeelemclientid[3]);
            var grdHostType= document.getElementById(arrhosttypeelemclientid[0]);
            var hfHostTypeID= document.getElementById(arrhosttypeelemclientid[4]);
            
            var count = 0;
           
            var nodecount = 0;
            while(count < (grdHostType.rows.length - 1))
            {
                while(nodecount<grdHostType.rows[count+1].cells[1].childNodes.length)
                {
                    if(grdHostType.rows[count+1].cells[1].childNodes[nodecount].nodeName=="A")
                        break;
                    nodecount++;
                }
                
                if(grdHostType.rows[count+1].cells[1].childNodes[nodecount].id == lnkBtnID)
                {  
                     showdiv();
                     txtName.value = grdHostType.rows[count+1].cells[1].childNodes[nodecount].innerHTML;
                     if( grdHostType.rows[count+1].cells[2].innerHTML == "&nbsp;")
                        txtDescription.value = '';
                     else
                        txtDescription.value = grdHostType.rows[count+1].cells[2].innerHTML;
                      
                     hfHostTypeID.value= count;
                     break;
                 }
              
                  count++; 
             }
             //debugger
             var sppopuptitle=document.getElementById('<%= this.sppopuptitle.ClientID %>');
             sppopuptitle.innerHTML="Edit Host Type";
             $find('mdlPopup').show();

             return false;
        }
     
    </script>


<div class="mainbody_outer">
            <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Host Type</span>
                    <span class="headingright_default"><asp:LinkButton ID="addNewHostType" runat="server" Text="+ Add New Host Type Name" OnClientClick='EmptyBoxes();'  /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            
               <%-- <div class="mainbody_inner_left">
                </div>
                
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft">
                        </div>
                    <div class="mainbody_titlelnkright">
                       
                        
                    </div>
                </div>
                
                <div class="mainbody_inner_right">
                </div>--%>
                <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server"></div> 
                 <%--******************* Buttons Row above Grid ***************** --%>
                <div class="divbuttonsrow">
                
                    <div class="master_buttons_row">
                        
                            <div class="master_buttons_con">
                            <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/App/Images/del-button_master.gif"
                                OnClientClick="return ConfirmMultiselect('Deleted')" OnClick="btnDelete_Click" />
                        </div>
                      
                        <div class="master_buttons_con">
                            <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="~/App/Images/activate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('Activate')" OnClick="btnActivate_Click" />
                        </div>
                        
                         <div class="master_buttons_con">
                            <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="~/App/Images/deactivate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('DeActivate')" OnClick="btnDeActivate_Click" />
                        </div>
                         <div class="master_buttons_con" style="visibility:hidden; display:none;">
                            <a href="javascript:showdiv()"></a>
                            <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditHostType();"
                                ImageUrl="~/App/Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                        </div>
                        
                    </div>
                
                </div>
                
                <%--**********************************************************--%>
                
                <div class="main_area_bdrnone" id="divGrdHostType" runat="server">
                    <asp:GridView runat="server" ID="grdHostType" AutoGenerateColumns="false" DataKeyNames="HostTypeID"
                        CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdHostType_RowDataBound"
                        EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdHostType_PageIndexChanging" AllowSorting="True" OnSorting="grdHostType_Sorting">
                        <Columns>
                           
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="name" HeaderText="HostType" SortExpression="name desc">
                            </asp:BoundField>--%>
                            <asp:TemplateField SortExpression="name desc" HeaderText="HostType">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnHostType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"name") %>' ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="description" HeaderText="Description">
                            </asp:BoundField>
                            <asp:BoundField DataField="active" HeaderText="Status">
                            </asp:BoundField>
                            <asp:BoundField DataField="HostTypeID" Visible="false" />
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                
                
                
                
            </div>
        </div>
        
        
        <asp:Panel ID="Panel1" runat="server" CssClass="PopUp">
       <div class="wrapper_pop"  id="PopUpDiv">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle"> Add New Host Type</span>
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
                        <span class="titletextsmallbld_default" style="margin-right: 10px;">HostType:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                             <asp:TextBox ID="txtName" runat="server" CssClass="inputf_def" Width="235px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;">Description:</span>
                         <span class="inputfldnowidth_default"> <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server" Width="235px" CssClass="inputf_def"></asp:TextBox></span>
                    </p>
                   
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                     <asp:ImageButton runat="server" CausesValidation="true" ID="btnSave" ImageUrl="~/App/Images/save-button.gif"
                            OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />
                    </span>
                     <span class="buttoncon_default">
                     <asp:ImageButton runat="server" CausesValidation="true" ID="btnCancel" ImageUrl="~/App/Images/cancel-button.gif" OnClientClick="$find('mdlPopup').hide(); return false;"
                            OnClick="btnCancel_Click" />  
                     </span>
                    </p>
                    
                </div>
            </div>
        </div>
         <asp:HiddenField ID="hfHostTypeID" runat="server" />
        </asp:Panel>
         <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewHostType" 
                    PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup" />


</asp:Content>

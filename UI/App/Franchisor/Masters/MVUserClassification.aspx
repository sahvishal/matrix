<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Masters_MVUserClassification" Codebehind="MVUserClassification.aspx.cs" %>

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
        
        function EmptyBoxes()
        {
            ////debugger
            var txtName= document.getElementById(arrmvuserclassificationelemclientid[2]);
            var txtDescription= document.getElementById(arrmvuserclassificationelemclientid[3]);
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            
            txtName.value = '';
            txtDescription.value = '';
            popuptitle.innerHTML = 'Add New MV Classification';
            
        }
        

        
        function HandleValidators()
        {
        ////debugger
            var txtName= document.getElementById(arrmvuserclassificationelemclientid[2]);
            var txtDescription= document.getElementById(arrmvuserclassificationelemclientid[3]);
            
             if(isBlank(txtName, 'MV Classification'))
                return false;
            
           
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

            for (var i = 0; i < trim(txtName.value).length; i++) 
            {
  	            if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) 
  	            {
  	                 
  	                alert("Special characters are not allowed in the MV Classification. Please remove them and try again.");
  	                return false;
  	            }
  	        }
            
        }
          
        function mastercheckboxclick()
        {
        ////debugger
            if(arrmvuserclassificationelemclientid == null)
                return;
            var grdMVUserClassification= document.getElementById(arrmvuserclassificationelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdMVUserClassification.rows[0].cells[0].childNodes.length)
            {
                if(grdMVUserClassification.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdMVUserClassification.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            
            rowcount = 1;
            var nodecount = 0;
            while(rowcount < grdMVUserClassification.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdMVUserClassification.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdMVUserClassification.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdMVUserClassification.rows[rowcount].cells.length > 1)
                    grdMVUserClassification.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked; 
                rowcount = rowcount + 1;
            }
            MultiSelect();

        }
        
        
        function checkallboxes()
        {
        ////debugger
            if(arrmvuserclassificationelemclientid == null)
                return;
            var grdMVUserClassification= document.getElementById(arrmvuserclassificationelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdMVUserClassification.rows[0].cells[0].childNodes.length)
            {
                if(grdMVUserClassification.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdMVUserClassification.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            MultiSelect();
            
            var nodecount = 0;
            while(rowcount < grdMVUserClassification.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdMVUserClassification.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdMVUserClassification.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdMVUserClassification.rows[rowcount].cells.length > 1)
                {
                    if(grdMVUserClassification.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
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
                var answer = confirm ("Are you sure you want to delete Classification(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate Classification(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate Classification(s)? ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
               
        }
        
        function MultiSelect()
        {   ////debugger
            //alert('i m in');
            if(arrmvuserclassificationelemclientid== null)
                return;
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrmvuserclassificationelemclientid[2]);
            var txtDescription= document.getElementById(arrmvuserclassificationelemclientid[3]);
            var grdMVUserClassification= document.getElementById(arrmvuserclassificationelemclientid[0]);
            var hfMVUserClassificationID= document.getElementById(arrmvuserclassificationelemclientid[4]);
                           
    
            var arrlength = grdMVUserClassification.rows.length;
            var count = 1;
            var nodecount = 0;
            while(count < arrlength)
            {
                if(count == 1)
                {
                    while(nodecount < grdMVUserClassification.rows[count].cells[0].childNodes.length)
                    {
                        if(grdMVUserClassification.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdMVUserClassification.rows[count].cells.length <= 1)
                {
                    count = count + 1;
                    continue;
                }
                
                if(grdMVUserClassification.rows[count].cells[0].childNodes[nodecount].checked == true)
                {
                    selectcount=selectcount+1;
                    selectedrow=count+1;
                    
                    if (selectcount>1)
                    {
                        var btnEdit= document.getElementById(arrmvuserclassificationelemclientid[1]);
                        btnEdit.disabled=true;
                        btnEdit.src="../../Images/edit-button-d.gif"
                        hidediv();
                        txtName.value=  "";
                        txtDescription.value= "";
                        hfMVUserClassificationID.value=  "";
                        return selectcount;
                    }
                }
                count = count + 1;
            }
                 
         //   }
            ////debugger
            var btnEdit= document.getElementById(arrmvuserclassificationelemclientid[1]);
            btnEdit.disabled=false;
            btnEdit.src="../../Images/edit_butt_master.gif"
            if (selectcount==1)
            {
            }
            else
            {
                txtName.value=  "";
                txtDescription.value= "";
                hfMVUserClassificationID.value=  "";
            }
            return selectcount;        
        }
        
        
        function EditMVUserClassification()
        {        
            if(arrmvuserclassificationelemclientid== null)
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
                var txtName= document.getElementById(arrmvuserclassificationelemclientid[2]);
                var txtDescription= document.getElementById(arrmvuserclassificationelemclientid[3]);
                var grdMVUserClassification= document.getElementById(arrmvuserclassificationelemclientid[0]);
                var hfMVUserClassificationID= document.getElementById(arrmvuserclassificationelemclientid[4]);
                
                var count = 0;
               
                var nodecount = 0;
                while(count < (grdMVUserClassification.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdMVUserClassification.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdMVUserClassification.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdMVUserClassification.rows[count+1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    
                    if(grdMVUserClassification.rows[count+1].cells[0].childNodes[nodecount].checked == true)
                    {  
                         showdiv();
                         txtName.value = grdMVUserClassification.rows[count+1].cells[1].innerHTML;
                         if( grdMVUserClassification.rows[count+1].cells[2].innerHTML == "&nbsp;")
                            txtDescription.value = '';
                         else
                            txtDescription.value = grdMVUserClassification.rows[count+1].cells[2].innerHTML;
                          
                         hfMVUserClassificationID.value= count;
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
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">MVUserClassification</span>
                    <span class="headingright_default"><asp:LinkButton ID="addNewMVUserClassification" runat="server" Text="+ Add new MV Classification" OnClientClick='EmptyBoxes();'  /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
               <%-- <div class="mainbody_inner_left">
                </div>
                
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft">
                        MVUserClassification</div>
                    <div class="mainbody_titlelnkright">
                        
                        <asp:LinkButton ID="addNewMVUserClassification" runat="server" Text="+ Add new MV Classification" OnClientClick='EmptyBoxes();'  />
                    </div>
                </div>
                
                <div class="mainbody_inner_right">
                </div>--%>
                <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false" runat="server"></div> 
                 <%--******************* Buttons Row above Grid ***************** --%>
                <div class="divbuttonsrow">
                
                    <%--<div class="pagealerttxtCNT" id="errordiv" runat="server">
                    </div>--%>
                
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
                     
                         <div class="master_buttons_con">
                            <a href="javascript:showdiv()"></a>
                            <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditMVUserClassification()"
                                ImageUrl="~/App/Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                        </div>
                        
                    </div>
                
                </div>
                
                <%--**********************************************************--%>
                
                <div class="main_area_bdrnone">
                    <asp:GridView runat="server" ID="grdMVUserClassification" AutoGenerateColumns="false" DataKeyNames="MVUserClassificationID"
                        CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdMVUserClassification_RowDataBound"
                        EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdMVUserClassification_PageIndexChanging" AllowSorting="True" OnSorting="grdMVUserClassification_Sorting" >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="name" HeaderText="Classification" SortExpression="name desc">
                            </asp:BoundField>
                            <asp:BoundField DataField="description" HeaderText="Description">
                            </asp:BoundField>
                            <asp:BoundField DataField="active" HeaderText="Status">
                            </asp:BoundField>
                            <asp:BoundField DataField="MVUserClassificationID" Visible="False" />
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                
                
                
                
            </div>
        </div>
        
        
        <asp:Panel ID="Panel1" runat="server">
            
         <div class="wrapper_pop"  id="Div1">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Add New MV Classification</span>
                        <span style="float: right">
                            <asp:ImageButton runat="server" ID="ibtnclosesymbol" ImageUrl="~/App/Images/close-button-symbol.gif" />
                        </span>
                    </p>
                      <p class="innermain_pop" style="border-top: solid 1px #ccc;">
                      <span id="diverrorsummary" style="float:left"></span>
                    <span style="float:right; margin-top:3px;">
                       <span class="graysmalltxt_default"><span class="reqiredmark"><sup>*</sup> </span>Mandatory Fields</span>
                       </span>
                    </p>
                    <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletextsmallbld1_default" style="margin-right: 15px;"> Classification:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtName" runat="server" CssClass="inputf_def" Width="215px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletextsmallbld1_default" style="margin-right: 15px;">Description:</span>
                         <span class="inputfldnowidth_default"><asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server" CssClass="inputf_def" Width="215px"></asp:TextBox></span>
                    </p>
                    <asp:HiddenField ID="hfMVUserClassificationID" runat="server" />
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                     <asp:ImageButton runat="server" CausesValidation="true" ID="btnCancel" ImageUrl="~/App/Images/cancel-button.gif" OnClientClick="$find('mdlPopup').hide(); return false;"
                            OnClick="btnCancel_Click" />
                    </span>
                     <span class="buttoncon_default">
                      <asp:ImageButton runat="server" CausesValidation="true" ID="btnSave" ImageUrl="~/App/Images/save-button.gif"
                            OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />  
                     </span>
                    </p>
                    
                </div>
            </div>
        </div>
            
            
            
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewMVUserClassification"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup"
             />


</asp:Content>
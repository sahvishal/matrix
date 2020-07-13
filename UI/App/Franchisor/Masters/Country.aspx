<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Masters_Country" Title="Untitled Page" Codebehind="Country.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
.wrapper_pop {float: left; width: 352px; padding: 10px; background-color: #f5f5f5; }
.wrapperin_pop {float: left; width: 328px; border: solid 2px #4888AB; padding: 10px; background-color: #fff; }
.innermain_pop {float: left; width: 328px; }
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
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            var txtName= document.getElementById(arrcountryelemclientid[2]);
            var txtDescription= document.getElementById(arrcountryelemclientid[3]);
            var txtCountryCode= document.getElementById('<%= this.txtCountryCode.ClientID %>'); 
            
            txtName.value = '';
            txtDescription.value = '';
            txtCountryCode.value='';
            popuptitle.innerHTML = 'Add new Country';
            
            
        }
        

        
        function HandleValidators()
        {
        //debugger
        
        var txtfname= document.getElementById("<%= this.txtName.ClientID %>");
        
         
         if (isBlank(txtfname,"Country Name"))                
         {return false;}
           
            if(isBlank(document.getElementById('<%= this.txtCountryCode.ClientID %>'), 'Country Code'))
            return false;
            
            var txtCountryCode= document.getElementById('<%= this.txtCountryCode.ClientID %>'); 
            var value=txtCountryCode.value;  
            for(var i=0;i<value.length;i++)
	        {
	           
	            if(!isDigit(val.charAt(i)))
		        {
		            alert("Country Code Should have some Character value.");
                    
                    return false;
                    
                    break;
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
            
     
        }
          
        function mastercheckboxclick()
        {
        ////debugger
            if(arrcountryelemclientid == null)
                return;
            var grdCountry= document.getElementById(arrcountryelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdCountry.rows[0].cells[0].childNodes.length)
            {
                if(grdCountry.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdCountry.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            
            rowcount = 1;
            var nodecount = 0;
            while(rowcount < grdCountry.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdCountry.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdCountry.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdCountry.rows[rowcount].cells.length > 1)
                    grdCountry.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked; 
                rowcount = rowcount + 1;
            }
            MultiSelect();

        }
        
        
        function checkallboxes()
        {
        ////debugger
            if(arrcountryelemclientid == null)
                return;
            var grdCountry= document.getElementById(arrcountryelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdCountry.rows[0].cells[0].childNodes.length)
            {
                if(grdCountry.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdCountry.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            MultiSelect();
            
            var nodecount = 0;
            while(rowcount < grdCountry.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdCountry.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdCountry.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdCountry.rows[rowcount].cells.length > 1)
                {
                    if(grdCountry.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
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
                var answer = confirm ("Are you sure you want to delete Country(s) ? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate Country(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate Country(s)? ")
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
            if(arrcountryelemclientid == null)
                return;
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrcountryelemclientid[2]);
            var txtDescription= document.getElementById(arrcountryelemclientid[3]);
            var grdCountry= document.getElementById(arrcountryelemclientid[0]);
            var hfCountryID= document.getElementById(arrcountryelemclientid[4]);
            var txtCountryCode= document.getElementById('<%= this.txtCountryCode.ClientID %>'); 
                           
    
            var arrlength = grdCountry.rows.length;
            var count = 1;
            var nodecount = 0;
            while(count < arrlength)
            {
                if(count == 1)
                {
                    while(nodecount < grdCountry.rows[count].cells[0].childNodes.length)
                    {
                        if(grdCountry.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdCountry.rows[count].cells.length <= 1)
                {
                    count = count + 1;
                    continue;
                }
                
                if(grdCountry.rows[count].cells[0].childNodes[nodecount].checked == true)
                {
                    selectcount=selectcount+1;
                    selectedrow=count+1;
                    
                    if (selectcount>1)
                    {
                        var btnEdit= document.getElementById(arrcountryelemclientid[1]);
                        btnEdit.disabled=true;
                        btnEdit.src="../../Images/edit-button-d.gif"
                        hidediv();
                        txtName.value=  "";
                        txtDescription.value= "";
                        hfCountryID.value=  "";
                        txtCountryCode.value="";
                        return selectcount;
                    }
                }
                count = count + 1;
            }
                 
         //   }
            ////debugger
            var btnEdit= document.getElementById(arrcountryelemclientid[1]);
            btnEdit.disabled=false;
            btnEdit.src="../../Images/edit_butt_master.gif"
            if (selectcount==1)
            {
            }
            else
            {
                txtName.value=  "";
                txtDescription.value= "";
                hfCountryID.value=  "";
                txtCountryCode.value="";
            }
            return selectcount;        
        }
        
        
        function EditCountry()
        {        
            if(arrcountryelemclientid == null)
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
                var txtName= document.getElementById(arrcountryelemclientid[2]);
                var txtDescription= document.getElementById(arrcountryelemclientid[3]);
                var grdCountry= document.getElementById(arrcountryelemclientid[0]);
                var hfCountryID= document.getElementById(arrcountryelemclientid[4]);
                var txtCountryCode= document.getElementById('<%= this.txtCountryCode.ClientID %>'); 
                
                var count = 0;
                var codepos=0;
                var nodecount = 0;
                while(count < (grdCountry.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdCountry.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdCountry.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                        var loopcount = 0;
                        var ininput = 0;
                        while(loopcount < grdCountry.rows[count + 1].cells[4].childNodes.length)
                        {
                            if(grdCountry.rows[count + 1].cells[4].childNodes[loopcount].tagName == "INPUT")
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
                    
                    if(grdCountry.rows[count+1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    
                    if(grdCountry.rows[count+1].cells[0].childNodes[nodecount].checked == true)
                    {  
                        
                         showdiv();
                         txtName.value = grdCountry.rows[count+1].cells[1].innerHTML;
                         var icount=0;
                         var descpos=0;
                         while(icount < grdCountry.rows[count+1].cells[2].childNodes.length)
                         {
                            if(grdCountry.rows[count+1].cells[2].childNodes[icount].tagName=="DIV")
                            {
                                descpos=icount;
                                break;
                            }
                            icount=icount + 1;
                         }
                         
                         
                         if( grdCountry.rows[count+1].cells[2].childNodes[descpos].innerHTML == "&nbsp;")
                            txtDescription.value = '';
                         else
                            txtDescription.value = trim(grdCountry.rows[count+1].cells[2].childNodes[descpos].innerHTML);
                         
                         txtCountryCode.value = grdCountry.rows[count+1].cells[4].childNodes[codepos].value; 
                         hfCountryID.value= count;
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
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Country</span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>

                <%--<div class="mainbody_inner_left">
                </div>
                
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft">
                        Country</div>
                    <div class="mainbody_titlelnkright">
                        <a href="javascript:showdiv()"> + Add new Country</a>
                        
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
                        <div class="master_buttons_con">
                            <a href="javascript:showdiv()"></a>
                            <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditCountry()"
                                ImageUrl="~/App/Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                        </div>
                        
                    </div>
                
                </div>
                
                <%--**********************************************************--%>
                
                <div class="main_area_bdrnone">
                    <asp:GridView runat="server" ID="grdCountry" AutoGenerateColumns="false" DataKeyNames="CountryID"
                        CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdCountry_RowDataBound"
                        EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdCountry_PageIndexChanging" AllowSorting="True" OnSorting="grdCountry_Sorting" >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                               <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="name" HeaderText="Country" SortExpression="name desc">
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="Description">
			                <ItemTemplate>
			                    <div title='<%# DataBinder.Eval(Container.DataItem, "description")%>' class="divitemdesccountry">
			                    <%# DataBinder.Eval(Container.DataItem, "description")%>
			                    </div>
			                </ItemTemplate>
			                </asp:TemplateField>
                            
                            <%--<asp:BoundField DataField="description" HeaderText="Description">
                                <ItemStyle CssClass="itemdesccountry" />
                                <HeaderStyle CssClass="headerdesccountry" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="active" HeaderText="Status">
                            </asp:BoundField>
                            <asp:BoundField DataField="CountryID" Visible="False" />
                              <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfCountryCode" Value='<%# DataBinder.Eval(Container.DataItem, "CountryCode") %>' />
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
        
        <asp:LinkButton runat="server" ID="lnkhidden"></asp:LinkButton>
        <asp:Panel ID="Panel1" runat="server" CssClass="PopUp">
      
      <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Edit Country</span>
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
                        <span class="titletext1b_default" style="margin-right: 10px;">Country:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                             <asp:TextBox ID="txtName" runat="server" CssClass="inputf_def" Width="210px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                     <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletext1b_default" style="margin-right: 10px;">Country Code:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                                <asp:TextBox runat="server" ID="txtCountryCode" Width="210px" CssClass="inputf_def" MaxLength="2"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletext1b_default" style="margin-right: 10px;"> Country:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                            <asp:DropDownList runat="server" ID="ddlcountry" Width="212px" CssClass="inputf_def">
                    </asp:DropDownList>
                          </span>
                    </p>
                     <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletext1b_default" style="margin-right: 10px;"> Description:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="210px" Rows="3" runat="server" CssClass="inputf_def"></asp:TextBox>
                        </span>
                    </p>
                    <asp:HiddenField ID="hfCountryID" runat="server" />
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                          <asp:ImageButton runat="server" CausesValidation="true" ID="btnCancel" ImageUrl="~/App/Images/cancel-button.gif" OnClientClick="$find('mdlPopup').hide(); return false;"  OnClick="btnCancel_Click" />
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
         <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="lnkhidden"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" BehaviorID="mdlPopup"
             />


</asp:Content>


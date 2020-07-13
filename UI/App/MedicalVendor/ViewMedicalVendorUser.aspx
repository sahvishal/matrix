<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="MedicalVendor_ViewMedicalVendorUser" Title="View Medical Vendor User" Codebehind="ViewMedicalVendorUser.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">
     
     function mastercheckboxclick()
        {
        ////debugger
            if(arrjscallcenterelementid == null)
                return;
            var grdcallcenter= document.getElementById(arrjscallcenterelementid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdcallcenter.rows[0].cells[0].childNodes.length)
            {
                if(grdcallcenter.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdcallcenter.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            
            rowcount = 1;
            var nodecount = 0;
            while(rowcount < grdcallcenter.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdcallcenter.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdcallcenter.rows[rowcount].cells.length > 1)
                    grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked; 
                rowcount = rowcount + 1;
            }
            MultiSelect();

        }
        
        function checkallboxes()
        {
        ////debugger
            if(arrjscallcenterelementid == null)
                return;
            var grdcallcenter= document.getElementById(arrjscallcenterelementid[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdcallcenter.rows[0].cells[0].childNodes.length)
            {
                if(grdcallcenter.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdcallcenter.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            MultiSelect();
            
            var nodecount = 0;
            while(rowcount < grdcallcenter.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdcallcenter.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdcallcenter.rows[rowcount].cells.length > 1)
                {
                    if(grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
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
       {   
            if(arrjscallcenterelementid == null)
                return;
            var selectcount=0;
            var selectedrow=0;
            
            var grdcallcenter= document.getElementById(arrjscallcenterelementid[0]);
            //var hfcallcentreid= document.getElementById(arrjscallcenterelementid[1]);
                           
    
            var arrlength = grdcallcenter.rows.length;
            var count = 1;
            var nodecount = 0;
            while(count < arrlength)
            {
                if(count == 1)
                {
                    while(nodecount < grdcallcenter.rows[count].cells[0].childNodes.length)
                    {
                        if(grdcallcenter.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdcallcenter.rows[count].cells.length <= 1)
                {
                    count = count + 1;
                    continue;
                }
                
                if(grdcallcenter.rows[count].cells[0].childNodes[nodecount].checked == true)
                {
                    selectcount=selectcount+1;
                    selectedrow=count+1;
                    
                    if (selectcount>1)
                    {
     //                   var btnEdit= document.getElementById(arrjscallcenterelementid[1]);
     //                   btnEdit.disabled=true;
     //                   btnEdit.src="../Images/edit-button-d.gif";
                        //hfcallcentreid.value=  "";
                        return selectcount;
                    }
                }
                count = count + 1;
            }
        
    //        var btnEdit= document.getElementById(arrjscallcenterelementid[1]);
    //       btnEdit.disabled=false;
    //        btnEdit.src="../Images/edit_butt_master.gif"
            if (selectcount==1)
            {
            }
            else
            {
                //hfcallcentreid.value = "";
            }
            return selectcount;        
        }

        function ConfirmMultiselect(type)
        {////debugger
            if (MultiSelect()>1)
            {
                var answer = confirm ("All the selected Items will be " + type + " ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
            else if ((type=='Deleted') && (MultiSelect()==1))
            {
                var answer = confirm ("The selected item will be deleted")
                return answer;
            }
        }
        
        function EditCallCentre()
        {
            if(MultiSelect()>1)
            {
    //            var btnEdit= document.getElementById(arrjscallcenterelementid[1]);
    //            btnEdit.disabled=true;
    //           btnEdit.src="../Images/edit-button-d.gif";
                return false;
            }
            return true;
        }

</script>
    
<div class="mainbody_outer">
            <div class="mainbody_inner">
            
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Medical Vendor User</span>
                    <span class="headingright_default"> <asp:LinkButton ID="lbtnNewMedicalVendorUser" runat="server" Text="+ Add new Medical Vendor User" OnClick="lbtnNewMedicalVendorUser_Click" /></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common"> <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            
            
               <%-- <div class="mainbody_inner_left">
                </div>
                
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft">
                        Medical Vendor User</div>
                    <div class="mainbody_titlelnkright">
                        <asp:LinkButton ID="lbtnNewMedicalVendorUser" runat="server" Text="+ Add new Medical Vendor User" OnClick="lbtnNewMedicalVendorUser_Click" />
                    </div>
                </div>
                
                <div class="mainbody_inner_right">
                </div>--%>
                <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server"></div> 
                 <%--******************* Buttons Row above Grid ***************** --%>
                <div class="divbuttonsrow">
                <asp:HiddenField runat="server" ID="hfcallcentreid" />
                    <div class="pagealerttxtCNT" id="errordiv" runat="server">
                    </div>
                
                    <div class="master_buttons_row">
                        <div class="master_buttons_con" style="visibility:hidden; display:none;">
                            <a href="javascript:showdiv()"></a>
                            <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditCallCentre()" 
                                ImageUrl="~/App/Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                        </div>
                        <%--
                        <div class="master_buttons_con">
                            <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="~/App/Images/deactivate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('DeActivate')" OnClick="btnDeActivate_Click" />
                        </div>
                        
                        <div class="master_buttons_con">
                            <a href=""></a>
                            <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="~/App/Images/activate_butt_master.gif"
                                OnClientClick="return ConfirmMultiselect('Activate')" OnClick="btnActivate_Click" />
                        </div>
                        --%>
                        <div class="master_buttons_con">
                            <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/App/Images/del-button_master.gif"
                                OnClientClick="return ConfirmMultiselect('Deleted')" OnClick="btnDelete_Click" />
                        </div>
                        
                    </div>
                
                </div>
                
                <%--**********************************************************--%>
                
                <div class="main_area_bdrnone">
                    <asp:GridView runat="server" ID="grdMVUser" AutoGenerateColumns="false" DataKeyNames="MedicalVendorMVUserID"
                        CssClass="divgrid_cl" GridLines="None" AllowPaging="true" PageSize="10"  AllowSorting="True" 
                        OnRowDataBound="grdMVUser_RowDataBound" OnPageIndexChanging="grdMVUser_PageIndexChanging" OnSorting="grdMVUser_Sorting" >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>    
                                                        
                            <asp:TemplateField HeaderText="User Name" SortExpression="Name">
                                <ItemTemplate>
                                   <asp:LinkButton runat="server" ID="lnkMedicalVendorMVUserEdit" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' ToolTip="Click here to view/edit the record." OnClick="lnkMedicalVendorMVUserEdit_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="BusinessName" HeaderText="Vendor Business Name" SortExpression="BusinessName">
                            </asp:BoundField>
                            
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                                
            </div>
        </div>
        
</asp:Content>


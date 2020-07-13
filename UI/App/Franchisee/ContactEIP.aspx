<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"AutoEventWireup="true" Inherits="Franchisee_ContactEIP" Codebehind="ContactEIP.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
.mainbody_outer_contacte{ float:right; width:777px; background-color:#fff; margin-top:5px; }
.mainbody_inner_contacte{ width:763px; margin-left:14px; margin-bottom:5px;}
.main_area_bdr_contacte{ float:left; width:753px; border:1px solid #E5E5E5; margin-top:5px;}
.divgridcontact_eip{float:left; width:750px;}
</style>
 <div class="mainbody_outer_contacte">
        <div class="mainbody_inner_contacte">
		<div class="mainbody_inner_left"></div>
		<div class="mainbody_inner_mid">
		<div class="mainbody_titletxtleft">Contact EIP</div>
		<div class="titlelnkright_v_prospects"></div>
		</div>
		<div class="mainbody_inner_right"></div>
		<div class="main_area_bdr_contacte">
		<%--<div class="divbuttonsrow">
                    <div class="pagealerttxtCNT" id="errordiv" runat="server">
                    </div>
                    
                </div>--%>
		<div class="divgridcontact_eip">
		<asp:GridView runat="server" ID="gridcontacteip" GridLines="none" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
		 CssClass="grid" OnPageIndexChanging="gridcontacteip_PageIndexChanging" AllowSorting="true" EnableSortingAndPagingCallbacks="False" OnSorting="gridcontacteip_Sorting"  >
         <Columns>
         <asp:BoundField DataField="" Visible="false"></asp:BoundField>
<%--         <asp:TemplateColumn>
         <HeaderTemplate>
         </HeaderTemplate>
         <HeaderStyle CssClass="headerchkboxcontact_eip" />
         <ItemTemplate>
         <asp:CheckBox ID="CheckBox1" runat="server" CssClass="" /></ItemTemplate>
         <ItemStyle CssClass="itemchkboxcontact_eip" />
         </asp:TemplateColumn>--%>
        
         <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="name desc">
         </asp:BoundField>
         
         <asp:BoundField DataField="Address" HeaderText="Address">
         </asp:BoundField>
         
        <asp:BoundField DataField="Country" HeaderText="Country">
         </asp:BoundField>
         
         <asp:BoundField DataField="PhoneDirect" HeaderText="Phone(home)">
         </asp:BoundField>
          <asp:TemplateField>
            <HeaderTemplate>
                 Phone(Other)</HeaderTemplate>
            <ItemTemplate>
             <div class="divitemphoneocontact_eip" title='<%# DataBinder.Eval(Container.DataItem, "PhoneOther")%>'>
               <%# DataBinder.Eval(Container.DataItem, "PhoneOther")%>
               </div> 
            </ItemTemplate>
        </asp:TemplateField>
         
         <%--<asp:BoundField DataField="PhoneOther" HeaderText="Phone(Other)">
         <HeaderStyle CssClass="headerphoneocontact_eip" />
         <ItemStyle CssClass="itemphoneocontact_eip" />
         </asp:BoundField>--%>

         <asp:BoundField DataField="Email" HeaderText="Email">
         </asp:BoundField>

        
         </Columns>
         <RowStyle CssClass="row2" />
         <HeaderStyle CssClass="row1" />
         <AlternatingRowStyle CssClass="row3" />
               
         </asp:GridView>
		</div>
		 
        </div>
   
   
   
        </div>
        </div>
 
 </asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="Franchisee_SalesRep_QuickReports" Codebehind="QuickReports.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.mainbody_outer_qr{ float:right; width:777px; background-color:#fff; margin-top:5px; }
.mainbody_inner_qr{ width:763px; margin-left:14px; margin-bottom:5px;}
.main_area_bdr_qr{ float:left; width:751px; border:1px solid #E5E5E5; margin-top:5px;}
.main_content_area_qr{ float:left; width:745px;}
.divgridquickreports{float:left; width:753px;}

</style>
<div class="mainbody_outer">
        <div class="mainbody_inner">
        
        <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading">Quick Report</span>
                    <span class="headingright_default"></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
        
		<%--<div class="mainbody_inner_left"></div>
		<div class="mainbody_inner_mid">
		<div class="mainbody_titletxtleft">Quick Report</div>
		<div class="titlelnkright_v_prospects"></div>
		</div>
		<div class="mainbody_inner_right"></div>--%>
		
		<div class="main_area_bdr">
		<div class="main_content_area_qr">
    
            <div class="divgridquickreports">
            <asp:GridView runat="server" GridLines="None" ID="gridquickreports" AutoGenerateColumns="false" CssClass="grid" 
            DataKeyNames="EventID" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridquickreports_PageIndexChanging" AllowSorting="true" EnableSortingAndPagingCallbacks="False" OnSorting="gridquickreports_Sorting" >
			<Columns>
			<asp:BoundField DataField="" Visible="false"></asp:BoundField>
			   		                
	       	<asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date desc" HtmlEncode=true DataFormatString="{0:MM/dd/yyyy}">
			
			</asp:BoundField>
			<asp:BoundField DataField="EventName" HeaderText="Event Name" SortExpression="eventname desc">
			</asp:BoundField>
			                
			<asp:BoundField DataField="Status" HeaderText="Status">
			</asp:BoundField>
			 
			<asp:TemplateField>
			<HeaderTemplate>Customer Count</HeaderTemplate>
			<ItemTemplate><a href='SalesRepCustomerList.aspx?EventID=<%# DataBinder.Eval(Container.DataItem, "EventID")%>'><%# DataBinder.Eval(Container.DataItem, "CustomerCount")%></a> </ItemTemplate>
			</asp:TemplateField>              
						        
			<asp:BoundField DataField="Pod" HeaderText="Pod">
			</asp:BoundField>
			<asp:BoundField DataField="EventID" Visible="False" />                 
			</Columns>
			<RowStyle CssClass="row2"></RowStyle>
            <HeaderStyle CssClass="row1"></HeaderStyle>
            <AlternatingRowStyle CssClass="row3"></AlternatingRowStyle>
			</asp:GridView>
            </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>

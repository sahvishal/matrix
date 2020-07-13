<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_MarketingPartner_AdvocateSalesManager_ucleftpanel" Codebehind="ucleftpanel.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
.grdLinks_leftpanel{float:left; width:100%;}
.leftsearchboxbg_leftpanel{background:url(/App/images/left-searchboxbg.gif) repeat-x;}
.leftnavlnkbg_leftpanel{float:left; width:182px; height:29px; background:url(/App/images/left-nav-bg.gif) repeat-x;}
.leftnavarrow_leftpanel{float:left; width:17px; height:12px; padding:9px 5px 0px 5px; }
.leftnavtxt_leftpanel{float:left; width:140px; padding-top:8px; text-overflow:ellipsis;	overflow:hidden; white-space:nowrap}
.leftnavtxt_leftpanel a:link{text-decoration:none;}
.leftnavtxt_leftpanel a:visited{text-decoration:none;}
.leftnavtxt_leftpanel a:hover{text-decoration:none;}

</style>
<asp:Panel ID="pnlSearch" runat="server" DefaultButton="imgSearch">
<div class="leftcontainer_inner" style="height:800px;">
    
    <p><img src="/App/Images/specer.gif" width="160px" height="5px" /></p>
    <div class="leftcontainer_header_left">
    </div>
    <div class="leftcontainer_header_mid">Quick Search</div>
    <div class="leftcontainer_header_right">    
    </div>
     <div class="leftsearchboxbg_leftpanel" style=" float:left; width:184px; border:1px solid #E5E5E5; margin-top:5px;">
     <div style=" float:left; padding:5px;">
    <span id="spTB" runat="server" style="float:left; width:170px; text-align:center;">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="inputf_def" Width="160px"></asp:TextBox>    
    </span>
    <p><img src="/App/Images/specer.gif" width="160px" height="4px" /></p>
     <div style="float:left;">Search in</div>
        <span id="spDDL" runat="server" style="float:left; width:170px; font:normal 12px arial; color:#666;">
         <asp:DropDownList ID="ddlSearch" runat="server" CssClass="inputf_def" Width="168px">
             <asp:ListItem>Advocate</asp:ListItem>
             <asp:ListItem>Campaign</asp:ListItem>
              <asp:ListItem>Marketing Material</asp:ListItem>
         </asp:DropDownList>
    </span>
    <p><img src="/App/Images/specer.gif" width="160px" height="8px" /></p>
    <span id="spImg" runat="server" style="float:left; width:170px; font:normal 12px arial; color:#666;">
        <asp:ImageButton ID="imgSearch" runat="server" OnClick="imgSearch_Click" ImageUrl="~/App/Images/search-button.gif" />
        <cc1:textboxwatermarkextender id="TextBoxWatermarkExtender1" runat="server" WatermarkText="." WatermarkCssClass="watermarktxtinput_default" targetcontrolid="txtSearch" ></cc1:textboxwatermarkextender>
    </span>
    </div>      
         
    </div>
    <p><img src="/App/Images/specer.gif" width="160px" height="5px" /></p>
    <div class="leftcontainer_header_left">
    </div>
    <div class="leftcontainer_header_mid">
        Quick Nav</div>
    <div class="leftcontainer_header_right">    
    </div>
     <div style=" float:left; width:184px; border:1px solid #E5E5E5; margin-top:5px; ">
    <span id="spLinks" runat="server" style="float:left; width:182px; font:normal 12px arial; color:#666;">
    <asp:GridView runat="server" ID="grdLinks" GridLines="None" ShowFooter="false" ShowHeader="false" CssClass="grdLinks_leftpanel" AutoGenerateColumns="false" >
    <Columns>
    <asp:TemplateField>
    <ItemTemplate>
    <div class="leftnavlnkbg_leftpanel">
    <span class="leftnavarrow_leftpanel"><img src="/App/Images/left-nav-arrow.gif" alt="" /></span>
    <span class="leftnavtxt_leftpanel"><a title='<%# DataBinder.Eval(Container.DataItem, "Name")%>' href='<%# DataBinder.Eval(Container.DataItem, "TargetURL")%>'><%# DataBinder.Eval(Container.DataItem, "Name")%></a></span>
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns> 
   </asp:GridView>
    </span>
    </div>
    
    
    <p><img src="/App/Images/specer.gif" width="160px" height="5px" /></p>
    <div class="leftcontainer_header_left">
    </div>
    <div class="leftcontainer_header_mid">
        Recently Visited</div>
    <div class="leftcontainer_header_right">    
    </div>
     <div style=" float:left; width:184px; border:1px solid #E5E5E5; margin-top:5px; ">
    <span id="Span1" runat="server" style="float:left; width:182px; font:normal 12px arial; color:#666;">
    <asp:GridView runat="server" ID="grdVisit" GridLines="None" ShowFooter="false" ShowHeader="false" CssClass="grdLinks_leftpanel" AutoGenerateColumns="false" >
    <Columns>
    <asp:TemplateField>
    <ItemTemplate>
    <div class="leftnavlnkbg_leftpanel">
    <span class="leftnavarrow_leftpanel"><img src="/App/Images/left-nav-arrow.gif" alt="" /></span>
    <span class="leftnavtxt_leftpanel">
    <a title='<%# DataBinder.Eval(Container.DataItem, "Name")%>' href='<%# DataBinder.Eval(Container.DataItem, "TargetURL")%>'><%# DataBinder.Eval(Container.DataItem, "Name")%> </a>
    </span>
    </div>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns> 
   </asp:GridView>
    </span>
    </div>
    
    
</div>  

</asp:Panel>

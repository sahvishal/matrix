<%@ Page Language="C#" MasterPageFile="~/App/MarketingPartner/AdvocateSalesManager/AdvocateSalesManager.master"
    AutoEventWireup="true" Inherits="App_MarketingPartner_AdvocateSalesManager_ManageTeam" Codebehind="ManageTeam.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        
        
     
     function UpdateStatus(intManagerId, intSalesRepID, bolStatus)
     {
        document.getElementById('divloading').style.visibility = "visible";
        document.getElementById('divloading').style.display = "block";
        
      ret = AutoCompleteService.UpdateAdvocateSalesManagerTeam(intManagerId,intSalesRepID,bolStatus);
      //var errordiv=document.getElementById('errordiv');
      var spText=document.getElementById('sp' + intSalesRepID);
         if (bolStatus==true)       
         {
             spText.innerHTML="<a href='#'  onclick='return UpdateStatus(" + intManagerId + "," + intSalesRepID + ",false)'>Remove</a> ";
             ///errordiv.innerHTML="Sales Rep successfully added to your team.";
          alert('Sales Rep succefully added to your team.');
         }
             
         else //// we have remove the sale rep. so now we have to add option
             {
              spText.innerHTML="<a href='#'  onclick='return UpdateStatus(" + intManagerId + "," + intSalesRepID + ",true)'>Add</a> ";
              ///errordiv.innerHTML="Sales Rep succefully removed from your team.";
         alert('Sales Rep succefully removed from your team.');
             }
             
       ///errordiv.style.display="block";
      
       document.getElementById('divloading').style.visibility = "hidden";
        document.getElementById('divloading').style.display = "none";
       return false;
     }
     
    

     
    </script>

    <div id="divloading" class="loadingdiv_ucecustlist" style="visibility: hidden; display: none;">
        <span style="float: left; padding-right: 5px" class="blktext14px_default">Updating status...</span>
        <span style="float: left">
            <img src="/App/Images/loading.gif" /></span>
    </div>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Manage Team</span>
                    <span class="headingright_default"><a href="SalesTeamOverview.aspx">Team Overview </a>
                    </span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            <%--******************* Buttons Row above Grid ***************** --%>
            <div class="divbuttonsrow">
                <div class="pagealerttxtCNT" id="errordiv">
                </div>
            </div>
            <%--**********************************************************--%>
            <div class="main_area_bdr_Editdata_fcr">
                <asp:GridView runat="server" ID="grdTeam" AutoGenerateColumns="false" CssClass="divgrid_cl"
                    GridLines="None" EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="25"
                    OnPageIndexChanging="grdTeam_PageIndexChanging" AllowSorting="True" OnSorting="grdTeam_Sorting">
                    <Columns>
                        <asp:BoundField DataField="Sr" HeaderText="Sr.No."></asp:BoundField>
                       <%-- <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name"></asp:BoundField>--%>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <span class="blkbold12_default">
                                    <%#DataBinder.Eval(Container.DataItem, "Name")%></span>
                                    
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Contact
                            </HeaderTemplate>
                            <ItemTemplate>
                            <div style="float:left; width:300px;">
                                <span class="graytxtbold">Phone: </span> <span style="float:left;">
                                    <%#DataBinder.Eval(Container.DataItem, "Phone")%></span>
                                    <br />
                                   <span class="graytxtbold"> Email: </span> <span style="float:left;">
                                        <%#DataBinder.Eval(Container.DataItem, "Email")%></span> </span>
                                        </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Advocate Sales Manager
                            </HeaderTemplate>
                            <ItemTemplate>
                            <span style=" float:left; width:130px; text-align:center">
                                <span id='sp<%# DataBinder.Eval(Container.DataItem, "franchiseefranchiseeuserid")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "Status")%></span>
                                    </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1" />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

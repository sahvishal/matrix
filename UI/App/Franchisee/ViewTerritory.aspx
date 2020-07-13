<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisee_ViewTerritory" Title="Untitled Page"
    CodeBehind="ViewTerritory.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 302px;
            padding:10px;
            background-color:#f5f5f5;
        }
        .wrapperin_pop
        {
            float: left;
            width: 278px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color:#fff;
        }
        .innermain_pop
        {
            float: left;
            width: 258px;
            padding: 0px 5px 0px 5px;
        }
        .innermain_1_pop
        {
            float: left;
            width: 263px;
            padding-top: 5px;
        }
    </style>

    <script type="text/javascript">

    String.prototype.trim = function() { return this.replace(/^\s+|\s+$/, ''); };
    
    function validateSearch()
    {
        __defaultFired=false;
        var txtSearch=document.getElementById("<%=this.txtSearch.ClientID %>");
        var txtZipCode=document.getElementById("<%=this.txtZipCode.ClientID %>");
        if(txtSearch.value.trim().length==0 && txtZipCode.value.trim().length==0)
        {
            alert("Please enter text to search territory.");
            return false;
        }
        return true;
    }
    
    function ExpandSalesRepTerritory(TerritoryID)
    {
        var aExpandID=document.getElementById("aExpand" + TerritoryID);
        var aCollapseID=document.getElementById("aCollapse" + TerritoryID);
        var divChildGrdID=document.getElementById("divChildGrd" + TerritoryID);
                
        aExpandID.style.display='none';
        aCollapseID.style.display='block';
        divChildGrdID.style.display='block';
        
    }
    
    function CollapseSalesRepTerritory(TerritoryID)
    {
        var aExpandID=document.getElementById("aExpand" + TerritoryID);
        var aCollapseID=document.getElementById("aCollapse" + TerritoryID);
        var divChildGrdID=document.getElementById("divChildGrd" + TerritoryID);
                
        aExpandID.style.display='block';
        aCollapseID.style.display='none';
        divChildGrdID.style.display='none';
        
    }
    
    function clearSearchCriteria()
    {
        var txtSearch=document.getElementById("<%=this.txtSearch.ClientID %>");
        var txtZipCode=document.getElementById("<%=this.txtZipCode.ClientID %>");
        txtSearch.value="";
        txtZipCode.value="";
        return false;
    }
    
    function txtkeypress(evt)
    {
        return KeyPress_NumericAllowedOnly(evt);
    }
    
    function deleteTerritory()
    {
        var check = confirm("Are you sure to delete this territory?");
        if(check==true)
            return true
        else
            return false;
    }
    
    function showTotalZips(territoryid)
    {
        $find('mdlPopupZipCodes').show();
        var spTitle=document.getElementById("spTitle");
        spTitle.innerHTML="All Zip Codes";
        ret = AutoCompleteService.GetAllZipCodesByTerritory(territoryid, OnComplete, OnTimeOut, OnError);
    }
    
    function showUnAssignedZips(territoryid)
    {
        $find('mdlPopupZipCodes').show();
        var spTitle=document.getElementById("spTitle");
        spTitle.innerHTML="Unassigned Zip Codes";
        ret = AutoCompleteService.GetUnAssignedCodesByTerritory(territoryid, OnComplete, OnTimeOut, OnError);
    }
    
    function showAssignedZips(territoryid)
    {
        $find('mdlPopupZipCodes').show();
        var spTitle=document.getElementById("spTitle");
        spTitle.innerHTML="Assigned Zip Codes";
        ret = AutoCompleteService.GetAllZipCodesByTerritory(territoryid, OnComplete, OnTimeOut, OnError);
    }
    
    function OnComplete(arg) 
    {//debugger
        var spZips=document.getElementById("spZips");
        var Zips="";
        if(arg.length>0)
        {
            for(icount=1;icount<arg.length;icount++)
            {
               Zips= Zips + arg[icount] + ",";
               if(icount%7==0)
                Zips= Zips + "<br />";
            }
            Zips=Zips + arg[0];
        }
        //Zips=Zips.substring(0,Zips.length -1);
        spZips.innerHTML=Zips;
                
    }
    
    function OnTimeOut(arg) 
    {
        //alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");
    }

    function OnError(arg) 
    {
        //alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");
    }
    </script>

    <script type="text/javascript">
    var __defaultFired = false;
    var __nonMSDOMBrowser = (window.navigator.appName.toLowerCase());
    function WebForm_FireDefaultButton(event, target) 
    {//debugger
        if (!__defaultFired && event.keyCode == 13 && !(event.srcElement && (event.srcElement.tagName.toLowerCase() == "textarea"))) 
        {
            var defaultButton;
            if (__nonMSDOMBrowser)
                defaultButton = document.getElementById("<%=this.ibtnSearch.ClientID %>");
            else
                defaultButton = document.all[target];

            if (typeof(defaultButton.click) != "undefined") 
            {
                __defaultFired = true;
                defaultButton.click();
                event.cancelBubble = true;
                
                if (event.stopPropagation) event.stopPropagation();
                return false;
            }

            if (typeof(defaultButton.href) != "undefined") 
            {
                __defaultFired = true;
                eval(defaultButton.href.substr(11));
                event.cancelBubble = true;
                
                if (event.stopPropagation) event.stopPropagation();
                return false;
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
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">View Territory</span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
            </div>
            <div class="grayboxtop_cl">
                <p class="grayboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                <p class="grayboxheader_cl">
                    <span style="float: left">Filter/Search</span></p>
                <div class="lgtgraybox_cl">
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span id="pnlSearchTerritory" onkeypress="javascript:return WebForm_FireDefaultButton(event,'ibtnSearch')">
                            <span class="titletextnowidth_default">Territory Name:</span> <span class="inputfldnowidth_default"
                                style="margin-right: 40px;">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="inputf_def" Width="200px"></asp:TextBox>
                            </span><span class="titletextnowidth_default">Containing Zip:</span> <span class="inputfldnowidth_default"
                                style="margin-right: 20px;">
                                <asp:TextBox ID="txtZipCode" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox>
                            </span><span class="button_con_nowidth">
                                <asp:ImageButton ID="ibtnClear" runat="server" ImageUrl="~/App/Images/clear-button.gif"
                                    OnClientClick="return clearSearchCriteria();" />
                                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                    OnClientClick="return validateSearch();" OnClick="ibtnSearch_Click" />
                            </span></span><span class="lgtgrayboxrow_cl">
                                <img src="/App/Images/specer.gif" width="10" height="6" alt="" /></span>
                    </p>
                </div>
                <p class="grayboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="4" /></p>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="750px" height="10px" /></p>
            <div class="divmainbody_cd">
                <span class="blkheadtxt_regcust" id="Span1" runat="server" style="float: left;">Total:</span>
                <span class="blueheadtxt_regcust" id="spNoResults" runat="server" style="float: left;">
                    10</span> <span class="blueheadtxt_regcust" style="float: left;">&nbsp;results found</span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
            <div style="float: left; width: 746px" id="divGrd" runat="server">
                <p class="blueboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" /></p>
                <div style="float: left; width: 746px">
                    <asp:GridView runat="server" ID="grdvTerritory" AutoGenerateColumns="False" CssClass="divgrid_cl"
                        GridLines="None" AllowPaging="True" PageSize="10" OnPageIndexChanging="grdvTerritory_PageIndexChanging"
                        OnRowDataBound="grdvTerritory_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div id="divExpandCollapse" runat="server">
                                        <a id='aExpand<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>' href='javascript:void(0);'
                                            onclick='ExpandSalesRepTerritory(<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>);'>
                                            <img src="/App/Images/Plus-signbox.gif" />
                                        </a><a id='aCollapse<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>' href='javascript:void(0);'
                                            onclick='CollapseSalesRepTerritory(<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>);'
                                            style='display: none;'>
                                            <img src="../Images/minus-signbox.gif" />
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Territory Name">
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "TerritoryName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:TemplateField HeaderText="Zips">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" id="aTotalZips" onclick='showTotalZips(<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>);'>Total <%#DataBinder.Eval(Container.DataItem, "TotalZipsCount")%></a> 
                                    | 
                                    <a href="javascript:void(0);" id="aUnassignedZips" onclick='showUnAssignedZips(<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>);'><%#DataBinder.Eval(Container.DataItem, "UnassignedZipCount")%> unassigned</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <a href='/App/Franchisee/CreateSalesRepTerritory.aspx?ParentTerritoryID=<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>'>
                                        Distribute</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="100%" style="margin: 0px; padding: 0px;">
                                            <div id='divChildGrd<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>' style='display: none;
                                                position: relative; left: 15px; overflow: auto; width: 97%; margin-top: 2px;
                                                margin-bottom: 2px;'>
                                                <asp:GridView runat="server" ID="grdvSalesRepTerritory" AutoGenerateColumns="False"
                                                    CssClass="grid_child" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SalesRep Territory">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "TerritoryName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SalesRep">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Franchisee")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Zip Assigned">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" id="aSalesRepAssignedZips" onclick='showAssignedZips(<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>);'><%#DataBinder.Eval(Container.DataItem, "AssignedZipsCount")%> Zips</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnRemove" runat="server" Text="Remove" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>'
                                                                    OnClientClick="return deleteTerritory();" OnClick="lnkBtnRemove_Click"></asp:LinkButton>
                                                                | <a id="aEditSalesRepTerritory" href='/App/Franchisee/CreateSalesRepTerritory.aspx?ParentTerritoryID=<%#DataBinder.Eval(Container.DataItem,"ParentTerritoryID") %>&TerritoryID=<%#DataBinder.Eval(Container.DataItem,"TerritoryID") %>'>
                                                                    Edit</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="row2" />
                                                    <HeaderStyle CssClass="row1" />
                                                    <AlternatingRowStyle CssClass="row2" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                <p class="blueboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" /></p>
            </div>
        </div>
    </div>
    <asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
    <cc1:modalpopupextender id="ModalPopupExtenderHint" runat="server" targetcontrolid="lnktemp"
        popupcontrolid="pnlZipCodes" backgroundcssclass="modalBackground" cancelcontrolid="ibtnClose"
        behaviorid="mdlPopupZipCodes" />
    <asp:Panel ID="pnlZipCodes" Style="display: none" runat="server">

            <div class="wrapper_pop">
                <div class="wrapperin_pop">
                    <div class="innermain_pop">
                        <p class="innermain_pop">
                            <span class="orngbold16_default" id="spTitle">Unassigned Zip Codes</span>
                        </p>
                        <p class="innermain_1_pop" style="border-top: solid 1px #ccc;">
                            <span class="titletext1b_default">
                                <img src="../Images/specer.gif" width="1px" height="1px" /></span>
                        </p>
                        <div class="innermain_pop" style="background-color: #f5f5f5;border:solid 1px #ccc;font-size:11px;height:310px;overflow-y:auto; overflow-x:hidden">
                            <p class="innermain_pop">
                                <span class="ttxtnowidthnormal_default" id="spZips" style="width:270px;">
                                    <img src="/App/Images/indicatorbig.gif" />
                                </span>
                            </p>
                        </div>
                        <p class="innermain_1_pop">
                            << Map coming soon >>
                        </p>
                        <p class="innermain_1_pop">
                            <span style="float:right">
                                <asp:ImageButton ID="ibtnClose" runat="server" ImageUrl="~/App/Images/close-button.gif" /></span>
                        </p>
                    </div>
                </div>
            </div>

    </asp:Panel>
</asp:Content>

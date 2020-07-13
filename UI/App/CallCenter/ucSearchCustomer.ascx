<%@ Control Language="C#" AutoEventWireup="true" Inherits="CallCenter_ucSearchCustomer"
    CodeBehind="ucSearchCustomer.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>


<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" />

<script type="text/javascript" language="javascript">
    var GB_ROOT_DIR = "../Wizard/greybox/";
        function expanddiv(divpanel,divclosepanel)
        {
            document.getElementById(divpanel).style.visibility='visible';
            document.getElementById(divpanel).style.display='block';
            document.getElementById(divclosepanel).style.visibility='hidden';
            document.getElementById(divclosepanel).style.display='none';
            document.getElementById('<%= this.txtadvcustomername.ClientID %>').value = document.getElementById('<%= this.txtcustomername.ClientID %>').value;
        }
        
        function closediv(divpanel,divclosepanel)
        {
            document.getElementById(divpanel).style.visibility='hidden';
            document.getElementById(divpanel).style.display='none';
            document.getElementById(divclosepanel).style.visibility='visible';
            document.getElementById(divclosepanel).style.display='block';
          document.getElementById('<%= this.txtcustomername.ClientID %>').value  =document.getElementById('<%= this.txtadvcustomername.ClientID %>').value ;
     
        }
        
        function ClearSearch()
        {
            document.getElementById('<%= this.txtcustomername.ClientID %>').value = '';
        }
        
        function ClearAdvanceSearch()
        {
            document.getElementById('<%= this.txtadvcustomername.ClientID %>').value = '';
            document.getElementById('<%= this.txtcustomerid.ClientID %>').value = '';
            document.getElementById('<%= this.txtregdate.ClientID %>').value = '';
            document.getElementById('<%= this.txtzip.ClientID %>').value = '';
            document.getElementById('<%= this.txtcity.ClientID %>').value = '';
            document.getElementById('<%= this.txtstate.ClientID %>').value = '';
            
        }
   
</script>

<script type="text/javascript" src="../Wizard/greybox/AJS.js"></script>

<script type="text/javascript" src="../Wizard/greybox/AJS_fx.js"></script>

<script type="text/javascript" src="../Wizard/greybox/gb_scripts.js"></script>

<%--<div class="mainbody_outer_sc">--%>
<div class="mainbody_inner_w_sc" style="background-color: #fff; padding-top: 3px;
    height: 560px;">
    <div class="mainbody_inner_left">
    </div>
    <div class="mainbody_inner_mid">
        <div class="mainbody_titletxtleft">
            Search Customer</div>
        <div class="titlelnkright_v_prospects">
        </div>
    </div>
    <div class="mainbody_inner_right">
    </div>
    <div class="divbuttonsrow">
        <div class="pagealerttxtCNT" id="errordiv" runat="server">
        </div>
        <div class="master_buttons_row">
        </div>
    </div>
    <div class="main_area_bdr_sc">
        <div class="main_content_area_sc">
            <div class="multitabsrow_sc">
                <div id="eventnamerow" class="searchfunc_sc">
                    <div class="first_name_sc">
                        Customer Name:
                    </div>
                    <div class="inputboxleft">
                        <asp:TextBox ID="txtcustomername" runat="server" Text="" CssClass="inputf_se" Width="180"></asp:TextBox>
                    </div>
                    <div class="button_con_sc">
                        <asp:ImageButton ID="ibtnsearch" runat="server" CssClass="" ImageUrl="~/App/Images/search-button.gif"
                            OnClick="ibtnsearch_Click" />
                    </div>
                    <div class="button_con_sc">
                        <%--<asp:ImageButton ID="ibtnclear" runat="server" CssClass="" ImageUrl="~/App/Images/clear-button.gif" />--%>
                        <img alt="" src="'/App/Images/clear-button.gif' onclick='ClearSearch();' />
                    </div>
                    <div class="advsearchlnk_sc">
                        <a href="javascript:expanddiv('advancedsearchcon','eventnamerow'); ">Advanced Search
                        </a>
                    </div>
                </div>
            </div>
            <div id='advancedsearchcon' class="advsearchmain_sc" style="visibility: hidden; display: none;">
                <div class="singlerow_sc">
                    <div class="first_name_sc">
                        Customer Name:
                    </div>
                    <div class="inputboxleft">
                        <asp:TextBox ID="txtadvcustomername" runat="server" Text="" CssClass="inputf_se"
                            Width="140"></asp:TextBox>
                    </div>
                    <div class="closelnk_sc">
                        <a href="javascript:closediv('advancedsearchcon','eventnamerow'); ClearAdvanceSearch(); ">
                            Close[ x ] </a>
                    </div>
                </div>
                <div class="singlerow_sc">
                    <div class="first_name_sc">
                        Customer ID:</div>
                    <div class="inputboxleft_sc">
                        <asp:TextBox ID="txtcustomerid" runat="server" CssClass="inputf_sae" Width="140"></asp:TextBox>
                    </div>
                    <div class="first_name_sc1">
                        Date of Reg:
                    </div>
                    <div class="inputboxleft_sc">
                        <asp:TextBox ID="txtregdate" runat="server" CssClass="inputf_sc date-picker" Width="80" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="singlerow_sc">
                    <div class="titlessmall_sc">
                        State:
                    </div>
                    <div class="inputboxright_sc">
                        <asp:TextBox runat="server" ID="txtstate" CssClass="inputf_sc auto-search-states" Width="120px"></asp:TextBox>
                    </div>
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                    <div class="titlessmallright_sc">
                        City:
                    </div>
                    <div class="inputboxright_sc">
                        <asp:TextBox runat="server" ID="txtcity" CssClass="inputf_sc auto-search-city" Width="110px"></asp:TextBox>
                    </div>
                    <%-- </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlstate" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>--%>
                    <div class="titlessmall2_sc">
                        Zip:
                    </div>
                    <div class="inputboxright_sc">
                        <asp:TextBox ID="txtzip" runat="server" CssClass="inputf_sae" Width="83"></asp:TextBox>
                    </div>
                    <div class="button_con_sc">
                        <asp:ImageButton ID="ibtnadvsearch" runat="server" CssClass="" ImageUrl="~/App/Images/search-button.gif"
                            OnClick="ibtnadvsearch_Click" />
                    </div>
                    <div class="button_con_sc">
                        <%--<asp:ImageButton ID="ibtnadclear" runat="server" CssClass="" ImageUrl="~/App/Images/clear-button.gif" />--%>
                        <img alt="" src="'/App/Images/clear-button.gif' onclick="ClearAdvanceSearch();" />
                    </div>
                </div>
            </div>
            <div class="headbg_box_sc">
                <div class="head_text_sc">
                    Customers
                </div>
            </div>
            <div class="divgridpage_sc">
                <asp:GridView ID="grdsearchcustomers" runat="server" CssClass="grid" AutoGenerateColumns="false"
                    CellPadding="0" CellSpacing="0" GridLines="None" AllowPaging="True" OnPageIndexChanging="grdsearchcustomers_PageIndexChanging"
                    OnRowCommand="grdsearchcustomers_RowCommand">
                    <Columns>
                        <%-- <asp:BoundField DataField="CustomerID" HeaderText="Customer ID">
                                    <ItemStyle CssClass="itemaddresssc"></ItemStyle>
                                    <HeaderStyle CssClass="headeraddress_sc"></HeaderStyle>
                                </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "CustomerName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                        <asp:BoundField DataField="State" HeaderText="State"></asp:BoundField>
                        <asp:BoundField DataField="City" HeaderText="City"></asp:BoundField>
                        <asp:BoundField DataField="Zip" HeaderText="Zip"></asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Select Customer
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button ID="btnEditCustomer" CommandName='<%# DataBinder.Eval(Container.DataItem, "CustomerID")%>'
                                    Text="Select" Font-Size="8pt" Width="45px" runat="Server" />
                            </ItemTemplate>
                            <ItemStyle CssClass="imgageicngrid_ccrep" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="row2"></RowStyle>
                    <HeaderStyle CssClass="row1"></HeaderStyle>
                    <AlternatingRowStyle CssClass="row3"></AlternatingRowStyle>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
    
        $('.auto-search-states').autoComplete({
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetStateByPrefixText")%>',
		    type: "POST",
		    data: "prefixText"
        });
        
        $(".date-picker").datepicker({
	        changeMonth: true,
	        changeYear: true,
	        yearRange:"-10:+50"
        });
        
        $('.auto-search-city').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyNameAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: $('.auto-search-states').val()
        });
        
        $('.auto-search-states').change(function(){
            $('.auto-search-city').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyNameAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('.auto-search-states').val()
            });
        });    
    });
    
    </script>


<%--</div>--%>

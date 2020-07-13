<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true" Inherits="App_Customer_SearchEvent" Codebehind="SearchEvent.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>

<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" />

<script type="text/javascript" language="javascript">

    var GB_ROOT_DIR = "/App/Wizard/greybox/";
    
    function Validate() {
        var state = document.getElementById("<%= this.txtState.ClientID %>").value; 
        var city = document.getElementById("<%= this.txtCity.ClientID %>").value; 
        var zip = document.getElementById("<%= this.txtZip.ClientID %>").value; 
        var txtFrom = document.getElementById("<%= this.txtFrom.ClientID %>").value ; 
        var txtTo = document.getElementById("<%= this.txtTo.ClientID %>").value ; 
        
        if(zip == "") {
            alert("Please enter zip to search."); 
            return false; 
        }
   
        if (txtFrom == "" && txtTo == "") {
            ///No date range provided
            return true}
        else {
            if (ValidateDate(txtFrom, 'Date Range') == false) {
                return false}
            if (ValidateDate(txtTo, 'Date Range') == false) {
                return false}
        }
      
        if (txtFrom != txtTo)
        { 
            if(CompareDateWithCurrentDate1(txtFrom) && CompareDateWithCurrentDate1(txtTo))
            {
                alert("You are searching for past events. Please search for future events.");
                return false;
            }
        }
        return true; 
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

    <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd">Register Event</span>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server" />
        </div>
        <div class="main_area_custdbrd">
            <div class="main_row_custdbrd">
                <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false" runat="server">
                </div>
                <div class="main_area_bdrnone">
                    <div class="divsteps_re">
                        <img src="../Images/Customer_step1n.gif" alt="" />
                    </div>
                    <div class="maincontentrow_re">
                        <p class="orngheadtxt_regcust">
                            Search Event</p>
                        <p class="fline_re">
                            <img src="../Images/specer.gif" width="1px" height="1px" alt="" /></p>
                    </div>
                   <div id="pnlSearchTerritory" onkeypress="javascript:return WebForm_FireDefaultButton(event,'ibtnSearch')">
                   <p class="maincontentrow_re" style="display:none;">
                        <span class="titletxt_regcust">State:</span> <span class="inputconleft_regcust">
                            <asp:TextBox ID="txtState" runat="server" CssClass="inputfield_ccrep auto-search-states" Width="135px"></asp:TextBox></span>
                        <span class="titletxt_regcust">City:</span> <span class="inputconright_regcust">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="inputfield_ccrep auto-search-city" Width="140px"></asp:TextBox></span>
                    </p>
                    
                    <p class="maincontentrow_re">
                        <span class="titletxt_regcust">Zip:</span> <span class="inputconleft_regcust">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" Width="100px"></asp:TextBox></span>
                        <span class="titletxt_regcust">Date:</span> 
                            <asp:TextBox ID="txtFrom" runat="server" CssClass="inputfield_ccrep date-picker" Width="70px"></asp:TextBox> - To -
                                   <asp:TextBox ID="txtTo" runat="server" CssClass="inputfield_ccrep date-picker" Width="70px"></asp:TextBox>
                        
                    </p>
                    <p class="fline_re">
                        <img src="../Images/specer.gif" width="1px" height="1px" alt="" /></p>
                    <div class="btnrows_re">
                        <span class="buttoncon_re">
                            <asp:ImageButton ID="ibtnSearch" OnClientClick="return Validate();" runat="server"
                                ImageUrl="~/App/Images/search-smallbtn.gif" OnClick="ibtnSearch_Click" /></span>
                    </div>
                    </div>
                </div>
                
                <p>
                    <img src="../Images/specer.gif" width="600px" height="10px" border="1px solid red" /></p>
                <p class="maincontentrow_re">
                    <span class="blkheadtxt_regcust" id="dvSearchResult1" runat="server"></span><span
                        class="blueheadtxt_regcust" id="dvSearchResult" runat="server"></span>
                </p>
                <div class="dgeventhistory_ccrep" style="padding-left: 3px;">
                    <asp:GridView ID="dgEvent" runat="server" CssClass="divgrid_clnew" AutoGenerateColumns="false"
                        GridLines="None" AllowPaging="true" PageSize="5" AllowSorting="true" EnableSortingAndPagingCallbacks="False"
                        OnSorting="dgEvent_Sorting" OnPageIndexChanging="dgEvent_PageIndexChanging" OnRowDataBound="dgEvent_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Event ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Event Name" SortExpression="Name" Visible="false"></asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Event Venue</HeaderTemplate>
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Host")%>
                                    <br />
                                    <font size="1px">
                                        <%# DataBinder.Eval(Container.DataItem, "Address")%>
                                        <br />
                                        <a href='<%# DataBinder.Eval(Container.DataItem, "GoogleMap")%>'
                                            target="_blank">[Map To Location]</a></font>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Event Date" SortExpression="Date">
                                <ItemTemplate>
                                    <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "Date")).ToString("dddd, MMMM dd, yyyy")%>
                                </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:BoundField DataField="Distance" HeaderText="Distance(Miles)" SortExpression="Distance">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <div style="text-align: center;">Register</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <span id="spSlots" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "IsSlotsAvailable")%>'>
                                            <asp:ImageButton ID="lnkSelectEvent" runat="server" CommandName="SelectEvent" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                ImageUrl="/Content/Images/reg.gif" OnClick="lnkSelectEvent_Click">
                                            </asp:ImageButton>
                                        </span>
                                        <span id="spNoSlots" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "IsNoSlotsAvailable")%>'><img src="/App/Images/no-slots-available-icongif.gif" alt="" /></span>
                                        <span id="spTempUnavailable" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "TempUnavailable")%>'><img src="/App/Images/temp-unavailable-icon.gif" alt="" /></span>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <RowStyle CssClass="row2" />
                        <AlternatingRowStyle CssClass="row2" />
                    </asp:GridView>
                </div>
                <p>
                    <img src="../Images/specer.gif" width="600px" height="10px" /></p>
                <div class="maincontentrow_re">
                </div>
            </div>
        </div>
    </div>

    <div class="wrapper_pop" id="InvitationCodeDiv" title="Invitation Code">
        <div class="wrapperin_pop">            
            <div class="innermain_pop">
                <span class="inputfield110px_anp">Invitation Code:
                    <asp:TextBox ID="txtInvitationCode" runat="server" CssClass="inputf_def" Width="200px"></asp:TextBox>
                </span>
            </div>
            <div class="innermain_pop" style="margin-top:10px;">
                <span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibtnVerifyInvitation" ImageUrl="~/App/Images/submit-button.gif" OnClientClick="return ValidateInvitation();" />
                </span><span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibnCancelInvitation" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClientClick="return HideInvitationPopup();" />
                </span>
            </div>            
        </div>
    </div>
    <input type="hidden" id="hidEventID" runat="server" />

    <script type="text/javascript" language="javascript">
        function ValidateInvitation() {//debugger;
            var txtInvitationCode = $("#<%=txtInvitationCode.ClientID %>");

            if (txtInvitationCode.val() == '') {
                alert('Please enter invitation code');
                txtInvitationCode.focus();
                return false;
            }
            __doPostBack('VerifyInvitationCode', txtInvitationCode.val());
        }
        function HideInvitationPopup() {
            $("#<%=hidEventID.ClientID %>").val("0");
            $("#InvitationCodeDiv").dialog('close');
            return false;
        }
        function SelectEvent(eventid) {//debugger;

            var hidEventID = $("#<%=hidEventID.ClientID %>");
            var txtInvitationCode = $("#<%=txtInvitationCode.ClientID %>");
            txtInvitationCode.val("");
            hidEventID.val(eventid);
            $("#InvitationCodeDiv").dialog('open');
            return false;
        }
    </script>
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

        $("#InvitationCodeDiv").dialog({ autoOpen: false, hide: 'slide', width: 350, height: 150, modal: true });        
    });
    
    </script>
    
    
    
    
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="Franchisee_Technician_uctechnicianleftpanel"
    CodeBehind="uctechnicianleftpanel.ascx.cs" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<%@ Register src="~/App/UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQToolKit" %>

<script language="javascript" type="text/javascript">

    String.prototype.trim = function() 
    {
        a = this.replace(/^\s+/, '');
        return a.replace(/\s+$/, '');
    };
    
    function keypress_AllowNumericAndAlphanumeric(evt)
    {//debugger
        
        var key =  (evt.which?evt.which:((evt.charCode)?evt.charCode:((evt.keyCode)?evt.keyCode:0))) ;
        
        if(evt.shiftKey == false)
        {
            if((key >= 48 && key <= 57) || key == 9 || key == 32 || key==13 || key == 8 || key == 222  || (key >=65 && key <= 90) || (key >=96 && key <= 105))
            {
                return true;
            }
        }
        else if(evt.shiftKey == true)
        {
            if ((key>=65 && key <=90))
            {
                return true;
            }
        }
        return false;
            
    }
    
    function ShowHideCheckBox()
    {
        var ddlSearch=document.getElementById("<%= this.ddlSearch.ClientID %>");
        var divShowCustomer=document.getElementById("<%= this.divShowCustomer.ClientID %>");
        if(ddlSearch.value=="Event")
        {
            divShowCustomer.style.display = 'none';
        }
        else
        {
            divShowCustomer.style.display = 'block';
        }
        return false;
    }
    
    function ValidateSearch()
        {
            var tb = $get("<%=txtSearch.ClientID %>");
            var behavior = $find("bTxtSearch");
           
            if(tb.value == behavior._watermarkText)
            {
                alert("Please enter text to search!");
                return false;
            }
            else
            {
                if(tb.value.trim()=="")
                {
                    alert("Please enter text to search!");
                    return false;
                }
            }
        }
</script>

<JQToolKit:jQueryToolKit ID="ucJquery" runat="server" IncludeJQueryUI="true" IncludeJQueryWaterMark="true" />

<script language="javascript" type="text/javascript">

    $(function () {
        $("#<%=txtSearch.ClientID %>").watermark();
    });


</script>

<div class="wrapper_leftnpad">
    <div class="leftheader">
        <div>Quick Search</div>
    </div>
    <div class="lftpnlserchbox">
        <asp:Panel ID="pnlQuickSearchTechnician" runat="server" DefaultButton="imgSearch">
            <span id="spTB" runat="server">
                <asp:TextBox ID="txtSearch" title="Search Text" runat="server" Width="160px"></asp:TextBox>
            </span> Search in
            <span id="spDDL" runat="server">
                <asp:DropDownList ID="ddlSearch" runat="server" CssClass="inputf_def" Width="161px" onchange="ShowHideCheckBox();">
                    <asp:ListItem>Customer</asp:ListItem>
                    <asp:ListItem>Event</asp:ListItem>
                </asp:DropDownList>
            </span>           
             <div class="chkbx" id="divShowCustomer" runat="server">
                <asp:CheckBox ID="chkShowCustomer" runat="server" Text="With no appointments" />
            </div>
            <div id="spImg" runat="server">
                <asp:ImageButton ID="imgSearch" runat="server" OnClick="imgSearch_Click" ImageUrl="~/App/Images/search-button.gif" />&nbsp;
                <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="."
                    WatermarkCssClass="watermarktxtinput_default" TargetControlID="txtSearch" BehaviorID="bTxtSearch">
                </cc1:TextBoxWatermarkExtender>--%>
            </div>
        </asp:Panel>
    </div>
</div>

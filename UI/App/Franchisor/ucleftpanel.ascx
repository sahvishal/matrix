<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_Franchisor_ucleftpanel"
    CodeBehind="ucleftpanel.ascx.cs" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<%@ Register src="../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQToolKit" %>

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
            if((key >= 48 && key <= 57) || key == 9 || key == 32 || key==13 || key == 8 || (key >=65 && key <= 90) || (key >=96 && key <= 105))
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
        if(ddlSearch.value=="Customer")
        {
            divShowCustomer.style.display = 'block';
        }
        else
        {
            divShowCustomer.style.display = 'none';
        }
        return false;
    }
    
   
     function ValidateSearch() {

         var tb = document.getElementById("<%= this.txtSearch.ClientID  %>");
           if(tb.value == "")
            {
                alert("Please enter text to search!");
                return false;
            }
        }

    
</script>

<JQToolKit:jQueryToolKit ID="ucJquery" runat="server" IncludeJQueryUI="true" IncludeJQueryWaterMark="true" />

<script language="javascript" type="text/javascript">

    $(function () {
        $("input:text").watermark();
    });


</script>

<div class="wrapper_leftnpad" id="divContainer" runat="server">
    <div class="leftheader">
        <div>Quick Search</div>
    </div>
    <div class="lftpnlserchbox">
        <asp:Panel ID="pnlQuickSearch" runat="server" DefaultButton="imgSearch">
            <span id="spTB" runat="server">
                <asp:TextBox ID="txtSearch" title="Search Text" runat="server" Width="155px"></asp:TextBox>
            </span>Search in <span id="spDDL" runat="server">
                <asp:DropDownList EnableViewState="true" ID="ddlSearch" runat="server" Width="161px"
                    onchange="ShowHideCheckBox();">
                </asp:DropDownList>
            </span>
            <div class="chkbx" id="divShowCustomer" runat="server">
                <asp:CheckBox ID="chkShowCustomer" runat="server" Text="With no appointments" />
            </div>
            <div class="srchbtn" id="spImg" runat="server">
                <asp:ImageButton ID="imgSearch" runat="server" OnClick="imgSearch_Click" ImageUrl="~/App/Images/search-button.gif" />
                <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="."
                    WatermarkCssClass="watermarktxtinput_default" TargetControlID="txtSearch" BehaviorID="bTxtSearch">
                </cc1:TextBoxWatermarkExtender>--%>
            </div>
        </asp:Panel>
    </div>
    <div class="leftheader">
        <div>Quick Nav</div>
    </div>
    <div class="lftpnlbox" id="_divQuickLinks" runat="server">
    </div>
    <div class="leftheader">
        <div>Recently Visited</div>
    </div>
    <div class="lftpnlbox" id="_divRecentlyVisitedLinks" runat="server">
    </div>
    <input type="hidden" runat="server" id="hidDropDownValue" />
</div>

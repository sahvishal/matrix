<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true"
    Inherits="App_Customer_ChangeAppointment" Title="Untitled Page" CodeBehind="ChangeAppointment.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UCCommon/UCChangeAppointment.ascx" TagName="UCChangeAppointment"
    TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
 
   var GB_ROOT_DIR = "/App/Wizard/greybox/";
    </script>

    <JQueryControl:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="false" IncludeSexyComboBox="false" IncudeJQueryAutoComplete="true" />
    <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd"> <%= IoC.Resolve<ISettings>().CompanyName %> Wellness Dashboard</span>
            <div style="float: right; width: 340px; padding-top: 3px;" id="divLastLogin" runat="server">
                <span style="float: left; width: 7px;">
                    <img src="/App/Images/leftroundlastlogin.gif" /></span> <span style="float: left;
                        width: 320px; padding: 1px; text-align: center; background-color: #FFD4A8; border-top: solid 1px #F1B678;
                        border-bottom: solid 1px #F1B678;"><span style="color: #000;" id="spLastLogin" runat="server">
                            Your last login time:</span></span> <span style="float: left">
                                <img src="/App/Images/rightroundlastlogin.gif"></span>
            </div>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
        </div>
        <div class="left">
            <uc1:UCChangeAppointment ID="UCChangeAppointment1" runat="server" IsCustomer="true" />
        </div>
    </div>
</asp:Content>

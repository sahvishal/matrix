<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_AddNewContact" CodeBehind="AddNewContact.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <style type="text/css">
        .mainbody_outer_anp
        {
            float: right;
            width: 777px;
            background-color: #fff;
            margin-top: 5px;
        }
        .mainbody_inner_anp
        {
            width: 763px;
            margin-left: 14px;
            margin-bottom: 5px;
        }
        .main_area_bdr_anp
        {
            float: left;
            width: 751px;
            border: 1px solid #E5E5E5;
            padding-bottom: 6px;
            padding-top: 6px;
            margin-top: 5px;
        }
        .main_container_row_anp
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 3px;
            padding-right: 5px;
            padding-bottom: 3px;
        }
        .titletext_anp
        {
            float: left;
            width: 100px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .titletext1_anp
        {
            float: left;
            width: 120px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .titletext2_anp
        {
            float: left;
            width: 130px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfieldcon_anp
        {
            float: left;
            width: 180px;
            margin-right: 85px;
            padding-top: 0px;
        }
        .inputfieldcontype_anp
        {
            float: left;
            width: 220px;
            margin-right: 45px;
            padding-top: 0px;
        }
        .inputfieldcontype1_anp
        {
            float: left;
            width: 220px;
            margin-right: 35px;
            padding-top: 0px;
        }
        .inputfieldbigcon_anp
        {
            float: left;
            width: 350px;
            padding-top: 4px;
        }
        .inputfieldrightcon_anp
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
        }
        .inputareacon_anp
        {
            float: left;
            width: 580px;
            font: normal 12px arial;
            color: #000;
        }
        .inputf_anp
        {
            float: left;
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 1px;
        }
        .headbg_box_anp
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-top: 5px;
            margin-bottom: 3px;
        }
        .head_text_anp
        {
            float: left;
            width: 740px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .list_anp
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .bigbtnconlft_anp
        {
            float: left;
            width: 110px;
            padding-left: 5px;
        }
        .bigbtncon2_anp
        {
            float: right;
            width: 135px;
            padding-right: 5px;
        }
        .headbg2_box_anp
        {
            float: left;
            width: 757px;
            padding-top: 5px;
            padding-bottom: 10px;
        }
        .save_button1_anp
        {
            float: right;
            width: 56px;
            height: 32px;
            padding: 0px 5px 0px 0px;
            margin-bottom: 10px;
        }
        .bigbtncon_anp
        {
            float: right;
            padding: 0px 5px 0px 0px;
            margin-bottom: 10px;
        }
        .cancel_button_anp
        {
            float: right;
            width: 56px;
            height: 32px;
            padding: 0px 5px 0px 0px;
            margin-bottom: 10px;
        }
        .headerclose_button_si
        {
            float: left;
            width: 120px;
            text-align: right;
            padding-top: 1px;
        }
        .headertitle_popup_si
        {
            float: left;
            width: 540px;
            padding-left: 10px;
            padding-top: 4px;
        }
        .maindivpagemainrow_anp
        {
            float: left;
            padding-left: 31px;
            width: 718px;
        }
        .maindivpagemainrow1_anp
        {
            float: left;
            width: 615px;
            padding-left: 8px;
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .pagemainrow_anp
        {
            float: left;
            width: 718px;
            padding-top: 2px;
        }
        .inputfieldcontypenew_anp
        {
            float: left;
            width: 220px;
            margin-right: 40px;
            padding-top: 0px;
        }
        .inputfield_pdetails_anp
        {
            float: left;
            width: 210px;
            margin-right: 25px;
            padding-top: 0px;
        }
    </style>

    <script language="javascript" type="text/javascript">
    
        function ValidatePopUp()
        {
            var txtBday = document.getElementById('<%= this.txtBday.ClientID %>');
            
            if(isBlank(document.getElementById('<%= this.txtFName.ClientID %>'), 'First Name'))
                return false;
                
            if(document.getElementById('<%= this.txtEMail.ClientID %>').value != '')
            {    
                if(validateEmail(document.getElementById('<%= this.txtEMail.ClientID %>'), "Email") != true)
                {
                   return false;
                }
            }
            
            if(trim(document.getElementById('<%= this.txtEmailOffice.ClientID %>').value) != '')
            {    
                if(validateEmail(document.getElementById('<%= this.txtEmailOffice.ClientID %>'), "Email Work") != true)
                {
                   return false;
                }
            }
            if (txtBday.value != '')
		    {
			if (ValidateDate(txtBday.value, 'Date of Birth.') == false)
			    {
					    return false;
			    }
		    }
          
        }
        
        function onclickProspect()
        {
            document.getElementById('divProspectHostBlock').style.display = 'block';
            document.getElementById('divhost').style.display = 'none';            
            document.getElementById('<%= this.txthost.ClientID %>').value = '';
            document.getElementById('divprospect').style.display = 'block';            
            document.getElementById('divcontactrole').style.display = 'block'; 
        }
        
        function onclickHost()
        {
            document.getElementById('divProspectHostBlock').style.display = 'block';
            document.getElementById('divprospect').style.display = 'none';            
            document.getElementById('<%= this.txtprospect.ClientID %>').value = '';
            document.getElementById('divhost').style.display = 'block';
            document.getElementById('divcontactrole').style.display = 'block'; 
        }
        
        function onclickNone()
        {
            document.getElementById('divProspectHostBlock').style.display = 'none';
            document.getElementById('divprospect').style.display = 'none';            
            document.getElementById('divhost').style.display = 'none';
            document.getElementById('divcontactrole').style.display = 'none'; 
            document.getElementById('<%= this.txtprospect.ClientID %>').value = '';
            document.getElementById('<%= this.txthost.ClientID %>').value = '';
        }
        
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="pgtitile" runat="server">Add New Contact</span>
                </div>
            </div>
            <div class="main_area_bdrnone" style="margin-top: 0px;">
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                <div id="Div1" class="pgnosymbolvsmall_common" runat="server">
                    <img src="/App/Images/page1symbolvsmall.gif" /></div>
                <div class="orngheadtxt16_common">
                    Personal Information</div>
            </div>
            <asp:Panel ID="pnlContact" runat="server" DefaultButton="ibtnSave">
                <div class="main_area_bdrnone">
                    <div class="maindivpagemainrow_anp">
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Title:</span> <span class="inputfieldcon_prospect">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="inputf_anp" Width="50px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">First Name:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputfieldcon_prospect">
                                <asp:TextBox ID="txtFName" runat="server" CssClass="inputf_anp" Width="170px"></asp:TextBox></span>
                            <span class="titletext_anp">Middle Name: </span><span class="inputfieldrightcon_anp">
                                <asp:TextBox ID="txtMName" runat="server" CssClass="inputf_anp" Width="170px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Last Name:</span> <span class="inputfieldcon_prospect">
                                <asp:TextBox ID="txtLName" runat="server" CssClass="inputf_anp" Width="170px"></asp:TextBox></span>
                            <span class="titletext_anp">Date of Birth:</span> <span class="inputfieldrightcon_anp">
                                <span style="float: left;">
                                    <asp:TextBox ID="txtBday" runat="server" CssClass="inputf_anp" Width="120px"></asp:TextBox>
                                </span><span style="float: left; padding-left: 3px; padding-top: 3px;">
                                    <asp:ImageButton ID="ibtntodate" runat="server" CssClass="" ImageUrl="~/App/Images/calendar-icon.gif" /></span>
                                <span style="float: left; font-size: 7pt;" cssclass="inputf_anp">(mm/dd/yyyy)</span>
                            </span>
                            <cc1:CalendarExtender ID="caleventfrom" runat="server" Format="MM/dd/yyyy" PopupButtonID="ibtntodate"
                                TargetControlID="txtBday">
                            </cc1:CalendarExtender>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Gender:</span> <span class="inputfieldcon_prospect">
                                <asp:RadioButton ID="rbtMale" runat="server" Checked="false" GroupName="grpGender" />
                                M&nbsp;
                                <asp:RadioButton ID="rbtFeMale" runat="server" Checked="false" GroupName="grpGender" />
                                F </span><span class="titletext_anp">Email:</span><span class="inputfieldrightcon_anp"><asp:TextBox
                                    ID="txtEMail" runat="server" CssClass="inputf_anp" Width="170px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Phone (Home):</span><span class="inputfieldcon_prospect"><asp:TextBox
                                ID="txtPhoneHome" runat="server" CssClass="inputf_anp mask-phone" Width="170px"></asp:TextBox></span>
                            <span class="titletext_anp">Phone (Cell):</span><span class="inputfieldrightcon_anp"><asp:TextBox
                                ID="txtPhoneCell" runat="server" CssClass="inputf_anp mask-phone" Width="120px"></asp:TextBox></span>
                        </p>
                    </div>
                </div>
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                    <div id="Div2" class="pgnosymbolvsmall_common" runat="server">
                        <img src="/App/Images/page2symbolvsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Work Place Information</div>
                </div>
                <div class="main_area_bdrnone">
                    <div class="maindivpagemainrow_anp">
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Job Title:</span> <span class="inputfieldcon_prospect">
                                <asp:TextBox ID="txtJobtitle" runat="server" CssClass="inputf_anp" Width="170px"></asp:TextBox></span>
                            <span class="titletext_anp">Company:</span><span class="inputfieldrightcon_anp"><asp:TextBox
                                ID="txtOrganisation" runat="server" Width="170px" CssClass="inputf_anp"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Org. Address:</span><span class="inputfieldcon_prospect"><asp:TextBox
                                ID="txtAddress" runat="server" CssClass="inputf_anp" TextMode="multiLine" Width="170px"></asp:TextBox></span>
                            <span class="titletext_anp">Website:</span><span class="inputfieldrightcon_anp"><asp:TextBox
                                ID="txtWebsite" runat="server" CssClass="inputf_anp" Width="170px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">City:</span><span class="inputfieldcon_prospect">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="inputf_anp auto-search-city" Width="130px"></asp:TextBox>
                            </span><span class="titletext_anp">Email:</span> <span class="inputfieldcon_prospect">
                                <asp:TextBox ID="txtEmailOffice" runat="server" CssClass="inputf_anp" Width="170px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">State:</span><span class="inputfieldcon_prospect"><asp:DropDownList
                                ID="ddlState" runat="server" Width="130px" CssClass="list_anp ddl-states" AutoPostBack="False">
                            </asp:DropDownList>
                            </span><span class="titletext_anp">Phone: </span><span class="inputfieldrightcon_anp">
                                <asp:TextBox ID="txtPhoneOffice" runat="server" CssClass="inputf_anp mask-phone" Width="120px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Zip:</span> <span class="inputfieldcon_prospect">
                                <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_anp" Width="100px"></asp:TextBox>
                            </span><span class="titletext_anp">Fax: </span><span class="inputfieldrightcon_anp">
                                <asp:TextBox ID="txtFax" runat="server" CssClass="inputf_anp mask-phone" Width="120px"></asp:TextBox></span>
                        </p>
                        <p class="pagemainrow_anp">
                            <span class="titletext_anp">Type:</span> <span class="inputfieldcon_prospect">
                                <asp:DropDownList ID="ddlContactType" runat="server" CssClass="list_anp" Width="140px">
                                </asp:DropDownList>
                            </span><span class="titletext_anp">Ext:</span><span class="inputfieldrightcon_anp"><asp:TextBox
                                ID="txtExt" runat="server" CssClass="inputf_anp" MaxLength="6" Width="50px"></asp:TextBox>
                            </span>
                        </p>
                    </div>
                </div>
                <div class="main_area_bdrnone" style="margin-top: 0px;">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                    <div id="Div3" class="pgnosymbolvsmall_common" runat="server">
                        <img src="/App/Images/page3symbolvsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Notes</div>
                </div>
                <div class="main_area_bdrnone">
                    <div class="maindivpagemainrow_anp">
                        <p class="pagemainrow_anp">
                            <span class="inputareacon_anp">
                                <asp:TextBox ID="txtNotes" runat="server" CssClass="inputf_anp" Width="625px" TextMode="MultiLine"
                                    Height="80px"></asp:TextBox></span>
                        </p>
                    </div>
                </div>
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></div>
                    <div class="pgnosymbolvsmall_common">
                        <img src="/App/Images/page4symbolvsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Contact Relationship</div>
                </div>
                <div class="main_area_bdrnone">
                    <div class="maindivpagemainrow_anp">
                        <asp:RadioButton runat="server" GroupName="ContactRel" Width="150px" onclick="onclickProspect();"
                            ID="rbtprospect" Text="Prospect" />
                        <asp:RadioButton runat="server" GroupName="ContactRel" Width="150px" onclick="onclickHost();"
                            ID="rbtHost" Text="Host" />
                        <asp:RadioButton runat="server" GroupName="ContactRel" Width="150px" onclick="onclickNone();"
                            Checked="true" ID="rbtNone" Text="None" />
                    </div>
                    <div id="divProspectHostBlock" style="float: left; display: none; width: 623px; margin-left: 31px;
                        border: solid 1px #e5e5e5; padding-top: 5px; margin-top: 5px; padding-bottom: 5px;">
                        <div style="display: none;" id="divprospect" class="maindivpagemainrow1_anp">
                            <span class="titletextnowidth_default">Prospect:</span> <span class="inputfldnowidth_default">
                                <asp:TextBox runat="server" ID="txtprospect" Width="300px" CssClass="auto-search-prospect">
                                </asp:TextBox></span>
                        </div>
                        <div style="display: none;" id="divhost" class="maindivpagemainrow1_anp">
                            <span class="titletextnowidth_default">Host:</span> <span class="inputfldnowidth_default">
                                <asp:TextBox runat="server" ID="txthost" CssClass="auto-search-host" Width="300px">
                                </asp:TextBox></span>
                        </div>
                        <div style="display: none;" id="divcontactrole" class="maindivpagemainrow1_anp">
                            <span class="titletextnowidth_default">Contact Role:</span> <span class="inputfldnowidth_default">
                                <asp:CheckBoxList runat="server" ID="chklistContactRole" RepeatColumns="3" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </span>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="headbg2_box_default" style="margin-top: 10px;">
                <div class="buttoncon_default">
                    <asp:ImageButton runat="server" CausesValidation="true" ID="ibtnSave" ImageUrl="~/App/Images/save-button.gif"
                        OnClientClick="return ValidatePopUp();" OnClick="ibtnSave_Click" /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton runat="server" CausesValidation="true" ID="ibtnCancel" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="ibtnCancel_Click" /></div>
            </div>
        </div>
    </div>

    <script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
    
        var stateId = "<%= this.StateId %>";
        
        $('.auto-search-city').autoComplete({
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
		    type: "POST",
		    data: "prefixText",
		    contextKey: stateId
        });
        
        $('.ddl-states').change(function()
            {
                $('.auto-search-city').autoComplete({
		            autoChange: true,
		            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
		            type: "POST",
		            data: "prefixText",
		            contextKey: $('.ddl-states option:selected').val()
                });
            });
            
        $('.auto-search-host').autoComplete({
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetHostByPrefixText")%>',
		    type: "POST",
		    data: "prefixText"
        });
        
        $('.auto-search-prospect').autoComplete({
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetProspectByPrefixText")%>',
		    type: "POST",
		    data: "prefixText"
        });
        // mask phone number
        $('.mask-phone').mask('(999)-999-9999');
    });
    
    </script>

</asp:Content>

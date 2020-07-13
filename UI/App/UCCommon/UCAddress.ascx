<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCAddress"
    CodeBehind="UCAddress.ascx.cs" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />

<script language="javascript" type="text/javascript">        
     function UCValidateAddress(prefix)
     { 
         var txtaddress1= document.getElementById("<%= this.txtaddress1.ClientID %>");
         var txtaddress2= document.getElementById("<%= this.txtAddress2.ClientID %>");
         var txtCity= document.getElementById("<%= this.txtCity.ClientID %>");
         var ddlState= document.getElementById("<%= this.ddlState.ClientID %>");        
         var txtzip1= document.getElementById("<%= this.txtZip.ClientID %>");
         var txtphonehome= document.getElementById("<%= this.txtphonehome.ClientID %>");
         var txtphoneother= document.getElementById("<%= this.txtphoneother.ClientID %>");
         var txtphonecell= document.getElementById("<%= this.txtphonecell.ClientID %>");
         var txtEmail1= document.getElementById("<%= this.txtEmail1.ClientID %>");
         var txtEmail2= document.getElementById("<%= this.txtEmail2.ClientID %>");
         
                  
         if (isBlank(txtaddress1,prefix + "Address"))
         {return false;}
         
         if ((checkDropDown(ddlState,prefix + "State for  Address")==false)      ||
              (isBlank(txtCity,prefix + "City for  Address")) )
         {return false;}
         
         if ((isInteger(txtzip1, prefix + "Zip")!=true))
         {return false;}
         
        if (isBlank(txtEmail1,prefix + "Email")){return false;}
         if ((validateEmail(txtEmail1,prefix + "Email")!=true)  )
         {return false;}
        
         if (txtEmail2.value !="")
         {
          if ((validateEmail(txtEmail2, prefix + "Other Email")!=true)  )
            {return false;}
         }
        
     }
   
</script>

<div id="divAddress" runat="server" style="float: left; padding: 0px; margin: 0px;">
    <p class="main_container_row_editp">
        <span class="titletext_editp">Address1:<span class="reqiredmark"><sup>*</sup></span>
        </span><span class="inputfieldcon_editp">
            <asp:TextBox ID="txtaddress1" runat="server" CssClass="inputf_editp" Width="170px"
                MaxLength="500" TextMode="multiLine" TabIndex="1"></asp:TextBox></span>
        <span class="titletext_editp">Phone (Cell):</span> <span class="inputfieldrightcon_editp">
            <asp:TextBox ID="txtphonecell" runat="server" CssClass="inputf_editp mask-phone-derived" TabIndex="6"
                MaxLength="100"></asp:TextBox>
        </span>
    </p>
    <p class="main_container_row_editp">
        <span class="titletext_editp">Suite,Apt,etc:</span><span class="inputfieldcon_editp">
            <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputf_editp" Width="170px"
                MaxLength="500" TextMode="multiLine" TabIndex="2"></asp:TextBox>
        </span><span class="titletext_editp">Phone (Home): </span><span class="inputfieldrightcon_editp">
            <asp:TextBox ID="txtphonehome" runat="server" TabIndex="6" CssClass="inputf_editp mask-phone-derived"
                MaxLength="100"></asp:TextBox>
        </span>
    </p>
    <p class="main_container_row_editp">
        <span class="titletext_editp">City:<span class="reqiredmark"><sup>*</sup></span>
        </span><span class="inputfieldcon_editp">
            <asp:TextBox ID="txtCity" runat="server" TabIndex="3" Width="100" CssClass="inputf_accm auto-search-city"></asp:TextBox>
        </span><span class="titletext_editp">Phone (Other): </span><span class="inputfieldrightcon_editp">
            <asp:TextBox ID="txtphoneother" runat="server" TabIndex="7" CssClass="inputf_editp mask-phone-derived"
                MaxLength="100"></asp:TextBox>
        </span>
    </p>
    <p class="main_container_row_editp">
        <span class="titletext_editp">State:<span class="reqiredmark"><sup>*</sup></span>
        </span><span class="inputfieldcon_editp">
            <asp:DropDownList ID="ddlState" runat="server" CssClass="inputf_accm" Width="120px"
                AutoPostBack="false" TabIndex="4">
            </asp:DropDownList>
        </span><span class="titletext_editp">Email:<span class="reqiredmark"><sup>*</sup></span>
        </span><span class="inputfieldrightcon_editp">
            <asp:TextBox ID="txtEmail1" runat="server" CssClass="inputf_editp" Width="170px"
                MaxLength="500" TabIndex="8"></asp:TextBox>
        </span>
    </p>
    <p class="main_container_row_editp">
        <span class="titletext_editp">Zip:<span class="reqiredmark"><sup>*</sup></span>
        </span><span class="inputfieldcon_editp">
            <asp:TextBox ID="txtZip" TabIndex="5" runat="server" CssClass="inputf_accm" Width="100"
                MaxLength="9"></asp:TextBox>
        </span><span class="titletext_editp">Other Email: </span><span class="inputfieldrightcon_editp">
            <asp:TextBox ID="txtEmail2" runat="server" CssClass="inputf_editp" Width="170px"
                MaxLength="500" TabIndex="9"></asp:TextBox>
        </span>
    </p>
</div>

<script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
    
        $('.auto-search-city').autoComplete({
            minchar: 3,
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
		    type: "POST",
		    data: "prefixText",
		    contextKey: "97"
        });
        
        $('.mask-phone-derived').mask("(999)-999-9999");
    });
    
</script>


<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCCustomerList"
    CodeBehind="UCCustomerList.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />

<script type="text/javascript" language="javascript">
 function Validate() 
 {
    
    var txtName = document.getElementById("<%= this.txtName.ClientID %>").value; 
    var txtCustomerID = document.getElementById("<%= this.txtCustomerID.ClientID %>").value; 


    var state = document.getElementById("<%= this.txtState.ClientID %>").value; 
    var city = document.getElementById("<%= this.txtCity.ClientID %>").value; 
    var zip = document.getElementById("<%= this.txtZip.ClientID %>").value; 
    var txtStartDate = document.getElementById("<%= this.txtStartDate.ClientID %>").value ; 
    var txtEndDate = document.getElementById("<%= this.txtEndDate.ClientID %>").value ; 
    var ddlFranchisee=document.getElementById("<%= this.ddlFranchisee.ClientID %>") ;
    var hfQueryString=document.getElementById("<%=this.hfQueryString.ClientID %>")
    
    var txtFirstName=document.getElementById("<%=this.txtFirstName.ClientID %>");
    var txtLastName=document.getElementById("<%=this.txtLastName.ClientID %>");
    var txtNCustomerID=document.getElementById("<%=this.txtNCustomerID.ClientID %>"); 
    
    if(hfQueryString.value=="No")
    {
        if((txtNCustomerID.value).length<1)
        {
            if(txtFirstName.value=="")
            {
                alert("Please enter first name.");
                return false;
            }
            if(txtLastName.value=="")
            {
                alert("Please enter last name.");
                return false;
            }
            if((txtFirstName.value).length<3)
            {
                alert("Please enter atleast 3 characters for first name.");
                return false;
            }
            if((txtLastName.value).length<3)
            {
                alert("Please enter atleast 3 characters for last name.");
                return false;
            }
        }
    }
    else
    {
        if(txtName == "" && txtCustomerID == "" && state == "" && city == "" && zip == "" && txtStartDate == "" && txtEndDate == "" && ddlFranchisee.selectedIndex <=0 ) 
        {
            alert("Please input at least one field (Name/State/City/Zip/CustomerID) to search."); 
            return false; 
        }
        if (txtStartDate == "" && txtEndDate == "") 
        {
        ///No date range provided
        //return true
        }
        else 
        {
            if (ValidateDate(txtStartDate, 'Date Range') == false) 
            {
                return false;
            }
            if (ValidateDate(txtEndDate, 'Date Range') == false) 
            {
                return false;
            }
        }
        
    }
   return true; 
   }
function Reset() {
    document.getElementById("<%= this.txtName.ClientID %>").value="";
    document.getElementById("<%= this.txtCustomerID.ClientID %>").value="";
   document.getElementById("<%= this.txtState.ClientID %>").value = ""; 
   document.getElementById("<%= this.txtCity.ClientID %>").value = ""; 
   document.getElementById("<%= this.txtZip.ClientID %>").value = ""; 
   document.getElementById("<%= this.txtStartDate.ClientID %>").value = ""; 
   document.getElementById("<%= this.txtEndDate.ClientID %>").value = ""; 
   document.getElementById("<%= this.ddlFranchisee.ClientID %>").selectedIndex=0;
   document.getElementById("<%= this.chkAbdCustomer.ClientID %>").checked=false;
   document.getElementById("<%=this.txtFirstName.ClientID %>").value="";
   document.getElementById("<%=this.txtLastName.ClientID %>").value="";
   document.getElementById("<%=this.txtNCustomerID.ClientID %>").value="";
   document.getElementById("<%=this.txtZipCode.ClientID %>").value="";
   
   return true; 
   }
   
   function NextBuild()
   {
        alert('Please check this in next release');
        return false; 
   }
 
    function txtkeypress(evt)
    {
        return KeyPress_NumericAllowedOnly(evt);
                
    }
    
    
     function AbondonedCustomer()
    {
   ///debugger
        var ddlFranchisee=document.getElementById("<%= this.ddlFranchisee.ClientID %>");
        var ddlDateType=document.getElementById("<%= this.ddlDateType.ClientID %>");
        var chkAbdCustomer=document.getElementById("<%= this.chkAbdCustomer.ClientID %>");
        var bolAbondonedCustomer=chkAbdCustomer.checked;
           
            ddlFranchisee.disabled = bolAbondonedCustomer;
           ddlDateType.disabled = bolAbondonedCustomer;

        if (bolAbondonedCustomer==true)
        {
            ddlFranchisee.selectedIndex=0;
            //ddlDateType.selectedIndex=1;
        }
        return true;
    
    }
    function popupmenu2(choice,wt,ht)
    {
        
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=no,scrollbars=no,menubar=no,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice,'theconfirmWin',winOpts);
    }

     
</script>

<div class="mainbody_outer">
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_default">
                <div class="orngheadtxt_default">
                    Search Customer</div>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <p class="graylinefull_default">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="725px" height="10px" /></p>
            <asp:Panel ID="pnlCustomer" runat="server" DefaultButton="ibtnSearch">
                <div class="divmainbody_cd">
                    <div class="grayboxtop_cl">
                        <p class="grayboxtopbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                        <p class="grayboxheader_cl">
                            Filter/Search Customer</p>
                        <div class="lgtgraybox_cl" id="divStartCallSearch" runat="server">
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titlenowdth_cl">Name:</span> <span class="inputfldnowidth_cl">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                                <span class="titlenowdth_cl">State:</span> <span class="inputfldnowidth_cl">
                                    <asp:TextBox ID="txtState" runat="server" CssClass="inputf_def auto-search-states"
                                        Width="100px"></asp:TextBox></span> <span class="titlenowdth_cl">City:</span>
                                <span class="inputfldnowidth_cl">
                                    <asp:TextBox ID="txtCity" runat="server" CssClass="inputf_def auto-search-city" Width="80px"></asp:TextBox></span>
                                <span class="titlenowdth_cl">Zip:</span> <span class="inputfldnowidth_cl">
                                    <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_def" Width="60px"></asp:TextBox></span>
                            </p>
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titlenowdth_cl">Customer ID:</span> <span class="inputfldnowidth_cl">
                                    <asp:TextBox ID="txtCustomerID" runat="server" MaxLength="9" CssClass="inputf_def"
                                        Width="62px"></asp:TextBox></span> <span class="titlenowdth_cl">Date Range:</span>
                                <span class="dateinputfldnowidth_cl dtfld_rgt">Start Date &nbsp;<asp:TextBox ID="txtStartDate"
                                    runat="server" CssClass="inputf_def date-picker" Width="60px"></asp:TextBox></span>
                                <span class="dateinputfldnowidth_cl dtfld_rgt">End Date &nbsp;<asp:TextBox ID="txtEndDate"
                                    runat="server" CssClass="inputf_def date-picker" Width="60px"></asp:TextBox></span>
                                <span style="float: left; padding-top: 2px;">
                                    <asp:DropDownList ID="ddlDateType" Width="110px" CssClass="inputfsmall_def" runat="server">
                                        <asp:ListItem Value="1">Signup Date</asp:ListItem>
                                        <asp:ListItem Value="3">Customer Date</asp:ListItem>
                                        <%--<asp:ListItem Value="4">Paid Customers</asp:ListItem>--%>
                                        <asp:ListItem Value="2">Attended Customers</asp:ListItem>
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span runat="server" id="divCustomer"><span class="titlenowdth_cl">Franchisee:</span>
                                    <span class="inputfldnowidth_cl">
                                        <asp:DropDownList ID="ddlFranchisee" runat="server" Width="150px" CssClass="inputf_def">
                                        </asp:DropDownList>
                                    </span></span><span class="inputfldnowidth_cl">
                                        <asp:CheckBox ID="chkAbdCustomer" Text="Show Customers who did not register for any event."
                                            runat="server" /></span>
                            </p>
                        </div>
                        <div class="lgtgraybox_cl" id="divWithoutStartCallSearch" runat="server" style="display: none;
                            visibility: hidden;">
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titlenowdth_cl_nocall">First Name:<span class="reqiredmark"><sup>*</sup></span></span>
                                <span class="inputfldnowidth_cl_nocall" style="width: 110px;">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox>
                                    <span style="float: left; font: normal 10px arial; color: #999; padding-left: 3px;">
                                        (min 3 characters)</span> </span><span class="titlenowdth_cl_nocall">Last Name:<span
                                            class="reqiredmark"><sup>*</sup></span></span> <span class="inputfldnowidth_cl_nocall"
                                                style="width: 110px;">
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox>
                                                <span style="float: left; font: normal 10px arial; color: #999; padding-left: 3px;">
                                                    (min 3 characters)</span> </span><span class="titlenowdth_cl_nocall">ZipCode:</span>
                                <span class="inputfldnowidth_cl_nocall" style="width: 110px;">
                                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox>
                                </span>
                            </p>
                            <p style="text-align: center; padding-top: 10px;">
                                <span style="font: bold 12px arial;">OR</span>
                            </p>
                            <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                                <span class="titlenowdth_cl_nocall">Customer ID:</span> <span class="inputfldnowidth_cl_nocall"
                                    style="width: 110px;">
                                    <asp:TextBox ID="txtNCustomerID" runat="server" CssClass="inputf_def" Width="100px"
                                        MaxLength="9"></asp:TextBox>
                                </span>
                            </p>
                        </div>
                        <div class="lgtgraybox_cl">
                            <span class="buttoncon_default">
                                <asp:ImageButton ID="ibtnSearch" OnClientClick="return Validate();" runat="server"
                                    ImageUrl="~/App/Images/search-smallbtn.gif" OnClick="ibtnSearch_Click" /></span>
                            <span class="buttoncon_default">
                                <asp:ImageButton ID="ibtnReset" OnClientClick="return Reset();" runat="server" ImageUrl="~/App/Images/reset-btn.gif"
                                    OnClick="ibtnReset_Click" /></span>
                        </div>
                        <p class="grayboxbotbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="4" /></p>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="740px" height="10px" /></p>
                    <p class="divmainbody_cd">
                        <span class="blkheadtxt_regcust" id="dvSearchResult1" runat="server"></span><span
                            class="blueheadtxt_regcust" id="dvSearchResult" runat="server" style="float: left">
                        </span>
                        <%-- <span class="orngheadtxt16_default" style="float:left">Search Results</span>--%>
                        <span id="spPageSize" runat="server"><span class="rightlnktxt_cl">
                            <asp:DropDownList ID="ddlRecords" AutoPostBack="true" CssClass="inputf_def" Width="50px"
                                runat="server" OnSelectedIndexChanged="ddlRecords_SelectedIndexChanged">
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="40">40</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                            </asp:DropDownList>
                        </span><span class="rightlnktxt_cl" id="spnPageLabel" runat="server" style="visibility: visible;
                            display: block">Records Per Page :&nbsp;</span> </span>
                    </p>
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <p class="graylinefull_default">
                        <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                    <p>
                        <img src="/App/Images/specer.gif" width="725px" height="10px" /></p>
                    <p class="divmainbody_cd">
                        <span runat="server" id="spButtons"><span class="buttoncon4_default">
                            <asp:ImageButton runat="server" ID="ibtnCSV" ImageUrl="~/App/Images/exptocsv-btn.gif"
                                OnClick="ibtnCSV_Click" /></span> <span class="buttoncon4_default">
                                    <asp:ImageButton runat="server" ID="ibtnPDF" ImageUrl="~/App/Images/exptopdf-btn.gif"
                                        OnClick="ibtnPDF_Click" /></span></span></p>
                    <%--<asp:LinkButton ID="lnkExcel" runat="server" Text="ExportToPDF" OnClick="lnkPDF_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkPDF" runat="server" Text="ExportToExcel" OnClick="lnkExcel_Click"></asp:LinkButton>--%>
                    <div class="grayboxtop_cl" id="divGrid" runat="server">
                        <p class="blueboxtopbg_cl">
                            <img src="../Images/specer.gif" width="746" height="6" /></p>
                        <div class="grayboxtop_cl">
                            <asp:GridView ID="grdCustomerList" DataKeyNames="CustomerID" runat="server" CssClass="divgrid_cl"
                                AutoGenerateColumns="false" AllowPaging="false" EnableSortingAndPagingCallbacks="False"
                                AllowSorting="false" GridLines="None" OnRowDataBound="grdCustomerList_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="CustomerID" HeaderText="ID">
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Customer Info.">
                                        <ItemTemplate>
                                            <span><a id="CustomerName" runat="server" href="Javascript:void(0)">
                                                <%# DataBinder.Eval(Container.DataItem, "Name")%></a></span>
                                            <br />
                                            <span><a href="mailto:<%# DataBinder.Eval(Container.DataItem, "Email")%>">
                                                <%# DataBinder.Eval(Container.DataItem, "Email")%></a> </span>
                                            <br />
                                            <span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "Phone")%></span>
                                            <br />
                                            <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RegDate")).ToString("dddd, MMMM dd, yyyy hh:mm tt") %>
                                            <br />
                                            Mode:<span style="color: #666; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "AddedBY")%></span> <span id="spAccountLocked"
                                                    runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "IsLocked")%>'
                                                    style="color: Red;">
                                                    <br />
                                                    <img src="/App/Images/accountlock-icon.gif" />
                                                </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marketing Source">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Marketing") %>
                                            <br />
                                            <%# IncomingNumber(DataBinder.Eval(Container.DataItem, "IncomingNumber")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Address")%>
                                            <br />
                                            <span style="color: #287AA8; font-size: 11px">
                                                <%# DataBinder.Eval(Container.DataItem, "RestAddress")%></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Most Recent Event">
                                        <ItemTemplate>
                                            <a id="EventName" runat="server" href="Javascript:void(0)">
                                                <%# DataBinder.Eval(Container.DataItem, "Event")%></a>
                                            <br />
                                            <%# DataBinder.Eval(Container.DataItem, "EventDate") %>
                                            <br />
                                            <span style="color:#287AA8;font-size:11px">
                                            <%# DataBinder.Eval(Container.DataItem, "Host")%></span>
                                            <br /><span style="color:#666;font-size:11px">
                                            <%# DataBinder.Eval(Container.DataItem, "Package")%>
                                        <%--<asp:Literal ID="_additionalTestLiteral" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "AdditionalTest"))!=string.Empty? "<br /><b>Add. Test: </b>" + DataBinder.Eval(Container.DataItem,"AdditionalTest"):"" %>' />
                     --%>
                                            </span><br />
                                            <%# DataBinder.Eval(Container.DataItem, "EventStatus")%>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Revenue">
                                        <ItemTemplate>
                                            $<%# DataBinder.Eval(Container.DataItem, "TotalRevenue")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField SortExpression="TotalRevenue" DataField="TotalRevenue" HeaderText="Total Revenue"></asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%--<asp:ImageButton ImageUrl="/App/Images/reg.gif" ID="ibtnCustomer" runat="server" OnClientClick="return NextBuild();" />--%>
                                            <a id="customerlist" runat="server" href='javascript:void(0);'>
                                                <img src="/App/Images/reg.gif" alt="Click here to view Details" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="row1" />
                                <RowStyle CssClass="row2" />
                                <AlternatingRowStyle CssClass="row3" />
                            </asp:GridView>
                        </div>
                        <div runat="server" id="tblGridPagingConFirmCust" style="float: left; width: 750px;"></div>
                        <p class="blueboxbotbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" /></p>
                    </div>
                </div>
            </asp:Panel>
            <p>
                <img src="/App/Images/specer.gif" width="725px" height="30px" /></p>
        </div>
    </div>
</div>
<asp:HiddenField ID="hfQueryString" runat="server" Value="0" />

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


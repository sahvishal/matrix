<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="True" Inherits="Falcon.App.UI.App.Common.SearchCustomer"
    CodeBehind="SearchCustomer.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true"  />

    <link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/app/JavascriptFiles/HttpRequest.js"></script>

    <script src="/app/JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function ClearSearch() {
            document.getElementById('<%= txtFirstName.ClientID %>').value = '';
            document.getElementById('<%= txtLastName.ClientID %>').value = '';
            document.getElementById('<%= txtCustomerID.ClientID %>').value = '';
            document.getElementById('<%= txtRegDate.ClientID %>').value = '';
            document.getElementById('<%= txtZip.ClientID %>').value = '';
            document.getElementById('<%= txtCity.ClientID %>').value = '';
            document.getElementById('<%= ddlstate.ClientID %>').selectedIndex = 0;
        }

        function Validation() {

            var txtFirstName = document.getElementById('<%= txtFirstName.ClientID %>');
            var txtLastName = document.getElementById('<%= txtLastName.ClientID %>');
            var txtCustomerID = document.getElementById('<%= txtCustomerID.ClientID %>');
            var txtRegDate = document.getElementById('<%= txtRegDate.ClientID %>');
            var txtZip = document.getElementById('<%= txtZip.ClientID %>');
            var txtCity = document.getElementById('<%= txtCity.ClientID %>');
            var ddlstate = document.getElementById('<%= ddlstate.ClientID %>');

            if (txtCustomerID.value == "") {
                if (txtFirstName.value.trim() == "") {
                    alert("Please enter the First Name.");
                    return false;
                }
                if (txtLastName.value.trim() == "") {
                    alert("Please enter the Last Name.");
                    return false;
                }
                if (txtFirstName.value != "" && (txtFirstName.value).length < 1) {
                    alert("Please enter atleast 1 character for the First Name.");
                    return false;
                }
                if (txtLastName.value != "" && (txtLastName.value).length < 2) {
                    alert("Please enter atleast 2 character for the Last Name.");
                    return false;
                }
            }
            var retresult = isNumericOnly(txtCustomerID, "CustomerID");

            if (retresult != true)
            { return false; }

        }

        function txtkeypress(evt)//Allows only alphanumeric
        {
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            if (key == 9 || key == 13 || key == 8 || (key >= 65 && key <= 90)) {
                return true;
            }
            return false;
        }

        function txtkeypress_numeric(evt) {
            return KeyPress_NumericAllowedOnly(evt);

        }

        function setFocusFirstName() {//debugger
            var txtFirstName = document.getElementById("<%=txtFirstName.ClientID %>");
            txtFirstName.focus();
        }
        function setFocusState() {
            var ddlstate = document.getElementById("<%=ddlstate.ClientID %>");
            ddlstate.focus();
        }
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Technician Register Customer
                    </span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innercon">
                        <p>
                            <img src="../Images/specer.gif" width="740px" height="5px" /></p>
                        <div class="regcust_innerrow">
                            <div class="pgnosymbol_regcust">
                                <asp:Image ID="imgSymbol" runat="server" ImageUrl="~/App/Images/CCRep/page1symbol.gif" />
                            </div>
                            <asp:Panel DefaultButton="ibtnSearch" ID="pnlSearch" runat="server">
                                <div class="middivrow_regcust">
                                    <p class="contentrow_regcust" style="visibility: hidden; display: none;">
                                        <span class="orngbold16_default" id="spSearchType" runat="server">Search Customer</span></p>
                                    <p class="fline_regcust" style="visibility: hidden; display: none;">
                                        <img src="../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                    <p class="middivrow_regcust">
                                        <span class="orngbold16_default">Search Customer</span>
                                    </p>
                                    <p class="fline_regcust">
                                        <img src="../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                    <p class="middivrow_regcust">
                                        <span class="titletxt_regcust">First Name:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                        </span><span class="titletxt_regcust">Last Name:<span class="reqiredmark"><sup>*</sup></span></span>
                                        <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="inputfield_ccrep" Width="95px"></asp:TextBox>
                                        </span>
                                    </p>
                                    <p class="middivrow_regcust">
                                        <span class="titletxt_regcust">Customer ID:</span> <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtCustomerID" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                                        <span class="titletxt_regcust">Date of Reg:</span> <span class="inputcondob_regcust">
                                            <asp:TextBox ID="txtRegDate" runat="server" CssClass="inputfield_ccrep date-picker"
                                                Width="95px"></asp:TextBox></span>
                                    </p>
                                    <p class="middivrow_regcust">
                                        <span class="titletxt_regcust">State:</span> <span class="inputconleft_regcust">
                                            <asp:DropDownList runat="server" Width="120px" ID="ddlstate" CssClass="inputf_def ddl-states" />
                                        </span>
                                        <span class="titletxt_regcust">City:</span> <span class="inputconright_regcust">
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="inputfield_ccrep auto-Search" Width="95px"></asp:TextBox>
                                        </span>
                                    </p>
                                    <p class="middivrow_regcust">
                                        <span class="titletxt_regcust">Zip:</span> <span class="inputconleft_regcust">
                                            <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                        </span>
                                        <span class="titletxt_regcust">Phone:</span> <span class="inputconright_regcust">
                                            <asp:TextBox runat="server" ID="txtPhone" CssClass="mask-phone"></asp:TextBox>
                                        </span>
                                    </p>
                                    <p class="fline_regcust">
                                        <img src="../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                    <div class="middivrow_regcust">
                                        <div style="float: left; width: 35px; color: #287AA8; font-weight: bold;">
                                            Note:
                                        </div>
                                        <div style="float: left; width: 360px; color: #287AA8; padding-right: 15px;">
                                            <span style="float: left; width: 10px;">&#8226;&nbsp;</span> <span style="float: left;
                                                width: 350px;">Please provide minimum one (1) character in First Name</span>
                                            <span style="width: 10px;">&#8226;&nbsp;</span> <span style="width: 350px;">Please provide
                                                minimun two (2) charcaters in Last Name for &nbsp;&nbsp;&nbsp;exact search or three
                                                (3) characters in Last Name for generic &nbsp;&nbsp;&nbsp;search.</span>
                                        </div>
                                        <span class="buttoncon_ccrep">
                                            <asp:ImageButton ID="ibtnClear" runat="server" ImageUrl="~/App/Images/clear-btn.gif"
                                                OnClientClick="ClearSearch(); return false;" />
                                        </span><span class="buttoncon_ccrep">
                                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                                OnClick="ibtnSearch_Click" OnClientClick="return Validation()" />
                                        </span>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="regcust_innerrow" id="divSkipNewCustomer" runat="server" visible="false">
                            <div style="float: right;">
                                <asp:LinkButton runat="server" ID="lnkSkipNewCustomer" Text="Skip To New Customer >>>"
                                    OnClick="lnkSkipNewCustomer_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="regcust_innerrow" id="divGrdCust" runat="server" style="display: none"
                            visible="false">
                            <p class="middivrow_regcust">
                                <img src="../Images/CCRep/specer.gif" width="1px" height="10px" /></p>
                            <div class="griddivnew_default">
                                <div class="griddivnew_default">
                                    <asp:GridView ID="grdCustomerHistory" runat="server" CssClass="divgrid_cl" AutoGenerateColumns="false"
                                        GridLines="None" AllowPaging="true" PageSize="20" OnPageIndexChanging="grdCustomerHistory_PageIndexChanging"
                                        OnRowCommand="grdCustomerHistory_RowCommand" OnRowDataBound="grdCustomerHistory_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="CustomerID" Visible="false"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Customer Name">
                                                <ItemTemplate>
                                                    <asp:Literal ID="CustomerNameLiteral" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Literal ID="AddressLiteral" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phone">
                                                <ItemTemplate>
                                                    <asp:Literal ID="PhoneLiteral" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOB">
                                                <ItemTemplate>
                                                    <asp:Literal ID="DOBLiteral" runat="server" /> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hint Q&A">
                                                <ItemTemplate>
                                                    <div id="divHintQA" runat="server">
                                                        <a href="javascript:void(0);" id='aShowHintQA<%#Eval("CustomerID") %>'>Show</a>
                                                        <span id="spanHintQA" style="display: none">                                                        
                                                            <span class="wrow">
                                                                <label class="bold">
                                                                    Question:</label>
                                                                <span id="spHintQues" runat="server"></span>
                                                            </span>
                                                            <span class="wrow" style="margin-top: 5px">
                                                                <label class="bold">
                                                                    Answer:</label>
                                                                <span id="spHintAns" runat="server"></span>
                                                            </span>
                                                        </span>
                                                    </div>
                                                    <script language="javascript" type="text/javascript">
                                                        $(document).ready(function () {
                                                            var customerId = '<%# DataBinder.Eval(Container.DataItem, "CustomerID")%>';

                                                            $("#aShowHintQA" + customerId).qtip({
                                                                content: {
                                                                    title: "Hint Question & Answer",
                                                                    text: function (api) {
                                                                        return $(this).next().html();
                                                                    }
                                                                }
                                                            });
                                                        });
                                                </script>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <div style="text-align: center;">
                                                        Action</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="text-align: center;">                                                        
                                                        <asp:LinkButton runat="server" ID="lnkBtnSelect" CommandName='<%# DataBinder.Eval(Container.DataItem, "CustomerId")%>'>Select</asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="row1" />
                                        <RowStyle CssClass="row2" />
                                        <AlternatingRowStyle CssClass="row2" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divMoreResults" runat="server" visible="false" >
                            <span class="info-box">“Results are always limited to 20, narrow down your search criteria by specifying more details.”</span>
                    </div>
                </div>
            </div>

            <script type="text/javascript" language="javascript">

                $(document).ready(function() {

                    var stateId = "<%= StateId %>";

                    $('.auto-Search').autoComplete({
                        autoChange: true,
                        url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                        type: "POST",
                        data: "prefixText",
                        contextKey: stateId
                    });

                    $(".date-picker").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-10:+50"
                    });

                    $('.ddl-states').change(function() {
                        $('.auto-Search').autoComplete({
                            autoChange: true,
                            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                            type: "POST",
                            data: "prefixText",
                            contextKey: $('.ddl-states option:selected').val()
                        });
                    });

                    $('.mask-phone').mask('(999)-999-9999');
                });

            </script>

        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <asp:HiddenField runat="server" ID="hfGuId" />
</asp:Content>

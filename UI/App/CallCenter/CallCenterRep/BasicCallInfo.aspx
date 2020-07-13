<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    AutoEventWireup="true" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.BasicCallInfo"
    Title="Basic Call Information" CodeBehind="BasicCallInfo.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryMaskInput="true"
        IncudeJQueryJTip="true" />
    <script type="text/javascript" src="../../JavascriptFiles/HttpRequest.js"></script>
    <script language="javascript" type="text/javascript">

        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        String.prototype.trim = function () {
            a = this.replace(/^\s+/, '');
            return a.replace(/\s+$/, '');
        };


        function requestFailed()
        { }

        function CallEnd() {
            postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "~/CallCenter/CallCenterRepDashboard/Index";
        }
        var IsOk = "2";

        function Validation() {
            var txtCallBackNo = document.getElementById("<%=txtCallBackNo.ClientID %>");
            if ('<%= IsInboundCall %>' == 'True' && '<%= IoC.Resolve<ISettings>().EnableCallPop %>' == 'True') {
                if (txtCallBackNo.value.trim().length < 1) {
                    alert("Please provide the caller's number as callback number.");
                    txtCallBackNo.focus();
                    return false;
                }
            }

            var txtCustomerID = document.getElementById("<%=txtCustomerID.ClientID %>");
            var txtZipCode = document.getElementById("<%=txtZipCode.ClientID %>");
            var txtMemberId =  document.getElementById("<%=txtMemberId.ClientID %>");
            var txtFirstName = document.getElementById("<%=txtFirstName.ClientID %>");
            var txtLastName = document.getElementById("<%=txtLastName.ClientID %>");
            if ($.trim(txtCustomerID.value).length <= 0 && $.trim(txtMemberId.value).length <= 0) {
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

                if ('<%= IsInboundCall %>' == 'True') {
                    if (txtZipCode.value.trim().length < 1) {
                        alert("Please provide the zip code of the called customer.");
                        txtZipCode.focus();
                        return false;
                    }
                }

            }
            var txtSourceCode = document.getElementById("<%=this.txtSourceCode.ClientID %>");
            if (txtSourceCode.value.trim() == "") {
                __doPostBack('Search', '');
            }
            else {
                checkVaildSourceCode();

            }
            return false;
        }

        function OnComplete(arg) {
            if (arg == false) {
                var IsOk = confirm("Source Code either invalid or Source Code is expired. Click Ok to continue without source code or click cancel to try again.");
                if (IsOk == false) {
                    return false;
                }
                else {
                    var txtSourceCode = document.getElementById("<%=this.txtSourceCode.ClientID %>");
                    txtSourceCode.value = "";
                }

            }
            __doPostBack('Search', '');
        }
        function OnTimeOut(arg) {
            alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");
        }
        function OnError(arg) {
            alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");
        }
        function checkVaildSourceCode() {
            var txtSourceCode = document.getElementById("<%=this.txtSourceCode.ClientID %>");
            $.ajax({
                url: '/App/AutoCompleteService.asmx/VerifySourceCode', contentType: "application/json; charset=utf-8", dataType: 'json', type: 'POST',
                data: "{'sourceCode': '" + txtSourceCode.value + "' }", success: function (result) { OnComplete(result.d); },
                error: function (a, b, c) { OnError(null); }
            });
            //ret = AutoCompleteService.VerifySourceCode(txtSourceCode.value, OnComplete, OnTimeOut, OnError);
        }

        function txtkeypress_AlphanumericOnly(evt)//Allows only alphanumeric
        {
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            if (key == 9 || key == 13 || key == 8 || key == 222 || (key >= 65 && key <= 90)) {
                return true;
            }
            return false;
        }

        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }


    </script>
    <div class="wrapper_inpg">
        <div class="bluheader">
            <div id="dvTitle" runat="server">
                Call Centre Rep Dashboard
            </div>
        </div>
        <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
            runat="server">
        </div>
        <div class="main_area_bdr">
            <div class="maincontentrow_ccrep">
                <div class="pgnosymbol_regcust">
                    <asp:Image ID="imgSymbol" runat="server" ImageUrl="~/App/Images/CCRep/page1symbol.gif" />
                </div>
                <asp:Panel DefaultButton="ibtnNext" ID="pnlSearch" runat="server">
                    <div class="midrow_bcinfo">
                        <h2>&nbsp;Basic Call Information</h2>
                        <div class="fline_regcust">
                        </div>
                        <div class="crepvoice">
                            Thank you for calling
                            <%= IoC.Resolve<ISettings>().CompanyName %>
                            (ask of the fields below)
                        </div>
                        <div class="fline_regcust">
                        </div>
                        <p class="midrow_bcinfo">
                            <span class="titletxt_regcust">Call Back No:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputconleft_regcust">
                                <asp:TextBox ID="txtCallBackNo" runat="server" CssClass="inputfield_ccrep mask-phone"
                                    Width="120px"></asp:TextBox>
                            </span><span class="titletxt_regcust">Zip Code:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputcondob_regcust">
                                <asp:TextBox ID="txtZipCode" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                        </p>
                        <p class="midrow_bcinfo">
                            <span class="titletxt_regcust">First Name:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputconleft_regcust">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                            <span class="titletxt_regcust">Last Name:<span class="reqiredmark"><sup>*</sup></span></span>
                            <span class="inputconright_regcust">
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                        </p>
                        <p class="midrow_bcinfo">
                            <span class="titletxt_regcust">Customer ID:<span class="reqiredmark"><sup>&#8224;</sup></span></span>
                            <span class="inputconleft_regcust">
                                <asp:TextBox ID="txtCustomerID" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                            <span class="titletxt_regcust">Phone Number:<span class="reqiredmark"></span></span>
                            <span class="inputconright_regcust">
                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="inputfield_ccrep mask-phone" Width="120px"></asp:TextBox></span>
                        </p>
                        <p class="midrow_bcinfo">
                            <span class="titletxt_regcust">Member Id:</span>
                            <span class="inputconleft_regcust">
                                <asp:TextBox ID="txtMemberId" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                            <span class="titletxt_regcust">HICN/Medicare Id:</span>
                            <span class="inputconright_regcust">
                                <asp:TextBox ID="txtHicn" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox></span>
                        </p>
                        
                        <p class="midrow_bcinfo">
                            <span class="titletxt_regcust">MBI Number:</span>
                            <span class="inputconleft_regcust">
                                <asp:TextBox ID="txtMbiNumber" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                            </span>
                        </p>
                         
                        <p class="midrow_bcinfo" id="p1" runat="server">
                            <span class="titletxt_regcust">Email:<sup>&#12345;</sup></span> <span class="inputconleft_regcust">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="inputfield_ccrep" Width="210px"></asp:TextBox></span>
                            
                        </p>
                        <div class="fline_regcust">
                        </div>
                        <p class="midrow_bcinfo">
                            <span class="titletxt_regcust" style="width: 160px;">Do you have a source code?</span>
                            <span class="inputconleft_regcust">
                                <asp:TextBox ID="txtSourceCode" runat="server" CssClass="inputfield_ccrep" Width="140px"></asp:TextBox>
                            </span><a href="javascript:void(0);" runat="server" id="ahrefToolTipIsPaid" class="jtip"
                                title=' &nbsp;| Source Code are directly tied to any Special Offers and Discounts offered. If you wish to take advantage of any special offer or discount, Please provide your source code.'>What is this?</a>
                        </p>
                        <div class="fline_regcust">
                        </div>
                        <div class="left" style="width: 420px; color: #287AA8">
                            <strong>Note:</strong>
                            <ul>
                                <li>Please provide a minimum of one (1) character of the First Name.</li>
                                <li>Please provide a minimum of two (2) charcaters of the Last Name for exact searches
                                    or three (3) or more characters of the Last Name for generic searches.</li>
                                <li>If a Customer ID is entered, only call back number is required in case of inbound
                                    call.</li>
                            </ul>
                        </div>
                        <div class="left">
                            <asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="~/App/Images/next-buton.gif"
                                OnClientClick="return Validation();" OnClick="ibtnNext_Click" />
                        </div>
                    </div>
                </asp:Panel>
                <div class="rightdivrow_regcust">
                    <div class="timeboard_ccrep_dboard">
                        <div class="timeboxbg_ccrep_dboard">
                            <p class="tboxrow_ccrep_dboard">
                                <span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span
                                    id="SS"></span></span>
                            </p>
                            <p class="tboxrowformat_ccrep_dboard">
                                <span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
                            </p>
                            <p class="tboxrowbtm_ccrep_dboard">
                                <span class="whttxt_ccrep_dboard">Call in Progress</span>
                            </p>
                        </div>
                    </div>
                    <div class="endcall_ccrep_dboard" style="margin-top: 5px">
                        <span class="endtbtn_ccrep_dboard">
                            <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                                OnClientClick="CallNotes(); return false;" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <script language="javascript" type="text/javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('.mask-phone').mask('(999)-999-9999');
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
        });
    </script>
</asp:Content>

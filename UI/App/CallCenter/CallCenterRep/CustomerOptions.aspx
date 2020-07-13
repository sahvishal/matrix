<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    AutoEventWireup="true" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.CustomerOptions"
    Title="Customer Options" CodeBehind="CustomerOptions.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Finance.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .viewScriptButton {
            -moz-appearance: none !important;
            /*background-color: #68AAC4 !important;*/
            background: url(/App/Images/button-bg.gif);
            border: none;
            color: white !important;
            padding: 4px 13px !important;
            margin: 0px 5px 0px 18px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 13px;
            font-weight: bold;
        }

        .warm-transfer-message {
            color: #4F8A10;
            background-color: #DFF2BF;
            padding: 10px;
            border: 1px solid #4f8a10;
            margin: 5px;
            width: 96%;
            font-weight: bold;
            font-style: italic;
        }
    </style>

    <div class="wrapcrep_inpg">
        <div class="bluheader">
            <div>
                &nbsp;
            </div>
        </div>
        <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
            runat="server">
        </div>
        <div class="main_area_bdr">
            <div class="maincontentrow_ccrep">
                <div class="regcust_innerrow">
                    <div class="pgnosymbol_regcust">
                        <asp:Image ID="imgSymbol" runat="server" ImageUrl="~/App/Images/CCRep/page3symbol.gif" />
                    </div>
                    <div class="midrow_bcinfo">
                        <h2>&nbsp;<span id="spSearchType" runat="server"></span></h2>
                        <div class="fline_regcust">
                        </div>
                        <div class="crepvoice" runat="server" id="customername">
                        </div>
                        <div class="fline_regcust">
                        </div>
                    </div>
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
                        <div>
                            <div class="endcall_ccrep_dboard" style="margin-top: 5px">
                                <span class="endtbtn_ccrep_dboard">
                                    <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                                        OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                                </span>
                            </div>
                        </div>
                        <div>
                        </div>
                    </div>
                    <div class="middivrow_regcust" id="divOptions" runat="server">
                        <div class="custmr_optlnk">
                            <img src="/App/Images/CCRep/one.gif" title="Customer Option 1" alt="Customer Option 1" />
                            <asp:LinkButton ID="lnkRegEventExisting" Text="Register for Event" runat="server"
                                OnClick="lnkCallType_Click" CommandName="ExistingCustomerRegister"></asp:LinkButton>
                        </div>
                        <div class="custmr_optlnk">
                            <img src="/App/Images/CCRep/two.gif" title="Customer Option 2" alt="Customer Option 2" />
                            <asp:LinkButton ID="lnkRegisterCustomer" Text="Review/Modify Existing Info" runat="server"
                                OnClick="lnkCallType_Click" CommandName="ExistingCustomer"></asp:LinkButton>
                        </div>
                        <div class="custmr_optlnk">
                            <img src="/App/Images/CCRep/three.gif" title="Customer Option 3" alt="Customer Option 3" />
                            <asp:LinkButton ID="lnkIssues" Text="Login Issues" runat="server" OnClick="lnkCallType_Click"
                                CommandName="Issues"></asp:LinkButton>
                        </div>
                        <div class="custmr_optlnk">
                            <img src="/App/Images/CCRep/four.gif" title="Customer Option 4" alt="Customer Option 4" />
                            <asp:LinkButton ID="lnkRequestPrintVersion" Text="Results Report Request" runat="server"
                                OnClick="lnkCallType_Click" CommandName="RequestReport"></asp:LinkButton>
                        </div>
                        <%
                            try
                            {
                                var products = IoC.Resolve<IElectronicProductRepository>().GetAllProducts();
                                if (products != null && products.Count > 0)
                                {%>
                        <div class="custmr_optlnk">
                            <img src="/App/Images/CCRep/five.gif" title="Customer Option 5" alt="Customer Option 5" />
                            <asp:LinkButton ID="lnkAdditionalProductRequest" Text="Add On Product" runat="server"
                                CommandName="AddOnProduct" OnClick="lnkCallType_Click"></asp:LinkButton>
                        </div>
                        <div class="custmr_optlnk">
                            <img src="/App/Images/CCRep/Six.gif" title="Customer Option 6" alt="Customer Option 6" />
                            <%
                                }
                                else
                                { %>
                            <div class="custmr_optlnk">
                                <img src="/App/Images/CCRep/five.gif" title="Customer Option 5" alt="Customer Option 5" />
                                <% }
                            }
                            catch
                            { %>
                                <div class="custmr_optlnk">
                                    <img src="/App/Images/CCRep/five.gif" title="Customer Option 5" alt="Customer Option 5" />
                                    <%}
                                    %>
                                    <asp:LinkButton ID="LinkButton1" Text="Gift Certificate" runat="server" CommandName="GiftCertificate"
                                        OnClick="lnkCallType_Click"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="middivrow_regcust" id="divNewOptions" runat="server">
                                <div class="custmr_optlnk">
                                    <img src="/App/Images/CCRep/one.gif" title="Customer Option 1" alt="Customer Option 1" />
                                    <asp:LinkButton ID="lnkRegisterEvent" Text="Register for Event" runat="server" OnClick="lnkCallType_Click"
                                        CommandName="RegisterCustomer"></asp:LinkButton>
                                </div>
                                <div class="custmr_optlnk">
                                    <img src="/App/Images/CCRep/two.gif" title="Customer Option 2" alt="Customer Option 2" />
                                    <asp:LinkButton ID="lnkNotes" Text="Information Request/Other" runat="server" CommandName="OtherIssues"
                                        OnClick="lnkCallType_Click"></asp:LinkButton>
                                </div>
                                <div class="custmr_optlnk">
                                    <img src="/App/Images/CCRep/three.gif" title="Customer Option 2" alt="Customer Option 2" />
                                    <asp:LinkButton ID="RCustomerGiftCertificateLinkButton" Text="Gift Certificate" runat="server"
                                        CommandName="GiftCertificate" OnClick="lnkCallType_Click"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="maincontentrow_ccrep">
                            <span id="ViewScriptDiv" runat="server" class="left" style="margin-top: 5px;">
                                <%--<input type="button" value="View Script" id="ViewScriptBtn" class="viewScriptButton" onclick="setScriptWindow();" />--%>
                                <a href="#" id="ViewScriptBtn" onclick="setScriptWindow();">
                                    <span class="viewScriptButton">View Script</span>
                                </a>
                            </span>

                            <span class="left" style="margin-top: 5px;" id="spBtnSearchAgain" runat="server">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App/Images/search-again-btn.gif"
                                    OnClick="ImageButton1_Click" />
                            </span>
                        </div>
                        <div class="maincontentrow_ccrep warm-transfer-message" runat="server" id="showWarmTransferMessage" style="display: none;">
                            <span>"This patient is eligible for home visit transfer"</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <script type="text/javascript" language="javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);

        var viewScriptUrl = '<%= ScriptUrl %>';

                function setScriptWindow() {
                    window.localStorage.setItem("isScriptOpen", true);
                    window.localStorage.setItem("scriptUrl", viewScriptUrl);
                    openScriptWindow();
                }


                $(document).ready(function () {
                    var decoded = $("<textarea/>").html($("#<%=customername.ClientID %>").html()).text();
                    $("#<%=customername.ClientID %>").html(decoded);

                    checkAndOpenScriptPopup();
                });
    </script>
</asp:Content>

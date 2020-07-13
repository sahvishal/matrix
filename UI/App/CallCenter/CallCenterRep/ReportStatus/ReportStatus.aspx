<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" Inherits="App_CallCenter_ReportStatus_ReportStatus" Codebehind="ReportStatus.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../../JavascriptFiles/HttpRequest.js"></script>

    <script language="javascript">
    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequest.failureCallback = requestFailed();

    function requestFailed()
    {}
    
     function CallEnd()
     {
        postRequest.url ="RegisterCustomerCall.aspx?CallEnd=True";
        postRequest.post("");
        window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
     }
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
        
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Call Centre Rep Dashboard</span>
                    <span class="headingright_default"></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            
            <div class="maindivredmsgbox" style="visibility: hidden; display: none">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innercon">
                        <span>
                            <img src="../../../Images/specer.gif" width="740px" height="5px" /></span>
                        <div class="regcust_innerrow">
                            <div class="pgnosymbol_regcust">
                                <img src="../../../Images/CCRep/page3symbol.jpg" />
                            </div>
                            <div class="middivrow_regcust">
                                <p class="orngheadtxt_regcust">
                                    Report Status</p>
                                <p class="fline_regcust">
                                    <img src="../../../Images/CCRep/specer.gif" width="1" height="1" /></p>
                                <p class="normaltxt_regcust">
                                </p>
                                <p class="subheadingbg_ccrep">
                                    Customer Information</p>
                                <p class="middivrow_regcust">
                                    <span class="titletxt_regcust">Customer Name:</span> <span class="inputconleft_regcust"
                                        id="spnCustomerName" runat="server">CustomerEvent2</span> <span class="titletxt_regcust">
                                            Email:</span> <span class="inputconright_regcust" id="spnEmail" runat="server">yashird@healthyes.com</span>
                                </p>
                                <p class="middivrow_regcust">
                                    <span class="titletxt_regcust">Address:<%--<span class="reqiredmark"><sup>*</sup></span>--%></span>
                                    <span class="inputconleft_regcust" id="spnAddress" runat="server">212, Mardayal, - 110025
                                    </span>
                                </p>
                                <p class="subheadingbg_ccrep">
                                    Report Collection</p>
                                <p class="middivrow_regcust">
                                    <span class="titletxtbig_regcust">Report Collection Mode:</span> <span class="inputconleft_regcust">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Enabled="false" Width="150px">
                                            <asp:ListItem Text="Select Mode"></asp:ListItem>
                                        </asp:DropDownList>
                                    </span>
                                </p>
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
                                <div><img src="../../../Images/specer.gif" height="5px" width="2px" /></div>
                                <div class="endcall_ccrep_dboard">
                                    <span class="endtbtn_ccrep_dboard">
                                      <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif" OnClientClick="CallNotes(); return false;"  />
                          
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="regcust_innerrow">
                            <p class="middivrow_regcust">
                                <img src="../../../Images/CCRep/specer.gif" width="1" height="10" /></p>
                            <%-- <div class="dgheadeventhistory_ccrep">Event History</div>--%>
                            <p class="maincontentrow_re">
                                <span class="blkheadtxt_regcust" id="dvSearchResult1" runat="server"></span><span
                                    class="blueheadtxt_regcust" id="dvSearchResult" runat="server"></span>
                            </p>
                            <div class="dgeventhistory_ccrep" id="dbsearch" runat="server" style="display: none"
                                visible="false">
                                <div class="dgheadeventhistory1_ccrep">
                                    <img src="../../../Images/CCRep/specer.gif" width="20px" height="3px" /></div>
                                <asp:GridView ID="dgeventhistory" runat="server" CssClass="grideventhistorynew" AutoGenerateColumns="false"
                                    GridLines="None" AllowPaging="true" PageSize="5" OnPageIndexChanged="dgeventhistory_PageIndexChanged"
                                    OnPageIndexChanging="dgeventhistory_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                                        <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                                        <asp:BoundField DataField="Date" HeaderText="Date"></asp:BoundField>
                                        <asp:BoundField DataField="City" HeaderText="City"></asp:BoundField>
                                        <asp:BoundField DataField="AppTime" HeaderText="AppTime"></asp:BoundField>
                                        <asp:BoundField DataField="Package" HeaderText="Package"></asp:BoundField>
                                        <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method"></asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                                       <%-- <asp:BoundField DataField="HealthInfo" HeaderText="HealthInfo"></asp:BoundField>--%>
                                    </Columns>
                                    <HeaderStyle CssClass="row1" />
                                    <RowStyle CssClass="row2" />
                                    <AlternatingRowStyle CssClass="row2" />
                                </asp:GridView>
                            </div>
                        </div>
                        <p class="regcust_innerrow">
                            <span class="btncon_ccrep">
                                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="~/App/Images/back-buton.gif"
                                    OnClick="imgBack_Click" /></span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />

    <script language="javascript">
     //// this will run after page is load
      var hfCallStartTime= document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>

</asp:Content>

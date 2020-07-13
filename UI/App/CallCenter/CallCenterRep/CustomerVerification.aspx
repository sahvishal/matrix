<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    AutoEventWireup="true" Inherits="App_CallCenter_CallCenterRep_CustomerVerification"
    Title="Untitled Page" CodeBehind="CustomerVerification.aspx.cs" %>

<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryUI="true" IncudeJQueryJTip="true" />

    <script type="text/javascript" src="../../JavascriptFiles/HttpRequest.js"></script>
    <link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>

    <style>
        .PopUp1 {
            width: 394px;
        }

        .PopUp_topbg1 {
            float: left;
            width: 394px;
            background: url(/App/images/topbg-popup-new.gif) no-repeat;
            padding: 0px;
            margin: 0px;
        }

        .PopUp_header1 {
            float: left;
            width: 390px;
            border-left: solid 2px #ADC7DE;
            border-right: solid 2px #ADC7DE;
            background-color: #CEE1F4;
        }

        .PopUp_headtxt1 {
            float: left;
            font: bold 16px arial;
            padding-left: 10px;
            padding-bottom: 10px;
        }

        .PopUp_closebtn1 {
            float: right;
            padding-right: 5px;
        }

        .PopUp_midbg1 {
            float: left;
            width: 370px;
            border-left: solid 2px #ADC7DE;
            border-right: solid 2px #ADC7DE;
            padding: 10px;
            background-color: #fff;
            text-align: justify;
            font: normal 12px arial;
        }

        .PopUp_botbg1 {
            float: left;
            width: 394px;
            background: url(/App/images/botbg-popup-new.gif) no-repeat;
            padding: 0px;
            margin: 0px;
        }

        .headerpopup_genreal1 {
            float: right;
            width: 353px;
            font: bold 12px arial;
            color: #000000;
            background-color: #CEE1F4;
        }

        .headertitle_popup1 {
            float: left;
            width: 240px;
            padding-left: 5px;
            padding-top: 4px;
        }

        .headerclose_button_large1 {
            float: right;
            width: 135px;
            text-align: right;
            padding-top: 1px;
        }

        .popupintdiv1 {
            width: 333px;
            padding-top: 10px;
            float: left;
            padding-left: 15px;
            padding-right: 5px;
        }

        .modalBackground1 {
            background-color: #AAB5B9;
            filter: alpha(opacity=50);
            -moz-opacity: 0.5;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function sel_caption(divactive) {
            document.getElementById("<%= this.hfheader.ClientID %>").value = divactive;

            document.getElementById('divHeaderOTHERS').className = 'gridtaboff_vesv_CV';
            document.getElementById('divOTHERS').className = 'tabtxtoff_vesv';
            document.getElementById('divHeaderZIP').className = 'gridtaboff_vesv_CV';
            document.getElementById('divZIP').className = 'tabtxtoff_vesv';

            document.getElementById('divHeaderProspect').className = 'gridtaboff_vesv_CV';
            document.getElementById('divProspect').className = 'tabtxtoff_vesv';

            document.getElementById(divactive).className = 'gridtabon_vesv_CV';

            if (divactive == 'divHeaderOTHERS')
                document.getElementById('divOTHERS').className = 'tabtxton_vesv';
            else if (divactive == 'divHeaderZIP')
                document.getElementById('divZIP').className = 'tabtxton_vesv';
            else if (divactive == 'divHeaderProspect')
                document.getElementById('divProspect').className = 'tabtxton_vesv';
        }


        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        function requestFailed()
        { }

        function CallEnd() {
            postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
        }

        function ShowHintQuesAns(HintQ, HintA) {
            var spQues = document.getElementById("spQues");
            var spAns = document.getElementById("spAns");
            spQues.innerHTML = HintQ.replace("*", "'");
            spAns.innerHTML = HintA.replace("*", "'");
            $('#divHintQA').dialog('open');
        }

    </script>

    <asp:HiddenField ID="hfheader" Value="divHeaderOTHERS" runat="server" />
    <div class="wrapcrep_inpg">
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
                <div class="regcust_innerrow">
                    <div class="pgnosymbol_regcust">
                        <asp:Image ID="imgSymbol" runat="server" ImageUrl="~/App/Images/CCRep/page2symbol.gif" />
                    </div>
                    <div class="middivrow_regcust">
                        <p class="contentrow_regcust">
                            <span class="orngheadtxt_regcust" id="spSearchType" runat="server">Customer Verification</span>
                        </p>
                        <div class="fline_regcust">
                        </div>
                        <div class="crepvoice2" id="ScriptTextDiv" runat="server">
                            Look like you have called us before or have an account with us.<br />
                            For verification please answer the following questions.
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
                        <div class="endcall_ccrep_dboard" style="margin-top: 5px">
                            <span class="endtbtn_ccrep_dboard">
                                <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                                    OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class="maindivgrids_hd" id="divResults" runat="server" style="margin-top: 25px;">
                    <div class="dgviewcalls_hd">
                        <cc1:TabContainer ActiveTabIndex="2" CssClass="grayboxtop_cl" ID="tbpnlContainer"
                            runat="server">
                            <cc1:TabPanel runat="server" ID="pnlZIP">
                                <HeaderTemplate>
                                    <div id="divHeaderZIP" class="gridtabon_vesv_CV">
                                        <div id="divZIP" style="cursor: pointer; width: 100%; font-weight: normal; text-align: left;"
                                            class="tabtxton_vesv" onclick="sel_caption('divHeaderZIP');">
                                            Records Matching Zip
                                        </div>
                                    </div>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div class="left" id="divResultsMatchingZip" runat="server">
                                        <div class="grayboxtop_cl">
                                            <asp:GridView ID="grdCustomerListZIP" runat="server" CssClass="divgrid_cl" AllowPaging="true"
                                                PageSize="10" AutoGenerateColumns="false" GridLines="None" OnPageIndexChanging="grdCustomerListZIP_PageIndexChanging"
                                                OnRowDataBound="grdCustomerListZIP_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Customer Info">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "User.FirstName") + " " + DataBinder.Eval(Container.DataItem, "User.LastName")%>
                                                            <br>
                                                            (id:<%#DataBinder.Eval(Container.DataItem, "CustomerID")%>) 

                                                             <asp:Image ImageUrl="/Content/Images/Do-Not-Call.gif" Style="width: 20px; height: 20px;" alt="" runat="server" class="donotcontact-infoimage" ID="doNotContactInfoImage"
                                                                 Visible="false" />
                                                            <asp:Image ImageUrl="/Content/Images/Do-Not-Mail.jpg" Style="width: 20px; height: 20px;" alt="" runat="server" class="donotcontact-infoimage" ID="doNotMailInfoImage"
                                                                Visible="false" />
                                                            
                                                            <div id="doNotContactDiv" style="display: none;">
                                                                <asp:Label ID="doNotContactReasonSpan" runat="server" Font-Bold="true">
                                                                </asp:Label>
                                                                <br />
                                                                <asp:Label ID="doNotContactReasonNotesSpan" runat="server" Font-Italic="true">
                                                                </asp:Label>
                                                            </div>
                                                            <br />
                                                            (Member Id: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "MemberId").ToString()) ? "N/A" : DataBinder.Eval(Container.DataItem, "MemberId") %>)
                                                            <br />
                                                            (HICN/Medicare Id: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Hicn").ToString()) ? "N/A" : DataBinder.Eval(Container.DataItem, "Hicn") %>)
                                                            <br />
                                                            <b>Tag:</b>  <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Tag").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "Tag")  %><br />
                                                            <b>Custom Tag:</b>  <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "CustomTag").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "CustomTag")  %><br />
                                                            (Copay Amount: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Copay").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "Copay")  %>)
                                                            <br />
                                                            (Medicare Plan Name: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "MedicarePlanName").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "MedicarePlanName")  %>)
                                                            <br />
                                                            <div style="<%# DataBinder.Eval(Container.DataItem, "IsEligible") == null ? "background-color:yellow": (DataBinder.Eval(Container.DataItem, "IsEligible").ToString() == "True"? "background-color:green":"background-color:red")  %>">(Eligible: <%# DataBinder.Eval(Container.DataItem, "IsEligible") == null ? "N/A" :   (DataBinder.Eval(Container.DataItem, "IsEligible").ToString() == "True"? "Yes":"No")  %>)</div>
                                                            <br />
                                                            <div style="float: left;">
                                                                <b>Pre-Approved Test(s): </b>
                                                            </div>
                                                            <div style="float: left; padding-left: 5px; padding-top: 2px;">
                                                                <a href="javascript:void(0)" class="view-pre-approved-test"><b>View</b></a>
                                                                <div class="pre-approved-tests" style="display: none;">
                                                                    <div style="max-width: 250px;"><%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "PreApprovedTest").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "PreApprovedTest")  %></div>
                                                                </div>

                                                            </div>
                                                            <%--<b>Pre-Approved Test(s): </b><%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "PreApprovedTest").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "PreApprovedTest")  %>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address">
                                                        <ItemTemplate>
                                                            <span style="width: 70px">
                                                                <%#DataBinder.Eval(Container.DataItem, "User.HomeAddress.Address1") + " " + DataBinder.Eval(Container.DataItem, "User.HomeAddress.City") + ", " + DataBinder.Eval(Container.DataItem, "User.HomeAddress.State") +", " +DataBinder.Eval(Container.DataItem, "User.HomeAddress.Zip")%>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DOB">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "User.DOB") != null && !string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "User.DOB").ToString()) ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "User.DOB")).ToString("MM/dd/yyyy") : "" %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hint Q&A">
                                                        <ItemTemplate>
                                                            <a href="#" id="aShow1" runat="server">Show</a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>                                                           
                                                            <asp:LinkButton runat="server" ID="SelectCustomerLink" Text="Select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerId") + "," + DataBinder.Eval(Container.DataItem, "User.UserID") %>'
                                                                OnClick="SelectCustomerLink_Click">                                                            
                                                            </asp:LinkButton>
                                                            <asp:LinkButton runat="server" ID="DNCSelectCustomerLink" Text="Select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerId")  %>'
                                                                OnClick="DNCSelectCustomerLink_Click">                                                            
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="row1" />
                                                <RowStyle CssClass="row2" />
                                                <AlternatingRowStyle CssClass="row3" />
                                            </asp:GridView>
                                        </div>
                                        <div class="blueboxbotbg_cl">
                                        </div>
                                    </div>
                                    <div style="float: left; width: 740px; border: solid 1px #e5e5e5; padding: 10px 0px; display: none;"
                                        id="divNoResultsMatchingZip" runat="server">
                                        <div class="divnoitemfound_custdbrd" style="margin-top: 15px;">
                                            <p class="divnoitemtxt_custdbrd">
                                                <span class="orngbold18_default">No Records Found</span>
                                            </p>
                                        </div>
                                    </div>
                                    <div id="divMoreResultsMatchingZip" runat="server" visible="false" style="color: #D60202; font-weight: bold;">
                                        <span>&ldquo;Too many results. Please be more specific with your search criteria.</span>
                                    </div>
                                </ContentTemplate>
                            </cc1:TabPanel>
                            <cc1:TabPanel runat="server" ID="pnlOTHERS">
                                <HeaderTemplate>
                                    <div id="divHeaderOTHERS" class="gridtabon_vesv_CV">
                                        <div id="divOTHERS" style="cursor: pointer; width: 100%; font-weight: normal; text-align: left;"
                                            class="tabtxton_vesv" onclick="sel_caption('divHeaderOTHERS');">
                                            Records Matching Without Zip
                                        </div>
                                    </div>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div class="left" id="divResultsWithoutMatchingZip" runat="server">
                                        <div class="grayboxtop_cl">
                                            <asp:GridView ID="grdCustomerList" runat="server" CssClass="divgrid_cl" AllowPaging="true"
                                                PageSize="10" AutoGenerateColumns="false" GridLines="None" OnPageIndexChanging="grdCustomerList_PageIndexChanging"
                                                OnRowDataBound="grdCustomerList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Customer Info">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "User.FirstName")+ " " + DataBinder.Eval(Container.DataItem, "User.LastName")%>
                                                            <br />
                                                            <%# DataBinder.Eval(Container.DataItem, "CustomerID").ToString().Trim() != "0" ? "id: " +  DataBinder.Eval(Container.DataItem, "CustomerID") : "" %>

                                                            <asp:Image ImageUrl="/Content/Images/Do-Not-Call.gif" Style="width: 20px; height: 20px;" alt="" runat="server" class="donotcontact-infoimage" ID="doNotContactInfoImage"
                                                                Visible="false" />
                                                             <asp:Image ImageUrl="/Content/Images/Do-Not-Mail.jpg" Style="width: 20px; height: 20px;" alt="" runat="server" class="donotcontact-infoimage" ID="doNotMailInfoImage"
                                                                Visible="false" />
                                                           
                                                            <div id="doNotContactDiv" style="display: none;">
                                                                <asp:Label ID="doNotContactReasonSpan" runat="server" Font-Bold="true">
                                                                </asp:Label>
                                                                <br />
                                                                <asp:Label ID="doNotContactReasonNotesSpan" runat="server" Font-Italic="true">
                                                                </asp:Label>
                                                            </div>
                                                            <br />
                                                            (Member Id: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "MemberId").ToString()) ? "N/A" : DataBinder.Eval(Container.DataItem, "MemberId") %>)
                                                            <br />
                                                            (HICN/Medicare Id: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Hicn").ToString()) ? "N/A" : DataBinder.Eval(Container.DataItem, "Hicn") %>)
                                                            <br />
                                                            <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Tag").ToString()) ? "" : "<b>Tag</b> : " + DataBinder.Eval(Container.DataItem, "Tag") + "<br/>" %>
                                                            <%# (string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "CustomTag").ToString())) ? "" : "<div style='max-width:250px'> <b>Custom Tag</b> : " + DataBinder.Eval(Container.DataItem, "CustomTag") + "</div>" %> 
                                                            (Copay Amount: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Copay").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "Copay")  %>)
                                                            <br />
                                                            (Medicare Plan Name: <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "MedicarePlanName").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "MedicarePlanName")  %>)
                                                            <br />
                                                            <div style="<%# DataBinder.Eval(Container.DataItem, "IsEligible") == null ? "background-color:yellow": (DataBinder.Eval(Container.DataItem, "IsEligible").ToString() == "True"? "background-color:green":"background-color:red")  %>">( <b>Eligible: <%# DataBinder.Eval(Container.DataItem, "IsEligible") == null ? "N/A" :   (DataBinder.Eval(Container.DataItem, "IsEligible").ToString() == "True"? "Yes":"No")  %></b>)</div>
                                                            <br />
                                                            <div style="float: left;">
                                                                <b>Pre-Approved Test(s): </b>
                                                            </div>
                                                            <div style="float: left; padding-left: 5px; padding-top: 2px;">
                                                                <a href="javascript:void(0)" class="view-pre-approved-test"><b>View</b></a>
                                                                <div class="pre-approved-tests" style="display: none;">
                                                                    <div style="max-width: 250px;"><%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "PreApprovedTest").ToString()) ? "N/A" :  DataBinder.Eval(Container.DataItem, "PreApprovedTest")  %></div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address">
                                                        <ItemTemplate>
                                                            <span style="width: 70px">
                                                                <%#DataBinder.Eval(Container.DataItem, "User.HomeAddress.Address1") + " " + DataBinder.Eval(Container.DataItem, "User.HomeAddress.City") + ", " + DataBinder.Eval(Container.DataItem, "User.HomeAddress.State") +", " +DataBinder.Eval(Container.DataItem, "User.HomeAddress.Zip")%>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DOB">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "User.DOB") != null && !string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "User.DOB").ToString()) ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "User.DOB")).ToString("MM/dd/yyyy") : "" %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hint Q&A">
                                                        <ItemTemplate>
                                                            <a href="#" id="aShow" runat="server">Show</a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="SelectCustomerLink" Text="Select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerId") + "," + DataBinder.Eval(Container.DataItem, "User.UserID") %>'
                                                                OnClick="SelectCustomerLink_Click">                                                            
                                                            </asp:LinkButton>
                                                            <asp:LinkButton runat="server" ID="DNCSelectCustomerLink" Text="Select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerId") %>'
                                                                OnClick="DNCSelectCustomerLink_Click">                                                            
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="row1" />
                                                <RowStyle CssClass="row2" />
                                                <AlternatingRowStyle CssClass="row3" />
                                            </asp:GridView>
                                        </div>
                                        <div class="blueboxbotbg_cl">
                                        </div>
                                    </div>
                                    <div style="float: left; width: 746px; border: solid 1px #e5e5e5; padding: 10px 0px; display: none;"
                                        id="divNoResultsWithoutMatchingZip" runat="server">
                                        <div class="divnoitemfound_custdbrd">
                                            <p class="divnoitemtxt_custdbrd">
                                                <span class="orngbold18_default">No Records Found</span>
                                            </p>
                                        </div>
                                    </div>
                                    <div id="divMoreResultsWithoutMatchingZip" runat="server" visible="false" style="color: #D60202; font-weight: bold;">
                                        <span>&ldquo;Too many results. Please be more specific with your search criteria.&ldquo;</span>
                                    </div>
                                </ContentTemplate>
                            </cc1:TabPanel>
                            <cc1:TabPanel runat="server" ID="pnlProspect">
                                <HeaderTemplate>
                                    <div id="divHeaderProspect" class="gridtabon_vesv_CV">
                                        <div id="divProspect" style="cursor: pointer; width: 100%; font-weight: normal; text-align: left;"
                                            class="tabtxton_vesv" onclick="sel_caption('divHeaderProspect');">
                                            Prospect
                                        </div>
                                    </div>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div class="left" id="ProspectCustomerContainerDiv" runat="server">
                                        <div class="grayboxtop_cl">
                                            <asp:GridView ID="ProspectGridView" runat="server" CssClass="divgrid_cl" AllowPaging="True"
                                                AutoGenerateColumns="False" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Customer Details">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName")%>
                                                            <br />
                                                            (Ph:<%# DataBinder.Eval(Container.DataItem, "PhoneHome").ToString() %>)
                                                            <br />
                                                            <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "WellnessSeminar").ToString()) ? "" : ("<b> Workshop: </b>" + DataBinder.Eval(Container.DataItem, "WellnessSeminar") + " " + " <br /> (Dated:" + Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "SeminarDate")).ToString("MM/dd/yyyy") + " ) " + "(" + DataBinder.Eval(Container.DataItem, "SourceCode") + ")") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "AddressLine1") %>
                                                            <%# string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "AddressLine2").ToString()) ? "" : ", " + DataBinder.Eval(Container.DataItem, "AddressLine2")%>
                                                            <br />
                                                            <%# DataBinder.Eval(Container.DataItem, "City") %>,
                                                            <%# DataBinder.Eval(Container.DataItem, "State") %>
                                                            <%# DataBinder.Eval(Container.DataItem, "Zip") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="SelectPropsectCustomerLink" Text="Select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProspectCustomerId") %>'
                                                                OnClick="SelectPropsectCustomerLink_Click">                                                            
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <AlternatingRowStyle CssClass="row3" />
                                                <HeaderStyle CssClass="row1" />
                                                <RowStyle CssClass="row2" />
                                            </asp:GridView>
                                        </div>
                                        <div class="blueboxbotbg_cl">
                                        </div>
                                    </div>
                                    <div style="float: left; width: 746px; border: solid 1px #e5e5e5; padding: 10px 0px; display: none;"
                                        id="ProspectCustomerNoResultFoundContainerDiv" runat="server">
                                        <div class="divnoitemfound_custdbrd">
                                            <p class="divnoitemtxt_custdbrd">
                                                <span class="orngbold18_default">No Records Found</span>
                                            </p>
                                        </div>
                                    </div>
                                    <div id="ProspectCustomerWarningContainerDiv" runat="server" style="color: #D60202; display: none; font-weight: bold;">
                                        <span>&ldquo;Too many results. Please be more specific with your search criteria.&lrdquo;</span>
                                    </div>
                                </ContentTemplate>
                            </cc1:TabPanel>
                        </cc1:TabContainer>
                    </div>
                </div>
                <div class="ntxtrowrow_ccrep_dboard" style="margin: 25px 0 0 2px;">
                    <span class="left" style="padding-right: 5px;">
                        <asp:ImageButton ID="ibtnskiptocustomer" runat="server" ImageUrl="~/App/Images/skiptocustomer-btn.gif"
                            OnClick="ibtnskiptocustomer_Click" />
                    </span><span class="left">
                        <asp:ImageButton ID="ibtnSearchAgain" runat="server" ImageUrl="~/App/Images/search-again-btn.gif"
                            OnClick="ibtnSearchAgain_Click" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />

    <script language="javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>

    <%--TODO:Need to remove--%>
    <asp:Panel ID="PanelHintQA" Style="display: none" runat="server" CssClass="PopUp1">
        <div class="left">
            <div class="PopUp_topbg1">
            </div>
            <div class="PopUp_header1">
                <span class="PopUp_headtxt1">Hint Question & Answer</span> <span class="PopUp_closebtn1">
                    <asp:ImageButton ID="ibtnclosesymbol" runat="server" ImageUrl="~/App/images/close-button-symbol.gif" /></span>
            </div>
            <div class="PopUp_midbg1">
                <span style="float: left; font: bold 12px Arial; width: 60px;"></span>
                <br />
                <span style="float: left; font: bold 12px Arial; width: 60px;"></span>
            </div>
            <div class="PopUp_botbg1">
            </div>
        </div>
    </asp:Panel>
    <asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="ModalPopupExtenderTop" runat="server" TargetControlID="lnktemp"
        PopupControlID="PanelHintQA" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol"
        BehaviorID="mdlPopup" />
    <%--TODO:Need to remove--%>
    <div id="divHintQA" style="display: block" title="Hint Question &amp; Answer">
        <asp:HiddenField ID="_hfsourceCode" runat="server" />
        <div class="wrow">
            <label class="bold">
                Question:</label>
            <span id="spQues"></span>
        </div>
        <div class="wrow" style="margin-top: 5px">
            <label class="bold">
                Answer:</label>
            <span id="spAns"></span>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#divHintQA').dialog({ width: 400, autoOpen: false, resizable: false, draggable: false, modal: true });

            var decoded = $("<textarea/>").html($("#<%=ScriptTextDiv.ClientID %>").html()).text();
            $("#<%=ScriptTextDiv.ClientID %>").html(decoded);

            checkAndOpenScriptPopup();
        });

        function AlertInEligibleCustomer() {
            var result = confirm("You are attempting to schedule a participant who is NOT eligible for testing.  Do you want to proceed?");
            return result;
        }

        $('.view-pre-approved-test').qtip({
            position: {

                viewport: $(window),
                adjust: {
                    method: 'shift'
                }

            },
            content: {
                title: "Pre-Approved Test(s)",
                text: function (api) {
                    return $(this).parent().find('.pre-approved-tests').html();
                }
            }
        });

        $('.donotcontact-infoimage').qtip({
            position: {

                viewport: $(window),
                adjust: {
                    method: 'shift'
                }

            },
            content: {
                text: function (api) {
                    return $(this).parent().find('#doNotContactDiv').html();
                }
            }
        });
        
    </script>
</asp:Content>

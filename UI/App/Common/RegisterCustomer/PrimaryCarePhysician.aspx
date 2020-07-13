<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="true" Inherits="App_Common_RegisterCustomer_PrimaryCarePhysician"
    Title="Untitled Page" CodeBehind="PrimaryCarePhysician.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/UCPCPInfo.ascx" TagName="UCPCPInfo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .main_containerbig_editp {
            float: left;
            width: 640px;
            padding: 3px 5px 3px 10px;
            margin: 0px;
        }

        .titletext_editp {
            float: left;
            width: 110px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }

        .inputfieldcus_editp {
            float: left;
            width: 150px;
            margin-right: 40px;
            padding-top: 0px;
            font: bold 12px arial;
            color: #000;
        }

        .inputf_editp {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }

        .inputfieldrightcon_editp {
            float: left;
            width: 180px;
            font: normal 12px arial;
        }

        .list_amv {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }

        .radiobuttoncon_sendmail_editp {
            float: left;
            width: 280px;
            font: normal 12px arial;
            color: #000;
        }

        .inputf_accm {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }

        .body_border_pw {
            float: left;
            width: 642px;
            background-color: #fff;
            border-top: 1px solid #B4C9E1;
            border-left: 1px solid #B4C9E1;
            border-right: 1px solid #B4C9E1;
        }

        .lineheight_pw {
            float: left;
            width: 640px;
            padding: 0px;
            margin: 0px;
        }

        .contentrow_pw {
            float: left;
            width: 627px;
            padding-left: 10px;
            padding-right: 5px;
            margin: 0px;
        }

        .titletextbold_pw {
            float: left;
            width: 125px;
            margin-right: 5px;
            padding-top: 9px;
            font: bold 12px arial;
            color: #000;
        }

        .inputfieldleftconnew_pw {
            float: left;
            width: 180px;
            padding-right: 10px;
            padding-top: 3px;
            font: normal 11px arial;
            color: #666;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function ShowdvPCP() {
            var divPcp = document.getElementById("<%= divPcp.ClientID %>");
            divPcp.style.display = "block";
        }

        function HidedvPCP() {
            var divPcp = document.getElementById("<%=divPcp.ClientID %>");
            divPcp.style.display = "none";
        }

    </script>
    <asp:HiddenField runat="server" ID="hfCountryID" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" />
                    </p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Cancel Appointments <<
                        Customer Name >></span>
                </div>
            </div>
            <div class="maindivredmsgbox" style="visibility: hidden; display: none">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innercon">
                        <span>
                            <img src="../../Images/CCRep/specer.gif" width="740px" height="5px" /></span>
                        <div class="regcust_innerrow">
                            <div class="pgnosymbol_regcust">
                                <img src="../../Images/CCRep/page5symbol.gif" id="imgSymbol" runat="server" />
                            </div>
                            <div class="middivrow_regcust">
                                <p class="orngheadtxt_regcust" style="visibility: hidden; display: none;">
                                    Register New Customer
                                </p>
                                <p class="fline_regcust" style="visibility: hidden; display: none;">
                                    <img src="../../Images/CCRep/specer.gif" width="1px" height="1px" />
                                </p>

                                <p class="contentrow_regcust">
                                    <span class="orngsmalltxt_regcust">Do You have your primary care physician information?
                                    </span><span>
                                        <asp:RadioButton ID="rbtnYes" runat="server" Text="Yes" GroupName="PCP" Checked="true" />
                                    </span><span>
                                        <asp:RadioButton ID="rbtnNo" runat="server" Text="No" GroupName="PCP" />
                                    </span>
                                </p>
                                <div id="divPcp" runat="server" style="display: none;">
                                    <div id="divExistingPcp">
                                        <p class="subheadingbg_ccrep">
                                            Find Primary Care Physician
                                        </p>
                                        <p class="lineheight_pw">
                                            <img src="/App/Images/specer.gif" height="5px" width="1px" />
                                        </p>
                                        <p class="contentrow_pw" style="font: bold 12px arial; color: #EE8111;">
                                            <span><b>(a)</b>&nbsp;&nbsp;<u>Enter</u> your Primary Care Physician's details and
					                            <u>Click</u> Search. </span>
                                        </p>
                                        <p class="lineheight_pw">
                                            <img src="/App/Images/specer.gif" height="5px" width="1px" />
                                        </p>

                                        <p class="contentrow_pw">
                                            <span class="titletextbold_pw" style="width: 80px; padding-left: 20px;">First Name:</span>
                                            <span class="inputfieldleftconnew_pw">
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputf_pw" Width="175px"></asp:TextBox>
                                            </span>
                                            <span class="titletextbold_pw" style="width: 80px; padding-left: 20px;">Last Name:</span>
                                            <span class="inputfieldleftconnew_pw">
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="inputf_pw" Width="175px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="contentrow_pw" style="margin-top: 10px;">
                                            <span class="titletextbold_pw" style="width: 80px; padding-left: 20px;">Zipcode:</span>
                                            <span class="inputfieldleftconnew_pw">
                                                <asp:TextBox ID="txtZipcode" runat="server" CssClass="inputf_pw" Width="175px" MaxLength="5"></asp:TextBox>
                                            </span>
                                            <span style="float: right; padding-right: 50px;" id="SearchButton">
                                                <input type="button" value="Search" onclick="ValidateSearch();" />
                                            </span>
                                            <span style="float: right; padding-right: 50px; display: none;" id="spnIndicator">
                                                <img src="/App/Images/indicator.gif" />
                                            </span>
                                        </p>
                                        <div class="lineheight_pw"></div>
                                        <div class="lineheight_pw"></div>
                                        <div runat="server" id="divHeading" style="display: none; visibility: hidden">
                                            <p class="contentrow_pw" style="font: bold 12px arial; color: #EE8111;">
                                                <span><b>(b)</b>&nbsp;&nbsp;<u>Select</u> your primary care physician and <u>Click</u>
                                                    Next. </span>
                                            </p>
                                        </div>
                                        <div class="lineheight_pw"></div>
                                        <div class="contentrow_pw" id="divGridPcp" style="display: none; margin-top: 10px;">
                                            <fieldset>
                                                <legend>Found Results</legend>
                                                <div id="divPcpResult">
                                                </div>
                                            </fieldset>
                                        </div>
                                        <div class="contentrow_pw" id="divNewPcpButton" style="display: none;">
                                            <span class="titletextbold_pw" style="width: 150px; text-align: left;">Not able find PCP?</span>
                                            <span class="titletextbold_pw">
                                                <input type="button" id="NewPcpButton" value="Add PCP" onclick="ShowNewPcpDiv(true);" />
                                            </span>
                                        </div>
                                        <div class="contentrow_pw" id="divVerifiedPcpInfo" style="display: none;">
                                            <input type="checkbox" id="chkVerifiedPcpInfo" runat="server" />
                                            <b>Is PCP Info Verified ? </b>
                                        </div>
                                    </div>
                                    <div class="contentrow_pw" id="divNewPCP" style="display: none; margin-top: 60px;">
                                        <p style="float: left; width: 642px; font: bold 12px arial; color: #EE8111; display: none;">
                                            <span class=""><b><span id="spNewDetails" runat="server">(c)</span></b>&nbsp;&nbsp;<u>Enter</u>
                                                information about your physician and <u>Click</u> Next. </span>
                                        </p>

                                        <p style="float: left; width: 545px;">
                                            <span style="float: left;" runat="server" id="spanpcpchange" visible="false">
                                                <asp:CheckBox ID="chkPCPChange" runat="server" Checked="false" />
                                                Have you changed primary care physician ? 
                                            </span>
                                            <span style="float: right;">
                                                <input type="button" id="SearchPcpButton" value="Search PCP" onclick="ShowNewPcpDiv(false);" />
                                            </span>
                                        </p>
                                        <uc1:UCPCPInfo ID="UCPCPInfo1" runat="server" />
                                    </div>
                                </div>
                                <div style="float: left">
                                    <span>
                                        <img src="/App/Images/CCRep/specer.gif" width="530px" height="30px" /></span>

                                    <p class="middivrow_regcust">
                                        <span class="buttoncon_ccrep" style="visibility: hidden; display: none;">
                                            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="~/App/Images/back-buton.gif"
                                                OnClick="imgBack_Click" />
                                        </span><span class="buttoncon_ccrep_pcp">
                                            <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/App/Images/finish-button.gif"
                                                OnClientClick="return Validation()" OnClick="imgSave_Click" />
                                        </span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="FirstNameHiddenField" Value="" />
    <asp:HiddenField runat="server" ID="LastNameHiddenField" Value="" />
    <asp:HiddenField runat="server" ID="ZipcodeHiddenField" Value="" />
    <asp:HiddenField runat="server" ID="PageNumberHiddenField" Value="1" />
    <input type="hidden" class="total-records" id="TotalRecordsHiddenField" runat="server" value="0" />

    <asp:HiddenField runat="server" ID="PhysicianMasterIdHiddenField" Value="0" />

    <asp:HiddenField runat="server" ID="NewPcpHiddenField" Value="False" />
    <asp:HiddenField runat="server" ID="HasPcpHiddenField" Value="False" />

    <script type="text/javascript">
        var searchedForPcp = false;
        function SearchPcp() {

            var firstName = $("#<%=FirstNameHiddenField.ClientID%>").val().trim();
            var lastName = $("#<%=LastNameHiddenField.ClientID%>").val().trim();
            var zipcode = $("#<%=ZipcodeHiddenField.ClientID%>").val().trim();
            var pageNumber = $("#<%= PageNumberHiddenField.ClientID%>").val();

            if ((firstName == "" && lastName == "") || zipcode == "") {
                return;
            }

            $("#SearchButton").hide();
            $("#spnIndicator").show();

            //Action method to search
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                dataType: "html", url: "/Medical/PrimaryCarePhysician/SearchPcp?firstName=" + firstName + "&lastName=" + lastName + "&zipcode=" + zipcode + "&pageNumber=" + pageNumber, data: '{}',
                success: function (result) {
                    $("#SearchButton").show();
                    $("#spnIndicator").hide();

                    $("#divPcpResult").html(result);
                    setTotalRecords();
                    SetButton();

                    $("#divGridPcp").show();
                    $("#divNewPcpButton").show();
                    searchedForPcp = true;
                }, error: function (a, b, c) {
                    $("#SearchButton").show();
                    $("#spnIndicator").hide();
                }
            });
        }

        function setPage(currentPage) {
            $("#<%= PageNumberHiddenField.ClientID%>").val(currentPage);
            SearchPcp();
        }

        function SetPhysicianMaster(physicianMasterId) {
            //debugger;
            $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val(physicianMasterId);
            SetButton();
        }
        function SetButton() {
            //debugger;
            var physicianMasterId = $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val();
            $("#divPcpResult .physician-master input[type=button]").css({ "background": "-moz-linear-gradient(center top , #f5f5f5, #cbcbcb) repeat scroll 0 0 transparent" });
            $("#divPcpResult .physician-master input[type=button]").attr("value", "Select");

            $("#divPcpResult .physician-master input[type=hidden][value='" + physicianMasterId + "']").parent().find("input[type=button]").css({ "background": "-moz-linear-gradient(center top , #bdb76b, #388c2c) repeat scroll 0 0 transparent" });
            $("#divPcpResult .physician-master input[type=hidden][value='" + physicianMasterId + "']").parent().find("input[type=button]").attr("value", "Selected");
            if (physicianMasterId > 0)
                $("#divVerifiedPcpInfo").show();
        }

        function ValidateSearch() {
            var firstName = $("#<%=txtFirstName.ClientID%>").val().trim();
            var lastName = $("#<%=txtLastName.ClientID%>").val().trim();
            var zipcode = $("#<%=txtZipcode.ClientID%>").val().trim();

            if ((firstName == "" && lastName == "") || zipcode == "") {
                alert("To search a PCP, please enter either first name or last name and zip code");
                return;
            }

            $("#<%= FirstNameHiddenField.ClientID%>").val(firstName);
            $("#<%= LastNameHiddenField.ClientID%>").val(lastName);
            $("#<%= ZipcodeHiddenField.ClientID%>").val(zipcode);
            $("#<%= PageNumberHiddenField.ClientID%>").val("1");

            $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val("0");

            SearchPcp();
        }

        function Validation() {
            //debugger;
            var physicianMasterIdHiddenField = $("#<%= PhysicianMasterIdHiddenField.ClientID %>").val();
            var rbtnYes = document.getElementById("<%= rbtnYes.ClientID %>");

            var totalRecords = $("#<%= TotalRecordsHiddenField.ClientID %>").val();
            if (rbtnYes.checked == true) {
                if (searchedForPcp == false && $("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.FalseString%>") {
                    alert("Please search your Primary Care Physician.");
                    return false;
                } else if (searchedForPcp == true && totalRecords == 0 && $("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.FalseString%>") {
                    alert("Please search again your Primary Care Physician or Add PCP.");
                    return false;
                } else if (searchedForPcp == true && totalRecords > 0 && physicianMasterIdHiddenField == 0 && $("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.FalseString%>") {
                    alert("Please select Primary Care Physician from list.");
                    return false;
                } else if ($("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.TrueString%>") {
                    return ValidatePCP();
                }

        if (physicianMasterIdHiddenField > 0 && (!$("input:checkbox[name$='chkVerifiedPcpInfo']").is(":checked"))) {
            return confirm("You have not verified the PCP Info. Do you want to continue?");
        }
    }
    return true;

}
    </script>

    <script type="text/javascript">
        function ShowNewPcpDiv(isNew) {
            if (isNew) {
                $("#<%= NewPcpHiddenField.ClientID%>").val("<%= Boolean.TrueString%>");
            } else {
                $("#<%= NewPcpHiddenField.ClientID%>").val("<%= Boolean.FalseString%>");
            }

            ShowHidePcpDiv();
        }

        function ShowHidePcpDiv() {
            if ($("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.TrueString%>") {
                $("#divNewPCP").show();

                $("#divPcpResult").html("");
                $("#divGridPcp").hide();
                $("#divNewPcpButton").hide();
                $("#divExistingPcp").hide();

                $("#<%= FirstNameHiddenField.ClientID%>").val("");
                $("#<%= LastNameHiddenField.ClientID%>").val("");
                $("#<%= ZipcodeHiddenField.ClientID%>").val("");
                $("#<%= PageNumberHiddenField.ClientID%>").val("1");

                $("#<%=txtFirstName.ClientID%>").val("");
                $("#<%=txtLastName.ClientID%>").val("");
                $("#<%=txtZipcode.ClientID%>").val("");

                $("#<%= PhysicianMasterIdHiddenField.ClientID%>").val("0");
                searchedForPcp = false;
            } else {

                $("#divNewPCP").hide();
                $("#divNewPcpButton").hide();
                $("#divExistingPcp").show();
            }
        }

        $(document).ready(function () {
            if ($("#<%= HasPcpHiddenField.ClientID %>").val() == "<%= Boolean.TrueString%>") {
                $("#<%= NewPcpHiddenField.ClientID%>").val("<%= Boolean.TrueString%>");
            }
            ShowHidePcpDiv();
            SearchPcp();
        });
    </script>

</asp:Content>

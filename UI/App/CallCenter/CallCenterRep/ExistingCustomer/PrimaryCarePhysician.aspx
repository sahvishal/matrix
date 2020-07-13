<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" AutoEventWireup="true" Inherits="App_CallCenter_RakeshNewCallCenterUI_RegisterCustomer_PrimaryCarePhysician" Title="Untitled Page" Codebehind="PrimaryCarePhysician.aspx.cs" %>
<%@ Register src="~/App/UCCommon/UCPCPInfo.ascx" tagname="UCPCPInfo" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .graybdrbox950_blankblock
        {
            float: left;
            width: 645px;
            text-align: center;
            background-color: #DFF1F8;
            border: solid 1px #B8D7E6;
            padding: 50px 0px 50px 5px;
        }
</style>
<script language="javascript" type="text/javascript">

    function ShowPcP() {
        var divPcp = document.getElementById("<%= divPcp.ClientID %>");
        divPcp.style.display = "block";
    }

    function HidePcp() {
        var divPcp = document.getElementById("<%=divPcp.ClientID %>");
        divPcp.style.display = "none";
    } 
</script>
      
<asp:HiddenField runat="server" ID="hfCountryID" />

<div class="wrapcrep_inpg">
    <div class="bluheader" style="visibility:hidden">
    <div id="dvTitle" runat="server">
        Call Centre Rep Dashboard</div>
	</div>
	<div class="contnr_bdr">
		<div class="pgnosymbol_regcust">
			<img src="/App/Images/CCRep/page6symbol-copy.gif" alt="" />
		</div>
	    <div class="middivrow_regcust">
		    <p class="orngheadtxt_regcust" id="_pCustomerType" runat="server">
			    Existing Customer</p>
		    <div class="fline_regcust">
		    </div>
		    <p class="contentrow_regcust">
			    <span class="orngsmalltxt_regcust">
				    Do You have your primary care physician information?
			    </span>
			    <span>
				    <asp:RadioButton ID="rbtnYes" runat="server" Text="Yes" GroupName="PCP" Checked="true" />
			    </span>
			    <span>
				    <asp:RadioButton ID="rbtnNo" runat="server" Text="No" GroupName="PCP"  />
			    </span>
		    </p>
		    <div id="divPcp" runat="server" style="display: none;">
		        <div id="divExistingPcp">
			        <p class="subheadingbg_ccrep">
				        Find Primary Care Physician</p>
			        <div class="lineheight_pw"></div>
			        <p class="contentrow_pw" style="font: bold 12px arial; color: #EE8111;">
				        <span><b>(a)</b>&nbsp;&nbsp;<u>Enter</u> your Primary Care Physician's details and
					        <u>Click</u> Search. </span>
			        </p>
			        <p class="lineheight_pw">
				        <img src="/App/Images/specer.gif" height="5px" width="1px" /></p>
			        
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
                            <input type="button" value="Search" onclick="ValidateSearch();"/>
                        </span>
                        <span style="float: right; padding-right: 50px; display: none;" id="spnIndicator">
                            <img src="/App/Images/indicator.gif" />
                        </span>
                    </p>
			        <div class="lineheight_pw"></div>
			        <div class="lineheight_pw"></div>
			        <div id="divHeading" style="display: none;">
				        <p class="contentrow_pw" style="font: bold 12px arial; color: #EE8111;">
					        <span><b>(b)</b>&nbsp;&nbsp;<u>Select</u> your primary care physician and <u>Click</u> Next. </span>
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
                            <input type="button" id="NewPcpButton" value="Add PCP" onclick="ShowNewPcpDiv(true);"/>
                        </span>                        
                    </div>     
                     <div class="contentrow_pw" id="divVerifiedPcpInfo" style="display:none;">                           
                            <input type="checkbox" id="chkVerifiedPcpInfo" runat="server"/>
                            <b>Is PCP Info Verified ? </b>                           
                      </div>             
                </div>
			    <div class="contentrow_pw" id="divNewPCP" style="display: none; margin-top: 60px;">
				    <p style="float: left; width: 642px; font: bold 12px arial; color: #EE8111; display: none;">
					    <span class=""><b><span id="spNewDetails" runat="server">(c)</span></b>&nbsp;&nbsp;<u>Enter</u> information about your physician and <u>Click</u>
						    Next. </span>
				    </p>
                    <p style="float: left; width: 545px;">
                        <span style="float:left;" runat="server" id="spanpcpchange" visible="false">
                            <asp:CheckBox ID="chkPCPChange" runat="server" Checked="false"  />   Have you changed primary care physician ? 
                        </span>
                        <span style="float: right;">
                            <input type="button" id="SearchPcpButton" value="Search PCP" onclick="ShowNewPcpDiv(false);"/>
                        </span>
                    </p>
				     <uc1:UCPCPInfo ID="UCPCPInfo1" runat="server" />
			    </div>
		    </div>
		    <div style="float:left">
		        <div class="fline_regcust" style="margin-top:30px">
		        </div>
		        <p class="middivrow_regcust">		    
			        <span class="buttoncon_ccrep" style="visibility:hidden; display:none;">
				        <asp:ImageButton ID="imgBack" runat="server" ImageUrl="~/App/Images/back-buton.gif" OnClick="imgBack_Click" /></span>
			        <span class="buttoncon_ccrep" style="float: right;">
				        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/App/Images/finish-button.gif" OnClientClick="return Validation()" OnClick="imgSave_Click" /></span>
		        </p>
		    </div>
	    </div>
    
	    <div class="rightdivrow_regcust" id="divCall" runat="server">
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
</div>

  
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    
    <asp:HiddenField runat="server" ID="FirstNameHiddenField" Value="" />
    <asp:HiddenField runat="server" ID="LastNameHiddenField" Value="" />
    <asp:HiddenField runat="server" ID="ZipcodeHiddenField" Value="" />
    <asp:HiddenField runat="server" ID="PageNumberHiddenField" Value="1" /> 
    <input type="hidden" class="total-records" id="TotalRecordsHiddenField" runat="server" value="0"/>

    <asp:HiddenField runat="server" ID="PhysicianMasterIdHiddenField" Value="0" />
    
    <asp:HiddenField runat="server" ID="NewPcpHiddenField" Value="False"/>
    <asp:HiddenField runat="server" ID="HasPcpHiddenField" Value="False"/>


    <script type="text/javascript" language="javascript">
     //// this will run after page is load
        var hfCallStartTime= document.getElementById("<%= hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>
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
                }, error: function(a, b, c) {
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
            if (physicianMasterId>0)
               $("#divVerifiedPcpInfo").show();
        }

        function ValidateSearch() {
            //debugger;
            var firstName = $("#<%=txtFirstName.ClientID%>").val().trim();
            var lastName = $("#<%=txtLastName.ClientID%>").val().trim();
            var zipcode = $("#<%=txtZipcode.ClientID%>").val().trim();
            
            if ((firstName == "" && lastName == "")  || zipcode == "") {
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
                }
                else if (searchedForPcp == true && totalRecords == 0 && $("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.FalseString%>") {
                    alert("Please search again your Primary Care Physician or Add PCP.");
                    return false;
                }
                else if (searchedForPcp == true && totalRecords > 0 && physicianMasterIdHiddenField == 0 && $("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.FalseString%>") {
                    alert("Please select Primary Care Physician from list.");
                    return false;
                }
                else if ($("#<%= NewPcpHiddenField.ClientID%>").val() == "<%= Boolean.TrueString%>") {
                    return ValidatePCP();
                }
                
                if (physicianMasterIdHiddenField > 0 && (!$("input:checkbox[name$='chkVerifiedPcpInfo']").is(":checked")))
                {
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

            checkAndOpenScriptPopup();
        });
    </script>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-957361-18', 'auto');
        ga('send', 'pageview');

        
    </script>
</asp:Content>
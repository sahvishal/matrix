<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
	Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.RequestReport.SendReportStep2" CodeBehind="SendReportStep2.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="~/App/UCCommon/UcShippingDetails.ascx" TagPrefix="uc" TagName="ShippingOption" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<JQueryControl:JQueryToolkit ID="JQueryToolkit" runat="server" IncudeJQueryJTip="true" />
    <style type="text/css">
        .eventgrid{border:none;border-collapse:collapse;width:100%}
        .eventgrid td{border:none;padding:4px 4px 4px 4px;border-bottom:solid 1px #D0D9E0}
        .eventgrid .smalltxt11{background:#EFF8FD;font:normal 12px arial;color:#333;vertical-align:top}
        .eventgrid .smalltxt12{background:#F8FCFF;font:normal 12px arial;color:#333;vertical-align:top}
    </style>
	<script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $('.jTip').cluetip({splitTitle: '|',cursor: 'pointer',tracking: true,cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false});
        });

	</script>

	<script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>

	<script language="javascript" type="text/javascript">
     
 
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

    function SelectedEvent(selectedRadio)
    {
        selectedRadio= document.getElementById(selectedRadio.id);
        selectedRadio.checked=false;

        alert("There is already a unprocessed shipping request in your order. Duplicate shipping cannot be added till this shipping request is processed.");
        return false;
    }

    function ShowRefundRequestShippingMessage(selectedRadio) {
        selectedRadio = document.getElementById(selectedRadio.id);
        selectedRadio.checked = false;

        alert("Customer has already requested for the removal of shipping for this event, the removal request is in process. Re-purchase of shipping is not allowed unless the request is resolved. Please contact your admin.");
        return false;
    }

    function SelectedEventDetail(selectedRadio, shippingOptionId) {        
        var rowcount = 0;
        var grdControl = document.getElementById("<%= dgeventhistory.ClientID %>");
        selectedRadio = document.getElementById(selectedRadio.id);

        var spEventName = document.getElementById("<%= spEventName.ClientID %>");
        var spEventDate = document.getElementById("<%= spEventDate.ClientID %>");
        var spHostName = document.getElementById("<%= spHostName.ClientID %>");
        var spHostVenue = document.getElementById("<%= spHostVenue.ClientID %>");

        var hfEventcustomerId = document.getElementById("<%= hfEventcustomerID.ClientID %>");
        var hfEventId = document.getElementById("<%= hfEventID.ClientID %>");

        while (rowcount < grdControl.rows.length) {
            if (grdControl.rows[rowcount].cells[0] != null && ($(grdControl.rows[rowcount]).hasClass("event-shpping-row") || $(grdControl.rows[rowcount]).hasClass("event-shpping-row"))) {
                var radio = document.getElementById(grdControl.rows[rowcount].cells[0].getElementsByTagName("INPUT")[0].id);
                var cell = grdControl.rows[rowcount].cells[0].getElementsByTagName("SPAN");

                if ((radio != null) && (radio.id != selectedRadio.id)) {
                    radio.checked = false;
                }
                else {
                    selectedRadio.checked = true;
                    hfEventcustomerId.value = cell[0].innerHTML;
                    spEventName.innerHTML = cell[1].innerHTML;
                    spHostName.innerHTML = cell[1].innerHTML;
                    spHostVenue.innerHTML = cell[2].innerHTML;
                    hfEventId.value = cell[3].innerHTML;
                    spEventDate.innerHTML = cell[4].innerHTML;
                    
                }
            }
            rowcount = rowcount + 1;
        }
        //var divEventDetail = document.getElementById("DivEventDetail");
        //divEventDetail.style.display = "block";
     
        $.ajax({
            type: "GET",
            dataType: "json", url: "/Operations/Shipping/GetShippingOptionForEvent?eventId=" + hfEventId.value, data: "{}",
            success: function (result) {
                
                if (result.IsHospitalPartnerEvent == true && result.AllShippingOptions != null && result.AllShippingOptions.length == 1) {
                    $('.main-shipping-table').find(".main-shipping-table-row").hide();

                    if (shippingOptionId == null)
                        shippingOptionId = result.AllShippingOptions[0].ShippingOptionId;

                    $('.main-shipping-table').find(".main-shipping-table-row input:radio[id='rbtn" + shippingOptionId + "']").closest("tr").show();

                    $('.main-shipping-table').find(".main-shipping-table-row input:radio[id='rbtn" + shippingOptionId + "']").attr('checked', true);
                    $('.main-shipping-table').find(".main-shipping-table-row input:radio[id='rbtn" + shippingOptionId + "']").click();
                } else {
                    
                    $('.main-shipping-table').find(".main-shipping-table-row").show();
                    
                    if (shippingOptionId == null){
                        $('.main-shipping-table').find('.main-shipping-table-row input:radio:first').attr('checked', true);
                        $('.main-shipping-table').find('.main-shipping-table-row input:radio:first').click();
                    }
                    else {
                        $('.main-shipping-table').find(".main-shipping-table-row input:radio[id='rbtn" + shippingOptionId + "']").attr('checked', true);
                        $('.main-shipping-table').find(".main-shipping-table-row input:radio[id='rbtn" + shippingOptionId + "']").click();
                    }
                    
                }

                var divEventDetail = document.getElementById("DivEventDetail");
                divEventDetail.style.display = "block";

            }, error: function (a, b, c) {
                //alert("Some error occured while processing your request. Please try again");
            }
        });


        return true;
    }

	function selectEvent(radioButtonClientId) {	       
        SelectedEventDetail(document.getElementById(radioButtonClientId), null);
	}

	function selectEventWithShipping(radioButtonClientId, shippingOptionId) {	    
	    SelectedEventDetail(document.getElementById(radioButtonClientId), shippingOptionId);
	}

    function Validation() {
        //debugger
        var hfEventcustomerId = document.getElementById("<%=hfEventcustomerID.ClientID %>");
        var hfEventId = document.getElementById("<%= hfEventID.ClientID %>");

        if ((hfEventId.value == "") || (hfEventcustomerId.value == "")) {
            alert("Please select an Event");
            return false;
        }
        if (!ValidateShippingAddress())
            return false;
        return true;
    }
     
    function selectResultOrder(resultOrderId)
    {            
        var hfResultOrderId = document.getElementById("<%= this.hfResultOrderID.ClientID %>"); 
        var hfResultOrderPrice = document.getElementById("<%= this.hfResultOrderPrice.ClientID %>");
        var hfResultOrderDesc= document.getElementById("<%= this.hfResultOrderDesc.ClientID %>");
        
        var selectedOrderRadio =document.getElementById("rbtn" + resultOrderId);
        if(selectedOrderRadio.checked==true)
        {
            var spSalePrice=document.getElementById("spSalePrice" + resultOrderId);
            var spTitle=document.getElementById("spTitle" + resultOrderId);
            hfResultOrderId.value=resultOrderId;
            hfResultOrderPrice.value=spSalePrice.innerHTML;
            hfResultOrderDesc.value=spTitle.innerHTML;
        }
        
        return true; 
    }


    function FirstTimeLoad(resultOrderId)
    {        
        var selectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
        selectedOrderRadio.checked=true;
        selectResultOrder(resultOrderId);
    }
	</script>

	
		<div class="wrapper_inpg">			
			<div class="maindivredmsgbox" style="visibility: hidden; display: none">
			</div>
			<div class="main_bdrccrep1">
				<div class="maincontentrow_ccrep">
					<div class="regcust_innercon">						
						<div class="regcust_innerrow">
							<div class="pgnosymbol_regcust">
								<img src="/App/Images/CCRep/page4symbol.gif" alt="" />
							</div>
							<div class="middivrow_regcust">
								<p class="orngheadtxt_regcust">
									Request Report</p>
								<div class="fline_regcust"></div>
								<p class="normaltxt_regcust">
								</p>
								<p class="subheadingbg_ccrep">
									Customer Information</p>
								<p class="middivrow_regcust">
									<span class="titletxtbld_regcust">Customer Name:</span> <span class="inputconleft_regcust"
										id="spnCustomerName" runat="server">CustomerEvent2</span> <span class="titletxtbld_regcust"
											style="width: 70px">Email:</span> <span class="inputconright_regcust" id="spnEmail"
												runat="server">yashird@healthyes.com</span>
								</p>
								<p class="middivrow_regcust">
									<span class="titletxtbld_regcust">Address:</span>
									<span class="left" id="spnAddress" runat="server">
									</span>
								</p>
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
								<div class="endcall_ccrep_dboard" style="margin-top:2px">
									<span class="endtbtn_ccrep_dboard">
										<asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
											OnClientClick="closeScriptPopup(); CallNotes();return false;" />
									</span>
								</div>
							</div>
						</div>
                        <div class="fline_regcust"></div>
						<div class="regcust_innerrow">						
							<p class="maincontentrow_re">								
                                <span class="blueheadtxt_regcust" id="dvSearchResult" runat="server"></span>
							</p>
							<div class="dgeventhistory_ccrep" id="dbsearch" runat="server" style="display: none"
								visible="false">
								<asp:GridView ID="dgeventhistory" runat="server" CssClass="eventgrid" AutoGenerateColumns="false"
									GridLines="None" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgeventhistory_PageIndexChanging"
									OnRowDataBound="dgeventhistory_RowDataBound" ShowHeader="false">
									<Columns>
                                        <asp:TemplateField>
											<ItemTemplate>
												<asp:RadioButton ID="rbtEventCustomerID" AutoPostBack="false" GroupName="EventCustomer"
													runat="server" />
												<asp:Label Style="visibility: hidden; display: none" runat="server" ID="spEventCustomerID"
													Text='<%# DataBinder.Eval(Container.DataItem, "EventcustomerID")%>' />
												<asp:Label Style="visibility: hidden; display: none" runat="server" ID="spHostName"
													Text='<%# DataBinder.Eval(Container.DataItem, "HostName")%>' />
												<asp:Label Style="visibility: hidden; display: none" runat="server" ID="spHostAddress"
													Text='<%# DataBinder.Eval(Container.DataItem, "HostAddress")%>' />
                                                <asp:Label Style="visibility: hidden; display: none" runat="server" ID="spEventId"
													Text='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                                <asp:Label Style="visibility: hidden; display: none" runat="server" ID="spEventDate"
													Text='<%# DataBinder.Eval(Container.DataItem, "Date")%>' />
											</ItemTemplate>
										</asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <span>Event (<%# Eval("Id")%>) on <%# Eval("Date")%> @ <%# Eval("AppTime")%> with package "<%# Eval("Package")%>"</span>
                                            </ItemTemplate>
                                        </asp:TemplateField>										
									</Columns>
									<RowStyle CssClass="smalltxt11 event-shpping-row" />
									<AlternatingRowStyle CssClass="smalltxt12 event-shpping-row" />
								</asp:GridView>
							</div>
							<div class="regcust_innercon">
								<div class="pgnosymbol_regcust">
									<img src="/App/Images/CCRep/specer.gif" width="1px" height="300px" />
								</div>
								<div style="margin-top:20px;">							
								    <div class="middivrow_regcust" id="DivEventDetail" style="display:none;">
									    <p class="subheadingbg_ccrep">
										    Event Details</p>
									    <p class="middivrow_regcust">
										    <span class="titletxt_regcust">Event Name:</span> <span class="inputconleft_regcust"
											    id="spEventName" runat="server"></span><span class="titletxt_regcust">Event Date:</span>
										    <span class="inputconright_regcust" id="spEventDate" runat="server"></span>
									    </p>
									    <p class="middivrow_regcust">
										    <span class="titletxt_regcust">Host Name:</span> <span class="inputconleft_regcust"
											    id="spHostName" runat="server"></span><span class="titletxt_regcust">Host Venue:</span>
										    <span class="inputconright_regcust" id="spHostVenue" runat="server"></span>
									    </p>
									    <p class="middivrow_regcust">
										    <span style="display: none" id="spEventCustomerid" runat="server"></span><span style="display: none"
											    id="spEventid" runat="server"></span>
										    <asp:HiddenField ID="hfEventcustomerID" runat="server" />
										    <asp:HiddenField ID="hfEventID" runat="server" />
									    </p>								
									    <div class="middivrow_regcust">
										    <p class="contentrow_regcust" style="display: none;">
											    <span class="bluesmalltxt_regcust">Do you want your screening report to be sent to you via mail</span> 
											    <span class="radiatxtbox_pw">
											        <asp:RadioButton ID="rbtReportMailY" Checked="true" runat="server" GroupName="ReportMail" AutoPostBack="false" />YES 
											    </span>
											    <span class="radiatxtbox_pw">
											        <asp:RadioButton ID="rbtReportMailN" runat="server" GroupName="ReportMail" AutoPostBack="false" />NO
										        </span>
										    </p>
										    <div class="dgselectpackage_ccrep">
											    <uc:ShippingOption ID="ShippingOtion" runat="server" />
										    </div>
									    </div>
									    <div class="fline_regcust"></div>
								    </div>
								    <div class="middivrow_regcust">
									    <p class="buttoncell_ccrep">
										    <span class="buttoncon_ccrep">
											    <asp:ImageButton ID="imgBack" runat="server" ImageUrl="~/App/Images/back-buton.gif" OnClick="imgBack_Click" />
										    </span> 
										    <span class="buttoncon_ccrep">
										        <asp:ImageButton ID="imgNext" runat="server" ImageUrl="~/App/Images/next-buton.gif" OnClick="imgNext_Click" OnClientClick="return Validation();" />
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
	<asp:HiddenField runat="server" ID="hfCallStartTime" />
	<asp:HiddenField runat="server" ID="hfResultOrderID" Value="0" />
	<asp:HiddenField runat="server" ID="hfResultOrderPrice" Value="" />
	<asp:HiddenField runat="server" ID="hfResultOrderDesc" />

	<script language="javascript">
     //// this will run after page is load
      var hfCallStartTime= document.getElementById("<%= this.hfCallStartTime.ClientID %>");
	    StartTimer(hfCallStartTime);

	    $(document).ready(function () {
	        checkAndOpenScriptPopup();
	    });
	</script>

</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcEventRegistrationSummary.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.UcEventRegistrationSummary" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" IncludeJQueryThickBox="true" IncudeJQueryJTip="true"
    IncludeJQueryCorner="true" />

<link href="/Content/colorbox/colorbox.css" rel="stylesheet" />

<script type="text/javascript" src="/App/JavascriptFiles/HraQuestionnaire.js?q=<%=VersionNumber %>"></script>
<script type="text/javascript" src="/Content/colorbox/jquery.colorbox.js"></script>

<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('#divnotes').dialog({ width: 700, autoOpen: false, resizable: true, draggable: true, modal: true });
        $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });

        $('#<%=UserNameTextBox.ClientID %>').bind("keyup", function (evt) { keyUp_userName(evt); });
    });
    function ShowDialog() {
        $('#divnotes').dialog('open');
    }
</script>

<script type="text/javascript" language="javascript">
    function addColorBoxWrapper(url, name, tag, token, evtId, eventCustId, custId, visitId) {
        checkSession().then(function() {
            if ($("#hravisitId_" + eventCustId).val() != "") {
                visitId = $("#hravisitId_" + eventCustId).val();
            }
            initiateHraQuestionare(url, name, tag, token, evtId, true, true);
            addColorBoxCustomerHistory(eventCustId, custId, visitId);
            //stop colorbox scroll
            $(document).bind('cbox_open', function () {
                $('body').css({ overflow: 'hidden' });
            }).bind('cbox_closed', function () {
                $('body').css({ overflow: '' });
            });

            $('#hraLink_' + eventCustId).click();
        }, function (data) {
            alert(data);
            window.location.replace("/login");
        });
    }
   

</script>

<div>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normaltxt_addnotes">Customer Name: <b><span class="bluebold_addnotes"
            runat="server" id="_spFullName"></span></b></span>
    </p>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normallefttxt_addnotes">Customer Id:</span>
        <span class="normalrighttxt_addnotes" id="_spCustomerId" runat="server"></span>
    </p>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normallefttxt_addnotes">Aces Id:</span>
        <span class="normalrighttxt_addnotes" id="_spAcesId" runat="server"></span>
    </p>
    <p>
        <img src="/App/Images/CCRep/specer.gif" width="400px" height="1px" />
    </p>
    <p class="contentrow_regcust">
        <span id="_spEventDetail" class="orng12pxtxt_addnotes">Event Details:</span>
    </p>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normallefttxt_addnotes">Event Id:</span>
        <span class="normalrighttxt_addnotes" id="_spEventId" runat="server"></span>
    </p>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normallefttxt_addnotes">When:</span>    <span class="normalrighttxt_addnotes"
            runat="server" id="_spWhen">[]</span>
    </p>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normallefttxt_addnotes">Where:</span> <span class="normalrighttxt_addnotes"
            runat="server" id="_spVenue">[]</span>
    </p>
    <div id="dvLoginDetails" runat="server">
        <p class="contentrow_regcust">
            <span class="orng12pxtxt_addnotes">Login Details:</span>
        </p>
        <p class="wcomemsgboxrow_addnotes">
            <span class="normallefttxt_addnotes">User name:</span>
            <span class="normalrighttxt_addnotes">
                <span id="_spUserName" runat="server"></span>
                <a href="javascript:void(0);" onclick="ShowChangeUserName();">Change UserName</a>
            </span>
            <span class="normallefttxt_addnotes"></span>
            <span class="normalrighttxt_addnotes" id="ChangeUserNameSpan" style="display: none;">
                <span style="float: left;">
                    <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
                    <asp:Button ID="UpdateUserNameButton" runat="server" Text="Update" OnClick="UpdateUserNameButton_Click" />
                </span>
                <span style="float: left; padding-left: 5px; padding-top: 2px; font-style: italic;">
                    <span id="spCheckAvailable" style="float: left; width: 215px; padding: 7px 2px 0px 0px; display: none; font-size: 11px;">
                        <img id="img1" src="/App/Images/check_available.gif" alt="Username available" />Checking for username availability... 
                    </span>
                    <span id="spMinChar" style="float: left; width: 215px; padding: 4px 2px 0px 0px; font-size: 11px; color: Red; display: none;">
                        <img id="img2" src="/App/Images/not-available.gif" alt="Minimum of 6 characters required" />Minimum of 6 characters required! 
                    </span>
                    <span id="spNotAvailable" style="float: left; width: 215px; padding: 4px 2px 0px 0px; font-size: 11px; color: Red; display: none;">
                        <img id="imgNotAvailable" src="/App/Images/not-available.gif" alt="Username not available" />Not Available! 
                    </span>
                    <span id="spAvailable" style="float: left; width: 215px; padding: 4px 0px 0px 0px; display: none; font-size: 11px; color: Green">
                        <img id="imgAvailable" runat="server" src="/App/Images/available.gif" alt="Username available" />Available!
                    </span>
                </span>
            </span>
        </p>
        <p class="wcomemsgboxrow_addnotes" style="display:none;">
            <span class="normallefttxt_addnotes">Password:</span>
            <span class="normalrighttxt_addnotes" id="_spPassword" runat="server"></span>
        </p>
    </div>
    <p class="wcomemsgboxrow_addnotes"><span class="orngbold12_default">Order Detail </span></p>
    <div class="wcomemsgboxrow_addnotes" id="_dvPackageMain" runat="server">
        <div class="normallefttxt_addnotes">Screening Package:</div>
        <div class="normalrighttxt_addnotes">
            <span runat="server" id="_spPackageName" class="graybold12_default"></span>
            <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px" runat="server" id="_spTestNames">
            </ul>
        </div>
    </div>
    <div class="wcomemsgboxrow_addnotes" id="_dvAdditionalTestMain" runat="server">
        <div class="normallefttxt_addnotes" id="_dvAdditionalTest" runat="server">Additional Test(s):</div>
        <div class="normalrighttxt_addnotes">
            <ul runat="server" id="_spAdditionalTestNames" style="margin: 0 0 0 15px; padding: 0 0 0 10px" class="graybold12_default">
            </ul>
        </div>
    </div>
    <div class="wcomemsgboxrow_addnotes" id="ProductDiv" runat="server">
        <span class="normallefttxt_addnotes">Product:</span>
        <span class="normalrighttxt_addnotes" runat="server" id="ProductSpan"></span>
    </div>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normallefttxt_addnotes">Shipping Option:</span> <span class="normalrighttxt_addnotes"
            runat="server" id="_spShippingOption"></span>
    </p>
    <p class="wcomemsgboxrow_addnotes">
        <span class="normallefttxt_addnotes">Order Value:</span>
        <span class="normalrighttxt_addnotes"><span runat="server" id="_spPrice">$ </span>[<span style="font: bold 12px arial; color: #F37C00" runat="server" id="_spPaymentStatus"></span>]</span>
    </p>

    <p class="wcomemsgboxrow_addnotes" runat="server" id="_spCCRepNotes">
        <span class="normallefttxt_addnotes">Notes:</span> <a href="#" onclick="ShowDialog();">View... </a>
    </p>
    <p class="wcomemsgboxrow_addnotes" runat="server" id="customerHaf">
        <span class="normallefttxt_addnotes" >HAF Status:</span> <span id="hafStatusText" runat="server"></span> (<a href="javascript:void(0);" onclick="ShowHafDialog()" id="hafStatubtn" runat="server"></a>) 
    </p>
    <% if (!string.IsNullOrEmpty(HraQuestionerAppUrl) && IsEawvPurchased)
              { %>
       <p class="wcomemsgboxrow_addnotes">
            <span class="normallefttxt_addnotes" >HRA Questionaire:</span> <a href="javascript:void(0);" onclick="addColorBoxWrapper('<%=HraQuestionerAppUrl%>', '<%=OrganizationNameForHraQuestioner%>', 
                '<%=CorporateAccountTag%>', '<%=HttpUtility.UrlEncode(HraToken)%>', '<%=EventId %>','0', <%=CustomerId %>, '<%=AwvVisitId %>')">Fill</a>
           <a id="hraLink_0" style="display: none;"></a>
            <input type="hidden" id="hravisitId_0" value="" />  
       </p>
        <% } %>
           
    <% if (!string.IsNullOrWhiteSpace(ChatQuestionerAppUrl)) {%>
       <p class="wcomemsgboxrow_addnotes">
            <span class="normallefttxt_addnotes" >CHAT Questionaire:</span> <a href='<%=ChatQuestionerAppUrl %>' target="_blank" >CHAT</a>
       </p>
    <%} %>
    <div id="PcpDetailDiv" runat="server">
        <div class="wcomemsgboxrow_addnotes"><span class="orngbold12_default">PCP Detail </span></div>
        <div class="wcomemsgboxrow_addnotes">
            <div class="normallefttxt_addnotes">Name:</div>
            <div class="normalrighttxt_addnotes" id="PcpNameDiv" runat="server"></div>
        </div>
        <div class="wcomemsgboxrow_addnotes">
            <div class="normallefttxt_addnotes">Address:</div>
            <div class="normalrighttxt_addnotes" id="PcpAddressDiv" runat="server"></div>
        </div>
        <div class="wcomemsgboxrow_addnotes">
            <div class="normallefttxt_addnotes">Email:</div>
            <div class="normalrighttxt_addnotes" id="PcpEmailDiv" runat="server"></div>
        </div>
        <div class="wcomemsgboxrow_addnotes">
            <div class="normallefttxt_addnotes">Phone:</div>
            <div class="normalrighttxt_addnotes" id="PcpPhoneDiv" runat="server"></div>
        </div>
        <div class="wcomemsgboxrow_addnotes">
            <div class="normallefttxt_addnotes">Fax:</div>
            <div class="normalrighttxt_addnotes" id="PcpFaxDiv" runat="server"></div>
        </div>
    </div>
    
    <div style="float: left; width: 690px; display: none; overflow: hidden" id="divnotes" title="Notes">
        <asp:TextBox ID="_txtCallCenterNotes" TextMode="MultiLine" Rows="27" ReadOnly="true"
            runat="server" Width="684px" CssClass="inputf_def" Text="abcdefghi"></asp:TextBox>
    </div>
   
</div>
<input type="hidden" id="hfUserID" runat="server" />
<script type="text/javascript" language="javascript">
    function ShowChangeUserName() {
        $('#ChangeUserNameSpan').show();
    }

    function CheckForBlank() {
        var txtRegUserName = document.getElementById("<%=UserNameTextBox.ClientID %>");
        if (isBlank(txtRegUserName, "User name")) {
            return false;
        }
        return true;
    }

    function keyUp_userName(evt) {
        if (document.getElementById("<%=UserNameTextBox.ClientID %>").value.length > 5) {
            $('#spMinChar').hide();
            $('#spNotAvailable').hide();
            $('#spAvailable').hide();
            $('#spCheckAvailable').show();
            CheckUserNameAvailability();

        }
        else {
            $('#spMinChar').show();
            $('#spNotAvailable').hide();
            $('#spAvailable').hide();
            $('#spCheckAvailable').hide();
        }
        return true;
    }

    function OnComplete(arg) {
        $('#spCheckAvailable').hide();
        if (arg.d == true) {
            $('#spAvailable').show();
            $('#spNotAvailable').hide();
        }
        else {
            $('#spNotAvailable').show();
            $('#spAvailable').hide();
        }
    }

    function CheckUserNameAvailability() {
        var txtRegUserName = document.getElementById("<%=UserNameTextBox.ClientID %>");
        var hfUserID = document.getElementById("<%=hfUserID.ClientID %>");
        if (isBlank(txtRegUserName, "User name")) {
            return false;
        }


        var parameter = "{'userName' : '" + txtRegUserName.value + "', 'userId' : '" + hfUserID.value + "'}";

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/App/AutoCompleteService.asmx/CheckUserNameAvailability",
            data: parameter,
            success: OnComplete,
            error: function (a, b, c) {
                alert("Error occurred while checking username availibility!");
            }

        });
        return (true);
    }
</script>
<script type="text/javascript">
    
    function ShowHafDialog() {
        var customerId = '<%=CustomerId %>';
        var eventId = '<%=EventId %>';
        winmedicalhistory = window.open("/App/Common/MedicalHistory.aspx?ReloadParent=false&ReturnPage=addnotes&Edit=true&CustomerID=" + customerId + "&EventId=" + eventId, "MedicalHistory", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=1000,height=500");
        return false;
    }

    function reloadWindow() {
        location.reload();
    }
</script>

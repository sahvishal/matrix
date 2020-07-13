<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/CallCenterMaster.master"
    Inherits="App_CallCenter_CallCenterRepDashboard" CodeBehind="CallCenterRepDashboard.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Application.Impl" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .datepanelmain {
            width: 955px !important;
        }

        .welcometextbg {
            width: 375px;
        }

            .welcometextbg div {
                height: 52px;
            }

        .topintercontainer {
            height: 138px;
        }

        h1 {
            font: bold 20px arial;
            margin: 0px;
            padding: 0px;
            color: #F47E1C;
        }

        h2 {
            font: bold 16px arial;
            margin: 0px;
            padding: 0px;
            color: #F47E1C;
        }

        h3 {
            font: bold 15px arial;
            margin: 0px;
            padding: 0px;
            color: #F47E1C;
        }

        h4 {
            font: bold 13px arial;
            margin: 0px;
            padding: 5px 0;
            color: #000;
        }

        fieldset {
            border: 1px solid #e5e5e5;
            margin: 0;
            padding: 0;
            width: 126%;
        }

        legend {
            margin: 0;
            padding: 0;
            color: #F37C00;
            font: bold 16px arial;
        }

        .graybdrbox950_stext {
            float: left;
            width: 740px;
            border: solid 1px #E4E4E4;
            padding: 2px 0px 4px 5px;
        }

        .graybdrbox950_blankblock {
            float: left;
            width: 720px;
            text-align: center;
            background-color: #DFF1F8;
            border: solid 1px #B8D7E6;
            padding: 70px 0px 90px 5px;
        }

        .graybdrbox950_row {
            float: left;
            width: 717px;
            padding-top: 3px;
        }

        .graylineinbdrbox {
            float: left;
            width: 717px;
            background-color: #dddddd;
        }

        .graybdrbox937_blankblock {
            float: left;
            width: 937px;
            text-align: center;
            background-color: #DFF1F8;
            border: solid 1px #B8D7E6;
            padding: 70px 0px 90px 5px;
        }

        .span_ccrep_norecordfound {
            font-weight: bold;
            font-size: 15px;
            color: #4490B2;
        }

        .phonerecordbox_ccrep {
            float: left;
            width: 570px;
            margin-top: 5px;
            background: #f3f3f3;
            border: solid 1px #ebebeb;
        }

        .phonerecordboxrownew_ccrep {
            float: left;
            width: 555px;
            padding: 12px 10px;
        }

        .phonerecordboxrow_ccrep {
            float: left;
            width: 555px;
            padding-left: 15px;
        }

        .inputf_pbox_ccrep {
            border: 1px solid #333;
            background: #fff;
            z-index: -5;
            font: normal 12px arial;
            color: #333;
            padding: 3px;
        }
        /* CCREP DASHBOARD */
        .titletextwidth_ccrep {
            float: left;
            width: 136px;
            margin-right: 4px;
            padding-top: 3px;
            color: #000;
        }

        body, html {
            font: normal 12px arial, helvetica, tahoma;
            background: #e5ecf3;
            margin: 0;
            color: #000;
            line-height: 1.5em;
            height: 101%;
        }

        .startbtn_ccrep_dboard {
            width: 152px !important;
        }
    </style>

    <JQueryControl:JQueryToolkit ID="JQueryToolkit" runat="server" />
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <%
        var userSession = IoC.Resolve<ISessionContext>().UserSession;
        var setting = IoC.Resolve<ISettings>();
        var moduleUrl = setting.AngularAppUrl + userSession.CurrentOrganizationRole.RoleAlias;
    %>
    <script type="text/javascript" language="javascript">
        function CheckOutBoundCall() { }
        <%--var c = 0;
        var t;
        var pageNumber = 1;

        function FillGrid() {
            //debugger;
            document.getElementById('divloading').style.visibility = "visible";
            document.getElementById('divloading').style.display = "block";

            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                dataType: "html", url: "/CallCenter/CallQueue/OutboundCallQueue?callQueueId=" + $("#<%=CallQueues.ClientID%>").val() + "&pageNumber=" + pageNumber, data: '{}',
                success: function (result) {
                    $("#divMainGridTest").html(result);
                    document.getElementById('divloading').style.visibility = "hidden";
                    document.getElementById('divloading').style.display = "none";
                    setTotalRecords();
                }, error: function (a, b, c) {
                    if (a.status == 401) {
                        alert("You do not have the permission.");
                    }
                    document.getElementById('divloading').style.visibility = "hidden";
                    document.getElementById('divloading').style.display = "none";
                }
            });--%>

        //var hidRefereshTime = document.getElementById("<%= hidRefereshTime.ClientID %>");
        //var Milisecond = (hidRefereshTime.value) * (60000);
        //Milisecond =5000;
        //t = setTimeout("FillGrid()", Milisecond);

        <%--        return false;
        }

        function StartCallClick() {
            var hfCallStartTime = document.getElementById("<%= hfCallStartTime.ClientID %>");

            present = new Date();
            hfCallStartTime.value = present.toDateString() + " " + present.toLocaleTimeString();

            var chkOutBoundCall = document.getElementById("<%=chkOutBoundCall.ClientID %>");
            $(chkOutBoundCall).removeAttr("checked");


            return true;
        }

        function StartOutboundCallClick() {

            var hfCallStartTime = document.getElementById("<%= hfCallStartTime.ClientID %>");

            present = new Date();
            hfCallStartTime.value = present.toDateString() + " " + present.toLocaleTimeString();

            var chkOutBoundCall = document.getElementById("<%=chkOutBoundCall.ClientID %>");
            $(chkOutBoundCall).attr("checked", '<%= Boolean.TrueString %>');

            return true;
        }


        function CheckOutBoundCall() { 
            if ('<%= IoC.Resolve<ISettings>().EnableCallPop %>' == '<%= Boolean.TrueString %>')
                return;

            var chkOutBoundCall = document.getElementById("<%=chkOutBoundCall.ClientID %>");

            var ibtnStartCall = document.getElementById("<%=ibtnStartCall.ClientID %>");
            if (chkOutBoundCall.checked) {
                //chkPrintOrderConfirm.checked = false;
                ibtnStartCall.disabled = '';
                ibtnStartCall.title = '';
            } else {
                ibtnStartCall.disabled = 'disabled';
                ibtnStartCall.title = "Please select Checkbox to start call.";
            }
        }

        function setPage(currentPage) {
            pageNumber = currentPage;
            FillGrid();
        }

        $(document).ready(function () {
            pageNumber = 1;
            FillGrid();
            $("#<%=CallQueues.ClientID%>").bind("change", function () {
                pageNumber = 1;
                FillGrid();
            });
        });--%>
    </script>

    <input type="hidden" id="hidRefereshTime" runat="server" />
    <div id="divloading" class="loadingdiv_ucecustlist" style="visibility: hidden; display: none;">
        <div class="divload">
            Loading...
        </div>
    </div>
    <div class="wrapper_inpg">
        <h1 class="left">Call Center Dashboard</h1>
        <div class="wrapper_llb" id="divLastLogin" runat="server">
            <div class="wrapperin_llb">
                <div>
                    <span id="spLastLogin" runat="server"></span>
                </div>
            </div>
        </div>
        <div id="dvStartCall">
            <div class="mainrow1_ccrep_dboard">
                <fieldset>
                    <legend>Inbound/Outbound Call</legend>
                    <div style="float: left; margin-top: 6px; padding-left: 10px; height: 75px;">
                        <div class="left">
                            <div class="phonerecordbox_ccrep" style="margin-right: 10px; height: 50px;">
                                <p class="phonerecordboxrownew_ccrep">
                                    <span class="titletextwidth_ccrep">Incoming Phone Line:</span> <span class="inputfldnowidth_default"
                                        style="padding-right: 25px">
                                        <asp:TextBox ID="txtIncomingPhLine" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"
                                            ReadOnly="true"></asp:TextBox></span> <span class="titletextwidth_ccrep">Caller’s Phone
                                                Number:</span> <span class="inputfldnowidth_default">
                                                    <asp:TextBox ID="txtCallersPhNumber" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"
                                                        ReadOnly="true"></asp:TextBox>
                                                </span>
                                </p>
                            </div>
                            <div class="startbtn_ccrep_dboard" style="padding-top: 5px; float: right;">
                                <div>
                                    <asp:ImageButton ID="ibtnStartCall" runat="server" ImageUrl="/App/Images/CCRep/start-inbound-call-btn.png"
                                        ToolTip="Please click this for Inbound Call" OnClientClick="return StartCallClick();"
                                        OnClick="ibtnStartCall_Click" />
                                </div>
                            </div>
                            <div class="startbtn_ccrep_dboard" style="padding-top: 0px; float: right;">
                                <div style="margin-top: 5px;">
                                    <asp:ImageButton ID="ibtnStartOutboundCall" runat="server" ImageUrl="/App/Images/CCRep/start-outbound-call-btn.png"
                                        ToolTip="Please click this for Outbound Call" OnClientClick="return StartOutboundCallClick();"
                                        OnClick="ibtnStartCall_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="rgt" style="padding-right: 25px; display: none;">
                            <span class="ttxtnowidthnormal_default">
                                <asp:CheckBox ID="chkOutBoundCall" runat="server" CssClass="" Text="Outbound Call" /></span>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="mainrow1_ccrep_dboard" style="width: 100%; display: none;" runat="server" id="div1">
            <fieldset>
                <legend>Outbound Call Queue</legend>
                <div style="width: 728px; padding: 10px;">
                    <div style="float: left; width: 30%;">
                        Total Record(s): <span class="total-records"></span>
                    </div>
                    <div style="float: right; width: 65%; text-align: right;">
                        My Queues:<asp:DropDownList runat="server" ID="CallQueues" Width="300" />
                    </div>
                </div>
                <div class="divgrd_cdshbrd" id="divMainGridTest">
                </div>
            </fieldset>
        </div>

        <div class="angularWrapper">
            <p style="color: #F37C00; font: bold 16px arial; clear: both; padding-top: 8px;padding-bottom: 1px">Assigned Call Queues</p>
            <div id="angularDashboard" class="mainrow1_ccrep_dboard" style="float: left; clear: both;">
            </div>
        </div>
        <%-- <div id="remove-dialog" title="Remove from Queue">
            <div>
                Please specify the reason of removing <span id="Name" style="font-weight: bold;"></span>from call queue
            </div>
            <div>
                <textarea id="reason" rows="5" cols="60"></textarea>
            </div>
            <div class="remove-buttons" style="text-align: right; margin-top: 5px;">
                <button id="remove" style="width: 70px; height: 25px;" onclick="removeFromCallQueue(); return false;">
                    Remove
                </button>
            </div>
            <div class="remove-buttons" style="display: none; text-align: right;">
                <img src="/App/Images/loading.gif" alt="" />
                Updating
            </div>
        </div>--%>
    </div>
    <script type="text/javascript" language="javascript">
        window.localStorage.setItem('token', "<%=((Session.SessionID + "_" + userSession.UserId +"_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt())%>");
        $(document).ready(function () {
            var target = $("div#angularDashboard");
            $.ajax({
                url: '<%=(moduleUrl) %>',
                type: 'GET'
            }).success(function (result) {
                target.html(result);
            });
        });
    </script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            if ("<%=StartCallAutomatically%>" === "<%= Boolean.TrueString%>") {
                $("#<%=ibtnStartCall.ClientID %>").click();
            }
            $(document).ready(function() {
                $('#remove-dialog').dialog({ width: 480, autoOpen: false, title: 'Remove from Queue', resizable: false, draggable: true });
            });

            var callQueueCustomerId = 0;

            function removeQueue(theCallQueueCustomerId, name) {
                //debugger;
                callQueueCustomerId = theCallQueueCustomerId;
                $("#reason").val('');
                $("#Name").html(name);
                $('#remove-dialog').dialog('open');
            }

            function removeFromCallQueue() {
                if ($.trim($("#reason").val()) == "") {
                    alert("Please enter the reason.");
                    return false;
                }
                $(".remove-buttons").toggle();
                if (callQueueCustomerId > 0) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "html",
                        url: "/Marketing/Reports/RemoveFromQueue",
                        data: "{'callQueueCustomerId' : '" + callQueueCustomerId + "', 'text' : '" + $("#reason").val().replace(/'/gi, "\\\'").replace(/"/gi, "\\\"") + "'}",
                        success: function(result) {
                            $(".remove-buttons").toggle();
                            $('#remove-dialog').dialog('close');
                            FillGrid();
                        },
                        error: function(a, b, c) {
                            if (a.status == 401) {
                                alert("You do not have the permission.");
                            } else
                                alert("Some error occured while removing from Queue! \nPlease try again or contact the support team!");
                            $(".remove-buttons").toggle();
                            $('#remove-dialog').dialog('close');
                        }
                    });
                }
            }
        });
    </script>
</asp:Content>

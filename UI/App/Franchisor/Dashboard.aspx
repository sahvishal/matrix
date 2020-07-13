<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_Dashboard" Title="Dashboard" CodeBehind="Dashboard.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .graphtxtbgbox_c {
            float: left;
            width: 61px;
            height: 21px;
            text-align: center;
            padding-top: 5px;
            background: url('/App/images/cboxbg.gif');
            font: normal 11px arial;
            color: #fff;
        }

        .graphtxtbgbox_cb {
            float: left;
            width: 61px;
            height: 21px;
            text-align: center;
            padding-top: 5px;
            background: url('/App/images/cbboxbg.gif');
            font: normal 11px arial;
            color: #fff;
        }

        .graphtxtbgbox_ch {
            float: left;
            width: 61px;
            height: 21px;
            text-align: center;
            padding-top: 5px;
            background: url('/App/images/chboxbg.gif');
            font: normal 11px arial;
            color: #fff;
        }

        .graphtxtbgbox_t {
            float: left;
            width: 61px;
            height: 21px;
            text-align: center;
            padding-top: 5px;
            background: url('/App/images/tboxbg.gif');
            font: normal 11px arial;
            color: #fff;
        }

        .greyboxheading {
            float: left;
            width: 172px;
            background: url(../images/fdbrd-tabs-bg.gif);
            padding: 4px 4px 4px 12px;
            border-top: solid 1px #e5e5e5;
            border-left: solid 1px #e5e5e5;
            border-right: solid 1px #e5e5e5;
            background-color: #f5f5f5;
            font: bold 14px arial;
            color: #000;
        }

        .greyboxbdrtop {
            float: left;
            width: 356px;
            height: 1px;
            background: url(../images/bg-greybox-fdbrd.gif) no-repeat;
        }

        .biggreyboxbdrtop {
            float: left;
            width: 745px;
            height: 1px;
            background: url(../images/bigbg-greybox-fdbrd.gif) no-repeat;
        }

        .greyboxbgnbdr {
            float: left;
            width: 330px;
            padding: 12px;
            border-left: solid 1px #e5e5e5;
            border-right: solid 1px #e5e5e5;
            border-bottom: solid 1px #e5e5e5;
            background-color: #f5f5f5;
        }

        .biggreyboxbgnbdr {
            float: left;
            width: 719px;
            padding: 12px;
            border-left: solid 1px #e5e5e5;
            border-right: solid 1px #e5e5e5;
            border-bottom: solid 1px #e5e5e5;
            background-color: #f5f5f5;
        }

        .orngbdrboxinner {
            float: left;
            width: 306px;
            padding: 5px 10px 5px 10px;
            border: solid 1px #F18B30;
            background-color: #fff;
        }

        .orngbdrboxinner_RA {
            float: left;
            width: 320px;
            padding: 3px;
            border: solid 1px #F18B30;
            background-color: #fff;
        }

        .orngbdrboxinner_Loading {
            float: left;
            width: 306px;
            padding: 80px 10px;
            border: solid 1px #F18B30;
            text-align: center;
            background-color: #fff;
        }

        .orngbdrboxinnerrow {
            float: left;
            width: 305px;
        }

        .orngbdrboxbetweenrow {
            float: left;
            width: 305px;
            margin-top: 5px;
            margin-bottom: 5px;
        }

        .bigorngbdrboxinner {
            float: left;
            width: 705px;
            padding: 5px;
            border: solid 1px #F18B30;
            background-color: #fff;
        }

        .bigorngbdrboxinner_Loading {
            float: left;
            width: 705px;
            padding: 80px 5px 80px 5px;
            text-align: center;
            border: solid 1px #F18B30;
            background-color: #fff;
        }

        .bigorngtabboxtop {
            float: left;
            width: 695px;
            height: 31px;
        }

        .orngtabboxtop {
            float: left;
            width: 326px;
            height: 31px;
        }

        .orngtabboxbottom {
            float: left;
            width: 326px;
        }

        .kpititletxt_16px {
            float: left;
            width: 125px;
            padding-top: 7px;
            font: bold 16px arial;
            color: #333;
        }

        .kpidatabox_big {
            float: left;
            width: 140px;
            height: 27px;
            background: url('/App/images/bigboxdata-kpi-fdbrd.gif');
            padding-top: 6px;
            font: bold 16px arial;
            text-align: center;
            color: #000;
        }

        .kpidatabox_small {
            float: left;
            width: 61px;
            height: 27px;
            background: url('/App/images/smallboxdata-kpi-fdbrd.gif');
            padding-top: 6px;
            font: bold 16px arial;
            text-align: center;
            color: #000;
        }

        .malefemaleicon_dbrd {
            float: left;
            width: 25px;
            margin-right: 10px;
        }

        .peoplecountbox {
            float: left;
            width: 59px;
            height: 23px;
            background: url('/App/images/peoplecountboxbg.gif');
            padding-top: 5px;
            font: bold 16px arial;
            text-align: center;
            color: #000;
        }

        .halfboxorngbox {
            float: left;
            width: 150px;
            text-align: center;
        }

        .kpititletxt_16pxnofloat {
            font: bold 16px arial;
            color: #333;
        }

        .prow_main {
            float: left;
            width: 753px;
        }

        .prow_fdb {
            float: left;
            width: 749px;
            margin: 5px 0 10px 0;
        }

        .lftarea_fdb {
            float: left;
            width: 360px;
            margin-right: 29px;
        }

            .lftarea_fdb .divrow {
                float: left;
                width: 100%;
            }

        .rgtarea_fdb {
            float: left;
            width: 360px;
        }

            .rgtarea_fdb .divrow {
                float: left;
                width: 100%;
            }

        .rfrshlnk {
            float: right;
            margin: 5px 10px 0 0;
        }

        .fullwdth {
            float: left;
            width: 100%;
        }

        .totaltxt {
            float: left;
            width: 160px;
            font: bold 12px arial;
        }

        .graphtxtrow {
            float: left;
            width: 75px;
            font: bold 11px arial;
            color: #000;
        }

        .graphtxtrow1 {
            float: left;
            width: 87px;
            font: bold 11px arial;
            color: #000;
        }

        .graphtxt {
            float: left;
            width: 10px;
            padding-top: 5px;
        }

        .graphtxt1 {
            float: left;
            width: 17px;
            padding-top: 5px;
        }

        .map-legend {
            background: #fff;
            padding: 10px;
        }

        .margin-bottom-10 {
            margin-bottom: 10px;
        }

        .margin-right-10 {
            margin-right: 10px;
        }

        .legend {
            width: 10px;
            height: 10px;
            float: left;
            margin-right: 5px;
        }

        .gm-style-iw + div {
            display: none;
        }
        .chart-loader-height{
            height: 260px; padding: 0 5px 0 5px;
        }   
     @media print {
         html, body {             
        height: 250px;
    }
}
    </style>
    
    <script type="text/javascript" src="/Scripts/highcharts.js"></script>
    <script type="text/javascript" src="/Scripts/highchartmodelexporting.js"></script>

    <div class="wrapper_inpg">
        <h1 class="left">Dashboard</h1>
        <div class="wrapper_llb" id="divLastLogin" runat="server">
            <div class="wrapperin_llb">
                <div><span id="spLastLogin" runat="server"></span></div>
            </div>
        </div>
        <div class="prow_fdb">
            <div class="prow_main">
                <div class="prow_main">
                    <span class="greyboxheading">Outreach Calls </span>
                    <span class="rfrshlnk">
                        <a href="javascript:StartGetOutreachCalls();">refresh </a>
                    </span>
                </div>
                <p class="biggreyboxbdrtop"></p>
                <div class="biggreyboxbgnbdr">
                    <div id="divLoadingOutreachCalls" class="bigorngbdrboxinner_Loading chart-loader-height">
                    <span class="fullwdth" style="margin-top: 100px;">
                        <img alt="Loading......" src="../Images/indicatorbig.gif" /></span>
                    <span class="fullwdth" style="font-weight: bold;">Loading</span>
                </div>                  
                   <div id="divOutreachCallChart" class="bigorngbdrboxinner">
                    <div id="outreachCall_container" style="min-height: 250px; max-height:300px">
                    </div>
                </div>
                </div>
            </div>
        </div>
        <div class="prow_main">
            <div class="prow_main">
                <span class="greyboxheading">Appointment Booked</span>
                <span class="rfrshlnk">
                    <a href="javascript:showAppointmentBookedChart();">refresh </a>
                </span>
            </div>
            <p class="biggreyboxbdrtop"></p>
            <div class="biggreyboxbgnbdr">
                <div id="divAppointmentBookedRbtn" class="editor-column" style="width: 100%; float: left; padding-top: 5px; clear: both;">
                    <div style="float: left; width: 8%">
                        <input type="radio" name="appointmentBookedRbtn" checked value='<% Response.Write(Falcon.App.Core.Scheduling.Enum.AppointmentBookedChartStatus.All); %>' />
                        All
                    </div>
                    <div style="float: left; width: 15%">
                        <input type="radio" name="appointmentBookedRbtn" class="rbtnAppointment" value='<% Response.Write(Falcon.App.Core.Scheduling.Enum.AppointmentBookedChartStatus.HealthPlan); %>' />Health Plan
                    </div>
                    <div style="float: left; width: 10%">
                        <input type="radio" name="appointmentBookedRbtn" class="rbtnAppointment" value='<% Response.Write(Falcon.App.Core.Scheduling.Enum.AppointmentBookedChartStatus.Retail); %>' />Retail
                    </div>
                    <div style="float: left; width: 15%">
                        <input type="radio" name="appointmentBookedRbtn" class="rbtnAppointment" value='<% Response.Write(Falcon.App.Core.Scheduling.Enum.AppointmentBookedChartStatus.Corporate); %>' />Corporate
                    </div>
                </div>
                <div id="divLoadingAppointmentBooked" class="bigorngbdrboxinner_Loading chart-loader-height">
                    <span class="fullwdth" style="margin-top: 100px;">
                        <img alt="Loading......" src="../Images/indicatorbig.gif" /></span>
                    <span class="fullwdth" style="font-weight: bold;">Loading</span>
                </div>               
                <div id="divAppointmentBookedChart" class="bigorngbdrboxinner appointment all" >
                    <div id="appointmentBooked_container" style="height: 250px; " align="center" >
                    </div>
                </div>
               
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $('input[type=radio][name=appointmentBookedRbtn]').change(function () {
                showAppointmentBookedChart();
            });
            StartGetOutreachCalls();
            showAppointmentBookedChart();
        });
        function showAppointmentBookedChart() {
            var val = $('input[name=appointmentBookedRbtn]:checked', '#divAppointmentBookedRbtn').val()
            if (val != '')
                StartGetAppointmentBookedStatus(val);
        }

    </script>
    <script language="javascript" type="text/javascript">
        function StartGetOutreachCalls(url) {
            $("#divOutreachCallChart").hide();
            $("#divLoadingOutreachCalls").show();            
            $.ajax({
                type: 'GET',
                datatype: 'image/jpeg',
                url: '/CallCenter/CallQueue/GetOutreachCallChart',
                success: function (data) {
                    var catagories = [];
                    var seriesData = [];
                    data.forEach(function (item) {
                        $("#divLoadingOutreachCalls").hide();
                        $("#divOutreachCallChart").show();
                        catagories.push(item.OutreachDate);
                        seriesData.push(item.Calls)
                    });
                    outreachCallFunc(catagories.reverse(), seriesData.reverse());
                }
            });
        }
        var chart;
        function outreachCallFunc(catagories, data) {
            var max = Math.max.apply(Math, (data));
            var extraVal = max / 4;
            var containerHeight = document.getElementById('outreachCall_container').clientHeight;
            Highcharts.chart('outreachCall_container', {
               chart: {
                   type: 'line'
                },
                title: {
                    text: 'Outreach Calls'
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: catagories
                },
                yAxis: {
                    allowDecimals: false,
                    title: {
                        text: 'Number of Calls'
                    },
                    max: (max + extraVal)
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: false
                    }
                }, exporting: {
                    filename: 'Outreach Calls',
                    sourceHeight: containerHeight,
                },
                credits: {
                    enabled: false
                },               
                series: [{
                    name: 'Dates',
                    data: data
                }]
           });           
        }              
    </script>

    <script language="javascript" type="text/javascript">

        function StartGetAppointmentBookedStatus(type) {
            $("#divAppointmentBookedChart").hide();
            $("#divLoadingAppointmentBooked").show();
            $.ajax({
                type: 'GET',
                datatype: 'image/jpeg',
                data: {
                    type: type
                },
                url: '/Scheduling/Reports/GetBookedAppointmentChart',
                success: function (data) {
                    $("#divLoadingAppointmentBooked").hide();
                    $("#divAppointmentBookedChart").show();
                    var catagories = [];
                    var seriesData = [];
                    data.forEach(function (item) {
                        catagories.push(item.BookedAppointmentDate);
                        seriesData.push(item.BookedAppointmentCustomers);
                    });
                    appintmentBookedFunc(catagories.reverse(), seriesData.reverse());
                }
            });
        }

        function appintmentBookedFunc(catagories, data) {
            var max = Math.max.apply(Math, (data));
            var extraVal = max / 4;
            var containerHeight =document.getElementById('appointmentBooked_container').clientHeight;
            Highcharts.chart('appointmentBooked_container', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Appointment Booked'
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: catagories
                },
                yAxis: {
                    allowDecimals: false,
                    title: {
                        text: 'Appointment Booked'
                    },
                    max: (max + extraVal)
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking:false
                    }
                }, credits: {
                    enabled: false
                }, exporting: {
                    filename: 'Appointment Booked',
                    sourceHeight: containerHeight,
                },
                series: [{
                    name: 'Dates',
                    data: data
                }]
            });
        }

    </script>
</asp:Content>

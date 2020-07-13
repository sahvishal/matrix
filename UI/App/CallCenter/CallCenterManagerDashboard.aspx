<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/CallCenterMaster.master" AutoEventWireup="true" Inherits="CallCenterManager_Dashboard" Title="Dashboard" CodeBehind="CallCenterManagerDashboard.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="/Scripts/highcharts.js"></script>
    <script type="text/javascript" src="/Scripts/highchartmodelexporting.js"></script>
    <style type="text/css">
        @media print {
            html, body {
                height: 250px;
            }
        }
    </style>
    <div class="mainbody_outer_mvdb_cm">
        <div class="mainbody_inner_mvdb_cm">
            <div class="mainbody_titletxtleft mainbody_inner_mid_cm">
                <p style="margin-left: 10px;">Call Center Manager Dashboard</p>
            </div>
        </div>
        <%--<div class="mainbody_inner_right" style="min-height: 500px;">
        </div>--%>
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
                    <div id="divOutreachCallChart" class="bigorngbdrboxinner" style="display: none;">
                        <div id="outreachCall_container" style="min-height: 250px; max-height: 300px">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            StartGetOutreachCalls();
        });
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
</asp:Content>

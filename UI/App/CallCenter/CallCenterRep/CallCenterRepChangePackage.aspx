<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" AutoEventWireup="true" Inherits="App_CallCenter_CallCenterRep_CallCenterRepChangePackage" CodeBehind="CallCenterRepChangePackage.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="../../UCCommon/ucChangePackage.ascx" TagName="ucChangePackage"
    TagPrefix="uc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
    
    <style type="text/css">
    .fill_clinical_questionaire {
            margin-top: 10px;
            float: left;
            clear: both;
            padding-left: 14px;
            margin-bottom: 6px;
    }
    .head_link_regcust {
        color: #287aa8;
        font-size: 14px !important;
        text-decoration: underline;
    }

    .head_link_regcust:hover {
        color: #287aa8;
    }

    .head_link_regcust:visited {
        color: #287aa8;
    }

    .error {
            font-weight: bold;
            margin: 10px 5px;
            color: #D8000C;
            background-color: #FFBABA;
            padding: 10px 7px;
            background-repeat: no-repeat;
            background-position: 10px center;
            border: 1px solid;
        }
    </style>
    <div style="float: left">
        <div class="mainbody_outer">
            <div class="mainbody_inner">
                <div class="main_area_bdrnone">
                    <div class="headingbox_top_body">
                        <p>
                            <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                        <div class="orngheadtxt_heading" id="dvTitle" runat="server">Call Centre Rep Dashboard</div>
                        <div class="headingright_default" id="divCall" runat="server">
                            <div class="endcall_ccrep_dboard">
                                <span class="endtbtn_ccrep_dboard" style="padding-top: 4px;">
                                    <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif" OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                                </span>
                            </div>
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
                        </div>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                </div>
            </div>
        </div>
        <div id="disqulifiedTests" runat="server" class="left-float disqualified-test error" style="width: 50%; display: none; font-size: 13px; margin-bottom: 10px;">
        </div>
        <div id="recommended_test_text" runat="server" class="left-float recommended-test info-box" style="width: 50%; display: none; font-size: 13px;">
        </div>
        <div class="fill_clinical_questionaire" runat="server" id="FillClinicialQuestionnaireDiv" Visible="False">
            <a href="javascript:void(0)" onclick="ShowClinicalQuestion()">
                <span class="head_link_regcust"><b>FILL CLINICAL QUESTIONNAIRE</b></span>
            </a>
        </div>
        <div style="float: left">

            <uc1:ucChangePackage ID="UcChangePackage1" runat="server" />
        </div> 
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />

    <script type="text/javascript" language="javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);


        var winclinicalhistory = null;
        function ShowClinicalQuestion() {
            var customerId = '<%=CustomerId %>';
            var eventId = '<%=EventId %>';
            var guid = '<%=GuId %>';
            var clinicalQuestionTemplateId = '<%=ClinicalQuestionTemplateId %>';
            var eventCustomerId = '<%=EventCustomerId %>';
            winclinicalhistory = window.open("/Medical/ClinicalQuestion/GetClinicalQuestion?guid=" + guid + "&customerId=" + customerId + "&eventId=" + eventId + "&clinicalQuestionTemplateId=" + clinicalQuestionTemplateId + "&eventCustomerId=" + eventCustomerId, "ClinicalQuestion", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=1100,height=500");
            return false;
        }
        function closeClinicalQuestion() {
            if (winclinicalhistory != null) {
                winclinicalhistory.close();
                GetRecommandation();
            }

        }

        function GetRecommandation() {
            var customerId = '<%=CustomerId %>';
            var eventId = '<%=EventId %>';
            var guid = '<%=GuId %>';
            $.ajax({
                url: '/Medical/ClinicalQuestion/GetRecommendations?guid=' + guid + "&customerId=" + customerId + "&eventId=" + eventId,
                type: 'Get',
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (result) {
                    isClinicalQuestionairFilled = true;
                    if (result.Result.length <= 0) {
                        $(".recommended-test").html("<b>Recommended Tests: </b>None");
                        $(".disqualified-test").html('');
                        $(".disqualified-test").hide();
                    } else {
                        var testids = [];
                        var testNames = [];
                        var disqualifiedTest = [];
                        $.each(result.Result, function (index, obj) {

                            if (obj.IsDisqualified == false) {
                                testids.push(obj.TestId);
                                testNames.push(obj.Name);
                            } if (obj.IsDisqualified == true) {
                                disqualifiedTest.push(obj.Name);
                            }

                        });

                        UpdateOrderWithRecommendations(testids);
                        if (testNames.length > 0) {
                            $(".recommended-test").html("<b>Recommended Tests: </b>" + testNames.join(","));
                        } else {
                            $(".recommended-test").html("<b>Recommended Tests: </b>None");
                        }

                        if (disqualifiedTest.length > 0) {
                            $(".disqualified-test").html("<b>Disqualified Tests: </b>" + disqualifiedTest.join(","));
                            $(".disqualified-test").show();
                        } else {
                            $(".disqualified-test").html('');
                            $(".disqualified-test").hide();
                        }
                    }
                    $(".recommended-test").show();
                },
                error: function (a, b, c) {
                    if (a.status == 401) {
                        alert("You do not have the permission.");
                    }
                }
            });
        }

        function UpdateOrderWithRecommendations(testids) {
            $.each(testids, function (index, value) {
                var checkbox = $("input:hidden[id='TestIdHidden'][value='" + value + "']").parent().find("input:checkbox");
                $(checkbox).attr("checked", "checked");
                $(checkbox).click();
                $(checkbox).attr("checked", "checked");
            });
        }
      
        $(document).ready(function() {
            checkAndOpenScriptPopup();
        });

    </script>
</asp:Content>

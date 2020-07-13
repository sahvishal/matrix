<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Common_ChangePackage" Codebehind="ChangePackage.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="../UCCommon/ucChangePackage.ascx" TagName="ucChangePackage" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <style type="text/css">
    .fill_clinical_questionaire {
             
            clear: both;
        padding-left: 14px;
        padding-top: 5px;
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
    <div id="disqulifiedTests" runat="server" class="left-float disqualified-test error" style="width: 50%; display: none; font-size: 13px; margin-bottom: 15px;">
    </div>
    <div id="recommended_test_text" runat="server" class="left-float recommended-test info-box" style="width: 50%; display: none; font-size: 13px; margin-bottom: 15px;">
    </div>
    <div class="fill_clinical_questionaire" runat="server" id="FillClinicialQuestionnaireDiv" Visible="False">
        <a href="javascript:void(0)" onclick="ShowClinicalQuestion()">
            <span class="head_link_regcust"><b>FILL CLINICAL QUESTIONNAIRE</b></span>
        </a>
    </div>
<uc1:ucChangePackage id="UcChangePackage1" runat="server">
</uc1:ucChangePackage>
    <script language="javascript">
         
       

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
    </script> 
  
    



	
	<style type="text/css">
		.saveWaitAnimationnew {
			background-image: url('/Content/Images/loading_Big_orng.gif');
			background-repeat: no-repeat;
			position: fixed;
			top: 0px;
			right: 0px;
			width: 100%;
			height: 100%;
			background-color: #000;
			background-position: center;
			z-index: 10000000;
			opacity: 0.4;
			filter: alpha(opacity=40);
		}

		#jSuggestContainer ul {
			width: 250px;
			max-height: 300px;
			overflow-y: scroll;
			overflow-x: hidden;
		}
	</style>

</asp:Content>

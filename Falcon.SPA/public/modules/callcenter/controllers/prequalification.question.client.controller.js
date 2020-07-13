(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.healthplanPreQualificationController,
    ['$scope', '$modalInstance', 'data', 'logger', CallCenterConfiguration.services.contactService,
	function ($scope, $modalInstance, data, logger, contactService, constants) {
	    $scope.InvitationCode = '';

	    $scope.model = null;

	    function init() {


	        contactService.GetPreQualificationQuestion(data.PatientInfo.CustomerId, data.TemplateIds).then(function (result) {
	            $scope.model = result;
	            setTimeout(function () {
	                getAnswer(result)
	            }, 100);
	        });

	    }

	    init();

	    $scope.save = function () {
	        var isComplete = true;
	        var questionAnsTestId = "";
	        $('#tblQuestion > tbody > tr').each(function (index, item) {

	            if ($(this).css('display') == 'none') {
	                return;
	            }
	            var queId = $(this).find('.hdnQuestionId').val();
	            var testId = $(this).find('.hdnTestId').val();
	            var controlType = $(this).find('.hdnControlType').val();
	         
	            var date = "";
	            var name = testId + '_' + queId;
	            var ans = "";

	            if (controlType == "124") {
	                ans = $(this).find("input[name='" + name + "']:checked").val();
	            }
	            else if (controlType == "126") {
	                ans = $(this).find("input[name='" + name + "']").val();
	            }
	            if (queId == 7 && ans == "Date")
	            {
	                date = $(this).find("input[name='29_8']").val()
	            }
	            if (typeof ans == "undefined" || ans == "") {
	                alert("You have to attempt all Questions.");
	                isComplete = false;
	                return false;
	            }
	            if (queId == 7 && ans == "Date" && date == "")
	            {
	                alert("You have to attempt all Questions.");
	                isComplete = false;
	                return false;
	            }

	            if (questionAnsTestId != "")
	                questionAnsTestId += '|' + queId + "," + ans + "," + testId;
	            else
	                questionAnsTestId += queId + "," + ans + "," + testId;

	            if (queId == 7 && ans == "Date" && date != "")
	            {
	                questionAnsTestId += '|' + 8 + "," + date + "," + testId;
	            }


	        });
	        if (isComplete) {

	            var disqualifedTest = CheckIsEligibleForTest(questionAnsTestId, data.Event.AllowNonMammoPatients ? 'True' : 'False');

	            var model = {
	                CustomerId: data.PatientInfo.CustomerId,
	                EventId: data.Event.EventId,
	                QuestionAnswerTestIds: questionAnsTestId,
	                DisqualifiedTests: disqualifedTest
	            }

	            contactService.SavePreQualificationAnswers(model).then(function () {

	                var redirectNonMammo = (typeof isRedirectNonMammo == "undefined") ? 'No' : isRedirectNonMammo;

	                questionAnsTestId = '';
	                var retData = { isRedirectNonMammo: redirectNonMammo, eventId: data.Event.EventId, disqualifedTest: disqualifedTest }
	                $scope.$close(retData);
	            
	            });
	        }
	    };

	    $scope.Cancel = function () {
	        $scope.$close(null);
	    };

	    $scope.radioChangeEvent = function (questionId, ans) {
	        
	        var listQuestionRule = $scope.model[0].DependencyRule;
	        $(listQuestionRule).each(function (index, item) {
	            
	            if (item.DependencyValue == ans && item.DependentQuestionId == questionId) {

	                $("#tr_" + item.QuestionId).css("display", "block");
	                if (ans == 'Date')
	                {
	                    var today = new Date();
	                    var dd = today.getDate();
	                    var mm = today.getMonth() + 1; 
	                    var yyyy = today.getFullYear();
	                    if (dd < 10) {
	                        dd = '0' + dd;
	                    }
	                    if (mm < 10) {
	                        mm = '0' + mm;
	                    }
	                    today = mm + '/' + dd + '/' + yyyy;
	                    $("#29_8").val(today);
	                }
	            }
	            else if (item.DependencyValue != ans && item.DependentQuestionId == questionId) {
	                $("#tr_" + item.QuestionId).css("display", "none");
	                clearControl(item.QuestionId)
	            }
	            if (questionId == 5 && ans == 'No') {
	                $("#tr_8").css("display", "none");
	            }

	        });

	    }
	    function getAnswer(answerList) {
	        
	        $(answerList).each(function (index, item) {
	            $(item.Questions).each(function (index, q) {
	                
	                setAnswer(q.Id, q.Answer, q.TypeId, item.TestId);

	                $scope.radioChangeEvent(q.Id, q.Answer);
	            });
	        });
	    }
	    function setAnswer(queid, ans, typeId, testId) {
	       
	        var radionselect = testId + '_' + queid + '_' + ans.replace(/ /g, "_");

	        if (typeId == '124') {
	            $('input:radio[id=' + radionselect + ']').attr('checked', true);
	        }
	        else if (typeId == '126') {
	                $("#" + testId + '_' + queid).val(ans);
	        }
	    }
	    function clearControl(trId) {
	        $("#tr_" + trId).find(':input').each(function (index, item) {
	            if ($(item).prop('type') == 'radio')
	            {
	                $(item).attr('checked', false);
	            }
	            else if ($(item).prop('type') == 'text')
	            {
	                $(item).val('');
	            }
	        })
	    }


	}]);
}());
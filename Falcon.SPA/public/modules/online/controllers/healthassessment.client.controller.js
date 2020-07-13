(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).controller(OnlineConfiguration.controllers.healthAssessmentController, [
        '$rootScope', '$scope', '$stateParams', '$state', '$modal', CoreConfiguration.constants, OnlineConfiguration.services.healthAssessmentService,  "usSpinnerService", 'logger',
        function ($rootScope, $scope, $stateParams, $state, $modal, constants, healthAssessmentService,  usSpinnerService, logger) {

            $rootScope.title = $state.current.title;
            $scope.data = {};
            $scope.hafModel = {};
            $scope.contentLoading = false;
            $scope.isCollapsed = true;
            $scope.displayControlTypes = constants.DisplayControlType;

            $scope.currentHafPageIndex = 0;
            $scope.TotalHafPagecount = 0;

            $scope.HafPageSize = 8;
            $scope.selectedCount = 0;
            
            $scope.skiptisInitiated = false;
            $scope.isPosted = false;
            $scope.loader_Skip = false;
            $scope.loader_Submit = false;
            $scope.loader_back = false;
            $scope.submitInitiated = false;
            var modelPopupInstance = null;
            $scope.currentGroupId = 1;
            $scope.currentTestId = 0;
            $scope.groupName = "";

            $scope.FeetDropwdown = new Array();
            $scope.InchDropwdown = new Array();
            $scope.Race = new Array();
            $scope.Weight = '';
            $scope.CustomerHeightInches = -1;
            $scope.CustomerHeightFeet = -1;
            $scope.Waist = '';

            $scope.selectedRace = new Object();


            $scope.PagewiseQuestions = new Array();

            $scope.HafQuestionList = {
                TotalHafQuestionCount: 0,
                TotalQuestionArray: new Array(),
                selectedHafQuestions: new Array(),
                questionIdsWithOutControlType: new Array(),
            };

            $scope.SelectedCount = 0;

            $scope.GetCount = function () {
                $scope.SelectedCount = healthAssessmentService.GetAnsweredCount($scope.HafQuestionList.TotalQuestionArray);

                if ($scope.SelectedCount > 0) {
                    var disabledQuestionCount = healthAssessmentService.GetNumberOfDisabledParentQuestions($scope.HafQuestionList.TotalQuestionArray);
                    $scope.SelectedCount = $scope.SelectedCount + disabledQuestionCount;
                }
            };


            var populateDropDown = function(data) {
                $scope.FeetDropwdown = new Array();
                $scope.InchDropwdown = new Array();
                $scope.Race = new Array();
                $scope.FeetDropwdown.push({ value: -1, text: 'Feet' });

                for (var feetIndex = 3; feetIndex <= 7; feetIndex++) {
                    var feet = { value: feetIndex, text: feetIndex };
                    $scope.FeetDropwdown.push(feet);
                }

                $scope.InchDropwdown.push({ value: -1, text: 'Inches' });
                for (var inchIndex = 0; inchIndex <= 11; inchIndex++) {
                    var inch = { value: inchIndex, text: inchIndex };
                    $scope.InchDropwdown.push(inch);
                }

                $.each(constants.RaceTypes, function(index, value) {
                    var race = index;
                    
                    if (value == constants.RaceTypes.DeclinesToReport) {

                        race = "Declines to report";
                    }

                    $scope.Race.push({ value: value, text: race });
                });

                $scope.selectedRace = $scope.Race[0];

                if (typeof(data) !== 'undefined' && data != null) {
                    if (data.Height != null && data.Height > 12) {
                        $scope.CustomerHeightFeet = parseInt(data.Height / 12);
                    }
                    if (data.Height != null && data.Height > 0) {
                        $scope.CustomerHeightInches = data.Height % 12;
                    }

                    if (data.Weight != null && data.Height > 0) {
                        $scope.Weight = data.Weight;
                    }
                    if (data.Waist != null && data.Waist > 0) {
                        $scope.Waist = data.Waist;
                    }

                    if (data.Race != null && data.Race > 0) {
                        $.each(constants.RaceTypes, function(index, value) {
                            if (data.Race === value) {
                                $scope.selectedRace = { value: value, text: index };
                            }
                        });
                    }
                }

            };

            $scope.getHafProgress = function () {
                var selectedQuestion = $scope.HafQuestionList.selectedHafQuestions;

                var totalHafQuestionCount = $scope.HafQuestionList.TotalHafQuestionCount;
                if (typeof selectedQuestion === 'undefined' || selectedQuestion === null || selectedQuestion.length <= 0) {
                    return '0%';
                }

                return (($scope.SelectedCount / totalHafQuestionCount) * 100) + "%";
            };

            function init() {
                $scope.contentLoading = true;

                populateDropDown(null);

                healthAssessmentService.GetHealthAssessmentQuestion($stateParams.guid).then(function (data) {
                     
                    $scope.hafModel = extactShowAsSeprateQuestions(data.HafModel);;

                    $scope.HafQuestionList.selectedHafQuestions = new Array();
                    $scope.isKynPurchased = data.IsKynPurchased;
                    populateDropDown(data);
                    $scope.data = data;
                    $scope.getTotalQuestion();
                    $scope.getTotalPageCount();
                    $scope.nextHafQuestion();
                    $scope.HafQuestionList.selectedHafQuestions = healthAssessmentService.HafSelectedQuestionArray($scope.HafQuestionList.TotalQuestionArray);

                    setTimeout(function () {
                        usSpinnerService.stop('online-spinner');
                    }, 1000);
                });
            }

            init();
            var showAsSeprateQuestion = [29, 301, 307, 325, 389, 440, 26, 1000];
            function extactShowAsSeprateQuestions(model) {
                var modelQuestions = model;

                if (model != null && model.HafGroup.Questions != null && model.HafGroup.Questions.length > 0) {
                    var questionList = new Array();
                    $.each(model.HafGroup.Questions, function (index, question) {
                        var result = showAsSeprateQuestion.filter(function (el) { return el === question.QuestoinId; });
                        if (result != null && result.length > 0 && question.ChildQuestion.length > 0) {
                            var childQuestion = question.ChildQuestion;
                            question.ChildQuestion = new Array();
                            questionList.push(question);
                            $.each(childQuestion, function (ci, cq) {
                                cq.ParentQuestionId = 0;
                                cq.showAsSeprateQuestion = true;
                                questionList.push(cq);
                            });
                        } else {
                            questionList.push(question);
                        }
                    });

                    modelQuestions.HafGroup.Questions = questionList;
                }

                return modelQuestions;
            }

            $scope.getTotalPageCount = function () {
                if ($scope.HafQuestionList.TotalHafQuestionCount <= 0) {
                    $scope.TotalHafPagecount = 0;
                    $scope.currentHafPageIndex = 0;
                }

                $scope.TotalHafPagecount = Math.ceil($scope.HafQuestionList.TotalHafQuestionCount / $scope.HafPageSize);
            };

            $scope.getTotalQuestion = function () {
                $scope.HafQuestionList = healthAssessmentService.HafQuestionList($scope.hafModel);
                $scope.HafQuestionList.TotalQuestionArray = healthAssessmentService.SetDependentQuestionEnableDisable($scope.HafQuestionList.TotalQuestionArray, $scope.HafQuestionList.TotalQuestionArray);

            };

            $scope.nextHafQuestion = function () {
                if ($scope.currentHafPageIndex >= $scope.TotalHafPagecount) {
                    return;
                }
                $scope.currentHafPageIndex = $scope.currentHafPageIndex + 1;
                $scope.PagewiseQuestions = healthAssessmentService.HafQuestionsPageWise($scope.HafQuestionList.TotalQuestionArray, $scope.currentHafPageIndex, $scope.HafPageSize);
                $scope.GetCount();
            };

            $scope.PreviousHafQuestion = function () {
                if ($scope.currentHafPageIndex >= $scope.TotalHafPagecount && $scope.currentHafPageIndex <= 1) {
                    return;
                }
                $scope.currentHafPageIndex = $scope.currentHafPageIndex - 1;

                $scope.PagewiseQuestions = healthAssessmentService.HafQuestionsPageWise($scope.HafQuestionList.TotalQuestionArray, $scope.currentHafPageIndex, $scope.HafPageSize);
                $scope.GetCount();
            };

            $scope.SaveSelectedObject = function (question, controlValue) {

                $scope.HafQuestionList.selectedHafQuestions = $scope.HafQuestionList.selectedHafQuestions.filter(function (el) { return el.QuestionId !== question.QuestoinId; });

                var questionList = new Array();

                $.each($scope.HafQuestionList.TotalQuestionArray, function (index, value) {

                    if (value.QuestoinId == question.QuestoinId) {
                        if (question.ControlType === $scope.displayControlTypes.Radio) {
                            value.Answer = controlValue;
                        } else {
                            value.Answer = question.Answer;
                        }
                    };

                    questionList.push(value);
                });

                $scope.HafQuestionList.TotalQuestionArray = questionList;

                $scope.HafQuestionList.selectedHafQuestions = healthAssessmentService.HafSelectedQuestionArray($scope.HafQuestionList.TotalQuestionArray);

                $scope.PagewiseQuestions = healthAssessmentService.HafQuestionsPageWise($scope.HafQuestionList.TotalQuestionArray, $scope.currentHafPageIndex, $scope.HafPageSize);

                $scope.GetCount();
            };

            $scope.SkiptAndSave = function () {
                $scope.submitInitiated = false;
                $scope.skiptisInitiated = true;
                var isAnswerd = healthAssessmentService.IsAllQuestionAnswered($scope.HafQuestionList.TotalQuestionArray);

                if (!isAnswerd) {
                    popupModel();
                } else {
                    $scope.post();
                }
            };

            $scope.SaveHealthAssessmentQuestion = function () {
                $scope.submitInitiated = true;
                $scope.skiptisInitiated = false;
                var isAnswerd = healthAssessmentService.IsAllQuestionAnswered($scope.HafQuestionList.TotalQuestionArray);

                if (!isAnswerd) {
                    popupModel();
                } else {
                    $scope.post();
                }
            };

            var modelPopupInstance = null;
            var popupModel = function () {

                var modalPopupObject = {
                    showTitle: true,
                    Title: "Health Assessment Question",
                    showCancelButton: true,
                    cancelButtonText: 'No, I will fill it later',
                    showOkButton: true,
                    OKButtonText: 'Let me finish now',
                    Message: 'It appears you have not answered all the necessary Health Assessment Questions.',
                    CallBackOnOkButton: null,
                    CallBackOnCancelButton: function () {
                        $scope.post();
                    }
                };

                modelPopupInstance = $modal.open({
                    templateUrl: ApplicationConfiguration.domainUrl + '/public/modules/shared/views/model.popup.client.view.html',
                    controller: 'modalPopupController',
                    resolve: {
                        data: function () {
                            return modalPopupObject;
                        }
                    }
                });
            };

            var getOnlineHealthAssessmentModel = function() {
                var heightinInches = 0;
                var heightinFeet = 0;
                var height = 0;
                var weight = 0;
                var race = 0;
                var waist = null;

                if ($scope.CustomerHeightInches !== '' || $scope.CustomerHeightFeet !== '') {
                    heightinInches = $scope.CustomerHeightInches;
                    heightinFeet = $scope.CustomerHeightFeet;
                    height = (heightinFeet * 12) + heightinInches;
                }

                if ($scope.Weight !== '') {
                    weight = $scope.Weight;
                }
                if ($scope.Waist !== '') {
                    waist = $scope.Waist;
                }

                if ($scope.selectedRace.value > -1) {
                    race = $scope.selectedRace.value;
                }
                var onlineHealthAssessmentQuestionModel = {
                    "QuestionEditModels": $scope.HafQuestionList.selectedHafQuestions,
                    "Guid": $stateParams.guid,
                    "Race": race,
                    "Height": height,
                    "Weight": weight,
                    "Waist": waist
                };

                return onlineHealthAssessmentQuestionModel;
            };

            $scope.post = function () {
                $scope.isPosted = true;

                $scope.loader_Skip = $scope.skiptisInitiated;
                $scope.loader_Submit = $scope.submitInitiated;
                var validation = true;
                var model = getOnlineHealthAssessmentModel();
                if ($scope.isKynPurchased) {
                    validation = validateDemographicInfo(model);
                }

                if (validation) {
                    healthAssessmentService.SaveHealthAssessmentQuestion(model).then(
                        function(result) {
                            $scope.loader_Skip = false;
                            $scope.loader_Submit = false;
                            $scope.isPosted = false;
                            $state.go('Confirmation', { guid: $stateParams.guid });

                        }, function() {
                            $scope.isPosted = false;
                            $scope.loader_Skip = false;
                            $scope.loader_Submit = false;
                        });
                } else {
                    $scope.loader_Skip = false;
                    $scope.loader_Submit = false;
                    $scope.isPosted = false;
                }
            };

            $scope.GetAssessmentGroupHeading = function (question) {

                var groupName = "";
                if (question.QuestionGroupId <= 1 || $scope.currentGroupId === question.QuestionGroupId) return "";

                if (typeof $scope.hafModel.HafTests === "undefined" || $scope.hafModel.HafTests == null || $scope.hafModel.HafTests.length <= 0) return "";

                $.each($scope.hafModel.HafTests, function (index, hafTest) {

                    var groupList = hafTest.HafQuestionGroups.filter(function (el) { return el.GroupId === question.QuestionGroupId; });

                    var group = $scope.GetFirstOrDefault(groupList);

                    if (group != null) {
                        $scope.currentGroupId = group.GroupId;
                        groupName = group.Name;
                        $scope.groupName = group.Name;
                    }
                });

                return groupName;
            };

            $scope.GetFirstOrDefault = function (model) {

                if (typeof model === 'undefined' || model === null || model.length <= 0)
                    return null;

                return model[0];
            };

            $scope.toolTipNext = "<div class=\'help-block\'>Click to view next questions</div>";
            $scope.toolTipPrev = "<div class=\'help-block\'>Click to view previous questions</div>";

            $scope.goToPreviousStep = function () {
                $scope.isPosted = true;
                $scope.loader_back = true;
                $state.go('ThankYou', { guid: $stateParams.guid });
            }

            function validateDemographicInfo(model) {
                
                if (Number(model.Height) <= 0) {
                    logger.showToasterError("Please enter Height.");
                    return false;
                }

                if (Number(model.Weight) <= 0) {
                    logger.showToasterError("Please enter Weight.");
                    return false;
                }
                
                if (Number(model.Race) <= 0) {
                    logger.showToasterError("Please select Race.");
                    return false;
                }

                if (Number(model.Waist) <= 0) {
                    logger.showToasterError("Please enter Waist.");
                    return false;
                }

                return true;
            }
            
            $scope.$on('$destroy', function () {
                $scope.movedtoOtherPage = true;
                if (modelPopupInstance != null) {
                    modelPopupInstance.close();
                }
            });
        }


    ]);
}());
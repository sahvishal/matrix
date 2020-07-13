(function () {
    'use strict';

    angular.module(OnlineConfiguration.moduleName).factory(OnlineConfiguration.services.healthAssessmentService, ['onlineHttpWrapper', CoreConfiguration.constants, function (onlineHttpWrapper, constants) {
        var healthAssessmentService = {};

        var displayControlType = constants.DisplayControlType;
        healthAssessmentService.GetHealthAssessmentQuestion = function (guid) {

            var endpoint = 'Users/OnlineHealthAssessment/GetHealthAssessmentQuestion?guid=' + guid;
            return onlineHttpWrapper.get(endpoint);
        };

        healthAssessmentService.SaveHealthAssessmentQuestion = function (data) {
            var endpoint = 'Medical/OnlineHealthAssessment/SaveHealthAssessment';
            
            return onlineHttpWrapper.post(endpoint, data);
        };

        healthAssessmentService.GetSelectedAnswerCount = function (selectedQuestions) {
            var parentQuestionOnly = selectedQuestions.filter(function (el) { return el.ParentQuestionId <= 0; });
            if (typeof parentQuestionOnly === 'undefined' || parentQuestionOnly === null || parentQuestionOnly.length <= 0) return 0;

            return parentQuestionOnly.length;
        };

        healthAssessmentService.HafQuestionList = function (hafModel) {
            var hafQuestionList = new Object();

            if (typeof hafModel === "undefined" || hafModel == null) {
                return hafQuestionList;
            }

            hafQuestionList.TotalHafQuestionCount = 0;
            hafQuestionList.TotalQuestionArray = new Array();
            hafQuestionList.selectedHafQuestions = new Array();

            var questionCount = 0;
            hafQuestionList.questionIdsWithOutControlType = new Array();

            $.each(hafModel.HafGroup.Questions, function (index, item) {

                if (item.ParentQuestionId <= 0) {
                    questionCount = questionCount + 1;
                }

                hafQuestionList.TotalQuestionArray.push(item);
            });

            hafQuestionList.TotalHafQuestionCount = questionCount;

            if ("undefined" === typeof hafModel.HafTests || hafModel.HafTests == null || hafModel.HafTests.length <= 0) {
                return hafQuestionList;
            }

            var hafTests = hafModel.HafTests;
            var groupId = 0;
            var isTestChanged = false;
            $.each(hafTests, function (index, hafTest) {
                isTestChanged = true;
                $.each(hafTest.HafQuestionGroups, function (ihafQuestionGroups, hafQuestionGroup) {
                    $.each(hafQuestionGroup.Questions, function (ihafQuestions, hafQuestion) {
                        if (hafQuestion.ParentQuestionId <= 0) {
                            questionCount = questionCount + 1;
                        }
                        if (isTestChanged) {
                            hafQuestion.TestName = hafTest.Name;
                            isTestChanged = false;
                        }

                        if (groupId != hafQuestion.QuestionGroupId) {
                            hafQuestion.GroupName = hafQuestionGroup.Name;
                            hafQuestion.Description = hafQuestionGroup.Description;
                            groupId = hafQuestion.QuestionGroupId;
                        }

                        hafQuestionList.TotalQuestionArray.push(hafQuestion);
                    });
                });
            });

            hafQuestionList.selectedHafQuestions = healthAssessmentService.HafSelectedQuestionArray(hafQuestionList.TotalQuestionArray);

            hafQuestionList.TotalHafQuestionCount = questionCount;

            return hafQuestionList;
        };

        healthAssessmentService.SetDependentQuestionEnableDisable = function (questionToCheck, totalQuestionArray) {
            var questionArray = new Array();
            $.each(questionToCheck, function (index, question) {
                if (typeof (question.showAsSeprateQuestion) != 'undefined' && question.showAsSeprateQuestion) {
                    healthAssessmentService.SetDependentQuestionEnableDisableForQuestion(question, totalQuestionArray);
                } else if (typeof (question.ChildQuestion) != 'undefined' && question.ChildQuestion != null && question.ChildQuestion.length > 0) {
                    $.each(question.ChildQuestion, function (i, value) {
                        healthAssessmentService.SetDependentQuestionEnableDisableForQuestion(value, totalQuestionArray);
                    });
                }

                questionArray.push(question);
            });

            return questionArray;
        };

        healthAssessmentService.SetDependentQuestionEnableDisableForQuestion = function (question, totalQuestionArray) {

            if (question.DependentQuestionId > 0) {

                var dependentQuestions = totalQuestionArray.filter(function (el) { return el.QuestoinId === question.DependentQuestionId; });

                if (typeof dependentQuestions !== 'undefined' && dependentQuestions !== null && dependentQuestions.length > 0) {
                    if (dependentQuestions[0].Answer != '' && dependentQuestions[0].Answer.toLowerCase() === question.DependencyRule.toLowerCase()) {
                        question.disable = false;
                    } else {
                        question.disable = true;
                        question.Answer = '';
                    }
                } else {
                    question.disable = false;
                }
            }
            else {
                question.disable = false;
                if (typeof question.ChildQuestion !== 'undefined' && question.ChildQuestion !== null && question.ChildQuestion.length > 0) {
                    question.ChildQuestion = healthAssessmentService.SetDependentQuestionEnableDisable(question.ChildQuestion, totalQuestionArray);
                }
            }

            return question;
        }

        healthAssessmentService.HafQuestionsPageWise = function (hafQuestionList, currentPage, pageSize) {

            var questionIndex = ((currentPage - 1) * pageSize) + 1;
            var lastIndex = (currentPage * pageSize);
            hafQuestionList = healthAssessmentService.SetDependentQuestionEnableDisable(hafQuestionList, hafQuestionList);
            var pagewiseQuestions = new Array();

            $.each(hafQuestionList, function (index, hafQuestion) {
                if ((index + 1) >= questionIndex && (index + 1) <= lastIndex) {
                    pagewiseQuestions.push(hafQuestion);
                }
            });

            return pagewiseQuestions;
        };

        healthAssessmentService.HafSelectedQuestionArray = function (totalQuestionArray) {
            var selectedHafQuestions = new Array();

            if (typeof totalQuestionArray === "undefined" || totalQuestionArray == null) {
                return selectedHafQuestions;
            }

            $.each(totalQuestionArray, function (index, item) {
                healthAssessmentService.HafSelectedQuestion(item, selectedHafQuestions);
            });

            return selectedHafQuestions;
        };

        healthAssessmentService.HafSelectedQuestion = function (question, selectedHafQuestions) {
            if (typeof question.Answer !== 'undefined' && question.Answer != null && question.Answer != '') {
                var ansObj = new Object();
                ansObj.Answer = question.Answer;
                ansObj.QuestionId = question.QuestoinId;
                ansObj.ParentQuestionId = question.ParentQuestionId;
                ansObj.DependentQuestionId = question.DependentQuestionId;

                selectedHafQuestions.push(ansObj);
            }
            if (question.ChildQuestion.length > 0) {
                $.each(question.ChildQuestion, function (index, childquestion) {
                    healthAssessmentService.HafSelectedQuestion(childquestion, selectedHafQuestions);
                });
            }
        }

        healthAssessmentService.GetAnsweredCount = function (totalQuestionArray) {
            if (typeof totalQuestionArray === 'undefined' || totalQuestionArray === null || totalQuestionArray.length <= 0) return 0;

            var totalAnsweredCount = 0;
            $.each(totalQuestionArray, function (index, question) {
                if ((typeof question.ControlValues != 'undefined' && question.ControlValues != null) || question.ControlValues > 0) {
                    if (question.ParentQuestionId <= 0 && question.ControlValues.length >= 0 && question.Answer != '') {
                        totalAnsweredCount = totalAnsweredCount + 1;
                    }
                } else {
                    if (question.ControlType == displayControlType.Radio) {
                        var isChecked = false;
                        $.each(question.ChildQuestion, function (i, childQuestion) {
                            if (childQuestion.Answer != '') {
                                isChecked = true;
                            }
                        });
                        if (isChecked) {
                            totalAnsweredCount = totalAnsweredCount + 1;
                        }
                    } else {
                        if (question.Answer != '') {
                            totalAnsweredCount = totalAnsweredCount + 1;
                        }
                    }
                }
            });

            return totalAnsweredCount;
        };

        healthAssessmentService.GetNumberOfDisabledParentQuestions = function (totalQuestionArray) {
            if (typeof totalQuestionArray === 'undefined' || totalQuestionArray === null || totalQuestionArray.length <= 0) return 0;

            var disabledQuestionsCount = 0;
            $.each(totalQuestionArray, function (index, question) {
                if (question.disable && question.DependentQuestionId > 0) {

                    var dependentQuestions = totalQuestionArray.filter(function (el) { return el.QuestoinId === question.DependentQuestionId; });

                    var dependentQuestion = getFirstOrDefault(dependentQuestions);
                    if (dependentQuestion != null && typeof (dependentQuestion.Answer) !== 'undefined' && dependentQuestion.Answer != '' && dependentQuestion.Answer !== question.DependencyRule) {
                        disabledQuestionsCount = disabledQuestionsCount + 1;
                    }
                }
            });

            return disabledQuestionsCount;
        };

        var getFirstOrDefault = function (model) {

            if (typeof model === 'undefined' || model === null || model.length <= 0)
                return null;

            return model[0];
        };
        healthAssessmentService.IsAllQuestionAnswered = function (totalQuestionArray) {
            if (typeof totalQuestionArray === 'undefined' || totalQuestionArray === null || totalQuestionArray.length <= 0) return true;

            var isChecked = true;
            $.each(totalQuestionArray, function (index, question) {
                if ((typeof question.ControlValues != 'undefined' && question.ControlValues != null) || question.ControlValues > 0) {
                    if (question.ParentQuestionId <= 0 && question.ControlValues.length >= 0 && question.Answer == '' && (typeof (question.disable) === 'undefined' || question.disable == false)) {
                        isChecked = false;
                    }
                } else {
                    if (question.ControlType == displayControlType.Radio) {
                        var isAnyChecked = false;
                        $.each(question.ChildQuestion, function (i, childQuestion) {
                            if (childQuestion.Answer != '') {
                                isAnyChecked = true;
                            }
                        });
                        if (!isAnyChecked) {
                            isChecked = isAnyChecked;
                        }
                    }
                }
            });

            return isChecked;
        }

        return healthAssessmentService;
    }]);

}());
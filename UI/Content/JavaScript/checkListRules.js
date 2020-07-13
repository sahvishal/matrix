
function GetGrouptAlias(questionId) {
    var obj = '';
    $.each(checkList, function (key, value) {
        if (Number(value.QuestionId) === questionId)
            obj = value.GroupAlias;
    });

    return obj;
}

function setChildTextBoxStatus(questionId) {

    var span = $("span[questionid='" + questionId + "']:visible");
    var checkBox = $(span).find("input[type='checkbox']");
    var childQuestions = $("span[parentId='" + questionId + "']");

    var inputBox = $(childQuestions).find("input[type='text']");

    if ($(checkBox).is(":checked")) {
        $(inputBox).removeAttr("disabled");
    } else {
        $(inputBox).val('');
        $(inputBox).attr("disabled", true);
    }
}

function checkParentQuestion(questionId, ischecked) {
    var span = $("span[questionid='" + questionId + "']:visible");
    if (span.length > 0) {
        var checkBox = $(span).find("input[type='checkbox']");
        $(checkBox).attr("checked", ischecked);
    }
}

function isQuestionIdChecked(questionId) {
    var span = $("span[questionid='" + questionId + "']:visible");
    if (span.length > 0)
        return $(span).find("input[type='checkbox']").is(":checked");
    return false;
}

function applyRules(qid) {

    var isAnySelected = false;
    var count = 0;
    var groupAlias = GetGrouptAlias(qid);

    if (groupAlias == 'biometricandminicogsection') {
        var drsDependency = [14, 15, 16, 246, 247]; // for 13
        if (drsDependency.indexOf(qid) > -1) {
            checkParentQuestion(13, false);

            $.each(drsDependency, function (index, item) {
                // debugger;
                if (isQuestionIdChecked(item))
                    checkParentQuestion(13, true);
            });
        }
    }

    if (qid == 11) {
        setChildTextBoxStatus(11);
    }

    if (qid === 17) {
        setChildTextBoxStatus(17);
    }

    if (groupAlias == 'takehomekitsection') {
        var umaDependency = [43, 44, 45, 46]; // for 41
        if (umaDependency.indexOf(qid) > -1) {
            checkParentQuestion(41, false);

            $.each(umaDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(41, true);
            });
        }


        var iFobtDependency = [49, 50, 51, 268]; // for 47
        var ifbotpquestion47 = $("span[questionid='47']:visible");
        if (ifbotpquestion47.length > 0) {
            iFobtDependency = [49, 50, 51, 268]; // for 47
            if (iFobtDependency.indexOf(qid) > -1) {
                isAnySelected = false;
                checkParentQuestion(47, false);
                $.each(iFobtDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        checkParentQuestion(47, true);
                });
            }
        }

        var ifbotpquestion418 = $("span[questionid='418']:visible");
        if (ifbotpquestion418.length > 0) {
            //debugger;
            iFobtDependency = [419, 420, 421]; // for 418
            if (iFobtDependency.indexOf(qid) > -1) {
                checkParentQuestion(418, true);
                //debugger;
                // isAnySelected = false;//
                $.each(iFobtDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        checkParentQuestion(418, false);
                });
            }
        }
    }
    //groupId == 26
    if (groupAlias == 'takehomekitsectionv3') {
        var umaDependency = [43, 453, 45, 46]; // for 41
        if (umaDependency.indexOf(qid) > -1) {
            checkParentQuestion(41, false);

            $.each(umaDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(41, true);
            });
        }


        var iFobtDependency = [455, 456, 457]; // for 454
        var ifbotpquestion47 = $("span[questionid='454']:visible");
        if (ifbotpquestion47.length > 0) {
            iFobtDependency = [455, 456, 457]; // for 454
            if (iFobtDependency.indexOf(qid) > -1) {
                checkParentQuestion(454, true);
                $.each(iFobtDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        checkParentQuestion(454, false);
                });
            }
        }
    }
    //groupId == 4
    if (groupAlias == 'respiratoryexamsection') {
        // for spirometry    64
        var orderSpiro = [66, 68, 434, 435, 474];

        if (orderSpiro.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(64, false);

            $.each(orderSpiro, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(64, true);
            });
        }
    }
    //groupId == 16
    if (groupAlias == 'respiratoryexamsectionv2') {
        // for spirometry    373

        var orderSpirov1 = [375, 377];

        if (orderSpirov1.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(373, false);

            $.each(orderSpirov1, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(373, true);
            });
        }
    }
    //groupId == 23
    if (groupAlias == 'respiratoryexamsectionv3') {
        // for spirometry    441

        var orderSpirov3 = [447, 435, 68];

        if (orderSpirov3.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(441, false);

            $.each(orderSpirov3, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(441, true);
            });
        }
    }
    //groupId == 12
    if (groupAlias == 'ekgv2') {
        // for Order EKG      313
        var ekgDependency = [417, 314, 315, 316, 317, 318];
        if (ekgDependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(313, false);

            $.each(ekgDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(313, true);
            });
        }
    }
    //groupId == 5
    if (groupAlias == 'cardiovascularexamsection') {
        // for 77
        var echoClaimDependency = [79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 436];
        var echoMedicaDependency = [94, 95, 96, 97];
        var echoSymptomDependency = [99, 100, 101, 102, 103, 104, 105, 106, 107, 108];
        var echoSignsDependency = [110, 111, 112, 113, 114, 115, 116, 117, 118, 119];
        var echoCombiDependency = [121, 122, 123, 124, 125, 126, 127];

        if (echoClaimDependency.indexOf(qid) > -1 || echoMedicaDependency.indexOf(qid) > -1 || echoSymptomDependency.indexOf(qid) > -1 || echoSignsDependency.indexOf(qid) > -1 || echoCombiDependency.indexOf(qid) > -1) {
            count = 0;
            isAnySelected = false;
            checkParentQuestion(77, false);

            $.each(echoClaimDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected)
                count = count + 1;
            isAnySelected = false;

            $.each(echoMedicaDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });
            if (isAnySelected)
                count = count + 1;
            isAnySelected = false;

            $.each(echoSymptomDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });
            if (isAnySelected)
                count = count + 1;
            isAnySelected = false;

            $.each(echoSignsDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });
            if (isAnySelected)
                count = count + 1;
            isAnySelected = false;

            $.each(echoCombiDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected)
                count = count + 1;
            isAnySelected = false;

            if (count >= 2) {
                checkParentQuestion(77, true);
            }
        }
    }
    //groupId == 11
    if (groupAlias == 'cardiovascularexamsectionv2') {
        // for Order EKG      281
        var echoADependency = [283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294];
        var echoBDependency = [296, 297, 298];
        var echoCDependency = [300, 301, 302, 303, 304, 305, 306, 307];
        if (echoADependency.indexOf(qid) > -1 || echoBDependency.indexOf(qid) > -1 || echoCDependency.indexOf(qid) > -1) {

            isAnySelected = false;
            var isAnySelectedC = false;
            checkParentQuestion(281, false);

            $.each(echoADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });
            if (isAnySelected == false) {
                $.each(echoBDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        isAnySelected = true;
                });
            }

            if (isAnySelected) {
                $.each(echoCDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        isAnySelectedC = true;
                });
            }

            if (isAnySelectedC) {
                checkParentQuestion(281, true);
            }

        }
    }
    //groupId == 24
    if (groupAlias == 'cardiovascularexamsectionv3') {
        // for Order EKG      443
        var echoClaimDependency = [79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 436];
        var echoMedicaDependency = [94, 95, 97];
        var echoSymptomDependency = [99, 100, 101, 102, 103, 104, 105, 106, 107, 108];
        var echoSignsDependency = [110, 111, 112, 113, 114, 115, 116, 117, 118, 119];
        var echoCombiDependency = [122, 125, 126, 444];

        if (echoClaimDependency.indexOf(qid) > -1 || echoMedicaDependency.indexOf(qid) > -1 || echoSymptomDependency.indexOf(qid) > -1 || echoSignsDependency.indexOf(qid) > -1 || echoCombiDependency.indexOf(qid) > -1) {

            checkParentQuestion(443, false);

            $.each(echoClaimDependency, function (index, item) {
                if (isQuestionIdChecked(item)) {
                    checkParentQuestion(443, true);
                    return;
                }
            });

            $.each(echoMedicaDependency, function (index, item) {
                if (isQuestionIdChecked(item)) {
                    checkParentQuestion(443, true);
                    return;
                }
            });

            $.each(echoSymptomDependency, function (index, item) {
                if (isQuestionIdChecked(item)) {
                    checkParentQuestion(443, true);
                    return;
                }
            });

            $.each(echoSignsDependency, function (index, item) {
                if (isQuestionIdChecked(item)) {
                    checkParentQuestion(443, true);
                    return;
                }
            });

            $.each(echoCombiDependency, function (index, item) {
                if (isQuestionIdChecked(item)) {
                    checkParentQuestion(443, true);
                    return;
                }
            });
        }
    }
    //groupId == 7
    if (groupAlias == 'ekgv1') {
        // for 133 EKG
        var ekgColADependency = [135, 136, 137, 138, 139, 445];
        var ekgColBDependency = [142, 143, 144, 145];
        if (ekgColADependency.indexOf(qid) > -1 || ekgColBDependency.indexOf(qid) > -1) {
            count = 0;
            isAnySelected = false;
            checkParentQuestion(133, false);

            $.each(ekgColADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });
            $.each(ekgColBDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    count = count + 1;
            });

            if (isAnySelected || count >= 2) {
                checkParentQuestion(133, true);
            }
        }
    }
    //groupId == 8
    if (groupAlias == 'abiflochckleadv1') {
        // for Order ABI/Flochec/LEAD      151
        var abiColADependency = [153, 154, 437, 446];
        var abiColBDependency = [157, 158, 159, 160];
        if (abiColADependency.indexOf(qid) > -1 || abiColBDependency.indexOf(qid) > -1) {
            count = 0;
            isAnySelected = false;
            checkParentQuestion(151, false);
            $.each(abiColADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            $.each(abiColBDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    count = count + 1;
            });

            if (isAnySelected || count >= 2) {
                checkParentQuestion(151, true);
            }
        }
    }
    //groupId == 13
    if (groupAlias == 'abileadv2') {
        // for Order LEAD/ABI  324

        var leadDependency = [325, 326, 327, 328, 329, 330];
        if (leadDependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(324, false);

            $.each(leadDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected == true) {
                checkParentQuestion(324, true);
            }
        }
    }
    //groupId == 9
    if (groupAlias == 'aaav1') {
        // for AAA  Male    166
        var aaaColADependency = [169, 438, 452];
        var aaaColBDependency = [172, 173, 174, 175, 176, 177];
        if (aaaColADependency.indexOf(qid) > -1 || aaaColBDependency.indexOf(qid) > -1) {
            count = 0;

            isAnySelected = false;
            checkParentQuestion(166, false);

            $.each(aaaColADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected == false) {
                $.each(aaaColBDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        isAnySelected = true;
                });
            }

            if (isAnySelected) {
                checkParentQuestion(166, true);
            }
        }
    }
    //groupId == 9
    if (groupAlias == 'aaav1') {
        // for AAA Female     183
        var aaafColADependency = [186, 439];
        var aaafColBDependency = [189, 190, 191, 192, 193, 194];
        if (aaafColADependency.indexOf(qid) > -1 || aaafColBDependency.indexOf(qid) > -1) {

            isAnySelected = false;
            var isAnyBSelected = false;
            checkParentQuestion(183, false);

            $.each(aaafColADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            $.each(aaafColBDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnyBSelected = true;
            });

            if (isAnySelected && isAnyBSelected) {
                checkParentQuestion(183, true);
            }
        }
    }
    //groupId == 25
    if (groupAlias == 'aaav3') {
        // for AAA Female     448
        var aaav3ColADependency = [438, 452];
        var aaav3ColBDependency = [189, 190, 191, 192, 193, 194];
        if (aaav3ColADependency.indexOf(qid) > -1 || aaav3ColBDependency.indexOf(qid) > -1) {

            isAnySelected = false;
            checkParentQuestion(448, false);

            $.each(aaav3ColADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected === false) {
                $.each(aaav3ColBDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        isAnySelected = true;
                });
            }

            if (isAnySelected) {
                checkParentQuestion(448, true);
            }
        }
    }

    //groupId == 14
    if (groupAlias == 'aaav2') {
        // for AAA  Male    336
        var aaaDependencyv1 = [338];

        if (aaaDependencyv1.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(336, false);

            $.each(aaaDependencyv1, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(338, true);
            }
        }
    }

    if (groupAlias == 'aaav2') {
        // for AAA Female     344
        var aaafColAfDependencyv1 = [347];
        var aaafColBfDependencyv1 = [350, 351, 352, 353, 354];
        if (aaafColADependency.indexOf(qid) > -1 || aaafColBDependency.indexOf(qid) > -1) {

            isAnySelected = false;
            var isAnyBSelectedv1 = false;
            checkParentQuestion(344, false);

            $.each(aaafColAfDependencyv1, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            $.each(aaafColBfDependencyv1, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnyBSelectedv1 = true;
            });

            if (isAnySelected && isAnyBSelectedv1) {
                checkParentQuestion(344, true);
            }
        }
    }
    //groupId == 19
    var isAllSelected = false;
    if (groupAlias == 'aaaultrasound') {
        // for aaa male   -Martins Point-   398
        var aaaColADependencyv2 = [399, 400];
        if ($("span[questionId='432']:visible")) {
            aaaColADependencyv2 = [399, 400, 432];
        }
        var aaaColBDependencyv2 = [401, 402, 403, 404, 405];
        if (aaaColADependencyv2.indexOf(qid) > -1 || aaaColBDependencyv2.indexOf(qid) > -1) {
            isAllSelected = true;
            checkParentQuestion(398, false);
            $.each(aaaColADependencyv2, function (index, item) {
                if (isQuestionIdChecked(item) == false)
                    isAllSelected = false;
            });

            isAnySelected = false;
            $.each(aaaColBDependencyv2, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected && isAllSelected) {
                checkParentQuestion(398, true);
            }
        }

    }
    //groupId == 19
    if (groupAlias == 'aaaultrasound') {

        var aaafColADependencyv2 = [407, 408];
        if ($("span[questionId='433']:visible")) {
            aaafColADependencyv2 = [407, 408, 433];
        }
        var aaafColBDependencyv2 = [350, 351, 352, 353, 354];
        if (aaafColADependencyv2.indexOf(qid) > -1 || aaafColBDependencyv2.indexOf(qid) > -1) {

            isAllSelected = true;
            checkParentQuestion(406, false);
            $.each(aaafColADependencyv2, function (index, item) {
                if (isQuestionIdChecked(item) == false)
                    isAllSelected = false;
            });

            isAnySelected = false;
            $.each(aaafColBDependencyv2, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected && isAllSelected) {
                checkParentQuestion(406, true);
            }
        }

    }
    //groupId == 20
    if (groupAlias == 'monofilament') {
        isAnySelected = false;
        var moonofilament = [410, 411]; //for 409

        if (moonofilament.indexOf(qid) > -1) {
            checkParentQuestion(409, false);
            $.each(moonofilament, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(409, true);
            }
        }
    }
    //groupId == 22
    if (groupAlias == 'dpnorperformmonofilament') {
        isAnySelected = false;
        var dpnMonofilament = [424, 425, 440]; //for DPN or MONOFILAMENT 423
        if (dpnMonofilament.indexOf(qid) > -1) {

            checkParentQuestion(423, false);
            $.each(dpnMonofilament, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(423, true);
            }
        }
    }
    //groupId == 10
    if (groupAlias == 'carotidv1') {
        // for Carotid      200
        var carotid = [202, 204]; //for 423

        if (carotid.indexOf(qid) > -1) {
            checkParentQuestion(200, false);

            $.each(carotid, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(200, true);
            }
        }
    }
    //groupId == 18
    if (groupAlias == 'biometricandminicogsectionv2') {
        // for Hemoglobin A1c:   -Martins Point-   11
        var hemoglobin = [245, 396];

        if (hemoglobin.indexOf(qid) > -1) {
            checkParentQuestion(11, false);

            $.each(hemoglobin, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(11, true);
            }

            setChildTextBoxStatus(11);
        }


        var drsDependencyv1 = [246, 247]; // for 13
        if (drsDependencyv1.indexOf(qid) > -1) {
            checkParentQuestion(13, false);

            $.each(drsDependencyv1, function (index, item) {
                // debugger;
                if (isQuestionIdChecked(item))
                    checkParentQuestion(13, true);
            });
        }
        // for lipid-   17
        isAnySelected = false;

        var lipidTotalQuestion = [251, 252, 253, 254, 255, 256, 248, 431];
        if (lipidTotalQuestion.indexOf(qid) > -1) {
            checkParentQuestion(17, false);

            var lipidDependency = [251, 252, 253, 254, 255, 256, 431];
            if (lipidDependency.indexOf(qid) > -1) {
                checkParentQuestion(397, false);
                $.each(lipidDependency, function (index, item) {
                    if (isQuestionIdChecked(item)) {
                        isAnySelected = true;
                        checkParentQuestion(397, true);
                    }
                });
            }

            if (isQuestionIdChecked(248) || (isQuestionIdChecked(397) != null && isAnySelected)) {
                checkParentQuestion(17, true);
            }

            setChildTextBoxStatus(17);
        }


    }
    ///groupId == 21
    if (groupAlias == 'takehomekitsectionv2') {
        // for Urine Micro-albumin - Martins Point - 41
        var lipidDependencyv2 = [43];
        if (lipidDependencyv2.indexOf(qid) > -1) {
            checkParentQuestion(41, false);

            $.each(lipidDependencyv2, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(41, true);
            }
        }

        // for iFOBT - Martins Point - 47
        var ifobtDependencyv2 = [268, 675];
        if (ifobtDependencyv2.indexOf(qid) > -1) {
            checkParentQuestion(47, false);

            $.each(ifobtDependencyv2, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(47, true);
            }

        }
    }

    ///groupId == 47
    if (groupAlias == 'orderquantifloabi') {

        // for ORDER QUANTIFLO/ABI - 47
        var quantifloabiDependencyv2 = [669, 670];
        if (quantifloabiDependencyv2.indexOf(qid) > -1) {
            checkParentQuestion(668, false);

            $.each(quantifloabiDependencyv2, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(668, true);
            }
        }
    }




    //groupId == 27
    if (groupAlias == 'ekgv3') {
        // for 475 EKG
        var ekgv3Dependency = [135, 136, 137, 138, 139, 142, 143, 144, 145];
        if (ekgv3Dependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(475, false);

            $.each(ekgv3Dependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(475, true);
            });
        }
    }

    //groupId == 28
    if (groupAlias == 'abiflochckleadv2') {
        // for 477 abiflochckleadv2
        var abiflochckleadv2Dependency = [478];
        if (abiflochckleadv2Dependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(477, false);

            $.each(abiflochckleadv2Dependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(477, true);
            });
        }
    }

    //groupId == 35
    if (groupAlias == 'aaav4') {
        // for aaav4  Male    166
        var aaav4ColADependency = [169, 438, 452];
        var aaav4ColBDependency = [172, 173, 174, 175, 176, 177];
        if (aaav4ColADependency.indexOf(qid) > -1 || aaav4ColBDependency.indexOf(qid) > -1) {
            count = 0;

            isAnySelected = false;
            checkParentQuestion(166, false);

            $.each(aaav4ColADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected == false) {
                $.each(aaav4ColBDependency, function (index, item) {
                    if (isQuestionIdChecked(item))
                        isAnySelected = true;
                });
            }

            if (isAnySelected) {
                checkParentQuestion(166, true);
            }
        }
    }
    //groupId == 35
    if (groupAlias == 'aaav4') {
        // for aaav4 Female     479
        var aaav4fColADependency = [186, 439];
        var aaav4fColBDependency = [189, 190, 191, 192, 193, 194];
        if (aaav4fColADependency.indexOf(qid) > -1 || aaav4fColBDependency.indexOf(qid) > -1) {

            isAnySelected = false;
            checkParentQuestion(479, false);

            $.each(aaav4fColADependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            $.each(aaav4fColBDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(479, true);
            }
        }
    }

    //groupId == 29
    if (groupAlias == 'dpnorperformmonofilamentv2') {
        // for 423 dpnorperformmonofilamentv2
        var dpnorperformmonofilamentv2Dependency = [480];
        if (dpnorperformmonofilamentv2Dependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(423, false);

            $.each(dpnorperformmonofilamentv2Dependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(423, true);
            });
        }
    }

    //groupId == 31
    if (groupAlias == 'osteoporosisbonedensityscreening') {
        // for 492 osteoporosisbonedensityscreening Male
        var osteoporosisMaleDependency = [493, 529];
        var questionDependecy = [494, 495, 496, 497, 498, 499];

        if (osteoporosisMaleDependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(492, false);

            $.each(osteoporosisMaleDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(492, true);
            });

            if (qid === 493) {
                var disabledValue = isQuestionIdChecked(qid)
                disableQuestionIdCheckbox(529, disabledValue);
                $.each(questionDependecy, function (index, item) {
                    disableQuestionIdCheckbox(item, disabledValue);
                });
            }
            else if (qid === 529) {
                disableQuestionIdCheckbox(493, isQuestionIdChecked(qid));
            }
            if (!isQuestionIdChecked(529) || qid === 493) {
                $.each(questionDependecy, function (index, item) {
                    var span = $("span[questionid='" + item + "']:visible");
                    if (span.length > 0) {
                        $(span).find("input[type='checkbox']").attr('checked', '');
                    }
                });
            }
        }
        if (questionDependecy.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(529, false);
            checkParentQuestion(492, false);
            var isDisable = false;
            $.each(questionDependecy, function (index, item) {
                if (isQuestionIdChecked(item)) {
                    checkParentQuestion(529, true);
                    checkParentQuestion(492, true);
                    isDisable = true;
                }
            });

            disableQuestionIdCheckbox(493, isDisable);
        }
    }

    //groupId == 31
    if (groupAlias == 'osteoporosisbonedensityscreening') {
        // for 485 osteoporosisbonedensityscreening Female
        var osteoporosisFemaleDependency = [486];
        if (osteoporosisFemaleDependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(485, false);

            $.each(osteoporosisFemaleDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(485, true);
            });
        }
    }

    //groupId == 32
    if (groupAlias == 'mammogram') {
        // for 505 mammogram Female
        var mammogramDependency = [506, 507, 508];
        if (mammogramDependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(505, false);

            $.each(mammogramDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(505, true);
            });
        }
    }

    //groupId == 34
    if (groupAlias == 'ra') {
        // for 524 ra
        var raDependency = [525, 526, 527, 528];
        if (raDependency.indexOf(qid) > -1) {
            isAnySelected = false;
            checkParentQuestion(524, false);

            $.each(raDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(524, true);
            });
        }
    }
    //groupAlias == biometricandminicogsectionv3
    if (groupAlias == 'biometricandminicogsectionv3') {
        // for Hemoglobin A1c:   11
        var hemoglobinv3 = [12];

        if (hemoglobinv3.indexOf(qid) > -1) {
            checkParentQuestion(11, false);

            $.each(hemoglobinv3, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });
            if (isAnySelected) {
                checkParentQuestion(11, true);
            }
            setChildTextBoxStatus(11);
        }

        var diabeticOverweightObese = [533, 650, 651, 652];
        if (diabeticOverweightObese.indexOf(qid) > -1) {
            checkParentQuestion(532, false);

            $.each(diabeticOverweightObese, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(532, true);
            }
            setChildTextBoxStatus(532);
        }

        var drsDependencyv3 = [534, 535]; // for 13
        if (drsDependencyv3.indexOf(qid) > -1) {
            checkParentQuestion(13, false);

            $.each(drsDependencyv3, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(13, true);
            });
        }
        // for lipid-   537
        isAnySelected = false;

        var performLipidPanel = [538, 692, 693, 694, 695, 696, 697];

        if (performLipidPanel.indexOf(qid) > -1) {
            checkParentQuestion(537, false);

            $.each(performLipidPanel, function (index, item) {
                if (isQuestionIdChecked(item)) {
                    isAnySelected = true;
                    checkParentQuestion(537, true);
                }
            });
        }
        setChildTextBoxStatus(537);
    }

    //groupAlias == takehomekitsectionv4
    if (groupAlias == 'takehomekitsectionv4') {
        var umaDependency = [43, 45, 539, 540, 653];
        if (umaDependency.indexOf(qid) > -1) {
            checkParentQuestion(41, false);
            $.each(umaDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(41, true);
            });
        }

        var iFobtDependency = [542, 543, 544, 545, 654];
        if (iFobtDependency.indexOf(qid) > -1) {
            if (patientAge != '0' && patientAge >= '50' && patientAge <= '75')
            { checkParentQuestion(541, true); }

            $.each(iFobtDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(541, false);
            });
        }
    }

    //groupAlias == respiratoryexamsectionv4
    if (groupAlias == 'respiratoryexamsectionv4') {
        var spirometryDependency = [550, 551, 552, 553, 554, 556, 557, 558, 559, 655, 656];
        if (spirometryDependency.indexOf(qid) > -1) {
            checkParentQuestion(64, false);
            $.each(spirometryDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(64, true);
            });
        }
    }

    //groupAlias == cardiovascularexamsectionv4
    if (groupAlias == 'cardiovascularexamsectionv4') {
        var cardiovascularDependency = [564, 565, 566, 567, 568, 569, 572, 573, 574, 575, 576, 577, 657, 658];
        if (cardiovascularDependency.indexOf(qid) > -1) {
            checkParentQuestion(561, false);
            $.each(cardiovascularDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(561, true);
            });
        }
    }

    //groupAlias == ekgv4
    if (groupAlias == 'ekgv4') {
        var ekgDependency = [580, 581, 582, 583, 585, 586, 587, 588, 659, 660];
        if (ekgDependency.indexOf(qid) > -1) {
            checkParentQuestion(579, false);
            $.each(ekgDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(579, true);
            });
        }
    }

    //groupAlias == quantaflolead
    if (groupAlias == 'quantaflolead') {
        var quantafloleadDependency = [592, 593, 594, 595, 596, 597, 599, 600, 601, 602, 603, 604, 661, 662];
        if (quantafloleadDependency.indexOf(qid) > -1) {
            checkParentQuestion(590, false);
            $.each(quantafloleadDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(590, true);
            });
        }
    }

    //groupAlias == aaav5
    if (groupAlias == 'aaav5') {
        var aaaDependency = [611, 612, 613, 614, 616, 617, 663, 664];
        if (aaaDependency.indexOf(qid) > -1) {
            checkParentQuestion(609, false);
            $.each(aaaDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(609, true);
            });
        }
    }

    //groupAlias == bonedensitometry
    if (groupAlias == 'bonedensitometry') {
        var bonedensitometryDependency = [623, 625, 627, 665];
        if (bonedensitometryDependency.indexOf(qid) > -1) {
            checkParentQuestion(622, false);
            $.each(bonedensitometryDependency, function (index, item) {
                if (isQuestionIdChecked(item) || isQuestionIdChecked(624) || isQuestionIdChecked(628)) {
                    checkParentQuestion(622, true);
                }
            });
        }

        var isParentChecked = false;
        $.each(bonedensitometryDependency, function (index, item) {
            if (isQuestionIdChecked(item)) {
                isParentChecked = true;
                return;
            }
        });

        var postMenopausalWoman = [676, 677, 678, 679, 680, 681, 682, 683, 684, 685];
        if (postMenopausalWoman.indexOf(qid) > -1) {
            checkParentQuestion(624, false);
            checkParentQuestion(622, false);

            $.each(postMenopausalWoman, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(624, true);
                checkParentQuestion(622, true);
            }
            if (isParentChecked)
                checkParentQuestion(622, true);

            setChildTextBoxStatus(624);
        }

        var youngerManRisk = [686, 687, 688, 689, 690, 691];
        if (youngerManRisk.indexOf(qid) > -1) {
            checkParentQuestion(628, false);
            checkParentQuestion(622, false);

            $.each(youngerManRisk, function (index, item) {
                if (isQuestionIdChecked(item))
                    isAnySelected = true;
            });

            if (isAnySelected) {
                checkParentQuestion(628, true);
                checkParentQuestion(622, true);
            }
            if (isParentChecked)
                checkParentQuestion(622, true);

            setChildTextBoxStatus(628);
        }

    }

    //groupAlias == dpnorperformmonofilamentv3
    if (groupAlias == 'dpnorperformmonofilamentv3') {
        var dpnDependency = [634, 635, 666];
        if (dpnDependency.indexOf(qid) > -1) {
            checkParentQuestion(633, false);
            $.each(dpnDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(633, true);
            });
        }
    }

    //groupAlias == mammography
    if (groupAlias == 'mammography') {
        var mammographyDependency = [642, 643, 667];
        if (mammographyDependency.indexOf(qid) > -1) {
            checkParentQuestion(640, false);
            $.each(mammographyDependency, function (index, item) {
                if (isQuestionIdChecked(item))
                    checkParentQuestion(640, true);
            });
        }
    }
}

function disableQuestionIdCheckbox(questionId, disabled) {
    var span = $("span[questionid='" + questionId + "']:visible");
    if (span.length > 0) {
        $(span).find("input[type='checkbox']").attr('disabled', disabled);
        $(span).find("input[type='checkbox']").attr('checked', '');
    }
}
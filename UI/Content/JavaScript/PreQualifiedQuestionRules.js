
var isRedirectNonMammo ;
var disqualifiedTestId = 29;
var preQualificationPopShow = true;

function CheckIsEligibleForTest(data, isAllowNonMammoPatients) {
    var preQualifiedCounter = 0;
    var queCount = 0;
    var testId;
    var disqualifiedquestion = '';

    var questionIdWithNoAnswer = [5, 6];
    var dependentTestId = [7, 8];
    var questionIdWithYesAnswer = [];
    var questionIdWithYesAnswerRedirectNonMemmoEvent = [6];
    isRedirectNonMammo = 'No';
    $(data.split('|')).each(function (index, item) {
        var que = item.split(',')[0];
        var answer = item.split(',')[1];
        testId = item.split(',')[2];
        queCount++;
        
        if (questionIdWithNoAnswer.indexOf(parseInt(que)) > -1) {
            if (answer == "No") {
                preQualifiedCounter++;
            }
            else {
                if (disqualifiedquestion != '') {
                    disqualifiedquestion += '|' + testId + ',' + que + ',' + answer;
                }
                else {
                    disqualifiedquestion += testId + ',' + que + ',' + answer;
                }
            }
        }

        if (questionIdWithYesAnswer.indexOf(parseInt(que)) > -1) {
            if (answer == "Yes") {
                preQualifiedCounter++;
            }
            else {
                if (disqualifiedquestion != '') {
                    disqualifiedquestion += '|' + testId + ',' + que + ',' + answer;
                }
                else {
                    disqualifiedquestion += testId + ',' + que + ',' + answer;
                }
            }
        }
        if (dependentTestId.indexOf(parseInt(que)) > -1) {
            if (disqualifiedquestion != '') {
                disqualifiedquestion += '|' + testId + ',' + que + ',' + answer;
            }
            else {
                disqualifiedquestion += testId + ',' + que + ',' + answer;
            }
        }
        if (questionIdWithYesAnswerRedirectNonMemmoEvent.indexOf(parseInt(que)) > -1) {
           
            if (answer == "Yes" && isAllowNonMammoPatients != "True") {
                isRedirectNonMammo = 'Yes';
            }
            else if (answer == "Yes") {
                isRedirectNonMammo = 'Continue';
            }
        }

    });

    if (preQualifiedCounter < queCount) {
        return disqualifiedquestion;
    }
    else {
        return '';
    }
}



USE [$(dbName)]
Go

--Echocardiogram
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where TestId in (4,47) and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions = 1, TestId = 54 where TestId in (4,47) and IsActive=1
	
	update TblClinicalTestQualificationCriteria set TestId = 54 where TestId in (4,47)
END

--Stroke/Carotid
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where TestId in (1,48) and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions = 1, TestId = 56 where TestId in (1,48) and IsActive=1
	
	update TblClinicalTestQualificationCriteria set TestId = 56 where TestId in (1,48)
END

--Stroke/Carotid
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where TestId in (10,49) and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions = 1, TestId = 55 where TestId in (10,49) and IsActive=1
	
	update TblClinicalTestQualificationCriteria set TestId = 55 where TestId in (10,49)
END
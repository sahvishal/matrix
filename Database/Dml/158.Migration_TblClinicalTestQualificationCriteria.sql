USE [$(dbName)]
Go

--Osteoporosis
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where TestId in (9) and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions = 1, TestId = 60 where TestId in (9) and IsActive=1
	
	update TblClinicalTestQualificationCriteria set TestId = 60 where TestId in (9)
END

--PAD/ABI
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where TestId in (2) and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions = 1, TestId = 53 where TestId in (2) and IsActive=1
	
	update TblClinicalTestQualificationCriteria set TestId = 53 where TestId in (2)
END

--Spiro
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where TestId in (36) and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions = 1, TestId = 52 where TestId in (36) and IsActive=1
	
	update TblClinicalTestQualificationCriteria set TestId = 52 where TestId in (36)
END
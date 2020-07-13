USE [$(dbName)]
Go

--upddate with HCP Echo
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'Echocardiogram' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=47 where Name = 'Echocardiogram' and IsActive=1
END

--upddate with HCP Carotid
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'Carotid' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=48 where Name = 'Carotid' and IsActive=1
END

--upddate with HCP AAA
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'AAA' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=49 where Name = 'AAA' and IsActive=1
END


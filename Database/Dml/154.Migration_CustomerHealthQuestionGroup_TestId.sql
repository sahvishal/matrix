USE [$(dbName)]
Go

--Osteoporosis
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'Bone Density Ultrasound' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=9 where Name = 'Bone Density Ultrasound' and IsActive=1
END

--PAD
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'A/B Index' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=2 where Name = 'A/B Index' and IsActive=1
END

--AAA
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'AAA' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=10 where Name = 'AAA' and IsActive=1
END

--
IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'Carotid' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=1 where Name = 'Carotid' and IsActive=1
END

IF EXISTS (Select CustomerHealthQuestionGroupID from TblCustomerHealthQuestionGroup where Name = 'Echocardiogram' and IsActive=1)
BEGIN
	update TblCustomerHealthQuestionGroup set IsClinicalQuestions=1,TestId=4 where Name = 'Echocardiogram' and IsActive=1
END
USE [$(dbname)]
GO

DECLARE @Groupalias VARCHAR(500), @groupQuestionId BIGINT

SET @Groupalias ='TAKEHOMEKITSECTION'

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(418, 'Order iFOBT for ALL patients that have NOT had ANY of the following:', 322, 184, 'Yes,No', ',', 418)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 418, null, 1)


INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(419, 'Colonoscopy in the last 10 years', 322, 184, 'Yes,No', ',', 419)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 419, 418, 1)


INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(420, 'Barium enema or sigmoidoscopy in the last 5 years', 322, 184, 'Yes,No', ',', 420)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 420, 418, 1)


INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(421, 'FOBT testing this year', 322, 184, 'Yes,No', ',', 421)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 421, 418, 1)



SET @Groupalias ='BIOMETRICANDMINICOGSECTION'

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(422, 'Additional Testing Indicated:', 321, 184, 'Yes,No', ',', 422)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 422, null, 1)


Update TblCheckListQuestion set Question = 'Spiro not completed' where id = 72

Update TblCheckListQuestion set Question = 'CAD/CVD' where id = 80

Update TblCheckListQuestion set Question = 'Enlarged heart/Heart failure/diastolic dys/decreased EF' where id = 87

Update TblCheckListQuestion set Question = 'Hypertrophic/Idiopathic cardiomyopathy' where id = 89

Update TblCheckListQuestion set Question = 'Hypertensive/ Infiltrative heart disease' where id = 90

Update TblCheckListQuestion set Question = 'Peripheral Edema' where id = 108

Update TblCheckListQuestion set Question = 'Order EKG if the patient has met at least 1 criteria from Column A or 2 criteria from Column B.' where id = 133

Update TblCheckListQuestion set Question = 'Order ABI/Flochec/LEAD if the patient has met at least 1 criteria from Column A or 2 criteria from Column B.' where id = 151

Update TblCheckListQuestion set Question = 'Current/former smoker 65 to 75 years old' where id = 169

Update TblCheckListQuestion set Question = 'Current/former smoker 65 to 75 years old' where id = 186

Update TblCheckListQuestion set Question = 'Pulmonary HTN' where id = 84

Update TblCheckListQuestion set Question = 'Order Spirometry if the patient has met at least 1 criteria from column A or Column B.' where id = 64

SET @Groupalias ='DPNORPERFORMMONOFILAMENT'

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias

 IF NOT EXISTS (SELECT Id FROM TblCheckListGroup WHERE Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		VALUES( 'DPN or PERFORM MONOFILAMENT','DPN or PERFORM MONOFILAMENT', 319,null, @Groupalias , 1)

		SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias
 END 

 
INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(423, 'ORDER DPN or PERFORM MONOFILAMENT if the patient meets ANY of the criteria from below.', 322, 184, 'Yes,No', ',', 423)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 423, null, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(424, 'Diabetes', 322, 184, 'Yes,No', ',', 424)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 424, 423, 1)


INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(425, 'Any patient complaining of numbness, tingling, or burning sensation in hands or feet, regardless of diabetes status.', 322, 184, 'Yes,No', ',', 425)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 425, 423, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(426, 'DPN or MONOFILAMENT not completed:', 321, 184, '', '', 426)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 426, NULL, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(427, 'Test performed this year', 322, 184, 'Yes,No', ',', 427)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 427, 426, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(428, 'Patient refused', 322, 184, 'Yes,No', ',', 428)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 428, 426, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(429, 'Standing orders criteria not met', 322, 184, 'Yes,No', ',', 429)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 429, 426, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(430, 'Equipment Malfunction', 322, 184, 'Yes,No', ',', 430)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 430, 426, 1)

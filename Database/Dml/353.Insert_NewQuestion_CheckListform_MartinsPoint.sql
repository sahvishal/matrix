USE [$(dbname)]
GO

DECLARE @Groupalias VARCHAR(500), @groupId BIGINT, @questionId BIGINT

SET @Groupalias ='BIOMETRICANDMINICOGSECTIONV2'

SELECT @groupId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(431, 'Obesity (BMI of 30 or higher)', 322, 184, 'Yes,No', ',', 431)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupId, 431, 397, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
SELECT @groupId, QuestionId, ParentId, 1 from TblChecklistGroupQuestion
WHERE QuestionId in 
(
	SELECT Id from TblCheckListQuestion
	WHERE Question = 'Standing orders criteria not met'
)
AND GroupId in 
(
	SELECT Id FROM TblCheckListGroup WHERE Alias = 'BIOMETRICANDMINICOGSECTION'
)



SET @Groupalias ='AAAULTRASOUND'

SELECT @groupId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(432, 'Has NOT had previous one-time screening performed.', 322, 185, 'Yes,No', ',', 432)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupId, 432, 398, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(433, 'Has NOT had previous one-time screening performed.', 322, 186, 'Yes,No', ',', 433)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupId, 433, 406, 1)
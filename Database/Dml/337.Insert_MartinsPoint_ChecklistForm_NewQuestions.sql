USE [$(dbname)]
GO

DECLARE @Groupalias VARCHAR(500), @groupQuestionId BIGINT

SET @Groupalias ='BIOMETRICANDMINICOGSECTIONV2'

 IF NOT EXISTS (SELECT Id FROM TblCheckListGroup WHERE Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		VALUES( 'BIOMETRIC and MINI COG SECTION','BIOMETRIC and MINI COG SECTION', 319,null, @Groupalias , 1)
 END 

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias
 
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 11, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 12, 11, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(395, 'if the patient meets any of the criteria below.', 321, 184, '', '', 395)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 395, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 245, 11, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(396, 'All pre-diabetic patients that have not had an A1c done this calendar year (This includes elevated fasting glucose or borderline diabetes). MST to document patient attestation to pre-diabetes in EMR.', 322, 184, 'Yes,No', ',', 396)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 396, 11, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 13, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 247, 13, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 246, 13, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 17, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 18, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 19, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 20, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 21, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 248, 17, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(397, 'Patients with any of the following conditions that have not had a lipid panel done this calendar year:', 322, 184, 'Yes,No', ',', 397)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 397, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 251, 397, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 252, 397, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 253, 397, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 254, 397, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 255, 397, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 256, 397, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 22, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 23, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 24, 17, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 35, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 37, 35, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 36, 35, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 39, 35, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 40, 35, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 258, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 259, 258, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 260, 258, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 262, 258, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 263, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 264, 263, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 265, 263, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 267, 263, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 26, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 27, 26, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 28, NULL, 1)



SET @Groupalias ='AAAULTRASOUND'

 IF NOT EXISTS (SELECT Id FROM TblCheckListGroup WHERE Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		VALUES( 'AAA ULTRASOUND','AAA ULTRASOUND', 319,null, @Groupalias , 1)
 END 

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias

-- AAA MALE
INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(398, 'ORDER MALE AAA ULTRASOUND if the patient has met all the criteria from Column A and at least 1 of the criteria from Column B.', 322, 185, 'Yes,No', ',', 398)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 398, NULL, 1)

-- Column A
INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(399, 'Current or former smoker', 322, 185, 'Yes,No', ',', 399)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 399, 398, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(400, '65 - 75 years old', 322, 185, 'Yes,No', ',', 400)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 400, 398, 1)

-- Column B
INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(401, 'Hypertension', 322, 185, 'Yes,No', ',', 401)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 401, 398, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(402, 'High cholesterol', 322, 185, 'Yes,No', ',', 402)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 402, 398, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(403, 'Diabetes in combination with HTN and/or high cholesterol', 322, 185, 'Yes,No', ',', 403)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 403, 398, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(404, 'Family history of AA', 322, 185, 'Yes,No', ',', 404)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 404, 398, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(405, 'Personal or family history of CAD/MI', 322, 185, 'Yes,No', ',', 405)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 405, 398, 1)


INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 339, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 340, 339, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 341, 339, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 342, 339, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 343, 339, 1)


-- AAA FEMALE
INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(406, 'ORDER FEMALE AAA ULTRASOUND if the patient has met all the criteria from Column A andat least 1 of the criteria from Column B.', 322, 186, 'Yes,No', ',', 406)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 406, NULL, 1)

-- Column A
INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(407, 'Current or former smoker', 322, 186, 'Yes,No', ',', 407)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 407, 406, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(408, '65 - 75 years old', 322, 186, 'Yes,No', ',', 408)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 408, 406, 1)

-- Column B
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 350, 406, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 351, 406, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 352, 406, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 353, 406, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 354, 406, 1)


INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 355, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 356, 355, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 357, 355, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 358, 355, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 359, 355, 1)



SET @Groupalias ='MONOFILAMENT'

 IF NOT EXISTS (SELECT Id FROM TblCheckListGroup WHERE Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		VALUES( 'MONOFILAMENT','MONOFILAMENT', 319, null, @Groupalias , 1)
 END 

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(409, '(Provider) PERFORM MONOFILAMENT if the patient meets ANY of the criteria from below.', 322, 184, 'Yes,No', ',', 409)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 409, NULL, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(410, 'Diabetes', 322, 184, 'Yes,No', ',', 410)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 410, 409, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(411, 'Any patient complaining of numbness, tingling, or burning sensation in hands or feet, regardless of diabetes status.', 322, 184, 'Yes,No', ',', 411)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 411, 409, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(412, 'MONOFILAMENT not completed', 321, 184, '', '', 412)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 412, NULL, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(413, 'Test performed this year', 322, 184, 'Yes,No', ',', 413)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 413, 412, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(414, 'Patient refused', 322, 184, 'Yes,No', ',', 414)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 414, 412, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(415, 'Standing orders criteria not met', 322, 184, 'Yes,No', ',', 415)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 415, 412, 1)

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(416, 'Equipment Malfunction', 322, 184, 'Yes,No', ',', 416)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 416, 412, 1)


SET @Groupalias ='TAKEHOMEKITSECTIONV2'

 IF NOT EXISTS (SELECT Id FROM TblCheckListGroup WHERE Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		VALUES( 'TAKE HOME KIT SECTION','TAKE HOME KIT SECTION', 319,null, @Groupalias , 1)
 END 

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 41, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 42, 41, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 43, 41, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 47, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 58, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 59, 58, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 60, 58, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 268, 47, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 269, NULL, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 270, 269, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 271, 269, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 272, 269, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 273, 269, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 371, 58, 1)

INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 372, 58, 1)



SET @Groupalias ='EKGV2'

SELECT @groupQuestionId = Id FROM TblCheckListGroup WHERE Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES(417, 'Elevated blood pressure without diagnosis of hypertension (no meds and no claims history)', 322, 184, 'Yes,No', ',', 417)
INSERT INTO TblChecklistGroupQuestion(GroupId, QuestionId, ParentId, IsActive)
VALUES (@groupQuestionId, 417, 313, 1)
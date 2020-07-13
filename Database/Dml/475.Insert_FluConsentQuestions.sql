USE [$(dbName)]
GO

DECLARE @TemplateId BIGINT

INSERT INTO TblFluConsentTemplate ([Name], IsPublished, IsActive, DateCreated, CreatedBy)
VALUES ('Default Flu Consent Template', 1, 1, GETDATE(), 1)

SELECT @TemplateId = SCOPE_IDENTITY()

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (1, 'Have you received the current flu vaccination for this year?', 324, 44, 'True,False', ',', 1)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 1)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ParentId, ControlValues, ControlValueDelimiter, [Index])
VALUES (2, 'If yes, when was your last vaccination?', 323, 44, 1, '', '', 2)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 2)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (3, 'Have you ever had an allergic or serious reaction to a past flu or other vaccination?', 324, 44, 'True,False', ',', 3)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 3)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ParentId, ControlValues, ControlValueDelimiter, [Index])
VALUES (4, 'If YES, please explain:', 323, 44, 3, '', '', 4)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 4)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (5, 'Have you ever had a severe allergic reaction to eggs, egg products, chickens, or chicken feathers?', 324, 44, 'True,False', ',', 5)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 5)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (6, 'Have you been diagnosed with Guillain-Barre Syndrome or a persistent neurological illness?', 324, 44, 'True,False', ',', 6)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 6)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (7, 'Do you feel ill today or do you have a fever?', 324, 44, 'True,False', ',', 7)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 7)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (8, 'Do you have an allergy to latex?', 324, 44, 'True,False', ',', 8)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 8)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (9, 'Do you take a daily blood thinner?', 324, 44, 'True,False', ',', 9)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 9)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (10, 'If you are female, are you pregnant?', 324, 44, 'True,False', ',', 10)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 10)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (11, 'I REQUEST to receive the vaccination.', 324, 44, 'True,False', ',', 11)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 11)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (12, 'Manufacturer Number:', 323, 44, '', '', 12)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 12)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (13, 'Lot/Expiration Date:', 323, 44, '', '', 13)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 13)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (14, 'Injection Site (circle one):', 324, 44, 'Left,Right', ',', 14)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 14)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (15, 'Clinical Provider’s Name:', 323, 44, '', '', 15)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 15)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (16, 'History of Guillain-Barre Syndrome. Advised to consult with PCP about getting the flu vaccine.', 322, 44, 'True,False', ',', 16)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 16)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (17, 'History of severe egg, chicken, or chicken feathers allergic reaction. Advised to consult with PCP about getting the flu vaccine.', 322, 44, 'True,False', ',', 17)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 17)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (18, 'History of severe reaction to influenza vaccine in the past. Advised to consult with PCP about getting the flu vaccine.', 322, 44, 'True,False', ',', 18)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 18)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ControlValues, ControlValueDelimiter, [Index])
VALUES (19, 'Had influenza vaccine already this flu season.', 322, 44, 'True,False', ',', 19)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 19)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ParentId, ControlValues, ControlValueDelimiter, [Index])
VALUES (20, 'Date:', 323, 44, 19, '', '', 20)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 20)

-----------------------------------------------------------------------------------------------------------

INSERT INTO TblFluConsentQuestion (Id, Question, TypeId, Gender, ParentId, ControlValues, ControlValueDelimiter, [Index])
VALUES (21, 'Time:', 323, 44, null, '', '', 21)

INSERT INTO TblFluConsentTemplateQuestion (TemplateId, QuestionId)
VALUES (@TemplateId, 21)


GO
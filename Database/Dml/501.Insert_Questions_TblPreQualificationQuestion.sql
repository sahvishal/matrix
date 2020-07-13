USE [$(dbName)]
GO

Declare @ParentId BIGINT

SET @ParentId = 5

INSERT INTO TblPreQualificationQuestion (Id,Question,TestId,ControlValues,ControlValueDelimiter,IsActive,[Index],CreatedBy,CreatedDate,DisqualifiedReason, ParentId, TypeId)
VALUES(5,'Had the patient had "Double mastectomy"?',29,'Yes,No',',',1,1,1,GETDATE(),'Had the patient had "Double mastectomy"', NULL, 124)

INSERT INTO TblPreQualificationQuestion (Id,Question,TestId,ControlValues,ControlValueDelimiter,IsActive,[Index],CreatedBy,CreatedDate,DisqualifiedReason, ParentId, TypeId)
VALUES(6,'Member Refused Mammogram?',29,'Yes,No',',',1,2,1,GETDATE(),'Member Refused Mammogram', @ParentId, 124)

INSERT INTO TblPreQualificationQuestion (Id,Question,TestId,ControlValues,ControlValueDelimiter,IsActive,[Index],CreatedBy,CreatedDate,DisqualifiedReason, ParentId, TypeId)
VALUES(7,'Date',29,'Date,Unknown,Member Declined to answer','',1,1,1,GETDATE(),'', @ParentId, 124)

--INSERT INTO TblPreQualificationQuestion (Id,Question,TestId,ControlValues,ControlValueDelimiter,IsActive,[Index],CreatedBy,CreatedDate,DisqualifiedReason, ParentId, TypeId)
--VALUES(8,'Unknown',29,'','',1,2,1,GETDATE(),'', @ParentId, 124)

--INSERT INTO TblPreQualificationQuestion (Id,Question,TestId,ControlValues,ControlValueDelimiter,IsActive,[Index],CreatedBy,CreatedDate,DisqualifiedReason, ParentId, TypeId)
--VALUES(9,'Member Declined to answer',29,'','',1,3,1,GETDATE(),'', @ParentId, 124)

INSERT INTO TblPreQualificationQuestion (Id,Question,TestId,ControlValues,ControlValueDelimiter,IsActive,[Index],CreatedBy,CreatedDate,DisqualifiedReason, ParentId, TypeId)
VALUES(8,'Date : ',29,'','',1,1,1,GETDATE(),'', 7, 126)


INSERT INTO TblPreQualificationQuestionRule (QuestionId,DependentQuestionId,DependencyValue)
VALUES (6,5,'No')

INSERT INTO TblPreQualificationQuestionRule (QuestionId,DependentQuestionId,DependencyValue)
VALUES (7,5,'Yes')

--INSERT INTO TblPreQualificationQuestionRule (QuestionId,DependentQuestionId,DependencyValue)
--VALUES (8,5,'Yes')

--INSERT INTO TblPreQualificationQuestionRule (QuestionId,DependentQuestionId,DependencyValue)
--VALUES (9,5,'Yes')

INSERT INTO TblPreQualificationQuestionRule (QuestionId,DependentQuestionId,DependencyValue)
VALUES (8,7,'Date')

USE [$(dbName)]
Go

DECLARE @lookUpTypeId BIGINT

INSERT INTO TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
VALUES ( 'EmailTemplate', 'Email Template', '', getdate(), getdate() )

SET @lookUpTypeId = @@IDENTITY

INSERT INTO TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
VALUES (174, @lookUpTypeId, 'Email', 'Email', '', 1, getdate(), NULL, 1, NULL, 1 )

INSERT INTO TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
VALUES (175, @lookUpTypeId, 'Phone', 'Phone', '', 2, getdate(), NULL, 1, NULL, 1 )
Go

UPDATE TblEmailTemplate Set TemplateType=174 WHERE EmailTemplateId>0
Go

ALTER TABLE TblEmailTemplate ALTER COLUMN TemplateType BIGINT NOT NULL
GO
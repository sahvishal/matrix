USE [$(dbName)]
GO

UPDATE TblPreQualificationQuestion SET DisqualifiedReason='The patient had "Double mastectomy"' WHERE Id=5
 
GO


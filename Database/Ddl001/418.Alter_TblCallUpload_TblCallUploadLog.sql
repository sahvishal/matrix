USE [$(dbName)]
Go

Alter Table TblCallUpload  Drop Constraint DF_TblCallUpload_IsParsed,Column  IsParsed
Go

Alter Table TblCallUploadLog Add IsRuleApplied bit NOT NULL CONSTRAINT DF_TblCallUploadLog_IsRuleApplied DEFAULT 0
Go

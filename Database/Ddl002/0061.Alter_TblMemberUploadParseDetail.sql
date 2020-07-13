USE [$(dbname)]
GO

ALTER TABLE TblMemberUploadParseDetail
ADD DNC varchar(64) NULL,
	ProductType varchar(64) NULL
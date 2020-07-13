USE [$(dbname)]
GO

ALTER TABLE TblCallCenterRepProfile
ADD DialerUrl NVARCHAR(2048) NULL

GO
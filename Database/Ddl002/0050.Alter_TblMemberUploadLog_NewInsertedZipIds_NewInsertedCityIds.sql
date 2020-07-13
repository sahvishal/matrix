
USE [$(dbName)]
GO	

ALTER TABLE TblMemberUploadLog
ADD NewInsertedZipIds varchar(200) NULL	
  , NewInsertedCityIds varchar(200) NULL

GO


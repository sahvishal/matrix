USE [$(dbName)]
Go

 





IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRaps]')   AND name = 'IcdVersion')
BEGIN 
	Alter Table TblRaps
	Add   IcdVersion int null
END

IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRapsUploadLog]')   AND name = 'MemberId')
BEGIN 
	Alter Table TblRapsUploadLog
	Add   MemberId varchar(255)
END

IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRapsUploadLog]')   AND name = 'IcdVersion')
BEGIN 
	Alter Table TblRapsUploadLog
	Add   IcdVersion int null
END





IF EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRaps]')   AND name = 'ProviderNpi')
BEGIN 
--
	Alter Table TblRaps
	Drop Column   DiagnosisCode

	Alter Table TblRaps
	Drop Column   DateOfServiceStartDate    

	Alter Table TblRaps
	Drop Column   DateOfServiceEndDate  

	Alter Table TblRaps
	Drop Column   ProviderNpi   

	Alter Table TblRaps
	Drop Column   DiagnosisCodeIndicator  
 
	Alter Table TblRaps
	Drop Column   DeleteIndicator  

	Alter Table TblRaps
	Drop Column   SignedByUser  

	Alter Table TblRaps
	Drop Column   SiteNAme 
END





IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRaps]')   AND name = 'ServiceDate')
BEGIN 
	Alter Table TblRaps
	Add   ServiceDate datetime null
END

IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRaps]')   AND name = 'IcdCode')
BEGIN 
	Alter Table TblRaps
	Add   IcdCode varchar(8) null
END
IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRaps]')   AND name = 'FirstName')
BEGIN 
	Alter Table TblRaps
	Add   FirstName varchar(500) null
END
IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRaps]')   AND name = 'SecondName')
BEGIN 
	Alter Table TblRaps
	Add   SecondName varchar(500) null
END

IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRapsUploadLog]')   AND name = 'ServiceDate')
BEGIN 
	Alter Table TblRapsUploadLog
	Add   ServiceDate datetime null
END

IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRapsUploadLog]')   AND name = 'IcdCode')
BEGIN 
	Alter Table TblRapsUploadLog
	Add   IcdCode varchar(8) null
END
IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRapsUploadLog]')   AND name = 'FirstName')
BEGIN 
	Alter Table TblRapsUploadLog
	Add   FirstName varchar(500) null
END
IF NOT EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRapsUploadLog]')   AND name = 'SecondName')
BEGIN 
	Alter Table TblRapsUploadLog
	Add   SecondName varchar(500) null
END




IF EXISTS (  SELECT 1   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[TblRapsUploadLog]')   AND name = 'DateOfServiceStartDate')
BEGIN 
--
	Alter Table TblRapsUploadLog
	Drop Column   DiagnosisCode

	Alter Table TblRapsUploadLog
	Drop Column   DateOfServiceStartDate    

	Alter Table TblRapsUploadLog
	Drop Column   DateOfServiceEndDate  

	Alter Table TblRapsUploadLog
	Drop Column   ProviderNpi   

	Alter Table TblRapsUploadLog
	Drop Column   DiagnosisCodeIndicator  
 
	Alter Table TblRapsUploadLog
	Drop Column   DeleteIndicator  

	Alter Table TblRapsUploadLog
	Drop Column   SignedByUser  

	Alter Table TblRapsUploadLog
	Drop Column   SiteNAme 
END

--select * from TblRaps
--select * from TblRapsUploadLog
USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblRole]  
		ADD IsPinRequired bit null
		
GO

Update [TblRole] Set IsPinrequired = 0

GO

ALTER TABLE [dbo].[TblRole]  
		ALTER COlUMN IsPinRequired bit not null
		
GO
USE [$(dbName)]
Go

INSERT INTO [dbo].[TblCallQueue]
           ([Name],[Description],[Attempts],[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId],[IsActive],[IsQueueGenerated],IsManual,Category,IsHealthPlan)
     VALUES
           ('Language Barrier','Language Barrier',10,GETDATE(),GETDATE(),1,1,1,0,0,'LanguageBarrier',1)          
          
GO

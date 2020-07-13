USE [$(dbName)]
Go

INSERT INTO [dbo].[TblCallQueue]
           ([Name],[Description],[Attempts],[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId],[IsActive],[IsQueueGenerated],IsManual,Category)
     VALUES
           ('Easiest to Convert Prospect','Easiest to Convert Prospect',10,GETDATE(),GETDATE(),1,1,1,0,0,'EasiestToConvertProspect'),
           ('Annual','Annual',10,GETDATE(),GETDATE(),1,1,1,0,0,'Annual'),
           ('Call Back','Call Back',10,GETDATE(),GETDATE(),1,1,1,0,0,'CallBack'),
           ('Fill Events','Fill Events',10,GETDATE(),GETDATE(),1,1,1,0,0,'FillEvents'),
           ('Upsell','Upsell',2,GETDATE(),GETDATE(),1,1,1,0,0,'Upsell'),
           ('Confirmation','Confirmation',2,GETDATE(),GETDATE(),1,1,1,0,0,'Confirmation')
GO
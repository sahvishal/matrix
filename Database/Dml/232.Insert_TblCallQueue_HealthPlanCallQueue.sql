USE [$(dbName)]
Go

INSERT INTO [dbo].[TblCallQueue]
           ([Name],[Description],[Attempts],[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId],[IsActive],[IsQueueGenerated],IsManual,Category,IsHealthPlan)
     VALUES
           ('Call Round','Call Round',10,GETDATE(),GETDATE(),1,1,1,0,0,'CallRound',1),          
           ('Fill Events','Fill Events',10,GETDATE(),GETDATE(),1,1,1,0,0,'FillEventsHealthPlan',1),
           ('No Shows','No Shows',10,GETDATE(),GETDATE(),1,1,1,0,0,'NoShows',1),
           ('Zip Radius','Zip Radius',10,GETDATE(),GETDATE(),1,1,1,0,0,'ZipRadius',1)
GO

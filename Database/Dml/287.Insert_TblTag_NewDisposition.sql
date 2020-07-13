USE [$(dbName)]
GO

INSERT INTO [dbo].[TblTag]
           ([Source],[Name],[Alias],[IsActive],[IsSystemDefined],[IsHealthPlanTag])
     VALUES
           (107, 'Transfer Unsuccessful', 'TransferUnsuccessful', 0, 0, 1)

INSERT INTO [dbo].[TblTag]
           ([Source],[Name],[Alias],[IsActive],[IsSystemDefined],[IsHealthPlanTag])
     VALUES
           (107, 'Not Eligible', 'NotEligible', 0, 0, 1)



USE [$(dbName)]
GO

INSERT INTO [dbo].[TblTag]
           ([Source],[Name],[Alias],[IsActive],[IsSystemDefined],[IsHealthPlanTag])
     VALUES
           (107, 'Tranfer To HealtFair', 'TranferToHealtFair', 0, 0, 1)

INSERT INTO [dbo].[TblTag]
           ([Source],[Name],[Alias],[IsActive],[IsSystemDefined],[IsHealthPlanTag])
     VALUES
           (107, 'Other', 'Other', 0, 0, 1)

INSERT INTO [dbo].[TblTag]
           ([Source],[Name],[Alias],[IsActive],[IsSystemDefined],[IsHealthPlanTag])
     VALUES
           (107, 'Hangup', 'Hangup', 0, 0, 1)
GO


USE [$(dbName)]
Go

INSERT INTO [dbo].[TblCallQueue]
           (
		   [Name],
		   [Description],
		   [Attempts],
		   [DateCreated],
		   [DateModified],
		   [CreatedByOrgRoleUserId],
		   [ModifiedByOrgRoleUserId],
		   [IsActive],
		   [IsQueueGenerated],
		   IsManual,
		   Category,
		   IsHealthPlan
		   )
     VALUES
           
           (
		   'Pre-Assessment Call Queue',
		   'Pre-Assessment Call Queue',
		   10,
		   GETDATE(),
		   GETDATE(),
		   1,
		   1,
		   0,
		   0,
		   0,
		   'PreAssessmentCallQueue',
		   1
		   )
GO


  USE [$(dbName)]
GO 


INSERT INTO [dbo].[TblExportableReports]
           ([Id]
           ,[Name]
           ,[Alias]
           ,[CreatedOn])
     VALUES
           (48
           ,'PreAssessment Report'
           ,'PreAssessmentReport'
           ,GETDATE())
GO



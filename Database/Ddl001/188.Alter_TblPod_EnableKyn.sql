
USE [$(dbName)]
GO


Alter Table TblPodDetails Add EnableKynIntegration bit not null Constraint DF_TblPodDetails_EnableKynIntegration default 0
GO

Alter Table TblEventPod Add EnableKynIntegration bit not null Constraint DF_TblEventPod_EnableKynIntegration default 0
GO




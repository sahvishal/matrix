USE [$(dbname)]
GO

ALTER TABLE TblEventNote
DROP COLUMN Pod
GO

ALTER TABLE TblEventNote 
ADD PodId BIGINT NULL
GO

Alter Table [dbo].[TblEventNote]
Add CONSTRAINT FK_TblEventNote_TblPodDetails_PodId FOREIGN KEY([PodId]) REFERENCES dbo.TblPodDetails (PodId),
CONSTRAINT FK_TblEventNote_TblAccount_HealthPlanId FOREIGN KEY([HealthPlanId]) REFERENCES dbo.TblAccount (AccountId)
GO


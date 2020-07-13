USE [$(dbName)]
GO

CREATE TABLE dbo.TblHealthPlanFillEventCallQueue
	(
		EventId bigint NOT NULL,
		CriteriaId bigint NOT NULL
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.TblHealthPlanFillEventCallQueue ADD CONSTRAINT PK_TblHealthPlanFillEventCallQueue PRIMARY KEY CLUSTERED (EventId,CriteriaId)  ON [PRIMARY]
GO

ALTER TABLE dbo.TblHealthPlanFillEventCallQueue ADD CONSTRAINT FK_TblHealthPlanFillEventCallQueue_TblEvent FOREIGN KEY (EventId) REFERENCES dbo.TblEvents(EventId) 	
GO

ALTER TABLE dbo.TblHealthPlanFillEventCallQueue ADD CONSTRAINT FK_TblHealthPlanFillEventCallQueue_TblHealthPlanCallQueueCriteria FOREIGN KEY (CriteriaId) REFERENCES dbo.TblHealthPlanCallQueueCriteria	(Id)	
GO

ALTER TABLE TblCallQueueCustomer Add EventIds varchar(2048)
Go
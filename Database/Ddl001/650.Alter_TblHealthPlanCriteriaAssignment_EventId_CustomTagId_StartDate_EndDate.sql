USE [$(dbname)]
GO

ALTER TABLE TblHealthPlanCriteriaAssignment 
ADD	[EventId] [varchar](max) NULL,
	[CustomTagId] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL
	
USE [$(dbName)]
Go

Alter Table TblHealthPlanCallQueueCriteria  Add IsDeleted bit not null CONSTRAINT DF_TblHealthPlanCallQueueCriteria_IsDeleted DEFAULT 0

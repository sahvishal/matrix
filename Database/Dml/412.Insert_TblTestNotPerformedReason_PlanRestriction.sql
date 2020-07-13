USE [$(dbName)]
GO

INSERT into TblTestNotPerformedReason (Id,Name,Alias,CreatedBy,CreatedOn)
VALUES (9, 'Plan Restriction', 'PlanRestriction', 1, GETDATE())

GO
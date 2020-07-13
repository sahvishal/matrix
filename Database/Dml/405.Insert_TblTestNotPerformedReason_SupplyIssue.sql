USE [$(dbName)]
GO

INSERT into TblTestNotPerformedReason
(Id,Name,Alias,CreatedBy,CreatedOn)
VALUES
(7,'Supply Issue','SupplyIssue',1,GETDATE())

GO
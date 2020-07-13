USE [$(dbName)]
GO

INSERT into TblTestNotPerformedReason (Id,Name,Alias,CreatedBy,CreatedOn)
VALUES (8, 'Staff Not Available', 'StaffNotAvailable', 1, GETDATE())

GO
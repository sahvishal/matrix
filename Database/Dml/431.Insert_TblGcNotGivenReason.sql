USE[$(dbName)]
GO

INSERT INTO TblGcNotGivenReason
(Id,[Name],Alias,DateCreated,CreatedBy)
VALUES
(1,'Out of Gift Cards','OutofGiftCards',GETDATE(),1)

GO
INSERT INTO TblGcNotGivenReason
(Id,[Name],Alias,DateCreated,CreatedBy)
VALUES
(2,'Member Left Without Card','MemberLeftWithoutCard',GETDATE(),1)

GO
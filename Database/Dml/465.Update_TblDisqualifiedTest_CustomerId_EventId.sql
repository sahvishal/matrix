USE [$(dbname)]
GO

UPDATE TDT SET EventId = EC.EventID, CustomerId = EC.CustomerID
FROM TblDisqualifiedTest TDT
INNER JOIN TblEventCustomers EC ON TDT.EventCustomerId = EC.EventCustomerID
GO

ALTER TABLE TblDisqualifiedTest
ALTER COLUMN CustomerId BIGINT NOT NULL
GO

ALTER TABLE TblDisqualifiedTest
ALTER COLUMN EventId BIGINT NOT NULL
GO

ALTER TABLE TblDisqualifiedTest
ADD CONSTRAINT PK_TblDisqualifiedTest PRIMARY KEY (CustomerId, EventId, QuestionId, [Version], TestId)
GO

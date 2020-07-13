USE [$(dbname)]
GO

UPDATE ECQA SET EventId = EC.EventID, CustomerId = EC.CustomerID
FROM TblEventCustomerQuestionAnswer ECQA
INNER JOIN TblEventCustomers EC ON ECQA.EventCustomerId = EC.EventCustomerID
GO

ALTER TABLE TblEventCustomerQuestionAnswer
ALTER COLUMN CustomerId BIGINT NOT NULL
GO

ALTER TABLE TblEventCustomerQuestionAnswer
ALTER COLUMN EventId BIGINT NOT NULL
GO

ALTER TABLE TblEventCustomerQuestionAnswer
ADD CONSTRAINT PK_TblEventCustomerQuestionAnswer PRIMARY KEY (CustomerId, EventId, QuestionId, [Version])
GO

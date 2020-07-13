USE [$(dbname)]
GO

ALTER TABLE TblCallQueueCustomer
ADD CONSTRAINT FK_TblCallQueueCustomer_TblActivityType_ActivityId
FOREIGN KEY (ActivityId) REFERENCES TblActivityType(Id)

GO
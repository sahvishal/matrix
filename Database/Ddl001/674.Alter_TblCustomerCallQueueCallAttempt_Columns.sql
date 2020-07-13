USE[$(dbName)]

GO

ALTER TABLE TblCustomerCallQueueCallAttempt
Alter Column DateCreated datetime not null

GO

ALTER TABLE TblCustomerCallQueueCallAttempt
Alter Column CreatedBy bigint not null

GO

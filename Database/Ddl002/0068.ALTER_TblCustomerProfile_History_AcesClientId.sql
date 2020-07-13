USE	[$(dbname)]
GO

Alter TABLE TblCustomerProfile
ADD AcesClientId BIGINT NULL
GO


Alter TABLE TblCustomerProfileHistory
ADD AcesClientId BIGINT NULL
GO



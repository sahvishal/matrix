USE	[$(dbname)]
GO

ALTER TABLE TblCustomerProfile 
ADD ActivityTypeIsManual BIT NOT NULL CONSTRAINT DF_TblCustomerProfile_ActivityTypeIsManual DEFAULT 0
GO


ALTER TABLE TblCustomerProfileHistory
ADD ActivityTypeIsManual BIT NOT NULL CONSTRAINT DF_TblCustomerProfileHistory_ActivityTypeIsManual DEFAULT 0
GO


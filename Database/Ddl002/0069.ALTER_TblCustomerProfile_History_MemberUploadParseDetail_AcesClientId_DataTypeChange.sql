USE	[$(dbname)]
GO

ALTER TABLE TblCustomerProfile 
ALTER COLUMN AcesClientId VARCHAR(250)

ALTER TABLE TblCustomerProfileHistory 
ALTER COLUMN AcesClientId VARCHAR(250)

ALTER TABLE TblMemberUploadParseDetail 
ALTER COLUMN AcesClientId VARCHAR(250)

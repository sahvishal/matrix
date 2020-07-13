USE[$(dbName)]

GO
ALTER TABLE TblAccount
ADD SendPatientDataToAces bit not null Constraint DF_TblAccount_SendPatientDataToAces DEFAULT(0)

GO
ALTER TABLE TblAccount
ADD ClientId varchar(50) null

GO
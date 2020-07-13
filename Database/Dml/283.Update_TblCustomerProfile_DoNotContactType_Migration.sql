USE [$(dbName)]
Go
	Declare @lookUpTypeId bigint
	SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='DoNotContactType'

	Declare @lookUpId bigint
	SELECT @lookUpId= LookupId from TblLookup where Alias='DoNotContact' and LookupTypeId=@lookUpTypeId

	Update TblCustomerProfile set DoNotContactTypeId=@lookUpId where DoNotContactReasonId is Not Null
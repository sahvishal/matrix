USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'ComparisonOperators'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('ComparisonOperators', 'Comparison Operators', 'Comparison Operators', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'LessThan' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (194, @lookupTypeId, 'LessThan', 'Less Than', 'Less Than', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'GreaterThan' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (195, @lookupTypeId, 'GreaterThan', 'Greater Than', 'Greater Than', 2, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'LessThanEqualTo' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (196, @lookupTypeId, 'LessThanEqualTo', 'Less Than Equal To', 'Less Than Equal To', 3, getdate(), 1, 1)
END



IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'GreaterThanEqualTo' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (197, @lookupTypeId, 'GreaterThanEqualTo', 'Greater Than Equal To', 'Greater Than Equal To', 4, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Between' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (198, @lookupTypeId, 'Between', 'Between', 'Between', 5, getdate(), 1, 1)
END





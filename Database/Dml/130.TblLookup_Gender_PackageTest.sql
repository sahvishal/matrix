
USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'Gender'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('Gender', 'Gender', 'Unspecified, Male, Female', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Both' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (184, @lookupTypeId, 'Both', 'Both', 'Both', 1, getdate(), 1, 1)	
END
else
Begin
 Update TblLookup set RelativeOrder = 1 where LookupId=184
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Male' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (185, @lookupTypeId, 'Male', 'Male', 'Male', 2, getdate(), 1, 1)	
END
else
Begin
 Update TblLookup set RelativeOrder = 2 where LookupId=185
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Female' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (186, @lookupTypeId, 'Female', 'Female', 'Female', 3, getdate(), 1, 1)		
END
else
Begin
 Update TblLookup set RelativeOrder = 3 where LookupId=186
End
Go

ALTER TABLE dbo.TblTest ADD CONSTRAINT 	FK_TblTest_Gender FOREIGN KEY
				(Gender) REFERENCES dbo.TblLookup	(LookupId) ON UPDATE  NO ACTION 
				ON DELETE  NO ACTION 
	
GO


ALTER TABLE dbo.TblPackage ADD CONSTRAINT  FK_TblPackage_Gender FOREIGN KEY (Gender) REFERENCES dbo.TblLookup
    (LookupId) ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
 
GO

ALTER TABLE dbo.TblEventPackageDetails ADD CONSTRAINT FK_TblEventPackageDetails_TblLookup FOREIGN KEY
			(Gender) REFERENCES dbo.TblLookup  (LookupId) ON UPDATE  NO ACTION ON DELETE  NO ACTION 	
GO

ALTER TABLE dbo.TblEventTest ADD CONSTRAINT FK_TblEventTest_TblLookup FOREIGN KEY
			(Gender) REFERENCES dbo.TblLookup  (LookupId) ON UPDATE  NO ACTION ON DELETE  NO ACTION 	
GO
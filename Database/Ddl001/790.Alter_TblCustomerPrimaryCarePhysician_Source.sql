USE[$(dbName)]
GO

ALTER Table TblCustomerPrimaryCarePhysician
Add Source bigint NULL

ALTER Table TblCustomerPrimaryCarePhysician
Add Constraint [FK_TblCustomerPrimaryCarePhysician_TblLookup_Source]
Foreign key (Source)
References TblLookup(LookupId)

GO
USE [$(dbName)]
GO

--Mark ChangedMind (297) and other (362) to IsActive to false for Customer Left Without screening

update TblLookup set IsActive=0 where LookupId in (297,362)

GO

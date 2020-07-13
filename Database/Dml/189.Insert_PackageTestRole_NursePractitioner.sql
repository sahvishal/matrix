USE [$(dbName)]
Go

--select * from TblPackageAvailabilityToRoles where RoleID = 8

insert into TblPackageAvailabilityToRoles
	(PackageID, RoleID)
select PackageID, 17 from TblPackageAvailabilityToRoles where RoleID = 8

--select * from TblTestAvailabilityToRoles where RoleID = 8

insert into TblTestAvailabilityToRoles
	(TestID, RoleID)
select TestID, 17 from TblTestAvailabilityToRoles where RoleID = 8
	
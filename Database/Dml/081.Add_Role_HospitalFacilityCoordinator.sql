
USE [$(dbName)]
GO
--select * from TblRole


insert into TblRole
	(RoleID, OrganizationTypeID, Name, Alias, DateCreated, DateModified, [Description], DefaultPage, IsActive , ShellType)
values
	(16, 8, 'Hospital Facility Coordinator', 'HospitalFacilityCoordinator', GETDATE(), GETDATE(), 'Hospital Facility Coordinator', '/Users/Dashboard/HospitalFacilityCoordinator', 1, 'HospitalFacility')
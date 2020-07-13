USE [$(dbName)]

insert into TblAccountCoordinatorProfile(OrganizationRoleUserId)
select OrganizationRoleUserID from TblOrganizationRoleUser where RoleID=15 
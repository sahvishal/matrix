USE [$(dbname)]
GO

 DECLARE @RoleId BIGINT;
 DECLARE @OrganizationId BIGINT;

 SELECT @RoleId = RoleId FROM TblRole where [Alias] = 'NursePractitioner'
 SELECT @OrganizationId = OrganizationId from TblOrganization where [Name] = 'HealthFair Screening'

 UPDATE TblOrganizationRoleUser SET OrganizationId = @OrganizationId where RoleID=@RoleId

GO
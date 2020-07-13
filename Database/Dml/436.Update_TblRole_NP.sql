USE [$(dbname)]
GO

 DECLARE @OrganizationTypeId BIGINT;
 SELECT @OrganizationTypeId = OrganizationTypeId FROM TblOrganizationType where [Alias]='Franchisee'
 
 UPDATE TblRole set OrganizationTypeID = @OrganizationTypeId where Alias='NursePractitioner'

 GO

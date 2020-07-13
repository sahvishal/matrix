USE [$(dbName)]
Go

SET IDENTITY_INSERT TBLRole ON

IF NOT EXISTS (select RoleID from tblRole where RoleID =17)
BEGIN
Insert into TblRole (RoleId,OrganizationTypeID,Name,Alias,DateCreated,DateModified,Description,DefaultPage,IsActive,ShellType,ParentId,IsSystemRole,IsTwoFactorAuthrequired,IsPinrequired)
	Values(17,5,'Nurse Practitioner','NursePractitioner',GETDATE(),GETDATE(),'Nurse Practitioner only for Corporate Accounts','', 1,'NursePractitioner',null,1,1,0)
END

SET IDENTITY_INSERT TBLRole OFF
USE [$(dbName)]
Go

Insert into TblRole (OrganizationTypeID,Name,Alias,DateCreated,DateModified,Description,DefaultPage,IsActive,ShellType,ParentId,IsSystemRole,IsTwoFactorAuthrequired)
	Values(5,'Nurse Practitioner','NursePractitioner',GETDATE(),GETDATE(),'Nurse Practitioner only for Corporate Accounts','', 1,'NursePractitioner',null,1,1)


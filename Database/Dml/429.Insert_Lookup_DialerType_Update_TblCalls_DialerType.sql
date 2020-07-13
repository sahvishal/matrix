USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT, @OrgRoleUserId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated, DateModified)
VALUES ('DialerType','Dialer Type','Type of External Dialer used to make outbound calls to call queue customers.',GETDATE(),GETDATE())

SET @LookupTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (384, @LookupTypeId, 'GMS', 'GMS', 'GMS Dialer', 1, GETDATE(), 1, 1)

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (385, @LookupTypeId, 'Vici', 'Vici', 'Vici Dialer', 2, GETDATE(), 1, 1)



SELECT @OrgRoleUserId = OrganizationRoleUserID FROM TblOrganizationRoleUser WHERE UserID = (SELECT UserLoginID FROM TblUserLogin WHERE UserName = 'gms.dialer') AND RoleID = 10

UPDATE TblCalls SET DialerType = 384 WHERE CreatedByOrgRoleUserId = @OrgRoleUserId

GO

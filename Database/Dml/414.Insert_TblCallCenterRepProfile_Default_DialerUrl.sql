USE [$(dbname)]
GO

INSERT INTO TblCallCenterRepProfile (CallCenterRepId, CanRefund, CanChangeNotes, DialerUrl)
SELECT OrganizationRoleUserId, 0, 0, 'Glocom://*65*CallerId*1PatientContact'
FROM TblOrganizationRoleUser WHERE IsActive = 1
AND 
(
	RoleID = 10
	OR
	RoleID IN
	(
		SELECT RoleID fROM TblRole WHERE ParentId = 10
	)
)
AND OrganizationRoleUserId NOT IN
(
	SELECT CallCenterRepId from TblCallCenterRepProfile
)
GO


UPDATE TblCallCenterRepProfile SET DialerUrl = 'Glocom://*65*CallerId*1PatientContact' WHERE DialerUrl IS NULL OR DialerUrl = ''
GO
USE [$(dbName)]
GO

UPDATE TblTechnicianProfile SET Pin = '44UUgOzIfKuOnUUwyW2A8w==', PinChangeDate = GETDATE()
GO

INSERT into TblPinChangelog
SELECT OrganizationRoleUserId,Pin,1,PinChangeDate,1  FROM TblTechnicianProfile
GO
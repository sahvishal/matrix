USE [$(dbName)]
GO

DECLARE @UpdateDate DATETIME = GETDATE()

UPDATE TblCustomerProfile SET EnableEmailUpdateDate = @UpdateDate 

UPDATE TblCustomerProfileHistory SET EnableEmailUpdateDate = @UpdateDate 
GO

UPDATE CP SET EnableEmail = 0 
FROM TblCustomerProfile CP 
INNER JOIN TblOrganizationRoleUser oru ON CP.CustomerID = ORU.OrganizationRoleUserID
INNER JOIN TblUser u ON oru.UserID = u.UserID 
WHERE (LEN(ISNULL(LTRIM(RTRIM(u.EMail1)),'')) = 0 AND LEN(ISNULL(LTRIM(RTRIM(u.EMail2)),'')) = 0)
	OR DoNotContactTypeId = 287 OR DoNotContactTypeId = 289 --Do Not Contact or Do Not Email
GO

UPDATE CPH SET EnableEmail = 0 
FROM TblCustomerProfileHistory CPH
INNER JOIN TblOrganizationRoleUser oru ON CPH.CustomerID = ORU.OrganizationRoleUserID
INNER JOIN TblUser u ON oru.UserID = u.UserID 
WHERE (LEN(ISNULL(LTRIM(RTRIM(u.EMail1)),'')) = 0 AND LEN(ISNULL(LTRIM(RTRIM(u.EMail2)),'')) = 0)
	OR DoNotContactTypeId = 287 OR DoNotContactTypeId = 289

GO

USE [$(dbName)]
Go

--select TU.FirstName, TU.MiddleName, TU.LastName, 
--TU.FirstName + ' ' + case when Len(Ltrim(Rtrim(isNull(TU.MiddleName,'')))) > 0 Then Ltrim(Rtrim(isNull(TU.MiddleName,''))) + ' ' Else '' End + TU.LastName as FullName
--from TblCustomerEventCriticalTestData TCECTD
--inner join TblOrganizationRoleUser TORU on TCECTD.PhysicianId = TORU.OrganizationRoleUserId
--inner join TblUser TU on TORU.UserId = TU.UserId

update TblCustomerEventCriticalTestData
set Physician = TU.FirstName + ' ' + case when Len(Ltrim(Rtrim(isNull(TU.MiddleName,'')))) > 0 Then Ltrim(Rtrim(isNull(TU.MiddleName,''))) + ' ' Else '' End + TU.LastName
from TblCustomerEventCriticalTestData TCECTD
inner join TblOrganizationRoleUser TORU on TCECTD.PhysicianId = TORU.OrganizationRoleUserId
inner join TblUser TU on TORU.UserId = TU.UserId
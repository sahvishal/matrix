
USE [$(dbName)]
Go

SET IDENTITY_INSERT [dbo].TblBillingAccount ON

insert Into TblBillingAccount
	(BillingAccountId, Name, CustomerKey, UserName, [Password], IsActive)
Values
	(1, 'Specialty Diagnostic Services', 'k6N9PuAvm5iJMTxppLihrQ==', 'yasir@taazaa.com', 'IDu/zCmZQzUaFwfDnrBuJA==', 1)
	
SET IDENTITY_INSERT [dbo].TblBillingAccount ON

--Insert into TblBillingAccountTest
--	(BillingAccountId, TestId)
--values
--	(1, 12)--Lipid
	
Insert into TblBillingAccountTest
	(BillingAccountId, TestId)
values
	(1, 29)--Mammo
	
--Insert into TblBillingAccountTest
--	(BillingAccountId, TestId)
--values
--	(1, 30)--CAD
	
--Insert into TblBillingAccountTest
--	(BillingAccountId, TestId)
--values
--	(1, 31)--FluShot

Insert into TblBillingAccountTest
	(BillingAccountId, TestId)
values
	(1, 32)--AWV
	

	

Update TblTest
set Name = 'Screening mammography, digital', DiagnosisCode = 'V76.12', CPTCode = 'G0202'
where TestID = 29

Update TblTest
set Name = 'Computer-aided detection', DiagnosisCode = 'V76.12', CPTCode = '77052'
where TestID = 30

Update TblTest
set Name = 'Lipid panel', DiagnosisCode = 'V70.0', CPTCode = '80061'
where TestID = 12

Update TblTest
set Name = 'Flu Shot', DiagnosisCode = 'V04.81', CPTCode = '90656'
where TestID = 31

Update TblTest
set Name = 'Annual Wellness Visit', DiagnosisCode = 'V70.0', CPTCode = 'G0438'
where TestID = 32
	

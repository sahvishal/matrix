
USE [$(dbName)]
Go

--Rite Aid
Declare @AccountId bigint
set @AccountId = 946



update TblAccount 
set 	
	CapturePCPConsent=1
	,CaptureABNStatus=1
	,AllowPrePayment=0
	,HICNumberRequired=1
where AccountID = @AccountId


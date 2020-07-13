
USE [$(dbName)]
Go

--PP
Declare @AccountId bigint

Declare @Lead BigInt
Declare @Spirometry BigInt
Declare @PPAAA BigInt
Declare @PPEcho BigInt

set @AccountId = 929

Set @Lead = 35
Set @Spirometry = 36
Set @PPAAA = 37
Set @PPEcho = 38

update TblAccount 
set 	
	 GenerateCustomerResult=0
	,IsCustomerResultsTestDependent=0
	,GeneratePcpResult=1
where AccountID = @AccountId

INSERT INTO [TblAccountPcpResultTestDependency]
           ([AccountId],[TestId])     
select @AccountId, TestId from TblTest where TestID in (@Lead, @Spirometry, @PPAAA, @PPEcho)
     
          
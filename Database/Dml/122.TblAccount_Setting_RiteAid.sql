
USE [$(dbName)]
Go

--Rite Aid
Declare @AccountId bigint
Declare @Stroke bigInt
Declare @PAD bigInt
Declare @ASI bigInt
Declare @AAA bigInt
Declare @EKG bigInt
Declare @AWV BigInt
Declare @Medicare BigInt
Declare @AwvSubsequent BigInt

set @AccountId = 946

set @Stroke=1
set @PAD=2
set @ASI=3
set @AAA=10
set @EKG=11
set @AWV=32
set @Medicare=34
set @AwvSubsequent=41


update TblAccount 
set 	
	GenerateCustomerResult=1
	,IsCustomerResultsTestDependent=1
	,GeneratePcpResult=1
where AccountID = @AccountId


INSERT INTO [TblAccountCustomerResultTestDependency]
           ([AccountId],[TestId]) 
select @AccountId, TestId from TblTest where TestID in (@Stroke, @PAD, @AAA, @EKG, @ASI)

INSERT INTO [TblAccountPcpResultTestDependency]
           ([AccountId],[TestId]) 
select @AccountId, TestId from TblTest where TestID in (@Stroke, @PAD, @AAA, @EKG, @ASI, @AWV, @Medicare, @AwvSubsequent)
     



USE [$(dbName)]
Go

--PP
Declare @AccountId bigint
set @AccountId = 929

Update TblAccount set SendWelcomeEmail = 0 where AccountID = 929


---------------------------

Update TblAccount set SendWelcomeEmail = 0 where AccountID in (361,768,823,824,856,873,883,886,887,890,892,893,895,924,946,947,950,953,958,959,960,961)

     
          
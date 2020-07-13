USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_EventCustomerPreApprovedTestList]    Script Date: 20-01-2017 11:59:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[vw_EventCustomerPreApprovedTestList]    
AS

Select EventCustomerId,TestId  from TblEventCustomerPreApprovedTest
--Union 
--SElect EventCustomerId,TestId from TblEventCustomerPreApprovedPackageTest


GO



USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_CustomerOrderBasicInfo]    Script Date: 12/07/2013 17:55:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create VIEW [dbo].[vw_EventCustomerPreApprovedTestList]    
AS

Select EventCustomerId,TestId  from TblEventCustomerPreApprovedTest
Union 
SElect EventCustomerId,TestId from TblEventCustomerPreApprovedPackageTest

GO



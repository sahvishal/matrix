USE [$(dbName)]
GO

Alter TABLE [dbo].[TblCustomerProfileHistory]
ADD  BillingMemberId VARCHAR(128)
	,BillingMemberPlan VARCHAR(512)
	,BillingMemberPlanYear INT

GO
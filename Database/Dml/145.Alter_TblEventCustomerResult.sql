USE [$(dbName)]
Go

/****** Object:  Index [IX_TblEventCustomerResult_EventId_ResultState_ResultSummary_EventCustomerResultId_INCL_2_6_7_8_9_10_11_13_16_17]    Script Date: 04/20/2015 14:50:13 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TblEventCustomerResult]') AND name = N'IX_TblEventCustomerResult_EventId_ResultState_ResultSummary_EventCustomerResultId_INCL_2_6_7_8_9_10_11_13_16_17')
DROP INDEX [IX_TblEventCustomerResult_EventId_ResultState_ResultSummary_EventCustomerResultId_INCL_2_6_7_8_9_10_11_13_16_17] ON [dbo].[TblEventCustomerResult] WITH ( ONLINE = OFF )
GO

/****** Object:  Index [IX_TblEventCustomerResult_RstState_IsPartial_EventCustRstId_EvtID_CustID_RstSum_INCL_InQueuePri]    Script Date: 04/20/2015 14:50:13 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TblEventCustomerResult]') AND name = N'IX_TblEventCustomerResult_RstState_IsPartial_EventCustRstId_EvtID_CustID_RstSum_INCL_InQueuePri')
DROP INDEX [IX_TblEventCustomerResult_RstState_IsPartial_EventCustRstId_EvtID_CustID_RstSum_INCL_InQueuePri] ON [dbo].[TblEventCustomerResult] WITH ( ONLINE = OFF )
GO

ALTER TABLE dbo.TblEventCustomerResult DROP COLUMN InQueuePriority 
GO
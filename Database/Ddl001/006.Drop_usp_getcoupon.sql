USE [$(dbName)]
Go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_getcoupon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_getcoupon]
GO



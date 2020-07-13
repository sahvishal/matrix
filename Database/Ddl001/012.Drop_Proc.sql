
USE [$(dbName)]
Go

/****** Object:  StoredProcedure [dbo].[usp_savecustomerhealthinformation]    Script Date: 03/23/2012 15:45:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_savecustomerhealthinformation]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_savecustomerhealthinformation]
GO

/****** Object:  StoredProcedure [dbo].[usp_getcustomerhealthquestionnareinfo]    Script Date: 03/23/2012 15:47:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_getcustomerhealthquestionnareinfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_getcustomerhealthquestionnareinfo]
GO


/****** Object:  StoredProcedure [dbo].[usp_savePackageCouponMapping]    Script Date: 03/23/2012 15:49:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_savePackageCouponMapping]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_savePackageCouponMapping]
GO

/****** Object:  StoredProcedure [dbo].[usp_savecouponsignupmode]    Script Date: 03/23/2012 15:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_savecouponsignupmode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_savecouponsignupmode]
GO

/****** Object:  StoredProcedure [dbo].[usp_getendofdaylist]    Script Date: 03/23/2012 15:51:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_getendofdaylist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_getendofdaylist]
GO


/****** Object:  StoredProcedure [dbo].[usp_updatecouponused]    Script Date: 03/23/2012 15:53:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_updatecouponused]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_updatecouponused]
GO

/****** Object:  StoredProcedure [dbo].[usp_saveeventcoupon]    Script Date: 03/23/2012 15:55:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_saveeventcoupon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_saveeventcoupon]
GO

/****** Object:  StoredProcedure [dbo].[usp_savecoupon]    Script Date: 03/23/2012 15:56:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_savecoupon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_savecoupon]
GO

/****** Object:  StoredProcedure [dbo].[usp_getcustomerhealthquestionnaire]    Script Date: 03/23/2012 16:02:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_getcustomerhealthquestionnaire]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_getcustomerhealthquestionnaire]
GO

/****** Object:  StoredProcedure [dbo].[usp_getcustomerbycustomereventtestid]    Script Date: 03/23/2012 16:08:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_getcustomerbycustomereventtestid]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_getcustomerbycustomereventtestid]
GO

/****** Object:  StoredProcedure [dbo].[usp_getCouponValueByCouponCode]    Script Date: 03/23/2012 16:10:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_getCouponValueByCouponCode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_getCouponValueByCouponCode]
GO

/****** Object:  StoredProcedure [dbo].[usp_gettestformanualentry]    Script Date: 03/23/2012 16:20:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_gettestformanualentry]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_gettestformanualentry]
GO

/****** Object:  StoredProcedure [dbo].[usp_savepartialcustomerdetails]    Script Date: 03/23/2012 16:21:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_savepartialcustomerdetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_savepartialcustomerdetails]
GO













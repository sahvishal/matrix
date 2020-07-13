USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD SlotBooking BIT NOT NULL CONSTRAINT DF_TblAccount_SlotBooking DEFAULT 0,
		AddImagesForAbnormal Bit Not Null CONSTRAINT DF_TblAccount_AddImagesForAbnormal DEFAULT 0,
		BookPcpAppointment Bit Not Null CONSTRAINT DF_TblAccount_BookPcpAppointment DEFAULT 0,
		NumberOfDays Int Not Null CONSTRAINT DF_TblAccount_NumberOfDays DEFAULT 0
		
GO
 
 
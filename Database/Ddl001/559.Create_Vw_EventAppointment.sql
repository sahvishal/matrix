USE [$(dbName)]
GO

IF OBJECT_ID ('Vw_EventAppointment', 'view') IS NOT NULL  
	DROP VIEW Vw_EventAppointment;  
GO 

CREATE VIEW Vw_EventAppointment
As

SELECT [AppointmentID]
      ,[EventID]
      ,[StartTime]
      ,[EndTime]
      ,[CheckinTime]
      ,[CheckoutTime]
      ,[DateCreated]
      ,[DateModified]
      ,[ScheduledByOrgRoleUserId]
FROM [TblEventAppointment] WITH (NOLOCK)
GO

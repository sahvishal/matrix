USE [$(dbname)]
GO

IF OBJECT_ID ('Vw_HostEventDetails', 'view') IS NOT NULL  
	DROP VIEW Vw_HostEventDetails;  
GO 

CREATE VIEW Vw_HostEventDetails
As

SELECT [HostEventID]
      ,[HostID]
      ,[EventID]
      ,[bConfirmMinRequirements]
      ,[bConfirmedVisually]
      ,[ConfirmedVisuallyComments]
      ,[DateCreated]
      ,[DateModified]
      ,[DepositAmount]
      ,[PayByCheck]
      ,[PayByCreditCard]
      ,[PaymentDueDate]
      ,[DepositDueDate]
      ,[InstructionForCallCenter]
      ,[IsHostRatedbyTechnician]
FROM [TblHostEventDetails] WITH (NOLOCK)
GO
use [$(dbName)]
go

IF OBJECT_ID ('Vw_GetDirectMailForCallQueue', 'view') IS NOT NULL  
	DROP VIEW Vw_GetDirectMailForCallQueue 
GO 

CREATE VIEW Vw_GetDirectMailForCallQueue
As

SELECT  Id, CustomerId, MailDate, MailedBy, CallUploadId, CampaignId, DirectMailTypeId, IsInvalidAddress, Notes
FROM TblDirectMail with(Nolock)
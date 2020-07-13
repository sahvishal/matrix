USE [$(dbName)]
Go

SET IDENTITY_INSERT TblScriptType ON

insert into TblScriptType
	(ScriptTypeID, ScriptName, [Description], DateCreated, DateModified, IsActive)
Values
	(27, 'OutboundCallQueueScript', 'Outbound Call Queue Script', GETDATE(), GETDATE(), 1)
	
SET IDENTITY_INSERT TblScriptType OFF
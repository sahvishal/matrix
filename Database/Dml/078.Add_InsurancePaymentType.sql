
USE [$(dbName)]
Go

SET IDENTITY_INSERT [TblPaymentType] ON

insert Into TblPaymentType
	(PaymentTypeId, Name, [Description], Alias, DateCreated, DateModified, IsActive)
Values
	(9, 'Insurance', 'Insurance', 'Insurance', GETDATE(), GETDATE(), 1)
	
SET IDENTITY_INSERT [TblPaymentType] OFF


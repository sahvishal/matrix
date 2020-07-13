USE [$(dbName)]
GO

Alter Table TblEvents 
	ADD UpdatedByAdmin bigInt NULL
	,IsManual  BIT not null CONSTRAINT DF_TblEvents_IsManual DEFAULT 0 
	,CONSTRAINT FK_TblEvents_TblOrganizationRoleUser_UpdatedByAdmin FOREIGN KEY([UpdatedByAdmin]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId])

Go
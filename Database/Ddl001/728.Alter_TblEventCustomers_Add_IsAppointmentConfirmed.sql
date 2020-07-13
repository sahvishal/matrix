USE [$(dbname)]
GO

ALTER TABLE TblEventCustomers
ADD IsAppointmentConfirmed BIT NOT NULL CONSTRAINT DF_TblEventCustomers_IsAppointmentConfirmed DEFAULT 0,
	ConfirmedBy BIGINT NULL,
	CONSTRAINT FK_TblEventCustomers_TblOrganizationRoleUser_ConfirmedBy FOREIGN KEY([ConfirmedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId])

GO
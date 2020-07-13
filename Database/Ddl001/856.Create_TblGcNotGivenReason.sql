USE[$(dbName)]
GO

CREATE Table [TblGcNotGivenReason]
(
Id bigint not null,
[Name] varchar(512) not null,
Alias varchar(512) not null,
DateCreated datetime not null,
CreatedBy bigint not null,
IsActive bit not null Constraint DF_TblGcNotGivenReason_IsActive Default (1),
DateModified datetime null,
ModifiedBy bigint null,
 CONSTRAINT [PK_TblGcNotGivenReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE TblGcNotGivenReason WITH CHECK ADD CONSTRAINT
[FK_TblGcNotGivenReason_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY ([CreatedBy])
REFERENCES TblOrganizationRoleUser([OrganizationRoleUserID])

GO

ALTER TABLE TblGcNotGivenReason WITH CHECK ADD CONSTRAINT
[FK_TblGcNotGivenReason_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY ([ModifiedBy])
REFERENCES [TblOrganizationRoleUser] ([OrganizationRoleUserID])

GO
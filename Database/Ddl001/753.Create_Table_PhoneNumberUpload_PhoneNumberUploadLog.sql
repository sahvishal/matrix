Use [$(dbName)]

GO

CREATE TABLE TblCustomerPhoneNumberUpdateUpload
(
Id bigint IDENTITY (1, 1) NOT NULL, 
FileId bigint NOT NULL,
StatusId bigint NOT NULL, 
SuccessUploadCount bigint NOT NULL, 
FailedUploadCount bigint NOT NULL, 
UploadTime datetime NOT NULL, 
ParseStartTime datetime Null, 
ParseEndTime datetime Null, 
UploadedByOrgRoleUserId bigint Not Null,
)

GO

Alter Table TblCustomerPhoneNumberUpdateUpload
Add Constraint PK_TblCustomerPhoneNumberUpdateUpload PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblCustomerPhoneNumberUpdateUpload
Add Constraint FK_TblCustomerPhoneNumberUpdateUpload_TblFile_FileId Foreign Key ([FileId])
References [TblFile](FileId)

GO

Alter Table TblCustomerPhoneNumberUpdateUpload
Add Constraint FK_TblCustomerPhoneNumberUpdateUpload_TblLookup_StatusId Foreign Key ([StatusId])
References [TblLookup](LookupId)

GO

Alter Table TblCustomerPhoneNumberUpdateUpload
Add Constraint FK_TblCustomerPhoneNumberUpdateUpload_TblOrganizationRoleUser_UploadedByOrgRoleUserId 
Foreign Key ([UploadedByOrgRoleUserId])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

CREATE TABLE TblCustomerPhoneNumberUpdateUploadLog
(
Id bigint IDENTITY (1,1) NOT NULL, 
UploadId bigint NOT NULL,
CustomerId varchar(50) NULL, 
FirstName varchar(50) NULL, 
LastName varchar(50) NULL,
DOB varchar(20) NULL, 
MemberId varchar(100) NULL, 
PhoneNumber varchar(50) NULL, 
PhoneType varchar(20) NULL,
IsSuccessful bit NOT NULL,
ErrorMessage nvarchar(2048)
)

GO

Alter Table TblCustomerPhoneNumberUpdateUploadLog
Add Constraint DF_TblCustomerPhoneNumberUpdateUploadLog_IsSuccessful
Default 0 for [IsSuccessful]

GO

Alter Table TblCustomerPhoneNumberUpdateUploadLog
Add Constraint PK_TblCustomerPhoneNumberUpdateUploadLog PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblCustomerPhoneNumberUpdateUploadLog
Add Constraint FK_TblCustomerPhoneNumberUpdateUploadLog_TblCustomerPhoneNumberUpdateUpload_UploadId Foreign Key ([UploadId])
References [TblCustomerPhoneNumberUpdateUpload](Id)

GO


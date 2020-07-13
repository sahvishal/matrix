USE [$(dbName)]

GO

CREATE TABLE [dbo].[TblAccountAdditionalFields](
	AccountId bigint not null,
	AdditionalFieldId bigint not null ,
	DisplayName nvarchar(255) not null
) 

alter table [TblAccountAdditionalFields] ADD CONSTRAINT CK_TblAccountAdditionalFields_TblAccount Primary KEY (AccountId,AdditionalFieldId) 

alter table [TblAccountAdditionalFields] ADD CONSTRAINT FK_TblAccountAdditionalFields_TblAdditionalFields FOREIGN KEY (AdditionalFieldId) REFERENCES TblAdditionalFields(Id)

alter table [TblAccountAdditionalFields] ADD CONSTRAINT FK_TblAccountAdditionalFields_TblAccount FOREIGN KEY (AccountID) REFERENCES TblAccount(AccountId)
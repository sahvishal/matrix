USE [$(dbName)]
GO

ALTER TABLE TblAccount
ADD IncludeMemberLetter BIT NOT NULL CONSTRAINT DF_TblAccount_IncludeMemberLetter DEFAULT 0,
 MemberLetterFileId BIGINT NULL	CONSTRAINT FK_TblAccount_TblFile_MemberLetterFileId FOREIGN KEY([MemberLetterFileId]) REFERENCES [TblFile]([FileId])

GO
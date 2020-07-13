USE [$(dbname)]
GO

ALTER TABLE TblChaperoneSignature
DROP CONSTRAINT PK_TblChaperoneSignature

ALTER TABLE TblChaperoneSignature
DROP COLUMN ConsentSignedDate
GO

ALTER TABLE TblChaperoneSignature
ADD StaffSignatureFileId BIGINT NOT NULL
GO

ALTER TABLE TblChaperoneSignature
ALTER COLUMN SignatureFileId BIGINT NULL
GO

ALTER TABLE TblChaperoneSignature
ADD CONSTRAINT PK_TblChaperoneSignature PRIMARY KEY (EventCustomerId, StaffSignatureFileId)
GO

ALTER TABLE TblChaperoneSignature
ADD CONSTRAINT FK_TblChaperoneSignature_TblFile_StaffSignatureFileId
FOREIGN KEY (StaffSignatureFileId)
REFERENCES [TblFile](FileId)
GO


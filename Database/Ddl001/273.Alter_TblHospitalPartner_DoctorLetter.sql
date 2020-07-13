USE [$(dbName)]
Go


ALTER TABLE dbo.TblHospitalPartner ADD
	AttachDoctorLetter bit NOT NULL CONSTRAINT DF_TblHospitalPartner_AttachDoctorLetter DEFAULT 1
GO

Alter Table TblMedicalVendorProfile Add DoctorLetterFileId bigint NULL
Go

ALTER TABLE [dbo].[TblMedicalVendorProfile]  WITH CHECK ADD  CONSTRAINT [FK_TblFile_TblMedicalVendorProfile_DoctorLetter] FOREIGN KEY([DoctorLetterFileId])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblMedicalVendorProfile] CHECK CONSTRAINT [FK_TblFile_TblMedicalVendorProfile_DoctorLetter]
GO



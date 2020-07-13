
USE [$(dbName)]
GO

Alter Table TblEventCustomers Add HospitalFacilityId bigint null
GO

ALTER TABLE [dbo].[TblEventCustomers]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomers_TblHospitalFacility] FOREIGN KEY([HospitalFacilityId])
REFERENCES [dbo].[TblHospitalFacility] ([HospitalFacilityId])
GO

ALTER TABLE [dbo].[TblEventCustomers] CHECK CONSTRAINT [FK_TblEventCustomers_TblHospitalFacility]
GO
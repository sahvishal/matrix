USE [$(dbname)]
GO
-- run query on for Optum NV and Optum NV Medicare
Update TblCustomerProfile SET Mrn = AdditionalField4 Where Tag='Optum NV' and AdditionalField4 is not null and AdditionalField4 <> ''
GO


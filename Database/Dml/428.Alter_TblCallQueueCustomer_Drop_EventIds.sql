USE [$(dbname)]
GO

----Column dropped in DML due to its usage in Healthplan Settings script

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]') AND name = N'IX_TblCallQueueCustomer_PCID_CQCID_CID_Status_INCL_K4_K1_K3_K5_2_6_7_8_9_10_11_12_13_14_15_16_17_18_19')
DROP INDEX [IX_TblCallQueueCustomer_PCID_CQCID_CID_Status_INCL_K4_K1_K3_K5_2_6_7_8_9_10_11_12_13_14_15_16_17_18_19] ON [TblCallQueueCustomer]
GO

ALTER TABLE TblCallQueueCustomer
DROP COLUMN EventIds
GO
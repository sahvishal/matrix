
USE [$(dbName)]
Go


ALTER TABLE TblCustomerSkipReview Add IsSkipEvaluation bit not null  CONSTRAINT DF_TblCustomerSkipReview_IsSkipEvaluation DEFAULT 1
GO

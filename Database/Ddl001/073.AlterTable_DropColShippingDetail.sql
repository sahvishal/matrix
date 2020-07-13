USE [$(dbName)]
Go

Alter Table TblShippingDetail Drop Column CarrierTransactionNumber
Alter Table TblShippingDetail Drop Column TrackingNumber
Alter Table TblShippingDetail Drop Column ShipmentNotes
Alter Table TblShippingDetail Drop Column ShipToName
Alter Table TblShippingDetail Drop Column DeliveryDate
Alter Table TblShippingDetail Drop Column DeliveryRecipientName

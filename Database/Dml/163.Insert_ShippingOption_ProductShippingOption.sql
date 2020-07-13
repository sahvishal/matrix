USE [$(dbName)]
GO 
Declare @ShippingOptionId bigint,@ProductId bigint

INSERT INTO [TblShippingOption]
           ([Name],[Type],[CarrierID],[Description],[Price],[CostToCompany],[Disclaimer],[ShippableToPOBox],[IsActive],[DateCreated],[DateModified],[ForOrderDisplayHtmlString])
     VALUES
           ('PCP-Free paper copy mailed',1,1,'A high-quality color printout of your results packet, will be shipped your address on file.  Results are typically delivered in 3 to 4 weeks; however this may vary depending on the time of year and holiday schedule.',
           0.0,0.0,'Re-shipment(s) due to incorrect address information are the responsibility of the customer.',0,1,GETDATE(),GETDATE(),null)
           
SET @ShippingOptionId = SCOPE_IDENTITY()
           
SELECT @ProductId = ProductID FROM TblProduct WHERE Name= 'Ultrasound Images'
           
INSERT INTO [TblProductShippingOption]
           ([ProductId],[ShippingOptionId],[IsShowVisible],[IsForPcp])
     VALUES
			(@ProductId,@ShippingOptionId,0,1)
			
GO







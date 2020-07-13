USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_CustomerEventBasicInfo]    Script Date: 12/07/2013 17:51:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[vw_CustomerEventBasicInfo]
AS
SELECT DISTINCT 
                      dbo.TblCustomerProfile.CustomerID
                      ,dbo.TblEventCustomers.EventCustomerID
                      ,TblUser_1.FirstName
                      ,TblUser_1.LastName
                      ,dbo.TblCustomerProfile.TrackingMarketingID AS SignUpMarketingSource
                      ,dbo.TblCustomerProfile.AddedByRoleID AS CustomerSignupMode
                      ,EventRegTORU.RoleID AS EventSignupMode
                      ,dbo.TblEventCustomers.DateCreated AS EventSignupDate
                      ,dbo.TblEventCustomers.EventID 
                      ,dbo.TblEvents.EventName
                      ,dbo.TblEvents.EventDate
                      ,TblUser_1.DateCreated AS CustomerSignupDate
                      ,CASE WHEN LEN(ISNULL(Package.[PackageName],''))>0
						THEN 
							CASE WHEN LEN(ISNULL(Test.[AdditionalTest],''))>0
									THEN Package.[PackageName] + '+ ' + REPLACE(Test.[AdditionalTest],',','+')
								ELSE Package.[PackageName]
							END 
						ELSE REPLACE(Test.[AdditionalTest],',','+')
					   END AS PackageName
                      ,dbo.TblPodDetails.Name AS PodName
                      ,dbo.TblEvents.AssignedToOrgRoleUserId
                      ,[vw_EventCustomerRevenue].[EffectiveCost] AS PaymentTotalAmount 
                      ,CONVERT(BIT,CASE WHEN [vw_EventCustomerRevenue].[EffectiveCost]> ISNULL([vw_EventCustomerPaymentNewOrderSystem].TotalPayment,0)
							THEN 0
							ELSE 1
						END)[IsPaid]
                      ,Convert(bit, 0) AS DrOrCr
                      ,[vw_EventCustomerRevenue].[CouponCode] 
                      ,dbo.TblCalls.IncomingPhoneLine
                      ,dbo.TblCalls.CallersPhoneNumber
                      ,dbo.TblCalls.CallStatus
                      ,dbo.TblEventPod.IsActive AS IsPodActive
                      ,dbo.TblUser.FirstName AS SalesRepFirstName
                      ,dbo.TblUser.MiddleName AS SalesRepMiddleName
                      ,dbo.TblUser.LastName AS SalesRepLastName
                      ,dbo.TblEventCustomers.MarketingSource
                      ,TblUser_1.HomeAddressID
                      ,dbo.vw_Address.Address1
                      ,dbo.vw_Address.Address2
                      ,dbo.vw_Address.CityID
                      ,dbo.vw_Address.City
                      ,dbo.vw_Address.StateID
                      ,dbo.vw_Address.State
                      ,dbo.vw_Address.ZipID
                      ,dbo.vw_Address.ZipCode
                      ,([vw_EventCustomerPaymentNewOrderSystem].[CreditCardPayment]
						+ [vw_EventCustomerPaymentNewOrderSystem].[CheckPayment]
						+ [vw_EventCustomerPaymentNewOrderSystem].[CashPayment]
						+ [vw_EventCustomerPaymentNewOrderSystem].[ECheckPayment]
						+ [vw_EventCustomerPaymentNewOrderSystem].[GCPayment]
						+ [vw_EventCustomerPaymentNewOrderSystem].[InsurancePayment]
						) AS PaidAmount
					
                      ,([vw_EventCustomerRevenue].[EffectiveCost] -
							(
								ISNULL([vw_EventCustomerPaymentNewOrderSystem].[CreditCardPayment],0)
								+ ISNULL([vw_EventCustomerPaymentNewOrderSystem].[CheckPayment],0)
								+ ISNULL([vw_EventCustomerPaymentNewOrderSystem].[CashPayment],0)
								+ ISNULL([vw_EventCustomerPaymentNewOrderSystem].[ECheckPayment],0)
								+ ISNULL([vw_EventCustomerPaymentNewOrderSystem].[GCPayment],0)
								+ ISNULL([vw_EventCustomerPaymentNewOrderSystem].[InsurancePayment],0)
							) 
						)AS UnpaidAmount
					  					
                      ,[vw_EventCustomerRevenue].[EffectiveCost] AS PaymentNet
                      ,dbo.TblEvents.EventStatus
                      ,[vw_EventCustomerRevenue].ScreeningCost AS [PackagePrice]
FROM         dbo.vw_Address 
					  RIGHT OUTER JOIN dbo.TblUser AS TblUser_1 WITH (NOLOCK) ON dbo.vw_Address.AddressID = TblUser_1.HomeAddressID 
                      RIGHT OUTER JOIN TblOrganizationRoleUser CustTORU WITH (NOLOCK) on CustTORU.UserId = TblUser_1.UserId
					  RIGHT OUTER JOIN dbo.TblUser WITH (NOLOCK)
                      INNER JOIN dbo.TblEvents WITH (NOLOCK)
                      INNER JOIN dbo.TblOrganizationRoleUser WITH (NOLOCK) ON dbo.TblEvents.AssignedToOrgRoleUserId = dbo.TblOrganizationRoleUser.OrganizationRoleUserId 
                      
                      ON dbo.TblUser.UserID = dbo.TblOrganizationRoleUser.UserID 
                      RIGHT OUTER JOIN dbo.TblCalls WITH (NOLOCK)
                      RIGHT OUTER JOIN dbo.TblCustomerProfile WITH (NOLOCK)
                      RIGHT OUTER JOIN dbo.TblEventCustomers WITH (NOLOCK) ON dbo.TblCustomerProfile.CustomerID = dbo.TblEventCustomers.CustomerID 
					  RIGHT OUTER JOIN TblOrganizationRoleUser EventRegTORU WITH (NOLOCK) on EventRegTORU.OrganizationRoleUserId = TblEventCustomers.CreatedByOrgRoleUserId
                      LEFT OUTER JOIN [vw_EventCustomerRevenue] ON [vw_EventCustomerRevenue].EventCustomerID=TblEventCustomers.[EventCustomerID]
                      LEFT OUTER JOIN dbo.vw_EventCustomerPaymentNewOrderSystem ON dbo.TblEventCustomers.EventCustomerID = dbo.vw_EventCustomerPaymentNewOrderSystem.EventCustomerID 
                      
                      ON dbo.TblCalls.CalledCustomerID = dbo.TblEventCustomers.CustomerID 
                      
						LEFT OUTER JOIN
						(
							SELECT ec.EventCustomerId, ISNULL(TP.PackageName,'') PackageName
							FROM [TblOrderDetail] TOD WITH (NOLOCK)
							INNER JOIN TblOrderItem TPI WITH (NOLOCK) ON TPI.OrderItemId = TOD.OrderItemId 
							INNER JOIN TblEventPackageOrderItem TEPOI WITH (NOLOCK) On TEPOI.OrderItemId = TPI.OrderItemId
							INNER JOIN [TblEventPackageDetails] TEPD WITH (NOLOCK) ON TEPOI.[EventPackageID]=TEPD.[EventPackageID]
							INNER JOIN [TblPackage] TP WITH (NOLOCK) ON TEPD.[PackageID] = TP.[PackageID]
							INNER JOIN 
							( 
								SELECT [OrderID],[EventCustomerId]  from  tblEventCustomerOrderDetail ecod   WITH (NOLOCK)
								INNER JOIN tblOrderDetail od  WITH (NOLOCK) on ecod.OrderDetailId = od.OrderDetailId
								WHERE ecod.[IsActive]=1  
							) ec ON ec.OrderID=TOD.[OrderID]
							WHERE TOD.Status=1 AND TPI.[Type]=1
						)Package ON Package.EventCustomerId=TblEventCustomers.EventCustomerID	 
						LEFT OUTER JOIN 
						(
							SELECT TOP 100 PERCENT b.EventCustomerID,
							STUFF
							(
								(SELECT  TOP 100 PERCENT ', ' + [Name] FROM 
									(     
										SELECT   [Name],[EventCustomerId]
										FROM tblOrderDetail od WITH (NOLOCK) INNER join  tblOrderItem oi WITH (NOLOCK) on od.OrderItemId = oi.OrderItemId
										INNER join  tblEventTestOrderItem etoi WITH (NOLOCK) on oi.OrderItemId = etoi.OrderItemId
										INNER join  tblEventTest et  WITH (NOLOCK) on etoi.EventTestId = et.EventTestId
										INNER JOIN [TblTest]  WITH (NOLOCK) ON et.[TestID] = [TblTest].[TestID] 
										INNER JOIN ( 
										SELECT [OrderID],[EventCustomerId]  from  tblEventCustomerOrderDetail ecod   WITH (NOLOCK)
										INNER JOIN tblOrderDetail od  WITH (NOLOCK) on ecod.OrderDetailId = od.OrderDetailId
										WHERE ecod.[IsActive]=1  ) ec ON ec.OrderID=od.[OrderID]
										AND  od.Status =1 AND  oi.[TYPE] = 4
									) 
									vw_Test
								WHERE b.eventcustomerid = vw_Test.eventcustomerid
								ORDER BY ',' + vw_Test.Name FOR XML PATH('')
							), 1, 1, '') AS AdditionalTest
							FROM  tbleventcustomers AS b WITH (NOLOCK)
							ORDER BY b.[EventCustomerID]
						)Test ON Test.EventCustomerID=TblEventCustomers.EventCustomerID
						
                      ON dbo.TblEvents.EventID = dbo.TblEventCustomers.EventID 
                      LEFT OUTER JOIN dbo.TblEventPod WITH (NOLOCK)
                      LEFT OUTER JOIN dbo.TblPodDetails WITH (NOLOCK) ON dbo.TblEventPod.PodID = dbo.TblPodDetails.PodID 
                      ON dbo.TblEvents.EventID = dbo.TblEventPod.EventID 
                      ON CustTORU.OrganizationRoleUserId = dbo.TblCustomerProfile.CustomerID
WHERE     (dbo.TblCalls.CallStatus = 'Register New Customer') OR
                      (dbo.TblCalls.CallStatus = 'Existing Customer') OR
                      (dbo.TblCalls.CallStatus IS NULL)


GO



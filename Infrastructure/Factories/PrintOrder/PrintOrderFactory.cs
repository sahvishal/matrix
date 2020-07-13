using System;
using System.Collections.Generic;
using System.IO;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Marketing.Interfaces;


namespace Falcon.App.Infrastructure.Factories.PrintOrder
{
    public class PrintOrderFactory : IPrintOrderFactory
    {
        public List<PrintOrderItem> CreatePrintOrderItemShipping(string filePath, OrganizationRoleUser statusUpdatedBy)
        {
            var listPrintOrderItem = new List<PrintOrderItem>();

            string row;
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();/// just to skip first line
                while (reader.Peek() != -1)
                {
                    row = reader.ReadLine();
                    string[] uplodedData = row.Split(new char[] { ',' });

                    if (uplodedData.Length > 13)
                    {
                        ItemStatus itemShippingStatus;

                        string shippingStatus = uplodedData[2].Replace(" ", "");
                        try
                        {
                            itemShippingStatus = (ItemStatus)Enum.Parse(typeof(ItemStatus), shippingStatus);

                        }
                        catch (Exception)
                        {
                            itemShippingStatus = ItemStatus.Unknown;

                        }
                        DateTime scheduledDeliveryDate;



                        DateTime.TryParse(uplodedData[3], out scheduledDeliveryDate);
                        string[] updatedSourceCode = uplodedData[13].Split(new[] { '/' });

                        foreach (string sourceCode in updatedSourceCode)
                        {
                            var printOrderItem = new PrintOrderItem();
                            var printOrderItemShipping = new PrintOrderItemTracking
                                                             {
                                                                 TrackingNumber = uplodedData[0],
                                                                 ShippingService = uplodedData[1],
                                                                 ///ShippingStatus = itemShippingStatus,
                                                                 ScheduledDeliveryDate = DateTime.TryParse(uplodedData[3], out scheduledDeliveryDate) ? scheduledDeliveryDate : (DateTime?)null,
                                                                 ShipToName = uplodedData[4],
                                                                 ShipToAttentionOf = uplodedData[5],
                                                                 ShippedToAddress1 = uplodedData[6],
                                                                 ShippedToAddress2 = uplodedData[7],
                                                                 ShippedToCity = uplodedData[8],
                                                                 ShippedToZip = uplodedData[9],
                                                                 ShippedToState = uplodedData[10],
                                                                 PackageReference1 = uplodedData[11],
                                                                 PackageReference2 = uplodedData[12],
                                                                 CreatedByOrgRoleUser = statusUpdatedBy,
                                                                 DateCreated = DateTime.Now,
                                                                 DateUpdated = DateTime.Now,
                                                                 UpdatedByOrgRoleUser = statusUpdatedBy,
                                                                 ConfirmationMode = null,
                                                             };

                            printOrderItemShipping.PackageReference3 = sourceCode;
                            printOrderItem.TrackingInfo = printOrderItemShipping;
                            printOrderItem.Status = itemShippingStatus;
                            listPrintOrderItem.Add(printOrderItem);
                        }

                    }
                }

            }
            return listPrintOrderItem;
        }


    }
}
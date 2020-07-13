using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.Linq;
using System.Reflection;
namespace Falcon.App.Infrastructure.Repositories.PrintOrder
{

    public class PrintOrderRepository : PersistenceRepository
    {
        private const string IncomingPhoneLineForPrintOrder = "8005559190";
        private const char CsvSeprator = ',';
        private const char SourceCodeSeprator = '/';

        private readonly IPrintOrderItemReposistory _printOrderItemReposistory = new PrintOrderItemRepository();

        public void AssignPrintOrderToPrintVendor(OrganizationRoleUser assignedBy,
            long printOrderId, long printVendorId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var printOrderData = linqMetaData.MarketingPrintOrder.Where(
                        printOrder => printOrder.MarketingPrintOrderId == printOrderId && printOrder.PrintVendorOrganizationId == null
                    ).SingleOrDefault();

                if (printOrderData != null)
                {
                    printOrderData.PrintVendorOrganizationId = printVendorId;
                    printOrderData.DateAssigned = DateTime.Now;
                    printOrderData.Status = ItemStatus.Assigned.ToString();
                    if (!myAdapter.SaveEntity(printOrderData, false, false))
                    {
                        throw new PersistenceFailureException();
                    }


                    var printOrderItems = linqMetaData.MarketingPrintOrderItem.Where(
                        printOrderItem => printOrderItem.MarketingPrintOrderId == printOrderData.MarketingPrintOrderId
                        ).ToList();


                    foreach (var orderItem in printOrderItems)
                    {

                        orderItem.Status = (long)ItemStatus.Assigned;
                        orderItem.DateModified = DateTime.Now;
                        if (!myAdapter.SaveEntity(orderItem, false, false))
                        {
                            throw new PersistenceFailureException();
                        }
                    }
                }
            }
        }

        public OrderedPair<string, PrintOrderItemTracking> UpdatePrintOrderShipping(PrintOrderItemTracking printOrderItemShipping, ItemStatus itemStatus,
            OrganizationRoleUser statusUpdatedBy)
        {

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {
                    printOrderItemShipping.PackageReference3 = printOrderItemShipping.PackageReference3.Trim();
                    
                    var printOrderItemData = linqMetaData.MarketingPrintOrderItem.
                        Join(
                        linqMetaData.Coupons.Where(
                            coupons => coupons.CouponCode == printOrderItemShipping.PackageReference3),
                        printOrderItem => printOrderItem.SourceCodeId, coupons => coupons.CouponId,
                        (printOrder, coupon) => new { printOrder }).Select(printOrder => printOrder.printOrder).
                        Where(@t => @t.IsActive).
                        FirstOrDefault();

                    var printOrderItemTrackingData = linqMetaData.PrintOrderItemTracking.Where(
                        printOrderItemTracking => printOrderItemTracking.PackageReference3 == (printOrderItemShipping.PackageReference3)
                           ).FirstOrDefault();
                    //ToDo: make one condition
                    if (printOrderItemData != null)
                    {
                        var printOrderItemShippingRepository = new PrintOrderItemTrackingRepository();
                        printOrderItemShipping.PrintOrderItemId = printOrderItemData.MarketingPrintOrderItemId;
                        printOrderItemShipping.PrintOrderItemShippingId = printOrderItemTrackingData != null
                                                                              ? printOrderItemTrackingData.
                                                                                    PrintOrderItemShippingId
                                                                              : 0;
                        //ToDo: check the status of printorderitem
                        /// if ((printOrderItemTrackingData == null) || (!printOrderItemTrackingData.ConfirmationState))

                        if ((printOrderItemTrackingData == null || (printOrderItemData.Status != (long)ItemStatus.Confirmed)))
                        {
                            printOrderItemShippingRepository.Save(printOrderItemShipping);
                            //ToDo:Update status in tblMarketingprintorderitem
                            _printOrderItemReposistory.UpdatePrintOrderItemStatus(
                                printOrderItemData.MarketingPrintOrderItemId, itemStatus);
                        }
                        else
                        {
                            return
                                new OrderedPair<string, PrintOrderItemTracking>(
                                    "Package Reference :" + printOrderItemShipping.PackageReference3 +
                                    " is already delivered and receipt is acknowledge by the " +
                                    printOrderItemShipping.ShipToAttentionOf, printOrderItemShipping);
                        }
                    }
                    else
                    {
                        return new OrderedPair<string, PrintOrderItemTracking>("No Record found for Package Reference :" + printOrderItemShipping.PackageReference3, printOrderItemShipping);
                    }
                }
                catch (Exception)
                {
                    return new OrderedPair<string, PrintOrderItemTracking>("Database Error. Please contact.", printOrderItemShipping);

                }
                return null;
            }
        }

        public List<OrderedPair<string, PrintOrderItemTracking>> ParsePrintOrderShippingCsv(string filePath, OrganizationRoleUser statusUpdatedBy, out Int32 successRecordCount)
        {
            return ParsePrintOrderShipping(filePath, CsvSeprator, statusUpdatedBy, out successRecordCount);
        }

        public Boolean ValidatePrintOrderShippingCsv(string filePath)
        {
            return ValidateFile(filePath, CsvSeprator, typeof(PrintOrderItemShippingParser));
        }

        public Boolean IsPhoneNumberForPrintOrderConfirmation(string phoneNumber)
        {
            ///ToDo:For the release it is hardcoded. once decided it will fetced from the DB.
            return phoneNumber == IncomingPhoneLineForPrintOrder;
        }

        public Boolean IsPrintOrderEditable(long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {
                    var printOrder = linqMetaData.MarketingPrintOrder.Join(
                        linqMetaData.MarketingPrintOrderEventMapping, item => item.MarketingPrintOrderId,
                        eventMapping => eventMapping.MarketingPrintOrderId,
                        (item, eventMapping) => new { item.Status, eventMapping.EventId }
                        ).Where(@t => @t.EventId == eventId).SingleOrDefault();

                    //Todo: in the print order table status is text filed and we are considering Draft and Placed interchangeble.
                    if ((printOrder != null) && (printOrder.Status != "Draft" && printOrder.Status != ItemStatus.Placed.ToString()))
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return true;
                }
                return true;
            }
        }

        public Boolean ValidateParsedFile(string filePath, char seprator)
        {
            var parserObject =
                (PrintOrderItemShippingParser)
                SetParserObject(filePath, seprator, typeof(PrintOrderItemShippingParser));
            var properties = parserObject.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                if (Convert.ToInt32(propertyInfo.GetValue(parserObject, null)) == 0)
                    return false;
            }

            return true;
        }

        public List<OrderedPair<string, PrintOrderItemTracking>> ParsePrintOrderShipping(string filePath, char seprator,
            OrganizationRoleUser statusUpdatedBy, out Int32 successRecordCount)
        {
            var failedRecordList = new List<OrderedPair<string, PrintOrderItemTracking>>();
            successRecordCount = 0;
            
            using (var reader = new StreamReader(filePath))
            {
                string rowHeader = reader.ReadLine();
                var parserObject = (PrintOrderItemShippingParser)SetParserObject(rowHeader, seprator, typeof(PrintOrderItemShippingParser));

                while (reader.Peek() != -1)
                {
                    string row = reader.ReadLine();
                   
                    string[] uplodedData = row.Split(seprator);
                    PrintOrderItem printOrderItem;
                    var printOrderItemTracking = new PrintOrderItemTracking();
                    try
                    {
                        printOrderItem = new PrintOrderItem();
                        printOrderItemTracking = SetUpPrintOrderItemTracking(uplodedData, parserObject,
                                                                              statusUpdatedBy);
                        ItemStatus itemShippingStatus;
                        string shippingStatus = uplodedData[parserObject.Status].Replace(" ", "");
                        try
                        {
                            itemShippingStatus = (ItemStatus)Enum.Parse(typeof(ItemStatus), shippingStatus);
                        }
                        catch (Exception)
                        {
                            itemShippingStatus = ItemStatus.Unknown;
                        }

                        string[] updatedSourceCode = uplodedData[parserObject.PackageReferenceNo3].Split(SourceCodeSeprator);
                        foreach (string sourceCode in updatedSourceCode)
                        {

                            printOrderItemTracking.PackageReference3 = sourceCode;
                            printOrderItem.TrackingInfo = printOrderItemTracking;
                            printOrderItem.Status = itemShippingStatus;

                            var failedPrintOrderItemTracking = UpdatePrintOrderShipping(printOrderItem.TrackingInfo,
                                                                                        printOrderItem.Status,
                                                                                        statusUpdatedBy);
                            if (failedPrintOrderItemTracking != null)
                            {

                                failedRecordList.Add(new OrderedPair<string, PrintOrderItemTracking>(failedPrintOrderItemTracking.FirstValue, printOrderItemTracking));

                            }
                            else
                            {
                                successRecordCount++;

                            }

                        }

                    }

                    catch (Exception)
                    {
                        var missingFieldList = MissingFieldList(parserObject, uplodedData.Length);
                        string missingField = string.Empty;
                        foreach (var item in missingFieldList)
                        {
                            missingField = missingField + item + ", ";
                        }

                        var failRecord = new OrderedPair<string, PrintOrderItemTracking>("Following fields are missing :" + missingField.Remove(missingField.Length - 2, 1) , printOrderItemTracking);
                        failedRecordList.Add(failRecord);
                    }


                }
            }


            return failedRecordList;
        }

        private static PrintOrderItemTracking SetUpPrintOrderItemTracking(string[] uplodedData, PrintOrderItemShippingParser parserObject, OrganizationRoleUser statusUpdatedBy)
        {
            var printOrderItemTracking = new PrintOrderItemTracking();

            try
            {
                DateTime scheduledDeliveryDate;
                printOrderItemTracking.TrackingNumber = uplodedData[parserObject.TrackingNumber];
                printOrderItemTracking.ShippingService = uplodedData[parserObject.Service];
                printOrderItemTracking.ScheduledDeliveryDate =
                    DateTime.TryParse(uplodedData[parserObject.ScheduledDelivery], out scheduledDeliveryDate)
                        ? scheduledDeliveryDate
                        : (DateTime?)null;
                printOrderItemTracking.ShipToName = uplodedData[parserObject.ShipToName];
                printOrderItemTracking.ShipToAttentionOf = uplodedData[parserObject.ShipToAttention];
                printOrderItemTracking.ShippedToAddress1 = uplodedData[parserObject.ShipToAddressLine1];
                printOrderItemTracking.ShippedToAddress2 = uplodedData[parserObject.ShipToAddressLine2];
                printOrderItemTracking.ShippedToCity = uplodedData[parserObject.ShipToCity];
                printOrderItemTracking.ShippedToZip = uplodedData[parserObject.ShipToPostalCode];
                printOrderItemTracking.ShippedToState = uplodedData[parserObject.ShipToStateProvince];
                printOrderItemTracking.PackageReference1 = uplodedData[parserObject.PackageReferenceNo1];
                printOrderItemTracking.PackageReference2 = uplodedData[parserObject.PackageReferenceNo2];
                printOrderItemTracking.CreatedByOrgRoleUser = statusUpdatedBy;
                printOrderItemTracking.DateCreated = DateTime.Now;
                printOrderItemTracking.DateUpdated = DateTime.Now;
                printOrderItemTracking.UpdatedByOrgRoleUser = statusUpdatedBy;
                printOrderItemTracking.ConfirmationMode = null;
            }
            catch
            {

            }

            return printOrderItemTracking;
        }


        //todo: this should be move to generic class

        public List<string> MissingFieldList(object parserObject, Int32 uplodedDataMaxIndex)
        {

            var missingField = new List<string>();

            var properties = parserObject.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                var propName = propertyInfo.Name;
                var propertyIndex =
                    Convert.ToInt16(parserObject.GetType().GetProperty(propName).GetValue(parserObject, null));
                if (propertyIndex >= uplodedDataMaxIndex)
                {
                    missingField.Add(propName);

                }


            }

            return missingField;
        }
        public Boolean ValidateFile(string filePath, char seprator, Type returnObjectType)
        {

            var parserObject = (PrintOrderItemShippingParser)SetParserObjectHeader(filePath, seprator, returnObjectType);

            var properties = returnObjectType.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                var propName = propertyInfo.Name;
                var propertyIndex =
                    Convert.ToInt16(parserObject.GetType().GetProperty(propName).GetValue(parserObject, null));
                if (propertyIndex == -1)
                {
                    return false;

                }


            }

            return true;
        }

        public Boolean ValidateFileRow(object parserObject, char seprator, Type returnObjectType)
        {

            ///var parserObject = (PrintOrderItemShippingParser)SetParserObject(row, seprator, returnObjectType);

            var properties = returnObjectType.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                var propName = propertyInfo.Name;
                var propertyIndex =
                    Convert.ToInt16(parserObject.GetType().GetProperty(propName).GetValue(parserObject, null));
                if (propertyIndex == -1)
                {
                    return false;

                }


            }

            return true;
        }


        public object SetParserObjectHeader(string filePath, char seprator, Type returnObjectType)
        {
            using (var reader = new StreamReader(filePath))
            {
                string row = reader.ReadLine();
                return SetParserObject(row, seprator, returnObjectType);
            }

        }


        public object SetParserObject(string row, char seprator, Type returnObjectType)
        {

            object objectToParse = Activator.CreateInstance(returnObjectType);

            string[] uplodedDataHeader = row.Split(seprator);
            Int16 i = 0;
            foreach (string item in uplodedDataHeader)
            {
                //todo: add the spl character in a class and loop through it
                var currentItem = item.Replace(" ", "").Replace("/", "").Replace(".", "");

                var properties = objectToParse.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in properties)
                {
                    var propName = propertyInfo.Name;

                    if (currentItem == propName)
                    {

                        objectToParse.GetType().GetProperty(currentItem).SetValue(objectToParse, i, null);
                    }
                }

                i++;
            }
            return objectToParse;


        }


    }

}


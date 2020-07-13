using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories.PrintOrder;
using Falcon.App.Infrastructure.Marketing.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.PrintOrder
{
    public class PrintOrderItemRepository : PersistenceRepository, IPrintOrderItemReposistory
    {
        private IPrintOrderItemFactory _printOrderItemFactory;
        public bool UpdatePrintOrderItemStatus(long printOrderItemId, ItemStatus itemStatus)
        {
            var printOrderItemEntity = new MarketingPrintOrderItemEntity(printOrderItemId) { Status = (long)itemStatus };
            IRelationPredicateBucket relationPredicateBucket =
            new RelationPredicateBucket(MarketingPrintOrderItemFields.MarketingPrintOrderItemId == printOrderItemId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(printOrderItemEntity, relationPredicateBucket) > 0;
            }
        }

        public List<string> ConfirmPrintOrderItemStatusByHsc(string confirmeByName, DateTime confirmationDate,
               string sourceCode, OrganizationRoleUser statusUpdatedBy)
        {
          return   ConfirmPrintOrderItemStatus(confirmeByName, confirmationDate, sourceCode, statusUpdatedBy,
                                        (long)ItemConfirmationMode.HSC);
        }

        public List<string> ConfirmPrintOrderItemStatusByCallCenter(string confirmeByName, DateTime confirmationDate,
                string sourceCode, OrganizationRoleUser statusUpdatedBy)
        {
           return  ConfirmPrintOrderItemStatus(confirmeByName, confirmationDate, sourceCode, statusUpdatedBy,
                                        (long)ItemConfirmationMode.CallCenter);
        }

        public List<string> ConfirmPrintOrderItemStatusByEmail(string confirmeByName, DateTime confirmationDate,
            string sourceCode)
        {
            return ConfirmPrintOrderItemStatus(confirmeByName, confirmationDate, sourceCode, null,
                                        (long)ItemConfirmationMode.Email);
        }

        public List<string> ConfirmPrintOrderItemStatusByUniqueUrl(string confirmeByName, DateTime confirmationDate,
                    string sourceCode)
        {
            return ConfirmPrintOrderItemStatus(confirmeByName, confirmationDate, sourceCode, null,
                                        (long)ItemConfirmationMode.UniqueUrl);
        }


        public List<string> ConfirmPrintOrderItemStatus(string confirmeByName, DateTime confirmationDate,
            string sourceCode, OrganizationRoleUser statusUpdatedBy, long confirmationMode)
        {
            var updatedSourceCode = new List<string>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {

                    var printOrderItemTrackingForSourceCode =
                        linqMetaData.MarketingPrintOrderItem.Join(linqMetaData.PrintOrderItemTracking, item =>
                                                                                                       item.
                                                                                                           MarketingPrintOrderItemId,
                                                                  tracking => tracking.PrintOrderItemId,
                                                                  (item, tracking) => new { item, tracking })
                            .Join(linqMetaData.Coupons, itemAndTracking => itemAndTracking.item.SourceCodeId,
                                  coupon => coupon.CouponId, (itemAndTracking, coupon) => new { itemAndTracking, coupon })
                                  .Where(@t => @t.coupon.CouponCode == sourceCode).Select(@t => @t.itemAndTracking.tracking).
                            FirstOrDefault();

                    if (printOrderItemTrackingForSourceCode != null)
                    {

                        var printOrderLinkedItemTracking =
                            linqMetaData.PrintOrderItemTracking.Where(@t => @t.TrackingNumber == printOrderItemTrackingForSourceCode.TrackingNumber)
                                .ToList();
                        // loop to all linked item if the ststau is not confirmed then confirm

                        foreach (var printOrderItemTracking in printOrderLinkedItemTracking)
                        {
                            var printOrderItemStatus =
                                linqMetaData.MarketingPrintOrderItem.Join(linqMetaData.PrintOrderItemTracking, item =>
                                                                                                               item.
                                                                                                                   MarketingPrintOrderItemId,
                                                                          tracking => tracking.PrintOrderItemId,
                                                                          (item, tracking) => new { item, tracking })
                                  .Where(@t => @t.tracking.PackageReference3 == printOrderItemTracking.PackageReference3
                                  && @t.item.IsActive).Select(
                                    @t => @t.item.Status).FirstOrDefault();
                            if (printOrderItemStatus != (long)ItemStatus.Confirmed)
                            {
                                printOrderItemTracking.ConfirmedBy = confirmeByName;
                                printOrderItemTracking.ActualDeliveryDate = confirmationDate;
                                printOrderItemTracking.DateUpdated = DateTime.Now;
                                printOrderItemTracking.UpdatedByOrgRoleUserId = statusUpdatedBy != null ? statusUpdatedBy.Id : (long?)null;
                                //ToDo: set the status on print order item
                                ////printOrderItemTracking.ConfirmationState = true;
                                printOrderItemTracking.ConfirmationMode = confirmationMode;
                                //////printOrderItemTracking.ShippingStatus = (long)ItemStatus.Confirmed;

                                var printOrderItemId = printOrderItemTracking.PrintOrderItemId;
                                var updateSourceCode = printOrderItemTracking.PackageReference3;
                                if (myAdapter.SaveEntity(printOrderItemTracking, false, false))
                                {
                                    UpdatePrintOrderItemStatus(printOrderItemId, ItemStatus.Confirmed);
                                    updatedSourceCode.Add(updateSourceCode);
                                }
                                else throw new PersistenceFailureException();
                                ConfirmPrintOrderStatus(sourceCode);
                            }

                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            return updatedSourceCode;
        }


        public void ConfirmPrintOrderStatus(string sourceCode)
        {

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {

                    var printOrderItem = linqMetaData.MarketingPrintOrderItem.
                        Join(
                        linqMetaData.Coupons.Where(
                            coupons => coupons.CouponCode == sourceCode),
                        printOrderItems => printOrderItems.SourceCodeId, coupons => coupons.CouponId,
                        (printOrder, coupon) => new { printOrder }).Select(printOrder => printOrder.printOrder).
                        SingleOrDefault();


                    var printOrderItemCount =
                       linqMetaData.MarketingPrintOrderItem.Where(
                                                                 @t => @t.MarketingPrintOrderId == printOrderItem.MarketingPrintOrderId
                                                                 ).Count();

                    var printOrderItemTrackingCount =
                       linqMetaData.MarketingPrintOrderItem.Where(
                                                                 @t => @t.MarketingPrintOrderId == printOrderItem.MarketingPrintOrderId && @t.Status == (long)ItemStatus.Confirmed
                                                                 ).Count();

                    if (printOrderItemTrackingCount == printOrderItemCount)
                    {
                        var marketingPrintOrderEntity = new MarketingPrintOrderEntity { Status = PrintOrderStatus.Completed.ToString() };

                        IRelationPredicateBucket bucket =
                            new RelationPredicateBucket(MarketingPrintOrderFields.MarketingPrintOrderId == printOrderItem.MarketingPrintOrderId);

                        using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                        {
                            adapter.UpdateEntitiesDirectly(marketingPrintOrderEntity, bucket);
                        }
                    }
                }
                catch (Exception)
                {

                }

            }
        }

        public Boolean SourceCodeAssociatedForPrintOrderItem(string sourceCode)
        {
            sourceCode = sourceCode.Trim();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {

                    var printOrderItemData = linqMetaData.MarketingPrintOrderItem.
                     Join(
                     linqMetaData.Coupons.Where(
                         coupons => coupons.CouponCode == sourceCode),
                     printOrderItem => printOrderItem.SourceCodeId, coupons => coupons.CouponId,
                     (printOrder, coupon) => new { printOrder }).Select(printOrder => printOrder.printOrder).
                     FirstOrDefault();

                    //ToDo: check the status of printorderitem
                    ////if (printOrderItemTracking != null && !printOrderItemTracking.ConfirmationState)
                    if ((printOrderItemData != null) && (printOrderItemData.Status != (long)ItemStatus.Confirmed))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return false;
            }
        }


        public List<PrintOrderItemViewData> GetPrintOrderItemDetail(long printOrderId)
        {
            var printOrderItemViewDataList = new List<PrintOrderItemViewData>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var printOrderItemData = linqMetaData.MarketingPrintOrderItem.WithPath(prefetchPath =>
                    prefetchPath.Prefetch(path => path.PrintOrderItemTracking)).Where(
                         printOrderItems => printOrderItems.MarketingPrintOrderId == printOrderId

                         ).ToList();




                _printOrderItemFactory = new PrintOrderItemFactory();

                foreach (MarketingPrintOrderItemEntity printOrderItem in printOrderItemData)
                {
                    var id = printOrderItem.MarketingPrintOrderItemId;
                    var marketingMaterial =
                     linqMetaData.MarketingPrintOrderItem.Join(linqMetaData.AfmarketingMaterial, item =>
                             item.MarketingMaterialId, mm => mm.MarketingMaterialId,
                             (item, mm) => new { mm.Title, mm.MarketingMaterialTypeId, item.MarketingPrintOrderItemId }).
                             Join(linqMetaData.AfmarketingMaterialType, @a =>
                             @a.MarketingMaterialTypeId, mmt => mmt.MarketingMaterialTypeId,
                             (@a, mmt) => new { @a.Title, mmt.Tag, @a.MarketingPrintOrderItemId })
                             .Where(@b => @b.MarketingPrintOrderItemId == id
                                                               ).Select(@c => new { @c.Title, @c.Tag }).FirstOrDefault();

                    ////printOrderItemList.Add(_printOrderItemFactory.CreatePrintOrderItem(printOrderItem));

                    printOrderItemViewDataList.Add(new PrintOrderItemViewData
                                               {
                                                   MarketingMaterialName = marketingMaterial.Title,
                                                   MarketingMaterialType = marketingMaterial.Tag,
                                                   PrintOrderItem =
                                                       _printOrderItemFactory.CreatePrintOrderItem(printOrderItem),

                                               });

                }
            }
            return printOrderItemViewDataList;
        }

        public Boolean IsPrintOrderItemEditable(long eventCampaignId)
        {
            //ToDo: parameter should be Print order item but it was not available in the UI.

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {

                    var printOrderItemData = linqMetaData.MarketingPrintOrderItem.Join(
                        linqMetaData.EventCampaignDetails, item => item.MarketingPrintOrderItemId,
                        campaign => campaign.MarketingPrintOrderItemId,
                        (item, campaign) =>
                        new { item.MarketingPrintOrderItemId, item.Status, item.IsActive, campaign.EventCampaignId }
                        ).Where(@t => @t.EventCampaignId == eventCampaignId && @t.IsActive).SingleOrDefault();

                    if ((printOrderItemData != null) && (printOrderItemData.Status != (long)ItemStatus.Placed))
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
        public Boolean IsAdvocateHaveAssignedPrintOrderItem(long advocateId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                try
                {

                    var printOrderItemData = linqMetaData.MarketingPrintOrderItem.Join(
                        linqMetaData.EventCampaignDetails, item => item.MarketingPrintOrderItemId,
                        campaign => campaign.MarketingPrintOrderItemId,
                        (item, campaign) => new { item.Status, item.IsActive, campaign.AffiliateId, campaign.EventId }
                        ).Where(@t => @t.AffiliateId == advocateId && @t.IsActive && @t.EventId == eventId).ToList();

                    foreach (var item in printOrderItemData)
                    {
                        if ((item != null) && (item.Status != (long)ItemStatus.Placed))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return false;
            }
        }

        public OrderedPair<string, string> GetPrintOrderItemAdvocate(long printOrderItemId)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var printOrderItemAdvocate =
                    linqMetaData.MarketingPrintOrderItem.Join(linqMetaData.OrganizationRoleUser, i => i.AffiliateId,
                                                              a => a.OrganizationRoleUserId,
                                                              (i, a) => new { i.MarketingPrintOrderItemId, a.UserId }).
                        Join(linqMetaData.User, @t => @t.UserId, u => u.UserId, (@t, u) =>
                                                                                new
                                                                                    {
                                                                                        @t.MarketingPrintOrderItemId,
                                                                                        u.FirstName,
                                                                                        u.LastName
                                                                                    }).Where
                        (@t => (@t.MarketingPrintOrderItemId == printOrderItemId)).FirstOrDefault();

                return new OrderedPair<string, string>(printOrderItemAdvocate.FirstName, printOrderItemAdvocate.LastName);
            }
        }

        public string GetPrintOrderPdfPathForEventCampaign(Int64 eventCampaignId )
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                
                var printOrderItemData = linqMetaData.MarketingPrintOrderItem.Join(
                        linqMetaData.EventCampaignDetails, item => item.MarketingPrintOrderItemId,
                        campaign => campaign.MarketingPrintOrderItemId,
                        (item, campaign) =>
                        new { item.MarketingMaterialId,campaign.EventCampaignId, item.IsActive }).Join(
                        linqMetaData.AfmarketingMaterial, @t => @t.MarketingMaterialId, mm =>mm.MarketingMaterialId,
                        (@t, mm) => new { mm.ImagePath, mm.ThumbnailImagePath, @t.EventCampaignId, @t.IsActive }
                        ).Where(@t => @t.EventCampaignId == eventCampaignId && @t.IsActive).SingleOrDefault();

                    if (printOrderItemData != null)
                    {
                        return printOrderItemData.ImagePath;
                    }
                
                return string.Empty;
            }

        }
    }
}
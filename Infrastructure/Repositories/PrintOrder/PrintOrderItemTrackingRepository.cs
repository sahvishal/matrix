using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Infrastructure.Factories.PrintOrder;
using Falcon.App.Infrastructure.Mappers.PrintOrder;
using Falcon.Data.Linq;
using Falcon.Data.EntityClasses;


namespace Falcon.App.Infrastructure.Repositories.PrintOrder
{
    public class PrintOrderItemTrackingRepository : PersistenceRepository, IPrintOrderItemTrackingRepository
    {
        private readonly IMapper<PrintOrderItemTracking, PrintOrderItemTrackingEntity> _mapper;

        public PrintOrderItemTrackingRepository()
            : this(new PrintOrderItemTrackingMapper())
        {

        }

        public PrintOrderItemTrackingRepository(IMapper<PrintOrderItemTracking, PrintOrderItemTrackingEntity> mapper)
        {
            _mapper = mapper;
        }

        public PrintOrderItemTracking GetById(long eventId)
        {
            return null;
        }

        public void Save(PrintOrderItemTracking printOrderItemShipping)
        {
            var printOrderItemShippingEntity = _mapper.Map(printOrderItemShipping);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(printOrderItemShippingEntity, false))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public List<PrintOrderItemViewData> GetPrintOrderItemTrackingDetailByFilters(long? eventId, DateTime? eventStartDate,
           DateTime? eventEndDate, ItemStatus? status, long? orderBySalesRepId
            , int pageNumber, int pageSize, out long totalRecord)
        {
            var printOrderItemTrackingViewDatas = new List<PrintOrderItemViewData>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventsEntities = linqMetaData.Events.Where(@e =>
                                                 (@e.IsActive) &&
                                                 (eventId == null || @e.EventId == eventId) &&
                                                 (eventStartDate == null || eventStartDate <= @e.EventDate) &&
                                                 (eventEndDate == null || eventEndDate >= @e.EventDate) &&
                                                 (orderBySalesRepId == null || orderBySalesRepId == @e.AssignedToOrgRoleUserId))
                   .ToList();

            
                var printOrderItems =
                    eventsEntities.Join(linqMetaData.MarketingPrintOrderEventMapping, e => e.EventId, poem => poem.EventId,
                                        (e, poem) => new { e.EventId, e.EventDate, e.EventName, poem.MarketingPrintOrderId }).
                                        Join
                                        (linqMetaData.MarketingPrintOrder, @t => @t.MarketingPrintOrderId, p => p.MarketingPrintOrderId,
                                        (@t, p) => new { @t.EventId, @t.EventDate, @t.EventName, p.MarketingPrintOrderId, p.OrgRoleUserId }).
                                        Join
                                        (linqMetaData.MarketingPrintOrderItem, @t => @t.MarketingPrintOrderId, po => po.MarketingPrintOrderId,
                                        (@t, po) => new { @t.EventId, @t.EventDate, @t.EventName, @t.OrgRoleUserId, po }).OrderBy(@t => @t.EventDate).
                                        Join
                                        (linqMetaData.MarketingOrderShippingInfo, @t => @t.po.MarketingOrderShippingInfoId,
                                        s => s.MarketingOrderShippingInfoId,
                                        (@t, s) => new { @t.EventId, @t.EventDate, @t.EventName, @t.OrgRoleUserId, @t.po, s }).OrderBy(@t => @t.EventDate)
                                        .ToList();

                printOrderItems = printOrderItems.Where(@t =>

                        (status == null || @t.po.Status == (long)status)
                        && (@t.po.IsActive)
                    /// && (orderBy == null || @t.UserId == orderBy.UserId)
                        ).ToList();

                var printOrderItemViewDataFactory = new PrintOrderItemViewDataFactory();
                totalRecord = printOrderItems.Count;

                printOrderItems = printOrderItems.Skip((pageNumber) * pageSize).Take(pageSize).ToList(); 

                foreach (var orderItem in printOrderItems)
                {
                    var marketingPrintOrderId = orderItem.po.MarketingPrintOrderId;
                    var marketingPrintOrderItemId = orderItem.po.MarketingPrintOrderItemId;

                    var orderPlacedBy = (from po in linqMetaData.MarketingPrintOrder
                                         join org in linqMetaData.OrganizationRoleUser on po.OrgRoleUserId equals org.OrganizationRoleUserId
                                         join us in linqMetaData.User on org.UserId equals us.UserId
                                         where po.MarketingPrintOrderId == marketingPrintOrderId
                                         select new { us.FirstName, us.LastName, po.MarketingPrintOrderId }).Single();
                    
                    var placedByName = orderPlacedBy.FirstName + " " + orderPlacedBy.LastName;

                    var printVendor = (from po in linqMetaData.MarketingPrintOrder
                              join pv in linqMetaData.Organization on po.PrintVendorOrganizationId equals pv.OrganizationId
                              where po.MarketingPrintOrderId == marketingPrintOrderId
                              select new { pv.Name, po.MarketingPrintOrderId }).SingleOrDefault();

                    var printVendorName = printVendor != null ? printVendor.Name : "N/A";

                    var printOrderItemTracking = linqMetaData.PrintOrderItemTracking.Where(@t =>
                                                 (@t.PrintOrderItemId == marketingPrintOrderItemId)).SingleOrDefault();
                    
                    var itemId = orderItem.po.MarketingPrintOrderItemId;
                    var marketingMaterial =
                    linqMetaData.MarketingPrintOrderItem.Join(linqMetaData.AfmarketingMaterial, item =>
                                                                                                item.MarketingMaterialId,
                                                              mm => mm.MarketingMaterialId,
                                                              (item, mm) =>
                                                              new
                                                                  {
                                                                      mm.Title,
                                                                      mm.MarketingMaterialTypeId,
                                                                      item.MarketingPrintOrderItemId
                                                                  }).
                        Join(linqMetaData.AfmarketingMaterialType, @a =>
                                                                   @a.MarketingMaterialTypeId,
                             mmt => mmt.MarketingMaterialTypeId,
                             (@a, mmt) => new { @a.Title, mmt.Tag, @a.MarketingPrintOrderItemId })
                        .Where(@b => @b.MarketingPrintOrderItemId == itemId
                        ).Select(@c => new { @c.Title, @c.Tag }).FirstOrDefault();

                    printOrderItemTrackingViewDatas.Add(
                        printOrderItemViewDataFactory.Create(orderItem.EventDate, orderItem.EventId,
                                                             orderItem.EventName, (long)orderItem.po.MarketingPrintOrderId, orderItem.po,
                                                             printOrderItemTracking,
                                                             printVendorName, marketingMaterial.Tag,
                                                             marketingMaterial.Title, placedByName,orderItem.s));
                }
            }
            
            return printOrderItemTrackingViewDatas;
        }


        public PrintOrderItemTrackingViewData GetPrintOrderItemTrackingDetail(long printOrderItemId)
        {
            //todo: error handling if invalid printorder item found
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var orderItem =
                    linqMetaData.MarketingPrintOrderItem.Where(@t => @t.MarketingPrintOrderItemId == printOrderItemId).
                        ToList();

                var printOrderItem = orderItem.FirstOrDefault();

                var createdBy = orderItem.Join(linqMetaData.MarketingPrintOrder, item => item.MarketingPrintOrderId,
                                               order => order.MarketingPrintOrderId, (item, order) => new { order.OrgRoleUserId })
                                               .Join(linqMetaData.OrganizationRoleUser, item => item.OrgRoleUserId, oru => oru.OrganizationRoleUserId, (item, oru) => new { oru.UserId })
                    .Join(linqMetaData.User, @t => @t.UserId, u => u.UserId, (@t, u) => new { u.FirstName, u.LastName }).
                    FirstOrDefault();

                var createdFor =
                    orderItem.Join(linqMetaData.MarketingOrderShippingInfo, item => item.MarketingOrderShippingInfoId,
                                   s => s.MarketingOrderShippingInfoId, (item, s) => new { s.FirstName, s.LastName }).
                        FirstOrDefault();

                var printOrderItemTracking = linqMetaData.PrintOrderItemTracking.Where(@t =>
                                                 @t.PrintOrderItemId == printOrderItemId).FirstOrDefault();

                var vendorEntity = linqMetaData.MarketingPrintOrder.Join(linqMetaData.Organization,
                                                              order => order.PrintVendorOrganizationId,
                                                              vendor => vendor.OrganizationId,
                                                              (order, vendor) => new { order.MarketingPrintOrderId, vendor.Name }).
                        Where(@t => @t.MarketingPrintOrderId == printOrderItem.MarketingPrintOrderId).Select(
                        @t => new { @t.Name }).FirstOrDefault();

                var vendorBusinessName = vendorEntity != null ? vendorEntity.Name : null;
                var printOrderItemTrackingViewDataFactory = new PrintOrderItemTrackingViewDataFactory();

                return printOrderItemTrackingViewDataFactory.Create(printOrderItem,
                                                createdBy.FirstName + " " + createdBy.LastName,
                                                createdFor.FirstName + " " + createdFor.LastName,
                                                vendorBusinessName, printOrderItemTracking);

            }

        }

    }
}


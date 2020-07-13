using System;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Shipping;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Repositories.Shipping
{
    public class ShippingDetailRepository : UniqueItemRepository<ShippingDetail, ShippingDetailEntity>, IShippingDetailRepository
    {
        public ShippingDetailRepository()
            : base(new ShippingDetailMapper())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return ShippingDetailFields.ShippingDetailId; }
        }

        public new ShippingDetail GetById(long shippingDetailId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var shippingDetail =
                    linqMetaData.ShippingDetail.WithPath(
                        prefetchPath =>
                        prefetchPath.Prefetch(path => path.ShippingOption).Prefetch(path => path.Address)).Where(
                        sd => sd.ShippingDetailId == shippingDetailId).
                        SingleOrDefault();
                if (shippingDetail == null)
                {
                    throw new ObjectNotFoundInPersistenceException<ShippingDetail>(shippingDetailId);
                }
                return Mapper.Map(shippingDetail);
            }
        }

        public IEnumerable<ShippingDetail> GetShippingDetailsForOrder(long orderDetailId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var shippingDetails =
                    linqMetaData.ShippingDetail.Join(linqMetaData.ShippingDetailOrderDetail, sd => sd.ShippingDetailId,
                                                     sdod => sdod.ShippingDetailId, (sd, sdod) => new { sd, sdod }).Where(
                        @t => @t.sdod.OrderDetailId == orderDetailId && @t.sdod.IsActive).Select(@t => @t.sd).ToList();


                shippingDetails.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                                     join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals
                                                                         pso.ShippingOptionId into sopso
                                                                     from sp in sopso.DefaultIfEmpty()
                                                                     where sds.ShippingOptionId == so.ShippingOptionId
                                                                     select so).FirstOrDefault());
                shippingDetails = shippingDetails.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(shippingDetails);
            }
        }

        public IEnumerable<ShippingDetail> GetShippingDetailsForCancellation(long orderDetailId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var shippingDetails =
                    linqMetaData.ShippingDetail.Join(linqMetaData.ShippingDetailOrderDetail, sd => sd.ShippingDetailId,
                                                     sdod => sdod.ShippingDetailId, (sd, sdod) => new { sd, sdod }).Where(
                        @t => @t.sdod.OrderDetailId == orderDetailId && @t.sdod.IsActive).Select(@t => @t.sd).ToList();

                shippingDetails.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                                     join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals
                                                                         pso.ShippingOptionId into sopso
                                                                     from sp in sopso.DefaultIfEmpty()
                                                                     where sds.ShippingOptionId == so.ShippingOptionId && (sp.IsShowVisible == null || sp.IsShowVisible)
                                                                     select so).FirstOrDefault());
                shippingDetails = shippingDetails.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(shippingDetails);
            }
        }

        public IEnumerable<ShippingDetail> GetProductShippingDetailsForCancellation(long orderDetailId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var shippingDetails =
                    linqMetaData.ShippingDetail.Join(linqMetaData.ShippingDetailOrderDetail, sd => sd.ShippingDetailId,
                                                     sdod => sdod.ShippingDetailId, (sd, sdod) => new { sd, sdod }).Where(
                        @t => @t.sdod.OrderDetailId == orderDetailId && @t.sdod.IsActive).Select(@t => @t.sd).ToList();

                shippingDetails.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                                     join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals
                                                                         pso.ShippingOptionId into sopso
                                                                     from sp in sopso.DefaultIfEmpty()
                                                                     where sds.ShippingOptionId == so.ShippingOptionId && (!sp.IsShowVisible) && (!sp.IsForPcp)
                                                                     select so).FirstOrDefault());
                shippingDetails = shippingDetails.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(shippingDetails);
            }
        }

        public IEnumerable<ShippingDetail> GetCancelledShippingDetailsForOrder(long orderDetailId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var shippingDetails =
                    linqMetaData.ShippingDetail.Join(linqMetaData.ShippingDetailOrderDetail, sd => sd.ShippingDetailId,
                                                     sdod => sdod.ShippingDetailId, (sd, sdod) => new { sd, sdod }).Where(
                        @t =>
                        @t.sdod.OrderDetailId == orderDetailId &&
                        (@t.sdod.IsActive || @t.sd.Status == (int)ShipmentStatus.Cancelled)).Select(
                        @t => @t.sd).ToList();

                //shippingDetails.ForEach(
                //    sd =>
                //    sd.ShippingOption =
                //    linqMetaData.ShippingOption.SingleOrDefault(so => so.ShippingOptionId == sd.ShippingOptionId));

                shippingDetails.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                                     join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals
                                                                         pso.ShippingOptionId into sopso
                                                                     from sp in sopso.DefaultIfEmpty()
                                                                     where sds.ShippingOptionId == so.ShippingOptionId
                                                                     select so).FirstOrDefault());
                shippingDetails = shippingDetails.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(shippingDetails);
            }
        }

        public int GetAllCount(int status, long shippingOptionId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return
                    linqMetaData.ShippingDetail.Where(
                        sd =>
                        (sd.Status == status || status == 0) &&
                        (sd.ShippingOptionId == shippingOptionId || shippingOptionId == 0)).Count();
            }
        }

        public decimal GetShippingPrice(long eventId, long customerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.EventCustomers.ToList().
                    Where(ec => ec.EventId == eventId && ec.CustomerId == customerId && ec.AppointmentId.HasValue).
                    Join(linqMetaData.EventCustomerOrderDetail, ec => ec.EventCustomerId, ecod => ecod.EventCustomerId,
                         (ec, ecod) => new { ecod.OrderDetailId }).
                    Join(linqMetaData.ShippingDetailOrderDetail, @t => @t.OrderDetailId, sdod => sdod.OrderDetailId,
                         (@t, sdod) => new { sdod.ShippingDetailId, sdod.IsActive }).
                    Where(sdod => sdod.IsActive).
                    Join(linqMetaData.ShippingDetail, sdod => sdod.ShippingDetailId,
                         shippigDetail => shippigDetail.ShippingDetailId,
                         (sdod, shippingDetail) => new { shippingDetail.ActualPrice }).
                    Sum(shippingDetail => shippingDetail.ActualPrice);

            }
        }

        public DateTime? MailedDateForEvent(long eventId, long hospitalFacilityId = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var productShippingOptionIds = (from so in linqMetaData.ShippingOption
                                                join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals pso.ShippingOptionId
                                                select so.ShippingOptionId).ToArray();

                var mailedDate = (from ec in linqMetaData.EventCustomers
                                  join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                  join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                  join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                  where ec.EventId == eventId && ecod.IsActive && sdod.IsActive && !productShippingOptionIds.Contains(sd.ShippingOptionId) && sd.ShipmentDate.HasValue
                                  && (hospitalFacilityId == 0 || ec.HospitalFacilityId == hospitalFacilityId)
                                  orderby sd.ShipmentDate
                                  select sd.ShipmentDate).FirstOrDefault();
                if (mailedDate == DateTime.MinValue)
                    return null;
                return mailedDate;
            }
        }

        public IEnumerable<OrderedPair<long, DateTime>> GetRecentMailedHospitalPartnerEvents(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var productShippingOptionIds = (from so in linqMetaData.ShippingOption
                                                join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals pso.ShippingOptionId
                                                select so.ShippingOptionId).ToArray();

                var eventAndShippmentDate = (from ec in linqMetaData.EventCustomers
                                             join ehp in linqMetaData.EventHospitalPartner on ec.EventId equals ehp.EventId
                                             join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId
                                                 equals
                                                 ecod.EventCustomerId
                                             join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId
                                                 equals
                                                 sdod.OrderDetailId
                                             join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals
                                                 sd.ShippingDetailId
                                             where ehp.HospitalPartnerId == hospitalPartnerId && ecod.IsActive && sdod.IsActive
                                                   && !productShippingOptionIds.Contains(sd.ShippingOptionId)
                                                   && sd.ShipmentDate.HasValue
                                             select new { ec.EventId, sd.ShipmentDate });
                return (from q in eventAndShippmentDate
                        group q by q.EventId
                            into g
                            orderby g.Min(q => q.ShipmentDate) descending
                            select new OrderedPair<long, DateTime>(g.Key, g.Min(q => q.ShipmentDate.Value))).Take(5).ToList();
            }
        }

        public IEnumerable<ShippingDetail> GetShippingDetailsForEventCustomer(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ec in linqMetaData.EventCustomers
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                where ec.EventId == eventId && ec.CustomerId == customerId && ecod.IsActive && sdod.IsActive
                                select sd).ToList();

                entities.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                              join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals
                                                                  pso.ShippingOptionId into sopso
                                                              from sp in sopso.DefaultIfEmpty()
                                                              where sds.ShippingOptionId == so.ShippingOptionId
                                                              select so).FirstOrDefault());

                entities = entities.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<ShippingDetail> GetShippingDetailsForCustomer(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ec in linqMetaData.EventCustomers
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                where ec.CustomerId == customerId && ecod.IsActive && sdod.IsActive
                                select sd).ToList();

                entities.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                              where sds.ShippingOptionId == so.ShippingOptionId
                                                              select so).FirstOrDefault());

                entities = entities.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<ShippingDetail> GetEventCustomerShippingDetailForFilter(int pageNumber, int pageSize, EventCustomerShippingDetailViewDataFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var applyExcFilter = filter.IsExclusivelyRequested != null;

                var isExclRequested = applyExcFilter ? filter.IsExclusivelyRequested.Value : true;

                var query = (from ec in linqMetaData.EventCustomers
                             join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                             join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                             join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                             join ecrl in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecrl.EventCustomerResultId
                             into ecrl_leftjoin
                             from ecrl_lj in ecrl_leftjoin.DefaultIfEmpty()
                             where ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                             && ecod.IsActive && sdod.IsActive
                             && (filter.EventId > 0 ? ec.EventId == filter.EventId : true)
                             && (applyExcFilter == false || sd.IsExclusivelyRequested == isExclRequested)
                             && (filter.ShippmentStatus > 0 ? sd.Status == filter.ShippmentStatus : true)
                             && (!filter.ShippingOptions.IsNullOrEmpty() ? filter.ShippingOptions.Contains(sd.ShippingOptionId) : true)
                             select new { ec, sd, ecrl = ecrl_lj });

                if (filter.DateFrom.HasValue || filter.DateTo.HasValue)
                {
                    var fromDate = filter.DateFrom.HasValue ? filter.DateFrom.Value.Date : DateTime.Now.Date;
                    var toDate = filter.DateTo.HasValue ? filter.DateTo.Value.Date : DateTime.Now.Date;

                    var eventIds = (from e in linqMetaData.Events
                                    where e.IsActive &&
                                          (filter.DateFrom != null ? e.EventDate >= fromDate : true) &&
                                          (filter.DateTo != null ? e.EventDate <= toDate : true)
                                    select e.EventId);

                    query = from q in query
                            where eventIds.Contains(q.ec.EventId)
                            select q;
                }

                //if (filter.IsExclusivelyRequested != null)
                //{
                //    query = from q in query where q.sd.IsExclusivelyRequested == filter.IsExclusivelyRequested.Value select q;
                //}

                if (filter.PodId > 0)
                {
                    var eventIds = (from ep in linqMetaData.EventPod
                                    where ep.PodId == filter.PodId
                                    select ep.EventId);

                    query = from q in query
                            where eventIds.Contains(q.ec.EventId)
                            select q;
                }

                if (filter.IsResultReady)
                {
                    query = from q in query
                            where q.ecrl.IsClinicalFormGenerated && q.ecrl.IsResultPdfgenerated
                            select q;
                }

                if (filter.HasEmail > 0)
                {
                    var customerIds = (from u in linqMetaData.User
                                       join toru in linqMetaData.OrganizationRoleUser on u.UserId equals toru.UserId
                                       where toru.RoleId == (long)Roles.Customer
                                       && filter.HasEmail == 1 ? (u.Email1 != null && u.Email1.Trim().Length > 1) : (u.Email1 == null || u.Email1.Trim().Length == 0)
                                       select toru.OrganizationRoleUserId);

                    query = from q in query
                            where customerIds.Contains(q.ec.CustomerId)
                            select q;
                }

                var queryForShipping = from q in query orderby q.ecrl.ResultState descending, q.sd.Status ascending, q.ec.EventId descending select q.sd;
                totalRecords = queryForShipping.Count();

                var entities = queryForShipping.TakePage(pageNumber, pageSize).ToArray();
                //var entities = query.OrderByDescending(q => q.ecrl.ResultState).OrderBy(q => q.sd.Status).OrderByDescending(q => q.ec.EventId).TakePage(pageNumber, pageSize).Select(q => q.sd).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetShippingDetailIdEventCustomerIdPairs(IEnumerable<long> shippingDetailIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                            ecod.EventCustomerId
                        join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals
                            sdod.OrderDetailId
                        where shippingDetailIds.Contains(sdod.ShippingDetailId)
                        select new OrderedPair<long, long>(sdod.ShippingDetailId, ec.EventCustomerId)).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventIdShippingCountPair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                        join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                        join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                        where ec.AppointmentId.HasValue && ecod.IsActive && sdod.IsActive
                        && sd.ActualPrice > 0
                        && eventIds.Contains(ec.EventId)
                        group ec by ec.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, decimal>> GetEventIdShippingRevenuePair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pair in
                            (from ec in linqMetaData.EventCustomers
                             join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                 ecod.EventCustomerId
                             join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals
                                 sdod.OrderDetailId
                             join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals
                                 sd.ShippingDetailId
                             where ec.AppointmentId.HasValue && ecod.IsActive && sdod.IsActive
                                   && sd.ActualPrice > 0
                                   && eventIds.Contains(ec.EventId)
                             select new { ec.EventId, sd.ActualPrice })
                        group pair by pair.EventId
                            into grp
                            select new OrderedPair<long, decimal>(grp.Key, grp.Sum(p => p.ActualPrice))).ToArray();
            }
        }

        public IEnumerable<ShippingDetail> GetAllCancelledShippingForOrder(long orderId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var orderDetailIds = (from od in linqMetaData.OrderDetail
                                      where od.OrderId == orderId
                                      select od.OrderDetailId).ToArray();
                var shippingDetails = (from sd in linqMetaData.ShippingDetail
                                       join sdod in linqMetaData.ShippingDetailOrderDetail on sd.ShippingDetailId equals
                                           sdod.ShippingDetailId
                                       where !sdod.IsActive && orderDetailIds.Contains(sdod.OrderDetailId)
                                       select sd).ToList();

                shippingDetails.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                                     join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals
                                                                         pso.ShippingOptionId into sopso
                                                                     from sp in sopso.DefaultIfEmpty()
                                                                     where sds.ShippingOptionId == so.ShippingOptionId
                                                                     select so).FirstOrDefault());
                shippingDetails = shippingDetails.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(shippingDetails);
            }
        }

        public IEnumerable<OrderedPair<long, DateTime>> GetRecentMailedHospitalFacilityEvents(long hospitalFacilityId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var productShippingOptionIds = (from so in linqMetaData.ShippingOption
                                                join pso in linqMetaData.ProductShippingOption on so.ShippingOptionId equals pso.ShippingOptionId
                                                select so.ShippingOptionId).ToArray();

                var eventAndShippmentDate = (from ec in linqMetaData.EventCustomers
                                             join ehf in linqMetaData.EventHospitalFacility on ec.EventId equals ehf.EventId
                                             join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                             join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                             join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                             where ehf.HospitalFacilityId == hospitalFacilityId && ecod.IsActive && sdod.IsActive && ec.HospitalFacilityId == hospitalFacilityId
                                                   && !productShippingOptionIds.Contains(sd.ShippingOptionId)
                                                   && sd.ShipmentDate.HasValue
                                             select new { ec.EventId, sd.ShipmentDate });
                return (from q in eventAndShippmentDate
                        group q by q.EventId
                            into g
                            orderby g.Min(q => q.ShipmentDate) descending
                            select new OrderedPair<long, DateTime>(g.Key, g.Min(q => q.ShipmentDate.Value))).Take(5).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetShippingDetailsIdCustomerId(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                        join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                        join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                        where customerIds.Contains(ec.CustomerId) && ecod.IsActive && sdod.IsActive
                        select new OrderedPair<long, long>(sd.ShippingDetailId, ec.CustomerId)).ToArray();


            }
        }

        public IEnumerable<ShippingDetail> GetShippingDetailsForCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ec in linqMetaData.EventCustomers
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                where customerIds.Contains(ec.CustomerId) && ecod.IsActive && sdod.IsActive
                                select sd).ToList();

                entities.ForEach(sds => sds.ShippingOption = (from so in linqMetaData.ShippingOption
                                                              where sds.ShippingOptionId == so.ShippingOptionId
                                                              select so).FirstOrDefault());

                entities = entities.Where(sds => sds.ShippingOption != null).Select(sds => sds).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<ShippingDetail> GetEventCustomerShippingDetailForFilter(int pageNumber, int pageSize, PcpResultMailedReportModelFilter filter, IEnumerable<long> shippingOptions, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);


                var query = (from ec in linqMetaData.EventCustomers
                             join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                             join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                             join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                             join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                             where ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                             && ea.AccountId == filter.HealthPlanId
                             && ecod.IsActive && sdod.IsActive
                             && sd.ShipmentDate.HasValue
                             && (sd.Status == (long)ShipmentStatus.Delivered || sd.Status == (long)ShipmentStatus.Shipped)
                             && (shippingOptions.Contains(sd.ShippingOptionId))

                             select new { ec, sd });

                if (filter.DateFrom.HasValue || filter.DateTo.HasValue)
                {
                    var fromDate = filter.DateFrom.HasValue ? filter.DateFrom.Value.Date : DateTime.Now.Date;
                    var toDate = filter.DateTo.HasValue ? filter.DateTo.Value.Date.AddDays(1) : DateTime.Now.Date.AddDays(1);

                    query = from q in query
                            where q.sd.ShipmentDate >= fromDate && q.sd.ShipmentDate <= toDate
                            select q;
                }

                if (!string.IsNullOrWhiteSpace(filter.Tag))
                {
                    var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == filter.Tag select cp.CustomerId);

                    query = (from q in query where customerIds.Contains(q.ec.CustomerId) select q);
                }

                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);

                    if (filter.ExcludeCustomerWithCustomTag)
                    {
                        query = (from q in query where !customTagCustomerIds.Contains(q.ec.CustomerId) select q);
                    }
                    else
                    {
                        query = (from q in query where customTagCustomerIds.Contains(q.ec.CustomerId) select q);
                    }
                }

                var queryForShipping = from q in query orderby q.sd.ShipmentDate ascending, q.ec.EventId ascending, q.ec.CustomerId ascending select q.sd;
                totalRecords = queryForShipping.Count();

                var entities = queryForShipping.TakePage(pageNumber, pageSize).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<ShippingDetail> GetEventCustomerShippingDetailForFilter(int pageNumber, int pageSize, PcpSummaryLogReportModelFilter filter, IEnumerable<long> shippingOptions, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);


                var query = (from ec in linqMetaData.EventCustomers
                             join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                             join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                             join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                             join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                             where ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                             && ea.AccountId == filter.HealthPlanId
                             && ecod.IsActive && sdod.IsActive
                             && sd.ShipmentDate.HasValue
                             && (sd.Status == (long)ShipmentStatus.Delivered || sd.Status == (long)ShipmentStatus.Shipped)
                             && (shippingOptions.Contains(sd.ShippingOptionId))

                             select new { ec, sd });

                if (filter.DateFrom.HasValue || filter.DateTo.HasValue)
                {
                    var fromDate = filter.DateFrom.HasValue ? filter.DateFrom.Value : DateTime.Now;
                    var toDate = filter.DateTo.HasValue ? filter.DateTo.Value : DateTime.Now;

                    query = from q in query
                            where q.sd.ShipmentDate >= fromDate && q.sd.ShipmentDate <= toDate
                            select q;
                }

                if (!string.IsNullOrWhiteSpace(filter.Tag))
                {
                    var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == filter.Tag select cp.CustomerId);

                    query = (from q in query where customerIds.Contains(q.ec.CustomerId) select q);
                }


                var queryForShipping = from q in query orderby q.sd.ShipmentDate ascending, q.ec.EventId ascending, q.ec.CustomerId ascending select q.sd;
                totalRecords = queryForShipping.Count();

                var entities = queryForShipping.TakePage(pageNumber, pageSize).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        //public IEnumerable<ShippingDetail> GetEventCustomerMemberResultMailedReportFilter(int pageNumber, int pageSize, MemberResultMailedReportFilter filter,
        //     out int totalRecords)
        //{
        //    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var linqMetaData = new LinqMetaData(adapter);

        //        var query = (from ec in linqMetaData.EventCustomers
        //                     join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
        //                     join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
        //                     join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
        //                     join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
        //                     where ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
        //                     && ea.AccountId == filter.HealthPlanId
        //                     && ecod.IsActive && sdod.IsActive
        //                     && sd.ShipmentDate.HasValue
        //                     && (sd.Status == (long)ShipmentStatus.Delivered || sd.Status == (long)ShipmentStatus.Shipped)
        //                     && (filter.ShippingOptions.Contains(sd.ShippingOptionId))

        //                     select new { ec, sd });

        //        if (filter.DateFrom.HasValue || filter.DateTo.HasValue)
        //        {
        //            var fromDate = filter.DateFrom.HasValue ? filter.DateFrom.Value.Date : DateTime.Now.Date;
        //            var toDate = filter.DateTo.HasValue ? filter.DateTo.Value.Date.AddDays(1) : DateTime.Now.Date.AddDays(1);

        //            query = from q in query
        //                    where q.sd.ShipmentDate >= fromDate && q.sd.ShipmentDate <= toDate
        //                    select q;
        //        }


        //        if (filter.CustomTags != null && filter.CustomTags.Any())
        //        {
        //            var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
        //                                        where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
        //                                        select ct.CustomerId);

        //            if (filter.ExcludeCustomerWithCustomTag)
        //            {
        //                query = (from q in query where !customTagCustomerIds.Contains(q.ec.CustomerId) select q);
        //            }
        //            else
        //            {
        //                query = (from q in query where customTagCustomerIds.Contains(q.ec.CustomerId) select q);
        //            }
        //        }

        //        var queryForShipping = from q in query orderby q.sd.ShipmentDate ascending, q.ec.EventId ascending, q.ec.CustomerId ascending select q.sd;
        //        totalRecords = queryForShipping.Count();

        //        var entities = queryForShipping.TakePage(pageNumber, pageSize).ToArray();
        //        return Mapper.MapMultiple(entities);
        //    }
        //}

    }
}

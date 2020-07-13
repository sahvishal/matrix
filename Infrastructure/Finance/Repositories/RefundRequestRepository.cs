using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    [DefaultImplementation(Interface = typeof(IRefundRequestRepository))]
    public class RefundRequestRepository : PersistenceRepository, IRepository<RefundRequest>, IRefundRequestRepository
    {
        public RefundRequestRepository(IPersistenceLayer persistenceLayer)
            : base(persistenceLayer)
        {

        }

        public RefundRequest Save(RefundRequest domainObject)
        {
            var entity = Mapper.Map<RefundRequest, RefundRequestEntity>(domainObject);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();
            }

            var pair = GetEventIdCustomerIdPairforOrder(domainObject.OrderId);
            var request = Mapper.Map<RefundRequestEntity, RefundRequest>(entity);

            if (pair != null)
            {
                request.EventId = pair.FirstValue;
                request.CustomerId = pair.SecondValue;
            }
            return request;
        }


        private IEnumerable<OrderedPair<long, OrderedPair<long, long>>> GetEventIdCustomerIdPairforOrders(IEnumerable<long> orderIds)
        {
            using (var adapater = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapater);
                return (from od in linqMetaData.OrderDetail
                        join ecod in linqMetaData.EventCustomerOrderDetail on od.OrderDetailId equals ecod.OrderDetailId
                        join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals ec.EventCustomerId
                        where orderIds.Contains(od.OrderId)
                        select new { od.OrderId, ec.EventId, ec.CustomerId }).Distinct()
                        .Select(a => new OrderedPair<long, OrderedPair<long, long>>(a.OrderId, new OrderedPair<long, long>(a.EventId, a.CustomerId))).ToArray();
            }
        }

        private OrderedPair<long, long> GetEventIdCustomerIdPairforOrder(long orderId)
        {
            using (var adapater = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapater);
                return (from od in linqMetaData.OrderDetail
                        join ecod in linqMetaData.EventCustomerOrderDetail on od.OrderDetailId equals ecod.OrderDetailId
                        join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals ec.EventCustomerId
                        where od.OrderId == orderId
                        select new OrderedPair<long, long>(ec.EventId, ec.CustomerId)).SingleOrDefault();
            }
        }

        public RefundRequest Get(long id)
        {
            var entity = new RefundRequestEntity(id);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.FetchEntity(entity))
                    throw new ObjectNotFoundInPersistenceException<RefundRequest>();
            }
            var pair = GetEventIdCustomerIdPairforOrder(entity.OrderId);
            var request = Mapper.Map<RefundRequestEntity, RefundRequest>(entity);

            if (request.RefundRequestResult == null && !string.IsNullOrWhiteSpace(entity.ProcessorNotes))
            {
                request.RefundRequestResult = new RefundRequestResult();
                request.RefundRequestResult.Notes = entity.ProcessorNotes;
            }

            if (pair != null)
            {
                request.EventId = pair.FirstValue;
                request.CustomerId = pair.SecondValue;
            }
            return request;
        }

        public void SaveProcessorNotes(long id, string notes)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new RefundRequestEntity() { ProcessorNotes = notes };
                adapter.UpdateEntitiesDirectly(entity,
                                               new RelationPredicateBucket(RefundRequestFields.RefundRequestId == id));
            }
        }

        public IEnumerable<RefundRequest> Get(int pageNumber, int pageSize, RefundRequestListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var refundRequestQuery = from rr in linqMetaData.RefundRequest where rr.IsActive select rr;
                IEnumerable<OrderedPair<long, OrderedPair<long, long>>> orderEventCustomerPair = null;
                IEnumerable<RefundRequest> requests;

                var assignEventCustomer = new Func<RefundRequest, RefundRequest>(rr =>
                                                                                      {
                                                                                          if (orderEventCustomerPair != null)
                                                                                          {
                                                                                              var pair = orderEventCustomerPair.Where(p => p.FirstValue == rr.OrderId).SingleOrDefault();
                                                                                              if (pair != null)
                                                                                              {
                                                                                                  rr.EventId =
                                                                                                      pair.SecondValue.FirstValue;
                                                                                                  rr.CustomerId =
                                                                                                      pair.SecondValue.SecondValue;
                                                                                              }
                                                                                          }
                                                                                          return rr;
                                                                                      });
                if (filter == null)
                {
                    var refundRequests = refundRequestQuery.OrderByDescending(rr => rr.RequestedOn).TakePage(pageNumber, pageSize).ToArray();
                    totalRecords = refundRequestQuery.Count();
                    requests = Mapper.Map<IEnumerable<RefundRequestEntity>, IEnumerable<RefundRequest>>(refundRequests);
                }
                else
                {
                    refundRequestQuery = from rr in linqMetaData.RefundRequest
                                         where
                                             rr.IsActive &&
                                             (filter.RefundRequestStatus < 1
                                                  ? true
                                                  : (rr.RequestStatus == filter.RefundRequestStatus))
                                         select rr;

                    if (filter.CustomerId > 0)
                    {
                        refundRequestQuery = (from od in linqMetaData.OrderDetail
                                              join rr in refundRequestQuery on od.OrderId equals rr.OrderId
                                              where od.ForOrganizationRoleUserId == filter.CustomerId
                                              select rr);
                    }
                    else
                    {
                        if (filter.RefundType > 0)
                        {
                            refundRequestQuery = from rr in refundRequestQuery
                                                 where rr.ReasonType == filter.RefundType
                                                 select rr;
                        }

                        if (!string.IsNullOrEmpty(filter.CustomerName))
                        {
                            refundRequestQuery = (from u in linqMetaData.User
                                                  join oru in linqMetaData.OrganizationRoleUser on u.UserId equals
                                                      oru.UserId
                                                  join od in linqMetaData.OrderDetail on oru.OrganizationRoleUserId equals
                                                      od.ForOrganizationRoleUserId
                                                  join rr in refundRequestQuery on od.OrderId equals rr.OrderId
                                                  where
                                                      (u.FirstName +
                                                       (u.MiddleName.Trim().Length > 0 ? (" " + u.MiddleName + " ") : " ") +
                                                       u.LastName).Contains(filter.CustomerName)
                                                  select rr);

                        }


                        if (filter.FromDate != null || filter.ToDate != null)
                        {
                            var startDate = filter.FromDate ?? DateTime.Now;
                            var endDate = filter.ToDate ?? DateTime.Now;
                            switch ((FilterDateType)filter.DateType)
                            {
                                case FilterDateType.EventDate:
                                    refundRequestQuery = from rr in refundRequestQuery
                                                         join o in linqMetaData.OrderDetail on rr.OrderId equals o.OrderId
                                                         join ecod in linqMetaData.EventCustomerOrderDetail on
                                                             o.OrderDetailId equals ecod.OrderDetailId
                                                         join ec in linqMetaData.EventCustomers on ecod.EventCustomerId
                                                             equals ec.EventCustomerId
                                                         join e in linqMetaData.Events on ec.EventId equals e.EventId
                                                         where (filter.FromDate == null || e.EventDate > startDate)
                                                               &&
                                                               (filter.ToDate == null || e.EventDate <= endDate.AddHours(23).AddMinutes(59))
                                                         select rr;
                                    break;

                                case FilterDateType.RequestDate:
                                    refundRequestQuery = from rr in refundRequestQuery
                                                         where (filter.FromDate == null || rr.RequestedOn > startDate)
                                                               &&
                                                               (filter.ToDate == null || rr.RequestedOn <= endDate.AddHours(23).AddMinutes(59))
                                                         select rr;
                                    break;

                                case FilterDateType.TransactionDate:
                                    refundRequestQuery = from rr in refundRequestQuery
                                                         join o in linqMetaData.Order on rr.OrderId equals o.OrderId
                                                         where (filter.FromDate == null || (o.DateCreated > startDate))
                                                               &&
                                                               (filter.ToDate == null || o.DateCreated <= endDate.AddHours(23).AddMinutes(59))
                                                         select rr;
                                    break;

                                case FilterDateType.ResolvedDate:
                                    refundRequestQuery = from rr in refundRequestQuery
                                                         where (filter.FromDate == null || rr.ProcessedOn > startDate)
                                                               &&
                                                               (filter.ToDate == null || rr.ProcessedOn <= endDate.AddHours(23).AddMinutes(59))
                                                         select rr;
                                    break;
                            }
                        }
                    }

                    totalRecords = refundRequestQuery.Count();
                    var refundRequests = refundRequestQuery.OrderByDescending(rr => rr.RequestedOn).TakePage(pageNumber, pageSize).ToArray();
                    requests = Mapper.Map<IEnumerable<RefundRequestEntity>, IEnumerable<RefundRequest>>(refundRequests);
                    requests.ToList().ForEach(rr =>
                                                  {
                                                      var refundRequestEntity = refundRequests.Where(entity => entity.RefundRequestId == rr.Id).FirstOrDefault();

                                                      if (rr.RefundRequestResult == null && refundRequestEntity != null && !string.IsNullOrWhiteSpace(refundRequestEntity.ProcessorNotes))
                                                      {
                                                          rr.RefundRequestResult = new RefundRequestResult();
                                                          rr.RefundRequestResult.Notes = refundRequestEntity.ProcessorNotes;
                                                      }
                                                  });
                }


                orderEventCustomerPair = GetEventIdCustomerIdPairforOrders(requests.Select(rr => rr.OrderId));
                requests.ToList().ForEach(rr => rr = assignEventCustomer(rr));
                return requests;
            }
        }

        public void Delete(RefundRequest domainObject)
        {
            if (domainObject != null && domainObject.Id > 0)
            {
                RefundRequest refundRequest = Get(domainObject.Id);
                if (refundRequest.RequestStatus == (long)RequestStatus.Pending)
                {
                    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                    {
                        var entity = new RefundRequestEntity() { IsActive = false };
                        adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(RefundRequestFields.RefundRequestId == domainObject.Id));
                    }
                }
            }
        }

        public void Delete(IEnumerable<RefundRequest> domainObjects)
        {
            foreach (var domainObject in domainObjects)
            {
                if (domainObject != null && domainObject.Id > 0)
                {
                    RefundRequest refundRequest = Get(domainObject.Id);
                    if (refundRequest.RequestStatus == (long)RequestStatus.Pending)
                    {
                        using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                        {
                            var entity = new RefundRequestEntity() { IsActive = false };
                            adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(RefundRequestFields.RefundRequestId == domainObject.Id));
                        }
                    }
                }
            }
        }

        public IEnumerable<RefundRequest> GetbyOrderId(long orderId, bool resolved = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = (new LinqMetaData(adapter)).RefundRequest.Where(r => r.OrderId == orderId && r.IsActive && (!resolved ? r.RequestStatus == (long)RequestStatus.Pending : r.RequestStatus == (long)RequestStatus.Resolved)).ToArray();
                if (entities.Count() < 1) return null;
                var pair = GetEventIdCustomerIdPairforOrder(orderId);
                var requests = Mapper.Map<IEnumerable<RefundRequestEntity>, IEnumerable<RefundRequest>>(entities);

                foreach (var request in requests)
                {
                    var refundRequestEntity = entities.Where(entity => entity.RefundRequestId == request.Id).FirstOrDefault();

                    if (request.RefundRequestResult == null && refundRequestEntity != null && !string.IsNullOrWhiteSpace(refundRequestEntity.ProcessorNotes))
                    {
                        request.RefundRequestResult = new RefundRequestResult();
                        request.RefundRequestResult.Notes = refundRequestEntity.ProcessorNotes;
                    }

                    request.EventId = pair.FirstValue;
                    request.CustomerId = pair.SecondValue;
                }

                return requests;
            }

        }

        public void SaveRequestandGiftCertificateMapping(long requestId, long giftCertificateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(new RefundRequestGiftCertificateEntity(giftCertificateId, requestId)))
                    throw new PersistenceFailureException("Request and Gift Certificate mapping creation failed!");
            }
        }

        public IEnumerable<RefundRequest> GeRefundRequestByOrderIds(IEnumerable<long> orderIds, RefundRequestType refundRequestType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from rr in linqMetaData.RefundRequest
                                where rr.IsActive && rr.ReasonType == (long)refundRequestType
                                      && orderIds.Contains(rr.OrderId)
                                select rr).ToArray();
                var requests = Mapper.Map<IEnumerable<RefundRequestEntity>, IEnumerable<RefundRequest>>(entities);

                foreach (var request in requests)
                {
                    var refundRequestEntity = entities.Where(entity => entity.RefundRequestId == request.Id).FirstOrDefault();

                    if (request.RefundRequestResult == null && refundRequestEntity != null && !string.IsNullOrWhiteSpace(refundRequestEntity.ProcessorNotes))
                    {
                        request.RefundRequestResult = new RefundRequestResult();
                        request.RefundRequestResult.Notes = refundRequestEntity.ProcessorNotes;
                    }

                }
                return requests;
            }
        }
    }
}
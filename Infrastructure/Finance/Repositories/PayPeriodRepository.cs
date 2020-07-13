using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    [DefaultImplementation]
    public class PayPeriodRepository : PersistenceRepository, IPayPeriodRepository
    {
        public PayPeriod GetById(long payperiodId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entity = (from pp in linqMetaData.PayPeriod
                              where pp.Id == payperiodId
                              orderby payperiodId
                              select pp).Single();

                return Mapper.Map<PayPeriodEntity, PayPeriod>(entity);
            }
        }

        public PayPeriod Save(PayPeriod domain)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PayPeriod, PayPeriodEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Pay Period");

                return Mapper.Map<PayPeriodEntity, PayPeriod>(entity);
            }
        }

        public bool DeletePayPeriod(long payperiodId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var payperiod = GetById(payperiodId);
                if (!payperiod.IsPublished)
                {
                    var bucket = new RelationPredicateBucket(PayPeriodCriteriaFields.PayPeriodId == payperiodId);

                    adapter.DeleteEntitiesDirectly(typeof(PayPeriodCriteriaEntity), bucket);

                    bucket = new RelationPredicateBucket(PayPeriodFields.Id == payperiodId);

                    return (adapter.DeleteEntitiesDirectly(typeof(PayPeriodEntity), bucket) > 0) ? true : false;
                }

                throw new Exception("Pay Period is published, Can not be deleted");
            }
        }

        public IEnumerable<PayPeriod> GetByFilter(PayPeriodFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var query = (from pp in linqMetaData.PayPeriod select pp);

                if (filter.StartDate.HasValue)
                {
                    query = (from q in query where q.StartDate >= filter.StartDate.Value select q);
                }
                if (filter.NumberOfWeek > 0)
                {
                    query = (from q in query where q.NumberOfWeeks >= filter.NumberOfWeek select q);
                }
                var entities = (from q in query orderby q.StartDate select q);

                totalRecords = entities.Count();

                var finalEntities = entities.TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<PayPeriodEntity>, IEnumerable<PayPeriod>>(finalEntities);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsersByRoleOrParentRole(CallCenterBonusFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallCenterAgentId > 0)
                {
                    var callCenterAgent = (from u in linqMetaData.User
                                           join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                                           where (oru.OrganizationRoleUserId == filter.CallCenterAgentId) && oru.IsActive && u.IsActive
                                           select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName))

                    .OrderBy(op => op.SecondValue);

                    totalRecords = callCenterAgent.Count();

                    return callCenterAgent.TakePage(pageNumber, pageSize).ToList();
                }

                var query = (from u in linqMetaData.User
                             join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                             join r in linqMetaData.Role on oru.RoleId equals r.RoleId
                             where (r.RoleId == (long)Roles.CallCenterRep || (r.ParentId.HasValue && r.ParentId.Value == (long)Roles.CallCenterRep)) && oru.IsActive && u.IsActive
                             select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName))
                    .OrderBy(op => op.SecondValue);

                totalRecords = query.Count();

                return query.TakePage(pageNumber, pageSize).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetTotalCallcount(CallCenterBonusFilter filter, IEnumerable<long> callCenterAgentids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from c in linqMetaData.VwGetCallsForCalculatingBonus
                        where c.DateCreated >= filter.StartDate && c.DateCreated < filter.EndDate.Value.AddDays(1)
                        where callCenterAgentids.Contains(c.CreatedByOrgRoleUserId)
                        group c by c.CreatedByOrgRoleUserId into cgrp
                        select new OrderedPair<long, long>(cgrp.Key, cgrp.Count())).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetTotalBookedCustomerCount(DateTime fromDate, DateTime toDate, IEnumerable<long> callCenterAgentids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.VwGetBookedAppointmentForCalculatingBonus
                        where ec.DateCreated >= fromDate && ec.DateCreated < toDate.AddDays(1)
                         && callCenterAgentids.Contains(ec.CreatedByOrgRoleUserId)
                        group ec by ec.CreatedByOrgRoleUserId into cgrp
                        select new OrderedPair<long, long>(cgrp.Key, cgrp.Count())).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetCustomerAppeardOnEventCount(CallCenterBonusFilter filter, IEnumerable<long> callCenterAgentids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join oru in linqMetaData.OrganizationRoleUser on ec.CreatedByOrgRoleUserId equals oru.OrganizationRoleUserId
                        //join eaccount in linqMetaData.EventAccount on ec.EventId equals eaccount.EventId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                       // join a in linqMetaData.Account on eaccount.AccountId equals a.AccountId
                        where ec.DateCreated >= filter.StartDate && ec.DateCreated < filter.EndDate.Value.AddDays(1)
                        && callCenterAgentids.Contains(ec.CreatedByOrgRoleUserId)
                        && ea.CheckinTime != null && !ec.NoShow
                       // && a.IsHealthPlan
                        group ec by ec.CreatedByOrgRoleUserId into cgrp
                        select new OrderedPair<long, long>(cgrp.Key, cgrp.Count())).ToArray();
            }
        }

        public IEnumerable<PayPeriod> GetAllForDropdown()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var query = (from pp in linqMetaData.PayPeriod where pp.IsActive && pp.IsPublished && pp.StartDate <= DateTime.Today orderby pp.StartDate select pp).ToArray();

                return Mapper.Map<IEnumerable<PayPeriodEntity>, IEnumerable<PayPeriod>>(query);
            }
        }

        public PayPeriod GetNextPublishedPayPeriod(DateTime effectiveDate, bool includeEffectiveDate = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from pp in linqMetaData.PayPeriod
                             where pp.IsPublished
                             && (includeEffectiveDate ? pp.StartDate >= effectiveDate : pp.StartDate > effectiveDate)
                             orderby pp.StartDate
                             select pp).FirstOrDefault();

                return query != null ? Mapper.Map<PayPeriodEntity, PayPeriod>(query) : null;
            }
        }

        public PayPeriod GetPreviousPublishedPayPeriod(DateTime effectiveDate, bool includeEffectiveDate = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from pp in linqMetaData.PayPeriod
                             where pp.IsPublished
                             && (includeEffectiveDate ? pp.StartDate <= effectiveDate : pp.StartDate < effectiveDate)
                             orderby pp.StartDate descending
                             select pp).FirstOrDefault();

                return query != null ? Mapper.Map<PayPeriodEntity, PayPeriod>(query) : null;
            }
        }

        public IEnumerable<PayPeriod> GetPayPeriods(DateTime fromDate, DateTime toDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var firstPayPeriod = (from pp in linqMetaData.PayPeriod where pp.IsPublished && pp.IsActive && pp.StartDate <= fromDate orderby pp.StartDate descending select pp).FirstOrDefault();

                var query = (from pp in linqMetaData.PayPeriod where pp.IsPublished && pp.IsActive && pp.StartDate >= fromDate && pp.StartDate <= toDate select pp);

                if (firstPayPeriod != null)
                {
                    query = (from pp in linqMetaData.PayPeriod where pp.IsPublished && pp.IsActive && ((pp.StartDate >= fromDate && pp.StartDate <= toDate) || (pp.Id == firstPayPeriod.Id)) select pp);
                }

                var entities = query.ToArray();

                return Mapper.Map<IEnumerable<PayPeriodEntity>, IEnumerable<PayPeriod>>(entities);
            }
        }

        public long GetPayPeriodBookingCountForAgent(DateTime fromDate, DateTime toDate, long callCenterAgentId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.VwGetBookedAppointmentForCalculatingBonus
                        where ec.DateCreated >= fromDate && ec.DateCreated < toDate.AddDays(1)
                         && ec.CreatedByOrgRoleUserId == callCenterAgentId
                        select ec).Count();
            }
        }
    }
}

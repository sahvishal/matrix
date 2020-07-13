using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Application.Attributes;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class CallCenterRepository : PersistenceRepository, ICallCenterRepository
    {

        public List<Call> GetOutboundCallQueue(long callCenterRepId) // Intakes Organization RoleUserId
        {
            throw new NotImplementedException();
        }

        public int CreateCallRecordforCallStarted(Call call)
        {
            throw new NotImplementedException();
        }

        public bool CreateCallNotificationfortheCallStarted(long callId, long notificationId)
        {
            //TODO:CallQueue new Flow
            //CallNotificationEntity callNotificationEntity = new CallNotificationEntity()
            //{
            //    CallId = callId,
            //    NotificationId = notificationId,
            //    IsNew = true
            //};

            //using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            //{
            //    if (!myAdapter.SaveEntity(callNotificationEntity, false))
            //    {
            //        throw new PersistenceFailureException();
            //    }
            //}
            return true;
        }

        public int UpdateCallStatusforCallFinished()
        {
            throw new NotImplementedException();
        }

        // TODO: To be removed later on, when flow for CCRep module is corrected
        public long GetProspectCustomerIdifCallforLeadConversion(long callId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                long prospectCustomerId = 0;

                //TODO:CallQueue new Flow
                //if (IsCallTypeOutbound(callId))
                //{
                //    prospectCustomerId = linqMetaData.CallNotification.Where(callNotification => callNotification.CallId == callId).
                //        Join(linqMetaData.ProspectCustomerNotification,
                //        callNotification => callNotification.NotificationId,
                //        prospectCustomerNotification => prospectCustomerNotification.NotificationId,
                //        (callNotification, prospectCustomerNotification) => prospectCustomerNotification.ProspectCustomerId).FirstOrDefault();
                //}

                if (prospectCustomerId < 1)
                {
                    //prospectCustomerId = linqMetaData.ProspectCustomerCall.Where(pcCall => pcCall.CallId == callId).Select(pcCall => pcCall.ProspectCustomerId).FirstOrDefault();
                    prospectCustomerId = (from pc in linqMetaData.ProspectCustomerCall
                                          where pc.CallId == callId
                                          orderby pc.ProspectCustomerId descending
                                          select pc.ProspectCustomerId).FirstOrDefault();

                }

                return prospectCustomerId;
            }
        }

        public bool IsCallTypeOutbound(long callId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var callEntity = linqMetaData.Calls.Where(call => call.CallId == callId).FirstOrDefault();

                return callEntity.OutBound != null ? callEntity.OutBound.Value : true;
            }
        }

        public bool BindCallToProspectCustomer(long callId, long prospectCustomerId)
        {

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var resultRecords = (from pc in linqMetaData.ProspectCustomerCall where pc.CallId == callId select pc).ToArray();

                if (!resultRecords.IsNullOrEmpty())
                {
                    if (resultRecords.Any(x => x.ProspectCustomerId != prospectCustomerId))
                    {
                        var bucket = new RelationPredicateBucket(ProspectCustomerCallFields.CallId == callId);
                        myAdapter.DeleteEntitiesDirectly(typeof(ProspectCustomerCallEntity), bucket);
                    }
                    else
                    {
                        return true;
                    }
                }

                var prospectCustomerCall = new ProspectCustomerCallEntity()
                {
                    ProspectCustomerId = prospectCustomerId,
                    CallId = callId,
                    IsNew = true
                };

                if (!myAdapter.SaveEntity(prospectCustomerCall, false))
                {
                    throw new PersistenceFailureException();
                }
            }

            return true;
        }

        public bool BindCallToProspectCustomerForCallQueue(long callId, long prospectCustomerId)
        {

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var resultRecords = linqMetaData.ProspectCustomerCall.
                    Where(pcCall => pcCall.CallId == callId && pcCall.ProspectCustomerId == prospectCustomerId).ToList();

                if (resultRecords != null && resultRecords.Count > 0)
                    return true;

                var prospectCustomerCall = new ProspectCustomerCallEntity()
                {
                    ProspectCustomerId = prospectCustomerId,
                    CallId = callId,
                    IsNew = true
                };

                if (!myAdapter.SaveEntity(prospectCustomerCall, false))
                {
                    throw new PersistenceFailureException();
                }
            }

            return true;
        }

        public bool IsCallTiedToTheProspectCustomer(long callId, long prospectCustomerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var resultRecords = linqMetaData.ProspectCustomerCall.
                    Where(pcCall => pcCall.CallId == callId && pcCall.ProspectCustomerId == prospectCustomerId).ToList();

                if (resultRecords != null && resultRecords.Count > 0)
                    return true;
            }

            return false;
        }

        public long[] GetCallCenterAgentsForConversionReport(AgentConversionReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cca in linqMetaData.VwGetCallCenterAgentsForConversionReport
                             where cca.HealthPlanId > 0 && cca.CallQueueId > 0
                             select cca);

                if (filter != null)
                {
                    if (filter.ShowPreviousDayData)
                    {
                        filter.FromDate = DateTime.Today.AddDays(-1);
                        filter.ToDate = DateTime.Today.AddDays(-1);
                    }
                    if (filter.FromDate.HasValue)
                    {
                        query = (from q in query where q.DateCreated >= filter.FromDate.Value select q);
                    }
                    if (filter.ToDate.HasValue)
                    {
                        query = (from q in query where q.DateCreated <= filter.ToDate.Value.GetEndOfDay() select q);
                    }
                    if (filter.CallCenterAgentId > 0)
                    {
                        query = (from q in query where q.CreatedByOrgRoleUserId == filter.CallCenterAgentId select q);
                    }
                }

                var agentIds = (from q in query
                                select q.CreatedByOrgRoleUserId);

                var sortedQuery = (from oru in linqMetaData.OrganizationRoleUser
                                   join u in linqMetaData.User on oru.UserId equals u.UserId
                                   where agentIds.Contains(oru.OrganizationRoleUserId)
                                   orderby u.FirstName, u.LastName
                                   select oru.OrganizationRoleUserId);

                totalRecords = sortedQuery.Count();

                var result = sortedQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

                return result.ToArray();
            }
        }

        public IEnumerable<OutboundCall> GetoutboundCallsForAgents(AgentConversionReportFilter filter, long[] agentIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from oc in linqMetaData.VwGetOutboundCalls
                             where agentIds.Contains(oc.CreatedByOrgRoleUserId)
                             && oc.HealthPlanId > 0 && oc.CallQueueId > 0
                             select oc);

                if (filter != null)
                {
                    if (filter.ShowPreviousDayData)
                    {
                        filter.FromDate = DateTime.Today.AddDays(-1);
                        filter.ToDate = DateTime.Today.AddDays(-1);
                    }
                    if (filter.FromDate.HasValue)
                    {
                        query = (from q in query where q.DateCreated >= filter.FromDate.Value select q);
                    }
                    if (filter.ToDate.HasValue)
                    {
                        query = (from q in query where q.DateCreated <= filter.ToDate.Value.GetEndOfDay() select q);
                    }
                }

                return Mapper.Map<IEnumerable<VwGetOutboundCallsEntity>, IEnumerable<OutboundCall>>(query);
            }
        }
    }
}

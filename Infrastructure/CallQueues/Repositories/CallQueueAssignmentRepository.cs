using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class CallQueueAssignmentRepository : PersistenceRepository, ICallQueueAssignmentRepository
    {
        public IEnumerable<CallQueueAssignment> GetByCallQueueId(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cqa in linqMetaData.CallQueueAssignment
                                where cqa.CallQueueId == callQueueId
                                orderby cqa.Percentage descending 
                                select cqa).ToArray();

                return Mapper.Map<IEnumerable<CallQueueAssignmentEntity>, IEnumerable<CallQueueAssignment>>(entities);
            }
        }

        public void Save(IEnumerable<CallQueueAssignment> callQueueAssignments, long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DeleteCallQueueAssignment(callQueueId);

                if (callQueueAssignments != null && callQueueAssignments.Any())
                {
                    foreach (var callQueueAssignment in callQueueAssignments)
                    {
                        var entity = Mapper.Map<CallQueueAssignment, CallQueueAssignmentEntity>(callQueueAssignment);
                        if (!adapter.SaveEntity(entity, true))
                        {
                            throw new PersistenceFailureException();
                        }
                    }
                }
            }
        }

        private void DeleteCallQueueAssignment(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(CallQueueAssignmentFields.CallQueueId == callQueueId);
                adapter.DeleteEntitiesDirectly(typeof(CallQueueAssignmentEntity), relationPredicateBucket);
            }
        }

        public IEnumerable<CallQueueAssignment> GetByCallQueueIds(IEnumerable<long> callQueueIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cqa in linqMetaData.CallQueueAssignment
                                where callQueueIds.Contains(cqa.CallQueueId)
                                select cqa).ToArray();

                return Mapper.Map<IEnumerable<CallQueueAssignmentEntity>, IEnumerable<CallQueueAssignment>>(entities);
            }
        }

        public IEnumerable<CallQueueAssignment> GetCallQueueAssignment(CallQueueReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    var query = (from cqa in linqMetaData.CallQueueAssignment
                                 join cq in linqMetaData.CallQueue on cqa.CallQueueId equals cq.CallQueueId
                                 join oru in linqMetaData.OrganizationRoleUser on cqa.AssignedOrgRoleUserId equals oru.OrganizationRoleUserId
                                 join u in linqMetaData.User on oru.UserId equals u.UserId
                                 where cq.IsActive
                                 orderby u.FirstName, u.LastName, cqa.CallQueueId
                                 select cqa);

                    totalRecords = query.Count();
                    var entities = query.TakePage(pageNumber, pageSize).ToArray();
                    return Mapper.Map<IEnumerable<CallQueueAssignmentEntity>, IEnumerable<CallQueueAssignment>>(entities);
                }
                else
                {
                    var query = (from cqa in linqMetaData.CallQueueAssignment 
                                 join cq in linqMetaData.CallQueue on cqa.CallQueueId equals cq.CallQueueId
                                 where cq.IsActive
                                 select cqa);

                    if (filter.AssignedToOrgRoleUserId > 0)
                    {
                        query = (from q in query where q.AssignedOrgRoleUserId == filter.AssignedToOrgRoleUserId  select q);
                    }

                    if (filter.CallQueueId > 0)
                    {
                        query = (from q in query where q.CallQueueId == filter.CallQueueId select q);
                    }

                    query = (from q in query
                             join oru in linqMetaData.OrganizationRoleUser on q.AssignedOrgRoleUserId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             orderby u.FirstName, u.LastName, q.CallQueueId
                             select q);

                    totalRecords = query.Count();
                    var entities = query.TakePage(pageNumber, pageSize).ToArray();
                    return Mapper.Map<IEnumerable<CallQueueAssignmentEntity>, IEnumerable<CallQueueAssignment>>(entities);
                }
            }
        }
    }
}

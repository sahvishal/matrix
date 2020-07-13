using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class CallCenterAgentTeamLogRepository : PersistenceRepository, ICallCenterAgentTeamLogRepository
    {
        public void SaveAll(IEnumerable<CallCenterAgentTeamLog> collection)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entitycollection = new EntityCollection<CallCenterAgentTeamLogEntity>();
                foreach (var callCenterAgentTeamLog in collection)
                {
                    entitycollection.Add(Mapper.Map<CallCenterAgentTeamLog, CallCenterAgentTeamLogEntity>(callCenterAgentTeamLog));
                }
                adapter.SaveEntityCollection(entitycollection);
            }
        }

        public CallCenterAgentTeamLog Save(CallCenterAgentTeamLog domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallCenterAgentTeamLog, CallCenterAgentTeamLogEntity>(domain);
                if (entity == null)
                {
                    return null;
                }
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<CallCenterAgentTeamLogEntity, CallCenterAgentTeamLog>(entity);
            }
        }

        public IEnumerable<CallCenterAgentTeamLog> GetAgentTeamLogForTeam(long teamId, IEnumerable<long> agentIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    Mapper.Map<IEnumerable<CallCenterAgentTeamLogEntity>, IEnumerable<CallCenterAgentTeamLog>>(
                        (from ccatl in linqMetaData.CallCenterAgentTeamLog
                         where ccatl.TeamId == teamId && ccatl.IsActive && agentIds.Contains(ccatl.AgentId)
                         select ccatl).ToArray());
            }
        }
    }
}

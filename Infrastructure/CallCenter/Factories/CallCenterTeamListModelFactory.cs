using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Infrastructure.CallCenter.Factories
{
    [DefaultImplementation]
    public class CallCenterTeamListModelFactory : ICallCenterTeamListModelFactory
    {
        public CallCenterTeamListModel Create(IEnumerable<CallCenterTeam> teams, IEnumerable<OrderedPair<long, long>> teamIdAgentIdPairs, IEnumerable<OrderedPair<long, string>> idNamePairs)
        {
            var model = new CallCenterTeamListModel();
            var teamModels = new List<CallCenterTeamViewModel>();

            foreach (var callCenterTeam in teams)
            {
                var createdBy = idNamePairs.First(x=>x.FirstValue== callCenterTeam.DataRecorderMetaData.DataRecorderCreator.Id).SecondValue;

                var modifiedBy = "";
                if(callCenterTeam.DataRecorderMetaData.DataRecorderModifier!=null && callCenterTeam.DataRecorderMetaData.DataRecorderModifier.Id > 0)
                    modifiedBy = idNamePairs.First(x => x.FirstValue == callCenterTeam.DataRecorderMetaData.DataRecorderModifier.Id).SecondValue;

                var agentIds = teamIdAgentIdPairs.Where(x=>x.FirstValue== callCenterTeam.Id).Select( x=>x.SecondValue).ToArray();

                var agents = idNamePairs.Where(x=>agentIds.Contains(x.FirstValue)).Select(x=>x.SecondValue).ToArray();

                var teamModel = new CallCenterTeamViewModel
                {
                    Id = callCenterTeam.Id,
                    Name = callCenterTeam.Name,
                    Description = callCenterTeam.Description,
                    Type = ((AgentTeamType)callCenterTeam.TypeId).GetDescription(),
                    DateCreated = callCenterTeam.DataRecorderMetaData.DateCreated,
                    DateModified = callCenterTeam.DataRecorderMetaData.DateModified,
                    CreatedBy = createdBy,
                    ModifiedBy = modifiedBy,
                    Agents = agents
                };
                teamModels.Add(teamModel);
            }

            model.Collection = teamModels;
            return model;
        }
    }
}

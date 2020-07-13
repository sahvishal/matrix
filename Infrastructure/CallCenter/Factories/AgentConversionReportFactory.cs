using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Enum;

namespace Falcon.App.Infrastructure.CallCenter.Factories
{
    [DefaultImplementation]
    public class AgentConversionReportFactory : IAgentConversionReportFactory
    {
        public AgentConversionReportListModel Create(long[] agentOrgRoleUserIds, IEnumerable<OutboundCall> outboundCalls, IEnumerable<OrderedPair<long, string>> orgRoleUsers)
        {
            var collection = new List<AgentConversionReportViewModel>();

            foreach (var agentOrgRoleUserId in agentOrgRoleUserIds)
            {
                var orgRoleUser = orgRoleUsers.FirstOrDefault(x => x.FirstValue == agentOrgRoleUserId);

                if (orgRoleUser == null) continue;

                var outboundCallsForAgent = outboundCalls.Where(x => x.CreatedByOrgRoleUserId == agentOrgRoleUserId).ToArray();
                var talkedToPatientCount = outboundCallsForAgent.Count(x => x.Status == (long)CallStatus.Attended);
                var bookedAppointmentCount = outboundCallsForAgent.Count(x => x.Status == (long)CallStatus.Attended && x.Disposition == ProspectCustomerTag.BookedAppointment.ToString());

                var value = bookedAppointmentCount > 0 ? ((double)bookedAppointmentCount / talkedToPatientCount) * 100 : 0;
                var percentage = Convert.ToInt32(Math.Round(value, 0));

                collection.Add(new AgentConversionReportViewModel
                {
                    Id = agentOrgRoleUserId,
                    AgentName = orgRoleUser.SecondValue,
                    OutboundCalls = outboundCallsForAgent.Count(),
                    TalkedToPatient = talkedToPatientCount,
                    BookedAppointment = bookedAppointmentCount,
                    Conversion = percentage + "%"
                });
            }

            return new AgentConversionReportListModel
            {
                Collection = collection
            };
        }
    }
}

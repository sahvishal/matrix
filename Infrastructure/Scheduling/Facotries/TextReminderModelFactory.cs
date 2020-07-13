using Falcon.App.Core.Scheduling;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core;
using Falcon.App.Core.Users;
namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class TextReminderModelFactory : ITextReminderModelFactory
    {
        private readonly IRoleRepository _roleRepository;
        public TextReminderModelFactory(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public TextReminderListModel Create(IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Customer> customers, IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs)
        {
            var model = new TextReminderListModel();
            var textReminderModels = new List<TextReminderViewModel>();

            eventCustomers.ToList().ForEach(ec =>
            {
                var eventModel = eventListModel.Collection.Where(e => e.EventCode == ec.EventId).FirstOrDefault();

                var customer = customers.Where(c => c.CustomerId == ec.CustomerId).FirstOrDefault();

                var registeredBy = (ec.DataRecorderMetaData == null || ec.DataRecorderMetaData.DataRecorderCreator == null ? null : agents.Where(a => a.Id == ec.DataRecorderMetaData.DataRecorderCreator.Id).FirstOrDefault());

                string agentName, agentRole;
                agentRole = agentName = string.Empty;
                if (registeredBy != null)
                {

                    if (GetParentRoleIdByRoleId(registeredBy.RoleId) == (long)Roles.Customer)
                    {
                        agentRole = "Internet";
                        agentName = "";
                    }
                    else
                    {
                        agentRole = roles.Where(r => r.Id == registeredBy.RoleId).FirstOrDefault().DisplayName;
                        agentName = agentIdNamePairs.Where(ap => ap.FirstValue == registeredBy.Id).FirstOrDefault().SecondValue;
                    }
                }

                var textReminderModel = new TextReminderViewModel
                {
                    CustomerId = ec.CustomerId,
                    OptedForSmsStaus = ec.EnableTexting ? "Yes" : "No",
                    EventId = eventModel.EventCode,
                    CustomerName = customer.Name.FullName,
                    AgentName = agentName + " (" + agentRole + ")",
                };

                textReminderModels.Add(textReminderModel);
            });
            model.Collection = textReminderModels;
            return model;
        }
        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }
    }
}

using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Factories
{
    public class TechnicianFactory : ITechnicianFactory
    {
        public Technician CreateTechnician(Technician technician, TechnicianProfileEntity technicianProfileEntity)
        {
            technician.CanDoPreAudit = technicianProfileEntity.CanCompletePreAudit;
            technician.IsTeamLead = technicianProfileEntity.IsTeamLead;
            technician.TechnicianId = technicianProfileEntity.OrganizationRoleUserId;
            technician.Pin = !string.IsNullOrWhiteSpace(technicianProfileEntity.Pin) ? technicianProfileEntity.Pin.Decrypt() : string.Empty;
            technician.PinChangeDate = technicianProfileEntity.PinChangeDate;

            return technician;
        }

        public TechnicianProfileEntity CreateTechnicianProfileEntity(Technician technician)
        {
            return new TechnicianProfileEntity()
                       {
                           OrganizationRoleUserId = technician.TechnicianId,
                           CanCompletePreAudit = technician.CanDoPreAudit,
                           IsTeamLead = technician.IsTeamLead,
                           Pin = !string.IsNullOrWhiteSpace(technician.Pin) ? technician.Pin.Encrypt() : string.Empty,
                           PinChangeDate = technician.PinChangeDate
                       };
        }
    }
}

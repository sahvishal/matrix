using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ITechnicianRepository
    {
        bool IsTeamLead(long technicianId);
        Technician GetTechnician(long technicianId);
        bool UpdatePin(long technicianId, string pin);
        int GetPinExpireInDays(long technicianId, int pinExpirationDays);
    }
}
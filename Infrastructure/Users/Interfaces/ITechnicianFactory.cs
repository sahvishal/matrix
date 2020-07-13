using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface ITechnicianFactory
    {
        Technician CreateTechnician(Technician technician, TechnicianProfileEntity technicianProfileEntity);
        TechnicianProfileEntity CreateTechnicianProfileEntity(Technician technician);
    }
}

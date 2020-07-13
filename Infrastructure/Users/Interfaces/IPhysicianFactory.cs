using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IPhysicianFactory
    {
        Physician CreatePhysician(Physician physician, PhysicianProfileEntity physicianProfile);
        PhysicianProfileEntity CreatePhysicianEntity(Physician physician);
    }
}

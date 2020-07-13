using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianMasterRepository
    {
        PhysicianMaster Save(PhysicianMaster domain);
        PhysicianMaster GetByNpi(string npi);
        PhysicianMaster GetById(long id);
        IEnumerable<PhysicianMaster> Search(string firstName, string lastName, string zipcode, int pageNumber, int pageSize, out int totalRecords);
    }
}

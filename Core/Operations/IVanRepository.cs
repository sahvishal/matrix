using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IVanRepository
    {
        Van GetVan(long vanId);        
        List<Van> GetVans(string vanName);
        List<Van> GetAllVans();
        Van SaveVan(Van van);
        void UpdateVan(Van van);
        void DeleteVan(long vanId);

        bool IsVanNameUnique(string vanName, long excludedId);
    }
}

using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface ILabRepository
    {
        IEnumerable<Lab> GetAll();
        Lab GetByName(string name);
        Lab Save(Lab domain);
        Lab GetById(long id);
    }
}

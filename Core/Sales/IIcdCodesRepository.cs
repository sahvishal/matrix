using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface IIcdCodesRepository
    {
        IcdCode GetIcdCodebyId(long id);
        IcdCode GetIcdByCodeName(string codeName);
        IcdCode Save(IcdCode icdCode);
        void Save(IEnumerable<IcdCode> icdCode);
        IEnumerable<IcdCode> GetIcdByCodeNames(IEnumerable<string> codeName);
        IEnumerable<IcdCode> GetIcdByIds(IEnumerable<long> ids);
    }
}
using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetAll();
        Language GetByName(string name);
        Language Save(Language domain);
        Language GetById(long id);
    }
}

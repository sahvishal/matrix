using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;

namespace Falcon.App.Core.Application
{
    public interface INotesRepository
    {
        Notes Get(long id);
        IEnumerable<Notes> Get(IEnumerable<long> ids);
        Notes Save(Notes domainObject);
    }
}
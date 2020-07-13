using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Marketing
{
    public interface IDirectMailTypeRepository
    {
        DirectMailType GetById(long id);
        DirectMailType GetByDirectMailName(string directMailName);
        IEnumerable<DirectMailType> GetAll();
    }
}

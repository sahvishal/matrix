using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface IScriptRepository
    {
        Script GetById(long id);
        IEnumerable<Script> GetByIds(IEnumerable<long> ids);
        Script Save(Script domain);
    }
}

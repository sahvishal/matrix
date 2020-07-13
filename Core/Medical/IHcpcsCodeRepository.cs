using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IHcpcsCodeRepository
    {
        List<HcpcsCode> GetAll();
        HcpcsCode SaveHcpcsCode(HcpcsCode domainObject); 
    }
}

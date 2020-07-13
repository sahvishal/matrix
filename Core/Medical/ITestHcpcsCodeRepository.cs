using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ITestHcpcsCodeRepository
    {
        List<TestHcpcsCode> GetAll();
        TestHcpcsCode SaveTestHcpcsCode(TestHcpcsCode domainObject); 
    }
}

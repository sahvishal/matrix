
using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ITestPerformedExternallyRepository
    {
        void Save(TestPerformedExternally testPerformedExternally);
    }
}

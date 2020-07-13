using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;
namespace Falcon.App.Core.Medical
{
   public interface ITestPerformedExternallyFactory
    {
       TestPerformedExternally CreateModel(TestPerformedExternally testPerformedExternally, long customerEventScreeningTestId);
    }
}

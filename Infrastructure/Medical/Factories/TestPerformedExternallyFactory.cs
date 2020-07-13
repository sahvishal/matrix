using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.Data.EntityClasses;
using System;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    public class TestPerformedExternallyFactory : ITestPerformedExternallyFactory
    {
        public TestPerformedExternally CreateModel(TestPerformedExternally testPerformedExternally, long customerEventScreeningTestId)
        {
            if (testPerformedExternally == null) return null;

            return new TestPerformedExternally
            {
                CustomerEventScreeningTestId = customerEventScreeningTestId,
                EntryCompleted = testPerformedExternally.EntryCompleted,
                ResultEntryTypeId = (long)ResultEntryType.Chat,
                CreatedBy = testPerformedExternally.CreatedBy,
                CreatedDate = testPerformedExternally.CreatedDate,
                ModifiedBy = testPerformedExternally.ModifiedBy,
                ModifiedDate = testPerformedExternally.ModifiedDate
            };
        }
    }
}

using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class TestPerformedExternallyRepository : PersistenceRepository, ITestPerformedExternallyRepository
    {
        public void Save(TestPerformedExternally testPerformedExternally)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var update = linqMetaData.TestPerformedExternally.Any(tpe => tpe.CustomerEventScreeningTestId == testPerformedExternally.CustomerEventScreeningTestId);
                if (update)
                {
                    var entity = new TestPerformedExternallyEntity()
                    {
                        EntryCompleted = testPerformedExternally.EntryCompleted,
                        ResultEntryTypeId = testPerformedExternally.ResultEntryTypeId,
                        ModifiedBy = testPerformedExternally.CreatedBy,
                        ModifiedDate = DateTime.Now,
                    };
                    var bucket = new RelationPredicateBucket(TestPerformedExternallyFields.CustomerEventScreeningTestId == testPerformedExternally.CustomerEventScreeningTestId);
                    adapter.UpdateEntitiesDirectly(entity, bucket);
                }
                else
                {
                    var entitiy = Mapper.Map<TestPerformedExternally, TestPerformedExternallyEntity>(testPerformedExternally);
                    adapter.SaveEntity(entitiy);
                }
            }
        }
    }
}

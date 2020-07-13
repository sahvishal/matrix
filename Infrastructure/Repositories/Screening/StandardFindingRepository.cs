using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Factories.Screening;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.Data.Linq;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    [DefaultImplementation(Interface = typeof(IStandardFindingRepository))]
    public class StandardFindingRepository : PersistenceRepository, IStandardFindingRepository
    {
        private readonly IStandardFindingFactory _standardFindingFactory;

        public StandardFindingRepository()
        {
            _standardFindingFactory = new StandardFindingFactory();
        }

        public StandardFindingRepository(IStandardFindingFactory standardFindingFactory)
        {
            _standardFindingFactory = standardFindingFactory;
        }

        public IEnumerable<StandardFinding<T>> GetByIds<T>(IEnumerable<long> ids)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var findings = linqMetaData.StandardFinding.Where(sf => ids.Contains(sf.StandardFindingId)).ToArray();
                if (findings.Count() < 1) return null;
                return _standardFindingFactory.CreateStandardFindings<T>(findings.ToList());
            }
        }

        public List<StandardFinding<T>> GetAllStandardFindings<T>(int testId)
        {
            List<StandardFindingEntity> standardFindingEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                standardFindingEntities = linqMetaData.StandardFinding.
                    WithPath(prefetchPath => prefetchPath.Prefetch(standardFinding => standardFinding.StandardFindingTestReading)).
                    Join(linqMetaData.StandardFindingTestReading, standardFinding => standardFinding.StandardFindingId, standardTestReading => standardTestReading.StandardFindingId, (standardFinding, standardTestReading) => new { standardFinding, standardTestReading }).
                    Where(@t => @t.standardTestReading.TestId == testId && @t.standardTestReading.ReadingId == null).
                    Select(@t => @t.standardFinding).OrderBy(@t => @t.WorstCaseOrder.HasValue ? @t.WorstCaseOrder : @t.StandardFindingId).
                    ToList();

            }
            return _standardFindingFactory.CreateStandardFindings<T>(standardFindingEntities);
        }

        public List<StandardFinding<T>> GetAllStandardFindings<T>(int testId, int readingId)
        {
            List<StandardFindingEntity> standardFindingEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                standardFindingEntities = linqMetaData.StandardFinding.
                    WithPath(prefetchPath => prefetchPath.Prefetch(standardFinding => standardFinding.StandardFindingTestReading)).
                    Join(linqMetaData.StandardFindingTestReading, standardFinding => standardFinding.StandardFindingId, standardTestReading => standardTestReading.StandardFindingId, (standardFinding, standardTestReading) => new { standardFinding, standardTestReading }).
                    Where(@t => @t.standardTestReading.TestId == testId && @t.standardTestReading.ReadingId == readingId).
                    Select(@t => @t.standardFinding).OrderBy(@t => @t.WorstCaseOrder.HasValue ? @t.WorstCaseOrder : @t.StandardFindingId).
                    ToList();

            }
            return _standardFindingFactory.CreateStandardFindings<T>(standardFindingEntities);
        }

        public long GetStandardFindingTestReadingIdForStandardFinding(int testId, int? readingId, long standardFindingId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                if (readingId != null)
                    return linqMetaData.StandardFinding.
                        Join(linqMetaData.StandardFindingTestReading,
                             standardFinding => standardFinding.StandardFindingId,
                             standardTestReading => standardTestReading.StandardFindingId,
                             (standardFinding, standardTestReading) => new { standardFinding, standardTestReading }).
                        Where(
                        @t =>
                        @t.standardTestReading.TestId == testId && (@t.standardTestReading.ReadingId == readingId) &&
                        @t.standardTestReading.StandardFindingId == standardFindingId).
                        Select(@t => @t.standardTestReading.StandardFindingTestReadingId).SingleOrDefault();
                else
                {
                    return linqMetaData.StandardFinding.
                        Join(linqMetaData.StandardFindingTestReading,
                             standardFinding => standardFinding.StandardFindingId,
                             standardTestReading => standardTestReading.StandardFindingId,
                             (standardFinding, standardTestReading) => new { standardFinding, standardTestReading }).
                        Where(
                        @t =>
                        @t.standardTestReading.TestId == testId &&
                        @t.standardTestReading.StandardFindingId == standardFindingId).
                        Select(@t => @t.standardTestReading.StandardFindingTestReadingId).SingleOrDefault();
                }

            }
        }

        public StandardFinding<T> GetStandardFinding<T>(long standardFindingId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var standardFindingEntity = linqMetaData.StandardFinding.Where(finding => finding.StandardFindingId == standardFindingId).SingleOrDefault();

                return _standardFindingFactory.CreateStandardFinding<T>(standardFindingEntity);
            }
        }

        public List<StandardFinding<T>> GetAllStandardFindings<T>(int testId, int readingId, DateTime dateCreated, bool before)
        {
            List<StandardFindingEntity> standardFindingEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                standardFindingEntities = linqMetaData.StandardFinding.
                    WithPath(prefetchPath => prefetchPath.Prefetch(standardFinding => standardFinding.StandardFindingTestReading)).
                    Join(linqMetaData.StandardFindingTestReading, standardFinding => standardFinding.StandardFindingId, standardTestReading => standardTestReading.StandardFindingId, (standardFinding, standardTestReading) => new { standardFinding, standardTestReading }).
                    Where(@t => @t.standardTestReading.TestId == testId && @t.standardTestReading.ReadingId == readingId 
                        && (before ? @t.standardFinding.CreatedOn < dateCreated : @t.standardFinding.CreatedOn >= dateCreated)).
                    Select(@t => @t.standardFinding).OrderBy(@t => @t.WorstCaseOrder.HasValue ? @t.WorstCaseOrder : @t.StandardFindingId).
                    ToList();

            }
            return _standardFindingFactory.CreateStandardFindings<T>(standardFindingEntities);
        }

    }
}

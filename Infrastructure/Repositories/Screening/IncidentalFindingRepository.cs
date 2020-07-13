using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Mappers.Screening;
using Falcon.Data.Linq;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    [DefaultImplementation(Interface = typeof(IIncidentalFindingRepository))]
    public class IncidentalFindingRepository : PersistenceRepository, IIncidentalFindingRepository
    {
        private readonly IMapper<IncidentalFinding, IncidentalFindingsEntity> _mapper;

        public IncidentalFindingRepository()
        {
            _mapper = new IncidentalFindingMapper();
        }

        public IncidentalFindingRepository(IMapper<IncidentalFinding, IncidentalFindingsEntity> mapper)
        {
            _mapper = mapper;
        }

        public List<IncidentalFindingGroup> GetAllIncidentalFindingGroup()
        {
            var incidentalFindingGroups = new List<IncidentalFindingGroup>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var incidentalFindingGroupEntities = linqMetaData.IncidentalFindingReadingGroup.WithPath(prefetchPath => prefetchPath.Prefetch(incidentalFinding =>
                    incidentalFinding.IncidentalFindingReadingGroupItem)).ToList();

                //TODO: To move it to Factory/Mapper
                incidentalFindingGroupEntities.ForEach(incidentalFindingGroupEntity =>
                    {
                        var incidentalFindingGroup = new IncidentalFindingGroup(incidentalFindingGroupEntity.GroupId);
                        incidentalFindingGroup.GroupItems = new List<IncidentalFindingGroupItem>();
                        incidentalFindingGroupEntity.IncidentalFindingReadingGroupItem.ToList()
                            .ForEach(
                                findingGroupItem =>
                                incidentalFindingGroup.GroupItems.Add(
                                    new IncidentalFindingGroupItem(findingGroupItem.GroupItemId)
                                        {
                                            Label = findingGroupItem.Label
                                        }));

                        incidentalFindingGroups.Add(incidentalFindingGroup);
                    });
            }
            return incidentalFindingGroups;
        }

        public IEnumerable<IncidentalFinding> GetAllIncidentalFinding()
        {
            IEnumerable<IncidentalFindingsEntity> incidentalFindingsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var query = (from inF in linqMetaData.IncidentalFindings select inF);

                incidentalFindingsEntities = query.
                    WithPath(prefetchPath => prefetchPath.Prefetch(incidentalFinding => incidentalFinding.IncidentalFindingIncidentalFindingReadingGroup)
                                                            .Prefetch(incidentalFinding => incidentalFinding.IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup)).ToArray();

                foreach (var incidentalFindingEntity in incidentalFindingsEntities)
                {
                    incidentalFindingEntity.
                        IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.ToList()
                        .ForEach(
                            readingGroup =>
                            readingGroup.IncidentalFindingReadingGroupItem.AddRange(
                                linqMetaData.IncidentalFindingReadingGroupItem.Where(
                                    readingGroupItem => readingGroupItem.GroupId == readingGroup.GroupId)));
                }
            }
            return _mapper.MapMultiple(incidentalFindingsEntities).ToArray();
        }

        public List<IncidentalFinding> GetAllIncidentalFinding(long testId)
        {
            List<IncidentalFindingsEntity> incidentalFindingsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var query = (from inF in linqMetaData.IncidentalFindings join tIf in linqMetaData.TestIncidentalFinding on inF.IncidentalFindingsId equals tIf.IncidentalFindingId
                            where tIf.TestId == testId
                            orderby tIf.Sequence
                            select inF );

                incidentalFindingsEntities = query.
                    WithPath(prefetchPath => prefetchPath.Prefetch(incidentalFinding => incidentalFinding.IncidentalFindingIncidentalFindingReadingGroup)
                                                            .Prefetch(incidentalFinding => incidentalFinding.IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup)).ToList();
                
                incidentalFindingsEntities.ForEach(
                    incidentalFindingEntity =>
                    incidentalFindingEntity.
                        IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup.ToList()
                        .ForEach(
                        readingGroup =>
                        readingGroup.IncidentalFindingReadingGroupItem.AddRange(
                            linqMetaData.IncidentalFindingReadingGroupItem.Where(
                                readingGroupItem => readingGroupItem.GroupId == readingGroup.GroupId))));

            }
            return _mapper.MapMultiple(incidentalFindingsEntities).ToList();
        }
    }
}
//.WithPath(prefetchPath => prefetchPath.Prefetch(incidentalFindingReadingGroup => incidentalFindingReadingGroup.IncidentalFindingsCollectionViaIncidentalFindingIncidentalFindingReadingGroup).Prefetch(incidentalFindingReadingGroup => incidentalFindingReadingGroup.IncidentalFindingReadingGroupItem))
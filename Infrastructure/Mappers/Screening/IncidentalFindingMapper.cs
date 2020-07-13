using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Mappers.Screening
{
    [DefaultImplementation(Interface = typeof(IMapper<IncidentalFinding, IncidentalFindingsEntity>))]
    public class IncidentalFindingMapper : DomainEntityMapper<IncidentalFinding, IncidentalFindingsEntity>
    {
        protected override void MapDomainFields(IncidentalFindingsEntity entity, 
            IncidentalFinding domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.IncidentalFindingsId;
            domainObjectToMapTo.Label = entity.Label;
            domainObjectToMapTo.LocationCount = (int)entity.LocationCount;

            EntityCollection<IncidentalFindingReadingGroupEntity> incidentalFindingReadingGroupEntities =
                entity.
                IncidentalFindingReadingGroupCollectionViaIncidentalFindingIncidentalFindingReadingGroup;
            if (incidentalFindingReadingGroupEntities != null)
            {
                domainObjectToMapTo.IncidentalFindingGroups = new List<IncidentalFindingGroup>();
                foreach (var incidentalFindingReadingGroupEntity in incidentalFindingReadingGroupEntities)
                {
                    var incidentalFindingGroup = new IncidentalFindingGroup(incidentalFindingReadingGroupEntity.GroupId)
                    {
                        GroupItems = new List<IncidentalFindingGroupItem>()
                    };
                    foreach (var incidentalFindingReadingGroupItem in 
                        incidentalFindingReadingGroupEntity.IncidentalFindingReadingGroupItem)
                    {
                        var groupItem = new IncidentalFindingGroupItem(incidentalFindingReadingGroupItem.
                            GroupItemId)
                        {
                            Label = incidentalFindingReadingGroupItem.Label
                        };
                        incidentalFindingGroup.GroupItems.Add(groupItem);
                    }
                    domainObjectToMapTo.IncidentalFindingGroups.Add(incidentalFindingGroup);
                }
            }
        }

        protected override void MapEntityFields(IncidentalFinding domainObject, 
            IncidentalFindingsEntity entityToMapTo)
        {
            throw new NotImplementedException();
        }
    }
}
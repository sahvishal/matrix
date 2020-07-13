using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.App.Infrastructure.Users.Mappers;
using Falcon.Data.Linq;
using System.Transactions;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation(Interface = typeof(IOrganizationRepository))]
    public class OrganizationRepository : PersistenceRepository, IOrganizationRepository
    {
        IMapper<Organization, OrganizationEntity> _mapper;

        public OrganizationRepository()
            : this(new SqlPersistenceLayer(), new OrganizationMapper())
        { }

        public OrganizationRepository(IPersistenceLayer persistenceLayer, IMapper<Organization, OrganizationEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }


        public long SaveOrganization(Organization organization)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var transactionScope = new TransactionScope())
                {
                    var entityToSave = _mapper.Map(organization);
                    if (!myAdapter.SaveEntity(entityToSave, true, false))
                    {
                        throw new PersistenceFailureException();
                    }
                    transactionScope.Complete();

                    return entityToSave.OrganizationId;
                }
            }

        }

        public Organization GetOrganizationbyId(long organizationId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organizationEntity = linqMetaData.Organization.Where(entity => entity.OrganizationId == organizationId).FirstOrDefault();

                if (organizationEntity == null) throw new ObjectNotFoundInPersistenceException<Organization>(organizationId);

                var organization = _mapper.Map(organizationEntity);

                return organization;
            }
        }

        public IEnumerable<Organization> GetOrganizations(long[] ids)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = linqMetaData.Organization.Where(entity => ids.Contains(entity.OrganizationId));

                return _mapper.MapMultiple(entities);
            }
        }

        public List<Organization> GetAllOrganizationsforUser(long userId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = linqMetaData.Organization.Join(linqMetaData.OrganizationRoleUser.Where(oru => oru.UserId == userId), organizationEntity => organizationEntity.OrganizationId,
                                                                        orgRoleUser => orgRoleUser.OrganizationId, (organizationEntity, orgRoleUser) => organizationEntity);

                return _mapper.MapMultiple(entities).ToList();
            }
        }

        public IEnumerable<Organization> GetOrganizationCollection(OrganizationType type)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = linqMetaData.Organization.Where(org => org.OrganizationTypeId == (long)type && org.IsActive).AsEnumerable();

                return _mapper.MapMultiple(entities).ToArray();
            }
        }

        public IEnumerable<Organization> GetOrganizationCollection(OrganizationType type, string searchText)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = linqMetaData.Organization.Where(org => org.OrganizationTypeId == (long)type && org.Name.Contains(searchText) && org.IsActive).AsEnumerable();

                return _mapper.MapMultiple(entities).ToArray();
            }
        }

        public IEnumerable<OrderedPair<string, long>> GetOrganizationIdNamePairs(OrganizationType type)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.Organization.Where(org => org.OrganizationTypeId == (long)type && org.IsActive).
                        Select(org => new OrderedPair<string, long>(org.Name, org.OrganizationId)).ToArray().OrderBy(org => org.FirstValue);
            }
        }

        public IEnumerable<OrderedPair<string, long>> GetAllOrganizationIdNamePairs()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.Organization.Where(org => org.IsActive).
                        Select(org => new OrderedPair<string, long>(org.Name, org.OrganizationId)).OrderBy(or => or.FirstValue).ToArray();
            }
        }

        public IEnumerable<OrderedPair<string, long>> GetOrganizationRoles(OrganizationType organizationType)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.Role.Where(roleEntity => roleEntity.IsActive && roleEntity.OrganizationTypeId == (long)organizationType).
                        Select(roleEntity => new OrderedPair<string, long>(roleEntity.Name, roleEntity.RoleId)).OrderBy(r => r.FirstValue).ToArray();
            }
        }


        public IEnumerable<OrderedPair<string, long>> GetOrganizationTypes()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.OrganizationType.Select(orgt => new OrderedPair<string, long>(orgt.Name, orgt.OrganizationTypeId)).ToArray();
            }
        }

        public bool Deactivate(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new OrganizationEntity { IsActive = false };
                var bucket = new RelationPredicateBucket(OrganizationFields.OrganizationId == id);

                if (adapter.UpdateEntitiesDirectly(entity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }

        public IEnumerable<MedicareSiteModel> GetMedicareSites()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from o in linqMetaData.Organization
                                join a in linqMetaData.Account on o.OrganizationId equals a.AccountId
                                where a.IsHealthPlan && a.Tag != null

                                select new MedicareSiteModel
                                {
                                    Name = o.Name,
                                    Description = o.Description,
                                    PhoneNumber = o.PhoneNumber,
                                    FaxNumber = o.FaxNumber,
                                    Email = o.Email,
                                    Alias = a.Tag,
                                    ShowHraQuestionnaire = false,
                                    AccountId = a.AccountId
                                }).ToArray();

                return entities;
            }
        }



        public IEnumerable<RoleDropdownListModel> GetRolesByOrganizationType(OrganizationType organizationType)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.Role.Where(roleEntity => roleEntity.IsActive && roleEntity.OrganizationTypeId == (long)organizationType).
                    Select(roleEntity => new RoleDropdownListModel
                    {
                        RoleId = roleEntity.RoleId,
                        Name = roleEntity.Name,
                        ParentId = roleEntity.ParentId.HasValue ? roleEntity.ParentId.Value : 0
                    }).OrderBy(x => x.Name).ToArray();
            }
        }

        public bool IsActiveOrganizationbyId(long organizationId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organizationEntity = linqMetaData.Organization.Where(entity => entity.OrganizationId == organizationId && entity.IsActive).FirstOrDefault();

                return organizationEntity !=null && organizationEntity.OrganizationId > 0 ? true : false;
               
            }
        }
    }
}
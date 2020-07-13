using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    public class RoleRepository : PersistenceRepository, IRoleRepository
    {

        public IEnumerable<Role> GetAll()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.Role.Where(r => r.IsActive).OrderBy(r => r.Name);

                return roleEntities.Select(Mapper.Map<RoleEntity, Role>).ToList();

            }
        }

        public IEnumerable<Role> GetAllSystemRoles()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.Role.Where(r => r.IsActive && r.IsSystemRole).OrderBy(r => r.Name);

                return roleEntities.Select(Mapper.Map<RoleEntity, Role>).ToList();

            }
        }

        public IEnumerable<Role> GetRolesByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return GetAll();

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.Role.Where(r => r.IsActive && r.Name.ToLower().Contains(name.ToLower())).OrderBy(r => r.Name);

                return roleEntities.Select(Mapper.Map<RoleEntity, Role>).ToList();

            }
        }

        public int GetRoleCount(long roleId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.OrganizationRoleUser.Count(r => r.IsActive && r.RoleId == roleId);
            }
        }

        public IEnumerable<Role> GetRolesByParentId(long parentId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.Role.Where(r => r.IsActive && r.ParentId == parentId);

                return roleEntities.Select(Mapper.Map<RoleEntity, Role>).ToList();

            }
        }

        public Role GetByRoleId(long roleId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntity = linqMetaData.Role.FirstOrDefault(r => r.IsActive && r.RoleId == roleId);

                return Mapper.Map<RoleEntity, Role>(roleEntity);
            }
        }

        public Role Save(Role role)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Role, RoleEntity>(role);

                entity.IsNew = role.Id < 1;

                if (!adapter.SaveEntity(entity, true, true))
                {
                    throw new PersistenceFailureException();
                }

                role.Id = entity.RoleId;
                return role;
            }
        }

        public bool OverRideIsTwoFactorAuthRequired(long roleId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new UserLoginEntity() { IsTwoFactorAuthrequired = null };
                var bucket = new RelationPredicateBucket();
                bucket.Relations.Add(UserLoginEntity.Relations.UserEntityUsingUserLoginId);
                bucket.PredicateExpression.Add(UserFields.DefaultRoleId == roleId);
                myAdapter.UpdateEntitiesDirectly(entity, bucket);
                return true;
            }
        }
        public IEnumerable<Role> GetRolesByExactName(string name)
        {
            if (string.IsNullOrEmpty(name)) return GetAll();

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.Role.Where(r => r.IsActive && r.Name.ToLower().Equals(name.ToLower()));

                return roleEntities.Select(Mapper.Map<RoleEntity, Role>).ToList();

            }
        }

        public List<Role> GetByRoleIds(List<long> roleIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.Role.Where(r => r.IsActive && roleIds.Contains(r.RoleId));

                return roleEntities.Select(Mapper.Map<RoleEntity, Role>).ToList();
            }
        }

        public IEnumerable<Role> GetRolesByAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias)) return GetAll();

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.Role.Where(r => r.IsActive && r.Alias.ToLower().Contains(alias.ToLower())).OrderBy(r => r.Name);

                return roleEntities.Select(Mapper.Map<RoleEntity, Role>).ToList();

            }
        }
    }
}
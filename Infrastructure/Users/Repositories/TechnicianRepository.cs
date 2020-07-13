using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Factories;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    public class TechnicianRepository : PersistenceRepository, IRepository<Technician>, ITechnicianRepository
    {
        private readonly ITechnicianFactory _technicianfactory;
        private readonly IUserRepository<Technician> _userRepository;

        public TechnicianRepository()
            : this(new SqlPersistenceLayer(), new TechnicianFactory(), new UserRepository<Technician>())
        { }

        public TechnicianRepository(IPersistenceLayer persistenceLayer, ITechnicianFactory technicianfactory, IUserRepository<Technician> userRepository)
            : base(persistenceLayer)
        {
            _technicianfactory = technicianfactory;
            _userRepository = userRepository;
        }

        public Technician Save(Technician domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var dbTechnician = linqMetaData.TechnicianProfile.FirstOrDefault(x => x.OrganizationRoleUserId == domainObject.TechnicianId);
                var entity = _technicianfactory.CreateTechnicianProfileEntity(domainObject);

                if (dbTechnician != null)
                {
                    entity.IsNew = false;
                    if (!string.IsNullOrEmpty(entity.Pin) && entity.Pin != dbTechnician.Pin)
                        entity.PinChangeDate = DateTime.Now;
                    else
                    {
                        entity.Pin = dbTechnician.Pin;
                        entity.PinChangeDate = dbTechnician.PinChangeDate;
                    }
                }
                else
                {
                    entity.IsNew = true;
                }

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return _technicianfactory.CreateTechnician(domainObject, entity);
            }
        }

        public void Delete(Technician domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Technician> domainObjects)
        {
            throw new NotImplementedException();
        }

        public bool IsTeamLead(long technicianId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(myAdapter);

                var orgRoleUserEntity = linqMetaData.TechnicianProfile.Where(tp => tp.OrganizationRoleUserId == technicianId).FirstOrDefault();

                if (orgRoleUserEntity == null)
                    return false;

                return orgRoleUserEntity.IsTeamLead;
            }
        }

        public Technician GetTechnician(long technicianId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var technicianProfileEntity =
                    linqMetaData.TechnicianProfile.WithPath(
                        prefetchPath =>
                        prefetchPath.Prefetch(tp => tp.OrganizationRoleUser)).
                        Where(tp => tp.OrganizationRoleUserId == technicianId).FirstOrDefault();

                if (technicianProfileEntity == null)
                    return null;

                Technician user = _userRepository.GetUser(technicianProfileEntity.OrganizationRoleUser.UserId);

                return _technicianfactory.CreateTechnician(user, technicianProfileEntity);
            }
        }

        public bool UpdatePin(long technicianId, string pin)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomerResultEntity = new TechnicianProfileEntity(technicianId) { Pin = pin, PinChangeDate = DateTime.Now };
                var bucket = new RelationPredicateBucket(TechnicianProfileFields.OrganizationRoleUserId == technicianId);
                return (myAdapter.UpdateEntitiesDirectly(eventCustomerResultEntity, bucket) > 0);
            }
        }

        public int GetPinExpireInDays(long technicianId, int pinExpirationDays)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var technician = linqMetaData.TechnicianProfile.SingleOrDefault(x => x.OrganizationRoleUserId == technicianId);

                if (technician == null || !technician.PinChangeDate.HasValue) return 0;

                var totalDaysLastPinChage = (technician.PinChangeDate.Value.AddDays(pinExpirationDays).Date - DateTime.Today.Date).TotalDays + 1;

                return Convert.ToInt32(totalDaysLastPinChage);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    public class StateRepository : PersistenceRepository, IStateRepository
    {
        private readonly IMapper<State, StateEntity> _mapper = new StateMapper();

        public List<State> GetAllStates()
        {
            List<StateEntity> stateEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                stateEntities = linqMetaData.State.Where(s => s.IsActive == true).OrderBy(s => s.Name).ToList();
            }
            return _mapper.MapMultiple(stateEntities).ToList();
        }

        public List<State> GetStates(IEnumerable<long> stateIds)
        {
            List<StateEntity> stateEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                stateEntities = linqMetaData.State.Where(s => stateIds.Contains(s.StateId)).OrderBy(s => s.Name).ToList();
            }
            return _mapper.MapMultiple(stateEntities).ToList();
        }

        public State GetState(long stateId)
        {
            var stateEntity = new StateEntity(stateId);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.FetchEntity(stateEntity))
                {
                    throw new ObjectNotFoundInPersistenceException<State>(stateId);
                }
            }
            return _mapper.Map(stateEntity);
        }

        public State GetState(string stateName)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var stateEntity = linqMetaData.State.Where(state => state.Name == stateName).SingleOrDefault();
                if (stateEntity == null)
                    throw new Exception("Invalid State Name:" + stateName);

                return _mapper.Map(stateEntity);
            }
        }

        public State GetStatebyCode(string stateCode)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var stateEntity =
                    linqMetaData.State.Where(state => state.StateCode == stateCode.Trim()).FirstOrDefault();
                if (stateEntity == null) return null;

                return _mapper.Map(stateEntity);
            }
        }


        public State GetStateByZip(long zipId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var stateEntity =
                    linqMetaData.State.Join(linqMetaData.City, s => s.StateId, c => c.StateId,
                                            (s, c) => new { State = s, City = c }).Join(linqMetaData.Zip,
                                                                                      @t => @t.City.CityId,
                                                                                      z => z.CityId,
                                                                                      (@t, z) => new { @t, Zip = z }).
                        Where(@a => @a.Zip.ZipId == zipId).Select(@a => @a.t.State).SingleOrDefault();

                if (stateEntity == null) throw new ObjectNotFoundInPersistenceException<State>();

                return _mapper.Map(stateEntity);
            }
        }

        public bool CheckforaPCPforProvidedState(string stateCode)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var listState =
                    linqMetaData.PhysicianMaster.Where(
                        physicianMaster => physicianMaster.PracticeState.Trim() == stateCode).ToList();

                if (listState.Count > 0) return true;
            }
            return false;
        }

        public State GetStateByCityId(long cityId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var stateEntity =
                    linqMetaData.City.Join(linqMetaData.State, c => c.StateId, s => s.StateId, (c, s) => new { c, s }).
                        Where(@t => @t.c.CityId == cityId).Select(@t => @t.s).SingleOrDefault();
                return _mapper.Map(stateEntity);
            }
        }


        public bool CheckForPcPForProvidedState(string stateCode)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var listState =
                    linqMetaData.PhysicianMaster.Where(
                        physicianMaster => physicianMaster.PracticeState.Trim() == stateCode).ToList();

                if (listState.Count > 0) return true;
            }
            return false;
        }

        public State GetTerritoryStatesByOrganizationRoleUserId(long organizationRoleUserId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var state =
                    linqMetaData.Territory.Join(linqMetaData.TerritoryZip, t => t.TerritoryId, tz => tz.TerritoryId,
                                                (t, tz) => new { t, tz }).Join(linqMetaData.Zip, @t => @t.tz.ZipId,
                                                                             z => z.ZipId, (@t, z) => new { @t, z }).Join(
                        linqMetaData.City, @t => @t.z.CityId, c => c.CityId, (@t, c) => new { @t, c }).Join(
                        linqMetaData.State, @t => @t.c.StateId, s => s.StateId, (@t, s) => new { @t, s }).Join(
                        linqMetaData.OrganizationRoleUserTerritory, @t => @t.t.t.t.t.TerritoryId, o => o.TerritoryId,
                        (@t, o) => new { @t, o }).Where(
                        @a =>
                        @a.t.t.t.t.t.IsActive && @a.t.s.IsActive.Value && @a.t.t.c.IsActive && @a.t.t.t.z.IsActive &&
                        @a.o.OrganizationRoleUserId == organizationRoleUserId).OrderByDescending(@a => @a.o.TerritoryId)
                        .Select(@a => @a.t.s).FirstOrDefault();

                return _mapper.Map(state);
            }
        }

        public List<State> GetStateByCountryId(long countryId)
        {
            List<StateEntity> stateEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                stateEntities = linqMetaData.State.Where(s => s.IsActive == true && s.Country.CountryId == countryId).OrderBy(s => s.Name).ToList();
            }
            return _mapper.MapMultiple(stateEntities).ToList();
        }
    }
}
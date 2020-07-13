using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface IStateRepository
    {
        List<State> GetAllStates();
        List<State> GetStates(IEnumerable<long> stateIds);
        State GetState(long stateId);
        State GetStateByZip(long zipId);
        State GetStateByCityId(long cityId);
        State GetState(string stateName);
        State GetStatebyCode(string stateCode);
        bool CheckForPcPForProvidedState(string stateCode);
        State GetTerritoryStatesByOrganizationRoleUserId(long organizationRoleUserId);
        List<State> GetStateByCountryId(long countryId);
    }
}
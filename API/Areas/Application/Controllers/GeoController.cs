using System.Collections.Generic;
using System.Web.Http;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;

namespace API.Areas.Application.Controllers
{
    [AllowAnonymous]
    public class GeoController : ApiController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;

        public GeoController(ICountryRepository countryRepository, IStateRepository stateRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public List<Country> GetCountries()
        {
            return _countryRepository.GetAll();
        }

        [HttpGet]
        public List<State> GetStates()
        {
            return _stateRepository.GetAllStates();
        }
    }
}

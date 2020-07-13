using Falcon.App.Core.Application;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using FluentValidation;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class GeoRegistrarSection : IDependencyRegistrarSection 
    {
        public void RegisterDependencies()
        {

            //services
            IoC.Register<IAddressService, AddressService>();


            //validators
            IoC.Register<IValidator<Address>, AddressValidator>();
            IoC.Register<IValidator<AddressEditModel>, AddressEditModelValidator>();
            

            //factories
            IoC.Register<IAddressFactory, AddressFactory>();
            IoC.Register<ITerritoryFactory, TerritoryFactory>();

            //mappers
            IoC.Register<IMapper<Country, CountryEntity>, CountryMapper>();
            IoC.Register<IMapper<State, StateEntity>, StateMapper>();
            IoC.Register<IMapper<ZipCode, ZipEntity>, ZipCodeMapper>();
            IoC.Register<IMapper<City, CityEntity>, CityMapper>();


            //repos
            IoC.Register<IAddressRepository, AddressRepository>();
            IoC.Register<ICityRepository, CityRepository>();
            IoC.Register<ICountryRepository, CountryRepository>();
            IoC.Register<IStateRepository, StateRepository>();
            IoC.Register<IZipCodeRepository, ZipCodeRepository>();
            IoC.Register <ITerritoryRepository,TerritoryRepository>();



        }
    }
}
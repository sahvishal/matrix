using Falcon.App.Core.Application;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Impl;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Factories.Hosts;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories.Host;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Sales.Factories;
using Falcon.App.Infrastructure.Sales.Impl;
using Falcon.App.Infrastructure.Sales.Interfaces;
using Falcon.App.Infrastructure.Sales.Mappers;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;
using FluentValidation;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class SalesRegistrarSection : IDependencyRegistrarSection
    {
                
        public void RegisterDependencies()
        {
            //mappers
            IoC.Register<IMapper<ProspectCustomer, ProspectCustomerEntity>, ProspectCustomerMapper>();
            IoC.Register<IMapper<HospitalPartnerCustomer, HospitalPartnerCustomerEntity>, HospitalPartnerCustomerMapper>();
            IoC.Register<IMapper<Tag, TagEntity>, TagMapper>();

            //repos         
            IoC.Register<IHostRepository, HostRepository>();
            IoC.Register<IHospitalPartnerCustomerRepository, HospitalPartnerCustomerRepository>();
            IoC.Register<IHostFacilityRankingRepository, HostFacilityRankingRepository>();
            IoC.Register<IContactRepository, ContactRepository>();
            IoC.Register<ITagRepository, TagRepository>();
            IoC.Register<IProspectCustomerRepository, ProspectCustomerRepository>();
            IoC.Register<IUniqueItemRepository<ProspectCustomer>,ProspectCustomerRepository>();

            //factory
            IoC.Register<IHostFactory, HostFactory>();
            IoC.Register<IContactFactory,ContactFactory>();

            //validators
            IoC.Register<IValidator<HospitalPartnerCustomerListModelFilter>, HospitalPartnerCustomerListModelFilterValidator>();
            IoC.Register<IValidator<HospitalPartnerCustomerEditModel>, HospitalPartnerCustomerEditModelValidator>();

            //service
            IoC.Register<IHostFacilityRankingService, HostFacilityRankingService>();
            IoC.Register<IHostService, HostService>();
        }
    }
}
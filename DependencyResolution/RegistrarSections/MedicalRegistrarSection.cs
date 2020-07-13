using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Medical.Impl;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;
using FluentValidation;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class MedicalRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            //validators
            IoC.Register<IValidator<Package>, PackageValidator>();
            IoC.Register<IValidator<ResultArchiveUploadEditModel>, ResultArchiveUploadEditModelValidator>();
            IoC.Register<IValidator<EventScreeningAuthorizationEditModel>, EventScreeningAuthorizationEditModelValidator>();
            IoC.Register<IValidator<CustomerScreeningAuthorizationEditModel>, CustomerScreeningAuthorizationEditModelValidator>();
            IoC.Register<IValidator<CustomerEventCriticalTestDataEditModel>, CustomerEventCriticalTestDataEditModelValidator>();

            //mappers
            IoC.Register<IMapper<Test, TestEntity>, TestMapper>();

            //Factory
            IoC.Register<IEventCustomerPackageTestDetailService, EventCustomerPackageTestDetailService>();
            IoC.Register<IPhysicianEvaluationService, PhysicianEvaluationService>();

            //repos
            IoC.Register<ICustomerScreeningViewDataRepository, CustomerScreeningViewDataRepository>();
            IoC.Register<ITestRepository, TestRepository>();
            IoC.Register<IUniqueItemRepository<Test>, TestRepository>();
            IoC.Register<IPhysicianEvaluationRepository, PhysicianEvaluationRepository>();
            IoC.Register<IRepository<BasicBiometric>, BasicBiometricRepository>();
            IoC.Register<IScreeningAuthorizationRepository, ScreeningAuthorizationRepository>();
            IoC.Register<ICustomerCriticalDataRepository, CustomerCriticalDataRepository>();
            IoC.Register<IRepository<CustomerCriticalData>, CustomerCriticalDataRepository>();
            //service
            IoC.Register<ITestService, TestService>();
        }
    }
}
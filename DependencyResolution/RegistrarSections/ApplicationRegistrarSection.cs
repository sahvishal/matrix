using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Application.Repositories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using FluentValidation;
using Falcon.Data.EntityClasses;
using Falcon.App.Infrastructure.Mappers;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class ApplicationRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            //global/base.
            IoC.Register<ISettings, Settings>();
            IoC.Register<IPdfGenerator, PdfGenerator>();
            IoC.Register<IConfigurationSettingRepository, ConfigurationSettingRepository>();
            IoC.Register<ISystemInformationRepository, SystemInformationRepository>();
            IoC.Register<IAutoMapperBootstrapper, AutoMapperBootstrapper>();
            IoC.Register<IPersistenceLayer, SqlPersistenceLayer>();
            IoC.Register<IFileHelper, FileHelper>();

            //validators
            IoC.Register<IValidator<Name>, NameValidator>();
            IoC.Register<IValidator<PhoneNumber>, PhoneNumberValidator>();
            IoC.Register<IValidator<ZipSearchModel>, ZipSearchModelValidator>();
            IoC.Register<IValidator<File>, FileValidator>();

            //factories
            IoC.Register<IEmailFactory, EmailFactory>();
            IoC.Register<IPhoneNumberFactory, PhoneNumberFactory>();
            IoC.Register<ISystemInformationFactory, SystemInformationFactory>();


            //Mappers
            IoC.Register<IMapper<File, FileEntity>, FileMapper>();

            //repos            
            IoC.Register<IUniqueItemRepository<ProspectCustomer>, ProspectCustomerRepository>();
            IoC.Register<IUniqueItemRepository<File>, FileRepository>();
            //IoC.Register<IUniqueItemRepository<Media>, FileMediaRepository>();
            IoC.Register<IRepository<Notes>, NotesRepository>();

            IoC.Register<IBarCodeGenerator, BarCodeGenerator>();
            IoC.Register<IExcelReader, ExcelReader>();

            IoC.Register<IDigitalAssetAccessLogRepository, DigitalAssetAccessLogRepository>();

        }
    }
}
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.Data.EntityClasses;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class MarketingRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            IoC.Register<IClickConversionRepository, ClickConversionRepository>();



            //mappers
            IoC.Register<IMapper<HospitalPartner, HospitalPartnerEntity>, HospitalPartnerMapper>();
            IoC.Register<IMapper<Testimonial, TestimonialEntity>, TestimonialMapper>();
            IoC.Register<IMapper<SourceCode, CouponsEntity>, SourceCodeMapper>();
            IoC.Register<IMapper<Package, PackageEntity>, PackageMapper>();
            //repos
            IoC.Register<ITestimonialRepository, TestimonialRepository>();
            IoC.Register<IGiftCertificateTypeRepository, GiftCertificateTypeRepository>();
            IoC.Register<IGiftCertificateRepository, GiftCertificateRepository>();
            IoC.Register<IGiftCertificateTypeRepository, GiftCertificateTypeRepository>();
            IoC.Register<IHospitalPartnerRepository, HospitalPartnerRepository>();
            IoC.Register<ISourceCodeRepository, SourceCodeRepository>();
            
            IoC.Register<IPackageRepository, PackageRepository>();
            IoC.Register<IUniqueItemRepository<Package>, PackageRepository>();

            IoC.Register<IElectronicProductRepository,ElectronicProductRepository>();
        }
    }
}
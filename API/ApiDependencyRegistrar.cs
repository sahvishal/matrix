using API.Areas.Finance;
using API.Areas.Finance.Impl;
using API.Areas.Scheduling;
using API.Areas.Scheduling.Impl;
using API.Areas.Users;
using API.Areas.Users.Impl;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;

namespace API
{
    public class ApiDependencyRegistrar
    {
        public static void RegisterDepndencies()
        {
            IoC.Register<ISessionContext, SessionContext>();
            IoC.Register<ICustomerOrderBuilderService, CustomerOrderBuilderService>();
            IoC.Register<IUpdateCustomerPackageService, UpdateCustomerPackageService>();
            IoC.Register<ICustomerPaymentService, CustomerPaymentService>();
            IoC.Register<IGiftCertificateFactory, GiftCertificateFactory>();
            IoC.Register<IPatientProfileUpdateService, PatientProfileUpdateService>();
            IoC.Register<IEventCustomerBriefListService, EventCustomerBriefListService>();
            IoC.Register<IPatientShippingDetailFactory, PatientShippingDetailFactory>();
            IoC.Register<IOnSiteRegistrationService, OnSiteRegistrationService>();
            IoC.Register<IAppSessionContext, AppSessionContext>();
        }
    }
}
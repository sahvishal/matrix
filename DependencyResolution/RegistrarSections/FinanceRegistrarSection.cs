using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Infrastructure.Factories.Order;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Finance.Mappers;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;
using FluentValidation;
using Microsoft.Practices.Unity;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class FinanceRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            //Payment Gateway integration
            IoC.Register<IPaymentProcessor, AuthorizeNetCreditCardPaymentGateway>();
            IoC.Register<IPrePaymentRestriction, PrePaymentRestrictions>();
            
            //Repository
            IoC.Register<IElectronicProductRepository, ElectronicProductRepository>();
            IoC.Register<ICombinedPaymentInstrumentRepository, CombinedPaymentInstrumentRepository>(new InjectionConstructor(typeof(IPaymentInstrumentRepositoryListFactory), typeof(IKeyValueDictionaryFactory<PaymentType, Core.Finance.Interfaces.IPaymentInstrumentRepository>)));
            IoC.Register<IOrderController, OrderController>();
            IoC.Register<IOrderItemRepository, OrderItemRepository>();
            IoC.Register<IRepository<RefundRequest>, RefundRequestRepository>();
            IoC.Register<IInsurancePaymentRepository, InsurancePaymentRepository>();
            
            //Mappers
            IoC.Register<IMapper<Order, OrderEntity>, OrderMapper>();
            IoC.Register<IMapper<OrderDetail, OrderDetailEntity>, OrderDetailMapper>();
            IoC.Register<IMapper<SourceCodeOrderDetail, SourceCodeOrderDetailEntity>, SourceCodeOrderDetailMapper>();
            IoC.Register<IMapper<EventCustomerOrderDetail, EventCustomerOrderDetailEntity>, EventCustomerOrderDetailMapper>();
            IoC.Register<IMapper<ShippingDetailOrderDetail, ShippingDetailOrderDetailEntity>, ShippingDetailOrderDetailMapper>();
            IoC.Register<IMapper<InsurancePayment, InsurancePaymentEntity>, InsurancePaymentMapper>();

            //Factory
            IoC.Register<IOrderFactory, OrderFactory>();
            IoC.Register<IOrderItemTraitsFactory, OrderItemTraitsFactory>();
            IoC.Register<IOrderDetailFactory, OrderDetailFactory>();
            
            

            //Validators
            IoC.Register<IValidator<DetailOpenOrderModelFilter>, DetailOpenOrderModelFilterValidator>();
            IoC.Register<IValidator<DailyRecapModelFilter>,DailyRecapModelFilterValidator>();

            //Service
            IoC.Register<IFinanceReportingService, FinanceReportingService>();
            IoC.Register<IOrderSynchronizationService, OrderSynchronizationService>();
            
            

        }
    }
}
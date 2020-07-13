using Falcon.App.Core.Application;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Factories.Events;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.Events;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Scheduling.Facotries;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Mappers;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Scheduling.Services;
using Falcon.App.Infrastructure.Service;
using Falcon.Data.EntityClasses;
using FluentValidation;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class SchedulingRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            
            //services
            IoC.Register<IEventPackageSelectorService, EventPackageSelectorService>();
            IoC.Register<IEventService, EventService>();
            IoC.Register<IEventAppointmentService, EventAppointmentService>();
            IoC.Register<ICustomerRegistrationService, CustomerRegistrationService>();
            

            //Repository
            IoC.Register<IEventCustomerRepository, EventCustomerRepository>();
            IoC.Register<IEventCustomerRegistrationViewDataRepository, EventCustomerRegistrationViewDataRepository>();
            IoC.Register<IAppointmentRepository, AppointmentRepository>();
            IoC.Register<IUniqueItemRepository<Event>, EventRepository>();
            IoC.Register<IUniqueItemRepository<Appointment>, AppointmentRepository>();
            IoC.Register<IEventAppointmentAggregateRepository, EventAppointmentAggregateRepository>();
            IoC.Register<IUniqueItemRepository<CustomerCallNotes>, CustomerCallNotesRepository>();
            IoC.Register<IEventPackageRepository, EventPackageRepository>();
            IoC.Register<IUniqueItemRepository<EventCustomer>, EventCustomerRepository>();
            IoC.Register<IEventTestRepository, EventTestRepository>();

            //validators
            IoC.Register<IValidator<CustomerUpsellListModelFilter>, CustomerUpsellListModelFilterValidator>();
            IoC.Register<IValidator<EventVolumeListModelFilter>, EventVoulmeListModelFilterValidator>();
            IoC.Register<IValidator<CustomerScheduleModelFilter>, CustomerScheduleModelFilterValidator>();
            IoC.Register<IValidator<NoShowCustomerModelFilter>, NoShowCustomerModelFilterValidator>();
            IoC.Register<IValidator<AppointmentsBookedListModelFilter>, AppointmentsBookedListModelFilterValidator>();
            IoC.Register<IValidator<MassRegistrationEditModel>, MassRegistrationEditModelValidator>();
            IoC.Register<IValidator<MassRegistrationListModel>,MassRegistrationListModelValidator>();
            IoC.Register<IValidator<CancelledCustomerModelFilter>, CancelledCustomerModelFilterValidator>();
            
            //mappers
            IoC.Register<IMapper<Event, EventsEntity>, EventMapper>();
            IoC.Register<IMapper<Appointment, EventAppointmentEntity>, AppointmentMapper>();
            IoC.Register<IMapper<CustomerCallNotes, CustomerRegistrationNotesEntity>, CustomerCallNotesMapper>();
            IoC.Register<IMapper<EventPackage, EventPackageDetailsEntity>, EventPackageMapper>();
            IoC.Register<IMapper<EventTest, EventTestEntity>, EventTestMapper>();

            //Factory
            IoC.Register<IEventCustomerRegistrationViewDataFactory, EventCustomerRegistrationViewDataFactory>();
            IoC.Register<IEventCustomerViewDataFactory, EventCustomerViewDataFactory>();
            IoC.Register<IEventAppointmentBasicInfoModelFactory, EventAppointmentBasicInfoModelFactory>();
            IoC.Register<IMassRegistrationEditModelFactory, MassRegistrationEditModelFactory>();
            
            
            
        }
    }
}
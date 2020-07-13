using Falcon.App.Core.Application;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Impl;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Operations.Mappers;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.Data.EntityClasses;
using FluentValidation;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class OperationsRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {

            //services
            IoC.Register<IEventStaffAssignmentService, EventStaffAssignmentService>();
            IoC.Register<IPhysicianAssignmentService, PhysicianAssignmentService>();
                        
            //repos
            IoC.Register<IVanRepository, VanRepository>();
            IoC.Register<IShippingOptionRepository, ShippingOptionRepository>();
            IoC.Register<IShippingDetailRepository, ShippingDetailRepository>();
            IoC.Register<IPodRepository, PodRepository>();
            IoC.Register<IUniqueItemRepository<Pod>, PodRepository>();
            IoC.Register<IUniqueItemRepository<PodStaff>, PodStaffAssignmentRepository>();
            IoC.Register<IMapper<PodStaff, PodDefaultTeamEntity>, PodTeamAssignmentMapper>();
            IoC.Register<IMapper<StaffEventRole, StaffEventRoleEntity>, EventRoleMapper>();
            IoC.Register<IUniqueItemRepository<StaffEventRole>, EventRoleRepository>();
            IoC.Register<IUniqueItemRepository<ShippingDetail>, ShippingDetailRepository>();
            IoC.Register<IUniqueItemRepository<ShippingOption>, ShippingOptionRepository>();

            IoC.Register<IRepository<EventStaffAssignment>, EventStaffAssignmentRepository>();
            IoC.Register<IEventStaffAssignmentRepository, EventStaffAssignmentRepository>();
            IoC.Register<IPhysicianEventAssignmentRepository, PhysicianEventAssignmentRepository>();
            IoC.Register<IPhysicianCustomerAssignmentRepository, PhysicianCustomerAssignmentRepository>();
            IoC.Register<ICdContentGeneratorTrackingRepository, CdContentGeneratorTrackingRepository>();
            

            //validators
            IoC.Register<IValidator<PodEditModel>, PodEditModelValidator>();
            IoC.Register<IValidator<PodStaffEditModel>, PodStaffModelValidator>();
            IoC.Register<IValidator<StaffEventRoleEditModel>, StaffEventRoleEditModelValidator>();
            IoC.Register<IValidator<Van>, VanValidator>();
            IoC.Register<IValidator<VanEditModel>, VanEditModelValidator>();
            IoC.Register<IValidator<EventStaffAssignmentListModelFilter>,EventStaffAssignmentListModelFilterValidator>();
            IoC.Register<IValidator<EventStaffAssignment>, EventStaffAssignmentValidator>();
            IoC.Register<IValidator<EventStaffBasicInfoModel>, EventStaffBasicInfoModelValidator>();
            IoC.Register<IValidator<PhysicianEventAssignmentEditModel>,PhysicianEventAssignmentEditModelValidator>();
            IoC.Register<IValidator<PhysicianCustomerAssignmentEditModel>, PhysicianCustomerAssignmentEditModelValidator>();
            IoC.Register<IValidator<AssignedPhysicianBasicInfoModel>, AssignedPhysicianBasicInfoModelValidator>();

            //mapper
            IoC.Register<IMapper<PhysicianEventAssignment, PhysicianEventAssignmentEntity>,PhysicianEventAssignmentMapper>();
            IoC.Register<IMapper<PhysicianCustomerAssignment, PhysicianCustomerAssignmentEntity>, PhysicianCustomerAssignmentMapper>();
            IoC.Register<IMapper<CdContentGeneratorTracking, CdcontentGeneratorTrackingEntity>, CdContentGeneratorTrackingMapper>();

            IoC.Register<IShippingController, ShippingController>();

        }
    }
}
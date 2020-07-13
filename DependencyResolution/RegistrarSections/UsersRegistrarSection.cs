using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Impl;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Infrastructure.Users.Factories;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.Infrastructure.Users.Mappers;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.Infrastructure.Users.Services;
using Falcon.Data.EntityClasses;
using FluentValidation;

namespace Falcon.App.DependencyResolution.RegistrarSections
{
    public class UsersRegistrarSection : IDependencyRegistrarSection
    {
        public void RegisterDependencies()
        {
            IoC.Register<IOrgRoleUserModelBinder, OrgRoleUserModelBinder>();            

            //services
            IoC.Register<IOrganizationService, OrganizationService>();
            IoC.Register<IUserService, UserService>();
            IoC.Register<IUserLoginService, UserLoginService>();
            IoC.Register<ICustomerService, CustomerService>();

            //validators
            IoC.Register<IValidator<OrganizationRoleUserModel>, OrganizationRoleUserModelValidator>();
            IoC.Register<IValidator<UserEditModel>, UserEditModelValidator>();
            IoC.Register<IValidator<ProfileEditModel>, ProfileEditModelValidator>();
            IoC.Register<IValidator<UserListModelFilter>, UserListModelFilterValidator>();
            IoC.Register<IMapper<CorporateAccount, AccountEntity>, CorporateAccountMapper>();
            IoC.Register<IValidator<OrganizationEditModel>, OrganizationEditModelValidator>();
            IoC.Register<IValidator<CorporateAccountEditModel>, CorporateAccountEditModelValidator>();
            IoC.Register<IValidator<CorporateAccountListModelFilter>, CorporateAccountListModelFilterValidator>();
            IoC.Register<IValidator<UserLoginModel>, UserLoginModelValidator>();
            IoC.Register<IValidator<MedicalVendorEditModel>,MedicalVendorEditModelValidator>();
            IoC.Register<IValidator<MedicalVendorListModelFilter>, MedicalVendorListModelFilterValidator>();
            IoC.Register<IValidator<PhysicianModel>, PhysicianModelValidator>();
            //factories
            IoC.Register<IUserFactory<User>, UserFactory<User>>();
            IoC.Register<IUserFactory<Customer>, UserFactory<Customer>>();
            IoC.Register<IUserLoginFactory, UserLoginFactory>();
            IoC.Register<ICustomerFactory, CustomerFactory>();
            IoC.Register<IUserFactory<CallCenterRep>, UserFactory<CallCenterRep>>();
            IoC.Register<IUserSessionModelFactory,UserSessionModelFactory>();
            IoC.Register<IOrganizationRoleUserModelFactory, OrganizationRoleUserModelFactory>();
            IoC.Register<ICustomerFactory, CustomerFactory>();
            IoC.Register<ITechnicianFactory, TechnicianFactory>();
            IoC.Register<IUserFactory<Technician>, UserFactory<Technician>>();
            IoC.Register<IMedicalVendorFactory, MedicalVendorFactory>();
            IoC.Register<IPhysicianFactory, PhysicianFactory>();
            IoC.Register<IUserFactory<Physician>, UserFactory<Physician>>();
            IoC.Register<IPhysicianLicenseModelFactory, PhysicianLicenseModelFactory>();
            IoC.Register<IUserFactory<AccountCoordinatorProfile>, UserFactory<AccountCoordinatorProfile>>();
            //mapppers
            IoC.Register<IMapper<Organization, OrganizationEntity>, OrganizationMapper>();
            IoC.Register<IMapper<OrganizationRoleUser, OrganizationRoleUserEntity>, OrganizationRoleUserMapper>();
            IoC.Register<IMapper<PhysicianLicense, PhysicianLicenseEntity>,PhysicianLicenseMapper>();
            IoC.Register<IMapper<PhysicianLabTest, PhysicianLabTestEntity>, PhysicianLabTestMapper>();

            //repos
            IoC.Register<IRoleRepository, RoleRepository>();
            IoC.Register<IUserRepository<User>, UserRepository<User>>();
            IoC.Register<IUserLoginRepository, UserLoginRepository>();
            IoC.Register<ICustomerRepository, CustomerRepository>();
            IoC.Register<IOrganizationRepository, OrganizationRepository>();
            IoC.Register<IMedicalVendorRepository, MedicalVendorRepository>();
            IoC.Register<IOrganizationRoleUserRepository, OrganizationRoleUserRepository>();
            IoC.Register<IUserRepository<Customer>, UserRepository<Customer>>();
            IoC.Register<IUserRepository<CallCenterRep>, UserRepository<CallCenterRep>>();
            IoC.Register<IUserListModelFactory, UserListModelFactory>();
            IoC.Register<IUsersListModelRepository, UserListModelRepository>();
            IoC.Register<IPhysicianRepository, PhysicianRepository>();
            IoC.Register<ICustomerRepository, CustomerRepository>();
            IoC.Register<ICorporateAccountRepository, CorporateAccountRepository>();
            IoC.Register<IUniqueItemRepository<UserLoginLog>, UserLoginLogRepository>();
            IoC.Register<IRepository<Technician>,TechnicianRepository>();
            IoC.Register<ITechnicianRepository, TechnicianRepository>();
            IoC.Register<IUserRepository<Technician>, UserRepository<Technician>>();
            IoC.Register<IUserRepository<AccountCoordinatorProfile>, UserRepository<AccountCoordinatorProfile>>();
            IoC.Register<IUserRepository<Physician>, UserRepository<Physician>>();
            IoC.Register<IPhysicianRepository, PhysicianRepository>();
            IoC.Register<IUniqueItemRepository<CorporateAccount>, CorporateAccountRepository>();
        }
    }
}
using System;
using System.Linq;
using API.Areas.Scheduling.Models;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Users;

namespace API.Areas.Scheduling.Impl
{
    public class PatientShippingDetailFactory : IPatientShippingDetailFactory
    {
        private readonly ICustomerRepository _customerRepository;


        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly long _creatorOrganizationRoleUser;

        public PatientShippingDetailFactory(ISessionContext sessionContext, ICustomerRepository customerRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _customerRepository = customerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _creatorOrganizationRoleUser = sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        }

        private Address GetShippinAddress(CustomerOrderDetail customerOrderDetail)
        {

            var customer = _customerRepository.GetCustomer(customerOrderDetail.CustomerId);
            var shippingAddress = customer.Address;

            if (customerOrderDetail.ShippingAddresss != null)
            {
                shippingAddress = Mapper.Map<AddressEditModel, Address>(customerOrderDetail.ShippingAddresss);
            }
            //Create new address for shipping
            shippingAddress.Id = 0;
            return shippingAddress;
        }

        public ShippingDetail GetShippingDetailData(CustomerOrderDetail customerOrderDetail)
        {
            var option = customerOrderDetail.ShippingOptions.FirstOrDefault();
            if (option == null) return null;

            var shippingDetail = new ShippingDetail
            {
                ShippingOption = new ShippingOption(option.Id),
                DataRecorderMetaData =
                    new DataRecorderMetaData
                    {
                        DataRecorderCreator = _organizationRoleUserRepository.GetOrganizationRoleUser(_creatorOrganizationRoleUser),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                Status = ShipmentStatus.Processing,
                ShippingAddress = GetShippinAddress(customerOrderDetail),
                ActualPrice = option.Price
            };

            return shippingDetail;
        }
    }
}
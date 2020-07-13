using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Users.Repositories;

namespace Falcon.App.Infrastructure.Factories.Order
{
    public class OrderViewDataFactory : IOrderViewDataFactory
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IRoleRepository _roleRepository;

        public OrderViewDataFactory(IUserRepository<User> userRepository, IEventTestRepository testRepository, 
            IEventPackageRepository packageRepository, ICustomerRepository customerRepository, 
            IOrganizationRoleUserRepository organizationRoleUserRepository,
            IShippingDetailRepository shippingDetailRepository, IElectronicProductRepository electronicProductRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _eventTestRepository = testRepository;
            _eventPackageRepository = packageRepository;
            _customerRepository = customerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _electronicProductRepository = electronicProductRepository;
            _roleRepository = roleRepository;
        }

        public OrderViewDataFactory()
            : this(new UserRepository<User>(), new EventTestRepository(), new EventPackageRepository(), 
            new CustomerRepository(), new OrganizationRoleUserRepository(), new ShippingDetailRepository(), new ElectronicProductRepository(), new RoleRepository())
        { }


        public OrderViewData Create(OrderDetail orderDetail)
        {
            var orderDetailOrganizationRoleUserCreator = GetOrganizationRoleUser(orderDetail,
                                                                        od =>
                                                                        od.DataRecorderMetaData.DataRecorderCreator.Id);

            var orderDetailOrganizationRoleUserFor = GetOrganizationRoleUser(orderDetail,
                                                                             od => od.ForOrganizationRoleUserId);

            var description = orderDetail.Description;
            if (orderDetail.DetailType == OrderItemType.EventPackageItem)
            {
                var package = _eventPackageRepository.GetById(orderDetail.OrderItem.ItemId);
                description = package == null ? "" : package.Package.Name;
            }
            else if (orderDetail.DetailType == OrderItemType.EventTestItem)
            {
                var eventTest = _eventTestRepository.GetbyId(orderDetail.OrderItem.ItemId);
                description = eventTest == null ? "" : eventTest.Test.Name;
            }

            else if (orderDetail.DetailType == OrderItemType.ProductItem)
                description = _electronicProductRepository.GetElectronicProductNameForOrder(orderDetail.OrderItemId);
            var customer = _customerRepository.GetCustomerByUserId(orderDetailOrganizationRoleUserFor.FirstValue.UserId);

            //var creatorRoleName =
            //    ((Roles)orderDetailOrganizationRoleUserCreator.FirstValue.RoleId).ToString();

            var orderDetailDateCreated = orderDetail.DataRecorderMetaData != null
                                             ? orderDetail.DataRecorderMetaData.DateCreated.ToString("MMM dd yyyy")
                                             : null;

            var eventCustomerId = (orderDetail.DetailType == OrderItemType.EventPackageItem ||
                                   orderDetail.DetailType == OrderItemType.EventTestItem) &&
                                  orderDetail.EventCustomerOrderDetail != null
                                      ? orderDetail.EventCustomerOrderDetail.EventCustomerId
                                      : 0;

            var orderViewData = new OrderViewData
                                    {
                                        CreationMode = orderDetailOrganizationRoleUserCreator.SecondValue.SecondValue,
                                        CreatorName = orderDetailOrganizationRoleUserCreator.SecondValue.FirstValue,
                                        CreatorRole = orderDetailOrganizationRoleUserCreator.SecondValue.SecondValue,
                                        CustomerId = customer.CustomerId,
                                        CustomerName = customer.NameAsString,
                                        Description = description,
                                        EventCustomerId = eventCustomerId,
                                        OrderDetailDateCreated = orderDetailDateCreated,
                                        OrderDetailStatus = orderDetail.OrderItemStatus.Name,
                                        OrderDetailType = orderDetail.OrderItemStatus.ItemTypeName,
                                        Price = orderDetail.Price,
                                        Quantity = orderDetail.Quantity,
                                        ShippingDetails = GetShippingDetailUserPair(orderDetail.Id).ToList()
                                    };

            if ((orderDetail.DetailType == OrderItemType.EventPackageItem || orderDetail.DetailType == OrderItemType.EventTestItem) && orderDetail.SourceCodeOrderDetail != null)
                orderViewData.SourceCode = GetSourceCodeUserPair(orderDetail.SourceCodeOrderDetail);

            return orderViewData;
        }

        public OrderViewData Create(long orderDetailId)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ShippingDetailViewData> GetShippingDetailUserPair(long orderDetailId)
        {
            var shippingDetailViewDatas = new List<ShippingDetailViewData>();
            var shippingDetails = _shippingDetailRepository.GetCancelledShippingDetailsForOrder(orderDetailId);

            foreach (var shippingDetail in shippingDetails)
            {
                ShippingDetail detail = shippingDetail;
                var organizationRoleUserCreator = GetOrganizationRoleUser(detail,
                                                                          sd => sd.DataRecorderMetaData.DataRecorderCreator.Id);

                // Add a new entry for the cancelled status.
                if (detail.Status == ShipmentStatus.Cancelled && organizationRoleUserCreator != null)
                {
                    var shippingDetailViewData = GetShippingDetailViewData(detail, organizationRoleUserCreator);
                    shippingDetailViewData.Status = ShipmentStatus.Processing.ToString();

                    shippingDetailViewDatas.Add(shippingDetailViewData);
                }

                if (organizationRoleUserCreator != null)
                {
                    var shippingDetailViewData = GetShippingDetailViewData(detail, organizationRoleUserCreator);
                    shippingDetailViewData.Status = detail.Status.ToString();
                    shippingDetailViewDatas.Add(shippingDetailViewData);
                }
            }
            return shippingDetailViewDatas;
        }

        private ShippingDetailViewData GetShippingDetailViewData(ShippingDetail detail, OrderedPair<OrganizationRoleUser, OrderedPair<string, string>> organizationRoleUserCreator)
        {
            return new ShippingDetailViewData
                       {
                           AppliedByName = organizationRoleUserCreator.SecondValue.FirstValue,
                           AppliedByRole =organizationRoleUserCreator.SecondValue.SecondValue,
                           AppliedDate =
                               detail.DataRecorderMetaData.DateCreated.ToString(
                               "MMM dd yyyy"),
                           Price = detail.ActualPrice,
                           ShippingDetailId = detail.Id,
                           ShippingOptionName =
                               detail.ShippingOption.Name
                       };
        }

        private SourceCodeViewData GetSourceCodeUserPair(SourceCodeOrderDetail sourceCodeOrderDetail)
        {
            if (sourceCodeOrderDetail == null) return null;
            var organizationRoleUserCreator = GetOrganizationRoleUser(sourceCodeOrderDetail,
                                                                      scod => scod.OrganizationRoleUserCreatorId);

            ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();

            var sourceCode = sourceCodeRepository.GetSourceCodeById(sourceCodeOrderDetail.SourceCodeId);
            if (sourceCode != null && organizationRoleUserCreator != null && organizationRoleUserCreator.FirstValue != null)
            {
                sourceCode.CouponValue = sourceCodeOrderDetail.Amount;
                sourceCode.DataRecorderMetaData = new DataRecorderMetaData() { DateCreated = sourceCodeOrderDetail.DateCreated };
                sourceCode.CouponDescription = ((Roles)organizationRoleUserCreator.FirstValue.RoleId).ToString();

                return new SourceCodeViewData
                           {
                               Amount = sourceCodeOrderDetail.Amount,
                               AppliedByName = organizationRoleUserCreator.SecondValue.FirstValue,
                               AppliedByRole = organizationRoleUserCreator.SecondValue.SecondValue,
                               AppliedDate =
                                   sourceCodeOrderDetail.DateCreated.ToString(
                                   "MMM dd yyyy"),
                               SourceCode = sourceCode.CouponCode,
                               SourceCodeId = sourceCode.Id
                           };
            }
            return null;
        }

        private OrderedPair<OrganizationRoleUser, OrderedPair<string, string>> GetOrganizationRoleUser<T>(T data, Func<T, long> organizationRoleUserId)
        {
            var organizationRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId(data));
            var user = _userRepository.GetUser(organizationRoleUser.UserId);
            var role = _roleRepository.GetByRoleId(organizationRoleUser.RoleId);
            return new OrderedPair<OrganizationRoleUser, OrderedPair<string, string>>(organizationRoleUser, new OrderedPair<string, string>(user.NameAsString,role.DisplayName));
        }

    }
}
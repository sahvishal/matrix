using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.Hosts;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Hosts
{
    public class HostPaymentFactory : IHostPaymentFactory
    {
        private readonly DomainEntityMapper<HostPaymentTransaction, HostPaymentTransactionEntity> _mapper;
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private readonly IAddressFactory _addressFactory;

        public HostPaymentFactory()
            : this(new DataRecorderMetaDataFactory(), new AddressFactory(), new HostPaymentTransactionMapper())
        { }
        public HostPaymentFactory(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory, IAddressFactory addressFactory, DomainEntityMapper<HostPaymentTransaction, HostPaymentTransactionEntity> mapper)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
            _addressFactory = addressFactory;
            _mapper = mapper;
        }

        public HostPaymentEntity CreateHostPaymentEntity(HostPayment hostPayment)
        {
            return new HostPaymentEntity(hostPayment.Id)
            {
                HostId = hostPayment.HostId,
                Amount = hostPayment.Amount,
                PaymentMode = (long)hostPayment.PaymentMode,
                PayableTo = hostPayment.PayableTo,
                MailingAttentionOf = hostPayment.MailingAttentionOf,
                MailingOrganizationName = hostPayment.MailingOrganizationName,
                DueDate = hostPayment.DueDate,
                Status = (long)hostPayment.Status,
                DateCreated = hostPayment.CreatedDate,
                EventId = hostPayment.EventId,
                IsDeposit = false,
                MailingAddressId = hostPayment.PaymentMailingAddress.Id,
                CreatorOrganizationRoleUserId = hostPayment.PaymentRecordedBy.Id,
                IsActive = hostPayment.IsActive,
                IsNew = hostPayment.Id == 0
            };
        }

        public HostPayment CreateHostPayment(HostPaymentEntity hostPaymentEntity, Address address)
        {
            return new HostPayment(hostPaymentEntity.HostPaymentId)
            {
                HostId = hostPaymentEntity.HostId,
                Amount = hostPaymentEntity.Amount,
                PaymentMode = (HostPaymentType)hostPaymentEntity.PaymentMode,
                PayableTo = hostPaymentEntity.PayableTo,
                MailingAttentionOf = hostPaymentEntity.MailingAttentionOf,
                MailingOrganizationName = hostPaymentEntity.MailingOrganizationName,
                DueDate = hostPaymentEntity.DueDate,
                Status = (HostPaymentStatus)hostPaymentEntity.Status,
                CreatedDate = hostPaymentEntity.DateCreated,
                EventId = hostPaymentEntity.EventId,
                PaymentMailingAddress = address,
                PaymentRecordedBy =
                    hostPaymentEntity.CreatorOrganizationRoleUserId != null
                        ? new OrganizationRoleUser(hostPaymentEntity.CreatorOrganizationRoleUserId.Value)
                        : null,
                IsActive = hostPaymentEntity.IsActive,
                HostPaymentTransactions =
                    _mapper.MapMultiple(hostPaymentEntity.HostPaymentTransaction).ToList()

            };
        }

        public void CreateHostDeposit(HostPaymentEntity hostPaymentEntity, HostPayment hostPayment, Address address)
        {
            hostPayment.Id = hostPaymentEntity.HostPaymentId;
            hostPayment.HostId = hostPaymentEntity.HostId;
            hostPayment.Amount = hostPaymentEntity.Amount;
            hostPayment.CreatedDate = hostPaymentEntity.DateCreated;
            hostPayment.DueDate = hostPaymentEntity.DueDate;
            hostPayment.EventId = hostPaymentEntity.EventId;

            hostPayment.MailingAttentionOf = hostPaymentEntity.MailingAttentionOf;
            hostPayment.MailingOrganizationName = hostPaymentEntity.MailingOrganizationName;
            hostPayment.PaymentMode = (HostPaymentType)hostPaymentEntity.PaymentMode;
            hostPayment.Status = (HostPaymentStatus)hostPaymentEntity.Status;
            hostPayment.PayableTo = hostPaymentEntity.PayableTo;
            hostPayment.PaymentMailingAddress = address;
            hostPayment.PaymentRecordedBy =
                hostPaymentEntity.CreatorOrganizationRoleUserId != null
                    ? new OrganizationRoleUser(hostPaymentEntity.CreatorOrganizationRoleUserId.Value)
                    : null;
            hostPayment.IsActive = hostPaymentEntity.IsActive;
            hostPayment.HostPaymentTransactions =
                _mapper.MapMultiple(hostPaymentEntity.HostPaymentTransaction).ToList();
        }
    }
}
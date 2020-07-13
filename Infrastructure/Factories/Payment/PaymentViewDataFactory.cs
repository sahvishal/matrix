using System;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;

namespace Falcon.App.Infrastructure.Factories.Payment
{
    public class PaymentViewDataFactory : IPaymentViewDataFactory
    {
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IUserRepository<User> _userRepository;

        public PaymentViewDataFactory(IUserRepository<User> userRepository, IChargeCardRepository chargeCardRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _userRepository = userRepository;
            _chargeCardRepository = chargeCardRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public PaymentViewDataFactory()
            : this(new UserRepository<User>(), new ChargeCardRepository(), new OrganizationRoleUserRepository())
        { }

        public PaymentViewData Create(PaymentInstrument paymentInstrument)
        {
            var orderDetailOrganizationRoleUserCreator = GetOrganizationRoleUser(paymentInstrument,
                                                                                 pi => pi.DataRecorderMetaData.DataRecorderCreator.Id);

            var creatorRoleName =
                ((Roles)orderDetailOrganizationRoleUserCreator.FirstValue.RoleId).ToString();

            var orderDetailDateCreated = paymentInstrument.DataRecorderMetaData != null
                                             ? paymentInstrument.DataRecorderMetaData.DateCreated.ToString("MMM dd yyyy  @ hh:mm tt CST")
                                             : null;

            var paymentViewData = new PaymentViewData
                                      {
                                          CreatorRoleName = creatorRoleName,
                                          CreationMode = creatorRoleName,
                                          CreatorUserName = orderDetailOrganizationRoleUserCreator.SecondValue,
                                          DateCreated = orderDetailDateCreated,
                                          PaymentInstrumentName = paymentInstrument.PaymentType.ToString(),
                                          Amount = paymentInstrument.Amount
                                      };

            return GetPaymentInstrumentInformation(paymentInstrument, paymentViewData);
        }

        public PaymentViewData Create(long paymentId)
        {
            throw new NotImplementedException();
        }

        private OrderedPair<OrganizationRoleUser, string> GetOrganizationRoleUser<T>(T data, Func<T, long> organizationRoleUserId)
        {
            var organizationRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId(data));
            var user = _userRepository.GetUser(organizationRoleUser.UserId);
            return new OrderedPair<OrganizationRoleUser, string>(organizationRoleUser, user.NameAsString);
        }

        private PaymentViewData GetPaymentInstrumentInformation(PaymentInstrument paymentInstrument, PaymentViewData paymentViewData)
        {
            if (paymentInstrument is CheckPayment)
            {
                var checkPayment = paymentInstrument as CheckPayment;
                paymentViewData.InstrumentNumber = checkPayment.Check.CheckNumber;
            }
            else if (paymentInstrument is ECheckPayment)
            {
                var eCheckPayment = paymentInstrument as ECheckPayment;
                var processorResponse = eCheckPayment.ProcessorResponse.Split('|');
                paymentViewData.ProcessorResponse = processorResponse.Length >= 6
                                                        ? processorResponse.GetValue(6).ToString()
                                                        : "-N/A-";
                paymentViewData.InstrumentNumber = eCheckPayment.ECheck.CheckNumber;
            }
            else if (paymentInstrument is ChargeCardPayment)
            {
                var chargeCardPayment = paymentInstrument as ChargeCardPayment;

                paymentViewData.ProcessorResponse = "-N/A-";
                if(ProcessorResponse.IsValidResponseString(chargeCardPayment.ProcessorResponse))
                {
                    paymentViewData.ProcessorResponse =
                        new ProcessorResponse(chargeCardPayment.ProcessorResponse).TransactionCode;
                }

                var chargeCard = _chargeCardRepository.GetById(chargeCardPayment.ChargeCardId);
                if (chargeCard != null)
                {
                    paymentViewData.InstrumentDate = chargeCard.ExpirationDate.ToString("MM/yyyy");
                    paymentViewData.InstrumentNumber = chargeCard.Number.Length > 3 ? chargeCard.TypeId + " - ends with " + chargeCard.Number.Substring(
                        chargeCard.Number.Length - 4, 4) : chargeCard.Number;
                }
            }
            else if (paymentInstrument is InsurancePayment)
            {
                var insurancePayment = paymentInstrument as InsurancePayment;

                if(insurancePayment.AmountToBePaid > insurancePayment.Amount)
                    paymentViewData.ProcessorResponse = "Amount: $" + insurancePayment.AmountToBePaid.ToString("0.00") + ", Status: Pending for settlement";
                else
                    paymentViewData.ProcessorResponse = "Amount: $" + insurancePayment.AmountToBePaid.ToString("0.00") + ", Status: Payment settled";
            }
            return paymentViewData;
        }
    }
}
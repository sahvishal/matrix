using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class PaymentController : IPaymentController
    {
        readonly IPaymentRepository _paymentRepository;
        readonly ICombinedPaymentInstrumentRepository _combinedPaymentInstrumentRepository;
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IChargeCardService _chargeCardService;
        private readonly IECheckService _checkService;
        private readonly IChargeCardPaymentRepository _chargeCardPaymentRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly bool _isEccEnabled;

        public PaymentController(IPaymentRepository paymentRepository, ICombinedPaymentInstrumentRepository combinedPaymentInstrumentRepository, IChargeCardPaymentRepository chargeCardPaymentRepository,
            IDataRecorderMetaDataFactory dataRecorderMetaDataFactory, IChargeCardRepository chargeCardRepository, IChargeCardService chargeCardService, IECheckService eCheckService, ISettings settings, ICustomerRepository customerRepository)
        {
            _paymentRepository = paymentRepository;
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
            _combinedPaymentInstrumentRepository = combinedPaymentInstrumentRepository;
            _chargeCardService = chargeCardService;
            _chargeCardRepository = chargeCardRepository;
            _chargeCardPaymentRepository = chargeCardPaymentRepository;
            _checkService = eCheckService;
            _isEccEnabled = settings.IsEccEnabled;
            _customerRepository = customerRepository;
        }

        public long SavePayment(PaymentInstrument paymentInstrument, string notes,
            long dataRecorderCreatorId)
        {
            return SavePayment(new List<PaymentInstrument> { paymentInstrument }, notes,
                dataRecorderCreatorId);
        }

        public long SavePayment(IEnumerable<PaymentInstrument> paymentInstruments, string notes,
            long dataRecorderCreatorId)
        {
            if (paymentInstruments == null || !paymentInstruments.Any() ||
                paymentInstruments.Contains(null))
            {
                throw new InvalidOperationException("The payment must include at least one payment instrument, and may not contain null payment instruments");
            }

            var payment = new Payment
            {
                Notes = notes,
                DataRecorderMetaData = _dataRecorderMetaDataFactory.
                    CreateDataRecorderMetaData(dataRecorderCreatorId, DateTime.Now)
            };

            using (var scope = new TransactionScope())
            {
                payment = _paymentRepository.Save(payment);
                foreach (var paymentInstrument in paymentInstruments)
                {
                    paymentInstrument.PaymentId = payment.Id;
                }
                _combinedPaymentInstrumentRepository.SavePaymentInstruments(paymentInstruments);
                scope.Complete();
            }
            return payment.Id;
        }

        public void ManagePayment(PaymentEditModel paymentEditModel, long customerId, string ipAddress, string uniquePaymentReference)
        {
            if (paymentEditModel.Payments == null || paymentEditModel.Payments.Count() < 1)
                return;
            var customer = _customerRepository.GetCustomer(customerId);
            var payments = paymentEditModel.Payments.Where(p => p.Amount != 0);

            int index = 1;
            try
            {
                foreach (var payment in payments)
                {
                    if (payment.PaymentType == PaymentType.ElectronicCheck.PersistenceLayerId && paymentEditModel.PaymentFlow == PaymentFlow.In)
                    {
                        var response = _checkService.ChargefromECheck(payment.ECheck.ECheck,
                                                       Mapper.Map<AddressEditModel, Address>(
                                                           paymentEditModel.ExistingBillingAddress), customer, ipAddress,
                                                       uniquePaymentReference);


                        if (response.ProcessorResult != ProcessorResponseResult.Accepted)
                        {
                            new NLogLogManager().GetLogger<PaymentController>().Info("ECheck Transaction - Details [RawResponse: " + response.RawResponse + "]");
                            throw new Exception("Transaction Failed!");
                        }

                        payment.IsProcessed = true;
                        payment.ECheck.ECheckPayment.ProcessorResponse = response.RawResponse;
                    }
                    else if ((payment.PaymentType == PaymentType.CreditCard.PersistenceLayerId || payment.PaymentType == PaymentType.CreditCardOnFile_Value) && payment.ChargeCard != null)
                    {
                        var transactionAmount = payment.ChargeCard.ChargeCardPayment.Amount;
                        if (paymentEditModel.PaymentFlow == PaymentFlow.Out) transactionAmount = -1 * transactionAmount;

                        ProcessorResponse response = null;
                        if (paymentEditModel.PaymentFlow == PaymentFlow.Out)
                        {
                            if (_isEccEnabled)
                            {
                                response = _chargeCardService.ApplyRefundtoNewCard(transactionAmount, customer.Name,
                                                                                   payment.ChargeCard.ChargeCard,
                                                                                   payment.BillingAddress, ipAddress,
                                                                                   uniquePaymentReference + "(" + index +
                                                                                   ")", customer.Email != null ? customer.Email.ToString() : string.Empty);
                            }
                            else if (payment.PaymentType == PaymentType.CreditCardOnFile_Value)
                            {
                                var cardPayment = _chargeCardPaymentRepository.GetById(payment.ChargeCard.ChargeCardPayment.Id);
                                string reasonForFailure = "";
                                bool isValidcard = _chargeCardService.IsCardValidforRefund(cardPayment, payment.Amount, out reasonForFailure);
                                if (!isValidcard)
                                    throw new Exception(reasonForFailure);

                                string previousResponse = cardPayment.ProcessorResponse;
                                if (cardPayment.Amount == payment.Amount)
                                {
                                    response = _chargeCardService.VoidRequest(previousResponse);
                                    if (response.ProcessorResult != ProcessorResponseResult.Accepted)
                                        response = _chargeCardService.ApplyRefundtoCardonFile(transactionAmount, payment.ChargeCard.ChargeCard.Number, payment.ChargeCard.ChargeCard.ExpirationDate, previousResponse);
                                    else
                                    {
                                        new NLogLogManager().GetLogger<PaymentController>().Info("CC Void Request - Details [RawResponse: " + response.RawResponse + "]");
                                    }
                                }
                                else
                                    response = _chargeCardService.ApplyRefundtoCardonFile(transactionAmount, payment.ChargeCard.ChargeCard.Number, payment.ChargeCard.ChargeCard.ExpirationDate, previousResponse);
                            }
                            else
                            {
                                throw new Exception("Refund on the provided card is not allowed. Please choose any other option.");
                            }
                        }
                        else
                        {
                            response = _chargeCardService.ChargefromCard(transactionAmount, new Name(payment.ChargeCard.ChargeCard.NameOnCard), payment.ChargeCard.ChargeCard, payment.BillingAddress, ipAddress,
                                                                        uniquePaymentReference + "(" + index + ")", customer.Email != null ? customer.Email.ToString() : string.Empty);
                        }

                        if (response.ProcessorResult != ProcessorResponseResult.Accepted)
                        {
                            new NLogLogManager().GetLogger<PaymentController>().Info("CC Transaction - Details [RawResponse: " + response.RawResponse + "]");
                            throw new Exception("Transaction Failed!");
                        }

                        payment.IsProcessed = true;
                        payment.ChargeCard.ChargeCardPayment.ProcessorResponse = response.RawResponse;
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An exception caused while " + (paymentEditModel.PaymentFlow == PaymentFlow.Out ? "refunding" : "charging") + " amount. Message: " + ex.Message, ex);
            }
        }

        public void VoidCreditCardGatewayRequests(PaymentEditModel paymentEditModel)
        {
            if (paymentEditModel.Payments == null || paymentEditModel.Payments.Count() < 1)
                return;

            var payments = paymentEditModel.Payments.Where(p => p.IsProcessed && (p.PaymentType == PaymentType.CreditCard.PersistenceLayerId || p.PaymentType == PaymentType.CreditCardOnFile_Value) && p.ChargeCard != null && p.ChargeCard.ChargeCardPayment != null);

            foreach (var payment in payments)
            {
                _chargeCardService.VoidRequest(payment.ChargeCard.ChargeCardPayment.ProcessorResponse);
            }
        }

        public long SavePayment(PaymentEditModel paymentEditModel, long dataRecorderOrgRoleUserId)
        {
            if (paymentEditModel.Payments == null || paymentEditModel.Payments.Count() < 1)
                return 0;

            var payments = paymentEditModel.Payments.Where(p => p.Amount != 0);
            var paymentInstruments = new List<PaymentInstrument>();

            var dataRecordermetaData = new DataRecorderMetaData()
                                          {
                                              DateCreated = DateTime.Now,
                                              DataRecorderCreator = new OrganizationRoleUser(dataRecorderOrgRoleUserId)
                                          };

            foreach (var payment in payments)
            {
                if ((payment.PaymentType == PaymentType.CreditCard.PersistenceLayerId || payment.PaymentType == PaymentType.CreditCardOnFile_Value) && payment.ChargeCard != null)
                {
                    payment.ChargeCard.ChargeCardPayment.DataRecorderMetaData = dataRecordermetaData;
                    payment.ChargeCard.ChargeCardPayment.Id = 0;

                    if (payment.ChargeCard.ChargeCard.Id < 1)
                        payment.ChargeCard.ChargeCard.DataRecorderMetaData = dataRecordermetaData;

                    if (payment.PaymentType != PaymentType.CreditCardOnFile_Value)
                        payment.ChargeCard.ChargeCard = _chargeCardRepository.Save(payment.ChargeCard.ChargeCard);

                    payment.ChargeCard.ChargeCardPayment.ChargeCardId = payment.ChargeCard.ChargeCard.Id;
                    payment.ChargeCard.ChargeCardPayment.ChargeCardPaymentStatus = ChargeCardPaymentStatus.Approve;
                    if (paymentEditModel.PaymentFlow == PaymentFlow.Out) payment.ChargeCard.ChargeCardPayment.Amount = -1 * payment.ChargeCard.ChargeCardPayment.Amount;

                    paymentInstruments.Add(payment.ChargeCard.ChargeCardPayment);
                }
                else if (payment.PaymentType == PaymentType.Cash.PersistenceLayerId)
                {
                    var cashPayment = new CashPayment
                                         {
                                             Amount = paymentEditModel.PaymentFlow == PaymentFlow.Out ? -1 * payment.Amount : payment.Amount,
                                             DataRecorderMetaData = dataRecordermetaData
                                         };
                    paymentInstruments.Add(cashPayment);
                }
                else if (payment.PaymentType == PaymentType.Check.PersistenceLayerId && payment.Check != null)
                {
                    var check = payment.Check.Check;
                    var checkPayment = payment.Check.CheckPayment;

                    if (check.Id < 1)
                        check.DataRecorderMetaData = dataRecordermetaData;

                    if (checkPayment.Id < 1)
                        checkPayment.DataRecorderMetaData = dataRecordermetaData;

                    checkPayment.Check = check;
                    if (paymentEditModel.PaymentFlow == PaymentFlow.Out)
                    {
                        checkPayment.Amount = -1 * checkPayment.Amount;
                        check.Amount = -1 * check.Amount;
                    }

                    paymentInstruments.Add(checkPayment);
                }
                else if (payment.PaymentType == PaymentType.ElectronicCheck.PersistenceLayerId && payment.ECheck != null)
                {
                    var check = payment.ECheck.ECheck;
                    var checkPayment = payment.ECheck.ECheckPayment;

                    if (check.Id < 1)
                        check.DataRecorderMetaData = dataRecordermetaData;

                    if (checkPayment.Id < 1)
                        checkPayment.DataRecorderMetaData = dataRecordermetaData;

                    checkPayment.ECheck = check;

                    paymentInstruments.Add(checkPayment);
                }
                else if (payment.PaymentType == PaymentType.GiftCertificate.PersistenceLayerId && payment.GiftCertificate != null)
                {
                    var giftCertificate = payment.GiftCertificate.GiftCertificate;
                    var giftCertificatePayment = payment.GiftCertificate.GiftCertificatePayment;

                    if (giftCertificate.Id < 1)
                        giftCertificate.DataRecorderMetaData = dataRecordermetaData;

                    if (giftCertificatePayment.Id < 1)
                        giftCertificatePayment.DataRecorderMetaData = dataRecordermetaData;

                    paymentInstruments.Add(giftCertificatePayment);
                }
                else if (payment.PaymentType == PaymentType.Insurance.PersistenceLayerId && payment.Insurance != null && payment.Insurance.EligibilityId > 0 && payment.Insurance.InsurancePayment.AmountToBePaid > 0)
                {
                    var insurancePayment = payment.Insurance.InsurancePayment;
                    insurancePayment.Amount = 0;
                    insurancePayment.DataRecorderMetaData = dataRecordermetaData;

                    paymentInstruments.Add(insurancePayment);
                }
            }

            long paymentId = SavePayment(paymentInstruments, "Payment", dataRecorderOrgRoleUserId);
            return paymentId;
        }

    }
}
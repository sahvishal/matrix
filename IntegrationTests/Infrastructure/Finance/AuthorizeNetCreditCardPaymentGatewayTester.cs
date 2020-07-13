using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Service;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    public class AuthorizeNetCreditCardPaymentGatewayTester
    {
        private IPaymentProcessor _authorizeNetCreditCardPaymentGateway;
        private readonly CreditCardProcessorProcessingInfo VAILD_TEST_CC;
        private readonly CreditCardProcessorProcessingInfo VALID_REAL_CC;

        private ISettings _fakeSettings;

        public AuthorizeNetCreditCardPaymentGatewayTester()
        {
            _fakeSettings = new Fakes.FakeSettings();
            VAILD_TEST_CC = new CreditCardProcessorProcessingInfo()
            {
                CreditCardNo = "4111111111111111",
                SecurityCode = "458",
                ExpiryMonth = 12,
                ExpiryYear = 2012,
                CardType = "Visa",
                Price = "100",
                FirstName = "Tester",
                LastName = "Tester",
                BillingAddress = "Address1",
                BillingCity = "Austin",
                BillingState = "Texas",
                BillingPostalCode = "78705",
                BillingCountry = "US",
                Email = "Mail@mail.com",
                IpAddress = "192.168.1.2",
                Currency = "USD",
                OrderId = "Cus005"
            };

            VALID_REAL_CC = new CreditCardProcessorProcessingInfo()
            {
                CreditCardNo = "4111111111111111",
                SecurityCode = "458",
                ExpiryMonth = 12,
                ExpiryYear = 2012,
                CardType = "Visa",
                Price = "100",
                FirstName = "Tester",
                LastName = "Tester",
                BillingAddress = "Address1",
                BillingCity = "Austin",
                BillingState = "Texas",
                BillingPostalCode = "78705",
                BillingCountry = "US",
                Email = "Mail@mail.com",
                IpAddress = "192.168.1.2",
                Currency = "USD",
                OrderId = "Cus005"
            };

            _authorizeNetCreditCardPaymentGateway = new AuthorizeNetCreditCardPaymentGateway(_fakeSettings);
        }


        [Test]
        public void ChargeCreditCard_ReturnsSuccessForValidCard()
        {
            ProcessorResponse processorResponse = _authorizeNetCreditCardPaymentGateway.ChargeCreditCard(VAILD_TEST_CC);

            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);
            Assert.IsNotNull(processorResponse);
        }

        [Test]
        public void VoidRequest_ReturnsSuccessForValidChargeTransaction()
        {
            ProcessorResponse processorResponse = _authorizeNetCreditCardPaymentGateway.ChargeCreditCard(VAILD_TEST_CC);
            Assert.IsNotNull(processorResponse); 
            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);

            processorResponse = _authorizeNetCreditCardPaymentGateway.VoidRequestforaPreviousResponse(processorResponse.RawResponse);
            
            Assert.IsNotNull(processorResponse); 
            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);
        }

        [Test]
        public void VoidRequest_ReturnsSuccessForRealValidChargeTransaction()
        {
            ProcessorResponse processorResponse = _authorizeNetCreditCardPaymentGateway.ChargeCreditCard(VALID_REAL_CC);
            Assert.IsNotNull(processorResponse);
            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);

            processorResponse = _authorizeNetCreditCardPaymentGateway.VoidRequestforaPreviousResponse(processorResponse.RawResponse);

            Assert.IsNotNull(processorResponse);
            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);
        }

        [Test]
        public void ChargeCreditCard_ReturnsSuccessForValidRealCard()
        {
            ProcessorResponse processorResponse = _authorizeNetCreditCardPaymentGateway.ChargeCreditCard(VALID_REAL_CC);

            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);
            Assert.IsNotNull(processorResponse);

        }


        [Test]
        public void ChargeCreditCard_DeclinesForExpiredCard()
        {
            var expiredCard = VAILD_TEST_CC;
            expiredCard.ExpiryMonth = 1;
            expiredCard.ExpiryYear = 2001;

            ProcessorResponse processorResponse = _authorizeNetCreditCardPaymentGateway.ChargeCreditCard(expiredCard);

            Assert.AreEqual(ProcessorResponseResult.Rejected, processorResponse.ProcessorResult);
            Assert.IsNotNull(processorResponse);

        }


        [Test]
        public void ChargeCreditCard_FailsForInValidCard()
        {
            var invalidCard = VAILD_TEST_CC;
            invalidCard.CreditCardNo = "41111111111112222";

            ProcessorResponse processorResponse = _authorizeNetCreditCardPaymentGateway.ChargeCreditCard(invalidCard);

            Assert.AreEqual(ProcessorResponseResult.Fail, processorResponse.ProcessorResult);
            Assert.IsNotNull(processorResponse);

        }

        [Test]
        public void RefundRequest_ReturnsSuccessForRealValidChargeTransaction()
        {
            ProcessorResponse processorResponse = _authorizeNetCreditCardPaymentGateway.ChargeCreditCard(VALID_REAL_CC);
            Assert.IsNotNull(processorResponse);
            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);


            processorResponse = _authorizeNetCreditCardPaymentGateway.RefundRequestOnSameCreditCard(processorResponse.TransactionCode, VALID_REAL_CC.CreditCardNo, new DateTime(VALID_REAL_CC.ExpiryYear,VALID_REAL_CC.ExpiryMonth, 1), "10");

            Assert.IsNotNull(processorResponse);
            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);
        }

        [Test]
        public void RefundRequest_ReturnsSuccessForaPreviousRealValidChargeTransaction()
        {
            var rawResponse = "";//"1|1|1|This transaction has been approved.|919264|Y|3706081658|23708_1314322||204.00|CC|auth_capture||kim|wasserman||819peacock plaza|Key West|FL|33040|US|||zeestan09@yahoo.com||||||||||||||027E6504A6CD489857DABD492B2DC118|P||||||||||||XXXX3413|Visa||||||||||||||||";
            var processorResponse = new ProcessorResponse(rawResponse);

            processorResponse = _authorizeNetCreditCardPaymentGateway.RefundRequestOnSameCreditCard(processorResponse.TransactionCode, "3413", new DateTime(2012, 6, 1), "204");

            Assert.IsNotNull(processorResponse);
            Assert.AreEqual(ProcessorResponseResult.Accepted, processorResponse.ProcessorResult);
        }

    }
}
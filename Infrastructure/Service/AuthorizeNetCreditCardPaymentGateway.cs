using System;
using System.IO;
using System.Net;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Service
{
    public class AuthorizeNetCreditCardPaymentGateway : IPaymentProcessor
    {

        private ISettings _settings;
        private const string TEST_URL = "https://test.authorize.net/gateway/transact.dll";
        private const string LIVE_URL = "https://secure.authorize.net/gateway/transact.dll";
         

        public AuthorizeNetCreditCardPaymentGateway(ISettings settings)
        {
            _settings = settings;
        }

        public AuthorizeNetCreditCardPaymentGateway()
            : this(new Settings())
        { }


        public ProcessorResponse ChargeCreditCard(CreditCardProcessorProcessingInfo creditCardProcessorProcessingInfo)
        {
            var rawResponse = PostRequest(BuildPostRequest(creditCardProcessorProcessingInfo));
            return new ProcessorResponse(rawResponse);

        }

        public ProcessorResponse ChargeECheck(ElectronicCheckProcessorProcessingInfo paymentProcessorMetaDataInfo)
        {
            throw new NotImplementedException();
        }
        
        public ProcessorResponse RefundRequestOnSameCreditCard(string transactionId, string cardNumber, DateTime expiryDate, string amount)
        {
            var strPost = new StringBuilder();

            int expiryMonth = expiryDate.Month;
            int expiryYear = expiryDate.Year;

            strPost.Append(String.Format("x_login={0}&", _settings.ProcessorLogin));
            strPost.Append(String.Format("x_tran_key={0}&", _settings.ProcessorTransactionKey));
            strPost.Append(String.Format("x_type={0}&", "CREDIT"));
            strPost.Append(String.Format("x_trans_id={0}&", transactionId));
            strPost.Append(String.Format("x_card_num={0}&", cardNumber));
            strPost.Append(String.Format("x_amount={0}&", Math.Round(decimal.Parse(amount), 2)));

            strPost.Append(String.Format("x_test_request={0}&", (_settings.ProcessorUseTestTransaction ? "TRUE" : "FALSE")));
            strPost.Append(String.Format("x_exp_date={0}&", expiryMonth.ToString().PadLeft(2, '0') + expiryYear));
            strPost.Append("x_delim_data=TRUE&");
            strPost.Append("x_delim_char=|&");
            strPost.Append("x_relay_response=FALSE&");
            strPost.Append("x_version=3.1");

            var rawResponse = PostRequest(strPost.ToString());
            return new ProcessorResponse(rawResponse);

            //cardNumber = _cryptographyService.Decrypt(cardNumber);
            //var creditRequest = new CreditRequest(transactionId, Convert.ToDecimal(amount), cardNumber);

            ////TODO:true for Testmode. false for live mode
            //var paymentGateway = new Gateway(_settings.ProcessorLogin, _settings.ProcessorTransactionKey, true);
            //var response = paymentGateway.Send(creditRequest);
            //return new ProcessorResponse(response.ToString()); //.Replace("[CardNumber]", _cryptographyService.Encrypt(cardNumber));
        }

        public ProcessorResponse VoidRequestforaPreviousResponse(string rawResponse)
        {
            var processorResponse = new ProcessorResponse(rawResponse);
            return VoidRequest(processorResponse.TransactionCode);
        }

        //ToDo: Need to refactor, reduce it to one method responsible for building all kind of request: Sandeep
        public ProcessorResponse VoidRequest(string transactionId)
        {
            var strPost = new StringBuilder();

            strPost.Append(String.Format("x_login={0}&", _settings.ProcessorLogin));
            strPost.Append(String.Format("x_tran_key={0}&", _settings.ProcessorTransactionKey));
            strPost.Append(String.Format("x_type={0}&", "VOID"));
            strPost.Append(String.Format("x_trans_id={0}&", transactionId));

            strPost.Append(String.Format("x_test_request={0}&", (_settings.ProcessorUseTestTransaction ? "TRUE" : "FALSE")));
            strPost.Append("x_delim_data=TRUE&");
            strPost.Append("x_delim_char=|&");
            strPost.Append("x_relay_response=FALSE&");
            strPost.Append("x_version=3.1");

            var rawResponse = PostRequest(strPost.ToString());
            return new ProcessorResponse(rawResponse);
        }

        public ProcessorResponse RefundRequestOnOtherCreditCard(CreditCardProcessorProcessingInfo creditCardProcessorProcessingInfo)
        {
            creditCardProcessorProcessingInfo.RequestType = ProcessorRequestType.Refund;
            var rawResponse = PostRequest(BuildPostRequest(creditCardProcessorProcessingInfo));
            return new ProcessorResponse(rawResponse);
        }

        private string BuildPostRequest(CreditCardProcessorProcessingInfo processingInfo)
        {
            var strPost = new StringBuilder();

            //billing            
            strPost.Append(String.Format("x_login={0}&", _settings.ProcessorLogin));
            strPost.Append(String.Format("x_tran_key={0}&", _settings.ProcessorTransactionKey));
            strPost.Append(String.Format("x_method={0}&", "CC"));
            strPost.Append(String.Format("x_type={0}&", (processingInfo.RequestType == ProcessorRequestType.Refund ? "CREDIT" : "AUTH_CAPTURE")));
            strPost.Append(String.Format("x_amount={0}&", Math.Round(decimal.Parse(processingInfo.Price), 2)));


            strPost.Append(String.Format("x_card_num={0}&", processingInfo.CreditCardNo));
            strPost.Append(String.Format("x_exp_date={0}&", processingInfo.ExpiryMonth.ToString().PadLeft(2, '0') + processingInfo.ExpiryYear));


            strPost.Append(String.Format("x_first_name={0}&", processingInfo.FirstName));
            strPost.Append(String.Format("x_last_name={0}&", processingInfo.LastName));
            strPost.Append(String.Format("x_address={0}&", processingInfo.BillingAddress));
            strPost.Append(String.Format("x_city={0}&", processingInfo.BillingCity));
            strPost.Append(String.Format("x_state={0}&", processingInfo.BillingState));
            strPost.Append(String.Format("x_zip={0}&", processingInfo.BillingPostalCode));
            strPost.Append(String.Format("x_country={0}&", processingInfo.BillingCountry));
            strPost.Append(String.Format("x_email={0}&", processingInfo.Email ?? ""));
            strPost.Append(String.Format("x_customer_ip={0}&", processingInfo.IpAddress ?? ""));


            //transaction addtional information
            strPost.Append(String.Format("x_description={0}&", processingInfo.Description));
            strPost.Append(String.Format("x_invoice_num={0}&", processingInfo.OrderId));

            strPost.Append(String.Format("x_test_request={0}&", (_settings.ProcessorUseTestTransaction ? "TRUE" : "FALSE")));
            strPost.Append("x_delim_data=TRUE&");
            strPost.Append("x_delim_char=|&");
            strPost.Append("x_relay_response=FALSE&");
            strPost.Append("x_version=3.1");

            return strPost.ToString();
        }

        public ProcessorResponse AuthorizeOnly(CreditCardProcessorProcessingInfo processingInfo)
        {
            var strPost = new StringBuilder();

            strPost.Append(String.Format("x_login={0}&", _settings.ProcessorLogin));
            strPost.Append(String.Format("x_tran_key={0}&", _settings.ProcessorTransactionKey));
            strPost.Append(String.Format("x_method={0}&", "CC"));
            strPost.Append(String.Format("x_type={0}&", "AUTH_ONLY"));

            strPost.Append(String.Format("x_amount={0}&", Math.Round(decimal.Parse(processingInfo.Price), 2)));
            strPost.Append(String.Format("x_card_num={0}&", processingInfo.CreditCardNo));
            strPost.Append(String.Format("x_exp_date={0}&", processingInfo.ExpiryMonth.ToString().PadLeft(2, '0') + processingInfo.ExpiryYear));
            

            strPost.Append(String.Format("x_test_request={0}&", (_settings.ProcessorUseTestTransaction ? "TRUE" : "FALSE")));
            strPost.Append("x_delim_data=TRUE&");
            strPost.Append("x_delim_char=|&");
            strPost.Append("x_relay_response=FALSE&");
            strPost.Append("x_version=3.1");

            var rawResponse = PostRequest(strPost.ToString());
            return new ProcessorResponse(rawResponse);
        }


        private string PostRequest(string postData)
        {
            string url = (_settings.ProcessorUseTestUrl ? TEST_URL : LIVE_URL);
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentLength = postData.Length;
            webRequest.ContentType = "application/x-www-form-urlencoded";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(postData);
            }

            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var rawResponse = "";
            using (var sr = new StreamReader(webResponse.GetResponseStream()))
            {
                rawResponse = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }

            try
            {
                new NLogLogManager().GetLogger<AuthorizeNetCreditCardPaymentGateway>().Info("CC Transaction - Details [PostData: " + postData + " Url" + url +" RawResponse" + rawResponse + "]");
            }
            catch
            {
            }

            return rawResponse;
        }

    }
}

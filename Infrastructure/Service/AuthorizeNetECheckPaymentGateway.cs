using System;
using System.Text;
using System.Net;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Service
{
    public class AuthorizeNetECheckPaymentGateway :IPaymentProcessor
    {
        private ISettings _settings;
        private const string TEST_URL = "https://test.authorize.net/gateway/transact.dll";
        private const string LIVE_URL = "https://secure.authorize.net/gateway/transact.dll";

        public AuthorizeNetECheckPaymentGateway(ISettings settings)
        {
            _settings = settings;
        }

        public AuthorizeNetECheckPaymentGateway()
            : this(new Settings())
        {}

        public ProcessorResponse ChargeCreditCard(CreditCardProcessorProcessingInfo creditCardProcessorProcessingInfo )
        {
            throw new NotImplementedException();
        }

        public ProcessorResponse ChargeECheck(ElectronicCheckProcessorProcessingInfo electronicCheckProcessorProcessingInfo)
        {
            string url = (_settings.ProcessorUseTestUrl ? TEST_URL : LIVE_URL);
            string result;

            var authorizepost = new StringBuilder();
            //Authorize.net required field
            authorizepost.Append("x_login=" + _settings.ProcessorLogin + "&");
            authorizepost.Append("x_tran_key=" + _settings.ProcessorTransactionKey + "&");
            authorizepost.Append("x_method=ECHECK&");
            authorizepost.Append("x_type=AUTH_CAPTURE&");
            authorizepost.Append("x_amount=" + electronicCheckProcessorProcessingInfo.Price + "&");
            authorizepost.Append("x_currency_code=" + electronicCheckProcessorProcessingInfo.Currency + "&");
            authorizepost.Append("x_delim_data=True&");
            authorizepost.Append("x_delim_char=|&");
            authorizepost.Append("x_relay_response=False&");
            authorizepost.Append("x_test_request=" + (_settings.ProcessorUseTestTransaction ? "TRUE" : "FALSE"));
            authorizepost.Append("x_version=3.1&");
            authorizepost.Append("x_tax=&");
            authorizepost.Append("x_freight=&");

            //echeck required field
            authorizepost.Append("x_bank_aba_code=" + electronicCheckProcessorProcessingInfo.BankRoutingNumber + "&");
            authorizepost.Append("x_bank_acct_num=" + electronicCheckProcessorProcessingInfo.BankAccountNumber + "&");
            authorizepost.Append("x_bank_acct_type=" + electronicCheckProcessorProcessingInfo.BankAccountType + "&");
            authorizepost.Append("x_bank_name=" + electronicCheckProcessorProcessingInfo.BankName + "&");
            authorizepost.Append("x_bank_acct_name=" + electronicCheckProcessorProcessingInfo.BankAccountName + "&");
            authorizepost.Append("x_echeck_type=" + electronicCheckProcessorProcessingInfo.CheckType + "&");
            authorizepost.Append("x_bank_check_number=" + electronicCheckProcessorProcessingInfo.CheckNumber + "&");
            authorizepost.Append("x_recurring_billing=N&");

            //customer billing info
            authorizepost.Append("x_First_Name =" + electronicCheckProcessorProcessingInfo.FirstName + "&");
            authorizepost.Append("x_Last_Name =" + electronicCheckProcessorProcessingInfo.LastName + "&");
            authorizepost.Append("x_Last_Name =" + electronicCheckProcessorProcessingInfo.LastName + "&");
            authorizepost.Append("x_Company =Test&");
            authorizepost.Append("x_Address =" + electronicCheckProcessorProcessingInfo.BillingAddress + "&");
            authorizepost.Append("x_City =" + electronicCheckProcessorProcessingInfo.BillingCity + "&");
            authorizepost.Append("x_State =" + electronicCheckProcessorProcessingInfo.BillingState + "&");
            authorizepost.Append("x_Zip =" + electronicCheckProcessorProcessingInfo.BillingPostalCode + "&");
            authorizepost.Append("x_Country =" + electronicCheckProcessorProcessingInfo.BillingCountry + "&");
            authorizepost.Append("x_Phone =" + electronicCheckProcessorProcessingInfo.PhoneNumber + "&");
            authorizepost.Append("x_fax=&");

            authorizepost.Append("x_Email =" + electronicCheckProcessorProcessingInfo.Email + "&");
            authorizepost.Append("x_email_customer=False&");
          

            //customer detail
            authorizepost.Append("x_Invoice_Num=" + electronicCheckProcessorProcessingInfo.OrderId + "&");
            authorizepost.Append("x_cust_id=" + electronicCheckProcessorProcessingInfo.CustomerId + "&");
            authorizepost.Append("x_customer_ip=" + electronicCheckProcessorProcessingInfo.IpAddress + "&");
            authorizepost.Append("x_Customer_Tax_ID=&");

            var objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = authorizepost.ToString().Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                using (var myWriter = new StreamWriter(objRequest.GetRequestStream()))
                {
                    myWriter.Write(authorizepost.ToString());
                }
            }
            catch (Exception e)
            {
                return new ProcessorResponse {ProcessorResult = ProcessorResponseResult.Fail, Message = e.Message};
            }

            var objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (var sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();

                // Close and clean up the StreamReader
                sr.Close();
            }

            try
            {
                new NLogLogManager().GetLogger<AuthorizeNetCreditCardPaymentGateway>().Info("ECheck Transaction - Details [PostData: " + authorizepost + " Url" + url + " RawResponse" + result + "]");
            }
            catch
            {
            }
            return new ProcessorResponse(result); 
        }

        public ProcessorResponse RefundRequestOnOtherCreditCard(CreditCardProcessorProcessingInfo creditCardProcessorProcessingInfo)
        {
            throw new NotImplementedException();
        }

        public ProcessorResponse VoidRequest(string transactionId)
        {
            throw new NotImplementedException();
        }

        public ProcessorResponse VoidRequestforaPreviousResponse(string rawResponse)
        {
            throw new NotImplementedException();
        }

        public ProcessorResponse AuthorizeOnly(CreditCardProcessorProcessingInfo processingInfo)
        {
            throw new NotImplementedException();
        }

        public ProcessorResponse RefundRequestOnSameCreditCard(string transactionId, string cardNumber, DateTime expiryDate, string amount)
        {
            throw new NotImplementedException();
        }
    }
}
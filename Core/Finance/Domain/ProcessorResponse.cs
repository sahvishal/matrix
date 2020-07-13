using System;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class ProcessorResponse
    {
        public ProcessorResponseResult ProcessorResult { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public string TransactionCode { get; set; }
        public string RawResponse { get; set; }

        public ProcessorResponse()
        {
            ProcessorResult = ProcessorResponseResult.Fail;
            Message = "Failed Response. Did not even get to the payment gateway";
        }

        public ProcessorResponse(string rawResponse)
        {
            RawResponse = rawResponse;
            ParseProcessorResult(rawResponse);
        }

        private void ParseProcessorResult(string rawResponse)
        {
            if (rawResponse.Trim().Length < 1)
            {
                ProcessorResult = ProcessorResponseResult.Fail;
                Message = "Empty response. May not have reached the processor or a networking issue.";
                return;
            }


            char[] seperator = { '|' };
            string[] response = rawResponse.Split(seperator);

            if (response.Length < 7)
            {
                ProcessorResult = ProcessorResponseResult.Fail;
                Message = "Partial Response from Processor, unable to parse completely.";
                return;
            }   
            
            switch(response[0])
            {
                case "1":   ProcessorResult = ProcessorResponseResult.Accepted;
                            Message = response[3];
                            ResponseCode = response[2];
                            TransactionCode = response[6];
                            break;

                case "2" :  ProcessorResult = ProcessorResponseResult.Rejected;
                            Message = response[3];
                            ResponseCode = response[2];
                            TransactionCode = response[6];
                            break;
                case "3" :  ProcessorResult = ProcessorResponseResult.ProcessorError;
                            Message = response[3];
                            ResponseCode = response[2];
                            TransactionCode = response[6];
                            break;
                case "4": ProcessorResult = ProcessorResponseResult.HeldForReview;
                            Message = response[3];
                            ResponseCode = response[2];
                            TransactionCode = response[6];
                            break;
                default :
                            ProcessorResult = ProcessorResponseResult.Fail;
                            Message = "Unknown processor response.";
                            break;                
            }
        }

        public static Boolean IsValidResponseString(string rawResponse)
        {
            if (rawResponse.Trim().Length < 1)            
                return false;
            
            char[] seperator = { '|' };
            string[] response = rawResponse.Split(seperator);

            if (response.Length < 7)
                return false;

            return true;
        }
    }
}
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.ViewModels;
using J2.eFaxDeveloper;
using J2.eFaxDeveloper.Outbound;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class EFaxApi : IEFaxApi
    {

        public string AccountId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        public string EFaxDispositionRecipient { get; set; }

        public string EFaxDispositionEmail { get; set; }


        public EFaxApi(ISettings settings)
        {
            AccountId = settings.EFaxAccountId;
            UserName = settings.EFaxUserName;
            Password = settings.EFaxPassword;
            EFaxDispositionEmail = settings.EFaxDispositionEmail;
            EFaxDispositionRecipient = settings.EFaxDispositionRecipient;
        }
        
        public EFaxResponse SendCreateEFax(EFaxParmaters parmaters)
        {
            var strArray = parmaters.Message.Split(new[] { ',' });

            var bites = strArray.Select(byte.Parse).ToArray();

            var outboundClient = new OutboundClient
            {
                AccountId = AccountId,
                UserName = UserName,
                Password = Password
            };

            var outboundRequest = new OutboundRequest
            {
                TransmissionControl =
                {
                    NoDuplicates = parmaters.SendDuplicate ? NoDuplicates.Disable : NoDuplicates.Enable,
                    Priority = parmaters.IsHighPriority ? Priority.High : Priority.Normal,
                    Resolution = Resolution.Fine,
                    CustomerID = parmaters.CustomerId,
                    TransmissionID = parmaters.TransmissionId,
                    SelfBusy = SelfBusy.Disable
                },
                DispositionControl =
                {
                    DispositionEmails = { new DispositionEmail { DispositionRecipient = EFaxDispositionRecipient, DispositionAddress = EFaxDispositionEmail } },
                    DispositionLevel = DispositionLevel.Error,
                    DispositionMethod = DispositionMethod.Email
                },
                Files =
                {
                    new FaxFile
                    {
                        FileContents = bites,
                        FileType = FaxFileType.pdf
                    }
                },
                Recipient =
                {
                   RecipientFax = parmaters.RecipientFax
                }

            };

            var outboundResponse = outboundClient.SendOutboundRequest(outboundRequest);

            var outputErrorLevel = EFaxErrorLevel.Undefined;
            switch (outboundResponse.ErrorLevel)
            {
                case ErrorLevel.Undefined:
                    outputErrorLevel = EFaxErrorLevel.Undefined;
                    break;
                case ErrorLevel.User:
                    outputErrorLevel = EFaxErrorLevel.User;
                    break;
                case ErrorLevel.System:
                    outputErrorLevel = EFaxErrorLevel.System;
                    break;
            }

            return new EFaxResponse
            {
                ErrorLevel = outputErrorLevel,
                ErrorMessage = outboundResponse.ErrorMessage,
                StatusCode =
                    (outboundResponse.StatusCode == StatusCode.Success ? EFaxStatusCode.Success : EFaxStatusCode.Failur),
                StatusDescription = outboundResponse.StatusDescription,
                TransmissionId = outboundResponse.TransmissionID
            };
        }

        public EFaxOutboundResponsStatus GetOutboundStatusResponse(long transmissionId)
        {
            var outboundClient = new OutboundClient
            {
                AccountId = AccountId,
                UserName = UserName,
                Password = Password
            };
            var response = outboundClient.SendOutboundStatusRequest(transmissionId.ToString(), "");

            return response == null ? null : new EFaxOutboundResponsStatus
            {
                Classification = response.Recipient.Status.Classification,
                Message = response.Recipient.Status.Message,
                Outcome = response.Recipient.Status.Outcome
            };
        }
    }
}

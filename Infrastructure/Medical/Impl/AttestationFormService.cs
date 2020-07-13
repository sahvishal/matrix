using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class AttestationFormService : IAttestationFormService
    {
        private readonly ISettings _settings;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly ILogger _logger;

        public AttestationFormService(ISettings settings, IEventCustomerResultRepository eventCustomerResultRepository, IMediaRepository mediaRepository, IPdfGenerator pdfGenerator, ILogManager logManager)
        {
            _settings = settings;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _mediaRepository = mediaRepository;
            _pdfGenerator = pdfGenerator;
            _logger = logManager.GetLogger("AttestationForm");

        }
        public string PrintAttestationPdf(long accountId, long customerId, long eventId)
        {
            try
            {
                if (accountId == _settings.MolinaAccountId || accountId == _settings.WellmedAccountId)
                {
                    var focAttestationPdfUrl = string.Empty;

                    var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                    var fileName = "Attestation_" + Guid.NewGuid() + ".pdf";

                    _logger.Info(string.Format("generating AttestationFormPdf: CustomerId {0} EventId {1} AccountId {2}", customerId, eventId, accountId));

                    var mediaLocation = _mediaRepository.GetTempMediaFileLocation();

                    if (accountId == _settings.WellmedAccountId && eventCustomerResult != null)
                    {
                        focAttestationPdfUrl = _settings.AppUrl + "/Medical/Attestation/WellMedView?eventCustomerResultId=" + eventCustomerResult.Id + "&accountId=" + accountId + "&customerId=" + customerId +
                                               "&eventId=" + eventId + "&print=true";
                    }
                    else if (accountId == _settings.MolinaAccountId && eventCustomerResult != null)
                    {
                        focAttestationPdfUrl = _settings.AppUrl + "/Medical/Attestation/MolinaView?eventCustomerResultId=" + eventCustomerResult.Id + "&accountId=" + accountId + "&customerId=" + customerId +
                                               "&eventId=" + eventId + "&print=true";
                    }
                    if (string.IsNullOrEmpty(focAttestationPdfUrl))
                        return string.Empty;

                    _pdfGenerator.GeneratePdf(focAttestationPdfUrl, mediaLocation.PhysicalPath + fileName);

                    return mediaLocation.PhysicalPath + fileName;
                }
            }
            catch (Exception exception)
            {

                _logger.Error(string.Format("Some Error occured: Exception: {0}  Stack Trace: {1}", exception.Message, exception.StackTrace));
            }

            return string.Empty;
        }
    }
}

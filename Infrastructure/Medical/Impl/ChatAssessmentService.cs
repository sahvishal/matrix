using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.ValueTypes;
using System;
using System.IO;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ChatAssessmentService : IChatAssessmentService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IChatAssessmentApiService _apiService;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;

        public ChatAssessmentService(IMediaRepository mediaRepository, IChatAssessmentApiService apiService, IEventCustomerResultRepository eventCustomerResultRepository)
        {
            _mediaRepository = mediaRepository;
            _apiService = apiService;
            _eventCustomerResultRepository = eventCustomerResultRepository;
        }

        public ChatAssessmentPdfViewModel GetChatAssessmentPdfPath(long eventId, string acesId)
        {
            var fileName = string.Format("ChatAssessment_{0}_{1}.pdf", eventId, acesId);

            var tempMediaLoaction = _mediaRepository.GetTempMediaFileLocation();

            var data = "eventId=" + eventId + "&acesId=" + acesId;
            var apiData = _apiService.Post<ChatAssessmentDataModel>(data);

            if (apiData != null && (apiData.returnCode == 1 || string.IsNullOrWhiteSpace(apiData.returnMessage)))
                throw new FileNotFoundException("No Assessment PDF available for this patient.");

            if (apiData != null && apiData.returnCode == 0 && !string.IsNullOrWhiteSpace(apiData.returnMessage))
            {
                var pdfUrl = SaveFile(apiData.returnMessage, tempMediaLoaction, fileName);

                return new ChatAssessmentPdfViewModel() { PdfUrl = pdfUrl };
            }

            throw new Exception("Some unexpected error at API level.");
        }

        private string SaveFile(string byteData, MediaLocation mediaLocation, string fileName)
        {
            var filePath = Path.Combine(mediaLocation.PhysicalPath, fileName);
            DirectoryOperationsHelper.DeleteFileIfExist(filePath);
            var dataBytes = Convert.FromBase64String(byteData);
            File.WriteAllBytes(filePath, dataBytes);
            return Path.Combine(mediaLocation.Url, fileName);
        }

        public bool SaveAssessmentPdfVerification(long eventId, long customerId, bool isVerified, bool isforOveread, long physicianId)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult == null) return false;

            if (!isforOveread)
            {
                eventCustomerResult.ChatPdfReviewedByPhysicianId = isVerified ? physicianId : (long?)null;
                eventCustomerResult.ChatPdfReviewedByPhysicianDate = isVerified ? DateTime.Now : (DateTime?)null;
            }
            else
            {
                eventCustomerResult.ChatPdfReviewedByOverreadPhysicianId = isVerified ? physicianId : (long?)null;
                eventCustomerResult.ChatPdfReviewedByOverreadPhysicianDate = isVerified ? DateTime.Now : (DateTime?)null;
            }
            _eventCustomerResultRepository.Save(eventCustomerResult);

            return true;
        }
    }
}

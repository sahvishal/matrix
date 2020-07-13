using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class FluVaccinationConsentService : IFluVaccinationConsentService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IFluConsentAnswerRepository _fluConsentAnswerRepository;
        private readonly IFluConsentQuestionRepository _fluConsentQuestionRepository;
        private readonly IFluConsentSignatureRepository _fluConsentSignatureRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;

        public FluVaccinationConsentService(IEventRepository eventRepository, IHostRepository hostRepository, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository,
            IFluConsentAnswerRepository fluConsentAnswerRepository, IFluConsentSignatureRepository fluConsentSignatureRepository, IUniqueItemRepository<File> fileRepository, IFluConsentQuestionRepository fluConsentQuestionRepository,
            IMediaRepository mediaRepository)
        {
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _fluConsentAnswerRepository = fluConsentAnswerRepository;
            _fluConsentSignatureRepository = fluConsentSignatureRepository;
            _fileRepository = fileRepository;
            _fluConsentQuestionRepository = fluConsentQuestionRepository;
            _mediaRepository = mediaRepository;
        }

        public FluVaccinationConsentViewModel GetFluVaccinationConsentViewModel(long eventId, long customerId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var host = _hostRepository.GetHostForEvent(eventId);
            var customer = _customerRepository.GetCustomer(customerId);

            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var answers = _fluConsentAnswerRepository.GetByEventCustomerId(eventCustomer.Id);
            var questions = _fluConsentQuestionRepository.GetAllQuestions();

            var signature = _fluConsentSignatureRepository.GetByEventCustomerId(eventCustomer.Id);

            var signatureFileIds = signature != null ? new[] { signature.SignatureFileId } : null;

            if (signature != null && signature.ClinicalProviderSignatureFileId.HasValue)
            {
                signatureFileIds = new[] { signature.SignatureFileId, signature.ClinicalProviderSignatureFileId.Value };
            }

            var signatureFiles = !signatureFileIds.IsNullOrEmpty() ? _fileRepository.GetByIds(signatureFileIds) : null;

            return GetFluVaccinationConsentViewModel(eventData, customer, host, questions, answers, signature, signatureFiles);
        }

        public FluVaccinationConsentViewModel GetFluVaccinationConsentViewModel(Event eventData, Customer customer, Host host, IEnumerable<FluConsentQuestion> questions, IEnumerable<FluConsentAnswer> answers, FluConsentSignature signature,
            IEnumerable<File> signatureFiles)
        {
            var model = new FluVaccinationConsentViewModel
            {
                Address = Mapper.Map<Address, AddressViewModel>(customer.Address),
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                DateofBirth = customer.DateOfBirth,
                Email = customer.Email != null ? customer.Email.ToString() : "",
                EventAddress = Mapper.Map<Address, AddressViewModel>(host.Address),
                EventDate = eventData.EventDate,
                EventId = eventData.Id,
                Gender = (int)customer.Gender,
                Height = customer.Height != null ? (int)customer.Height.TotalInches : 0,
                Weight = customer.Weight != null ? (int)customer.Weight.TotalPounds : 0,
                PhoneNumber = customer.HomePhoneNumber.ToString(),
                Race = (int)customer.Race,
            };

            var questionAnswers = new List<FluConsentQuestionAnswerEditModel>();
            if (!answers.IsNullOrEmpty())
            {
                foreach (var answer in answers)
                {
                    var question = questions.First(x => x.Id == answer.QuestionId);
                    var questionAnswer = new FluConsentQuestionAnswerEditModel
                    {
                        QuestionId = answer.QuestionId,
                        Question = question.Question,
                        Answer = answer.Answer,
                        ControlValue = !string.IsNullOrWhiteSpace(question.ControlValues) ? question.ControlValues.Split(',') : null,
                        Type = (CheckListQuestionType)question.TypeId,
                        Index = question.Index,
                        ParentId = question.ParentId
                    };

                    questionAnswers.Add(questionAnswer);
                }
                model.Answers = questionAnswers;
            }

            if (!signatureFiles.IsNullOrEmpty())
            {
                var mediaLocation = _mediaRepository.GetFluVaccineConsentSignatureLocation(eventData.Id, customer.CustomerId);

                var patientSignature = signatureFiles.FirstOrDefault(x => x.Id == signature.SignatureFileId);
                model.SignatureImageUrl = patientSignature != null ? mediaLocation.Url + patientSignature.Path : string.Empty;
                model.ConsentSignedDate = signature.ConsentSignedDate.ToString("MM/dd/yyyy");

                var clinicalProviderSignature = signatureFiles.FirstOrDefault(x => x.Id == signature.ClinicalProviderSignatureFileId);
                model.ClinicalProviderSignatureImageUrl = clinicalProviderSignature != null ? mediaLocation.Url + clinicalProviderSignature.Path : string.Empty;
            }

            return model;
        }
    }
}

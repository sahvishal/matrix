using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = System.IO.File;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class FluConsentService : IFluConsentService
    {
        private readonly IFluConsentTemplateRepository _fluConsentTemplateRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IFluConsentQuestionRepository _fluConsentQuestionRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IFluConsentSignatureRepository _fluConsentSignatureRepository;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly IFluConsentAnswerRepository _fluConsentAnswerRepository;

        private const int ReceiveVaccinationQuestionId = 11;

        public FluConsentService(IFluConsentTemplateRepository fluConsentTemplateRepository, ICorporateAccountRepository corporateAccountRepository, IFluConsentQuestionRepository fluConsentQuestionRepository,
            IEventCustomerRepository eventCustomerRepository, IMediaRepository mediaRepository, IFluConsentSignatureRepository fluConsentSignatureRepository, IUniqueItemRepository<Core.Application.Domain.File> fileRepository,
            IFluConsentAnswerRepository fluConsentAnswerRepository)
        {
            _fluConsentTemplateRepository = fluConsentTemplateRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _fluConsentQuestionRepository = fluConsentQuestionRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _mediaRepository = mediaRepository;
            _fluConsentSignatureRepository = fluConsentSignatureRepository;
            _fileRepository = fileRepository;
            _fluConsentAnswerRepository = fluConsentAnswerRepository;
        }

        public FluConsentTemplateListModel GetFluConsentTemplateList(FluConsentTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var templates = _fluConsentTemplateRepository.GetTemplates(filter, pageNumber, pageSize, out totalRecords);

            var healthPlans = _corporateAccountRepository.GetByFluConsentTemplateIds(templates.Select(x => x.Id));
            var list = new List<FluConsentTemplateViewModel>();

            foreach (var template in templates)
            {
                var healthPlanName = "N/A";
                var fluConsentHealthPlans = healthPlans.Where(x => x.FluConsentTemplateId == template.Id);
                if (!fluConsentHealthPlans.IsNullOrEmpty())
                    healthPlanName = string.Join(", ", fluConsentHealthPlans.Select(x => x.Name));

                list.Add(new FluConsentTemplateViewModel
                {
                    Id = template.Id,
                    Name = template.Name,
                    HealthPlan = healthPlanName,
                    IsActive = template.IsActive,
                    IsPublished = template.IsPublished
                });
            }

            return new FluConsentTemplateListModel
            {
                Collection = list,
                Filter = filter
            };
        }

        public FluConsentTemplateEditModel GetTemplateById(long templateId)
        {
            var questions = _fluConsentQuestionRepository.GetAllQuestions();

            var template = _fluConsentTemplateRepository.GetById(templateId);

            var selectedQuestionIds = _fluConsentQuestionRepository.GetQuestionIdsByTemplateId(templateId);

            var questionList = new List<FluConsentQuestionEditModel>();

            foreach (var question in questions)
            {
                var questionModel = new FluConsentQuestionEditModel
                {
                    QuestionId = question.Id,
                    ParentId = question.ParentId,
                    Index = question.Index,
                    Question = question.Question,
                    IsSelected = selectedQuestionIds.Contains(question.Id)
                };

                questionList.Add(questionModel);
            }

            return new FluConsentTemplateEditModel
            {
                Id = templateId,
                Name = template.Name,
                IsPublished = template.IsPublished,
                IsActive = template.IsActive,
                Questions = questionList.ToArray()
            };
        }

        public void Save(FluConsentTemplateEditModel model, long orgRoleUserId)
        {
            FluConsentTemplate domain;

            if (model.Id > 0)
            {
                domain = _fluConsentTemplateRepository.GetById(model.Id);

                domain.Name = model.Name;
                domain.IsPublished = model.IsPublished;
                domain.DateModified = DateTime.Now;
                domain.ModifiedBy = orgRoleUserId;
            }
            else
            {
                domain = new FluConsentTemplate
                {
                    Name = model.Name,
                    IsActive = true,
                    IsPublished = model.IsPublished,
                    DateCreated = DateTime.Now,
                    CreatedBy = orgRoleUserId
                };
            }

            domain = _fluConsentTemplateRepository.Save(domain);

            _fluConsentQuestionRepository.DeleteTemplateQuestions(model.Id);

            if (model.Questions != null)
            {
                var questions = model.Questions.Select(x => new FluConsentTemplateQuestion
                {
                    TemplateId = domain.Id,
                    QuestionId = x.QuestionId
                });

                _fluConsentQuestionRepository.SaveTemplateQuestions(questions);
            }
        }

        public bool SaveAnswers(FluVaccineConsentModel model, long orgRoleUserId)
        {
            var evenntCustomer = _eventCustomerRepository.GetById(model.EventCustomerId);
            if (evenntCustomer == null) return false;

            var signatureLocation = _mediaRepository.GetFluVaccineConsentSignatureLocation(evenntCustomer.EventId, evenntCustomer.CustomerId);

            var version = _fluConsentSignatureRepository.GetLatestVersion(model.EventCustomerId);

            var fluConsentSignature = new FluConsentSignature
            {
                EventCustomerId = model.EventCustomerId,
                Version = version,
                IsActive = true,
                CreatedBy = orgRoleUserId,
                DateCreated = DateTime.Now
            };

            var answers = new List<FluConsentAnswerModel>();
            if (!model.CustomerAnswers.IsNullOrEmpty())
            {
                answers.AddRange(model.CustomerAnswers);
            }

            if (!model.ClinicalAnswers.IsNullOrEmpty())
            {
                answers.AddRange(model.ClinicalAnswers);
            }

            if (!answers.IsNullOrEmpty())
            {
                var fluConsentAnswers = new List<FluConsentAnswer>();

                var answerVersion = _fluConsentAnswerRepository.GetLatestVersion(model.EventCustomerId);

                foreach (var answer in answers)
                {
                    var fluConsentAnswer = new FluConsentAnswer
                    {
                        EventCustomerId = model.EventCustomerId,
                        QuestionId = answer.QuestionId,
                        Answer = answer.Answer,
                        Version = answerVersion + 1,
                        IsActive = true,
                        DateCreated = DateTime.Now,
                        CreatedBy = orgRoleUserId
                    };

                    fluConsentAnswers.Add(fluConsentAnswer);
                }

                _fluConsentAnswerRepository.SaveAnswer(fluConsentAnswers);
            }

            if (!string.IsNullOrWhiteSpace(model.PatientSignatureBytes))
            {
                var fileName = "PatientSignature_" + Guid.NewGuid() + ".jpg";

                var patientImageFile = SaveSignatureImage(model.PatientSignatureBytes, orgRoleUserId, signatureLocation, fileName);

                fluConsentSignature.SignatureFileId = patientImageFile.Id;
                fluConsentSignature.ConsentSignedDate = DateTime.Now;
            }

            //If Clinical Provider Signature provided before Patient Signature, we will not save the consent data.
            if (!string.IsNullOrWhiteSpace(model.ClinicalProviderSignatureBytes))
            {
                var fileName = "ClinicalProviderSignature_" + Guid.NewGuid() + ".jpg";

                var clinicalProviderImageFile = SaveSignatureImage(model.ClinicalProviderSignatureBytes, orgRoleUserId, signatureLocation, fileName);

                fluConsentSignature.ClinicalProviderSignatureFileId = clinicalProviderImageFile.Id;
            }

            _fluConsentSignatureRepository.Save(fluConsentSignature);

            var consentQuestion = model.CustomerAnswers.FirstOrDefault(x => x.QuestionId == ReceiveVaccinationQuestionId);
            if (consentQuestion != null && consentQuestion.Answer.ToLower() == Boolean.TrueString.ToLower())
            {
                evenntCustomer.IsFluVaccineConsentSigned = true;
                _eventCustomerRepository.Save(evenntCustomer);
            }
            else
            {
                evenntCustomer.IsFluVaccineConsentSigned = false;
                _eventCustomerRepository.Save(evenntCustomer);
            }

            return true;
        }

        private Core.Application.Domain.File SaveSignatureImage(string signatureBytes, long orgRoleUserId, MediaLocation signatureLocation, string fileName)
        {
            var filePath = Path.Combine(signatureLocation.PhysicalPath, fileName);

            var imageBytes = Convert.FromBase64String(signatureBytes);

            File.WriteAllBytes(filePath, imageBytes);

            var fileInfo = new FileInfo(filePath);

            var file = new Core.Application.Domain.File
            {
                Path = fileName,
                FileSize = fileInfo.Length,
                Type = FileType.Image,
                UploadedBy = new OrganizationRoleUser(orgRoleUserId),
                UploadedOn = DateTime.Now
            };

            file = _fileRepository.Save(file);

            return file;
        }

        public FluVaccineConsentModel GetFluConsent(long eventCustomerId)
        {
            var fluConsentSignature = _fluConsentSignatureRepository.GetByEventCustomerId(eventCustomerId);

            if (fluConsentSignature == null) return new FluVaccineConsentModel { EventCustomerId = eventCustomerId };
            
            var fileIds = new Int64[2];

            fileIds[0] = fluConsentSignature.SignatureFileId;
            if (fluConsentSignature.ClinicalProviderSignatureFileId != null)
                fileIds[1] = (long)fluConsentSignature.ClinicalProviderSignatureFileId;

            var fileFeatch = _fileRepository.GetByIds(fileIds);

            if (fileFeatch == null)
            {
                return new FluVaccineConsentModel
                {
                    EventCustomerId = eventCustomerId,
                    ClinicalProviderSignatureBytes = null,
                    ClinicalAnswers = null,
                    CustomerAnswers = null,
                    PatientSignatureBytes = null,
                };
            }

            var fluConsentQuestionAllQuestion = _fluConsentQuestionRepository.GetAllQuestions();

            var CustomerQuestion = GetFluConsentQuestion(fluConsentQuestionAllQuestion, (long)FluConsentQuestionsType.CustomerQuestion);

            var ClinicalQuestion = GetFluConsentQuestion(fluConsentQuestionAllQuestion, (long)FluConsentQuestionsType.ClinicalQuestion);

            var fluConsentAnswers = _fluConsentAnswerRepository.GetByEventCustomerId(eventCustomerId);

            var fluConsentCustomerAnswerModel = GetFluConsentAnswer(fluConsentAnswers, CustomerQuestion);
            var fluConsentClinicalAnswerModel = GetFluConsentAnswer(fluConsentAnswers, ClinicalQuestion);

            var fluConsentSignatureFileName = fileFeatch.Where(x => x.Id == fluConsentSignature.SignatureFileId).Select(x => x.Path).SingleOrDefault();

            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            var mediaLocation = _mediaRepository.GetFluVaccineConsentSignatureLocation(eventCustomer.EventId, eventCustomer.CustomerId);

            var fluConsentSignatureFilePath = Path.Combine(mediaLocation.PhysicalPath, fluConsentSignatureFileName);

            string ClinicalProviderSignatureFileName = "";
            if (fluConsentSignature.ClinicalProviderSignatureFileId > default(long))
                ClinicalProviderSignatureFileName = fileFeatch.Where(x => x.Id == (long)fluConsentSignature.ClinicalProviderSignatureFileId).Select(x => x.Path).SingleOrDefault();

            var ClinicalProviderSignatureFilePath = Path.Combine(mediaLocation.PhysicalPath, ClinicalProviderSignatureFileName);

            var fluVaccineConsentModel = new FluVaccineConsentModel
            {
                EventCustomerId = eventCustomerId
            };

            if (File.Exists(fluConsentSignatureFilePath))
            {
                var fluConsentSignatureFileByte = File.ReadAllBytes(fluConsentSignatureFilePath);
                fluVaccineConsentModel.PatientSignatureBytes = Convert.ToBase64String(fluConsentSignatureFileByte);
            }
            if (File.Exists(ClinicalProviderSignatureFilePath))
            {
                var ClinicalProviderSignatureFileByte = File.ReadAllBytes(ClinicalProviderSignatureFilePath);
                fluVaccineConsentModel.ClinicalProviderSignatureBytes = Convert.ToBase64String(ClinicalProviderSignatureFileByte);
            }
            fluVaccineConsentModel.ClinicalAnswers = fluConsentClinicalAnswerModel;
            fluVaccineConsentModel.CustomerAnswers = fluConsentCustomerAnswerModel;

            return fluVaccineConsentModel;
        }

        public IEnumerable<FluConsentAnswerModel> GetFluConsentAnswer(IEnumerable<FluConsentAnswer> fluConsentAnswers, IEnumerable<long> fluConsentQuestion)
        {
            return fluConsentAnswers.Where(x => fluConsentQuestion.Contains((long)x.QuestionId))
                        .Select(x => new FluConsentAnswerModel { QuestionId = x.QuestionId, Answer = x.Answer }).ToArray();
        }


        public IEnumerable<long> GetFluConsentQuestion(IEnumerable<FluConsentQuestion> fluConsentQuestionAllQuestion, long QuestionsType)
        {
            return fluConsentQuestionAllQuestion.Where(x => x.FluConsentQuestionType == QuestionsType)
                       .Select(x => x.Id).ToArray();
        }

    }
}

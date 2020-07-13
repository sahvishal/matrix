using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using File = System.IO.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ChaperoneService : IChaperoneService
    {
        private readonly IChaperoneQuestionRepository _chaperoneQuestionRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IChaperoneSignatureRepository _chaperoneSignatureRepository;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly IChaperoneAnswerRepository _chaperoneAnswerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;

        public ChaperoneService(IChaperoneQuestionRepository chaperoneQuestionRepository, IEventCustomerRepository eventCustomerRepository,
            IMediaRepository mediaRepository, IChaperoneSignatureRepository chaperoneSignatureRepository, IUniqueItemRepository<Core.Application.Domain.File> fileRepository,
            IChaperoneAnswerRepository chaperoneAnswerRepository, ICustomerRepository customerRepository, IEventRepository eventRepository)
        {
            _chaperoneQuestionRepository = chaperoneQuestionRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _mediaRepository = mediaRepository;
            _chaperoneSignatureRepository = chaperoneSignatureRepository;
            _fileRepository = fileRepository;
            _chaperoneAnswerRepository = chaperoneAnswerRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
        }

        public ChaperoneFormModel GetChaperoneFormModel(long eventCustomerId)
        {
            var chaperoneSignature = _chaperoneSignatureRepository.GetByEventCustomerId(eventCustomerId);

            var staffSignatureFile = chaperoneSignature != null ? _fileRepository.GetById(chaperoneSignature.StaffSignatureFileId) : null;

            if (staffSignatureFile == null)
            {
                return new ChaperoneFormModel
                {
                    EventCustomerId = eventCustomerId,
                    CustomerAnswers = null,
                    PatientSignatureBytes = null,
                };
            }

            var chaperoneQuestions = _chaperoneQuestionRepository.GetAllQuestions();

            var chaperoneAnswers = _chaperoneAnswerRepository.GetByEventCustomerId(eventCustomerId);
            
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);

            var mediaLocation = _mediaRepository.GetChaperoneSignatureLocation(eventCustomer.EventId, eventCustomer.CustomerId);

            string signatureFilePath = string.Empty;

            var signatureFile = chaperoneSignature != null && chaperoneSignature.SignatureFileId.HasValue ? _fileRepository.GetById(chaperoneSignature.SignatureFileId.Value) : null;
            if (signatureFile != null)
                signatureFilePath = Path.Combine(mediaLocation.PhysicalPath, signatureFile.Path);

            var staffSignatureFilePath = Path.Combine(mediaLocation.PhysicalPath, staffSignatureFile.Path);

            var chaperoneFormModel = new ChaperoneFormModel();
            chaperoneFormModel.EventCustomerId = eventCustomerId;
            chaperoneFormModel.CustomerAnswers = chaperoneAnswers
                                                .Select(x => new ChaperoneAnswerModel
                                                {
                                                    QuestionId = x.QuestionId,
                                                    Answer = x.Answer
                                                })
                                                .ToArray();

            if (!string.IsNullOrEmpty(signatureFilePath) && File.Exists(signatureFilePath))
            {
                var signatureFileByte = File.ReadAllBytes(signatureFilePath);
                chaperoneFormModel.PatientSignatureBytes = Convert.ToBase64String(signatureFileByte);
            }

            if (File.Exists(staffSignatureFilePath))
            {
                var staffSignatureFileByte = File.ReadAllBytes(staffSignatureFilePath);
                chaperoneFormModel.StaffSignatureBytes = Convert.ToBase64String(staffSignatureFileByte);
            }

            return chaperoneFormModel;
        }

        public bool SaveAnswers(ChaperoneFormModel model, long orgRoleUserId)
        {
            var evenntCustomer = _eventCustomerRepository.GetById(model.EventCustomerId);
            if (evenntCustomer == null) return false;

            var signatureLocation = _mediaRepository.GetChaperoneSignatureLocation(evenntCustomer.EventId, evenntCustomer.CustomerId);

            var version = _chaperoneSignatureRepository.GetLatestVersion(model.EventCustomerId);

            var answers = new List<ChaperoneAnswerModel>();
            if (!model.CustomerAnswers.IsNullOrEmpty())
            {
                answers.AddRange(model.CustomerAnswers);
            }

            if (!answers.IsNullOrEmpty())
            {
                var chaperoneAnswers = new List<ChaperoneAnswer>();

                var answerVersion = _chaperoneAnswerRepository.GetLatestVersion(model.EventCustomerId);

                foreach (var answer in answers)
                {
                    var chaperoneAnswer = new ChaperoneAnswer
                    {
                        EventCustomerId = model.EventCustomerId,
                        QuestionId = answer.QuestionId,
                        Answer = answer.Answer,
                        Version = answerVersion + 1,
                        IsActive = true,
                        DateCreated = DateTime.Now,
                        CreatedBy = orgRoleUserId
                    };

                    chaperoneAnswers.Add(chaperoneAnswer);
                }

                _chaperoneAnswerRepository.SaveAnswer(chaperoneAnswers);
            }

            var chaperoneSignature = new ChaperoneSignature
            {
                EventCustomerId = model.EventCustomerId,
                Version = version,
                IsActive = true,
                CreatedBy = orgRoleUserId,
                DateCreated = DateTime.Now
            };

            if (!string.IsNullOrWhiteSpace(model.PatientSignatureBytes))
            {
                var fileName = "PatientSignature_" + Guid.NewGuid() + ".jpg";

                var patientImageFile = SaveSignatureImage(model.PatientSignatureBytes, orgRoleUserId, signatureLocation, fileName);

                chaperoneSignature.SignatureFileId = patientImageFile.Id;
            }
           
            

            if (!string.IsNullOrWhiteSpace(model.StaffSignatureBytes))
            {
                var fileName = "StaffSignature_" + Guid.NewGuid() + ".jpg";

                var patientImageFile = SaveSignatureImage(model.StaffSignatureBytes, orgRoleUserId, signatureLocation, fileName);

                chaperoneSignature.StaffSignatureFileId = patientImageFile.Id;
            }
           

            _chaperoneSignatureRepository.Save(chaperoneSignature);

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

        public ChaperoneFormViewModel GetModel(long eventId, long customerId)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            if (eventCustomer == null)
            {
                return new ChaperoneFormViewModel();
            }

            var customer = _customerRepository.GetCustomer(customerId);
            var answers = _chaperoneAnswerRepository.GetByEventCustomerId(eventCustomer.Id);
            var questions = _chaperoneQuestionRepository.GetAllQuestions();
            var signature = _chaperoneSignatureRepository.GetByEventCustomerId(eventCustomer.Id);
            var eventData = _eventRepository.GetById(eventId);

            var signatureFile = signature != null && signature.SignatureFileId.HasValue ? _fileRepository.GetById(signature.SignatureFileId.Value) : null;
            var staffSignatureFile = signature != null ? _fileRepository.GetById(signature.StaffSignatureFileId) : null;

            var model = new ChaperoneFormViewModel();
            model.CustomerName = customer.Name;
            model.CustomerId = customer.CustomerId;
            model.DateofBirth = customer.DateOfBirth;
            model.EventDate = eventData.EventDate;

            var questionAnswers = new List<ChaperoneQuestionAnswerViewModel>();
            if (!answers.IsNullOrEmpty())
            {
                foreach (var answer in answers)
                {
                    var question = questions.First(x => x.Id == answer.QuestionId);
                    var questionAnswer = new ChaperoneQuestionAnswerViewModel
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

            if (signatureFile != null)
            {
                var mediaLocation = _mediaRepository.GetChaperoneSignatureLocation(eventId, customerId);
                model.SignatureImageUrl = mediaLocation.Url + signatureFile.Path;
            }

            if (staffSignatureFile != null)
            {
                var mediaLocation = _mediaRepository.GetChaperoneSignatureLocation(eventId, customerId);
                model.StaffSignatureImageUrl = mediaLocation.Url + staffSignatureFile.Path;
            }

            return model;
        }
    }
}

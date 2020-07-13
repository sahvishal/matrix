using System;
using System.IO;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = System.IO.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ParticipationConsentService : IParticipationConsentService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly IParticipationConsentSignatureRepository _participationConsentSignatureRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;

        public ParticipationConsentService(IEventCustomerRepository eventCustomerRepository, IMediaRepository mediaRepository, IUniqueItemRepository<Core.Application.Domain.File> fileRepository,
            IParticipationConsentSignatureRepository participationConsentSignatureRepository, IEventRepository eventRepository, ICustomerRepository customerRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _participationConsentSignatureRepository = participationConsentSignatureRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
        }

        public bool Save(ParticipationConsentSignatureModel model, long orgRoleUserId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(model.EventCustomerId);
            if (eventCustomer == null) return false;

            var signatureLocation = _mediaRepository.GetParticipationConsentSignatureLocation(eventCustomer.EventId, eventCustomer.CustomerId);

            var version = _participationConsentSignatureRepository.GetLatestVersion(model.EventCustomerId);

            var participationConsentSignature = new ParticipationConsentSignature()
            {
                EventCustomerId = model.EventCustomerId,
                Version = version,
                IsActive = true,
                CreatedBy = orgRoleUserId,
                DateCreated = DateTime.Now
            };

            if (!string.IsNullOrWhiteSpace(model.SignatureBytes))
            {
                var fileName = "Signature_" + Guid.NewGuid() + ".jpg";

                var signatureImageFile = SaveSignatureImage(model.SignatureBytes, orgRoleUserId, signatureLocation, fileName);

                participationConsentSignature.SignatureFileId = signatureImageFile.Id;
                participationConsentSignature.ConsentSignedDate = DateTime.Now;
            }

            if (!string.IsNullOrWhiteSpace(model.InsuranceSignatureBytes))
            {
                var fileName = "InsuranceSignature_" + Guid.NewGuid() + ".jpg";

                var technicianImageFile = SaveSignatureImage(model.InsuranceSignatureBytes, orgRoleUserId, signatureLocation, fileName);

                participationConsentSignature.InsuranceSignatureFileId = technicianImageFile.Id;
                participationConsentSignature.InsuranceConsentSignedDate = DateTime.Now;
            }

            _participationConsentSignatureRepository.Save(participationConsentSignature);

            if (participationConsentSignature.SignatureFileId > 0 && participationConsentSignature.InsuranceSignatureFileId > 0)
            {
                eventCustomer.HIPAAStatus = RegulatoryState.Signed;
                eventCustomer.IsParticipationConsentSigned = true;

                _eventCustomerRepository.Save(eventCustomer);
            }
            else
            {

                eventCustomer.IsParticipationConsentSigned = false;
                _eventCustomerRepository.Save(eventCustomer);
            }

            return true;
        }

        private Core.Application.Domain.File SaveSignatureImage(string signatureBytes, long orgRoleUserId, MediaLocation signatureLocation,
            string fileName)
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

        public HealthAssessmentHeaderEditModel GetModel(long eventId, long customerId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            var physicianName = string.Empty;
            if (pcp != null && pcp.Name != null)
            {
                physicianName = pcp.Name.FullName;
            }

            var participationConsent = new ParticipationConsentModel();
            var participationConsentMediaLocation = _mediaRepository.GetParticipationConsentSignatureLocation(eventId, customerId);
            var participationConsentSignature = _participationConsentSignatureRepository.GetByEventCustomerId(eventCustomer.Id);
            if (participationConsentSignature != null)
            {
                var signatureFileIds = new[] { participationConsentSignature.SignatureFileId, participationConsentSignature.InsuranceSignatureFileId };
                var signatureFiles = _fileRepository.GetByIds(signatureFileIds);

                var participationSignatreFile = signatureFiles.First(x => x.Id == participationConsentSignature.SignatureFileId);
                participationConsent.SignatureImageUrl = participationConsentMediaLocation.Url + participationSignatreFile.Path;
                participationConsent.ConsentSignedDate = participationConsentSignature.ConsentSignedDate.ToString("MM/dd/yyyy");

                var insuranceSignatureFile = signatureFiles.First(x => x.Id == participationConsentSignature.InsuranceSignatureFileId);
                participationConsent.InsuranceSignatureImageUrl = participationConsentMediaLocation.Url + insuranceSignatureFile.Path;
                participationConsent.InsuranceConsentSignedDate = participationConsentSignature.InsuranceConsentSignedDate.ToString("MM/dd/yyyy");
            }

            return new HealthAssessmentHeaderEditModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                DateofBirth = customer.DateOfBirth,
                EventDate = eventData.EventDate,
                EventId = eventData.Id,
                PhysicianName = physicianName,
                ParticipationConsent = participationConsent
            };
        }

        public ParticipationConsentSignatureModel GetParticipationConsentSignature(long eventCustomerId)
        {
            var participationConsentSignature = _participationConsentSignatureRepository.GetByEventCustomerId(eventCustomerId);

            if (participationConsentSignature == null)
            {
                return new ParticipationConsentSignatureModel
                {
                    EventCustomerId = eventCustomerId,
                    InsuranceSignatureBytes = null,
                    SignatureBytes = null,

                };
            }

            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            var signatureFile = _fileRepository.GetById(participationConsentSignature.SignatureFileId);
            var insuranceSignatureFile = _fileRepository.GetById(participationConsentSignature.InsuranceSignatureFileId);

            var signatureFileName = signatureFile.Path;
            var insuranceSignatureFileName = insuranceSignatureFile.Path;
            var mediaLocation = _mediaRepository.GetParticipationConsentSignatureLocation(eventCustomer.EventId, eventCustomer.CustomerId);
            var signatureFilePath = Path.Combine(mediaLocation.PhysicalPath, signatureFileName);
            var insuranceSignatureFilePath = Path.Combine(mediaLocation.PhysicalPath, insuranceSignatureFileName);
            var participationConsentSignatureModel = new ParticipationConsentSignatureModel
            {
                EventCustomerId = eventCustomerId
            };
            if (File.Exists(signatureFilePath))
            {
                var FileByte = File.ReadAllBytes(signatureFilePath);
                participationConsentSignatureModel.SignatureBytes = Convert.ToBase64String(FileByte);
            }
            if (File.Exists(insuranceSignatureFilePath))
            {
                var FileByte = File.ReadAllBytes(insuranceSignatureFilePath);
                participationConsentSignatureModel.InsuranceSignatureBytes = Convert.ToBase64String(FileByte);
            }


            return participationConsentSignatureModel;

        }
    }
}

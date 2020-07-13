using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = System.IO.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PhysicianRecordRequestService : IPhysicianRecordRequestService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly IPhysicianRecordRequestSignatureRepository _physicianRecordRequestSignatureRepository;

        public PhysicianRecordRequestService(IEventCustomerRepository eventCustomerRepository, IMediaRepository mediaRepository, IUniqueItemRepository<Core.Application.Domain.File> fileRepository,
            IPhysicianRecordRequestSignatureRepository physicianRecordRequestSignatureRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _physicianRecordRequestSignatureRepository = physicianRecordRequestSignatureRepository;
        }

        public bool Save(PhysicianRecordRequestSignatureModel model, long orgRoleUserId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(model.EventCustomerId);
            if (eventCustomer == null) return false;

            var signatureLocation = _mediaRepository.GetPhysicianRecordRequestSignatureLocation(eventCustomer.EventId, eventCustomer.CustomerId);

            var version = _physicianRecordRequestSignatureRepository.GetLatestVersion(model.EventCustomerId);

            var physicianRecordRequestSignature = new PhysicianRecordRequestSignature
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

                var patientImageFile = SaveSignatureImage(model, orgRoleUserId, signatureLocation, fileName);

                physicianRecordRequestSignature.SignatureFileId = patientImageFile.Id;
                physicianRecordRequestSignature.ConsentSignedDate = DateTime.Now;
            }

            _physicianRecordRequestSignatureRepository.Save(physicianRecordRequestSignature);

            if (physicianRecordRequestSignature.SignatureFileId > 0)
            {
                eventCustomer.PcpConsentStatus = RegulatoryState.Signed;
                eventCustomer.IsPhysicianRecordRequestSigned = true;

                _eventCustomerRepository.Save(eventCustomer);
            }
            else
            {

                eventCustomer.IsPhysicianRecordRequestSigned = false;
                _eventCustomerRepository.Save(eventCustomer);
            }

            return true;
        }

        private Core.Application.Domain.File SaveSignatureImage(PhysicianRecordRequestSignatureModel model, long orgRoleUserId, MediaLocation signatureLocation, string fileName)
        {
            var filePath = Path.Combine(signatureLocation.PhysicalPath, fileName);

            var imageBytes = Convert.FromBase64String(model.SignatureBytes);

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

        public PhysicianRecordRequestSignatureModel GetPhysicianRecordRequestSignature(long eventCustomerId)
        {
            var physicianRecordRequest = _physicianRecordRequestSignatureRepository.GetByEventCustomerId(eventCustomerId);

            var file = physicianRecordRequest != null ? _fileRepository.GetById(physicianRecordRequest.SignatureFileId) : null;

            if (file == null)
            {
                return new PhysicianRecordRequestSignatureModel
                {
                    EventCustomerId = eventCustomerId,
                    SignatureBytes = null
                };
            }

            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            var filename = file.Path;
            var signatureLocation = _mediaRepository.GetPhysicianRecordRequestSignatureLocation(eventCustomer.EventId, eventCustomer.CustomerId);
            var filePath = Path.Combine(signatureLocation.PhysicalPath, filename);

            var physicianRecordRequestSignatureModel = new PhysicianRecordRequestSignatureModel
            {
                EventCustomerId = eventCustomerId
            };

            var signatureBytes = string.Empty;
            if (File.Exists(filePath))
            {
                var bytes = File.ReadAllBytes(filePath);
                signatureBytes = Convert.ToBase64String(bytes);
            }

            physicianRecordRequestSignatureModel.SignatureBytes = signatureBytes;

            return physicianRecordRequestSignatureModel;
        }
    }
}

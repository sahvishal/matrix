using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = System.IO.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class GiftCardService : IGiftCardService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly IEventCustomerGiftCardRepository _eventCustomerGiftCardRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public GiftCardService(IEventCustomerRepository eventCustomerRepository, IMediaRepository mediaRepository, IUniqueItemRepository<Core.Application.Domain.File> fileRepository,
            IEventCustomerGiftCardRepository eventCustomerGiftCardRepository, IEventRepository eventRepository, ICustomerRepository customerRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _eventCustomerGiftCardRepository = eventCustomerGiftCardRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public bool Save(GiftCertificateSignatureModel model, long orgRoleUserId)
        {
            var evenntCustomer = _eventCustomerRepository.GetById(model.EventCustomerId);
            if (evenntCustomer == null) return false;

            var signatureLocation = _mediaRepository.GetGiftCardSignatureLocation(evenntCustomer.EventId,
                evenntCustomer.CustomerId);

            var version = _eventCustomerGiftCardRepository.GetLatestVersion(model.EventCustomerId);

            var giftCardSignature = new EventCustomerGiftCard()
            {
                EventCustomerId = model.EventCustomerId,
                GiftCardReceived = model.GiftCardReceived,
                Version = version,
                IsActive = true,
                CreatedBy = orgRoleUserId,
                DateCreated = DateTime.Now
            };

            if (!string.IsNullOrWhiteSpace(model.PatientSignatureBytes))
            {
                var fileName = "PatientSignature_GiftCard_" + Guid.NewGuid() + ".jpg";

                var patientImageFile = SaveSignatureImage(model.PatientSignatureBytes, orgRoleUserId, signatureLocation, fileName);

                giftCardSignature.PatientSignatureFileId = patientImageFile.Id;
            }

            if (!string.IsNullOrWhiteSpace(model.TechnicianSignatureBytes))
            {
                var fileName = "TechnicianSignature_GiftCard_" + Guid.NewGuid() + ".jpg";

                var technicianImageFile = SaveSignatureImage(model.TechnicianSignatureBytes, orgRoleUserId, signatureLocation, fileName);

                giftCardSignature.TechnicianSignatureFileId = technicianImageFile.Id;
            }

            _eventCustomerGiftCardRepository.Save(giftCardSignature);

            if (model.GiftCardReceived)
            {
                evenntCustomer.IsGiftCertificateDelivered = true;
                evenntCustomer.GiftCode = model.GiftCardNumber;
                _eventCustomerRepository.Save(evenntCustomer);
            }
            else
            {
                if (model.GcNotGivenReasonId != null && model.GcNotGivenReasonId > 0)
                {
                    evenntCustomer.GcNotGivenReasonId = model.GcNotGivenReasonId;
                    evenntCustomer.IsGiftCertificateDelivered = false;
                    _eventCustomerRepository.Save(evenntCustomer);
                }
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

        public GiftCertificateViewModel GetModel(long eventId, long customerId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var account = _corporateAccountRepository.GetbyEventId(eventId);

            var patientGiftCardSignatureUrl = string.Empty;
            var technicianGiftCardSignatureUrl = string.Empty;
            var giftCardSignatureMediaLocation = _mediaRepository.GetGiftCardSignatureLocation(eventId, customerId);
            var giftCertificateSignature = _eventCustomerGiftCardRepository.GetByEventCustomerId(eventCustomer.Id);
            if (giftCertificateSignature != null && (giftCertificateSignature.PatientSignatureFileId.HasValue || giftCertificateSignature.TechnicianSignatureFileId.HasValue))
            {
                var signatureFileIds = new List<long>();
                if (giftCertificateSignature.PatientSignatureFileId.HasValue)
                    signatureFileIds.Add(giftCertificateSignature.PatientSignatureFileId.Value);
                if (giftCertificateSignature.TechnicianSignatureFileId.HasValue)
                    signatureFileIds.Add(giftCertificateSignature.TechnicianSignatureFileId.Value);

                var signatureFiles = _fileRepository.GetByIds(signatureFileIds);
                if (giftCertificateSignature.PatientSignatureFileId.HasValue)
                {
                    var patientFile = signatureFiles.First(x => x.Id == giftCertificateSignature.PatientSignatureFileId.Value);
                    patientGiftCardSignatureUrl = giftCardSignatureMediaLocation.Url + patientFile.Path;
                }
                if (giftCertificateSignature.TechnicianSignatureFileId.HasValue)
                {
                    var technicianFile = signatureFiles.First(x => x.Id == giftCertificateSignature.TechnicianSignatureFileId.Value);
                    technicianGiftCardSignatureUrl = giftCardSignatureMediaLocation.Url + technicianFile.Path;
                }
            }

            return new GiftCertificateViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                EventDate = eventData.EventDate,
                GiftAmmount = account.GiftCardAmount ?? 0,
                GiftCardReceived = giftCertificateSignature != null ? giftCertificateSignature.GiftCardReceived : (bool?)null,
                PatientSignatureUrl = patientGiftCardSignatureUrl,
                TechnicianSignatureUrl = technicianGiftCardSignatureUrl
            };
        }
    }
}

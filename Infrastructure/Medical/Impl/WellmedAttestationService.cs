using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;
using IoFile = System.IO.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class WellmedAttestationService : IWellmedAttestationService
    {
        private readonly IWellMedAttestationRepository _wellMedAttestationRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;

        public WellmedAttestationService(IWellMedAttestationRepository wellMedAttestationRepository, IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository)
        {
            _wellMedAttestationRepository = wellMedAttestationRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
        }

        public void Save(WellMedAttestationListModel model)
        {
            var attestations = new List<WellMedAttestation>();
            foreach (var wellMedAttestation in model.Attestations)
            {
                var attestation = Mapper.Map<WellMedAttestationViewModel, WellMedAttestation>(wellMedAttestation);
                var file = GetFileFromFileModel(wellMedAttestation.ProviderSignatureImage, _mediaRepository.GetWellMedAttestationImageFolderLocation(), FileType.Image);
                if (file != null)
                {
                    file = _fileRepository.Save(file);
                    attestation.ProviderSignatureFileId = file.Id;
                }
                attestations.Add(attestation);
            }
            _wellMedAttestationRepository.Save(attestations);
        }
        public bool Save(WellMedAttestationViewModel wellMedAttestation)
        {
            try
            {
                var attestations = new List<WellMedAttestation>();

                var attestation = Mapper.Map<WellMedAttestationViewModel, WellMedAttestation>(wellMedAttestation);
                var file = wellMedAttestation.ProviderSignatureImage != null
                    ? GetFileFromFileModel(wellMedAttestation.ProviderSignatureImage, _mediaRepository.GetWellMedAttestationImageFolderLocation(), FileType.Image)
                    : null;
                if (wellMedAttestation.ProviderSignatureImage != null && !string.IsNullOrEmpty(wellMedAttestation.ProviderSignatureImage.FileName))
                {
                    if (file != null)
                    {
                        file = _fileRepository.Save(file);
                        attestation.ProviderSignatureFileId = file.Id;
                    }
                }
                else
                {
                    attestation.ProviderSignatureFileId = null;
                }
                if (attestation.StatusId == 0)
                {
                    attestation.StatusId = null;
                }

                attestations.Add(attestation);

                _wellMedAttestationRepository.Save(attestations);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long eventCustomerResultId)
        {
            _wellMedAttestationRepository.Delete(eventCustomerResultId);
        }

        public IEnumerable<WellMedAttestationViewModel> GetbyEventCustumerResultId(long eventCustomerResultId)
        {
            var attestations = _wellMedAttestationRepository.GetbyEventCustumerResultId(eventCustomerResultId);
            if (attestations == null) return null;
            var attestationViewModels = new List<WellMedAttestationViewModel>();
            foreach (var wellMedAttestation in attestations)
            {
                var model = Mapper.Map<WellMedAttestation, WellMedAttestationViewModel>(wellMedAttestation);
                File signatureFile = null;
                if (wellMedAttestation.ProviderSignatureFileId.HasValue && wellMedAttestation.ProviderSignatureFileId > 0)
                    signatureFile = _fileRepository.GetById(wellMedAttestation.ProviderSignatureFileId.Value);

                model.ProviderSignatureImage = GetFileModelFromFile(signatureFile, _mediaRepository.GetWellMedAttestationImageFolderLocation());
                attestationViewModels.Add(model);
            }
            return attestationViewModels;
        }

        private FileModel GetFileModelFromFile(File file, MediaLocation location)
        {
            return file == null ? new FileModel() : new FileModel
            {
                Id = file.Id,
                Caption = Path.GetFileNameWithoutExtension(file.Path),
                FileName = file.Path,
                FileSize = file.FileSize,
                FileType = (long)file.Type,
                PhisicalPath = file.Path,
                UploadedBy = file.UploadedBy.Id,
                Url = location.Url
            };
        }

        private File GetFileFromFileModel(FileModel model, MediaLocation location, FileType mediaType)
        {
            var fileLocation = location.PhysicalPath + model.Caption + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(model.FileName);
            var file = new File
            {
                Id = model.Id,
                FileSize = model.FileSize,
                Path = model.IsTemporaryLocated ? model.Caption + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(model.FileName) : model.PhisicalPath,
                Type = mediaType,
                UploadedOn = DateTime.Now,
                UploadedBy = new OrganizationRoleUser(model.UploadedBy)
            };

            if (model.IsTemporaryLocated)
            {
                IoFile.Copy(model.FolderPath + model.FileName, fileLocation);
            }

            return file;
        }


    }
}

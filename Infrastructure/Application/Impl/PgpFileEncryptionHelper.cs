using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Exception = System.Exception;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class PgpFileEncryptionHelper : IPgpFileEncryptionHelper
    {
        private readonly IPgpFileEncryption _pgpFileEncryption;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger _logger;
        private readonly bool _deleteFileAfterEncryption;
        public PgpFileEncryptionHelper(IPgpFileEncryption pgpFileEncryption, IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, ISettings settings, ILogManager logManager)
        {
            _pgpFileEncryption = pgpFileEncryption;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _deleteFileAfterEncryption = settings.DeleteFileAfterPgpEcnryption;

            _logger = logManager.GetLogger<PgpFileEncryptionHelper>();
        }

        public string EncryptFile(CorporateAccount account, string sourcePath)
        {
            try
            {
                if (account.EnablePgpEncryption && account.PublicKeyFileId > 0)
                {
                    var publicKeyFile = string.Empty;
                    if (account.EnablePgpEncryption && account.PublicKeyFileId > 0)
                    {
                        File pgpPublicKey = _fileRepository.GetById(account.PublicKeyFileId);
                        publicKeyFile = GetPublicKeyFile(pgpPublicKey, _mediaRepository.GetPublicKeyFolderLocation());
                    }

                    if (System.IO.File.Exists(publicKeyFile))
                    {
                        var encryptedFileName = sourcePath + ".pgp";
                        if (System.IO.File.Exists(encryptedFileName))
                            System.IO.File.Delete(encryptedFileName);

                        _pgpFileEncryption.EncryptFile(encryptedFileName, sourcePath, publicKeyFile);

                        if (_deleteFileAfterEncryption)
                        {
                            System.IO.File.Delete(sourcePath);
                        }

                        sourcePath = encryptedFileName;
                        _logger.Info("pgp encryption done For file Path : " + sourcePath);
                    }
                    else
                    {
                        _logger.Info("No pgp file found for the account Id: " + account.Id);
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format(" Some Error Occure while encryptiong file {0}", sourcePath));
                _logger.Error(string.Format(" Message:{0} stack trace: {1}", exception.Message, exception.StackTrace));
            }
            return sourcePath;
        }
        private string GetPublicKeyFile(File file, MediaLocation location)
        {
            return location.PhysicalPath + file.Path;
        }
    }
}
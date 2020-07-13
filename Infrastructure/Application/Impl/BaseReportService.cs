using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Application.Impl
{

    [DefaultImplementation]
    public class BaseReportService : IBaseReportService
    {
        private readonly IZipHelper _zipHelper;
        private readonly ILoginSettingRepository _loginSettingRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository<User> _userRepository;

        public BaseReportService(IZipHelper zipHelper, ILoginSettingRepository loginSettingRepository,
            IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IUserRepository<User> userRepository)
        {
            _zipHelper = zipHelper;
            _loginSettingRepository = loginSettingRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }


        public string DownloadZipFile(MediaLocation mediaLocation, string csvfileName, long userId, ILogger logger)
        {
            var csvFilePath = mediaLocation.PhysicalPath + csvfileName;
            var fileName = string.Empty;
            try
            {

                var isPinRequired = false;
                var user = _userRepository.GetUser(userId);
                var orgRoles = _organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(userId);
                var defaultRole = orgRoles.FirstOrDefault(oru => oru.RoleId == (long)user.DefaultRole);
                if (defaultRole != null)
                {
                    Role role = _roleRepository.GetByRoleId(defaultRole.RoleId);
                    isPinRequired = role.IsPinRequired;
                }
                var password = "";
                if (isPinRequired)
                {
                    var userSetting = _loginSettingRepository.Get(userId);
                    if (userSetting != null)
                        password = userSetting.DownloadFilePin;
                }

                string zipFilePath = _zipHelper.CreateZipOfSingleFile(csvFilePath, password);

                fileName = Path.GetFileName(zipFilePath);
                if (fileName == null || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    throw new InvalidFileNameException();
                }
            }
            finally
            {
                try
                {
                    DirectoryOperationsHelper.Delete(csvFilePath);
                }
                catch (Exception ex)
                {
                    logger.Error("exception Message : " + ex.Message + " Stack Trace :" + ex.StackTrace);
                }
            }

            return fileName;
        }

        public bool GetResponse(GenericReportRequest request, bool append = false)
        {
            using (var streamWriter = new StreamWriter(request.CsvFilePath, append))
            {
                streamWriter.Write(request.Model);
                streamWriter.Close();
            }

            return true;
        }
    }
}

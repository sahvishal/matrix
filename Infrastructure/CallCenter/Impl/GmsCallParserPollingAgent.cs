using System;
using System.Data;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class GmsCallParserPollingAgent : IGmsCallParserPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly bool _isDevEnvironment;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly IGmsCallParserHelper _gmsCallParserHelper;
        private readonly ICallUploadService _callUploadService;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public GmsCallParserPollingAgent(ISettings settings, ILogManager logManager, IMediaRepository mediaRepository, ICsvReader csvReader, IGmsCallParserHelper gmsCallParserHelper, ICallUploadService callUploadService, IUserLoginRepository userLoginRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _settings = settings;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _gmsCallParserHelper = gmsCallParserHelper;
            _callUploadService = callUploadService;
            _userLoginRepository = userLoginRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("GMSDialerParsing");

        }

        public void PollForCallParsing()
        {
            try
            {
                _logger.Info("Entering In GMS Dialer Parsing ");
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || (timeOfDay.TimeOfDay < new TimeSpan(1, 0, 0)) || (timeOfDay.TimeOfDay > new TimeSpan(2, 0, 0)))
                {
                    //Check for file
                    _logger.Info("Getting files");

                    var sourceLocation = _settings.GmsDialerFilePath;
                    var dialerFiles = DirectoryOperationsHelper.GetFiles(sourceLocation, "*.csv");
                    if (dialerFiles.IsNullOrEmpty())
                    {
                        _logger.Info("No dialer file found at " + sourceLocation);
                        return;
                    }

                    //move file to media location
                    var mediaLocation = _mediaRepository.GetGMSDialerMediaFileLocation();
                    var archiveMediaLoation = _mediaRepository.GetGMSDialerArchiveMediaLocation();
                    foreach (var dialerFile in dialerFiles)
                    {
                        var fileInfo = new FileInfo(dialerFile);

                        DirectoryOperationsHelper.Move(dialerFile, mediaLocation.PhysicalPath + fileInfo.Name);
                    }

                    long orgRoleUserId = 1;

                    var gmsUser = _userLoginRepository.GetByUserName(_settings.GmsUserName);
                    if (gmsUser != null)
                    {
                        var organizationRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUsermodel(gmsUser.Id, (long)Roles.CallCenterRep);
                        if (organizationRoleUser != null)
                            orgRoleUserId = organizationRoleUser.OrganizationRoleUserId;
                    }

                    //parse file
                    var files = DirectoryOperationsHelper.GetFiles(mediaLocation.PhysicalPath, "*.csv");
                    foreach (var file in files)
                    {
                        try
                        {
                            var fileInfo = new FileInfo(file);

                            var callTable = _csvReader.ReadWithTextQualifier(file);
                            if (callTable.Rows.Count == 0)
                            {
                                _logger.Info(string.Format("No data for file FileName:{0}.", file));
                                return;
                            }

                            var missingColumnNames = _gmsCallParserHelper.CheckForColumns(callTable.Rows[0]);
                            if (!string.IsNullOrEmpty(missingColumnNames))
                            {
                                _logger.Info(string.Format("Invalid file FileName:{0}. Missing headers: {1}", file, missingColumnNames));
                                return;
                            }

                            foreach (DataRow row in callTable.Rows)
                            {
                                var model = _gmsCallParserHelper.GetGmsDialerCallModel(row);
                                try
                                {
                                    _callUploadService.SaveGmsDialerCall(model, orgRoleUserId, _logger);
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error(string.Format("Error for Customer Id: {0} in file: {1}. Message: {2}. \n Stack Trace{3}", model.CustomerId, fileInfo.Name, ex.Message, ex.StackTrace));
                                }

                            }

                            //move to archive location
                            DirectoryOperationsHelper.Move(file, archiveMediaLoation.PhysicalPath + fileInfo.Name);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Error for file {0}. Message: {1} \n Stack Trace : {2}", file, ex.Message, ex.StackTrace));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error("GMSDialerParsing Exception Message: " + ex.Message + "\n Stack Trace:" + ex.StackTrace);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using StackExchange.Redis;

namespace Falcon.App.UI.Controllers
{
    public class BaseReportsController : AsyncController
    {
        private readonly IZipHelper _zipHelper;
        private readonly ILogger _logger;
        private readonly ISessionContext _sessionContext;
        private readonly ILoginSettingRepository _loginSettingRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository<User> _userRepository;

        //private readonly string _host;
        private readonly int _redisDatabaseKey;
        const int WaitForSeconds = 450; //seven and half 
        //private ConnectionMultiplexer _redis;
        //private ConnectionMultiplexer ConnectionMultiplexer
        //{
        //    get
        //    {
        //        if (_redis == null || !_redis.IsConnected)
        //        {
        //            var config = ConfigurationOptions.Parse(_host);
        //            config.KeepAlive = WaitForSeconds;
        //            //config.ConnectTimeout = 5000;
        //            _redis = ConnectionMultiplexer.Connect(config);
        //        }
        //        return _redis;
        //    }
        //}

        public BaseReportsController(IZipHelper zipHelper, ILogManager logManager, ISessionContext sessionContext, ILoginSettingRepository loginSettingRepository,
            IRoleRepository roleRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IUserRepository<User> userRepository, ISettings settings)
        {
            _zipHelper = zipHelper;
            _logger = logManager.GetLogger<Global>();
            _sessionContext = sessionContext;
            _loginSettingRepository = loginSettingRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            //_host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
        }

        protected void DownloadZipFile(MediaLocation mediaLocation, string csvfileName)
        {
            var csvFilePath = mediaLocation.PhysicalPath + csvfileName;

            var response = Response;
            try
            {
                if (_sessionContext == null || _sessionContext.UserSession == null)
                {
                    _logger.Error("User Session is null while downloading report file: " + csvFilePath);
                    throw new Exception();
                }

                var userId = _sessionContext.UserSession.UserId;
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

                var zipFilePath = _zipHelper.CreateZipOfSingleFile(csvFilePath, password);

                var fileName = Path.GetFileName(zipFilePath);
                if (fileName == null || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    throw new InvalidFileNameException();
                }
                response.Clear();
                response.ClearHeaders();
                response.ContentType = "application/zip";
                response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.HtmlEncode(fileName.Replace(Environment.NewLine, "")));
                response.Cache.SetCacheability(HttpCacheability.NoCache);
                var buffer = DirectoryOperationsHelper.ReadAllBytes(zipFilePath);
                response.BinaryWrite(buffer);
            }
            catch (Exception ex)
            {
                _logger.Error("Error while creating zip file. CSV File Name :  " + csvFilePath + ". Message: " + ex.Message + " \n\t Stack Trace:" + ex.StackTrace);
            }
            finally
            {
                try
                {
                    DirectoryOperationsHelper.Delete(csvFilePath);
                }
                catch (Exception exception)
                {
                    _logger.Error("Error while deleting file. Name :  " + csvFilePath + ". Message: " + exception.Message + " \n\t Stack Trace:" + exception.StackTrace);
                }
                response.End();
            }
        }

        protected bool GetResponse<T>(T pub, string queue, string channel) where T : ReportRequestBase
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_redisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();
            var elapsedSeconds = 0;
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(queue, serialisedObject);
            sub.Publish(channel, "");

            var value = string.Empty;
            while (string.IsNullOrEmpty(value))
            {
                elapsedSeconds++;
                value = db.StringGet(pub.Guid);
                if (!string.IsNullOrEmpty(value))
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return value == "Completed";
                }

                Thread.Sleep(1000);
                if (elapsedSeconds == WaitForSeconds)
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return false;
                }
            }
            return true;
        }

    }
}
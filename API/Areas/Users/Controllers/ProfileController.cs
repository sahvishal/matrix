using System;
using System.Linq;
using System.Web.Http;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace API.Areas.Users.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly ISessionContext _sessionContext;
        private readonly IUserProfileService _userProfileService;
        private readonly ILogger _logger;
        private readonly IValidator<ProfileEditModel> _profileEditModelValidator;

        public ProfileController(ISessionContext sessionContext, IUserProfileService userProfileService, ILogManager logManager, IValidator<ProfileEditModel> profileEditModelValidator)
        {
            _sessionContext = sessionContext;
            _userProfileService = userProfileService;
            _logger = logManager.GetLogger<ProfileController>();
            _profileEditModelValidator = profileEditModelValidator;
        }

        [HttpGet]
        public ProfileEditModel Get()
        {
            return _userProfileService.GetProfileEditModel(_sessionContext.UserSession.UserId);
        }

        [HttpPost]
        public ResponseBaseModel Save([FromBody] ProfileEditModel model)
        {
            var result = _profileEditModelValidator.Validate(model);

            var profileBeforUpdation = _userProfileService.GetProfileEditModel(_sessionContext.UserSession.UserId);

            model.DefaultRole = profileBeforUpdation.DefaultRole;

            if (!result.IsValid)
            {
                var firstOrDefault = result.Errors.FirstOrDefault();
                if (firstOrDefault != null)
                    return new ResponseBaseModel { IsSuccess = false, Message = firstOrDefault.ErrorMessage };
            }
            try
            {
                if (string.IsNullOrEmpty(model.Password))
                {
                    model.Password = null;
                    model.ConfirmPassword = null;
                }

                model.DateCreated = DateTime.Now;

                _userProfileService.SaveProfile(model);

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message {0}\n " +
                                            "Stack Trace {1}", exception.Message, exception.StackTrace));
                return new ResponseBaseModel { IsSuccess = false, Message = exception.Message };
            }

            return new ResponseBaseModel { IsSuccess = true, Message = "success" }; ;
        }
    }
}
